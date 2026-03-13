// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Customized copy of generated code excluded from compilation to work around TypeSpec migration compile errors.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.CognitiveServices.Models;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.CognitiveServices
{
    /// <summary> Cognitive Services Rai External Safety provider Schema. </summary>
    public partial class RaiExternalSafetyProviderSchemaData : ResourceData
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private protected readonly IDictionary<string, BinaryData> _additionalBinaryDataProperties;

        /// <summary> Initializes a new instance of <see cref="RaiExternalSafetyProviderSchemaData"/>. </summary>
        public RaiExternalSafetyProviderSchemaData()
        {
            Tags = new ChangeTrackingDictionary<string, string>();
        }

        /// <summary> Initializes a new instance of <see cref="RaiExternalSafetyProviderSchemaData"/>. </summary>
        /// <param name="id"> Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}. </param>
        /// <param name="name"> The name of the resource. </param>
        /// <param name="resourceType"> The type of the resource. E.g. "Microsoft.Compute/virtualMachines" or "Microsoft.Storage/storageAccounts". </param>
        /// <param name="systemData"> Azure Resource Manager metadata containing createdBy and modifiedBy information. </param>
        /// <param name="additionalBinaryDataProperties"> Keeps track of any properties unknown to the library. </param>
        /// <param name="properties"> Properties of Cognitive Services Rai External Safety provider. </param>
        /// <param name="eTag"> Resource Etag. </param>
        /// <param name="tags"> Resource tags. </param>
        internal RaiExternalSafetyProviderSchemaData(string id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, BinaryData> additionalBinaryDataProperties, RaiExternalSafetyProviderSchemaProperties properties, string eTag, IDictionary<string, string> tags) : base(id is null ? null : new ResourceIdentifier(id), name, resourceType, systemData)
        {
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
            Properties = properties;
            ETag = eTag;
            Tags = tags;
        }

        internal RaiExternalSafetyProviderSchemaData(string id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, BinaryData> additionalBinaryDataProperties, RaiExternalSafetyProviderSchemaProperties properties, string eTag, IReadOnlyDictionary<string, string> tags)
            : this(id, name, resourceType, systemData, additionalBinaryDataProperties, properties, eTag, ToMutableTags(tags))
        {
        }

        private static IDictionary<string, string> ToMutableTags(IReadOnlyDictionary<string, string> tags)
        {
            return tags is null ? null : new ChangeTrackingDictionary<string, string>(tags);
        }

        /// <summary> Properties of Cognitive Services Rai External Safety provider. </summary>
        public RaiExternalSafetyProviderSchemaProperties Properties { get; set; }

        /// <summary> Resource Etag. </summary>
        public string ETag { get; }

        /// <summary> Resource tags. </summary>
        public IDictionary<string, string> Tags { get; }
    }
}
