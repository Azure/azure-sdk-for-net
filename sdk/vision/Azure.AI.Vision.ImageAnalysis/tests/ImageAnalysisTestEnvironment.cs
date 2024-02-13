// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Azure.Core;
using Azure.Core.TestFramework;

namespace Azure.AI.Vision.ImageAnalysis.Tests
{
    public class ImageAnalysisTestEnvironment : TestEnvironment
    {
        private static class Constants
        {
            public const string EndpointVariable = "VISION_ENDPOINT";
            public const string CogServicesVisionKeyVariable = "VISION_KEY";
            public const string ImageInputPathVariable = "IMAGEANALYSIS_TEST_IMAGE_INPUT_PATH";
            public const string ImageInputUrlVariable = "IMAGEANALYSIS_TEST_IMAGE_INPUT_URL";
        }

        public string Endpoint => GetRecordedVariable(Constants.EndpointVariable);
        public string CogServicesVisionKey => GetOptionalVariable(Constants.CogServicesVisionKeyVariable);

        public string TestImageInputPath => GetOptionalVariable(Constants.ImageInputPathVariable) ?? "image-analysis-sample.jpg";
        public Uri TestImageInputUrl => new Uri(GetOptionalVariable(Constants.ImageInputUrlVariable) ?? "https://aka.ms/azsdk/image-analysis/sample.jpg");
    }
}
