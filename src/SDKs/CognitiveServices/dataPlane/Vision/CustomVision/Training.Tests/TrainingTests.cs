using Microsoft.Azure.CognitiveServices.Vision.CustomVision.Training.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.IO;
using System.Linq;
using Xunit;

namespace Microsoft.Azure.CognitiveServices.Vision.CustomVision.Training.Tests
{
    public class TrainingTests : BaseTests
    {
        private const string projName = "Test Project";
        private const string projDescription = "This is a test project";
        private const string tagName = "Test Tag 1";
        private const string tagDescription = "This is a test tag";

        [Fact]
        public async void CreateUpdateDeleteProject()
        {
            var updatedProjName = "Another Name";
            var updatedProjDescription = "Updated Project Description";

            using (MockContext context = MockContext.Start(this.GetType().Name))
            {
                HttpMockServer.Initialize(this.GetType().Name, "CreateUpdateDeleteProject");

                ITrainingApi client = GetTrainingApiClient(HttpMockServer.CreateInstance());
                var newProject = client.CreateProjectAsync(projName, projDescription).Result;

                Assert.Contains(projName, newProject.Name);
                Assert.Equal(projDescription, newProject.Description);
                Assert.NotEqual(Guid.Empty, newProject.Id);

                var updatedProject = client.UpdateProjectAsync(newProject.Id, new Project()
                {
                    Name = updatedProjName,
                    Description = updatedProjDescription,
                }).Result;

                Assert.Equal(updatedProjName, updatedProject.Name);
                Assert.Equal(updatedProjDescription, updatedProject.Description);
                Assert.Equal(newProject.Id, updatedProject.Id);
                Assert.Equal(newProject.Settings.DomainId, updatedProject.Settings.DomainId);

                await client.DeleteProjectAsync(newProject.Id);
            }
        }

        [Fact]
        public async void CreateDeleteProjectWithDomain()
        {
            using (MockContext context = MockContext.Start(this.GetType().Name))            
            {
                HttpMockServer.Initialize(this.GetType().Name, "CreateDeleteProjectWithDomain");

                ITrainingApi client = GetTrainingApiClient(HttpMockServer.CreateInstance());
                var newProject = client.CreateProjectAsync(projName, projDescription, FoodDomain).Result;

                Assert.Contains(projName, newProject.Name);
                Assert.Equal(projDescription, newProject.Description);
                Assert.Equal(FoodDomain, newProject.Settings.DomainId);
                Assert.NotEqual(Guid.Empty, newProject.Id);

                await client.DeleteProjectAsync(newProject.Id);
            }
        }


        [Fact]
        public async void CreateImageFromUrl()
        {
            string imageUrl = "https://raw.githubusercontent.com/Microsoft/Cognitive-CustomVision-Windows/master/Samples/Images/Hemlock/hemlock_1.jpg";

            using (MockContext context = MockContext.Start(this.GetType().Name))
            {
                HttpMockServer.Initialize(this.GetType().Name, "CreateImageFromUrl");

                ITrainingApi client = GetTrainingApiClient(HttpMockServer.CreateInstance());
                var newProject = client.CreateProjectAsync(projName, projDescription, FoodDomain).Result;
                var tag = client.CreateTagAsync(newProject.Id, tagName).Result;
                var urlImages = new ImageUrlCreateEntry[] { new ImageUrlCreateEntry(imageUrl) };
                var tags = new Guid[] { tag.Id };
                var imageCreatedFromUrl = client.CreateImagesFromUrlsAsync(newProject.Id, new ImageUrlCreateBatch(urlImages, tags)).Result;

                Assert.True(imageCreatedFromUrl.IsBatchSuccessful);
                Assert.Equal(1, imageCreatedFromUrl.Images.Count);
                Assert.Equal(imageUrl, imageCreatedFromUrl.Images[0].SourceUrl);
                Assert.Equal("OK", imageCreatedFromUrl.Images[0].Status);
                Assert.NotEqual(Guid.Empty, imageCreatedFromUrl.Images[0].Image.Id);
                Assert.NotEqual(0, imageCreatedFromUrl.Images[0].Image.Width);
                Assert.NotEqual(0, imageCreatedFromUrl.Images[0].Image.Height);
                Assert.NotEmpty(imageCreatedFromUrl.Images[0].Image.ImageUri);
                Assert.NotEmpty(imageCreatedFromUrl.Images[0].Image.ThumbnailUri);

                await client.DeleteProjectAsync(newProject.Id);
            }
        }

