// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Azure.AI.FormRecognizer.Models;
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
        [ServiceVersion(Min = FormRecognizerClientOptions.ServiceVersion.V2_1_Preview_3)]
        public void FormRecognizerClientCannotAuthenticateWithFakeApiKey()
        {
            var client = CreateFormRecognizerClient(apiKey: "fakeKey");

            using var stream = FormRecognizerTestEnvironment.CreateStream(TestFile.ReceiptJpg);
            using (Recording.DisableRequestBodyRecording())
            {
                Assert.ThrowsAsync<RequestFailedException>(async () => await client.StartRecognizeContentAsync(stream));
            }
        }
    }
}
