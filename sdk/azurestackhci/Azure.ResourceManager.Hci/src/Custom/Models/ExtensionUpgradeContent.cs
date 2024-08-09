// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.Hci.Models
{
    /// <summary> Describes the parameters for Extension upgrade. </summary>
    [Obsolete("This class is now deprecated. Please use the new class `ArcExtensionUpgradeContent` moving forward.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ExtensionUpgradeContent
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

        /// <summary> Initializes a new instance of <see cref="ExtensionUpgradeContent"/>. </summary>
        public ExtensionUpgradeContent()
        {
        }

        /// <summary> Initializes a new instance of <see cref="ExtensionUpgradeContent"/>. </summary>
        /// <param name="targetVersion"> Extension Upgrade Target Version. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal ExtensionUpgradeContent(string targetVersion, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            TargetVersion = targetVersion;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Extension Upgrade Target Version. </summary>
        public string TargetVersion { get; set; }
    }
}
