// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure;
using Microsoft.Azure.Management.Authorization;
using Microsoft.Azure.Management.Authorization.Models;
using Microsoft.Azure.Graph.RBAC;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Azure.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Management.Resources;
using Microsoft.Rest;
using System.Threading;
using Microsoft.Azure.Graph.RBAC.Models;
using Microsoft.Rest.Azure.OData;

namespace Authorization.Tests
{
    public class TestExecutionContext : GraphTestBase, IDisposable
    {
        private List<User> createdUsers;

        private List<ADGroup> createdGroups;

        private bool disposed = false;

        private GraphRbacManagementClient GraphClient { get; set; }

        public IReadOnlyCollection<User> Users
        {
            get
            {
                return this.createdUsers.AsReadOnly();
            }
        }

        public IReadOnlyCollection<ADGroup> Groups
        {
            get
            {
                return this.createdGroups.AsReadOnly();
            }
        }

        public TestExecutionContext()
        {
            HttpMockServer.RecordsDirectory = "SessionRecords";
            this.createdUsers = new List<User>();
            this.createdGroups = new List<ADGroup>();

            if (HttpMockServer.GetCurrentMode() == HttpRecorderMode.Record)
            {
                this.CleanupTestData(MockContext.Start(this.GetType()));
            }

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                this.GraphClient = (GetGraphClient(context));

                this.CreateGroups(context, 10);
                this.CreateUsers(context, 10);

                TestUtilities.Wait(1000 * 10);
            }
        }

        public ResourceManagementClient GetResourceManagementClient(MockContext context)
        {
            return context.GetServiceClient<ResourceManagementClient>();
        }

        public AuthorizationManagementClient GetAuthorizationManagementClient(MockContext context)
        {
            return context.GetServiceClient<AuthorizationManagementClient>();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            try
            {
                if (disposing)
                {
                    Cleanup();
                }
            }
            finally
            {
                disposed = true;
            }
        }

        private void Cleanup()
        {
        }

        private void CreateUsers(MockContext context, int number)
        {
            for (int i = 0; i < number; i++)
            {
                User user = CreateUser(context, "testUser" + i + Guid.NewGuid());
                this.createdUsers.Add(user);
            }
        }

        private void CreateGroups(MockContext context, int number)
        {
            for (int i = 0; i < number; i++)
            {
                ADGroup group = CreateGroup(context, "testGroup" + i + Guid.NewGuid());
                this.createdGroups.Add(group);
            }
        }

        internal void AddMemberToGroup(MockContext context, ADGroup groupId, User user)
        {
            AddMember(context, groupId, user);
        }

        private void CleanupTestData(MockContext context)
        {
            foreach (var user in this.createdUsers)
            {
                DeleteUser(context, user.ObjectId);
            }

            createdUsers.Clear();

            foreach (var group in this.createdGroups)
            {
                DeleteGroup(context, group.ObjectId);
            }

            createdGroups.Clear();
            foreach (var user in this.GraphClient.Users.List(new ODataQuery<User>(f => f.DisplayName.Contains("testUser"))))
            {
                DeleteUser(context, user.ObjectId);
            }

            foreach (var group in this.GraphClient.Groups.List(new ODataQuery<ADGroup>(f => f.DisplayName.Contains("testGroup"))))
            {
                DeleteGroup(context, group.ObjectId);
            }

            var env = TestEnvironmentFactory.GetTestEnvironment();
            var cred = env.TokenInfo[TokenAudience.Management];
            var authorizationClient = new AuthorizationManagementClient(
                TestEnvironmentFactory.GetTestEnvironment().BaseUri,
                cred);
            foreach (var assignment in authorizationClient.RoleAssignments.List(null))
            {
                if (assignment.Id.Contains(BasicTests.ResourceGroup))
                {
                    authorizationClient.RoleAssignments.DeleteById(assignment.Id);
                }
            }
        }
    }
}
