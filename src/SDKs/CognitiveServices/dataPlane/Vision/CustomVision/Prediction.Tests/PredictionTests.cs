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
        public void PredictImage()
        {
            using (MockContext context = MockContext.Start(this.GetType().Name))
            {
                HttpMockServer.Initialize(this.GetType().Name, "PredictImage", RecorderMode);

                IPredictionEndpoint client = GetPredictionClientClient();
                using (FileStream stream = new FileStream(Path.Combine("TestImages", "test_image.jpg"), FileMode.Open))
                {
                    ImagePrediction results = client.PredictImageAsync(ProjectId, stream).Result;
                    ValidateResults(results);
                }
            }
        }

        [Fact]
        public void PredictImageNoStore()
        {
            using (MockContext context = MockContext.Start(this.GetType().Name))
            {
                HttpMockServer.Initialize(this.GetType().Name, "PredictImageNoStore", RecorderMode);

                IPredictionEndpoint client = GetPredictionClientClient();
                using (FileStream stream = new FileStream(Path.Combine("TestImages", "test_image.jpg"), FileMode.Open))
                {
                    ImagePrediction results = client.PredictImageWithNoStoreAsync(ProjectId, stream).Result;
                    ValidateResults(results);
                }
            }
        }

        [Fact]
        public void PredictImageUrl()
        {
            string testImageUrl = "https://raw.githubusercontent.com/Microsoft/Cognitive-CustomVision-Windows/master/Samples/Images/Test/test_image.jpg";
            using (MockContext context = MockContext.Start(this.GetType().Name))
            {
                HttpMockServer.Initialize(this.GetType().Name, "PredictImageUrl", RecorderMode);

                IPredictionEndpoint client = GetPredictionClientClient();
                ImageUrl url = new ImageUrl(testImageUrl);

                ImagePrediction results = client.PredictImageUrlAsync(ProjectId, url).Result;
                ValidateResults(results);
            }
        }

        [Fact]
        public void PredictImageUrlNoStore()
        {
            string testImageUrl = "https://raw.githubusercontent.com/Microsoft/Cognitive-CustomVision-Windows/master/Samples/Images/Test/test_image.jpg";
            using (MockContext context = MockContext.Start(this.GetType().Name))
            {
                HttpMockServer.Initialize(this.GetType().Name, "PredictImageUrlNoStore", RecorderMode);

                IPredictionEndpoint client = GetPredictionClientClient();
                ImageUrl url = new ImageUrl(testImageUrl);

                ImagePrediction results = client.PredictImageUrlWithNoStoreAsync(ProjectId, url).Result;
                ValidateResults(results);
            }
        }

        private static void ValidateResults(ImagePrediction results)
        {
            Assert.Equal(ProjectId, results.Project);
            Assert.NotEqual(Guid.Empty, results.Iteration);
            Assert.Equal(2, results.Predictions.Count);
            Assert.Equal("hemlock", results.Predictions[0].TagName);
            Assert.InRange(results.Predictions[0].Probability, 0.9, 1);
            Assert.NotEqual(Guid.Empty, results.Predictions[0].TagId);
            Assert.Equal("cherry", results.Predictions[1].TagName);
            Assert.InRange(results.Predictions[1].Probability, 0, 0.1);
            Assert.NotEqual(Guid.Empty, results.Predictions[1].TagId);
        }
    }
}
