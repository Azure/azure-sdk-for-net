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

    [Collection("IntegrationAccountScenarioTests")]
    public class IntegrationAccountScenarioTests : ScenarioTestsBase
    { 
        [Fact]
        public void IntegrationAccounts_Create_OK()
        {
            using (var context = MockContext.Start(this.TestClassType))
            {
                var client = this.GetClient(context);
                this.CleanResourceGroup(client);
                var integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                var integrationAccount = this.CreateIntegrationAccount(integrationAccountName);
                var createdIntegrationAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    integrationAccount);

                this.ValidateIntegrationAccount(integrationAccount, createdIntegrationAccount);

                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);
            }
        }

        [Fact]
        public void IntegrationAccounts_Get_OK()
        {
            using (var context = MockContext.Start(this.TestClassType))
            {
                var client = this.GetClient(context);
                this.CleanResourceGroup(client);
                var integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                var integrationAccount = this.CreateIntegrationAccount(integrationAccountName);
                var createdIntegrationAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    integrationAccount);

                var retrievedIntegrationAccount = client.IntegrationAccounts.Get(Constants.DefaultResourceGroup, integrationAccountName);

                this.ValidateIntegrationAccount(integrationAccount, retrievedIntegrationAccount);

                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);
            }
        }

        [Fact]
        public void IntegrationAccounts_List_OK()
        {
            using (var context = MockContext.Start(this.TestClassType))
            {
                var client = this.GetClient(context);
                this.CleanResourceGroup(client);
                var integrationAccountName1 = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                var integrationAccount1 = this.CreateIntegrationAccount(integrationAccountName1);
                var createdIntegrationAccount1 = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName1,
                    integrationAccount1);

                var integrationAccountName2 = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                var integrationAccount2 = this.CreateIntegrationAccount(integrationAccountName2);
                var createdIntegrationAccount2 = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName2,
                    integrationAccount2);

                var integrationAccountName3 = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                var integrationAccount3 = this.CreateIntegrationAccount(integrationAccountName3);
                var createdIntegrationAccount3 = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName3,
                    integrationAccount3);

                var integrationAccounts = client.IntegrationAccounts.ListByResourceGroup(Constants.DefaultResourceGroup);

                Assert.Equal(3, integrationAccounts.Count());

                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName1);
                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName2);
                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName3);
            }
        }

        [Fact]
        public void IntegrationAccounts_ListBySubscription_OK()
        {
            using (var context = MockContext.Start(this.TestClassType))
            {
                var client = this.GetClient(context);
                this.CleanResourceGroup(client);
                var integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                var integrationAccount = this.CreateIntegrationAccount(integrationAccountName);
                var createdIntegrationAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    integrationAccount);

                var integrationAccounts = client.IntegrationAccounts.ListBySubscription();

                Assert.NotEmpty(integrationAccounts);

                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);
            }
        }

        [Fact]
        public void IntegrationAccounts_Update_OK()
        {
            using (var context = MockContext.Start(this.TestClassType))
            {
                var client = this.GetClient(context);
                this.CleanResourceGroup(client);
                var integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                var integrationAccount = this.CreateIntegrationAccount(integrationAccountName);
                integrationAccount.Sku.Name = IntegrationAccountSkuName.Basic;
                var createdAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    integrationAccount);

                var newIntegrationAccount = this.CreateIntegrationAccount(integrationAccountName);
                newIntegrationAccount.Sku.Name = IntegrationAccountSkuName.Standard;

                var updatedIntegrationAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    newIntegrationAccount);

                this.ValidateIntegrationAccount(newIntegrationAccount, updatedIntegrationAccount);

                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);
            }
        }

        [Fact]
        public void IntegrationAccounts_Delete_OK()
        {
            using (var context = MockContext.Start(this.TestClassType))
            {
                var client = this.GetClient(context);
                this.CleanResourceGroup(client);
                var integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                var integrationAccount = this.CreateIntegrationAccount(integrationAccountName);
                var createdIntegrationAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    integrationAccount);

                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);
                Assert.Throws<CloudException>(() => client.IntegrationAccounts.Get(Constants.DefaultResourceGroup, integrationAccountName));
            }
        }

        [Fact]
        public void IntegrationAccounts_ListContentCallbackUrl_OK()
        {
            using (var context = MockContext.Start(this.TestClassType))
            {
                var client = this.GetClient(context);
                this.CleanResourceGroup(client);
                var integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                var integrationAccount = this.CreateIntegrationAccount(integrationAccountName);
                var createdIntegrationAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    integrationAccount);

                var contentCallbackUrl = client.IntegrationAccounts.ListCallbackUrl(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    new GetCallbackUrlParameters
                    {
                        KeyType = "Primary"
                    });

                Assert.NotEmpty(contentCallbackUrl.Value);

                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);
            }
        }

        private void ValidateIntegrationAccount(IntegrationAccount expected, IntegrationAccount actual)
        {
            Assert.Equal(expected.Name, actual.Name);
            Assert.Equal(expected.Location, actual.Location);
            Assert.Equal(expected.Sku.Name, actual.Sku.Name);
        }
    }
}
