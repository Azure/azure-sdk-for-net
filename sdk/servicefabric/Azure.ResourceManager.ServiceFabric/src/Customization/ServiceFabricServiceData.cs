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
        private ServiceResourceProperties RequireProperties()
        {
            return Properties ?? throw new InvalidOperationException("ServiceFabricServiceData.Properties must be initialized to a StatefulServiceProperties or StatelessServiceProperties instance before accessing flattened members.");
        }

        /// <summary> A list that describes the correlation of the service with other services. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<ServiceCorrelationDescription> CorrelationScheme => RequireProperties().CorrelationScheme;

        /// <summary> Specifies the move cost for the service. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ApplicationMoveCost? DefaultMoveCost
        {
            get => RequireProperties().DefaultMoveCost;
            set => RequireProperties().DefaultMoveCost = value;
        }

        /// <summary> Describes how the service is partitioned. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PartitionSchemeDescription PartitionDescription
        {
            get => RequireProperties().PartitionDescription;
            set => RequireProperties().PartitionDescription = value;
        }

        /// <summary> The placement constraints as a string. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string PlacementConstraints
        {
            get => RequireProperties().PlacementConstraints;
            set => RequireProperties().PlacementConstraints = value;
        }

        /// <summary> The current deployment or provisioning state. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ProvisioningState => RequireProperties().ProvisioningState;

        /// <summary> Dns name used for the service. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ServiceDnsName
        {
            get => RequireProperties().ServiceDnsName;
            set => RequireProperties().ServiceDnsName = value;
        }

        /// <summary> The service load metrics. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<ServiceLoadMetricDescription> ServiceLoadMetrics => RequireProperties().ServiceLoadMetrics;

        /// <summary> The activation Mode of the service package. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ArmServicePackageActivationMode? ServicePackageActivationMode
        {
            get => RequireProperties().ServicePackageActivationMode;
            set => RequireProperties().ServicePackageActivationMode = value;
        }

        /// <summary> A list that describes the service placement policies. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<ServicePlacementPolicyDescription> ServicePlacementPolicies => RequireProperties().ServicePlacementPolicies;

        /// <summary> The name of the service type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ServiceTypeName
        {
            get => RequireProperties().ServiceTypeName;
            set => RequireProperties().ServiceTypeName = value;
        }
    }
}
