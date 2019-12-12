// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Azure.Storage.Blobs.Models
{
    /// <summary>
    /// Wrapper for an encryption scope for server-side encryption.
    /// </summary>
    public class EncryptionScope
    {
        /// <summary>
        /// The name of a previously-created encryption scope created in the control plane, to be used for server-side encryption.
        /// </summary>
        public string EncryptionScopeKey { get; set; }
    }
}
