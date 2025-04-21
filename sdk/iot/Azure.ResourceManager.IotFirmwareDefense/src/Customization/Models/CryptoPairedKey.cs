// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.ResourceManager.IotFirmwareDefense.Models
{
    /// <summary> Details of a matching paired key or certificate. </summary>
    public partial class CryptoPairedKey
    {
        /// <summary> ID of the paired key or certificate. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Id
        {
            get => PairedKeyId;
            set => PairedKeyId = value;
        }
    }
}
