// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.Globalization;
using DataFactory.Tests.JsonSamples;
using DataFactory.Tests.Utils;
using Microsoft.Azure.Management.DataFactory.Models;
using Microsoft.Rest.Serialization;
using Newtonsoft.Json.Linq;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace DataFactory.Tests.UnitTests
{
    public class ActivityTests : BaseUnitTest
    {
        // Enable Xunit test output logger.
        protected readonly ITestOutputHelper logger = new TestOutputHelper();

        public ActivityTests(ITestOutputHelper logger)
            : base()
        {
            this.logger = logger;
        }

        [Theory]
        [ClassData(typeof(ActivityJsonSamples))]
        [Trait(TraitName.TestType, TestType.Unit)]
        public void Activity_SerializationTest(JsonSampleInfo jsonSample)
        {
            TestJsonSample<Activity>(jsonSample);
        }

        [Fact]
        public void ExecutePipelineActivity_SDKSample()
        {
            string triggeredPipelineName = "MyTriggeredPipeline";
            Activity activity = new ExecutePipelineActivity
            {
                Name = "MyExecutePipelineActivity",
                Description = "Execute pipeline activity",
                Pipeline = new PipelineReference(triggeredPipelineName),
                Parameters = new Dictionary<string, object>(),
                WaitOnCompletion = true,
                Policy = new ExecutePipelineActivityPolicy()
            };

            var handler = new RecordedDelegatingHandler();
            var client = this.CreateWorkflowClient(handler);
            var json = SafeJsonConvert.SerializeObject(activity, client.SerializationSettings);
            Assert.Contains(triggeredPipelineName, json);
        }

        [Fact]
        public void ExecuteSsisPackageActivity_SDKSample()
        {
            string triggeredPipelineName = "MyExecuteSsisPackagePipelineActivity";
            var projectParameters = new Dictionary<string, SSISExecutionParameter>();
            projectParameters["project_param_1"] = new SSISExecutionParameter()
            {
                Value = "123",
            };
            projectParameters["project_param_2"] = new SSISExecutionParameter()
            {
                Value = 1,
            };
            var packageParameters = new Dictionary<string, SSISExecutionParameter>();
            packageParameters["package_param_1"] = new SSISExecutionParameter()
            {
                Value = "06A9E439-6C23-43A1-AF56-F73A54B0F17D",
            };
            packageParameters["project_param_2"] = new SSISExecutionParameter()
            {
                Value = DateTimeOffset.UtcNow,
            };
            var projectCMs = new Dictionary<string, IDictionary<string, SSISExecutionParameter>>();
            projectCMs["MyOledbCM"] = new Dictionary<string, SSISExecutionParameter>();
            projectCMs["MyOledbCM"]["userName"] = new SSISExecutionParameter() { Value = "sa" };
            projectCMs["MyOledbCM"]["passWord"] = new SSISExecutionParameter() { Value = new SecureString() { Value = "123" } };
            var packageCMs = new Dictionary<string, IDictionary<string, SSISExecutionParameter>>();
            packageCMs["MyOledbCM"] = new Dictionary<string, SSISExecutionParameter>();
            packageCMs["MyOledbCM"]["userName"] = new SSISExecutionParameter() { Value = "sa" };
            packageCMs["MyOledbCM"]["passWord"] = new SSISExecutionParameter() { Value = new SecureString() { Value = "123" } };
            var propertyOverrides = new Dictionary<string, SSISPropertyOverride>();
            propertyOverrides["\\package.dtsx\\maxparralcount"] = new SSISPropertyOverride() { Value = 3, IsSensitive = false };
            var accessCredential = new SSISAccessCredential() { UserName = "user", Domain = "domain", Password = new SecureString() { Value = "123" } };
            ExecuteSSISPackageActivity activity = new ExecuteSSISPackageActivity
            {
                Name = triggeredPipelineName,
                Description = "Execute ssis package activity",
                Runtime = "x64",
                LoggingLevel = "Basic",
                EnvironmentPath = "./test",
                PackageLocation = new SSISPackageLocation
                {
                    Type = "File",
                    PackagePath = "\\\\Host\\share\\mypackage.dtsx",
                    ConfigurationPath = "\\\\Host\\share\\config.dtsConfig",
                    AccessCredential = accessCredential,
                    PackagePassword = new SecureString() { Value = "123" }
                },
                ConnectVia = new IntegrationRuntimeReference
                {
                    ReferenceName = "myIntegrationRuntime"
                },
                ProjectParameters = projectParameters,
                PackageParameters = packageParameters,
                ProjectConnectionManagers = projectCMs,
                PackageConnectionManagers = packageCMs,
                PropertyOverrides = propertyOverrides,
                LogLocation = new SSISLogLocation()
                {
                    LogPath = "\\\\Host\\share\\log",
                    AccessCredential = accessCredential,
                    LogRefreshInterval = "00:01:00"
                }
            };
            var handler = new RecordedDelegatingHandler();
            var client = this.CreateWorkflowClient(handler);
            var json = SafeJsonConvert.SerializeObject(activity, client.SerializationSettings);
            Assert.Contains(triggeredPipelineName, json);
        }

        [Fact]
        public void ExecuteBasicWebActivity_SDKSample()
        {
            string triggeredPipelineName = "MyBasicWebPipelineActivity";
            WebActivity activity = new WebActivity
            {
                Name = triggeredPipelineName,
                Description = "Execute web activity with basic authentication",
                Url = "http://www.bing.com",
                Method = "Get",
                Authentication = new WebActivityAuthentication
                {
                    Username = "test",
                    Password = new SecureString("fake"),
                    Type = "Basic"
                },
                DisableCertValidation = false
            };

            var handler = new RecordedDelegatingHandler();
            var client = this.CreateWorkflowClient(handler);
            var json = SafeJsonConvert.SerializeObject(activity, client.SerializationSettings);
            Assert.Contains(activity.Authentication.Type, json);
            JObject originalObj = JObject.Parse(json);
            Activity restored = SafeJsonConvert.DeserializeObject<Activity>(json, client.DeserializationSettings);
            var restoredJson = SafeJsonConvert.SerializeObject(restored, client.SerializationSettings);
            JObject restoredObj = JObject.Parse(restoredJson);
            Assert.True(JToken.DeepEquals(originalObj, restoredObj), string.Format(CultureInfo.InvariantCulture, "Failed at case: {0}.", triggeredPipelineName));
        }

        [Fact]
        public void ExecuteClientCertWebActivity_SDKSample()
        {
            string triggeredPipelineName = "MyClientCertWebPipelineActivity";
            WebActivity activity = new WebActivity
            {
                Name = triggeredPipelineName,
                Description = "Execute web activity with client certification authentication",
                Url = "http://www.bing.com",
                Method = "Get",
                Authentication = new WebActivityAuthentication
                {
                    Pfx = new SecureString("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"),
                    Password = new SecureString("fake"),
                    Type = "ClientCertificate"
                }
            };

            var handler = new RecordedDelegatingHandler();
            var client = this.CreateWorkflowClient(handler);
            var json = SafeJsonConvert.SerializeObject(activity, client.SerializationSettings);
            Assert.Contains(activity.Authentication.Type, json);
            JObject originalObj = JObject.Parse(json);
            Activity restored = SafeJsonConvert.DeserializeObject<Activity>(json, client.DeserializationSettings);
            var restoredJson = SafeJsonConvert.SerializeObject(restored, client.SerializationSettings);
            JObject restoredObj = JObject.Parse(restoredJson);
            Assert.True(JToken.DeepEquals(originalObj, restoredObj), string.Format(CultureInfo.InvariantCulture, "Failed at case: {0}.", triggeredPipelineName));
        }
    }
}
