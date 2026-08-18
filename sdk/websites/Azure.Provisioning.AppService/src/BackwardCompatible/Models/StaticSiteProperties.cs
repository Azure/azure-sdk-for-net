// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.Provisioning.AppService;

internal partial class StaticSiteProperties
{
    private BicepList<StaticSiteUserProvidedFunctionAppData> _userProvidedFunctionAppData;

    internal BicepList<StaticSiteUserProvidedFunctionAppData> UserProvidedFunctionAppData
    {
        get
        {
            Initialize();
            return _userProvidedFunctionAppData;
        }
    }

    partial void DefineAdditionalProperties()
    {
        _userProvidedFunctionAppData = DefineListProperty<StaticSiteUserProvidedFunctionAppData>(
            nameof(UserProvidedFunctionAppData),
            new string[] { "userProvidedFunctionApps" });
    }
}
