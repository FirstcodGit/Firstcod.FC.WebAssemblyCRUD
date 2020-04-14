using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Firstcod.FC.Provider;
using Firstcod.FC.Provider.Models;
using Firstcod.FC.WebAssemblyCRUD.Client.Pages.Customer;
using Firstcod.FC.WebAssemblyCRUD.Server.Connector;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.JSInterop;

namespace Firstcod.FC.WebAssemblyCRUD.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHubContext<HubConnector, IHubConnector> _hub;

        public MembersController(IUnitOfWork unitOfWork, IHubContext<HubConnector, IHubConnector> hub)
        {
            _unitOfWork = unitOfWork;
            _hub = hub;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _unitOfWork.Member.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            return Ok(await _unitOfWork.Member.FindByIdAsync(s => s.Id == id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Shared.Models.Member member)
        {
            try
            {
                MD5 md5 = MD5.Create();
                byte[] byt = System.Text.ASCIIEncoding.ASCII.GetBytes(member.Password);
                byte[] passWord = md5.ComputeHash(byt);

                Member m = new Member()
                {
                    Name = member.Name,
                    LastName = member.LastName,
                    EmailAddress = member.EmailAddress,
                    Password = passWord,
                    UpdateDate = DateTime.Now,
                    CreateDate = DateTime.Now,
                    Roles = "Member",
                    StateId = 1
                };

                _unitOfWork.Member.Add(m);
                await _unitOfWork.SaveChange();

                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] Shared.Models.Member member)
        {
            try
            {
                var query = _unitOfWork.Member.FindById(s => s.Id == id);
                query.Name = member.Name;
                query.LastName = member.LastName;
                query.EmailAddress = member.EmailAddress;
                query.UpdateDate = DateTime.Now;

                _unitOfWork.Member.Update(query);
                await _unitOfWork.SaveChange();

                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                var delete = _unitOfWork.Member.FindById(s => s.Id == id);
                _unitOfWork.Member.Delete(delete);
                await _unitOfWork.SaveChange();

                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
