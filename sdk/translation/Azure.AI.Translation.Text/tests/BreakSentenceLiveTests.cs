// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Translation.Text.Tests
{
    public partial class BreakSentenceLiveTests : TextTranslationLiveTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TranslationLiveTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public BreakSentenceLiveTests(bool isAsync)
            : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task BreakSentenceWithAutoDetect()
        {
            TextTranslationClient client = GetClient();
            string inputText = "hello world";
            var response = await client.FindSentenceBoundariesAsync(inputText).ConfigureAwait(false);

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("en", response.Value[0].DetectedLanguage.Language);
            Assert.LessOrEqual(0.5, response.Value.FirstOrDefault().DetectedLanguage.Confidence);
            Assert.AreEqual(11, response.Value[0].SentencesLengths[0]);
        }

        [RecordedTest]
        public async Task BreakSentenceWithLanguage()
        {
            TextTranslationClient client = GetClient();
            IEnumerable<string> inputText = new[]
            {
                "รวบรวมแผ่นคำตอบ ระยะเวลาของโครงการ วิธีเลือกชายในฝัน หมายเลขซีเรียลของระเบียน วันที่สิ้นสุดของโครงการเมื่อเสร็จสมบูรณ์ ปีที่มีการรวบรวม ทุกคนมีวัฒนธรรมและวิธีคิดเหมือนกัน ได้รับโทษจำคุกตลอดชีวิตใน ฉันลดได้ถึง 55 ปอนด์ได้อย่างไร  ฉันคิดว่าใครๆ ก็ต้องการกำหนดเมนูอาหารส่วนบุคคล"
            };
            var response = await client.FindSentenceBoundariesAsync(inputText, language: "th").ConfigureAwait(false);

            Assert.AreEqual(200, response.GetRawResponse().Status);
            int[] expectedLengths = new[] { 78, 41, 110, 46 };
            for (int i = 0; i < expectedLengths.Length; i++)
            {
                Assert.AreEqual(expectedLengths[i], response.Value[0].SentencesLengths[i]);
            }
        }

        [RecordedTest]
        public async Task BreakSentenceWithLanguageAndScript()
        {
            TextTranslationClient client = GetClient();
            IEnumerable<string> inputText = new[]
            {
                "zhè shì gè cè shì。"
            };
            var response = await client.FindSentenceBoundariesAsync(inputText, language: "zh-Hans", script: "Latn").ConfigureAwait(false);

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(18, response.Value[0].SentencesLengths[0]);
        }

        [RecordedTest]
        public async Task BreakSentenceWithMultipleLanguages()
        {
            TextTranslationClient client = GetClient();
            IEnumerable<string> inputText = new[]
            {
                "hello world",
                "العالم هو مكان مثير جدا للاهتمام"
            };
            var response = await client.FindSentenceBoundariesAsync(inputText).ConfigureAwait(false);

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("en", response.Value[0].DetectedLanguage.Language);
            Assert.AreEqual("ar", response.Value[1].DetectedLanguage.Language);
            Assert.AreEqual(11, response.Value[0].SentencesLengths[0]);
            Assert.AreEqual(32, response.Value[1].SentencesLengths[0]);
        }
    }
}
