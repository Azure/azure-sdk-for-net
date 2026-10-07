// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.Provisioning.AppService;

// Support the obsolete StaticSite.UserProvidedFunctionApps compatibility property whose historical element type is no longer generated from TypeSpec.
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
