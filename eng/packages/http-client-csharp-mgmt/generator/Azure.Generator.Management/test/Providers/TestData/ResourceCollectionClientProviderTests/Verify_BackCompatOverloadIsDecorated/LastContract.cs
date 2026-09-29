using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;

namespace Samples
{
    public partial class ResponseTypeCollection : ArmCollection
    {
        public virtual global::Azure.Response<global::Samples.ResponseTypeResource> Get(string testName, global::System.Threading.CancellationToken cancellationToken = default) => throw null;
        public virtual global::System.Threading.Tasks.Task<global::Azure.Response<global::Samples.ResponseTypeResource>> GetAsync(string testName, global::System.Threading.CancellationToken cancellationToken = default) => throw null;
    }
}
