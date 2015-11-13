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

using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Test;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Newtonsoft.Json.Linq;
using Xunit;

namespace ResourceGroups.Tests
{
    public class LiveDeploymentTests : TestBase
    {
        const string DummyTemplateUri = "https://testtemplates.blob.core.windows.net/templates/dummytemplate.js";
        const string GoodWebsiteTemplateUri = "https://testtemplates.blob.core.windows.net/templates/good-website.js";
        const string BadTemplateUri = "https://testtemplates.blob.core.windows.net/templates/bad-website-1.js";

        public ResourceManagementClient GetResourceManagementClient(MockContext context, RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            return this.GetResourceManagementClientWithHandler(context, handler);
        }

        [Fact]
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
                client.ResourceGroups.CreateOrUpdate(groupName, new ResourceGroup { Location = "West Europe" });
                client.Deployments.CreateOrUpdate(groupName, deploymentName, parameters);

                JObject json = JObject.Parse(handler.Request);

                Assert.NotNull(client.Deployments.Get(groupName, deploymentName));
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
                            @"{ 'siteName': {'value': 'mctest0101'},'hostingPlanName': {'value': 'mctest0101'},'siteMode': {'value': 'Limited'},'computeMode': {'value': 'Shared'},'siteLocation': {'value': 'North Europe'},'sku': {'value': 'Free'},'workerSize': {'value': '0'}}"),
                        Mode = DeploymentMode.Incremental,
                    }
                };
                string groupName = TestUtilities.GenerateName("csmrg");
                string deploymentName = TestUtilities.GenerateName("csmd");
                client.ResourceGroups.CreateOrUpdate(groupName, new ResourceGroup { Location = "West Europe" });
                var deploymentCreateResult = client.Deployments.CreateOrUpdate(groupName, deploymentName, parameters);

                Assert.NotNull(deploymentCreateResult.Id);
                Assert.Equal(deploymentName, deploymentCreateResult.Name);

                TestUtilities.Wait(1000);

                var deploymentListResult = client.Deployments.List(groupName, null);
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
        public void ValidateGoodDeployment()
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
                            Uri = GoodWebsiteTemplateUri,
                        },
                        Parameters =
                        JObject.Parse(@"{ 'siteName': {'value': 'mctest0101'},'hostingPlanName': {'value': 'mctest0101'},'siteMode': {'value': 'Limited'},'computeMode': {'value': 'Shared'},'siteLocation': {'value': 'North Europe'},'sku': {'value': 'Free'},'workerSize': {'value': '0'}}"),
                        Mode = DeploymentMode.Incremental,
                    }
                };

                client.ResourceGroups.CreateOrUpdate(groupName, new ResourceGroup { Location = "West Europe" });

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
        public void ValidateGoodDeploymentWithInlineTemplate()
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
                        Template = File.ReadAllText(Path.Combine("ScenarioTests", "good-website.js")),
                        Parameters =
                        JObject.Parse(@"{ 'siteName': {'value': 'mctest0101'},'hostingPlanName': {'value': 'mctest0101'},'siteMode': {'value': 'Limited'},'computeMode': {'value': 'Shared'},'siteLocation': {'value': 'North Europe'},'sku': {'value': 'Free'},'workerSize': {'value': '0'}}"),
                        Mode = DeploymentMode.Incremental,
                    }
                };

                client.ResourceGroups.CreateOrUpdate(groupName, new ResourceGroup { Location = "West Europe" });

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

                client.ResourceGroups.CreateOrUpdate(groupName, new ResourceGroup { Location = "West Europe" });
                var result = client.Deployments.Validate(groupName, deploymentName, parameters);
                Assert.NotNull(result);
                Assert.Equal("InvalidTemplate", result.Error.Code);
            }
        }

        [Fact]
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

                client.ResourceGroups.CreateOrUpdate(groupName, new ResourceGroup { Location = "West Europe" });
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

        [Fact]
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
                        JObject.Parse(@"{ 'siteName': {'value': 'mctest0101'},'hostingPlanName': {'value': 'mctest0101'},'siteMode': {'value': 'Limited'},'computeMode': {'value': 'Shared'},'siteLocation': {'value': 'North Europe'},'sku': {'value': 'Free'},'workerSize': {'value': '0'}}"),
                        Mode = DeploymentMode.Incremental,
                    }
                };
                string groupName = TestUtilities.GenerateName("csmrg");
                string deploymentName = TestUtilities.GenerateName("csmd");
                client.ResourceGroups.CreateOrUpdate(groupName, new ResourceGroup { Location = "West Europe" });
                client.Deployments.CreateOrUpdate(groupName, deploymentName, parameters);

                var deploymentListResult = client.Deployments.List(groupName, d => d.ProvisioningState == "Running");
                if (null == deploymentListResult|| deploymentListResult.Count() == 0)
                {
                    deploymentListResult = client.Deployments.List(groupName, d => d.ProvisioningState == "Accepted");
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
                        JObject.Parse(
                            "{ 'siteName': {'value': '" + resourceName + "'},'hostingPlanName': {'value': '" +
                            resourceName +
                            "'},'siteMode': {'value': 'Limited'},'computeMode': {'value': 'Shared'},'siteLocation': {'value': 'North Europe'},'sku': {'value': 'Free'},'workerSize': {'value': '0'}}"),
                        Mode = DeploymentMode.Incremental,
                    }
                };

                client.ResourceGroups.CreateOrUpdate(groupName, new ResourceGroup { Location = "South Central US" });
                client.Deployments.CreateOrUpdate(groupName, deploymentName, parameters);

                // Wait until deployment completes
                TestUtilities.Wait(30000);
                var operations = client.DeploymentOperations.List(groupName, deploymentName, null);

                Assert.True(operations.Any());
            }
        }
    }
}
