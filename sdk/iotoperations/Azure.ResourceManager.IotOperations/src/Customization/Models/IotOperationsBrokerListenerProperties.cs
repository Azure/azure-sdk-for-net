// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.IotOperations.Models
{
    /// <summary> Defines a Broker listener. A listener is a collection of ports on which the broker accepts connections from clients. </summary>
    public partial class IotOperationsBrokerListenerProperties
    {
        /// <summary> Kubernetes Service type of this listener. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is deprecated. Please use ServiceType of type BrokerListenerServiceType instead.")]
        public BlockerListenerServiceType? ServiceType { get => ListenerServiceType?.ToString(); set => ListenerServiceType = value.ToString(); }
    }
}
