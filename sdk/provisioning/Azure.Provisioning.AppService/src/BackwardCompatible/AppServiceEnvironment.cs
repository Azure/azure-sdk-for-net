// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.Provisioning.AppService;

public partial class AppServiceEnvironment
{
    /// <summary>
    /// Full view of the custom domain suffix configuration for ASEv3.
    ///
    /// This property is obsoleted and will be removed in future versions. Please use
    /// <see cref="AppServiceEnvironment.CustomDnsSuffixConfig"/> instead."/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public CustomDnsSuffixConfigurationData CustomDnsSuffixConfiguration
    {
        get { Initialize(); return _customDnsSuffixConfiguration!; }
        set { Initialize(); AssignOrReplace(ref _customDnsSuffixConfiguration, value); }
    }
    private CustomDnsSuffixConfigurationData? _customDnsSuffixConfiguration;

    /// <summary>
    /// Full view of networking configuration for an ASE.
    ///
    /// This property is obsoleted and will be removed in future versions. Please use
    /// <see cref="AppServiceEnvironment.NetworkingConfig"/> instead."/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public AseV3NetworkingConfigurationData NetworkingConfiguration
    {
        get { Initialize(); return _networkingConfiguration!; }
        set { Initialize(); AssignOrReplace(ref _networkingConfiguration, value); }
    }
    private AseV3NetworkingConfigurationData? _networkingConfiguration;

    private partial void DefineAdditionalProperties()
    {
        _customDnsSuffixConfiguration = DefineModelProperty<CustomDnsSuffixConfigurationData>("CustomDnsSuffixConfiguration", ["properties", "customDnsSuffixConfiguration"]);
        _networkingConfiguration = DefineModelProperty<AseV3NetworkingConfigurationData>("NetworkingConfiguration", ["properties", "networkingConfiguration"]);
    }
}
