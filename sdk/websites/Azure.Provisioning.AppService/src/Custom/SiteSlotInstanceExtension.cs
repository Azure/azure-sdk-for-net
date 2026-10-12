// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Provisioning;

namespace Azure.Provisioning.AppService;

public partial class SiteSlotInstanceExtension
{
    // Work around https://github.com/Azure/azure-sdk-for-net/issues/61011 by restoring create-body properties omitted from the response model.

    /// <summary> Start time. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This property is obsolete and will be removed in a future release. Please use StartsOn instead.", false)]
    public BicepValue<DateTimeOffset> StartOn => StartsOn;

    /// <summary> End time. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This property is obsolete and will be removed in a future release. Please use EndsOn instead.", false)]
    public BicepValue<DateTimeOffset> EndOn => EndsOn;

    /// <summary> SQL Connection String. </summary>
    public BicepValue<string> ConnectionString
    {
        get { EnsureProperties(); return Properties.ConnectionString; }
        set { EnsureProperties(); Properties.ConnectionString = value; }
    }

    /// <summary> Database Type. </summary>
    public BicepValue<string> DBType
    {
        get { EnsureProperties(); return Properties.DBType; }
        set { EnsureProperties(); Properties.DBType = value; }
    }

    /// <summary> Sets the AppOffline rule while the MSDeploy operation executes. </summary>
    public BicepValue<bool> IsAppOffline
    {
        get { EnsureProperties(); return Properties.IsAppOffline; }
        set { EnsureProperties(); Properties.IsAppOffline = value; }
    }

    /// <summary> Package URI. </summary>
    public BicepValue<Uri> PackageUri
    {
        get { EnsureProperties(); return Properties.PackageUri; }
        set { EnsureProperties(); Properties.PackageUri = value; }
    }

    /// <summary> MSDeploy Parameters. Must not be set if SetParametersXmlFileUri is used. </summary>
    public BicepDictionary<string> SetParameters
    {
        get { EnsureProperties(); return Properties.SetParameters; }
        set { EnsureProperties(); Properties.SetParameters = value; }
    }

    /// <summary> URI of MSDeploy Parameters file. Must not be set if SetParameters is used. </summary>
    public BicepValue<Uri> SetParametersXmlFileUri
    {
        get { EnsureProperties(); return Properties.SetParametersXmlFileUri; }
        set { EnsureProperties(); Properties.SetParametersXmlFileUri = value; }
    }

    /// <summary> Controls whether the MSDeploy operation skips the App_Data directory. </summary>
    public BicepValue<bool> SkipAppData
    {
        get { EnsureProperties(); return Properties.SkipAppData; }
        set { EnsureProperties(); Properties.SkipAppData = value; }
    }

    private void EnsureProperties()
    {
        if (Properties is null)
        {
            Properties = new MSDeployStatusProperties();
        }
    }
}
