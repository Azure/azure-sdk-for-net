// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Customized copy of generated code excluded from compilation to work around TypeSpec migration compile errors.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.CognitiveServices.Models;
using Azure.ResourceManager.Models;
using ArmManagedServiceIdentity = Azure.ResourceManager.Models.ManagedServiceIdentity;
using ArmManagedServiceIdentityType = Azure.ResourceManager.Models.ManagedServiceIdentityType;
using ArmUserAssignedIdentity = Azure.ResourceManager.Models.UserAssignedIdentity;
using CognitiveUserAssignedIdentity = Azure.ResourceManager.CognitiveServices.Models.UserAssignedIdentity;

namespace Azure.ResourceManager.CognitiveServices
{
    /// <summary> Cognitive Services project is an Azure resource representing the provisioned account's project, it's type, location and SKU. </summary>
    public partial class CognitiveServicesProjectData : ResourceData
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private protected readonly IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        /// <summary> Initializes a new instance of <see cref="CognitiveServicesProjectData"/>. </summary>
        public CognitiveServicesProjectData()
        {
            Tags = new ChangeTrackingDictionary<string, string>();
        }

        /// <summary> Initializes a new instance of <see cref="CognitiveServicesProjectData"/>. </summary>
        /// <param name="id"> Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}. </param>
        /// <param name="name"> The name of the resource. </param>
        /// <param name="resourceType"> The type of the resource. E.g. "Microsoft.Compute/virtualMachines" or "Microsoft.Storage/storageAccounts". </param>
        /// <param name="systemData"> Azure Resource Manager metadata containing createdBy and modifiedBy information. </param>
        /// <param name="additionalBinaryDataProperties"> Keeps track of any properties unknown to the library. </param>
        /// <param name="properties"> Properties of Cognitive Services project. </param>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="location"> The geo-location where the resource lives. </param>
        /// <param name="eTag"> Resource Etag. </param>
        /// <param name="identity"> Identity for the resource. </param>
        internal CognitiveServicesProjectData(string id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, BinaryData> additionalBinaryDataProperties, CognitiveServicesProjectProperties properties, IDictionary<string, string> tags, string location, string eTag, Identity identity) : base(id is null ? null : new ResourceIdentifier(id), name, resourceType, systemData)
        {
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
            Properties = properties;
            Tags = tags;
            Location = location;
            ETag = eTag;
            Identity = identity;
        }

        internal CognitiveServicesProjectData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, BinaryData> additionalBinaryDataProperties, CognitiveServicesProjectProperties properties, IDictionary<string, string> tags, string location, string eTag, ArmManagedServiceIdentity identity)
            : this(id?.ToString(), name, resourceType, systemData, additionalBinaryDataProperties, properties, tags, location, eTag, ConvertIdentity(identity))
        {
        }

        private static Identity ConvertIdentity(ArmManagedServiceIdentity identity)
        {
            if (identity is null)
            {
                return null;
            }

            IDictionary<string, CognitiveUserAssignedIdentity> userAssignedIdentities = new ChangeTrackingDictionary<string, CognitiveUserAssignedIdentity>();
            if (identity.UserAssignedIdentities is not null)
            {
                foreach (KeyValuePair<ResourceIdentifier, ArmUserAssignedIdentity> item in identity.UserAssignedIdentities)
                {
                    userAssignedIdentities[item.Key.ToString()] = item.Value is null
                        ? new CognitiveUserAssignedIdentity()
                        : new CognitiveUserAssignedIdentity(item.Value.PrincipalId?.ToString(), item.Value.ClientId?.ToString(), new ChangeTrackingDictionary<string, BinaryData>());
                }
            }

            return new Identity(ConvertIdentityType(identity.ManagedServiceIdentityType), identity.TenantId?.ToString(), identity.PrincipalId?.ToString(), userAssignedIdentities, new ChangeTrackingDictionary<string, BinaryData>());
        }

        private static ResourceIdentityType? ConvertIdentityType(ArmManagedServiceIdentityType identityType)
        {
            string value = identityType.ToString();
            if (string.IsNullOrEmpty(value))
            {
                return default;
            }
            if (value.Contains("SystemAssigned", StringComparison.Ordinal) && value.Contains("UserAssigned", StringComparison.Ordinal))
            {
                return ResourceIdentityType.SystemAssignedUserAssigned;
            }
            if (value.Contains("SystemAssigned", StringComparison.Ordinal))
            {
                return ResourceIdentityType.SystemAssigned;
            }
            if (value.Contains("UserAssigned", StringComparison.Ordinal))
            {
                return ResourceIdentityType.UserAssigned;
            }
            return ResourceIdentityType.None;
        }

        /// <summary> Properties of Cognitive Services project. </summary>
        public CognitiveServicesProjectProperties Properties { get; set; }

        /// <summary> Resource tags. </summary>
        public IDictionary<string, string> Tags { get; }

        /// <summary> The geo-location where the resource lives. </summary>
        public string Location { get; set; }

        /// <summary> Resource Etag. </summary>
        public string ETag { get; }

        /// <summary> Identity for the resource. </summary>
        public Identity Identity { get; set; }
    }
}
