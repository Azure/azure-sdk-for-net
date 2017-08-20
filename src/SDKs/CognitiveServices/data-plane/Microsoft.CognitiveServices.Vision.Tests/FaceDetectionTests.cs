using Microsoft.CognitiveServices.Vision.Face;
using Microsoft.CognitiveServices.Vision.Face.Models;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace FaceSDK.Tests
{
    public class FaceDetectionTests : BaseTests
    {
        [Fact]
        public void FaceDetection()
        {
            FaceAPI client = GetClient();
            using (FileStream stream = new FileStream("TestImages\\detection1.jpg", FileMode.Open))
            {
                IList<DetectedFace> faceList = client.Face.DetectInStream(stream);
                Assert.Equal(1, faceList.Count);
            }
        }
    }
}
