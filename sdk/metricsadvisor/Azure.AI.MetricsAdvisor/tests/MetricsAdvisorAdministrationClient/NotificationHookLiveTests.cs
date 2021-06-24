// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.AI.MetricsAdvisor.Administration;
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
        [TestCase(true)]
        [TestCase(false)]
        public async Task CreateAndGetEmailNotificationHookWithMinimumSetup(bool useTokenCredential)
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient(useTokenCredential);

            string hookName = Recording.GenerateAlphaNumericId("hook");

            var hookToCreate = new EmailNotificationHook(hookName)
            {
                EmailsToAlert = { "fake1@email.com", "fake2@email.com" }
            };

            await using var disposableHook = await DisposableNotificationHook.CreateHookAsync(adminClient, hookToCreate);

            NotificationHook createdHook = disposableHook.Hook;

            Assert.That(createdHook.Id, Is.Not.Null.And.Not.Empty);
            Assert.That(createdHook.Name, Is.EqualTo(hookName));
            Assert.That(createdHook.Description, Is.Empty);
            Assert.That(createdHook.ExternalLink, Is.Null);
            Assert.That(createdHook.AdministratorsEmails, Is.Not.Null);
            Assert.That(createdHook.AdministratorsEmails.Single(), Is.Not.Null.And.Not.Empty);

            var createdEmailHook = createdHook as EmailNotificationHook;

            Assert.That(createdEmailHook, Is.Not.Null);
            Assert.That(createdEmailHook.EmailsToAlert.Count, Is.EqualTo(2));
            Assert.That(createdEmailHook.EmailsToAlert.Contains("fake1@email.com"));
            Assert.That(createdEmailHook.EmailsToAlert.Contains("fake2@email.com"));
        }

        [RecordedTest]
        public async Task CreateAndGetEmailNotificationHookWithOptionalMembers()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            string hookName = Recording.GenerateAlphaNumericId("hook");
            var description = "This hook was created to test the .NET client.";

            var hookToCreate = new EmailNotificationHook(hookName)
            {
                EmailsToAlert = { "fake1@email.com", "fake2@email.com" },
                Description = description,
                ExternalLink = new Uri("http://fake.endpoint.com/")
            };

            await using var disposableHook = await DisposableNotificationHook.CreateHookAsync(adminClient, hookToCreate);

            NotificationHook createdHook = disposableHook.Hook;

            Assert.That(createdHook.Id, Is.Not.Null.And.Not.Empty);
            Assert.That(createdHook.Name, Is.EqualTo(hookName));
            Assert.That(createdHook.Description, Is.EqualTo(description));
            Assert.That(createdHook.ExternalLink.AbsoluteUri, Is.EqualTo("http://fake.endpoint.com/"));
            Assert.That(createdHook.AdministratorsEmails, Is.Not.Null);
            Assert.That(createdHook.AdministratorsEmails.Single(), Is.Not.Null.And.Not.Empty);

            var createdEmailHook = createdHook as EmailNotificationHook;

            Assert.That(createdEmailHook, Is.Not.Null);
            Assert.That(createdEmailHook.EmailsToAlert.Count, Is.EqualTo(2));
            Assert.That(createdEmailHook.EmailsToAlert.Contains("fake1@email.com"));
            Assert.That(createdEmailHook.EmailsToAlert.Contains("fake2@email.com"));
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/21504")]
        public async Task CreateAndGetWebNotificationHookWithMinimumSetup()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            string hookName = Recording.GenerateAlphaNumericId("hook");

            var hookToCreate = new WebNotificationHook(hookName, new Uri("http://contoso.com/"));

            await using var disposableHook = await DisposableNotificationHook.CreateHookAsync(adminClient, hookToCreate);

            NotificationHook createdHook = disposableHook.Hook;

            Assert.That(createdHook.Id, Is.Not.Null.And.Not.Empty);
            Assert.That(createdHook.Name, Is.EqualTo(hookName));
            Assert.That(createdHook.Description, Is.Empty);
            Assert.That(createdHook.ExternalLink, Is.Null);
            Assert.That(createdHook.AdministratorsEmails, Is.Not.Null);
            Assert.That(createdHook.AdministratorsEmails.Single(), Is.Not.Null.And.Not.Empty);

            var createdWebHook = createdHook as WebNotificationHook;

            Assert.That(createdWebHook, Is.Not.Null);
            Assert.That(createdWebHook.Endpoint.AbsoluteUri, Is.EqualTo("http://contoso.com/"));
            Assert.That(createdWebHook.CertificateKey, Is.Empty);
            Assert.That(createdWebHook.CertificatePassword, Is.Empty);
            Assert.That(createdWebHook.Username, Is.Empty);
            Assert.That(createdWebHook.Password, Is.Empty);
            Assert.That(createdWebHook.Headers, Is.Not.Null.And.Empty);
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/21504")]
        public async Task CreateAndGetWebNotificationHookWithOptionalMembers()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            string hookName = Recording.GenerateAlphaNumericId("hook");
            var endpoint = new Uri("http://contoso.com/");
            var description = "This hook was created to test the .NET client.";
            var headers = new Dictionary<string, string>()
            {
                { "key1", "value1" },
                { "key2", "value2" }
            };

            var hookToCreate = new WebNotificationHook(hookName, endpoint)
            {
                Description = description,
                ExternalLink = new Uri("http://fake.endpoint.com/"),
                // TODO: add CertificateKey validation (https://github.com/Azure/azure-sdk-for-net/issues/17485)
                CertificatePassword = "certPassword",
                Username = "fakeUsername",
                Password = "fakePassword"
            };

            foreach (var header in headers)
            {
                hookToCreate.Headers.Add(header);
            }

            await using var disposableHook = await DisposableNotificationHook.CreateHookAsync(adminClient, hookToCreate);

            NotificationHook createdHook = disposableHook.Hook;

            Assert.That(createdHook.Id, Is.Not.Null.And.Not.Empty);
            Assert.That(createdHook.Name, Is.EqualTo(hookName));
            Assert.That(createdHook.Description, Is.EqualTo(description));
            Assert.That(createdHook.ExternalLink.AbsoluteUri, Is.EqualTo("http://fake.endpoint.com/"));
            Assert.That(createdHook.AdministratorsEmails, Is.Not.Null);
            Assert.That(createdHook.AdministratorsEmails.Single(), Is.Not.Null.And.Not.Empty);

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
        [TestCase(true)]
        [TestCase(false)]
        public async Task UpdateEmailNotificationHookWithMinimumSetup(bool useTokenCredential)
        {
            // Create a hook.

            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient(useTokenCredential);

            string hookName = Recording.GenerateAlphaNumericId("hook");

            var hookToCreate = new EmailNotificationHook(hookName)
            {
                EmailsToAlert = { "fake1@email.com", "fake2@email.com" }
            };

            await using var disposableHook = await DisposableNotificationHook.CreateHookAsync(adminClient, hookToCreate);

            // Update the created hook.

            var hookToUpdate = disposableHook.Hook as EmailNotificationHook;

            hookToUpdate.EmailsToAlert.Add("fake3@email.com");

            var updatedEmailHook = (await adminClient.UpdateHookAsync(hookToUpdate)).Value as EmailNotificationHook;

            // Check if updates are in place.

            Assert.That(updatedEmailHook.Id, Is.EqualTo(hookToUpdate.Id));
            Assert.That(updatedEmailHook.Name, Is.EqualTo(hookName));
            Assert.That(updatedEmailHook.Description, Is.Empty);
            Assert.That(updatedEmailHook.ExternalLink, Is.Null);
            Assert.That(updatedEmailHook.AdministratorsEmails, Is.Not.Null);
            Assert.That(updatedEmailHook.AdministratorsEmails.Single(), Is.Not.Null.And.Not.Empty);

            var expectedEmailsToAlert = new List<string>() { "fake1@email.com", "fake2@email.com", "fake3@email.com" };
            Assert.That(updatedEmailHook.EmailsToAlert, Is.EquivalentTo(expectedEmailsToAlert));
        }

        [RecordedTest]
        public async Task UpdateEmailNotificationHookWithEveryMember()
        {
            // Create a hook.

            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            string hookName = Recording.GenerateAlphaNumericId("hook");
            var description = "This hook was created to test the .NET client.";

            var hookToCreate = new EmailNotificationHook(hookName)
            {
                EmailsToAlert = { "fake1@email.com", "fake2@email.com" }
            };

            await using var disposableHook = await DisposableNotificationHook.CreateHookAsync(adminClient, hookToCreate);

            // Update the created hook.

            var hookToUpdate = disposableHook.Hook as EmailNotificationHook;

            hookToUpdate.Description = description;
            hookToUpdate.ExternalLink = new Uri("http://fake.endpoint.com/");
            hookToUpdate.EmailsToAlert.Add("fake3@email.com");

            var updatedEmailHook = (await adminClient.UpdateHookAsync(hookToUpdate)).Value as EmailNotificationHook;

            // Check if updates are in place.

            Assert.That(updatedEmailHook.Id, Is.EqualTo(hookToUpdate.Id));
            Assert.That(updatedEmailHook.Name, Is.EqualTo(hookName));
            Assert.That(updatedEmailHook.Description, Is.EqualTo(description));
            Assert.That(updatedEmailHook.ExternalLink.AbsoluteUri, Is.EqualTo("http://fake.endpoint.com/"));
            Assert.That(updatedEmailHook.AdministratorsEmails, Is.Not.Null);
            Assert.That(updatedEmailHook.AdministratorsEmails.Single(), Is.Not.Null.And.Not.Empty);

            var expectedEmailsToAlert = new List<string>() { "fake1@email.com", "fake2@email.com", "fake3@email.com" };
            Assert.That(updatedEmailHook.EmailsToAlert, Is.EquivalentTo(expectedEmailsToAlert));
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/21504")]
        public async Task UpdateWebNotificationHookWithMinimumSetup()
        {
            // Create a hook.

            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            string hookName = Recording.GenerateAlphaNumericId("hook");

            var hookToCreate = new WebNotificationHook(hookName, new Uri("http://contoso.com/"));

            await using var disposableHook = await DisposableNotificationHook.CreateHookAsync(adminClient, hookToCreate);

            // Update the created hook.

            var hookToUpdate = disposableHook.Hook as WebNotificationHook;

            hookToUpdate.Username = "fakeUsername";

            var updatedWebHook = (await adminClient.UpdateHookAsync(hookToUpdate)).Value as WebNotificationHook;

            // Check if updates are in place.

            Assert.That(updatedWebHook.Id, Is.EqualTo(hookToUpdate.Id));
            Assert.That(updatedWebHook.Name, Is.EqualTo(hookName));
            Assert.That(updatedWebHook.Description, Is.Empty);
            Assert.That(updatedWebHook.ExternalLink, Is.Null);
            Assert.That(updatedWebHook.AdministratorsEmails, Is.Not.Null);
            Assert.That(updatedWebHook.AdministratorsEmails.Single(), Is.Not.Null.And.Not.Empty);

            Assert.That(updatedWebHook.Endpoint.AbsoluteUri, Is.EqualTo("http://contoso.com/"));
            Assert.That(updatedWebHook.CertificateKey, Is.Empty);
            Assert.That(updatedWebHook.CertificatePassword, Is.Empty);
            Assert.That(updatedWebHook.Username, Is.EqualTo("fakeUsername"));
            Assert.That(updatedWebHook.Password, Is.Empty);
            Assert.That(updatedWebHook.Headers, Is.Not.Null.And.Empty);
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/21504")]
        public async Task UpdateWebNotificationHookWithEveryMember()
        {
            // Create a hook.

            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            string hookName = Recording.GenerateAlphaNumericId("hook");
            var endpoint = new Uri("http://contoso.com/");
            var description = "This hook was created to test the .NET client.";
            var headers = new Dictionary<string, string>()
            {
                { "key1", "value1" },
                { "key2", "value2" }
            };

            var hookToCreate = new WebNotificationHook(hookName, endpoint);

            await using var disposableHook = await DisposableNotificationHook.CreateHookAsync(adminClient, hookToCreate);

            // Update the created hook.

            var hookToUpdate = disposableHook.Hook as WebNotificationHook;

            hookToUpdate.Description = description;
            hookToUpdate.ExternalLink = new Uri("http://fake.endpoint.com/");
            // TODO: add certificate key validation (https://github.com/Azure/azure-sdk-for-net/issues/17485)
            hookToUpdate.CertificatePassword = "certPassword";
            hookToUpdate.Username = "fakeUsername";
            hookToUpdate.Password = "fakePassword";

            foreach (var header in headers)
            {
                hookToUpdate.Headers.Add(header);
            }

            var updatedWebHook = (await adminClient.UpdateHookAsync(hookToUpdate)).Value as WebNotificationHook;

            // Check if updates are in place.

            Assert.That(updatedWebHook.Id, Is.EqualTo(hookToUpdate.Id));
            Assert.That(updatedWebHook.Name, Is.EqualTo(hookName));
            Assert.That(updatedWebHook.Description, Is.EqualTo(description));
            Assert.That(updatedWebHook.ExternalLink.AbsoluteUri, Is.EqualTo("http://fake.endpoint.com/"));
            Assert.That(updatedWebHook.AdministratorsEmails, Is.Not.Null);
            Assert.That(updatedWebHook.AdministratorsEmails.Single(), Is.Not.Null.And.Not.Empty);

            Assert.That(updatedWebHook.Endpoint, Is.EqualTo(endpoint));
            // TODO: add certificate key validation (https://github.com/Azure/azure-sdk-for-net/issues/17485)
            Assert.That(updatedWebHook.CertificatePassword, Is.EqualTo("certPassword"));
            Assert.That(updatedWebHook.Username, Is.EqualTo("fakeUsername"));
            Assert.That(updatedWebHook.Password, Is.EqualTo("fakePassword"));
            Assert.That(updatedWebHook.Headers, Is.EquivalentTo(headers));
        }

        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/18004")]
        public async Task GetHooksWithMinimumSetup(bool useTokenCredential)
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient(useTokenCredential);

            string hookName = Recording.GenerateAlphaNumericId("hook");
            var hookToCreate = new WebNotificationHook(hookName, new Uri("http://contoso.com/"));

            await using var disposableHook = await DisposableNotificationHook.CreateHookAsync(adminClient, hookToCreate);

            var hookCount = 0;

            await foreach (NotificationHook hook in adminClient.GetHooksAsync())
            {
                Assert.That(hook.Id, Is.Not.Null.And.Not.Empty);
                Assert.That(hook.Name, Is.Not.Null.And.Not.Empty);
                Assert.That(hook.AdministratorsEmails, Is.Not.Null.And.Not.Empty);
                Assert.That(hook.AdministratorsEmails.Any(admin => admin == null || admin == string.Empty), Is.False);
                Assert.That(hook.Description, Is.Not.Null);

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
            var hookToCreate = new EmailNotificationHook(hookName) { EmailsToAlert = { "fake@email.com" } };

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
                Assert.That(hook.AdministratorsEmails, Is.Not.Null.And.Not.Empty);
                Assert.That(hook.AdministratorsEmails.Any(admin => admin == null || admin == string.Empty), Is.False);
                Assert.That(hook.Description, Is.Not.Null);

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
        [TestCase(true)]
        [TestCase(false)]
        public async Task DeleteNotificationHook(bool useTokenCredential)
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient(useTokenCredential);

            string hookName = Recording.GenerateAlphaNumericId("hook");
            var hookToCreate = new EmailNotificationHook(hookName) { EmailsToAlert = { "fake@email.com" } };

            string hookId = null;

            try
            {
                NotificationHook createdHook = await adminClient.CreateHookAsync(hookToCreate);
                hookId = createdHook.Id;

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
