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
         * - Create a user
         * - Assign role to AD user
         * - Revoke role from AD user
         * - Get role by scope and role name
         * - Create service principal
         * - Assign role to service principal
         * - Create 2 Active Directory groups
         * - Add the user, the service principal, and the 1st group as members of the 2nd group
         */
        public static void RunSample(Azure.IAuthenticated authenticated)
        {
            string userEmail = Utilities.CreateRandomName("test");
            string userName = userEmail.Replace("test", "Test ");
            string spName = Utilities.CreateRandomName("sp");
            string raName1 = SdkContext.RandomGuid();
            string raName2 = SdkContext.RandomGuid();
            string groupEmail1 = Utilities.CreateRandomName("group1");
            string groupEmail2 = Utilities.CreateRandomName("group2");
            string groupName1 = groupEmail1.Replace("group1", "Group ");
            string groupName2 = groupEmail2.Replace("group2", "Group ");
            String spId = "";

            string subscriptionId = authenticated.Subscriptions.List().First().SubscriptionId;
            Utilities.Log("Selected subscription: " + subscriptionId);

            // ============================================================
            // Create a user

            Utilities.Log("Creating an Active Directory user " + userName + "...");

            var user = authenticated.ActiveDirectoryUsers
                .Define(userName)
                .WithEmailAlias(userEmail)
                .WithPassword("StrongPass!12")
                .Create();
            
            Utilities.Log("Created Active Directory user " + userName);
            Utilities.Print(user);

            // ============================================================
            // Assign role to AD user

            IRoleAssignment roleAssignment1 = authenticated.RoleAssignments
                .Define(raName1)
                .ForUser(user)
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
            // Create Service Principal

            IServicePrincipal sp = authenticated.ServicePrincipals.Define(spName)
                    .WithNewApplication("http://" + spName)
                    .Create();
            // wait till service principal created and propagated
            SdkContext.DelayProvider.Delay(15000);
            Utilities.Log("Created Service Principal:");
            Utilities.Print(sp);
            spId = sp.Id;

            // ============================================================
            // Assign role to Service Principal

            string defaultSubscription = authenticated.Subscriptions.List().First().SubscriptionId;

            IRoleAssignment roleAssignment2 = authenticated.RoleAssignments
                    .Define(raName2)
                    .ForServicePrincipal(sp)
                    .WithBuiltInRole(BuiltInRole.Contributor)
                    .WithSubscriptionScope(defaultSubscription)
                    .Create();
            Utilities.Log("Created Role Assignment:");
            Utilities.Print(roleAssignment2);

            // ============================================================
            // Create Active Directory groups

            Utilities.Log("Creating Active Directory group " + groupName1 + "...");
            var group1 = authenticated.ActiveDirectoryGroups
                    .Define(groupName1)
                    .WithEmailAlias(groupEmail1)
                    .Create();

            Utilities.Log("Created Active Directory group " + groupName1);
            Utilities.Print(group1);

            var group2 = authenticated.ActiveDirectoryGroups
                    .Define(groupName2)
                    .WithEmailAlias(groupEmail2)
                    .Create();

            Utilities.Log("Created Active Directory group " + groupName2);
            Utilities.Print(group2);

            Utilities.Log("Adding group members to group " + groupName2 + "...");
            group2.Update()
                .WithMember(user)
                .WithMember(sp)
                .WithMember(group1)
                .Apply();

            Utilities.Log("Group members added to group " + groupName2);
            Utilities.Print(group2);
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
