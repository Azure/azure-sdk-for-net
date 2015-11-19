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

using System.IO;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Test;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Formatters;
using System.Threading;
using Xunit;

namespace ResourceGroups.Tests
{
    public class LiveDeploymentTests : TestBase
    {
        const string DummyTemplateUri = "https://testtemplates.blob.core.windows.net/templates/dummytemplate.js";
        const string GoodWebsiteTemplateUri = "https://testtemplates.blob.core.windows.net/templates/good-website.js";
        const string BadTemplateUri = "https://testtemplates.blob.core.windows.net/templates/bad-website-1.js";

        public ResourceManagementClient GetResourceManagementClient(RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            return this.GetResourceManagementClient().WithHandler(handler);
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
            var serializedDictionary = JsonConvert.SerializeObject(dictionary, new JsonSerializerSettings
            {
                TypeNameAssemblyFormat = FormatterAssemblyStyle.Simple,
                TypeNameHandling = TypeNameHandling.None
            });

            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetResourceManagementClient(handler);
                var parameters = new Deployment
                {
                    Properties = new DeploymentProperties()
                    {
                        TemplateLink = new TemplateLink
                        {
                            Uri = new Uri(DummyTemplateUri)
                        },
                        Parameters = serializedDictionary,
                        Mode = DeploymentMode.Incremental,
                    }
                };

                string groupName = TestUtilities.GenerateName("csmrg");
                string deploymentName = TestUtilities.GenerateName("csmd");
                client.ResourceGroups.CreateOrUpdate(groupName, new ResourceGroup { Location = "West Europe" });
                client.Deployments.CreateOrUpdate(groupName, deploymentName, parameters);

                JObject json = JObject.Parse(handler.Request);

                Assert.Equal(HttpStatusCode.OK, client.Deployments.Get(groupName, deploymentName).StatusCode);
            }
        }

