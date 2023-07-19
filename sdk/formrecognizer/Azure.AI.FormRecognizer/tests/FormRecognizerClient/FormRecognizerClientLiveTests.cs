// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.FormRecognizer.Tests
{
    /// <summary>
    /// The suite of tests for the <see cref="FormRecognizerClient"/> class.
    /// </summary>
    /// <remarks>
    /// These tests have a dependency on live Azure services and may incur costs for the associated
    /// Azure subscription.
    /// </remarks>
    [ClientTestFixture(
    FormRecognizerClientOptions.ServiceVersion.V2_0,
    FormRecognizerClientOptions.ServiceVersion.V2_1)]
    public class FormRecognizerClientLiveTests : FormRecognizerLiveTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FormRecognizerClientLiveTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public FormRecognizerClientLiveTests(bool isAsync, FormRecognizerClientOptions.ServiceVersion serviceVersion)
            : base(isAsync, serviceVersion)
        {
        }

        [RecordedTest]
        [ServiceVersion(Min = FormRecognizerClientOptions.ServiceVersion.V2_1)]
        public void FormRecognizerClientCannotAuthenticateWithFakeApiKey()
        {
            var client = CreateFormRecognizerClient(apiKey: "fakeKey");

            using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.ReceiptJpg);
            using (Recording.DisableRequestBodyRecording())
            {
                Assert.ThrowsAsync<RequestFailedException>(async () => await client.StartRecognizeContentAsync(stream));
            }
        }

        [RecordedTest]
        [ServiceVersion(Max = FormRecognizerClientOptions.ServiceVersion.V2_0)]
        public void StartRecognizeBusinessCardsWithV2()
        {
            var client = CreateFormRecognizerClient();
            var uri = FormRecognizerTestEnvironment.CreateUri(TestFile.BusinessCardJpg);

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.StartRecognizeBusinessCardsFromUriAsync(uri));
            Assert.AreEqual("404", ex.ErrorCode);
        }

        [RecordedTest]
        [ServiceVersion(Max = FormRecognizerClientOptions.ServiceVersion.V2_0)]
        public void StartRecognizeIdentityDocumentsWithV2()
        {
            var client = CreateFormRecognizerClient();
            var uri = FormRecognizerTestEnvironment.CreateUri(TestFile.DriverLicenseJpg);

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.StartRecognizeIdentityDocumentsFromUriAsync(uri));
            Assert.AreEqual("404", ex.ErrorCode);
        }

        [RecordedTest]
        [ServiceVersion(Max = FormRecognizerClientOptions.ServiceVersion.V2_0)]
        public void StartRecognizeInvoicesWithV2()
        {
            var client = CreateFormRecognizerClient();
            var uri = FormRecognizerTestEnvironment.CreateUri(TestFile.InvoiceJpg);

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.StartRecognizeInvoicesFromUriAsync(uri));
            Assert.AreEqual("404", ex.ErrorCode);
        }
    }
}
