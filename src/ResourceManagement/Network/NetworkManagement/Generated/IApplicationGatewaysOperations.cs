namespace Microsoft.Azure.Management.Network
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using Microsoft.Azure;
    using Models;

    /// <summary>
    /// </summary>
    public partial interface IApplicationGatewaysOperations
    {
        /// <summary>
        /// The delete applicationgateway operation deletes the specified
        /// applicationgateway.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='applicationGatewayName'>
        /// The name of the applicationgateway.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse> DeleteWithOperationResponseAsync(string resourceGroupName, string applicationGatewayName, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The delete applicationgateway operation deletes the specified
        /// applicationgateway.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='applicationGatewayName'>
        /// The name of the applicationgateway.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse> BeginDeleteWithOperationResponseAsync(string resourceGroupName, string applicationGatewayName, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The Get applicationgateway operation retreives information about
        /// the specified applicationgateway.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='applicationGatewayName'>
        /// The name of the applicationgateway.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<ApplicationGateway>> GetWithOperationResponseAsync(string resourceGroupName, string applicationGatewayName, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The Put ApplicationGateway operation creates/updates a
        /// ApplicationGateway
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='applicationGatewayName'>
        /// The name of the ApplicationGateway.
        /// </param>
        /// <param name='parameters'>
        /// Parameters supplied to the create/delete ApplicationGateway
        /// operation
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<ApplicationGateway>> CreateOrUpdateWithOperationResponseAsync(string resourceGroupName, string applicationGatewayName, ApplicationGateway parameters, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The Put ApplicationGateway operation creates/updates a
        /// ApplicationGateway
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='applicationGatewayName'>
        /// The name of the ApplicationGateway.
        /// </param>
        /// <param name='parameters'>
        /// Parameters supplied to the create/delete ApplicationGateway
        /// operation
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<ApplicationGateway>> BeginCreateOrUpdateWithOperationResponseAsync(string resourceGroupName, string applicationGatewayName, ApplicationGateway parameters, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The List ApplicationGateway opertion retrieves all the
        /// applicationgateways in a resource group.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<ApplicationGatewayListResult>> ListWithOperationResponseAsync(string resourceGroupName, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The List applicationgateway opertion retrieves all the
        /// applicationgateways in a subscription.
        /// </summary>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<ApplicationGatewayListResult>> ListAllWithOperationResponseAsync(CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The Start ApplicationGateway operation starts application
        /// gatewayin the specified resource group through Network resource
        /// provider.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='applicationGatewayName'>
        /// The name of the application gateway.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse> StartWithOperationResponseAsync(string resourceGroupName, string applicationGatewayName, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The Start ApplicationGateway operation starts application
        /// gatewayin the specified resource group through Network resource
        /// provider.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='applicationGatewayName'>
        /// The name of the application gateway.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse> BeginStartWithOperationResponseAsync(string resourceGroupName, string applicationGatewayName, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The STOP ApplicationGateway operation stops application gatewayin
        /// the specified resource group through Network resource provider.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='applicationGatewayName'>
        /// The name of the application gateway.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse> StopWithOperationResponseAsync(string resourceGroupName, string applicationGatewayName, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The STOP ApplicationGateway operation stops application gatewayin
        /// the specified resource group through Network resource provider.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='applicationGatewayName'>
        /// The name of the application gateway.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse> BeginStopWithOperationResponseAsync(string resourceGroupName, string applicationGatewayName, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The List ApplicationGateway opertion retrieves all the
        /// applicationgateways in a resource group.
        /// </summary>
        /// <param name='nextLink'>
        /// NextLink from the previous successful call to List operation.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<ApplicationGatewayListResult>> ListNextWithOperationResponseAsync(string nextLink, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The List applicationgateway opertion retrieves all the
        /// applicationgateways in a subscription.
        /// </summary>
        /// <param name='nextLink'>
        /// NextLink from the previous successful call to List operation.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<ApplicationGatewayListResult>> ListAllNextWithOperationResponseAsync(string nextLink, CancellationToken cancellationToken = default(CancellationToken));
    }
}
