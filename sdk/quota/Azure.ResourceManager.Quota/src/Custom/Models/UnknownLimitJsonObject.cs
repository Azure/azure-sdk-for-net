// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.Quota.Models
{
    // This is a workaround for the code generator does not support to rename the type UnknownQuotaLimitJsonObject
    [CodeGenType("UnknownQuotaLimitJsonObject")]
    internal partial class UnknownLimitJsonObject
    {
    }
}
