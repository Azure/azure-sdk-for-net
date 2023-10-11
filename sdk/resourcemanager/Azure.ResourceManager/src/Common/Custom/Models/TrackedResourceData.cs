// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

[assembly: CodeGenSuppressType("TrackedResource")]
namespace Azure.ResourceManager.Models
{
    /// <summary> The resource model definition for an Azure Resource Manager tracked top level resource which has &apos;tags&apos; and a &apos;location&apos;. </summary>
    [ReferenceType(new string[]{"SystemData"})]
    public abstract partial class TrackedResourceData : ResourceData
    {
        /// <summary> Initializes a new instance of TrackedResource. </summary>
        /// <param name="location"> The geo-location where the resource lives. </param>
        [InitializationConstructor]
        protected TrackedResourceData(AzureLocation location)
        {
            Tags = new ChangeTrackingDictionary<string, string>();
            Location = location;
        }

        /// <summary> Initializes a new instance of TrackedResource. </summary>
        /// <param name="id"> Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}. </param>
        /// <param name="name"> The name of the resource. </param>
        /// <param name="resourceType"> The type of the resource. E.g. &quot;Microsoft.Compute/virtualMachines&quot; or &quot;Microsoft.Storage/storageAccounts&quot;. </param>
        /// <param name="systemData"> Azure Resource Manager metadata containing createdBy and modifiedBy information. </param>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="location"> The geo-location where the resource lives. </param>
        [SerializationConstructor]
        protected TrackedResourceData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location) : base(id, name, resourceType, systemData)
        {
            Tags = tags;
            Location = location;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="TrackedResourceData"/> for deserialization.
        /// </summary>
        protected TrackedResourceData()
        {
        }

        /// <summary> Resource tags. </summary>
        public IDictionary<string, string> Tags { get; }
        /// <summary> The geo-location where the resource lives. </summary>
        public AzureLocation Location { get; set; }
    }
}
