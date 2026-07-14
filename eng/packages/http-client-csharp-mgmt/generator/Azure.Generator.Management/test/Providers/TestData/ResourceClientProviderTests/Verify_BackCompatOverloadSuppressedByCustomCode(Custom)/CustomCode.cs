using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;

namespace Samples
{
    // Simulates a hand-written back-compat overload preserving the previous method signature
    // (Get/GetAsync taking only a CancellationToken). Because it matches the previous contract's
    // signature, the generator must NOT synthesize a duplicate back-compat overload.
    public partial class ResponseTypeResource : ArmResource
    {
        public virtual global::Azure.Response<global::Samples.ResponseTypeResource> Get(global::System.Threading.CancellationToken cancellationToken = default) => throw null;
        public virtual global::System.Threading.Tasks.Task<global::Azure.Response<global::Samples.ResponseTypeResource>> GetAsync(global::System.Threading.CancellationToken cancellationToken = default) => throw null;
    }
}
