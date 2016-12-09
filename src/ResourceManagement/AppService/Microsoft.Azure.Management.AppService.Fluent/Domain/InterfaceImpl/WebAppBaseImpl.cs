// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using WebAppBase.Definition;
    using WebAppBase.Update;
    using Microsoft.Azure.Management.Resource.Fluent;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using System.Collections.Generic;
    using System;

    internal abstract partial class WebAppBaseImpl<FluentT,FluentImplT> 
    {
        /// <summary>
        /// Removes source control for deployment from the web app.
        /// </summary>
        WebAppBase.Update.IUpdate<FluentT> WebAppBase.Update.IWithSourceControl<FluentT>.WithoutSourceControl()
        {
            return this.WithoutSourceControl() as WebAppBase.Update.IUpdate<FluentT>;
        }

        /// <summary>
        /// Specifies the source control to be a local Git repository on the web app.
        /// </summary>
        WebAppBase.Update.IUpdate<FluentT> WebAppBase.Update.IWithSourceControl<FluentT>.WithLocalGitSourceControl()
        {
            return this.WithLocalGitSourceControl() as WebAppBase.Update.IUpdate<FluentT>;
        }

        /// <summary>
        /// Starts the definition of a new source control.
        /// </summary>
        WebAppSourceControl.UpdateDefinition.IBlank<WebAppBase.Update.IUpdate<FluentT>> WebAppBase.Update.IWithSourceControl<FluentT>.DefineSourceControl
        {
            get
            {
                return this.DefineSourceControl() as WebAppSourceControl.UpdateDefinition.IBlank<WebAppBase.Update.IUpdate<FluentT>>;
            }
        }

        /// <summary>
        /// Specifies the source control to be a local Git repository on the web app.
        /// </summary>
        WebAppBase.Definition.IWithCreate<FluentT> WebAppBase.Definition.IWithSourceControl<FluentT>.WithLocalGitSourceControl()
        {
            return this.WithLocalGitSourceControl() as WebAppBase.Definition.IWithCreate<FluentT>;
        }

        /// <summary>
        /// Starts the definition of a new source control.
        /// </summary>
        WebAppSourceControl.Definition.IBlank<WebAppBase.Definition.IWithCreate<FluentT>> WebAppBase.Definition.IWithSourceControl<FluentT>.DefineSourceControl
        {
            get
            {
                return this.DefineSourceControl() as WebAppSourceControl.Definition.IBlank<WebAppBase.Definition.IWithCreate<FluentT>>;
            }
        }

        /// <summary>
        /// Specifies if SCM site is also stopped when the web app is stopped.
        /// </summary>
        /// <param name="scmSiteAlsoStopped">True if SCM site is also stopped.</param>
        WebAppBase.Update.IUpdate<FluentT> WebAppBase.Update.IWithScmSiteAlsoStopped<FluentT>.WithScmSiteAlsoStopped(bool scmSiteAlsoStopped)
        {
            return this.WithScmSiteAlsoStopped(scmSiteAlsoStopped) as WebAppBase.Update.IUpdate<FluentT>;
        }

        /// <summary>
        /// Specifies if SCM site is also stopped when the web app is stopped.
        /// </summary>
        /// <param name="scmSiteAlsoStopped">True if SCM site is also stopped.</param>
        WebAppBase.Definition.IWithCreate<FluentT> WebAppBase.Definition.IWithScmSiteAlsoStopped<FluentT>.WithScmSiteAlsoStopped(bool scmSiteAlsoStopped)
        {
            return this.WithScmSiteAlsoStopped(scmSiteAlsoStopped) as WebAppBase.Definition.IWithCreate<FluentT>;
        }

        Microsoft.Azure.Management.AppService.Fluent.Models.SiteAvailabilityState Microsoft.Azure.Management.Appservice.Fluent.IWebAppBase<T>.AvailabilityState
        {
            get
            {
                return this.AvailabilityState();
            }
        }

        bool Microsoft.Azure.Management.Appservice.Fluent.IWebAppBase<T>.Enabled
        {
            get
            {
                return this.Enabled();
            }
        }

        Microsoft.Azure.Management.AppService.Fluent.Models.RemoteVisualStudioVersion Microsoft.Azure.Management.Appservice.Fluent.IWebAppBase<T>.RemoteDebuggingVersion
        {
            get
            {
                return this.RemoteDebuggingVersion() as Microsoft.Azure.Management.AppService.Fluent.Models.RemoteVisualStudioVersion;
            }
        }

        bool Microsoft.Azure.Management.Appservice.Fluent.IWebAppBase<T>.WebSocketsEnabled
        {
            get
            {
                return this.WebSocketsEnabled();
            }
        }

        bool Microsoft.Azure.Management.Appservice.Fluent.IWebAppBase<T>.IsDefaultContainer
        {
            get
            {
                return this.IsDefaultContainer();
            }
        }

        Microsoft.Azure.Management.AppService.Fluent.Models.ManagedPipelineMode Microsoft.Azure.Management.Appservice.Fluent.IWebAppBase<T>.ManagedPipelineMode
        {
            get
            {
                return this.ManagedPipelineMode();
            }
        }

        string Microsoft.Azure.Management.Appservice.Fluent.IWebAppBase<T>.NodeVersion
        {
            get
            {
                return this.NodeVersion();
            }
        }

        string Microsoft.Azure.Management.Appservice.Fluent.IWebAppBase<T>.RepositorySiteName
        {
            get
            {
                return this.RepositorySiteName();
            }
        }

        bool Microsoft.Azure.Management.Appservice.Fluent.IWebAppBase<T>.HostNamesDisabled
        {
            get
            {
                return this.HostNamesDisabled();
            }
        }

        Microsoft.Azure.Management.AppService.Fluent.Models.PhpVersion Microsoft.Azure.Management.Appservice.Fluent.IWebAppBase<T>.PhpVersion
        {
            get
            {
                return this.PhpVersion() as Microsoft.Azure.Management.AppService.Fluent.Models.PhpVersion;
            }
        }

        bool Microsoft.Azure.Management.Appservice.Fluent.IWebAppBase<T>.IsPremiumApp
        {
            get
            {
                return this.IsPremiumApp();
            }
        }

        bool Microsoft.Azure.Management.Appservice.Fluent.IWebAppBase<T>.ScmSiteAlsoStopped
        {
            get
            {
                return this.ScmSiteAlsoStopped();
            }
        }

        string Microsoft.Azure.Management.Appservice.Fluent.IWebAppBase<T>.AutoSwapSlotName
        {
            get
            {
                return this.AutoSwapSlotName();
            }
        }

        string Microsoft.Azure.Management.Appservice.Fluent.IWebAppBase<T>.JavaContainerVersion
        {
            get
            {
                return this.JavaContainerVersion();
            }
        }

        Microsoft.Azure.Management.AppService.Fluent.Models.UsageState Microsoft.Azure.Management.Appservice.Fluent.IWebAppBase<T>.UsageState
        {
            get
            {
                return this.UsageState();
            }
        }

        string Microsoft.Azure.Management.Appservice.Fluent.IWebAppBase<T>.AppServicePlanId
        {
            get
            {
                return this.AppServicePlanId();
            }
        }

        string Microsoft.Azure.Management.Appservice.Fluent.IWebAppBase<T>.GatewaySiteName
        {
            get
            {
                return this.GatewaySiteName();
            }
        }

        System.Collections.Generic.IList<string> Microsoft.Azure.Management.Appservice.Fluent.IWebAppBase<T>.DefaultDocuments
        {
            get
            {
                return this.DefaultDocuments() as System.Collections.Generic.IList<string>;
            }
        }

        Microsoft.Azure.Management.AppService.Fluent.Models.PythonVersion Microsoft.Azure.Management.Appservice.Fluent.IWebAppBase<T>.PythonVersion
        {
            get
            {
                return this.PythonVersion() as Microsoft.Azure.Management.AppService.Fluent.Models.PythonVersion;
            }
        }

        bool Microsoft.Azure.Management.Appservice.Fluent.IWebAppBase<T>.AlwaysOn
        {
            get
            {
                return this.AlwaysOn();
            }
        }

        System.Collections.Generic.ISet<string> Microsoft.Azure.Management.Appservice.Fluent.IWebAppBase<T>.HostNames
        {
            get
            {
                return this.HostNames() as System.Collections.Generic.ISet<string>;
            }
        }

        string Microsoft.Azure.Management.Appservice.Fluent.IWebAppBase<T>.JavaContainer
        {
            get
            {
                return this.JavaContainer();
            }
        }

        System.Collections.Generic.ISet<string> Microsoft.Azure.Management.Appservice.Fluent.IWebAppBase<T>.OutboundIpAddresses
        {
            get
            {
                return this.OutboundIpAddresses() as System.Collections.Generic.ISet<string>;
            }
        }

        Microsoft.Azure.Management.AppService.Fluent.Models.NetFrameworkVersion Microsoft.Azure.Management.Appservice.Fluent.IWebAppBase<T>.NetFrameworkVersion
        {
            get
            {
                return this.NetFrameworkVersion() as Microsoft.Azure.Management.AppService.Fluent.Models.NetFrameworkVersion;
            }
        }

        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Appservice.Fluent.IConnectionString> Microsoft.Azure.Management.Appservice.Fluent.IWebAppBase<T>.ConnectionStrings
        {
            get
            {
                return this.ConnectionStrings() as System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Appservice.Fluent.IConnectionString>;
            }
        }

        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.AppService.Fluent.Models.HostNameSslState> Microsoft.Azure.Management.Appservice.Fluent.IWebAppBase<T>.HostNameSslStates
        {
            get
            {
                return this.HostNameSslStates() as System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.AppService.Fluent.Models.HostNameSslState>;
            }
        }

        System.Collections.Generic.ISet<string> Microsoft.Azure.Management.Appservice.Fluent.IWebAppBase<T>.TrafficManagerHostNames
        {
            get
            {
                return this.TrafficManagerHostNames() as System.Collections.Generic.ISet<string>;
            }
        }

        string Microsoft.Azure.Management.Appservice.Fluent.IWebAppBase<T>.MicroService
        {
            get
            {
                return this.MicroService();
            }
        }

        bool Microsoft.Azure.Management.Appservice.Fluent.IWebAppBase<T>.ClientAffinityEnabled
        {
            get
            {
                return this.ClientAffinityEnabled();
            }
        }

        bool Microsoft.Azure.Management.Appservice.Fluent.IWebAppBase<T>.ClientCertEnabled
        {
            get
            {
                return this.ClientCertEnabled();
            }
        }

        Microsoft.Azure.Management.AppService.Fluent.Models.JavaVersion Microsoft.Azure.Management.Appservice.Fluent.IWebAppBase<T>.JavaVersion
        {
            get
            {
                return this.JavaVersion() as Microsoft.Azure.Management.AppService.Fluent.Models.JavaVersion;
            }
        }

        Microsoft.Azure.Management.AppService.Fluent.Models.CloningInfo Microsoft.Azure.Management.Appservice.Fluent.IWebAppBase<T>.CloningInfo
        {
            get
            {
                return this.CloningInfo() as Microsoft.Azure.Management.AppService.Fluent.Models.CloningInfo;
            }
        }

        System.Collections.Generic.ISet<string> Microsoft.Azure.Management.Appservice.Fluent.IWebAppBase<T>.EnabledHostNames
        {
            get
            {
                return this.EnabledHostNames() as System.Collections.Generic.ISet<string>;
            }
        }

        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Appservice.Fluent.IAppSetting> Microsoft.Azure.Management.Appservice.Fluent.IWebAppBase<T>.AppSettings
        {
            get
            {
                return this.AppSettings() as System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.Appservice.Fluent.IAppSetting>;
            }
        }

        bool Microsoft.Azure.Management.Appservice.Fluent.IWebAppBase<T>.RemoteDebuggingEnabled
        {
            get
            {
                return this.RemoteDebuggingEnabled();
            }
        }

        string Microsoft.Azure.Management.Appservice.Fluent.IWebAppBase<T>.TargetSwapSlot
        {
            get
            {
                return this.TargetSwapSlot();
            }
        }

        string Microsoft.Azure.Management.Appservice.Fluent.IWebAppBase<T>.DefaultHostName
        {
            get
            {
                return this.DefaultHostName();
            }
        }

        string Microsoft.Azure.Management.Appservice.Fluent.IWebAppBase<T>.State
        {
            get
            {
                return this.State();
            }
        }

        System.DateTime Microsoft.Azure.Management.Appservice.Fluent.IWebAppBase<T>.LastModifiedTime
        {
            get
            {
                return this.LastModifiedTime();
            }
        }

        int Microsoft.Azure.Management.Appservice.Fluent.IWebAppBase<T>.ContainerSize
        {
            get
            {
                return this.ContainerSize();
            }
        }

        /// <summary>
        /// Disables the web app upon creation.
        /// </summary>
        WebAppBase.Update.IUpdate<FluentT> WebAppBase.Update.IWithSiteEnabled<FluentT>.WithAppDisabledOnCreation()
        {
            return this.WithAppDisabledOnCreation() as WebAppBase.Update.IUpdate<FluentT>;
        }

        /// <summary>
        /// Disables the web app upon creation.
        /// </summary>
        WebAppBase.Definition.IWithCreate<FluentT> WebAppBase.Definition.IWithSiteEnabled<FluentT>.WithAppDisabledOnCreation()
        {
            return this.WithAppDisabledOnCreation() as WebAppBase.Definition.IWithCreate<FluentT>;
        }

        /// <summary>
        /// Changes the stickiness of an app setting.
        /// </summary>
        /// <param name="key">The key of the app setting to change stickiness.</param>
        /// <param name="sticky">True if the app setting sticks to the slot during a swap.</param>
        WebAppBase.Update.IUpdate<FluentT> WebAppBase.Update.IWithAppSettings<FluentT>.WithAppSettingStickiness(string key, bool sticky)
        {
            return this.WithAppSettingStickiness(key, sticky) as WebAppBase.Update.IUpdate<FluentT>;
        }

        /// <summary>
        /// Specifies the app settings for the web app as a Map. These app settings
        /// will stay at the slot during a swap.
        /// </summary>
        /// <param name="settings">A Map of app settings.</param>
        WebAppBase.Update.IUpdate<FluentT> WebAppBase.Update.IWithAppSettings<FluentT>.WithStickyAppSettings(IDictionary<string,string> settings)
        {
            return this.WithStickyAppSettings(settings) as WebAppBase.Update.IUpdate<FluentT>;
        }

        /// <summary>
        /// Specifies the app settings for the web app as a Map.
        /// </summary>
        /// <param name="settings">A Map of app settings.</param>
        WebAppBase.Update.IUpdate<FluentT> WebAppBase.Update.IWithAppSettings<FluentT>.WithAppSettings(IDictionary<string,string> settings)
        {
            return this.WithAppSettings(settings) as WebAppBase.Update.IUpdate<FluentT>;
        }

        /// <summary>
        /// Adds an app setting to the web app.
        /// </summary>
        /// <param name="key">The key for the app setting.</param>
        /// <param name="value">The value for the app setting.</param>
        WebAppBase.Update.IUpdate<FluentT> WebAppBase.Update.IWithAppSettings<FluentT>.WithAppSetting(string key, string value)
        {
            return this.WithAppSetting(key, value) as WebAppBase.Update.IUpdate<FluentT>;
        }

        /// <summary>
        /// Adds an app setting to the web app. This app setting
        /// will stay at the slot during a swap.
        /// </summary>
        /// <param name="key">The key for the app setting.</param>
        /// <param name="value">The value for the app setting.</param>
        WebAppBase.Update.IUpdate<FluentT> WebAppBase.Update.IWithAppSettings<FluentT>.WithStickyAppSetting(string key, string value)
        {
            return this.WithStickyAppSetting(key, value) as WebAppBase.Update.IUpdate<FluentT>;
        }

        /// <summary>
        /// Removes an app setting from the web app.
        /// </summary>
        /// <param name="key">The key of the app setting to remove.</param>
        WebAppBase.Update.IUpdate<FluentT> WebAppBase.Update.IWithAppSettings<FluentT>.WithoutAppSetting(string key)
        {
            return this.WithoutAppSetting(key) as WebAppBase.Update.IUpdate<FluentT>;
        }

        /// <summary>
        /// Specifies the app settings for the web app as a Map. These app settings will be swapped
        /// as well after a deployment slot swap.
        /// </summary>
        /// <param name="settings">A Map of app settings.</param>
        WebAppBase.Definition.IWithCreate<FluentT> WebAppBase.Definition.IWithAppSettings<FluentT>.WithStickyAppSettings(IDictionary<string,string> settings)
        {
            return this.WithStickyAppSettings(settings) as WebAppBase.Definition.IWithCreate<FluentT>;
        }

        /// <summary>
        /// Specifies the app settings for the web app as a Map.
        /// </summary>
        /// <param name="settings">A Map of app settings.</param>
        WebAppBase.Definition.IWithCreate<FluentT> WebAppBase.Definition.IWithAppSettings<FluentT>.WithAppSettings(IDictionary<string,string> settings)
        {
            return this.WithAppSettings(settings) as WebAppBase.Definition.IWithCreate<FluentT>;
        }

        /// <summary>
        /// Adds an app setting to the web app.
        /// </summary>
        /// <param name="key">The key for the app setting.</param>
        /// <param name="value">The value for the app setting.</param>
        WebAppBase.Definition.IWithCreate<FluentT> WebAppBase.Definition.IWithAppSettings<FluentT>.WithAppSetting(string key, string value)
        {
            return this.WithAppSetting(key, value) as WebAppBase.Definition.IWithCreate<FluentT>;
        }

        /// <summary>
        /// Adds an app setting to the web app. This app setting will be swapped
        /// as well after a deployment slot swap.
        /// </summary>
        /// <param name="key">The key for the app setting.</param>
        /// <param name="value">The value for the app setting.</param>
        WebAppBase.Definition.IWithCreate<FluentT> WebAppBase.Definition.IWithAppSettings<FluentT>.WithStickyAppSetting(string key, string value)
        {
            return this.WithStickyAppSetting(key, value) as WebAppBase.Definition.IWithCreate<FluentT>;
        }

        /// <summary>
        /// Adds a connection string to the web app.
        /// </summary>
        /// <param name="name">The name of the connection string.</param>
        /// <param name="value">The connection string value.</param>
        /// <param name="type">The connection string type.</param>
        WebAppBase.Update.IUpdate<FluentT> WebAppBase.Update.IWithConnectionString<FluentT>.WithConnectionString(string name, string value, ConnectionStringType type)
        {
            return this.WithConnectionString(name, value, type) as WebAppBase.Update.IUpdate<FluentT>;
        }

        /// <summary>
        /// Adds a connection string to the web app. This connection string
        /// will stay at the slot during a swap.
        /// </summary>
        /// <param name="name">The name of the connection string.</param>
        /// <param name="value">The connection string value.</param>
        /// <param name="type">The connection string type.</param>
        WebAppBase.Update.IUpdate<FluentT> WebAppBase.Update.IWithConnectionString<FluentT>.WithStickyConnectionString(string name, string value, ConnectionStringType type)
        {
            return this.WithStickyConnectionString(name, value, type) as WebAppBase.Update.IUpdate<FluentT>;
        }

        /// <summary>
        /// Removes a connection string from the web app.
        /// </summary>
        /// <param name="name">The name of the connection string.</param>
        WebAppBase.Update.IUpdate<FluentT> WebAppBase.Update.IWithConnectionString<FluentT>.WithoutConnectionString(string name)
        {
            return this.WithoutConnectionString(name) as WebAppBase.Update.IUpdate<FluentT>;
        }

        /// <summary>
        /// Changes the stickiness of a connection string.
        /// </summary>
        /// <param name="name">The name of the connection string.</param>
        /// <param name="sticky">True if the connection string sticks to the slot during a swap.</param>
        WebAppBase.Update.IUpdate<FluentT> WebAppBase.Update.IWithConnectionString<FluentT>.WithConnectionStringStickiness(string name, bool sticky)
        {
            return this.WithConnectionStringStickiness(name, sticky) as WebAppBase.Update.IUpdate<FluentT>;
        }

        /// <summary>
        /// Adds a connection string to the web app.
        /// </summary>
        /// <param name="name">The name of the connection string.</param>
        /// <param name="value">The connection string value.</param>
        /// <param name="type">The connection string type.</param>
        WebAppBase.Definition.IWithCreate<FluentT> WebAppBase.Definition.IWithConnectionString<FluentT>.WithConnectionString(string name, string value, ConnectionStringType type)
        {
            return this.WithConnectionString(name, value, type) as WebAppBase.Definition.IWithCreate<FluentT>;
        }

        /// <summary>
        /// Adds a connection string to the web app. This connection string will be swapped
        /// as well after a deployment slot swap.
        /// </summary>
        /// <param name="name">The name of the connection string.</param>
        /// <param name="value">The connection string value.</param>
        /// <param name="type">The connection string type.</param>
        WebAppBase.Definition.IWithCreate<FluentT> WebAppBase.Definition.IWithConnectionString<FluentT>.WithStickyConnectionString(string name, string value, ConnectionStringType type)
        {
            return this.WithStickyConnectionString(name, value, type) as WebAppBase.Definition.IWithCreate<FluentT>;
        }

        /// <summary>
        /// Removes an SSL binding for a specific hostname.
        /// </summary>
        /// <param name="hostname">The hostname to remove SSL certificate from.</param>
        WebAppBase.Update.IUpdate<FluentT> WebAppBase.Update.IWithHostNameSslBinding<FluentT>.WithoutSslBinding(string hostname)
        {
            return this.WithoutSslBinding(hostname) as WebAppBase.Update.IUpdate<FluentT>;
        }

        /// <summary>
        /// Starts a definition of an SSL binding.
        /// </summary>
        HostNameSslBinding.UpdateDefinition.IBlank<WebAppBase.Update.IUpdate<FluentT>> WebAppBase.Update.IWithHostNameSslBinding<FluentT>.DefineSslBinding
        {
            get
            {
                return this.DefineSslBinding() as HostNameSslBinding.UpdateDefinition.IBlank<WebAppBase.Update.IUpdate<FluentT>>;
            }
        }

        /// <summary>
        /// Starts a definition of an SSL binding.
        /// </summary>
        HostNameSslBinding.Definition.IBlank<WebAppBase.Definition.IWithHostNameSslBinding<FluentT>> WebAppBase.Definition.IWithHostNameSslBinding<FluentT>.DefineSslBinding
        {
            get
            {
                return this.DefineSslBinding() as HostNameSslBinding.Definition.IBlank<WebAppBase.Definition.IWithHostNameSslBinding<FluentT>>;
            }
        }

        /// <summary>
        /// Defines a list of host names of an externally purchased domain. The hostnames
        /// must be configured before hand to point to the web app.
        /// </summary>
        /// <param name="domain">The external domain name.</param>
        /// <param name="hostnames">The list of sub-domains.</param>
        WebAppBase.Update.IUpdate<FluentT> WebAppBase.Update.IWithHostNameBinding<FluentT>.WithThirdPartyHostnameBinding(string domain, params string[] hostnames)
        {
            return this.WithThirdPartyHostnameBinding(domain, hostnames) as WebAppBase.Update.IUpdate<FluentT>;
        }

        /// <summary>
        /// Defines a list of host names of an Azure managed domain. The DNS record type is
        /// defaulted to be CNAME except for the root level domain (".
        /// </summary>
        /// <param name="domain">The Azure managed domain.</param>
        /// <param name="hostnames">The list of sub-domains.</param>
        WebAppBase.Update.IUpdate<FluentT> WebAppBase.Update.IWithHostNameBinding<FluentT>.WithManagedHostnameBindings(IAppServiceDomain domain, params string[] hostnames)
        {
            return this.WithManagedHostnameBindings(domain, hostnames) as WebAppBase.Update.IUpdate<FluentT>;
        }

        /// <summary>
        /// Starts the definition of a new host name binding.
        /// </summary>
        HostNameBinding.UpdateDefinition.IBlank<WebAppBase.Update.IUpdate<FluentT>> WebAppBase.Update.IWithHostNameBinding<FluentT>.DefineHostnameBinding
        {
            get
            {
                return this.DefineHostnameBinding() as HostNameBinding.UpdateDefinition.IBlank<WebAppBase.Update.IUpdate<FluentT>>;
            }
        }

        /// <summary>
        /// Unbinds a hostname from the web app.
        /// </summary>
        /// <param name="hostname">The hostname to unbind.</param>
        WebAppBase.Update.IUpdate<FluentT> WebAppBase.Update.IWithHostNameBinding<FluentT>.WithoutHostnameBinding(string hostname)
        {
            return this.WithoutHostnameBinding(hostname) as WebAppBase.Update.IUpdate<FluentT>;
        }

        /// <summary>
        /// Defines a list of host names of an externally purchased domain. The hostnames
        /// must be configured before hand to point to the web app.
        /// </summary>
        /// <param name="domain">The external domain name.</param>
        /// <param name="hostnames">The list of sub-domains.</param>
        WebAppBase.Definition.IWithHostNameSslBinding<FluentT> WebAppBase.Definition.IWithHostNameBinding<FluentT>.WithThirdPartyHostnameBinding(string domain, params string[] hostnames)
        {
            return this.WithThirdPartyHostnameBinding(domain, hostnames) as WebAppBase.Definition.IWithHostNameSslBinding<FluentT>;
        }

        /// <summary>
        /// Defines a list of host names of an Azure managed domain. The DNS record type is
        /// defaulted to be CNAME except for the root level domain (".
        /// </summary>
        /// <param name="domain">The Azure managed domain.</param>
        /// <param name="hostnames">The list of sub-domains.</param>
        WebAppBase.Definition.IWithHostNameSslBinding<FluentT> WebAppBase.Definition.IWithHostNameBinding<FluentT>.WithManagedHostnameBindings(IAppServiceDomain domain, params string[] hostnames)
        {
            return this.WithManagedHostnameBindings(domain, hostnames) as WebAppBase.Definition.IWithHostNameSslBinding<FluentT>;
        }

        /// <summary>
        /// Starts the definition of a new host name binding.
        /// </summary>
        HostNameBinding.Definition.IBlank<WebAppBase.Definition.IWithHostNameSslBinding<FluentT>> WebAppBase.Definition.IWithHostNameBinding<FluentT>.DefineHostnameBinding
        {
            get
            {
                return this.DefineHostnameBinding() as HostNameBinding.Definition.IBlank<WebAppBase.Definition.IWithHostNameSslBinding<FluentT>>;
            }
        }

        /// <summary>
        /// Adds a list of default documents.
        /// </summary>
        /// <param name="documents">List of default documents.</param>
        WebAppBase.Update.IUpdate<FluentT> WebAppBase.Update.IWithSiteConfigs<FluentT>.WithDefaultDocuments(IList<string> documents)
        {
            return this.WithDefaultDocuments(documents) as WebAppBase.Update.IUpdate<FluentT>;
        }

        /// <summary>
        /// Specifies if web sockets are enabled.
        /// </summary>
        /// <param name="enabled">True if web sockets are enabled.</param>
        WebAppBase.Update.IUpdate<FluentT> WebAppBase.Update.IWithSiteConfigs<FluentT>.WithWebSocketsEnabled(bool enabled)
        {
            return this.WithWebSocketsEnabled(enabled) as WebAppBase.Update.IUpdate<FluentT>;
        }

        /// <summary>
        /// Turn off Java support.
        /// </summary>
        WebAppBase.Update.IUpdate<FluentT> WebAppBase.Update.IWithSiteConfigs<FluentT>.WithoutJava()
        {
            return this.WithoutJava() as WebAppBase.Update.IUpdate<FluentT>;
        }

        /// <summary>
        /// Specifies the Java version.
        /// </summary>
        /// <param name="version">The Java version.</param>
        WebAppBase.Update.IWithWebContainer<FluentT> WebAppBase.Update.IWithSiteConfigs<FluentT>.WithJavaVersion(JavaVersion version)
        {
            return this.WithJavaVersion(version) as WebAppBase.Update.IWithWebContainer<FluentT>;
        }

        /// <summary>
        /// Disables remote debugging.
        /// </summary>
        WebAppBase.Update.IUpdate<FluentT> WebAppBase.Update.IWithSiteConfigs<FluentT>.WithRemoteDebuggingDisabled()
        {
            return this.WithRemoteDebuggingDisabled() as WebAppBase.Update.IUpdate<FluentT>;
        }

        /// <summary>
        /// Specifies if the VM powering the web app is always powered on.
        /// </summary>
        /// <param name="alwaysOn">True if the web app is always powered on.</param>
        WebAppBase.Update.IUpdate<FluentT> WebAppBase.Update.IWithSiteConfigs<FluentT>.WithWebAppAlwaysOn(bool alwaysOn)
        {
            return this.WithWebAppAlwaysOn(alwaysOn) as WebAppBase.Update.IUpdate<FluentT>;
        }

        /// <summary>
        /// Removes a default document.
        /// </summary>
        /// <param name="document">Default document to remove.</param>
        WebAppBase.Update.IUpdate<FluentT> WebAppBase.Update.IWithSiteConfigs<FluentT>.WithoutDefaultDocument(string document)
        {
            return this.WithoutDefaultDocument(document) as WebAppBase.Update.IUpdate<FluentT>;
        }

        /// <summary>
        /// Specifies the platform architecture to use.
        /// </summary>
        /// <param name="platform">The platform architecture.</param>
        WebAppBase.Update.IUpdate<FluentT> WebAppBase.Update.IWithSiteConfigs<FluentT>.WithPlatformArchitecture(PlatformArchitecture platform)
        {
            return this.WithPlatformArchitecture(platform) as WebAppBase.Update.IUpdate<FluentT>;
        }

        /// <summary>
        /// Adds a default document.
        /// </summary>
        /// <param name="document">Default document.</param>
        WebAppBase.Update.IUpdate<FluentT> WebAppBase.Update.IWithSiteConfigs<FluentT>.WithDefaultDocument(string document)
        {
            return this.WithDefaultDocument(document) as WebAppBase.Update.IUpdate<FluentT>;
        }

        /// <summary>
        /// Specifies the .NET Framework version.
        /// </summary>
        /// <param name="version">The .NET Framework version.</param>
        WebAppBase.Update.IUpdate<FluentT> WebAppBase.Update.IWithSiteConfigs<FluentT>.WithNetFrameworkVersion(NetFrameworkVersion version)
        {
            return this.WithNetFrameworkVersion(version) as WebAppBase.Update.IUpdate<FluentT>;
        }

        /// <summary>
        /// Specifies the PHP version.
        /// </summary>
        /// <param name="version">The PHP version.</param>
        WebAppBase.Update.IUpdate<FluentT> WebAppBase.Update.IWithSiteConfigs<FluentT>.WithPhpVersion(PhpVersion version)
        {
            return this.WithPhpVersion(version) as WebAppBase.Update.IUpdate<FluentT>;
        }

        /// <summary>
        /// Turn off Python support.
        /// </summary>
        WebAppBase.Update.IUpdate<FluentT> WebAppBase.Update.IWithSiteConfigs<FluentT>.WithoutPython()
        {
            return this.WithoutPython() as WebAppBase.Update.IUpdate<FluentT>;
        }

        /// <summary>
        /// Specifies the slot name to auto-swap when a deployment is completed in this web app / deployment slot.
        /// </summary>
        /// <param name="slotName">The name of the slot, or 'production', to auto-swap.</param>
        WebAppBase.Update.IUpdate<FluentT> WebAppBase.Update.IWithSiteConfigs<FluentT>.WithAutoSwapSlotName(string slotName)
        {
            return this.WithAutoSwapSlotName(slotName) as WebAppBase.Update.IUpdate<FluentT>;
        }

        /// <summary>
        /// Specifies the Visual Studio version for remote debugging.
        /// </summary>
        /// <param name="remoteVisualStudioVersion">The Visual Studio version for remote debugging.</param>
        WebAppBase.Update.IUpdate<FluentT> WebAppBase.Update.IWithSiteConfigs<FluentT>.WithRemoteDebuggingEnabled(RemoteVisualStudioVersion remoteVisualStudioVersion)
        {
            return this.WithRemoteDebuggingEnabled(remoteVisualStudioVersion) as WebAppBase.Update.IUpdate<FluentT>;
        }

        /// <summary>
        /// Specifies the managed pipeline mode.
        /// </summary>
        /// <param name="managedPipelineMode">Managed pipeline mode.</param>
        WebAppBase.Update.IUpdate<FluentT> WebAppBase.Update.IWithSiteConfigs<FluentT>.WithManagedPipelineMode(ManagedPipelineMode managedPipelineMode)
        {
            return this.WithManagedPipelineMode(managedPipelineMode) as WebAppBase.Update.IUpdate<FluentT>;
        }

        /// <summary>
        /// Specifies the Python version.
        /// </summary>
        /// <param name="version">The Python version.</param>
        WebAppBase.Update.IUpdate<FluentT> WebAppBase.Update.IWithSiteConfigs<FluentT>.WithPythonVersion(PythonVersion version)
        {
            return this.WithPythonVersion(version) as WebAppBase.Update.IUpdate<FluentT>;
        }

        /// <summary>
        /// Adds a list of default documents.
        /// </summary>
        /// <param name="documents">List of default documents.</param>
        WebAppBase.Definition.IWithCreate<FluentT> WebAppBase.Definition.IWithSiteConfigs<FluentT>.WithDefaultDocuments(IList<string> documents)
        {
            return this.WithDefaultDocuments(documents) as WebAppBase.Definition.IWithCreate<FluentT>;
        }

        /// <summary>
        /// Specifies if web sockets are enabled.
        /// </summary>
        /// <param name="enabled">True if web sockets are enabled.</param>
        WebAppBase.Definition.IWithCreate<FluentT> WebAppBase.Definition.IWithSiteConfigs<FluentT>.WithWebSocketsEnabled(bool enabled)
        {
            return this.WithWebSocketsEnabled(enabled) as WebAppBase.Definition.IWithCreate<FluentT>;
        }

        /// <summary>
        /// Turn off PHP support.
        /// </summary>
        WebAppBase.Definition.IWithCreate<FluentT> WebAppBase.Definition.IWithSiteConfigs<FluentT>.WithoutPhp()
        {
            return this.WithoutPhp() as WebAppBase.Definition.IWithCreate<FluentT>;
        }

        /// <summary>
        /// Specifies the Java version.
        /// </summary>
        /// <param name="version">The Java version.</param>
        WebAppBase.Definition.IWithWebContainer<FluentT> WebAppBase.Definition.IWithSiteConfigs<FluentT>.WithJavaVersion(JavaVersion version)
        {
            return this.WithJavaVersion(version) as WebAppBase.Definition.IWithWebContainer<FluentT>;
        }

        /// <summary>
        /// Disables remote debugging.
        /// </summary>
        WebAppBase.Definition.IWithCreate<FluentT> WebAppBase.Definition.IWithSiteConfigs<FluentT>.WithRemoteDebuggingDisabled()
        {
            return this.WithRemoteDebuggingDisabled() as WebAppBase.Definition.IWithCreate<FluentT>;
        }

        /// <summary>
        /// Specifies if the VM powering the web app is always powered on.
        /// </summary>
        /// <param name="alwaysOn">True if the web app is always powered on.</param>
        WebAppBase.Definition.IWithCreate<FluentT> WebAppBase.Definition.IWithSiteConfigs<FluentT>.WithWebAppAlwaysOn(bool alwaysOn)
        {
            return this.WithWebAppAlwaysOn(alwaysOn) as WebAppBase.Definition.IWithCreate<FluentT>;
        }

        /// <summary>
        /// Removes a default document.
        /// </summary>
        /// <param name="document">Default document to remove.</param>
        WebAppBase.Definition.IWithCreate<FluentT> WebAppBase.Definition.IWithSiteConfigs<FluentT>.WithoutDefaultDocument(string document)
        {
            return this.WithoutDefaultDocument(document) as WebAppBase.Definition.IWithCreate<FluentT>;
        }

        /// <summary>
        /// Specifies the platform architecture to use.
        /// </summary>
        /// <param name="platform">The platform architecture.</param>
        WebAppBase.Definition.IWithCreate<FluentT> WebAppBase.Definition.IWithSiteConfigs<FluentT>.WithPlatformArchitecture(PlatformArchitecture platform)
        {
            return this.WithPlatformArchitecture(platform) as WebAppBase.Definition.IWithCreate<FluentT>;
        }

        /// <summary>
        /// Adds a default document.
        /// </summary>
        /// <param name="document">Default document.</param>
        WebAppBase.Definition.IWithCreate<FluentT> WebAppBase.Definition.IWithSiteConfigs<FluentT>.WithDefaultDocument(string document)
        {
            return this.WithDefaultDocument(document) as WebAppBase.Definition.IWithCreate<FluentT>;
        }

        /// <summary>
        /// Specifies the .NET Framework version.
        /// </summary>
        /// <param name="version">The .NET Framework version.</param>
        WebAppBase.Definition.IWithCreate<FluentT> WebAppBase.Definition.IWithSiteConfigs<FluentT>.WithNetFrameworkVersion(NetFrameworkVersion version)
        {
            return this.WithNetFrameworkVersion(version) as WebAppBase.Definition.IWithCreate<FluentT>;
        }

        /// <summary>
        /// Specifies the PHP version.
        /// </summary>
        /// <param name="version">The PHP version.</param>
        WebAppBase.Definition.IWithCreate<FluentT> WebAppBase.Definition.IWithSiteConfigs<FluentT>.WithPhpVersion(PhpVersion version)
        {
            return this.WithPhpVersion(version) as WebAppBase.Definition.IWithCreate<FluentT>;
        }

        /// <summary>
        /// Specifies the slot name to auto-swap when a deployment is completed in this web app / deployment slot.
        /// </summary>
        /// <param name="slotName">The name of the slot, or 'production', to auto-swap.</param>
        WebAppBase.Definition.IWithCreate<FluentT> WebAppBase.Definition.IWithSiteConfigs<FluentT>.WithAutoSwapSlotName(string slotName)
        {
            return this.WithAutoSwapSlotName(slotName) as WebAppBase.Definition.IWithCreate<FluentT>;
        }

        /// <summary>
        /// Specifies the Visual Studio version for remote debugging.
        /// </summary>
        /// <param name="remoteVisualStudioVersion">The Visual Studio version for remote debugging.</param>
        WebAppBase.Definition.IWithCreate<FluentT> WebAppBase.Definition.IWithSiteConfigs<FluentT>.WithRemoteDebuggingEnabled(RemoteVisualStudioVersion remoteVisualStudioVersion)
        {
            return this.WithRemoteDebuggingEnabled(remoteVisualStudioVersion) as WebAppBase.Definition.IWithCreate<FluentT>;
        }

        /// <summary>
        /// Specifies the managed pipeline mode.
        /// </summary>
        /// <param name="managedPipelineMode">Managed pipeline mode.</param>
        WebAppBase.Definition.IWithCreate<FluentT> WebAppBase.Definition.IWithSiteConfigs<FluentT>.WithManagedPipelineMode(ManagedPipelineMode managedPipelineMode)
        {
            return this.WithManagedPipelineMode(managedPipelineMode) as WebAppBase.Definition.IWithCreate<FluentT>;
        }

        /// <summary>
        /// Specifies the Python version.
        /// </summary>
        /// <param name="version">The Python version.</param>
        WebAppBase.Definition.IWithCreate<FluentT> WebAppBase.Definition.IWithSiteConfigs<FluentT>.WithPythonVersion(PythonVersion version)
        {
            return this.WithPythonVersion(version) as WebAppBase.Definition.IWithCreate<FluentT>;
        }

        /// <summary>
        /// Specifies if client affinity is enabled.
        /// </summary>
        /// <param name="enabled">True if client affinity is enabled.</param>
        WebAppBase.Update.IUpdate<FluentT> WebAppBase.Update.IWithClientAffinityEnabled<FluentT>.WithClientAffinityEnabled(bool enabled)
        {
            return this.WithClientAffinityEnabled(enabled) as WebAppBase.Update.IUpdate<FluentT>;
        }

        /// <summary>
        /// Specifies if client affinity is enabled.
        /// </summary>
        /// <param name="enabled">True if client affinity is enabled.</param>
        WebAppBase.Definition.IWithCreate<FluentT> WebAppBase.Definition.IWithClientAffinityEnabled<FluentT>.WithClientAffinityEnabled(bool enabled)
        {
            return this.WithClientAffinityEnabled(enabled) as WebAppBase.Definition.IWithCreate<FluentT>;
        }

        /// <summary>
        /// Specifies if client cert is enabled.
        /// </summary>
        /// <param name="enabled">True if client cert is enabled.</param>
        WebAppBase.Update.IUpdate<FluentT> WebAppBase.Update.IWithClientCertEnabled<FluentT>.WithClientCertEnabled(bool enabled)
        {
            return this.WithClientCertEnabled(enabled) as WebAppBase.Update.IUpdate<FluentT>;
        }

        /// <summary>
        /// Specifies if client cert is enabled.
        /// </summary>
        /// <param name="enabled">True if client cert is enabled.</param>
        WebAppBase.Definition.IWithCreate<FluentT> WebAppBase.Definition.IWithClientCertEnabled<FluentT>.WithClientCertEnabled(bool enabled)
        {
            return this.WithClientCertEnabled(enabled) as WebAppBase.Definition.IWithCreate<FluentT>;
        }

        /// <summary>
        /// Refreshes the resource to sync with Azure.
        /// </summary>
        T Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions.IRefreshable<T>.Refresh()
        {
            return this.Refresh() as T;
        }

        /// <summary>
        /// Specifies the Java web container.
        /// </summary>
        /// <param name="webContainer">The Java web container.</param>
        WebAppBase.Update.IUpdate<FluentT> WebAppBase.Update.IWithWebContainer<FluentT>.WithWebContainer(WebContainer webContainer)
        {
            return this.WithWebContainer(webContainer) as WebAppBase.Update.IUpdate<FluentT>;
        }

        /// <summary>
        /// Specifies the Java web container.
        /// </summary>
        /// <param name="webContainer">The Java web container.</param>
        WebAppBase.Definition.IWithCreate<FluentT> WebAppBase.Definition.IWithWebContainer<FluentT>.WithWebContainer(WebContainer webContainer)
        {
            return this.WithWebContainer(webContainer) as WebAppBase.Definition.IWithCreate<FluentT>;
        }
    }
}