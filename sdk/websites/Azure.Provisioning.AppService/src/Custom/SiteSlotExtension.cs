// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Provisioning;

namespace Azure.Provisioning.AppService;

public partial class SiteSlotExtension
{
    // Work around https://github.com/Azure/azure-sdk-for-net/issues/61011 by restoring create-body properties omitted from the response model.

    /// <summary> SQL Connection String. </summary>
    public BicepValue<string> ConnectionString
    {
        get { Initialize(); return _connectionString; }
        set { Initialize(); _connectionString.Assign(value); }
    }
    private BicepValue<string> _connectionString;

    /// <summary> Database Type. </summary>
    public BicepValue<string> DBType
    {
        get { Initialize(); return _dBType; }
        set { Initialize(); _dBType.Assign(value); }
    }
    private BicepValue<string> _dBType;

    /// <summary> Sets the AppOffline rule while the MSDeploy operation executes. </summary>
    public BicepValue<bool> IsAppOffline
    {
        get { Initialize(); return _isAppOffline; }
        set { Initialize(); _isAppOffline.Assign(value); }
    }
    private BicepValue<bool> _isAppOffline;

    /// <summary> Package URI. </summary>
    public BicepValue<Uri> PackageUri
    {
        get { Initialize(); return _packageUri; }
        set { Initialize(); _packageUri.Assign(value); }
    }
    private BicepValue<Uri> _packageUri;

    /// <summary> MSDeploy Parameters. Must not be set if SetParametersXmlFileUri is used. </summary>
    public BicepDictionary<string> SetParameters
    {
        get { Initialize(); return _setParameters; }
        set { Initialize(); _setParameters.Assign(value); }
    }
    private BicepDictionary<string> _setParameters;

    /// <summary> URI of MSDeploy Parameters file. Must not be set if SetParameters is used. </summary>
    public BicepValue<Uri> SetParametersXmlFileUri
    {
        get { Initialize(); return _setParametersXmlFileUri; }
        set { Initialize(); _setParametersXmlFileUri.Assign(value); }
    }
    private BicepValue<Uri> _setParametersXmlFileUri;

    /// <summary> Controls whether the MSDeploy operation skips the App_Data directory. </summary>
    public BicepValue<bool> SkipAppData
    {
        get { Initialize(); return _skipAppData; }
        set { Initialize(); _skipAppData.Assign(value); }
    }
    private BicepValue<bool> _skipAppData;

    partial void DefineAdditionalProperties()
    {
        _connectionString = DefineProperty<string>(nameof(ConnectionString), ["properties", "connectionString"]);
        _dBType = DefineProperty<string>(nameof(DBType), ["properties", "dbType"]);
        _isAppOffline = DefineProperty<bool>(nameof(IsAppOffline), ["properties", "appOffline"]);
        _packageUri = DefineProperty<Uri>(nameof(PackageUri), ["properties", "packageUri"]);
        _setParameters = DefineDictionaryProperty<string>(nameof(SetParameters), ["properties", "setParameters"]);
        _setParametersXmlFileUri = DefineProperty<Uri>(nameof(SetParametersXmlFileUri), ["properties", "setParametersXmlFileUri"]);
        _skipAppData = DefineProperty<bool>(nameof(SkipAppData), ["properties", "skipAppData"]);
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
        /// <summary> API version "2018-11-01". </summary>
        public static readonly string V2018_11_01 = "2018-11-01";
        /// <summary> API version "2018-02-01". </summary>
        public static readonly string V2018_02_01 = "2018-02-01";
        /// <summary> API version "2017-08-01". </summary>
        public static readonly string V2017_08_01 = "2017-08-01";
        /// <summary> API version "2016-09-01". </summary>
        public static readonly string V2016_09_01 = "2016-09-01";
        /// <summary> API version "2016-08-01". </summary>
        public static readonly string V2016_08_01 = "2016-08-01";
        /// <summary> API version "2016-03-01". </summary>
        public static readonly string V2016_03_01 = "2016-03-01";
        /// <summary> API version "2015-11-01". </summary>
        public static readonly string V2015_11_01 = "2015-11-01";
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
        /// <summary> API version "2015-01-01". </summary>
        public static readonly string V2015_01_01 = "2015-01-01";
        /// <summary> API version "2014-11-01". </summary>
        public static readonly string V2014_11_01 = "2014-11-01";
        /// <summary> API version "2014-06-01". </summary>
        public static readonly string V2014_06_01 = "2014-06-01";
        /// <summary> API version "2014-04-01". </summary>
        public static readonly string V2014_04_01 = "2014-04-01";
    }
}
