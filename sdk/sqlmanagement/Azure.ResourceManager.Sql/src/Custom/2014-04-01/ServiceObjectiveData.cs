// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Sql
{
    /// <summary>
    /// A class representing the ServiceObjective data model.
    /// Represents a database service objective.
    /// </summary>
    [Obsolete("This class is deprecated and will be removed in a future release.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ServiceObjectiveData : ResourceData
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

        /// <summary> Initializes a new instance of <see cref="ServiceObjectiveData"/>. </summary>
        public ServiceObjectiveData()
        {
        }

        /// <summary> Initializes a new instance of <see cref="ServiceObjectiveData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="serviceObjectiveName"> The name for the service objective. </param>
        /// <param name="isDefault"> Gets whether the service level objective is the default service objective. </param>
        /// <param name="isSystem"> Gets whether the service level objective is a system service objective. </param>
        /// <param name="description"> The description for the service level objective. </param>
        /// <param name="isEnabled"> Gets whether the service level objective is enabled. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal ServiceObjectiveData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, string serviceObjectiveName, bool? isDefault, bool? isSystem, string description, bool? isEnabled, IDictionary<string, BinaryData> serializedAdditionalRawData) : base(id, name, resourceType, systemData)
        {
            ServiceObjectiveName = serviceObjectiveName;
            IsDefault = isDefault;
            IsSystem = isSystem;
            Description = description;
            IsEnabled = isEnabled;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> The name for the service objective. </summary>
        [WirePath("properties.serviceObjectiveName")]
        public string ServiceObjectiveName { get; }
        /// <summary> Gets whether the service level objective is the default service objective. </summary>
        [WirePath("properties.isDefault")]
        public bool? IsDefault { get; }
        /// <summary> Gets whether the service level objective is a system service objective. </summary>
        [WirePath("properties.isSystem")]
        public bool? IsSystem { get; }
        /// <summary> The description for the service level objective. </summary>
        [WirePath("properties.description")]
        public string Description { get; }
        /// <summary> Gets whether the service level objective is enabled. </summary>
        [WirePath("properties.enabled")]
        public bool? IsEnabled { get; }
    }
}
