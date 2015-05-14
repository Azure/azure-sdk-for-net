//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.IO;
using System.Linq;
using System.Net;
using Hyak.Common;
using Microsoft.Azure;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.WindowsAzure.Management;
using Microsoft.WindowsAzure.Management.Compute;
using Microsoft.WindowsAzure.Management.Compute.Models;
using Microsoft.WindowsAzure.Management.Monitoring.Alerts;
using Microsoft.WindowsAzure.Management.Monitoring.Alerts.Models;
using Microsoft.WindowsAzure.Management.Monitoring.Models;
using Microsoft.Azure.Test;
using Microsoft.WindowsAzure.Management.Storage;
using Microsoft.WindowsAzure.Management.Storage.Models;
using Monitoring.Tests.Helpers;
using Xunit;
using Microsoft.WindowsAzure.Testing;

namespace Monitoring.Tests
{
    public class AlertsTests : TestBase
    {
        public AlertsClient GetAlertsClient(RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            return TestBase.GetServiceClient<AlertsClient>(new RDFETestEnvironmentFactory()).WithHandler(handler);
        }

        [Fact (Skip ="Code: NotFound. Exception of type 'Microsoft.WindowsAzure.Management.Monitoring.Rest.MonitoringServiceException' was thrown.")]
        public void AlertRuleCrudTest()
        {
            var handler = new RecordedDelegatingHandler() { };

            using (UndoContext context = UndoContext.Current)
            {
                context.Start();

                var alertsClient = GetAlertsClient(handler);

                // provision a hosted service to consume by the test case 
                string newServiceName = TestUtilities.GenerateName("cs");

                var deploymentStatus = ProvisionHostedService(newServiceName);
                var deployment = deploymentStatus.Deployments.FirstOrDefault();
                var id = HttpMockServer.GetVariable("RuleID", Guid.NewGuid().ToString());
                Assert.NotNull(deployment);

                // now the actual test case
                Rule newRule = new Rule
                {
                    Name = TestUtilities.GenerateName("rule"),
                    Description = "rule description",
                    Id = id,
                    IsEnabled = false,
                    Condition = new ThresholdRuleCondition
                    {
                        Operator = ConditionOperator.GreaterThanOrEqual,
                        Threshold = 80.0,
                        WindowSize = TimeSpan.FromMinutes(5),
                        DataSource = new RuleMetricDataSource
                        {
                            MetricName = "Percentage CPU",
                            ResourceId =
                                string.Format("/hostedservices/{0}/deployments/{1}/roles/{2}", newServiceName,
                                    deployment.Name, deployment.Roles.FirstOrDefault().RoleName),
                            MetricNamespace = MetricNamespace.None
                        }
                    }
                };
                
                newRule.Actions.Add(new RuleEmailAction());

                // Create the rule
                AzureOperationResponse createRuleResponse =
                    alertsClient.Rules.CreateOrUpdate(new RuleCreateOrUpdateParameters {Rule = newRule});
                Assert.Equal(HttpStatusCode.Created, createRuleResponse.StatusCode);
                Console.WriteLine("Created alert rule {0}", newRule.Name);

                // Retrieve the rule
                RuleGetResponse getRuleResponse = alertsClient.Rules.Get(newRule.Id);
                Assert.Equal(HttpStatusCode.OK, getRuleResponse.StatusCode);
                Assert.True(AreEquivalent(newRule, getRuleResponse.Rule),
                    "The retrieved rule is not equivalent to the original rule");

                // Get incidents for the rule
                IncidentListResponse incidentListResponse = alertsClient.Incidents.ListForRule(newRule.Id, true);
                Assert.Equal(HttpStatusCode.OK, incidentListResponse.StatusCode);
                Assert.False(incidentListResponse.Any(),
                    string.Format("There should be no active incident for the rule [{0}].", newRule.Name));

                // Validate rule is included by list operation
                RuleListResponse listRulesResponse = alertsClient.Rules.List();
                Assert.Equal(HttpStatusCode.OK, getRuleResponse.StatusCode);
                Assert.True(listRulesResponse.Value.Any(),
                    "The alertClient.Rules.List() call returned an empty collection of alert rules");
                Assert.True(listRulesResponse.Value.Any(rc => rc.Id.Equals(newRule.Id)),
                    "The newly created rule is not in present in the collection of rules returned by alertClient.Rules.List()");

                // Update and validate the rule
                Rule updatedRule = newRule;
                updatedRule.Description = "updated description";
                ((ThresholdRuleCondition)(updatedRule.Condition)).Threshold = 60.0;
                AzureOperationResponse updateRuleResponse =
                    alertsClient.Rules.CreateOrUpdate(new RuleCreateOrUpdateParameters {Rule = updatedRule});
                Assert.Equal(HttpStatusCode.OK, updateRuleResponse.StatusCode);

                getRuleResponse = alertsClient.Rules.Get(newRule.Id);
                Assert.Equal(HttpStatusCode.OK, getRuleResponse.StatusCode);
                Assert.True(AreEquivalent(updatedRule, getRuleResponse.Rule),
                    "The retrieved rule is not equivalent to the updated rule");

                // Delete the rule
                AzureOperationResponse deleteResponse = alertsClient.Rules.Delete(newRule.Id);
                Assert.Equal(HttpStatusCode.OK, deleteResponse.StatusCode);

                // Validate the rule was deleted
                Assert.Throws<CloudException>(() => alertsClient.Rules.Get(newRule.Id));

                listRulesResponse = alertsClient.Rules.List();
                Assert.Equal(HttpStatusCode.OK, getRuleResponse.StatusCode);
                if (listRulesResponse.Value.Count > 0)
                {
                    var foundDeletedRule = listRulesResponse.Value.Any(rc => rc.Id.Equals(newRule.Id));
                    Assert.False(foundDeletedRule, string.Format("Rule [{0}] is found after its deletion.", newRule.Name));
                }
            }
        }

