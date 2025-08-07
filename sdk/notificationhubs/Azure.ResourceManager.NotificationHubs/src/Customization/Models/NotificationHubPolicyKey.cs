// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.NotificationHubs.Models
{
    /// <summary> Namespace/NotificationHub Regenerate Keys. </summary>
    public partial class NotificationHubPolicyKey
    {
        /// <summary> Initializes a new instance of <see cref="NotificationHubPolicyKey"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NotificationHubPolicyKey()
        {
        }

        /// <summary> Name of the key that has to be regenerated for the Namespace/Notification Hub Authorization Rule. The value can be Primary Key/Secondary Key. </summary>
        public string PolicyKey { get; set; }
    }
}
