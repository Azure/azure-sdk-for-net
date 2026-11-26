// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Provisioning;

namespace Azure.Provisioning.AppService;

// Preserve the historical float-typed compatibility property while binding it within the generated nested HTTP model to avoid overwriting sibling trigger settings.
internal partial class FunctionsScaleAndConcurrencyTriggersHttp
{
    // Use methods so the compatibility member does not count as another property during safe flattening.
    // Workaround for https://github.com/Azure/azure-sdk-for-net/issues/65191.
    internal BicepValue<float> GetHttpPerInstanceConcurrency()
    {
        Initialize();
        return _httpPerInstanceConcurrency;
    }

    internal void SetHttpPerInstanceConcurrency(BicepValue<float> value)
    {
        Initialize();
        _httpPerInstanceConcurrency.Assign(value);
    }
    private BicepValue<float> _httpPerInstanceConcurrency;

    partial void DefineAdditionalProperties()
    {
        _httpPerInstanceConcurrency = DefineProperty<float>(nameof(FunctionAppScaleAndConcurrency.HttpPerInstanceConcurrency), ["perInstanceConcurrency"]);
    }
}
