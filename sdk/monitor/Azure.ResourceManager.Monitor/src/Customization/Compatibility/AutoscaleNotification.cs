// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Monitor.Models
{
    [CodeGenSuppress("AutoscaleNotification")]
    public partial class AutoscaleNotification
    {
        /// <summary> Initializes a new instance of <see cref="AutoscaleNotification"/>. </summary>
        public AutoscaleNotification()
            : this(MonitorOperationType.Scale)
        {
        }
    }
}
