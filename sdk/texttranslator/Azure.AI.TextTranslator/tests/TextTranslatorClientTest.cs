// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.TextTranslator.Tests
{
    public class TextTranslatorClientTest: RecordedTestBase<TextTranslatorClientTestEnvironment>
    {
        public TextTranslatorClientTest(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task TestGetLanguages()
        {
            var client = new TranslatorClient(new Uri("https://api.cognitive.microsofttranslator.com"));
            var langs = await client.GetLanguagesAsync(cancellationToken: CancellationToken.None).ConfigureAwait(false);

            Assert.AreEqual(200, langs.GetRawResponse().Status);
            Assert.IsTrue(langs.Value.Translation.TryGetValue("cs", out var language));
            Assert.IsNotNull(language);
        }
    }
}
