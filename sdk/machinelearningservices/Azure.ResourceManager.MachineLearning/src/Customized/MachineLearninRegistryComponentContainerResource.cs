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
    /// <summary> A class representing a MachineLearninRegistryComponentContainer along with the instance operations that can be performed on it. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("MachineLearninRegistryComponentContainerResource is obsolete and will be removed in a future release. Please use MachineLearningRegistryComponentContainerResource instead.")]
    public partial class MachineLearninRegistryComponentContainerResource : MachineLearningRegistryComponentContainerResource
    {
        /// <summary> Gets the resource type for the operations. </summary>
        public static new readonly ResourceType ResourceType = MachineLearningRegistryComponentContainerResource.ResourceType;

        /// <summary> Initializes a new instance of MachineLearninRegistryComponentContainerResource for mocking. </summary>
        protected MachineLearninRegistryComponentContainerResource()
        {
        }

        internal MachineLearninRegistryComponentContainerResource(ArmClient client, MachineLearningComponentContainerData data) : base(client, data)
        {
        }

        internal MachineLearninRegistryComponentContainerResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        /// <summary> Get container. </summary>
        public new virtual async Task<Response<MachineLearninRegistryComponentContainerResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            Response<MachineLearningRegistryComponentContainerResource> response = await base.GetAsync(cancellationToken).ConfigureAwait(false);
            return Response.FromValue(new MachineLearninRegistryComponentContainerResource(Client, response.Value.Data), response.GetRawResponse());
        }

        /// <summary> Get container. </summary>
        public new virtual Response<MachineLearninRegistryComponentContainerResource> Get(CancellationToken cancellationToken = default)
        {
            Response<MachineLearningRegistryComponentContainerResource> response = base.Get(cancellationToken);
            return Response.FromValue(new MachineLearninRegistryComponentContainerResource(Client, response.Value.Data), response.GetRawResponse());
        }

        /// <summary> Update a MachineLearninRegistryComponentContainer. </summary>
        public new virtual async Task<ArmOperation<MachineLearninRegistryComponentContainerResource>> UpdateAsync(WaitUntil waitUntil, MachineLearningComponentContainerData data, CancellationToken cancellationToken = default)
        {
            ArmOperation<MachineLearningRegistryComponentContainerResource> operation = await base.UpdateAsync(waitUntil, data, cancellationToken).ConfigureAwait(false);
            return new MachineLearninRegistryComponentCompatOperation<MachineLearningRegistryComponentContainerResource, MachineLearninRegistryComponentContainerResource>(operation, ConvertContainerResource);
        }

        /// <summary> Update a MachineLearninRegistryComponentContainer. </summary>
        public new virtual ArmOperation<MachineLearninRegistryComponentContainerResource> Update(WaitUntil waitUntil, MachineLearningComponentContainerData data, CancellationToken cancellationToken = default)
        {
            ArmOperation<MachineLearningRegistryComponentContainerResource> operation = base.Update(waitUntil, data, cancellationToken);
            return new MachineLearninRegistryComponentCompatOperation<MachineLearningRegistryComponentContainerResource, MachineLearninRegistryComponentContainerResource>(operation, ConvertContainerResource);
        }

        // Customized: child-resource accessors are generated from the corrected resource name. Keep the
        // historical MachineLearnin* accessor names because client.tsp cannot create compatibility aliases.
        /// <summary> Gets a collection of MachineLearninRegistryComponentVersionResources in the <see cref="MachineLearninRegistryComponentContainerResource"/>. </summary>
        public virtual MachineLearninRegistryComponentVersionCollection GetMachineLearninRegistryComponentVersions() => new MachineLearninRegistryComponentVersionCollection(Client, Id);
        /// <summary> Gets a registry component version. </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<MachineLearninRegistryComponentVersionResource>> GetMachineLearninRegistryComponentVersionAsync(string version, CancellationToken cancellationToken = default) => GetMachineLearninRegistryComponentVersions().GetAsync(version, cancellationToken);
        /// <summary> Gets a registry component version. </summary>
        [ForwardsClientCalls]
        public virtual Response<MachineLearninRegistryComponentVersionResource> GetMachineLearninRegistryComponentVersion(string version, CancellationToken cancellationToken = default) => GetMachineLearninRegistryComponentVersions().Get(version, cancellationToken);

        private MachineLearninRegistryComponentContainerResource ConvertContainerResource(MachineLearningRegistryComponentContainerResource resource)
        {
            return resource.HasData ? new MachineLearninRegistryComponentContainerResource(Client, resource.Data) : new MachineLearninRegistryComponentContainerResource(Client, resource.Id);
        }
    }
}
