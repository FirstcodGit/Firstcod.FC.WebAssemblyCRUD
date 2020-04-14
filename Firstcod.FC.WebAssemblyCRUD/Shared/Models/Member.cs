using System;
using System.Collections.Generic;
using System.Text;

namespace Firstcod.FC.WebAssemblyCRUD.Shared.Models
{
    public class Member
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string Roles { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime CreateDate { get; set; }
        public int StateId { get; set; }
    }
}
