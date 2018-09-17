// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Test.Azure.Management.Logic
{
    using System;
    using System.Linq;
    using Microsoft.Azure.Management.Logic;
    using Microsoft.Azure.Management.Logic.Models;
    using Microsoft.Rest.Azure;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Xunit;

    /// <summary>
    /// Scenario tests for the integration accounts session.
    /// </summary>
    [Collection("IntegrationAccountPartnerScenarioTests")]
    public class IntegrationAccountSessionScenarioTests : ScenarioTestsBase, IDisposable
    {
        private readonly MockContext context;
        private readonly ILogicManagementClient client;
        private readonly string integrationAccountName;
        private readonly IntegrationAccount integrationAccount;
        private readonly string sessionName;

        public IntegrationAccountSessionScenarioTests()
        {
            this.context = MockContext.Start(className: this.TestClassName);
            this.client = this.GetClient(this.context);

            this.integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
            this.integrationAccount = this.client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                this.CreateIntegrationAccount(this.integrationAccountName));

            this.sessionName = TestUtilities.GenerateName(prefix: Constants.IntegrationAccountSessionPrefix);
        }

        public void Dispose()
        {
            this.client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, this.integrationAccountName);

            this.client.Dispose();
            this.context.Dispose();
        }

        [Fact]
        public void IntegrationAccountSessions_Create_OK()
        {
            var session = this.CreateIntegrationAccountSession(this.sessionName);
            var createdSession = this.client.IntegrationAccountSessions.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                this.sessionName,
                session);

            this.ValidateSession(session, createdSession);
        }

        [Fact]
        public void IntegrationAccountSessions_Get_OK()
        {
            var session = this.CreateIntegrationAccountSession(this.sessionName);
            var createdSession = this.client.IntegrationAccountSessions.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                this.sessionName,
                session);

            var retrievedSession = this.client.IntegrationAccountSessions.Get(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                this.sessionName);

            this.ValidateSession(session, retrievedSession);
        }

        [Fact]
        public void IntegrationAccountSessions_List_OK()
        {
            var session1 = this.CreateIntegrationAccountSession(this.sessionName);
            var createdSession = this.client.IntegrationAccountSessions.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                this.sessionName,
                session1);

            var sessionName2 = TestUtilities.GenerateName(Constants.IntegrationAccountSessionPrefix);
            var session2 = this.CreateIntegrationAccountSession(sessionName2);
            var createdSession2 = this.client.IntegrationAccountSessions.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                sessionName2,
                session2);

            var sessionName3 = TestUtilities.GenerateName(Constants.IntegrationAccountSessionPrefix);
            var session3 = this.CreateIntegrationAccountSession(sessionName3);
            var createdSession3 = this.client.IntegrationAccountSessions.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                sessionName3,
                session3);

            var sessions = this.client.IntegrationAccountSessions.List(Constants.DefaultResourceGroup, this.integrationAccountName);

            Assert.Equal(3, sessions.Count());
            this.ValidateSession(session1, sessions.Single(x => x.Name == session1.Name));
            this.ValidateSession(session2, sessions.Single(x => x.Name == session2.Name));
            this.ValidateSession(session3, sessions.Single(x => x.Name == session3.Name));
        }

        [Fact]
        public void IntegrationAccountSessions_Update_OK()
        {
            var session = this.CreateIntegrationAccountSession(this.sessionName);
            var createdSession = this.client.IntegrationAccountSessions.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                this.sessionName,
                session);

            var newSession = this.CreateIntegrationAccountSession(this.sessionName);
            var updatedSession = this.client.IntegrationAccountSessions.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                this.sessionName,
                newSession);

            this.ValidateSession(newSession, updatedSession);
        }

        [Fact]
        public void IntegrationAccountSessions_Delete_OK()
        {
            var session = this.CreateIntegrationAccountSession(this.sessionName);
            var createdSession = this.client.IntegrationAccountSessions.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                this.sessionName,
                session);

            this.client.IntegrationAccountSessions.Delete(Constants.DefaultResourceGroup, this.integrationAccountName, this.sessionName);
            Assert.Throws<CloudException>(() => this.client.IntegrationAccountSessions.Get(Constants.DefaultResourceGroup, this.integrationAccountName, this.sessionName));
        }

        [Fact]
        public void IntegrationAccountSessions_DeleteWhenDeleteIntegrationAccount_OK()
        {
            var session = this.CreateIntegrationAccountSession(this.sessionName);
            var createdSession = this.client.IntegrationAccountSessions.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                this.sessionName,
                session);

            this.client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, this.integrationAccountName);
            Assert.Throws<CloudException>(() => this.client.IntegrationAccountSessions.Get(Constants.DefaultResourceGroup, this.integrationAccountName, this.sessionName));
        }

        #region Private

        private void ValidateSession(IntegrationAccountSession expected, IntegrationAccountSession actual)
        {
            Assert.Equal(expected.Name, actual.Name);
            Assert.Equal(expected.Content, actual.Content);
            Assert.NotNull(actual.CreatedTime);
            Assert.NotNull(actual.ChangedTime);
        }

        private IntegrationAccountSession CreateIntegrationAccountSession(string sessionName)
        {
            return new IntegrationAccountSession(
                name: sessionName,
                location: Constants.DefaultLocation,
                content: "456");
        }

        #endregion Private
    }
}