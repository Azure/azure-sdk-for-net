// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Appservice.Fluent.WebAppBase.Update
{
    using Microsoft.Azure.Management.Appservice.Fluent.WebAppSourceControl.UpdateDefinition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.Resource.Update;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using Microsoft.Azure.Management.Appservice.Fluent.HostNameSslBinding.UpdateDefinition;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Appservice.Fluent;
    using Microsoft.Azure.Management.Appservice.Fluent.HostNameBinding.UpdateDefinition;

    /// <summary>
    /// The stage of the web app update allowing setting if client affinity is enabled.
    /// </summary>
    public interface IWithClientAffinityEnabled<FluentT> 
    {
        /// <summary>
        /// Specifies if client affinity is enabled.
        /// </summary>
        /// <param name="enabled">True if client affinity is enabled.</param>
        Microsoft.Azure.Management.Appservice.Fluent.WebAppBase.Update.IUpdate<FluentT> WithClientAffinityEnabled(bool enabled);
    }

    /// <summary>
    /// A web app update stage allowing source control to be set.
    /// </summary>
    public interface IWithSourceControl<FluentT> 
    {
        /// <summary>
        /// Specifies the source control to be a local Git repository on the web app.
        /// </summary>
        Microsoft.Azure.Management.Appservice.Fluent.WebAppBase.Update.IUpdate<FluentT> WithLocalGitSourceControl();

        /// <summary>
        /// Starts the definition of a new source control.
        /// </summary>
        Microsoft.Azure.Management.Appservice.Fluent.WebAppSourceControl.UpdateDefinition.IBlank<Microsoft.Azure.Management.Appservice.Fluent.WebAppBase.Update.IUpdate<FluentT>> DefineSourceControl { get; }

        /// <summary>
        /// Removes source control for deployment from the web app.
        /// </summary>
        Microsoft.Azure.Management.Appservice.Fluent.WebAppBase.Update.IUpdate<FluentT> WithoutSourceControl();
    }

    /// <summary>
    /// The template for a web app update operation, containing all the settings that can be modified.
    /// </summary>
    public interface IUpdate<FluentT>  :
        IAppliable<FluentT>,
        IUpdateWithTags<Microsoft.Azure.Management.Appservice.Fluent.WebAppBase.Update.IUpdate<FluentT>>,
        IWithHostNameBinding<FluentT>,
        IWithHostNameSslBinding<FluentT>,
        IWithClientAffinityEnabled<FluentT>,
        IWithClientCertEnabled<FluentT>,
        IWithScmSiteAlsoStopped<FluentT>,
        IWithSiteEnabled<FluentT>,
        IWithSiteConfigs<FluentT>,
        IWithAppSettings<FluentT>,
        IWithConnectionString<FluentT>,
        IWithSourceControl<FluentT>
    {
    }

    /// <summary>
    /// The stage of the web app update allowing Java web container to be set. This is required
    /// after specifying Java version.
    /// </summary>
    public interface IWithWebContainer<FluentT> 
    {
        /// <summary>
        /// Specifies the Java web container.
        /// </summary>
        /// <param name="webContainer">The Java web container.</param>
        Microsoft.Azure.Management.Appservice.Fluent.WebAppBase.Update.IUpdate<FluentT> WithWebContainer(WebContainer webContainer);
    }

    /// <summary>
    /// The stage of the web app update allowing SSL binding to be set.
    /// </summary>
    public interface IWithHostNameSslBinding<FluentT> 
    {
        /// <summary>
        /// Removes an SSL binding for a specific hostname.
        /// </summary>
        /// <param name="hostname">The hostname to remove SSL certificate from.</param>
        Microsoft.Azure.Management.Appservice.Fluent.WebAppBase.Update.IUpdate<FluentT> WithoutSslBinding(string hostname);

        /// <summary>
        /// Starts a definition of an SSL binding.
        /// </summary>
        Microsoft.Azure.Management.Appservice.Fluent.HostNameSslBinding.UpdateDefinition.IBlank<Microsoft.Azure.Management.Appservice.Fluent.WebAppBase.Update.IUpdate<FluentT>> DefineSslBinding { get; }
    }

    /// <summary>
    /// A web app update stage allowing app settings to be set.
    /// </summary>
    public interface IWithAppSettings<FluentT> 
    {
        /// <summary>
        /// Specifies the app settings for the web app as a Map. These app settings
        /// will stay at the slot during a swap.
        /// </summary>
        /// <param name="settings">A Map of app settings.</param>
        Microsoft.Azure.Management.Appservice.Fluent.WebAppBase.Update.IUpdate<FluentT> WithStickyAppSettings(IDictionary<string,string> settings);

        /// <summary>
        /// Adds an app setting to the web app.
        /// </summary>
        /// <param name="key">The key for the app setting.</param>
        /// <param name="value">The value for the app setting.</param>
        Microsoft.Azure.Management.Appservice.Fluent.WebAppBase.Update.IUpdate<FluentT> WithAppSetting(string key, string value);

        /// <summary>
        /// Changes the stickiness of an app setting.
        /// </summary>
        /// <param name="key">The key of the app setting to change stickiness.</param>
        /// <param name="sticky">True if the app setting sticks to the slot during a swap.</param>
        Microsoft.Azure.Management.Appservice.Fluent.WebAppBase.Update.IUpdate<FluentT> WithAppSettingStickiness(string key, bool sticky);

        /// <summary>
        /// Adds an app setting to the web app. This app setting
        /// will stay at the slot during a swap.
        /// </summary>
        /// <param name="key">The key for the app setting.</param>
        /// <param name="value">The value for the app setting.</param>
        Microsoft.Azure.Management.Appservice.Fluent.WebAppBase.Update.IUpdate<FluentT> WithStickyAppSetting(string key, string value);

        /// <summary>
        /// Specifies the app settings for the web app as a Map.
        /// </summary>
        /// <param name="settings">A Map of app settings.</param>
        Microsoft.Azure.Management.Appservice.Fluent.WebAppBase.Update.IUpdate<FluentT> WithAppSettings(IDictionary<string,string> settings);

        /// <summary>
        /// Removes an app setting from the web app.
        /// </summary>
        /// <param name="key">The key of the app setting to remove.</param>
        Microsoft.Azure.Management.Appservice.Fluent.WebAppBase.Update.IUpdate<FluentT> WithoutAppSetting(string key);
    }

    /// <summary>
    /// A web app update stage allowing connection strings to be set.
    /// </summary>
    public interface IWithConnectionString<FluentT> 
    {
        /// <summary>
        /// Removes a connection string from the web app.
        /// </summary>
        /// <param name="name">The name of the connection string.</param>
        Microsoft.Azure.Management.Appservice.Fluent.WebAppBase.Update.IUpdate<FluentT> WithoutConnectionString(string name);

        /// <summary>
        /// Adds a connection string to the web app.
        /// </summary>
        /// <param name="name">The name of the connection string.</param>
        /// <param name="value">The connection string value.</param>
        /// <param name="type">The connection string type.</param>
        Microsoft.Azure.Management.Appservice.Fluent.WebAppBase.Update.IUpdate<FluentT> WithConnectionString(string name, string value, ConnectionStringType type);

        /// <summary>
        /// Adds a connection string to the web app. This connection string
        /// will stay at the slot during a swap.
        /// </summary>
        /// <param name="name">The name of the connection string.</param>
        /// <param name="value">The connection string value.</param>
        /// <param name="type">The connection string type.</param>
        Microsoft.Azure.Management.Appservice.Fluent.WebAppBase.Update.IUpdate<FluentT> WithStickyConnectionString(string name, string value, ConnectionStringType type);

        /// <summary>
        /// Changes the stickiness of a connection string.
        /// </summary>
        /// <param name="name">The name of the connection string.</param>
        /// <param name="sticky">True if the connection string sticks to the slot during a swap.</param>
        Microsoft.Azure.Management.Appservice.Fluent.WebAppBase.Update.IUpdate<FluentT> WithConnectionStringStickiness(string name, bool sticky);
    }

    /// <summary>
    /// The stage of the web app update allowing other configurations to be set. These configurations
    /// can be cloned when creating or swapping with a deployment slot.
    /// </summary>
    public interface IWithSiteConfigs<FluentT> 
    {
        /// <summary>
        /// Specifies the Java version.
        /// </summary>
        /// <param name="version">The Java version.</param>
        Microsoft.Azure.Management.Appservice.Fluent.WebAppBase.Update.IWithWebContainer<FluentT> WithJavaVersion(JavaVersion version);

        /// <summary>
        /// Specifies the PHP version.
        /// </summary>
        /// <param name="version">The PHP version.</param>
        Microsoft.Azure.Management.Appservice.Fluent.WebAppBase.Update.IUpdate<FluentT> WithPhpVersion(PhpVersion version);

        /// <summary>
        /// Turn off Python support.
        /// </summary>
        Microsoft.Azure.Management.Appservice.Fluent.WebAppBase.Update.IUpdate<FluentT> WithoutPython();

        /// <summary>
        /// Disables remote debugging.
        /// </summary>
        Microsoft.Azure.Management.Appservice.Fluent.WebAppBase.Update.IUpdate<FluentT> WithRemoteDebuggingDisabled();

        /// <summary>
        /// Adds a default document.
        /// </summary>
        /// <param name="document">Default document.</param>
        Microsoft.Azure.Management.Appservice.Fluent.WebAppBase.Update.IUpdate<FluentT> WithDefaultDocument(string document);

        /// <summary>
        /// Specifies if the VM powering the web app is always powered on.
        /// </summary>
        /// <param name="alwaysOn">True if the web app is always powered on.</param>
        Microsoft.Azure.Management.Appservice.Fluent.WebAppBase.Update.IUpdate<FluentT> WithWebAppAlwaysOn(bool alwaysOn);

        /// <summary>
        /// Adds a list of default documents.
        /// </summary>
        /// <param name="documents">List of default documents.</param>
        Microsoft.Azure.Management.Appservice.Fluent.WebAppBase.Update.IUpdate<FluentT> WithDefaultDocuments(IList<string> documents);

        /// <summary>
        /// Specifies if web sockets are enabled.
        /// </summary>
        /// <param name="enabled">True if web sockets are enabled.</param>
        Microsoft.Azure.Management.Appservice.Fluent.WebAppBase.Update.IUpdate<FluentT> WithWebSocketsEnabled(bool enabled);

        /// <summary>
        /// Specifies the platform architecture to use.
        /// </summary>
        /// <param name="platform">The platform architecture.</param>
        Microsoft.Azure.Management.Appservice.Fluent.WebAppBase.Update.IUpdate<FluentT> WithPlatformArchitecture(PlatformArchitecture platform);

        /// <summary>
        /// Specifies the slot name to auto-swap when a deployment is completed in this web app / deployment slot.
        /// </summary>
        /// <param name="slotName">The name of the slot, or 'production', to auto-swap.</param>
        Microsoft.Azure.Management.Appservice.Fluent.WebAppBase.Update.IUpdate<FluentT> WithAutoSwapSlotName(string slotName);

        /// <summary>
        /// Specifies the .NET Framework version.
        /// </summary>
        /// <param name="version">The .NET Framework version.</param>
        Microsoft.Azure.Management.Appservice.Fluent.WebAppBase.Update.IUpdate<FluentT> WithNetFrameworkVersion(NetFrameworkVersion version);

        /// <summary>
        /// Turn off Java support.
        /// </summary>
        Microsoft.Azure.Management.Appservice.Fluent.WebAppBase.Update.IUpdate<FluentT> WithoutJava();

        /// <summary>
        /// Specifies the Python version.
        /// </summary>
        /// <param name="version">The Python version.</param>
        Microsoft.Azure.Management.Appservice.Fluent.WebAppBase.Update.IUpdate<FluentT> WithPythonVersion(PythonVersion version);

        /// <summary>
        /// Removes a default document.
        /// </summary>
        /// <param name="document">Default document to remove.</param>
        Microsoft.Azure.Management.Appservice.Fluent.WebAppBase.Update.IUpdate<FluentT> WithoutDefaultDocument(string document);

        /// <summary>
        /// Specifies the Visual Studio version for remote debugging.
        /// </summary>
        /// <param name="remoteVisualStudioVersion">The Visual Studio version for remote debugging.</param>
        Microsoft.Azure.Management.Appservice.Fluent.WebAppBase.Update.IUpdate<FluentT> WithRemoteDebuggingEnabled(RemoteVisualStudioVersion remoteVisualStudioVersion);

        /// <summary>
        /// Specifies the managed pipeline mode.
        /// </summary>
        /// <param name="managedPipelineMode">Managed pipeline mode.</param>
        Microsoft.Azure.Management.Appservice.Fluent.WebAppBase.Update.IUpdate<FluentT> WithManagedPipelineMode(ManagedPipelineMode managedPipelineMode);
    }

    /// <summary>
    /// The stage of the web app update allowing setting if client cert is enabled.
    /// </summary>
    public interface IWithClientCertEnabled<FluentT> 
    {
        /// <summary>
        /// Specifies if client cert is enabled.
        /// </summary>
        /// <param name="enabled">True if client cert is enabled.</param>
        Microsoft.Azure.Management.Appservice.Fluent.WebAppBase.Update.IUpdate<FluentT> WithClientCertEnabled(bool enabled);
    }

    /// <summary>
    /// The stage of the web app update allowing disabling the web app upon creation.
    /// </summary>
    public interface IWithSiteEnabled<FluentT> 
    {
        /// <summary>
        /// Disables the web app upon creation.
        /// </summary>
        Microsoft.Azure.Management.Appservice.Fluent.WebAppBase.Update.IUpdate<FluentT> WithAppDisabledOnCreation();
    }

    /// <summary>
    /// The stage of the web app update allowing host name binding to be set.
    /// </summary>
    public interface IWithHostNameBinding<FluentT> 
    {
        /// <summary>
        /// Defines a list of host names of an Azure managed domain. The DNS record type is
        /// defaulted to be CNAME except for the root level domain (".
        /// </summary>
        /// <param name="domain">The Azure managed domain.</param>
        /// <param name="hostnames">The list of sub-domains.</param>
        Microsoft.Azure.Management.Appservice.Fluent.WebAppBase.Update.IUpdate<FluentT> WithManagedHostnameBindings(IAppServiceDomain domain, params string[] hostnames);

        /// <summary>
        /// Defines a list of host names of an externally purchased domain. The hostnames
        /// must be configured before hand to point to the web app.
        /// </summary>
        /// <param name="domain">The external domain name.</param>
        /// <param name="hostnames">The list of sub-domains.</param>
        Microsoft.Azure.Management.Appservice.Fluent.WebAppBase.Update.IUpdate<FluentT> WithThirdPartyHostnameBinding(string domain, params string[] hostnames);

        /// <summary>
        /// Starts the definition of a new host name binding.
        /// </summary>
        Microsoft.Azure.Management.Appservice.Fluent.HostNameBinding.UpdateDefinition.IBlank<Microsoft.Azure.Management.Appservice.Fluent.WebAppBase.Update.IUpdate<FluentT>> DefineHostnameBinding { get; }

        /// <summary>
        /// Unbinds a hostname from the web app.
        /// </summary>
        /// <param name="hostname">The hostname to unbind.</param>
        Microsoft.Azure.Management.Appservice.Fluent.WebAppBase.Update.IUpdate<FluentT> WithoutHostnameBinding(string hostname);
    }

    /// <summary>
    /// The stage of the web app update allowing setting if SCM site is also stopped when the web app is stopped.
    /// </summary>
    public interface IWithScmSiteAlsoStopped<FluentT> 
    {
        /// <summary>
        /// Specifies if SCM site is also stopped when the web app is stopped.
        /// </summary>
        /// <param name="scmSiteAlsoStopped">True if SCM site is also stopped.</param>
        Microsoft.Azure.Management.Appservice.Fluent.WebAppBase.Update.IUpdate<FluentT> WithScmSiteAlsoStopped(bool scmSiteAlsoStopped);
    }
}