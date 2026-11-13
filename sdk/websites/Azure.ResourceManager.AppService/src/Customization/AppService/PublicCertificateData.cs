// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.AppService.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.AppService
{
    [CodeGenSuppress("Blob")]
    public partial class PublicCertificateData
    {
        // GA shipped byte[] for this blob property; TypeSpec `bytes` now emits as BinaryData.
        // Restore byte[] for backward compatibility by converting on access.
        /// <summary> Public Certificate byte array. </summary>
        [WirePath("properties.blob")]
        public byte[] Blob
        {
            get => Properties is null ? null : Properties.Blob?.ToArray();
            set
            {
                if (Properties is null)
                {
                    Properties = new PublicCertificateProperties();
                }
                Properties.Blob = value is null ? null : BinaryData.FromBytes(value);
            }
        }

        /// <summary>
        /// Certificate Thumbprint
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
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and will be removed in a future release. Please use `ThumbprintString` instead.", false)]
        public BinaryData Thumbprint => BinaryData.FromString(ThumbprintString);
    }
}
