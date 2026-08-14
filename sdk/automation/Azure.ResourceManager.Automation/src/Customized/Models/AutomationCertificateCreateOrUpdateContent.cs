// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Automation.Models
{
    // Generated certificate content keeps optional values under CertificateCreateOrUpdateProperties and uses ThumbprintString.
    // Keep GA top-level setters and the obsolete BinaryData Thumbprint API for source compatibility.
    public partial class AutomationCertificateCreateOrUpdateContent
    {
        /// <summary> Gets or sets the description of the certificate. </summary>
        public string Description
        {
            get => Properties.Description;
            [EditorBrowsable(EditorBrowsableState.Never)]
            set => Properties.Description = value;
        }

        /// <summary> Gets or sets the thumbprint of the certificate. </summary>
        public string ThumbprintString
        {
            get => Properties.ThumbprintString;
            [EditorBrowsable(EditorBrowsableState.Never)]
            set => Properties.ThumbprintString = value;
        }

        /// <summary> Gets or sets the is exportable flag of the certificate. </summary>
        public bool? IsExportable
        {
            get => Properties.IsExportable;
            [EditorBrowsable(EditorBrowsableState.Never)]
            set => Properties.IsExportable = value;
        }

        /// <summary>
        /// Gets or sets the thumbprint of the certificate.
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
        public BinaryData Thumbprint
        {
            get { return BinaryData.FromString(ThumbprintString); }
            [EditorBrowsable(EditorBrowsableState.Never)]
            set { ThumbprintString = value.ToString(); }
        }
    }
}
