// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Provisioning;

namespace Azure.Provisioning.AppService;

internal partial class FunctionsScaleAndConcurrencyTriggersHttp
{
    internal BicepValue<float> HttpPerInstanceConcurrency
    {
        get { Initialize(); return _httpPerInstanceConcurrency; }
        set { Initialize(); _httpPerInstanceConcurrency.Assign(value); }
    }
    private BicepValue<float> _httpPerInstanceConcurrency;

    partial void DefineAdditionalProperties()
    {
        _httpPerInstanceConcurrency = DefineProperty<float>(nameof(HttpPerInstanceConcurrency), ["perInstanceConcurrency"]);
    }
}
