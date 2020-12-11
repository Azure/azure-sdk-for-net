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

        /// <param name="populateOptionalMembers">
        /// When <c>true</c>, all optional properties are populated to make sure values are being passed and returned
        /// correctly. When <c>false</c>, the test makes sure it's still possible to make a request with the minimum
        /// configuration and that the responses with <c>null</c> and <c>default</c> values can be parsed by the client.
        /// </param>
        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task CreateAndGetEmailNotificationHook(bool populateOptionalMembers)
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            string hookName = Recording.GenerateAlphaNumericId("hook");
            var emailsToAlert = new List<string>() { "fake1@email.com", "fake2@email.com" };
            var description = "This hook was created to test the .NET client.";

            var hookToCreate = new EmailNotificationHook(hookName, emailsToAlert);

            if (populateOptionalMembers)
            {
                hookToCreate.Description = description;
                hookToCreate.ExternalLink = "http://fake.endpoint.com";
            }

            await using var disposableHook = await DisposableNotificationHook.CreateHookAsync(adminClient, hookToCreate);

            NotificationHook createdHook = await adminClient.GetHookAsync(disposableHook.Id);

            Assert.That(createdHook.Id, Is.EqualTo(disposableHook.Id));
            Assert.That(createdHook.Name, Is.EqualTo(hookName));
            Assert.That(createdHook.Administrators, Is.Not.Null);
            Assert.That(createdHook.Administrators.Single(), Is.Not.Null.And.Not.Empty);

            var createdEmailHook = createdHook as EmailNotificationHook;

            Assert.That(createdEmailHook, Is.Not.Null);
            Assert.That(createdEmailHook.EmailsToAlert, Is.EquivalentTo(emailsToAlert));

            if (populateOptionalMembers)
            {
                Assert.That(createdHook.Description, Is.EqualTo(description));
                Assert.That(createdHook.ExternalLink, Is.EqualTo("http://fake.endpoint.com"));
            }
            else
            {
                Assert.That(createdHook.Description, Is.Empty);
                Assert.That(createdHook.ExternalLink, Is.Empty);
            }
        }

        /// <param name="populateOptionalMembers">
        /// When <c>true</c>, all optional properties are populated to make sure values are being passed and returned
        /// correctly. When <c>false</c>, the test makes sure it's still possible to make a request with the minimum
        /// configuration and that the responses with <c>null</c> and <c>default</c> values can be parsed by the client.
        /// </param>
        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task CreateAndGetWebNotificationHook(bool populateOptionalMembers)
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

            var hookToCreate = new WebNotificationHook(hookName, endpoint);

            if (populateOptionalMembers)
            {
                hookToCreate.Description = description;
                hookToCreate.ExternalLink = "http://fake.endpoint.com";
                // TODO: add certificate key validation (https://github.com/Azure/azure-sdk-for-net/issues/17485).
                hookToCreate.CertificatePassword = "certPassword";
                hookToCreate.Username = "fakeUsername";
                hookToCreate.Password = "fakePassword";
                hookToCreate.Headers = headers;
            }

            await using var disposableHook = await DisposableNotificationHook.CreateHookAsync(adminClient, hookToCreate);

            NotificationHook createdHook = await adminClient.GetHookAsync(disposableHook.Id);

            Assert.That(createdHook.Id, Is.EqualTo(disposableHook.Id));
            Assert.That(createdHook.Name, Is.EqualTo(hookName));
            Assert.That(createdHook.Administrators, Is.Not.Null);
            Assert.That(createdHook.Administrators.Single(), Is.Not.Null.And.Not.Empty);

            var createdWebHook = createdHook as WebNotificationHook;

            Assert.That(createdWebHook, Is.Not.Null);
            Assert.That(createdWebHook.Endpoint, Is.EqualTo(endpoint));

            if (populateOptionalMembers)
            {
                Assert.That(createdHook.Description, Is.EqualTo(description));
                Assert.That(createdHook.ExternalLink, Is.EqualTo("http://fake.endpoint.com"));
                // TODO: add certificate key validation (https://github.com/Azure/azure-sdk-for-net/issues/17485).
                Assert.That(createdWebHook.CertificatePassword, Is.EqualTo("certPassword"));
                Assert.That(createdWebHook.Username, Is.EqualTo("fakeUsername"));
                Assert.That(createdWebHook.Password, Is.EqualTo("fakePassword"));
                Assert.That(createdWebHook.Headers, Is.EquivalentTo(headers));
            }
            else
            {
                Assert.That(createdHook.Description, Is.Empty);
                Assert.That(createdHook.ExternalLink, Is.Empty);
                Assert.That(createdWebHook.CertificateKey, Is.Empty);
                Assert.That(createdWebHook.CertificatePassword, Is.Empty);
                Assert.That(createdWebHook.Username, Is.Empty);
                Assert.That(createdWebHook.Password, Is.Empty);
                Assert.That(createdWebHook.Headers, Is.Not.Null.And.Empty);
            }
        }

        /// <param name="updateWithNewInstance">
        /// Users have two ways of creating a <see cref="NotificationHook"/>, and this parameter is used to test the Update
        /// method with both. If <c>true</c>, the instance passed to Update is created from scratch. If <c>false</c>, the
        /// instance passed to Update is obtained from the Get method.
        /// </param>
        /// <param name="updateAllMembers">
        /// When <c>true</c>, updates all possible members to make sure values are being passed and returned correctly.
        /// When <c>false</c>, only updates one member, and makes sure that other values were not altered.
        /// </param>
        [RecordedTest]
        [TestCase(true, true)]
        [TestCase(true, false)]
        [TestCase(false, true)]
        [TestCase(false, false)]
        public async Task UpdateEmailNotificationHook(bool updateWithNewInstance, bool updateAllMembers)
        {
            // Create a hook.

            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            string hookName = Recording.GenerateAlphaNumericId("hook");
            var emailsToAlert = new List<string>() { "fake1@email.com", "fake2@email.com" };
            var description = "This hook was created to test the .NET client.";

            var hookToCreate = new EmailNotificationHook(hookName, emailsToAlert);

            await using var disposableHook = await DisposableNotificationHook.CreateHookAsync(adminClient, hookToCreate);

            // Update the created hook.

            var hookToUpdate = updateWithNewInstance
                ? new EmailNotificationHook(hookName, emailsToAlert)
                : (await adminClient.GetHookAsync(disposableHook.Id)).Value as EmailNotificationHook;

            hookToUpdate.EmailsToAlert.Add("fake3@email.com");

            if (updateAllMembers)
            {
                hookToUpdate.Description = description;
                hookToUpdate.ExternalLink = "http://fake.endpoint.com";
            }

            await adminClient.UpdateHookAsync(disposableHook.Id, hookToUpdate);

            // Get the hook and check if updates are in place.

            var updatedEmailHook = (await adminClient.GetHookAsync(disposableHook.Id)).Value as EmailNotificationHook;

            Assert.That(updatedEmailHook.Id, Is.EqualTo(disposableHook.Id));
            Assert.That(updatedEmailHook.Name, Is.EqualTo(hookName));
            Assert.That(updatedEmailHook.Administrators, Is.Not.Null);
            Assert.That(updatedEmailHook.Administrators.Single(), Is.Not.Null.And.Not.Empty);

            var expectedEmailsToAlert = new List<string>() { "fake1@email.com", "fake2@email.com", "fake3@email.com" };
            Assert.That(updatedEmailHook.EmailsToAlert, Is.EquivalentTo(expectedEmailsToAlert));

            if (updateAllMembers)
            {
                Assert.That(updatedEmailHook.Description, Is.EqualTo(description));
                Assert.That(updatedEmailHook.ExternalLink, Is.EqualTo("http://fake.endpoint.com"));
            }
            else
            {
                Assert.That(updatedEmailHook.Description, Is.Empty);
                Assert.That(updatedEmailHook.ExternalLink, Is.Empty);
            }
        }

        /// <param name="updateWithNewInstance">
        /// Users have two ways of creating a <see cref="NotificationHook"/>, and this parameter is used to test the Update
        /// method with both. If <c>true</c>, the instance passed to Update is created from scratch. If <c>false</c>, the
        /// instance passed to Update is obtained from the Get method.
        /// </param>
        /// <param name="updateAllMembers">
        /// When <c>true</c>, updates all possible members to make sure values are being passed and returned correctly.
        /// When <c>false</c>, only updates one member, and makes sure that other values were not altered.
        /// </param>
        [RecordedTest]
        [TestCase(true, true)]
        [TestCase(true, false)]
        [TestCase(false, true)]
        [TestCase(false, false)]
        public async Task UpdateWebNotificationHook(bool updateWithNewInstance, bool updateAllMembers)
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

            var hookToUpdate = updateWithNewInstance
                ? new WebNotificationHook(hookName, endpoint)
                : (await adminClient.GetHookAsync(disposableHook.Id)).Value as WebNotificationHook;

            hookToUpdate.Username = "fakeUsername";

            if (updateAllMembers)
            {
                hookToUpdate.Description = description;
                hookToUpdate.ExternalLink = "http://fake.endpoint.com";
                // TODO: add certificate key validation (https://github.com/Azure/azure-sdk-for-net/issues/17485).
                hookToUpdate.CertificatePassword = "certPassword";
                hookToUpdate.Password = "fakePassword";
                hookToUpdate.Headers = headers;
            }

            await adminClient.UpdateHookAsync(disposableHook.Id, hookToUpdate);

            // Get the hook and check if updates are in place.

            var updatedWebHook = (await adminClient.GetHookAsync(disposableHook.Id)).Value as WebNotificationHook;

            Assert.That(updatedWebHook.Id, Is.EqualTo(disposableHook.Id));
            Assert.That(updatedWebHook.Name, Is.EqualTo(hookName));
            Assert.That(updatedWebHook.Endpoint, Is.EqualTo(endpoint));
            Assert.That(updatedWebHook.Administrators, Is.Not.Null);
            Assert.That(updatedWebHook.Administrators.Single(), Is.Not.Null.And.Not.Empty);

            Assert.That(updatedWebHook.Username, Is.EquivalentTo("fakeUsername"));

            if (updateAllMembers)
            {
                Assert.That(updatedWebHook.Description, Is.EqualTo(description));
                Assert.That(updatedWebHook.ExternalLink, Is.EqualTo("http://fake.endpoint.com"));
                // TODO: add certificate key validation (https://github.com/Azure/azure-sdk-for-net/issues/17485).
                Assert.That(updatedWebHook.CertificatePassword, Is.EqualTo("certPassword"));
                Assert.That(updatedWebHook.Password, Is.EqualTo("fakePassword"));
                Assert.That(updatedWebHook.Headers, Is.EquivalentTo(headers));
            }
            else
            {
                Assert.That(updatedWebHook.Description, Is.Empty);
                Assert.That(updatedWebHook.ExternalLink, Is.Empty);
                Assert.That(updatedWebHook.CertificateKey, Is.Empty);
                Assert.That(updatedWebHook.CertificatePassword, Is.Empty);
                Assert.That(updatedWebHook.Password, Is.Empty);
                Assert.That(updatedWebHook.Headers, Is.Not.Null.And.Empty);
            }
        }

        /// <param name="populateOptionalMembers">
        /// When <c>true</c>, all optional properties are populated to make sure values are being passed and returned
        /// correctly. When <c>false</c>, the test makes sure it's still possible to make a request with the minimum
        /// configuration and that the responses with <c>null</c> and <c>default</c> values can be parsed by the client.
        /// </param>
        [RecordedTest]
        [TestCase(true)]
        [TestCase(false)]
        public async Task GetHooks(bool populateOptionalMembers)
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            string hookName = Recording.GenerateAlphaNumericId("hook");
            string hookNameFilter = hookName.Substring(1, hookName.Length - 3);
            var hookToCreate = new WebNotificationHook(hookName, "http://contoso.com");

            await using var disposableHook = await DisposableNotificationHook.CreateHookAsync(adminClient, hookToCreate);

            var options = new GetHooksOptions();

            if (populateOptionalMembers)
            {
                options.HookNameFilter = hookNameFilter;
            }

            var hookCount = 0;

            await foreach (NotificationHook hook in adminClient.GetHooksAsync(options))
            {
                Assert.That(hook.Id, Is.Not.Null.And.Not.Empty);
                Assert.That(hook.Name, Is.Not.Null.And.Not.Empty);
                Assert.That(hook.Administrators, Is.Not.Null.And.Not.Empty);
                Assert.That(hook.Administrators.Any(admin => admin == null || admin == string.Empty), Is.False);
                Assert.That(hook.Description, Is.Not.Null);
                Assert.That(hook.ExternalLink, Is.Not.Null);

                if (populateOptionalMembers)
                {
                    Assert.That(hook.Name.Contains(hookNameFilter));
                }

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

                    Assert.That(async () => await adminClient.GetHookAsync(hookId), Throws.InstanceOf<RequestFailedException>());
                }
            }
        }
    }
}
