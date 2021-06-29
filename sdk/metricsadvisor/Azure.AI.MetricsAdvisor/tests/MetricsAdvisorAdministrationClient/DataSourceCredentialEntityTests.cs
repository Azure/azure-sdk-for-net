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
    public class DataSourceCredentialEntityTests : ClientTestBase
    {
        public DataSourceCredentialEntityTests(bool isAsync) : base(isAsync)
        {
        }

        private string FakeGuid => "00000000-0000-0000-0000-000000000000";

        [Test]
        public void CreateDataSourceCredentialValidatesArguments()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            Assert.That(() => adminClient.CreateDataSourceCredentialAsync(null), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => adminClient.CreateDataSourceCredential(null), Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void CreateDataSourceCredentialRespectsTheCancellationToken()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var credential = new DataSourceServicePrincipal("credentialName", "clientId", "clientSecret", "tenantId");

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            Assert.That(() => adminClient.CreateDataSourceCredentialAsync(credential, cancellationSource.Token), Throws.InstanceOf<OperationCanceledException>());
            Assert.That(() => adminClient.CreateDataSourceCredential(credential, cancellationSource.Token), Throws.InstanceOf<OperationCanceledException>());
        }

        [Test]
        public void UpdateDataSourceCredentialValidatesArguments()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            Assert.That(() => adminClient.UpdateDataSourceCredentialAsync(null), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => adminClient.UpdateDataSourceCredential(null), Throws.InstanceOf<ArgumentNullException>());

            var credentialWithNullId = new DataSourceServicePrincipal("name", "clientId", "clientSecret", "tenantId");

            Assert.That(() => adminClient.UpdateDataSourceCredentialAsync(credentialWithNullId), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => adminClient.UpdateDataSourceCredential(credentialWithNullId), Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void UpdateDataSourceCredentialRespectsTheCancellationToken()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            var credential = new DataSourceServicePrincipal(default, FakeGuid, default, default, new ServicePrincipalParam("clientId", "clientSecret"));

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            Assert.That(() => adminClient.UpdateDataSourceCredentialAsync(credential, cancellationSource.Token), Throws.InstanceOf<OperationCanceledException>());
            Assert.That(() => adminClient.UpdateDataSourceCredential(credential, cancellationSource.Token), Throws.InstanceOf<OperationCanceledException>());
        }

        [Test]
        public void GetDataSourceCredentialValidatesArguments()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            Assert.That(() => adminClient.GetDataSourceCredentialAsync(null), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => adminClient.GetDataSourceCredentialAsync(""), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => adminClient.GetDataSourceCredentialAsync("credentialId"), Throws.InstanceOf<ArgumentException>().With.InnerException.TypeOf(typeof(FormatException)));

            Assert.That(() => adminClient.GetDataSourceCredential(null), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => adminClient.GetDataSourceCredential(""), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => adminClient.GetDataSourceCredential("credentialId"), Throws.InstanceOf<ArgumentException>().With.InnerException.TypeOf(typeof(FormatException)));
        }

        [Test]
        public void GetDataSourceCredentialRespectsTheCancellationToken()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            Assert.That(() => adminClient.GetDataSourceCredentialAsync(FakeGuid, cancellationSource.Token), Throws.InstanceOf<OperationCanceledException>());
            Assert.That(() => adminClient.GetDataSourceCredential(FakeGuid, cancellationSource.Token), Throws.InstanceOf<OperationCanceledException>());
        }

        [Test]
        public void GetDataSourceCredentialsRespectsTheCancellationToken()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            IAsyncEnumerator<DataSourceCredentialEntity> asyncEnumerator = adminClient.GetDataSourceCredentialsAsync(cancellationToken: cancellationSource.Token).GetAsyncEnumerator();
            Assert.That(async () => await asyncEnumerator.MoveNextAsync(), Throws.InstanceOf<OperationCanceledException>());

            IEnumerator<DataSourceCredentialEntity> enumerator = adminClient.GetDataSourceCredentials(cancellationToken: cancellationSource.Token).GetEnumerator();
            Assert.That(() => enumerator.MoveNext(), Throws.InstanceOf<OperationCanceledException>());
        }

        [Test]
        public void DeleteDataSourceCredentialValidatesArguments()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            Assert.That(() => adminClient.DeleteDataSourceCredentialAsync(null), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => adminClient.DeleteDataSourceCredentialAsync(""), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => adminClient.DeleteDataSourceCredentialAsync("credentialId"), Throws.InstanceOf<ArgumentException>().With.InnerException.TypeOf(typeof(FormatException)));

            Assert.That(() => adminClient.DeleteDataSourceCredential(null), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => adminClient.DeleteDataSourceCredential(""), Throws.InstanceOf<ArgumentException>());
            Assert.That(() => adminClient.DeleteDataSourceCredential("credentialId"), Throws.InstanceOf<ArgumentException>().With.InnerException.TypeOf(typeof(FormatException)));
        }

        [Test]
        public void DeleteDataSourceCredentialRespectsTheCancellationToken()
        {
            MetricsAdvisorAdministrationClient adminClient = GetMetricsAdvisorAdministrationClient();

            using var cancellationSource = new CancellationTokenSource();
            cancellationSource.Cancel();

            Assert.That(() => adminClient.DeleteDataSourceCredentialAsync(FakeGuid, cancellationSource.Token), Throws.InstanceOf<OperationCanceledException>());
            Assert.That(() => adminClient.DeleteDataSourceCredential(FakeGuid, cancellationSource.Token), Throws.InstanceOf<OperationCanceledException>());
        }

        private MetricsAdvisorAdministrationClient GetMetricsAdvisorAdministrationClient()
        {
            var fakeEndpoint = new Uri("http://notreal.azure.com");
            var fakeCredential = new MetricsAdvisorKeyCredential("fakeSubscriptionKey", "fakeApiKey");

            return new MetricsAdvisorAdministrationClient(fakeEndpoint, fakeCredential);
        }
    }
}
