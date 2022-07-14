// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Net;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Sql.Models
{
    /// <summary> A security event. </summary>
    public partial class SecurityEvent : ResourceData
    {
        /// <summary> The IP address of the client who executed the statement. </summary>
        [CodeGenMember("ClientIP")]
        public IPAddress ClientIP { get; }
    }
}
