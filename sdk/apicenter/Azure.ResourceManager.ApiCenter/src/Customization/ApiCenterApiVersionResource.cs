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
     * Backward-compatibility shim for the ApiCenterApiVersionResource.
     *
     * In the 1.0.0 GA release (AutoRest-generated), this resource class had Head/HeadAsync
     * methods as generated self-check operations returning Response<bool> with no parameters
     * (besides CancellationToken).
     *
     * After migrating to the TypeSpec MPG generator, the generator produces a different Head method:
     * Head(string definitionName, CancellationToken) that checks if a child definition exists,
     * returning Response instead of Response<bool>. This is a parent-check pattern, not self-check.
     *
     * These custom methods preserve the parameterless self-check Head/HeadAsync with Response<bool>
     * return type for 1.0.0 GA backward compatibility. They coexist with the generated
     * Head(string definitionName) overload as different method signatures.
     * issue link: https://github.com/Azure/azure-sdk-for-net/issues/56996
     */
    public partial class ApiCenterApiVersionResource
    {
        /// <summary>
        /// Checks if specified API version exists.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiCenter/services/{serviceName}/workspaces/{workspaceName}/apis/{apiName}/versions/{versionName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ApiVersions_Head</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-03-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ApiCenterApiVersionResource"/></description>
        /// </item>
        /// </list>
        /// <para>Backward-compat: In old AutoRest-generated code this was a generated method.
        /// Note: The new MPG generator generates Head(string definitionName) for child-checking;
        /// this parameterless overload is the old self-check pattern.</para>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<bool>> HeadAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _apiVersionsClientDiagnostics.CreateScope("ApiCenterApiVersionResource.Head");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken,
                    ErrorOptions = ErrorOptions.NoThrow
                };
                HttpMessage message = _apiVersionsRestClient.CreateHeadApiVersionRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Parent.Parent.Name, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, context);
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
        /// Checks if specified API version exists.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiCenter/services/{serviceName}/workspaces/{workspaceName}/apis/{apiName}/versions/{versionName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ApiVersions_Head</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-03-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ApiCenterApiVersionResource"/></description>
        /// </item>
        /// </list>
        /// <para>Backward-compat: same as HeadAsync above, synchronous version.</para>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<bool> Head(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _apiVersionsClientDiagnostics.CreateScope("ApiCenterApiVersionResource.Head");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken,
                    ErrorOptions = ErrorOptions.NoThrow
                };
                HttpMessage message = _apiVersionsRestClient.CreateHeadApiVersionRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Parent.Parent.Parent.Name, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, context);
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
