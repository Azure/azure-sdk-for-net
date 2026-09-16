// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Provisioning;

namespace Azure.Provisioning.AppService;

public partial class SiteInstanceExtension
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
}
