// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

[assembly: CodeGenSuppressType("ArmResourceData")]
namespace Azure.ResourceManager.Models
{
    /// <summary> Common fields that are returned in the response for all Azure Resource Manager resources. </summary>
    [ReferenceType(new string[]{"SystemData"})]
    public abstract partial class ResourceData
    {
        /// <summary> Initializes a new instance of Resource. </summary>
        [InitializationConstructor]
        protected ResourceData()
        {
        }

        /// <summary> Initializes a new instance of Resource. </summary>
        /// <param name="id"> Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}. </param>
        /// <param name="name"> The name of the resource. </param>
        /// <param name="resourceType"> The type of the resource. E.g. &quot;Microsoft.Compute/virtualMachines&quot; or &quot;Microsoft.Storage/storageAccounts&quot;. </param>
        /// <param name="systemData"> Azure Resource Manager metadata containing createdBy and modifiedBy information. </param>
        [SerializationConstructor]
        protected ResourceData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData)
        {
            Id = id;
            Name = name;
            ResourceType = resourceType;
            SystemData = systemData;
        }

        /// <summary> Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}. </summary>
        public ResourceIdentifier Id { get; private set; }
        /// <summary> The name of the resource. </summary>
        public string Name { get; private set;}
        /// <summary> The type of the resource. E.g. &quot;Microsoft.Compute/virtualMachines&quot; or &quot;Microsoft.Storage/storageAccounts&quot;. </summary>
        public ResourceType ResourceType { get; private set;}
        /// <summary> Azure Resource Manager metadata containing createdBy and modifiedBy information. </summary>
        public SystemData SystemData { get; private set;}

        /// <summary> Deserializes a <see cref="JsonElement"/> to an instance of <see cref="ResourceData"/>. </summary>
#pragma warning disable AZC0014 // Types from System.Text.Json, Newtonsoft.Json, System.Collections.Immutable assemblies should not be exposed as part of public API surface.
        protected virtual void Deserialize(JsonElement element)
#pragma warning restore AZC0014 // Types from System.Text.Json, Newtonsoft.Json, System.Collections.Immutable assemblies should not be exposed as part of public API surface.
        {
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"))
                {
                    Id = new ResourceIdentifier(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("name"))
                {
                    Name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("type"))
                {
                    ResourceType = new ResourceType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("systemData"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    SystemData = JsonSerializer.Deserialize<SystemData>(property.Value.GetRawText());
                    continue;
                }
            }
        }
    }
}
