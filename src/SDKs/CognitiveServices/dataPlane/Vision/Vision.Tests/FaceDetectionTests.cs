using Microsoft.Azure.CognitiveServices.Vision.Face;
using Microsoft.Azure.CognitiveServices.Vision.Face.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace FaceSDK.Tests
{
    public class FaceDetectionTests : BaseTests
    {
        [Fact]
        public void FaceDetectionWithAttributes()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                HttpMockServer.Initialize(this.GetType().FullName, "FaceDetectionWithAttributes");

                IFaceAPI client = GetFaceClient(HttpMockServer.CreateInstance());
                using (FileStream stream = new FileStream(Path.Combine("TestImages", "detection2.jpg"), FileMode.Open))
                {
                    IList<DetectedFace> faceList = client.Face.DetectInStreamAsync(
                        stream,
                        true,
                        true,
                        new List<FaceAttributeTypes>()
                            {
                            FaceAttributeTypes.Accessories,
                            FaceAttributeTypes.Age,
                            FaceAttributeTypes.Blur,
                            FaceAttributeTypes.Emotion,
                            FaceAttributeTypes.Exposure,
                            FaceAttributeTypes.FacialHair,
                            FaceAttributeTypes.Gender,
                            FaceAttributeTypes.Glasses,
                            FaceAttributeTypes.Hair,
                            FaceAttributeTypes.HeadPose,
                            FaceAttributeTypes.Makeup,
                            FaceAttributeTypes.Noise,
                            FaceAttributeTypes.Occlusion,
                            FaceAttributeTypes.Smile
                            }
                        ).Result;

                    Assert.Equal(1, faceList.Count);
                    var face = faceList[0];

                    // Ensure face rectangle coordinates return correctly
                    Assert.True(face.FaceRectangle.Top > 0);
                    Assert.True(face.FaceRectangle.Left > 0);
                    Assert.True(face.FaceRectangle.Width > 0);
                    Assert.True(face.FaceRectangle.Height > 0);

                    // Ensure face ID return correctly
                    Assert.True(face.FaceId.Length > 0);

                    // Ensure attributes match image
                    Assert.True(face.FaceAttributes.Hair.Invisible);
                    Assert.True(face.FaceAttributes.HeadPose.Roll != 0);
                    Assert.True(face.FaceAttributes.HeadPose.Yaw > 0);
                    Assert.Equal(Gender.Male, face.FaceAttributes.Gender);
                    Assert.True(face.FaceAttributes.Age > 0);
                    Assert.True(face.FaceAttributes.FacialHair.Beard > 0);
                    Assert.True(face.FaceAttributes.FacialHair.Moustache > 0);
                    Assert.True(face.FaceAttributes.FacialHair.Sideburns > 0);
                    Assert.True(face.FaceAttributes.Glasses == GlassesTypes.ReadingGlasses);
                    Assert.False(face.FaceAttributes.Makeup.EyeMakeup);
                    Assert.False(face.FaceAttributes.Makeup.LipMakeup);
                    Assert.True(face.FaceAttributes.Emotion.Neutral > 0.9);
                    Assert.True(face.FaceAttributes.Occlusion.ForeheadOccluded);
                    Assert.False(face.FaceAttributes.Occlusion.EyeOccluded);
                    Assert.False(face.FaceAttributes.Occlusion.MouthOccluded);
                    Assert.True(face.FaceAttributes.Accessories.Count > 0);
                    var accessories = face.FaceAttributes.Accessories;
                    Assert.Equal("glasses", accessories[0].Type, true, true, true);
                    Assert.True(accessories[0].Confidence > 0.9);
                    Assert.Equal("headwear", accessories[1].Type, true, true, true);
                    Assert.True(accessories[0].Confidence > 0.9);
                    Assert.Equal(BlurLevels.Low, face.FaceAttributes.Blur.BlurLevel);
                    Assert.Equal(ExposureLevels.GoodExposure, face.FaceAttributes.Exposure.ExposureLevel);
                    Assert.Equal(NoiseLevels.Medium, face.FaceAttributes.Noise.NoiseLevel);

                    // Ensure face landmarks are de-serialized correctly.
                    var landMarks = face.FaceLandmarks;
                    Assert.True(landMarks.PupilLeft.X > 0);
                    Assert.True(landMarks.PupilLeft.Y > 0);
                    Assert.True(landMarks.PupilRight.X > 0);
                    Assert.True(landMarks.PupilRight.Y > 0);
                    Assert.True(landMarks.NoseTip.X > 0);
                    Assert.True(landMarks.NoseTip.Y > 0);
                    Assert.True(landMarks.MouthLeft.X > 0);
                    Assert.True(landMarks.MouthLeft.Y > 0);
                    Assert.True(landMarks.MouthRight.X > 0);
                    Assert.True(landMarks.MouthRight.Y > 0);
                    Assert.True(landMarks.EyebrowLeftOuter.X > 0);
                    Assert.True(landMarks.EyebrowLeftInner.Y > 0);
                    Assert.True(landMarks.EyeLeftOuter.X > 0);
                    Assert.True(landMarks.EyeLeftOuter.Y > 0);
                    Assert.True(landMarks.EyeLeftTop.X > 0);
                    Assert.True(landMarks.EyeLeftTop.Y > 0);
                    Assert.True(landMarks.EyeLeftBottom.X > 0);
                    Assert.True(landMarks.EyeLeftBottom.Y > 0);
                    Assert.True(landMarks.EyeLeftInner.X > 0);
                    Assert.True(landMarks.EyeLeftInner.Y > 0);
                    Assert.True(landMarks.EyebrowRightInner.X > 0);
                    Assert.True(landMarks.EyebrowRightInner.Y > 0);
                    Assert.True(landMarks.EyebrowRightOuter.X > 0);
                    Assert.True(landMarks.EyebrowRightOuter.Y > 0);
                    Assert.True(landMarks.EyeRightInner.X > 0);
                    Assert.True(landMarks.EyeRightInner.Y > 0);
                    Assert.True(landMarks.EyeRightTop.X > 0);
                    Assert.True(landMarks.EyeRightTop.Y > 0);
                    Assert.True(landMarks.EyeRightBottom.X > 0);
                    Assert.True(landMarks.EyeRightBottom.Y > 0);
                    Assert.True(landMarks.EyeRightOuter.X > 0);
                    Assert.True(landMarks.EyeRightOuter.Y > 0);
                    Assert.True(landMarks.NoseRootLeft.X > 0);
                    Assert.True(landMarks.NoseRootLeft.Y > 0);
                    Assert.True(landMarks.NoseRootRight.X > 0);
                    Assert.True(landMarks.NoseRootRight.Y > 0);
                    Assert.True(landMarks.NoseLeftAlarTop.X > 0);
                    Assert.True(landMarks.NoseLeftAlarTop.Y > 0);
                    Assert.True(landMarks.NoseRightAlarTop.X > 0);
                    Assert.True(landMarks.NoseRightAlarTop.Y > 0);
                    Assert.True(landMarks.NoseLeftAlarOutTip.X > 0);
                    Assert.True(landMarks.NoseLeftAlarOutTip.Y > 0);
                    Assert.True(landMarks.NoseRightAlarOutTip.X > 0);
                    Assert.True(landMarks.NoseRightAlarOutTip.Y > 0);
                    Assert.True(landMarks.UpperLipTop.X > 0);
                    Assert.True(landMarks.UpperLipTop.Y > 0);
                    Assert.True(landMarks.UpperLipBottom.X > 0);
                    Assert.True(landMarks.UpperLipBottom.Y > 0);
                    Assert.True(landMarks.UnderLipTop.X > 0);
                    Assert.True(landMarks.UnderLipTop.Y > 0);
                    Assert.True(landMarks.UnderLipBottom.X > 0);
                    Assert.True(landMarks.UnderLipBottom.Y > 0);
                }
            }
        }

        [Fact]
        public void FaceDetectionNoFace()
        {
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                HttpMockServer.Initialize(this.GetType().FullName, "FaceDetectionNoFace");

                IFaceAPI client = GetFaceClient(HttpMockServer.CreateInstance());
                using (FileStream stream = new FileStream(Path.Combine("TestImages", "NoFace.jpg"), FileMode.Open))
                {
                    IList<DetectedFace> faceList = client.Face.DetectInStreamAsync(stream).Result;
                    Assert.Equal(0, faceList.Count);
                }
            }
        }
    }
}
