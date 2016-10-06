// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Microsoft.Azure.Management.ResourceManager;

namespace Microsoft.Rest.Azure
{
    public static class PolicyClientExtensions
    {
        public static IPolicyClient GetPolicyClient(this IAzureContext context)
        {
           return PolicyClient.CreateClient(context);
        }

        public static IPolicyAssignmentsOperations GetPolicyAssignmentOperations(this IAzureContext context)
        {
            return context.GetPolicyClient().PolicyAssignments;
        }
        public static IPolicyDefinitionsOperations GetPolicyDefinitionsOperations(this IAzureContext context)
        {
            return context.GetPolicyClient().PolicyDefinitions;
        }
    }
}
