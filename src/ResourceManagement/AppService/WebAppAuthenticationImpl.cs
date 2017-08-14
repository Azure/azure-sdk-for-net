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
    using System.Collections.Generic;

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
            Inner.MicrosoftAccountClientId = clientId;
            Inner.MicrosoftAccountClientSecret = clientSecret;
            return this;
        }

        public WebAppAuthenticationImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> WithAnonymousAuthentication()
        {
            Inner.UnauthenticatedClientAction = UnauthenticatedClientAction.AllowAnonymous;
            return this;
        }

        public FluentImplT Attach()
        {
            parent.WithAuthentication(this);
            return (FluentImplT) parent;
        }

        public WebAppAuthenticationImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> WithFacebook(string appId, string appSecret)
        {
            Inner.FacebookAppId = appId;
            Inner.FacebookAppSecret = appSecret;
            return this;
        }

        public FluentImplT Parent()
        {
            parent.WithAuthentication(this);
            return (FluentImplT) this.parent;
        }

        public WebAppAuthenticationImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> WithDefaultAuthenticationProvider(BuiltInAuthenticationProvider provider)
        {
            Inner.UnauthenticatedClientAction = UnauthenticatedClientAction.RedirectToLoginPage;
            Inner.DefaultProvider = provider;
            return this;
        }

        public WebAppAuthenticationImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> WithTwitter(string apiKey, string apiSecret)
        {
            Inner.TwitterConsumerKey = apiKey;
            Inner.TwitterConsumerSecret = apiSecret;
            return this;
        }

        public WebAppAuthenticationImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> WithAllowedExternalRedirectUrl(string url)
        {
            if (Inner.AllowedExternalRedirectUrls == null)
            {
                Inner.AllowedExternalRedirectUrls = new List<string>();
            }
            Inner.AllowedExternalRedirectUrls.Add(url);
            return this;
        }

        public WebAppAuthenticationImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> WithTokenStore(bool enabled)
        {
            Inner.TokenStoreEnabled = enabled;
            return this;
        }

        public WebAppAuthenticationImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> WithGoogle(string clientId, string clientSecret)
        {
            Inner.GoogleClientId = clientId;
            Inner.GoogleClientSecret = clientSecret;
            return this;
        }

        public WebAppAuthenticationImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> WithActiveDirectory(string clientId, string issuerUrl)
        {
            Inner.ClientId = clientId;
            Inner.Issuer = issuerUrl;
            return this;
        }

        internal  WebAppAuthenticationImpl(SiteAuthSettingsInner inner, WebAppBaseImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> parent)
            : base(inner)
        {
            this.parent = parent;
            Inner.TokenStoreEnabled = true;
        }
    }
}
