// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.Grafana.Models
{
    /// <summary>
    /// A class representing the ManagedGrafanaPatchProperties data model.
    /// </summary>
    public partial class ManagedGrafanaPatchProperties
    {
        /// <summary>
        /// Email server settings.
        /// https://grafana.com/docs/grafana/v9.0/setup-grafana/configure-grafana/#smtp
        /// </summary>
        public Smtp GrafanaConfigurationsSmtp
        {
            get => GrafanaConfigurations is null ? default : GrafanaConfigurations.Smtp;
            set
            {
                if (GrafanaConfigurations is null)
                    GrafanaConfigurations = new GrafanaConfigurations();
                GrafanaConfigurations.Smtp = value;
            }
        }
    }
}
