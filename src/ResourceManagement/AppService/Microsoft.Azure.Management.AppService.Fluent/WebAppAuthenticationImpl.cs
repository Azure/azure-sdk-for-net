// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using Microsoft.Azure.Management.AppService.Fluent.WebAppAuthentication.Definition;
    using Microsoft.Azure.Management.AppService.Fluent.WebAppAuthentication.Update;
    using Microsoft.Azure.Management.AppService.Fluent.WebAppAuthentication.UpdateDefinition;
    using Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition;
    using Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// Implementation for WebAppAuthentication and its create and update interfaces.
    /// </summary>
    /// <typeparam name="FluentT">The fluent interface of the parent web app.</typeparam>
    /// <typeparam name="FluentImplT">The fluent implementation of the parent web app.</typeparam>
    internal partial class WebAppAuthenticationImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT>  :
        IndexableWrapperImpl<Models.SiteAuthSettingsInner>,
        IWebAppAuthentication,
        IDefinition<WebAppBase.Definition.IWithCreate<FluentT>>,
        IUpdateDefinition<WebAppBase.Update.IUpdate<FluentT>>,
        WebAppAuthentication.Update.IUpdate<WebAppBase.Update.IUpdate<FluentT>>
        where FluentImplT : WebAppBaseImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT>, FluentT
        where FluentT : class, IWebAppBase
        where DefAfterRegionT : class
        where DefAfterGroupT : class
        where UpdateT : class, WebAppBase.Update.IUpdate<FluentT>
    {
        private WebAppBaseImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> parent;
                public WebAppAuthenticationImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> WithMicrosoft(string clientId, string clientSecret)
        {
            //$ inner().WithMicrosoftAccountClientId(clientId).WithMicrosoftAccountClientSecret(clientSecret);
            //$ return this;

            return this;
        }

                public WebAppAuthenticationImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> WithAnonymousAuthentication()
        {
            //$ inner().WithUnauthenticatedClientAction(UnauthenticatedClientAction.ALLOW_ANONYMOUS);
            //$ return this;

            return this;
        }

                public FluentImplT Attach()
        {
            //$ parent.WithAuthentication(this);
            //$ return parent();

            return default(FluentImplT);
        }

                public WebAppAuthenticationImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> WithFacebook(string appId, string appSecret)
        {
            //$ inner().WithFacebookAppId(appId).WithFacebookAppSecret(appSecret);
            //$ return this;

            return this;
        }

                public FluentImplT Parent()
        {
            //$ public FluentImplT parent() {
            //$ parent.WithAuthentication(this);
            //$ return (FluentImplT) this.parent;

            return default(FluentImplT);
        }

                public WebAppAuthenticationImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> WithDefaultAuthenticationProvider(BuiltInAuthenticationProvider provider)
        {
            //$ inner().WithUnauthenticatedClientAction(UnauthenticatedClientAction.REDIRECT_TO_LOGIN_PAGE).WithDefaultProvider(provider);
            //$ return this;

            return this;
        }

                public WebAppAuthenticationImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> WithTwitter(string apiKey, string apiSecret)
        {
            //$ inner().WithTwitterConsumerKey(apiKey).WithTwitterConsumerSecret(apiSecret);
            //$ return this;

            return this;
        }

                public WebAppAuthenticationImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> WithAllowedExternalRedirectUrl(string url)
        {
            //$ if (inner().AllowedExternalRedirectUrls() == null) {
            //$ inner().WithAllowedExternalRedirectUrls(new ArrayList<String>());
            //$ }
            //$ inner().AllowedExternalRedirectUrls().Add(url);
            //$ return this;

            return this;
        }

                public WebAppAuthenticationImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> WithTokenStore(bool enabled)
        {
            //$ inner().WithTokenStoreEnabled(enabled);
            //$ return this;

            return this;
        }

                public WebAppAuthenticationImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> WithGoogle(string clientId, string clientSecret)
        {
            //$ inner().WithGoogleClientId(clientId).WithGoogleClientSecret(clientSecret);
            //$ return this;

            return this;
        }

                public WebAppAuthenticationImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> WithActiveDirectory(string clientId, string issuerUrl)
        {
            //$ inner().WithClientId(clientId).WithIssuer(issuerUrl);
            //$ return this;

            return this;
        }

                internal  WebAppAuthenticationImpl(SiteAuthSettingsInner inner, WebAppBaseImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> parent)
        {
            //$ super(inner);
            //$ this.parent = parent;
            //$ inner.WithLocation(parent.RegionName());
            //$ inner.WithTokenStoreEnabled(true);
            //$ }

        }

<<<<<<<<<<<<<<<<<<<<<<<<<<<NEW>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///GENMHASH:B6C01C5B033B0AEC8586430851CF2885:0F84D84BC69CE5BC4511F30705E1A909
        public WebAppAuthenticationImpl<FluentT,FluentImplT> WithActiveDirectory(string clientId, string issuerUrl)
        {
            //$ inner().WithClientId(clientId).WithIssuer(issuerUrl);
            //$ return this;

            return this;
        }

<<<<<<<<<<<<<<<<<<<<<<<<<<<NEW>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///GENMHASH:C3CD45856BFDB95BF32832524FE9644B:A85205525CAD210BA3ECB73C7ECB52A5
        public WebAppAuthenticationImpl<FluentT,FluentImplT> WithGoogle(string clientId, string clientSecret)
        {
            //$ inner().WithGoogleClientId(clientId).WithGoogleClientSecret(clientSecret);
            //$ return this;

            return this;
        }

<<<<<<<<<<<<<<<<<<<<<<<<<<<NEW>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///GENMHASH:629F5C2F24635A4E2773CF0E2A6FF1C8:B2E3A2339790D0B8FAAB78BB2BB31756
        public WebAppAuthenticationImpl<FluentT,FluentImplT> WithTokenStore(bool enabled)
        {
            //$ inner().WithTokenStoreEnabled(enabled);
            //$ return this;

            return this;
        }

<<<<<<<<<<<<<<<<<<<<<<<<<<<NEW>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///GENMHASH:95B41B7C2244FA05942DF402FAB6B2A6:EC5CC4173E34912C38D03F88669191E7
        public WebAppAuthenticationImpl<FluentT,FluentImplT> WithAllowedExternalRedirectUrl(string url)
        {
            //$ if (inner().AllowedExternalRedirectUrls() == null) {
            //$ inner().WithAllowedExternalRedirectUrls(new ArrayList<String>());
            //$ }
            //$ inner().AllowedExternalRedirectUrls().Add(url);
            //$ return this;

            return this;
        }

<<<<<<<<<<<<<<<<<<<<<<<<<<<NEW>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///GENMHASH:23D7C7D2F7E99717590BF05A1508D344:BF8493001099CB6FFB09BF0D4E243B10
        public WebAppAuthenticationImpl<FluentT,FluentImplT> WithTwitter(string apiKey, string apiSecret)
        {
            //$ inner().WithTwitterConsumerKey(apiKey).WithTwitterConsumerSecret(apiSecret);
            //$ return this;

            return this;
        }

<<<<<<<<<<<<<<<<<<<<<<<<<<<NEW>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///GENMHASH:3A9C02B5EC8D40B1F081022A1F5F2B4F:108B85D77162FEA1CF34E43C5606ADE2
        public WebAppAuthenticationImpl<FluentT,FluentImplT> WithDefaultAuthenticationProvider(BuiltInAuthenticationProvider provider)
        {
            //$ inner().WithUnauthenticatedClientAction(UnauthenticatedClientAction.REDIRECT_TO_LOGIN_PAGE).WithDefaultProvider(provider);
            //$ return this;

            return this;
        }

<<<<<<<<<<<<<<<<<<<<<<<<<<<NEW>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///GENMHASH:FD5D5A8D6904B467321E345BE1FA424E:22D6A04114BC348654147EDB4D83A9C6
        public FluentImplT Parent()
        {
            //$ public FluentImplT parent() {
            //$ parent.WithAuthentication(this);
            //$ return (FluentImplT) this.parent;

            return default(FluentImplT);
        }

<<<<<<<<<<<<<<<<<<<<<<<<<<<NEW>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///GENMHASH:27B8F97F7CEF7E7DF904BB9A4D9D4663:ACCD56D05658AC17A6FF60880C59627F
        public WebAppAuthenticationImpl<FluentT,FluentImplT> WithFacebook(string appId, string appSecret)
        {
            //$ inner().WithFacebookAppId(appId).WithFacebookAppSecret(appSecret);
            //$ return this;

            return this;
        }

<<<<<<<<<<<<<<<<<<<<<<<<<<<NEW>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///GENMHASH:077EB7776EFFBFAA141C1696E75EF7B3:57D4DB11AAD6F64DA8325FC493D2DBF1
        public FluentImplT Attach()
        {
            //$ parent.WithAuthentication(this);
            //$ return parent();

            return default(FluentImplT);
        }

<<<<<<<<<<<<<<<<<<<<<<<<<<<NEW>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///GENMHASH:A3081DD017C840CFF99E73931B3E8D3E:7998C93FCEDA14C88EAE5DCE8443C80A
        public WebAppAuthenticationImpl<FluentT,FluentImplT> WithAnonymousAuthentication()
        {
            //$ inner().WithUnauthenticatedClientAction(UnauthenticatedClientAction.ALLOW_ANONYMOUS);
            //$ return this;

            return this;
        }

<<<<<<<<<<<<<<<<<<<<<<<<<<<NEW>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///GENMHASH:0086AD4BFE46C4028B8695DA65ED6B48:A89E28F3CF05B340ECAE895218915F7C
        public WebAppAuthenticationImpl<FluentT,FluentImplT> WithMicrosoft(string clientId, string clientSecret)
        {
            //$ inner().WithMicrosoftAccountClientId(clientId).WithMicrosoftAccountClientSecret(clientSecret);
            //$ return this;

            return this;
        }

    }
}
