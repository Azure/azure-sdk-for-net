// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System.ComponentModel;

namespace Azure.ResourceManager.ContainerInstance.Models
{
    public partial class ContainerProbe
    {
        // backward-compat shim: old name was InitialDelayInSeconds, new is InitialDelaySeconds
        /// <summary> The initial delay seconds. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? InitialDelayInSeconds
        {
            get => InitialDelaySeconds;
            set => InitialDelaySeconds = value;
        }

        // backward-compat shim: old name was PeriodInSeconds, new is PeriodSeconds
        /// <summary> The period seconds. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? PeriodInSeconds
        {
            get => PeriodSeconds;
            set => PeriodSeconds = value;
        }

        // backward-compat shim: old name was TimeoutInSeconds, new is TimeoutSeconds
        /// <summary> The timeout seconds. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? TimeoutInSeconds
        {
            get => TimeoutSeconds;
            set => TimeoutSeconds = value;
        }
    }
}
