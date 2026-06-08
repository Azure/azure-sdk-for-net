// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Monitor.Models
{
    public partial class AutoscaleNotification
    {
        /// <summary> the operation associated with the notification and its value must be &quot;scale&quot;. </summary>
        public MonitorOperationType Operation { get; [EditorBrowsable(EditorBrowsableState.Never)] set; }
    }
}
