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
        IndexableWrapper<Models.SiteAuthSettingsInner>,
        IWebAppAuthentication,
        WebAppAuthentication.Definition.IDefinition<WebAppBase.Definition.IWithCreate<FluentT>>,
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
            : base(inner)
        {
            //$ super(inner);
            //$ this.parent = parent;
            //$ inner.WithLocation(parent.RegionName());
            //$ inner.WithTokenStoreEnabled(true);
            //$ }

        }
    }
}
