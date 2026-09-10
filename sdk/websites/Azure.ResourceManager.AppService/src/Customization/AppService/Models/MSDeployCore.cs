// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.AppService.Models
{
    // ROOT CAUSE: GA 1.5.0 exposed this property as `AppOffline` (bool?). The TypeSpec emitter renames
    // boolean properties to follow the verb-prefix guideline (BOOL001), producing `IsAppOffline`.
    // Adding a hidden `AppOffline` partial that delegates to `IsAppOffline` preserves the GA name
    // for binary/source compatibility while the generated `IsAppOffline` becomes the recommended name.
    public partial class MSDeployCore
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
