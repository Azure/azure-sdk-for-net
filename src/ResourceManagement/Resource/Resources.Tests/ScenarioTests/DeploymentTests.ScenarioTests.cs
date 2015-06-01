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
            return this.GetResourceManagementClientWithHandler(handler);
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
                            Uri = DummyTemplateUri
                        },
                        Parameters = serializedDictionary,
                        Mode = "Incremental",
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
                            Uri = GoodWebsiteTemplateUri,
                        },
                        Parameters =
                            @"{ 'siteName': {'value': 'mctest0101'},'hostingPlanName': {'value': 'mctest0101'},'siteMode': {'value': 'Limited'},'computeMode': {'value': 'Shared'},'siteLocation': {'value': 'North Europe'},'sku': {'value': 'Free'},'workerSize': {'value': '0'}}",
                        Mode = "Incremental",
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

                Assert.NotEmpty(deploymentListResult.Value);
                Assert.Equal(deploymentName, deploymentGetResult.Name);
                Assert.Equal(deploymentName, deploymentListResult.Value[0].Name);
                Assert.Equal(GoodWebsiteTemplateUri, deploymentGetResult.Properties.TemplateLink.Uri);
                Assert.Equal(GoodWebsiteTemplateUri, deploymentListResult.Value[0].Properties.TemplateLink.Uri);
                Assert.NotNull(deploymentGetResult.Properties.ProvisioningState);
                Assert.NotNull(deploymentListResult.Value[0].Properties.ProvisioningState);
                Assert.NotNull(deploymentGetResult.Properties.CorrelationId);
                Assert.NotNull(deploymentListResult.Value[0].Properties.CorrelationId);
                Assert.True(deploymentGetResult.Properties.Parameters.ToString().Contains("mctest0101"));
                Assert.True(deploymentListResult.Value[0].Properties.Parameters.ToString().Contains("mctest0101"));
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
                            Uri = GoodWebsiteTemplateUri,
                        },
                        Parameters =
                            @"{ 'siteName': {'value': 'mctest0101'},'hostingPlanName': {'value': 'mctest0101'},'siteMode': {'value': 'Limited'},'computeMode': {'value': 'Shared'},'siteLocation': {'value': 'North Europe'},'sku': {'value': 'Free'},'workerSize': {'value': '0'}}",
                        Mode = "Incremental",
                    }
                };

                client.ResourceGroups.CreateOrUpdate(groupName, new ResourceGroup { Location = "West Europe" });

                //Action
                DeploymentValidateResponse validationResult = client.Deployments.Validate(groupName, deploymentName, parameters);
 
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
                        Mode = "Incremental",
                    }
                };

                client.ResourceGroups.CreateOrUpdate(groupName, new ResourceGroup { Location = "West Europe" });

                //Action
                DeploymentValidateResponse validationResult = client.Deployments.Validate(groupName, deploymentName, parameters);

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
                            Uri = BadTemplateUri,
                        },
                        Parameters =
                            @"{ 'siteName': {'value': 'mctest0101'},'hostingPlanName': {'value': 'mctest0101'},'siteMode': {'value': 'Limited'},'computeMode': {'value': 'Shared'},'siteLocation': {'value': 'North Europe'},'sku': {'value': 'Free'},'workerSize': {'value': '0'}}",
                        Mode = "Incremental",
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
                            Uri = DummyTemplateUri
                        },
                        Parameters = serializedDictionary,
                        Mode = "Incremental",
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

                Assert.True(operations.Value.Any());
                Assert.NotNull(operations.Value[0].Id);
                Assert.NotNull(operations.Value[0].OperationId);
                Assert.NotNull(operations.Value[0].Properties);
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
                            Uri = GoodWebsiteTemplateUri,
                        },
                        Parameters =
                            @"{ 'siteName': {'value': 'mctest0101'},'hostingPlanName': {'value': 'mctest0101'},'siteMode': {'value': 'Limited'},'computeMode': {'value': 'Shared'},'siteLocation': {'value': 'North Europe'},'sku': {'value': 'Free'},'workerSize': {'value': '0'}}",
                        Mode = "Incremental",
                    }
                };
                string groupName = TestUtilities.GenerateName("csmrg");
                string deploymentName = TestUtilities.GenerateName("csmd");
                client.ResourceGroups.CreateOrUpdate(groupName, new ResourceGroup { Location = "West Europe" });
                client.Deployments.CreateOrUpdate(groupName, deploymentName, parameters);

                var deploymentListResult = client.Deployments.List(groupName, d => d.ProvisioningState == "Running");
                if (null == deploymentListResult.Value || deploymentListResult.Value.Count < 1)
                {
                    deploymentListResult = client.Deployments.List(groupName, d => d.ProvisioningState == "Running");
                }
                var deploymentGetResult = client.Deployments.Get(groupName, deploymentName);

                Assert.NotEmpty(deploymentListResult.Value);
                Assert.Equal(deploymentName, deploymentGetResult.Name);
                Assert.Equal(deploymentName, deploymentListResult.Value[0].Name);
                Assert.Equal(GoodWebsiteTemplateUri, deploymentGetResult.Properties.TemplateLink.Uri);
                Assert.Equal(GoodWebsiteTemplateUri, deploymentListResult.Value[0].Properties.TemplateLink.Uri);
                Assert.NotNull(deploymentGetResult.Properties.ProvisioningState);
                Assert.NotNull(deploymentListResult.Value[0].Properties.ProvisioningState);
                Assert.NotNull(deploymentGetResult.Properties.CorrelationId);
                Assert.NotNull(deploymentListResult.Value[0].Properties.CorrelationId);
                Assert.True(deploymentGetResult.Properties.Parameters.ToString().Contains("mctest0101"));
                Assert.True(deploymentListResult.Value[0].Properties.Parameters.ToString().Contains("mctest0101"));
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
                            Uri = GoodWebsiteTemplateUri,
                        },
                        Parameters =
                            "{ 'siteName': {'value': '" + resourceName + "'},'hostingPlanName': {'value': '" +
                            resourceName +
                            "'},'siteMode': {'value': 'Limited'},'computeMode': {'value': 'Shared'},'siteLocation': {'value': 'North Europe'},'sku': {'value': 'Free'},'workerSize': {'value': '0'}}",
                        Mode = "Incremental",
                    }
                };

                client.ResourceGroups.CreateOrUpdate(groupName, new ResourceGroup { Location = "South Central US" });
                client.Deployments.CreateOrUpdate(groupName, deploymentName, parameters);

                // Wait until deployment completes
                TestUtilities.Wait(30000);
                var operations = client.DeploymentOperations.List(groupName, deploymentName, null);

                Assert.True(operations.Value.Any());
            }
        }
    }
}