        [Fact]
        public async void CreateImagesFromFiles()
        {
            var dataFileName = "hemlock_1.jpg";

            using (MockContext context = MockContext.Start(this.GetType().Name))
            {
                HttpMockServer.Initialize(this.GetType().Name, "CreateImagesFromFiles");

                ITrainingApi client = GetTrainingApiClient(HttpMockServer.CreateInstance());
                var newProject = client.CreateProjectAsync(projName, projDescription, FoodDomain).Result;
                var tag = client.CreateTagAsync(newProject.Id, tagName).Result;
                var fileName = Path.Combine("TestImages", dataFileName);
                var fileImages = new ImageFileCreateEntry[] { new ImageFileCreateEntry(dataFileName, File.ReadAllBytes(fileName)) };
                var tags = new Guid[] { tag.Id };
                var imageCreatedFromFile = client.CreateImagesFromFilesAsync(newProject.Id, new ImageFileCreateBatch(fileImages, tags)).Result;

                Assert.True(imageCreatedFromFile.IsBatchSuccessful);
                Assert.Equal(1, imageCreatedFromFile.Images.Count);
                Assert.Contains(dataFileName, imageCreatedFromFile.Images[0].SourceUrl);
                Assert.Equal("OK", imageCreatedFromFile.Images[0].Status);
                Assert.NotEqual(Guid.Empty, imageCreatedFromFile.Images[0].Image.Id);
                Assert.NotEqual(0, imageCreatedFromFile.Images[0].Image.Width);
                Assert.NotEqual(0, imageCreatedFromFile.Images[0].Image.Height);
                Assert.NotEmpty(imageCreatedFromFile.Images[0].Image.ImageUri);
                Assert.NotEmpty(imageCreatedFromFile.Images[0].Image.ThumbnailUri);

                await client.DeleteProjectAsync(newProject.Id);
            }
        }

        [Fact]
        public async void CreateImagesFromData()
        {
            var dataFileName = "hemlock_1.jpg";

            using (MockContext context = MockContext.Start(this.GetType().Name))
            {
                HttpMockServer.Initialize(this.GetType().Name, "CreateImagesFromData");

                ITrainingApi client = GetTrainingApiClient(HttpMockServer.CreateInstance());
                var newProject = client.CreateProjectAsync(projName, projDescription, FoodDomain).Result;
                var tag = client.CreateTagAsync(newProject.Id, tagName).Result;
                using (FileStream stream = new FileStream(Path.Combine("TestImages", dataFileName), FileMode.Open))
                {
                    var imageCreatedFromData = client.CreateImagesFromDataAsync(newProject.Id, stream, new string[] { tag.Id.ToString() }).Result;

                    Assert.True(imageCreatedFromData.IsBatchSuccessful);
                    Assert.Equal(1, imageCreatedFromData.Images.Count);
                    Assert.Contains(dataFileName, imageCreatedFromData.Images[0].SourceUrl);
                    Assert.Equal("OK", imageCreatedFromData.Images[0].Status);
                    Assert.NotEqual(Guid.Empty, imageCreatedFromData.Images[0].Image.Id);
                    Assert.NotEqual(0, imageCreatedFromData.Images[0].Image.Width);
                    Assert.NotEqual(0, imageCreatedFromData.Images[0].Image.Height);
                    Assert.NotEmpty(imageCreatedFromData.Images[0].Image.ImageUri);
                    Assert.NotEmpty(imageCreatedFromData.Images[0].Image.ThumbnailUri);
                }
                await client.DeleteProjectAsync(newProject.Id);
            }
        }
        [Fact]
        public void ProjectRetrieval()
        {
            using (MockContext context = MockContext.Start(this.GetType().Name))
            {
                HttpMockServer.Initialize(this.GetType().Name, "ProjectRetrieval");

                ITrainingApi client = GetTrainingApiClient(HttpMockServer.CreateInstance());
                var projects = client.GetProjectsAsync().Result;

                Assert.Equal(15, projects.Count);

                var firstProject = client.GetProjectAsync(projects[0].Id).Result;

                Assert.Equal(projects[0].Id, firstProject.Id);
                Assert.Equal(projects[0].Name, firstProject.Name);
                Assert.Equal(projects[0].Description, firstProject.Description);
                Assert.Equal(projects[0].Settings.DomainId, firstProject.Settings.DomainId);
            }
        }


