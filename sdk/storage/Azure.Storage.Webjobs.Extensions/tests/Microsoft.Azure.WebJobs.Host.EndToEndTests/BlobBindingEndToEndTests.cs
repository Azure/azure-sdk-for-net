﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using Newtonsoft.Json;
using Xunit;

namespace Microsoft.Azure.WebJobs.Host.EndToEndTests
{
    public class BlobBindingEndToEndTests : IClassFixture<BlobBindingEndToEndTests.TestFixture>
    {
        private const string TestArtifactPrefix = "e2etestbindings";
        private const string ContainerName = TestArtifactPrefix + "-%rnd%";
        private const string OutputContainerName = TestArtifactPrefix + "-out%rnd%";
        private const string PageBlobContainerName = TestArtifactPrefix + "pageblobs-%rnd%";
        private const string AppendBlobContainerName = TestArtifactPrefix + "appendblobs-%rnd%";
        private const string HierarchicalBlobContainerName = TestArtifactPrefix + "subblobs-%rnd%";
        private const string TestData = "TestData";
        private readonly TestFixture _fixture;
        private static int _numBlobsRead;

        public BlobBindingEndToEndTests(TestFixture fixture)
        {
            _fixture = fixture;
            _numBlobsRead = 0;
        }

        [Fact]
        public async Task BindToCloudBlobContainer()
        {
            await _fixture.JobHost.CallAsync(typeof(BlobBindingEndToEndTests).GetMethod("CloudBlobContainerBinding"));

            Assert.Equal(6, _numBlobsRead);
        }

        [Fact]
        public async Task BindToCloudBlobDirectory()
        {
            await _fixture.JobHost.CallAsync(typeof(BlobBindingEndToEndTests).GetMethod("CloudBlobDirectoryBinding"));

            Assert.Equal(3, _numBlobsRead);
        }

        [Fact]
        public async Task BindToCloudBlobContainer_WithModelBinding()
        {
            TestPoco poco = new TestPoco
            {
                A = _fixture.NameResolver.ResolveWholeString(ContainerName)
            };
            string json = JsonConvert.SerializeObject(poco);
            var arguments = new { poco = json };

            await _fixture.JobHost.CallAsync(typeof(BlobBindingEndToEndTests).GetMethod("CloudBlobContainerBinding_WithModelBinding"), arguments);

            Assert.Equal(6, _numBlobsRead);
        }

        [Fact]
        public async Task BindToCloudBlockBlob_WithUrlBinding()
        {
            // get url for the test blob
            CloudBlockBlob blob = _fixture.BlobContainer.GetBlockBlobReference("blob1");
            TestPoco poco = new TestPoco
            {
                A = blob.Uri.ToString()
            };
            string json = JsonConvert.SerializeObject(poco);
            var arguments = new { poco = json };
            await _fixture.JobHost.CallAsync(typeof(BlobBindingEndToEndTests).GetMethod("CloudBlockBlobBinding_WithUrlBinding"), arguments);

            Assert.Equal(1, _numBlobsRead);
        }

        [Fact]
        public async Task BindToCloudBlob_WithModelBinding_Fail()
        {
            TestPoco poco = new TestPoco
            {
                A = _fixture.NameResolver.ResolveWholeString(ContainerName)
            };
            string json = JsonConvert.SerializeObject(poco);
            var arguments = new { poco = json };
            var ex = await Assert.ThrowsAsync<FunctionInvocationException>(() =>
           _fixture.JobHost.CallAsync(typeof(BlobBindingEndToEndTests).GetMethod("CloudBlockBlobBinding_WithUrlBinding"), arguments));
            // CloudBlockBlobBinding_WithUrlBinding is suppose to bind to a blob
            Assert.Equal($"Invalid blob path specified : '{poco.A}'. Blob identifiers must be in the format 'container/blob'.", ex.InnerException.InnerException.Message);
        }

