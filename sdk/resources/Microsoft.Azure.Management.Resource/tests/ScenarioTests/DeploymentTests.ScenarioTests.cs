// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Test;
using Microsoft.Rest.Azure.OData;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Newtonsoft.Json.Linq;
using Xunit;

namespace ResourceGroups.Tests
{
    public class LiveDeploymentTests : TestBase
    {
        const string DummyTemplateUri = "https://testtemplates.blob.core.windows.net/templates/dummytemplate.js";
        const string GoodWebsiteTemplateUri = "https://raw.githubusercontent.com/Azure/azure-quickstart-templates/master/201-web-app-github-deploy/azuredeploy.json";
        const string BadTemplateUri = "https://testtemplates.blob.core.windows.net/templates/bad-website-1.js";
        const string GoodResourceId = "/subscriptions/a1bfa635-f2bf-42f1-86b5-848c674fc321/resourceGroups/TemplateSpecSDK/providers/Microsoft.Resources/TemplateSpecs/SdkTestTemplate/versions/1.0.0";

        const string LocationWestEurope = "West Europe";
        const string LocationSouthCentralUS = "South Central US";

        public ResourceManagementClient GetResourceManagementClient(MockContext context, RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            return this.GetResourceManagementClientWithHandler(context, handler);
        }

        // TODO: Fix
        [Fact (Skip = "TODO: Re-record test")]
        public void CreateDummyDeploymentTemplateWorks()
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.Created };

            var dictionary = new Dictionary<string, object> {
                    {"string", new Dictionary<string, object>() {
                        {"value", "myvalue"},
                    }},
                    {"securestring", new Dictionary<string, object>() {
                        {"value", "myvalue"},
                    }},
                    {"int", new Dictionary<string, object>() {
                        {"value", 42},
                    }},
                    {"bool", new Dictionary<string, object>() {
                        {"value", true},
                    }}
                };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var client = GetResourceManagementClient(context, handler);
                var parameters = new Deployment
                {
                    Properties = new DeploymentProperties()
                    {
                        TemplateLink = new TemplateLink
                        {
                            Uri = DummyTemplateUri
                        },
                        Parameters = dictionary,
                        Mode = DeploymentMode.Incremental,
                    }
                };

                string groupName = TestUtilities.GenerateName("csmrg");
                string deploymentName = TestUtilities.GenerateName("csmd");
                client.ResourceGroups.CreateOrUpdate(groupName, new ResourceGroup { Location = LiveDeploymentTests.LocationWestEurope });
                client.Deployments.CreateOrUpdate(groupName, deploymentName, parameters);

                JObject json = JObject.Parse(handler.Request);

