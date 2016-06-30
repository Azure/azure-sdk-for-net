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

    /// <summary>
    /// Scenario tests for the integration accounts partner.
    /// </summary>
    [Collection("IntegrationAccountPartnerScenarioTests")]
    public class IntegrationAccountPartnerScenarioTests : BaseScenarioTests
    {
        /// <summary>
        /// Name of the test class
        /// </summary>
        private const string TestClass = "Test.Azure.Management.Logic.IntegrationAccountPartnerScenarioTests";

        /// <summary>
        /// Tests the create and delete operations of the integration account partner.
        /// </summary>
        [Fact]
        public void CreateAndDeleteIntegrationAccountPartner()
        {
            using (
                MockContext context = MockContext.Start(TestClass))
            {
                string integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                string integrationAccountPartnerName =
                    TestUtilities.GenerateName(Constants.IntegrationAccountPartnerPrefix);
                var client = this.GetIntegrationAccountClient(context);
                var createdAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    CreateIntegrationAccountInstance(integrationAccountName));
                var partner = client.IntegrationAccountPartners.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName, integrationAccountPartnerName,
                    CreateIntegrationAccountPartnerInstance(integrationAccountPartnerName, integrationAccountName));

                Assert.Equal(partner.Name, integrationAccountPartnerName);

                client.IntegrationAccountPartners.Delete(Constants.DefaultResourceGroup, integrationAccountName,
                    integrationAccountPartnerName);
                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);
            }
        }

        /// <summary>
        /// Tests the delete operations of the integration account partner on integration account deletion.
        /// </summary>
        [Fact]
        public void DeleteIntegrationAccountPartnerOnAccountDeletion()
        {
            using (
                MockContext context = MockContext.Start(TestClass))
            {
                string integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                string integrationAccountPartnerName =
                    TestUtilities.GenerateName(Constants.IntegrationAccountPartnerPrefix);
                var client = this.GetIntegrationAccountClient(context);
                var createdAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    CreateIntegrationAccountInstance(integrationAccountName));
                var partner = client.IntegrationAccountPartners.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName, integrationAccountPartnerName,
                    CreateIntegrationAccountPartnerInstance(integrationAccountPartnerName, integrationAccountName));

                Assert.Equal(partner.Name, integrationAccountPartnerName);

                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);
                Assert.Throws<CloudException>(
                    () =>
                        client.IntegrationAccountPartners.Get(Constants.DefaultResourceGroup, integrationAccountName,
                            integrationAccountPartnerName));
            }
        }

        /// <summary>
        /// Tests the create and update operations of the integration account partner.
        /// </summary>
        [Fact]
        public void CreateAndUpdateIntegrationAccountPartner()
        {
            using (
                MockContext context = MockContext.Start(TestClass))
            {
                string integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                string integrationAccountPartnerName =
                    TestUtilities.GenerateName(Constants.IntegrationAccountPartnerPrefix);

                var client = this.GetIntegrationAccountClient(context);
                client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    CreateIntegrationAccountInstance(integrationAccountName));
                client.IntegrationAccountPartners.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName, integrationAccountPartnerName,
                    CreateIntegrationAccountPartnerInstance(integrationAccountPartnerName, integrationAccountName));

                var identities = new List<BusinessIdentity>
                {
                    new BusinessIdentity() {Qualifier = "XX", Value = "DD"},
                    new BusinessIdentity() {Qualifier = "XX", Value = "DD"}
                };

                var updatedPartner = client.IntegrationAccountPartners.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    integrationAccountPartnerName, new IntegrationAccountPartner
                    {
                        Location = Constants.DefaultLocation,
                        Name = integrationAccountPartnerName,
                        Metadata = "updated",
                        PartnerType = PartnerType.B2B,
                        Content = new PartnerContent
                        {
                            B2b = new B2BPartnerContent
                            {
                                BusinessIdentities = identities
                            }
                        }
                    });

                Assert.Equal(updatedPartner.Name, integrationAccountPartnerName);

                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);
            }
        }

        /// <summary>
        /// Tests the create and get operations of the integration account partner.
        /// </summary>
        [Fact]
        public void CreateAndGetIntegrationAccountPartner()
        {
            using (
                MockContext context = MockContext.Start(TestClass))
            {
                string integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                string integrationAccountPartnerName =
                    TestUtilities.GenerateName(Constants.IntegrationAccountPartnerPrefix);
                var client = this.GetIntegrationAccountClient(context);
                var createdAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    CreateIntegrationAccountInstance(integrationAccountName));
                var partner = client.IntegrationAccountPartners.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName, integrationAccountPartnerName,
                    CreateIntegrationAccountPartnerInstance(integrationAccountPartnerName, integrationAccountName));


                Assert.NotNull(partner);
                Assert.Equal(partner.Name, integrationAccountPartnerName);

                var getPartner = client.IntegrationAccountPartners.Get(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    integrationAccountPartnerName);

                Assert.Equal(partner.Name, getPartner.Name);

                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);
            }
        }

        /// <summary>
        /// Tests the create and list operations of the integration account partner.
        /// </summary>
        [Fact]
        public void ListIntegrationAccountPartners()
        {
            using (
                MockContext context = MockContext.Start(TestClass))
            {
                string integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                string integrationAccountPartnerName =
                    TestUtilities.GenerateName(Constants.IntegrationAccountPartnerPrefix);
                var client = this.GetIntegrationAccountClient(context);
                var createdAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    CreateIntegrationAccountInstance(integrationAccountName));

                var createdSchema = client.IntegrationAccountPartners.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName, integrationAccountPartnerName,
                    CreateIntegrationAccountPartnerInstance(integrationAccountPartnerName, integrationAccountName));

                var partners = client.IntegrationAccountPartners.List(Constants.DefaultResourceGroup,
                    integrationAccountName);

                Assert.True(partners.Any());

                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);

            }
        }

        #region Private

        /// <summary>
        /// Creates an Integration account partner
        /// </summary>
        /// <param name="integrationAccountPartnerName">Name of the partner</param>
        /// <param name="integrationAccountName">Name of the integration account</param>        
        /// <returns>Schema instance</returns>
        private IntegrationAccountPartner CreateIntegrationAccountPartnerInstance(string integrationAccountPartnerName,
            string integrationAccountName)
        {
            IDictionary<string, string> tags = new Dictionary<string, string>();
            tags.Add("integrationAccountPartnerName", integrationAccountPartnerName);

            var identities = new List<BusinessIdentity>
            {
                new BusinessIdentity() {Qualifier = "AA", Value = "ZZ"}
            };

            var partner = new IntegrationAccountPartner
            {
                Location = Constants.DefaultLocation,
                Name = integrationAccountPartnerName,
                Tags = tags,
                PartnerType = PartnerType.B2B,
                Metadata = integrationAccountPartnerName,
                Content = new PartnerContent
                {
                    B2b = new B2BPartnerContent
                    {
                        BusinessIdentities = identities
                    }
                }
            };

            return partner;
        }

        #endregion Private
    }
}