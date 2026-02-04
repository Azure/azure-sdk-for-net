// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using Azure;
using Azure.Core;
using Azure.ResourceManager.IotOperations;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.IotOperations.Models
{
    public static partial class ArmIotOperationsModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="T:Azure.ResourceManager.IotOperations.Models.IotOperationsBrokerProperties" />. </summary>
        /// <param name="advanced"> Advanced settings of Broker. </param>
        /// <param name="cardinality"> The cardinality details of the broker. </param>
        /// <param name="diagnostics"> Spec defines the desired identities of Broker diagnostics settings. </param>
        /// <param name="diskBackedMessageBuffer"> Settings of Disk Backed Message Buffer. </param>
        /// <param name="generateResourceLimitsCpu"> This setting controls whether Kubernetes CPU resource limits are requested. Increasing the number of replicas or workers proportionally increases the amount of CPU resources requested. If this setting is enabled and there are insufficient CPU resources, an error will be emitted. </param>
        /// <param name="memoryProfile"> Memory profile of Broker. </param>
        /// <param name="provisioningState"> The status of the last operation. </param>
        /// <returns> A new <see cref="T:Azure.ResourceManager.IotOperations.Models.IotOperationsBrokerProperties" /> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static IotOperationsBrokerProperties IotOperationsBrokerProperties(BrokerAdvancedSettings advanced, BrokerCardinality cardinality, BrokerDiagnostics diagnostics, DiskBackedMessageBuffer diskBackedMessageBuffer, IotOperationsOperationalMode? generateResourceLimitsCpu, BrokerMemoryProfile? memoryProfile, IotOperationsProvisioningState? provisioningState)
            => IotOperationsBrokerProperties(advanced, cardinality, diagnostics, diskBackedMessageBuffer, generateResourceLimitsCpu, memoryProfile, null, provisioningState, null);

        /// <summary> Initializes a new instance of <see cref="Models.IotOperationsBrokerAuthenticationProperties"/>. </summary>
        /// <param name="authenticationMethods"> Defines a set of Broker authentication methods to be used on `BrokerListeners`. For each array element one authenticator type supported. </param>
        /// <param name="provisioningState"> The status of the last operation. </param>
        /// <returns> A new <see cref="Models.IotOperationsBrokerAuthenticationProperties"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static IotOperationsBrokerAuthenticationProperties IotOperationsBrokerAuthenticationProperties(IEnumerable<BrokerAuthenticatorMethods> authenticationMethods, IotOperationsProvisioningState? provisioningState)
            => IotOperationsBrokerAuthenticationProperties(authenticationMethods, provisioningState, null);

        /// <summary> Initializes a new instance of <see cref="Models.IotOperationsBrokerAuthorizationProperties"/>. </summary>
        /// <param name="authorizationPolicies"> The list of authorization policies supported by the Authorization Resource. </param>
        /// <param name="provisioningState"> The status of the last operation. </param>
        /// <returns> A new <see cref="Models.IotOperationsBrokerAuthorizationProperties"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static IotOperationsBrokerAuthorizationProperties IotOperationsBrokerAuthorizationProperties(BrokerAuthorizationConfig authorizationPolicies, IotOperationsProvisioningState? provisioningState)
            => IotOperationsBrokerAuthorizationProperties(authorizationPolicies, provisioningState, null);

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

        /// <summary> Initializes a new instance of <see cref="T:Azure.ResourceManager.IotOperations.Models.IotOperationsDataflowEndpointProperties" />. </summary>
        /// <param name="endpointType"> Endpoint Type. </param>
        /// <param name="dataExplorerSettings"> Azure Data Explorer endpoint. </param>
        /// <param name="dataLakeStorageSettings"> Azure Data Lake endpoint. </param>
        /// <param name="fabricOneLakeSettings"> Microsoft Fabric endpoint. </param>
        /// <param name="kafkaSettings"> Kafka endpoint. </param>
        /// <param name="localStoragePersistentVolumeClaimRef"> Local persistent volume endpoint. </param>
        /// <param name="mqttSettings"> Broker endpoint. </param>
        /// <param name="provisioningState"> The status of the last operation. </param>
        /// <returns> A new <see cref="T:Azure.ResourceManager.IotOperations.Models.IotOperationsDataflowEndpointProperties" /> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static IotOperationsDataflowEndpointProperties IotOperationsDataflowEndpointProperties(DataflowEndpointType endpointType, DataflowEndpointDataExplorer dataExplorerSettings, DataflowEndpointDataLakeStorage dataLakeStorageSettings, DataflowEndpointFabricOneLake fabricOneLakeSettings, DataflowEndpointKafka kafkaSettings, string localStoragePersistentVolumeClaimRef, DataflowEndpointMqtt mqttSettings, IotOperationsProvisioningState? provisioningState)
            => IotOperationsDataflowEndpointProperties(endpointType, null, dataExplorerSettings, dataLakeStorageSettings, fabricOneLakeSettings, kafkaSettings , localStoragePersistentVolumeClaimRef, mqttSettings, null, provisioningState, null);

        /// <summary> Initializes a new instance of <see cref="Models.IotOperationsDataflowProfileProperties"/>. </summary>
        /// <param name="diagnostics"> Spec defines the desired identities of NBC diagnostics settings. </param>
        /// <param name="instanceCount"> To manually scale the dataflow profile, specify the maximum number of instances you want to run. </param>
        /// <param name="provisioningState"> The status of the last operation. </param>
        /// <returns> A new <see cref="Models.IotOperationsDataflowProfileProperties"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static IotOperationsDataflowProfileProperties IotOperationsDataflowProfileProperties(DataflowProfileDiagnostics diagnostics = null, int? instanceCount = null, IotOperationsProvisioningState? provisioningState = null)
            => IotOperationsDataflowProfileProperties(diagnostics, instanceCount, provisioningState, null);

        /// <summary> Initializes a new instance of <see cref="T:Azure.ResourceManager.IotOperations.Models.IotOperationsDataflowProperties" />. </summary>
        /// <param name="mode"> Mode for Dataflow. Optional; defaults to Enabled. </param>
        /// <param name="operations"> List of operations including source and destination references as well as transformation. </param>
        /// <param name="provisioningState"> The status of the last operation. </param>
        /// <returns> A new <see cref="T:Azure.ResourceManager.IotOperations.Models.IotOperationsDataflowProperties" /> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static IotOperationsDataflowProperties IotOperationsDataflowProperties(IotOperationsOperationalMode? mode, IEnumerable<DataflowOperationProperties> operations, IotOperationsProvisioningState? provisioningState)
            => IotOperationsDataflowProperties(mode, null, operations, provisioningState, null);

        /// <summary> Initializes a new instance of <see cref="T:Azure.ResourceManager.IotOperations.Models.IotOperationsInstanceProperties" />. </summary>
        /// <param name="description"> Detailed description of the Instance. </param>
        /// <param name="provisioningState"> The status of the last operation. </param>
        /// <param name="version"> The Azure IoT Operations version. </param>
        /// <param name="schemaRegistryRefResourceId"> The reference to the Schema Registry for this AIO Instance. </param>
        /// <returns> A new <see cref="T:Azure.ResourceManager.IotOperations.Models.IotOperationsInstanceProperties" /> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static IotOperationsInstanceProperties IotOperationsInstanceProperties(string description, IotOperationsProvisioningState? provisioningState, string version, ResourceIdentifier schemaRegistryRefResourceId)
            => IotOperationsInstanceProperties(description, provisioningState, version, schemaRegistryRefResourceId, null, null, null, null);
    }
}
