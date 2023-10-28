// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Vision.ImageAnalysis.Tests
{
    internal class SegmentTests : ImageAnalysisTestBase
    {
        public SegmentTests(bool isAsync) : base(isAsync)
        { }

        public SegmentTests(bool isAsync, RecordedTestMode? mode = null) : base(isAsync, mode)
        {
        }

        [RecordedTest]
        public async Task SegmentFromUrl()
        {
            var client = GetClientWithKey();

            foreach (var mode in new SegmentationMode[] { SegmentationMode.ForegroundMatting, SegmentationMode.BackgroundRemoval })
            {
                var result = await client.SegmentAsync(mode, new ImageUrl(TestEnvironment.TestImageInputUrl));

                Assert.IsNotNull(result);
                var newImage = result.Value;
                Assert.IsNotNull(newImage);

                ValidateResponse(newImage, mode);
            }
        }

        [RecordedTest]
        public async Task SegmentFromStream()
        {
            var client = GetClientWithKey();

            var fileLocation = TestEnvironment.TestImageInputPath;

            foreach (var mode in new SegmentationMode[] { SegmentationMode.ForegroundMatting, SegmentationMode.BackgroundRemoval })
            {
                using var fileStream = new FileStream(fileLocation, FileMode.Open, FileAccess.Read);
                var result = await client.SegmentAsync(mode, BinaryData.FromStream(fileStream));

                Assert.IsNotNull(result);
                var newImage = result.Value;
                Assert.IsNotNull(newImage);

                ValidateResponse(newImage, mode);
            }
        }

        private void ValidateResponse(BinaryData data, SegmentationMode mode)
        {
            var dataArray = data.ToArray();

            // Validate size of output image
            if (mode == SegmentationMode.BackgroundRemoval)
            {
                Assert.Greater(dataArray.Length, 400000);
            }
            else
            { // segmentationMode == SegmentationMode.FOREGROUND_MATTING
                Assert.Greater(dataArray.Length, 7000);
            }

            byte[] pngHeader = new byte[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A };

            for (int i = 0; i < pngHeader.Length; i++)
            {
                Assert.AreEqual(pngHeader[i], dataArray[i]);
            }
        }
    }
}
