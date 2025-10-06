// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using Azure.Provisioning.Primitives;
using System;
using System.ComponentModel;

namespace Azure.Provisioning.AppService;

public partial class FunctionAppAlwaysReadyConfig : ProvisionableConstruct
{
    /// <summary>
    /// Sets the number of &apos;Always Ready&apos; instances for a given
    /// function group or a specific function. For additional information see
    /// https://aka.ms/flexconsumption/alwaysready.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public BicepValue<float> InstanceCount
    {
        get { Initialize(); return _instanceCount!; }
        set { Initialize(); _instanceCount!.Assign(value); }
    }
    private BicepValue<float>? _instanceCount;
}
