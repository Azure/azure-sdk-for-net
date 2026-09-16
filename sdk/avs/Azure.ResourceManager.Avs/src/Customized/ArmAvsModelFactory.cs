// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Avs.Models
{
    /// <summary> Model factory for models. </summary>
    // The generated overloads cannot be used while CommonClusterProperties keeps virtual properties for ApiCompat.
    // TODO: Remove this model factory workaround once https://github.com/Azure/azure-sdk-for-net/issues/59326 is fixed.
    [CodeGenSuppress("AvsManagementCluster", typeof(int?), typeof(AvsPrivateCloudClusterProvisioningState?), typeof(int?), typeof(IEnumerable<string>), typeof(string))]
    [CodeGenSuppress("AvsManagementCluster", typeof(int?), typeof(AvsPrivateCloudClusterProvisioningState?), typeof(int?), typeof(IEnumerable<string>))]
    [CodeGenSuppress("CommonClusterProperties", typeof(int?), typeof(AvsPrivateCloudClusterProvisioningState?), typeof(int?), typeof(IEnumerable<string>))]
    [CodeGenSuppress("AvsHostProperties", typeof(string), typeof(AvsHostProvisioningState?), typeof(string), typeof(string), typeof(string), typeof(AvsHostMaintenance?), typeof(string))]
    [CodeGenSuppress("AvsHostProperties", typeof(string), typeof(AvsHostProvisioningState?), typeof(string), typeof(string), typeof(string), typeof(AvsHostMaintenance?), typeof(string), typeof(IEnumerable<HostLicense>))]
    [CodeGenSuppress("GeneralAvsHostProperties", typeof(AvsHostProvisioningState?), typeof(string), typeof(string), typeof(string), typeof(AvsHostMaintenance?), typeof(string), typeof(IEnumerable<HostLicense>))]
    [CodeGenSuppress("SpecializedAvsHostProperties", typeof(AvsHostProvisioningState?), typeof(string), typeof(string), typeof(string), typeof(AvsHostMaintenance?), typeof(string), typeof(IEnumerable<HostLicense>))]
    [CodeGenSuppress("AvsMaintenanceProperties", typeof(AvsMaintenanceType?), typeof(string), typeof(int?), typeof(IEnumerable<MaintenanceActivity>), typeof(MaintenanceGroup), typeof(MaintenanceRelationships), typeof(string), typeof(string), typeof(bool?), typeof(AvsMaintenanceState), typeof(System.DateTimeOffset?), typeof(long?), typeof(AvsMaintenanceProvisioningState?), typeof(IEnumerable<AvsMaintenanceManagementOperation>), typeof(AvsMaintenanceReadiness))]
    [CodeGenSuppress("AvsScheduleOperation", typeof(bool?), typeof(string), typeof(IEnumerable<AvsScheduleOperationConstraint>), typeof(IEnumerable<MaintenanceWindowRecommendation>))]
    [CodeGenSuppress("AvsRescheduleOperation", typeof(bool?), typeof(string), typeof(IEnumerable<AvsRescheduleOperationConstraint>), typeof(IEnumerable<MaintenanceWindowRecommendation>))]
    public static partial class ArmAvsModelFactory
    {
        /// <summary> The properties of a management cluster. </summary>
        /// <param name="clusterSize"> The cluster size. </param>
        /// <param name="provisioningState"> The state of the cluster provisioning. </param>
        /// <param name="clusterId"> The identity. </param>
        /// <param name="hosts"> The hosts. </param>
        /// <param name="vsanDatastoreName"> Name of the vsan datastore associated with the cluster. </param>
        /// <returns> A new <see cref="Models.AvsManagementCluster"/> instance for mocking. </returns>
        // Preserve the prior public overload including VsanDatastoreName; generated output is suppressed above.
        public static AvsManagementCluster AvsManagementCluster(int? clusterSize = default, AvsPrivateCloudClusterProvisioningState? provisioningState = default, int? clusterId = default, IEnumerable<string> hosts = default, string vsanDatastoreName = default)
        {
            hosts ??= new ChangeTrackingList<string>();

            return new AvsManagementCluster(clusterSize, provisioningState, clusterId, hosts.ToList(), additionalBinaryDataProperties: null)
            {
                VsanDatastoreName = vsanDatastoreName
            };
        }

        /// <summary> The common properties of a cluster. </summary>
        /// <param name="clusterSize"> The cluster size. </param>
        /// <param name="provisioningState"> The state of the cluster provisioning. </param>
        /// <param name="clusterId"> The identity. </param>
        /// <param name="hosts"> The hosts. </param>
        /// <returns> A new <see cref="Models.CommonClusterProperties"/> instance for mocking. </returns>
        // Preserve the prior public overload for the customized virtual property shape.
        public static CommonClusterProperties CommonClusterProperties(int? clusterSize = default, AvsPrivateCloudClusterProvisioningState? provisioningState = default, int? clusterId = default, IEnumerable<string> hosts = default)
        {
            hosts ??= new ChangeTrackingList<string>();

            return new CommonClusterProperties(clusterSize, provisioningState, clusterId, hosts.ToList(), additionalBinaryDataProperties: null);
        }

        /// <summary>
        /// The properties of a host.
        /// Please note this is the abstract base class. The derived classes available for instantiation are: <see cref="Models.GeneralAvsHostProperties"/> and <see cref="Models.SpecializedAvsHostProperties"/>.
        /// </summary>
        /// <param name="kind"> The kind of host. </param>
        /// <param name="provisioningState"> The state of the host provisioning. </param>
        /// <param name="displayName"> Display name of the host in VMware vCenter. </param>
        /// <param name="moRefId"> vCenter managed object reference ID of the host. </param>
        /// <param name="fqdn"> Fully qualified domain name of the host. </param>
        /// <param name="maintenance"> If provided, the host is in maintenance. The value is the reason for maintenance. </param>
        /// <param name="faultDomain"></param>
        /// <returns> A new <see cref="Models.AvsHostProperties"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AvsHostProperties AvsHostProperties(string kind = default, AvsHostProvisioningState? provisioningState = default, string displayName = default, string moRefId = default, string fqdn = default, AvsHostMaintenance? maintenance = default, string faultDomain = default)
        {
            return new UnknownAvsHostProperties(
                default,
                provisioningState,
                displayName,
                moRefId,
                fqdn,
                maintenance,
                faultDomain,
                new ChangeTrackingList<HostLicense>(),
                default);
        }

        /// <summary>
        /// The properties of a host.
        /// Please note this is the abstract base class. The derived classes available for instantiation are: <see cref="Models.GeneralAvsHostProperties"/> and <see cref="Models.SpecializedAvsHostProperties"/>.
        /// </summary>
        /// <param name="kind"> The kind of host. </param>
        /// <param name="provisioningState"> The state of the host provisioning. </param>
        /// <param name="displayName"> Display name of the host in VMware vCenter. </param>
        /// <param name="moRefId"> vCenter managed object reference ID of the host. </param>
        /// <param name="fqdn"> Fully qualified domain name of the host. </param>
        /// <param name="maintenance"> If provided, the host is in maintenance. The value is the reason for maintenance. </param>
        /// <param name="faultDomain"></param>
        /// <param name="licenses"> The licenses assigned to the host. </param>
        /// <returns> A new <see cref="Models.AvsHostProperties"/> instance for mocking. </returns>
        public static AvsHostProperties AvsHostProperties(string kind = default, AvsHostProvisioningState? provisioningState = default, string displayName = default, string moRefId = default, string fqdn = default, AvsHostMaintenance? maintenance = default, string faultDomain = default, IEnumerable<HostLicense> licenses = default)
        {
            licenses ??= new ChangeTrackingList<HostLicense>();

            return new UnknownAvsHostProperties(
                default,
                provisioningState,
                displayName,
                moRefId,
                fqdn,
                maintenance,
                faultDomain,
                licenses.ToList(),
                default);
        }

        /// <summary> The properties of a general host. </summary>
        /// <param name="provisioningState"> The state of the host provisioning. </param>
        /// <param name="displayName"> Display name of the host in VMware vCenter. </param>
        /// <param name="moRefId"> vCenter managed object reference ID of the host. </param>
        /// <param name="fqdn"> Fully qualified domain name of the host. </param>
        /// <param name="maintenance"> If provided, the host is in maintenance. The value is the reason for maintenance. </param>
        /// <param name="faultDomain"></param>
        /// <param name="licenses"> The licenses assigned to the host. </param>
        /// <returns> A new <see cref="Models.GeneralAvsHostProperties"/> instance for mocking. </returns>
        public static GeneralAvsHostProperties GeneralAvsHostProperties(AvsHostProvisioningState? provisioningState = default, string displayName = default, string moRefId = default, string fqdn = default, AvsHostMaintenance? maintenance = default, string faultDomain = default, IEnumerable<HostLicense> licenses = default)
        {
            licenses ??= new ChangeTrackingList<HostLicense>();

            return new GeneralAvsHostProperties(
                default,
                provisioningState,
                displayName,
                moRefId,
                fqdn,
                maintenance,
                faultDomain,
                licenses.ToList(),
                default);
        }

        /// <summary> The properties of a specialized host. </summary>
        /// <param name="provisioningState"> The state of the host provisioning. </param>
        /// <param name="displayName"> Display name of the host in VMware vCenter. </param>
        /// <param name="moRefId"> vCenter managed object reference ID of the host. </param>
        /// <param name="fqdn"> Fully qualified domain name of the host. </param>
        /// <param name="maintenance"> If provided, the host is in maintenance. The value is the reason for maintenance. </param>
        /// <param name="faultDomain"></param>
        /// <param name="licenses"> The licenses assigned to the host. </param>
        /// <returns> A new <see cref="Models.SpecializedAvsHostProperties"/> instance for mocking. </returns>
        public static SpecializedAvsHostProperties SpecializedAvsHostProperties(AvsHostProvisioningState? provisioningState = default, string displayName = default, string moRefId = default, string fqdn = default, AvsHostMaintenance? maintenance = default, string faultDomain = default, IEnumerable<HostLicense> licenses = default)
        {
            licenses ??= new ChangeTrackingList<HostLicense>();

            return new SpecializedAvsHostProperties(
                default,
                provisioningState,
                displayName,
                moRefId,
                fqdn,
                maintenance,
                faultDomain,
                licenses.ToList(),
                default);
        }

        /// <summary> Properties of a maintenance. </summary>
        /// <param name="component"> Type of maintenance. </param>
        /// <param name="displayName"> Display name for maintenance. </param>
        /// <param name="clusterId"> Cluster ID for on which maintenance will be applied. Empty if maintenance is at private cloud level. </param>
        /// <param name="activities"> Activities performed as part of maintenance. </param>
        /// <param name="group"> Group details if maintenance is part of a group. </param>
        /// <param name="relationships"> Relationships with other maintenances like dependencies and prerequisites. </param>
        /// <param name="infoLink"> Link to maintenance info. </param>
        /// <param name="impact"> Impact on the resource during maintenance period. </param>
        /// <param name="isScheduledByMicrosoft"> If maintenance is scheduled by Microsoft. </param>
        /// <param name="state"> The state of the maintenance. </param>
        /// <param name="scheduledStartOn"> Scheduled maintenance start time. </param>
        /// <param name="estimatedDurationInMinutes"> Estimated time maintenance will take in minutes. </param>
        /// <param name="provisioningState"> The provisioning state. </param>
        /// <param name="operations"> Operations on maintenance. </param>
        /// <param name="maintenanceReadiness"> Indicates whether the maintenance is ready to proceed. </param>
        /// <returns> A new <see cref="Models.AvsMaintenanceProperties"/> instance for mocking. </returns>
        public static AvsMaintenanceProperties AvsMaintenanceProperties(AvsMaintenanceType? component = default, string displayName = default, int? clusterId = default, IEnumerable<MaintenanceActivity> activities = default, MaintenanceGroup group = default, MaintenanceRelationships relationships = default, string infoLink = default, string impact = default, bool? isScheduledByMicrosoft = default, AvsMaintenanceState state = default, System.DateTimeOffset? scheduledStartOn = default, long? estimatedDurationInMinutes = default, AvsMaintenanceProvisioningState? provisioningState = default, IEnumerable<AvsMaintenanceManagementOperation> operations = default, AvsMaintenanceReadiness maintenanceReadiness = default)
        {
            activities ??= new ChangeTrackingList<MaintenanceActivity>();
            operations ??= new ChangeTrackingList<AvsMaintenanceManagementOperation>();

            return new AvsMaintenanceProperties(
                component,
                displayName,
                clusterId,
                activities.ToList(),
                group,
                relationships,
                infoLink,
                impact,
                isScheduledByMicrosoft,
                state,
                scheduledStartOn,
                estimatedDurationInMinutes,
                provisioningState,
                operations.ToList(),
                maintenanceReadiness,
                default);
        }

        /// <param name="isDisabled"> If scheduling is disabled. </param>
        /// <param name="disabledReason"> Reason for schedule disabled. </param>
        /// <param name="constraints"> Constraints for scheduling maintenance. </param>
        /// <param name="recommendationMaintenanceWindows"> List of recommended maintenance windows. </param>
        /// <returns> A new <see cref="Models.AvsScheduleOperation"/> instance for mocking. </returns>
        public static AvsScheduleOperation AvsScheduleOperation(bool? isDisabled = default, string disabledReason = default, IEnumerable<AvsScheduleOperationConstraint> constraints = default, IEnumerable<MaintenanceWindowRecommendation> recommendationMaintenanceWindows = default)
        {
            constraints ??= new ChangeTrackingList<AvsScheduleOperationConstraint>();

            return new AvsScheduleOperation(
                default,
                default,
                isDisabled,
                disabledReason,
                constraints.ToList(),
                recommendationMaintenanceWindows is null ? default : new MaintenanceRecommendation(recommendationMaintenanceWindows.ToList(), default));
        }

        /// <param name="isDisabled"> If rescheduling is disabled. </param>
        /// <param name="disabledReason"> Reason for reschedule disabled. </param>
        /// <param name="constraints"> Constraints for rescheduling maintenance. </param>
        /// <param name="recommendationMaintenanceWindows"> List of recommended maintenance windows. </param>
        /// <returns> A new <see cref="Models.AvsRescheduleOperation"/> instance for mocking. </returns>
        public static AvsRescheduleOperation AvsRescheduleOperation(bool? isDisabled = default, string disabledReason = default, IEnumerable<AvsRescheduleOperationConstraint> constraints = default, IEnumerable<MaintenanceWindowRecommendation> recommendationMaintenanceWindows = default)
        {
            constraints ??= new ChangeTrackingList<AvsRescheduleOperationConstraint>();

            return new AvsRescheduleOperation(
                default,
                default,
                isDisabled,
                disabledReason,
                constraints.ToList(),
                recommendationMaintenanceWindows is null ? default : new MaintenanceRecommendation(recommendationMaintenanceWindows.ToList(), default));
        }

        /// <summary> Initializes a new instance of <see cref="Avs.AvsPrivateCloudData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="skuName"> The private cloud SKU. </param>
        /// <param name="identity"> The identity of the private cloud, if configured. Current supported identity types: SystemAssigned, None. </param>
        /// <param name="managementCluster"> The default cluster used for management. </param>
        /// <param name="internet"> Connectivity to internet is enabled or disabled. </param>
        /// <param name="identitySources"> vCenter Single Sign On Identity Sources. </param>
        /// <param name="availability"> Properties describing how the cloud is distributed across availability zones. </param>
        /// <param name="encryption"> Customer managed key encryption, can be enabled or disabled. </param>
        /// <param name="provisioningState"> The provisioning state. </param>
        /// <param name="circuit"> An ExpressRoute Circuit. </param>
        /// <param name="endpoints"> The endpoints. </param>
        /// <param name="networkBlock"> The block of addresses should be unique across VNet in your subscription as well as on-premise. Make sure the CIDR format is conformed to (A.B.C.D/X) where A,B,C,D are between 0 and 255, and X is between 0 and 22. </param>
        /// <param name="managementNetwork"> Network used to access vCenter Server and NSX-T Manager. </param>
        /// <param name="provisioningNetwork"> Used for virtual machine cold migration, cloning, and snapshot migration. </param>
        /// <param name="vMotionNetwork"> Used for live migration of virtual machines. </param>
        /// <param name="vCenterPassword"> Optionally, set the vCenter admin password when the private cloud is created. </param>
        /// <param name="nsxtPassword"> Optionally, set the NSX-T Manager password when the private cloud is created. </param>
        /// <param name="vCenterCertificateThumbprint"> Thumbprint of the vCenter Server SSL certificate. </param>
        /// <param name="nsxtCertificateThumbprint"> Thumbprint of the NSX-T Manager SSL certificate. </param>
        /// <param name="externalCloudLinks"> Array of cloud link IDs from other clouds that connect to this one. </param>
        /// <param name="secondaryCircuit"> A secondary expressRoute circuit from a separate AZ. Only present in a stretched private cloud. </param>
        /// <param name="nsxPublicIPQuotaRaised"> Flag to indicate whether the private cloud has the quota for provisioned NSX Public IP count raised from 64 to 1024. </param>
        /// <returns> A new <see cref="Avs.AvsPrivateCloudData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AvsPrivateCloudData AvsPrivateCloudData(ResourceIdentifier id, string name, ResourceType resourceType, ResourceManager.Models.SystemData systemData, IDictionary<string, string> tags, AzureLocation location, string skuName, ManagedServiceIdentity identity = null, AvsManagementCluster managementCluster = null, InternetConnectivityState? internet = null, IEnumerable<SingleSignOnIdentitySource> identitySources = null, PrivateCloudAvailabilityProperties availability = null, CustomerManagedEncryption encryption = null, AvsPrivateCloudProvisioningState? provisioningState = null, ExpressRouteCircuit circuit = null, AvsPrivateCloudEndpoints endpoints = null, string networkBlock = null, string managementNetwork = null, string provisioningNetwork = null, string vMotionNetwork = null, string vCenterPassword = null, string nsxtPassword = null, string vCenterCertificateThumbprint = null, string nsxtCertificateThumbprint = null, IEnumerable<ResourceIdentifier> externalCloudLinks = null, ExpressRouteCircuit secondaryCircuit = null, NsxPublicIPQuotaRaisedEnum? nsxPublicIPQuotaRaised = null)
            => AvsPrivateCloudData(id, name, resourceType, systemData, tags, location, managementCluster, internet, identitySources, availability, encryption, null, provisioningState, circuit, endpoints, networkBlock, managementNetwork, provisioningNetwork, vMotionNetwork, vCenterPassword, nsxtPassword, vCenterCertificateThumbprint, nsxtCertificateThumbprint, externalCloudLinks, secondaryCircuit, nsxPublicIPQuotaRaised, null, null, new AvsSku(skuName), identity, null);

        /// <summary> Initializes a new instance of <see cref="Avs.AvsPrivateCloudData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="sku"> The SKU (Stock Keeping Unit) assigned to this resource. </param>
        /// <param name="identity"> The managed service identities assigned to this resource. Current supported identity types: None, SystemAssigned. </param>
        /// <param name="managementCluster"> The default cluster used for management. </param>
        /// <param name="internet"> Connectivity to internet is enabled or disabled. </param>
        /// <param name="identitySources"> vCenter Single Sign On Identity Sources. </param>
        /// <param name="availability"> Properties describing how the cloud is distributed across availability zones. </param>
        /// <param name="encryption"> Customer managed key encryption, can be enabled or disabled. </param>
        /// <param name="extendedNetworkBlocks">
        /// Array of additional networks noncontiguous with networkBlock. Networks must be
        /// unique and non-overlapping across VNet in your subscription, on-premise, and
        /// this privateCloud networkBlock attribute. Make sure the CIDR format conforms to
        /// (A.B.C.D/X).
        /// </param>
        /// <param name="provisioningState"> The provisioning state. </param>
        /// <param name="circuit"> An ExpressRoute Circuit. </param>
        /// <param name="endpoints"> The endpoints. </param>
        /// <param name="networkBlock">
        /// The block of addresses should be unique across VNet in your subscription as
        /// well as on-premise. Make sure the CIDR format is conformed to (A.B.C.D/X) where
        /// A,B,C,D are between 0 and 255, and X is between 0 and 22
        /// </param>
        /// <param name="managementNetwork"> Network used to access vCenter Server and NSX-T Manager. </param>
        /// <param name="provisioningNetwork"> Used for virtual machine cold migration, cloning, and snapshot migration. </param>
        /// <param name="vMotionNetwork"> Used for live migration of virtual machines. </param>
        /// <param name="vCenterPassword"> Optionally, set the vCenter admin password when the private cloud is created. </param>
        /// <param name="nsxtPassword"> Optionally, set the NSX-T Manager password when the private cloud is created. </param>
        /// <param name="vCenterCertificateThumbprint"> Thumbprint of the vCenter Server SSL certificate. </param>
        /// <param name="nsxtCertificateThumbprint"> Thumbprint of the NSX-T Manager SSL certificate. </param>
        /// <param name="externalCloudLinks"> Array of cloud link IDs from other clouds that connect to this one. </param>
        /// <param name="secondaryCircuit">
        /// A secondary expressRoute circuit from a separate AZ. Only present in a
        /// stretched private cloud
        /// </param>
        /// <param name="nsxPublicIPQuotaRaised">
        /// Flag to indicate whether the private cloud has the quota for provisioned NSX
        /// Public IP count raised from 64 to 1024
        /// </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AvsPrivateCloudData AvsPrivateCloudData(ResourceIdentifier id, string name, ResourceType resourceType, ResourceManager.Models.SystemData systemData, IDictionary<string, string> tags, AzureLocation location, string sku, ManagedServiceIdentity identity = null, AvsManagementCluster managementCluster = null, InternetConnectivityState? internet = null, IEnumerable<SingleSignOnIdentitySource> identitySources = null, PrivateCloudAvailabilityProperties availability = null, CustomerManagedEncryption encryption = null, IEnumerable<string> extendedNetworkBlocks = null, AvsPrivateCloudProvisioningState? provisioningState = null, ExpressRouteCircuit circuit = null, AvsPrivateCloudEndpoints endpoints = null, string networkBlock = null, string managementNetwork = null, string provisioningNetwork = null, string vMotionNetwork = null, string vCenterPassword = null, string nsxtPassword = null, string vCenterCertificateThumbprint = null, string nsxtCertificateThumbprint = null, IEnumerable<ResourceIdentifier> externalCloudLinks = null, ExpressRouteCircuit secondaryCircuit = null, NsxPublicIPQuotaRaisedEnum? nsxPublicIPQuotaRaised = null)
            => AvsPrivateCloudData(id, name, resourceType, systemData, tags, location, managementCluster, internet, identitySources, availability, encryption, extendedNetworkBlocks, provisioningState, circuit, endpoints, networkBlock, managementNetwork, provisioningNetwork, vMotionNetwork, vCenterPassword, nsxtPassword, vCenterCertificateThumbprint, nsxtCertificateThumbprint, externalCloudLinks, secondaryCircuit, nsxPublicIPQuotaRaised, null, null, null, new AvsSku(sku), identity, null);

        /// <summary> Initializes a new instance of <see cref="Avs.AvsPrivateCloudClusterData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="sku"> The SKU (Stock Keeping Unit) assigned to this resource. </param>
        /// <param name="clusterSize"> The cluster size. </param>
        /// <param name="provisioningState"> The state of the cluster provisioning. </param>
        /// <param name="clusterId"> The identity. </param>
        /// <param name="hosts"> The hosts. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AvsPrivateCloudClusterData AvsPrivateCloudClusterData(ResourceIdentifier id, string name, ResourceType resourceType, ResourceManager.Models.SystemData systemData, string sku, int? clusterSize, AvsPrivateCloudClusterProvisioningState? provisioningState, int? clusterId, IEnumerable<string> hosts)
            => AvsPrivateCloudClusterData(id, name, resourceType, systemData, new AvsSku(sku), clusterSize, provisioningState, clusterId, hosts, null);

        /// <summary> Initializes a new instance of <see cref="Models.AvsManagementCluster"/>. </summary>
        /// <param name="clusterSize"> The cluster size. </param>
        /// <param name="provisioningState"> The state of the cluster provisioning. </param>
        /// <param name="clusterId"> The identity. </param>
        /// <param name="hosts"> The hosts. </param>
        /// <returns> A new <see cref="Models.AvsManagementCluster"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        // Hidden compatibility overload from the previous generated API; delegate to the new overload.
        public static AvsManagementCluster AvsManagementCluster(int? clusterSize, AvsPrivateCloudClusterProvisioningState? provisioningState, int? clusterId, IEnumerable<string> hosts)
            => AvsManagementCluster(clusterSize: clusterSize, provisioningState: provisioningState, clusterId: clusterId, hosts: hosts, vsanDatastoreName: default);

        /// <summary> Initializes a new instance of <see cref="Avs.AvsPrivateCloudClusterData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="clusterSize"> The cluster size. </param>
        /// <param name="provisioningState"> The state of the cluster provisioning. </param>
        /// <param name="clusterId"> The identity. </param>
        /// <param name="hosts"> The hosts. </param>
        /// <param name="vsanDatastoreName"> Name of the vsan datastore associated with the cluster. </param>
        /// <param name="sku"> The SKU (Stock Keeping Unit) assigned to this resource. </param>
        /// <returns> A new <see cref="Avs.AvsPrivateCloudClusterData"/> instance for mocking. </returns>
        public static AvsPrivateCloudClusterData AvsPrivateCloudClusterData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, int? clusterSize, AvsPrivateCloudClusterProvisioningState? provisioningState = null, int? clusterId = null, IEnumerable<string> hosts = null, string vsanDatastoreName = null, AvsSku sku = null)
            => AvsPrivateCloudClusterData(id, name, resourceType, systemData, sku, clusterSize, provisioningState, clusterId, hosts, vsanDatastoreName);

        /// <summary> Initializes a new instance of <see cref="Avs.AvsPrivateCloudDatastoreData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="provisioningState"> The state of the datastore provisioning. </param>
        /// <param name="netAppVolumeId"> An Azure NetApp Files volume. </param>
        /// <param name="diskPoolVolume"> An iSCSI volume. </param>
        /// <param name="status"> The operational status of the datastore. </param>
        /// <returns> A new <see cref="Avs.AvsPrivateCloudDatastoreData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AvsPrivateCloudDatastoreData AvsPrivateCloudDatastoreData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, AvsPrivateCloudDatastoreProvisioningState? provisioningState, ResourceIdentifier netAppVolumeId, DiskPoolVolume diskPoolVolume, DatastoreStatus? status)
            => AvsPrivateCloudDatastoreData(id, name, resourceType, systemData, provisioningState, netAppVolumeId, diskPoolVolume, null, null, status);

        /// <summary> Initializes a new instance of <see cref="Avs.AvsPrivateCloudDatastoreData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="provisioningState"> The state of the datastore provisioning. </param>
        /// <param name="netAppVolumeId"> An Azure NetApp Files volume. </param>
        /// <param name="diskPoolVolume"> An iSCSI volume. </param>
        /// <param name="elasticSanVolumeTargetId"> An Elastic SAN volume. </param>
        /// <param name="status"> The operational status of the datastore. </param>
        /// <returns> A new <see cref="Avs.AvsPrivateCloudDatastoreData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AvsPrivateCloudDatastoreData AvsPrivateCloudDatastoreData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, AvsPrivateCloudDatastoreProvisioningState? provisioningState, ResourceIdentifier netAppVolumeId, DiskPoolVolume diskPoolVolume, ResourceIdentifier elasticSanVolumeTargetId, DatastoreStatus? status)
            => AvsPrivateCloudDatastoreData(id, name, resourceType, systemData, provisioningState, netAppVolumeId, diskPoolVolume, elasticSanVolumeTargetId, null, status);

        /// <summary> Initializes a new instance of <see cref="Avs.WorkloadNetworkVmGroupData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="displayName"> Display name of the VM group. </param>
        /// <param name="members"> Virtual machine members of this group. </param>
        /// <param name="status"> VM Group status. </param>
        /// <param name="provisioningState"> The provisioning state. </param>
        /// <param name="revision"> NSX revision number. </param>
        /// <returns> A new <see cref="Avs.WorkloadNetworkVmGroupData"/> instance for mocking. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static WorkloadNetworkVmGroupData WorkloadNetworkVmGroupData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, string displayName = null, IEnumerable<string> members = null, WorkloadNetworkVmGroupStatus? status = null, WorkloadNetworkVmGroupProvisioningState? provisioningState = null, long? revision = null)
        {
            return new WorkloadNetworkVmGroupData(
                id,
                name,
                resourceType,
                systemData,
                displayName is null && members is null ? default : new WorkloadNetworkVmGroupProperties(displayName, members?.ToList(), status, provisioningState, revision, null),
                null);
        }
    }
}
