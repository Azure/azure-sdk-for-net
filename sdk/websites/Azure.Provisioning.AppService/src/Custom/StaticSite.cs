// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.AppService;

public partial class StaticSite
{
    /// <summary>
    /// User provided function apps registered with the static site.
    /// </summary>
    [CodeGenMember("UserProvidedFunctionApps")]
    public BicepList<StaticSiteUserProvidedFunctionApp> UserFunctionApps
    {
        get
        {
            if (Properties is null)
            {
                Properties = new StaticSiteProperties();
            }
            return Properties.UserProvidedFunctionApps;
        }
    }

    /// <summary>
    /// User provided function apps registered with the static site.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This property is deprecated and it will be removed in a future version. Please use UserFunctionApps instead.")]
    public BicepList<StaticSiteUserProvidedFunctionAppData> UserProvidedFunctionApps
    {
        get
        {
            if (Properties is null)
            {
                Properties = new StaticSiteProperties();
            }
            return Properties.UserProvidedFunctionAppData;
        }
    }
}
