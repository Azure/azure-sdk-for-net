// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;
    using System;

    /// <summary>
    /// An immutable client-side representation of an Azure Web App or deployment slot.
    /// </summary>
    public interface IWebAppBase  :
        IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasName,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IGroupableResource<Microsoft.Azure.Management.AppService.Fluent.IAppServiceManager,Models.SiteInner>
    {
        /// <summary>
        /// Gets Last time web app was modified in UTC.
        /// </summary>
        System.DateTime? LastModifiedTime { get; }

        /// <summary>
        /// Gets whether to stop SCM (KUDU) site when the web app is
        /// stopped. Default is false.
        /// </summary>
        bool ScmSiteAlsoStopped { get; }

        /// <summary>
        /// Gets list of Azure Traffic manager host names associated with web
        /// app.
        /// </summary>
        System.Collections.Generic.ISet<string> TrafficManagerHostNames { get; }

        /// <summary>
        /// Gets the version of PHP.
        /// </summary>
        Microsoft.Azure.Management.AppService.Fluent.PhpVersion PhpVersion { get; }

        /// <return>The mapping from host names and the host name bindings.</return>
        Task<System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.AppService.Fluent.IHostNameBinding>> GetHostNameBindingsAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets name of repository site.
        /// </summary>
        string RepositorySiteName { get; }

        /// <summary>
        /// Starts the web app or deployment slot.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        Task StartAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets Java container version.
        /// </summary>
        string JavaContainerVersion { get; }

        /// <summary>
        /// Gets the version of Python.
        /// </summary>
        Microsoft.Azure.Management.AppService.Fluent.PythonVersion PythonVersion { get; }

        /// <summary>
        /// Apply the slot (or sticky) configurations from the specified slot
        /// to the current one. This is useful for "Swap with Preview".
        /// </summary>
        /// <param name="slotName">The target slot to apply configurations from.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        Task ApplySlotConfigurationsAsync(string slotName, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the remote debugging version.
        /// </summary>
        Microsoft.Azure.Management.AppService.Fluent.RemoteVisualStudioVersion RemoteDebuggingVersion { get; }

        /// <summary>
        /// Gets if web socket is enabled.
        /// </summary>
        bool WebSocketsEnabled { get; }

        /// <summary>
        /// Stops the web app or deployment slot.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        Task StopAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets true if the site is enabled; otherwise, false.
        /// </summary>
        bool Enabled { get; }

        /// <return>The URL and credentials for publishing through FTP or Git.</return>
        Microsoft.Azure.Management.AppService.Fluent.IPublishingProfile GetPublishingProfile();

        /// <summary>
        /// Gets size of a function container.
        /// </summary>
        int ContainerSize { get; }

        /// <summary>
        /// Apply the slot (or sticky) configurations from the specified slot
        /// to the current one. This is useful for "Swap with Preview".
        /// </summary>
        /// <param name="slotName">The target slot to apply configurations from.</param>
        void ApplySlotConfigurations(string slotName);

        /// <summary>
        /// Gets the app settings defined on the web app.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.AppService.Fluent.IAppSetting> AppSettings { get; }

        /// <summary>
        /// Gets if the client certificate is enabled for the web app.
        /// </summary>
        bool ClientCertEnabled { get; }

        /// <summary>
        /// Verifies the ownership of the domain for a certificate order by verifying a hostname
        /// of the domain is bound to this web app.
        /// </summary>
        /// <param name="certificateOrderName">The name of the certificate order.</param>
        /// <param name="domainVerificationToken">The domain verification token for the certificate order.</param>
        void VerifyDomainOwnership(string certificateOrderName, string domainVerificationToken);

        /// <summary>
        /// Gets the .NET Framework version.
        /// </summary>
        Microsoft.Azure.Management.AppService.Fluent.NetFrameworkVersion NetFrameworkVersion { get; }

        /// <summary>
        /// Starts the web app or deployment slot.
        /// </summary>
        void Start();

        /// <summary>
        /// Gets host names for the web app that are enabled.
        /// </summary>
        System.Collections.Generic.ISet<string> EnabledHostNames { get; }

        /// <summary>
        /// Gets the version of Node.JS.
        /// </summary>
        string NodeVersion { get; }

        /// <return>The URL and credentials for publishing through FTP or Git.</return>
        Task<Microsoft.Azure.Management.AppService.Fluent.IPublishingProfile> GetPublishingProfileAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the connection strings defined on the web app.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.AppService.Fluent.IConnectionString> ConnectionStrings { get; }

        /// <summary>
        /// Gets the architecture of the platform, either 32 bit (x86) or 64 bit (x64).
        /// </summary>
        Microsoft.Azure.Management.AppService.Fluent.PlatformArchitecture PlatformArchitecture { get; }

        /// <summary>
        /// Stops the web app or deployment slot.
        /// </summary>
        void Stop();

        /// <summary>
        /// Gets the operating system the web app is running on.
        /// </summary>
        Microsoft.Azure.Management.AppService.Fluent.OperatingSystem OperatingSystem { get; }

        /// <summary>
        /// Gets the auto swap slot name.
        /// </summary>
        string AutoSwapSlotName { get; }

        /// <summary>
        /// Swaps the app running in the current web app / slot with the app
        /// running in the specified slot.
        /// </summary>
        /// <param name="slotName">
        /// The target slot to swap with. Use 'production' for
        /// the production slot.
        /// </param>
        /// <return>A representation of the deferred computation of this call.</return>
        Task SwapAsync(string slotName, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets state of the web app.
        /// </summary>
        string State { get; }

        /// <summary>
        /// Gets whether web app is deployed as a premium app.
        /// </summary>
        bool IsPremiumApp { get; }

        /// <summary>
        /// Reset the slot to its original configurations.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        Task ResetSlotConfigurationsAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets if the public hostnames are disabled the web app.
        /// If set to true the app is only accessible via API
        /// Management process.
        /// </summary>
        bool HostNamesDisabled { get; }

        /// <summary>
        /// Gets management information availability state for the web app.
        /// </summary>
        Models.SiteAvailabilityState AvailabilityState { get; }

        /// <summary>
        /// Gets information about whether the web app is cloned from another.
        /// </summary>
        Models.CloningInfo CloningInfo { get; }

        /// <summary>
        /// Gets managed pipeline mode.
        /// </summary>
        Models.ManagedPipelineMode ManagedPipelineMode { get; }

        /// <summary>
        /// Gets if the web app is always on.
        /// </summary>
        bool AlwaysOn { get; }

        /// <summary>
        /// Verifies the ownership of the domain for a certificate order by verifying a hostname
        /// of the domain is bound to this web app.
        /// </summary>
        /// <param name="certificateOrderName">The name of the certificate order.</param>
        /// <param name="domainVerificationToken">The domain verification token for the certificate order.</param>
        /// <return>A representation of the deferred computation of this call.</return>
        Task VerifyDomainOwnershipAsync(string certificateOrderName, string domainVerificationToken, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets state indicating whether web app has exceeded its quota usage.
        /// </summary>
        Models.UsageState UsageState { get; }

        /// <summary>
        /// Gets name of gateway app associated with web app.
        /// </summary>
        string GatewaySiteName { get; }

        /// <summary>
        /// Gets which slot this app will swap into.
        /// </summary>
        string TargetSwapSlot { get; }

        /// <summary>
        /// Gets default hostname of the web app.
        /// </summary>
        string DefaultHostName { get; }

        /// <summary>
        /// Gets Java version.
        /// </summary>
        Microsoft.Azure.Management.AppService.Fluent.JavaVersion JavaVersion { get; }

        /// <summary>
        /// Gets The resource ID of the app service plan.
        /// </summary>
        string AppServicePlanId { get; }

        /// <summary>
        /// Gets if the remote eebugging is enabled.
        /// </summary>
        bool RemoteDebuggingEnabled { get; }

        /// <summary>
        /// Reset the slot to its original configurations.
        /// </summary>
        void ResetSlotConfigurations();

        /// <summary>
        /// Restarts the web app or deployment slot.
        /// </summary>
        void Restart();

        /// <summary>
        /// Gets Java container.
        /// </summary>
        string JavaContainer { get; }

        /// <summary>
        /// Restarts the web app or deployment slot.
        /// </summary>
        /// <return>A representation of the deferred computation of this call.</return>
        Task RestartAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets if the client affinity is enabled when load balancing http
        /// request for multiple instances of the web app.
        /// </summary>
        bool ClientAffinityEnabled { get; }

        /// <summary>
        /// Gets hostnames associated with web app.
        /// </summary>
        System.Collections.Generic.ISet<string> HostNames { get; }

        /// <summary>
        /// Gets list of SSL states used to manage the SSL bindings for site's hostnames.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,Models.HostNameSslState> HostNameSslStates { get; }

        /// <summary>
        /// Gets the default documents.
        /// </summary>
        System.Collections.Generic.IReadOnlyList<string> DefaultDocuments { get; }

        /// <summary>
        /// Gets the micro-service name.
        /// </summary>
        string MicroService { get; }

        /// <return>The mapping from host names and the host name bindings.</return>
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.AppService.Fluent.IHostNameBinding> GetHostNameBindings();

        /// <return>The source control information for the web app.</return>
        Task<Microsoft.Azure.Management.AppService.Fluent.IWebAppSourceControl> GetSourceControlAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <return>The source control information for the web app.</return>
        Microsoft.Azure.Management.AppService.Fluent.IWebAppSourceControl GetSourceControl();

        /// <summary>
        /// Gets site is a default container.
        /// </summary>
        bool IsDefaultContainer { get; }

        /// <summary>
        /// Swaps the app running in the current web app / slot with the app
        /// running in the specified slot.
        /// </summary>
        /// <param name="slotName">
        /// The target slot to swap with. Use 'production' for
        /// the production slot.
        /// </param>
        void Swap(string slotName);

        /// <summary>
        /// Gets list of IP addresses that this web app uses for
        /// outbound connections. Those can be used when configuring firewall
        /// rules for databases accessed by this web app.
        /// </summary>
        System.Collections.Generic.ISet<string> OutboundIPAddresses { get; }

        /// <summary>
        /// Gets the Linux app framework and version if this is a Linux web app.
        /// </summary>
        string LinuxFxVersion { get; }

        /// <summary>
        /// First step specifying the parameters to make a web deployment (MS Deploy) to the web app.
        /// </summary>
        /// <returns>the first stage to create web deployment</returns>
        WebDeployment.Definition.IWithPackageUri Deploy();
    }
}