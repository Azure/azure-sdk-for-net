// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.Provisioning.Search
{
    /// <summary> Shared private link resource. </summary>
    public partial class SharedSearchServicePrivateLink : SharedSearchServicePrivateLinkResource
    {
        /// <summary> Creates a new SharedSearchServicePrivateLink. </summary>
        public SharedSearchServicePrivateLink(string bicepIdentifier, string resourceVersion = null) : base(bicepIdentifier, resourceVersion)
        {
        }

        /// <summary> Creates a reference to an existing SharedSearchServicePrivateLink. </summary>
        public static new SharedSearchServicePrivateLink FromExisting(string bicepIdentifier, string resourceVersion = null)
        {
            SharedSearchServicePrivateLink result = new SharedSearchServicePrivateLink(bicepIdentifier, resourceVersion);
            result.IsExistingResource = true;
            return result;
        }

        public static new partial class ResourceVersions
        {
            public static readonly string V2014_07_31_Preview = "2014-07-31-preview";
            public static readonly string V2015_02_28 = "2015-02-28";
            public static readonly string V2015_08_19 = "2015-08-19";
            public static readonly string V2019_10_01_Preview = "2019-10-01-preview";
            public static readonly string V2020_03_13 = "2020-03-13";
            public static readonly string V2020_08_01 = "2020-08-01";
            public static readonly string V2020_08_01_Preview = "2020-08-01-preview";
            public static readonly string V2021_04_01_Preview = "2021-04-01-preview";
            public static readonly string V2021_06_06_Preview = "2021-06-06-preview";
            public static readonly string V2022_09_01 = "2022-09-01";
            public static readonly string V2023_11_01 = "2023-11-01";
            public static readonly string V2024_03_01_Preview = "2024-03-01-preview";
            public static readonly string V2024_06_01_Preview = "2024-06-01-preview";
        }
    }
}
