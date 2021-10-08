// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.Analytics.Synapse.AccessControl
{
    public partial class RoleAssignmentsClient
    {
        public virtual Response<RoleAssignmentDetails> GetRoleAssignmentById(string roleAssignmentId)
        {
            RequestOptions options = new RequestOptions();
            Response response = GetRoleAssignmentById(roleAssignmentId, options);
            return Response.FromValue((RoleAssignmentDetails)response, response);
        }
    }
}
