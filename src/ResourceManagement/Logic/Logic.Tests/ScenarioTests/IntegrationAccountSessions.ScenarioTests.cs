// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Test.Azure.Management.Logic
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Azure.Management.Logic;
    using Microsoft.Azure.Management.Logic.Models;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Xunit;

    /// <summary>
    /// Scenario tests for the integration accounts session.
    /// </summary>
    [Collection("IntegrationAccountPartnerScenarioTests")]
    public class IntegrationAccountSessionScenarioTests : ScenarioTestsBase
    {
        /// <summary>
        /// Tests the create and delete operations of the integration account session.
        /// https://msazure.visualstudio.com/One/_workitems/edit/587947
        /// </summary>
        [Fact]
        public void CreateAndDeleteIntegrationAccountSession()
        {
            using (var context = MockContext.Start(className: this.testClassName))
            {
                var integrationAccountName = TestUtilities.GenerateName(prefix: Constants.IntegrationAccountPrefix);
                var integrationAccountSessionName = TestUtilities.GenerateName(prefix: Constants.IntegrationAccountSessionPrefix);
                var client = context.GetServiceClient<LogicManagementClient>();

                var createdAccount = client.IntegrationAccounts.CreateOrUpdate(
                    resourceGroupName: Constants.DefaultResourceGroup,
                    integrationAccountName: integrationAccountName,
                    integrationAccount: this.CreateIntegrationAccountInstance(integrationAccountName: integrationAccountName));

                var instance = this.CreateIntegrationAccountSessionInstanceWithoutLocation(
                    integrationAccountSessionName: integrationAccountSessionName,
                    integrationAccountName: integrationAccountName);
                instance.Content = "256";

                var session = client.Sessions.CreateOrUpdate(
                    resourceGroupName: Constants.DefaultResourceGroup,
                    integrationAccountName: integrationAccountName,
                    sessionName: integrationAccountSessionName,
                    session: instance);

                var getSession = client.Sessions.Get(
                    resourceGroupName: Constants.DefaultResourceGroup,
                    integrationAccountName: integrationAccountName,
                    sessionName: integrationAccountSessionName) as IntegrationAccountSession;

                Assert.Equal(expected: integrationAccountSessionName, actual: getSession.Name);
                Assert.Equal(expected: "256", actual: getSession.Content);

                // Deleting an existing record should return 200
                client.Sessions.Delete(
                    resourceGroupName: Constants.DefaultResourceGroup,
                    integrationAccountName: integrationAccountName,
                    sessionName: integrationAccountSessionName);

                // Deleting an absent record should not throw, RP returns 204
                client.Sessions.Delete(
                    resourceGroupName: Constants.DefaultResourceGroup,
                    integrationAccountName: integrationAccountName,
                    sessionName: integrationAccountSessionName);

                // Getting an absent record should not throw, RP returns 404 and error response
                var errorResponse = client.Sessions.Get(
                    resourceGroupName: Constants.DefaultResourceGroup,
                    integrationAccountName: integrationAccountName,
                    sessionName: integrationAccountSessionName) as ErrorResponse;
                Assert.NotNull(errorResponse);
                Assert.NotNull(errorResponse.Error);
                Assert.Equal(expected: "SessionNotFound", actual: errorResponse.Error.Code);
                Assert.Contains(expectedSubstring: "could not be found in integration account", actualString: errorResponse.Error.Message);

                // Clean-up the integration account.
                client.IntegrationAccounts.Delete(
                    resourceGroupName: Constants.DefaultResourceGroup,
                    integrationAccountName: integrationAccountName);
            }
        }

        /// <summary>
        /// Tests the create and update operations of the integration account session.
        /// </summary>
        [Fact]
        public void CreateAndUpdateIntegrationAccountSession()
        {
            using (var context = MockContext.Start(className: this.testClassName))
            {
                var integrationAccountName = TestUtilities.GenerateName(prefix: Constants.IntegrationAccountPrefix);
                var integrationAccountSessionName = TestUtilities.GenerateName(prefix: Constants.IntegrationAccountSessionPrefix);
                var client = context.GetServiceClient<LogicManagementClient>();

                var createdAccount = client.IntegrationAccounts.CreateOrUpdate(
                    resourceGroupName: Constants.DefaultResourceGroup,
                    integrationAccountName: integrationAccountName,
                    integrationAccount: this.CreateIntegrationAccountInstance(integrationAccountName: integrationAccountName));

                var session = client.Sessions.CreateOrUpdate(
                    resourceGroupName: Constants.DefaultResourceGroup,
                    integrationAccountName: integrationAccountName,
                    sessionName: integrationAccountSessionName,
                    session: this.CreateIntegrationAccountSessionInstanceWithoutLocation(
                        integrationAccountSessionName: integrationAccountSessionName,
                        integrationAccountName: integrationAccountName));

                var updateSession = this.CreateIntegrationAccountSessionInstanceWithoutLocation(
                    integrationAccountSessionName: integrationAccountSessionName,
                    integrationAccountName: integrationAccountName);
                updateSession.Content = "foobar_update";

                var updatedSession = client.Sessions.CreateOrUpdate(
                    resourceGroupName: Constants.DefaultResourceGroup,
                    integrationAccountName: integrationAccountName,
                    sessionName: integrationAccountSessionName,
                    session: updateSession);

                Assert.Equal(expected: integrationAccountSessionName, actual: updatedSession.Name);
                Assert.Equal(expected: "foobar_update", actual: updateSession.Content);

                client.IntegrationAccounts.Delete(
                    resourceGroupName: Constants.DefaultResourceGroup,
                    integrationAccountName: integrationAccountName);
            }
        }

        /// <summary>
        /// Tests the create and get operations of the integration account session.
        /// https://msazure.visualstudio.com/One/_workitems/edit/587947
        /// </summary>
        [Fact]
        public void CreateAndGetIntegrationAccountSession()
        {
            using (var context = MockContext.Start(className: this.testClassName))
            {
                var integrationAccountName = TestUtilities.GenerateName(prefix: Constants.IntegrationAccountPrefix);
                var integrationAccountSessionName = TestUtilities.GenerateName(prefix: Constants.IntegrationAccountSessionPrefix);
                var client = context.GetServiceClient<LogicManagementClient>();

                var createdAccount = client.IntegrationAccounts.CreateOrUpdate(
                    resourceGroupName: Constants.DefaultResourceGroup,
                    integrationAccountName: integrationAccountName,
                    integrationAccount: this.CreateIntegrationAccountInstance(integrationAccountName: integrationAccountName));
                var instance = this.CreateIntegrationAccountSessionInstanceWithoutLocation(
                    integrationAccountSessionName: integrationAccountSessionName,
                    integrationAccountName: integrationAccountName);
                instance.Content= "256";

                var session = client.Sessions.CreateOrUpdate(
                    resourceGroupName: Constants.DefaultResourceGroup,
                    integrationAccountName: integrationAccountName,
                    sessionName: integrationAccountSessionName,
                    session: instance);

                Assert.Equal(actual: session.Name, expected: integrationAccountSessionName);

                var getSession = client.Sessions.Get(
                    resourceGroupName: Constants.DefaultResourceGroup,
                    integrationAccountName: integrationAccountName,
                    sessionName: integrationAccountSessionName) as IntegrationAccountSession;

                Assert.Equal(session.Name, getSession.Name);
                Assert.Equal(session.Content, "256");

                client.IntegrationAccounts.Delete(
                    resourceGroupName: Constants.DefaultResourceGroup,
                    integrationAccountName: integrationAccountName);
            }
        }

        /// <summary>
        /// Tests the create and list operations of the integration account session.
        /// </summary>
        [Fact]
        public void ListIntegrationAccountSessions()
        {
            using (var context = MockContext.Start(className: this.testClassName))
            {

                var integrationAccountName = TestUtilities.GenerateName(prefix: Constants.IntegrationAccountPrefix);

                var integrationAccountSessionName1 = TestUtilities.GenerateName(prefix: Constants.IntegrationAccountSessionPrefix);
                var integrationAccountSessionName2 = TestUtilities.GenerateName(prefix: Constants.IntegrationAccountSessionPrefix);
                var integrationAccountSessionName3 = TestUtilities.GenerateName(prefix: Constants.IntegrationAccountSessionPrefix);

                var client = context.GetServiceClient<LogicManagementClient>();
                var createdAccount = client.IntegrationAccounts.CreateOrUpdate(
                    resourceGroupName: Constants.DefaultResourceGroup,
                    integrationAccountName: integrationAccountName,
                    integrationAccount: this.CreateIntegrationAccountInstance(integrationAccountName: integrationAccountName));

                client.Sessions.CreateOrUpdate(
                    resourceGroupName: Constants.DefaultResourceGroup,
                    integrationAccountName: integrationAccountName,
                    sessionName: integrationAccountSessionName1,
                    session: this.CreateIntegrationAccountSessionInstanceWithoutLocation(
                        integrationAccountSessionName: integrationAccountSessionName1,
                        integrationAccountName: integrationAccountName));

                client.Sessions.CreateOrUpdate(
                    resourceGroupName: Constants.DefaultResourceGroup,
                    integrationAccountName: integrationAccountName,
                    sessionName: integrationAccountSessionName2,
                    session: this.CreateIntegrationAccountSessionInstanceWithoutLocation(
                        integrationAccountSessionName: integrationAccountSessionName2,
                        integrationAccountName: integrationAccountName));

                client.Sessions.CreateOrUpdate(
                    resourceGroupName: Constants.DefaultResourceGroup,
                    integrationAccountName: integrationAccountName,
                    sessionName: integrationAccountSessionName3,
                    session: this.CreateIntegrationAccountSessionInstanceWithoutLocation(
                        integrationAccountSessionName: integrationAccountSessionName3,
                        integrationAccountName: integrationAccountName));

                var sessions = client.Sessions.ListByIntegrationAccounts(
                    resourceGroupName: Constants.DefaultResourceGroup,
                    integrationAccountName: integrationAccountName);

                Assert.True(sessions.Count() == 3);

                client.IntegrationAccounts.Delete(
                    resourceGroupName: Constants.DefaultResourceGroup,
                    integrationAccountName: integrationAccountName);
            }
        }

        /// <summary>
        /// Tests the delete operations of the integration account session with integration account. 
        /// Session must be deleted with the integration account deletion.
        /// </summary>
        [Fact]
        public void DeleteIntegrationAccountSessionOnAccountDeletion()
        {
            using (var context = MockContext.Start(className: this.testClassName))
            {
                var integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                var integrationAccountSessionName = TestUtilities.GenerateName(Constants.IntegrationAccountSessionPrefix);
                var client = context.GetServiceClient<LogicManagementClient>();

                var createdAccount = client.IntegrationAccounts.CreateOrUpdate(
                    resourceGroupName: Constants.DefaultResourceGroup,
                    integrationAccountName: integrationAccountName,
                    integrationAccount: this.CreateIntegrationAccountInstance(integrationAccountName: integrationAccountName));
                var session = client.Sessions.CreateOrUpdate(
                    resourceGroupName: Constants.DefaultResourceGroup,
                    integrationAccountName: integrationAccountName,
                    sessionName: integrationAccountSessionName,
                    session: this.CreateIntegrationAccountSessionInstanceWithoutLocation(
                        integrationAccountSessionName: integrationAccountSessionName,
                        integrationAccountName: integrationAccountName));

                Assert.Equal(actual: session.Name, expected: integrationAccountSessionName);

                client.IntegrationAccounts.Delete(
                    resourceGroupName: Constants.DefaultResourceGroup,
                    integrationAccountName: integrationAccountName);
                var errorResponse = client.Sessions
                        .Get(
                            resourceGroupName: Constants.DefaultResourceGroup,
                            integrationAccountName: integrationAccountName,
                            sessionName: integrationAccountSessionName) as ErrorResponse;
                Assert.NotNull(errorResponse);
                Assert.NotNull(errorResponse.Error);
                Assert.Equal(expected: "ResourceNotFound", actual: errorResponse.Error.Code);
                Assert.Contains(expectedSubstring: "under resource group 'flowrg' was not found.", actualString: errorResponse.Error.Message);
            }
        }

        /// <summary>
        /// Tests the create operations of the integration account session using file input.
        /// </summary>
        [Fact]
        public void CreateIntegrationAccountSessionUsingFile()
        {
            using (var context = MockContext.Start(className: this.testClassName))
            {
                var integrationAccountName = TestUtilities.GenerateName(prefix: Constants.IntegrationAccountPrefix);
                var integrationAs2AccountSessionName =TestUtilities.GenerateName(prefix: Constants.IntegrationAccountSessionPrefix);
                var integrationX12AccountSessionName = TestUtilities.GenerateName(prefix: Constants.IntegrationAccountSessionPrefix);
                var integrationEdifactAccountSessionName = TestUtilities.GenerateName(prefix: Constants.IntegrationAccountSessionPrefix);
                var client = context.GetServiceClient<LogicManagementClient>();

                var createdAccount = client.IntegrationAccounts.CreateOrUpdate(
                    resourceGroupName: Constants.DefaultResourceGroup,
                    integrationAccountName: integrationAccountName,
                    integrationAccount: this.CreateIntegrationAccountInstance(integrationAccountName: integrationAccountName));

                var as2Session = client.Sessions.CreateOrUpdate(
                    resourceGroupName: Constants.DefaultResourceGroup,
                    integrationAccountName: integrationAccountName,
                    sessionName: integrationAs2AccountSessionName,
                    session: this.CreateIntegrationAccountSessionInstanceWithLocation(
                        integrationAccountSessionName: integrationAs2AccountSessionName,
                        integrationAccountName: integrationAccountName));

                var edifactSession = client.Sessions.CreateOrUpdate(
                    resourceGroupName: Constants.DefaultResourceGroup,
                    integrationAccountName: integrationAccountName,
                    sessionName: integrationEdifactAccountSessionName,
                    session: this.CreateIntegrationAccountSessionInstanceWithLocation(
                        integrationAccountSessionName: integrationEdifactAccountSessionName,
                        integrationAccountName: integrationAccountName));

                var x12Session = client.Sessions.CreateOrUpdate(
                    resourceGroupName: Constants.DefaultResourceGroup,
                    integrationAccountName: integrationAccountName,
                    sessionName: integrationX12AccountSessionName,
                    session: this.CreateIntegrationAccountSessionInstanceWithLocation(
                        integrationAccountSessionName: integrationX12AccountSessionName,
                        integrationAccountName: integrationAccountName));

                Assert.Equal(actual: as2Session.Name, expected: integrationAs2AccountSessionName);
                Assert.Equal(actual: edifactSession.Name, expected: integrationEdifactAccountSessionName);
                Assert.Equal(actual: x12Session.Name, expected: integrationX12AccountSessionName);

                client.IntegrationAccounts.Delete(
                    resourceGroupName: Constants.DefaultResourceGroup,
                    integrationAccountName: integrationAccountName);
            }
        }

        #region Private

        /// <summary>
        /// Creates an Integration account session without the location property
        /// </summary>
        /// <param name="integrationAccountSessionName">Name of the integration account session</param>
        /// <param name="integrationAccountName">Name of the integration account</param>
        /// <returns>Session instance</returns>
        private IntegrationAccountSession CreateIntegrationAccountSessionInstanceWithoutLocation(
            string integrationAccountSessionName,
            string integrationAccountName)
        {
            var tags = new Dictionary<string, string>();
            tags.Add("IntegrationAccountSession", integrationAccountSessionName);

            var session = new IntegrationAccountSession
            {
                Tags = tags,
                Content = "123"
            };

            return session;
        }

        /// <summary>
        /// Creates an Integration account session with the location property
        /// </summary>
        /// <param name="integrationAccountSessionName">Name of the integration account session</param>
        /// <param name="integrationAccountName">Name of the integration account</param>        
        /// <returns>Session instance</returns>
        private IntegrationAccountSession CreateIntegrationAccountSessionInstanceWithLocation(
            string integrationAccountSessionName,
            string integrationAccountName)
        {
            var tags = new Dictionary<string, string>();
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