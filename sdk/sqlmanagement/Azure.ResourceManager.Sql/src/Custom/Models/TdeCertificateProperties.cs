// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.ResourceManager.Sql;

namespace Azure.ResourceManager.Sql.Models
{
    // Make all properties settable to ensure backward compatibility with the previous version of the SDK, the code will be removed once https://github.com/Azure/azure-sdk-for-net/issues/60037 is resolved.
    public partial class TdeCertificateProperties
    {
        /// <summary> The base64 encoded certificate private blob. </summary>
        [WirePath("privateBlob")]
        public string PrivateBlob { get; set; }
    }
}