        [Fact]
        public async Task BindToCloudBlobContainer_WithUrlBinding_Fail()
        {
            // get url for the test blob
            CloudBlockBlob blob = _fixture.BlobContainer.GetBlockBlobReference("blob1");
            TestPoco poco = new TestPoco
            {
                A = blob.Uri.ToString()
            };
            string json = JsonConvert.SerializeObject(poco);
            var arguments = new { poco = json };
            var ex = await Assert.ThrowsAsync<FunctionInvocationException>(() =>
            _fixture.JobHost.CallAsync(typeof(BlobBindingEndToEndTests).GetMethod("CloudBlobContainerBinding_WithModelBinding"), arguments));
            // CloudBlobContainerBinding_WithModelBinding is suppose to bind to a container
            Assert.IsType<FormatException>(ex.InnerException.InnerException);
        }

        [Fact]
        public async Task BindToIEnumerableCloudBlockBlob_WithPrefixFilter()
        {
            await _fixture.JobHost.CallAsync(typeof(BlobBindingEndToEndTests).GetMethod("IEnumerableCloudBlockBlobBinding_WithPrefixFilter"));

            Assert.Equal(3, _numBlobsRead);
        }

        [Fact]
        public async Task BindToIEnumerableCloudBlockBlob_WithPrefixFilter_NoMatchingBlobs()
        {
            await _fixture.JobHost.CallAsync(typeof(BlobBindingEndToEndTests).GetMethod("IEnumerableCloudBlockBlobBinding_WithPrefixFilter_NoMatchingBlobs"));

            Assert.Equal(0, _numBlobsRead);
        }

        [Fact]
        public async Task BindToIEnumerableCloudBlockBlob_WithPrefixFilter_HierarchicalBlobs()
        {
            await _fixture.JobHost.CallAsync(typeof(BlobBindingEndToEndTests).GetMethod("IEnumerableCloudBlockBlobBinding_WithPrefixFilter_HierarchicalBlobs"));

            Assert.Equal(2, _numBlobsRead);
        }

        [Fact]
        public async Task BindToIEnumerableCloudBlockBlob_WithPrefixFilter_HierarchicalBlobs_UsesFlatBlobListing()
        {
            await _fixture.JobHost.CallAsync(typeof(BlobBindingEndToEndTests).GetMethod("IEnumerableCloudBlockBlobBinding_WithPrefixFilter_HierarchicalBlobs_UsesFlatBlobListing"));

            Assert.Equal(3, _numBlobsRead);
        }

        [Fact]
        public async Task BindToIEnumerableCloudBlockBlob_WithModelBinding()
        {
            TestPoco poco = new TestPoco
            {
                A = _fixture.NameResolver.ResolveWholeString(ContainerName),
                B = "bl"
            };
            string json = JsonConvert.SerializeObject(poco);
            var arguments = new { poco = json };

            await _fixture.JobHost.CallAsync(typeof(BlobBindingEndToEndTests).GetMethod("IEnumerableCloudBlockBlobBinding_WithModelBinding"), arguments);

            Assert.Equal(3, _numBlobsRead);
        }

        [Fact]
        public async Task BindToIEnumerableCloudPageBlob()
        {
            await _fixture.JobHost.CallAsync(typeof(BlobBindingEndToEndTests).GetMethod("IEnumerableCloudPageBlobBinding"));

            Assert.Equal(2, _numBlobsRead);
        }

        [Fact]
        public async Task BindToIEnumerableCloudAppendBlob()
        {
            await _fixture.JobHost.CallAsync(typeof(BlobBindingEndToEndTests).GetMethod("IEnumerableCloudAppendBlobBinding"));

            Assert.Equal(3, _numBlobsRead);
        }

        [Fact]
        public async Task BindToIEnumerableString()
        {
            await _fixture.JobHost.CallAsync(typeof(BlobBindingEndToEndTests).GetMethod("IEnumerableStringBinding"));

            Assert.Equal(6, _numBlobsRead);
        }

