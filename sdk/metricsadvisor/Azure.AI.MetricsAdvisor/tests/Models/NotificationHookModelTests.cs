// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.AI.MetricsAdvisor.Administration;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.MetricsAdvisor.Tests
{
    public class NotificationHookModelTests : MockClientTestBase
    {
        public NotificationHookModelTests(bool isAsync) : base(isAsync)
        {
        }

        private string UnknownHookContent => $@"
        {{
            ""hookId"": ""{FakeGuid}"",
            ""hookName"": ""unknownHookName"",
            ""hookType"": ""unknownType"",
            ""externalLink"": ""https://fakeuri.com/"",
            ""description"": ""unknown hook description"",
            ""admins"": [
              ""foo@contoso.com""
            ]
        }}
        ";

        [Test]
        public async Task NotificationHookGetsUnknownHook()
        {
            MockResponse getResponse = new MockResponse(200);
            getResponse.SetContent(UnknownHookContent);

            MetricsAdvisorAdministrationClient adminClient = CreateInstrumentedAdministrationClient(getResponse);
            NotificationHook hook = await adminClient.GetHookAsync(FakeGuid);

            Assert.That(hook.Id, Is.EqualTo(FakeGuid));
            Assert.That(hook.Name, Is.EqualTo("unknownHookName"));
            Assert.That(hook.ExternalUri.AbsoluteUri, Is.EqualTo("https://fakeuri.com/"));
            Assert.That(hook.Description, Is.EqualTo("unknown hook description"));
            Assert.That(hook.Administrators.Single(), Is.EqualTo("foo@contoso.com"));
        }

        [Test]
        public async Task NotificationHookUpdatesUnknownHook()
        {
            MockResponse getResponse = new MockResponse(200);
            getResponse.SetContent(UnknownHookContent);

            MockResponse updateResponse = new MockResponse(200);
            updateResponse.SetContent(UnknownHookContent);

            MockTransport mockTransport = new MockTransport(getResponse, updateResponse);
            MetricsAdvisorAdministrationClient adminClient = CreateInstrumentedAdministrationClient(mockTransport);
            NotificationHook hook = await adminClient.GetHookAsync(FakeGuid);

            hook.Name = "newHookName";
            hook.ExternalUri = new Uri("https://newfakeuri.com/");
            hook.Description = "new description";

            await adminClient.UpdateHookAsync(hook);

            MockRequest request = mockTransport.Requests.Last();
            string content = ReadContent(request);

            Assert.That(request.Uri.Path, Contains.Substring(FakeGuid));
            Assert.That(content, ContainsJsonString("hookName", "newHookName"));
            Assert.That(content, ContainsJsonString("hookType", "unknownType"));
            Assert.That(content, ContainsJsonString("externalLink", "https://newfakeuri.com/"));
            Assert.That(content, ContainsJsonString("description", "new description"));
            Assert.That(content, ContainsJsonStringArray("admins", "foo@contoso.com"));
        }
    }
}
