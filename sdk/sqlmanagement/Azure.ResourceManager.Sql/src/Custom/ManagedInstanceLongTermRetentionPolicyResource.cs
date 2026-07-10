// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Sql
{
    // The generator now models this delete as non-generic ArmOperation, but the shipped SDK returned ArmOperation<ManagedInstanceLongTermRetentionPolicyResource>.
    [CodeGenSuppress("DeleteAsync", typeof(WaitUntil), typeof(CancellationToken))]
    [CodeGenSuppress("Delete", typeof(WaitUntil), typeof(CancellationToken))]
    public partial class ManagedInstanceLongTermRetentionPolicyResource
    {
        /// <summary> Deletes a long term retention policy. </summary>
        public virtual async Task<ArmOperation<ManagedInstanceLongTermRetentionPolicyResource>> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _managedInstanceLongTermRetentionPoliciesClientDiagnostics.CreateScope("ManagedInstanceLongTermRetentionPolicyResource.Delete");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _managedInstanceLongTermRetentionPoliciesRestClient.CreateDeleteRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                SqlArmOperation<ManagedInstanceLongTermRetentionPolicyResource> operation = new SqlArmOperation<ManagedInstanceLongTermRetentionPolicyResource>(new ManagedInstanceLongTermRetentionPolicyResourceOperationSource(Client), _managedInstanceLongTermRetentionPoliciesClientDiagnostics, Pipeline, message.Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                {
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                }
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Deletes a long term retention policy. </summary>
        public virtual ArmOperation<ManagedInstanceLongTermRetentionPolicyResource> Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _managedInstanceLongTermRetentionPoliciesClientDiagnostics.CreateScope("ManagedInstanceLongTermRetentionPolicyResource.Delete");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _managedInstanceLongTermRetentionPoliciesRestClient.CreateDeleteRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, context);
                Response response = Pipeline.ProcessMessage(message, context);
                SqlArmOperation<ManagedInstanceLongTermRetentionPolicyResource> operation = new SqlArmOperation<ManagedInstanceLongTermRetentionPolicyResource>(new ManagedInstanceLongTermRetentionPolicyResourceOperationSource(Client), _managedInstanceLongTermRetentionPoliciesClientDiagnostics, Pipeline, message.Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                {
                    operation.WaitForCompletion(cancellationToken);
                }
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
