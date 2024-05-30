// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.AppService.Models
{
    [CodeGenModel(Usage = new[] { "input" })]
    public partial class CertificateOrderAction : ResourceData
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Kind { get; set; }
    }
}
