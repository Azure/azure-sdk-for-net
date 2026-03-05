// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.ApiCenter.Models;

namespace Azure.ResourceManager.ApiCenter
{
    public partial class ApiCenterApiDefinitionResource
    {
        /// <summary> Checks if this resource exists. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<bool>> HeadAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _apiDefinitionsClientDiagnostics.CreateScope("ApiCenterApiDefinitionResource.Head");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken,
                    ErrorOptions = ErrorOptions.NoThrow
                };
                HttpMessage message = _apiDefinitionsRestClient.CreateHeadRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Parent.Parent.Parent.Name, Id.Parent.Parent.Parent.Name, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                return Response.FromValue(response.Status != 404, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Checks if this resource exists. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<bool> Head(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _apiDefinitionsClientDiagnostics.CreateScope("ApiCenterApiDefinitionResource.Head");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken,
                    ErrorOptions = ErrorOptions.NoThrow
                };
                HttpMessage message = _apiDefinitionsRestClient.CreateHeadRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Parent.Parent.Parent.Name, Id.Parent.Parent.Parent.Name, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, context);
                Response response = Pipeline.ProcessMessage(message, context);
                return Response.FromValue(response.Status != 404, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Imports the API specification. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation> ImportSpecificationAsync(WaitUntil waitUntil, ApiSpecImportContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using DiagnosticScope scope = _apiDefinitionsClientDiagnostics.CreateScope("ApiCenterApiDefinitionResource.ImportSpecification");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _apiDefinitionsRestClient.CreateImportSpecificationWithResultRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Parent.Parent.Parent.Name, Id.Parent.Parent.Parent.Name, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, ApiSpecImportContent.ToRequestContent(content), context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                ApiCenterArmOperation operation = new ApiCenterArmOperation(
                    _apiDefinitionsClientDiagnostics,
                    Pipeline,
                    message.Request,
                    response,
                    OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                {
                    await operation.WaitForCompletionResponseAsync(cancellationToken).ConfigureAwait(false);
                }
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Imports the API specification. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation ImportSpecification(WaitUntil waitUntil, ApiSpecImportContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using DiagnosticScope scope = _apiDefinitionsClientDiagnostics.CreateScope("ApiCenterApiDefinitionResource.ImportSpecification");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _apiDefinitionsRestClient.CreateImportSpecificationWithResultRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Parent.Parent.Parent.Name, Id.Parent.Parent.Parent.Name, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, ApiSpecImportContent.ToRequestContent(content), context);
                Response response = Pipeline.ProcessMessage(message, context);
                ApiCenterArmOperation operation = new ApiCenterArmOperation(
                    _apiDefinitionsClientDiagnostics,
                    Pipeline,
                    message.Request,
                    response,
                    OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                {
                    operation.WaitForCompletionResponse(cancellationToken);
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
