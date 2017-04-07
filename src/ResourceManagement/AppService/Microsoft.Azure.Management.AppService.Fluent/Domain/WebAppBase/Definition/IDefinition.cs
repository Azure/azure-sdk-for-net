// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition
{
    using Microsoft.Azure.Management.AppService.Fluent;
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.AppService.Fluent.WebAppAuthentication.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Azure.Management.AppService.Fluent.WebAppSourceControl.Definition;
    using Microsoft.Azure.Management.AppService.Fluent.HostNameBinding.Definition;
    using Microsoft.Azure.Management.AppService.Fluent.HostNameSslBinding.Definition;

    /// <summary>
    /// A web app definition stage allowing other configurations to be set. These configurations
    /// can be cloned when creating or swapping with a deployment slot.
    /// </summary>
    /// <typeparam name="FluentT">The type of the resource.</typeparam>
    public interface IWithSiteConfigs<FluentT> 
    {
        /// <summary>
        /// Specifies the Java version.
        /// </summary>
        /// <param name="version">The Java version.</param>
        /// <return>The next stage of the web app definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithWebContainer<FluentT> WithJavaVersion(JavaVersion version);

        /// <summary>
        /// Specifies the PHP version.
        /// </summary>
        /// <param name="version">The PHP version.</param>
        /// <return>The next stage of the web app definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithCreate<FluentT> WithPhpVersion(PhpVersion version);

        /// <summary>
        /// Disables remote debugging.
        /// </summary>
        /// <return>The next stage of the web app definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithCreate<FluentT> WithRemoteDebuggingDisabled();

        /// <summary>
        /// Adds a default document.
        /// </summary>
        /// <param name="document">Default document.</param>
        /// <return>The next stage of the web app definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithCreate<FluentT> WithDefaultDocument(string document);

        /// <summary>
        /// Specifies if the VM powering the web app is always powered on.
        /// </summary>
        /// <param name="alwaysOn">True if the web app is always powered on.</param>
        /// <return>The next stage of the web app definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithCreate<FluentT> WithWebAppAlwaysOn(bool alwaysOn);

        /// <summary>
        /// Adds a list of default documents.
        /// </summary>
        /// <param name="documents">List of default documents.</param>
        /// <return>The next stage of the web app definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithCreate<FluentT> WithDefaultDocuments(IList<string> documents);

        /// <summary>
        /// Specifies if web sockets are enabled.
        /// </summary>
        /// <param name="enabled">True if web sockets are enabled.</param>
        /// <return>The next stage of the web app definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithCreate<FluentT> WithWebSocketsEnabled(bool enabled);

        /// <summary>
        /// Specifies the platform architecture to use.
        /// </summary>
        /// <param name="platform">The platform architecture.</param>
        /// <return>The next stage of the web app definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithCreate<FluentT> WithPlatformArchitecture(PlatformArchitecture platform);

        /// <summary>
        /// Specifies the slot name to auto-swap when a deployment is completed in this web app / deployment slot.
        /// </summary>
        /// <param name="slotName">The name of the slot, or 'production', to auto-swap.</param>
        /// <return>The next stage of the web app definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithCreate<FluentT> WithAutoSwapSlotName(string slotName);

        /// <summary>
        /// Specifies the .NET Framework version.
        /// </summary>
        /// <param name="version">The .NET Framework version.</param>
        /// <return>The next stage of the web app definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithCreate<FluentT> WithNetFrameworkVersion(NetFrameworkVersion version);

        /// <summary>
        /// Turn off PHP support.
        /// </summary>
        /// <return>The next stage of the web app definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithCreate<FluentT> WithoutPhp();

        /// <summary>
        /// Specifies the Python version.
        /// </summary>
        /// <param name="version">The Python version.</param>
        /// <return>The next stage of the web app definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithCreate<FluentT> WithPythonVersion(PythonVersion version);

        /// <summary>
        /// Removes a default document.
        /// </summary>
        /// <param name="document">Default document to remove.</param>
        /// <return>The next stage of the web app definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithCreate<FluentT> WithoutDefaultDocument(string document);

        /// <summary>
        /// Specifies the Visual Studio version for remote debugging.
        /// </summary>
        /// <param name="remoteVisualStudioVersion">The Visual Studio version for remote debugging.</param>
        /// <return>The next stage of the web app definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithCreate<FluentT> WithRemoteDebuggingEnabled(RemoteVisualStudioVersion remoteVisualStudioVersion);

        /// <summary>
        /// Specifies the managed pipeline mode.
        /// </summary>
        /// <param name="managedPipelineMode">Managed pipeline mode.</param>
        /// <return>The next stage of the web app definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithCreate<FluentT> WithManagedPipelineMode(ManagedPipelineMode managedPipelineMode);
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
        Microsoft.Azure.Management.AppService.Fluent.WebAppAuthentication.Definition.IBlank<Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithCreate<FluentT>> DefineAuthentication { get; }
    }

    /// <summary>
    /// A web app definition stage allowing setting if client affinity is enabled.
    /// </summary>
    /// <typeparam name="FluentT">The type of the resource.</typeparam>
    public interface IWithClientAffinityEnabled<FluentT> 
    {
        /// <summary>
        /// Specifies if client affinity is enabled.
        /// </summary>
        /// <param name="enabled">True if client affinity is enabled.</param>
        /// <return>The next stage of the web app definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithCreate<FluentT> WithClientAffinityEnabled(bool enabled);
    }

    /// <summary>
    /// A web app definition stage allowing Java web container to be set. This is required
    /// after specifying Java version.
    /// </summary>
    /// <typeparam name="FluentT">The type of the resource.</typeparam>
    public interface IWithWebContainer<FluentT> 
    {
        /// <summary>
        /// Specifies the Java web container.
        /// </summary>
        /// <param name="webContainer">The Java web container.</param>
        /// <return>The next stage of the web app definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithCreate<FluentT> WithWebContainer(WebContainer webContainer);
    }

    /// <summary>
    /// A web app definition stage allowing connection strings to be set.
    /// </summary>
    /// <typeparam name="FluentT">The type of the resource.</typeparam>
    public interface IWithConnectionString<FluentT> 
    {
        /// <summary>
        /// Adds a connection string to the web app.
        /// </summary>
        /// <param name="name">The name of the connection string.</param>
        /// <param name="value">The connection string value.</param>
        /// <param name="type">The connection string type.</param>
        /// <return>The next stage of the web app definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithCreate<FluentT> WithConnectionString(string name, string value, ConnectionStringType type);

        /// <summary>
        /// Adds a connection string to the web app. This connection string will be swapped
        /// as well after a deployment slot swap.
        /// </summary>
        /// <param name="name">The name of the connection string.</param>
        /// <param name="value">The connection string value.</param>
        /// <param name="type">The connection string type.</param>
        /// <return>The next stage of the web app definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithCreate<FluentT> WithStickyConnectionString(string name, string value, ConnectionStringType type);
    }

    /// <summary>
    /// A web app definition stage allowing disabling the web app upon creation.
    /// </summary>
    /// <typeparam name="FluentT">The type of the resource.</typeparam>
    public interface IWithSiteEnabled<FluentT> 
    {
        /// <summary>
        /// Disables the web app upon creation.
        /// </summary>
        /// <return>The next stage of the web app definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithCreate<FluentT> WithAppDisabledOnCreation();
    }

    /// <summary>
    /// The entirety of the web app base definition.
    /// </summary>
    /// <typeparam name="FluentT">The type of the resource.</typeparam>
    public interface IDefinition<FluentT>  :
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithWebContainer<FluentT>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithCreate<FluentT>
    {
    }

    /// <summary>
    /// A site definition with sufficient inputs to create a new web app /
    /// deployments slot in the cloud, but exposing additional optional
    /// inputs to specify.
    /// </summary>
    /// <typeparam name="FluentT">The type of the resource.</typeparam>
    public interface IWithCreate<FluentT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<FluentT>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Resource.Definition.IDefinitionWithTags<Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithCreate<FluentT>>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithClientAffinityEnabled<FluentT>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithClientCertEnabled<FluentT>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithScmSiteAlsoStopped<FluentT>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithSiteConfigs<FluentT>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithAppSettings<FluentT>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithConnectionString<FluentT>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithSourceControl<FluentT>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithHostNameBinding<FluentT>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithHostNameSslBinding<FluentT>,
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithAuthentication<FluentT>
    {
    }

    /// <summary>
    /// A web app definition stage allowing source control to be set.
    /// </summary>
    /// <typeparam name="FluentT">The type of the resource.</typeparam>
    public interface IWithSourceControl<FluentT> 
    {
        /// <summary>
        /// Specifies the source control to be a local Git repository on the web app.
        /// </summary>
        /// <return>The next stage of the web app definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithCreate<FluentT> WithLocalGitSourceControl();

        /// <summary>
        /// Starts the definition of a new source control.
        /// </summary>
        /// <return>The first stage of a source control definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppSourceControl.Definition.IBlank<Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithCreate<FluentT>> DefineSourceControl();
    }

    /// <summary>
    /// A web app definition stage allowing setting if SCM site is also stopped when the web app is stopped.
    /// </summary>
    /// <typeparam name="FluentT">The type of the resource.</typeparam>
    public interface IWithScmSiteAlsoStopped<FluentT> 
    {
        /// <summary>
        /// Specifies if SCM site is also stopped when the web app is stopped.
        /// </summary>
        /// <param name="scmSiteAlsoStopped">True if SCM site is also stopped.</param>
        /// <return>The next stage of the web app definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithCreate<FluentT> WithScmSiteAlsoStopped(bool scmSiteAlsoStopped);
    }

    /// <summary>
    /// A web app definition stage allowing setting if client cert is enabled.
    /// </summary>
    /// <typeparam name="FluentT">The type of the resource.</typeparam>
    public interface IWithClientCertEnabled<FluentT> 
    {
        /// <summary>
        /// Specifies if client cert is enabled.
        /// </summary>
        /// <param name="enabled">True if client cert is enabled.</param>
        /// <return>The next stage of the web app definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithCreate<FluentT> WithClientCertEnabled(bool enabled);
    }

    /// <summary>
    /// A web app definition stage allowing app settings to be set.
    /// </summary>
    /// <typeparam name="FluentT">The type of the resource.</typeparam>
    public interface IWithAppSettings<FluentT> 
    {
        /// <summary>
        /// Specifies the app settings for the web app as a  Map. These app settings will be swapped
        /// as well after a deployment slot swap.
        /// </summary>
        /// <param name="settings">A  Map of app settings.</param>
        /// <return>The next stage of the web app definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithCreate<FluentT> WithStickyAppSettings(IDictionary<string,string> settings);

        /// <summary>
        /// Adds an app setting to the web app.
        /// </summary>
        /// <param name="key">The key for the app setting.</param>
        /// <param name="value">The value for the app setting.</param>
        /// <return>The next stage of the web app definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithCreate<FluentT> WithAppSetting(string key, string value);

        /// <summary>
        /// Adds an app setting to the web app. This app setting will be swapped
        /// as well after a deployment slot swap.
        /// </summary>
        /// <param name="key">The key for the app setting.</param>
        /// <param name="value">The value for the app setting.</param>
        /// <return>The next stage of the web app definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithCreate<FluentT> WithStickyAppSetting(string key, string value);

        /// <summary>
        /// Specifies the app settings for the web app as a  Map.
        /// </summary>
        /// <param name="settings">A  Map of app settings.</param>
        /// <return>The next stage of the web app definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithCreate<FluentT> WithAppSettings(IDictionary<string,string> settings);
    }

    /// <summary>
    /// A web app definition stage allowing host name binding to be specified.
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
        /// <return>The next stage of the web app definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithCreate<FluentT> WithManagedHostnameBindings(IAppServiceDomain domain, params string[] hostnames);

        /// <summary>
        /// Defines a list of host names of an externally purchased domain. The hostnames
        /// must be configured before hand to point to the web app.
        /// </summary>
        /// <param name="domain">The external domain name.</param>
        /// <param name="hostnames">The list of sub-domains.</param>
        /// <return>The next stage of the web app definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithCreate<FluentT> WithThirdPartyHostnameBinding(string domain, params string[] hostnames);

        /// <summary>
        /// Starts the definition of a new host name binding.
        /// </summary>
        /// <return>The first stage of a hostname binding definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.HostNameBinding.Definition.IBlank<Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithCreate<FluentT>> DefineHostnameBinding();
    }

    /// <summary>
    /// A web app definition stage allowing SSL binding to be set.
    /// </summary>
    /// <typeparam name="FluentT">The type of the resource.</typeparam>
    public interface IWithHostNameSslBinding<FluentT> 
    {
        /// <summary>
        /// Starts a definition of an SSL binding.
        /// </summary>
        /// <return>The first stage of an SSL binding definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.HostNameSslBinding.Definition.IBlank<Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition.IWithCreate<FluentT>> DefineSslBinding();
    }
}