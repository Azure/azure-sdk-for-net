// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.RecoveryServices.Models
{
    public partial class RawCertificateData
    {
        /// <summary>
        /// The base64 encoded certificate raw data string
        /// </summary>
        public Byte[] Certificate {get; set;}
    }
}
