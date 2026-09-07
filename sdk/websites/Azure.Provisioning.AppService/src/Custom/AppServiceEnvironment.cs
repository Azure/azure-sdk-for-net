// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.AppService;

public partial class AppServiceEnvironment
{
    /// <summary>
    /// Full view of the custom domain suffix configuration for ASEv3.
    /// </summary>
    [CodeGenMember("CustomDnsSuffixConfiguration")]
    public CustomDnsSuffixConfiguration CustomDnsSuffixConfig
    {
        get
        {
            if (Properties is null)
            {
                Properties = new AppServiceEnvironmentProperties();
            }
            return Properties.CustomDnsSuffixConfiguration;
        }
        set
        {
            if (Properties is null)
            {
                Properties = new AppServiceEnvironmentProperties();
            }
            Properties.CustomDnsSuffixConfiguration = value;
        }
    }

    /// <summary>
    /// Full view of the custom domain suffix configuration for ASEv3.
    ///
    /// This property is obsoleted and will be removed in future versions. Please use
    /// <see cref="AppServiceEnvironment.CustomDnsSuffixConfig"/> instead."/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This property is deprecated and it will be removed in a future version. Please use CustomDnsSuffixConfig instead.")]
    public CustomDnsSuffixConfigurationData CustomDnsSuffixConfiguration
    {
        get
        {
            if (Properties is null)
            {
                Properties = new AppServiceEnvironmentProperties();
            }
            return Properties.CustomDnsSuffixConfigurationData;
        }
        set
        {
            if (Properties is null)
            {
                Properties = new AppServiceEnvironmentProperties();
            }
            Properties.CustomDnsSuffixConfigurationData = value;
        }
    }

    /// <summary>
    /// Full view of networking configuration for an ASE.
    /// </summary>
    [CodeGenMember("NetworkingConfiguration")]
    public AseV3NetworkingConfiguration NetworkingConfig
    {
        get
        {
            if (Properties is null)
            {
                Properties = new AppServiceEnvironmentProperties();
            }
            return Properties.NetworkingConfiguration;
        }
        set
        {
            if (Properties is null)
            {
                Properties = new AppServiceEnvironmentProperties();
            }
            Properties.NetworkingConfiguration = value;
        }
    }

    /// <summary>
    /// Full view of networking configuration for an ASE.
    ///
    /// This property is obsoleted and will be removed in future versions. Please use
    /// <see cref="AppServiceEnvironment.NetworkingConfig"/> instead."/>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This property is deprecated and it will be removed in a future version. Please use NetworkingConfig instead.")]
    public AseV3NetworkingConfigurationData NetworkingConfiguration
    {
        get
        {
            if (Properties is null)
            {
                Properties = new AppServiceEnvironmentProperties();
            }
            return Properties.NetworkingConfigurationData;
        }
        set
        {
            if (Properties is null)
            {
                Properties = new AppServiceEnvironmentProperties();
            }
            Properties.NetworkingConfigurationData = value;
        }
    }
}
