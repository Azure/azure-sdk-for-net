// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;

[assembly: CodeGenSuppressType("PolicyMetadataData")]

namespace Azure.ResourceManager.PolicyInsights
{
    /// <summary>
    /// A class representing the PolicyMetadata data model.
    /// Policy metadata resource definition.
    /// </summary>
    public partial class PolicyMetadataData : ResourceData
    {
        /// <summary> Initializes a new instance of PolicyMetadataData. </summary>
        internal PolicyMetadataData()
        {
        }

        /// <summary> Initializes a new instance of PolicyMetadataData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="metadataId"> The policy metadata identifier. </param>
        /// <param name="category"> The category of the policy metadata. </param>
        /// <param name="title"> The title of the policy metadata. </param>
        /// <param name="owner"> The owner of the policy metadata. </param>
        /// <param name="additionalContentUri"> Url for getting additional content about the resource metadata. </param>
        /// <param name="additionalContentUriString"> Url for getting additional content about the resource metadata. </param>
        /// <param name="metadata"> Additional metadata. </param>
        /// <param name="description"> The description of the policy metadata. </param>
        /// <param name="requirements"> The requirements of the policy metadata. </param>
        internal PolicyMetadataData(ResourceIdentifier id, string name, ResourceType resourceType, ResourceManager.Models.SystemData systemData, string metadataId, string category, string title, string owner, Uri additionalContentUri, string additionalContentUriString, BinaryData metadata, string description, string requirements) : base(id, name, resourceType, systemData)
        {
            MetadataId = metadataId;
            Category = category;
            Title = title;
            Owner = owner;
            AdditionalContentUri = additionalContentUri;
            AdditionalContentUriString = additionalContentUriString;
            Metadata = metadata;
            Description = description;
            Requirements = requirements;
        }

        /// <summary> The policy metadata identifier. </summary>
        public string MetadataId { get; }
        /// <summary> The category of the policy metadata. </summary>
        public string Category { get; }
        /// <summary> The title of the policy metadata. </summary>
        public string Title { get; }
        /// <summary> The owner of the policy metadata. </summary>
        public string Owner { get; }
        /// <summary> Url for getting additional content about the resource metadata. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Uri AdditionalContentUri { get; }
        /// <summary> Url for getting additional content about the resource metadata. </summary>
#pragma warning disable CA1056 // AdditionalContentUri is not always a real URI
        public string AdditionalContentUriString { get; }
#pragma warning restore CA1056 // AdditionalContentUri is not always a real URI
        /// <summary>
        /// Additional metadata.
        /// <para>
        /// To assign an object to this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
        /// </para>
        /// <para>
        /// To assign an already formated json string to this property use <see cref="BinaryData.FromString(string)"/>.
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
        public BinaryData Metadata { get; }
        /// <summary> The description of the policy metadata. </summary>
        public string Description { get; }
        /// <summary> The requirements of the policy metadata. </summary>
        public string Requirements { get; }
    }
}
