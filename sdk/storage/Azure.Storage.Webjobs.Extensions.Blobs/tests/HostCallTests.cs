// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs.Host.Blobs;
using Microsoft.Azure.WebJobs.Host.Config;
using Newtonsoft.Json;
using Xunit;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using Azure.Storage.Blobs.Specialized;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Azure.WebJobs.Extensions.Storage.Common.Tests;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common;

namespace Microsoft.Azure.WebJobs.Host.FunctionalTests
{
    // Some tests in this class aren't as targeted as most other tests in this project.
    // (Look elsewhere for better examples to use as templates for new tests.)
    [Collection(AzuriteCollection.Name)]
    public class HostCallTests
    {
        private const string ContainerName = "container-hostcalltests";
        private const string BlobName = "blob";
        private const string BlobPath = ContainerName + "/" + BlobName;
        private const string OutputBlobName = "blob.out";
        private const string OutputBlobPath = ContainerName + "/" + OutputBlobName;
        private const int TestValue = Int32.MinValue;
        private readonly StorageAccount account;

        public HostCallTests(AzuriteFixture azuriteFixture)
        {
            account = azuriteFixture.GetAccount();
            account.CreateBlobServiceClient().GetBlobContainerClient(ContainerName).DeleteIfExists();
        }

        [Theory]
        [InlineData("FuncWithString")]
        [InlineData("FuncWithTextReader")]
        [InlineData("FuncWithStreamRead")]
        [InlineData("FuncWithBlockBlob")]
        [InlineData("FuncWithOutStringNull")]
        [InlineData("FuncWithT")]
        [InlineData("FuncWithOutTNull")]
        [InlineData("FuncWithValueT")]
        public async Task Blob_IfBoundToTypeAndBlobIsMissing_DoesNotCreate(string methodName)
        {
            // Arrange
            var client = account.CreateBlobServiceClient();
            var container = client.GetBlobContainerClient(ContainerName);
            var blob = container.GetBlockBlobClient(BlobName);

            // Act
            await CallAsync(account, typeof(MissingBlobProgram), methodName, typeof(CustomBlobConverterExtensionConfigProvider));

            // Assert
            Assert.False(await blob.ExistsAsync());
        }

        [Theory]
        [InlineData("FuncWithOutString")]
        [InlineData("FuncWithStreamWriteNoop")]
        [InlineData("FuncWithTextWriter")]
        [InlineData("FuncWithStreamWrite")]
        [InlineData("FuncWithOutT")]
        [InlineData("FuncWithOutValueT")]
        public async Task Blob_IfBoundToTypeAndBlobIsMissing_Creates(string methodName)
        {
            // Arrange
            var client = account.CreateBlobServiceClient();
            var container = client.GetBlobContainerClient(ContainerName);
            var blob = container.GetBlockBlobClient(BlobName);

            // Act
            await CallAsync(account, typeof(MissingBlobProgram), methodName, typeof(CustomBlobConverterExtensionConfigProvider));

            // Assert
            Assert.True(await blob.ExistsAsync());
        }

        [Fact]
        public async Task BlobTrigger_IfHasUnboundParameter_CanCall()
        {
            // Arrange
            var client = account.CreateBlobServiceClient();
            var container = client.GetBlobContainerClient(ContainerName);
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
            await CallAsync(account, typeof(BlobProgram), "UnboundParameter", arguments);

            var outputBlob = container.GetBlockBlobClient("note.csv");
            string content = await outputBlob.DownloadTextAsync();
            Assert.Equal("done", content);

            // $$$ Put this in its own unit test?
            Guid? guid = BlobCausalityManager.GetWriterAsync(outputBlob,
                CancellationToken.None).GetAwaiter().GetResult();

            Assert.True(guid != Guid.Empty, "Blob is missing causality information");
        }

        [Fact]
        public async Task Blob_IfBoundToCloudBlockBlob_CanCall()
        {
            // Arrange
            var client = account.CreateBlobServiceClient();
            var container = client.GetBlobContainerClient(ContainerName);
            var inputBlob = container.GetBlockBlobClient(BlobName);
            await container.CreateIfNotExistsAsync();
            await inputBlob.UploadTextAsync("ignore");

            // Act
            await CallAsync(account, typeof(BlobProgram), "BindToCloudBlockBlob");
        }

