using Firstcod.FC.Provider.IRepositories;
using Firstcod.FC.Provider.Repositories;
using System.Threading.Tasks;

namespace Firstcod.FC.Provider
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        IMemberRepositories memberRepositories;

        public IMemberRepositories Member
        {
            get
            {
                if (memberRepositories == null)
                    memberRepositories = new MemberRepositories(_context);

                return memberRepositories;
            }
        }

        public async Task SaveChange()
        {
            await _context.SaveChangesAsync();
        }
    }
}
