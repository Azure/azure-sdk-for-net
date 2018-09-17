// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Test.Azure.Management.Logic
{
    using Microsoft.Azure.Management.Logic;
    using Microsoft.Azure.Management.Logic.Models;
    using Microsoft.Rest.Azure;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Xunit;

    [Collection("IntegrationAccountBatchConfigurationsScenarioTests")]
    public class IntegrationAccountBatchConfigurationsScenarioTests : ScenarioTestsBase, IDisposable
    {
        private readonly MockContext context;
        private readonly ILogicManagementClient client;
        private readonly string integrationAccountName;
        private readonly string batchConfigurationName;
        private readonly IntegrationAccount integrationAccount;

        public IntegrationAccountBatchConfigurationsScenarioTests()
        {
            this.context = MockContext.Start(className: this.TestClassName);
            this.client = this.GetClient(this.context);

            this.integrationAccountName = TestUtilities.GenerateName(Constants.IntegrationAccountPrefix);
            this.integrationAccount = this.client.IntegrationAccounts.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                this.CreateIntegrationAccount(this.integrationAccountName));

            this.batchConfigurationName = TestUtilities.GenerateName(Constants.IntegrationAccountBatchConfigurationPrefix);
        }

        public void Dispose()
        {
            this.client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, this.integrationAccountName);

            this.client.Dispose();
            this.context.Dispose();
        }

        [Fact]
        public void IntegrationAccountBatchConfigurations_Create_OK()
        {
            var batchConfiguration = this.CreateIntegrationAccountBatchConfiguration(this.batchConfigurationName);
            var createdBatchConfiguration = this.client.IntegrationAccountBatchConfigurations.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                this.batchConfigurationName,
                batchConfiguration);

            this.ValidateBatchConfiguration(batchConfiguration, createdBatchConfiguration);
        }

        [Fact]
        public void IntegrationAccountBatchConfigurations_Get_OK()
        {
            var batchConfiguration = this.CreateIntegrationAccountBatchConfiguration(this.batchConfigurationName);
            var createdBatchConfiguration = this.client.IntegrationAccountBatchConfigurations.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                this.batchConfigurationName,
                batchConfiguration);

            var retrievedBatchConfiguration = this.client.IntegrationAccountBatchConfigurations.Get(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                this.batchConfigurationName);

            this.ValidateBatchConfiguration(batchConfiguration, retrievedBatchConfiguration);
        }

        [Fact]
        public void IntegrationAccountBatchConfigurations_List_OK()
        {
            var batchConfiguration1 = this.CreateIntegrationAccountBatchConfiguration(this.batchConfigurationName);
            var createdBatchConfiguration1 = this.client.IntegrationAccountBatchConfigurations.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                this.batchConfigurationName,
                batchConfiguration1);

            var batchConfigurationName2 = TestUtilities.GenerateName(Constants.IntegrationAccountBatchConfigurationPrefix);
            var batchConfiguration2 = this.CreateIntegrationAccountBatchConfiguration(batchConfigurationName2);
            var createdBatchConfiguration2 = this.client.IntegrationAccountBatchConfigurations.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                batchConfigurationName2,
                batchConfiguration2);

            var batchConfigurationName3 = TestUtilities.GenerateName(Constants.IntegrationAccountBatchConfigurationPrefix);
            var batchConfiguration3 = this.CreateIntegrationAccountBatchConfiguration(batchConfigurationName3);
            var createdBatchConfiguration3 = this.client.IntegrationAccountBatchConfigurations.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                batchConfigurationName3,
                batchConfiguration3);

            var batchConfigurations = this.client.IntegrationAccountBatchConfigurations.List(Constants.DefaultResourceGroup, this.integrationAccountName);

            Assert.Equal(3, batchConfigurations.Count());
            this.ValidateBatchConfiguration(batchConfiguration1, createdBatchConfiguration1);
            this.ValidateBatchConfiguration(batchConfiguration2, createdBatchConfiguration2);
            this.ValidateBatchConfiguration(batchConfiguration3, createdBatchConfiguration3);
        }

        [Fact]
        public void IntegrationAccountBatchConfigurations_Delete_OK()
        {
            var batchConfiguration = this.CreateIntegrationAccountBatchConfiguration(this.batchConfigurationName);
            var createdBatchConfiguration = this.client.IntegrationAccountBatchConfigurations.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                this.batchConfigurationName,
                batchConfiguration);

            this.client.IntegrationAccountBatchConfigurations.Delete(Constants.DefaultResourceGroup, this.integrationAccountName, this.batchConfigurationName);
            Assert.Throws<CloudException>(() => this.client.IntegrationAccountBatchConfigurations.Get(Constants.DefaultResourceGroup, this.integrationAccountName, this.batchConfigurationName));
        }

        [Fact]
        public void IntegrationAccountBatchConfigurations_DeleteWhenDeleteIntegrationAccount_OK()
        {
            var batchConfiguration = this.CreateIntegrationAccountBatchConfiguration(this.batchConfigurationName);
            var createdBatchConfiguration = this.client.IntegrationAccountBatchConfigurations.CreateOrUpdate(Constants.DefaultResourceGroup,
                this.integrationAccountName,
                this.batchConfigurationName,
                batchConfiguration);

            this.client.IntegrationAccounts.Delete(Constants.DefaultResourceGroup, this.integrationAccountName);
            Assert.Throws<CloudException>(() => this.client.IntegrationAccountBatchConfigurations.Get(Constants.DefaultResourceGroup, this.integrationAccountName, this.batchConfigurationName));
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