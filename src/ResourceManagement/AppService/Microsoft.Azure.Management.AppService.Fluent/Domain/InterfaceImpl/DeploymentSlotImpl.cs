// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.AppService.Fluent.DeploymentSlot.Definition;
    using Microsoft.Azure.Management.AppService.Fluent.DeploymentSlot.Update;
    using Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition;
    using Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update;
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using System.Collections.Generic;

    internal partial class DeploymentSlotImpl 
    {
        /// <summary>
        /// Removes source control for deployment from the web app.
        /// </summary>
        /// <return>The next stage of the web app update.</return>
        WebAppBase.Update.IUpdate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot> WebAppBase.Update.IWithSourceControl<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>.WithoutSourceControl()
        {
            return this.WithoutSourceControl() as WebAppBase.Update.IUpdate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>;
        }

        /// <summary>
        /// Specifies the source control to be a local Git repository on the web app.
        /// </summary>
        /// <return>The next stage of the web app update.</return>
        WebAppBase.Update.IUpdate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot> WebAppBase.Update.IWithSourceControl<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>.WithLocalGitSourceControl()
        {
            return this.WithLocalGitSourceControl() as WebAppBase.Update.IUpdate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>;
        }

        /// <summary>
        /// Starts the definition of a new source control.
        /// </summary>
        /// <return>The first stage of a source control definition.</return>
        WebAppSourceControl.UpdateDefinition.IBlank<WebAppBase.Update.IUpdate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>> WebAppBase.Update.IWithSourceControl<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>.DefineSourceControl()
        {
            return this.DefineSourceControl() as WebAppSourceControl.UpdateDefinition.IBlank<WebAppBase.Update.IUpdate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>>;
        }

        /// <summary>
        /// Specifies the source control to be a local Git repository on the web app.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        WebAppBase.Definition.IWithCreate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot> WebAppBase.Definition.IWithSourceControl<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>.WithLocalGitSourceControl()
        {
            return this.WithLocalGitSourceControl() as WebAppBase.Definition.IWithCreate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>;
        }

        /// <summary>
        /// Starts the definition of a new source control.
        /// </summary>
        /// <return>The first stage of a source control definition.</return>
        WebAppSourceControl.Definition.IBlank<WebAppBase.Definition.IWithCreate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>> WebAppBase.Definition.IWithSourceControl<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>.DefineSourceControl()
        {
            return this.DefineSourceControl() as WebAppSourceControl.Definition.IBlank<WebAppBase.Definition.IWithCreate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>>;
        }

        /// <summary>
        /// Gets the name of the resource.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasName.Name
        {
            get
            {
                return this.Name();
            }
        }

        /// <summary>
        /// Specifies if SCM site is also stopped when the web app is stopped.
        /// </summary>
        /// <param name="scmSiteAlsoStopped">True if SCM site is also stopped.</param>
        /// <return>The next stage of web app update.</return>
        WebAppBase.Update.IUpdate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot> WebAppBase.Update.IWithScmSiteAlsoStopped<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>.WithScmSiteAlsoStopped(bool scmSiteAlsoStopped)
        {
            return this.WithScmSiteAlsoStopped(scmSiteAlsoStopped) as WebAppBase.Update.IUpdate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>;
        }

        /// <summary>
        /// Specifies if SCM site is also stopped when the web app is stopped.
        /// </summary>
        /// <param name="scmSiteAlsoStopped">True if SCM site is also stopped.</param>
        /// <return>The next stage of the definition.</return>
        WebAppBase.Definition.IWithCreate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot> WebAppBase.Definition.IWithScmSiteAlsoStopped<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>.WithScmSiteAlsoStopped(bool scmSiteAlsoStopped)
        {
            return this.WithScmSiteAlsoStopped(scmSiteAlsoStopped) as WebAppBase.Definition.IWithCreate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>;
        }

        /// <summary>
        /// Gets the parent of this child object.
        /// </summary>
        Microsoft.Azure.Management.AppService.Fluent.IWebApp Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasParent<Microsoft.Azure.Management.AppService.Fluent.IWebApp>.Parent
        {
            get
            {
                return this.Parent() as Microsoft.Azure.Management.AppService.Fluent.IWebApp;
            }
        }

        /// <summary>
        /// Changes the stickiness of an app setting.
        /// </summary>
        /// <param name="key">The key of the app setting to change stickiness.</param>
        /// <param name="sticky">True if the app setting sticks to the slot during a swap.</param>
        /// <return>The next stage of the web app update.</return>
        WebAppBase.Update.IUpdate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot> WebAppBase.Update.IWithAppSettings<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>.WithAppSettingStickiness(string key, bool sticky)
        {
            return this.WithAppSettingStickiness(key, sticky) as WebAppBase.Update.IUpdate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>;
        }

        /// <summary>
        /// Specifies the app settings for the web app as a  Map. These app settings
        /// will stay at the slot during a swap.
        /// </summary>
        /// <param name="settings">A  Map of app settings.</param>
        /// <return>The next stage of the web app update.</return>
        WebAppBase.Update.IUpdate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot> WebAppBase.Update.IWithAppSettings<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>.WithStickyAppSettings(IDictionary<string,string> settings)
        {
            return this.WithStickyAppSettings(settings) as WebAppBase.Update.IUpdate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>;
        }

        /// <summary>
        /// Specifies the app settings for the web app as a  Map.
        /// </summary>
        /// <param name="settings">A  Map of app settings.</param>
        /// <return>The next stage of the web app update.</return>
        WebAppBase.Update.IUpdate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot> WebAppBase.Update.IWithAppSettings<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>.WithAppSettings(IDictionary<string,string> settings)
        {
            return this.WithAppSettings(settings) as WebAppBase.Update.IUpdate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>;
        }

        /// <summary>
        /// Removes an app setting from the web app.
        /// </summary>
        /// <param name="key">The key of the app setting to remove.</param>
        /// <return>The next stage of the web app update.</return>
        WebAppBase.Update.IUpdate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot> WebAppBase.Update.IWithAppSettings<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>.WithoutAppSetting(string key)
        {
            return this.WithoutAppSetting(key) as WebAppBase.Update.IUpdate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>;
        }

        /// <summary>
        /// Adds an app setting to the web app. This app setting
        /// will stay at the slot during a swap.
        /// </summary>
        /// <param name="key">The key for the app setting.</param>
        /// <param name="value">The value for the app setting.</param>
        /// <return>The next stage of the web app update.</return>
        WebAppBase.Update.IUpdate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot> WebAppBase.Update.IWithAppSettings<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>.WithStickyAppSetting(string key, string value)
        {
            return this.WithStickyAppSetting(key, value) as WebAppBase.Update.IUpdate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>;
        }

        /// <summary>
        /// Adds an app setting to the web app.
        /// </summary>
        /// <param name="key">The key for the app setting.</param>
        /// <param name="value">The value for the app setting.</param>
        /// <return>The next stage of the web app update.</return>
        WebAppBase.Update.IUpdate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot> WebAppBase.Update.IWithAppSettings<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>.WithAppSetting(string key, string value)
        {
            return this.WithAppSetting(key, value) as WebAppBase.Update.IUpdate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>;
        }

        /// <summary>
        /// Specifies the app settings for the web app as a  Map. These app settings will be swapped
        /// as well after a deployment slot swap.
        /// </summary>
        /// <param name="settings">A  Map of app settings.</param>
        /// <return>The next stage of the definition.</return>
        WebAppBase.Definition.IWithCreate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot> WebAppBase.Definition.IWithAppSettings<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>.WithStickyAppSettings(IDictionary<string,string> settings)
        {
            return this.WithStickyAppSettings(settings) as WebAppBase.Definition.IWithCreate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>;
        }

        /// <summary>
        /// Specifies the app settings for the web app as a  Map.
        /// </summary>
        /// <param name="settings">A  Map of app settings.</param>
        /// <return>The next stage of the definition.</return>
        WebAppBase.Definition.IWithCreate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot> WebAppBase.Definition.IWithAppSettings<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>.WithAppSettings(IDictionary<string,string> settings)
        {
            return this.WithAppSettings(settings) as WebAppBase.Definition.IWithCreate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>;
        }

        /// <summary>
        /// Adds an app setting to the web app. This app setting will be swapped
        /// as well after a deployment slot swap.
        /// </summary>
        /// <param name="key">The key for the app setting.</param>
        /// <param name="value">The value for the app setting.</param>
        /// <return>The next stage of the definition.</return>
        WebAppBase.Definition.IWithCreate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot> WebAppBase.Definition.IWithAppSettings<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>.WithStickyAppSetting(string key, string value)
        {
            return this.WithStickyAppSetting(key, value) as WebAppBase.Definition.IWithCreate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>;
        }

        /// <summary>
        /// Adds an app setting to the web app.
        /// </summary>
        /// <param name="key">The key for the app setting.</param>
        /// <param name="value">The value for the app setting.</param>
        /// <return>The next stage of the definition.</return>
        WebAppBase.Definition.IWithCreate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot> WebAppBase.Definition.IWithAppSettings<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>.WithAppSetting(string key, string value)
        {
            return this.WithAppSetting(key, value) as WebAppBase.Definition.IWithCreate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>;
        }

        /// <summary>
        /// Removes an SSL binding for a specific hostname.
        /// </summary>
        /// <param name="hostname">The hostname to remove SSL certificate from.</param>
        /// <return>The next stage of web app update.</return>
        WebAppBase.Update.IUpdate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot> WebAppBase.Update.IWithHostNameSslBinding<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>.WithoutSslBinding(string hostname)
        {
            return this.WithoutSslBinding(hostname) as WebAppBase.Update.IUpdate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>;
        }

        /// <summary>
        /// Starts a definition of an SSL binding.
        /// </summary>
        /// <return>The first stage of an SSL binding definition.</return>
        HostNameSslBinding.UpdateDefinition.IBlank<WebAppBase.Update.IUpdate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>> WebAppBase.Update.IWithHostNameSslBinding<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>.DefineSslBinding()
        {
            return this.DefineSslBinding() as HostNameSslBinding.UpdateDefinition.IBlank<WebAppBase.Update.IUpdate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>>;
        }

        /// <summary>
        /// Starts a definition of an SSL binding.
        /// </summary>
        /// <return>The first stage of an SSL binding definition.</return>
        HostNameSslBinding.Definition.IBlank<WebAppBase.Definition.IWithCreate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>> WebAppBase.Definition.IWithHostNameSslBinding<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>.DefineSslBinding()
        {
            return this.DefineSslBinding() as HostNameSslBinding.Definition.IBlank<WebAppBase.Definition.IWithCreate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>>;
        }

        /// <summary>
        /// Turns off the authentication on the web app.
        /// </summary>
        /// <return>The next stage of the web app update.</return>
        WebAppBase.Update.IUpdate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot> WebAppBase.Update.IWithAuthentication<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>.WithoutAuthentication()
        {
            return this.WithoutAuthentication() as WebAppBase.Update.IUpdate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>;
        }

        /// <summary>
        /// Gets Specifies the definition of a new authentication configuration.
        /// </summary>
        /// <summary>
        /// Gets the first stage of an authentication definition.
        /// </summary>
        WebAppAuthentication.UpdateDefinition.IBlank<WebAppBase.Update.IUpdate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>> WebAppBase.Update.IWithAuthentication<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>.DefineAuthentication
        {
            get
            {
                return this.DefineAuthentication() as WebAppAuthentication.UpdateDefinition.IBlank<WebAppBase.Update.IUpdate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>>;
            }
        }

        /// <summary>
        /// Gets Updates the authentication configuration of the web app.
        /// </summary>
        /// <summary>
        /// Gets the first stage of an authentication update.
        /// </summary>
        WebAppAuthentication.Update.IUpdate<WebAppBase.Update.IUpdate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>> WebAppBase.Update.IWithAuthentication<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>.UpdateAuthentication
        {
            get
            {
                return this.UpdateAuthentication() as WebAppAuthentication.Update.IUpdate<WebAppBase.Update.IUpdate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>>;
            }
        }

        /// <summary>
        /// Gets Specifies the definition of a new authentication configuration.
        /// </summary>
        /// <summary>
        /// Gets the first stage of an authentication definition.
        /// </summary>
        WebAppAuthentication.Definition.IBlank<WebAppBase.Definition.IWithCreate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>> WebAppBase.Definition.IWithAuthentication<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>.DefineAuthentication
        {
            get
            {
                return this.DefineAuthentication() as WebAppAuthentication.Definition.IBlank<WebAppBase.Definition.IWithCreate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>>;
            }
        }

        /// <summary>
        /// Removes a connection string from the web app.
        /// </summary>
        /// <param name="name">The name of the connection string.</param>
        /// <return>The next stage of the web app update.</return>
        WebAppBase.Update.IUpdate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot> WebAppBase.Update.IWithConnectionString<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>.WithoutConnectionString(string name)
        {
            return this.WithoutConnectionString(name) as WebAppBase.Update.IUpdate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>;
        }

        /// <summary>
        /// Changes the stickiness of a connection string.
        /// </summary>
        /// <param name="name">The name of the connection string.</param>
        /// <param name="sticky">True if the connection string sticks to the slot during a swap.</param>
        /// <return>The next stage of the web app update.</return>
        WebAppBase.Update.IUpdate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot> WebAppBase.Update.IWithConnectionString<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>.WithConnectionStringStickiness(string name, bool sticky)
        {
            return this.WithConnectionStringStickiness(name, sticky) as WebAppBase.Update.IUpdate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>;
        }

        /// <summary>
        /// Adds a connection string to the web app.
        /// </summary>
        /// <param name="name">The name of the connection string.</param>
        /// <param name="value">The connection string value.</param>
        /// <param name="type">The connection string type.</param>
        /// <return>The next stage of the web app update.</return>
        WebAppBase.Update.IUpdate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot> WebAppBase.Update.IWithConnectionString<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>.WithConnectionString(string name, string value, ConnectionStringType type)
        {
            return this.WithConnectionString(name, value, type) as WebAppBase.Update.IUpdate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>;
        }

        /// <summary>
        /// Adds a connection string to the web app. This connection string
        /// will stay at the slot during a swap.
        /// </summary>
        /// <param name="name">The name of the connection string.</param>
        /// <param name="value">The connection string value.</param>
        /// <param name="type">The connection string type.</param>
        /// <return>The next stage of the web app update.</return>
        WebAppBase.Update.IUpdate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot> WebAppBase.Update.IWithConnectionString<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>.WithStickyConnectionString(string name, string value, ConnectionStringType type)
        {
            return this.WithStickyConnectionString(name, value, type) as WebAppBase.Update.IUpdate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>;
        }

        /// <summary>
        /// Adds a connection string to the web app.
        /// </summary>
        /// <param name="name">The name of the connection string.</param>
        /// <param name="value">The connection string value.</param>
        /// <param name="type">The connection string type.</param>
        /// <return>The next stage of the definition.</return>
        WebAppBase.Definition.IWithCreate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot> WebAppBase.Definition.IWithConnectionString<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>.WithConnectionString(string name, string value, ConnectionStringType type)
        {
            return this.WithConnectionString(name, value, type) as WebAppBase.Definition.IWithCreate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>;
        }

        /// <summary>
        /// Adds a connection string to the web app. This connection string will be swapped
        /// as well after a deployment slot swap.
        /// </summary>
        /// <param name="name">The name of the connection string.</param>
        /// <param name="value">The connection string value.</param>
        /// <param name="type">The connection string type.</param>
        /// <return>The next stage of the definition.</return>
        WebAppBase.Definition.IWithCreate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot> WebAppBase.Definition.IWithConnectionString<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>.WithStickyConnectionString(string name, string value, ConnectionStringType type)
        {
            return this.WithStickyConnectionString(name, value, type) as WebAppBase.Definition.IWithCreate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>;
        }

        /// <summary>
        /// Defines a list of host names of an Azure managed domain. The DNS record type is
        /// defaulted to be CNAME except for the root level domain (".
        /// </summary>
        /// <param name="domain">The Azure managed domain.</param>
        /// <param name="hostnames">The list of sub-domains.</param>
        /// <return>The next stage of web app update.</return>
        WebAppBase.Update.IUpdate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot> WebAppBase.Update.IWithHostNameBinding<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>.WithManagedHostnameBindings(IAppServiceDomain domain, params string[] hostnames)
        {
            return this.WithManagedHostnameBindings(domain, hostnames) as WebAppBase.Update.IUpdate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>;
        }

        /// <summary>
        /// Starts the definition of a new host name binding.
        /// </summary>
        /// <return>The first stage of a hostname binding update.</return>
        HostNameBinding.UpdateDefinition.IBlank<WebAppBase.Update.IUpdate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>> WebAppBase.Update.IWithHostNameBinding<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>.DefineHostnameBinding()
        {
            return this.DefineHostnameBinding() as HostNameBinding.UpdateDefinition.IBlank<WebAppBase.Update.IUpdate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>>;
        }

        /// <summary>
        /// Unbinds a hostname from the web app.
        /// </summary>
        /// <param name="hostname">The hostname to unbind.</param>
        /// <return>The next stage of web app update.</return>
        WebAppBase.Update.IUpdate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot> WebAppBase.Update.IWithHostNameBinding<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>.WithoutHostnameBinding(string hostname)
        {
            return this.WithoutHostnameBinding(hostname) as WebAppBase.Update.IUpdate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>;
        }

        /// <summary>
        /// Defines a list of host names of an externally purchased domain. The hostnames
        /// must be configured before hand to point to the web app.
        /// </summary>
        /// <param name="domain">The external domain name.</param>
        /// <param name="hostnames">The list of sub-domains.</param>
        /// <return>The next stage of web app update.</return>
        WebAppBase.Update.IUpdate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot> WebAppBase.Update.IWithHostNameBinding<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>.WithThirdPartyHostnameBinding(string domain, params string[] hostnames)
        {
            return this.WithThirdPartyHostnameBinding(domain, hostnames) as WebAppBase.Update.IUpdate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>;
        }

        /// <summary>
        /// Defines a list of host names of an Azure managed domain. The DNS record type is
        /// defaulted to be CNAME except for the root level domain (".
        /// </summary>
        /// <param name="domain">The Azure managed domain.</param>
        /// <param name="hostnames">The list of sub-domains.</param>
        /// <return>The next stage of the definition.</return>
        WebAppBase.Definition.IWithCreate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot> WebAppBase.Definition.IWithHostNameBinding<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>.WithManagedHostnameBindings(IAppServiceDomain domain, params string[] hostnames)
        {
            return this.WithManagedHostnameBindings(domain, hostnames) as WebAppBase.Definition.IWithCreate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>;
        }

        /// <summary>
        /// Starts the definition of a new host name binding.
        /// </summary>
        /// <return>The first stage of a hostname binding definition.</return>
        HostNameBinding.Definition.IBlank<WebAppBase.Definition.IWithCreate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>> WebAppBase.Definition.IWithHostNameBinding<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>.DefineHostnameBinding()
        {
            return this.DefineHostnameBinding() as HostNameBinding.Definition.IBlank<WebAppBase.Definition.IWithCreate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>>;
        }

        /// <summary>
        /// Defines a list of host names of an externally purchased domain. The hostnames
        /// must be configured before hand to point to the web app.
        /// </summary>
        /// <param name="domain">The external domain name.</param>
        /// <param name="hostnames">The list of sub-domains.</param>
        /// <return>The next stage of the definition.</return>
        WebAppBase.Definition.IWithCreate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot> WebAppBase.Definition.IWithHostNameBinding<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>.WithThirdPartyHostnameBinding(string domain, params string[] hostnames)
        {
            return this.WithThirdPartyHostnameBinding(domain, hostnames) as WebAppBase.Definition.IWithCreate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>;
        }

        /// <summary>
        /// Specifies the platform architecture to use.
        /// </summary>
        /// <param name="platform">The platform architecture.</param>
        /// <return>The next stage of web app update.</return>
        WebAppBase.Update.IUpdate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot> WebAppBase.Update.IWithSiteConfigs<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>.WithPlatformArchitecture(PlatformArchitecture platform)
        {
            return this.WithPlatformArchitecture(platform) as WebAppBase.Update.IUpdate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>;
        }

        /// <summary>
        /// Adds a list of default documents.
        /// </summary>
        /// <param name="documents">List of default documents.</param>
        /// <return>The next stage of web app update.</return>
        WebAppBase.Update.IUpdate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot> WebAppBase.Update.IWithSiteConfigs<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>.WithDefaultDocuments(IList<string> documents)
        {
            return this.WithDefaultDocuments(documents) as WebAppBase.Update.IUpdate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>;
        }

        /// <summary>
        /// Disables remote debugging.
        /// </summary>
        /// <return>The next stage of web app update.</return>
        WebAppBase.Update.IUpdate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot> WebAppBase.Update.IWithSiteConfigs<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>.WithRemoteDebuggingDisabled()
        {
            return this.WithRemoteDebuggingDisabled() as WebAppBase.Update.IUpdate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>;
        }

        /// <summary>
        /// Specifies the .NET Framework version.
        /// </summary>
        /// <param name="version">The .NET Framework version.</param>
        /// <return>The next stage of web app update.</return>
        WebAppBase.Update.IUpdate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot> WebAppBase.Update.IWithSiteConfigs<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>.WithNetFrameworkVersion(NetFrameworkVersion version)
        {
            return this.WithNetFrameworkVersion(version) as WebAppBase.Update.IUpdate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>;
        }

        /// <summary>
        /// Specifies if the VM powering the web app is always powered on.
        /// </summary>
        /// <param name="alwaysOn">True if the web app is always powered on.</param>
        /// <return>The next stage of web app update.</return>
        WebAppBase.Update.IUpdate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot> WebAppBase.Update.IWithSiteConfigs<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>.WithWebAppAlwaysOn(bool alwaysOn)
        {
            return this.WithWebAppAlwaysOn(alwaysOn) as WebAppBase.Update.IUpdate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>;
        }

        /// <summary>
        /// Turn off Python support.
        /// </summary>
        /// <return>The next stage of web app update.</return>
        WebAppBase.Update.IUpdate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot> WebAppBase.Update.IWithSiteConfigs<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>.WithoutPython()
        {
            return this.WithoutPython() as WebAppBase.Update.IUpdate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>;
        }

        /// <summary>
        /// Specifies if web sockets are enabled.
        /// </summary>
        /// <param name="enabled">True if web sockets are enabled.</param>
        /// <return>The next stage of web app update.</return>
        WebAppBase.Update.IUpdate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot> WebAppBase.Update.IWithSiteConfigs<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>.WithWebSocketsEnabled(bool enabled)
        {
            return this.WithWebSocketsEnabled(enabled) as WebAppBase.Update.IUpdate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>;
        }

        /// <summary>
        /// Turn off Java support.
        /// </summary>
        /// <return>The next stage of web app update.</return>
        WebAppBase.Update.IUpdate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot> WebAppBase.Update.IWithSiteConfigs<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>.WithoutJava()
        {
            return this.WithoutJava() as WebAppBase.Update.IUpdate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>;
        }

        /// <summary>
        /// Specifies the slot name to auto-swap when a deployment is completed in this web app / deployment slot.
        /// </summary>
        /// <param name="slotName">The name of the slot, or 'production', to auto-swap.</param>
        /// <return>The next stage of web app update.</return>
        WebAppBase.Update.IUpdate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot> WebAppBase.Update.IWithSiteConfigs<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>.WithAutoSwapSlotName(string slotName)
        {
            return this.WithAutoSwapSlotName(slotName) as WebAppBase.Update.IUpdate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>;
        }

        /// <summary>
        /// Specifies the managed pipeline mode.
        /// </summary>
        /// <param name="managedPipelineMode">Managed pipeline mode.</param>
        /// <return>The next stage of web app update.</return>
        WebAppBase.Update.IUpdate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot> WebAppBase.Update.IWithSiteConfigs<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>.WithManagedPipelineMode(ManagedPipelineMode managedPipelineMode)
        {
            return this.WithManagedPipelineMode(managedPipelineMode) as WebAppBase.Update.IUpdate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>;
        }

        /// <summary>
        /// Specifies the Visual Studio version for remote debugging.
        /// </summary>
        /// <param name="remoteVisualStudioVersion">The Visual Studio version for remote debugging.</param>
        /// <return>The next stage of web app update.</return>
        WebAppBase.Update.IUpdate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot> WebAppBase.Update.IWithSiteConfigs<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>.WithRemoteDebuggingEnabled(RemoteVisualStudioVersion remoteVisualStudioVersion)
        {
            return this.WithRemoteDebuggingEnabled(remoteVisualStudioVersion) as WebAppBase.Update.IUpdate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>;
        }

        /// <summary>
        /// Removes a default document.
        /// </summary>
        /// <param name="document">Default document to remove.</param>
        /// <return>The next stage of web app update.</return>
        WebAppBase.Update.IUpdate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot> WebAppBase.Update.IWithSiteConfigs<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>.WithoutDefaultDocument(string document)
        {
            return this.WithoutDefaultDocument(document) as WebAppBase.Update.IUpdate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>;
        }

        /// <summary>
        /// Specifies the Python version.
        /// </summary>
        /// <param name="version">The Python version.</param>
        /// <return>The next stage of web app update.</return>
        WebAppBase.Update.IUpdate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot> WebAppBase.Update.IWithSiteConfigs<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>.WithPythonVersion(PythonVersion version)
        {
            return this.WithPythonVersion(version) as WebAppBase.Update.IUpdate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>;
        }

        /// <summary>
        /// Specifies the PHP version.
        /// </summary>
        /// <param name="version">The PHP version.</param>
        /// <return>The next stage of web app update.</return>
        WebAppBase.Update.IUpdate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot> WebAppBase.Update.IWithSiteConfigs<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>.WithPhpVersion(PhpVersion version)
        {
            return this.WithPhpVersion(version) as WebAppBase.Update.IUpdate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>;
        }

        /// <summary>
        /// Specifies the Java version.
        /// </summary>
        /// <param name="version">The Java version.</param>
        /// <return>The next stage of web app update.</return>
        WebAppBase.Update.IWithWebContainer<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot> WebAppBase.Update.IWithSiteConfigs<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>.WithJavaVersion(JavaVersion version)
        {
            return this.WithJavaVersion(version) as WebAppBase.Update.IWithWebContainer<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>;
        }

        /// <summary>
        /// Adds a default document.
        /// </summary>
        /// <param name="document">Default document.</param>
        /// <return>The next stage of web app update.</return>
        WebAppBase.Update.IUpdate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot> WebAppBase.Update.IWithSiteConfigs<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>.WithDefaultDocument(string document)
        {
            return this.WithDefaultDocument(document) as WebAppBase.Update.IUpdate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>;
        }

        /// <summary>
        /// Specifies the platform architecture to use.
        /// </summary>
        /// <param name="platform">The platform architecture.</param>
        /// <return>The next stage of the definition.</return>
        WebAppBase.Definition.IWithCreate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot> WebAppBase.Definition.IWithSiteConfigs<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>.WithPlatformArchitecture(PlatformArchitecture platform)
        {
            return this.WithPlatformArchitecture(platform) as WebAppBase.Definition.IWithCreate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>;
        }

        /// <summary>
        /// Adds a list of default documents.
        /// </summary>
        /// <param name="documents">List of default documents.</param>
        /// <return>The next stage of the definition.</return>
        WebAppBase.Definition.IWithCreate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot> WebAppBase.Definition.IWithSiteConfigs<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>.WithDefaultDocuments(IList<string> documents)
        {
            return this.WithDefaultDocuments(documents) as WebAppBase.Definition.IWithCreate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>;
        }

        /// <summary>
        /// Disables remote debugging.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        WebAppBase.Definition.IWithCreate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot> WebAppBase.Definition.IWithSiteConfigs<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>.WithRemoteDebuggingDisabled()
        {
            return this.WithRemoteDebuggingDisabled() as WebAppBase.Definition.IWithCreate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>;
        }

        /// <summary>
        /// Specifies the .NET Framework version.
        /// </summary>
        /// <param name="version">The .NET Framework version.</param>
        /// <return>The next stage of the definition.</return>
        WebAppBase.Definition.IWithCreate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot> WebAppBase.Definition.IWithSiteConfigs<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>.WithNetFrameworkVersion(NetFrameworkVersion version)
        {
            return this.WithNetFrameworkVersion(version) as WebAppBase.Definition.IWithCreate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>;
        }

        /// <summary>
        /// Specifies if the VM powering the web app is always powered on.
        /// </summary>
        /// <param name="alwaysOn">True if the web app is always powered on.</param>
        /// <return>The next stage of the definition.</return>
        WebAppBase.Definition.IWithCreate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot> WebAppBase.Definition.IWithSiteConfigs<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>.WithWebAppAlwaysOn(bool alwaysOn)
        {
            return this.WithWebAppAlwaysOn(alwaysOn) as WebAppBase.Definition.IWithCreate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>;
        }

        /// <summary>
        /// Specifies if web sockets are enabled.
        /// </summary>
        /// <param name="enabled">True if web sockets are enabled.</param>
        /// <return>The next stage of the definition.</return>
        WebAppBase.Definition.IWithCreate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot> WebAppBase.Definition.IWithSiteConfigs<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>.WithWebSocketsEnabled(bool enabled)
        {
            return this.WithWebSocketsEnabled(enabled) as WebAppBase.Definition.IWithCreate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>;
        }

        /// <summary>
        /// Specifies the slot name to auto-swap when a deployment is completed in this web app / deployment slot.
        /// </summary>
        /// <param name="slotName">The name of the slot, or 'production', to auto-swap.</param>
        /// <return>The next stage of the definition.</return>
        WebAppBase.Definition.IWithCreate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot> WebAppBase.Definition.IWithSiteConfigs<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>.WithAutoSwapSlotName(string slotName)
        {
            return this.WithAutoSwapSlotName(slotName) as WebAppBase.Definition.IWithCreate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>;
        }

        /// <summary>
        /// Specifies the managed pipeline mode.
        /// </summary>
        /// <param name="managedPipelineMode">Managed pipeline mode.</param>
        /// <return>The next stage of the definition.</return>
        WebAppBase.Definition.IWithCreate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot> WebAppBase.Definition.IWithSiteConfigs<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>.WithManagedPipelineMode(ManagedPipelineMode managedPipelineMode)
        {
            return this.WithManagedPipelineMode(managedPipelineMode) as WebAppBase.Definition.IWithCreate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>;
        }

        /// <summary>
        /// Specifies the Visual Studio version for remote debugging.
        /// </summary>
        /// <param name="remoteVisualStudioVersion">The Visual Studio version for remote debugging.</param>
        /// <return>The next stage of the definition.</return>
        WebAppBase.Definition.IWithCreate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot> WebAppBase.Definition.IWithSiteConfigs<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>.WithRemoteDebuggingEnabled(RemoteVisualStudioVersion remoteVisualStudioVersion)
        {
            return this.WithRemoteDebuggingEnabled(remoteVisualStudioVersion) as WebAppBase.Definition.IWithCreate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>;
        }

        /// <summary>
        /// Removes a default document.
        /// </summary>
        /// <param name="document">Default document to remove.</param>
        /// <return>The next stage of the definition.</return>
        WebAppBase.Definition.IWithCreate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot> WebAppBase.Definition.IWithSiteConfigs<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>.WithoutDefaultDocument(string document)
        {
            return this.WithoutDefaultDocument(document) as WebAppBase.Definition.IWithCreate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>;
        }

        /// <summary>
        /// Specifies the Python version.
        /// </summary>
        /// <param name="version">The Python version.</param>
        /// <return>The next stage of the definition.</return>
        WebAppBase.Definition.IWithCreate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot> WebAppBase.Definition.IWithSiteConfigs<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>.WithPythonVersion(PythonVersion version)
        {
            return this.WithPythonVersion(version) as WebAppBase.Definition.IWithCreate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>;
        }

        /// <summary>
        /// Turn off PHP support.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        WebAppBase.Definition.IWithCreate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot> WebAppBase.Definition.IWithSiteConfigs<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>.WithoutPhp()
        {
            return this.WithoutPhp() as WebAppBase.Definition.IWithCreate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>;
        }

        /// <summary>
        /// Specifies the PHP version.
        /// </summary>
        /// <param name="version">The PHP version.</param>
        /// <return>The next stage of the definition.</return>
        WebAppBase.Definition.IWithCreate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot> WebAppBase.Definition.IWithSiteConfigs<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>.WithPhpVersion(PhpVersion version)
        {
            return this.WithPhpVersion(version) as WebAppBase.Definition.IWithCreate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>;
        }

        /// <summary>
        /// Specifies the Java version.
        /// </summary>
        /// <param name="version">The Java version.</param>
        /// <return>The next stage of the definition.</return>
        WebAppBase.Definition.IWithWebContainer<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot> WebAppBase.Definition.IWithSiteConfigs<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>.WithJavaVersion(JavaVersion version)
        {
            return this.WithJavaVersion(version) as WebAppBase.Definition.IWithWebContainer<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>;
        }

        /// <summary>
        /// Adds a default document.
        /// </summary>
        /// <param name="document">Default document.</param>
        /// <return>The next stage of the definition.</return>
        WebAppBase.Definition.IWithCreate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot> WebAppBase.Definition.IWithSiteConfigs<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>.WithDefaultDocument(string document)
        {
            return this.WithDefaultDocument(document) as WebAppBase.Definition.IWithCreate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>;
        }

        /// <summary>
        /// Specifies if client affinity is enabled.
        /// </summary>
        /// <param name="enabled">True if client affinity is enabled.</param>
        /// <return>The next stage of web app update.</return>
        WebAppBase.Update.IUpdate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot> WebAppBase.Update.IWithClientAffinityEnabled<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>.WithClientAffinityEnabled(bool enabled)
        {
            return this.WithClientAffinityEnabled(enabled) as WebAppBase.Update.IUpdate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>;
        }

        /// <summary>
        /// Specifies if client affinity is enabled.
        /// </summary>
        /// <param name="enabled">True if client affinity is enabled.</param>
        /// <return>The next stage of the definition.</return>
        WebAppBase.Definition.IWithCreate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot> WebAppBase.Definition.IWithClientAffinityEnabled<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>.WithClientAffinityEnabled(bool enabled)
        {
            return this.WithClientAffinityEnabled(enabled) as WebAppBase.Definition.IWithCreate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>;
        }

        /// <summary>
        /// Specifies if client cert is enabled.
        /// </summary>
        /// <param name="enabled">True if client cert is enabled.</param>
        /// <return>The next stage of web app update.</return>
        WebAppBase.Update.IUpdate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot> WebAppBase.Update.IWithClientCertEnabled<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>.WithClientCertEnabled(bool enabled)
        {
            return this.WithClientCertEnabled(enabled) as WebAppBase.Update.IUpdate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>;
        }

        /// <summary>
        /// Specifies if client cert is enabled.
        /// </summary>
        /// <param name="enabled">True if client cert is enabled.</param>
        /// <return>The next stage of the definition.</return>
        WebAppBase.Definition.IWithCreate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot> WebAppBase.Definition.IWithClientCertEnabled<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>.WithClientCertEnabled(bool enabled)
        {
            return this.WithClientCertEnabled(enabled) as WebAppBase.Definition.IWithCreate<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>;
        }

        /// <summary>
        /// Refreshes the resource to sync with Azure.
        /// </summary>
        /// <return>The Observable to refreshed resource.</return>
        async Task<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot> Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IRefreshable<Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot>.RefreshAsync(CancellationToken cancellationToken)
        {
            return await this.RefreshAsync(cancellationToken) as Microsoft.Azure.Management.AppService.Fluent.IDeploymentSlot;
        }

        /// <summary>
        /// Gets site is a default container.
        /// </summary>
        bool Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.IsDefaultContainer
        {
            get
            {
                return this.IsDefaultContainer();
            }
        }

        /// <summary>
        /// Gets the app settings defined on the web app.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.AppService.Fluent.IAppSetting> Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.AppSettings
        {
            get
            {
                return this.AppSettings() as System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.AppService.Fluent.IAppSetting>;
            }
        }

        /// <summary>
        /// Gets Java container.
        /// </summary>
        string Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.JavaContainer
        {
            get
            {
                return this.JavaContainer();
            }
        }

        /// <summary>
        /// Gets if web socket is enabled.
        /// </summary>
        bool Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.WebSocketsEnabled
        {
            get
            {
                return this.WebSocketsEnabled();
            }
        }

        /// <summary>
        /// Gets management information availability state for the web app.
        /// </summary>
        Models.SiteAvailabilityState Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.AvailabilityState
        {
            get
            {
                return this.AvailabilityState();
            }
        }

        /// <summary>
        /// Gets if the web app is always on.
        /// </summary>
        bool Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.AlwaysOn
        {
            get
            {
                return this.AlwaysOn();
            }
        }

        /// <summary>
        /// Gets the architecture of the platform, either 32 bit (x86) or 64 bit (x64).
        /// </summary>
        Microsoft.Azure.Management.AppService.Fluent.PlatformArchitecture Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.PlatformArchitecture
        {
            get
            {
                return this.PlatformArchitecture();
            }
        }

        /// <return>The URL and credentials for publishing through FTP or Git.</return>
        async Task<Microsoft.Azure.Management.AppService.Fluent.IPublishingProfile> Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.GetPublishingProfileAsync(CancellationToken cancellationToken)
        {
            return await this.GetPublishingProfileAsync(cancellationToken) as Microsoft.Azure.Management.AppService.Fluent.IPublishingProfile;
        }

        /// <summary>
        /// Gets the operating system the web app is running on.
        /// </summary>
        OperatingSystem Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.OperatingSystem
        {
            get
            {
                return this.OperatingSystem();
            }
        }

        /// <return>The mapping from host names and the host name bindings.</return>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.AppService.Fluent.IHostNameBinding> Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.GetHostNameBindings()
        {
            return this.GetHostNameBindings() as System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.AppService.Fluent.IHostNameBinding>;
        }

        /// <summary>
        /// Swaps the app running in the current web app / slot with the app
        /// running in the specified slot.
        /// </summary>
        /// <param name="slotName">
        /// The target slot to swap with. Use 'production' for
        /// the production slot.
        /// </param>
        void Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.Swap(string slotName)
        {
 
            this.Swap(slotName);
        }

        /// <return>The source control information for the web app.</return>
        Microsoft.Azure.Management.AppService.Fluent.IWebAppSourceControl Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.GetSourceControl()
        {
            return this.GetSourceControl() as Microsoft.Azure.Management.AppService.Fluent.IWebAppSourceControl;
        }

        /// <summary>
        /// Apply the slot (or sticky) configurations from the specified slot
        /// to the current one. This is useful for "Swap with Preview".
        /// </summary>
        /// <param name="slotName">The target slot to apply configurations from.</param>
        void Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.ApplySlotConfigurations(string slotName)
        {
 
            this.ApplySlotConfigurations(slotName);
        }

        /// <summary>
        /// Gets size of a function container.
        /// </summary>
        int Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.ContainerSize
        {
            get
            {
                return this.ContainerSize();
            }
        }

        /// <summary>
        /// Gets the remote debugging version.
        /// </summary>
        Microsoft.Azure.Management.AppService.Fluent.RemoteVisualStudioVersion Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.RemoteDebuggingVersion
        {
            get
            {
                return this.RemoteDebuggingVersion() as Microsoft.Azure.Management.AppService.Fluent.RemoteVisualStudioVersion;
            }
        }

        /// <summary>
        /// Restarts the web app or deployment slot.
        /// </summary>
        void Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.Restart()
        {
 
            this.Restart();
        }

        /// <summary>
        /// Verifies the ownership of the domain for a certificate order by verifying a hostname
        /// of the domain is bound to this web app.
        /// </summary>
        /// <param name="certificateOrderName">The name of the certificate order.</param>
        /// <param name="domainVerificationToken">The domain verification token for the certificate order.</param>
        void Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.VerifyDomainOwnership(string certificateOrderName, string domainVerificationToken)
        {
 
            this.VerifyDomainOwnership(certificateOrderName, domainVerificationToken);
        }

        /// <summary>
        /// Reset the slot to its original configurations.
        /// </summary>
        void Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.ResetSlotConfigurations()
        {
 
            this.ResetSlotConfigurations();
        }

        /// <summary>
        /// Gets the .NET Framework version.
        /// </summary>
        Microsoft.Azure.Management.AppService.Fluent.NetFrameworkVersion Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.NetFrameworkVersion
        {
            get
            {
                return this.NetFrameworkVersion() as Microsoft.Azure.Management.AppService.Fluent.NetFrameworkVersion;
            }
        }

        /// <summary>
        /// Gets list of SSL states used to manage the SSL bindings for site's hostnames.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Models.HostNameSslState> Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.HostNameSslStates
        {
            get
            {
                return this.HostNameSslStates() as System.Collections.Generic.IReadOnlyDictionary<string,Models.HostNameSslState>;
            }
        }

        /// <summary>
        /// Gets the default documents.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<string> Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.DefaultDocuments
        {
            get
            {
                return this.DefaultDocuments() as System.Collections.Generic.IReadOnlyList<string>;
            }
        }

        /// <summary>
        /// Gets if the remote eebugging is enabled.
        /// </summary>
        bool Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.RemoteDebuggingEnabled
        {
            get
            {
                return this.RemoteDebuggingEnabled();
            }
        }

        /// <summary>
        /// Gets the connection strings defined on the web app.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.AppService.Fluent.IConnectionString> Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.ConnectionStrings
        {
            get
            {
                return this.ConnectionStrings() as System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.AppService.Fluent.IConnectionString>;
            }
        }

        /// <summary>
        /// Gets name of gateway app associated with web app.
        /// </summary>
        string Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.GatewaySiteName
        {
            get
            {
                return this.GatewaySiteName();
            }
        }

        /// <summary>
        /// Gets Java container version.
        /// </summary>
        string Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.JavaContainerVersion
        {
            get
            {
                return this.JavaContainerVersion();
            }
        }

        /// <summary>
        /// Gets list of Azure Traffic manager host names associated with web
        /// app.
        /// </summary>
        System.Collections.Generic.ISet<string> Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.TrafficManagerHostNames
        {
            get
            {
                return this.TrafficManagerHostNames() as System.Collections.Generic.ISet<string>;
            }
        }

        /// <summary>
        /// Gets true if the site is enabled; otherwise, false.
        /// </summary>
        bool Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.Enabled
        {
            get
            {
                return this.Enabled();
            }
        }

        /// <summary>
        /// Verifies the ownership of the domain for a certificate order by verifying a hostname
        /// of the domain is bound to this web app.
        /// </summary>
        /// <param name="certificateOrderName">The name of the certificate order.</param>
        /// <param name="domainVerificationToken">The domain verification token for the certificate order.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.VerifyDomainOwnershipAsync(string certificateOrderName, string domainVerificationToken, CancellationToken cancellationToken)
        {
 
            await this.VerifyDomainOwnershipAsync(certificateOrderName, domainVerificationToken, cancellationToken);
        }

        /// <summary>
        /// Starts the web app or deployment slot.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.StartAsync(CancellationToken cancellationToken)
        {
 
            await this.StartAsync(cancellationToken);
        }

        /// <summary>
        /// Gets name of repository site.
        /// </summary>
        string Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.RepositorySiteName
        {
            get
            {
                return this.RepositorySiteName();
            }
        }

        /// <summary>
        /// Gets host names for the web app that are enabled.
        /// </summary>
        System.Collections.Generic.ISet<string> Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.EnabledHostNames
        {
            get
            {
                return this.EnabledHostNames() as System.Collections.Generic.ISet<string>;
            }
        }

        /// <return>The mapping from host names and the host name bindings.</return>
        async Task<System.Collections.Generic.IDictionary<string,Microsoft.Azure.Management.AppService.Fluent.IHostNameBinding>> Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.GetHostNameBindingsAsync(CancellationToken cancellationToken)
        {
            return await this.GetHostNameBindingsAsync(cancellationToken) as System.Collections.Generic.IDictionary<string,Microsoft.Azure.Management.AppService.Fluent.IHostNameBinding>;
        }

        /// <summary>
        /// Stops the web app or deployment slot.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.StopAsync(CancellationToken cancellationToken)
        {
 
            await this.StopAsync(cancellationToken);
        }

        /// <summary>
        /// Stops the web app or deployment slot.
        /// </summary>
        void Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.Stop()
        {
 
            this.Stop();
        }

        /// <summary>
        /// Gets the micro-service name.
        /// </summary>
        string Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.MicroService
        {
            get
            {
                return this.MicroService();
            }
        }

        /// <summary>
        /// Gets managed pipeline mode.
        /// </summary>
        Models.ManagedPipelineMode Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.ManagedPipelineMode
        {
            get
            {
                return this.ManagedPipelineMode();
            }
        }

        /// <summary>
        /// Restarts the web app or deployment slot.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.RestartAsync(CancellationToken cancellationToken)
        {
 
            await this.RestartAsync(cancellationToken);
        }

        /// <summary>
        /// Reset the slot to its original configurations.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.ResetSlotConfigurationsAsync(CancellationToken cancellationToken)
        {
 
            await this.ResetSlotConfigurationsAsync(cancellationToken);
        }

        /// <summary>
        /// Gets Java version.
        /// </summary>
        Microsoft.Azure.Management.AppService.Fluent.JavaVersion Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.JavaVersion
        {
            get
            {
                return this.JavaVersion() as Microsoft.Azure.Management.AppService.Fluent.JavaVersion;
            }
        }

        /// <summary>
        /// Gets list of IP addresses that this web app uses for
        /// outbound connections. Those can be used when configuring firewall
        /// rules for databases accessed by this web app.
        /// </summary>
        System.Collections.Generic.ISet<string> Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.OutboundIPAddresses
        {
            get
            {
                return this.OutboundIPAddresses() as System.Collections.Generic.ISet<string>;
            }
        }

        /// <summary>
        /// Gets the version of Node.JS.
        /// </summary>
        string Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.NodeVersion
        {
            get
            {
                return this.NodeVersion();
            }
        }

        /// <summary>
        /// Gets if the public hostnames are disabled the web app.
        /// If set to true the app is only accessible via API
        /// Management process.
        /// </summary>
        bool Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.HostNamesDisabled
        {
            get
            {
                return this.HostNamesDisabled();
            }
        }

        /// <summary>
        /// Gets the auto swap slot name.
        /// </summary>
        string Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.AutoSwapSlotName
        {
            get
            {
                return this.AutoSwapSlotName();
            }
        }

        /// <summary>
        /// Gets state indicating whether web app has exceeded its quota usage.
        /// </summary>
        Models.UsageState Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.UsageState
        {
            get
            {
                return this.UsageState();
            }
        }

        /// <summary>
        /// Gets hostnames associated with web app.
        /// </summary>
        System.Collections.Generic.ISet<string> Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.HostNames
        {
            get
            {
                return this.HostNames() as System.Collections.Generic.ISet<string>;
            }
        }

        /// <summary>
        /// Gets Last time web app was modified in UTC.
        /// </summary>
        System.DateTime? Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.LastModifiedTime
        {
            get
            {
                return this.LastModifiedTime();
            }
        }

        /// <summary>
        /// Gets state of the web app.
        /// </summary>
        string Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.State
        {
            get
            {
                return this.State();
            }
        }

        /// <return>The URL and credentials for publishing through FTP or Git.</return>
        Microsoft.Azure.Management.AppService.Fluent.IPublishingProfile Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.GetPublishingProfile()
        {
            return this.GetPublishingProfile() as Microsoft.Azure.Management.AppService.Fluent.IPublishingProfile;
        }

        /// <summary>
        /// Gets default hostname of the web app.
        /// </summary>
        string Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.DefaultHostName
        {
            get
            {
                return this.DefaultHostName();
            }
        }

        /// <summary>
        /// Gets the version of Python.
        /// </summary>
        Microsoft.Azure.Management.AppService.Fluent.PythonVersion Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.PythonVersion
        {
            get
            {
                return this.PythonVersion() as Microsoft.Azure.Management.AppService.Fluent.PythonVersion;
            }
        }

        /// <summary>
        /// Swaps the app running in the current web app / slot with the app
        /// running in the specified slot.
        /// </summary>
        /// <param name="slotName">
        /// The target slot to swap with. Use 'production' for
        /// the production slot.
        /// </param>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.SwapAsync(string slotName, CancellationToken cancellationToken)
        {
 
            await this.SwapAsync(slotName, cancellationToken);
        }

        /// <summary>
        /// Gets the version of PHP.
        /// </summary>
        Microsoft.Azure.Management.AppService.Fluent.PhpVersion Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.PhpVersion
        {
            get
            {
                return this.PhpVersion() as Microsoft.Azure.Management.AppService.Fluent.PhpVersion;
            }
        }

        /// <summary>
        /// Gets information about whether the web app is cloned from another.
        /// </summary>
        Models.CloningInfo Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.CloningInfo
        {
            get
            {
                return this.CloningInfo() as Models.CloningInfo;
            }
        }

        /// <summary>
        /// Gets whether web app is deployed as a premium app.
        /// </summary>
        bool Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.IsPremiumApp
        {
            get
            {
                return this.IsPremiumApp();
            }
        }

        /// <summary>
        /// Starts the web app or deployment slot.
        /// </summary>
        void Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.Start()
        {
 
            this.Start();
        }

        /// <summary>
        /// Apply the slot (or sticky) configurations from the specified slot
        /// to the current one. This is useful for "Swap with Preview".
        /// </summary>
        /// <param name="slotName">The target slot to apply configurations from.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        async Task Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.ApplySlotConfigurationsAsync(string slotName, CancellationToken cancellationToken)
        {
 
            await this.ApplySlotConfigurationsAsync(slotName, cancellationToken);
        }

        /// <summary>
        /// Gets which slot this app will swap into.
        /// </summary>
        string Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.TargetSwapSlot
        {
            get
            {
                return this.TargetSwapSlot();
            }
        }

        /// <return>The source control information for the web app.</return>
        async Task<Microsoft.Azure.Management.AppService.Fluent.IWebAppSourceControl> Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.GetSourceControlAsync(CancellationToken cancellationToken)
        {
            return await this.GetSourceControlAsync(cancellationToken) as Microsoft.Azure.Management.AppService.Fluent.IWebAppSourceControl;
        }

        /// <summary>
        /// Gets whether to stop SCM (KUDU) site when the web app is
        /// stopped. Default is false.
        /// </summary>
        bool Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.ScmSiteAlsoStopped
        {
            get
            {
                return this.ScmSiteAlsoStopped();
            }
        }

        /// <summary>
        /// Gets if the client certificate is enabled for the web app.
        /// </summary>
        bool Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.ClientCertEnabled
        {
            get
            {
                return this.ClientCertEnabled();
            }
        }

        /// <summary>
        /// Gets The resource ID of the app service plan.
        /// </summary>
        string Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.AppServicePlanId
        {
            get
            {
                return this.AppServicePlanId();
            }
        }

        /// <summary>
        /// Gets if the client affinity is enabled when load balancing http
        /// request for multiple instances of the web app.
        /// </summary>
        bool Microsoft.Azure.Management.AppService.Fluent.IWebAppBase.ClientAffinityEnabled
        {
            get
            {
                return this.ClientAffinityEnabled();
            }
        }

        /// <summary>
        /// Copies the site configurations from the web app the deployment slot belongs to.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        DeploymentSlot.Definition.IWithCreate DeploymentSlot.Definition.IWithConfiguration.WithConfigurationFromParent()
        {
            return this.WithConfigurationFromParent() as DeploymentSlot.Definition.IWithCreate;
        }

        /// <summary>
        /// Creates the deployment slot with brand new site configurations.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        DeploymentSlot.Definition.IWithCreate DeploymentSlot.Definition.IWithConfiguration.WithBrandNewConfiguration()
        {
            return this.WithBrandNewConfiguration() as DeploymentSlot.Definition.IWithCreate;
        }

        /// <summary>
        /// Copies the site configurations from a given deployment slot.
        /// </summary>
        /// <param name="deploymentSlot">The deployment slot to copy the configurations from.</param>
        /// <return>The next stage of the definition.</return>
        DeploymentSlot.Definition.IWithCreate DeploymentSlot.Definition.IWithConfiguration.WithConfigurationFromDeploymentSlot(IDeploymentSlot deploymentSlot)
        {
            return this.WithConfigurationFromDeploymentSlot(deploymentSlot) as DeploymentSlot.Definition.IWithCreate;
        }

        /// <summary>
        /// Copies the site configurations from a given web app.
        /// </summary>
        /// <param name="webApp">The web app to copy the configurations from.</param>
        /// <return>The next stage of the definition.</return>
        DeploymentSlot.Definition.IWithCreate DeploymentSlot.Definition.IWithConfiguration.WithConfigurationFromWebApp(IWebApp webApp)
        {
            return this.WithConfigurationFromWebApp(webApp) as DeploymentSlot.Definition.IWithCreate;
        }
    }
}