        [Fact]
        public async Task BindToIEnumerableStream()
        {
            await _fixture.JobHost.CallAsync(typeof(BlobBindingEndToEndTests).GetMethod("IEnumerableStreamBinding"));

            Assert.Equal(6, _numBlobsRead);
        }

        [Fact]
        public async Task BindToIEnumerableTextReader()
        {
            await _fixture.JobHost.CallAsync(typeof(BlobBindingEndToEndTests).GetMethod("IEnumerableTextReaderBinding"));

            Assert.Equal(6, _numBlobsRead);
        }

        [Fact]
        public async Task BindToIEnumerableICloudBlob()
        {
            await _fixture.JobHost.CallAsync(typeof(BlobBindingEndToEndTests).GetMethod("IEnumerableICloudBlobBinding"));

            Assert.Equal(6, _numBlobsRead);
        }

        [Fact]
        public async Task BindToByteArray()
        {
            await _fixture.JobHost.CallAsync(typeof(BlobBindingEndToEndTests).GetMethod("ByteArrayBinding"));

            Assert.Equal(1, _numBlobsRead);
        }

        [Theory]
        [InlineData("StringBinding_Block")]
        [InlineData("StringBinding_Page")]
        [InlineData("StringBinding_Append")]
        public async Task BindToString(string functionName)
        {
            await _fixture.JobHost.CallAsync(typeof(BlobBindingEndToEndTests).GetMethod(functionName));

            Assert.Equal(1, _numBlobsRead);
        }

        [Theory]
        [InlineData("StreamBindingReadable_Block")]
        [InlineData("StreamBindingReadable_Page")]
        [InlineData("StreamBindingReadable_Append")]
        public async Task BindToStream(string functionName)
        {
            await _fixture.JobHost.CallAsync(typeof(BlobBindingEndToEndTests).GetMethod(functionName));

            Assert.Equal(1, _numBlobsRead);
        }

        [Fact]
        public async Task BindToOutString()
        {
            CloudBlockBlob blob = _fixture.BlobContainer.GetBlockBlobReference("overwrite");
            Assert.Equal(TestData, await blob.DownloadTextAsync());
            await _fixture.JobHost.CallAsync(typeof(BlobBindingEndToEndTests).GetMethod("OutStringBinding_Block"));
            string text = null;
            using (var reader = new StreamReader(await blob.OpenReadAsync()))
            {
                text = reader.ReadToEnd();
            }
            Assert.Equal("overwritten", text);
            await blob.UploadTextAsync(TestData);
        }

        [Theory]
        [InlineData("OutStringBinding_Page")]
        [InlineData("OutStringBinding_Append")]
        public async Task BindToOutString_Fails(string functionName)
        {
            var ex = await Assert.ThrowsAsync<FunctionInvocationException>(() =>
            _fixture.JobHost.CallAsync(typeof(BlobBindingEndToEndTests).GetMethod(functionName)));

            var innerEx = ex.InnerException.InnerException;
            Assert.Equal("Cannot bind to page or append blobs using 'out string', 'TextWriter', or writable 'Stream' parameters.", innerEx.Message);
        }

        [Fact]
        public async Task BindToTextWriter()
        {
            CloudBlockBlob blob = _fixture.BlobContainer.GetBlockBlobReference("overwrite");
            Assert.Equal(TestData, await blob.DownloadTextAsync());
            await _fixture.JobHost.CallAsync(typeof(BlobBindingEndToEndTests).GetMethod("OutStringBinding_Block"));

            string text = null;
            using (var reader = new StreamReader(await blob.OpenReadAsync()))
            {
                text = reader.ReadToEnd();
            }
            Assert.Equal("overwritten", text);
            await blob.UploadTextAsync(TestData);
        }

        [Theory]
        [InlineData("TextWriterBinding_Page")]
        [InlineData("TextWriterBinding_Append")]
        public async Task BindToTextWriter_Fails(string functionName)
        {
            var ex = await Assert.ThrowsAsync<FunctionInvocationException>(() =>
            _fixture.JobHost.CallAsync(typeof(BlobBindingEndToEndTests).GetMethod(functionName)));

            var innerEx = ex.InnerException.InnerException;
            Assert.Equal("Cannot bind to page or append blobs using 'out string', 'TextWriter', or writable 'Stream' parameters.", innerEx.Message);
        }

