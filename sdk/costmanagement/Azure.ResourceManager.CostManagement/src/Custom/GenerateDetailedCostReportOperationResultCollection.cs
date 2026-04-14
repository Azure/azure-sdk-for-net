// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.CostManagement
{
    [CodeGenSuppress("ExistsAsync", typeof(WaitUntil), typeof(string), typeof(CancellationToken))]
    // TODO: This file can be removed once https://github.com/Azure/azure-sdk-for-net/pull/58153 is resolved.
    [CodeGenSuppress("Exists", typeof(WaitUntil), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetIfExistsAsync", typeof(WaitUntil), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetIfExists", typeof(WaitUntil), typeof(string), typeof(CancellationToken))]
    public partial class GenerateDetailedCostReportOperationResultCollection
    {
        /// <summary> Checks to see if the resource exists in azure. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> for LRO completion. </param>
        /// <param name="operationId"> The target operation Id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<bool>> ExistsAsync(WaitUntil waitUntil, string operationId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(operationId, nameof(operationId));
            using DiagnosticScope scope = _generateDetailedCostReportOperationResultsClientDiagnostics.CreateScope("GenerateDetailedCostReportOperationResultCollection.Exists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _generateDetailedCostReportOperationResultsRestClient.CreateGetRequest(Id, operationId, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context, cancellationToken).ConfigureAwait(false);
                return result.Status switch
                {
                    200 => Response.FromValue(true, result),
                    404 => Response.FromValue(false, result),
                    _ => throw new RequestFailedException(result)
                };
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Checks to see if the resource exists in azure. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> for LRO completion. </param>
        /// <param name="operationId"> The target operation Id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<bool> Exists(WaitUntil waitUntil, string operationId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(operationId, nameof(operationId));
            using DiagnosticScope scope = _generateDetailedCostReportOperationResultsClientDiagnostics.CreateScope("GenerateDetailedCostReportOperationResultCollection.Exists");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _generateDetailedCostReportOperationResultsRestClient.CreateGetRequest(Id, operationId, context);
                Response result = Pipeline.ProcessMessage(message, context, cancellationToken);
                return result.Status switch
                {
                    200 => Response.FromValue(true, result),
                    404 => Response.FromValue(false, result),
                    _ => throw new RequestFailedException(result)
                };
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> for LRO completion. </param>
        /// <param name="operationId"> The target operation Id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<NullableResponse<GenerateDetailedCostReportOperationResultResource>> GetIfExistsAsync(WaitUntil waitUntil, string operationId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(operationId, nameof(operationId));
            using DiagnosticScope scope = _generateDetailedCostReportOperationResultsClientDiagnostics.CreateScope("GenerateDetailedCostReportOperationResultCollection.GetIfExists");
            scope.Start();
            try
            {
                var operation = await GetAsync(waitUntil, operationId, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(operation.Value, operation.GetRawResponse());
            }
            catch (RequestFailedException ex) when (ex.Status == 404)
            {
                return new NoValueResponse<GenerateDetailedCostReportOperationResultResource>(ex.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> for LRO completion. </param>
        /// <param name="operationId"> The target operation Id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual NullableResponse<GenerateDetailedCostReportOperationResultResource> GetIfExists(WaitUntil waitUntil, string operationId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(operationId, nameof(operationId));
            using DiagnosticScope scope = _generateDetailedCostReportOperationResultsClientDiagnostics.CreateScope("GenerateDetailedCostReportOperationResultCollection.GetIfExists");
            scope.Start();
            try
            {
                var operation = Get(waitUntil, operationId, cancellationToken);
                return Response.FromValue(operation.Value, operation.GetRawResponse());
            }
            catch (RequestFailedException ex) when (ex.Status == 404)
            {
                return new NoValueResponse<GenerateDetailedCostReportOperationResultResource>(ex.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
