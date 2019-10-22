﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Security.KeyVault.Keys
{
    /// <summary>
    /// The key-specific properties needed to create a key using the <see cref="KeyClient"/>.
    /// </summary>
    public class CreateKeyOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateKeyOptions"/> class.
        /// </summary>
        public CreateKeyOptions()
        {
        }

        /// <summary>
        /// List of supported <see cref="KeyOperations"/>.
        /// </summary>
        public IList<KeyOperation> KeyOperations { get; } = new List<KeyOperation>();

        /// <summary>
        /// Not before date in UTC.
        /// </summary>
        public DateTimeOffset? NotBefore { get; set; }

        /// <summary>
        /// Expiry date in UTC.
        /// </summary>
        public DateTimeOffset? ExpiresOn { get; set; }

        /// <summary>
        /// Determines whether the object is enabled.
        /// </summary>
        public bool? Enabled { get; set; }

        /// <summary>
        /// A dictionary of tags with specific metadata about the key.
        /// </summary>
        public IDictionary<string, string> Tags { get; } = new Dictionary<string, string>();
    }
}
