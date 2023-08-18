// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Storage.Test.Shared;
using Microsoft.Net.Http.Headers;
using NUnit.Framework;

namespace Azure.Storage.Blobs.Tests
{
    public class StorageTelemetryTests : BlobTestBase
    {
        private const string CseV1UserAgentString = "azstorage-clientsideencryption/1.0";
        private const string CseV2UserAgentString = "azstorage-clientsideencryption/2.0";

        private ClientBuilder<BlobServiceClient, BlobClientOptions> ClientBuilder { get; }

        public StorageTelemetryTests(bool async, BlobClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, RecordedTestMode.Live /* RecordedTestMode.Record /* to re-record */)
        {
            ClientBuilder = ClientBuilderExtensions.GetNewBlobsClientBuilder(Tenants, serviceVersion);
        }

        private Action<Request> GetCheckAzFeatureUserAgent(ClientSideEncryptionVersion version)
        {
            bool IsCommitBlockList(Request request)
                => request.Method == RequestMethod.Put && request.Uri.Query.Contains("comp=blocklist");
            bool IsPutBlob(Request request)
                => request.Method == RequestMethod.Put && !request.Uri.Query.Contains("comp");
            bool IsDownloadRange(Request request)
                => request.Method == RequestMethod.Get && !request.Uri.Query.Contains("comp");
            return req =>
            {
                if (!req.Headers.TryGetValue(HeaderNames.UserAgent, out string userAgent))
                {
                    Assert.Fail("Missing User-Agent header in request.");
                }
                string expected = version switch
                {
#pragma warning disable CS0618 // Type or member is obsolete
                    ClientSideEncryptionVersion.V1_0 => CseV1UserAgentString,
#pragma warning restore CS0618 // Type or member is obsolete
                    ClientSideEncryptionVersion.V2_0 => CseV2UserAgentString,
                    _ => throw new ArgumentException("Bad CSE version"),
                };

                if (IsCommitBlockList(req) || IsPutBlob(req) || IsDownloadRange(req))
                {
                    Assert.That(userAgent, Does.Contain(expected));
                }
                else
                {
                    Assert.That(userAgent, Does.Not.Contain(expected));
                }
            };
        }

        [Test]
        [LiveOnly]
        public async Task ClientSideEncryption_Upload(
#pragma warning disable CS0618 // Type or member is obsolete
            [Values(ClientSideEncryptionVersion.V2_0, ClientSideEncryptionVersion.V1_0)] ClientSideEncryptionVersion cseVersion,
#pragma warning restore CS0618 // Type or member is obsolete
            [Values(true, false)] bool split)
        {
            await using DisposingContainer disposingContainer = await ClientBuilder.GetTestContainerAsync();

            AssertMessageContentsPolicy assertionPolicy = new(checkRequest: GetCheckAzFeatureUserAgent(cseVersion))
            {
                CheckRequest = true
            };
            Specialized.SpecializedBlobClientOptions clientOptions = new()
            {
                ClientSideEncryption = new(cseVersion)
                {
                    KeyEncryptionKey = this.GetIKeyEncryptionKey(default).Object,
                    KeyWrapAlgorithm = ClientSideEncryptionTestExtensions.s_algorithmName
                }
            };
            clientOptions.AddPolicy(assertionPolicy, HttpPipelinePosition.BeforeTransport);

            BlobClient encryptedClient = InstrumentClient(new BlobClient(
                disposingContainer.Container.GetBlobClient(GetNewBlobName()).Uri,
                ClientBuilder.Tenants.GetNewSharedKeyCredentials(),
                clientOptions));

            const int dataSize = Constants.KB;
            int chunkSize = split ? dataSize / 2 : dataSize * 2;
            StorageTransferOptions transferOptions = new()
            {
                InitialTransferSize = chunkSize,
                MaximumTransferSize = chunkSize,
            };

            // Assertions are in assertionPolicy
            await encryptedClient.UploadAsync(
                BinaryData.FromBytes(GetRandomBuffer(Constants.KB)),
                new Models.BlobUploadOptions()
                {
                    TransferOptions = transferOptions
                });
        }
    }
}
