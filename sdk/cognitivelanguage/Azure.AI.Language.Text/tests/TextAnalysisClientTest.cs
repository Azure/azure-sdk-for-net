// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Language.Text.Tests
{
    public class TextAnalysisClientTest : RecordedTestBase<TextAnalysisClientTestEnvironment>
    {
        public TextAnalysisClientTest(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public void TextAnalysisClientEndpointNull()
        {
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(
                () => new TextAnalysisClient(null, (AzureKeyCredential)null));
            Assert.AreEqual("endpoint", ex.ParamName);
        }

        [Test]
        public void TextAnalysisClientCredentialNull()
        {
            Uri endpoint = new("https://test.cognitive.microsoft.com", UriKind.Absolute);

            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(
                () => new TextAnalysisClient(endpoint, (AzureKeyCredential)null));
            Assert.AreEqual("credential", ex.ParamName);
        }

        [Test]
        public void TextAnalysisClientEndpointNullUsingTokenCredential()
        {
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(
                () => new TextAnalysisClient(null, (TokenCredential)null));
            Assert.AreEqual("endpoint", ex.ParamName);
        }

        [Test]
        public void TextAnalysisClientCredentialNullUsingTokenCredential()
        {
            Uri endpoint = new("https://test.cognitive.microsoft.com", UriKind.Absolute);

            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(
                () => new TextAnalysisClient(endpoint, (TokenCredential)null));
            Assert.AreEqual("credential", ex.ParamName);
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
