// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Provisioning;

namespace Azure.Provisioning.AppService;

public partial class StaticSiteCustomDomainOverview
{
    // Work around https://github.com/Azure/azure-sdk-for-net/issues/61011 by restoring a create-body property omitted from the response model.

    /// <summary> Validation method for adding a custom domain. </summary>
    public BicepValue<string> ValidationMethod
    {
        get { Initialize(); return _validationMethod; }
        set { Initialize(); _validationMethod.Assign(value); }
    }
    private BicepValue<string> _validationMethod;

    partial void DefineAdditionalProperties()
    {
        _validationMethod = DefineProperty<string>(nameof(ValidationMethod), ["properties", "validationMethod"]);
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
    }
}
