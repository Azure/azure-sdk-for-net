// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
        /// <summary> A list that describes the correlation of the service with other services. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<ServiceCorrelationDescription> CorrelationScheme => Properties?.CorrelationScheme;

        /// <summary> Specifies the move cost for the service. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ApplicationMoveCost? DefaultMoveCost
        {
            get => Properties?.DefaultMoveCost;
            set
            {
                if (Properties != null)
                    Properties.DefaultMoveCost = value;
            }
        }

        /// <summary> Describes how the service is partitioned. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PartitionSchemeDescription PartitionDescription
        {
            get => Properties?.PartitionDescription;
            set
            {
                if (Properties != null)
                    Properties.PartitionDescription = value;
            }
        }

        /// <summary> The placement constraints as a string. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string PlacementConstraints
        {
            get => Properties?.PlacementConstraints;
            set
            {
                if (Properties != null)
                    Properties.PlacementConstraints = value;
            }
        }

        /// <summary> The current deployment or provisioning state. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ProvisioningState => Properties?.ProvisioningState;

        /// <summary> Dns name used for the service. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ServiceDnsName
        {
            get => Properties?.ServiceDnsName;
            set
            {
                if (Properties != null)
                    Properties.ServiceDnsName = value;
            }
        }

        /// <summary> The service load metrics. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<ServiceLoadMetricDescription> ServiceLoadMetrics => Properties?.ServiceLoadMetrics;

        /// <summary> The activation Mode of the service package. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ArmServicePackageActivationMode? ServicePackageActivationMode
        {
            get => Properties?.ServicePackageActivationMode;
            set
            {
                if (Properties != null)
                    Properties.ServicePackageActivationMode = value;
            }
        }

        /// <summary> A list that describes the service placement policies. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<ServicePlacementPolicyDescription> ServicePlacementPolicies => Properties?.ServicePlacementPolicies;

        /// <summary> The name of the service type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ServiceTypeName
        {
            get => Properties?.ServiceTypeName;
            set
            {
                if (Properties != null)
                    Properties.ServiceTypeName = value;
            }
        }
    }
}
