// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // The current TypeSpec renamed, nested, or removed these legacy model members, so generation omits the GA constructor/property shape; reintroduce the source-compatible member in this partial.
    /// <summary>
    /// Provides a compatibility shim for the SecurityContactPropertiesAlertNotifications class.
    /// </summary>
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public partial class SecurityContactPropertiesAlertNotifications
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityContactPropertiesAlertNotifications"/> type for compatibility with the previous public API surface.
        /// </summary>
        public SecurityContactPropertiesAlertNotifications() { }
        /// <summary>
        /// Gets or sets the MinimalSeverity value preserved from the previous public API surface.
        /// </summary>
        public Azure.ResourceManager.SecurityCenter.Models.SecurityAlertMinimalSeverity? MinimalSeverity { get; set; }
        /// <summary>
        /// Gets or sets the State value preserved from the previous public API surface.
        /// </summary>
        public Azure.ResourceManager.SecurityCenter.Models.SecurityAlertNotificationState? State { get; set; }
    }
}
