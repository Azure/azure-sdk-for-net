// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Chaos
{
    /// <summary>
    /// A class representing the ChaosTargetType data model.
    /// Model that represents a Target Type resource.
    /// </summary>
    [Obsolete("This class is now deprecated. Please use the new class `ChaosTargetMetadataData` moving forward.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ChaosTargetTypeData : ResourceData
    {
        /// <summary>
        /// Keeps track of any properties unknown to the library.
        /// <para>
        /// To assign an object to the value of this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
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
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="ChaosTargetTypeData"/>. </summary>
        public ChaosTargetTypeData()
        {
            ResourceTypes = new ChangeTrackingList<string>();
        }

        /// <summary> Initializes a new instance of <see cref="ChaosTargetTypeData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="location"> Location of the Target Type resource. </param>
        /// <param name="displayName"> Localized string of the display name. </param>
        /// <param name="description"> Localized string of the description. </param>
        /// <param name="propertiesSchema"> URL to retrieve JSON schema of the Target Type properties. </param>
        /// <param name="resourceTypes"> List of resource types this Target Type can extend. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal ChaosTargetTypeData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, AzureLocation? location, string displayName, string description, string propertiesSchema, IReadOnlyList<string> resourceTypes, IDictionary<string, BinaryData> serializedAdditionalRawData) : base(id, name, resourceType, systemData)
        {
            Location = location;
            DisplayName = displayName;
            Description = description;
            PropertiesSchema = propertiesSchema;
            ResourceTypes = resourceTypes;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Location of the Target Type resource. </summary>
        public AzureLocation? Location { get; set; }
        /// <summary> Localized string of the display name. </summary>
        public string DisplayName { get; }
        /// <summary> Localized string of the description. </summary>
        public string Description { get; }
        /// <summary> URL to retrieve JSON schema of the Target Type properties. </summary>
        public string PropertiesSchema { get; }
        /// <summary> List of resource types this Target Type can extend. </summary>
        public IReadOnlyList<string> ResourceTypes { get; }
    }
}
