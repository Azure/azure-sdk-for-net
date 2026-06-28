// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.AppService;

namespace Azure.ResourceManager.AppService.Models
{
    internal partial class CertificateProperties
    {
        // Compatibility shim: property CerBlob is now writable.
        /// <summary>
        /// Raw bytes of .cer file
        /// <para>
        /// To assign a byte[] to this property use <see cref="BinaryData.FromBytes(byte[])"/>.
        /// The byte[] will be serialized to a Base64 encoded string.
        /// </para>
        /// <para>
        /// Examples:
        /// <list type="bullet">
        /// <item>
        /// <term> BinaryData.FromBytes(new byte[] { 1, 2, 3 }). </term>
        /// <description> Creates a payload of "AQID". </description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        [WirePath("cerBlob")]
        public BinaryData CerBlob { get; set;}
    }
}
