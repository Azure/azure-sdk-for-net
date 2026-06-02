// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;

namespace Azure.ResourceManager.ComputeBulkActions
{
    /// <summary>
    /// A class representing a collection of <see cref="BulkActionResource"/> and their operations.
    /// </summary>
    public partial class BulkActionCollection
    {
        /// <summary> Initializes a new instance of <see cref="BulkActionCollection"/> class with a location. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        /// <param name="location"> The location for the resource. </param>
        internal BulkActionCollection(ArmClient client, ResourceIdentifier id, AzureLocation location) : base(client, id)
        {
            this.TryGetApiVersion(BulkActionResource.ResourceType, out string bulkActionApiVersion);
            _bulkActionsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.ComputeBulkActions", BulkActionResource.ResourceType.Namespace, Diagnostics);
            _bulkActionsRestClient = new BulkActions(_bulkActionsClientDiagnostics, Pipeline, Endpoint, bulkActionApiVersion ?? "2026-02-01-preview");
            _location = location;
        }
    }
}
