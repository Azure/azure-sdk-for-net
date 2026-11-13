// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ArcData.Models;
using Azure.ResourceManager.Resources;
using NUnit.Framework;

namespace Azure.ResourceManager.ArcData.Tests
{
    public class ArcDataOperationTests
    {
        private const string SubscriptionId = "00000000-0000-0000-0000-000000000001";
        private const string ResourceGroupName = "arcdata-rg";
        private const string DataControllerName = "dc1";
        private const string SqlServerInstanceName = "sql1";
        private const string ApiVersion = "2026-03-01-preview";

        [Test]
        public void DataControllerCrudUsesExpectedRequests()
        {
            string dataControllerPath = $"/subscriptions/{SubscriptionId}/resourceGroups/{ResourceGroupName}/providers/Microsoft.AzureArcData/dataControllers/{DataControllerName}";
            var expectedRequests = new Queue<(RequestMethod Method, string Path)>(new[]
            {
                (RequestMethod.Put, dataControllerPath),
                (RequestMethod.Get, dataControllerPath),
                (RequestMethod.Patch, dataControllerPath),
                (RequestMethod.Delete, dataControllerPath)
            });
            var transport = MockTransport.FromMessageCallback(message =>
            {
                var expected = expectedRequests.Dequeue();
                AssertRequest(message, expected.Method, expected.Path);

                return expected.Method == RequestMethod.Get
                    ? JsonResponse(200, CreateDataControllerJson(dataControllerPath))
                    : AcceptedResponse(expected.Path);
            });
            var client = CreateClient(transport);
            ResourceGroupResource resourceGroup = client.GetResourceGroupResource(ResourceGroupResource.CreateResourceIdentifier(SubscriptionId, ResourceGroupName));
            DataControllerCollection collection = resourceGroup.GetDataControllers();

            var data = new DataControllerData(AzureLocation.WestUS2, new DataControllerProperties());
            collection.CreateOrUpdate(WaitUntil.Started, DataControllerName, data);
            DataControllerResource resource = collection.Get(DataControllerName).Value;
            var patch = new DataControllerPatch();
            patch.Tags.Add("environment", "test");
            resource.Update(WaitUntil.Started, patch);
            resource.Delete(WaitUntil.Started);

            Assert.That(expectedRequests, Is.Empty);
            Assert.That(transport.Requests, Has.Count.EqualTo(4));
        }

        [Test]
        public void SqlServerInstanceActionUsesExpectedLongRunningRequest()
        {
            string sqlServerInstancePath = $"/subscriptions/{SubscriptionId}/resourceGroups/{ResourceGroupName}/providers/Microsoft.AzureArcData/sqlServerInstances/{SqlServerInstanceName}";
            string actionPath = sqlServerInstancePath + "/runTargetRecommendationJob";
            var transport = MockTransport.FromMessageCallback(message =>
            {
                AssertRequest(message, RequestMethod.Post, actionPath);
                return AcceptedResponse(actionPath);
            });
            var client = CreateClient(transport);
            SqlServerInstanceResource resource = client.GetSqlServerInstanceResource(SqlServerInstanceResource.CreateResourceIdentifier(SubscriptionId, ResourceGroupName, SqlServerInstanceName));
            var content = new ArcDataSqlServerInstanceRunTargetRecommendationJobRequestContent
            {
                ShouldIncludeFileLevelRequirements = true,
                TargetLocation = "eastus",
                Percentile = 95,
                LookbackPeriodInDays = 30
            };

            resource.RunTargetRecommendationJob(WaitUntil.Started, content);

            Assert.That(transport.Requests, Has.Count.EqualTo(1));
        }

        private static ArmClient CreateClient(MockTransport transport)
            => new ArmClient(new MockCredential(), SubscriptionId, new ArmClientOptions { Transport = transport });

        private static void AssertRequest(HttpMessage message, RequestMethod method, string absolutePath)
        {
            Uri uri = message.Request.Uri.ToUri();
            Assert.That(message.Request.Method, Is.EqualTo(method));
            Assert.That(uri.AbsolutePath, Is.EqualTo(absolutePath));
            Assert.That(uri.Query, Does.Contain("api-version=" + ApiVersion));
        }

        private static MockResponse JsonResponse(int status, string content)
            => new MockResponse(status).SetContent(content);

        private static MockResponse AcceptedResponse(string path)
        {
            var response = new MockResponse(202);
            response.AddHeader("Azure-AsyncOperation", $"https://management.azure.com{path}/operations/operation1?api-version={ApiVersion}");
            response.AddHeader("Location", $"https://management.azure.com{path}/operationResults/operation1?api-version={ApiVersion}");
            return response;
        }

        private static string CreateDataControllerJson(string id)
            => "{\"id\":\"" + id + "\",\"name\":\"" + DataControllerName + "\",\"type\":\"Microsoft.AzureArcData/dataControllers\",\"location\":\"westus2\",\"properties\":{}}";
    }
}
