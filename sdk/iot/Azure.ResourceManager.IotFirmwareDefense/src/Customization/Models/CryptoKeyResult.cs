// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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

        /// <summary> Type of the key (public or private). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string KeyType {
            get => CryptoKeyType.ToString();
            set => CryptoKeyType = value;
        }

        /// <summary>
        /// Functions the key can fulfill.
        /// Serialized Name: CryptoKeyResource.properties.usage
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<string> Usage
        {
            get => CryptoKeyUsage.ToList();
            [Obsolete("This property is now deprecated. Please use the new property `CryptoKeyUsage` moving forward.")]
            set
            {
                // CryptoKeyUsage does not have a setter, there is nothing to do
                return;
            }
        }
    }
}
