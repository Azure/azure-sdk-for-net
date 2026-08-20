// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.ComponentModel;

namespace Azure.Provisioning.CosmosDB;

/// <summary>
/// CosmosDBService.
/// </summary>
public partial class CosmosDBService
{
    // CUSTOMIZATION: Preserve the legacy Properties member for API compatibility. The current
    // generator flattens this response model and cannot implement the member without extensibility.
    /// <summary>
    /// Services response resource.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public CosmosDBServiceProperties Properties
    {
        get => throw new NotSupportedException("TODO: Needs to be implemented using extensibility API.");
    }

    public static partial class ResourceVersions
    {
        /// <summary> API version "2014-04-01". </summary>
        public static readonly string V2014_04_01 = "2014-04-01";
        /// <summary> API version "2015-04-08". </summary>
        public static readonly string V2015_04_08 = "2015-04-08";
        /// <summary> API version "2015-11-06". </summary>
        public static readonly string V2015_11_06 = "2015-11-06";
        /// <summary> API version "2016-03-19". </summary>
        public static readonly string V2016_03_19 = "2016-03-19";
        /// <summary> API version "2016-03-31". </summary>
        public static readonly string V2016_03_31 = "2016-03-31";
        /// <summary> API version "2019-08-01". </summary>
        public static readonly string V2019_08_01 = "2019-08-01";
        /// <summary> API version "2019-12-12". </summary>
        public static readonly string V2019_12_12 = "2019-12-12";
        /// <summary> API version "2020-03-01". </summary>
        public static readonly string V2020_03_01 = "2020-03-01";
        /// <summary> API version "2020-04-01". </summary>
        public static readonly string V2020_04_01 = "2020-04-01";
        /// <summary> API version "2020-09-01". </summary>
        public static readonly string V2020_09_01 = "2020-09-01";
        /// <summary> API version "2021-01-15". </summary>
        public static readonly string V2021_01_15 = "2021-01-15";
        /// <summary> API version "2021-03-15". </summary>
        public static readonly string V2021_03_15 = "2021-03-15";
        /// <summary> API version "2021-04-15". </summary>
        public static readonly string V2021_04_15 = "2021-04-15";
        /// <summary> API version "2021-05-15". </summary>
        public static readonly string V2021_05_15 = "2021-05-15";
        /// <summary> API version "2021-06-15". </summary>
        public static readonly string V2021_06_15 = "2021-06-15";
        /// <summary> API version "2021-10-15". </summary>
        public static readonly string V2021_10_15 = "2021-10-15";
        /// <summary> API version "2022-05-15". </summary>
        public static readonly string V2022_05_15 = "2022-05-15";
        /// <summary> API version "2022-08-15". </summary>
        public static readonly string V2022_08_15 = "2022-08-15";
        /// <summary> API version "2022-11-15". </summary>
        public static readonly string V2022_11_15 = "2022-11-15";
        /// <summary> API version "2023-03-15". </summary>
        public static readonly string V2023_03_15 = "2023-03-15";
        /// <summary> API version "2023-04-15". </summary>
        public static readonly string V2023_04_15 = "2023-04-15";
        /// <summary> API version "2023-09-15". </summary>
        public static readonly string V2023_09_15 = "2023-09-15";
        /// <summary> API version "2023-11-15". </summary>
        public static readonly string V2023_11_15 = "2023-11-15";
        /// <summary> API version "2024-05-15". </summary>
        public static readonly string V2024_05_15 = "2024-05-15";
        /// <summary> API version "2024-08-15". </summary>
        public static readonly string V2024_08_15 = "2024-08-15";
        /// <summary> API version "2024-11-15". </summary>
        public static readonly string V2024_11_15 = "2024-11-15";
        /// <summary> API version "2025-04-15". </summary>
        public static readonly string V2025_04_15 = "2025-04-15";
    }
}
