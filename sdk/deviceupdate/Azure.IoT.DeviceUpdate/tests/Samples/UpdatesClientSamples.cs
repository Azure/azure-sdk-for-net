// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.IoT.DeviceUpdate.Models;
using NUnit.Framework;

namespace Azure.IoT.DeviceUpdate.Tests
{
    /// <summary>
    /// Updates management live samples.
    /// </summary>
    /// <seealso cref="SamplesBase{ServiceClientTestEnvironment}"/>
    public class UpdatesClientSamples : SamplesBase<ServiceClientTestEnvironment>
    {
        private const string FileName = "setup.exe";

        private UpdatesClient CreateClient()
        {
            return new UpdatesClient(
                TestEnvironment.AccountEndpoint,
                TestEnvironment.InstanceId,
                TestEnvironment.Credential);
        }

        [Test]
        public async Task ImportUpdate()
        {
            var client = CreateClient();
            var update = new ImportUpdateInput(
                new ImportManifestMetadata(
                    "https://adutest.blob.core.windows.net/test/Ak1xigPLmur511bYfCvzeC?sv=2019-02-02&sr=b&sig=L9RZxCUwduStz0m1cj4YnXt6OJCvWSe9SPseum3cclE%3D&se=2020-05-08T20%3A52%3A51Z&sp=r",
                    453,
                    new Dictionary<string, string>
                    {
                        { "SHA256", "Ak1xigPLmur511bYfCvzeCwF6r/QxiBKeEDHOvHPzr4=" }
                    }),
                new[] { new FileImportMetadata(
                    FileName,
                    "https://adutest.blob.core.windows.net/test/zVknnlx1tyYSMHY28LZVzk?sv=2019-02-02&sr=b&sig=QtS6bAOcHon18wLwIt9uvHIM%2B4M27EoVPNP4RWpMjyw%3D&se=2020-05-08T20%3A52%3A51Z&sp=r"), });

            Response<string> jobIdResponse = await client.ImportUpdateAsync(update);

            Assert.IsNotNull(jobIdResponse);
            Assert.IsNotNull(jobIdResponse.GetRawResponse());
            Assert.AreEqual(202, jobIdResponse.GetRawResponse().Status);
            Assert.IsNotNull(jobIdResponse.Value);
        }

        [Test]
        public async Task GetUpdate()
        {
            var client = CreateClient();
            var expected = TestEnvironment;
            Response<Update> response = await client.GetUpdateAsync(expected.Provider, expected.Model, expected.Version);
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.GetRawResponse());
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.IsNotNull(response.Value);
            Assert.AreEqual(expected.Provider, response.Value.UpdateId.Provider);
            Assert.AreEqual(expected.Model, response.Value.UpdateId.Name);
            Assert.AreEqual(expected.Version, response.Value.UpdateId.Version);
        }

        [Test]
        public async Task GetUpdate_NotFound()
        {
            var client = CreateClient();
            try
            {
                Response<Update> _ = await client.GetUpdateAsync("foo", "bar", "0.0.0.1");
            }
            catch (RequestFailedException e)
            {
                Assert.AreEqual(404, e.Status);
            }
        }

        [Test]
        public async Task GetProviders()
        {
            var client = CreateClient();
            AsyncPageable<string> response = client.GetProvidersAsync();

            Assert.IsNotNull(response);
            int counter = 0;
            await foreach (var item in response)
            {
                Assert.IsNotNull(item);
                counter++;
            }

            Assert.IsTrue(counter > 0);
        }

        [Test]
        public async Task GetNames()
        {
            var client = CreateClient();
            var expected = TestEnvironment;
            var response = client.GetNamesAsync(expected.Provider);

            Assert.IsNotNull(response);
            int counter = 0;
            await foreach (var item in response)
            {
                Assert.IsNotNull(item);
                counter++;
            }

            Assert.IsTrue(counter > 0);
        }

