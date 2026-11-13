// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager.ApiCenter
{
    /*
     * Backward-compatibility shim for the ApiCenterApiResource.
     *
     * In the 1.0.0 GA release (AutoRest-generated), this resource class had Head/HeadAsync
     * methods as generated self-check operations returning Response<bool>.
     *
     * After migrating to the TypeSpec MPG generator, HEAD operations are no longer generated
     * as self-check methods on the resource itself. Instead, the generator places them on the
     * parent resource (e.g., HeadApi(string apiName) on ApiCenterWorkspaceResource) and returns
     * Response instead of Response<bool>.
     *
     * These custom methods preserve the 1.0.0 GA public API surface for backward compatibility.
     * issue link: https://github.com/Azure/azure-sdk-for-net/issues/56996
     */
    public partial class ApiCenterApiResource
    {
        /// <summary>
        /// Checks if specified API exists.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiCenter/services/{serviceName}/workspaces/{workspaceName}/apis/{apiName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Apis_Head</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-03-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ApiCenterApiResource"/></description>
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
            using DiagnosticScope scope = _apisClientDiagnostics.CreateScope("ApiCenterApiResource.Head");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken,
                    ErrorOptions = ErrorOptions.NoThrow
                };
                HttpMessage message = _apisRestClient.CreateHeadApiRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, context);
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
        /// Checks if specified API exists.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiCenter/services/{serviceName}/workspaces/{workspaceName}/apis/{apiName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Apis_Head</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-03-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ApiCenterApiResource"/></description>
        /// </item>
        /// </list>
        /// <para>Backward-compat: same as HeadAsync above, synchronous version.</para>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<bool> Head(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _apisClientDiagnostics.CreateScope("ApiCenterApiResource.Head");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken,
                    ErrorOptions = ErrorOptions.NoThrow
                };
                HttpMessage message = _apisRestClient.CreateHeadApiRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, context);
                Response response = Pipeline.ProcessMessage(message, context);
                return Response.FromValue(response.Status != 404, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
