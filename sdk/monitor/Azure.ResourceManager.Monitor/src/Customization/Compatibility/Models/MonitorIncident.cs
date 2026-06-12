// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.Monitor.Models
{
    /// <summary> An alert rule incident. </summary>
    [Obsolete("This API is no longer supported.", false)]
    public partial class MonitorIncident
    {
        /// <summary> Initializes a new instance of <see cref="MonitorIncident"/>. </summary>
        public MonitorIncident()
            => throw new NotSupportedException("This API is no longer supported.");
    }
}
