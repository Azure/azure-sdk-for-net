// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.NotificationHubs.Models
{
    // Backward-compat: baseline had a public parameterless constructor.
    public partial class NotificationHubAdmCredential
    {
        /// <summary> Initializes a new instance of <see cref="NotificationHubAdmCredential"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NotificationHubAdmCredential()
        {
        }
    }
}
