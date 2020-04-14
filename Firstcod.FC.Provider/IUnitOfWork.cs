using Firstcod.FC.Provider.IRepositories;
using System.Threading.Tasks;

namespace Firstcod.FC.Provider
{
    public interface IUnitOfWork
    {
        IMemberRepositories Member { get; }

        Task SaveChange();
    }
}
