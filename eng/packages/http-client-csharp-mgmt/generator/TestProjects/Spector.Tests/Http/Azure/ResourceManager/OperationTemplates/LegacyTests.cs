// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.OperationTemplates;
using Azure.ResourceManager.OperationTemplates.Models;
using NUnit.Framework;

namespace TestProjects.Spector.Tests.Http.Azure.ResourceManager.OperationTemplates
{
    public class LegacyTests : OperationTemplatesTestBase
    {
        [SpectorTest]
        public Task RoutedGet() => Test(async host =>
        {
            var requests = new RequestRecorder();
            var response = await GetResourceGroup(host, requests).RoutedGetAsync("default", "memory");
            Assert.That(requests.Count, Is.EqualTo(1));
            requests.AssertRequest(0, "GET", $"{ResourceGroupProviderPath}/configurations/default/diagnostics/memory", "");
            Assert.That(response.Value.Name, Is.EqualTo("memory"));
            Assert.That(response.Value.Status, Is.EqualTo("healthy"));
        });

        [SpectorTest]
        public Task CreateOrReplaceOptionalBody() => Test(async host =>
        {
            var requests = new RequestRecorder();
            var group = GetResourceGroup(host, requests);
            var empty = await group.CreateOrReplaceOptionalBodyAsync("default", null);
            Assert.That(empty.Value.Properties.ConfigValue, Is.EqualTo("default-value"));

            var data = new Configuration(AzureLocation.EastUS)
            {
                Properties = new ConfigurationProperties { ConfigValue = "custom-value" }
            };
            var response = await group.CreateOrReplaceOptionalBodyAsync("default", data);
            Assert.That(requests.Count, Is.EqualTo(2));
            requests.AssertRequest(0, "PUT", $"{ResourceGroupProviderPath}/configurations/default", "");
            requests.AssertRequest(1, "PUT", $"{ResourceGroupProviderPath}/configurations/default", """{"location":"eastus","properties":{"configValue":"custom-value"}}""");
            Assert.That(response.Value.Properties.ConfigValue, Is.EqualTo("custom-value"));
        });
    }
}
