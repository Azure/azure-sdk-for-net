// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Resources.Models
{
    /// <summary> Generic object modeling results of script execution. </summary>
    public partial class ScriptStatus
    {
        /// <summary> Time the deployment script resource will expire. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DateTimeOffset? ExpirationOn => ExpireOn;
    }
}
