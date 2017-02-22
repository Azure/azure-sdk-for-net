// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Test.Azure.Management.Logic
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Xunit;
    using Microsoft.Azure.Management.Logic;
    using Microsoft.Azure.Management.Logic.Models;
    using Microsoft.Rest.Azure;
    using Newtonsoft.Json;
    using System.IO;

    /// <summary>
    /// Scenario tests for the integration accounts session.
    /// </summary>
    [Collection("IntegrationAccountPartnerScenarioTests")]
    public class IntegrationAccountSessionScenarioTests : BaseScenarioTests
    {
        /// <summary>
        /// Name of the test class
        /// </summary>
        private const string TestClass = "Test.Azure.Management.Logic.IntegrationAccountSessionScenarioTests";

        /// <summary>
        /// Tests the create and delete operations of the integration account session.
        /// https://msazure.visualstudio.com/One/_workitems/edit/587947
        /// </summary>
        [Fact]
        public void CreateAndDeleteIntegrationAccountSession()
        {
            using (
                MockContext context = MockContext.Start(TestClass))
            {
                string integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                string integrationAccountSessionName =
                    TestUtilities.GenerateName(Constants.IntegrationAccountSessionPrefix);
                var client = context.GetServiceClient<LogicManagementClient>();
                var createdAccount = client.IntegrationAccounts.CreateOrUpdate(
                    Constants.DefaultResourceGroup,
                    integrationAccountName,
                    CreateIntegrationAccountInstance(integrationAccountName));

                var instance = CreateIntegrationAccountSessionInstance(integrationAccountSessionName, integrationAccountName);
                instance.Content = "256";

                var session = client.Sessions.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName, integrationAccountSessionName, instance);

                var getSession = client.Sessions.Get(Constants.DefaultResourceGroup,
                integrationAccountName,
                integrationAccountSessionName);

                Assert.Equal(getSession.Name, integrationAccountSessionName);
                Assert.Equal(getSession.Content, "256");
                
                client.Sessions.Delete(Constants.DefaultResourceGroup, integrationAccountName, integrationAccountSessionName);
                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);
            }
        }

        /// <summary>
        /// Tests the create and update operations of the integration account session.
        /// </summary>
        [Fact]
        public void CreateAndUpdateIntegrationAccountSession()
        {
            using (
                MockContext context = MockContext.Start(TestClass))
            {
                string integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                string integrationAccountSessionName =
                    TestUtilities.GenerateName(Constants.IntegrationAccountSessionPrefix);

                var client = context.GetServiceClient<LogicManagementClient>();

                var createdAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    CreateIntegrationAccountInstance(integrationAccountName));

                var session = client.Sessions.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName, integrationAccountSessionName,
                    CreateIntegrationAccountSessionInstance(integrationAccountSessionName, integrationAccountName));

                var updateSession = CreateIntegrationAccountSessionInstance(integrationAccountSessionName,
                    integrationAccountName);

                var updatedSession = client.Sessions.CreateOrUpdate(
                    Constants.DefaultResourceGroup,
                    integrationAccountName,
                    integrationAccountSessionName, updateSession);

                Assert.Equal(updatedSession.Name, integrationAccountSessionName);

                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);
            }
        }

        /// <summary>
        /// Tests the create and get operations of the integration account session.
        /// https://msazure.visualstudio.com/One/_workitems/edit/587947
        /// </summary>
        [Fact]
        public void CreateAndGetIntegrationAccountSession()
        {
            using (
                MockContext context = MockContext.Start(TestClass))
            {
                string integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                string integrationAccountSessionName =
                    TestUtilities.GenerateName(Constants.IntegrationAccountSessionPrefix);
                var client = context.GetServiceClient<LogicManagementClient>();

                var createdAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    CreateIntegrationAccountInstance(integrationAccountName));
                var instance = CreateIntegrationAccountSessionInstance(integrationAccountSessionName, integrationAccountName);

                instance.Content= "256";

                var session = client.Sessions.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName, integrationAccountSessionName, instance);

                Assert.Equal(session.Name, integrationAccountSessionName);

                var getSession = client.Sessions.Get(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    integrationAccountSessionName);

                Assert.Equal(session.Name, getSession.Name);
                Assert.Equal(session.Content, "256");

                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);
            }
        }

        /// <summary>
        /// Tests the create and list operations of the integration account session.
        /// </summary>
        [Fact]
        public void ListIntegrationAccountSessions()
        {
            using (
                MockContext context = MockContext.Start(TestClass))
            {

                var integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);

                var integrationAccountSessionName1 =
                    TestUtilities.GenerateName(Constants.IntegrationAccountSessionPrefix);
                var integrationAccountSessionName2 =
                    TestUtilities.GenerateName(Constants.IntegrationAccountSessionPrefix);
                var integrationAccountSessionName3 =
                    TestUtilities.GenerateName(Constants.IntegrationAccountSessionPrefix);

                var client = context.GetServiceClient<LogicManagementClient>();
                var createdAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    CreateIntegrationAccountInstance(integrationAccountName));

                client.Sessions.CreateOrUpdate(
                    Constants.DefaultResourceGroup,
                    integrationAccountName, integrationAccountSessionName1,
                    CreateIntegrationAccountSessionInstance(integrationAccountSessionName1, integrationAccountName));

                client.Sessions.CreateOrUpdate(
                    Constants.DefaultResourceGroup,
                    integrationAccountName, integrationAccountSessionName2,
                    CreateIntegrationAccountSessionInstance(integrationAccountSessionName2, integrationAccountName));

                client.Sessions.CreateOrUpdate(
                    Constants.DefaultResourceGroup,
                    integrationAccountName, integrationAccountSessionName3,
                    CreateIntegrationAccountSessionInstance(integrationAccountSessionName3, integrationAccountName));

                var sessions = client.Sessions.ListByIntegrationAccounts(Constants.DefaultResourceGroup, integrationAccountName);

                Assert.True(sessions.Count() == 3);

                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);

            }
        }

        /// <summary>
        /// Tests the delete operations of the integration account session with integration account. 
        /// Session must be deleted with the integration account deletion.
        /// </summary>
        [Fact]
        public void DeleteIntegrationAccountSessionOnAccountDeletion()
        {
            using (
                MockContext context = MockContext.Start(TestClass))
            {
                string integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                string integrationAccountSessionName =
                    TestUtilities.GenerateName(Constants.IntegrationAccountSessionPrefix);
                var client = context.GetServiceClient<LogicManagementClient>();
                var createdAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    CreateIntegrationAccountInstance(integrationAccountName));
                var session = client.Sessions.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName, integrationAccountSessionName,
                    CreateIntegrationAccountSessionInstance(integrationAccountSessionName, integrationAccountName));

                Assert.Equal(session.Name, integrationAccountSessionName);

                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);
                Assert.Throws<CloudException>(
                    () =>
                        client.Sessions.Get(Constants.DefaultResourceGroup, integrationAccountName,
                            integrationAccountSessionName));
            }
        }

        /// <summary>
        /// Tests the create operations of the integration account session using file input.
        /// </summary>
        [Fact]
        public void CreateIntegrationAccountSessionUsingFile()
        {
            using (
                MockContext context = MockContext.Start(TestClass))
            {
                var integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);

                var integrationAs2AccountSessionName =
                    TestUtilities.GenerateName(Constants.IntegrationAccountSessionPrefix);
                var integrationX12AccountSessionName =
                    TestUtilities.GenerateName(Constants.IntegrationAccountSessionPrefix);
                var integrationEdifactAccountSessionName =
                    TestUtilities.GenerateName(Constants.IntegrationAccountSessionPrefix);

                var client = context.GetServiceClient<LogicManagementClient>();

                var createdAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName, CreateIntegrationAccountInstance(integrationAccountName));

                var as2Session = client.Sessions.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName, integrationAs2AccountSessionName,
                    CreateIntegrationAccountSessionInstanceFromFile(integrationAs2AccountSessionName,
                        integrationAccountName));

                var edifactSession = client.Sessions.CreateOrUpdate(
                    Constants.DefaultResourceGroup,
                    integrationAccountName, integrationEdifactAccountSessionName,
                    CreateIntegrationAccountSessionInstanceFromFile(integrationEdifactAccountSessionName, integrationAccountName));

                var x12Session = client.Sessions.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName, integrationX12AccountSessionName,
                    CreateIntegrationAccountSessionInstanceFromFile(integrationX12AccountSessionName, integrationAccountName));

                Assert.Equal(as2Session.Name, integrationAs2AccountSessionName);
                Assert.Equal(edifactSession.Name, integrationEdifactAccountSessionName);
                Assert.Equal(x12Session.Name, integrationX12AccountSessionName);

                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);
            }
        }

        #region Private

        /// <summary>
        /// Creates an Integration account session
        /// </summary>
        /// <param name="integrationAccountSessionName">Name of the integration account session</param>
        /// <param name="integrationAccountName">Name of the integration account</param>
        /// <returns>Session instance</returns>
        private IntegrationAccountSession CreateIntegrationAccountSessionInstance(
            string integrationAccountSessionName,
            string integrationAccountName)
        {
            IDictionary<string, string> tags = new Dictionary<string, string>();
            tags.Add("IntegrationAccountSession", integrationAccountSessionName);

            var session = new IntegrationAccountSession
            {
                Location = Constants.DefaultLocation,
                Tags = tags,
                Content = "123"
            };

            return session;
        }

        /// <summary>
        /// Creates an Integration account session from file source
        /// </summary>
        /// <param name="integrationAccountSessionName">Name of the integration account session</param>
        /// <param name="integrationAccountName">Name of the integration account</param>        
        /// <returns>Session instance</returns>
        private IntegrationAccountSession CreateIntegrationAccountSessionInstanceFromFile(
            string integrationAccountSessionName,
            string integrationAccountName)
        {
            IDictionary<string, string> tags = new Dictionary<string, string>();
            tags.Add("IntegrationAccountSession", integrationAccountSessionName);

            var session = new IntegrationAccountSession
            {
                Location = Constants.DefaultLocation,
                Tags = tags,
                Content = "456"
            };

            return session;
        }

        #endregion Private
    }
}