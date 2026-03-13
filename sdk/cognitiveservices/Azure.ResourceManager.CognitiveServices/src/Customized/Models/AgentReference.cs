// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Customized copy of generated code excluded from compilation to work around TypeSpec migration compile errors.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.CognitiveServices.Models
{
    /// <summary> Agent Reference resource. </summary>
    public partial class AgentReference : ResourceData
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private protected readonly IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        /// <summary> Initializes a new instance of <see cref="AgentReference"/>. </summary>
        /// <param name="properties"> [Required] Additional attributes of the entity. </param>
        internal AgentReference(AgentReferenceProperties properties)
        {
            Properties = properties;
        }

        /// <summary> Initializes a new instance of <see cref="AgentReference"/>. </summary>
        /// <param name="id"> Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}. </param>
        /// <param name="name"> The name of the resource. </param>
        /// <param name="resourceType"> The type of the resource. E.g. "Microsoft.Compute/virtualMachines" or "Microsoft.Storage/storageAccounts". </param>
        /// <param name="systemData"> Azure Resource Manager metadata containing createdBy and modifiedBy information. </param>
        /// <param name="additionalBinaryDataProperties"> Keeps track of any properties unknown to the library. </param>
        /// <param name="properties"> [Required] Additional attributes of the entity. </param>
        internal AgentReference(string id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, BinaryData> additionalBinaryDataProperties, AgentReferenceProperties properties) : base(id is null ? null : new ResourceIdentifier(id), name, resourceType, systemData)
        {
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
            Properties = properties;
        }

        /// <summary> [Required] Additional attributes of the entity. </summary>
        public AgentReferenceProperties Properties { get; }
    }
}
