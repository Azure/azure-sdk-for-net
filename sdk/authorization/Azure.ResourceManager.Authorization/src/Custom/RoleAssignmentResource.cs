// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// The management generator intentionally emits resource DELETE operations without final results.
// The custom DELETE methods retain the previously shipped generic ArmOperation<TResource> surface.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Authorization
{
    [CodeGenSuppress("Delete", typeof(WaitUntil), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("DeleteAsync", typeof(WaitUntil), typeof(string), typeof(CancellationToken))]
    public partial class RoleAssignmentResource
    {
        /// <summary>
        /// Delete a role assignment by scope and name.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /{scope}/providers/Microsoft.Authorization/roleAssignments/{roleAssignmentName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> RoleAssignments_Delete. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2022-04-01. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="RoleAssignmentResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if the method should return after starting the operation. </param>
        /// <param name="tenantId"> Tenant ID for cross-tenant request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation<RoleAssignmentResource>> DeleteAsync(WaitUntil waitUntil, string tenantId = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _roleAssignmentsClientDiagnostics.CreateScope("RoleAssignmentResource.Delete");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _roleAssignmentsRestClient.CreateDeleteRequest(Id.Parent.ToString(), Id.Name, tenantId, context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                RequestUriBuilder uri = message.Request.Uri;
                RehydrationToken rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Delete, uri.ToUri(), uri.ToString(), "None", null, OperationFinalStateVia.OriginalUri.ToString());
                AuthorizationArmOperation<RoleAssignmentResource> operation = new AuthorizationArmOperation<RoleAssignmentResource>(
                    Response.FromValue(CreateDeleteResult(response), response),
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
        /// Delete a role assignment by scope and name.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /{scope}/providers/Microsoft.Authorization/roleAssignments/{roleAssignmentName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> RoleAssignments_Delete. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2022-04-01. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="RoleAssignmentResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if the method should return after starting the operation. </param>
        /// <param name="tenantId"> Tenant ID for cross-tenant request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation<RoleAssignmentResource> Delete(WaitUntil waitUntil, string tenantId = default, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _roleAssignmentsClientDiagnostics.CreateScope("RoleAssignmentResource.Delete");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _roleAssignmentsRestClient.CreateDeleteRequest(Id.Parent.ToString(), Id.Name, tenantId, context);
                Response response = Pipeline.ProcessMessage(message, context);
                RequestUriBuilder uri = message.Request.Uri;
                RehydrationToken rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Delete, uri.ToUri(), uri.ToString(), "None", null, OperationFinalStateVia.OriginalUri.ToString());
                AuthorizationArmOperation<RoleAssignmentResource> operation = new AuthorizationArmOperation<RoleAssignmentResource>(
                    Response.FromValue(CreateDeleteResult(response), response),
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

        private RoleAssignmentResource CreateDeleteResult(Response response)
        {
            // A successful DELETE can return the deleted resource or an empty 204 response. Preserve
            // returned data when present; otherwise return an identity-only resource without fabricating data.
            if (response.Content?.ToMemory().Length > 0)
            {
                RoleAssignmentData data = RoleAssignmentData.FromResponse(response);
                return new RoleAssignmentResource(Client, data);
            }

            return new RoleAssignmentResource(Client, Id);
        }
    }
}
