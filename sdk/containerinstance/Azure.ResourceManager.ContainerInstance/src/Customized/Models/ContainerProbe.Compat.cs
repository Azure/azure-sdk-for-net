// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

// Backward-compat property shims: renamed in TypeSpec migration.
// InitialDelayInSeconds → InitialDelaySeconds, PeriodInSeconds → PeriodSeconds, TimeoutInSeconds → TimeoutSeconds.

namespace Azure.ResourceManager.ContainerInstance.Models
{
    public partial class ContainerProbe
    {
        /// <summary> The initial delay seconds. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? InitialDelayInSeconds { get => InitialDelaySeconds; set => InitialDelaySeconds = value; }

        /// <summary> The period seconds. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? PeriodInSeconds { get => PeriodSeconds; set => PeriodSeconds = value; }

        /// <summary> The timeout seconds. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? TimeoutInSeconds { get => TimeoutSeconds; set => TimeoutSeconds = value; }
    }
}
