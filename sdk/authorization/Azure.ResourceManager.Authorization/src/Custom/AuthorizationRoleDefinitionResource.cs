// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// AutoRest mapped roleDefinitionId to ResourceIdentifier although the service parameter is a name string.
// This hidden obsolete overload preserves GA compatibility and forwards to the generated string API.
// The management generator intentionally emits resource DELETE operations without final results.
// The custom DELETE methods restore the shipped generic operation and use this resource instance as its result.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Authorization
{
    public partial class AuthorizationRoleDefinitionResource
    {
        /// <inheritdoc cref="CreateResourceIdentifier(string, string)"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("this method is deprecated and will be removed in a future version, please use CreateResourceIdentifier(string scope, string roleDefinitionId) instead.")]
        public static ResourceIdentifier CreateResourceIdentifier(string scope, ResourceIdentifier roleDefinitionId)
        {
            Argument.AssertNotNull(roleDefinitionId, nameof(roleDefinitionId));

            return CreateResourceIdentifier(scope, roleDefinitionId.ToString());
        }

        /// <summary>
        /// Deletes a role definition.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /{scope}/providers/Microsoft.Authorization/roleDefinitions/{roleDefinitionId}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> RoleDefinitions_Delete. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2022-05-01-preview. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="AuthorizationRoleDefinitionResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if the method should return after starting the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation<AuthorizationRoleDefinitionResource>> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _roleDefinitionsClientDiagnostics.CreateScope("AuthorizationRoleDefinitionResource.Delete");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _roleDefinitionsRestClient.CreateDeleteRequest(Id.Parent.ToString(), Id.Name, context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                RequestUriBuilder uri = message.Request.Uri;
                RehydrationToken rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Delete, uri.ToUri(), uri.ToString(), "None", null, OperationFinalStateVia.OriginalUri.ToString());
                AuthorizationArmOperation<AuthorizationRoleDefinitionResource> operation = new AuthorizationArmOperation<AuthorizationRoleDefinitionResource>(
                    Response.FromValue(this, response),
                    rehydrationToken);
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

        /// <summary>
        /// Deletes a role definition.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /{scope}/providers/Microsoft.Authorization/roleDefinitions/{roleDefinitionId}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> RoleDefinitions_Delete. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2022-05-01-preview. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="AuthorizationRoleDefinitionResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if the method should return after starting the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation<AuthorizationRoleDefinitionResource> Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _roleDefinitionsClientDiagnostics.CreateScope("AuthorizationRoleDefinitionResource.Delete");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _roleDefinitionsRestClient.CreateDeleteRequest(Id.Parent.ToString(), Id.Name, context);
                Response response = Pipeline.ProcessMessage(message, context);
                RequestUriBuilder uri = message.Request.Uri;
                RehydrationToken rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Delete, uri.ToUri(), uri.ToString(), "None", null, OperationFinalStateVia.OriginalUri.ToString());
                AuthorizationArmOperation<AuthorizationRoleDefinitionResource> operation = new AuthorizationArmOperation<AuthorizationRoleDefinitionResource>(
                    Response.FromValue(this, response),
                    rehydrationToken);
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
