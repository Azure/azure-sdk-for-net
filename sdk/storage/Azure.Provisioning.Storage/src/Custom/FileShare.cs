// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Provisioning;

namespace Azure.Provisioning.Storage;

public partial class FileShare
{
    // TypeSpec generates AccessTierChangedOn; retain the shipped AccessTierChangeOn compatibility alias.
    /// <summary> Gets the last modification time for the share access tier. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This property is obsoleted and will be removed in a future version. Please use AccessTierChangedOn instead.")]
    public BicepValue<DateTimeOffset> AccessTierChangeOn => AccessTierChangedOn;

    public static partial class ResourceVersions
    {
        /// <summary>2024-01-01.</summary>
        public static readonly string V2024_01_01 = "2024-01-01";
        /// <summary>2023-05-01.</summary>
        public static readonly string V2023_05_01 = "2023-05-01";
        /// <summary>2023-04-01.</summary>
        public static readonly string V2023_04_01 = "2023-04-01";
        /// <summary>2023-01-01.</summary>
        public static readonly string V2023_01_01 = "2023-01-01";
        /// <summary>2022-09-01.</summary>
        public static readonly string V2022_09_01 = "2022-09-01";
        /// <summary>2022-05-01.</summary>
        public static readonly string V2022_05_01 = "2022-05-01";
        /// <summary>2021-09-01.</summary>
        public static readonly string V2021_09_01 = "2021-09-01";
        /// <summary>2021-08-01.</summary>
        public static readonly string V2021_08_01 = "2021-08-01";
        /// <summary>2021-06-01.</summary>
        public static readonly string V2021_06_01 = "2021-06-01";
        /// <summary>2021-05-01.</summary>
        public static readonly string V2021_05_01 = "2021-05-01";
        /// <summary>2021-04-01.</summary>
        public static readonly string V2021_04_01 = "2021-04-01";
        /// <summary>2021-02-01.</summary>
        public static readonly string V2021_02_01 = "2021-02-01";
        /// <summary>2021-01-01.</summary>
        public static readonly string V2021_01_01 = "2021-01-01";
        /// <summary>2019-06-01.</summary>
        public static readonly string V2019_06_01 = "2019-06-01";
        /// <summary>2019-04-01.</summary>
        public static readonly string V2019_04_01 = "2019-04-01";
        /// <summary>2018-11-01.</summary>
        public static readonly string V2018_11_01 = "2018-11-01";
        /// <summary>2018-07-01.</summary>
        public static readonly string V2018_07_01 = "2018-07-01";
        /// <summary>2018-02-01.</summary>
        public static readonly string V2018_02_01 = "2018-02-01";
        /// <summary>2017-10-01.</summary>
        public static readonly string V2017_10_01 = "2017-10-01";
        /// <summary>2017-06-01.</summary>
        public static readonly string V2017_06_01 = "2017-06-01";
        /// <summary>2016-12-01.</summary>
        public static readonly string V2016_12_01 = "2016-12-01";
        /// <summary>2016-05-01.</summary>
        public static readonly string V2016_05_01 = "2016-05-01";
    }
}
