// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using Azure.AI.MetricsAdvisor.Administration;
using Azure.AI.MetricsAdvisor.Models;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.MetricsAdvisor.Tests
{
    public class CredentialEntityTests : ClientTestBase
    {
        public CredentialEntityTests(bool isAsync) : base(isAsync)
        {
        }

        private string FakeGuid => "00000000-0000-0000-0000-000000000000";

        [Test]
        public void CreateCredentialEntityValidatesArguments()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            Assert.That(() => adminClient.CreateCredentialEntityAsync(null), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => adminClient.CreateCredentialEntity(null), Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void CreateCredentialEntityRespectsTheCancellationToken()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var credential = new ServicePrincipalCredentialEntity("credentialName", "clientId", "clientSecret", "tenantId");

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            Assert.That(() => adminClient.CreateCredentialEntityAsync(credential, cancellationSource.Token), Throws.InstanceOf<OperationCanceledException>());
            Assert.That(() => adminClient.CreateCredentialEntity(credential, cancellationSource.Token), Throws.InstanceOf<OperationCanceledException>());
        }

        [Test]
        public void GetCredentialEntityValidatesArguments()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            Assert.That(() => adminClient.GetCredentialEntityAsync(null), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => adminClient.GetCredentialEntityAsync(""), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => adminClient.GetCredentialEntityAsync("credentialId"), Throws.InstanceOf<ArgumentException>().With.InnerException.TypeOf(typeof(FormatException)));

            Assert.That(() => adminClient.GetCredentialEntity(null), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => adminClient.GetCredentialEntity(""), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => adminClient.GetCredentialEntity("credentialId"), Throws.InstanceOf<ArgumentException>().With.InnerException.TypeOf(typeof(FormatException)));
        }

        [Test]
        public void GetCredentialEntityRespectsTheCancellationToken()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            Assert.That(() => adminClient.GetCredentialEntityAsync(FakeGuid, cancellationSource.Token), Throws.InstanceOf<OperationCanceledException>());
            Assert.That(() => adminClient.GetCredentialEntity(FakeGuid, cancellationSource.Token), Throws.InstanceOf<OperationCanceledException>());
        }

        [Test]
        public void DeleteCredentialEntityValidatesArguments()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            Assert.That(() => adminClient.DeleteCredentialEntityAsync(null), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => adminClient.DeleteCredentialEntityAsync(""), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => adminClient.DeleteCredentialEntityAsync("credentialId"), Throws.InstanceOf<ArgumentException>().With.InnerException.TypeOf(typeof(FormatException)));

            Assert.That(() => adminClient.DeleteCredentialEntity(null), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => adminClient.DeleteCredentialEntity(""), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => adminClient.DeleteCredentialEntity("credentialId"), Throws.InstanceOf<ArgumentException>().With.InnerException.TypeOf(typeof(FormatException)));
        }

        [Test]
        public void DeleteCredentialEntityRespectsTheCancellationToken()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            Assert.That(() => adminClient.DeleteCredentialEntityAsync(FakeGuid, cancellationSource.Token), Throws.InstanceOf<OperationCanceledException>());
            Assert.That(() => adminClient.DeleteCredentialEntity(FakeGuid, cancellationSource.Token), Throws.InstanceOf<OperationCanceledException>());
        }

        private MetricsAdvisorAdministrationClient GetMetricsAdvisorAdministrationClient()
        {
            var fakeEndpoint = new Uri("http://notreal.azure.com");
            var fakeCredential = new MetricsAdvisorKeyCredential("fakeSubscriptionKey", "fakeApiKey");

            return new MetricsAdvisorAdministrationClient(fakeEndpoint, fakeCredential);
        }
    }
}
