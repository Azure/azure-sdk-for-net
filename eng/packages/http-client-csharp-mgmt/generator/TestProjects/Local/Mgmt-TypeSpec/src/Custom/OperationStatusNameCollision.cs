// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Generator.MgmtTypeSpec.Tests.Models;

internal class HandwrittenOperationStatus : OperationStatusResult
{
    internal HandwrittenOperationStatus()
        : base(null, null, "Ready", null, null, null, null, null)
    {
    }

    internal global::Azure.ResourceManager.Models.OperationStatusResult FrameworkStatus => this;
}

[CodeGenType("ServiceError")]
public partial class OperationStatusError2
{
    internal string ServiceErrorCode => ServiceCode;
}