        [Fact]
        public async Task BindToByteArray_Output()
        {
            // if the function sets the output binding to null, no blob
            // should be written
            var arguments = new { input = "null" };
            var method = typeof(BlobBindingEndToEndTests).GetMethod("ByteArrayOutputBinding");
            await _fixture.JobHost.CallAsync(method, arguments);

            CloudBlockBlob blob = _fixture.OutputBlobContainer.GetBlockBlobReference("blob1");
            Assert.False(await blob.ExistsAsync());

            // if the function sets a value, the blob should be written
            arguments = new { input = TestData };
            await _fixture.JobHost.CallAsync(method, arguments);

            Assert.True(await blob.ExistsAsync());
            string result = await blob.DownloadTextAsync();
            Assert.Equal(TestData, result);
        }

        [Fact]
        public async Task BindToByteArray_Trigger()
        {
            var arguments = new { blob = string.Format("{0}/{1}", _fixture.NameResolver.ResolveWholeString(ContainerName), "blob1") };

            await _fixture.JobHost.CallAsync(typeof(BlobBindingEndToEndTests).GetMethod("ByteArrayTriggerBinding"), arguments);

            Assert.Equal(1, _numBlobsRead);
        }

        [Fact]
        public async Task BlobTriggerSingletonListener_LockIsHeld()
        {
            await _fixture.VerifyLockState("WebJobs.Internal.Blobs.Listener", LeaseState.Leased, LeaseStatus.Locked);
        }

        // This function just exists to force initialization of the
        // blob listener pipeline
#pragma warning disable xUnit1013 // Public method should be marked as test
        public static void TestBlobTrigger([BlobTrigger("test/test")] string blob)
        {
        }

        [NoAutomaticTrigger]
        public static void CloudBlobContainerBinding(
            [Blob(ContainerName)] CloudBlobContainer container)
        {
            var blobs = container.ListBlobsSegmentedAsync(null).Result;
            foreach (CloudBlockBlob blob in blobs.Results)
            {
                string content = blob.DownloadTextAsync().Result;
                Assert.Equal(TestData, content);
            }
            _numBlobsRead = blobs.Results.Count();
        }

        [NoAutomaticTrigger]
        public static async Task CloudBlobDirectoryBinding(
            [Blob(HierarchicalBlobContainerName + "/sub")] CloudBlobDirectory directory)
        {
            var directoryItems = await directory.ListBlobsSegmentedAsync(null);

            var blobs = directoryItems.Results.OfType<CloudBlockBlob>();
            foreach (CloudBlockBlob blob in blobs)
            {
                string content = blob.DownloadTextAsync().Result;
                Assert.Equal(TestData, content);
            }
            _numBlobsRead += blobs.Count();

            CloudBlobDirectory subDirectory = directoryItems.Results.OfType<CloudBlobDirectory>().Single();
            CloudBlockBlob subBlob = (await subDirectory.ListBlobsSegmentedAsync(null)).Results.Cast<CloudBlockBlob>().Single();
            Assert.Equal(TestData, await subBlob.DownloadTextAsync());
            _numBlobsRead += 1;
        }

        [NoAutomaticTrigger]
        public static void CloudBlobContainerBinding_WithModelBinding(
            [QueueTrigger("testqueue")] TestPoco poco,
            [Blob("{A}")] CloudBlobContainer container)
        {
            CloudBlobContainerBinding(container);
        }

        [NoAutomaticTrigger]
        public static void CloudBlockBlobBinding_WithUrlBinding(
            [QueueTrigger("testqueue")] TestPoco poco,
            [Blob("{A}")] string blob)
        {
            Assert.Equal(TestData, blob);
            _numBlobsRead = 1;
        }

