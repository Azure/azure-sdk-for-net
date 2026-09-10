// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.ResourceManager.ServiceFabric.Models;

namespace Azure.ResourceManager.ServiceFabric
{
    // Backward-compatible flattened properties for ServiceFabricServiceData.
    // ServiceResource.properties is polymorphic (StatefulServiceProperties / StatelessServiceProperties),
    // so @@flattenProperty cannot be used in the TypeSpec. These shim properties delegate to the
    // generated Properties bag so that existing consumer code continues to compile.
    public partial class ServiceFabricServiceData
    {
        private ServiceResourceProperties EnsureProperties()
        {
            return Properties ?? throw new NotSupportedException("Flattened ServiceFabricServiceData properties cannot be used when Properties is null because the underlying service properties model is discriminated. Set Properties to a concrete StatefulServiceProperties or StatelessServiceProperties instance first.");
        }

        /// <summary> A list that describes the correlation of the service with other services. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<ServiceCorrelationDescription> CorrelationScheme => EnsureProperties().CorrelationScheme;

        /// <summary> Specifies the move cost for the service. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ApplicationMoveCost? DefaultMoveCost
        {
            get => EnsureProperties().DefaultMoveCost;
            set => EnsureProperties().DefaultMoveCost = value;
        }

        /// <summary> Describes how the service is partitioned. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PartitionSchemeDescription PartitionDescription
        {
            get => EnsureProperties().PartitionDescription;
            set => EnsureProperties().PartitionDescription = value;
        }

        /// <summary> The placement constraints as a string. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string PlacementConstraints
        {
            get => EnsureProperties().PlacementConstraints;
            set => EnsureProperties().PlacementConstraints = value;
        }

        /// <summary> The current deployment or provisioning state. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ProvisioningState => EnsureProperties().ProvisioningState;

        /// <summary> Dns name used for the service. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ServiceDnsName
        {
            get => EnsureProperties().ServiceDnsName;
            set => EnsureProperties().ServiceDnsName = value;
        }

        /// <summary> The service load metrics. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<ServiceLoadMetricDescription> ServiceLoadMetrics => EnsureProperties().ServiceLoadMetrics;

        /// <summary> The activation Mode of the service package. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ArmServicePackageActivationMode? ServicePackageActivationMode
        {
            get => EnsureProperties().ServicePackageActivationMode;
            set => EnsureProperties().ServicePackageActivationMode = value;
        }

        /// <summary> A list that describes the service placement policies. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<ServicePlacementPolicyDescription> ServicePlacementPolicies => EnsureProperties().ServicePlacementPolicies;

        /// <summary> The name of the service type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ServiceTypeName
        {
            get => EnsureProperties().ServiceTypeName;
            set => EnsureProperties().ServiceTypeName = value;
        }
    }
}
