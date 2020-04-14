
namespace Firstcod.FC.Provider
{
    public class HttpUnitOfWork : UnitOfWork
    {
        public HttpUnitOfWork(ApplicationDbContext context)
            : base(context) { }
    }
}
