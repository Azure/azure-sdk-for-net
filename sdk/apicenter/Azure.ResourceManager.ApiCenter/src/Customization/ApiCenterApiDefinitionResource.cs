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
    /*
     * Backward-compatibility shim for the ApiCenterApiDefinitionResource.
     *
     * In the 1.0.0 GA release (AutoRest-generated), this resource class had:
     *   - Head/HeadAsync: self-check methods returning Response<bool> to test if the definition exists.
     *   - ImportSpecification/ImportSpecificationAsync: LRO returning non-generic ArmOperation.
     *
     * After migrating to the TypeSpec MPG generator:
     *   - HEAD operations are no longer generated as self-check methods on the resource itself.
     *     Instead, the generator places them on the parent resource (e.g., HeadAsync(string definitionName)
     *     on ApiCenterApiVersionResource) and returns Response instead of Response<bool>.
     *   - The import operation was renamed to ImportSpecificationWithResult and now returns
     *     ArmOperation<ApiCenterApiImportSuccess> due to the TypeSpec defining a typed response model.
     *
     * These custom methods preserve the 1.0.0 GA public API surface for backward compatibility.
     * issue link: https://github.com/Azure/azure-sdk-for-net/issues/56996
     */
    public partial class ApiCenterApiDefinitionResource
    {
        /// <summary>
        /// Checks if specified API definition exists.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiCenter/services/{serviceName}/workspaces/{workspaceName}/apis/{apiName}/versions/{versionName}/definitions/{definitionName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ApiDefinitions_Head</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-03-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ApiCenterApiDefinitionResource"/></description>
        /// </item>
        /// </list>
        /// <para>Backward-compat: In old AutoRest-generated code this was a generated method.
        /// The new MPG generator does not generate self-check HEAD on the resource itself,
        /// so this custom code manually sends the HEAD request and converts the HTTP status to bool.</para>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
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

        /// <summary>
        /// Checks if specified API definition exists.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiCenter/services/{serviceName}/workspaces/{workspaceName}/apis/{apiName}/versions/{versionName}/definitions/{definitionName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ApiDefinitions_Head</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-03-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ApiCenterApiDefinitionResource"/></description>
        /// </item>
        /// </list>
        /// <para>Backward-compat: same as HeadAsync above, synchronous version.</para>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
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

        /// <summary>
        /// Imports the API specification.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiCenter/services/{serviceName}/workspaces/{workspaceName}/apis/{apiName}/versions/{versionName}/definitions/{definitionName}/importSpecification</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ApiDefinitions_ImportSpecification</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-03-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ApiCenterApiDefinitionResource"/></description>
        /// </item>
        /// </list>
        /// <para>Backward-compat: In old AutoRest-generated code, this method returned non-generic ArmOperation.
        /// The new TypeSpec spec defines a typed response (ApiImportSuccess), so the generator creates
        /// ImportSpecificationWithResult returning ArmOperation&lt;ApiCenterApiImportSuccess&gt;.
        /// This custom method preserves the old ArmOperation return type for 1.0.0 GA API compatibility.</para>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> The content of the action request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
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
                HttpMessage message = _apiDefinitionsRestClient.CreateImportSpecificationRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Parent.Parent.Parent.Name, Id.Parent.Parent.Parent.Name, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, ApiSpecImportContent.ToRequestContent(content), context);
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

        /// <summary>
        /// Imports the API specification.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiCenter/services/{serviceName}/workspaces/{workspaceName}/apis/{apiName}/versions/{versionName}/definitions/{definitionName}/importSpecification</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ApiDefinitions_ImportSpecification</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-03-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ApiCenterApiDefinitionResource"/></description>
        /// </item>
        /// </list>
        /// <para>Backward-compat: same as ImportSpecificationAsync above, synchronous version.</para>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="content"> The content of the action request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
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
                HttpMessage message = _apiDefinitionsRestClient.CreateImportSpecificationRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Parent.Parent.Parent.Name, Id.Parent.Parent.Parent.Name, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, ApiSpecImportContent.ToRequestContent(content), context);
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