        private HostedServiceGetDetailedResponse ProvisionHostedService(string newServiceName)
        {
            ComputeManagementClient computeClient = TestBase.GetServiceClient<ComputeManagementClient>();
            StorageManagementClient storageClient = TestBase.GetServiceClient<StorageManagementClient>();

            string computeLocation = GetLocation("Compute");

            var createHostedServiceResp = computeClient.HostedServices.Create(new HostedServiceCreateParameters()
            {
                ServiceName = newServiceName,
                Location = computeLocation
            });

            Assert.Equal(HttpStatusCode.Created, createHostedServiceResp.StatusCode);

            string newStorageAccountName = TestUtilities.GenerateName("storage");
            string storageLocation = GetLocation("Storage");

            var createStorageResp = storageClient.StorageAccounts.Create(new StorageAccountCreateParameters
            {
                Location = storageLocation,
                Name = newStorageAccountName,
                AccountType = "Standard_GRS"
            });

            Assert.Equal(HttpStatusCode.OK, createStorageResp.StatusCode);

            var blobUri = StorageTestUtilities.UploadFileToBlobStorage(newStorageAccountName, "deployments",
                @"SampleService\SMNetTestAppProject.cspkg");
            var configXml = File.ReadAllText(@"SampleService\ServiceConfiguration.Cloud.cscfg");

            string deploymentName = TestUtilities.GenerateName("deployment");

            // create the hosted service deployment
            var deploymentResult = computeClient.Deployments.Create(newServiceName,
                DeploymentSlot.Production,
                new DeploymentCreateParameters
                {
                    Configuration = configXml,
                    Name = deploymentName,
                    Label = "label1",
                    StartDeployment = true,
                    ExtensionConfiguration = null,
                    PackageUri = blobUri
                });

            Assert.Equal(HttpStatusCode.OK, deploymentResult.StatusCode);
            
            var detailedStatus = computeClient.HostedServices.GetDetailedAsync(newServiceName).Result;

            return detailedStatus;
        }

        private bool AreEquivalent(Rule thisRule, Rule thatRule)
        {
            if (!thisRule.Name.Equals(thatRule.Name, StringComparison.Ordinal)) return false;
            if (!thisRule.Description.Equals(thatRule.Description, StringComparison.Ordinal)) return false;
            if (thisRule.IsEnabled != thatRule.IsEnabled) return false;
            if (!thisRule.Actions.ToJson().Equals(thatRule.Actions.ToJson())) return false;
            if (!thisRule.Condition.ToJson().Equals(thatRule.Condition.ToJson())) return false;
            return true;
        }

        private string GetLocation(string serviceName)
        {
            ManagementClient managementClient = TestBase.GetServiceClient<ManagementClient>();

            var serviceLocations =
                managementClient.Locations.ListAsync()
                    .Result.Where(l => l.AvailableServices.Contains(serviceName))
                    .ToList();

            return serviceLocations.Any(l => l.Name.Equals("West US"))
                ? "West US"
                : serviceLocations.FirstOrDefault().Name;
        }
    }
}
