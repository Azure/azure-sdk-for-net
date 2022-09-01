// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

// The Id of content item does not meet the criteria of ResourceIdentifier.
// Therefore we suppress the generation of ApiManagementContentItem to stop it from inheriting ResourceData.
// This customization can be removed once we support no type replacement of inheritance in generator.
[assembly: CodeGenSuppressType("ApiManagementContentItem")]
namespace Azure.ResourceManager.ApiManagement.Models
{
    /// <summary> Content type contract details. </summary>
    public partial class ApiManagementContentItem
    {
        /// <summary> Initializes a new instance of ApiManagementContentItem. </summary>
        public ApiManagementContentItem()
        {
            Properties = new ChangeTrackingDictionary<string, BinaryData>();
        }

        /// <summary> Initializes a new instance of ApiManagementContentItem. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="properties"> Properties of the content item. </param>
        internal ApiManagementContentItem(string id, string name, ResourceType resourceType, IDictionary<string, BinaryData> properties)
        {
            ContentItemId = id;
            Name = name;
            ResourceType = resourceType;
            Properties = properties;
        }

        /// <summary> Content Item ID. </summary>
        public string ContentItemId { get; }
        /// <summary> The name of the resource. </summary>
        public string Name { get; }
        /// <summary> The type of the resource. E.g. &quot;Microsoft.Compute/virtualMachines&quot; or &quot;Microsoft.Storage/storageAccounts&quot;. </summary>
        public ResourceType ResourceType { get; }
        /// <summary> Properties of the content item. </summary>
        public IDictionary<string, BinaryData> Properties { get; }
    }
}
