// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.Testing;
using Azure.Security.KeyVault.Secrets;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Test
{
    public class SecretListTests : KeyVaultTestBase
    {
        private const int VersionCount = 50;

        private readonly Dictionary<string, Secret> _versions = new Dictionary<string, Secret>(VersionCount);
        private TestRecording _setupRecording;
        private SecretClient _client;
        private string _secretName;

        public SecretListTests(bool isAsync) : base(isAsync)
        {
        }

        public override void StartTestRecording()
        {
            base.StartTestRecording();

            _client = GetClient();
        }

        [OneTimeSetUp]
        public async Task Setup()
        {
            _setupRecording = StartRecording("Setup");
            _secretName = _setupRecording.GenerateId();

            var setupClient = GetClient(_setupRecording);

            for (int i = 0; i < VersionCount; i++)
            {
                Secret secret = await setupClient.SetAsync(_secretName, _setupRecording.GenerateId());

                typeof(Secret).GetProperty(nameof(secret.Value)).SetValue(secret, null);

                _versions[secret.Id.ToString()] = secret;
            }
        }

        [OneTimeTearDown]
        public async Task TearDown()
        {
            await _client.DeleteAsync(_secretName);
            _setupRecording.Dispose();
        }

        [Test]
        public async Task GetAllVersionsAsyncForEach()
        {
            int actVersionCount = 0;

            await foreach (var secret in _client.GetAllVersionsAsync(_secretName))
            {
                Assert.True(_versions.TryGetValue(secret.Id.ToString(), out Secret exp));

                AssertSecretsEqual(exp, secret);

                actVersionCount++;
            }

            Assert.AreEqual(VersionCount, actVersionCount);
        }

        [Test]
        public async Task ListVersionEnumeratorMoveNext()
        {
            int actVersionCount = 0;

            var enumerator = _client.GetAllVersionsAsync(_secretName);

            while (await enumerator.MoveNextAsync())
            {
                Assert.True(_versions.TryGetValue(enumerator.Current.Id.ToString(), out Secret exp));

                AssertSecretsEqual(exp, enumerator.Current);

                actVersionCount++;
            }

            Assert.AreEqual(VersionCount, actVersionCount);
        }


        [Test]
        public async Task GetAllVersionsByPageAsyncForEach()
        {
            int actVersionCount = 0;

            await foreach (Page<SecretBase> currentPage in _client.GetAllVersionsAsync(_secretName).ByPage())
            {
                for (int i = 0; i < currentPage.Items.Length; i++)
                {
                    Assert.True(_versions.TryGetValue(currentPage.Items[i].Id.ToString(), out Secret exp));

                    AssertSecretsEqual(exp, currentPage.Items[i]);

                    actVersionCount++;
                }
            }

            Assert.AreEqual(VersionCount, actVersionCount);
        }

        [Test]
        public async Task ListVersionByPageEnumeratorMoveNext()
        {
            int actVersionCount = 0;

            var enumerator = _client.GetAllVersionsAsync(_secretName).ByPage();

            while (await enumerator.MoveNextAsync())
            {
                Page<SecretBase> currentPage = enumerator.Current;

                for (int i = 0; i < currentPage.Items.Length; i++)
                {
                    Assert.True(_versions.TryGetValue(currentPage.Items[i].Id.ToString(), out Secret exp));

                    AssertSecretsEqual(exp, currentPage.Items[i]);

                    actVersionCount++;
                }
            }

            Assert.AreEqual(VersionCount, actVersionCount);
        }
    }
}