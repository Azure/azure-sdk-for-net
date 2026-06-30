// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    /// <summary> Provides a compatibility shim for the IngestionConnectionString class. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class IngestionConnectionString
    {
        /// <summary> Initializes a new instance of <see cref="IngestionConnectionString"/>. </summary>
        public IngestionConnectionString()
        {
        }

        internal IngestionConnectionString(AzureLocation? location, string value)
        {
            Location = location;
            Value = value;
        }

        /// <summary> Gets or sets the location. </summary>
        public AzureLocation? Location { get; set; }

        /// <summary> Gets or sets the connection string value. </summary>
        public string Value { get; set; }
    }
}
