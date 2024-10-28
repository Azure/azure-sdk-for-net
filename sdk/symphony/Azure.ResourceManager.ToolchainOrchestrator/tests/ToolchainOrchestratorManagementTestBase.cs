// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using Azure.ResourceManager.ToolchainOrchestrator.Models;
using System.Xml.Linq;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.ToolchainOrchestrator.Tests
{
    public class ToolchainOrchestratorManagementTestBase : ManagementRecordedTestBase<ToolchainOrchestratorManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }
        protected SubscriptionResource DefaultSubscription { get; private set; }
        protected AzureLocation DefaultLocation => AzureLocation.EastUS;
        protected Stack<Action> CleanupActions { get; } = new Stack<Action>();

        protected ToolchainOrchestratorManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected ToolchainOrchestratorManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public async Task Setup()
        {
            Client = GetArmClient();
            DefaultSubscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
        }

        protected async Task<ResourceGroupResource> CreateResourceGroup(SubscriptionResource subscription, string rgNamePrefix, AzureLocation location)
        {
            string rgName = Recording.GenerateAssetName(rgNamePrefix);
            ResourceGroupData input = new ResourceGroupData(location);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }
        protected async Task<SolutionResource> CreateOrUpdateSolution(string name = null, bool verifyResult = false)
        {
            ResourceGroupResource ResourceGroup = await CreateResourceGroup(this.DefaultSubscription, "rg-symphonytest", DefaultLocation);
            SolutionCollection storageCacheCollectionVar = ResourceGroup.GetSolutions();
            string cacheNameVar = name ?? Recording.GenerateAssetName("testsc");
            SolutionData dataVar = new SolutionData(this.DefaultLocation, new ExtendedLocation() { Name = $"/subscriptions/{DefaultSubscription.Id.SubscriptionId}/resourceGroups/shawntest/providers/Microsoft.ExtendedLocation/customLocations/shawncustomlo", Type = "CustomLocation"});

            ArmOperation<SolutionResource> lro = await storageCacheCollectionVar.CreateOrUpdateAsync(
                waitUntil: WaitUntil.Completed,
                solutionName: cacheNameVar,
                data: dataVar);
            this.CleanupActions.Push(async () => await lro.Value.DeleteAsync(WaitUntil.Completed));
            if (verifyResult)
            {
                this.VerifySolution(lro.Value, dataVar);
            }
            return lro.Value;
        }

        protected void VerifySolution(SolutionResource actual, SolutionData expected)
        {
            Assert.AreEqual(actual.Data.ExtendedLocation.Type, expected.ExtendedLocation.Type);
            Assert.AreEqual(actual.Data.ExtendedLocation.Name, expected.ExtendedLocation.Name);
        }
        protected async Task<SolutionVersionResource> CreateOrUpdateSolutionVersion(SolutionResource solution, string name = null, bool verifyResult = false)
        {
            SolutionVersionCollection svCollectionVar = solution.GetSolutionVersions();
            string cacheNameVar = name ?? Recording.GenerateAssetName("testsolutionver");
            SolutionVersionData dataVar = new SolutionVersionData(this.DefaultLocation);
            dataVar.ExtendedLocation = new ExtendedLocation() { Name = $"/subscriptions/{DefaultSubscription.Id.SubscriptionId}/resourceGroups/shawntest/providers/Microsoft.ExtendedLocation/customLocations/shawncustomlo", Type = "CustomLocation" };

            string jsonString = @"
            {
              ""metadata"" : {
                  ""deployment.replicas"" : ""#1"",
                  ""service.ports"" : ""[{\""name\"":\""port9090\"",\""port\"": 9090}]"",
                  ""service.type"" : ""LoadBalancer""
              },
              ""components"" : [
                  {
                      ""name"" : ""sample-prometheus-server"",
                      ""type"" : ""k8s.container"",
                      ""properties"" : {
                          ""container.ports"" : ""[{\""containerPort\"":9090,\""protocol\"":\""TCP\""}]"",
                          ""container.imagePullPolicy"" : ""Always"",
                          ""container.resources"" : ""{\""requests\"":{\""cpu\"":\""100m\"",\""memory\"":\""100Mi\""}}"",
                          ""container.image"" : ""mcr.microsoft.com/cbl-mariner/base/prometheus:2.37""
                      }
                  }
              ]
            }";
            SolutionVersionProperties properties = new SolutionVersionProperties();
            dataVar.Properties = properties.DeserializeJson(jsonString);
            ArmOperation<SolutionVersionResource> lro = await svCollectionVar.CreateOrUpdateAsync(
                waitUntil: WaitUntil.Completed,
                versionName: cacheNameVar,
                data: dataVar);
            this.CleanupActions.Push(async () => await lro.Value.DeleteAsync(WaitUntil.Completed));
            if (verifyResult)
            {
                this.VerifySolutionVersion(lro.Value, dataVar);
            }
            return lro.Value;
        }
        protected void VerifySolutionVersion(SolutionVersionResource actual, SolutionVersionData expected)
        {
            Assert.AreEqual(actual.Data.ExtendedLocation.Type, expected.ExtendedLocation.Type);
            Assert.AreEqual(actual.Data.ExtendedLocation.Name, expected.ExtendedLocation.Name);
            Assert.AreEqual(actual.Data.Properties.Components[0].Type, expected.Properties.Components[0].Type);
        }

        protected async Task<TargetResource> CreateOrUpdateTarget(string name = null, bool verifyResult = false)
        {
            ResourceGroupResource ResourceGroup = await CreateResourceGroup(this.DefaultSubscription, "rg-symphonytest", DefaultLocation);
            TargetCollection targetCollectionVar = ResourceGroup.GetTargets();
            string cacheNameVar = name ?? Recording.GenerateAssetName("testtarget");
            TargetData dataVar = new TargetData(this.DefaultLocation, new ExtendedLocation() { Name = $"/subscriptions/{DefaultSubscription.Id.SubscriptionId}/resourceGroups/shawntest/providers/Microsoft.ExtendedLocation/customLocations/shawncustomlo", Type = "CustomLocation" });

            string jsonString = @"
            {
                ""topologies"" : [
                    {
                        ""bindings"" : [
                            {
                                ""role"" : ""k8s.container"",
                                ""provider"" : ""providers.target.k8s"",
                                ""config"" : {
                                ""inCluster"" : ""true""
                                }
                            }
                        ]
                    }
                ]
            }";
            TargetProperties properties = new TargetProperties();
            dataVar.Properties = properties.DeserializeJson(jsonString);
            ArmOperation<TargetResource> lro = await targetCollectionVar.CreateOrUpdateAsync(
                waitUntil: WaitUntil.Completed,
                targetName: cacheNameVar,
                data: dataVar);
            this.CleanupActions.Push(async () => await lro.Value.DeleteAsync(WaitUntil.Completed));
            if (verifyResult)
            {
                this.VerifyTarget(lro.Value, dataVar);
            }
            return lro.Value;
        }
        protected void VerifyTarget(TargetResource actual, TargetData expected)
        {
            Assert.AreEqual(actual.Data.ExtendedLocation.Type, expected.ExtendedLocation.Type);
            Assert.AreEqual(actual.Data.ExtendedLocation.Name, expected.ExtendedLocation.Name);
            Assert.AreEqual(actual.Data.Properties.Topologies[0].Bindings[0].Role, expected.Properties.Topologies[0].Bindings[0].Role);
        }
        protected async Task<InstanceResource> CreateOrUpdateInstance(string name = null, string solutionName = null, string targetName = null, bool verifyResult = false)
        {
            ResourceGroupResource ResourceGroup = await CreateResourceGroup(this.DefaultSubscription, "rg-symphonytest", DefaultLocation);
            InstanceCollection targetCollectionVar = ResourceGroup.GetInstances();
            string cacheNameVar = name ?? Recording.GenerateAssetName("testtarget");
            InstanceData dataVar = new InstanceData(this.DefaultLocation, new ExtendedLocation() { Name = $"/subscriptions/{DefaultSubscription.Id.SubscriptionId}/resourceGroups/shawntest/providers/Microsoft.ExtendedLocation/customLocations/shawncustomlo", Type = "CustomLocation" });
            InstanceProperties properties = new InstanceProperties(solutionName);
            properties.Target = new TargetSelectorProperties();
            properties.Target.Name = targetName;
            properties.Scope = "scope1";
            dataVar.Properties = properties;
            ArmOperation<InstanceResource> lro = await targetCollectionVar.CreateOrUpdateAsync(
                waitUntil: WaitUntil.Completed,
                instanceName: cacheNameVar,
                data: dataVar);
            this.CleanupActions.Push(async () => await lro.Value.DeleteAsync(WaitUntil.Completed));
            if (verifyResult)
            {
                this.VerifyInstance(lro.Value, dataVar);
            }
            return lro.Value;
        }
        protected void VerifyInstance(InstanceResource actual, InstanceData expected)
        {
            Assert.AreEqual(actual.Data.ExtendedLocation.Type, expected.ExtendedLocation.Type);
            Assert.AreEqual(actual.Data.ExtendedLocation.Name, expected.ExtendedLocation.Name);
            Assert.AreEqual(actual.Data.Properties.Target.Name, expected.Properties.Target.Name);
        }
        protected async Task<CampaignResource> CreateOrUpdateCampaign(string name = null, string solutionName = null, string targetName = null, bool verifyResult = false)
        {
            ResourceGroupResource ResourceGroup = await CreateResourceGroup(this.DefaultSubscription, "rg-symphonytest", DefaultLocation);
            CampaignCollection camCollectionVar = ResourceGroup.GetCampaigns();
            string cacheNameVar = name ?? Recording.GenerateAssetName("testcampaign");
            CampaignData dataVar = new CampaignData(this.DefaultLocation, new ExtendedLocation() { Name = $"/subscriptions/{DefaultSubscription.Id.SubscriptionId}/resourceGroups/shawntest/providers/Microsoft.ExtendedLocation/customLocations/shawncustomlo", Type = "CustomLocation" });
            ArmOperation<CampaignResource> lro = await camCollectionVar.CreateOrUpdateAsync(
                waitUntil: WaitUntil.Completed,
                campaignName: cacheNameVar,
                data: dataVar);
            this.CleanupActions.Push(async () => await lro.Value.DeleteAsync(WaitUntil.Completed));
            if (verifyResult)
            {
                this.VerifyCampaign(lro.Value, dataVar);
            }
            return lro.Value;
        }
        protected void VerifyCampaign(CampaignResource actual, CampaignData expected)
        {
            Assert.AreEqual(actual.Data.ExtendedLocation.Type, expected.ExtendedLocation.Type);
            Assert.AreEqual(actual.Data.ExtendedLocation.Name, expected.ExtendedLocation.Name);
        }

        protected async Task<CampaignVersionResource> CreateOrUpdateCampaignVersion(CampaignResource campaign, string name = null, bool verifyResult = false)
        {
            CampaignVersionCollection svCollectionVar = campaign.GetCampaignVersions();
            string cacheNameVar = name ?? Recording.GenerateAssetName("testcampaignver");
            CampaignVersionData dataVar = new CampaignVersionData(this.DefaultLocation);
            dataVar.ExtendedLocation = new ExtendedLocation() { Name = $"/subscriptions/{DefaultSubscription.Id.SubscriptionId}/resourceGroups/shawntest/providers/Microsoft.ExtendedLocation/customLocations/shawncustomlo", Type = "CustomLocation" };

            string jsonString = @"
            {
                ""firstStage"": ""wait"",
                ""stages"": {
                    ""wait"": {
                        ""name"": ""wait"",
                        ""provider"": ""providers.stage.wait"",
                        ""stageSelector"": ""list"",
                        ""config"": {
                            ""baseUrl"": ""http://symphony-service:8080/v1alpha2/"",
                            ""user"": ""admin"",
                            ""password"": """"
                        },
                        ""inputs"": {
                            ""objectType"": ""catalogs"",
                            ""names"": [
                                ""sitecatalog:v1"",
                                ""sitecatalog2:v1"",
                                ""siteapp:v1"",
                                ""sitek8starget:v1"",
                                ""siteinstance:v1""
                            ]
                        }
                    },
                    ""list"": {
                        ""name"": ""list"",
                        ""provider"": ""providers.stage.list"",
                        ""stageSelector"": ""deploy"",
                        ""config"": {
                            ""baseUrl"": ""http://symphony-service:8080/v1alpha2/"",
                            ""user"": ""admin"",
                            ""password"": """"
                        },
                        ""inputs"": {
                            ""objectType"": ""catalogs"",
                            ""namesOnly"": true
                        }
                    },
                    ""deploy"": {
                        ""name"": ""deploy"",
                        ""provider"": ""providers.stage.materialize"",
                        ""stageSelector"": """",
                        ""schedule"": ""2020-10-31T12:00:00-07:00"",
                        ""config"": {
                            ""baseUrl"": ""http://symphony-service:8080/v1alpha2/"",
                            ""user"": ""admin"",
                            ""password"": """"
                        },
                        ""inputs"": {
                            ""names"": ""${{$output(list,items)}}""
                        }
                    }
                },
                ""selfDriving"": true
            }";
            CampaignVersionProperties properties = new CampaignVersionProperties();
            dataVar.Properties = properties.DeserializeJson(jsonString);
            ArmOperation<CampaignVersionResource> lro = await svCollectionVar.CreateOrUpdateAsync(
                waitUntil: WaitUntil.Completed,
                versionName: cacheNameVar,
                data: dataVar);
            this.CleanupActions.Push(async () => await lro.Value.DeleteAsync(WaitUntil.Completed));
            if (verifyResult)
            {
                this.VerifyCampaignVersion(lro.Value, dataVar);
            }
            return lro.Value;
        }
        protected void VerifyCampaignVersion(CampaignVersionResource actual, CampaignVersionData expected)
        {
            Assert.AreEqual(actual.Data.ExtendedLocation.Type, expected.ExtendedLocation.Type);
            Assert.AreEqual(actual.Data.ExtendedLocation.Name, expected.ExtendedLocation.Name);
            Assert.AreEqual(actual.Data.Properties.Stages["deploy"].Provider, expected.Properties.Stages["deploy"].Provider);
        }
    }
}
