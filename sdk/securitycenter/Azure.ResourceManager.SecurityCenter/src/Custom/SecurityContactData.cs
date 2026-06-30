// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.ResourceManager.SecurityCenter.Models;

namespace Azure.ResourceManager.SecurityCenter
{
    // Generated SecurityContactData follows the current TypeSpec properties, which no longer include the previous GA AlertNotifications member. Keep the property as a hidden stateful shim for ApiCompat.
    /// <summary>
    /// Provides a compatibility shim for the SecurityContactData class.
    /// </summary>
    public partial class SecurityContactData
    {
        /// <summary>
        /// Gets or sets the AlertNotifications value preserved from the previous public API surface.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SecurityContactPropertiesAlertNotifications AlertNotifications { get; set; }
    }
}
