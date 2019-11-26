// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Test.Azure.Management.Logic
{
    using Microsoft.Azure.Management.Logic;
    using Microsoft.Azure.Management.Logic.Models;
    using Microsoft.Rest.Azure;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using System.Linq;
    using Xunit;

    [Collection("IntegrationAccountBatchConfigurationsScenarioTests")]
    public class IntegrationAccountBatchConfigurationsScenarioTests : ScenarioTestsBase
    {
        [Fact]
        public void IntegrationAccountBatchConfigurations_Create_OK()
        {
            using (var context = MockContext.Start(this.TestClassType))
            {
                var client = this.GetClient(context);
                this.CleanResourceGroup(client);
                var integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                var integrationAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    this.CreateIntegrationAccount(integrationAccountName));

                var batchConfigurationName = TestUtilities.GenerateName(Constants.IntegrationAccountBatchConfigurationPrefix);
                var batchConfiguration = this.CreateIntegrationAccountBatchConfiguration(batchConfigurationName);
                var createdBatchConfiguration = client.IntegrationAccountBatchConfigurations.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    batchConfigurationName,
                    batchConfiguration);

                this.ValidateBatchConfiguration(batchConfiguration, createdBatchConfiguration);

                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);
            }
        }

        [Fact]
        public void IntegrationAccountBatchConfigurations_Get_OK()
        {
            using (var context = MockContext.Start(this.TestClassType))
            {
                var client = this.GetClient(context);
                this.CleanResourceGroup(client);
                var integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                var integrationAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    this.CreateIntegrationAccount(integrationAccountName));

                var batchConfigurationName = TestUtilities.GenerateName(Constants.IntegrationAccountBatchConfigurationPrefix);
                var batchConfiguration = this.CreateIntegrationAccountBatchConfiguration(batchConfigurationName);
                var createdBatchConfiguration = client.IntegrationAccountBatchConfigurations.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    batchConfigurationName,
                    batchConfiguration);

                var retrievedBatchConfiguration = client.IntegrationAccountBatchConfigurations.Get(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    batchConfigurationName);

                this.ValidateBatchConfiguration(batchConfiguration, retrievedBatchConfiguration);

                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);
            }
        }

        [Fact]
        public void IntegrationAccountBatchConfigurations_List_OK()
        {
            using (var context = MockContext.Start(this.TestClassType))
            {
                var client = this.GetClient(context);
                this.CleanResourceGroup(client);
                var integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                var integrationAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    this.CreateIntegrationAccount(integrationAccountName));

                var batchConfigurationName1 = TestUtilities.GenerateName(Constants.IntegrationAccountBatchConfigurationPrefix);
                var batchConfiguration1 = this.CreateIntegrationAccountBatchConfiguration(batchConfigurationName1);
                var createdBatchConfiguration1 = client.IntegrationAccountBatchConfigurations.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    batchConfigurationName1,
                    batchConfiguration1);

                var batchConfigurationName2 = TestUtilities.GenerateName(Constants.IntegrationAccountBatchConfigurationPrefix);
                var batchConfiguration2 = this.CreateIntegrationAccountBatchConfiguration(batchConfigurationName2);
                var createdBatchConfiguration2 = client.IntegrationAccountBatchConfigurations.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    batchConfigurationName2,
                    batchConfiguration2);

                var batchConfigurationName3 = TestUtilities.GenerateName(Constants.IntegrationAccountBatchConfigurationPrefix);
                var batchConfiguration3 = this.CreateIntegrationAccountBatchConfiguration(batchConfigurationName3);
                var createdBatchConfiguration3 = client.IntegrationAccountBatchConfigurations.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    batchConfigurationName3,
                    batchConfiguration3);

                var batchConfigurations = client.IntegrationAccountBatchConfigurations.List(Constants.DefaultResourceGroup, integrationAccountName);

                Assert.Equal(3, batchConfigurations.Count());
                this.ValidateBatchConfiguration(batchConfiguration1, createdBatchConfiguration1);
                this.ValidateBatchConfiguration(batchConfiguration2, createdBatchConfiguration2);
                this.ValidateBatchConfiguration(batchConfiguration3, createdBatchConfiguration3);

                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);
            }
        }

        [Fact]
        public void IntegrationAccountBatchConfigurations_Delete_OK()
        {
            using (var context = MockContext.Start(this.TestClassType))
            {
                var client = this.GetClient(context);
                this.CleanResourceGroup(client);
                var integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                var integrationAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    this.CreateIntegrationAccount(integrationAccountName));

                var batchConfigurationName = TestUtilities.GenerateName(Constants.IntegrationAccountBatchConfigurationPrefix);
                var batchConfiguration = this.CreateIntegrationAccountBatchConfiguration(batchConfigurationName);
                var createdBatchConfiguration = client.IntegrationAccountBatchConfigurations.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    batchConfigurationName,
                    batchConfiguration);

                client.IntegrationAccountBatchConfigurations.Delete(Constants.DefaultResourceGroup, integrationAccountName, batchConfigurationName);
                Assert.Throws<CloudException>(() => client.IntegrationAccountBatchConfigurations.Get(Constants.DefaultResourceGroup, integrationAccountName, batchConfigurationName));

                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);
            }
        }

        // IntegrationAccountBatchConfigurations_DeleteWhenDeleteIntegrationAccount_OK
        // Renamed to get around path limitations
        [Fact]
        public void BatchConfigurations_IntegrationAccountDelete_OK()
        {
            using (var context = MockContext.Start(this.TestClassType))
            {
                var client = this.GetClient(context);
                this.CleanResourceGroup(client);
                var integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
                var integrationAccount = client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    this.CreateIntegrationAccount(integrationAccountName));

                var batchConfigurationName = TestUtilities.GenerateName(Constants.IntegrationAccountBatchConfigurationPrefix);
                var batchConfiguration = this.CreateIntegrationAccountBatchConfiguration(batchConfigurationName);
                var createdBatchConfiguration = client.IntegrationAccountBatchConfigurations.CreateOrUpdate(Constants.DefaultResourceGroup,
                    integrationAccountName,
                    batchConfigurationName,
                    batchConfiguration);

                client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, integrationAccountName);
                Assert.Throws<CloudException>(() => client.IntegrationAccountBatchConfigurations.Get(Constants.DefaultResourceGroup, integrationAccountName, batchConfigurationName));
            }
        }

        #region Private

        private void ValidateBatchConfiguration(BatchConfiguration expected, BatchConfiguration actual)
        {
            Assert.Equal(expected.Name, actual.Name);
            Assert.Equal(expected.Properties.BatchGroupName, actual.Properties.BatchGroupName);
            Assert.Equal(expected.Properties.ReleaseCriteria.BatchSize, actual.Properties.ReleaseCriteria.BatchSize);
            Assert.NotNull(actual.Properties.CreatedTime);
            Assert.NotNull(actual.Properties.ChangedTime);

        }

        private BatchConfiguration CreateIntegrationAccountBatchConfiguration(string batchConfigurationName)
        {
            var batchConfigurationProperties = new BatchConfigurationProperties("batchGroupName", new BatchReleaseCriteria(batchSize: 10));

            var batchConfiguration = new BatchConfiguration(batchConfigurationProperties,
                location: Constants.DefaultLocation,
                name: batchConfigurationName);

            return batchConfiguration;
        }

        #endregion Private
    }
}
