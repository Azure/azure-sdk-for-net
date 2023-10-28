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
    public class ImageAnalysisTestEnvironment: TestEnvironment
    {
        private static class Constants
        {
            public const string EndpointVariable = "IMAGEANALYSIS_ENDPOINT";
            public const string CogServicesVisionKeyVariable = "IMAGEANALYSIS_KEY";
            public const string ImageInputPathVariable = "IMAGEANALYSIS_TEST_IMAGE_INPUT_PATH";
            public const string ImageInputUrlVariable = "IMAGEANALYSIS_TEST_IMAGE_INPUT_URL";

            public static AzureLocation Location = AzureLocation.EastUS;
        }

        public string Endpoint => GetRecordedVariable(Constants.EndpointVariable);
        public string CogServicesVisionKey => GetOptionalVariable(Constants.CogServicesVisionKeyVariable);

        public string TestImageInputPath => GetOptionalVariable(Constants.ImageInputPathVariable);
        public Uri TestImageInputUrl => new Uri(GetOptionalVariable(Constants.ImageInputUrlVariable));
    }
}
