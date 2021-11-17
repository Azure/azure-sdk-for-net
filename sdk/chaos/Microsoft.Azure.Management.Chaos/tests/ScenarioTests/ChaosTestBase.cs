// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Chaos.Tests.Helpers;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;

namespace Microsoft.Azure.Management.Chaos.Tests.ScenarioTests
{
    public abstract class ChaosTestBase
    {
        private const string AzureTestModeEnvironmentVariableName = "AZURE_TEST_MODE";
        private const string TestSubscriptionIdEnvironmentVariableName = "AZURE_TEST_SUBSCRIPTIONID";
        private const string ConnectionStringEnvironmentVariableName = "TEST_CSM_ORGID_AUTHENTICATION";
        private const string SanatizedSecret = "SANATIZED";
        private const string DefaultAzureTestMode = "Playback";
        private const string RecordAzureTestMode = "Record";

        protected string SubscriptionId { get; set; }

        protected string ConnectionString { get; set; }

        protected string AzureTestMode { get; set; }

        protected ChaosManagementClient GetChaosManagementClient(MockContext mockContext, RecordedDelegatingHandler recordedDelegationHandler)
        {
            var subscriptionId = Environment.GetEnvironmentVariable(TestSubscriptionIdEnvironmentVariableName);
            subscriptionId = string.IsNullOrWhiteSpace(subscriptionId) ? TestDependencies.TestConstants.DefaultTestSubscriptionId : subscriptionId;
            this.SubscriptionId = subscriptionId;

            var connnectionString = Environment.GetEnvironmentVariable(ConnectionStringEnvironmentVariableName);
            this.ConnectionString = string.IsNullOrEmpty(connnectionString) ? SanatizedSecret : connnectionString;

            var azureTestMode = Environment.GetEnvironmentVariable(AzureTestModeEnvironmentVariableName);
            this.AzureTestMode = string.IsNullOrEmpty(azureTestMode) ? DefaultAzureTestMode : azureTestMode;

            if (recordedDelegationHandler != null)
            {
                recordedDelegationHandler.IsPassThrough = true;
            }

            ChaosManagementClient chaosManagementClient;

            if (string.Equals(this.AzureTestMode, RecordAzureTestMode, StringComparison.InvariantCultureIgnoreCase))
            {
                var testEnvironment = new TestEnvironment(connectionString: this.ConnectionString);
                chaosManagementClient = mockContext.GetServiceClient<ChaosManagementClient>(
                    currentEnvironment: testEnvironment,
                    handlers: recordedDelegationHandler ?? new RecordedDelegatingHandler { SubsequentStatusCodeToReturn = System.Net.HttpStatusCode.OK });
            }
            else
            {
                chaosManagementClient = mockContext.GetServiceClient<ChaosManagementClient>(
                    handlers: recordedDelegationHandler ?? new RecordedDelegatingHandler { SubsequentStatusCodeToReturn = System.Net.HttpStatusCode.OK });
            }

            return chaosManagementClient;
        }
    }
}
