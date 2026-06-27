// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.AppService.Models
{
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
