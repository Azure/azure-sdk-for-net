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
    public interface IApplicationGateways  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsCreating<ApplicationGateway.Definition.IBlank>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListing<Microsoft.Azure.Management.Network.Fluent.IApplicationGateway>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsListingByResourceGroup<Microsoft.Azure.Management.Network.Fluent.IApplicationGateway>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingByResourceGroup<Microsoft.Azure.Management.Network.Fluent.IApplicationGateway>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsGettingById<Microsoft.Azure.Management.Network.Fluent.IApplicationGateway>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsDeletingById,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsDeletingByResourceGroup,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsBatchCreation<Microsoft.Azure.Management.Network.Fluent.IApplicationGateway>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions.ISupportsBatchDeletion,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasManager<Microsoft.Azure.Management.Network.Fluent.INetworkManager>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Microsoft.Azure.Management.Network.Fluent.IApplicationGatewaysOperations>
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
        void Stop(ICollection<string> ids);

        /// <summary>
        /// Starts the specified application gateways.
        /// </summary>
        /// <param name="ids">Application gateway resource ids.</param>
        void Start(params string[] ids);

        /// <summary>
        /// Starts the specified application gateways.
        /// </summary>
        /// <param name="ids">Application gateway resource ids.</param>
        void Start(ICollection<string> ids);

        /// <summary>
        /// Stops the specified application gateways in parallel asynchronously.
        /// </summary>
        /// <param name="ids">Application gateway resource ids.</param>
        /// <return>An emitter of the resource ID for each successfully stopped application gateway.</return>
        Task<System.Collections.Generic.IEnumerable<string>> StopAsync(string[] ids, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Stops the specified application gateways in parallel asynchronously.
        /// </summary>
        /// <param name="ids">Application gateway resource id.</param>
        /// <return>An emitter of the resource ID for each successfully stopped application gateway.</return>
        Task<System.Collections.Generic.IEnumerable<string>> StopAsync(ICollection<string> ids, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Starts the specified application gateways in parallel asynchronously.
        /// </summary>
        /// <param name="ids">Application gateway resource id.</param>
        /// <return>An emitter of the resource ID for each successfully started application gateway.</return>
        Task<System.Collections.Generic.IEnumerable<string>> StartAsync(string[] ids, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Starts the specified application gateways in parallel asynchronously.
        /// </summary>
        /// <param name="ids">Application gateway resource id.</param>
        /// <return>An emitter of the resource ID for each successfully started application gateway.</return>
        Task<System.Collections.Generic.IEnumerable<string>> StartAsync(ICollection<string> ids, CancellationToken cancellationToken = default(CancellationToken));
    }
}