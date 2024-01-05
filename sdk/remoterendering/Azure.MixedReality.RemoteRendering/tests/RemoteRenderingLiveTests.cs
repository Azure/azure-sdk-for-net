// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.MixedReality.RemoteRendering.Tests
{
    public class RemoteRenderingLiveTests : RecordedTestBase<RemoteRenderingTestEnvironment>
    {
        public RemoteRenderingLiveTests(bool isAsync) :
            base(isAsync/*, RecordedTestMode.Record*/)
        {
            // TODO (39914): enable after Azure.MixedReality.Authentication is released
            TestDiagnostics = false;
        }

        [RecordedTest]
        public async Task TestSimpleConversion()
        {
            var client = GetClient();

            Uri storageUri = new Uri($"https://{TestEnvironment.StorageAccountName}.blob.core.windows.net/{TestEnvironment.BlobContainerName}");

            AssetConversionInputOptions input = new AssetConversionInputOptions(storageUri, "testBox.fbx")
            {
                // We use SAS for live testing, as there can be a delay before DRAM-based access is available for new accounts.
                StorageContainerReadListSas = TestEnvironment.SasToken,
                BlobPrefix = "Input"
            };
            AssetConversionOutputOptions output = new AssetConversionOutputOptions(storageUri)
            {
                StorageContainerWriteSas = TestEnvironment.SasToken,
                BlobPrefix = "Output"
            };
            AssetConversionOptions conversionOptions = new AssetConversionOptions(input, output);

            string conversionId = Recording.Random.NewGuid().ToString();

            AssetConversionOperation conversionOperation = await client.StartConversionAsync(conversionId, conversionOptions);
            Assert.AreEqual(conversionId, conversionOperation.Id);
            Assert.AreEqual(conversionOptions.InputOptions.RelativeInputAssetPath, conversionOperation.Value.Options.InputOptions.RelativeInputAssetPath);
            Assert.AreNotEqual(AssetConversionStatus.Failed, conversionOperation.Value.Status);

            AssetConversion conversion = await client.GetConversionAsync(conversionId);
            Assert.AreEqual(conversion.ConversionId, conversionId);
            Assert.AreNotEqual(AssetConversionStatus.Failed, conversion.Status);

            AssetConversion conversion2 = await conversionOperation.WaitForCompletionAsync();
            Assert.AreEqual(conversionId, conversion2.ConversionId);
            Assert.AreEqual(AssetConversionStatus.Succeeded, conversion2.Status);
            Assert.IsTrue(conversionOperation.Value.Output.OutputAssetUri.EndsWith("Output/testBox.arrAsset"));

            bool foundConversion = false;
            await foreach (var s in client.GetConversionsAync())
            {
                if (s.ConversionId == conversionId)
                {
                    foundConversion = true;
                }
            }
            Assert.IsTrue(foundConversion);
        }

        [RecordedTest]
        public void TestFailedConversionsNoAccess()
        {
            var client = GetClient();

            Uri storageUri = new Uri($"https://{TestEnvironment.StorageAccountName}.blob.core.windows.net/{TestEnvironment.BlobContainerName}");

            AssetConversionInputOptions input = new AssetConversionInputOptions(storageUri, "testBox.fbx")
            {
                // Do not provide SAS access to the container, and assume the test account is not linked to the storage.
                BlobPrefix = "Input"
            };
            AssetConversionOutputOptions output = new AssetConversionOutputOptions(storageUri)
            {
                BlobPrefix = "Output"
            };
            AssetConversionOptions conversionOptions = new AssetConversionOptions(input, output);

            string conversionId = Recording.Random.NewGuid().ToString();

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(() => client.StartConversionAsync(conversionId, conversionOptions));
            Assert.AreEqual(403, ex.Status);
            // Error accessing connected storage account due to insufficient permissions. Check if the Mixed Reality resource has correct permissions assigned
            Assert.IsTrue(ex.Message.ToLower().Contains("storage"));
            Assert.IsTrue(ex.Message.ToLower().Contains("permissions"));
        }

        [RecordedTest]
        public async Task TestFailedConversionsMissingAsset()
        {
            var client = GetClient();

            Uri storageUri = new Uri($"https://{TestEnvironment.StorageAccountName}.blob.core.windows.net/{TestEnvironment.BlobContainerName}");

            AssetConversionInputOptions input = new AssetConversionInputOptions(storageUri, "boxWhichDoesNotExist.fbx")
            {
                // We use SAS for live testing, as there can be a delay before DRAM-based access is available for new accounts.
                StorageContainerReadListSas = TestEnvironment.SasToken,
                BlobPrefix = "Input"
            };
            AssetConversionOutputOptions output = new AssetConversionOutputOptions(storageUri)
            {
                StorageContainerWriteSas = TestEnvironment.SasToken,
                BlobPrefix = "Output"
            };
            AssetConversionOptions conversionOptions = new AssetConversionOptions(input, output);

            string conversionId = Recording.Random.NewGuid().ToString();

            AssetConversionOperation conversionOperation = await client.StartConversionAsync(conversionId, conversionOptions);
            AssetConversion conversion = await conversionOperation.WaitForCompletionAsync();
            Assert.AreEqual(AssetConversionStatus.Failed, conversion.Status);
            Assert.IsNotNull(conversion.Error);
            // Invalid input provided. Check logs in output container for details.
            Assert.IsTrue(conversion.Error.Message.ToLower().Contains("invalid input"));
            Assert.IsTrue(conversion.Error.Message.ToLower().Contains("logs"));
        }

        [RecordedTest]
        public async Task TestSimpleSession()
        {
            var client = GetClient();

            RenderingSessionOptions options = new RenderingSessionOptions(TimeSpan.FromMinutes(4), RenderingServerSize.Standard);

            string sessionId = Recording.Random.NewGuid().ToString();

            StartRenderingSessionOperation startSessionOperation = await client.StartSessionAsync(sessionId, options);
            Assert.IsTrue(startSessionOperation.HasValue);
            Assert.AreEqual(options.Size, startSessionOperation.Value.Size);
            Assert.AreEqual(sessionId, startSessionOperation.Value.SessionId);

            RenderingSession sessionProperties = await client.GetSessionAsync(sessionId);
            Assert.AreEqual(startSessionOperation.Value.CreatedOn, sessionProperties.CreatedOn);

            UpdateSessionOptions updateOptions = new UpdateSessionOptions(TimeSpan.FromMinutes(5));

            RenderingSession updatedSession = await client.UpdateSessionAsync(sessionId, updateOptions);
            Assert.AreEqual(updatedSession.MaxLeaseTime, TimeSpan.FromMinutes(5));

            RenderingSession readyRenderingSession = await startSessionOperation.WaitForCompletionAsync();
            Assert.IsTrue((readyRenderingSession.MaxLeaseTime == TimeSpan.FromMinutes(4)) || (readyRenderingSession.MaxLeaseTime == TimeSpan.FromMinutes(5)));
            Assert.IsNotNull(readyRenderingSession.Host);
            Assert.IsNotNull(readyRenderingSession.ArrInspectorPort);
            Assert.IsNotNull(readyRenderingSession.HandshakePort);
            Assert.AreEqual(readyRenderingSession.Size, options.Size);

            UpdateSessionOptions updateOptions2 = new UpdateSessionOptions(TimeSpan.FromMinutes(6));
            Assert.AreEqual(TimeSpan.FromMinutes(6), updateOptions2.MaxLeaseTime);

            bool foundSession = false;
            await foreach (var s in client.GetSessionsAsync())
            {
                if (s.SessionId == sessionId)
                {
                    foundSession = true;
                }
            }
            Assert.IsTrue(foundSession);
            await client.StopSessionAsync(sessionId);

            RenderingSession stoppedRenderingSession = await client.GetSessionAsync(sessionId);
            Assert.AreEqual(RenderingSessionStatus.Stopped, stoppedRenderingSession.Status);
        }

        [RecordedTest]
        public void TestFailedSessionRequest()
        {
            var client = GetClient();

            // Make an invalid request (negative lease time).
            RenderingSessionOptions options = new RenderingSessionOptions(TimeSpan.FromMinutes(-4), RenderingServerSize.Standard);

            string sessionId = Recording.Random.NewGuid().ToString();

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(() => client.StartSessionAsync(sessionId, options));
            Assert.AreEqual(400, ex.Status);

            // The maxLeaseTimeMinutes value cannot be negative
            Assert.IsTrue(ex.Message.ToLower().Contains("lease"));
            Assert.IsTrue(ex.Message.ToLower().Contains("negative"));
        }

        private RemoteRenderingClient GetClient()
        {
            Guid accountId = new Guid(TestEnvironment.AccountId);
            string accountDomain = TestEnvironment.AccountDomain;
            Uri serviceEndpoint = new Uri(TestEnvironment.ServiceEndpoint);

            var options = InstrumentClientOptions(new RemoteRenderingClientOptions());

            // We don't need to test communication with the STS Authentication Library, so in playback
            // we use a code-path which does not attempt to contact that service.
            RemoteRenderingClient client;
            if (Mode != RecordedTestMode.Playback)
            {
                AzureKeyCredential accountKeyCredential = new AzureKeyCredential(TestEnvironment.AccountKey);
                client = new RemoteRenderingClient(serviceEndpoint, accountId, accountDomain, accountKeyCredential, options);
            }
            else
            {
                AccessToken artificialToken = new AccessToken("TestToken", DateTimeOffset.MaxValue);
                client = new RemoteRenderingClient(serviceEndpoint, accountId, accountDomain, artificialToken, options);
            }
            return InstrumentClient(client);
        }
    }
}
