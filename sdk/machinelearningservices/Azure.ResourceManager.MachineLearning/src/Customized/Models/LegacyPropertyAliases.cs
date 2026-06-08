// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable SA1402 // Backward-compat property aliases are grouped to keep related shims together.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.MachineLearning.Models
{
    // Customized: restore legacy property names over generated TypeSpec-normalized names.
    public partial class MachineLearningEndpointAuthToken
    {
        /// <summary> Access token expiry time. </summary>
        [WirePath("expiryTimeUtc")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DateTimeOffset? ExpireOn => ExpiryTimeUtc.HasValue ? DateTimeOffset.FromUnixTimeSeconds(ExpiryTimeUtc.Value) : null;

        /// <summary> Refresh access token after time. </summary>
        [WirePath("refreshAfterTimeUtc")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DateTimeOffset? RefreshOn => RefreshAfterTimeUtc.HasValue ? DateTimeOffset.FromUnixTimeSeconds(RefreshAfterTimeUtc.Value) : null;
    }

    [CodeGenSuppress("ContainerRegistryCredentials")]
    public partial class MachineLearningWorkspaceGetKeysResult
    {
        /// <summary> The resource ID of the workspace storage. </summary>
        [WirePath("userStorageResourceId")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string UserStorageResourceId => UserStorageArmId;

        /// <summary> Gets the ContainerRegistryCredentials. </summary>
        [WirePath("containerRegistryCredentials")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MachineLearningContainerRegistryCredentials ContainerRegistryCredentials { get; internal set; }
    }

    [CodeGenSuppress("ProvisioningErrors")]
    public abstract partial class MachineLearningComputeProperties
    {
        /// <summary> Errors during provisioning. </summary>
        [WirePath("provisioningErrors")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IReadOnlyList<MachineLearningError> ProvisioningErrors { get; }
    }

    [CodeGenSuppress("Errors")]
    public partial class AmlComputeProperties
    {
        /// <summary> Collection of errors encountered by various compute nodes during node setup. </summary>
        [WirePath("errors")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IReadOnlyList<MachineLearningError> Errors { get; }
    }

    [CodeGenSuppress("Errors")]
    public partial class MachineLearningComputeInstanceProperties
    {
        /// <summary> Collection of errors encountered on this ComputeInstance. </summary>
        [WirePath("errors")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IReadOnlyList<MachineLearningError> Errors { get; }
    }

    [CodeGenSuppress("GroupIds")]
    [CodeGenSuppress("PrivateEndpoint")]
    public partial class RegistryPrivateEndpointConnection
    {
        /// <summary> The group ids. </summary>
        [WirePath("properties.groupIds")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<string> GroupIds
        {
            get
            {
                Properties ??= new RegistryPrivateEndpointConnectionProperties();
                return Properties.GroupIds;
            }
            set
            {
                Properties ??= new RegistryPrivateEndpointConnectionProperties();
                Properties.GroupIds.Clear();
                if (value is not null)
                {
                    foreach (string item in value)
                    {
                        Properties.GroupIds.Add(item);
                    }
                }
            }
        }

        /// <summary> The PE network resource that is linked to this PE connection. </summary>
        [WirePath("properties.privateEndpoint")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public RegistryPrivateEndpoint PrivateEndpoint
        {
            get
            {
                if (Properties?.PrivateEndpoint is null)
                {
                    return default;
                }

                return Properties.PrivateEndpoint is RegistryPrivateEndpoint registryPrivateEndpoint
                    ? registryPrivateEndpoint
                    : new RegistryPrivateEndpoint(Properties.PrivateEndpoint.Id)
                    {
                        SubnetArmId = Properties.PrivateEndpoint.SubnetArmId
                    };
            }
            set
            {
                Properties ??= new RegistryPrivateEndpointConnectionProperties();
                Properties.PrivateEndpoint = value;
            }
        }
    }

    [CodeGenSuppress("ComponentId")]
    public partial class BatchPipelineComponentDeploymentConfiguration
    {
        /// <summary> The ARM id of the component to be run. </summary>
        [WirePath("componentId")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MachineLearningIdAssetReference ComponentId { get; set; }
    }

    [CodeGenSuppress("Limits")]
    public partial class MachineLearningCommandJob
    {
        /// <summary> Command Job limit. </summary>
        [WirePath("limits")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MachineLearningCommandJobLimits Limits { get; set; }
    }

    [CodeGenSuppress("EndpointInvocationDefinition")]
    public partial class MachineLearningEndpointScheduleAction
    {
        /// <summary>
        /// [Required] Defines Schedule action definition details.
        /// <see href="TBD" />
        /// </summary>
        [WirePath("endpointInvocationDefinition")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BinaryData EndpointInvocationDefinition { get; set; }
    }

    [CodeGenSuppress("Identity")]
    public partial class MachineLearningResourcePatchWithIdentity
    {
        /// <summary> Managed service identity (system assigned and/or user assigned identities). </summary>
        [WirePath("identity")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MachineLearningPartialManagedServiceIdentity Identity { get; set; }
    }

    [CodeGenSuppress("Identity")]
    public partial class MachineLearningServerlessEndpointPatch
    {
        /// <summary> Managed service identity (system assigned and/or user assigned identities). </summary>
        [WirePath("identity")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MachineLearningPartialManagedServiceIdentity Identity { get; set; }
    }

    [CodeGenSuppress("PublicNetworkAccess")]
    public partial class MachineLearningOnlineEndpointProperties
    {
        /// <summary> Enum to determine whether PublicNetworkAccess is Enabled or Disabled. </summary>
        [WirePath("publicNetworkAccess")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MachineLearningPublicNetworkAccessType? PublicNetworkAccess { get; set; }
    }

    [CodeGenSuppress("Status")]
    public partial class MachineLearningPrivateLinkServiceConnectionState
    {
        /// <summary> Connection status of the service consumer with the service provider. </summary>
        [WirePath("status")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MachineLearningPrivateEndpointServiceConnectionStatus? Status { get; set; }
    }

    [CodeGenSuppress("Status")]
    public partial class MachineLearningSharedPrivateLinkResource
    {
        /// <summary> Connection status of the service consumer with the service provider. </summary>
        [WirePath("properties.status")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MachineLearningPrivateEndpointServiceConnectionStatus? Status
        {
            get => Properties is null || !Properties.Status.HasValue ? null : new MachineLearningPrivateEndpointServiceConnectionStatus(Properties.Status.Value.ToString());
            set
            {
                Properties ??= new SharedPrivateLinkResourceProperty();
                Properties.Status = value.HasValue ? new EndpointServiceConnectionStatus(value.Value.ToString()) : null;
            }
        }
    }

    [CodeGenSuppress("MachineLearningFeatureProperties")]
    [CodeGenSuppress("DataType")]
    [CodeGenSuppress("FeatureName")]
    public partial class MachineLearningFeatureProperties
    {
        /// <summary> Initializes a new instance of <see cref="MachineLearningFeatureProperties"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MachineLearningFeatureProperties()
        {
        }

        /// <summary> Specifies type. </summary>
        [WirePath("dataType")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FeatureDataType? DataType { get; set; }

        /// <summary> Specifies name. </summary>
        [WirePath("featureName")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string FeatureName { get; set; }
    }

    public partial class MachineLearningFqdnEndpoints
    {
        /// <summary> Gets the FQDN endpoint property bag. </summary>
        [WirePath("properties")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MachineLearningFqdnEndpointsProperties Properties => new MachineLearningFqdnEndpointsProperties(this);
    }

    public partial class MountBindOptions
    {
        /// <summary> Indicate whether to create host path. </summary>
        [WirePath("createHostPath")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? DoesCreateHostPath
        {
            get => CreateHostPath;
            set => CreateHostPath = value;
        }
    }

    public partial class ContainerEndpoint
    {
        /// <summary> Host IP over which the application is exposed from the container. </summary>
        [WirePath("hostIp")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string HostIP
        {
            get => HostIp;
            set => HostIp = value;
        }
    }

    public partial class EnvironmentVariable
    {
        /// <summary> Type of the Environment Variable. </summary>
        [WirePath("type")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public EnvironmentVariableType? VariableType
        {
            get => Type;
            set => Type = value;
        }
    }

    public partial class ImageMetadata
    {
        /// <summary> Whether this compute instance is running on the latest operating system image. </summary>
        [WirePath("isLatestOsImageVersion")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsLatestOSImageVersion => IsLatestOsImageVersion;
    }

    public partial class ImageSetting
    {
        /// <summary> Type of the image. </summary>
        [WirePath("type")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageType? ImageType
        {
            get => Type;
            set => Type = value;
        }
    }

    public partial class MachineLearningAutoPauseProperties
    {
        /// <summary> Gets or sets whether auto pause is enabled. </summary>
        [WirePath("enabled")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsEnabled
        {
            get => Enabled;
            set => Enabled = value;
        }
    }

    public partial class MachineLearningAutoScaleProperties
    {
        /// <summary> Gets or sets whether auto scale is enabled. </summary>
        [WirePath("enabled")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsEnabled
        {
            get => Enabled;
            set => Enabled = value;
        }
    }

    public partial class MachineLearningVmSize
    {
        /// <summary> The number of vCPUs supported by the virtual machine size. </summary>
        [WirePath("vCPUs")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? VCpus => VCPUs;

        /// <summary> The OS VHD disk size, in MB, allowed by the virtual machine size. </summary>
        [WirePath("osVhdSizeMB")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? OSVhdSizeMB => OsVhdSizeMB;

        /// <summary> Specifies if the virtual machine size supports premium IO. </summary>
        [WirePath("premiumIO")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? IsPremiumIOSupported => PremiumIO;
    }

    public partial class ServerlessComputeSettings
    {
        /// <summary> Whether serverless compute nodes have no public IP. </summary>
        [WirePath("serverlessComputeNoPublicIP")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? HasNoPublicIP
        {
            get => ServerlessComputeNoPublicIP;
            set => ServerlessComputeNoPublicIP = value;
        }
    }

    public partial class VolumeDefinition
    {
        /// <summary> Type of Volume Definition. </summary>
        [WirePath("type")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public VolumeDefinitionType? DefinitionType
        {
            get => Type;
            set => Type = value;
        }
    }

    public partial class MachineLearningQuotaProperties
    {
        /// <summary> Specifies the resource type. </summary>
        [WirePath("type")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string QuotaBasePropertiesType
        {
            get => Type;
            set => Type = value;
        }
    }

    public partial class MachineLearningResourceQuota
    {
        /// <summary> Specifies the resource type. </summary>
        [WirePath("type")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ResourceQuotaType => Type;
    }

    public partial class MachineLearningUsage
    {
        /// <summary> Specifies the resource type. </summary>
        [WirePath("type")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string UsageType => Type;
    }

    public partial class MachineLearningWorkspaceQuotaUpdate
    {
        /// <summary> Specifies the resource type. </summary>
        [WirePath("type")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string UpdateWorkspaceQuotasType => Type;
    }

    public partial class ServerlessEndpointProperties
    {
        /// <summary> Specifies the content safety status. </summary>
        [WirePath("contentSafety.contentSafetyStatus")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ContentSafetyStatus? ContentSafetyStatus
        {
            get => ContentSafety?.ContentSafetyStatus;
            set
            {
                if (value.HasValue)
                {
                    ContentSafety ??= new ContentSafety(value.Value);
                    ContentSafety.ContentSafetyStatus = value.Value;
                }
                else
                {
                    ContentSafety = null;
                }
            }
        }
    }

    public partial class RegistryAcrDetails
    {
        /// <summary> ARM resource ID of the generated ACR account. </summary>
        [WirePath("userCreatedAcrAccount.armResourceId.resourceId")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier ArmResourceId
        {
            get => SystemCreatedAcrAccount?.ArmResourceId;
            set
            {
                SystemCreatedAcrAccount ??= new SystemCreatedAcrAccount();
                SystemCreatedAcrAccount.ArmResourceId = value;
            }
        }
    }

    public partial class StorageAccountDetails
    {
        /// <summary> ARM resource ID of the generated storage account. </summary>
        [WirePath("userCreatedStorageAccount.armResourceId.resourceId")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceIdentifier ArmResourceId
        {
            get => SystemCreatedStorageAccount?.ArmResourceId;
            set
            {
                SystemCreatedStorageAccount ??= new SystemCreatedStorageAccount();
                SystemCreatedStorageAccount.ArmResourceId = value;
            }
        }
    }

    public partial class MonitorDefinition
    {
        /// <summary> The email recipient list which has a limitation of 499 characters in total. </summary>
        [WirePath("alertNotificationSettings.emailNotificationSettings.emails")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<string> Emails
        {
            get => AlertNotificationEmails;
            set
            {
                AlertNotificationEmails.Clear();
                if (value is null)
                {
                    return;
                }

                foreach (string email in value)
                {
                    AlertNotificationEmails.Add(email);
                }
            }
        }
    }
}

#pragma warning restore SA1402
