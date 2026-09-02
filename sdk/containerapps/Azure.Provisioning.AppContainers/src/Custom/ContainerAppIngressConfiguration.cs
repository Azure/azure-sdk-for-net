// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Provisioning.AppContainers
{
    public partial class ContainerAppIngressConfiguration
    {
        // The generated property was renamed to distinguish its new affinity type, so preserve the shipped property as a forwarding alias.
        /// <summary> Gets or sets the sticky session affinity. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Use StickySessionsAffinityValue instead.", false)]
        public BicepValue<StickySessionAffinity> StickySessionsAffinity
        {
            get => StickySessionsAffinityValue;
            set => StickySessionsAffinityValue = value;
        }
    }
}