        [NoAutomaticTrigger]
        public static async Task IEnumerableCloudBlockBlobBinding_WithPrefixFilter(
            [Blob(ContainerName + "/blo")] IEnumerable<CloudBlockBlob> blobs)
        {
            foreach (var blob in blobs)
            {
                string content = await blob.DownloadTextAsync();
                Assert.Equal(TestData, content);
            }
            _numBlobsRead = blobs.Count();
        }

        [NoAutomaticTrigger]
        public static void IEnumerableCloudBlockBlobBinding_WithPrefixFilter_NoMatchingBlobs(
            [Blob(ContainerName + "/dne")] IEnumerable<CloudBlockBlob> blobs)
        {
            _numBlobsRead = blobs.Count();
        }

        [NoAutomaticTrigger]
        public static async Task IEnumerableCloudBlockBlobBinding_WithPrefixFilter_HierarchicalBlobs(
            [Blob(HierarchicalBlobContainerName + "/sub/bl")] IEnumerable<CloudBlockBlob> blobs)
        {
            foreach (var blob in blobs)
            {
                string content = await blob.DownloadTextAsync();
                Assert.Equal(TestData, content);
            }
            _numBlobsRead = blobs.Count();
        }

        // Ensure that a flat blob listing is used, meaning if a route prefix covers
        // sub directries, blobs within those sub directories are returned. Users can bind
        // to CloudBlobDirectory if they want to operate on directories.
        [NoAutomaticTrigger]
        public static async Task IEnumerableCloudBlockBlobBinding_WithPrefixFilter_HierarchicalBlobs_UsesFlatBlobListing(
            [Blob(HierarchicalBlobContainerName + "/sub")] IEnumerable<CloudBlockBlob> blobs)
        {
            foreach (var blob in blobs)
            {
                string content = await blob.DownloadTextAsync();
                Assert.Equal(TestData, content);
            }
            _numBlobsRead = blobs.Count();
        }

        [NoAutomaticTrigger]
        public static async Task IEnumerableCloudBlockBlobBinding_WithModelBinding(
            [QueueTrigger("testqueue")] TestPoco poco,
            [Blob("{A}/{B}ob")] IEnumerable<CloudBlockBlob> blobs)
        {
            foreach (var blob in blobs)
            {
                string content = await blob.DownloadTextAsync();
                Assert.Equal(TestData, content);
            }
            _numBlobsRead = blobs.Count();
        }

        [NoAutomaticTrigger]
        public static async Task IEnumerableCloudPageBlobBinding(
            [Blob(PageBlobContainerName)] IEnumerable<CloudPageBlob> blobs)
        {
            foreach (var blob in blobs)
            {
                byte[] bytes = new byte[512];
                int byteCount = await blob.DownloadToByteArrayAsync(bytes, 0);
                string content = Encoding.UTF8.GetString(bytes, 0, byteCount);
                Assert.StartsWith(TestData, content);
            }
            _numBlobsRead = blobs.Count();
        }

        [NoAutomaticTrigger]
        public static async Task IEnumerableCloudAppendBlobBinding(
            [Blob(AppendBlobContainerName)] IEnumerable<CloudAppendBlob> blobs)
        {
            foreach (var blob in blobs)
            {
                string content = await blob.DownloadTextAsync();
                Assert.Equal(TestData, content);
            }
            _numBlobsRead = blobs.Count();
        }

        [NoAutomaticTrigger]
        public static void IEnumerableStringBinding(
            [Blob(ContainerName)] IEnumerable<string> blobs)
        {
            foreach (var blob in blobs)
            {
                Assert.Equal(TestData, blob);
            }
            _numBlobsRead = blobs.Count();
        }

        [NoAutomaticTrigger]
        public static void IEnumerableStreamBinding(
            [Blob(ContainerName)] IEnumerable<Stream> blobs)
        {
            foreach (var blobStream in blobs)
            {
                using (StreamReader reader = new StreamReader(blobStream))
                {
                    string content = reader.ReadToEnd();
                    Assert.Equal(TestData, content);
                }
            }
            _numBlobsRead = blobs.Count();
        }

