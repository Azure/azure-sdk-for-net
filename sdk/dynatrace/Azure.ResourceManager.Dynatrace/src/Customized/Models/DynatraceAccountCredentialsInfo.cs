// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.Dynatrace.Models
{
    /// <summary> Dynatrace account API Key. </summary>
    // Add this model due to the api compatibility for operation: Monitors_GetAccountCredentials.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class DynatraceAccountCredentialsInfo
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

        /// <summary> Initializes a new instance of <see cref="DynatraceAccountCredentialsInfo"/>. </summary>
        internal DynatraceAccountCredentialsInfo()
        {
        }

        /// <summary> Initializes a new instance of <see cref="DynatraceAccountCredentialsInfo"/>. </summary>
        /// <param name="accountId"> Account Id of the account this environment is linked to. </param>
        /// <param name="apiKey"> API Key of the user account. </param>
        /// <param name="regionId"> Region in which the account is created. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal DynatraceAccountCredentialsInfo(string accountId, string apiKey, string regionId, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            AccountId = accountId;
            ApiKey = apiKey;
            RegionId = regionId;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Account Id of the account this environment is linked to. </summary>
        public string AccountId { get; }
        /// <summary> API Key of the user account. </summary>
        public string ApiKey { get; }
        /// <summary> Region in which the account is created. </summary>
        public string RegionId { get; }
    }
}
