// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.MachineLearning
{
    // Customized: the client.tsp resource-name override generates the corrected MachineLearning* resource,
    // while the previously shipped MachineLearnin* resource must remain for compatibility. Inherit the
    // corrected implementation and project invariant operation and response values to the legacy type.
    /// <summary> A class representing a MachineLearninRegistryComponentVersion along with the instance operations that can be performed on it. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("MachineLearninRegistryComponentVersionResource is obsolete and will be removed in a future release. Please use MachineLearningRegistryComponentVersionResource instead.")]
    public partial class MachineLearninRegistryComponentVersionResource : MachineLearningRegistryComponentVersionResource
    {
        /// <summary> Gets the resource type for the operations. </summary>
        public static new readonly ResourceType ResourceType = MachineLearningRegistryComponentVersionResource.ResourceType;

        /// <summary> Initializes a new instance of MachineLearninRegistryComponentVersionResource for mocking. </summary>
        protected MachineLearninRegistryComponentVersionResource()
        {
        }

        internal MachineLearninRegistryComponentVersionResource(ArmClient client, MachineLearningComponentVersionData data) : base(client, data)
        {
        }

        internal MachineLearninRegistryComponentVersionResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        /// <summary> Get version. </summary>
        public new virtual async Task<Response<MachineLearninRegistryComponentVersionResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            Response<MachineLearningRegistryComponentVersionResource> response = await base.GetAsync(cancellationToken).ConfigureAwait(false);
            return Response.FromValue(new MachineLearninRegistryComponentVersionResource(Client, response.Value.Data), response.GetRawResponse());
        }

        /// <summary> Get version. </summary>
        public new virtual Response<MachineLearninRegistryComponentVersionResource> Get(CancellationToken cancellationToken = default)
        {
            Response<MachineLearningRegistryComponentVersionResource> response = base.Get(cancellationToken);
            return Response.FromValue(new MachineLearninRegistryComponentVersionResource(Client, response.Value.Data), response.GetRawResponse());
        }

        /// <summary> Update a MachineLearninRegistryComponentVersion. </summary>
        public new virtual async Task<ArmOperation<MachineLearninRegistryComponentVersionResource>> UpdateAsync(WaitUntil waitUntil, MachineLearningComponentVersionData data, CancellationToken cancellationToken = default)
        {
            ArmOperation<MachineLearningRegistryComponentVersionResource> operation = await base.UpdateAsync(waitUntil, data, cancellationToken).ConfigureAwait(false);
            return new MachineLearninRegistryComponentCompatOperation<MachineLearningRegistryComponentVersionResource, MachineLearninRegistryComponentVersionResource>(operation, ConvertVersionResource);
        }

        /// <summary> Update a MachineLearninRegistryComponentVersion. </summary>
        public new virtual ArmOperation<MachineLearninRegistryComponentVersionResource> Update(WaitUntil waitUntil, MachineLearningComponentVersionData data, CancellationToken cancellationToken = default)
        {
            ArmOperation<MachineLearningRegistryComponentVersionResource> operation = base.Update(waitUntil, data, cancellationToken);
            return new MachineLearninRegistryComponentCompatOperation<MachineLearningRegistryComponentVersionResource, MachineLearninRegistryComponentVersionResource>(operation, ConvertVersionResource);
        }

        private MachineLearninRegistryComponentVersionResource ConvertVersionResource(MachineLearningRegistryComponentVersionResource resource)
        {
            return resource.HasData ? new MachineLearninRegistryComponentVersionResource(Client, resource.Data) : new MachineLearninRegistryComponentVersionResource(Client, resource.Id);
        }
    }
}