        [Fact]
        public void TagRetrieval()
        {
            using (MockContext context = MockContext.Start(this.GetType().Name))
            {
                HttpMockServer.Initialize(this.GetType().Name, "TagRetrieval");

                ITrainingApi client = GetTrainingApiClient(HttpMockServer.CreateInstance());
                var tagList = client.GetTagsAsync(ProjectId).Result;

                Assert.Equal(2, tagList.Tags.Count);

                var firstTag = client.GetTagAsync(ProjectId, tagList.Tags[0].Id).Result;

                Assert.Equal(tagList.Tags[0].Id, firstTag.Id);
                Assert.Equal(tagList.Tags[0].Name, firstTag.Name);
                Assert.Equal(tagList.Tags[0].Description, firstTag.Description);
                Assert.Equal(tagList.Tags[0].ImageCount, firstTag.ImageCount);
            }
        }
        [Fact]
        public void DomainsApiTests()
        {
            using (MockContext context = MockContext.Start(this.GetType().Name))
            {
                HttpMockServer.Initialize(this.GetType().Name, "DomainsApiTests");

                ITrainingApi client = GetTrainingApiClient(HttpMockServer.CreateInstance());

                var domains = client.GetDomainsAsync().Result;
                Assert.Equal(8, domains.Count);

                var foodDomain = domains.FirstOrDefault(d => d.Id == FoodDomain);
                Assert.NotNull(foodDomain);
                Assert.False(foodDomain.Exportable);
                Assert.Contains("food", foodDomain.Name.ToLowerInvariant());

                var generalDomain = client.GetDomainAsync(GeneralDomain).Result;
                Assert.Equal(GeneralDomain, generalDomain.Id);
                Assert.False(generalDomain.Exportable);
                Assert.Contains("general", generalDomain.Name.ToLowerInvariant());
            }
        }

        [Fact]
        public async void CreateUpdateDeleteTag()
        {
            var updatedName = "New Tag Name";
            var updatedDescription = "Updated Description";

            using (MockContext context = MockContext.Start(this.GetType().Name))
            {
                HttpMockServer.Initialize(this.GetType().Name, "CreateUpdateDeleteTag");

                ITrainingApi client = GetTrainingApiClient(HttpMockServer.CreateInstance());

                var tag = client.CreateTagAsync(ProjectId, tagName, tagDescription).Result;

                Assert.Equal(tagName, tag.Name);
                Assert.Equal(tagDescription, tag.Description);
                Assert.Equal(0, tag.ImageCount);
                Assert.NotEqual(Guid.Empty, tag.Id);


                var updatedTag = client.UpdateTagAsync(ProjectId, tag.Id, new Tag()
                {
                    Name = updatedName,
                    Description = updatedDescription
                }).Result;

                Assert.Equal(updatedName, updatedTag.Name);
                Assert.Equal(updatedDescription, updatedTag.Description);
                Assert.Equal(tag.ImageCount, updatedTag.ImageCount);
                Assert.Equal(tag.Id, updatedTag.Id);


                await client.DeleteTagAsync(ProjectId, tag.Id);
            }
        }

        [Fact]
        public void GetIterations()
        {
            var updatedName = "New Iteration Name";

            using (MockContext context = MockContext.Start(this.GetType().Name))
            {
                HttpMockServer.Initialize(this.GetType().Name, "GetIterations");

                ITrainingApi client = GetTrainingApiClient(HttpMockServer.CreateInstance());

                var iterations = client.GetIterationsAsync(ProjectId).Result;

                Assert.Equal(2, iterations.Count);
                Assert.NotEmpty(iterations[0].Name);
                Assert.NotEqual(Guid.Empty, iterations[0].DomainId);
                Assert.NotEqual(Guid.Empty, iterations[0].Id);
                Assert.Equal(ProjectId, iterations[0].ProjectId);
                Assert.True(iterations[0].IsDefault);
                Assert.Equal("Completed", iterations[0].Status);
                Assert.False(iterations[0].Exportable);

                var iteration = client.GetIterationAsync(ProjectId, iterations[0].Id).Result;
                Assert.Equal(iteration.Name, iterations[0].Name);
                Assert.Equal(iteration.Id, iterations[0].Id);
                Assert.True(iterations[0].IsDefault);

                var updatedIteration = client.UpdateIterationAsync(ProjectId, iteration.Id, new Iteration()
                {
                    Name = updatedName,
                    IsDefault = !iterations[0].IsDefault,
                }).Result;

                Assert.Equal(updatedName, updatedIteration.Name);
                Assert.Equal(!iteration.IsDefault, updatedIteration.IsDefault);
            }
        }