        [NoAutomaticTrigger]
        public static void IEnumerableTextReaderBinding(
            [Blob(ContainerName)] IEnumerable<TextReader> blobs)
        {
            foreach (var blob in blobs)
            {
                string content = blob.ReadToEnd();
                Assert.Equal(TestData, content);
            }
            _numBlobsRead = blobs.Count();
        }

        [NoAutomaticTrigger]
        public static async Task IEnumerableICloudBlobBinding(
            [Blob(ContainerName)] IEnumerable<ICloudBlob> blobs)
        {
            foreach (var blob in blobs)
            {
                Stream stream = await blob.OpenReadAsync(null, null, null);
                using (StreamReader reader = new StreamReader(stream))
                {
                    string content = reader.ReadToEnd();
                    Assert.Equal(TestData, content);
                }
            }
            _numBlobsRead = blobs.Count();
        }

        [NoAutomaticTrigger]
        public static void StringBinding_Block(
            [Blob(ContainerName + "/blob1")] string blob)
        {
            Assert.Equal(TestData, blob);
            _numBlobsRead = 1;
        }

        [NoAutomaticTrigger]
        public static void StringBinding_Page(
            [Blob(PageBlobContainerName + "/blob1")] string blob)
        {
            blob = blob.Trim('\0');
            Assert.Equal(TestData, blob);
            _numBlobsRead = 1;
        }

        [NoAutomaticTrigger]
        public static void StringBinding_Append(
            [Blob(AppendBlobContainerName + "/blob1")] string blob)
        {
            Assert.Equal(TestData, blob);
            _numBlobsRead = 1;
        }

        [NoAutomaticTrigger]
        public static void OutStringBinding_Block(
            [Blob(ContainerName + "/overwrite")] out string blob)
        {
            blob = "overwritten";
        }

        [NoAutomaticTrigger]
        public static void OutStringBinding_Page(
            [Blob(PageBlobContainerName + "/blob1")] out string blob)
        {
            // this wil fail before getting this far
            blob = TestData;
        }

        [NoAutomaticTrigger]
        public static void OutStringBinding_Append(
            [Blob(AppendBlobContainerName + "/blob1")] out string blob)
        {
            // this will fail before getting this far
            blob = TestData;
        }

        [NoAutomaticTrigger]
        public static void TextWriterBinding_Block(
            [Blob(ContainerName + "/overwrite")] TextWriter blob)
        {
            // this will fail
            blob.Write("overwritten");
        }

        [NoAutomaticTrigger]
        public static void TextWriterBinding_Page(
            [Blob(PageBlobContainerName + "/blob1")] TextWriter blob)
        {
            // this will fail
        }

        [NoAutomaticTrigger]
        public static void TextWriterBinding_Append(
            [Blob(AppendBlobContainerName + "/blob1")] TextWriter blob)
        {
            // this will fail
        }

        [NoAutomaticTrigger]
        public static void StreamBindingReadable_Block(
            [Blob(ContainerName + "/blob1", FileAccess.Read)] Stream blobStream)
        {
            using (StreamReader reader = new StreamReader(blobStream))
            {
                string content = reader.ReadToEnd();
                Assert.Equal(TestData, content);
            }
            _numBlobsRead = 1;
        }

        [NoAutomaticTrigger]
        public static void StreamBindingReadable_Page(
            [Blob(ContainerName + "/blob1", FileAccess.Read)] Stream blobStream)
        {
            using (StreamReader reader = new StreamReader(blobStream))
            {
                string content = reader.ReadToEnd();
                Assert.Equal(TestData, content);
            }
            _numBlobsRead = 1;
        }

        [NoAutomaticTrigger]
        public static void StreamBindingReadable_Append(
            [Blob(ContainerName + "/blob1", FileAccess.Read)] Stream blobStream)
        {
            using (StreamReader reader = new StreamReader(blobStream))
            {
                string content = reader.ReadToEnd();
                Assert.Equal(TestData, content);
            }
            _numBlobsRead = 1;
        }

