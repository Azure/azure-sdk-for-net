// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.IotOperations.Models
{
    public static partial class ArmIotOperationsModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Models.IotOperationsDataflowProfileProperties"/>. </summary>
        /// <param name="diagnostics"> Spec defines the desired identities of NBC diagnostics settings. </param>
        /// <param name="instanceCount"> To manually scale the dataflow profile, specify the maximum number of instances you want to run. </param>
        /// <param name="provisioningState"> The status of the last operation. </param>
        /// <returns> A new <see cref="Models.IotOperationsDataflowProfileProperties"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static IotOperationsDataflowProfileProperties IotOperationsDataflowProfileProperties(DataflowProfileDiagnostics diagnostics = null, int? instanceCount = null, IotOperationsProvisioningState? provisioningState = null)
            => IotOperationsDataflowProfileProperties(diagnostics, instanceCount, provisioningState, null);

        /// <summary> Initializes a new instance of <see cref="Models.IotOperationsBrokerListenerProperties"/>. </summary>
        /// <param name="serviceName"> Kubernetes Service name of this listener. </param>
        /// <param name="ports"> Ports on which this listener accepts client connections. </param>
        /// <param name="serviceType"> Kubernetes Service type of this listener. </param>
        /// <param name="provisioningState"> The status of the last operation. </param>
        /// <returns> A new <see cref="Models.IotOperationsBrokerListenerProperties"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete and will be removed in a future release")]
        public static IotOperationsBrokerListenerProperties IotOperationsBrokerListenerProperties(string serviceName, IEnumerable<BrokerListenerPort> ports, BlockerListenerServiceType? serviceType, IotOperationsProvisioningState? provisioningState)
            => IotOperationsBrokerListenerProperties(serviceName, ports, serviceType.ToString(), provisioningState, null);
    }
}
