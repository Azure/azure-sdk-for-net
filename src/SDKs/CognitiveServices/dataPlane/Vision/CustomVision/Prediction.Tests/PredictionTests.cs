using Microsoft.Azure.CognitiveServices.Vision.CustomVision.Prediction.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.IO;
using Xunit;

namespace Microsoft.Azure.CognitiveServices.Vision.CustomVision.Prediction.Tests
{
    public class PredictionTests : BaseTests
    {
        [Fact]
        public void PredictImage()
        {
            using (MockContext context = MockContext.Start(this.GetType().Name))
            {
                HttpMockServer.Initialize(this.GetType().Name, "PredictImage");

                IPredictionEndpoint client = GetPredictionEndpointClient(HttpMockServer.CreateInstance());
                using (FileStream stream = new FileStream(Path.Combine("TestImages", "test_image.jpg"), FileMode.Open))
                {
                    ImagePredictionResultModel results = client.PredictImageAsync(ProjectId, stream).Result;
                    ValidateResults(results);
                }
            }
        }

        [Fact]
        public void PredictImageNoStore()
        {
            using (MockContext context = MockContext.Start(this.GetType().Name))
            {
                HttpMockServer.Initialize(this.GetType().Name, "PredictImageNoStore");

                IPredictionEndpoint client = GetPredictionEndpointClient(HttpMockServer.CreateInstance());
                using (FileStream stream = new FileStream(Path.Combine("TestImages", "test_image.jpg"), FileMode.Open))
                {
                    ImagePredictionResultModel results = client.PredictImageWithNoStoreAsync(ProjectId, stream).Result;
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
                HttpMockServer.Initialize(this.GetType().Name, "PredictImageUrl");

                IPredictionEndpoint client = GetPredictionEndpointClient(HttpMockServer.CreateInstance());
                ImageUrl url = new ImageUrl(testImageUrl);

                ImagePredictionResultModel results = client.PredictImageUrlAsync(ProjectId, url).Result;
                ValidateResults(results);
            }
        }

        [Fact]
        public void PredictImageUrlNoStore()
        {
            string testImageUrl = "https://raw.githubusercontent.com/Microsoft/Cognitive-CustomVision-Windows/master/Samples/Images/Test/test_image.jpg";
            using (MockContext context = MockContext.Start(this.GetType().Name))
            {
                HttpMockServer.Initialize(this.GetType().Name, "PredictImageUrlNoStore");

                IPredictionEndpoint client = GetPredictionEndpointClient(HttpMockServer.CreateInstance());
                ImageUrl url = new ImageUrl(testImageUrl);

                ImagePredictionResultModel results = client.PredictImageUrlWithNoStoreAsync(ProjectId, url).Result;
                ValidateResults(results);
            }
        }

        private static void ValidateResults(ImagePredictionResultModel results)
        {
            Assert.Equal(ProjectId, results.Project);
            Assert.Equal(Guid.Parse("015deca4-aa39-4d20-81fe-73de4efd6acf"), results.Iteration);
            Assert.Equal(2, results.Predictions.Count);
            Assert.Equal("Hemlock", results.Predictions[0].Tag);
            Assert.Equal(1, results.Predictions[0].Probability);
            Assert.Equal(Guid.Parse("f7304b5d-0318-4a29-b98c-114c6f90c81d"), results.Predictions[0].TagId);
            Assert.Equal("Japanese Cherry", results.Predictions[1].Tag);
            Assert.InRange(results.Predictions[1].Probability, 0, 1e-6);
            Assert.Equal(Guid.Parse("5408cebc-c28d-4578-8515-7a4718f5e0d3"), results.Predictions[1].TagId);
        }
    }
}
