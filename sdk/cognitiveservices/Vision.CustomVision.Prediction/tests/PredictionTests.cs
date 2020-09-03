namespace Microsoft.Azure.CognitiveServices.Vision.CustomVision.Prediction.Tests
{
    using Microsoft.Azure.CognitiveServices.Vision.CustomVision.Prediction.Models;
    using Microsoft.Azure.Test.HttpRecorder;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using System;
    using System.IO;
    using Xunit;

    public class PredictionTests : BaseTests
    {
        [Fact]
        public void ClassifyImage()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "ClassifyImage", RecorderMode);

                ICustomVisionPredictionClient client = GetPredictionClientClient();
                using (FileStream stream = new FileStream(Path.Combine("TestImages", "test_image.jpg"), FileMode.Open))
                {
                    ImagePrediction results = client.ClassifyImage(ClassificationProjectId, ClassificationPublishedName, stream);
                    ValidateResults(results);
                }
            }
        }

        [Fact]
        public void ClassifyImageNoStore()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "ClassifyImageNoStore", RecorderMode);

                ICustomVisionPredictionClient client = GetPredictionClientClient();
                using (FileStream stream = new FileStream(Path.Combine("TestImages", "test_image.jpg"), FileMode.Open))
                {
                    ImagePrediction results = client.ClassifyImageWithNoStore(ClassificationProjectId, ClassificationPublishedName, stream);
                    ValidateResults(results);
                }
            }
        }

        [Fact]
        public void ClassifyImageUrl()
        {
            string testImageUrl = "https://raw.githubusercontent.com/Microsoft/Cognitive-CustomVision-Windows/master/Samples/Images/Test/test_image.jpg";
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "ClassifyImageUrl", RecorderMode);

                ICustomVisionPredictionClient client = GetPredictionClientClient();
                ImageUrl url = new ImageUrl(testImageUrl);

                ImagePrediction results = client.ClassifyImageUrl(ClassificationProjectId, ClassificationPublishedName, url);
                ValidateResults(results);
            }
        }

        [Fact]
        public void ClassifyImageUrlNoStore()
        {
            string testImageUrl = "https://raw.githubusercontent.com/Microsoft/Cognitive-CustomVision-Windows/master/Samples/Images/Test/test_image.jpg";
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "ClassifyImageUrlNoStore", RecorderMode);

                ICustomVisionPredictionClient client = GetPredictionClientClient();
                ImageUrl url = new ImageUrl(testImageUrl);

                ImagePrediction results = client.ClassifyImageUrlWithNoStore(ClassificationProjectId, ClassificationPublishedName, url);
                ValidateResults(results);
            }
        }

        [Fact]
        public void DetectImage()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "DetectImage", RecorderMode);

                ICustomVisionPredictionClient client = GetPredictionClientClient();
                using (FileStream stream = new FileStream(Path.Combine("TestImages", "test_image.jpg"), FileMode.Open))
                {
                    ImagePrediction results = client.DetectImage(ObjectDetectionProjectId, ObjDetectionPublishedName, stream);
                    ValidateObjDetectionResults(results);
                }
            }
        }

        [Fact]
        public void DetectImageNoStore()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "DetectImageNoStore", RecorderMode);

                ICustomVisionPredictionClient client = GetPredictionClientClient();
                using (FileStream stream = new FileStream(Path.Combine("TestImages", "test_image.jpg"), FileMode.Open))
                {
                    ImagePrediction results = client.DetectImageWithNoStore(ObjectDetectionProjectId, ObjDetectionPublishedName, stream);
                    ValidateObjDetectionResults(results);
                }
            }
        }

        [Fact]
        public void DetectImageUrl()
        {
            string testImageUrl = "https://raw.githubusercontent.com/Microsoft/Cognitive-CustomVision-Windows/master/Samples/Images/Test/test_image.jpg";
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "DetectImageUrl", RecorderMode);

                ICustomVisionPredictionClient client = GetPredictionClientClient();
                ImageUrl url = new ImageUrl(testImageUrl);

                ImagePrediction results = client.DetectImageUrl(ObjectDetectionProjectId, ObjDetectionPublishedName, url);
                ValidateObjDetectionResults(results);
            }
        }

        [Fact]
        public void DetectImageUrlNoStore()
        {
            string testImageUrl = "https://raw.githubusercontent.com/Microsoft/Cognitive-CustomVision-Windows/master/Samples/Images/Test/test_image.jpg";
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "DetectImageUrlNoStore", RecorderMode);

                ICustomVisionPredictionClient client = GetPredictionClientClient();
                ImageUrl url = new ImageUrl(testImageUrl);

                ImagePrediction results = client.DetectImageUrlWithNoStore(ObjectDetectionProjectId, ObjDetectionPublishedName, url);
                ValidateObjDetectionResults(results);
            }
        }

        private static void ValidateResults(ImagePrediction results)
        {
            Assert.Equal(ClassificationProjectId, results.Project);
            Assert.NotEqual(Guid.Empty, results.Iteration);
            Assert.Equal(2, results.Predictions.Count);
            Assert.Equal("Tag1", results.Predictions[0].TagName);
            Assert.Equal(TagType.Regular, results.Predictions[0].TagType);
            Assert.InRange(results.Predictions[0].Probability, 0, 1);
            Assert.NotEqual(Guid.Empty, results.Predictions[0].TagId);
            Assert.Null(results.Predictions[0].BoundingBox);
            Assert.Equal("Tag2", results.Predictions[1].TagName);
            Assert.Equal(TagType.Regular, results.Predictions[1].TagType);
            Assert.InRange(results.Predictions[1].Probability, 0, 0.1);
            Assert.NotEqual(Guid.Empty, results.Predictions[1].TagId);
            Assert.Null(results.Predictions[1].BoundingBox);
        }

        private static void ValidateObjDetectionResults(ImagePrediction results)
        {
            Assert.Equal(ObjectDetectionProjectId, results.Project);
            Assert.NotEqual(Guid.Empty, results.Iteration);
            Assert.Equal(4, results.Predictions.Count);

            var expectedTags = new string[] { "fork", "fork", "scissors", "scissors" };

            for (var i = 0; i < expectedTags.Length; i++)
            {
                Assert.Equal(expectedTags[i], results.Predictions[i].TagName);
                Assert.Equal(TagType.Regular, results.Predictions[i].TagType);
                Assert.InRange(results.Predictions[i].Probability, 0, 1);
                Assert.NotEqual(Guid.Empty, results.Predictions[i].TagId);
                Assert.NotNull(results.Predictions[i].BoundingBox);
                Assert.InRange(results.Predictions[i].BoundingBox.Left, 0, 1);
                Assert.InRange(results.Predictions[i].BoundingBox.Top, 0, 1);
                Assert.InRange(results.Predictions[i].BoundingBox.Width, 0, 1);
                Assert.InRange(results.Predictions[i].BoundingBox.Height, 0, 1);
            }
        }
    }
}