        [Fact]
        public void GetIterationPerformance()
        {
            using (MockContext context = MockContext.Start(this.GetType().Name))
            {
                HttpMockServer.Initialize(this.GetType().Name, "GetIterationPerformance");

                ITrainingApi client = GetTrainingApiClient(HttpMockServer.CreateInstance());

                var iterations = client.GetIterationsAsync(ProjectId).Result;

                Assert.True(iterations.Count > 1);

                var iterationPerf = client.GetIterationPerformanceAsync(ProjectId, iterations[iterations.Count - 1].Id, 0.9).Result;
                Assert.Equal(1, iterationPerf.Recall);
                Assert.Equal(0, iterationPerf.RecallStdDeviation);
                Assert.Equal(1, iterationPerf.Precision);
                Assert.Equal(0, iterationPerf.PrecisionStdDeviation);
                Assert.Equal(2, iterationPerf.PerTagPerformance.Count);
                Assert.Equal("Hemlock", iterationPerf.PerTagPerformance[0].Name);
                Assert.Equal(1, iterationPerf.PerTagPerformance[0].Recall);
                Assert.Equal(0, iterationPerf.PerTagPerformance[0].RecallStdDeviation);
                Assert.Equal(1, iterationPerf.PerTagPerformance[0].Precision);
                Assert.Equal(0, iterationPerf.PerTagPerformance[0].PrecisionStdDeviation);
                Assert.Equal("Japanese Cherry", iterationPerf.PerTagPerformance[1].Name);
                Assert.Equal(1, iterationPerf.PerTagPerformance[1].Recall);
                Assert.Equal(0, iterationPerf.PerTagPerformance[1].RecallStdDeviation);
                Assert.Equal(1, iterationPerf.PerTagPerformance[1].Precision);
                Assert.Equal(0, iterationPerf.PerTagPerformance[1].PrecisionStdDeviation);
            }
        }

        [Fact]
        public void ExportIteration()
        {
            using (MockContext context = MockContext.Start(this.GetType().Name))
            {
                HttpMockServer.Initialize(this.GetType().Name, "ExportIteration");

                ITrainingApi client = GetTrainingApiClient(HttpMockServer.CreateInstance());

                var iterations = client.GetIterationsAsync(ProjectId).Result;
                var exportableIteration = iterations.FirstOrDefault(e => e.Exportable);
                Assert.NotNull(exportableIteration);

                var export = client.ExportIterationAsync(ProjectId, exportableIteration.Id, "TensorFlow").Result;

                Assert.Equal("Exporting", export.Status);
                Assert.Null(export.DownloadUri);
                Assert.Equal("TensorFlow", export.Platform);
            }
        }

        [Fact]
        public void GetExports()
        {
            using (MockContext context = MockContext.Start(this.GetType().Name))
            {
                HttpMockServer.Initialize(this.GetType().Name, "GetExports");

                ITrainingApi client = GetTrainingApiClient(HttpMockServer.CreateInstance());

                var iterations = client.GetIterationsAsync(ProjectId).Result;
                var exportableIteration = iterations.FirstOrDefault(e => e.Exportable);
                Assert.NotNull(exportableIteration);

                var exports = client.GetExportsAsync(ProjectId, exportableIteration.Id).Result;
                Assert.Equal(1, exports.Count);
                Assert.Equal("TensorFlow", exports[0].Platform);
                Assert.NotEmpty(exports[0].DownloadUri);
                Assert.Equal("Done", exports[0].Status);
            }
        }

        [Fact]
        public async void TrainProject()
        {
            using (MockContext context = MockContext.Start(this.GetType().Name))
            {
                HttpMockServer.Initialize(this.GetType().Name, "TrainProject");

                ITrainingApi client = GetTrainingApiClient(HttpMockServer.CreateInstance());

                // Remove the last iteration so we can retrain
                var iterations = client.GetIterationsAsync(ProjectId).Result;
                var iterationToDelete = iterations[iterations.Count - 1];
                await client.DeleteIterationAsync(ProjectId, iterationToDelete.Id);

                var trainedIteration = client.TrainProjectAsync(ProjectId).Result;

                Assert.NotEqual(iterationToDelete.Name, trainedIteration.Name);
                Assert.NotEqual(iterationToDelete.Id, trainedIteration.Id);
                Assert.NotEqual(Guid.Empty, trainedIteration.Id);
                Assert.False(trainedIteration.IsDefault);
                Assert.Equal("Training", trainedIteration.Status);
                Assert.False(trainedIteration.Exportable);
            }
        }

