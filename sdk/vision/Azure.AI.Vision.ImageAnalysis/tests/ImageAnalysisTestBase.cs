// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;

using NUnit.Framework;

namespace Azure.AI.Vision.ImageAnalysis.Tests
{
    public abstract class ImageAnalysisTestBase : RecordedTestBase<ImageAnalysisTestEnvironment>
    {
        protected ImageAnalysisTestBase(bool isAsync, RecordedTestMode? mode = null) : base(isAsync, mode)
        {
            HeaderRegexSanitizers.Add(new HeaderRegexSanitizer("Ocp-Apim-Subscription-Key", "***********"));
            UriRegexSanitizers.Add(new UriRegexSanitizer(@"https:\/\/[a-zA-Z0-9-]*\.cognitiveservices.azure.com/", @"https://ResourceName.cognitiveservices.azure.com/"));
        }

        protected ImageAnalysisClient GetClientWithKey(string apiKey = null, ImageAnalysisClientOptions options = null)
        {
            var credential = string.IsNullOrEmpty(apiKey) ? GetCognitiveVisionApiKeyCredential() : new AzureKeyCredential(apiKey);

            options = options ?? new ImageAnalysisClientOptions
            {
                Diagnostics = { IsLoggingContentEnabled = true }
            };
            var client = InstrumentClient(new ImageAnalysisClient(new Uri(TestEnvironment.Endpoint), credential, InstrumentClientOptions(options)));
            return client;
        }

        protected AzureKeyCredential GetCognitiveVisionApiKeyCredential()
        {
            if (Mode == RecordedTestMode.Playback)
            {
                return new AzureKeyCredential("placeholder");
            }
            else if (!string.IsNullOrEmpty(TestEnvironment.CogServicesVisionKey))
            {
                return new AzureKeyCredential(TestEnvironment.CogServicesVisionKey);
            }
            else
            {
                throw new InvalidOperationException(
                    "No Azure Cognitive Vision API key found. Please set the appropriate environment variable to "
                    + "use this value.");
            }
        }

        protected Stream GetTestImageStream()
        {
            Recording.DisableRequestBodyRecording();
            if (Mode == RecordedTestMode.Playback)
            {
                return new MemoryStream();
            }

            return File.OpenRead(TestEnvironment.TestImageInputPath);
        }
    }
}
