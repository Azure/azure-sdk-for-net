// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core.Pipeline;
using Azure.ResourceManager.MySql.FlexibleServers.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.MySql.FlexibleServers
{
    /// <summary> A class to add extension methods to Azure.ResourceManager.MySql.FlexibleServers. </summary>
    public static partial class FlexibleServersExtensions
    {
        /// <summary>
        /// Get the operation detailed status for a long running operation.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.DBforMySQL/locations/{locationName}/operationProgress/{operationId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>OperationProgress_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="operation"> The long-running operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="operation"/> is null or the long-running operation doesn't support get detailed status. </exception>
        public static async Task<Response<OperationProgressResult>> GetDetailedStatusAsync<T>(this ArmOperation<T> operation, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(operation, nameof(operation));
            Argument.AssertNotNullOrEmpty(operation.Id, nameof(operation.Id));

            //if (operation is not FlexibleServersArmOperation2<T>)
            //{
            //    throw new ArgumentException($"Operation {typeof(ArmOperation<T>)} doesn't support get operation detailed status.");
            //}

            FlexibleServersArmOperation2<T> flexibleServersArmOperation = (FlexibleServersArmOperation2<T>)operation;
            if (flexibleServersArmOperation.Pipeline is null)
            {
                throw new ArgumentException($"Operation {typeof(ArmOperation<T>)} doesn't support get operation detailed status.");
            }

            ClientDiagnostics operationProgressClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.MySql.FlexibleServers", ProviderConstants.DefaultProviderNamespace, flexibleServersArmOperation.Diagnostics);
            OperationProgressRestOperations operationProgressRestClient = new OperationProgressRestOperations(flexibleServersArmOperation.Pipeline, flexibleServersArmOperation.Diagnostics.ApplicationId, flexibleServersArmOperation.Endpoint);

            using var scope = operationProgressClientDiagnostics.CreateScope("MockableMySqlFlexibleServersSubscriptionResource.GetOperationProgress");
            scope.Start();
            try
            {
                var response = await operationProgressRestClient.GetAsync(flexibleServersArmOperation.ResourceId.SubscriptionId, flexibleServersArmOperation.ResourceId.Location.Value, operation.Id, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get the operation detailed status for a long running operation.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.DBforMySQL/locations/{locationName}/operationProgress/{operationId}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>OperationProgress_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="operation"> The long-running operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="operation"/> is null or the long-running operation doesn't support get detailed status. </exception>
        public static Response<OperationProgressResult> GetDetailedStatus<T>(this ArmOperation<T> operation, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(operation, nameof(operation));
            Argument.AssertNotNullOrEmpty(operation.Id, nameof(operation.Id));

            if (operation is not FlexibleServersArmOperation2<T>)
            {
                throw new ArgumentException($"Operation {typeof(ArmOperation<T>)} doesn't support get operation detailed status.");
            }

            FlexibleServersArmOperation2<T> flexibleServersArmOperation = operation as FlexibleServersArmOperation2<T>;
            if (flexibleServersArmOperation.Pipeline is null)
            {
                throw new ArgumentException($"Operation {typeof(ArmOperation<T>)} doesn't support get operation detailed status.");
            }

            ClientDiagnostics operationProgressClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.MySql.FlexibleServers", ProviderConstants.DefaultProviderNamespace, flexibleServersArmOperation.Diagnostics);
            OperationProgressRestOperations operationProgressRestClient = new OperationProgressRestOperations(flexibleServersArmOperation.Pipeline, flexibleServersArmOperation.Diagnostics.ApplicationId, flexibleServersArmOperation.Endpoint);

            using var scope = operationProgressClientDiagnostics.CreateScope("MockableMySqlFlexibleServersSubscriptionResource.GetOperationProgress");
            scope.Start();
            try
            {
                var response = operationProgressRestClient.Get(flexibleServersArmOperation.ResourceId.SubscriptionId, flexibleServersArmOperation.ResourceId.Location.Value, operation.Id, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