        [Fact]
        public void GetTaggedImages()
        {
            using (MockContext context = MockContext.Start(this.GetType().Name))
            {
                HttpMockServer.Initialize(this.GetType().Name, "GetTaggedImages");

                ITrainingApi client = GetTrainingApiClient(HttpMockServer.CreateInstance());

                var images = client.GetTaggedImagesAsync(ProjectId).Result;
                var tag1 = images[0].Tags[0].TagId;

                var imagesWithTag1 = 0;

                Assert.Equal(18, images.Count);
                foreach (var image in images)
                {
                    Assert.NotEqual(Guid.Empty, image.Id);
                    Assert.NotEmpty(image.ImageUri);
                    Assert.NotEmpty(image.ThumbnailUri);
                    Assert.NotEqual(0, image.Width);
                    Assert.NotEqual(0, image.Height);
                    Assert.Equal(1, image.Tags.Count);
                    if (image.Tags[0].TagId == tag1)
                        imagesWithTag1++;
                }

                var tag1Images = client.GetTaggedImagesAsync(ProjectId, null, new string[] { tag1.ToString() }).Result;
                Assert.Equal(imagesWithTag1, tag1Images.Count);
            }
        }

        [Fact]
        public void GetUntaggedImages()
        {
            using (MockContext context = MockContext.Start(this.GetType().Name))
            {
                HttpMockServer.Initialize(this.GetType().Name, "GetUntaggedImages");

                ITrainingApi client = GetTrainingApiClient(HttpMockServer.CreateInstance());

                var images = client.GetUntaggedImagesAsync(ProjectId).Result;
                Assert.Equal(0, images.Count);
            }
        }

        [Fact]
        public async void ImageTagManipulation()
        {            
            using (MockContext context = MockContext.Start(this.GetType().Name))
            {
                HttpMockServer.Initialize(this.GetType().Name, "ImageTagManipulation");

                ITrainingApi client = GetTrainingApiClient(HttpMockServer.CreateInstance());

                var untaggedImages = client.GetUntaggedImagesAsync(ProjectId).Result;
                Assert.Equal(0, untaggedImages.Count);

                var taggedImages = client.GetTaggedImagesAsync(ProjectId).Result;
                Assert.Equal(17, taggedImages.Count);

                var imageToBeModified = taggedImages[0].Id;
                var tagToBeModified = taggedImages[0].Tags[0].TagId;

                await client.DeleteImageTagsAsync(ProjectId, new string[] { imageToBeModified.ToString() }, new string[] { tagToBeModified.ToString() });

                untaggedImages = client.GetUntaggedImagesAsync(ProjectId).Result;
                Assert.Equal(1, untaggedImages.Count);

                var imageTags = new ImageTagCreateEntry(imageToBeModified, tagToBeModified);
                var result = client.PostImageTagsAsync(ProjectId, new ImageTagCreateBatch(new ImageTagCreateEntry[] { imageTags })).Result;

                Assert.Equal(1, result.Created.Count);
                Assert.Equal(imageToBeModified, result.Created[0].ImageId);
                Assert.Equal(tagToBeModified, result.Created[0].TagId);
            }
        }

        [Fact]
        public async void DeleteImages()
        {
            using (MockContext context = MockContext.Start(this.GetType().Name))
            {
                HttpMockServer.Initialize(this.GetType().Name, "DeleteImages");

                ITrainingApi client = GetTrainingApiClient(HttpMockServer.CreateInstance());

                string imageUrl = "https://raw.githubusercontent.com/Microsoft/Cognitive-CustomVision-Windows/master/Samples/Images/Test/test_image.jpg";
                var urlImages = new ImageUrlCreateEntry[] { new ImageUrlCreateEntry(imageUrl) };
                var result = client.CreateImagesFromUrlsAsync(ProjectId, new ImageUrlCreateBatch(urlImages)).Result;
                Assert.True(result.IsBatchSuccessful);
                Assert.Equal(1, result.Images.Count);

                await client.DeleteImagesAsync(ProjectId, new string[] { result.Images[0].Image.Id.ToString() });
            }
        }

