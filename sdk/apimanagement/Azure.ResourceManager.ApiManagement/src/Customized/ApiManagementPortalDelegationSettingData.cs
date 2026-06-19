// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.ResourceManager.ApiManagement.Models;

namespace Azure.ResourceManager.ApiManagement
{
    public partial class ApiManagementPortalDelegationSettingData
    {
        // PortalDelegationSettings.properties flatten is excluded for csharp in back-compatible.tsp
        // (the global flatten was removed because the generator doesn't flatten this resource data).
        // These shortcuts delegate into the nested Properties bag for backward compat.

        /// <summary> A delegation Url. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
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
        [EditorBrowsable(EditorBrowsableState.Never)]
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

        // Deep path shortcuts (properties.subscriptions.enabled, properties.userRegistration.enabled).
        // Two levels past properties — not fixable by @@flattenProperty.

        /// <summary> Enable or disable delegation for subscriptions. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.subscriptions.enabled")]
        public bool? IsSubscriptionDelegationEnabled
        {
            get => Properties?.Subscriptions?.IsSubscriptionDelegationEnabled;
            set => Subscriptions.IsSubscriptionDelegationEnabled = value;
        }

        /// <summary> Enable or disable delegation for user registration. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
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
}