        [Test]
        public async Task GetNames_NotFound()
        {
            var client = CreateClient();
            var response = client.GetNamesAsync("foo");

            Assert.IsNotNull(response);
            try
            {
                await foreach (var _ in response)
                { }
                Assert.Fail("Should have thrown 404");
            }
            catch (RequestFailedException e)
            {
                Assert.AreEqual(404, e.Status);
            }
        }

        [Test]
        public async Task GetVersions()
        {
            var client = CreateClient();
            var expected = TestEnvironment;
            var response = client.GetVersionsAsync(expected.Provider, expected.Model);

            Assert.IsNotNull(response);
            int counter = 0;
            await foreach (var item in response)
            {
                Assert.IsNotNull(item);
                counter++;
            }

            Assert.IsTrue(counter > 0);
        }

        [Test]
        public async Task GetVersions_NotFound()
        {
            var client = CreateClient();
            var response = client.GetVersionsAsync("foo", "bar");

            Assert.IsNotNull(response);
            try
            {
                await foreach (var _ in response)
                { }
                Assert.Fail("Should have thrown 404");
            }
            catch (RequestFailedException e)
            {
                Assert.AreEqual(404, e.Status);
            }
        }

        [Test]
        public async Task GetFiles()
        {
            var client = CreateClient();
            var expected = TestEnvironment;
            var response = client.GetFilesAsync(expected.Provider, expected.Model, expected.Version);

            Assert.IsNotNull(response);
            int counter = 0;
            await foreach (var item in response)
            {
                Assert.IsNotNull(item);
                counter++;
            }

            Assert.IsTrue(counter > 0);
        }

        [Test]
        public async Task GetFiles_NotFound()
        {
            var client = CreateClient();
            var response = client.GetFilesAsync("foo", "bar", "0.0.0.1");

            Assert.IsNotNull(response);
            try
            {
                await foreach (var _ in response)
                { }
                Assert.Fail("Should have thrown 404");
            }
            catch (RequestFailedException e)
            {
                Assert.AreEqual(404, e.Status);
            }
        }

        [Test]
        public async Task GetFile()
        {
            var client = CreateClient();
            var expected = TestEnvironment;
            Response<File> response = await client.GetFileAsync(expected.Provider, expected.Model, expected.Version, "00000");

            Assert.IsNotNull(response);
            Assert.IsNotNull(response.GetRawResponse());
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.IsNotNull(response.Value);
            Assert.AreEqual("00000", response.Value.FileId);
        }

        [Test]
        public async Task GetFile_NotFound()
        {
            var client = CreateClient();
            var expected = TestEnvironment;
            try
            {
                Response<File> _ = await client.GetFileAsync(expected.Provider, expected.Model, expected.Version, "foobar");
            }
            catch (RequestFailedException e)
            {
                Assert.AreEqual(404, e.Status);
            }
        }

        [Test]
        public async Task GetOperation()
        {
            var client = CreateClient();
            var expected = TestEnvironment;
            Response<Models.Operation> response = await client.GetOperationAsync(expected.OperationId);

            Assert.IsNotNull(response);
            Assert.IsNotNull(response.GetRawResponse());
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.IsNotNull(response.Value);
            Assert.AreEqual(OperationStatus.Succeeded, response.Value.Status);
        }

        [Test]
        public async Task GetOperation_NotFound()
        {
            var client = CreateClient();
            try
            {
                Response<Models.Operation> _ = await client.GetOperationAsync("fake");
            }
            catch (RequestFailedException e)
            {
                Assert.AreEqual(404, e.Status);
            }
        }

        [Test]
        public async Task GetOperations()
        {
            var client = CreateClient();
            var response = client.GetOperationsAsync(top: 1);

            Assert.IsNotNull(response);
            int counter = 0;
            await foreach (var item in response)
            {
                Assert.IsNotNull(item);
                counter++;
            }

            Assert.AreEqual(1, counter);
        }
    }
}