        [Fact]
        public async Task Blob_IfBoundToString_CanCall()
        {
            // Arrange
            var client = account.CreateBlobServiceClient();
            var container = client.GetBlobContainerClient(ContainerName);
            var inputBlob = container.GetBlockBlobClient(BlobName);
            await container.CreateIfNotExistsAsync();
            await inputBlob.UploadTextAsync("0,1,2");

            await CallAsync(account, typeof(BlobProgram), "BindToString");
        }

        [Fact]
        public async Task Blob_IfCopiedViaString_CanCall()
        {
            // Arrange
            var client = account.CreateBlobServiceClient();
            var container = client.GetBlobContainerClient(ContainerName);
            var inputBlob = container.GetBlockBlobClient(BlobName);
            await container.CreateIfNotExistsAsync();
            string expectedContent = "abc";
            await inputBlob.UploadTextAsync(expectedContent);

            // Act
            await CallAsync(account, typeof(BlobProgram), "CopyViaString");

            // Assert
            var outputBlob = container.GetBlockBlobClient(OutputBlobName);
            string outputContent = await outputBlob.DownloadTextAsync();
            Assert.Equal(expectedContent, outputContent);
        }

        [Fact]
        public async Task BlobTrigger_IfCopiedViaTextReaderTextWriter_CanCall()
        {
            // Arrange
            var client = account.CreateBlobServiceClient();
            var container = client.GetBlobContainerClient(ContainerName);
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
            await CallAsync(account, typeof(BlobProgram), "CopyViaTextReaderTextWriter", arguments);

            // Assert
            var outputBlob = container.GetBlockBlobClient(OutputBlobName);
            string outputContent = await outputBlob.DownloadTextAsync();
            Assert.Equal(expectedContent, outputContent);
        }

        [Fact]
        public async Task BlobTrigger_IfBoundToICloudBlob_CanCallWithBlockBlob()
        {
            // Arrange
            var client = account.CreateBlobServiceClient();
            var container = client.GetBlobContainerClient(ContainerName);
            var blob = container.GetBlockBlobClient(BlobName);
            await container.CreateIfNotExistsAsync();
            await blob.UploadTextAsync("ignore");

            // TODO: Remove argument once host.Call supports more flexibility.
            IDictionary<string, object> arguments = new Dictionary<string, object>
            {
                { "blob", BlobPath }
            };

            // Act
            BlobBaseClient result = await CallAsync<BlobBaseClient>(account, typeof(BlobTriggerBindToICloudBlobProgram), "Call", arguments,
                (s) => BlobTriggerBindToICloudBlobProgram.TaskSource = s);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<BlockBlobClient>(result);
        }

        [Fact]
        public async Task BlobTrigger_IfBoundToICloudBlob_CanCallWithPageBlob()
        {
            // Arrange
            var client = account.CreateBlobServiceClient();
            var container = client.GetBlobContainerClient(ContainerName);
            var blob = container.GetPageBlobClient(BlobName);
            await container.CreateIfNotExistsAsync();
            await blob.CreateIfNotExistsAsync(512);

            // TODO: Remove argument once host.Call supports more flexibility.
            IDictionary<string, object> arguments = new Dictionary<string, object>
            {
                { "blob", BlobPath }
            };

            // Act
            BlobBaseClient result = await CallAsync<BlobBaseClient>(account, typeof(BlobTriggerBindToICloudBlobProgram), "Call", arguments,
                (s) => BlobTriggerBindToICloudBlobProgram.TaskSource = s);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<PageBlobClient>(result);
        }

        [Fact]
        public async Task BlobTrigger_IfBoundToICloudBlobAndTriggerArgumentIsMissing_CallThrows()
        {
            // Act
            Exception exception = await CallFailureAsync(account, typeof(BlobTriggerBindToICloudBlobProgram), "Call");

            // Assert
            Assert.IsType<InvalidOperationException>(exception);
            Assert.Equal("Missing value for trigger parameter 'blob'.", exception.Message);
        }

