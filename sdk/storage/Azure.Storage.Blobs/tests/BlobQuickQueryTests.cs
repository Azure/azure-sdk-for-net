// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Blobs.Tests;
using Azure.Storage.Test;
using Azure.Storage.Test.Shared;
using Azure.Storage.Tests.Shared;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Test
{
    public class BlobQuickQueryTests : BlobTestBase
    {
        public BlobQuickQueryTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        [RetryOnException(TestConstants.QuickQueryRetryCount, typeof(IOException))]
        public async Task QueryAsync_Min()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlockBlobClient blockBlobClient = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            Stream stream = CreateDataStream(Constants.KB);
            await blockBlobClient.UploadAsync(stream);

            // Act
            string query = @"SELECT _2 from BlobStorage WHERE _1 > 250;";
            Response<BlobDownloadInfo> response = await blockBlobClient.QueryAsync(query);

            using StreamReader streamReader = new StreamReader(response.Value.Content);
            string s = await streamReader.ReadToEndAsync();

            // Assert
            Assert.That(s, Is.EqualTo("400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n"));

            // Ensure that we grab the whole ETag value from the service without removing the quotes
            Assert.That($"\"{response.GetRawResponse().Headers.ETag.ToString()}\"", Is.EqualTo(response.Value.Details.ETag.ToString()));
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        [RetryOnException(TestConstants.QuickQueryRetryCount, typeof(IOException))]
        public async Task QueryAsync_Snapshot()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlockBlobClient blockBlobClient = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            Stream stream = CreateDataStream(Constants.KB);
            await blockBlobClient.UploadAsync(stream);
            Response<BlobSnapshotInfo> snapshotResponse = await blockBlobClient.CreateSnapshotAsync();
            BlockBlobClient snapshotClient = InstrumentClient(blockBlobClient.WithSnapshot(snapshotResponse.Value.Snapshot));

            // Act
            string query = @"SELECT _2 from BlobStorage WHERE _1 > 250;";
            Response<BlobDownloadInfo> response = await snapshotClient.QueryAsync(query);

            using StreamReader streamReader = new StreamReader(response.Value.Content);
            string s = await streamReader.ReadToEndAsync();

            // Assert
            Assert.That(s, Is.EqualTo("400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n"));
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        [RetryOnException(TestConstants.QuickQueryRetryCount, typeof(IOException))]
        public async Task QueryAsync_Error()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlockBlobClient blockBlobClient = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            string query = @"SELECT _2 from BlobStorage WHERE _1 > 250;";

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blockBlobClient.QueryAsync(
                    query),
                e => Assert.That(e.ErrorCode, Is.EqualTo("BlobNotFound")));
        }

        [RecordedTest]
        [Ignore("Don't want to record 16 MB of data.")]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        [RetryOnException(TestConstants.QuickQueryRetryCount, typeof(IOException))]
        public async Task QueryAsync_MultipleDataRecords()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlockBlobClient blockBlobClient = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            Stream stream = CreateDataStream(16 * Constants.MB);
            await blockBlobClient.UploadAsync(stream);
            string query = @"SELECT * from BlobStorage";

            // Act
            TestProgress progressReporter = new TestProgress();
            BlobQueryOptions options = new BlobQueryOptions
            {
                ProgressHandler = progressReporter
            };
            Response<BlobDownloadInfo> response = await blockBlobClient.QueryAsync(
                query,
                options);

            stream.Seek(0, SeekOrigin.Begin);
            using StreamReader expectedStreamReader = new StreamReader(stream);
            string expected = await expectedStreamReader.ReadToEndAsync();

            using StreamReader actualStreamReader = new StreamReader(response.Value.Content);
            string actual = await actualStreamReader.ReadToEndAsync();

            // Assert
            // Check we got back the same content that we uploaded.
            Assert.That(actual, Is.EqualTo(expected));

            // Check progress reporter
            Assert.That(progressReporter.List.Count, Is.EqualTo(5));
            Assert.That(progressReporter.List[0], Is.EqualTo(4 * Constants.MB));
            Assert.That(progressReporter.List[1], Is.EqualTo(8 * Constants.MB));
            Assert.That(progressReporter.List[2], Is.EqualTo(12 * Constants.MB));
            Assert.That(progressReporter.List[3], Is.EqualTo(16 * Constants.MB));
            Assert.That(progressReporter.List[4], Is.EqualTo(16 * Constants.MB));
        }

        [RecordedTest]
        [Ignore("Don't want to record 250 MB of data.")]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        [RetryOnException(TestConstants.QuickQueryRetryCount, typeof(IOException))]
        public async Task QueryAsync_Large()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlockBlobClient blockBlobClient = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            Stream stream = CreateDataStream(250 * Constants.MB);
            await blockBlobClient.UploadAsync(stream);
            string query = @"SELECT * from BlobStorage";

            // Act
            TestProgress progressReporter = new TestProgress();
            BlobQueryOptions options = new BlobQueryOptions
            {
                ProgressHandler = progressReporter
            };
            Response<BlobDownloadInfo> response = await blockBlobClient.QueryAsync(
                query,
                options);

            stream.Seek(0, SeekOrigin.Begin);
            using StreamReader expectedStreamReader = new StreamReader(stream);
            string expected = await expectedStreamReader.ReadToEndAsync();

            using StreamReader actualStreamReader = new StreamReader(response.Value.Content);
            string actual = await actualStreamReader.ReadToEndAsync();

            // Assert
            // Check we got back the same content that we uploaded.
            Assert.That(actual, Is.EqualTo(expected));
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        [RetryOnException(TestConstants.QuickQueryRetryCount, typeof(IOException))]
        public async Task QueryAsync_Progress()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlockBlobClient blockBlobClient = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            Stream stream = CreateDataStream(Constants.KB);
            await blockBlobClient.UploadAsync(stream);

            // Act
            string query = @"SELECT _2 from BlobStorage WHERE _1 > 250;";
            TestProgress progressReporter = new TestProgress();
            BlobQueryOptions options = new BlobQueryOptions
            {
                ProgressHandler = progressReporter
            };

            Response<BlobDownloadInfo> response = await blockBlobClient.QueryAsync(
                query,
                options);

            using StreamReader streamReader = new StreamReader(response.Value.Content);
            await streamReader.ReadToEndAsync();

            Assert.That(progressReporter.List.Count, Is.EqualTo(2));
            Assert.That(progressReporter.List[0], Is.EqualTo(Constants.KB));
            Assert.That(progressReporter.List[1], Is.EqualTo(Constants.KB));
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/12063")]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        [RetryOnException(TestConstants.QuickQueryRetryCount, typeof(IOException))]
        public async Task QueryAsync_QueryTextConfigurations()
        {
            await using DisposingContainer test = await GetTestContainerAsync();
            BlockBlobClient blockBlobClient = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            Stream stream = CreateDataStream(Constants.KB);
            await blockBlobClient.UploadAsync(stream);

            // Act
            string query = @"SELECT _2 from BlobStorage WHERE _1 > 250;";

            BlobQueryCsvTextOptions csvTextConfiguration = new BlobQueryCsvTextOptions
            {
                ColumnSeparator = ",",
                QuotationCharacter = '"',
                EscapeCharacter = '\\',
                RecordSeparator = "\n",
                HasHeaders = false
            };

            BlobQueryJsonTextOptions jsonTextConfiguration = new BlobQueryJsonTextOptions
            {
                RecordSeparator = "\n"
            };

            BlobQueryOptions options = new BlobQueryOptions
            {
                InputTextConfiguration = csvTextConfiguration,
                OutputTextConfiguration = jsonTextConfiguration
            };

            // Act
            Response<BlobDownloadInfo> response = await blockBlobClient.QueryAsync(
                query,
                options);

            using StreamReader streamReader = new StreamReader(response.Value.Content);
            string s = await streamReader.ReadToEndAsync();

            // Assert
            Assert.That(s, Is.EqualTo("{\"_1\":\"400\"}\n{\"_1\":\"400\"}\n{\"_1\":\"400\"}\n{\"_1\":\"400\"}\n{\"_1\":\"400\"}\n{\"_1\":\"400\"}\n{\"_1\":\"400\"}\n{\"_1\":\"400\"}\n{\"_1\":\"400\"}\n{\"_1\":\"400\"}\n{\"_1\":\"400\"}\n{\"_1\":\"400\"}\n{\"_1\":\"400\"}\n{\"_1\":\"400\"}\n{\"_1\":\"400\"}\n{\"_1\":\"400\"}\n{\"_1\":\"400\"}\n{\"_1\":\"400\"}\n{\"_1\":\"400\"}\n{\"_1\":\"400\"}\n{\"_1\":\"400\"}\n{\"_1\":\"400\"}\n{\"_1\":\"400\"}\n{\"_1\":\"400\"}\n{\"_1\":\"400\"}\n{\"_1\":\"400\"}\n{\"_1\":\"400\"}\n{\"_1\":\"400\"}\n{\"_1\":\"400\"}\n{\"_1\":\"400\"}\n{\"_1\":\"400\"}\n{\"_1\":\"400\"}\n"));
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        [RetryOnException(TestConstants.QuickQueryRetryCount, typeof(IOException))]
        public async Task QueryAsync_NonFatalError()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlockBlobClient blockBlobClient = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

            byte[] data = Encoding.UTF8.GetBytes("100,pizza,300,400\n300,400,500,600\n");
            using MemoryStream stream = new MemoryStream(data);
            await blockBlobClient.UploadAsync(stream);
            string query = @"SELECT _1 from BlobStorage WHERE _2 > 250;";

            // Act - with no IBlobQueryErrorReceiver
            Response<BlobDownloadInfo> response = await blockBlobClient.QueryAsync(query);
            using StreamReader streamReader = new StreamReader(response.Value.Content);
            string s = await streamReader.ReadToEndAsync();

            // Act - with  IBlobQueryErrorReceiver
            BlobQueryError expectedBlobQueryError = new BlobQueryError
            {
                IsFatal = false,
                Name = "InvalidTypeConversion",
                Description = "Invalid type conversion.",
                Position = 0
            };

            BlobQueryErrorHandler errorHandler = new BlobQueryErrorHandler(expectedBlobQueryError);

            BlobQueryOptions options = new BlobQueryOptions();
            options.ErrorHandler += errorHandler.Handle;

            response = await blockBlobClient.QueryAsync(
                query,
                options);
            using StreamReader streamReader2 = new StreamReader(response.Value.Content);
            s = await streamReader2.ReadToEndAsync();
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/12063")]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        [RetryOnException(TestConstants.QuickQueryRetryCount, typeof(IOException))]
        public async Task QueryAsync_FatalError()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlockBlobClient blockBlobClient = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            Stream stream = CreateDataStream(Constants.KB);
            await blockBlobClient.UploadAsync(stream);
            string query = @"SELECT * from BlobStorage;";
            BlobQueryJsonTextOptions jsonTextConfiguration = new BlobQueryJsonTextOptions
            {
                RecordSeparator = "\n"
            };
            BlobQueryOptions options = new BlobQueryOptions
            {
                InputTextConfiguration = jsonTextConfiguration
            };

            // Act - with no IBlobQueryErrorReceiver
            Response<BlobDownloadInfo> response = await blockBlobClient.QueryAsync(
                query,
                options);
            using StreamReader streamReader = new StreamReader(response.Value.Content);
            string s = await streamReader.ReadToEndAsync();

            // Act - with  IBlobQueryErrorReceiver
            BlobQueryError expectedBlobQueryError = new BlobQueryError
            {
                IsFatal = true,
                Name = "ParseError",
                Description = "Unexpected token ',' at [byte: 3]. Expecting tokens '{', or '['.",
                Position = 0
            };

            BlobQueryErrorHandler errorHandler = new BlobQueryErrorHandler(expectedBlobQueryError);

            options = new BlobQueryOptions
            {
                InputTextConfiguration = jsonTextConfiguration,
            };
            options.ErrorHandler += errorHandler.Handle;

            response = await blockBlobClient.QueryAsync(
                query,
                options);
            using StreamReader streamReader2 = new StreamReader(response.Value.Content);
            s = await streamReader2.ReadToEndAsync();
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        [RetryOnException(TestConstants.QuickQueryRetryCount, typeof(IOException))]
        public async Task QueryAsync_AccessConditions()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in AccessConditions_Data)
            {
                // Arrange
                await using DisposingContainer test = await GetTestContainerAsync();
                BlockBlobClient blockBlobClient = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
                Stream stream = CreateDataStream(Constants.KB);
                await blockBlobClient.UploadAsync(stream);

                parameters.Match = await SetupBlobMatchCondition(blockBlobClient, parameters.Match);
                parameters.LeaseId = await SetupBlobLeaseCondition(blockBlobClient, parameters.LeaseId, garbageLeaseId);
                BlobRequestConditions accessConditions = BuildAccessConditions(
                    parameters: parameters,
                    lease: true);
                BlobQueryOptions options = new BlobQueryOptions
                {
                    Conditions = accessConditions
                };

                string query = @"SELECT * from BlobStorage";

                // Act
                Response<BlobDownloadInfo> response = await blockBlobClient.QueryAsync(
                    query,
                    options);

                // Assert
                Assert.That(response.Value.Details.ETag, Is.Not.Null);
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        [RetryOnException(TestConstants.QuickQueryRetryCount, typeof(IOException))]
        public async Task QueryAsync_AccessConditionsFail()
        {
            var garbageLeaseId = GetGarbageLeaseId();
            foreach (AccessConditionParameters parameters in GetAccessConditionsFail_Data(garbageLeaseId))
            {
                // Arrange
                await using DisposingContainer test = await GetTestContainerAsync();
                BlockBlobClient blockBlobClient = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
                Stream stream = CreateDataStream(Constants.KB);
                await blockBlobClient.UploadAsync(stream);

                parameters.NoneMatch = await SetupBlobMatchCondition(blockBlobClient, parameters.NoneMatch);
                BlobRequestConditions accessConditions = BuildAccessConditions(parameters);
                BlobQueryOptions options = new BlobQueryOptions
                {
                    Conditions = accessConditions
                };

                string query = @"SELECT * from BlobStorage";

                // Act
                await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                    blockBlobClient.QueryAsync(
                        query,
                        options),
                    e => { });
            }
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        [RetryOnException(TestConstants.QuickQueryRetryCount, typeof(IOException))]
        public async Task QueryAsync_IfTags()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlockBlobClient blockBlobClient = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            Stream stream = CreateDataStream(Constants.KB);
            await blockBlobClient.UploadAsync(stream);

            Dictionary<string, string> tags = new Dictionary<string, string>
            {
                { "coolTag", "true" }
            };
            await blockBlobClient.SetTagsAsync(tags);

            BlobQueryOptions blobQueryOptions = new BlobQueryOptions
            {
                Conditions = new BlobRequestConditions
                {
                    TagConditions = "\"coolTag\" = 'true'"
                }
            };

            // Act
            string query = @"SELECT _2 from BlobStorage WHERE _1 > 250;";
            Response<BlobDownloadInfo> response = await blockBlobClient.QueryAsync(
                querySqlExpression: query,
                options: blobQueryOptions);

            using StreamReader streamReader = new StreamReader(response.Value.Content);
            string s = await streamReader.ReadToEndAsync();

            // Assert
            Assert.That(s, Is.EqualTo("400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n400\n"));
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2019_12_12)]
        [RetryOnException(TestConstants.QuickQueryRetryCount, typeof(IOException))]
        public async Task QueryAsync_IfTags_Failed()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlockBlobClient blockBlobClient = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            Stream stream = CreateDataStream(Constants.KB);
            await blockBlobClient.UploadAsync(stream);

            BlobQueryOptions blobQueryOptions = new BlobQueryOptions
            {
                Conditions = new BlobRequestConditions
                {
                    TagConditions = "\"coolTag\" = 'true'"
                }
            };

            string query = @"SELECT _2 from BlobStorage WHERE _1 > 250;";

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                blockBlobClient.QueryAsync(
                    querySqlExpression: query,
                    options: blobQueryOptions),
                e => Assert.That(e.ErrorCode, Is.EqualTo(BlobErrorCode.ConditionNotMet.ToString())));
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_02_10)]
        [RetryOnException(TestConstants.QuickQueryRetryCount, typeof(IOException))]
        public async Task QueryAsync_ArrowConfiguration()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlockBlobClient blockBlobClient = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            Stream stream = CreateDataStream(Constants.KB);
            await blockBlobClient.UploadAsync(stream);

            // Act
            string query = @"SELECT _2 from BlobStorage WHERE _1 > 250;";
            BlobQueryOptions options = new BlobQueryOptions
            {
                OutputTextConfiguration = new BlobQueryArrowOptions
                {
                    Schema = new List<BlobQueryArrowField>()
                    {
                        new BlobQueryArrowField
                        {
                            Type = BlobQueryArrowFieldType.Decimal,
                            Name = "Name",
                            Precision = 4,
                            Scale = 2
                        }
                    }
                }
            };

            // Act
            await blockBlobClient.QueryAsync(
                query,
                options: options);
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_08_04)]
        [RetryOnException(TestConstants.QuickQueryRetryCount, typeof(IOException))]
        public async Task QueryAsync_ParquetConfiguration()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlockBlobClient blockBlobClient = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            using FileStream stream = File.OpenRead(
                $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}{Path.DirectorySeparatorChar}Resources{Path.DirectorySeparatorChar}parquet.parquet");
            await blockBlobClient.UploadAsync(stream);

            // Act
            string query = @"select * from blobstorage where id < 1;";
            BlobQueryOptions options = new BlobQueryOptions
            {
                InputTextConfiguration = new BlobQueryParquetTextOptions()
            };
            Response<BlobDownloadInfo> response = await blockBlobClient.QueryAsync(
                query,
                options: options);

            // Assert
            using StreamReader streamReader = new StreamReader(response.Value.Content);
            string s = await streamReader.ReadToEndAsync();

            // Assert
            Assert.That(s, Is.EqualTo("0,mdifjt55.ea3,mdifjt55.ea3\n"));
        }

        [Test]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_08_04)]
        [RetryOnException(TestConstants.QuickQueryRetryCount, typeof(IOException))]
        public async Task QueryAsync_ParquetOutputError()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlockBlobClient blockBlobClient = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));

            // Act
            string query = @"select * from blobstorage where id < 1;";
            BlobQueryOptions options = new BlobQueryOptions
            {
                OutputTextConfiguration = new BlobQueryParquetTextOptions()
            };

            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                blockBlobClient.QueryAsync(
                    query, options),
                e => Assert.That(e.Message, Is.EqualTo($"{nameof(BlobQueryParquetTextOptions)} can only be used for input serialization.")));
        }

        [RecordedTest]
        [ServiceVersion(Min = BlobClientOptions.ServiceVersion.V2020_02_10)]
        [RetryOnException(TestConstants.QuickQueryRetryCount, typeof(IOException))]
        public async Task QueryAsync_ArrowConfigurationInput()
        {
            // Arrange
            await using DisposingContainer test = await GetTestContainerAsync();
            BlockBlobClient blockBlobClient = InstrumentClient(test.Container.GetBlockBlobClient(GetNewBlobName()));
            Stream stream = CreateDataStream(Constants.KB);
            await blockBlobClient.UploadAsync(stream);

            string query = @"SELECT _2 from BlobStorage WHERE _1 > 250;";
            BlobQueryOptions options = new BlobQueryOptions
            {
                InputTextConfiguration = new BlobQueryArrowOptions
                {
                    Schema = new List<BlobQueryArrowField>()
                    {
                        new BlobQueryArrowField
                        {
                            Type = BlobQueryArrowFieldType.Decimal,
                            Name = "Name",
                            Precision = 4,
                            Scale = 2
                        }
                    }
                }
            };

            // Act
            await TestHelper.AssertExpectedExceptionAsync<ArgumentException>(
                blockBlobClient.QueryAsync(
                query,
                options: options),
                e => Assert.That(e.Message, Is.EqualTo($"{nameof(BlobQueryArrowOptions)} can only be used for output serialization.")));
        }

        private Stream CreateDataStream(long size)
        {
            MemoryStream stream = new MemoryStream();
            byte[] rowData = Encoding.UTF8.GetBytes("100,200,300,400\n300,400,500,600\n");
            long blockLength = 0;
            while (blockLength < size)
            {
                stream.Write(rowData, 0, rowData.Length);
                blockLength += rowData.Length;
            }

            stream.Seek(0, SeekOrigin.Begin);
            return stream;
        }

        public IEnumerable<AccessConditionParameters> AccessConditions_Data
            => new[]
            {
                new AccessConditionParameters(),
                new AccessConditionParameters { IfModifiedSince = OldDate },
                new AccessConditionParameters { IfUnmodifiedSince = NewDate },
                new AccessConditionParameters { Match = ReceivedETag },
                new AccessConditionParameters { NoneMatch = GarbageETag },
                new AccessConditionParameters { LeaseId = ReceivedLeaseId }
            };

        public IEnumerable<AccessConditionParameters> GetAccessConditionsFail_Data(string garbageLeaseId)
            => new[]
            {
                new AccessConditionParameters { IfModifiedSince = NewDate },
                new AccessConditionParameters { IfUnmodifiedSince = OldDate },
                new AccessConditionParameters { Match = GarbageETag },
                new AccessConditionParameters { NoneMatch = ReceivedETag },
                new AccessConditionParameters { LeaseId = garbageLeaseId },
             };

        private RequestConditions BuildRequestConditions(
            AccessConditionParameters parameters)
            => new RequestConditions
            {
                IfModifiedSince = parameters.IfModifiedSince,
                IfUnmodifiedSince = parameters.IfUnmodifiedSince,
                IfMatch = parameters.Match != null ? new ETag(parameters.Match) : default(ETag?),
                IfNoneMatch = parameters.NoneMatch != null ? new ETag(parameters.NoneMatch) : default(ETag?)
            };

        private BlobRequestConditions BuildAccessConditions(
            AccessConditionParameters parameters,
            bool lease = true)
        {
            var accessConditions = BuildRequestConditions(parameters).ToBlobRequestConditions();
            if (lease)
            {
                accessConditions.LeaseId = parameters.LeaseId;
            }
            return accessConditions;
        }

        public class AccessConditionParameters
        {
            public DateTimeOffset? IfModifiedSince { get; set; }
            public DateTimeOffset? IfUnmodifiedSince { get; set; }
            public string Match { get; set; }
            public string NoneMatch { get; set; }
            public string LeaseId { get; set; }
        }
    }
}
