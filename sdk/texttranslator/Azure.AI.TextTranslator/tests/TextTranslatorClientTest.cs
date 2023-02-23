// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.TextTranslator.Models;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Identity;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Azure.AI.TextTranslator.Tests
{
    public class TextTranslatorClientTest: RecordedTestBase<TextTranslatorClientTestEnvironment>
    {
        public TextTranslatorClientTest(bool isAsync) : base(isAsync)
        {
        }

        /* please refer to https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/template/Azure.Template/tests/TemplateClientLiveTests.cs to write tests. */

        [RecordedTest]
        public async Task TestGetLanguages()
        {
            var client = new TranslatorClient(new Uri("https://api.cognitive.microsofttranslator.com"));
            var langs = await client.GetLanguagesAsync(cancellationToken: CancellationToken.None).ConfigureAwait(false);

            Assert.AreEqual(200, langs.GetRawResponse().Status);
            Assert.IsTrue(langs.Value.Translation.TryGetValue("cs", out var language));
            Assert.IsNotNull(language);
        }

        [RecordedTest]
        public async Task TestGlobalEndpointTranslate()
        {
            var key = new AzureKeyCredential("");
            var client = new TranslatorClient(new Uri("https://api.cognitive.microsofttranslator.com"), key, "westus2");
            var translate = await client.TranslateAsync(new[] { "cs" }, new object[] { new InputText { Text = "This is a Test" } }).ConfigureAwait(false);

            Assert.AreEqual(200, translate.GetRawResponse().Status);
            Assert.AreEqual(1, translate.Value.Count);
        }

        [RecordedTest]
        public async Task TestCustomEndpointTranslate()
        {
            var key = new AzureKeyCredential("");
            var client = new TranslatorClient(new Uri("https://mimat-cus-white.cognitiveservices.azure.com"), key);
            var translate = await client.TranslateAsync(new[] { "cs" }, new object[] { new InputText { Text = "This is a Test" } }).ConfigureAwait(false);

            Assert.AreEqual(200, translate.GetRawResponse().Status);
            Assert.AreEqual(1, translate.Value.Count);
        }

        [RecordedTest]
        public async Task TestGlobalEndpointTokenTranslate()
        {
            TokenCredential token = new StaticAccessTokenCredential(new AccessToken("", DateTimeOffset.Now.AddDays(1)));

            var client = new TranslatorClient(new Uri("https://api.cognitive.microsofttranslator.com"), token);
            var translate = await client.TranslateAsync(new[] { "cs" }, new object[] { new InputText { Text = "This is a Test" } }).ConfigureAwait(false);

            Assert.AreEqual(200, translate.GetRawResponse().Status);
            Assert.AreEqual(1, translate.Value.Count);
        }

        #region Helpers

        private static BinaryData GetContentFromResponse(Response r)
        {
            // Workaround azure/azure-sdk-for-net#21048, which prevents .Content from working when dealing with responses
            // from the playback system.

            MemoryStream ms = new MemoryStream();
            r.ContentStream.CopyTo(ms);
            return new BinaryData(ms.ToArray());
        }
        #endregion
    }
}
