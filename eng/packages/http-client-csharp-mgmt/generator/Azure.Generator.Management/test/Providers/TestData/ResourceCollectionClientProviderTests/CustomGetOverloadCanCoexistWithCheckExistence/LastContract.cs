using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.ResourceManager;

namespace Samples
{
    public partial class ResponseTypeCollection : ArmCollection
    {
        public virtual Response<bool> Exists(string testName, string expand = null, CancellationToken cancellationToken = default) => throw null;
        public virtual Task<Response<bool>> ExistsAsync(string testName, string expand = null, CancellationToken cancellationToken = default) => throw null;
    }
}
