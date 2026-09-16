// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.Provisioning.AppService;

internal partial class AppServiceEnvironmentProperties
{
    private CustomDnsSuffixConfigurationData _customDnsSuffixConfigurationData;
    private AseV3NetworkingConfigurationData _networkingConfigurationData;

    internal CustomDnsSuffixConfigurationData CustomDnsSuffixConfigurationData
    {
        get
        {
            Initialize();
            return _customDnsSuffixConfigurationData;
        }
        set
        {
            Initialize();
            AssignOrReplace(ref _customDnsSuffixConfigurationData, value);
        }
    }

    internal AseV3NetworkingConfigurationData NetworkingConfigurationData
    {
        get
        {
            Initialize();
            return _networkingConfigurationData;
        }
        set
        {
            Initialize();
            AssignOrReplace(ref _networkingConfigurationData, value);
        }
    }

    partial void DefineAdditionalProperties()
    {
        _customDnsSuffixConfigurationData = DefineModelProperty<CustomDnsSuffixConfigurationData>(
            nameof(CustomDnsSuffixConfigurationData),
            new string[] { "customDnsSuffixConfiguration" });
        _networkingConfigurationData = DefineModelProperty<AseV3NetworkingConfigurationData>(
            nameof(NetworkingConfigurationData),
            new string[] { "networkingConfiguration" });
    }
}
