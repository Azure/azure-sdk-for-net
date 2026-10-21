// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> A compatibility name for the complete connection monitor request. </summary>
    public partial class ConnectionMonitorContent : ConnectionMonitorCreateOrUpdateContent
    {
        /// <summary> Initializes a new instance of <see cref="ConnectionMonitorContent"/>. </summary>
        public ConnectionMonitorContent()
        {
        }

        internal ConnectionMonitorContent(AzureLocation? location, IDictionary<string, string> tags, ConnectionMonitorParameters properties, IDictionary<string, BinaryData> additionalBinaryDataProperties)
            : base(location, tags, properties, additionalBinaryDataProperties)
        {
        }
    }
}
