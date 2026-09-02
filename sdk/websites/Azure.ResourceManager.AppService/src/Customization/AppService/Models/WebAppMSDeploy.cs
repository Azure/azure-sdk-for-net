// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.ResourceManager.AppService.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.AppService.Models
{
    // ROOT CAUSE: The mgmt generator auto-emits a back-compat shim property
    // `AppOffline` (forwarding to the renamed `IsAppOffline`) on flattened
    // outer wrappers when `@@clientName(...IsAppOffline...)` is applied to the
    // inner property `MSDeployProperties.appOffline`. The auto-emitted shim
    // uses `[EditorBrowsableAttribute(1)]` literal — invalid C# (enum cast).
    // Until the generator is fixed, suppress the auto-emitted member here and
    // add an equivalent compat shim manually below.
    [CodeGenSuppress("AppOffline")]
    public partial class WebAppMSDeploy
    {
        /// <summary> Sets the AppOffline rule while the MSDeploy operation executes. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? AppOffline
        {
            get => IsAppOffline;
            set => IsAppOffline = value;
        }
    }
}
