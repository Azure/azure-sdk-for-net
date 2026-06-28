// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.AppService.Models
{
    /// <summary>
    /// GA-compatibility model-factory overloads for the ProxyResource->flat shimmed types:
    /// AppServiceEnvironmentAddressResult, CsmDeploymentStatus, and
    /// SiteAuthSettingsV2. These models are recreated in customization as
    /// `ResourceData`-derived plain models, so their factory entries live here.
    /// </summary>
    public static partial class ArmAppServiceModelFactory
    {
        /// <summary> Initializes a new instance of AppServiceEnvironmentAddressResult. </summary>
        public static AppServiceEnvironmentAddressResult AppServiceEnvironmentAddressResult(
            ResourceIdentifier id = null,
            string name = null,
            ResourceType resourceType = default,
            SystemData systemData = null,
            string kind = null,
            IPAddress serviceIPAddress = null,
            IPAddress internalIPAddress = null,
            IEnumerable<IPAddress> outboundIPAddresses = null,
            IEnumerable<VirtualIPMapping> virtualIPMappings = null)
        {
            outboundIPAddresses ??= new List<IPAddress>();
            virtualIPMappings ??= new List<VirtualIPMapping>();
            return new AppServiceEnvironmentAddressResult(
                id, name, resourceType, systemData,
                kind, serviceIPAddress, internalIPAddress,
                outboundIPAddresses.ToList(), virtualIPMappings.ToList(),
                rawData: null);
        }

        /// <summary> Obsolete overload preserved for source compatibility with previous GA factory signature. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static AppServiceEnvironmentAddressResult AppServiceEnvironmentAddressResult(
            ResourceIdentifier id,
            string name,
            ResourceType resourceType,
            SystemData systemData,
            IPAddress serviceIPAddress,
            IPAddress internalIPAddress,
            IEnumerable<IPAddress> outboundIPAddresses,
            IEnumerable<VirtualIPMapping> virtualIPMappings,
            string kind)
            => AppServiceEnvironmentAddressResult(id, name, resourceType, systemData, kind, serviceIPAddress, internalIPAddress, outboundIPAddresses, virtualIPMappings);

        /// <summary> Initializes a new instance of CsmDeploymentStatus. </summary>
        public static CsmDeploymentStatus CsmDeploymentStatus(
            ResourceIdentifier id = null,
            string name = null,
            ResourceType resourceType = default,
            SystemData systemData = null,
            string kind = null,
            string deploymentId = null,
            DeploymentBuildStatus? status = null,
            int? numberOfInstancesSuccessful = null,
            int? numberOfInstancesInProgress = null,
            int? numberOfInstancesFailed = null,
            IEnumerable<string> failedInstancesLogs = null,
            IEnumerable<ResponseError> errors = null)
        {
            failedInstancesLogs ??= new List<string>();
            errors ??= new List<ResponseError>();
            return new CsmDeploymentStatus(
                id, name, resourceType, systemData,
                kind, deploymentId, status,
                numberOfInstancesSuccessful, numberOfInstancesInProgress, numberOfInstancesFailed,
                failedInstancesLogs.ToList(), errors.ToList(),
                rawData: null);
        }

        /// <summary> Obsolete overload preserved for source compatibility with previous GA factory signature. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CsmDeploymentStatus CsmDeploymentStatus(
            ResourceIdentifier id,
            string name,
            ResourceType resourceType,
            SystemData systemData,
            string deploymentId,
            DeploymentBuildStatus? status,
            int? numberOfInstancesSuccessful,
            int? numberOfInstancesInProgress,
            int? numberOfInstancesFailed,
            IEnumerable<string> failedInstancesLogs,
            IEnumerable<ResponseError> errors,
            string kind)
            => CsmDeploymentStatus(id, name, resourceType, systemData, kind, deploymentId, status, numberOfInstancesSuccessful, numberOfInstancesInProgress, numberOfInstancesFailed, failedInstancesLogs, errors);

        /// <summary> Initializes a new instance of SiteAuthSettingsV2. </summary>
        public static SiteAuthSettingsV2 SiteAuthSettingsV2(
            ResourceIdentifier id = null,
            string name = null,
            ResourceType resourceType = default,
            SystemData systemData = null,
            string kind = null,
            AuthPlatform platform = null,
            GlobalValidation globalValidation = null,
            AppServiceIdentityProviders identityProviders = null,
            WebAppLoginInfo login = null,
            AppServiceHttpSettings httpSettings = null)
        {
            return new SiteAuthSettingsV2(
                id, name, resourceType, systemData,
                kind, platform, globalValidation, identityProviders, login, httpSettings,
                rawData: null);
        }

        /// <summary> Obsolete overload preserved for source compatibility with previous GA factory signature. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static SiteAuthSettingsV2 SiteAuthSettingsV2(
            ResourceIdentifier id,
            string name,
            ResourceType resourceType,
            SystemData systemData,
            AuthPlatform platform,
            GlobalValidation globalValidation,
            AppServiceIdentityProviders identityProviders,
            WebAppLoginInfo login,
            AppServiceHttpSettings httpSettings,
            string kind)
            => SiteAuthSettingsV2(id, name, resourceType, systemData, kind, platform, globalValidation, identityProviders, login, httpSettings);

        // ROOT CAUSE: GA 1.5.0 exposed factory overloads for ResourceNameAvailability,
        // ResourceNameAvailabilityContent, and PrivateLinkConnectionApprovalRequestInfo
        // (all of which survive as customization models). Recreate the GA factory
        // signatures so existing test/sample code continues to compile.

        /// <summary> Initializes a new instance of <see cref="ResourceNameAvailability"/>. </summary>
        public static ResourceNameAvailability ResourceNameAvailability(
            bool? isNameAvailable = default,
            InAvailabilityReasonType? reason = default,
            string message = default)
            => new ResourceNameAvailability(isNameAvailable, reason, message, serializedAdditionalRawData: null);

        /// <summary> Initializes a new instance of <see cref="ResourceNameAvailabilityContent"/>. </summary>
        public static ResourceNameAvailabilityContent ResourceNameAvailabilityContent(
            string name = default,
            CheckNameResourceType resourceType = default,
            bool? isFqdn = default,
            string environmentId = default)
            => new ResourceNameAvailabilityContent(name, resourceType, isFqdn, environmentId, serializedAdditionalRawData: null);

        /// <summary> Initializes a new instance of <see cref="PrivateLinkConnectionApprovalRequestInfo"/>. </summary>
        public static PrivateLinkConnectionApprovalRequestInfo PrivateLinkConnectionApprovalRequestInfo(
            ResourceIdentifier id = null,
            string name = null,
            ResourceType resourceType = default,
            SystemData systemData = null,
            PrivateLinkConnectionState privateLinkServiceConnectionState = null,
            string kind = null)
            => new PrivateLinkConnectionApprovalRequestInfo(id, name, resourceType, systemData, privateLinkServiceConnectionState, kind, serializedAdditionalRawData: null);
    }
}
