// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.MySql.Models
{
    /// <summary> Represents a server to be created. </summary>
    public partial class MySqlServerCreateOrUpdateContent
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

        /// <summary> Initializes a new instance of <see cref="MySqlServerCreateOrUpdateContent"/>. </summary>
        /// <param name="properties">
        /// Properties of the server.
        /// Please note <see cref="MySqlServerPropertiesForCreate"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="MySqlServerPropertiesForDefaultCreate"/>, <see cref="MySqlServerPropertiesForGeoRestore"/>, <see cref="MySqlServerPropertiesForRestore"/> and <see cref="MySqlServerPropertiesForReplica"/>.
        /// </param>
        /// <param name="location"> The location the resource resides in. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="properties"/> is null. </exception>
        public MySqlServerCreateOrUpdateContent(MySqlServerPropertiesForCreate properties, AzureLocation location)
        {
            Argument.AssertNotNull(properties, nameof(properties));

            Properties = properties;
            Location = location;
            Tags = new ChangeTrackingDictionary<string, string>();
        }

        /// <summary> Initializes a new instance of <see cref="MySqlServerCreateOrUpdateContent"/>. </summary>
        /// <param name="identity"> The Azure Active Directory identity of the server. Current supported identity types: SystemAssigned. </param>
        /// <param name="sku"> The SKU (pricing tier) of the server. </param>
        /// <param name="properties">
        /// Properties of the server.
        /// Please note <see cref="MySqlServerPropertiesForCreate"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="MySqlServerPropertiesForDefaultCreate"/>, <see cref="MySqlServerPropertiesForGeoRestore"/>, <see cref="MySqlServerPropertiesForRestore"/> and <see cref="MySqlServerPropertiesForReplica"/>.
        /// </param>
        /// <param name="location"> The location the resource resides in. </param>
        /// <param name="tags"> Application-specific metadata in the form of key-value pairs. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal MySqlServerCreateOrUpdateContent(ManagedServiceIdentity identity, MySqlSku sku, MySqlServerPropertiesForCreate properties, AzureLocation location, IDictionary<string, string> tags, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Identity = identity;
            Sku = sku;
            Properties = properties;
            Location = location;
            Tags = tags;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="MySqlServerCreateOrUpdateContent"/> for deserialization. </summary>
        internal MySqlServerCreateOrUpdateContent()
        {
        }

        /// <summary> The Azure Active Directory identity of the server. Current supported identity types: SystemAssigned. </summary>
        public ManagedServiceIdentity Identity { get; set; }
        /// <summary> The SKU (pricing tier) of the server. </summary>
        public MySqlSku Sku { get; set; }
        /// <summary>
        /// Properties of the server.
        /// Please note <see cref="MySqlServerPropertiesForCreate"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="MySqlServerPropertiesForDefaultCreate"/>, <see cref="MySqlServerPropertiesForGeoRestore"/>, <see cref="MySqlServerPropertiesForRestore"/> and <see cref="MySqlServerPropertiesForReplica"/>.
        /// </summary>
        public MySqlServerPropertiesForCreate Properties { get; }
        /// <summary> The location the resource resides in. </summary>
        public AzureLocation Location { get; }
        /// <summary> Application-specific metadata in the form of key-value pairs. </summary>
        public IDictionary<string, string> Tags { get; }
    }
}