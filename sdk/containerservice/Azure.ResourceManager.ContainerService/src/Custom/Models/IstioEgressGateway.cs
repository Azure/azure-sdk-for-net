// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Collections.Generic;

namespace Azure.ResourceManager.ContainerService.Models
{
    /// <summary> Istio egress gateway configuration. </summary>
    public partial class IstioEgressGateway
    {
        /// <summary> Initializes a new instance of <see cref="IstioEgressGateway"/>. </summary>
        /// <param name="isEnabled"> Whether to enable the egress gateway. </param>
        [Obsolete("This constructor is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IstioEgressGateway(bool isEnabled)
        {
            IsEnabled = isEnabled;
            NodeSelector = new ChangeTrackingDictionary<string, string>();
        }

        /// <summary> NodeSelector for scheduling the egress gateway. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("nodeSelector")]
        public IDictionary<string, string> NodeSelector { get; }
    }
}
