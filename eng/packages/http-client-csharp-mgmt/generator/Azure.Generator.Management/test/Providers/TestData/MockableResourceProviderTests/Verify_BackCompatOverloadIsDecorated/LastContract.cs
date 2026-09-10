
using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;

namespace Samples.Mocking
{
    public partial class MockableSamplesArmClient : ArmResource
    {
        public virtual global::Azure.Pageable<global::Samples.EventResource> GetEvents(global::Azure.Core.ResourceIdentifier scope, global::System.Threading.CancellationToken cancellationToken = default) => throw null;
        public virtual global::Azure.AsyncPageable<global::Samples.EventResource> GetEventsAsync(global::Azure.Core.ResourceIdentifier scope, global::System.Threading.CancellationToken cancellationToken = default) => throw null;
    }
}
