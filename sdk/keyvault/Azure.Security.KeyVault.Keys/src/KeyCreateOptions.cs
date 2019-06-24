// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;

namespace Azure.Security.KeyVault.Keys
{
    /// <summary>
    /// Represent the key specific attributes needed in order to create a key.
    /// </summary>
    public class KeyCreateOptions
    {
        /// <summary>
        /// List of supported <see cref="KeyOperations"/>.
        /// </summary>
        public IList<KeyOperations> KeyOperations { get; set; }

        /// <summary>
        /// Not before date in UTC.
        /// </summary>
        public DateTimeOffset? NotBefore { get; set; }

        /// <summary>
        /// Expiry date in UTC.
        /// </summary>
        public DateTimeOffset? Expires { get; set; }

        /// <summary>
        /// Determines whether the object is enabled.
        /// </summary>
        public bool? Enabled { get; set; }

        /// <summary>
        /// A dictionary of tags with specific metadata about the key.
        /// </summary>
        public IDictionary<string, string> Tags { get; private set; } = new Dictionary<string, string> ();
    }
}
