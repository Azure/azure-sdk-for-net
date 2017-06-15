// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Graph.RBAC.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using System;
using System.Linq;

namespace ManageUsersGroupsAndRoles
{
    public class Program
    {
        /**
         * Azure Users, Groups and Roles sample.
         * - List users
         * - Get user by email
         * - Assign role to AD user
         * - Revoke role from AD user
         * - Get role by scope and role name
         * - List roles
         * - List Active Directory groups.
         */
        public static void RunSample(Azure.IAuthenticated authenticated)
        {
            string subscriptionId = authenticated.Subscriptions.List().First().SubscriptionId;
            Utilities.Log("Selected subscription: " + subscriptionId);
            string raName1 = SdkContext.RandomGuid();
            // ============================================================
            // List users

            var users = authenticated.ActiveDirectoryUsers.List();
            Utilities.Log("Active Directory Users:");
            foreach (var user in users)
            {
                Utilities.Print(user);
            }

            // ============================================================
            // Get user by email

            IActiveDirectoryUser adUser = authenticated.ActiveDirectoryUsers.GetByName("admin@azuresdkteam.onmicrosoft.com");
            Utilities.Log("Found User with email \"admin@azuresdkteam.onmicrosoft.com\": ");
            Utilities.Print(adUser);

            // ============================================================
            // Assign role to AD user

            IRoleAssignment roleAssignment1 = authenticated.RoleAssignments
                .Define(raName1)
                .ForUser(adUser)
                .WithBuiltInRole(BuiltInRole.DnsZoneContributor)
                .WithSubscriptionScope(subscriptionId)
                .Create();
            Utilities.Log("Created Role Assignment:");
            Utilities.Print(roleAssignment1);

            // ============================================================
            // Revoke role from AD user

            authenticated.RoleAssignments.DeleteById(roleAssignment1.Id);
            Utilities.Log("Revoked Role Assignment: " + roleAssignment1.Id);

            // ============================================================
            // Get role by scope and role name

            IRoleDefinition roleDefinition = authenticated.RoleDefinitions
                .GetByScopeAndRoleName("subscriptions/" + subscriptionId, "Contributor");
            Utilities.Print(roleDefinition);

            // ============================================================
            // List roles

            var roles = authenticated.RoleDefinitions
                .ListByScope("subscriptions/" + subscriptionId);
            Utilities.Log("Roles: ");
            foreach (var role in roles)
            {
                Utilities.Print(role);
            }

            // ============================================================
            // List Active Directory groups

            var groups = authenticated.ActiveDirectoryGroups.List();
            Utilities.Log("Active Directory Groups:");
            foreach (var group in groups)
            {
                Utilities.Print(group);
            }
        }

        public static void Main(string[] args)
        {
            try
            {
                //=================================================================
                // Authenticate
                AzureCredentials credentials = SdkContext.AzureCredentialsFactory.FromFile(Environment.GetEnvironmentVariable("AZURE_AUTH_LOCATION"));

                var authenticated = Azure
                    .Configure()
                    .WithLogLevel(HttpLoggingDelegatingHandler.Level.Basic)
                    .Authenticate(credentials);

                RunSample(authenticated);
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Utilities.Log(ex);
                Console.ReadLine();
            }
        }
    }
}
