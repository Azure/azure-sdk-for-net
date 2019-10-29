// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Blueprint
{
    public static class Constants
    {
        public static class ResourceScopes
        {
            public const string SubscriptionScope = "/subscriptions/{0}";
            public const string ManagementGroupScope = "/providers/Microsoft.Management/managementGroups/{0}";

        }

        /// <summary>
        /// Allowed target scope of blueprint.
        /// </summary>
        public static class BlueprintTargetScopes
        {
            public const string Subscription = "subscription";
        }

        /// <summary>
        /// allowed parameter types, align with Azure Resource Template
        /// </summary>
        public static class ParameterDefinitionTypes
        {
            public const string String = "string";
            public const string Int = "int";
            public const string Array = "array";
            public const string Bool = "bool";
            public const string Object = "object";
            public const string SecureString = "secureString";
            public const string SecureObject = "secureObject";
        }

        public static class ManagedServiceIdentityType
        {
            public const string SystemAssigned = "SystemAssigned";
        }

        public static class AssignmentProvisioningState
        {
            public const string Creating = "Creating";
            public const string Validating = "Validating";
            public const string Waiting = "Waiting";
            public const string Deploying = "Deploying";
            public const string Succeeded = "Succeeded";
            public const string Failed = "Failed";
            public const string Canceled = "Canceled";
            public const string Locking = "Locking";
            public const string Deleting = "Deleting";

        }
    }
}
