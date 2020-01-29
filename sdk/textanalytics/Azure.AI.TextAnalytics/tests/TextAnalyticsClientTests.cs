// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;
using Azure.Core.Testing;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.AI.TextAnalytics.Tests
{
    public class TextAnalyticsClientTests : ClientTestBase
    {
        public TextAnalyticsClientTests(bool isAsync) : base(isAsync)
        {
            TextAnalyticsClientOptions options = new TextAnalyticsClientOptions
            {
                Transport = new MockTransport(),
            };

             Client = InstrumentClient(new TextAnalyticsClient(new Uri("http://localhost"), new DefaultAzureCredential(), options));
        }

        public TextAnalyticsClient Client { get; set; }

        [Test]
        public void CreateClientArgumentValidation()
        {
            var uri = new Uri("http://localhost");

            Assert.Throws<ArgumentNullException>(() => new TextAnalyticsClient(null, new TextAnalyticsSubscriptionKeyCredential("subscriptionKey")));
            Assert.Throws<ArgumentNullException>(() => new TextAnalyticsClient(uri, (TextAnalyticsSubscriptionKeyCredential)null));
            Assert.Throws<ArgumentNullException>(() => new TextAnalyticsClient(uri, (TokenCredential)null));
            Assert.Throws<ArgumentNullException>(() => new TextAnalyticsClient(null, new DefaultAzureCredential()));
        }

        [Test]
        public void DetectLanguageArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.DetectLanguageAsync(null));
        }

        [Test]
        public void DetectLanguagesArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.DetectLanguagesAsync((List<string>)null));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.DetectLanguagesAsync(null, new TextAnalyticsRequestOptions()));
        }

        [Test]
        public void RecognizeEntitiesArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.RecognizeEntitiesAsync((string)null));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.RecognizeEntitiesAsync((List<string>)null));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.RecognizeEntitiesAsync(null, new TextAnalyticsRequestOptions()));
        }

        [Test]
        public void AnalyzeSentimentArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.AnalyzeSentimentAsync((string)null));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.AnalyzeSentimentAsync((List<string>)null));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.AnalyzeSentimentAsync(null, new TextAnalyticsRequestOptions()));
        }

        [Test]
        public void ExtractKeyPhrasesArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.ExtractKeyPhrasesAsync((string)null));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.ExtractKeyPhrasesAsync((List<string>)null));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.ExtractKeyPhrasesAsync(null, new TextAnalyticsRequestOptions()));
        }

        [Test]
        public void RecognizePiiEntitiesArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.RecognizePiiEntitiesAsync((string)null));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.RecognizePiiEntitiesAsync((List<string>)null));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.RecognizePiiEntitiesAsync(null, new TextAnalyticsRequestOptions()));
        }

        [Test]
        public void RecognizeLinkedEntitiesArgumentValidation()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.RecognizeLinkedEntitiesAsync((string)null));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.RecognizeLinkedEntitiesAsync((List<string>)null));
            Assert.ThrowsAsync<ArgumentNullException>(() => Client.RecognizeLinkedEntitiesAsync(null, new TextAnalyticsRequestOptions()));
        }

        [Test]
        public void ConvertToDocumentInputTest()
        {
            string input = "This is a test";
            var expectedDocument = new TextDocumentInput("0", input)
            {
                Language = "en"
            };

            TextDocumentInput textInput = Client.ConvertToDocumentInput(input, null);
            Assert.IsTrue(CompareInputObject(expectedDocument, textInput));

            textInput = Client.ConvertToDocumentInput(input, "es");
            expectedDocument.Language = "es";
            Assert.IsTrue(CompareInputObject(expectedDocument, textInput));

            textInput = Client.ConvertToDocumentInput(input, "es", 2);
            var expectedDocument2 = new TextDocumentInput("2", input)
            {
                Language = "es"
            };
            Assert.IsTrue(CompareInputObject(expectedDocument2, textInput));
        }

        [Test]
        public void ConvertToDocumentInputsTest()
        {
            var inputText0 = "This is a document";
            var inputText1 = "that we are using";
            var inputText2 = "for tests.";
            var language = "en";

            var expectedList = new List<TextDocumentInput>
            {
                new TextDocumentInput("0", inputText0)
                {
                    Language = language
                },
                new TextDocumentInput("1", inputText1)
                {
                    Language = language
                },
                new TextDocumentInput("2", inputText2)
                {
                    Language = language
                }
            };

            var inputList = new List<string> { inputText0, inputText1, inputText2 };
            List<TextDocumentInput> result = Client.ConvertToDocumentInputs(inputList, language);
            Assert.IsTrue(CompareListInputObject(expectedList, result));
        }

        [Test]
        public void ConvertToDetectLanguageInputTest()
        {
            string input = "This is a test";
            var expectedDocument = new DetectLanguageInput("0", input)
            {
                CountryHint = "us"
            };

            DetectLanguageInput textInput = Client.ConvertToDetectLanguageInput(input, null);
            Assert.IsTrue(CompareInputObject(expectedDocument, textInput));

            textInput = Client.ConvertToDetectLanguageInput(input, "fr");
            expectedDocument.CountryHint = "fr";
            Assert.IsTrue(CompareInputObject(expectedDocument, textInput));

            textInput = Client.ConvertToDetectLanguageInput(input, "fr", 2);
            var expectedDocument2 = new DetectLanguageInput("2", input)
            {
                CountryHint = "fr"
            };
            Assert.IsTrue(CompareInputObject(expectedDocument2, textInput));
        }

        [Test]
        public void ConvertToDetectLanguageInputsTest()
        {
            var inputText0 = "Hola mundo";
            var inputText1 = "Este es un test de prueba";
            var inputText2 = "En español";
            var countryHint = "co";

            var expectedList = new List<DetectLanguageInput>
            {
                new DetectLanguageInput("0", inputText0)
                {
                    CountryHint = countryHint
                },
                new DetectLanguageInput("1", inputText1)
                {
                    CountryHint = countryHint
                },
                new DetectLanguageInput("2", inputText2)
                {
                    CountryHint = countryHint
                }
            };

            var inputList = new List<string> { inputText0, inputText1, inputText2 };
            List<DetectLanguageInput> result = Client.ConvertToDetectLanguageInputs(inputList, countryHint);
            Assert.IsTrue(CompareListInputObject(expectedList, result));
        }

        private bool CompareListInputObject(List<TextDocumentInput> list1, List<TextDocumentInput> list2)
        {
            if (list1.Count != list2.Count)
                return false;
            for (int i = 0; i < list1.Count; i++)
            {
                if (!CompareInputObject(list1[i], list2[i]))
                    return false;
            }
            return true;
        }

        private bool CompareListInputObject(List<DetectLanguageInput> list1, List<DetectLanguageInput> list2)
        {
            if (list1.Count != list2.Count)
                return false;
            for (int i = 0; i < list1.Count; i++)
            {
                if (!CompareInputObject(list1[i], list2[i]))
                    return false;
            }
            return true;
        }

        private bool CompareInputObject(TextDocumentInput tdi1, TextDocumentInput tdi2)
        {
            if (!tdi1.Id.Equals(tdi2.Id))
                return false;
            if (!tdi1.Language.Equals(tdi2.Language))
                return false;
            if (!tdi1.Text.Equals(tdi2.Text))
                return false;
            return true;
        }

        private bool CompareInputObject(DetectLanguageInput tdi1, DetectLanguageInput tdi2)
        {
            if (!tdi1.Id.Equals(tdi2.Id))
                return false;
            if (!tdi1.CountryHint.Equals(tdi2.CountryHint))
                return false;
            if (!tdi1.Text.Equals(tdi2.Text))
                return false;
            return true;
        }
    }
}
