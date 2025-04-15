// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.IotFirmwareDefense.Models
{
    /// <summary> Crypto key resource. </summary>
    public partial class CryptoKeyResult : ResourceData
    {
        /// <summary> Size of the key in bits. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public long? KeySize
        {
            get => CryptoKeySize;
            set => CryptoKeySize = value;
        }

        ///// <summary> Type of the key (public or private). </summary>
        //[EditorBrowsable(EditorBrowsableState.Never)]
        //public string KeyType { get; set; }
    }
}
