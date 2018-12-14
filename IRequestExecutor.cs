using Refit;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Camunda
{
    public interface IRequestExecutor
    {

        [Post("/fetchAndLock")]
        Task<List<ExternalTask>> FetchAndLock([Body] FetchAndLockRequestDto fetch);

        [Post("/{id}/complete")]
        Task Complete(string id, [Body] CompleteExternalTask complete);
    }
}