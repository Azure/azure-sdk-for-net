// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.AI.MetricsAdvisor.Administration;
using Azure.AI.MetricsAdvisor.Models;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.MetricsAdvisor.Tests
{
    public class NotificationHookLiveTests : MetricsAdvisorLiveTestBase
    {
        public NotificationHookLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task CreateAndGetEmailNotificationHookWithMinimumSetup()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            string hookName = Recording.GenerateAlphaNumericId("hook");
            var emailsToAlert = new List<string>() { "fake1@email.com", "fake2@email.com" };

            var hookToCreate = new EmailNotificationHook(hookName, emailsToAlert);

            await using var disposableHook = await DisposableNotificationHook.CreateHookAsync(adminClient, hookToCreate);

            NotificationHook createdHook = await adminClient.GetHookAsync(disposableHook.Id);

            Assert.That(createdHook.Id, Is.EqualTo(disposableHook.Id));
            Assert.That(createdHook.Name, Is.EqualTo(hookName));
            Assert.That(createdHook.Description, Is.Empty);
            Assert.That(createdHook.ExternalLink, Is.Empty);
            Assert.That(createdHook.Administrators, Is.Not.Null);
            Assert.That(createdHook.Administrators.Single(), Is.Not.Null.And.Not.Empty);

            var createdEmailHook = createdHook as EmailNotificationHook;

            Assert.That(createdEmailHook, Is.Not.Null);
            Assert.That(createdEmailHook.EmailsToAlert, Is.EquivalentTo(emailsToAlert));
        }

        [RecordedTest]
        public async Task CreateAndGetEmailNotificationHookWithOptionalMembers()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            string hookName = Recording.GenerateAlphaNumericId("hook");
            var emailsToAlert = new List<string>() { "fake1@email.com", "fake2@email.com" };
            var description = "This hook was created to test the .NET client.";

            var hookToCreate = new EmailNotificationHook(hookName, emailsToAlert)
            {
                Description = description,
                ExternalLink = "http://fake.endpoint.com"
            };

            await using var disposableHook = await DisposableNotificationHook.CreateHookAsync(adminClient, hookToCreate);

            NotificationHook createdHook = await adminClient.GetHookAsync(disposableHook.Id);

            Assert.That(createdHook.Id, Is.EqualTo(disposableHook.Id));
            Assert.That(createdHook.Name, Is.EqualTo(hookName));
            Assert.That(createdHook.Description, Is.EqualTo(description));
            Assert.That(createdHook.ExternalLink, Is.EqualTo("http://fake.endpoint.com"));
            Assert.That(createdHook.Administrators, Is.Not.Null);
            Assert.That(createdHook.Administrators.Single(), Is.Not.Null.And.Not.Empty);

            var createdEmailHook = createdHook as EmailNotificationHook;

            Assert.That(createdEmailHook, Is.Not.Null);
            Assert.That(createdEmailHook.EmailsToAlert, Is.EquivalentTo(emailsToAlert));
        }

        [RecordedTest]
        public async Task CreateAndGetWebNotificationHookWithMinimumSetup()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            string hookName = Recording.GenerateAlphaNumericId("hook");

            var hookToCreate = new WebNotificationHook(hookName, "http://contoso.com");

            await using var disposableHook = await DisposableNotificationHook.CreateHookAsync(adminClient, hookToCreate);

            NotificationHook createdHook = await adminClient.GetHookAsync(disposableHook.Id);

            Assert.That(createdHook.Id, Is.EqualTo(disposableHook.Id));
            Assert.That(createdHook.Name, Is.EqualTo(hookName));
            Assert.That(createdHook.Description, Is.Empty);
            Assert.That(createdHook.ExternalLink, Is.Empty);
            Assert.That(createdHook.Administrators, Is.Not.Null);
            Assert.That(createdHook.Administrators.Single(), Is.Not.Null.And.Not.Empty);

            var createdWebHook = createdHook as WebNotificationHook;

            Assert.That(createdWebHook, Is.Not.Null);
            Assert.That(createdWebHook.Endpoint, Is.EqualTo("http://contoso.com"));
            Assert.That(createdWebHook.CertificateKey, Is.Empty);
            Assert.That(createdWebHook.CertificatePassword, Is.Empty);
            Assert.That(createdWebHook.Username, Is.Empty);
            Assert.That(createdWebHook.Password, Is.Empty);
            Assert.That(createdWebHook.Headers, Is.Not.Null.And.Empty);
        }

        [RecordedTest]
        public async Task CreateAndGetWebNotificationHookWithOptionalMembers()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            string hookName = Recording.GenerateAlphaNumericId("hook");
            var endpoint = "http://contoso.com";
            var description = "This hook was created to test the .NET client.";
            var headers = new Dictionary<string, string>()
            {
                { "key1", "value1" },
                { "key2", "value2" }
            };

            var hookToCreate = new WebNotificationHook(hookName, endpoint)
            {
                Description = description,
                ExternalLink = "http://fake.endpoint.com",
                // TODO: add CertificateKey validation (https://github.com/Azure/azure-sdk-for-net/issues/17485)
                CertificatePassword = "certPassword",
                Username = "fakeUsername",
                Password = "fakePassword",
                Headers = headers
            };

            await using var disposableHook = await DisposableNotificationHook.CreateHookAsync(adminClient, hookToCreate);

            NotificationHook createdHook = await adminClient.GetHookAsync(disposableHook.Id);

            Assert.That(createdHook.Id, Is.EqualTo(disposableHook.Id));
            Assert.That(createdHook.Name, Is.EqualTo(hookName));
            Assert.That(createdHook.Description, Is.EqualTo(description));
            Assert.That(createdHook.ExternalLink, Is.EqualTo("http://fake.endpoint.com"));
            Assert.That(createdHook.Administrators, Is.Not.Null);
            Assert.That(createdHook.Administrators.Single(), Is.Not.Null.And.Not.Empty);

            var createdWebHook = createdHook as WebNotificationHook;

            Assert.That(createdWebHook, Is.Not.Null);
            Assert.That(createdWebHook.Endpoint, Is.EqualTo(endpoint));
            // TODO: add CertificateKey validation (https://github.com/Azure/azure-sdk-for-net/issues/17485)
            Assert.That(createdWebHook.CertificatePassword, Is.EqualTo("certPassword"));
            Assert.That(createdWebHook.Username, Is.EqualTo("fakeUsername"));
            Assert.That(createdWebHook.Password, Is.EqualTo("fakePassword"));
            Assert.That(createdWebHook.Headers, Is.EquivalentTo(headers));
        }

        [RecordedTest]
        public async Task UpdateEmailNotificationHookWithMinimumSetupAndGetInstance()
        {
            // Create a hook.

            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            string hookName = Recording.GenerateAlphaNumericId("hook");
            var emailsToAlert = new List<string>() { "fake1@email.com", "fake2@email.com" };

            var hookToCreate = new EmailNotificationHook(hookName, emailsToAlert);

            await using var disposableHook = await DisposableNotificationHook.CreateHookAsync(adminClient, hookToCreate);

            // Update the created hook.

            var hookToUpdate = (await adminClient.GetHookAsync(disposableHook.Id)).Value as EmailNotificationHook;

            hookToUpdate.EmailsToAlert.Add("fake3@email.com");

            await adminClient.UpdateHookAsync(disposableHook.Id, hookToUpdate);

            // Get the hook and check if updates are in place.

            var updatedEmailHook = (await adminClient.GetHookAsync(disposableHook.Id)).Value as EmailNotificationHook;

            Assert.That(updatedEmailHook.Id, Is.EqualTo(disposableHook.Id));
            Assert.That(updatedEmailHook.Name, Is.EqualTo(hookName));
            Assert.That(updatedEmailHook.Description, Is.Empty);
            Assert.That(updatedEmailHook.ExternalLink, Is.Empty);
            Assert.That(updatedEmailHook.Administrators, Is.Not.Null);
            Assert.That(updatedEmailHook.Administrators.Single(), Is.Not.Null.And.Not.Empty);

            var expectedEmailsToAlert = new List<string>() { "fake1@email.com", "fake2@email.com", "fake3@email.com" };
            Assert.That(updatedEmailHook.EmailsToAlert, Is.EquivalentTo(expectedEmailsToAlert));
        }

        [RecordedTest]
        public async Task UpdateEmailNotificationHookWithMinimumSetupAndNewInstance()
        {
            // Create a hook.

            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            string hookName = Recording.GenerateAlphaNumericId("hook");
            var emailsToAlert = new List<string>() { "fake1@email.com", "fake2@email.com" };

            var hookToCreate = new EmailNotificationHook(hookName, emailsToAlert);

            await using var disposableHook = await DisposableNotificationHook.CreateHookAsync(adminClient, hookToCreate);

            // Update the created hook.

            var hookToUpdate = new EmailNotificationHook(hookName, emailsToAlert);

            hookToUpdate.EmailsToAlert.Add("fake3@email.com");

            await adminClient.UpdateHookAsync(disposableHook.Id, hookToUpdate);

            // Get the hook and check if updates are in place.

            var updatedEmailHook = (await adminClient.GetHookAsync(disposableHook.Id)).Value as EmailNotificationHook;

            Assert.That(updatedEmailHook.Id, Is.EqualTo(disposableHook.Id));
            Assert.That(updatedEmailHook.Name, Is.EqualTo(hookName));
            Assert.That(updatedEmailHook.Description, Is.Empty);
            Assert.That(updatedEmailHook.ExternalLink, Is.Empty);
            Assert.That(updatedEmailHook.Administrators, Is.Not.Null);
            Assert.That(updatedEmailHook.Administrators.Single(), Is.Not.Null.And.Not.Empty);

            var expectedEmailsToAlert = new List<string>() { "fake1@email.com", "fake2@email.com", "fake3@email.com" };
            Assert.That(updatedEmailHook.EmailsToAlert, Is.EquivalentTo(expectedEmailsToAlert));
        }

        [RecordedTest]
        public async Task UpdateEmailNotificationHookWithEveryMemberAndGetInstance()
        {
            // Create a hook.

            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            string hookName = Recording.GenerateAlphaNumericId("hook");
            var emailsToAlert = new List<string>() { "fake1@email.com", "fake2@email.com" };
            var description = "This hook was created to test the .NET client.";

            var hookToCreate = new EmailNotificationHook(hookName, emailsToAlert);

            await using var disposableHook = await DisposableNotificationHook.CreateHookAsync(adminClient, hookToCreate);

            // Update the created hook.

            var hookToUpdate = (await adminClient.GetHookAsync(disposableHook.Id)).Value as EmailNotificationHook;

            hookToUpdate.Description = description;
            hookToUpdate.ExternalLink = "http://fake.endpoint.com";
            hookToUpdate.EmailsToAlert.Add("fake3@email.com");

            await adminClient.UpdateHookAsync(disposableHook.Id, hookToUpdate);

            // Get the hook and check if updates are in place.

            var updatedEmailHook = (await adminClient.GetHookAsync(disposableHook.Id)).Value as EmailNotificationHook;

            Assert.That(updatedEmailHook.Id, Is.EqualTo(disposableHook.Id));
            Assert.That(updatedEmailHook.Name, Is.EqualTo(hookName));
            Assert.That(updatedEmailHook.Description, Is.EqualTo(description));
            Assert.That(updatedEmailHook.ExternalLink, Is.EqualTo("http://fake.endpoint.com"));
            Assert.That(updatedEmailHook.Administrators, Is.Not.Null);
            Assert.That(updatedEmailHook.Administrators.Single(), Is.Not.Null.And.Not.Empty);

            var expectedEmailsToAlert = new List<string>() { "fake1@email.com", "fake2@email.com", "fake3@email.com" };
            Assert.That(updatedEmailHook.EmailsToAlert, Is.EquivalentTo(expectedEmailsToAlert));
        }

        [RecordedTest]
        public async Task UpdateEmailNotificationHookWithEveryMemberAndNewInstance()
        {
            // Create a hook.

            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            string hookName = Recording.GenerateAlphaNumericId("hook");
            var emailsToAlert = new List<string>() { "fake1@email.com", "fake2@email.com" };
            var description = "This hook was created to test the .NET client.";

            var hookToCreate = new EmailNotificationHook(hookName, emailsToAlert);

            await using var disposableHook = await DisposableNotificationHook.CreateHookAsync(adminClient, hookToCreate);

            // Update the created hook.

            var hookToUpdate = new EmailNotificationHook(hookName, emailsToAlert);

            hookToUpdate.Description = description;
            hookToUpdate.ExternalLink = "http://fake.endpoint.com";
            hookToUpdate.EmailsToAlert.Add("fake3@email.com");

            await adminClient.UpdateHookAsync(disposableHook.Id, hookToUpdate);

            // Get the hook and check if updates are in place.

            var updatedEmailHook = (await adminClient.GetHookAsync(disposableHook.Id)).Value as EmailNotificationHook;

            Assert.That(updatedEmailHook.Id, Is.EqualTo(disposableHook.Id));
            Assert.That(updatedEmailHook.Name, Is.EqualTo(hookName));
            Assert.That(updatedEmailHook.Description, Is.EqualTo(description));
            Assert.That(updatedEmailHook.ExternalLink, Is.EqualTo("http://fake.endpoint.com"));
            Assert.That(updatedEmailHook.Administrators, Is.Not.Null);
            Assert.That(updatedEmailHook.Administrators.Single(), Is.Not.Null.And.Not.Empty);

            var expectedEmailsToAlert = new List<string>() { "fake1@email.com", "fake2@email.com", "fake3@email.com" };
            Assert.That(updatedEmailHook.EmailsToAlert, Is.EquivalentTo(expectedEmailsToAlert));
        }

        [RecordedTest]
        public async Task UpdateWebNotificationHookWithMinimumSetupAndGetInstance()
        {
            // Create a hook.

            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            string hookName = Recording.GenerateAlphaNumericId("hook");

            var hookToCreate = new WebNotificationHook(hookName, "http://contoso.com");

            await using var disposableHook = await DisposableNotificationHook.CreateHookAsync(adminClient, hookToCreate);

            // Update the created hook.

            var hookToUpdate = (await adminClient.GetHookAsync(disposableHook.Id)).Value as WebNotificationHook;

            hookToUpdate.Username = "fakeUsername";

            await adminClient.UpdateHookAsync(disposableHook.Id, hookToUpdate);

            // Get the hook and check if updates are in place.

            var updatedWebHook = (await adminClient.GetHookAsync(disposableHook.Id)).Value as WebNotificationHook;

            Assert.That(updatedWebHook.Id, Is.EqualTo(disposableHook.Id));
            Assert.That(updatedWebHook.Name, Is.EqualTo(hookName));
            Assert.That(updatedWebHook.Description, Is.Empty);
            Assert.That(updatedWebHook.ExternalLink, Is.Empty);
            Assert.That(updatedWebHook.Administrators, Is.Not.Null);
            Assert.That(updatedWebHook.Administrators.Single(), Is.Not.Null.And.Not.Empty);

            Assert.That(updatedWebHook.Endpoint, Is.EqualTo("http://contoso.com"));
            Assert.That(updatedWebHook.CertificateKey, Is.Empty);
            Assert.That(updatedWebHook.CertificatePassword, Is.Empty);
            Assert.That(updatedWebHook.Username, Is.EqualTo("fakeUsername"));
            Assert.That(updatedWebHook.Password, Is.Empty);
            Assert.That(updatedWebHook.Headers, Is.Not.Null.And.Empty);
        }

        [RecordedTest]
        public async Task UpdateWebNotificationHookWithMinimumSetupAndNewInstance()
        {
            // Create a hook.

            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            string hookName = Recording.GenerateAlphaNumericId("hook");
            var endpoint = "http://contoso.com";

            var hookToCreate = new WebNotificationHook(hookName, endpoint);

            await using var disposableHook = await DisposableNotificationHook.CreateHookAsync(adminClient, hookToCreate);

            // Update the created hook.

            var hookToUpdate = new WebNotificationHook(hookName, endpoint);

            hookToUpdate.Username = "fakeUsername";

            await adminClient.UpdateHookAsync(disposableHook.Id, hookToUpdate);

            // Get the hook and check if updates are in place.

            var updatedWebHook = (await adminClient.GetHookAsync(disposableHook.Id)).Value as WebNotificationHook;

            Assert.That(updatedWebHook.Id, Is.EqualTo(disposableHook.Id));
            Assert.That(updatedWebHook.Name, Is.EqualTo(hookName));
            Assert.That(updatedWebHook.Description, Is.Empty);
            Assert.That(updatedWebHook.ExternalLink, Is.Empty);
            Assert.That(updatedWebHook.Administrators, Is.Not.Null);
            Assert.That(updatedWebHook.Administrators.Single(), Is.Not.Null.And.Not.Empty);

            Assert.That(updatedWebHook.Endpoint, Is.EqualTo(endpoint));
            Assert.That(updatedWebHook.CertificateKey, Is.Empty);
            Assert.That(updatedWebHook.CertificatePassword, Is.Empty);
            Assert.That(updatedWebHook.Username, Is.EqualTo("fakeUsername"));
            Assert.That(updatedWebHook.Password, Is.Empty);
            Assert.That(updatedWebHook.Headers, Is.Not.Null.And.Empty);
        }

        [RecordedTest]
        public async Task UpdateWebNotificationHookWithEveryMemberAndGetInstance()
        {
            // Create a hook.

            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            string hookName = Recording.GenerateAlphaNumericId("hook");
            var endpoint = "http://contoso.com";
            var description = "This hook was created to test the .NET client.";
            var headers = new Dictionary<string, string>()
            {
                { "key1", "value1" },
                { "key2", "value2" }
            };

            var hookToCreate = new WebNotificationHook(hookName, endpoint);

            await using var disposableHook = await DisposableNotificationHook.CreateHookAsync(adminClient, hookToCreate);

            // Update the created hook.

            var hookToUpdate = (await adminClient.GetHookAsync(disposableHook.Id)).Value as WebNotificationHook;

            hookToUpdate.Description = description;
            hookToUpdate.ExternalLink = "http://fake.endpoint.com";
            // TODO: add certificate key validation (https://github.com/Azure/azure-sdk-for-net/issues/17485)
            hookToUpdate.CertificatePassword = "certPassword";
            hookToUpdate.Username = "fakeUsername";
            hookToUpdate.Password = "fakePassword";
            hookToUpdate.Headers = headers;

            await adminClient.UpdateHookAsync(disposableHook.Id, hookToUpdate);

            // Get the hook and check if updates are in place.

            var updatedWebHook = (await adminClient.GetHookAsync(disposableHook.Id)).Value as WebNotificationHook;

            Assert.That(updatedWebHook.Id, Is.EqualTo(disposableHook.Id));
            Assert.That(updatedWebHook.Name, Is.EqualTo(hookName));
            Assert.That(updatedWebHook.Description, Is.EqualTo(description));
            Assert.That(updatedWebHook.ExternalLink, Is.EqualTo("http://fake.endpoint.com"));
            Assert.That(updatedWebHook.Administrators, Is.Not.Null);
            Assert.That(updatedWebHook.Administrators.Single(), Is.Not.Null.And.Not.Empty);

            Assert.That(updatedWebHook.Endpoint, Is.EqualTo(endpoint));
            // TODO: add certificate key validation (https://github.com/Azure/azure-sdk-for-net/issues/17485)
            Assert.That(updatedWebHook.CertificatePassword, Is.EqualTo("certPassword"));
            Assert.That(updatedWebHook.Username, Is.EqualTo("fakeUsername"));
            Assert.That(updatedWebHook.Password, Is.EqualTo("fakePassword"));
            Assert.That(updatedWebHook.Headers, Is.EquivalentTo(headers));
        }

        [RecordedTest]
        public async Task UpdateWebNotificationHookWithEveryMemberAndNewInstance()
        {
            // Create a hook.

            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            string hookName = Recording.GenerateAlphaNumericId("hook");
            var endpoint = "http://contoso.com";
            var description = "This hook was created to test the .NET client.";
            var headers = new Dictionary<string, string>()
            {
                { "key1", "value1" },
                { "key2", "value2" }
            };

            var hookToCreate = new WebNotificationHook(hookName, endpoint);

            await using var disposableHook = await DisposableNotificationHook.CreateHookAsync(adminClient, hookToCreate);

            // Update the created hook.

            var hookToUpdate = new WebNotificationHook(hookName, endpoint);

            hookToUpdate.Description = description;
            hookToUpdate.ExternalLink = "http://fake.endpoint.com";
            // TODO: add certificate key validation (https://github.com/Azure/azure-sdk-for-net/issues/17485)
            hookToUpdate.CertificatePassword = "certPassword";
            hookToUpdate.Username = "fakeUsername";
            hookToUpdate.Password = "fakePassword";
            hookToUpdate.Headers = headers;

            await adminClient.UpdateHookAsync(disposableHook.Id, hookToUpdate);

            // Get the hook and check if updates are in place.

            var updatedWebHook = (await adminClient.GetHookAsync(disposableHook.Id)).Value as WebNotificationHook;

            Assert.That(updatedWebHook.Id, Is.EqualTo(disposableHook.Id));
            Assert.That(updatedWebHook.Name, Is.EqualTo(hookName));
            Assert.That(updatedWebHook.Description, Is.EqualTo(description));
            Assert.That(updatedWebHook.ExternalLink, Is.EqualTo("http://fake.endpoint.com"));
            Assert.That(updatedWebHook.Administrators, Is.Not.Null);
            Assert.That(updatedWebHook.Administrators.Single(), Is.Not.Null.And.Not.Empty);

            Assert.That(updatedWebHook.Endpoint, Is.EqualTo(endpoint));
            // TODO: add certificate key validation (https://github.com/Azure/azure-sdk-for-net/issues/17485)
            Assert.That(updatedWebHook.CertificatePassword, Is.EqualTo("certPassword"));
            Assert.That(updatedWebHook.Username, Is.EqualTo("fakeUsername"));
            Assert.That(updatedWebHook.Password, Is.EqualTo("fakePassword"));
            Assert.That(updatedWebHook.Headers, Is.EquivalentTo(headers));
        }

        [RecordedTest]
        public async Task GetHooksWithMinimumSetup()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            string hookName = Recording.GenerateAlphaNumericId("hook");
            var hookToCreate = new WebNotificationHook(hookName, "http://contoso.com");

            await using var disposableHook = await DisposableNotificationHook.CreateHookAsync(adminClient, hookToCreate);

            var hookCount = 0;

            await foreach (NotificationHook hook in adminClient.GetHooksAsync())
            {
                Assert.That(hook.Id, Is.Not.Null.And.Not.Empty);
                Assert.That(hook.Name, Is.Not.Null.And.Not.Empty);
                Assert.That(hook.Administrators, Is.Not.Null.And.Not.Empty);
                Assert.That(hook.Administrators.Any(admin => admin == null || admin == string.Empty), Is.False);
                Assert.That(hook.Description, Is.Not.Null);
                Assert.That(hook.ExternalLink, Is.Not.Null);

                if (hook is EmailNotificationHook)
                {
                    var emailHook = hook as EmailNotificationHook;

                    Assert.That(emailHook.EmailsToAlert, Is.Not.Null);
                }
                else
                {
                    var webHook = hook as WebNotificationHook;

                    Assert.That(webHook, Is.Not.Null);
                    Assert.That(webHook.CertificateKey, Is.Not.Null);
                    Assert.That(webHook.CertificatePassword, Is.Not.Null);
                    Assert.That(webHook.Username, Is.Not.Null);
                    Assert.That(webHook.Password, Is.Not.Null);
                    Assert.That(webHook.Headers, Is.Not.Null);
                    Assert.That(webHook.Headers.Values.Any(value => value == null), Is.False);
                }

                if (++hookCount >= MaximumSamplesCount)
                {
                    break;
                }
            }

            Assert.That(hookCount, Is.GreaterThan(0));
        }

        [RecordedTest]
        public async Task GetHooksWithOptionalNameFilter()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            string hookName = Recording.GenerateAlphaNumericId("hook");
            string hookNameFilter = hookName.Substring(1, hookName.Length - 3);
            var hookToCreate = new WebNotificationHook(hookName, "http://contoso.com");

            await using var disposableHook = await DisposableNotificationHook.CreateHookAsync(adminClient, hookToCreate);

            var options = new GetHooksOptions()
            {
                HookNameFilter = hookNameFilter
            };

            var hookCount = 0;

            await foreach (NotificationHook hook in adminClient.GetHooksAsync(options))
            {
                Assert.That(hook.Id, Is.Not.Null.And.Not.Empty);
                Assert.That(hook.Name, Is.Not.Null.And.Not.Empty);
                Assert.That(hook.Name.Contains(hookNameFilter));
                Assert.That(hook.Administrators, Is.Not.Null.And.Not.Empty);
                Assert.That(hook.Administrators.Any(admin => admin == null || admin == string.Empty), Is.False);
                Assert.That(hook.Description, Is.Not.Null);
                Assert.That(hook.ExternalLink, Is.Not.Null);

                if (hook is EmailNotificationHook)
                {
                    var emailHook = hook as EmailNotificationHook;

                    Assert.That(emailHook.EmailsToAlert, Is.Not.Null);
                }
                else
                {
                    var webHook = hook as WebNotificationHook;

                    Assert.That(webHook, Is.Not.Null);
                    Assert.That(webHook.CertificateKey, Is.Not.Null);
                    Assert.That(webHook.CertificatePassword, Is.Not.Null);
                    Assert.That(webHook.Username, Is.Not.Null);
                    Assert.That(webHook.Password, Is.Not.Null);
                    Assert.That(webHook.Headers, Is.Not.Null);
                    Assert.That(webHook.Headers.Values.Any(value => value == null), Is.False);
                }

                if (++hookCount >= MaximumSamplesCount)
                {
                    break;
                }
            }

            Assert.That(hookCount, Is.GreaterThan(0));
        }

        [RecordedTest]
        public async Task DeleteNotificationHook()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            string hookName = Recording.GenerateAlphaNumericId("hook");
            var hookToCreate = new WebNotificationHook(hookName, "http://contoso.com");

            string hookId = null;

            try
            {
                hookId = await adminClient.CreateHookAsync(hookToCreate);

                Assert.That(hookId, Is.Not.Null.And.Not.Empty);
            }
            finally
            {
                if (hookId != null)
                {
                    await adminClient.DeleteHookAsync(hookId);

                    var errorCause = "hookId is invalid";
                    Assert.That(async () => await adminClient.GetHookAsync(hookId), Throws.InstanceOf<RequestFailedException>().With.Message.Contains(errorCause));
                }
            }
        }
    }
}
