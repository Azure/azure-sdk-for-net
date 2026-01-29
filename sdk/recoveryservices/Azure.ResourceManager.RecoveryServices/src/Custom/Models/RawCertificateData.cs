// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.RecoveryServices.Models
{
    /// <summary> Raw certificate data. </summary>
    public partial class RawCertificateData
    {
        /// <summary>
        /// The base64 encoded certificate raw data string
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
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Byte[] Certificate {
            get { return this.CertificateData.ToArray(); }
            set { this.CertificateData = BinaryData.FromBytes(value); }
        }
    }
}
