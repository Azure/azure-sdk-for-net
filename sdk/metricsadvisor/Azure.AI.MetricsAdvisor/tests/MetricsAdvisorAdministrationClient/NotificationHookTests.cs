// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using Azure.AI.MetricsAdvisor.Administration;
using Azure.AI.MetricsAdvisor.Models;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.MetricsAdvisor.Tests
{
    public class NotificationHookTests : ClientTestBase
    {
        public NotificationHookTests(bool isAsync) : base(isAsync)
        {
        }

        private string FakeGuid => "00000000-0000-0000-0000-000000000000";

        [Test]
        public void CreateHookValidatesArguments()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var name = "hookName";
            var endpoint = "http://fakeendpoint.com";

            var genericHook = new NotificationHook() { Name = name };
            var emailHook = new EmailNotificationHook() { Name = null, EmailsToAlert = { "fake@email.com" } };
            var webHook = new WebNotificationHook() { Name = null, Endpoint = endpoint };

            Assert.That(() => adminClient.CreateHookAsync(null), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => adminClient.CreateHook(null), Throws.InstanceOf<ArgumentNullException>());

            Assert.That(() => adminClient.CreateHookAsync(emailHook), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => adminClient.CreateHook(emailHook), Throws.InstanceOf<ArgumentNullException>());

            emailHook.Name = "";
            Assert.That(() => adminClient.CreateHookAsync(emailHook), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => adminClient.CreateHook(emailHook), Throws.InstanceOf<ArgumentException>());

            emailHook.Name = name;
            emailHook.EmailsToAlert.Clear();
            Assert.That(() => adminClient.CreateHookAsync(emailHook), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => adminClient.CreateHook(emailHook), Throws.InstanceOf<ArgumentException>());

            Assert.That(() => adminClient.CreateHookAsync(webHook), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => adminClient.CreateHook(webHook), Throws.InstanceOf<ArgumentNullException>());

            webHook.Name = "";
            Assert.That(() => adminClient.CreateHookAsync(webHook), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => adminClient.CreateHook(webHook), Throws.InstanceOf<ArgumentException>());

            webHook.Name = name;
            webHook.Endpoint = null;
            Assert.That(() => adminClient.CreateHookAsync(webHook), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => adminClient.CreateHook(webHook), Throws.InstanceOf<ArgumentNullException>());

            webHook.Endpoint = "";
            Assert.That(() => adminClient.CreateHookAsync(webHook), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => adminClient.CreateHook(webHook), Throws.InstanceOf<ArgumentException>());

            Assert.That(() => adminClient.CreateHookAsync(genericHook), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => adminClient.CreateHook(genericHook), Throws.InstanceOf<ArgumentException>());
        }

        [Test]
        public void CreateHookRespectsTheCancellationToken()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var hook = new EmailNotificationHook()
            {
                Name = "hookName",
                EmailsToAlert = { "fake@email.com" }
            };

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            Assert.That(() => adminClient.CreateHookAsync(hook, cancellationSource.Token), Throws.InstanceOf<OperationCanceledException>());
            Assert.That(() => adminClient.CreateHook(hook, cancellationSource.Token), Throws.InstanceOf<OperationCanceledException>());
        }

        [Test]
        public void UpdateHookValidatesArguments()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var hook = new EmailNotificationHook();

            Assert.That(() => adminClient.UpdateHookAsync(null, hook), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => adminClient.UpdateHookAsync("", hook), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => adminClient.UpdateHookAsync("hookId", hook), Throws.InstanceOf<ArgumentException>().With.InnerException.TypeOf(typeof(FormatException)));
            Assert.That(() => adminClient.UpdateHookAsync(FakeGuid, null), Throws.InstanceOf<ArgumentNullException>());

            Assert.That(() => adminClient.UpdateHook(null, hook), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => adminClient.UpdateHook("", hook), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => adminClient.UpdateHook("hookId", hook), Throws.InstanceOf<ArgumentException>().With.InnerException.TypeOf(typeof(FormatException)));
            Assert.That(() => adminClient.UpdateHook(FakeGuid, null), Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void UpdateHookRespectsTheCancellationToken()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var hook = new EmailNotificationHook();

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            Assert.That(() => adminClient.UpdateHookAsync(FakeGuid, hook, cancellationSource.Token), Throws.InstanceOf<OperationCanceledException>());
            Assert.That(() => adminClient.UpdateHook(FakeGuid, hook, cancellationSource.Token), Throws.InstanceOf<OperationCanceledException>());
        }

        [Test]
        public void GetHookValidatesArguments()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            Assert.That(() => adminClient.GetHookAsync(null), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => adminClient.GetHookAsync(""), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => adminClient.GetHookAsync("hookId"), Throws.InstanceOf<ArgumentException>().With.InnerException.TypeOf(typeof(FormatException)));

            Assert.That(() => adminClient.GetHook(null), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => adminClient.GetHook(""), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => adminClient.GetHook("hookId"), Throws.InstanceOf<ArgumentException>().With.InnerException.TypeOf(typeof(FormatException)));
        }

        [Test]
        public void GetHookRespectsTheCancellationToken()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            Assert.That(() => adminClient.GetHookAsync(FakeGuid, cancellationSource.Token), Throws.InstanceOf<OperationCanceledException>());
            Assert.That(() => adminClient.GetHook(FakeGuid, cancellationSource.Token), Throws.InstanceOf<OperationCanceledException>());
        }

        [Test]
        public void GetHooksRespectsTheCancellationToken()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            IAsyncEnumerator<NotificationHook> asyncEnumerator = adminClient.GetHooksAsync(cancellationToken: cancellationSource.Token).GetAsyncEnumerator();
            Assert.That(async () => await asyncEnumerator.MoveNextAsync(), Throws.InstanceOf<OperationCanceledException>());

            IEnumerator<NotificationHook> enumerator = adminClient.GetHooks(cancellationToken: cancellationSource.Token).GetEnumerator();
            Assert.That(() => enumerator.MoveNext(), Throws.InstanceOf<OperationCanceledException>());
        }

        [Test]
        public void DeleteHookValidatesArguments()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            Assert.That(() => adminClient.DeleteHookAsync(null), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => adminClient.DeleteHookAsync(""), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => adminClient.DeleteHookAsync("hookId"), Throws.InstanceOf<ArgumentException>().With.InnerException.TypeOf(typeof(FormatException)));

            Assert.That(() => adminClient.DeleteHook(null), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => adminClient.DeleteHook(""), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => adminClient.DeleteHook("hookId"), Throws.InstanceOf<ArgumentException>().With.InnerException.TypeOf(typeof(FormatException)));
        }

        [Test]
        public void DeleteHookRespectsTheCancellationToken()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            Assert.That(() => adminClient.DeleteHookAsync(FakeGuid, cancellationSource.Token), Throws.InstanceOf<OperationCanceledException>());
            Assert.That(() => adminClient.DeleteHook(FakeGuid, cancellationSource.Token), Throws.InstanceOf<OperationCanceledException>());
        }

        private MetricsAdvisorAdministrationClient GetMetricsAdvisorAdministrationClient()
        {
            var fakeEndpoint = new Uri("http://notreal.azure.com");
            var fakeCredential = new MetricsAdvisorKeyCredential("fakeSubscriptionKey", "fakeApiKey");

            return new MetricsAdvisorAdministrationClient(fakeEndpoint, fakeCredential);
        }
    }
}