        [Fact]
        public void CreateDeploymentAndValidateProperties()
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.Created };

            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetResourceManagementClient(handler);
                string resourceName = TestUtilities.GenerateName("csmr");

                var parameters = new Deployment
                {
                    Properties = new DeploymentProperties()
                    {
                        TemplateLink = new TemplateLink
                        {
                            Uri = new Uri(GoodWebsiteTemplateUri),
                        },
                        Parameters =
                            @"{ 'siteName': {'value': 'mctest0101'},'hostingPlanName': {'value': 'mctest0101'},'siteMode': {'value': 'Limited'},'computeMode': {'value': 'Shared'},'siteLocation': {'value': 'North Europe'},'sku': {'value': 'Free'},'workerSize': {'value': '0'}}",
                        Mode = DeploymentMode.Incremental,
                    }
                };
                string groupName = TestUtilities.GenerateName("csmrg");
                string deploymentName = TestUtilities.GenerateName("csmd");
                client.ResourceGroups.CreateOrUpdate(groupName, new ResourceGroup { Location = "West Europe" });
                var deploymentCreateResult = client.Deployments.CreateOrUpdate(groupName, deploymentName, parameters);

                Assert.NotNull(deploymentCreateResult.Deployment.Id);
                Assert.Equal(deploymentName, deploymentCreateResult.Deployment.Name);

                TestUtilities.Wait(1000);

                var deploymentListResult = client.Deployments.List(groupName, null);
                var deploymentGetResult = client.Deployments.Get(groupName, deploymentName);

                Assert.NotEmpty(deploymentListResult.Deployments);
                Assert.Equal(deploymentName, deploymentGetResult.Deployment.Name);
                Assert.Equal(deploymentName, deploymentListResult.Deployments[0].Name);
                Assert.Equal(GoodWebsiteTemplateUri, deploymentGetResult.Deployment.Properties.TemplateLink.Uri.AbsoluteUri);
                Assert.Equal(GoodWebsiteTemplateUri, deploymentListResult.Deployments[0].Properties.TemplateLink.Uri.AbsoluteUri);
                Assert.NotNull(deploymentGetResult.Deployment.Properties.ProvisioningState);
                Assert.NotNull(deploymentListResult.Deployments[0].Properties.ProvisioningState);
                Assert.NotNull(deploymentGetResult.Deployment.Properties.CorrelationId);
                Assert.NotNull(deploymentListResult.Deployments[0].Properties.CorrelationId);
                Assert.True(deploymentGetResult.Deployment.Properties.Parameters.Contains("mctest0101"));
                Assert.True(deploymentListResult.Deployments[0].Properties.Parameters.Contains("mctest0101"));

                //stop the deployment
                client.Deployments.Cancel(groupName, deploymentName);
                TestUtilities.Wait(2000);

                //Delete deployment
                Assert.Equal(HttpStatusCode.NoContent, client.Deployments.Delete(groupName, deploymentName).StatusCode);
            }
        }

        [Fact]
        public void ValidateGoodDeployment()
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.Created };

            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetResourceManagementClient(handler);
                string groupName = TestUtilities.GenerateName("csmrg");
                string deploymentName = TestUtilities.GenerateName("csmd");

                var parameters = new Deployment
                {
                    Properties = new DeploymentProperties()
                    {
                        TemplateLink = new TemplateLink
                        {
                            Uri = new Uri(GoodWebsiteTemplateUri),
                        },
                        Parameters =
                            @"{ 'siteName': {'value': 'mctest0101'},'hostingPlanName': {'value': 'mctest0101'},'siteMode': {'value': 'Limited'},'computeMode': {'value': 'Shared'},'siteLocation': {'value': 'North Europe'},'sku': {'value': 'Free'},'workerSize': {'value': '0'}}",
                        Mode = DeploymentMode.Incremental,
                    }
                };

                client.ResourceGroups.CreateOrUpdate(groupName, new ResourceGroup { Location = "West Europe" });

                //Action
                DeploymentValidateResponse validationResult = client.Deployments.Validate(groupName, deploymentName, parameters);
 
                 //Assert
                Assert.True(validationResult.IsValid);
                Assert.Null(validationResult.Error);
                Assert.NotNull(validationResult.Properties);
                Assert.NotNull(validationResult.Properties.Providers);
                Assert.Equal(1, validationResult.Properties.Providers.Count);
                Assert.Equal("Microsoft.Web", validationResult.Properties.Providers[0].Namespace);
            }
        }

        [Fact]
        public void ValidateGoodDeploymentWithInlineTemplate()
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.Created };

            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetResourceManagementClient(handler);
                string groupName = TestUtilities.GenerateName("csmrg");
                string deploymentName = TestUtilities.GenerateName("csmd");

                var parameters = new Deployment
                {
                    Properties = new DeploymentProperties()
                    {
                        Template = File.ReadAllText("ScenarioTests\\good-website.js"),
                        Parameters =
                            @"{ 'siteName': {'value': 'mctest0101'},'hostingPlanName': {'value': 'mctest0101'},'siteMode': {'value': 'Limited'},'computeMode': {'value': 'Shared'},'siteLocation': {'value': 'North Europe'},'sku': {'value': 'Free'},'workerSize': {'value': '0'}}",
                        Mode = DeploymentMode.Incremental,
                    }
                };

                client.ResourceGroups.CreateOrUpdate(groupName, new ResourceGroup { Location = "West Europe" });

                //Action
                DeploymentValidateResponse validationResult = client.Deployments.Validate(groupName, deploymentName, parameters);

                //Assert
                Assert.True(validationResult.IsValid);
                Assert.Null(validationResult.Error);
                Assert.NotNull(validationResult.Properties);
                Assert.NotNull(validationResult.Properties.Providers);
                Assert.Equal(1, validationResult.Properties.Providers.Count);
                Assert.Equal("Microsoft.Web", validationResult.Properties.Providers[0].Namespace);
            }
        }

        [Fact]
        public void ValidateBadDeployment()
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.Created };

            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetResourceManagementClient(handler);

                string groupName = TestUtilities.GenerateName("csmrg");
                string deploymentName = TestUtilities.GenerateName("csmd");
                var parameters = new Deployment
                {
                    Properties = new DeploymentProperties()
                    {
                        TemplateLink = new TemplateLink
                        {
                            Uri = new Uri(BadTemplateUri),
                        },
                        Parameters =
                            @"{ 'siteName': {'value': 'mctest0101'},'hostingPlanName': {'value': 'mctest0101'},'siteMode': {'value': 'Limited'},'computeMode': {'value': 'Shared'},'siteLocation': {'value': 'North Europe'},'sku': {'value': 'Free'},'workerSize': {'value': '0'}}",
                        Mode = DeploymentMode.Incremental,
                    }
                };

                client.ResourceGroups.CreateOrUpdate(groupName, new ResourceGroup { Location = "West Europe" });
                var result = client.Deployments.Validate(groupName, deploymentName, parameters);
                Assert.False(result.IsValid);
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
            var serializedDictionary = JsonConvert.SerializeObject(dictionary, new JsonSerializerSettings
            {
                TypeNameAssemblyFormat = FormatterAssemblyStyle.Simple,
                TypeNameHandling = TypeNameHandling.None
            });

            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetResourceManagementClient(handler);
                var parameters = new Deployment
                {
                    Properties = new DeploymentProperties()
                    {
                        TemplateLink = new TemplateLink
                        {
                            Uri = new Uri(DummyTemplateUri)
                        },
                        Parameters = serializedDictionary,
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

                Assert.True(operations.Operations.Any());
                Assert.NotNull(operations.Operations[0].Id);
                Assert.NotNull(operations.Operations[0].OperationId);
                Assert.NotNull(operations.Operations[0].Properties);
            }
        }

        [Fact]
        public void ListDeploymentsWorksWithFilter()
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.Created };

            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetResourceManagementClient(handler);
                string resourceName = TestUtilities.GenerateName("csmr");

                var parameters = new Deployment
                {
                    Properties = new DeploymentProperties()
                    {
                        TemplateLink = new TemplateLink
                        {
                            Uri = new Uri(GoodWebsiteTemplateUri),
                        },
                        Parameters =
                            @"{ 'siteName': {'value': 'mctest0101'},'hostingPlanName': {'value': 'mctest0101'},'siteMode': {'value': 'Limited'},'computeMode': {'value': 'Shared'},'siteLocation': {'value': 'North Europe'},'sku': {'value': 'Free'},'workerSize': {'value': '0'}}",
                        Mode = DeploymentMode.Incremental,
                    }
                };
                string groupName = TestUtilities.GenerateName("csmrg");
                string deploymentName = TestUtilities.GenerateName("csmd");
                client.ResourceGroups.CreateOrUpdate(groupName, new ResourceGroup { Location = "West Europe" });
                client.Deployments.CreateOrUpdate(groupName, deploymentName, parameters);

                var deploymentListResult = client.Deployments.List(groupName, new DeploymentListParameters { ProvisioningState = ProvisioningState.Running });
                if (null == deploymentListResult.Deployments || deploymentListResult.Deployments.Count < 1)
                {
                    deploymentListResult = client.Deployments.List(groupName, new DeploymentListParameters { ProvisioningState = ProvisioningState.Accepted });
                }
                var deploymentGetResult = client.Deployments.Get(groupName, deploymentName);

                Assert.NotEmpty(deploymentListResult.Deployments);
                Assert.Equal(deploymentName, deploymentGetResult.Deployment.Name);
                Assert.Equal(deploymentName, deploymentListResult.Deployments[0].Name);
                Assert.Equal(GoodWebsiteTemplateUri, deploymentGetResult.Deployment.Properties.TemplateLink.Uri.AbsoluteUri);
                Assert.Equal(GoodWebsiteTemplateUri, deploymentListResult.Deployments[0].Properties.TemplateLink.Uri.AbsoluteUri);
                Assert.NotNull(deploymentGetResult.Deployment.Properties.ProvisioningState);
                Assert.NotNull(deploymentListResult.Deployments[0].Properties.ProvisioningState);
                Assert.NotNull(deploymentGetResult.Deployment.Properties.CorrelationId);
                Assert.NotNull(deploymentListResult.Deployments[0].Properties.CorrelationId);
                Assert.True(deploymentGetResult.Deployment.Properties.Parameters.Contains("mctest0101"));
                Assert.True(deploymentListResult.Deployments[0].Properties.Parameters.Contains("mctest0101"));
            }
        }

        [Fact]
        public void CreateLargeWebDeploymentTemplateWorks()
        {
            var handler = new RecordedDelegatingHandler();
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                string resourceName = TestUtilities.GenerateName("csmr");
                string groupName = TestUtilities.GenerateName("csmrg");
                string deploymentName = TestUtilities.GenerateName("csmd");

                var client = GetResourceManagementClient(handler);
                var parameters = new Deployment
                {
                    Properties = new DeploymentProperties()
                    {
                        TemplateLink = new TemplateLink
                        {
                            Uri = new Uri(GoodWebsiteTemplateUri),
                        },
                        Parameters =
                            "{ 'siteName': {'value': '" + resourceName + "'},'hostingPlanName': {'value': '" +
                            resourceName +
                            "'},'siteMode': {'value': 'Limited'},'computeMode': {'value': 'Shared'},'siteLocation': {'value': 'North Europe'},'sku': {'value': 'Free'},'workerSize': {'value': '0'}}",
                        Mode = DeploymentMode.Incremental,
                    }
                };

                client.ResourceGroups.CreateOrUpdate(groupName, new ResourceGroup { Location = "South Central US" });
                client.Deployments.CreateOrUpdate(groupName, deploymentName, parameters);

                // Wait until deployment completes
                TestUtilities.Wait(30000);
                var operations = client.DeploymentOperations.List(groupName, deploymentName, null);

                Assert.True(operations.Operations.Any());
            }
        }

        [Fact]
        public void CheckExistenceReturnsCorrectValue()
        {
            var handler = new RecordedDelegatingHandler() { StatusCodeToReturn = HttpStatusCode.Created };

            using (UndoContext context = UndoContext.Current)
            {
                context.Start();
                var client = GetResourceManagementClient(handler);
                string resourceName = TestUtilities.GenerateName("csmr");

                var parameters = new Deployment
                {
                    Properties = new DeploymentProperties()
                    {
                        TemplateLink = new TemplateLink
                        {
                            Uri = new Uri(GoodWebsiteTemplateUri),
                        },
                        Parameters =
                            @"{ 'siteName': {'value': 'mctest0101'},'hostingPlanName': {'value': 'mctest0101'},'siteMode': {'value': 'Limited'},'computeMode': {'value': 'Shared'},'siteLocation': {'value': 'North Europe'},'sku': {'value': 'Free'},'workerSize': {'value': '0'}}",
                        Mode = DeploymentMode.Incremental,
                    }
                };
                string groupName = TestUtilities.GenerateName("csmrg");
                string deploymentName = TestUtilities.GenerateName("csmd");
                client.ResourceGroups.CreateOrUpdate(groupName, new ResourceGroup { Location = "West Europe" });

                var checkExistenceFirst = client.Deployments.CheckExistence(groupName, deploymentName);
                Assert.False(checkExistenceFirst.Exists);

                var deploymentCreateResult = client.Deployments.CreateOrUpdate(groupName, deploymentName, parameters);

                var checkExistenceSecond = client.Deployments.CheckExistence(groupName, deploymentName);

                Assert.True(checkExistenceSecond.Exists);
            }
        }
    }
}
