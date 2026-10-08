// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Provisioning;

namespace Azure.Provisioning.AppService;

internal partial class CertificateProperties
{
    // Preserve the legacy BinaryData-typed wire binding while retaining the current string-typed thumbprint API.

    /// <summary> Certificate thumbprint. </summary>
    internal BicepValue<BinaryData> Thumbprint
    {
        get { Initialize(); return _thumbprint; }
    }
    private BicepValue<BinaryData> _thumbprint;

    partial void DefineAdditionalProperties()
    {
        _thumbprint = DefineProperty<BinaryData>(nameof(Thumbprint), ["thumbprint"], isOutput: true);
    }
}
