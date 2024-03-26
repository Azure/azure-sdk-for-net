// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;

namespace Azure.AI.Translator.Document.Tests
{
    public abstract class DocumentTranslationLiveTestBase : RecordedTestBase<DocumentTranslationTestEnvironment>
    {
        public DocumentTranslationLiveTestBase(bool isAsync)
            : base(isAsync)
        {
            SanitizedHeaders.Add("Ocp-Apim-Subscription-Key");
        }

        public SingleDocumentTranslationClient GetClient(
            AzureKeyCredential credential = default,
            SingleDocumentTranslationClientOptions options = default,
            bool useTokenCredential = default)
        {
            var endpoint = new Uri(TestEnvironment.Endpoint);
            options ??= new SingleDocumentTranslationClientOptions()
            {
                Diagnostics =
                {
                    LoggedHeaderNames = { "x-ms-request-id", "X-RequestId", "apim-request-id" },
                    IsLoggingContentEnabled = true
                }
            };

            if (useTokenCredential)
            {
                return InstrumentClient(new SingleDocumentTranslationClient(endpoint, TestEnvironment.Credential, InstrumentClientOptions(options)));
            }
            else
            {
                credential ??= new AzureKeyCredential(TestEnvironment.ApiKey);
                return InstrumentClient(new SingleDocumentTranslationClient(endpoint, credential, InstrumentClientOptions(options)));
            }
        }
    }
}
