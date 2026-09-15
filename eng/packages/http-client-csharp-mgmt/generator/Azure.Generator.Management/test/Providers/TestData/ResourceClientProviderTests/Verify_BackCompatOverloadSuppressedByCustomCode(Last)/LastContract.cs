using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;

namespace Samples
{
    public partial class ResponseTypeResource : ArmResource
    {
        public virtual global::Azure.Response<ResponseTypeResource> Get(global::System.Threading.CancellationToken cancellationToken = default) => throw null;
        public virtual global::System.Threading.Tasks.Task<global::Azure.Response<ResponseTypeResource>> GetAsync(global::System.Threading.CancellationToken cancellationToken = default) => throw null;
    }
}
