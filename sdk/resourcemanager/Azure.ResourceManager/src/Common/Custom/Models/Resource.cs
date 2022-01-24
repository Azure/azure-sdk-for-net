// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager.Core;

[assembly: CodeGenSuppressType("Resource")]
namespace Azure.ResourceManager.Models
{
    /// <summary> Common fields that are returned in the response for all Azure Resource Manager resources. </summary>
    [ReferenceType(new string[]{"SystemData"})]
    public abstract partial class Resource
    {
        /// <summary> Initializes a new instance of Resource. </summary>
        [InitializationConstructor]
        protected Resource()
        {
        }

        /// <summary> Initializes a new instance of Resource. </summary>
        /// <param name="id"> Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}. </param>
        /// <param name="name"> The name of the resource. </param>
        /// <param name="type"> The type of the resource. E.g. &quot;Microsoft.Compute/virtualMachines&quot; or &quot;Microsoft.Storage/storageAccounts&quot;. </param>
        /// <param name="systemData"> Azure Resource Manager metadata containing createdBy and modifiedBy information. </param>
        [SerializationConstructor]
        protected Resource(ResourceIdentifier id, string name, ResourceType type, SystemData systemData)
        {
            Id = id;
            Name = name;
            Type = type;
            SystemData = systemData;
        }

        /// <summary> Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}. </summary>
        public ResourceIdentifier Id { get; }
        /// <summary> The name of the resource. </summary>
        public string Name { get; }
        /// <summary> The type of the resource. E.g. &quot;Microsoft.Compute/virtualMachines&quot; or &quot;Microsoft.Storage/storageAccounts&quot;. </summary>
        public ResourceType Type { get; }
        /// <summary> Azure Resource Manager metadata containing createdBy and modifiedBy information. </summary>
        public SystemData SystemData { get; }
    }
}
