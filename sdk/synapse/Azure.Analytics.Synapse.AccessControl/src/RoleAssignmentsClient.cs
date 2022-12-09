// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Analytics.Synapse.AccessControl
{
    public partial class RoleAssignmentsClient
    {
        public virtual Response<RoleAssignmentDetails> GetRoleAssignmentById(string roleAssignmentId)
        {
            Response response = GetRoleAssignmentById(roleAssignmentId, default);
            return Response.FromValue((RoleAssignmentDetails)response, response);
        }

        public virtual async Task<Response<RoleAssignmentDetails>> GetRoleAssignmentByIdAsync(string roleAssignmentId)
        {
            Response response = await GetRoleAssignmentByIdAsync(roleAssignmentId, default).ConfigureAwait(false);
            return Response.FromValue((RoleAssignmentDetails)response, response);
        }

        /// <summary> Check if the given principalId has access to perform list of actions at a given scope. </summary>
        /// <param name="checkAccessRequest"></param>
        public virtual Response<CheckPrincipalAccessResponse> CheckPrincipalAccess(CheckPrincipalAccessRequest checkAccessRequest)
        {
            Response response = CheckPrincipalAccess(checkAccessRequest, ContentType.ApplicationJson, default);
            return Response.FromValue((CheckPrincipalAccessResponse)response, response);
        }

        /// <summary> Check if the given principalId has access to perform list of actions at a given scope. </summary>
        /// <param name="checkAccessRequest"></param>
        public virtual async Task<Response<CheckPrincipalAccessResponse>> CheckPrincipalAccessAsync(CheckPrincipalAccessRequest checkAccessRequest)
        {
            Response response = await CheckPrincipalAccessAsync(checkAccessRequest, ContentType.ApplicationJson, default).ConfigureAwait(false);
            return Response.FromValue((CheckPrincipalAccessResponse)response, response);
        }
    }
}
