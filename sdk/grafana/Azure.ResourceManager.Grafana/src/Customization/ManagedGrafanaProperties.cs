// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Grafana.Models
{
    /// <summary>
    /// A class representing the ManagedGrafanaProperties data model.
    /// </summary>
    public partial class ManagedGrafanaProperties
    {
        /// <summary>
        /// Email server settings.
        /// https://grafana.com/docs/grafana/v9.0/setup-grafana/configure-grafana/#smtp
        /// </summary>
        [Obsolete("This property is obsolete and will be removed in a future release.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Smtp GrafanaConfigurationsSmtp { get; set; }
    }
}
