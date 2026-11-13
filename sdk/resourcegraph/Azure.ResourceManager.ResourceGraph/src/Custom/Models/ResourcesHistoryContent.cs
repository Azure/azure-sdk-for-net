// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.ResourceGraph.Models
{
    /// <summary> Describes a history request to be executed. </summary>
    public partial class ResourcesHistoryContent
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

        /// <summary> Initializes a new instance of <see cref="ResourcesHistoryContent"/>. </summary>
        public ResourcesHistoryContent()
        {
            Subscriptions = new ChangeTrackingList<string>();
            ManagementGroups = new ChangeTrackingList<string>();
        }

        /// <summary> Initializes a new instance of <see cref="ResourcesHistoryContent"/>. </summary>
        /// <param name="subscriptions"> Azure subscriptions against which to execute the query. </param>
        /// <param name="query"> The resources query. </param>
        /// <param name="options"> The history request evaluation options. </param>
        /// <param name="managementGroups"> Azure management groups against which to execute the query. Example: [ 'mg1', 'mg2' ]. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal ResourcesHistoryContent(IList<string> subscriptions, string query, ResourcesHistoryRequestOptions options, IList<string> managementGroups, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Subscriptions = subscriptions;
            Query = query;
            Options = options;
            ManagementGroups = managementGroups;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Azure subscriptions against which to execute the query. </summary>
        public IList<string> Subscriptions { get; }
        /// <summary> The resources query. </summary>
        public string Query { get; set; }
        /// <summary> The history request evaluation options. </summary>
        public ResourcesHistoryRequestOptions Options { get; set; }
        /// <summary> Azure management groups against which to execute the query. Example: [ 'mg1', 'mg2' ]. </summary>
        public IList<string> ManagementGroups { get; }
    }
}
