// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

// The Id of content type does not meet the criteria of ResourceIdentifier.
// Therefore we suppress the generation of ApiManagementContentType to stop it from inheriting ResourceData.
// This customization can be removed once we support no type replacement of inheritance in generator.
[assembly: CodeGenSuppressType("ApiManagementContentType")]
namespace Azure.ResourceManager.ApiManagement.Models
{
    /// <summary> Content type contract details. </summary>
    public partial class ApiManagementContentType
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="ApiManagementContentType"/>. </summary>
        public ApiManagementContentType()
        {
        }

        /// <summary> Initializes a new instance of <see cref="ApiManagementContentType"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="contentTypeIdentifier"> Content type identifier. </param>
        /// <param name="contentTypeName"> Content type name. Must be 1 to 250 characters long. </param>
        /// <param name="description"> Content type description. </param>
        /// <param name="schema"> Content type schema. </param>
        /// <param name="version"> Content type version. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal ApiManagementContentType(string id, string name, ResourceType resourceType, string contentTypeIdentifier, string contentTypeName, string description, BinaryData schema, string version, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            ContentTypeId = id;
            Name = name;
            ResourceType = resourceType;
            ContentTypeIdentifier = contentTypeIdentifier;
            ContentTypeName = contentTypeName;
            Description = description;
            Schema = schema;
            Version = version;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Content Type ID. </summary>
        public string ContentTypeId { get; }
        /// <summary> The name of the resource. </summary>
        public string Name { get; }
        /// <summary> The type of the resource. E.g. &quot;Microsoft.Compute/virtualMachines&quot; or &quot;Microsoft.Storage/storageAccounts&quot;. </summary>
        public ResourceType ResourceType { get; }
        /// <summary> Content type identifier. </summary>
        public string ContentTypeIdentifier { get; set; }
        /// <summary> Content type name. Must be 1 to 250 characters long. </summary>
        public string ContentTypeName { get; set; }
        /// <summary> Content type description. </summary>
        public string Description { get; set; }
        /// <summary>
        /// Content type schema.
        /// <para>
        /// To assign an object to this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
        /// </para>
        /// <para>
        /// To assign an already formatted json string to this property use <see cref="BinaryData.FromString(string)"/>.
        /// </para>
        /// <para>
        /// Examples:
        /// <list type="bullet">
        /// <item>
        /// <term>BinaryData.FromObjectAsJson("foo")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("\"foo\"")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromObjectAsJson(new { key = "value" })</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("{\"key\": \"value\"}")</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        public BinaryData Schema { get; set; }
        /// <summary> Content type version. </summary>
        public string Version { get; set; }
    }
}
