// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.SecurityCenter.Models;

namespace Azure.ResourceManager.SecurityCenter
{
    /// <summary>
    /// A Class representing a SecurityConnectorGovernanceRule along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct a <see cref="SecurityConnectorGovernanceRuleResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetSecurityConnectorGovernanceRuleResource method.
    /// Otherwise you can get one from its parent resource <see cref="SecurityConnectorResource" /> using the GetSecurityConnectorGovernanceRule method.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This class is obsolete and will be removed in a future release.", false)]
    public partial class SecurityConnectorGovernanceRuleResource : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="SecurityConnectorGovernanceRuleResource"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string securityConnectorName, string ruleId)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Security/securityConnectors/{securityConnectorName}/providers/Microsoft.Security/governanceRules/{ruleId}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _securityConnectorGovernanceRuleClientDiagnostics;
        private readonly SecurityConnectorGovernanceRulesRestOperations _securityConnectorGovernanceRuleRestClient;
        private readonly ClientDiagnostics _subscriptionGovernanceRuleGovernanceRulesClientDiagnostics;
        private readonly SubscriptionGovernanceRulesRestOperations _subscriptionGovernanceRuleGovernanceRulesRestClient;
        private readonly ClientDiagnostics _securityConnectorGovernanceRulesExecuteStatusClientDiagnostics;
        private readonly SecurityConnectorGovernanceRulesExecuteStatusRestOperations _securityConnectorGovernanceRulesExecuteStatusRestClient;
        private readonly GovernanceRuleData _data;

        /// <summary> Initializes a new instance of the <see cref="SecurityConnectorGovernanceRuleResource"/> class for mocking. </summary>
        protected SecurityConnectorGovernanceRuleResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "SecurityConnectorGovernanceRuleResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal SecurityConnectorGovernanceRuleResource(ArmClient client, GovernanceRuleData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="SecurityConnectorGovernanceRuleResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal SecurityConnectorGovernanceRuleResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _securityConnectorGovernanceRuleClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.SecurityCenter", ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ResourceType, out string securityConnectorGovernanceRuleApiVersion);
            _securityConnectorGovernanceRuleRestClient = new SecurityConnectorGovernanceRulesRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, securityConnectorGovernanceRuleApiVersion);
            _subscriptionGovernanceRuleGovernanceRulesClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.SecurityCenter", SubscriptionGovernanceRuleResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(SubscriptionGovernanceRuleResource.ResourceType, out string subscriptionGovernanceRuleGovernanceRulesApiVersion);
            _subscriptionGovernanceRuleGovernanceRulesRestClient = new SubscriptionGovernanceRulesRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, subscriptionGovernanceRuleGovernanceRulesApiVersion);
            _securityConnectorGovernanceRulesExecuteStatusClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.SecurityCenter", ProviderConstants.DefaultProviderNamespace, Diagnostics);
            _securityConnectorGovernanceRulesExecuteStatusRestClient = new SecurityConnectorGovernanceRulesExecuteStatusRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Security/governanceRules";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual GovernanceRuleData Data
        {
            get
            {
                if (!HasData)
                    throw new InvalidOperationException("The current instance does not have data, you must call Get first.");
                return _data;
            }
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceType), nameof(id));
        }

        /// <summary>
        /// Get a specific governanceRule for the requested scope by ruleId
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Security/securityConnectors/{securityConnectorName}/providers/Microsoft.Security/governanceRules/{ruleId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SecurityConnectorGovernanceRules_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<SecurityConnectorGovernanceRuleResource>> GetAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _securityConnectorGovernanceRuleClientDiagnostics.CreateScope("SecurityConnectorGovernanceRuleResource.Get");
            scope.Start();
            try
            {
                var response = await _securityConnectorGovernanceRuleRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SecurityConnectorGovernanceRuleResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get a specific governanceRule for the requested scope by ruleId
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Security/securityConnectors/{securityConnectorName}/providers/Microsoft.Security/governanceRules/{ruleId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SecurityConnectorGovernanceRules_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<SecurityConnectorGovernanceRuleResource> Get(CancellationToken cancellationToken = default)
        {
            using var scope = _securityConnectorGovernanceRuleClientDiagnostics.CreateScope("SecurityConnectorGovernanceRuleResource.Get");
            scope.Start();
            try
            {
                var response = _securityConnectorGovernanceRuleRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SecurityConnectorGovernanceRuleResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Delete a GovernanceRule over a given scope
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Security/securityConnectors/{securityConnectorName}/providers/Microsoft.Security/governanceRules/{ruleId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SecurityConnectorGovernanceRules_Delete</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _securityConnectorGovernanceRuleClientDiagnostics.CreateScope("SecurityConnectorGovernanceRuleResource.Delete");
            scope.Start();
            try
            {
                var response = await _securityConnectorGovernanceRuleRestClient.DeleteAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken).ConfigureAwait(false);
                var operation = new SecurityCenterArmOperation(response);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Delete a GovernanceRule over a given scope
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Security/securityConnectors/{securityConnectorName}/providers/Microsoft.Security/governanceRules/{ruleId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SecurityConnectorGovernanceRules_Delete</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _securityConnectorGovernanceRuleClientDiagnostics.CreateScope("SecurityConnectorGovernanceRuleResource.Delete");
            scope.Start();
            try
            {
                var response = _securityConnectorGovernanceRuleRestClient.Delete(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken);
                var operation = new SecurityCenterArmOperation(response);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletionResponse(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Creates or update a security GovernanceRule on the given security connector.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Security/securityConnectors/{securityConnectorName}/providers/Microsoft.Security/governanceRules/{ruleId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SecurityConnectorGovernanceRules_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> GovernanceRule over a subscription scope. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<SecurityConnectorGovernanceRuleResource>> UpdateAsync(WaitUntil waitUntil, GovernanceRuleData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _securityConnectorGovernanceRuleClientDiagnostics.CreateScope("SecurityConnectorGovernanceRuleResource.Update");
            scope.Start();
            try
            {
                var response = await _securityConnectorGovernanceRuleRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, data, cancellationToken).ConfigureAwait(false);
                var operation = new SecurityCenterArmOperation<SecurityConnectorGovernanceRuleResource>(Response.FromValue(new SecurityConnectorGovernanceRuleResource(Client, response), response.GetRawResponse()));
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Creates or update a security GovernanceRule on the given security connector.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Security/securityConnectors/{securityConnectorName}/providers/Microsoft.Security/governanceRules/{ruleId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SecurityConnectorGovernanceRules_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> GovernanceRule over a subscription scope. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<SecurityConnectorGovernanceRuleResource> Update(WaitUntil waitUntil, GovernanceRuleData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _securityConnectorGovernanceRuleClientDiagnostics.CreateScope("SecurityConnectorGovernanceRuleResource.Update");
            scope.Start();
            try
            {
                var response = _securityConnectorGovernanceRuleRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, data, cancellationToken);
                var operation = new SecurityCenterArmOperation<SecurityConnectorGovernanceRuleResource>(Response.FromValue(new SecurityConnectorGovernanceRuleResource(Client, response), response.GetRawResponse()));
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Execute a security GovernanceRule on the given security connector.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Security/securityConnectors/{securityConnectorName}/providers/Microsoft.Security/governanceRules/{ruleId}/execute</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>GovernanceRules_RuleIdExecuteSingleSecurityConnector</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="executeGovernanceRuleParams"> GovernanceRule over a subscription scope. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation> ExecuteRuleAsync(WaitUntil waitUntil, ExecuteGovernanceRuleParams executeGovernanceRuleParams = null, CancellationToken cancellationToken = default)
        {
            using var scope = _subscriptionGovernanceRuleGovernanceRulesClientDiagnostics.CreateScope("SecurityConnectorGovernanceRuleResource.ExecuteRule");
            scope.Start();
            try
            {
                var response = await _subscriptionGovernanceRuleGovernanceRulesRestClient.RuleIdExecuteSingleSecurityConnectorAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, executeGovernanceRuleParams, cancellationToken).ConfigureAwait(false);
                var operation = new SecurityCenterArmOperation(_subscriptionGovernanceRuleGovernanceRulesClientDiagnostics, Pipeline, _subscriptionGovernanceRuleGovernanceRulesRestClient.CreateRuleIdExecuteSingleSecurityConnectorRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, executeGovernanceRuleParams).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Execute a security GovernanceRule on the given security connector.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Security/securityConnectors/{securityConnectorName}/providers/Microsoft.Security/governanceRules/{ruleId}/execute</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>GovernanceRules_RuleIdExecuteSingleSecurityConnector</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="executeGovernanceRuleParams"> GovernanceRule over a subscription scope. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation ExecuteRule(WaitUntil waitUntil, ExecuteGovernanceRuleParams executeGovernanceRuleParams = null, CancellationToken cancellationToken = default)
        {
            using var scope = _subscriptionGovernanceRuleGovernanceRulesClientDiagnostics.CreateScope("SecurityConnectorGovernanceRuleResource.ExecuteRule");
            scope.Start();
            try
            {
                var response = _subscriptionGovernanceRuleGovernanceRulesRestClient.RuleIdExecuteSingleSecurityConnector(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, executeGovernanceRuleParams, cancellationToken);
                var operation = new SecurityCenterArmOperation(_subscriptionGovernanceRuleGovernanceRulesClientDiagnostics, Pipeline, _subscriptionGovernanceRuleGovernanceRulesRestClient.CreateRuleIdExecuteSingleSecurityConnectorRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, executeGovernanceRuleParams).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletionResponse(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get a specific governanceRule execution status for the requested scope by ruleId and operationId
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Security/securityConnectors/{securityConnectorName}/providers/Microsoft.Security/governanceRules/{ruleId}/operationResults/{operationId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SecurityConnectorGovernanceRulesExecuteStatus_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="operationId"> The security GovernanceRule execution key - unique key for the execution of GovernanceRule. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="operationId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="operationId"/> is null. </exception>
        public virtual async Task<ArmOperation<ExecuteRuleStatus>> GetRuleExecutionStatusAsync(WaitUntil waitUntil, string operationId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(operationId, nameof(operationId));

            using var scope = _securityConnectorGovernanceRulesExecuteStatusClientDiagnostics.CreateScope("SecurityConnectorGovernanceRuleResource.GetRuleExecutionStatus");
            scope.Start();
            try
            {
                var response = await _securityConnectorGovernanceRulesExecuteStatusRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, operationId, cancellationToken).ConfigureAwait(false);
                var operation = new SecurityCenterArmOperation<ExecuteRuleStatus>(new ExecuteRuleStatusOperationSource(), _securityConnectorGovernanceRulesExecuteStatusClientDiagnostics, Pipeline, _securityConnectorGovernanceRulesExecuteStatusRestClient.CreateGetRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, operationId).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get a specific governanceRule execution status for the requested scope by ruleId and operationId
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Security/securityConnectors/{securityConnectorName}/providers/Microsoft.Security/governanceRules/{ruleId}/operationResults/{operationId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>SecurityConnectorGovernanceRulesExecuteStatus_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="operationId"> The security GovernanceRule execution key - unique key for the execution of GovernanceRule. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="operationId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="operationId"/> is null. </exception>
        public virtual ArmOperation<ExecuteRuleStatus> GetRuleExecutionStatus(WaitUntil waitUntil, string operationId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(operationId, nameof(operationId));

            using var scope = _securityConnectorGovernanceRulesExecuteStatusClientDiagnostics.CreateScope("SecurityConnectorGovernanceRuleResource.GetRuleExecutionStatus");
            scope.Start();
            try
            {
                var response = _securityConnectorGovernanceRulesExecuteStatusRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, operationId, cancellationToken);
                var operation = new SecurityCenterArmOperation<ExecuteRuleStatus>(new ExecuteRuleStatusOperationSource(), _securityConnectorGovernanceRulesExecuteStatusClientDiagnostics, Pipeline, _securityConnectorGovernanceRulesExecuteStatusRestClient.CreateGetRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, operationId).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
