// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.OperationTemplates;
using Azure.ResourceManager.OperationTemplates.Models;
using NUnit.Framework;

namespace TestProjects.Spector.Tests.Http.Azure.ResourceManager.OperationTemplates
{
    public class CheckNameAvailabilityTests : OperationTemplatesTestBase
    {
        [SpectorTest]
        public Task CheckGlobal() => Test(async host =>
        {
            var requests = new RequestRecorder();
            CheckNameAvailabilityRequest request = new()
            {
                Name = "checkName",
                Type = "Microsoft.Web/site"
            };

            var response = await GetSubscription(host, requests).CheckGlobalAsync(request);

            Assert.That(requests.Count, Is.EqualTo(1));
            requests.AssertRequest(0, "POST", $"{ProviderPath}/checkNameAvailability", """{"name":"checkName","type":"Microsoft.Web/site"}""");
            Assert.That(response.Value.NameAvailable, Is.False);
            Assert.That(response.Value.Message, Is.EqualTo("Hostname 'checkName' already exists. Please select a different name."));
        });

        [SpectorTest]
        public Task CheckLocal() => Test(async host =>
        {
            var requests = new RequestRecorder();
            CheckNameAvailabilityRequest request = new()
            {
                Name = "checkName",
                Type = "Microsoft.Web/site"
            };

            var response = await GetSubscription(host, requests).CheckLocalAsync(AzureLocation.WestUS, request);

            Assert.That(requests.Count, Is.EqualTo(1));
            requests.AssertRequest(0, "POST", $"{ProviderPath}/locations/westus/checkNameAvailability", """{"name":"checkName","type":"Microsoft.Web/site"}""");
            Assert.That(response.Value.NameAvailable, Is.False);
            Assert.That(response.Value.Message, Is.EqualTo("Hostname 'checkName' already exists. Please select a different name."));
        });
    }
}
