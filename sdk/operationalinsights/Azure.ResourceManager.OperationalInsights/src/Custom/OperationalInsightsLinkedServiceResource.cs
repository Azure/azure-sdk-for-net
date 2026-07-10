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

namespace Azure.ResourceManager.OperationalInsights
{
    // The generator now models this delete as non-generic ArmOperation, but the shipped SDK returned ArmOperation<OperationalInsightsLinkedServiceResource>.
    [CodeGenSuppress("DeleteAsync", typeof(WaitUntil), typeof(CancellationToken))]
    [CodeGenSuppress("Delete", typeof(WaitUntil), typeof(CancellationToken))]
    public partial class OperationalInsightsLinkedServiceResource
    {
        /// <summary> Deletes a linked service instance. </summary>
        public virtual async Task<ArmOperation<OperationalInsightsLinkedServiceResource>> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _linkedServicesClientDiagnostics.CreateScope("OperationalInsightsLinkedServiceResource.Delete");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _linkedServicesRestClient.CreateDeleteRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                OperationalInsightsArmOperation<OperationalInsightsLinkedServiceResource> operation = new OperationalInsightsArmOperation<OperationalInsightsLinkedServiceResource>(new OperationalInsightsLinkedServiceResourceOperationSource(Client), _linkedServicesClientDiagnostics, Pipeline, message.Request, response, OperationFinalStateVia.Location);
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

        /// <summary> Deletes a linked service instance. </summary>
        public virtual ArmOperation<OperationalInsightsLinkedServiceResource> Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _linkedServicesClientDiagnostics.CreateScope("OperationalInsightsLinkedServiceResource.Delete");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _linkedServicesRestClient.CreateDeleteRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Name, Id.Name, context);
                Response response = Pipeline.ProcessMessage(message, context);
                OperationalInsightsArmOperation<OperationalInsightsLinkedServiceResource> operation = new OperationalInsightsArmOperation<OperationalInsightsLinkedServiceResource>(new OperationalInsightsLinkedServiceResourceOperationSource(Client), _linkedServicesClientDiagnostics, Pipeline, message.Request, response, OperationFinalStateVia.Location);
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
