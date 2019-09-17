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

    [Collection("IntegrationAccountPartnerScenarioTests")]
    public class IntegrationAccountPartnerScenarioTests : ScenarioTestsBase
    {
        [Fact]
        public void IntegrationAccountPartners_Create_OK()
        {
            using (var context = MockContext.Start(this.TestClassType))
            {
                var client = this.GetClient(context);
                this.CleanResourceGroup(client);
                var integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                var integrationAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    this.CreateIntegrationAccount(integrationAccountName));

                var partnerName = TestUtilities.GenerateName(Constants.IntegrationAccountPartnerPrefix);
                var partner = this.CreateIntegrationAccountPartner(partnerName);
                var createdPartner = client.IntegrationAccountPartners.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    partnerName,
                    partner);

                this.ValidatePartner(partner, createdPartner);

                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);
            }
        }

        [Fact]
        public void IntegrationAccountPartners_Get_OK()
        {
            using (var context = MockContext.Start(this.TestClassType))
            {
                var client = this.GetClient(context);
                this.CleanResourceGroup(client);
                var integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                var integrationAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    this.CreateIntegrationAccount(integrationAccountName));

                var partnerName = TestUtilities.GenerateName(Constants.IntegrationAccountPartnerPrefix);
                var partner = this.CreateIntegrationAccountPartner(partnerName);
                var createdPartner = client.IntegrationAccountPartners.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    partnerName,
                    partner);

                var retrievedPartner = client.IntegrationAccountPartners.Get(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    partnerName);

                this.ValidatePartner(partner, retrievedPartner);

                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);
            }
        }

        [Fact]
        public void IntegrationAccountPartners_List_OK()
        {
            using (var context = MockContext.Start(this.TestClassType))
            {
                var client = this.GetClient(context);
                this.CleanResourceGroup(client);
                var integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                var integrationAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    this.CreateIntegrationAccount(integrationAccountName));

                var partnerName1 = TestUtilities.GenerateName(Constants.IntegrationAccountPartnerPrefix);
                var partner1 = this.CreateIntegrationAccountPartner(partnerName1);
                var createdPartner = client.IntegrationAccountPartners.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    partnerName1,
                    partner1);

                var partnerName2 = TestUtilities.GenerateName(Constants.IntegrationAccountPartnerPrefix);
                var partner2 = this.CreateIntegrationAccountPartner(partnerName2);
                var createdPartner2 = client.IntegrationAccountPartners.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    partnerName2,
                    partner2);

                var partnerName3 = TestUtilities.GenerateName(Constants.IntegrationAccountPartnerPrefix);
                var partner3 = this.CreateIntegrationAccountPartner(partnerName3);
                var createdPartner3 = client.IntegrationAccountPartners.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    partnerName3,
                    partner3);

                var partners = client.IntegrationAccountPartners.List(Constants.DefaultResourceGroup, integrationAccountName);

                Assert.Equal(3, partners.Count());
                this.ValidatePartner(partner1, partners.Single(x => x.Name == partner1.Name));
                this.ValidatePartner(partner2, partners.Single(x => x.Name == partner2.Name));
                this.ValidatePartner(partner3, partners.Single(x => x.Name == partner3.Name));

                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);
            }
        }

        [Fact]
        public void IntegrationAccountPartners_Update_OK()
        {
            using (var context = MockContext.Start(this.TestClassType))
            {
                var client = this.GetClient(context);
                this.CleanResourceGroup(client);
                var integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                var integrationAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    this.CreateIntegrationAccount(integrationAccountName));

                var partnerName = TestUtilities.GenerateName(Constants.IntegrationAccountPartnerPrefix);
                var partner = this.CreateIntegrationAccountPartner(partnerName);
                var createdPartner = client.IntegrationAccountPartners.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    partnerName,
                    partner);

                var newPartner = this.CreateIntegrationAccountPartner(partnerName);
                var updatedPartner = client.IntegrationAccountPartners.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    partnerName,
                    newPartner);

                this.ValidatePartner(newPartner, updatedPartner);

                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);
            }
        }

        [Fact]
        public void IntegrationAccountPartners_Delete_OK()
        {
            using (var context = MockContext.Start(this.TestClassType))
            {
                var client = this.GetClient(context);
                this.CleanResourceGroup(client);
                var integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                var integrationAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    this.CreateIntegrationAccount(integrationAccountName));

                var partnerName = TestUtilities.GenerateName(Constants.IntegrationAccountPartnerPrefix);
                var partner = this.CreateIntegrationAccountPartner(partnerName);
                var createdPartner = client.IntegrationAccountPartners.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    partnerName,
                    partner);

                client.IntegrationAccountPartners.Delete(Constants.DefaultResourceGroup, integrationAccountName, partnerName);
                Assert.Throws<CloudException>(() => client.IntegrationAccountPartners.Get(Constants.DefaultResourceGroup, integrationAccountName, partnerName));

                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);
            }
        }

        [Fact]
        public void IntegrationAccountPartners_DeleteWhenDeleteIntegrationAccount_OK()
        {
            using (var context = MockContext.Start(this.TestClassType))
            {
                var client = this.GetClient(context);
                this.CleanResourceGroup(client);
                var integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                var integrationAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    this.CreateIntegrationAccount(integrationAccountName));

                var partnerName = TestUtilities.GenerateName(Constants.IntegrationAccountPartnerPrefix);
                var partner = this.CreateIntegrationAccountPartner(partnerName);
                var createdPartner = client.IntegrationAccountPartners.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    partnerName,
                    partner);

                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);
                Assert.Throws<CloudException>(() => client.IntegrationAccountPartners.Get(Constants.DefaultResourceGroup, integrationAccountName, partnerName));
            }
        }

        [Fact]
        public void IntegrationAccountPartners_ListContentCallbackUrl_OK()
        {
            using (var context = MockContext.Start(this.TestClassType))
            {
                var client = this.GetClient(context);
                this.CleanResourceGroup(client);
                var integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                var integrationAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    this.CreateIntegrationAccount(integrationAccountName));

                var partnerName = TestUtilities.GenerateName(Constants.IntegrationAccountPartnerPrefix);
                var partner = this.CreateIntegrationAccountPartner(partnerName);
                var createdPartner = client.IntegrationAccountPartners.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    partnerName,
                    partner);

                var contentCallbackUrl = client.IntegrationAccountPartners.ListContentCallbackUrl(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    partnerName,
                    new GetCallbackUrlParameters
                    {
                        KeyType = "Primary"
                    });

                Assert.Equal("GET", contentCallbackUrl.Method);
                Assert.Contains(partnerName, contentCallbackUrl.Value);

                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);
            }
        }

        #region Private

        private void ValidatePartner(IntegrationAccountPartner expected, IntegrationAccountPartner actual)
        {
            Assert.Equal(expected.Name, actual.Name);
            Assert.Equal(expected.PartnerType, actual.PartnerType);
            Assert.Equal(expected.Content.B2b.BusinessIdentities.Count(), actual.Content.B2b.BusinessIdentities.Count());
            Assert.Equal(expected.Content.B2b.BusinessIdentities.First().Qualifier, actual.Content.B2b.BusinessIdentities.First().Qualifier);
            Assert.Equal(expected.Content.B2b.BusinessIdentities.First().Value, actual.Content.B2b.BusinessIdentities.First().Value);
            Assert.NotNull(actual.CreatedTime);
            Assert.NotNull(actual.ChangedTime);
        }

        private IntegrationAccountPartner CreateIntegrationAccountPartner(string partnerName)
        {
            return new IntegrationAccountPartner(PartnerType.B2B,
                new PartnerContent
                {
                    B2b = new B2BPartnerContent
                    {
                        BusinessIdentities = new List<BusinessIdentity>
                        {
                            new BusinessIdentity
                            {
                                Qualifier = "AA",
                                Value = "ZZ"
                            }
                        }
                    }
                },
                name: partnerName,
                location: Constants.DefaultLocation);
        }

        #endregion Private
    }
}
