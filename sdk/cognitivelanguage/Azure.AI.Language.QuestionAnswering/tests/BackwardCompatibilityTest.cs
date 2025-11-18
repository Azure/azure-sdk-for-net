// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Threading.Tasks;
using NUnit.Framework;
using Azure.AI.Language.QuestionAnswering;

namespace Azure.AI.Language.QuestionAnswering.Tests
{
    /// <summary>
    /// Tests to ensure backward compatibility with older versions of the SDK.
    /// </summary>
    public class BackwardCompatibilityTest
    {
        /// <summary>
        /// test GetAnswersFromTextAsync backward compatibility
        /// </summary>
        [Test]
        public async Task GetAnswersFromTextAsync_BackwardCompatibility()
        {
            QuestionAnsweringClientOptions clientOptions = new QuestionAnsweringClientOptions();

            QuestionAnsweringClient client = new QuestionAnsweringClient(new("https://qnatestqi.cognitiveservices.azure.com/"), new AzureKeyCredential("bf99f2cc197f414b8780e566f750c552"));

            Response<AnswersFromTextResult> response = await client.GetAnswersFromTextAsync(
                            "How long it takes to charge surface?",
                            new[]
                            {
                    "Power and charging. It takes two to four hours to charge the Surface Pro 4 battery fully from an empty state. " +
                    "It can take longer if you’re using your Surface for power-intensive activities like gaming or video streaming while you’re charging it.",

                    "You can use the USB port on your Surface Pro 4 power supply to charge other devices, like a phone, while your Surface charges. " +
                    "The USB port on the power supply is only for charging, not for data transfer. If you want to use a USB device, plug it into the USB port on your Surface.",
                            }).ConfigureAwait(false);
            Assert.NotNull(response.Value);
            Assert.That(response.Value.Answers.Count, Is.GreaterThan(0));
        }
    }
}
