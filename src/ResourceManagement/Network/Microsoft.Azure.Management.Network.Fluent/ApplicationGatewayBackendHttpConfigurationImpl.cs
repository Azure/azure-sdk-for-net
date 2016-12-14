﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using ApplicationGatewayBackendHttpConfiguration.Definition;
    using ApplicationGatewayBackendHttpConfiguration.UpdateDefinition;
    using Models;
    using Resource.Fluent.Core;
    using Resource.Fluent.Core.ChildResourceActions;

    /// <summary>
    /// Implementation for ApplicationGatewayBackendHttpConfiguration.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uQXBwbGljYXRpb25HYXRld2F5QmFja2VuZEh0dHBDb25maWd1cmF0aW9uSW1wbA==
    internal partial class ApplicationGatewayBackendHttpConfigurationImpl :
        ChildResource<ApplicationGatewayBackendHttpSettingsInner, ApplicationGatewayImpl, IApplicationGateway>,
        IApplicationGatewayBackendHttpConfiguration,
        IDefinition<ApplicationGateway.Definition.IWithCreate>,
        IUpdateDefinition<ApplicationGateway.Update.IUpdate>,
        ApplicationGatewayBackendHttpConfiguration.Update.IUpdate
    {
        ///GENMHASH:B42BC3A9C7262D63AB700D3AA7560DE4:C0847EA0CDA78F6D91EFD239C70F0FA7
        internal ApplicationGatewayBackendHttpConfigurationImpl(ApplicationGatewayBackendHttpSettingsInner inner, ApplicationGatewayImpl parent) : base(inner, parent)
        {
        }

        #region Accessors

        ///GENMHASH:D319F463FBCA0E7C5434F8E5BDE378E5:21C8F5F4674718D4F9BB874ED4B6C86E
        public int RequestTimeout()
        {
            if (Inner.RequestTimeout != null)
            {
                return Inner.RequestTimeout.Value;
            }
            else
            {
                return 0;
            }
        }

        ApplicationGateway.Update.IUpdate ISettable<ApplicationGateway.Update.IUpdate>.Parent()
        {
            return Parent;
        }

        ///GENMHASH:D684E7477889A9013C81FAD82F69C54F:BD249A015EF71106387B78281489583A
        public ApplicationGatewayProtocol Protocol()
        {
            return ApplicationGatewayProtocol.Parse(Inner.Protocol);
        }

        ///GENMHASH:BF1200B4E784F046AF04467F35BAC1C4:C151EBC301EA3EE8C113856084E73D31
        public int Port()
        {
            return Inner.Port != null ? Inner.Port.Value : 0;
        }

        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:61C1065B307679F3800C701AE0D87070
        public override string Name()
        {
            return Inner.Name;
        }

        ///GENMHASH:0BBB3340617BD27DD6A3E851FD10BEE1:D4B1DE858DBE0FCA40F8B11A09E4AE8E
        public bool CookieBasedAffinity()
        {
            if (Inner.CookieBasedAffinity != null)
            {
                return Inner.CookieBasedAffinity.ToLower().Equals(ApplicationGatewayCookieBasedAffinity.Enabled.ToLower());
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region Withers

        ///GENMHASH:1B3DD32E4CACEF2636F8CF7212EEF52E:9E143B49CA62E36912E10621B5CA8F8C
        public ApplicationGatewayBackendHttpConfigurationImpl WithRequestTimeout(int seconds)
        {
            Inner.RequestTimeout = seconds;
            return this;
        }

        ///GENMHASH:A473E8C551A81C93BD8EA73FE99E314B:8E47A7551FAA8958BCB5314D0E665506
        public ApplicationGatewayBackendHttpConfigurationImpl WithProtocol(ApplicationGatewayProtocol protocol)
        {
            Inner.Protocol = (protocol != null) ? protocol.ToString() : null;
            return this;
        }

        ///GENMHASH:7884DB3A8071CC7B3FBB06615EBA996B:CA52EFCC70207EE737066999569A5D75
        public ApplicationGatewayBackendHttpConfigurationImpl WithPort(int port)
        {
            Inner.Port = port;
            return this;
        }

        ///GENMHASH:1AB1FD137FCAFECBC19E784B21600422:6BB24B56EA50DCC3F395622096E46000
        public ApplicationGatewayBackendHttpConfigurationImpl WithoutCookieBasedAffinity()
        {
            Inner.CookieBasedAffinity = ApplicationGatewayCookieBasedAffinity.Disabled;
            return this;
        }

        ///GENMHASH:389A52ADE2A3CD0EC1D4345823ED3438:F757DEFCD2347931069D56892B798728
        public ApplicationGatewayBackendHttpConfigurationImpl WithCookieBasedAffinity()
        {
            Inner.CookieBasedAffinity = ApplicationGatewayCookieBasedAffinity.Enabled;
            return this;
        }

        #endregion

        #region Actions

        ///GENMHASH:077EB7776EFFBFAA141C1696E75EF7B3:EA0F53B8E1A36EBC1DB975D85320CCC5
        public ApplicationGatewayImpl Attach()
        {
            Parent.WithBackendHttpConfiguration(this);
            return Parent;
        }

        #endregion
    }
}