        [Fact]
        public async Task BlobTrigger_IfBoundToCloudBlockBlob_CanCall()
        {
            // Arrange
            var client = account.CreateBlobServiceClient();
            var container = client.GetBlobContainerClient(ContainerName);
            var blob = container.GetBlockBlobClient(BlobName);
            await container.CreateIfNotExistsAsync();
            await blob.UploadTextAsync("ignore");

            // TODO: Remove argument once host.Call supports more flexibility.
            IDictionary<string, object> arguments = new Dictionary<string, object>
            {
                { "blob", BlobPath }
            };

            // Act
            var result = await CallAsync<BlockBlobClient>(account, typeof(BlobTriggerBindToCloudBlockBlobProgram),
                "Call", arguments, (s) => BlobTriggerBindToCloudBlockBlobProgram.TaskSource = s);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task BlobTrigger_IfBoundToCloudBLockBlobAndTriggerArgumentIsMissing_CallThrows()
        {
            // Act
            Exception exception = await CallFailureAsync(account, typeof(BlobTriggerBindToCloudBlockBlobProgram), "Call");

            // Assert
            Assert.IsType<InvalidOperationException>(exception);
            Assert.Equal("Missing value for trigger parameter 'blob'.", exception.Message);
        }

        private class BlobTriggerBindToCloudBlockBlobProgram
        {
            public static TaskCompletionSource<BlockBlobClient> TaskSource { get; set; }

            public static void Call([BlobTrigger(BlobPath)] BlockBlobClient blob)
            {
                TaskSource.TrySetResult(blob);
            }
        }

        [Fact]
        public async Task BlobTrigger_IfBoundToCloudPageBlob_CanCall()
        {
            // Arrange
            var client = account.CreateBlobServiceClient();
            var container = client.GetBlobContainerClient(ContainerName);
            var blob = container.GetPageBlobClient(BlobName);
            await container.CreateIfNotExistsAsync();
            await blob.CreateIfNotExistsAsync(512);

            // TODO: Remove argument once host.Call supports more flexibility.
            IDictionary<string, object> arguments = new Dictionary<string, object>
            {
                { "blob", BlobPath }
            };

            // Act
            PageBlobClient result = await CallAsync<PageBlobClient>(account, typeof(BlobTriggerBindToCloudPageBlobProgram), "Call",
                arguments, (s) => BlobTriggerBindToCloudPageBlobProgram.TaskSource = s);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task BlobTrigger_IfBoundToCloudPageBlobAndTriggerArgumentIsMissing_CallThrows()
        {
            // Act
            Exception exception = await CallFailureAsync(account, typeof(BlobTriggerBindToCloudPageBlobProgram), "Call");

            // Assert
            Assert.IsType<InvalidOperationException>(exception);
            Assert.Equal("Missing value for trigger parameter 'blob'.", exception.Message);
        }

        private class BlobTriggerBindToCloudPageBlobProgram
        {
            public static TaskCompletionSource<PageBlobClient> TaskSource { get; set; }

            public static void Call([BlobTrigger(BlobPath)] PageBlobClient blob)
            {
                TaskSource.TrySetResult(blob);
            }
        }

        [Fact]
        public async Task BlobTrigger_IfBoundToCloudAppendBlob_CanCall()
        {
            // Arrange
            var client = account.CreateBlobServiceClient();
            var container = client.GetBlobContainerClient(ContainerName);
            var blob = container.GetAppendBlobClient(BlobName);
            await container.CreateIfNotExistsAsync();
            await blob.UploadTextAsync("test");

            // TODO: Remove argument once host.Call supports more flexibility.
            IDictionary<string, object> arguments = new Dictionary<string, object>
            {
                { "blob", BlobPath }
            };

            // Act
            var result = await CallAsync<AppendBlobClient>(account, typeof(BlobTriggerBindToCloudAppendBlobProgram), "Call",
                arguments, (s) => BlobTriggerBindToCloudAppendBlobProgram.TaskSource = s);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task BlobTrigger_IfBoundToCloudAppendBlobAndTriggerArgumentIsMissing_CallThrows()
        {
            // Act
            Exception exception = await CallFailureAsync(account, typeof(BlobTriggerBindToCloudAppendBlobProgram), "Call");

            // Assert
            Assert.IsType<InvalidOperationException>(exception);
            Assert.Equal("Missing value for trigger parameter 'blob'.", exception.Message);
        }

        private class BlobTriggerBindToCloudAppendBlobProgram
        {
            public static TaskCompletionSource<AppendBlobClient> TaskSource { get; set; }

            public static void Call([BlobTrigger(BlobPath)] AppendBlobClient blob)
            {
                TaskSource.TrySetResult(blob);
            }
        }

        [Fact]
        public async Task Int32Argument_CanCallViaStringParse()
        {
            IDictionary<string, object> arguments = new Dictionary<string, object>
            {
                { "value", "15" }
            };

            // Act
            int result = await CallAsync<int>(account, typeof(UnboundInt32Program), "Call", arguments,
                (s) => UnboundInt32Program.TaskSource = s);

            Assert.Equal(15, result);
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

        [Fact]
        public async Task Binder_IfBindingBlobToTextWriter_CanCall()
        {
            // Act
            await CallAsync(account, typeof(BindToBinderBlobTextWriterProgram), "Call");

            // Assert
            var container = account.CreateBlobServiceClient().GetBlobContainerClient(ContainerName);
            var blob = container.GetBlockBlobClient(OutputBlobName);
            string content = await blob.DownloadTextAsync();
            Assert.Equal("output", content);
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

        [Fact]
        public async Task BlobTrigger_IfCopiedViaPoco_CanCall()
        {
            // Arrange
            var client = account.CreateBlobServiceClient();
            var container = client.GetBlobContainerClient(ContainerName);
            var inputBlob = container.GetBlockBlobClient(BlobName);
            await container.CreateIfNotExistsAsync();
            await inputBlob.UploadTextAsync("abc");

            Dictionary<string, object> arguments = new Dictionary<string, object>
            {
                { "input", BlobPath }
            };

            // Act
            await CallAsync(account, typeof(CopyBlobViaPocoProgram), "CopyViaPoco", arguments, typeof(CustomBlobConverterExtensionConfigProvider));

            // Assert
            var outputBlob = container.GetBlockBlobClient(OutputBlobName);
            string content = await outputBlob.DownloadTextAsync();
            Assert.Equal("*abc*", content);
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

        private static async Task CallAsync(StorageAccount account, Type programType, string methodName, params Type[] customExtensions)
        {
            await FunctionalTest.CallAsync(account, programType, programType.GetMethod(methodName), null, customExtensions);
        }

        private static async Task CallAsync(StorageAccount account, Type programType, string methodName,
            IDictionary<string, object> arguments, params Type[] customExtensions)
        {
            await FunctionalTest.CallAsync(account, programType, programType.GetMethod(methodName), arguments, customExtensions);
        }

        private static async Task<TResult> CallAsync<TResult>(StorageAccount account, Type programType, string methodName,
            IDictionary<string, object> arguments, Action<TaskCompletionSource<TResult>> setTaskSource)
        {
            return await FunctionalTest.CallAsync<TResult>(account, programType, programType.GetMethod(methodName), arguments, setTaskSource);
        }

        private static async Task<Exception> CallFailureAsync(StorageAccount account, Type programType, string methodName)
        {
            return await FunctionalTest.CallFailureAsync(account, programType, programType.GetMethod(methodName), null);
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
                Assert.Equal(BlobName, blob.Name);
                Assert.Equal(ContainerName, blob.BlobContainerName);
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
#pragma warning disable xUnit2002 // Do not use null check on value type
                Assert.NotNull(value);
#pragma warning restore xUnit2002 // Do not use null check on value type
                Assert.Equal(0, value.ValueId);
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
                Assert.Equal("test", unbound);
                Assert.Equal("note", name);
                Assert.Equal("monday", date);

                string content = values.ReadToEnd();
                Assert.Equal("abc", content);

                output.Write("done");
            }

            public static void BindToCloudBlockBlob([Blob(BlobPath)] BlockBlobClient blob)
            {
                Assert.NotNull(blob);
                Assert.Equal(BlobName, blob.Name);
            }

            public static void BindToString([Blob(BlobPath)] string content)
            {
                Assert.NotNull(content);
                string[] strings = content.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                // Verify expected number of entries in CloudBlob
                Assert.Equal(3, strings.Length);
                for (int i = 0; i < 3; ++i)
                {
                    bool parsed = int.TryParse(strings[i], out int value);
                    string message = String.Format("Unable to parse CloudBlob strings[{0}]: '{1}'", i, strings[i]);
                    Assert.True(parsed, message);
                    // Ensure expected value in CloudBlob
                    Assert.Equal(i, value);
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
                        Assert.Equal(TestValue, value.ValueId);

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

                    Assert.Equal(TestValue, value.ValueId);

                    const byte ignore = 0xFF;
                    stream.WriteByte(ignore);

                    return null;
                });
            }
        }
    }
}
