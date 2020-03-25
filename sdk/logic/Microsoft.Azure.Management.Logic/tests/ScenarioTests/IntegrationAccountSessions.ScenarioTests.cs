// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Test.Azure.Management.Logic
{
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
    public class IntegrationAccountSessionScenarioTests : ScenarioTestsBase
    {
        [Fact]
        public void IntegrationAccountSessions_Create_OK()
        {
            using (var context = MockContext.Start(this.TestClassType))
            {
                var client = this.GetClient(context);
                this.CleanResourceGroup(client);
                var integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                var integrationAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    this.CreateIntegrationAccount(integrationAccountName));

                var sessionName = TestUtilities.GenerateName(Constants.IntegrationAccountSessionPrefix);
                var session = this.CreateIntegrationAccountSession(sessionName);
                var createdSession = client.IntegrationAccountSessions.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    sessionName,
                    session);

                this.ValidateSession(session, createdSession);

                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);
            }
        }

        [Fact]
        public void IntegrationAccountSessions_Get_OK()
        {
            using (var context = MockContext.Start(this.TestClassType))
            {
                var client = this.GetClient(context);
                this.CleanResourceGroup(client);
                var integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                var integrationAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    this.CreateIntegrationAccount(integrationAccountName));

                var sessionName = TestUtilities.GenerateName(Constants.IntegrationAccountSessionPrefix);
                var session = this.CreateIntegrationAccountSession(sessionName);
                var createdSession = client.IntegrationAccountSessions.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    sessionName,
                    session);

                var retrievedSession = client.IntegrationAccountSessions.Get(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    sessionName);

                this.ValidateSession(session, retrievedSession);

                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);
            }
        }

        [Fact]
        public void IntegrationAccountSessions_List_OK()
        {
            using (var context = MockContext.Start(this.TestClassType))
            {
                var client = this.GetClient(context);
                this.CleanResourceGroup(client);
                var integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                var integrationAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    this.CreateIntegrationAccount(integrationAccountName));

                var sessionName1 = TestUtilities.GenerateName(Constants.IntegrationAccountSessionPrefix);
                var session1 = this.CreateIntegrationAccountSession(sessionName1);
                var createdSession = client.IntegrationAccountSessions.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    sessionName1,
                    session1);

                var sessionName2 = TestUtilities.GenerateName(Constants.IntegrationAccountSessionPrefix);
                var session2 = this.CreateIntegrationAccountSession(sessionName2);
                var createdSession2 = client.IntegrationAccountSessions.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    sessionName2,
                    session2);

                var sessionName3 = TestUtilities.GenerateName(Constants.IntegrationAccountSessionPrefix);
                var session3 = this.CreateIntegrationAccountSession(sessionName3);
                var createdSession3 = client.IntegrationAccountSessions.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    sessionName3,
                    session3);

                var sessions = client.IntegrationAccountSessions.List(Constants.DefaultResourceGroup, integrationAccountName);

                Assert.Equal(3, sessions.Count());
                this.ValidateSession(session1, sessions.Single(x => x.Name == session1.Name));
                this.ValidateSession(session2, sessions.Single(x => x.Name == session2.Name));
                this.ValidateSession(session3, sessions.Single(x => x.Name == session3.Name));

                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);
            }
        }

        [Fact]
        public void IntegrationAccountSessions_Update_OK()
        {
            using (var context = MockContext.Start(this.TestClassType))
            {
                var client = this.GetClient(context);
                this.CleanResourceGroup(client);
                var integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                var integrationAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    this.CreateIntegrationAccount(integrationAccountName));

                var sessionName = TestUtilities.GenerateName(Constants.IntegrationAccountSessionPrefix);
                var session = this.CreateIntegrationAccountSession(sessionName);
                var createdSession = client.IntegrationAccountSessions.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    sessionName,
                    session);

                var newSession = this.CreateIntegrationAccountSession(sessionName);
                var updatedSession = client.IntegrationAccountSessions.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    sessionName,
                    newSession);

                this.ValidateSession(newSession, updatedSession);

                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);
            }
        }

        [Fact]
        public void IntegrationAccountSessions_Delete_OK()
        {
            using (var context = MockContext.Start(this.TestClassType))
            {
                var client = this.GetClient(context);
                this.CleanResourceGroup(client);
                var integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                var integrationAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    this.CreateIntegrationAccount(integrationAccountName));

                var sessionName = TestUtilities.GenerateName(Constants.IntegrationAccountSessionPrefix);
                var session = this.CreateIntegrationAccountSession(sessionName);
                var createdSession = client.IntegrationAccountSessions.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    sessionName,
                    session);

                client.IntegrationAccountSessions.Delete(Constants.DefaultResourceGroup, integrationAccountName, sessionName);
                Assert.Throws<CloudException>(() => client.IntegrationAccountSessions.Get(Constants.DefaultResourceGroup, integrationAccountName, sessionName));

                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);
            }
        }

        [Fact]
        public void IntegrationAccountSessions_DeleteWhenDeleteIntegrationAccount_OK()
        {
            using (var context = MockContext.Start(this.TestClassType))
            {
                var client = this.GetClient(context);
                this.CleanResourceGroup(client);
                var integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                var integrationAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    this.CreateIntegrationAccount(integrationAccountName));

                var sessionName = TestUtilities.GenerateName(Constants.IntegrationAccountSessionPrefix);
                var session = this.CreateIntegrationAccountSession(sessionName);
                var createdSession = client.IntegrationAccountSessions.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    sessionName,
                    session);

                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);
                Assert.Throws<CloudException>(() => client.IntegrationAccountSessions.Get(Constants.DefaultResourceGroup, integrationAccountName, sessionName));
            }
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
