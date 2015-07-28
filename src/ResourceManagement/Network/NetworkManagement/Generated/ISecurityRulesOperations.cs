namespace Microsoft.Azure.Management.Network
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using System.Linq;
    using Microsoft.Rest.Azure;
    using Models;

    /// <summary>
    /// SecurityRulesOperations operations.
    /// </summary>
    public partial interface ISecurityRulesOperations
    {
        /// <summary>
        /// The delete network security rule operation deletes the specified
        /// network security rule.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='networkSecurityGroupName'>
        /// The name of the network security group.
        /// </param>
        /// <param name='securityRuleName'>
        /// The name of the security rule.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<AzureOperationResponse> DeleteWithHttpMessagesAsync(string resourceGroupName, string networkSecurityGroupName, string securityRuleName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The delete network security rule operation deletes the specified
        /// network security rule.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='networkSecurityGroupName'>
        /// The name of the network security group.
        /// </param>
        /// <param name='securityRuleName'>
        /// The name of the security rule.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<AzureOperationResponse> BeginDeleteWithHttpMessagesAsync(string resourceGroupName, string networkSecurityGroupName, string securityRuleName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The Get NetworkSecurityRule operation retreives information about
        /// the specified network security rule.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='networkSecurityGroupName'>
        /// The name of the network security group.
        /// </param>
        /// <param name='securityRuleName'>
        /// The name of the security rule.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<AzureOperationResponse<SecurityRule>> GetWithHttpMessagesAsync(string resourceGroupName, string networkSecurityGroupName, string securityRuleName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The Put network security rule operation creates/updates a security
        /// rule in the specified network security group
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='networkSecurityGroupName'>
        /// The name of the network security group.
        /// </param>
        /// <param name='securityRuleName'>
        /// The name of the security rule.
        /// </param>
        /// <param name='securityRuleParameters'>
        /// Parameters supplied to the create/update network security rule
        /// operation
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<AzureOperationResponse<SecurityRule>> CreateOrUpdateWithHttpMessagesAsync(string resourceGroupName, string networkSecurityGroupName, string securityRuleName, SecurityRule securityRuleParameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The Put network security rule operation creates/updates a security
        /// rule in the specified network security group
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='networkSecurityGroupName'>
        /// The name of the network security group.
        /// </param>
        /// <param name='securityRuleName'>
        /// The name of the security rule.
        /// </param>
        /// <param name='securityRuleParameters'>
        /// Parameters supplied to the create/update network security rule
        /// operation
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<AzureOperationResponse<SecurityRule>> BeginCreateOrUpdateWithHttpMessagesAsync(string resourceGroupName, string networkSecurityGroupName, string securityRuleName, SecurityRule securityRuleParameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The List network security rule opertion retrieves all the security
        /// rules in a network security group.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// The name of the resource group.
        /// </param>
        /// <param name='networkSecurityGroupName'>
        /// The name of the network security group.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<AzureOperationResponse<Page<SecurityRule>>> ListWithHttpMessagesAsync(string resourceGroupName, string networkSecurityGroupName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The List network security rule opertion retrieves all the security
        /// rules in a network security group.
        /// </summary>
        /// <param name='nextPageLink'>
        /// NextLink from the previous successful call to List operation.
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<AzureOperationResponse<Page<SecurityRule>>> ListNextWithHttpMessagesAsync(string nextPageLink, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}
