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

    [Collection("IntegrationAccountScenarioTests")]
    public class IntegrationAccountScenarioTests : ScenarioTestsBase, IDisposable
    {
        private readonly MockContext context;
        private readonly ILogicManagementClient client;
        private readonly string integrationAccountName;
        private readonly IntegrationAccount integrationAccount;

        public IntegrationAccountScenarioTests()
        {
            this.context = MockContext.Start(className: this.TestClassName);
            this.client = this.GetClient(this.context);

            this.integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
            this.integrationAccount = this.CreateIntegrationAccount(this.integrationAccountName);
        }

        public void Dispose()
        {
            this.client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, this.integrationAccountName);

            this.client.Dispose();
            this.context.Dispose();
        }

        [Fact]
        public void IntegrationAccounts_Create_OK()
        {
            var createdIntegrationAccount = this.client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                this.integrationAccount);

            this.ValidateIntegrationAccount(this.integrationAccount, createdIntegrationAccount);
        }

        [Fact]
        public void IntegrationAccounts_Get_OK()
        {
            var createdIntegrationAccount = this.client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                this.integrationAccount);

            var retrievedIntegrationAccount = this.client.IntegrationAccounts.Get(Constants.DefaultResourceGroup, this.integrationAccountName);

            this.ValidateIntegrationAccount(this.integrationAccount, retrievedIntegrationAccount);
        }

        [Fact]
        public void IntegrationAccounts_List_OK()
        {
            var createdIntegrationAccount = this.client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                this.integrationAccount);

            var integrationAccountName2 = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
            var integrationAccount2 = this.CreateIntegrationAccount(integrationAccountName2);
            var createdIntegrationAccount2 = this.client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                integrationAccountName2,
                integrationAccount2);

            var integrationAccountName3 = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
            var integrationAccount3 = this.CreateIntegrationAccount(integrationAccountName3);
            var createdIntegrationAccount3 = this.client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                integrationAccountName3,
                integrationAccount3);

            var integrationAccounts = this.client.IntegrationAccounts.ListByResourceGroup(Constants.DefaultResourceGroup);

            Assert.Equal(3, integrationAccounts.Count());

            // Not handled by the dispose method
            this.client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName2);
            this.client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName3);
        }

        [Fact]
        public void IntegrationAccounts_ListBySubscription_OK()
        {
            var createdIntegrationAccount = this.client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                this.integrationAccount);

            var integrationAccounts = this.client.IntegrationAccounts.ListBySubscription();

            Assert.NotEmpty(integrationAccounts);
        }

        [Fact]
        public void IntegrationAccounts_Update_OK()
        {
            this.integrationAccount.Sku.Name = IntegrationAccountSkuName.Basic;
            var createdIntegrationAccount = this.client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                this.integrationAccount);

            var newIntegrationAccount = this.CreateIntegrationAccount(this.integrationAccountName);
            newIntegrationAccount.Sku.Name = IntegrationAccountSkuName.Standard;

            var updatedIntegrationAccount = this.client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                newIntegrationAccount);

            this.ValidateIntegrationAccount(newIntegrationAccount, updatedIntegrationAccount);
        }

        [Fact]
        public void IntegrationAccounts_Delete_OK()
        {
            var createdIntegrationAccount = this.client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                this.integrationAccount);

            this.client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, this.integrationAccountName);
            Assert.Throws<CloudException>(() => this.client.IntegrationAccounts.Get(Constants.DefaultResourceGroup, this.integrationAccountName));
        }

        [Fact]
        public void IntegrationAccounts_ListContentCallbackUrl_OK()
        {
            var createdIntegrationAccount = this.client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                this.integrationAccount);

            var contentCallbackUrl = this.client.IntegrationAccounts.ListCallbackUrl(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                new GetCallbackUrlParameters {
                    KeyType = "Primary"
                });

            Assert.NotEmpty(contentCallbackUrl.Value);
        }

        private void ValidateIntegrationAccount(IntegrationAccount expected, IntegrationAccount actual)
        {
            Assert.Equal(expected.Name, actual.Name);
            Assert.Equal(expected.Location, actual.Location);
            Assert.Equal(expected.Sku.Name, actual.Sku.Name);
        }
    }
}