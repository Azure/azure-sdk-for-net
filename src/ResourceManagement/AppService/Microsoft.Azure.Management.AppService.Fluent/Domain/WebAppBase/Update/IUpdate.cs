// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update
{
    using Microsoft.Azure.Management.AppService.Fluent.WebAppSourceControl.UpdateDefinition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.AppService.Fluent;
    using Microsoft.Azure.Management.AppService.Fluent.HostNameSslBinding.UpdateDefinition;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using Microsoft.Azure.Management.AppService.Fluent.HostNameBinding.UpdateDefinition;
    using Microsoft.Azure.Management.AppService.Fluent.WebAppAuthentication.Update;
    using Microsoft.Azure.Management.AppService.Fluent.WebAppAuthentication.UpdateDefinition;

    /// <summary>
    /// The stage of the web app update allowing setting if client affinity is enabled.
    /// </summary>
    /// <typeparam name="FluentT">The type of the resource.</typeparam>
    public interface IWithClientAffinityEnabled<FluentT> 
    {
        /// <summary>
        /// Specifies if client affinity is enabled.
        /// </summary>
        /// <param name="enabled">True if client affinity is enabled.</param>
        /// <return>The next stage of web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithClientAffinityEnabled(bool enabled);
    }

    /// <summary>
    /// A web app update stage allowing source control to be set.
    /// </summary>
    /// <typeparam name="FluentT">The type of the resource.</typeparam>
    public interface IWithSourceControl<FluentT> 
    {
        /// <summary>
        /// Specifies the source control to be a local Git repository on the web app.
        /// </summary>
        /// <return>The next stage of the web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithLocalGitSourceControl();

        /// <summary>
        /// Starts the definition of a new source control.
        /// </summary>
        /// <return>The first stage of a source control definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppSourceControl.UpdateDefinition.IBlank<Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT>> DefineSourceControl();

        /// <summary>
        /// Removes source control for deployment from the web app.
        /// </summary>
        /// <return>The next stage of the web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithoutSourceControl();
    }

    /// <summary>
    /// The template for a site update operation, containing all the settings that can be modified.
    /// </summary>
    /// <typeparam name="FluentT">The type of the resource.</typeparam>
    public interface IUpdate<FluentT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IAppliable<FluentT>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Update.IUpdateWithTags<Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT>>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IWithClientAffinityEnabled<FluentT>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IWithClientCertEnabled<FluentT>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IWithScmSiteAlsoStopped<FluentT>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IWithSiteConfigs<FluentT>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IWithAppSettings<FluentT>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IWithConnectionString<FluentT>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IWithSourceControl<FluentT>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IWithHostNameBinding<FluentT>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IWithHostNameSslBinding<FluentT>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IWithAuthentication<FluentT>
    {
    }

    /// <summary>
    /// The stage of the web app update allowing Java web container to be set. This is required
    /// after specifying Java version.
    /// </summary>
    /// <typeparam name="FluentT">The type of the resource.</typeparam>
    public interface IWithWebContainer<FluentT> 
    {
        /// <summary>
        /// Specifies the Java web container.
        /// </summary>
        /// <param name="webContainer">The Java web container.</param>
        /// <return>The next stage of the web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithWebContainer(WebContainer webContainer);
    }

    /// <summary>
    /// The stage of the web app update allowing SSL binding to be set.
    /// </summary>
    /// <typeparam name="FluentT">The type of the resource.</typeparam>
    public interface IWithHostNameSslBinding<FluentT> 
    {
        /// <summary>
        /// Removes an SSL binding for a specific hostname.
        /// </summary>
        /// <param name="hostname">The hostname to remove SSL certificate from.</param>
        /// <return>The next stage of web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithoutSslBinding(string hostname);

        /// <summary>
        /// Starts a definition of an SSL binding.
        /// </summary>
        /// <return>The first stage of an SSL binding definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.HostNameSslBinding.UpdateDefinition.IBlank<Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT>> DefineSslBinding();
    }

    /// <summary>
    /// A web app update stage allowing app settings to be set.
    /// </summary>
    /// <typeparam name="FluentT">The type of the resource.</typeparam>
    public interface IWithAppSettings<FluentT> 
    {
        /// <summary>
        /// Specifies the app settings for the web app as a  Map. These app settings
        /// will stay at the slot during a swap.
        /// </summary>
        /// <param name="settings">A  Map of app settings.</param>
        /// <return>The next stage of the web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithStickyAppSettings(IDictionary<string,string> settings);

        /// <summary>
        /// Adds an app setting to the web app.
        /// </summary>
        /// <param name="key">The key for the app setting.</param>
        /// <param name="value">The value for the app setting.</param>
        /// <return>The next stage of the web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithAppSetting(string key, string value);

        /// <summary>
        /// Changes the stickiness of an app setting.
        /// </summary>
        /// <param name="key">The key of the app setting to change stickiness.</param>
        /// <param name="sticky">True if the app setting sticks to the slot during a swap.</param>
        /// <return>The next stage of the web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithAppSettingStickiness(string key, bool sticky);

        /// <summary>
        /// Adds an app setting to the web app. This app setting
        /// will stay at the slot during a swap.
        /// </summary>
        /// <param name="key">The key for the app setting.</param>
        /// <param name="value">The value for the app setting.</param>
        /// <return>The next stage of the web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithStickyAppSetting(string key, string value);

        /// <summary>
        /// Specifies the app settings for the web app as a  Map.
        /// </summary>
        /// <param name="settings">A  Map of app settings.</param>
        /// <return>The next stage of the web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithAppSettings(IDictionary<string,string> settings);

        /// <summary>
        /// Removes an app setting from the web app.
        /// </summary>
        /// <param name="key">The key of the app setting to remove.</param>
        /// <return>The next stage of the web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithoutAppSetting(string key);
    }

    /// <summary>
    /// A web app update stage allowing connection strings to be set.
    /// </summary>
    /// <typeparam name="FluentT">The type of the resource.</typeparam>
    public interface IWithConnectionString<FluentT> 
    {
        /// <summary>
        /// Removes a connection string from the web app.
        /// </summary>
        /// <param name="name">The name of the connection string.</param>
        /// <return>The next stage of the web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithoutConnectionString(string name);

        /// <summary>
        /// Adds a connection string to the web app.
        /// </summary>
        /// <param name="name">The name of the connection string.</param>
        /// <param name="value">The connection string value.</param>
        /// <param name="type">The connection string type.</param>
        /// <return>The next stage of the web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithConnectionString(string name, string value, ConnectionStringType type);

        /// <summary>
        /// Adds a connection string to the web app. This connection string
        /// will stay at the slot during a swap.
        /// </summary>
        /// <param name="name">The name of the connection string.</param>
        /// <param name="value">The connection string value.</param>
        /// <param name="type">The connection string type.</param>
        /// <return>The next stage of the web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithStickyConnectionString(string name, string value, ConnectionStringType type);

        /// <summary>
        /// Changes the stickiness of a connection string.
        /// </summary>
        /// <param name="name">The name of the connection string.</param>
        /// <param name="sticky">True if the connection string sticks to the slot during a swap.</param>
        /// <return>The next stage of the web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithConnectionStringStickiness(string name, bool sticky);
    }

    /// <summary>
    /// The stage of the web app update allowing other configurations to be set. These configurations
    /// can be cloned when creating or swapping with a deployment slot.
    /// </summary>
    /// <typeparam name="FluentT">The type of the resource.</typeparam>
    public interface IWithSiteConfigs<FluentT> 
    {
        /// <summary>
        /// Specifies the Java version.
        /// </summary>
        /// <param name="version">The Java version.</param>
        /// <return>The next stage of web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IWithWebContainer<FluentT> WithJavaVersion(JavaVersion version);

        /// <summary>
        /// Specifies the PHP version.
        /// </summary>
        /// <param name="version">The PHP version.</param>
        /// <return>The next stage of web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithPhpVersion(PhpVersion version);

        /// <summary>
        /// Turn off Python support.
        /// </summary>
        /// <return>The next stage of web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithoutPython();

        /// <summary>
        /// Disables remote debugging.
        /// </summary>
        /// <return>The next stage of web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithRemoteDebuggingDisabled();

        /// <summary>
        /// Adds a default document.
        /// </summary>
        /// <param name="document">Default document.</param>
        /// <return>The next stage of web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithDefaultDocument(string document);

        /// <summary>
        /// Specifies if the VM powering the web app is always powered on.
        /// </summary>
        /// <param name="alwaysOn">True if the web app is always powered on.</param>
        /// <return>The next stage of web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithWebAppAlwaysOn(bool alwaysOn);

        /// <summary>
        /// Adds a list of default documents.
        /// </summary>
        /// <param name="documents">List of default documents.</param>
        /// <return>The next stage of web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithDefaultDocuments(IList<string> documents);

        /// <summary>
        /// Specifies if web sockets are enabled.
        /// </summary>
        /// <param name="enabled">True if web sockets are enabled.</param>
        /// <return>The next stage of web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithWebSocketsEnabled(bool enabled);

        /// <summary>
        /// Specifies the platform architecture to use.
        /// </summary>
        /// <param name="platform">The platform architecture.</param>
        /// <return>The next stage of web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithPlatformArchitecture(PlatformArchitecture platform);

        /// <summary>
        /// Specifies the slot name to auto-swap when a deployment is completed in this web app / deployment slot.
        /// </summary>
        /// <param name="slotName">The name of the slot, or 'production', to auto-swap.</param>
        /// <return>The next stage of web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithAutoSwapSlotName(string slotName);

        /// <summary>
        /// Specifies the .NET Framework version.
        /// </summary>
        /// <param name="version">The .NET Framework version.</param>
        /// <return>The next stage of web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithNetFrameworkVersion(NetFrameworkVersion version);

        /// <summary>
        /// Turn off Java support.
        /// </summary>
        /// <return>The next stage of web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithoutJava();

        /// <summary>
        /// Specifies the Python version.
        /// </summary>
        /// <param name="version">The Python version.</param>
        /// <return>The next stage of web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithPythonVersion(PythonVersion version);

        /// <summary>
        /// Removes a default document.
        /// </summary>
        /// <param name="document">Default document to remove.</param>
        /// <return>The next stage of web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithoutDefaultDocument(string document);

        /// <summary>
        /// Specifies the Visual Studio version for remote debugging.
        /// </summary>
        /// <param name="remoteVisualStudioVersion">The Visual Studio version for remote debugging.</param>
        /// <return>The next stage of web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithRemoteDebuggingEnabled(RemoteVisualStudioVersion remoteVisualStudioVersion);

        /// <summary>
        /// Specifies the managed pipeline mode.
        /// </summary>
        /// <param name="managedPipelineMode">Managed pipeline mode.</param>
        /// <return>The next stage of web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithManagedPipelineMode(ManagedPipelineMode managedPipelineMode);
    }

    /// <summary>
    /// The stage of the web app update allowing setting if client cert is enabled.
    /// </summary>
    /// <typeparam name="FluentT">The type of the resource.</typeparam>
    public interface IWithClientCertEnabled<FluentT> 
    {
        /// <summary>
        /// Specifies if client cert is enabled.
        /// </summary>
        /// <param name="enabled">True if client cert is enabled.</param>
        /// <return>The next stage of web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithClientCertEnabled(bool enabled);
    }

    /// <summary>
    /// The stage of the web app update allowing disabling the web app upon creation.
    /// </summary>
    /// <typeparam name="FluentT">The type of the resource.</typeparam>
    public interface IWithSiteEnabled<FluentT> 
    {
        /// <summary>
        /// Disables the web app upon creation.
        /// </summary>
        /// <return>The next stage of web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithAppDisabledOnCreation();
    }

    /// <summary>
    /// The stage of the web app update allowing host name binding to be set.
    /// </summary>
    /// <typeparam name="FluentT">The type of the resource.</typeparam>
    public interface IWithHostNameBinding<FluentT> 
    {
        /// <summary>
        /// Defines a list of host names of an Azure managed domain. The DNS record type is
        /// defaulted to be CNAME except for the root level domain (".
        /// </summary>
        /// <param name="domain">The Azure managed domain.</param>
        /// <param name="hostnames">The list of sub-domains.</param>
        /// <return>The next stage of web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithManagedHostnameBindings(IAppServiceDomain domain, params string[] hostnames);

        /// <summary>
        /// Defines a list of host names of an externally purchased domain. The hostnames
        /// must be configured before hand to point to the web app.
        /// </summary>
        /// <param name="domain">The external domain name.</param>
        /// <param name="hostnames">The list of sub-domains.</param>
        /// <return>The next stage of web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithThirdPartyHostnameBinding(string domain, params string[] hostnames);

        /// <summary>
        /// Starts the definition of a new host name binding.
        /// </summary>
        /// <return>The first stage of a hostname binding update.</return>
        Microsoft.Azure.Management.AppService.Fluent.HostNameBinding.UpdateDefinition.IBlank<Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT>> DefineHostnameBinding();

        /// <summary>
        /// Unbinds a hostname from the web app.
        /// </summary>
        /// <param name="hostname">The hostname to unbind.</param>
        /// <return>The next stage of web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithoutHostnameBinding(string hostname);
    }

    /// <summary>
    /// The stage of the web app update allowing setting if SCM site is also stopped when the web app is stopped.
    /// </summary>
    /// <typeparam name="FluentT">The type of the resource.</typeparam>
    public interface IWithScmSiteAlsoStopped<FluentT> 
    {
        /// <summary>
        /// Specifies if SCM site is also stopped when the web app is stopped.
        /// </summary>
        /// <param name="scmSiteAlsoStopped">True if SCM site is also stopped.</param>
        /// <return>The next stage of web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithScmSiteAlsoStopped(bool scmSiteAlsoStopped);
    }

    /// <summary>
    /// A web app definition stage allowing authentication to be set.
    /// </summary>
    /// <typeparam name="FluentT">The type of the resource.</typeparam>
    public interface IWithAuthentication<FluentT> 
    {
        /// <summary>
        /// Gets Specifies the definition of a new authentication configuration.
        /// </summary>
        /// <summary>
        /// Gets the first stage of an authentication definition.
        /// </summary>
        Microsoft.Azure.Management.AppService.Fluent.WebAppAuthentication.UpdateDefinition.IBlank<Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT>> DefineAuthentication { get; }

        /// <summary>
        /// Turns off the authentication on the web app.
        /// </summary>
        /// <return>The next stage of the web app update.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT> WithoutAuthentication();

        /// <summary>
        /// Gets Updates the authentication configuration of the web app.
        /// </summary>
        /// <summary>
        /// Gets the first stage of an authentication update.
        /// </summary>
        Microsoft.Azure.Management.AppService.Fluent.WebAppAuthentication.Update.IUpdate<Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update.IUpdate<FluentT>> UpdateAuthentication { get; }
    }
}