        [Fact]
        public void QuickTestImage()
        {
            var dataFileName = "test_image.jpg";

            using (MockContext context = MockContext.Start(this.GetType().Name))
            {
                HttpMockServer.Initialize(this.GetType().Name, "QuickTestImage");

                ITrainingApi client = GetTrainingApiClient(HttpMockServer.CreateInstance());

                using (FileStream stream = new FileStream(Path.Combine("TestImages", dataFileName), FileMode.Open))
                {   
                    var result = client.QuickTestImageAsync(ProjectId, stream).Result;
                    Assert.NotEqual(Guid.Empty, result.Id);
                    Assert.NotEqual(Guid.Empty, result.Iteration);
                    Assert.Equal(ProjectId, result.Project);
                    Assert.NotEqual(0, result.Predictions.Count);
                    Assert.Equal(1, result.Predictions[0].Probability);
                    Assert.Equal("Hemlock", result.Predictions[0].Tag);
                }
            }
        }

        [Fact]
        public void QuickTestImageUrl()
        {
            using (MockContext context = MockContext.Start(this.GetType().Name))
            {
                HttpMockServer.Initialize(this.GetType().Name, "QuickTestImageUrl");

                ITrainingApi client = GetTrainingApiClient(HttpMockServer.CreateInstance());

                string imageUrl = "https://raw.githubusercontent.com/Microsoft/Cognitive-CustomVision-Windows/master/Samples/Images/Test/test_image.jpg";
                var result = client.QuickTestImageUrlAsync(ProjectId, new ImageUrl(imageUrl)).Result;
                Assert.NotEqual(Guid.Empty, result.Id);
                Assert.NotEqual(Guid.Empty, result.Iteration);
                Assert.Equal(ProjectId, result.Project);
                Assert.NotEqual(0, result.Predictions.Count);
                Assert.Equal(1, result.Predictions[0].Probability);
                Assert.Equal("Hemlock", result.Predictions[0].Tag);
            }
        }

        [Fact]
        public void CreateImagesFromPredictions()
        {
            using (MockContext context = MockContext.Start(this.GetType().Name))
            {
                HttpMockServer.Initialize(this.GetType().Name, "CreateImagesFromPredictions");

                ITrainingApi client = GetTrainingApiClient(HttpMockServer.CreateInstance());

                string imageUrl = "https://raw.githubusercontent.com/Microsoft/Cognitive-CustomVision-Windows/master/Samples/Images/Test/test_image.jpg";
                var predictionResult = client.QuickTestImageUrlAsync(ProjectId, new ImageUrl(imageUrl)).Result;

                var i = new ImageIdCreateEntry[] { new ImageIdCreateEntry(predictionResult.Id) };
                var result = client.CreateImagesFromPredictionsAsync(ProjectId, new ImageIdCreateBatch(i)).Result;

                Assert.Equal(1, result.Images.Count);
                Assert.NotEmpty(result.Images[0].SourceUrl);
            }
        }

        [Fact]
        public void QueryPredictionResults()
        {
            using (MockContext context = MockContext.Start(this.GetType().Name))
            //using (MockContext context = new MockContext())
            {
                HttpMockServer.Initialize(this.GetType().Name, "QueryPredictionResults");

                ITrainingApi client = GetTrainingApiClient(HttpMockServer.CreateInstance());

                var token = new PredictionQueryToken()
                {
                    OrderBy = "Newest",
                };
                var result = client.QueryPredictionResultsAsync(ProjectId, token).Result;
                Assert.NotEqual(0, result.Results.Count);
                foreach (var prediction in result.Results)
                {
                    Assert.Equal(ProjectId, prediction.Project);
                    Assert.NotEqual(Guid.Empty, prediction.Id);
                    Assert.NotEqual(Guid.Empty, prediction.Iteration);
                    Assert.NotEmpty(prediction.ThumbnailUri);
                    Assert.NotEmpty(prediction.ImageUri);
                    Assert.NotEqual(0, prediction.Predictions.Count);
                }
            }
        }

        [Fact]
        public async void DeletePrediction()
        {
            using (MockContext context = MockContext.Start(this.GetType().Name))            
            {
                HttpMockServer.Initialize(this.GetType().Name, "DeletePrediction");

                ITrainingApi client = GetTrainingApiClient(HttpMockServer.CreateInstance());

                var token = new PredictionQueryToken()
                {
                    OrderBy = "Newest",
                };
                var result = client.QueryPredictionResultsAsync(ProjectId, token).Result;
                Assert.NotEqual(0, result.Results.Count);

                await client.DeletePredictionAsync(ProjectId, new string[] { result.Results[result.Results.Count - 1].Id.ToString() });
            }
        }
    }
}
