// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable SA1402 // File may only contain a single type
#pragma warning disable SA1649 // File name should match first type name

using System;
using Azure.Core;
using Azure.ResourceManager.ApiManagement.Models;

namespace Azure.ResourceManager.ApiManagement
{
    public partial class ApiGatewayData
    {
        /// <summary> The ARM ID of the subnet in which the backend systems are hosted. </summary>
        [WirePath("properties.backend.subnet.id")]
        public ResourceIdentifier SubnetId
        {
            get => BackendSubnetId is null ? default : new ResourceIdentifier(BackendSubnetId);
            set => BackendSubnetId = value?.ToString();
        }
    }

    public partial class ApiManagementPrivateEndpointConnectionData
    {
        /// <summary> A collection of information about the state of the connection between service consumer and provider. </summary>
        [WirePath("properties.privateLinkServiceConnectionState")]
        public ApiManagementPrivateLinkServiceConnectionState ConnectionState
        {
            get => PrivateLinkServiceConnectionState;
            set => PrivateLinkServiceConnectionState = value;
        }
    }

    public partial class ApiManagementGroupData
    {
        /// <summary> Group type. </summary>
        [WirePath("properties.type")]
        public ApiManagementGroupType? GroupType
        {
            get => ApiManagementGroupType;
            set => ApiManagementGroupType = value;
        }
    }

    public partial class ApiManagementPortalDelegationSettingData
    {
        /// <summary> A delegation Url. </summary>
        [WirePath("properties.url")]
        public Uri Uri
        {
            get => Properties is null ? default : Properties.Uri;
            set
            {
                if (Properties is null)
                {
                    Properties = new PortalDelegationSettingsProperties();
                }
                Properties.Uri = value;
            }
        }

        /// <summary> A base64-encoded validation key to validate, that a request is coming from Azure API Management. </summary>
        [WirePath("properties.validationKey")]
        public string ValidationKey
        {
            get => Properties is null ? default : Properties.ValidationKey;
            set
            {
                if (Properties is null)
                {
                    Properties = new PortalDelegationSettingsProperties();
                }
                Properties.ValidationKey = value;
            }
        }

        /// <summary> Enable or disable delegation for subscriptions. </summary>
        [WirePath("properties.subscriptions.enabled")]
        public bool? IsSubscriptionDelegationEnabled
        {
            get => Properties?.Subscriptions?.IsSubscriptionDelegationEnabled;
            set => Subscriptions.IsSubscriptionDelegationEnabled = value;
        }

        /// <summary> Enable or disable delegation for user registration. </summary>
        [WirePath("properties.userRegistration.enabled")]
        public bool? IsUserRegistrationDelegationEnabled
        {
            get => Properties?.UserRegistration?.IsUserRegistrationDelegationEnabled;
            set => UserRegistration.IsUserRegistrationDelegationEnabled = value;
        }

        /// <summary> Subscriptions delegation settings. </summary>
        [WirePath("properties.subscriptions")]
        internal SubscriptionDelegationSettingProperties Subscriptions
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new PortalDelegationSettingsProperties();
                }
                return Properties.Subscriptions ??= new SubscriptionDelegationSettingProperties();
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new PortalDelegationSettingsProperties();
                }
                Properties.Subscriptions = value;
            }
        }

        /// <summary> User registration delegation settings. </summary>
        [WirePath("properties.userRegistration")]
        internal RegistrationDelegationSettingProperties UserRegistration
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new PortalDelegationSettingsProperties();
                }
                return Properties.UserRegistration ??= new RegistrationDelegationSettingProperties();
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new PortalDelegationSettingsProperties();
                }
                Properties.UserRegistration = value;
            }
        }
    }

    public partial class ApiOperationData
    {
        /// <summary> Relative URL template identifying the target resource for this operation. </summary>
        [WirePath("properties.urlTemplate")]
        public string UriTemplate
        {
            get => UrlTemplate;
            set => UrlTemplate = value;
        }
    }
}

namespace Azure.ResourceManager.ApiManagement.Models
{
    public partial class AssociatedOperationProperties
    {
        /// <summary> Relative URL template identifying the target resource for this operation. </summary>
        [WirePath("urlTemplate")]
        public string UriTemplate => UrlTemplate;
    }

    public partial class ConnectivityHop
    {
        /// <summary> The type of the hop. </summary>
        [WirePath("type")]
        public string ConnectivityHopType => Type;
    }

    public partial class ParameterContract
    {
        /// <summary> Parameter type. </summary>
        [WirePath("type")]
        public string ParameterContractType
        {
            get => Type;
            set => Type = value;
        }
    }

    public partial class ApiGatewayPatch
    {
        /// <summary> The ARM ID of the subnet in which the backend systems are hosted. </summary>
        [WirePath("properties.backend.subnet.id")]
        public ResourceIdentifier SubnetId
        {
            get => BackendSubnetId is null ? default : new ResourceIdentifier(BackendSubnetId);
            set => BackendSubnetId = value?.ToString();
        }
    }

    public partial class ApiManagementBackendPatch
    {
        /// <summary> Type of the backend. A backend can be either Single or Pool. </summary>
        [WirePath("properties.type")]
        public BackendType? BackendType
        {
            get => TypePropertiesType;
            set => TypePropertiesType = value;
        }
    }

    public partial class ConfigurationDeployContent
    {
        /// <summary> The value enforcing deleting subscriptions to products that are deleted in this update. </summary>
        [WirePath("properties.force")]
        public bool? ForceDelete
        {
            get => Force;
            set => Force = value;
        }
    }

    public partial class DiagnosticUpdateContract
    {
        /// <summary> Log the ClientIP. Default is false. </summary>
        [WirePath("properties.logClientIp")]
        public bool? IsLogClientIPEnabled
        {
            get => LogClientIp;
            set => LogClientIp = value;
        }
    }

    public partial class TenantAccessInfoCreateOrUpdateContent
    {
        /// <summary> Determines whether direct access is enabled. </summary>
        [WirePath("properties.enabled")]
        public bool? IsDirectAccessEnabled
        {
            get => Enabled;
            set => Enabled = value;
        }
    }

    public partial class TenantAccessInfoPatch
    {
        /// <summary> Determines whether direct access is enabled. </summary>
        [WirePath("properties.enabled")]
        public bool? IsDirectAccessEnabled
        {
            get => Enabled;
            set => Enabled = value;
        }
    }

    public partial class UserTokenContent
    {
        /// <summary> The Expiry time of the Token. </summary>
        [WirePath("properties.expiry")]
        public DateTimeOffset? ExpireOn
        {
            get => Properties?.ExpireOn;
            set
            {
                if (value.HasValue)
                {
                    Properties ??= new UserTokenParameterProperties();
                    Properties.ExpireOn = value.Value;
                }
            }
        }
    }

    public partial class ApiOperationPatch
    {
        /// <summary> Relative URL template identifying the target resource for this operation. </summary>
        [WirePath("properties.urlTemplate")]
        public string UriTemplate
        {
            get => UrlTemplate;
            set => UrlTemplate = value;
        }
    }
}
