// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Provisioning;

namespace Azure.Provisioning.AppService;

internal partial class MSDeployStatusProperties
{
    internal BicepValue<string> ConnectionString { get { Initialize(); return _connectionString; } set { Initialize(); _connectionString.Assign(value); } }
    private BicepValue<string> _connectionString;

    internal BicepValue<string> DBType { get { Initialize(); return _dBType; } set { Initialize(); _dBType.Assign(value); } }
    private BicepValue<string> _dBType;

    internal BicepValue<bool> IsAppOffline { get { Initialize(); return _isAppOffline; } set { Initialize(); _isAppOffline.Assign(value); } }
    private BicepValue<bool> _isAppOffline;

    internal BicepValue<Uri> PackageUri { get { Initialize(); return _packageUri; } set { Initialize(); _packageUri.Assign(value); } }
    private BicepValue<Uri> _packageUri;

    internal BicepDictionary<string> SetParameters { get { Initialize(); return _setParameters; } set { Initialize(); _setParameters.Assign(value); } }
    private BicepDictionary<string> _setParameters;

    internal BicepValue<Uri> SetParametersXmlFileUri { get { Initialize(); return _setParametersXmlFileUri; } set { Initialize(); _setParametersXmlFileUri.Assign(value); } }
    private BicepValue<Uri> _setParametersXmlFileUri;

    internal BicepValue<bool> SkipAppData { get { Initialize(); return _skipAppData; } set { Initialize(); _skipAppData.Assign(value); } }
    private BicepValue<bool> _skipAppData;

    partial void DefineAdditionalProperties()
    {
        _connectionString = DefineProperty<string>(nameof(ConnectionString), ["connectionString"]);
        _dBType = DefineProperty<string>(nameof(DBType), ["dbType"]);
        _isAppOffline = DefineProperty<bool>(nameof(IsAppOffline), ["appOffline"]);
        _packageUri = DefineProperty<Uri>(nameof(PackageUri), ["packageUri"]);
        _setParameters = DefineDictionaryProperty<string>(nameof(SetParameters), ["setParameters"]);
        _setParametersXmlFileUri = DefineProperty<Uri>(nameof(SetParametersXmlFileUri), ["setParametersXmlFileUri"]);
        _skipAppData = DefineProperty<bool>(nameof(SkipAppData), ["skipAppData"]);
    }
}