        [NoAutomaticTrigger]
        public static void ByteArrayBinding(
            [Blob(ContainerName + "/blob1")] byte[] blob)
        {
            string result = Encoding.UTF8.GetString(blob);
            Assert.Equal(TestData, result);
            _numBlobsRead = 1;
        }

        [NoAutomaticTrigger]
        public static void ByteArrayBinding_Page(
            [Blob(PageBlobContainerName + "/blob1")] byte[] blob)
        {
            string result = Encoding.UTF8.GetString(blob);
            Assert.Equal(TestData, result);
            _numBlobsRead = 1;
        }

        [NoAutomaticTrigger]
        public static void ByteArrayBinding_Append(
            [Blob(AppendBlobContainerName + "/blob1")] byte[] blob)
        {
            string result = Encoding.UTF8.GetString(blob);
            Assert.Equal(TestData, result);
            _numBlobsRead = 1;
        }

        [NoAutomaticTrigger]
        public static void ByteArrayOutputBinding(string input,
            [Blob(OutputContainerName + "/blob1")] out byte[] output)
        {
            if (input == "null")
            {
                output = null;
            }
            else
            {
                output = Encoding.UTF8.GetBytes(input);
            }
        }

        [NoAutomaticTrigger]
        public static void ByteArrayTriggerBinding(
            [BlobTrigger(ContainerName)] byte[] blob)
        {
            string result = Encoding.UTF8.GetString(blob);
            Assert.Equal(TestData, result);
            _numBlobsRead = 1;
        }
#pragma warning restore xUnit1013 // Public method should be marked as test

        public class TestFixture : IAsyncLifetime
        {
            public async Task InitializeAsync()
            {
                RandomNameResolver nameResolver = new RandomNameResolver();

                Host = new HostBuilder()
                    .ConfigureDefaultTestHost<BlobBindingEndToEndTests>(b =>
                    {
                        b.AddAzureStorage();
                        b.AddAzureStorageCoreServices();
                    })
                    .ConfigureServices(services =>
                     {
                         services.AddSingleton<INameResolver>(nameResolver);
                     })
                    .Build();


                JobHost = Host.GetJobHost();

                var provider = Host.Services.GetService<StorageAccountProvider>();
                StorageAccount = provider.GetHost().SdkObject;
                CloudBlobClient blobClient = StorageAccount.CreateCloudBlobClient();

                BlobContainer = blobClient.GetContainerReference(nameResolver.ResolveInString(ContainerName));
                Assert.False(await BlobContainer.ExistsAsync());
                await BlobContainer.CreateAsync();

                OutputBlobContainer = blobClient.GetContainerReference(nameResolver.ResolveInString(OutputContainerName));

                CloudBlobContainer pageBlobContainer = blobClient.GetContainerReference(nameResolver.ResolveInString(PageBlobContainerName));
                Assert.False(await pageBlobContainer.ExistsAsync());
                await pageBlobContainer.CreateAsync();

                CloudBlobContainer hierarchicalBlobContainer = blobClient.GetContainerReference(nameResolver.ResolveInString(HierarchicalBlobContainerName));
                Assert.False(await hierarchicalBlobContainer.ExistsAsync());
                await hierarchicalBlobContainer.CreateAsync();

                CloudBlobContainer appendBlobContainer = blobClient.GetContainerReference(nameResolver.ResolveInString(AppendBlobContainerName));
                Assert.False(await appendBlobContainer.ExistsAsync());
                await appendBlobContainer.CreateAsync();

                await Host.StartAsync();

                // upload some test blobs
                CloudBlockBlob blob = BlobContainer.GetBlockBlobReference("blob1");
                await blob.UploadTextAsync(TestData);
                blob = BlobContainer.GetBlockBlobReference("blob2");
                await blob.UploadTextAsync(TestData);
                blob = BlobContainer.GetBlockBlobReference("blob3");
                await blob.UploadTextAsync(TestData);
                blob = BlobContainer.GetBlockBlobReference("file1");
                await blob.UploadTextAsync(TestData);
                blob = BlobContainer.GetBlockBlobReference("file2");
                await blob.UploadTextAsync(TestData);
                blob = BlobContainer.GetBlockBlobReference("overwrite");
                await blob.UploadTextAsync(TestData);

                // add a couple hierarchical blob paths
                blob = hierarchicalBlobContainer.GetBlockBlobReference("sub/blob1");
                await blob.UploadTextAsync(TestData);
                blob = hierarchicalBlobContainer.GetBlockBlobReference("sub/blob2");
                await blob.UploadTextAsync(TestData);
                blob = hierarchicalBlobContainer.GetBlockBlobReference("sub/sub/blob3");
                await blob.UploadTextAsync(TestData);
                blob = hierarchicalBlobContainer.GetBlockBlobReference("blob4");
                await blob.UploadTextAsync(TestData);

                byte[] bytes = new byte[512];
                byte[] testBytes = Encoding.UTF8.GetBytes(TestData);
                for (int i = 0; i < testBytes.Length; i++)
                {
                    bytes[i] = testBytes[i];
                }
                CloudPageBlob pageBlob = pageBlobContainer.GetPageBlobReference("blob1");
                await pageBlob.UploadFromByteArrayAsync(bytes, 0, bytes.Length);
                pageBlob = pageBlobContainer.GetPageBlobReference("blob2");
                await pageBlob.UploadFromByteArrayAsync(bytes, 0, bytes.Length);

                CloudAppendBlob appendBlob = appendBlobContainer.GetAppendBlobReference("blob1");
                await appendBlob.UploadTextAsync(TestData);
                appendBlob = appendBlobContainer.GetAppendBlobReference("blob2");
                await appendBlob.UploadTextAsync(TestData);
                appendBlob = appendBlobContainer.GetAppendBlobReference("blob3");
                await appendBlob.UploadTextAsync(TestData);
            }

