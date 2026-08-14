// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.Provisioning.AppService;

public partial class StaticSite
{
    /// <summary>
    /// User provided function apps registered with the static site.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public BicepList<StaticSiteUserProvidedFunctionAppData> UserProvidedFunctionApps
    {
        get { Initialize(); return _userProvidedFunctionApps!; }
    }
    private BicepList<StaticSiteUserProvidedFunctionAppData>? _userProvidedFunctionApps;

    private partial void DefineAdditionalProperties()
    {
        _userProvidedFunctionApps = DefineListProperty<StaticSiteUserProvidedFunctionAppData>("UserProvidedFunctionApps", ["properties", "userProvidedFunctionApps"]);
    }
}
