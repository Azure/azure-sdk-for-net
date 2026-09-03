// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.AppContainers.Models
{
    public partial class ContainerAppIngressConfiguration
    {
        // The affinity type now has a service-specific name, so preserve the shipped property with conversion to the generated property.
#pragma warning disable CS0618 // Affinity is intentionally used by this obsolete compatibility property.
        /// <summary> Sticky Session Affinity. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use StickySessionAffinity instead.", false)]
        public Affinity? StickySessionsAffinity
        {
            get => StickySessionAffinity.HasValue
                ? new Affinity(StickySessionAffinity.Value.ToString())
                : null;
            set => StickySessionAffinity = value.HasValue
                ? new StickySessionAffinity(value.Value.ToString())
                : null;
        }
#pragma warning restore CS0618
    }
}