            public IHost Host
            {
                get;
                private set;
            }

            public JobHost JobHost
            {
                get;
                private set;
            }

            public INameResolver NameResolver => Host.Services.GetService<INameResolver>();

            public string HostId => Host.Services.GetService<IHostIdProvider>().GetHostIdAsync(CancellationToken.None).Result;

            public CloudStorageAccount StorageAccount
            {
                get;
                private set;
            }

            public CloudBlobContainer BlobContainer
            {
                get;
                private set;
            }

            public CloudBlobContainer OutputBlobContainer
            {
                get;
                private set;
            }

            public async Task VerifyLockState(string lockId, LeaseState state, LeaseStatus status)
            {
                CloudBlobClient blobClient = StorageAccount.CreateCloudBlobClient();
                var container = blobClient.GetContainerReference("azure-webjobs-hosts");
                string blobName = string.Format("locks/{0}/{1}", HostId, lockId);
                var lockBlob = container.GetBlockBlobReference(blobName);

                Assert.True(await lockBlob.ExistsAsync());
                await lockBlob.FetchAttributesAsync();

                Assert.Equal(state, lockBlob.Properties.LeaseState);
                Assert.Equal(status, lockBlob.Properties.LeaseStatus);
            }

            public async Task DisposeAsync()
            {
                await Host.StopAsync();

                // $$$ reenalbe this
                VerifyLockState("WebJobs.Internal.Blobs.Listener", LeaseState.Available, LeaseStatus.Unlocked).Wait();

                CloudBlobClient blobClient = StorageAccount.CreateCloudBlobClient();
                foreach (var testContainer in (await blobClient.ListContainersSegmentedAsync(TestArtifactPrefix, null)).Results)
                {
                    await testContainer.DeleteAsync();
                }
            }
        }

        public class TestPoco
        {
            public string A { get; set; }

            public string B { get; set; }
        }
    }
}
