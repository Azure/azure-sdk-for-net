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
    public class DatasourceCredentialTests : ClientTestBase
    {
        public DatasourceCredentialTests(bool isAsync) : base(isAsync)
        {
        }

        private string FakeGuid => "00000000-0000-0000-0000-000000000000";

        [Test]
        public void CreateDatasourceCredentialValidatesArguments()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            Assert.That(() => adminClient.CreateDatasourceCredentialAsync(null), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => adminClient.CreateDatasourceCredential(null), Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void CreateDatasourceCredentialRespectsTheCancellationToken()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var credential = new ServicePrincipalDatasourceCredential("credentialName", "clientId", "clientSecret", "tenantId");

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            Assert.That(() => adminClient.CreateDatasourceCredentialAsync(credential, cancellationSource.Token), Throws.InstanceOf<OperationCanceledException>());
            Assert.That(() => adminClient.CreateDatasourceCredential(credential, cancellationSource.Token), Throws.InstanceOf<OperationCanceledException>());
        }

        [Test]
        public void UpdateDatasourceCredentialValidatesArguments()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            Assert.That(() => adminClient.UpdateDatasourceCredentialAsync(null), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => adminClient.UpdateDatasourceCredential(null), Throws.InstanceOf<ArgumentNullException>());

            var credentialWithNullId = new ServicePrincipalDatasourceCredential("name", "clientId", "clientSecret", "tenantId");

            Assert.That(() => adminClient.UpdateDatasourceCredentialAsync(credentialWithNullId), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => adminClient.UpdateDatasourceCredential(credentialWithNullId), Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void UpdateDatasourceCredentialRespectsTheCancellationToken()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var credential = new ServicePrincipalDatasourceCredential(default, FakeGuid, default, default, new ServicePrincipalParam("clientId", "clientSecret"));

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            Assert.That(() => adminClient.UpdateDatasourceCredentialAsync(credential, cancellationSource.Token), Throws.InstanceOf<OperationCanceledException>());
            Assert.That(() => adminClient.UpdateDatasourceCredential(credential, cancellationSource.Token), Throws.InstanceOf<OperationCanceledException>());
        }

        [Test]
        public void GetDatasourceCredentialValidatesArguments()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            Assert.That(() => adminClient.GetDatasourceCredentialAsync(null), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => adminClient.GetDatasourceCredentialAsync(""), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => adminClient.GetDatasourceCredentialAsync("credentialId"), Throws.InstanceOf<ArgumentException>().With.InnerException.TypeOf(typeof(FormatException)));

            Assert.That(() => adminClient.GetDatasourceCredential(null), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => adminClient.GetDatasourceCredential(""), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => adminClient.GetDatasourceCredential("credentialId"), Throws.InstanceOf<ArgumentException>().With.InnerException.TypeOf(typeof(FormatException)));
        }

        [Test]
        public void GetDatasourceCredentialRespectsTheCancellationToken()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            Assert.That(() => adminClient.GetDatasourceCredentialAsync(FakeGuid, cancellationSource.Token), Throws.InstanceOf<OperationCanceledException>());
            Assert.That(() => adminClient.GetDatasourceCredential(FakeGuid, cancellationSource.Token), Throws.InstanceOf<OperationCanceledException>());
        }

        [Test]
        public void GetDatasourceCredentialsRespectsTheCancellationToken()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            IAsyncEnumerator<DatasourceCredential> asyncEnumerator = adminClient.GetDatasourceCredentialsAsync(cancellationToken: cancellationSource.Token).GetAsyncEnumerator();
            Assert.That(async () => await asyncEnumerator.MoveNextAsync(), Throws.InstanceOf<OperationCanceledException>());

            IEnumerator<DatasourceCredential> enumerator = adminClient.GetDatasourceCredentials(cancellationToken: cancellationSource.Token).GetEnumerator();
            Assert.That(() => enumerator.MoveNext(), Throws.InstanceOf<OperationCanceledException>());
        }

        [Test]
        public void DeleteDatasourceCredentialValidatesArguments()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            Assert.That(() => adminClient.DeleteDatasourceCredentialAsync(null), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => adminClient.DeleteDatasourceCredentialAsync(""), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => adminClient.DeleteDatasourceCredentialAsync("credentialId"), Throws.InstanceOf<ArgumentException>().With.InnerException.TypeOf(typeof(FormatException)));

            Assert.That(() => adminClient.DeleteDatasourceCredential(null), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => adminClient.DeleteDatasourceCredential(""), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => adminClient.DeleteDatasourceCredential("credentialId"), Throws.InstanceOf<ArgumentException>().With.InnerException.TypeOf(typeof(FormatException)));
        }

        [Test]
        public void DeleteDatasourceCredentialRespectsTheCancellationToken()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            Assert.That(() => adminClient.DeleteDatasourceCredentialAsync(FakeGuid, cancellationSource.Token), Throws.InstanceOf<OperationCanceledException>());
            Assert.That(() => adminClient.DeleteDatasourceCredential(FakeGuid, cancellationSource.Token), Throws.InstanceOf<OperationCanceledException>());
        }

        private MetricsAdvisorAdministrationClient GetMetricsAdvisorAdministrationClient()
        {
            var fakeEndpoint = new Uri("http://notreal.azure.com");
            var fakeCredential = new MetricsAdvisorKeyCredential("fakeSubscriptionKey", "fakeApiKey");

            return new MetricsAdvisorAdministrationClient(fakeEndpoint, fakeCredential);
        }
    }
}
