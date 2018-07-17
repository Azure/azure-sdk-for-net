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

            using (MockContext context = MockContext.Start(this.GetType().FullName))
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

            using (MockContext context = MockContext.Start(this.GetType().FullName))
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

            using (MockContext context = MockContext.Start(this.GetType().FullName))
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
                            @"{'repoURL': {'value': 'https://github.com/devigned/az-roadshow-oss.git'}, 'siteName': {'value': '" + resourceName  + "'}, 'hostingPlanName': {'value': 'someplan'}, 'sku': {'value': 'F1'}}"),
                        Mode = DeploymentMode.Incremental,
                    }
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
            }
        }

        [Fact]
        public void ValidateGoodDeployment()
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.Created };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
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
                        JObject.Parse(@"{'repoURL': {'value': 'https://github.com/devigned/az-roadshow-oss.git'}, 'siteName': {'value': '" + resourceName + "'}, 'hostingPlanName': {'value': 'someplan'}, 'sku': {'value': 'F1'}}"),
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

            using (MockContext context = MockContext.Start(this.GetType().FullName))
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

            using (MockContext context = MockContext.Start(this.GetType().FullName))
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

            using (MockContext context = MockContext.Start(this.GetType().FullName))
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

            using (MockContext context = MockContext.Start(this.GetType().FullName))
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
                Assert.True(deploymentGetResult.Properties.Parameters.ToString().Contains("mctest0101"));
                Assert.True(deploymentListResult.First().Properties.Parameters.ToString().Contains("mctest0101"));
            }
        }

        [Fact]
        public void CreateLargeWebDeploymentTemplateWorks()
        {
            var handler = new RecordedDelegatingHandler();
            using (MockContext context = MockContext.Start(this.GetType().FullName))
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
                        JObject.Parse("{'repoURL': {'value': 'https://github.com/devigned/az-roadshow-oss.git'}, 'siteName': {'value': '" + resourceName + "'}, 'hostingPlanName': {'value': 'someplan'}, 'sku': {'value': 'F1'}}"),
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

            using (MockContext context = MockContext.Start(this.GetType().FullName))
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
                    Location = "WestUS"
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
            }
        }
    }
}