                Assert.NotNull(client.Deployments.Get(groupName, deploymentName));
            }
        }

        [Fact()]
        public void CreateDeploymentWithStringTemplateAndParameters()
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.Created };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var client = GetResourceManagementClient(context, handler);
                var parameters = new Deployment
                {
                    Properties = new DeploymentProperties()
                    {
                        Template = File.ReadAllText(Path.Combine("ScenarioTests", "simple-storage-account.json")),
                        Parameters = File.ReadAllText(Path.Combine("ScenarioTests", "simple-storage-account-parameters.json")),
                        Mode = DeploymentMode.Incremental,
                    }
                };

                string groupName = TestUtilities.GenerateName("csmrg");
                string deploymentName = TestUtilities.GenerateName("csmd");
                client.ResourceGroups.CreateOrUpdate(groupName, new ResourceGroup { Location = LiveDeploymentTests.LocationWestEurope });
                client.Deployments.CreateOrUpdate(groupName, deploymentName, parameters);

                var deployment = client.Deployments.Get(groupName, deploymentName);
                Assert.Equal("Succeeded", deployment.Properties.ProvisioningState);
            }
        }

        [Fact]
        public void CreateDeploymentAndValidateProperties()
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.Created };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var client = GetResourceManagementClient(context, handler);
                string resourceName = TestUtilities.GenerateName("csmr");

                var parameters = new Deployment
                {
                    Properties = new DeploymentProperties()
                    {
                        TemplateLink = new TemplateLink
                        {
                            Uri = GoodWebsiteTemplateUri,
                        },
                        Parameters =
                        JObject.Parse(
                            @"{'repoURL': {'value': 'https://github.com/devigned/az-roadshow-oss.git'}, 'siteName': {'value': '" + resourceName  + "'}, 'location': {'value': 'westus'}, 'sku': {'value': 'F1'}}"),
                        Mode = DeploymentMode.Incremental,
                    },
                    Tags = new Dictionary<string, string> { { "tagKey1", "tagValue1" } }
                };
                string groupName = TestUtilities.GenerateName("csmrg");
                string deploymentName = TestUtilities.GenerateName("csmd");
                client.ResourceGroups.CreateOrUpdate(groupName, new ResourceGroup { Location = LiveDeploymentTests.LocationWestEurope });
                var deploymentCreateResult = client.Deployments.CreateOrUpdate(groupName, deploymentName, parameters);

                Assert.NotNull(deploymentCreateResult.Id);
                Assert.Equal(deploymentName, deploymentCreateResult.Name);

                TestUtilities.Wait(1000);

                var deploymentListResult = client.Deployments.ListByResourceGroup(groupName, null);
                var deploymentGetResult = client.Deployments.Get(groupName, deploymentName);

                Assert.NotEmpty(deploymentListResult);
                Assert.Equal(deploymentName, deploymentGetResult.Name);
                Assert.Equal(deploymentName, deploymentListResult.First().Name);
                Assert.Equal(GoodWebsiteTemplateUri, deploymentGetResult.Properties.TemplateLink.Uri);
                Assert.Equal(GoodWebsiteTemplateUri, deploymentListResult.First().Properties.TemplateLink.Uri);
                Assert.NotNull(deploymentGetResult.Properties.ProvisioningState);
                Assert.NotNull(deploymentListResult.First().Properties.ProvisioningState);
                Assert.NotNull(deploymentGetResult.Properties.CorrelationId);
                Assert.NotNull(deploymentListResult.First().Properties.CorrelationId);
                Assert.NotNull(deploymentListResult.First().Tags);
                Assert.True(deploymentListResult.First().Tags.ContainsKey("tagKey1"));
            }
        }

        [Fact]
        public void CreateDeploymentWithResourceId()
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.Created };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var client = GetResourceManagementClient(context, handler);
                string resourceName = TestUtilities.GenerateName("csmr");

                var parameters = new Deployment
                {
                    Properties = new DeploymentProperties()
                    {
                        TemplateLink = new TemplateLink
                        {
                            Id = GoodResourceId
                        },
                        Parameters =
                        JObject.Parse(
                            @"{'repoURL': {'value': 'https://github.com/devigned/az-roadshow-oss.git'}, 'siteName': {'value': '" + resourceName + "'}, 'location': {'value': 'westus'}, 'sku': {'value': 'F1'}}"),
                        Mode = DeploymentMode.Incremental,
                    },
                    Tags = new Dictionary<string, string> { { "tagKey1", "tagValue1" } }
                };
                string groupName = TestUtilities.GenerateName("csmrg");
                string deploymentName = TestUtilities.GenerateName("csmd");
                client.ResourceGroups.CreateOrUpdate(groupName, new ResourceGroup { Location = LiveDeploymentTests.LocationWestEurope });
                var deploymentCreateResult = client.Deployments.CreateOrUpdate(groupName, deploymentName, parameters);

                Assert.NotNull(deploymentCreateResult.Id);
                Assert.Equal(deploymentName, deploymentCreateResult.Name);

                TestUtilities.Wait(1000);

                var deploymentListResult = client.Deployments.ListByResourceGroup(groupName, null);
                var deploymentGetResult = client.Deployments.Get(groupName, deploymentName);

                Assert.NotEmpty(deploymentListResult);
                Assert.Equal(deploymentName, deploymentGetResult.Name);
                Assert.Equal(deploymentName, deploymentListResult.First().Name);
                Assert.Equal(GoodResourceId, deploymentGetResult.Properties.TemplateLink.Id);
                Assert.Equal(GoodResourceId, deploymentListResult.First().Properties.TemplateLink.Id);
                Assert.NotNull(deploymentGetResult.Properties.ProvisioningState);
                Assert.NotNull(deploymentListResult.First().Properties.ProvisioningState);
                Assert.NotNull(deploymentGetResult.Properties.CorrelationId);
                Assert.NotNull(deploymentListResult.First().Properties.CorrelationId);
                Assert.NotNull(deploymentListResult.First().Tags);
                Assert.True(deploymentListResult.First().Tags.ContainsKey("tagKey1"));
            }
        }

        [Fact]
        public void ValidateGoodDeployment()
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.Created };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var client = GetResourceManagementClient(context, handler);
                string groupName = TestUtilities.GenerateName("csmrg");
                string deploymentName = TestUtilities.GenerateName("csmd");
                string resourceName = TestUtilities.GenerateName("csres");

                var parameters = new Deployment
                {
                    Properties = new DeploymentProperties()
                    {
                        TemplateLink = new TemplateLink
                        {
                            Uri = GoodWebsiteTemplateUri,
                        },
                        Parameters =
                        JObject.Parse(@"{'repoURL': {'value': 'https://github.com/devigned/az-roadshow-oss.git'}, 'siteName': {'value': '" + resourceName + "'}, 'location': {'value': 'westus'}, 'sku': {'value': 'F1'}}"),
                        Mode = DeploymentMode.Incremental,
                    }
                };

                client.ResourceGroups.CreateOrUpdate(groupName, new ResourceGroup { Location = LiveDeploymentTests.LocationWestEurope });

                //Action
                var validationResult = client.Deployments.Validate(groupName, deploymentName, parameters);
 
                 //Assert
                Assert.Null(validationResult.Error);
                Assert.NotNull(validationResult.Properties);
                Assert.NotNull(validationResult.Properties.Providers);
                Assert.Equal(1, validationResult.Properties.Providers.Count);
                Assert.Equal("Microsoft.Web", validationResult.Properties.Providers[0].NamespaceProperty);
            }
        }

        [Fact]
        public void ValidateGoodDeploymentWithId()
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.Created };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var client = GetResourceManagementClient(context, handler);
                string groupName = TestUtilities.GenerateName("csmrg");
                string deploymentName = TestUtilities.GenerateName("csmd");
                string resourceName = TestUtilities.GenerateName("csres");

                var parameters = new Deployment
                {
                    Properties = new DeploymentProperties()
                    {
                        TemplateLink = new TemplateLink
                        {
                            Id = GoodResourceId,
                        },
                        Parameters =
                        JObject.Parse(@"{'repoURL': {'value': 'https://github.com/devigned/az-roadshow-oss.git'}, 'siteName': {'value': '" + resourceName + "'}, 'location': {'value': 'westus'}, 'sku': {'value': 'F1'}}"),
                        Mode = DeploymentMode.Incremental,
                    }
                };

                client.ResourceGroups.CreateOrUpdate(groupName, new ResourceGroup { Location = LiveDeploymentTests.LocationWestEurope });

                //Action
                var validationResult = client.Deployments.Validate(groupName, deploymentName, parameters);

                //Assert
                Assert.Null(validationResult.Error);
                Assert.NotNull(validationResult.Properties);
                Assert.NotNull(validationResult.Properties.Providers);
                Assert.Equal(1, validationResult.Properties.Providers.Count);
                Assert.Equal("Microsoft.Web", validationResult.Properties.Providers[0].NamespaceProperty);
            }
        }

        //TODO: Fix
        [Fact(Skip = "TODO: Re-record test")]
        public void ValidateGoodDeploymentWithInlineTemplate()
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.Created };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var client = GetResourceManagementClient(context, handler);
                string groupName = TestUtilities.GenerateName("csmrg");
                string deploymentName = TestUtilities.GenerateName("csmd");
                string resourceName = TestUtilities.GenerateName("csmr");

                var parameters = new Deployment
                {
                    Properties = new DeploymentProperties()
                   {
                        Template = File.ReadAllText(Path.Combine("ScenarioTests", "good-website.json")),
                        Parameters =
                        JObject.Parse(@"{'repoURL': {'value': 'https://github.com/devigned/az-roadshow-oss.git'}, 'siteName': {'value': '" + resourceName + "'}, 'hostingPlanName': {'value': 'someplan'}, 'siteLocation': {'value': 'westus'}, 'sku': {'value': 'Standard'}}"),
                        Mode = DeploymentMode.Incremental,
                    }
                };

                client.ResourceGroups.CreateOrUpdate(groupName, new ResourceGroup { Location = LiveDeploymentTests.LocationWestEurope });

                //Action
                var validationResult = client.Deployments.Validate(groupName, deploymentName, parameters);

                //Assert
                Assert.Null(validationResult.Error);
                Assert.NotNull(validationResult.Properties);
                Assert.NotNull(validationResult.Properties.Providers);
                Assert.Equal(1, validationResult.Properties.Providers.Count);
                Assert.Equal("Microsoft.Web", validationResult.Properties.Providers[0].NamespaceProperty);
            }
        }

        [Fact]
        public void ValidateBadDeployment()
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.Created };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var client = GetResourceManagementClient(context, handler);

                string groupName = TestUtilities.GenerateName("csmrg");
                string deploymentName = TestUtilities.GenerateName("csmd");
                var parameters = new Deployment
                {
                    Properties = new DeploymentProperties()
                    {
                        TemplateLink = new TemplateLink
                        {
                            Uri = BadTemplateUri,
                        },
                        Parameters =
                        JObject.Parse(@"{ 'siteName': {'value': 'mctest0101'},'hostingPlanName': {'value': 'mctest0101'},'siteMode': {'value': 'Limited'},'computeMode': {'value': 'Shared'},'siteLocation': {'value': 'North Europe'},'sku': {'value': 'Free'},'workerSize': {'value': '0'}}"),
                        Mode = DeploymentMode.Incremental,
                    }
                };

                client.ResourceGroups.CreateOrUpdate(groupName, new ResourceGroup { Location = LiveDeploymentTests.LocationWestEurope });
                var result = client.Deployments.Validate(groupName, deploymentName, parameters);
                Assert.NotNull(result);
                Assert.Equal("InvalidTemplate", result.Error.Code);
            }
        }

        [Fact]
        public void CreateDeploymentCheckSuccessOperations()
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.Created };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var client = GetResourceManagementClient(context, handler);
                string groupName = TestUtilities.GenerateName("csmrg");
                string deploymentName = TestUtilities.GenerateName("csmd");
                string resourceName = TestUtilities.GenerateName("csres");

                var parameters = new Deployment
                {
                    Properties = new DeploymentProperties()
                    {
                        TemplateLink = new TemplateLink
                        {
                            Id = GoodResourceId,
                        },
                        Parameters =
                        JObject.Parse(@"{'repoURL': {'value': 'https://github.com/devigned/az-roadshow-oss.git'}, 'siteName': {'value': '" + resourceName + "'}, 'location': {'value': 'westus'}, 'sku': {'value': 'F1'}}"),
                        Mode = DeploymentMode.Incremental,
                    }
                };

                client.ResourceGroups.CreateOrUpdate(groupName, new ResourceGroup { Location = LiveDeploymentTests.LocationWestEurope });

                client.Deployments.CreateOrUpdate(groupName, deploymentName, parameters);

                //Wait for deployment to complete
                TestUtilities.Wait(30000);
                var operations = client.DeploymentOperations.List(groupName, deploymentName, null);

                Assert.True(operations.Any());
                Assert.NotNull(operations.First().Id);
                Assert.NotNull(operations.First().OperationId);
                Assert.NotNull(operations.First().Properties);
                Assert.Null(operations.First().Properties.StatusMessage);
            }

        }

            // TODO: Fix
            [Fact(Skip = "TODO: Re-record test")]
        public void CreateDummyDeploymentProducesOperations()
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.Created };
            var dictionary = new Dictionary<string, object> {
                    {"string", new Dictionary<string, object>() {
                        {"value", "myvalue"},
                    }},
                    {"securestring", new Dictionary<string, object>() {
                        {"value", "myvalue"},
                    }},
                    {"int", new Dictionary<string, object>() {
                        {"value", 42},
                    }},
                    {"bool", new Dictionary<string, object>() {
                        {"value", true},
                    }}
                };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var client = GetResourceManagementClient(context, handler);
                var parameters = new Deployment
                {
                    Properties = new DeploymentProperties()
                    {
                        TemplateLink = new TemplateLink
                        {
                            Uri = DummyTemplateUri
                        },
                        Parameters = dictionary,
                        Mode = DeploymentMode.Incremental,
                    }
                };

                string groupName = TestUtilities.GenerateName("csmrg");
                string deploymentName = TestUtilities.GenerateName("csmd");
                string resourceName = TestUtilities.GenerateName("csmr");

                client.ResourceGroups.CreateOrUpdate(groupName, new ResourceGroup { Location = LiveDeploymentTests.LocationWestEurope });
                client.Deployments.CreateOrUpdate(groupName, deploymentName, parameters);

                // Wait until deployment completes
                TestUtilities.Wait(30000);
                var operations = client.DeploymentOperations.List(groupName, deploymentName, null);

                Assert.True(operations.Any());
                Assert.NotNull(operations.First().Id);
                Assert.NotNull(operations.First().OperationId);
                Assert.NotNull(operations.First().Properties);
            }
        }

        // TODO: Fix
        [Fact(Skip = "TODO: Re-record test")]
        public void ListDeploymentsWorksWithFilter()
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.Created };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var client = GetResourceManagementClient(context, handler);
                string resourceName = TestUtilities.GenerateName("csmr");

                var parameters = new Deployment
                {
                    Properties = new DeploymentProperties()
                    {
                        TemplateLink = new TemplateLink
                        {
                            Uri = GoodWebsiteTemplateUri,
                        },
                        Parameters =
                        JObject.Parse(@"{'repoURL': {'value': 'https://github.com/devigned/az-roadshow-oss.git'}, 'siteName': {'value': '" + resourceName + "'}, 'hostingPlanName': {'value': 'someplan'}, 'siteLocation': {'value': 'westus'}, 'sku': {'value': 'Standard'}}"),
                        Mode = DeploymentMode.Incremental,
                    }
                };
                string groupName = TestUtilities.GenerateName("csmrg");
                string deploymentName = TestUtilities.GenerateName("csmd");
                client.ResourceGroups.CreateOrUpdate(groupName, new ResourceGroup { Location = LiveDeploymentTests.LocationWestEurope });
                client.Deployments.CreateOrUpdate(groupName, deploymentName, parameters);

                var deploymentListResult = client.Deployments.ListByResourceGroup(groupName, new ODataQuery<DeploymentExtendedFilter>(d => d.ProvisioningState == "Running"));
                if (null == deploymentListResult|| deploymentListResult.Count() == 0)
                {
                    deploymentListResult = client.Deployments.ListByResourceGroup(groupName, new ODataQuery<DeploymentExtendedFilter>(d => d.ProvisioningState == "Accepted"));
                }
                var deploymentGetResult = client.Deployments.Get(groupName, deploymentName);

                Assert.NotEmpty(deploymentListResult);
                Assert.Equal(deploymentName, deploymentGetResult.Name);
                Assert.Equal(deploymentName, deploymentListResult.First().Name);
                Assert.Equal(GoodWebsiteTemplateUri, deploymentGetResult.Properties.TemplateLink.Uri);
                Assert.Equal(GoodWebsiteTemplateUri, deploymentListResult.First().Properties.TemplateLink.Uri);
                Assert.NotNull(deploymentGetResult.Properties.ProvisioningState);
                Assert.NotNull(deploymentListResult.First().Properties.ProvisioningState);
                Assert.NotNull(deploymentGetResult.Properties.CorrelationId);
                Assert.NotNull(deploymentListResult.First().Properties.CorrelationId);
                Assert.Contains("mctest0101", deploymentGetResult.Properties.Parameters.ToString());
                Assert.Contains("mctest0101", deploymentListResult.First().Properties.Parameters.ToString());
            }
        }

        [Fact]
        public void CreateLargeWebDeploymentTemplateWorks()
        {
            var handler = new RecordedDelegatingHandler();
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                string resourceName = TestUtilities.GenerateName("csmr");
                string groupName = TestUtilities.GenerateName("csmrg");
                string deploymentName = TestUtilities.GenerateName("csmd");

                var client = GetResourceManagementClient(context, handler);
                var parameters = new Deployment
                {
                    Properties = new DeploymentProperties()
                    {
                        TemplateLink = new TemplateLink
                        {
                            Uri = GoodWebsiteTemplateUri,
                        },
                        Parameters =
                        JObject.Parse("{'repoURL': {'value': 'https://github.com/devigned/az-roadshow-oss.git'}, 'siteName': {'value': '" + resourceName + "'}, 'location': {'value': 'westus'}, 'sku': {'value': 'F1'}}"),
                        Mode = DeploymentMode.Incremental,
                    }
                };

                client.ResourceGroups.CreateOrUpdate(groupName, new ResourceGroup { Location = LiveDeploymentTests.LocationSouthCentralUS });
                client.Deployments.CreateOrUpdate(groupName, deploymentName, parameters);

                // Wait until deployment completes
                TestUtilities.Wait(30000);
                var operations = client.DeploymentOperations.List(groupName, deploymentName, null);

                Assert.True(operations.Any());
            }
        }

        [Fact]
        public void SubscriptionLevelDeployment()
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.Created };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var client = GetResourceManagementClient(context, handler);
                string groupName = "SDK-test";
                string deploymentName = TestUtilities.GenerateName("csmd");
                string resourceName = TestUtilities.GenerateName("csmr");

                var parameters = new Deployment
                {
                    Properties = new DeploymentProperties()
                    {
                        Template = JObject.Parse(File.ReadAllText(Path.Combine("ScenarioTests", "subscription_level_template.json"))),
                        Parameters =
                        JObject.Parse("{'storageAccountName': {'value': 'armbuilddemo1803'}}"),
                        Mode = DeploymentMode.Incremental,
                    },
                    Location = "WestUS",
                    Tags = new Dictionary<string, string> { { "tagKey1", "tagValue1" } }
                };

                client.ResourceGroups.CreateOrUpdate(groupName, new ResourceGroup { Location = "WestUS" });

                //Validate
                var validationResult = client.Deployments.ValidateAtSubscriptionScope(deploymentName, parameters);

                //Assert
                Assert.Null(validationResult.Error);
                Assert.NotNull(validationResult.Properties);
                Assert.NotNull(validationResult.Properties.Providers);

                //Put deployment
                var deploymentResult = client.Deployments.CreateOrUpdateAtSubscriptionScope(deploymentName, parameters);

                var deployment = client.Deployments.GetAtSubscriptionScope(deploymentName);
                Assert.Equal("Succeeded", deployment.Properties.ProvisioningState);
                Assert.NotNull(deployment.Tags);
                Assert.True(deployment.Tags.ContainsKey("tagKey1"));
            }
        }

        [Fact]
        public void ManagementGroupLevelDeployment()
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.Created };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var client = GetResourceManagementClient(context, handler);
                string groupId = "tag-mg-sdk";
                string deploymentName = TestUtilities.GenerateName("csharpsdktest");

                var parameters = new ScopedDeployment
                {
                    Properties = new DeploymentProperties()
                    {
                        Template = JObject.Parse(File.ReadAllText(Path.Combine("ScenarioTests", "management_group_level_template.json"))),
                        Parameters =
                        JObject.Parse("{'storageAccountName': {'value': 'tagsa060120'}}"),
                        Mode = DeploymentMode.Incremental,
                    },
                    Location = "East US",
                    Tags = new Dictionary<string, string> { { "tagKey1", "tagValue1" } }
                };

                //Validate
                var validationResult = client.Deployments.ValidateAtManagementGroupScope(groupId, deploymentName, parameters);

                //Assert
                Assert.Null(validationResult.Error);
                Assert.NotNull(validationResult.Properties);
                Assert.NotNull(validationResult.Properties.Providers);

                //Put deployment
                var deploymentResult = client.Deployments.CreateOrUpdateAtManagementGroupScope(groupId, deploymentName, parameters);

                var deployment = client.Deployments.GetAtManagementGroupScope(groupId, deploymentName);
                Assert.Equal("Succeeded", deployment.Properties.ProvisioningState);
                Assert.NotNull(deployment.Tags);
                Assert.True(deployment.Tags.ContainsKey("tagKey1"));
            }
        }

        [Fact]
        public void TenantLevelDeployment()
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.Created };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var client = GetResourceManagementClient(context, handler);
                string deploymentName = TestUtilities.GenerateName("csharpsdktest");

                var parameters = new ScopedDeployment
                {
                    Properties = new DeploymentProperties()
                    {
                        Template = JObject.Parse(File.ReadAllText(Path.Combine("ScenarioTests", "tenant_level_template.json"))),
                        Parameters =
                        JObject.Parse("{'managementGroupId': {'value': 'gopremra-testmg'}}"),
                        Mode = DeploymentMode.Incremental,
                    },
                    Location = "East US 2",
                    Tags = new Dictionary<string, string> { { "tagKey1", "tagValue1" } }
                };

                //Validate
                var validationResult = client.Deployments.ValidateAtTenantScope(deploymentName, parameters);

                //Assert
                Assert.Null(validationResult.Error);
                Assert.NotNull(validationResult.Properties);
                Assert.NotNull(validationResult.Properties.Providers);

                //Put deployment
                var deploymentResult = client.Deployments.CreateOrUpdateAtTenantScope(deploymentName, parameters);

                var deployment = client.Deployments.GetAtTenantScope(deploymentName);
                Assert.Equal("Succeeded", deployment.Properties.ProvisioningState);
                Assert.NotNull(deployment.Tags);
                Assert.True(deployment.Tags.ContainsKey("tagKey1"));

                var deploymentOperations = client.DeploymentOperations.ListAtTenantScope(deploymentName);
                Assert.Equal(4, deploymentOperations.Count());
            }
        }

        [Fact]
        public void DeploymentWithScope_AtTenant()
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.Created };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var client = GetResourceManagementClient(context, handler);
                string deploymentName = TestUtilities.GenerateName("csharpsdktest");

                var parameters = new Deployment
                {
                    Properties = new DeploymentProperties()
                    {
                        Template = JObject.Parse(File.ReadAllText(Path.Combine("ScenarioTests", "tenant_level_template.json"))),
                        Parameters =
                        JObject.Parse("{'managementGroupId': {'value': 'gopremra-testmg'}}"),
                        Mode = DeploymentMode.Incremental,
                    },
                    Location = "East US 2",
                    Tags = new Dictionary<string, string> { { "tagKey1", "tagValue1" } }
                };

                //Validate
                var validationResult = client.Deployments.ValidateAtScope(scope: "", deploymentName: deploymentName, parameters: parameters);

                //Assert
                Assert.Null(validationResult.Error);
                Assert.NotNull(validationResult.Properties);
                Assert.NotNull(validationResult.Properties.Providers);

                //Put deployment
                var deploymentResult = client.Deployments.CreateOrUpdateAtScope(scope: "", deploymentName: deploymentName, parameters: parameters);

                var deployment = client.Deployments.GetAtScope(scope: "", deploymentName: deploymentName);
                Assert.Equal("Succeeded", deployment.Properties.ProvisioningState);
                Assert.NotNull(deployment.Tags);
                Assert.True(deployment.Tags.ContainsKey("tagKey1"));

                var deploymentOperations = client.DeploymentOperations.ListAtScope(scope: "", deploymentName: deploymentName);
                Assert.Equal(4, deploymentOperations.Count());
            }
        }

        [Fact]
        public void DeploymentWithScope_AtManagementGroup()
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.Created };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var client = GetResourceManagementClient(context, handler);
                string groupId = "tag-mg-sdk";
                string deploymentName = TestUtilities.GenerateName("csharpsdktest");

                var parameters = new Deployment
                {
                    Properties = new DeploymentProperties()
                    {
                        Template = JObject.Parse(File.ReadAllText(Path.Combine("ScenarioTests", "management_group_level_template.json"))),
                        Parameters =
                        JObject.Parse("{'storageAccountName': {'value': 'tagsa1'}}"),
                        Mode = DeploymentMode.Incremental,
                    },
                    Location = "East US",
                    Tags = new Dictionary<string, string> { { "tagKey1", "tagValue1" } }
                };

                var managementGroupScope = $"/providers/Microsoft.Management/managementGroups/{groupId}";

                //Validate
                var validationResult = client.Deployments.ValidateAtScope(scope: managementGroupScope, deploymentName: deploymentName, parameters: parameters);

                //Assert
                Assert.Null(validationResult.Error);
                Assert.NotNull(validationResult.Properties);
                Assert.NotNull(validationResult.Properties.Providers);

                //Put deployment
                var deploymentResult = client.Deployments.CreateOrUpdateAtScope(scope: managementGroupScope, deploymentName: deploymentName, parameters: parameters);

                var deployment = client.Deployments.GetAtScope(scope: managementGroupScope, deploymentName: deploymentName);
                Assert.Equal("Succeeded", deployment.Properties.ProvisioningState);
                Assert.NotNull(deployment.Tags);
                Assert.True(deployment.Tags.ContainsKey("tagKey1"));

                var deploymentOperations = client.DeploymentOperations.ListAtScope(scope: managementGroupScope, deploymentName: deploymentName);
                Assert.Equal(4, deploymentOperations.Count());
            }
        }

        [Fact]
        public void DeploymentWithScope_AtSubscription()
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.Created };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var client = GetResourceManagementClient(context, handler);
                string groupName = "SDK-test";
                string deploymentName = TestUtilities.GenerateName("csmd");

                var parameters = new Deployment
                {
                    Properties = new DeploymentProperties()
                    {
                        Template = JObject.Parse(File.ReadAllText(Path.Combine("ScenarioTests", "subscription_level_template.json"))),
                        Parameters =
                        JObject.Parse("{'storageAccountName': {'value': 'armbuilddemo1803'}}"),
                        Mode = DeploymentMode.Incremental,
                    },
                    Location = "WestUS",
                    Tags = new Dictionary<string, string> { { "tagKey1", "tagValue1" } }
                };

                client.ResourceGroups.CreateOrUpdate(groupName, new ResourceGroup { Location = "WestUS" });

                var subscriptionScope = $"/subscriptions/{client.SubscriptionId}";

                //Validate
                var validationResult = client.Deployments.ValidateAtScope(scope: subscriptionScope, deploymentName: deploymentName, parameters: parameters);

                //Assert
                Assert.Null(validationResult.Error);
                Assert.NotNull(validationResult.Properties);
                Assert.NotNull(validationResult.Properties.Providers);

                //Put deployment
                var deploymentResult = client.Deployments.CreateOrUpdateAtScope(scope: subscriptionScope, deploymentName: deploymentName, parameters: parameters);

                var deployment = client.Deployments.GetAtScope(scope: subscriptionScope, deploymentName: deploymentName);
                Assert.Equal("Succeeded", deployment.Properties.ProvisioningState);
                Assert.NotNull(deployment.Tags);
                Assert.True(deployment.Tags.ContainsKey("tagKey1"));

                var deploymentOperations = client.DeploymentOperations.ListAtScope(scope: subscriptionScope, deploymentName: deploymentName);
                Assert.Equal(4, deploymentOperations.Count());
            }
        }

        [Fact]
        public void DeploymentWithScope_AtResourceGroup()
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.Created };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var client = GetResourceManagementClient(context, handler);
                string groupName = "SDK-test-01";
                string deploymentName = TestUtilities.GenerateName("csmd");

                var parameters = new Deployment
                {
                    Properties = new DeploymentProperties()
                    {
                        Template = JObject.Parse(File.ReadAllText(Path.Combine("ScenarioTests", "simple-storage-account.json"))),
                        Parameters =
                        JObject.Parse("{'storageAccountName': {'value': 'sdkTestStorageAccount'}}"),
                        Mode = DeploymentMode.Incremental,
                    },
                    Tags = new Dictionary<string, string> { { "tagKey1", "tagValue1" } }
                };

                client.ResourceGroups.CreateOrUpdate(groupName, new ResourceGroup { Location = "WestUS" });

                var resourceGroupScope = $"/subscriptions/{client.SubscriptionId}/resourceGroups/{groupName}";

                //Validate
                var validationResult = client.Deployments.ValidateAtScope(scope: resourceGroupScope, deploymentName: deploymentName, parameters: parameters);

                //Assert
                Assert.Null(validationResult.Error);
                Assert.NotNull(validationResult.Properties);
                Assert.NotNull(validationResult.Properties.Providers);

                //Put deployment
                var deploymentResult = client.Deployments.CreateOrUpdateAtScope(scope: resourceGroupScope, deploymentName: deploymentName, parameters: parameters);

                var deployment = client.Deployments.GetAtScope(scope: resourceGroupScope, deploymentName: deploymentName);
                Assert.Equal("Succeeded", deployment.Properties.ProvisioningState);
                Assert.NotNull(deployment.Tags);
                Assert.True(deployment.Tags.ContainsKey("tagKey1"));

                var deploymentOperations = client.DeploymentOperations.ListAtScope(scope: resourceGroupScope, deploymentName: deploymentName);
                Assert.Equal(2, deploymentOperations.Count());
            }
        }
    }
}

