// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Network.Fluent.ApplicationGateway.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using System.Collections.Generic;

    /// <summary>
    /// Entry point to application gateway management API in Azure.
    /// </summary>
    /// <remarks>
    /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
    /// future releases, including removal, regardless of any compatibility expectations set by the containing library
    /// version number.).
    /// </remarks>
    public interface IApplicationGateways  :
        ISupportsCreating<ApplicationGateway.Definition.IBlank>,
        ISupportsListing<Microsoft.Azure.Management.Network.Fluent.IApplicationGateway>,
        ISupportsListingByResourceGroup<Microsoft.Azure.Management.Network.Fluent.IApplicationGateway>,
        ISupportsGettingByResourceGroup<Microsoft.Azure.Management.Network.Fluent.IApplicationGateway>,
        ISupportsGettingById<Microsoft.Azure.Management.Network.Fluent.IApplicationGateway>,
        ISupportsDeletingById,
        ISupportsDeletingByResourceGroup,
        ISupportsBatchCreation<Microsoft.Azure.Management.Network.Fluent.IApplicationGateway>,
        ISupportsBatchDeletion,
        IHasManager<Microsoft.Azure.Management.Network.Fluent.INetworkManager>,
        IHasInner<Microsoft.Azure.Management.Network.Fluent.IApplicationGatewaysOperations>
    {
        /// <summary>
        /// Stops the specified application gateways.
        /// </summary>
        /// <param name="ids">Application gateway resource ids.</param>
        void Stop(params string[] ids);

        /// <summary>
        /// Stops the specified application gateways.
        /// </summary>
        /// <param name="ids">Application gateway resource ids.</param>
        void Stop(IList<string> ids);

        /// <summary>
        /// Starts the specified application gateways.
        /// </summary>
        /// <param name="ids">Application gateway resource ids.</param>
        void Start(params string[] ids);

        /// <summary>
        /// Starts the specified application gateways.
        /// </summary>
        /// <param name="ids">Application gateway resource ids.</param>
        void Start(IList<string> ids);

        /// <summary>
        /// Stops the specified application gateways in parallel asynchronously.
        /// </summary>
        /// <param name="ids">Application gateway resource ids.</param>
        /// <return>An Observable emitting the resource ID for each successfully stopped application gateway.</return>
        Task<System.Collections.Generic.IEnumerable<string>> StopAsync(string[] ids, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Stops the specified application gateways in parallel asynchronously.
        /// </summary>
        /// <param name="ids">Application gateway resource id.</param>
        /// <return>An Observable emitting the resource ID for each successfully stopped application gateway.</return>
        Task<System.Collections.Generic.IEnumerable<string>> StopAsync(IList<string> ids, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Starts the specified application gateways in parallel asynchronously.
        /// </summary>
        /// <param name="ids">Application gateway resource id.</param>
        /// <return>An Observable emitting the resource ID for each successfully started application gateway.</return>
        Task<System.Collections.Generic.IEnumerable<string>> StartAsync(string[] ids, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Starts the specified application gateways in parallel asynchronously.
        /// </summary>
        /// <param name="ids">Application gateway resource id.</param>
        /// <return>An Observable emitting the resource ID for each successfully started application gateway.</return>
        Task<System.Collections.Generic.IEnumerable<string>> StartAsync(IList<string> ids, CancellationToken cancellationToken = default(CancellationToken));
    }
}