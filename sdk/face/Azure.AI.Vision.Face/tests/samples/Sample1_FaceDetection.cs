// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading.Tasks;
using Azure.AI.Vision.Face.Tests;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Vision.Face.Samples
{
    public partial class Sample1_FaceDetection : FaceSamplesBase
    {
        [Test]
        public void Detect()
        {
            var client = CreateClient();
            var imagePath = FaceTestConstant.LocalMultipleFaceSampleImage;

            #region Snippet:DetectFaces
            using var stream = new FileStream(imagePath, FileMode.Open, FileAccess.Read);

            var detectResponse = client.Detect(
                BinaryData.FromStream(stream),
                FaceDetectionModel.Detection03,
                FaceRecognitionModel.Recognition04,
                returnFaceId: false,
                returnFaceAttributes: new[] { FaceAttributeType.Detection03.HeadPose, FaceAttributeType.Detection03.Mask, FaceAttributeType.Recognition04.QualityForRecognition },
                returnFaceLandmarks: true,
                returnRecognitionModel: true,
                faceIdTimeToLive: 120);

            var detectedFaces = detectResponse.Value;
            Console.WriteLine($"Detected {detectedFaces.Count} face(s) in the image.");
            foreach (var detectedFace in detectedFaces)
            {
                Console.WriteLine($"Face Rectangle: left={detectedFace.FaceRectangle.Left}, top={detectedFace.FaceRectangle.Top}, width={detectedFace.FaceRectangle.Width}, height={detectedFace.FaceRectangle.Height}");
                Console.WriteLine($"Head pose: pitch={detectedFace.FaceAttributes.HeadPose.Pitch}, roll={detectedFace.FaceAttributes.HeadPose.Roll}, yaw={detectedFace.FaceAttributes.HeadPose.Yaw}");
                Console.WriteLine($"Mask: NoseAndMouthCovered={detectedFace.FaceAttributes.Mask.NoseAndMouthCovered}, Type={detectedFace.FaceAttributes.Mask.Type}");
                Console.WriteLine($"Quality: {detectedFace.FaceAttributes.QualityForRecognition}");
                Console.WriteLine($"Recognition model: {detectedFace.RecognitionModel}");
                Console.WriteLine($"Landmarks: ");

                Console.WriteLine($"    PupilLeft: ({detectedFace.FaceLandmarks.PupilLeft.X}, {detectedFace.FaceLandmarks.PupilLeft.Y})");
                Console.WriteLine($"    PupilRight: ({detectedFace.FaceLandmarks.PupilRight.X}, {detectedFace.FaceLandmarks.PupilRight.Y})");
                Console.WriteLine($"    NoseTip: ({detectedFace.FaceLandmarks.NoseTip.X}, {detectedFace.FaceLandmarks.NoseTip.Y})");
                Console.WriteLine($"    MouthLeft: ({detectedFace.FaceLandmarks.MouthLeft.X}, {detectedFace.FaceLandmarks.MouthLeft.Y})");
                Console.WriteLine($"    MouthRight: ({detectedFace.FaceLandmarks.MouthRight.X}, {detectedFace.FaceLandmarks.MouthRight.Y})");
                Console.WriteLine($"    EyebrowLeftOuter: ({detectedFace.FaceLandmarks.EyebrowLeftOuter.X}, {detectedFace.FaceLandmarks.EyebrowLeftOuter.Y})");
                Console.WriteLine($"    EyebrowLeftInner: ({detectedFace.FaceLandmarks.EyebrowLeftInner.X}, {detectedFace.FaceLandmarks.EyebrowLeftInner.Y})");
                Console.WriteLine($"    EyeLeftOuter: ({detectedFace.FaceLandmarks.EyeLeftOuter.X}, {detectedFace.FaceLandmarks.EyeLeftOuter.Y})");
                Console.WriteLine($"    EyeLeftTop: ({detectedFace.FaceLandmarks.EyeLeftTop.X}, {detectedFace.FaceLandmarks.EyeLeftTop.Y})");
                Console.WriteLine($"    EyeLeftBottom: ({detectedFace.FaceLandmarks.EyeLeftBottom.X}, {detectedFace.FaceLandmarks.EyeLeftBottom.Y})");
                Console.WriteLine($"    EyeLeftInner: ({detectedFace.FaceLandmarks.EyeLeftInner.X}, {detectedFace.FaceLandmarks.EyeLeftInner.Y})");
                Console.WriteLine($"    EyebrowRightInner: ({detectedFace.FaceLandmarks.EyebrowRightInner.X}, {detectedFace.FaceLandmarks.EyebrowRightInner.Y})");
                Console.WriteLine($"    EyebrowRightOuter: ({detectedFace.FaceLandmarks.EyebrowRightOuter.X}, {detectedFace.FaceLandmarks.EyebrowRightOuter.Y})");
                Console.WriteLine($"    EyeRightInner: ({detectedFace.FaceLandmarks.EyeRightInner.X}, {detectedFace.FaceLandmarks.EyeRightInner.Y})");
                Console.WriteLine($"    EyeRightTop: ({detectedFace.FaceLandmarks.EyeRightTop.X}, {detectedFace.FaceLandmarks.EyeRightTop.Y})");
                Console.WriteLine($"    EyeRightBottom: ({detectedFace.FaceLandmarks.EyeRightBottom.X}, {detectedFace.FaceLandmarks.EyeRightBottom.Y})");
                Console.WriteLine($"    EyeRightOuter: ({detectedFace.FaceLandmarks.EyeRightOuter.X}, {detectedFace.FaceLandmarks.EyeRightOuter.Y})");
                Console.WriteLine($"    NoseRootLeft: ({detectedFace.FaceLandmarks.NoseRootLeft.X}, {detectedFace.FaceLandmarks.NoseRootLeft.Y})");
                Console.WriteLine($"    NoseRootRight: ({detectedFace.FaceLandmarks.NoseRootRight.X}, {detectedFace.FaceLandmarks.NoseRootRight.Y})");
                Console.WriteLine($"    NoseLeftAlarTop: ({detectedFace.FaceLandmarks.NoseLeftAlarTop.X}, {detectedFace.FaceLandmarks.NoseLeftAlarTop.Y})");
                Console.WriteLine($"    NoseRightAlarTop: ({detectedFace.FaceLandmarks.NoseRightAlarTop.X}, {detectedFace.FaceLandmarks.NoseRightAlarTop.Y})");
                Console.WriteLine($"    NoseLeftAlarOutTip: ({detectedFace.FaceLandmarks.NoseLeftAlarOutTip.X}, {detectedFace.FaceLandmarks.NoseLeftAlarOutTip.Y})");
                Console.WriteLine($"    NoseRightAlarOutTip: ({detectedFace.FaceLandmarks.NoseRightAlarOutTip.X}, {detectedFace.FaceLandmarks.NoseRightAlarOutTip.Y})");
                Console.WriteLine($"    UpperLipTop: ({detectedFace.FaceLandmarks.UpperLipTop.X}, {detectedFace.FaceLandmarks.UpperLipTop.Y})");
                Console.WriteLine($"    UpperLipBottom: ({detectedFace.FaceLandmarks.UpperLipBottom.X}, {detectedFace.FaceLandmarks.UpperLipBottom.Y})");
                Console.WriteLine($"    UnderLipTop: ({detectedFace.FaceLandmarks.UnderLipTop.X}, {detectedFace.FaceLandmarks.UnderLipTop.Y})");
                Console.WriteLine($"    UnderLipBottom: ({detectedFace.FaceLandmarks.UnderLipBottom.X}, {detectedFace.FaceLandmarks.UnderLipBottom.Y})");
            }
            #endregion
        }

        [Test]
        public void DetectFromUrl()
        {
            var client = CreateClient();
            var imageUri = new Uri(FaceTestConstant.UrlSampleImage);

            #region Snippet:DetectFacesFromUrl

            var detectResponse = client.Detect(
                imageUri,
                FaceDetectionModel.Detection01,
                FaceRecognitionModel.Recognition04,
                returnFaceId: false,
                returnFaceAttributes: new[] {
                    FaceAttributeType.Detection01.Accessories,
                    FaceAttributeType.Detection01.Glasses,
                    FaceAttributeType.Detection01.Exposure,
                    FaceAttributeType.Detection01.Noise });

            var detectedFaces = detectResponse.Value;
            Console.WriteLine($"Detected {detectedFaces.Count} face(s) in the image.");
            foreach (var detectedFace in detectedFaces)
            {
                Console.WriteLine($"Face Rectangle: left={detectedFace.FaceRectangle.Left}, top={detectedFace.FaceRectangle.Top}, width={detectedFace.FaceRectangle.Width}, height={detectedFace.FaceRectangle.Height}");
                Console.WriteLine($"Accessories:");
                foreach (var accessory in detectedFace.FaceAttributes.Accessories)
                {
                    Console.WriteLine($"    Type: {accessory.Type}, Confidence: {accessory.Confidence}");
                }
                Console.WriteLine($"Glasses: {detectedFace.FaceAttributes.Glasses}");
                Console.WriteLine($"Exposure Level: {detectedFace.FaceAttributes.Exposure.ExposureLevel}, Value: {detectedFace.FaceAttributes.Exposure.Value}");
                Console.WriteLine($"Noise Level: {detectedFace.FaceAttributes.Noise.NoiseLevel}, Value: {detectedFace.FaceAttributes.Noise.Value}");
            }
            #endregion
        }

        [Test]
        public void DetectFromUrl_InvalidUrl()
        {
            var client = CreateClient();

            #region Snippet:DetectFacesInvalidUrl
            var invalidUri = new Uri("http://invalid.uri");
            try {
                var detectResponse = client.Detect(
                    invalidUri,
                    FaceDetectionModel.Detection01,
                    FaceRecognitionModel.Recognition04,
                    returnFaceId: false);
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            #endregion
        }
    }
}
