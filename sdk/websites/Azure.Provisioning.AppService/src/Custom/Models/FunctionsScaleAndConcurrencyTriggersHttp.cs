// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Provisioning;

namespace Azure.Provisioning.AppService;

// Preserve the historical float-typed compatibility property while binding it within the generated nested HTTP model to avoid overwriting sibling trigger settings.
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
