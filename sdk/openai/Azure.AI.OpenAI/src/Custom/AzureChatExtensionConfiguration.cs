// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.AI.OpenAI
{
    public partial class AzureChatExtensionConfiguration
    {
        // CUSTOM CODE NOTE: required properties are moved here to support an init-only default constructor pattern.

        /// <summary> Initializes a new instance of AzureChatExtensionConfiguration. </summary>
        public AzureChatExtensionConfiguration()
        {
        }

        /// <summary>
        ///   The label for the type of an Azure chat extension. This typically corresponds to a matching Azure resource.
        ///   Azure chat extensions are only compatible with Azure OpenAI.
        /// </summary>
        public virtual AzureChatExtensionType Type { get; set; }
        /// <summary>
        ///   The configuration payload used for the Azure chat extension. The structure payload details are specific to the
        ///   extension being configured.
        ///   Azure chat extensions are only compatible with Azure OpenAI.
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
        public BinaryData Parameters { get; set; }
    }
}
