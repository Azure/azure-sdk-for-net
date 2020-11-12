// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Queues;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Tests;
using Microsoft.Azure.WebJobs.Host.Config;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs
{
    // Some tests in this class aren't as targeted as most other tests in this project.
    // (Look elsewhere for better examples to use as templates for new tests.)
    public class HostCallTests
    {
        private const string ContainerName = "container-hostcalltests";
        private const string BlobName = "blob";
        private const string BlobPath = ContainerName + "/" + BlobName;
        private const string OutputBlobName = "blob.out";
        private const string OutputBlobPath = ContainerName + "/" + OutputBlobName;
        private const int TestValue = Int32.MinValue;
        private BlobServiceClient blobServiceClient;
        private QueueServiceClient queueServiceClient;

        [SetUp]
        public void SetUp()
        {
            queueServiceClient = AzuriteNUnitFixture.Instance.GetQueueServiceClient();
            blobServiceClient = AzuriteNUnitFixture.Instance.GetBlobServiceClient();
            blobServiceClient.GetBlobContainerClient(ContainerName).DeleteIfExists();
        }

        [TestCase("FuncWithString")]
        [TestCase("FuncWithTextReader")]
        [TestCase("FuncWithStreamRead")]
        [TestCase("FuncWithBlockBlob")]
        [TestCase("FuncWithOutStringNull")]
        [TestCase("FuncWithT")]
        [TestCase("FuncWithOutTNull")]
        [TestCase("FuncWithValueT")]
        public async Task Blob_IfBoundToTypeAndBlobIsMissing_DoesNotCreate(string methodName)
        {
            // Arrange
            var container = blobServiceClient.GetBlobContainerClient(ContainerName);
            var blob = container.GetBlockBlobClient(BlobName);

            // Act
            await CallAsync(typeof(MissingBlobProgram), methodName, typeof(CustomBlobConverterExtensionConfigProvider));

            // Assert
            Assert.False(await blob.ExistsAsync());
        }

        [TestCase("FuncWithOutString")]
        [TestCase("FuncWithStreamWriteNoop")]
        [TestCase("FuncWithTextWriter")]
        [TestCase("FuncWithStreamWrite")]
        [TestCase("FuncWithOutT")]
        [TestCase("FuncWithOutValueT")]
        public async Task Blob_IfBoundToTypeAndBlobIsMissing_Creates(string methodName)
        {
            // Arrange
            var container = blobServiceClient.GetBlobContainerClient(ContainerName);
            var blob = container.GetBlockBlobClient(BlobName);

            // Act
            await CallAsync(typeof(MissingBlobProgram), methodName, typeof(CustomBlobConverterExtensionConfigProvider));

            // Assert
            Assert.True(await blob.ExistsAsync());
        }

        [Test]
        public async Task BlobTrigger_IfHasUnboundParameter_CanCall()
        {
            // Arrange
            var container = blobServiceClient.GetBlobContainerClient(ContainerName);
            const string inputBlobName = "note-monday.csv";
            var inputBlob = container.GetBlockBlobClient(inputBlobName);
            await container.CreateIfNotExistsAsync();
            await inputBlob.UploadTextAsync("abc");

            IDictionary<string, object> arguments = new Dictionary<string, object>
            {
                { "values", ContainerName + "/" + inputBlobName },
                { "unbound", "test" }
            };

            // Act
            await CallAsync(typeof(BlobProgram), "UnboundParameter", arguments);

            var outputBlob = container.GetBlockBlobClient("note.csv");
            string content = await outputBlob.DownloadTextAsync();
            Assert.AreEqual("done", content);

            // $$$ Put this in its own unit test?
            Guid? guid = BlobCausalityManager.GetWriterAsync(outputBlob,
                CancellationToken.None).GetAwaiter().GetResult();

            Assert.True(guid != Guid.Empty, "Blob is missing causality information");
        }

        [Test]
        public async Task Blob_IfBoundToCloudBlockBlob_CanCall()
        {
            // Arrange
            var container = blobServiceClient.GetBlobContainerClient(ContainerName);
            var inputBlob = container.GetBlockBlobClient(BlobName);
            await container.CreateIfNotExistsAsync();
            await inputBlob.UploadTextAsync("ignore");

            // Act
            await CallAsync(typeof(BlobProgram), "BindToCloudBlockBlob");
        }

        [Test]
        public async Task Blob_IfBoundToBlobClient_CanCall()
        {
            // Arrange
            var container = blobServiceClient.GetBlobContainerClient(ContainerName);
            var inputBlob = container.GetBlockBlobClient(BlobName);
            await container.CreateIfNotExistsAsync();
            await inputBlob.UploadTextAsync("ignore");

            // Act
            await CallAsync(typeof(BlobProgram), "BindToBlobClient");
        }

        [Test]
        public async Task Blob_IfBoundToString_CanCall()
        {
            // Arrange
            var container = blobServiceClient.GetBlobContainerClient(ContainerName);
            var inputBlob = container.GetBlockBlobClient(BlobName);
            await container.CreateIfNotExistsAsync();
            await inputBlob.UploadTextAsync("0,1,2");

            await CallAsync(typeof(BlobProgram), "BindToString");
        }

        [Test]
        public async Task Blob_IfCopiedViaString_CanCall()
        {
            // Arrange
            var container = blobServiceClient.GetBlobContainerClient(ContainerName);
            var inputBlob = container.GetBlockBlobClient(BlobName);
            await container.CreateIfNotExistsAsync();
            string expectedContent = "abc";
            await inputBlob.UploadTextAsync(expectedContent);

            // Act
            await CallAsync(typeof(BlobProgram), "CopyViaString");

            // Assert
            var outputBlob = container.GetBlockBlobClient(OutputBlobName);
            string outputContent = await outputBlob.DownloadTextAsync();
            Assert.AreEqual(expectedContent, outputContent);
        }

        [Test]
        public async Task BlobTrigger_IfCopiedViaTextReaderTextWriter_CanCall()
        {
            // Arrange
            var container = blobServiceClient.GetBlobContainerClient(ContainerName);
            var inputBlob = container.GetBlockBlobClient(BlobName);
            await container.CreateIfNotExistsAsync();
            string expectedContent = "abc";
            await inputBlob.UploadTextAsync(expectedContent);

            // TODO: Remove argument once host.Call supports more flexibility.
            IDictionary<string, object> arguments = new Dictionary<string, object>
            {
                { "values", BlobPath }
            };

            // Act
            await CallAsync(typeof(BlobProgram), "CopyViaTextReaderTextWriter", arguments);

            // Assert
            var outputBlob = container.GetBlockBlobClient(OutputBlobName);
            string outputContent = await outputBlob.DownloadTextAsync();
            Assert.AreEqual(expectedContent, outputContent);
        }

        [Test]
        public async Task BlobTrigger_IfBoundToICloudBlob_CanCallWithBlockBlob()
        {
            // Arrange
            var container = blobServiceClient.GetBlobContainerClient(ContainerName);
            var blob = container.GetBlockBlobClient(BlobName);
            await container.CreateIfNotExistsAsync();
            await blob.UploadTextAsync("ignore");

            // TODO: Remove argument once host.Call supports more flexibility.
            IDictionary<string, object> arguments = new Dictionary<string, object>
            {
                { "blob", BlobPath }
            };

            // Act
            BlobBaseClient result = await CallAsync<BlobBaseClient>(typeof(BlobTriggerBindToICloudBlobProgram), "Call", arguments,
                (s) => BlobTriggerBindToICloudBlobProgram.TaskSource = s);

            // Assert
            Assert.NotNull(result);
            Assert.IsInstanceOf<BlockBlobClient>(result);
        }

        [Test]
        public async Task BlobTrigger_IfBoundToICloudBlob_CanCallWithPageBlob()
        {
            // Arrange
            var container = blobServiceClient.GetBlobContainerClient(ContainerName);
            var blob = container.GetPageBlobClient(BlobName);
            await container.CreateIfNotExistsAsync();
            await blob.CreateIfNotExistsAsync(512);

            // TODO: Remove argument once host.Call supports more flexibility.
            IDictionary<string, object> arguments = new Dictionary<string, object>
            {
                { "blob", BlobPath }
            };

            // Act
            BlobBaseClient result = await CallAsync<BlobBaseClient>(typeof(BlobTriggerBindToICloudBlobProgram), "Call", arguments,
                (s) => BlobTriggerBindToICloudBlobProgram.TaskSource = s);

            // Assert
            Assert.NotNull(result);
            Assert.IsInstanceOf<PageBlobClient>(result);
        }

        [Test]
        public async Task BlobTrigger_IfBoundToICloudBlobAndTriggerArgumentIsMissing_CallThrows()
        {
            // Act
            Exception exception = await CallFailureAsync(typeof(BlobTriggerBindToICloudBlobProgram), "Call");

            // Assert
            Assert.IsInstanceOf<InvalidOperationException>(exception);
            Assert.AreEqual("Missing value for trigger parameter 'blob'.", exception.Message);
        }

        [Test]
        public async Task BlobTrigger_IfBoundToCloudBlockBlob_CanCall()
        {
            // Arrange
            var container = blobServiceClient.GetBlobContainerClient(ContainerName);
            var blob = container.GetBlockBlobClient(BlobName);
            await container.CreateIfNotExistsAsync();
            await blob.UploadTextAsync("ignore");

            // TODO: Remove argument once host.Call supports more flexibility.
            IDictionary<string, object> arguments = new Dictionary<string, object>
            {
                { "blob", BlobPath }
            };

            // Act
            var result = await CallAsync<BlockBlobClient>(typeof(BlobTriggerBindToCloudBlockBlobProgram),
                "Call", arguments, (s) => BlobTriggerBindToCloudBlockBlobProgram.TaskSource = s);

            // Assert
            Assert.NotNull(result);
        }

        [Test]
        public async Task BlobTrigger_IfBoundToCloudBLockBlobAndTriggerArgumentIsMissing_CallThrows()
        {
            // Act
            Exception exception = await CallFailureAsync(typeof(BlobTriggerBindToCloudBlockBlobProgram), "Call");

            // Assert
            Assert.IsInstanceOf<InvalidOperationException>(exception);
            Assert.AreEqual("Missing value for trigger parameter 'blob'.", exception.Message);
        }

        private class BlobTriggerBindToCloudBlockBlobProgram
        {
            public static TaskCompletionSource<BlockBlobClient> TaskSource { get; set; }

            public static void Call([BlobTrigger(BlobPath)] BlockBlobClient blob)
            {
                TaskSource.TrySetResult(blob);
            }
        }

        [Test]
        public async Task BlobTrigger_IfBoundToBlobClient_CanCall()
        {
            // Arrange
            var container = blobServiceClient.GetBlobContainerClient(ContainerName);
            var blob = container.GetBlockBlobClient(BlobName);
            await container.CreateIfNotExistsAsync();
            await blob.UploadTextAsync("ignore");

            // TODO: Remove argument once host.Call supports more flexibility.
            IDictionary<string, object> arguments = new Dictionary<string, object>
            {
                { "blob", BlobPath }
            };

            // Act
            var result = await CallAsync<BlobClient>(typeof(BlobTriggerBindToBlobClientProgram),
                "Call", arguments, (s) => BlobTriggerBindToBlobClientProgram.TaskSource = s);

            // Assert
            Assert.NotNull(result);
        }

        [Test]
        public async Task BlobTrigger_IfBoundToBlobClientAndTriggerArgumentIsMissing_CallThrows()
        {
            // Act
            Exception exception = await CallFailureAsync(typeof(BlobTriggerBindToBlobClientProgram), "Call");

            // Assert
            Assert.IsInstanceOf<InvalidOperationException>(exception);
            Assert.AreEqual("Missing value for trigger parameter 'blob'.", exception.Message);
        }

        private class BlobTriggerBindToBlobClientProgram
        {
            public static TaskCompletionSource<BlobClient> TaskSource { get; set; }

            public static void Call([BlobTrigger(BlobPath)] BlobClient blob)
            {
                TaskSource.TrySetResult(blob);
            }
        }

        [Test]
        public async Task BlobTrigger_IfBoundToCloudPageBlob_CanCall()
        {
            // Arrange
            var container = blobServiceClient.GetBlobContainerClient(ContainerName);
            var blob = container.GetPageBlobClient(BlobName);
            await container.CreateIfNotExistsAsync();
            await blob.CreateIfNotExistsAsync(512);

            // TODO: Remove argument once host.Call supports more flexibility.
            IDictionary<string, object> arguments = new Dictionary<string, object>
            {
                { "blob", BlobPath }
            };

            // Act
            PageBlobClient result = await CallAsync<PageBlobClient>(typeof(BlobTriggerBindToCloudPageBlobProgram), "Call",
                arguments, (s) => BlobTriggerBindToCloudPageBlobProgram.TaskSource = s);

            // Assert
            Assert.NotNull(result);
        }

        [Test]
        public async Task BlobTrigger_IfBoundToCloudPageBlobAndTriggerArgumentIsMissing_CallThrows()
        {
            // Act
            Exception exception = await CallFailureAsync(typeof(BlobTriggerBindToCloudPageBlobProgram), "Call");

            // Assert
            Assert.IsInstanceOf<InvalidOperationException>(exception);
            Assert.AreEqual("Missing value for trigger parameter 'blob'.", exception.Message);
        }

        private class BlobTriggerBindToCloudPageBlobProgram
        {
            public static TaskCompletionSource<PageBlobClient> TaskSource { get; set; }

            public static void Call([BlobTrigger(BlobPath)] PageBlobClient blob)
            {
                TaskSource.TrySetResult(blob);
            }
        }

        [Test]
        public async Task BlobTrigger_IfBoundToCloudAppendBlob_CanCall()
        {
            // Arrange
            var container = blobServiceClient.GetBlobContainerClient(ContainerName);
            var blob = container.GetAppendBlobClient(BlobName);
            await container.CreateIfNotExistsAsync();
            await blob.UploadTextAsync("test");

            // TODO: Remove argument once host.Call supports more flexibility.
            IDictionary<string, object> arguments = new Dictionary<string, object>
            {
                { "blob", BlobPath }
            };

            // Act
            var result = await CallAsync<AppendBlobClient>(typeof(BlobTriggerBindToCloudAppendBlobProgram), "Call",
                arguments, (s) => BlobTriggerBindToCloudAppendBlobProgram.TaskSource = s);

            // Assert
            Assert.NotNull(result);
        }

        [Test]
        public async Task BlobTrigger_IfBoundToCloudAppendBlobAndTriggerArgumentIsMissing_CallThrows()
        {
            // Act
            Exception exception = await CallFailureAsync(typeof(BlobTriggerBindToCloudAppendBlobProgram), "Call");

            // Assert
            Assert.IsInstanceOf<InvalidOperationException>(exception);
            Assert.AreEqual("Missing value for trigger parameter 'blob'.", exception.Message);
        }

        private class BlobTriggerBindToCloudAppendBlobProgram
        {
            public static TaskCompletionSource<AppendBlobClient> TaskSource { get; set; }

            public static void Call([BlobTrigger(BlobPath)] AppendBlobClient blob)
            {
                TaskSource.TrySetResult(blob);
            }
        }

        [Test]
        public async Task Int32Argument_CanCallViaStringParse()
        {
            IDictionary<string, object> arguments = new Dictionary<string, object>
            {
                { "value", "15" }
            };

            // Act
            int result = await CallAsync<int>(typeof(UnboundInt32Program), "Call", arguments,
                (s) => UnboundInt32Program.TaskSource = s);

            Assert.AreEqual(15, result);
        }

        private class UnboundInt32Program
        {
            public static TaskCompletionSource<int> TaskSource { get; set; }

            [NoAutomaticTrigger]
            public static void Call(int value)
            {
                TaskSource.TrySetResult(value);
            }
        }

        [Test]
        public async Task Binder_IfBindingBlobToTextWriter_CanCall()
        {
            // Act
            await CallAsync(typeof(BindToBinderBlobTextWriterProgram), "Call");

            // Assert
            var container = blobServiceClient.GetBlobContainerClient(ContainerName);
            var blob = container.GetBlockBlobClient(OutputBlobName);
            string content = await blob.DownloadTextAsync();
            Assert.AreEqual("output", content);
        }

        private class BindToBinderBlobTextWriterProgram
        {
            [NoAutomaticTrigger]
            public static void Call(IBinder binder)
            {
                TextWriter tw = binder.Bind<TextWriter>(new BlobAttribute(OutputBlobPath));
                tw.Write("output");

                // closed automatically
            }
        }

        [Test]
        public async Task BlobTrigger_IfCopiedViaPoco_CanCall()
        {
            // Arrange
            var container = blobServiceClient.GetBlobContainerClient(ContainerName);
            var inputBlob = container.GetBlockBlobClient(BlobName);
            await container.CreateIfNotExistsAsync();
            await inputBlob.UploadTextAsync("abc");

            Dictionary<string, object> arguments = new Dictionary<string, object>
            {
                { "input", BlobPath }
            };

            // Act
            await CallAsync(typeof(CopyBlobViaPocoProgram), "CopyViaPoco", arguments, typeof(CustomBlobConverterExtensionConfigProvider));

            // Assert
            var outputBlob = container.GetBlockBlobClient(OutputBlobName);
            string content = await outputBlob.DownloadTextAsync();
            Assert.AreEqual("*abc*", content);
        }

        private class CopyBlobViaPocoProgram
        {
            public static void CopyViaPoco(
                [BlobTrigger(BlobPath)] PocoBlob input,
                [Blob(OutputBlobPath)] out PocoBlob output)
            {
                output = new PocoBlob { Value = "*" + input.Value + "*" };
            }
        }

        private class PocoBlob
        {
            public string Value;
        }

        private async Task CallAsync(Type programType, string methodName, params Type[] customExtensions)
        {
            await FunctionalTest.CallAsync(b => ConfigureStorage(b), programType, programType.GetMethod(methodName), null, customExtensions);
        }

        private async Task CallAsync(Type programType, string methodName,
            IDictionary<string, object> arguments, params Type[] customExtensions)
        {
            await FunctionalTest.CallAsync(b => ConfigureStorage(b), programType, programType.GetMethod(methodName), arguments, customExtensions);
        }

        private async Task<TResult> CallAsync<TResult>(Type programType, string methodName,
            IDictionary<string, object> arguments, Action<TaskCompletionSource<TResult>> setTaskSource)
        {
            return await FunctionalTest.CallAsync<TResult>(b => ConfigureStorage(b), programType, programType.GetMethod(methodName), arguments, setTaskSource);
        }

        private async Task<Exception> CallFailureAsync(Type programType, string methodName)
        {
            return await FunctionalTest.CallFailureAsync(b => ConfigureStorage(b), programType, programType.GetMethod(methodName), null);
        }

        private void ConfigureStorage(IWebJobsBuilder builder)
        {
            builder.AddAzureStorageBlobs();
            builder.UseStorageServices(blobServiceClient, queueServiceClient);
        }

        private struct CustomDataValue
        {
            public int ValueId { get; set; }
            public string Content { get; set; }
        }

        private class CustomDataObject
        {
            public int ValueId { get; set; }
            public string Content { get; set; }
        }

        private class MissingBlobProgram
        {
            public static void FuncWithBlockBlob([Blob(BlobPath)] BlockBlobClient blob)
            {
                Assert.NotNull(blob);
                Assert.AreEqual(BlobName, blob.Name);
                Assert.AreEqual(ContainerName, blob.BlobContainerName);
            }

            public static void FuncWithStreamRead([Blob(BlobPath, FileAccess.Read)] Stream stream)
            {
                Assert.Null(stream);
            }

            public static void FuncWithStreamWrite([Blob(BlobPath, FileAccess.Write)] Stream stream)
            {
                Assert.NotNull(stream);

                const byte ignore = 0xFF;
                stream.WriteByte(ignore);
            }

            public static void FuncWithStreamWriteNoop([Blob(BlobPath, FileAccess.Write)] Stream stream)
            {
                Assert.NotNull(stream);
            }

            public static void FuncWithTextReader([Blob(BlobPath)] TextReader reader)
            {
                Assert.Null(reader);
            }

            public static void FuncWithTextWriter([Blob(BlobPath)] TextWriter writer)
            {
                Assert.NotNull(writer);
            }

            public static void FuncWithString([Blob(BlobPath)] string content)
            {
                Assert.Null(content);
            }

            public static void FuncWithOutString([Blob(BlobPath)] out string content)
            {
                content = "ignore";
            }

            public static void FuncWithOutStringNull([Blob(BlobPath)] out string content)
            {
                content = null;
            }

            public static void FuncWithT([Blob(BlobPath)] CustomDataObject value)
            {
                Assert.Null(value); // null value is Blob is Missing
            }

            public static void FuncWithOutT([Blob(BlobPath)] out CustomDataObject value)
            {
                value = new CustomDataObject { ValueId = TestValue, Content = "ignore" };
            }

            public static void FuncWithOutTNull([Blob(BlobPath)] out CustomDataObject value)
            {
                value = null;
            }

            public static void FuncWithValueT([Blob(BlobPath)] CustomDataValue value)
            {
                // default(T) is blob is missing
                Assert.NotNull(value);
                Assert.AreEqual(0, value.ValueId);
            }

            public static void FuncWithOutValueT([Blob(BlobPath)] out CustomDataValue value)
            {
                value = new CustomDataValue { ValueId = TestValue, Content = "ignore" };
            }
        }

        private class BlobProgram
        {
            // This can be invoked explicitly (and providing parameters)
            // or it can be invoked implicitly by triggering on input. // (assuming no unbound parameters)
            [NoAutomaticTrigger]
            public static void UnboundParameter(
                string name, string date,  // used by input
                string unbound, // not used by in/out
                [BlobTrigger(ContainerName + "/{name}-{date}.csv")] TextReader values,
                [Blob(ContainerName + "/{name}.csv")] TextWriter output
                )
            {
                Assert.AreEqual("test", unbound);
                Assert.AreEqual("note", name);
                Assert.AreEqual("monday", date);

                string content = values.ReadToEnd();
                Assert.AreEqual("abc", content);

                output.Write("done");
            }

            public static void BindToCloudBlockBlob([Blob(BlobPath)] BlockBlobClient blob)
            {
                Assert.NotNull(blob);
                Assert.AreEqual(BlobName, blob.Name);
            }

            public static void BindToBlobClient([Blob(BlobPath)] BlobClient blob)
            {
                Assert.NotNull(blob);
                Assert.AreEqual(BlobName, blob.Name);
            }

            public static void BindToString([Blob(BlobPath)] string content)
            {
                Assert.NotNull(content);
                string[] strings = content.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                // Verify expected number of entries in CloudBlob
                Assert.AreEqual(3, strings.Length);
                for (int i = 0; i < 3; ++i)
                {
                    bool parsed = int.TryParse(strings[i], out int value);
                    string message = String.Format("Unable to parse CloudBlob strings[{0}]: '{1}'", i, strings[i]);
                    Assert.True(parsed, message);
                    // Ensure expected value in CloudBlob
                    Assert.AreEqual(i, value);
                }
            }

            public static void CopyViaString(
                [Blob(BlobPath)] string blobIn,
                [Blob(OutputBlobPath)] out string blobOut
                )
            {
                blobOut = blobIn;
            }

            public static void CopyViaTextReaderTextWriter(
                [BlobTrigger(BlobPath)] TextReader values,
                [Blob(OutputBlobPath)] TextWriter output)
            {
                string content = values.ReadToEnd();
                output.Write(content);
            }
        }

        private class BlobTriggerBindToICloudBlobProgram
        {
            public static TaskCompletionSource<BlobBaseClient> TaskSource { get; set; }

            public static void Call([BlobTrigger(BlobPath)] BlobBaseClient blob)
            {
                TaskSource.TrySetResult(blob);
            }
        }

        internal class CustomBlobConverterExtensionConfigProvider : IExtensionConfigProvider
        {
            public void Initialize(ExtensionConfigContext context)
            {
                context.AddConverter<Stream, PocoBlob>(s =>
                {
                    TextReader reader = new StreamReader(s);
                    string text = reader.ReadToEnd();
                    return new PocoBlob { Value = text };
                });

                context.AddConverter<ApplyConversion<PocoBlob, Stream>, object>(p =>
                {
                    PocoBlob value = p.Value;
                    Stream stream = p.Existing;

                    TextWriter writer = new StreamWriter(stream);
                    writer.WriteAsync(value.Value).GetAwaiter().GetResult();
                    writer.FlushAsync().GetAwaiter().GetResult();

                    return null;
                });

                context.AddConverter<Stream, CustomDataObject>(s =>
                {
                    // Read() shouldn't be called if the stream is missing.
                    Assert.False(true, "If stream is missing, should never call Read() converter");
                    return null;
                });

                context.AddConverter<ApplyConversion<CustomDataObject, Stream>, object>(p =>
                {
                    CustomDataObject value = p.Value;
                    Stream stream = p.Existing;

                    if (value != null)
                    {
                        Assert.AreEqual(TestValue, value.ValueId);

                        const byte ignore = 0xFF;
                        stream.WriteByte(ignore);
                    }

                    return null;
                });

                context.AddConverter<Stream, CustomDataValue>(s =>
                {
                    // Read() shouldn't be called if the stream is missing.
                    Assert.False(true, "If stream is missing, should never call Read() converter");
                    return default(CustomDataValue);
                });

                context.AddConverter<ApplyConversion<CustomDataValue, Stream>, object>(p =>
                {
                    CustomDataValue value = p.Value;
                    Stream stream = p.Existing;

                    Assert.AreEqual(TestValue, value.ValueId);

                    const byte ignore = 0xFF;
                    stream.WriteByte(ignore);

                    return null;
                });
            }
        }
    }
}
