// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.IoT.DeviceOnboarding.Models
{
    /// <summary>
    /// Class to define Service Info Module's Keys properties
    /// </summary>
    public class ServiceInfoKeys
    {
        /// <summary>
        /// Gets or sets Key name
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Gets or Sets the flag to determine is key is mandatory
        /// </summary>
        public bool IsRequired { get; set; }

        /// <summary>
        /// Gets or Sets the Value Type for the Key
        /// This is constrained to CBOR Base types
        /// </summary>
        public Type ValueType { get; set; }
    }
}
