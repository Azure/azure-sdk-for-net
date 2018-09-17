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
    using System;

    /// <summary>
    /// Scenario tests for the integration accounts partner.
    /// </summary>
    [Collection("IntegrationAccountPartnerScenarioTests")]
    public class IntegrationAccountPartnerScenarioTests : ScenarioTestsBase, IDisposable
    {
        private readonly MockContext context;
        private readonly ILogicManagementClient client;
        private readonly string integrationAccountName;
        private readonly string partnerName;
        private readonly IntegrationAccount integrationAccount;

        public IntegrationAccountPartnerScenarioTests()
        {
            this.context = MockContext.Start(className: this.TestClassName);
            this.client = this.GetClient(this.context);

            this.integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
            this.integrationAccount = this.client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                this.CreateIntegrationAccount(this.integrationAccountName));

            this.partnerName = TestUtilities.GenerateName(Constants.IntegrationAccountPartnerPrefix);
        }

        public void Dispose()
        {
            this.client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, this.integrationAccountName);

            this.client.Dispose();
            this.context.Dispose();
        }

        [Fact]
        public void IntegrationAccountPartners_Create_OK()
        {
            var partner = this.CreateIntegrationAccountPartner(this.partnerName);
            var createdPartner = this.client.IntegrationAccountPartners.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                this.partnerName,
                partner);

            this.ValidatePartner(partner, createdPartner);
        }

        [Fact]
        public void IntegrationAccountPartners_Get_OK()
        {
            var partner = this.CreateIntegrationAccountPartner(this.partnerName);
            var createdPartner = this.client.IntegrationAccountPartners.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                this.partnerName,
                partner);

            var retrievedPartner = this.client.IntegrationAccountPartners.Get(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                this.partnerName);

            this.ValidatePartner(partner, retrievedPartner);
        }

        [Fact]
        public void IntegrationAccountPartners_List_OK()
        {
            var partner1 = this.CreateIntegrationAccountPartner(this.partnerName);
            var createdPartner = this.client.IntegrationAccountPartners.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                this.partnerName,
                partner1);

            var partnerName2 = TestUtilities.GenerateName(Constants.IntegrationAccountPartnerPrefix);
            var partner2 = this.CreateIntegrationAccountPartner(partnerName2);
            var createdPartner2 = this.client.IntegrationAccountPartners.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                partnerName2,
                partner2);

            var partnerName3 = TestUtilities.GenerateName(Constants.IntegrationAccountPartnerPrefix);
            var partner3 = this.CreateIntegrationAccountPartner(partnerName3);
            var createdPartner3 = this.client.IntegrationAccountPartners.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                partnerName3,
                partner3);

            var partners = this.client.IntegrationAccountPartners.List(Constants.DefaultResourceGroup, this.integrationAccountName);

            Assert.Equal(3, partners.Count());
            this.ValidatePartner(partner1, partners.Single(x => x.Name == partner1.Name));
            this.ValidatePartner(partner2, partners.Single(x => x.Name == partner2.Name));
            this.ValidatePartner(partner3, partners.Single(x => x.Name == partner3.Name));
        }

        [Fact]
        public void IntegrationAccountPartners_Update_OK()
        {
            var partner = this.CreateIntegrationAccountPartner(this.partnerName);
            var createdPartner = this.client.IntegrationAccountPartners.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                this.partnerName,
                partner);

            var newPartner = this.CreateIntegrationAccountPartner(this.partnerName);
            var updatedPartner = this.client.IntegrationAccountPartners.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                this.partnerName,
                newPartner);

            this.ValidatePartner(newPartner, updatedPartner);
        }

        [Fact]
        public void IntegrationAccountPartners_Delete_OK()
        {
            var partner = this.CreateIntegrationAccountPartner(this.partnerName);
            var createdPartner = this.client.IntegrationAccountPartners.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                this.partnerName,
                partner);

            this.client.IntegrationAccountPartners.Delete(Constants.DefaultResourceGroup, this.integrationAccountName, this.partnerName);
            Assert.Throws<CloudException>(() => this.client.IntegrationAccountPartners.Get(Constants.DefaultResourceGroup, this.integrationAccountName, this.partnerName));
        }

        [Fact]
        public void IntegrationAccountPartners_DeleteWhenDeleteIntegrationAccount_OK()
        {
            var partner = this.CreateIntegrationAccountPartner(this.partnerName);
            var createdPartner = this.client.IntegrationAccountPartners.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                this.partnerName,
                partner);

            this.client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, this.integrationAccountName);
            Assert.Throws<CloudException>(() => this.client.IntegrationAccountPartners.Get(Constants.DefaultResourceGroup, this.integrationAccountName, this.partnerName));
        }

        [Fact]
        public void IntegrationAccountPartners_ListContentCallbackUrl_OK()
        {
            var partner = this.CreateIntegrationAccountPartner(this.partnerName);
            var createdPartner = this.client.IntegrationAccountPartners.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                this.partnerName,
                partner);

            var contentCallbackUrl = this.client.IntegrationAccountPartners.ListContentCallbackUrl(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                this.partnerName,
                new GetCallbackUrlParameters
                {
                    KeyType = "Primary"
                });

            Assert.Equal("GET", contentCallbackUrl.Method);
            Assert.Contains(this.partnerName, contentCallbackUrl.Value);
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