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
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse> DeleteWithOperationResponseAsync(string resourceGroupName, string networkSecurityGroupName, string securityRuleName, CancellationToken cancellationToken = default(CancellationToken));
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
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse> BeginDeleteWithOperationResponseAsync(string resourceGroupName, string networkSecurityGroupName, string securityRuleName, CancellationToken cancellationToken = default(CancellationToken));
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
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<SecurityRule>> GetWithOperationResponseAsync(string resourceGroupName, string networkSecurityGroupName, string securityRuleName, CancellationToken cancellationToken = default(CancellationToken));
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
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<SecurityRule>> CreateOrUpdateWithOperationResponseAsync(string resourceGroupName, string networkSecurityGroupName, string securityRuleName, SecurityRule securityRuleParameters, CancellationToken cancellationToken = default(CancellationToken));
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
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<SecurityRule>> BeginCreateOrUpdateWithOperationResponseAsync(string resourceGroupName, string networkSecurityGroupName, string securityRuleName, SecurityRule securityRuleParameters, CancellationToken cancellationToken = default(CancellationToken));
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
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<SecurityRuleListResponse>> ListWithOperationResponseAsync(string resourceGroupName, string networkSecurityGroupName, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// The List network security rule opertion retrieves all the security
        /// rules in a network security group.
        /// </summary>
        /// <param name='nextLink'>
        /// NextLink from the previous successful call to List operation.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<SecurityRuleListResponse>> ListNextWithOperationResponseAsync(string nextLink, CancellationToken cancellationToken = default(CancellationToken));
    }
}
