// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Azure.Security.Attestation.Models
{
    [JsonConverter(typeof(PolicyCertificateModificationResultConverter))]
    public partial class PolicyCertificatesModificationResult
    {
    }
}
