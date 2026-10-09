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

    public static partial class ResourceVersions
    {
        // Preserve historical API versions that shipped from the reflection-based provisioning generator.
        /// <summary> API version "2024-11-01". </summary>
        public static readonly string V2024_11_01 = "2024-11-01";
        /// <summary> API version "2024-04-01". </summary>
        public static readonly string V2024_04_01 = "2024-04-01";
        /// <summary> API version "2023-12-01". </summary>
        public static readonly string V2023_12_01 = "2023-12-01";
        /// <summary> API version "2023-01-01". </summary>
        public static readonly string V2023_01_01 = "2023-01-01";
        /// <summary> API version "2022-09-01". </summary>
        public static readonly string V2022_09_01 = "2022-09-01";
        /// <summary> API version "2022-03-01". </summary>
        public static readonly string V2022_03_01 = "2022-03-01";
        /// <summary> API version "2021-03-01". </summary>
        public static readonly string V2021_03_01 = "2021-03-01";
        /// <summary> API version "2021-02-01". </summary>
        public static readonly string V2021_02_01 = "2021-02-01";
        /// <summary> API version "2021-01-15". </summary>
        public static readonly string V2021_01_15 = "2021-01-15";
        /// <summary> API version "2021-01-01". </summary>
        public static readonly string V2021_01_01 = "2021-01-01";
        /// <summary> API version "2020-12-01". </summary>
        public static readonly string V2020_12_01 = "2020-12-01";
        /// <summary> API version "2020-10-01". </summary>
        public static readonly string V2020_10_01 = "2020-10-01";
        /// <summary> API version "2020-09-01". </summary>
        public static readonly string V2020_09_01 = "2020-09-01";
        /// <summary> API version "2020-06-01". </summary>
        public static readonly string V2020_06_01 = "2020-06-01";
        /// <summary> API version "2019-08-01". </summary>
        public static readonly string V2019_08_01 = "2019-08-01";
        /// <summary> API version "2019-02-01". </summary>
        public static readonly string V2019_02_01 = "2019-02-01";
        /// <summary> API version "2019-01-01". </summary>
        public static readonly string V2019_01_01 = "2019-01-01";
        /// <summary> API version "2018-11-01". </summary>
        public static readonly string V2018_11_01 = "2018-11-01";
        /// <summary> API version "2018-08-01". </summary>
        public static readonly string V2018_08_01 = "2018-08-01";
        /// <summary> API version "2018-02-01". </summary>
        public static readonly string V2018_02_01 = "2018-02-01";
        /// <summary> API version "2017-08-01". </summary>
        public static readonly string V2017_08_01 = "2017-08-01";
        /// <summary> API version "2016-09-01". </summary>
        public static readonly string V2016_09_01 = "2016-09-01";
        /// <summary> API version "2016-03-01". </summary>
        public static readonly string V2016_03_01 = "2016-03-01";
        /// <summary> API version "2015-08-01". </summary>
        public static readonly string V2015_08_01 = "2015-08-01";
        /// <summary> API version "2015-07-01". </summary>
        public static readonly string V2015_07_01 = "2015-07-01";
        /// <summary> API version "2015-06-01". </summary>
        public static readonly string V2015_06_01 = "2015-06-01";
        /// <summary> API version "2015-05-01". </summary>
        public static readonly string V2015_05_01 = "2015-05-01";
        /// <summary> API version "2015-04-01". </summary>
        public static readonly string V2015_04_01 = "2015-04-01";
        /// <summary> API version "2015-02-01". </summary>
        public static readonly string V2015_02_01 = "2015-02-01";
        /// <summary> API version "2014-11-01". </summary>
        public static readonly string V2014_11_01 = "2014-11-01";
        /// <summary> API version "2014-06-01". </summary>
        public static readonly string V2014_06_01 = "2014-06-01";
        /// <summary> API version "2014-04-01". </summary>
        public static readonly string V2014_04_01 = "2014-04-01";
    }
}
