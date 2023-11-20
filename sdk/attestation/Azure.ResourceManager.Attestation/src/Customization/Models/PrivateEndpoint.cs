// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable
using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Attestation.Models
{
    public partial class PrivateEndpoint
    {
        /// <summary> Resource Id. </summary>
        [CodeGenMember("Id")]
        public string Id { get; set; }
    }
}
