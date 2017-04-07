// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent.WebAppAuthentication.UpdateDefinition
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update;
    using Microsoft.Azure.Management.AppService.Fluent.Models;

    /// <summary>
    /// A web app authentication definition allowing detailed provider information to be specified.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithAuthenticationProvider<ParentT> 
    {
        /// <summary>
        /// Specifies the provider to be Microsoft and its client ID and client secret.
        /// </summary>
        /// <param name="clientId">The Microsoft app's client ID.</param>
        /// <param name="clientSecret">The Microsoft app's client secret.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppAuthentication.UpdateDefinition.IWithAttach<ParentT> WithMicrosoft(string clientId, string clientSecret);

        /// <summary>
        /// Specifies the provider to be Facebook and its app ID and app secret.
        /// </summary>
        /// <param name="appId">The Facebook app ID.</param>
        /// <param name="appSecret">The Facebook app secret.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppAuthentication.UpdateDefinition.IWithAttach<ParentT> WithFacebook(string appId, string appSecret);

        /// <summary>
        /// Specifies the provider to be Twitter and its API key and API secret.
        /// </summary>
        /// <param name="apiKey">The Twitter app's API key.</param>
        /// <param name="apiSecret">The Twitter app's API secret.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppAuthentication.UpdateDefinition.IWithAttach<ParentT> WithTwitter(string apiKey, string apiSecret);

        /// <summary>
        /// Specifies the provider to be Google and its client ID and client secret.
        /// </summary>
        /// <param name="clientId">The Google app's client ID.</param>
        /// <param name="clientSecret">The Google app's client secret.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppAuthentication.UpdateDefinition.IWithAttach<ParentT> WithGoogle(string clientId, string clientSecret);

        /// <summary>
        /// Specifies the provider to be Active Directory and its client ID and issuer URL.
        /// </summary>
        /// <param name="clientId">The AAD app's client ID.</param>
        /// <param name="issuerUrl">The token issuer URL in the format of https://sts.windows.net/(tenantId).</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppAuthentication.UpdateDefinition.IWithAttach<ParentT> WithActiveDirectory(string clientId, string issuerUrl);
    }

    /// <summary>
    /// The first stage of a web app authentication definition as part of a definition of a web app.
    /// </summary>
    /// <typeparam name="ParentT">The return type of the final  Attachable.attach().</typeparam>
    public interface IBlank<ParentT>  :
        Microsoft.Azure.Management.AppService.Fluent.WebAppAuthentication.UpdateDefinition.IWithDefaultAuthenticationProvider<ParentT>
    {
    }

    /// <summary>
    /// The final stage of the web app authentication definition.
    /// At this stage, any remaining optional settings can be specified, or the web app authentication definition
    /// can be attached to the parent web app update using  WithAttach.attach().
    /// </summary>
    /// <typeparam name="ParentT">The return type of  WithAttach.attach().</typeparam>
    public interface IWithAttach<ParentT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update.IInUpdate<ParentT>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppAuthentication.UpdateDefinition.IWithAuthenticationProvider<ParentT>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppAuthentication.UpdateDefinition.IWithTokenStore<ParentT>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppAuthentication.UpdateDefinition.IWithExternalRedirectUrls<ParentT>
    {
    }

    /// <summary>
    /// A web app authentication definition allowing token store to be specified.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithTokenStore<ParentT> 
    {
        /// <summary>
        /// Specifies if token store should be enabled.
        /// </summary>
        /// <param name="enabled">True if token store should be enabled.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppAuthentication.UpdateDefinition.IWithAttach<ParentT> WithTokenStore(bool enabled);
    }

    /// <summary>
    /// The entirety of a web app authentication definition as part of a web app update.
    /// </summary>
    /// <typeparam name="ParentT">The return type of the final  UpdateDefinitionStages.WithAttach.attach().</typeparam>
    public interface IUpdateDefinition<ParentT>  :
        Microsoft.Azure.Management.AppService.Fluent.WebAppAuthentication.UpdateDefinition.IBlank<ParentT>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppAuthentication.UpdateDefinition.IWithAttach<ParentT>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppAuthentication.UpdateDefinition.IWithDefaultAuthenticationProvider<ParentT>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppAuthentication.UpdateDefinition.IWithAuthenticationProvider<ParentT>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppAuthentication.UpdateDefinition.IWithTokenStore<ParentT>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppAuthentication.UpdateDefinition.IWithExternalRedirectUrls<ParentT>
    {
    }

    /// <summary>
    /// A web app authentication definition allowing branch to be specified.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithExternalRedirectUrls<ParentT> 
    {
        /// <summary>
        /// Adds an external redirect URL.
        /// </summary>
        /// <param name="url">The external redirect URL.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppAuthentication.UpdateDefinition.IWithAttach<ParentT> WithAllowedExternalRedirectUrl(string url);
    }

    /// <summary>
    /// A web app authentication definition allowing the default authentication provider to be set.
    /// </summary>
    /// <typeparam name="ParentT">The return type of the final  Attachable.attach().</typeparam>
    public interface IWithDefaultAuthenticationProvider<ParentT> 
    {
        /// <summary>
        /// Does not require login by default.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppAuthentication.UpdateDefinition.IWithAttach<ParentT> WithAnonymousAuthentication();

        /// <summary>
        /// Specifies the default authentication provider.
        /// </summary>
        /// <param name="provider">The default authentication provider.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppAuthentication.UpdateDefinition.IWithAttach<ParentT> WithDefaultAuthenticationProvider(BuiltInAuthenticationProvider provider);
    }
}