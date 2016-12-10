// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using System.Collections.Generic;
    using System;

    /// <summary>
    /// An immutable client-side representation of an Azure Web App or deployment slot.
    /// </summary>
    public interface IWebAppBase  :
        IHasName,
        IGroupableResource,
        IWrapper<Microsoft.Azure.Management.AppService.Fluent.Models.SiteInner>
    {
        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.AppService.Fluent.IConnectionString> ConnectionStrings { get; }

        System.DateTime LastModifiedTime { get; }

        /// <summary>
        /// Stops the web app or deployment slot.
        /// </summary>
        void Stop();

        Microsoft.Azure.Management.AppService.Fluent.PhpVersion PhpVersion { get; }

        System.Collections.Generic.ISet<string> TrafficManagerHostNames { get; }

        bool ScmSiteAlsoStopped { get; }

        string AutoSwapSlotName { get; }

        string State { get; }

        bool IsPremiumApp { get; }

        string RepositorySiteName { get; }

        Microsoft.Azure.Management.AppService.Fluent.Models.SiteAvailabilityState AvailabilityState { get; }

        bool HostNamesDisabled { get; }

        string JavaContainerVersion { get; }

        Microsoft.Azure.Management.AppService.Fluent.Models.ManagedPipelineMode ManagedPipelineMode { get; }

        Microsoft.Azure.Management.AppService.Fluent.Models.CloningInfo CloningInfo { get; }

        bool AlwaysOn { get; }

        Microsoft.Azure.Management.AppService.Fluent.PythonVersion PythonVersion { get; }

        /// <summary>
        /// Verifies the ownership of the domain for a certificate order by verifying a hostname
        /// of the domain is bound to this web app.
        /// </summary>
        /// <param name="certificateOrderName">The name of the certificate order.</param>
        /// <param name="domainVerificationToken">The domain verification token for the certificate order.</param>
        Task VerifyDomainOwnershipAsync(string certificateOrderName, string domainVerificationToken, CancellationToken cancellationToken = default(CancellationToken));

        Task CacheAppSettingsAndConnectionStringsAsync(CancellationToken cancellationToken = default(CancellationToken));

        Microsoft.Azure.Management.AppService.Fluent.Models.UsageState UsageState { get; }

        string TargetSwapSlot { get; }

        string GatewaySiteName { get; }

        Microsoft.Azure.Management.AppService.Fluent.JavaVersion JavaVersion { get; }

        string DefaultHostName { get; }

        string AppServicePlanId { get; }

        Microsoft.Azure.Management.AppService.Fluent.RemoteVisualStudioVersion RemoteDebuggingVersion { get; }

        bool RemoteDebuggingEnabled { get; }

        System.Collections.Generic.ISet<string> OutboundIpAddresses { get; }

        /// <summary>
        /// Reset the slot to its original configurations.
        /// </summary>
        void ResetSlotConfigurations();

        bool WebSocketsEnabled { get; }

        bool Enabled { get; }

        /// <summary>
        /// Restarts the web app or deployment slot.
        /// </summary>
        void Restart();

        Microsoft.Azure.Management.AppService.Fluent.IPublishingProfile GetPublishingProfile();

        int ContainerSize { get; }

        string JavaContainer { get; }

        /// <summary>
        /// Apply the slot (or sticky) configurations from the specified slot
        /// to the current one. This is useful for "Swap with Preview".
        /// </summary>
        void ApplySlotConfigurations(string slotName);

        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.AppService.Fluent.IAppSetting> AppSettings { get; }

        System.Collections.Generic.ISet<string> HostNames { get; }

        bool ClientAffinityEnabled { get; }

        System.Collections.Generic.IList<string> DefaultDocuments { get; }

        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.AppService.Fluent.Models.HostNameSslState> HostNameSslStates { get; }

        System.Collections.Generic.IReadOnlyDictionary<string,Microsoft.Azure.Management.AppService.Fluent.IHostNameBinding> GetHostNameBindings();

        string MicroService { get; }

        bool ClientCertEnabled { get; }

        /// <summary>
        /// Verifies the ownership of the domain for a certificate order by verifying a hostname
        /// of the domain is bound to this web app.
        /// </summary>
        /// <param name="certificateOrderName">The name of the certificate order.</param>
        void VerifyDomainOwnership(string certificateOrderName, string domainVerificationToken);

        Microsoft.Azure.Management.AppService.Fluent.IWebAppSourceControl GetSourceControl();

        Microsoft.Azure.Management.AppService.Fluent.NetFrameworkVersion NetFrameworkVersion { get; }

        /// <summary>
        /// Starts the web app or deployment slot.
        /// </summary>
        void Start();

        bool IsDefaultContainer { get; }

        System.Collections.Generic.ISet<string> EnabledHostNames { get; }

        /// <summary>
        /// Swaps the app running in the current web app / slot with the app
        /// running in the specified slot.
        /// </summary>
        void Swap(string slotName);

        string NodeVersion { get; }
    }
}