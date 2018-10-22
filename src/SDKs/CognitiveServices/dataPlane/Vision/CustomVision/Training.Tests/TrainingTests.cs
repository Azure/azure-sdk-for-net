namespace Microsoft.Azure.CognitiveServices.Vision.CustomVision.Training.Tests
{
    using Microsoft.Azure.CognitiveServices.Vision.CustomVision.Training.Models;
    using Microsoft.Azure.Test.HttpRecorder;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using Xunit;

    public class TrainingTests : BaseTests
    {
        private const string projName = "Test Project";
        private const string projDescription = "This is a test project";
        private const string tagName = "Test Tag 1";
        private const string tagDescription = "This is a test tag";

        public TrainingTests(ProjectIdFixture fixture)
            : base(fixture)
        {
        }

        [Fact]
        public async void CreateUpdateDeleteProject()
        {
            var updatedProjName = "Another Name";
            var updatedProjDescription = "Updated Project Description";

            using (MockContext context = MockContext.Start(this.GetType().Name))
            {
                HttpMockServer.Initialize(this.GetType().Name, "CreateUpdateDeleteProject", RecorderMode);

                ITrainingApi client = GetTrainingClient();
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
                HttpMockServer.Initialize(this.GetType().Name, "CreateDeleteProjectWithDomain", RecorderMode);

                ITrainingApi client = GetTrainingClient();
                var newProject = await client.CreateProjectAsync(projName, projDescription, FoodDomain);

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
                HttpMockServer.Initialize(this.GetType().Name, "CreateImageFromUrl", RecorderMode);

                ITrainingApi client = GetTrainingClient();
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
                HttpMockServer.Initialize(this.GetType().Name, "CreateImagesFromFiles", RecorderMode);

                ITrainingApi client = GetTrainingClient();
                var newProject = client.CreateProjectAsync(projName, projDescription, FoodDomain).Result;
                var tag = client.CreateTagAsync(newProject.Id, tagName).Result;
                var fileName = Path.Combine("TestImages", "tag1", dataFileName);
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
                HttpMockServer.Initialize(this.GetType().Name, "CreateImagesFromData", RecorderMode);

                ITrainingApi client = GetTrainingClient();
                var newProject = client.CreateProjectAsync(projName, projDescription, FoodDomain).Result;
                var tag = client.CreateTagAsync(newProject.Id, tagName).Result;
                using (FileStream stream = new FileStream(Path.Combine("TestImages", "tag1", dataFileName), FileMode.Open))
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
        public async void ProjectRetrieval()
        {
            using (MockContext context = MockContext.Start(this.GetType().Name))
            {
                HttpMockServer.Initialize(this.GetType().Name, "ProjectRetrieval", RecorderMode);

                ITrainingApi client = GetTrainingClient();

                var newProject = await client.CreateProjectAsync(projName, projDescription, FoodDomain);
                var projects = await client.GetProjectsAsync();

                Assert.True(projects.Count > 0);
                Assert.Contains(projects, p => p.Id == newProject.Id);

                var firstProject = await client.GetProjectAsync(projects[0].Id);

                Assert.Equal(projects[0].Id, firstProject.Id);
                Assert.Equal(projects[0].Name, firstProject.Name);
                Assert.Equal(projects[0].Description, firstProject.Description);
                Assert.Equal(projects[0].Settings.DomainId, firstProject.Settings.DomainId);

                await client.DeleteProjectAsync(newProject.Id);
            }
        }

        [Fact]
        public async void TagRetrieval()
        {
            using (MockContext context = MockContext.Start(this.GetType().Name))
            {
                HttpMockServer.Initialize(this.GetType().Name, "TagRetrieval", RecorderMode);

                ITrainingApi client = GetTrainingClient();

                var newProject = await client.CreateProjectAsync("TagRetrievalTest", projDescription, GeneralDomain);
                var numTags = 4;

                for (var i = 0; i < numTags; i++)
                {
                    await client.CreateTagAsync(newProject.Id, "Tag #" + i.ToString(), string.Empty);
                }

                var tagList = await client.GetTagsAsync(newProject.Id);

                Assert.Equal(numTags, tagList.Count);

                foreach (var tag in tagList)
                {
                    Assert.NotEqual(Guid.Empty, tag.Id);
                    Assert.Contains("Tag #", tag.Name);
                    Assert.Null(tag.Description);
                    Assert.Equal(0, tag.ImageCount);
                }

                await client.DeleteProjectAsync(newProject.Id);
            }
        }

        [Fact]
        public void DomainsApiTests()
        {
            using (MockContext context = MockContext.Start(this.GetType().Name))
            {
                HttpMockServer.Initialize(this.GetType().Name, "DomainsApiTests", RecorderMode);

                ITrainingApi client = GetTrainingClient();

                var domains = client.GetDomainsAsync().Result;
                Assert.Equal(9, domains.Count);

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
                HttpMockServer.Initialize(this.GetType().Name, "CreateUpdateDeleteTag", RecorderMode);

                ITrainingApi client = GetTrainingClient();

                var projectId = (await client.CreateProjectAsync(projName)).Id;

                var tag = await client.CreateTagAsync(projectId, tagName, tagDescription);

                Assert.Equal(tagName, tag.Name);
                Assert.Equal(tagDescription, tag.Description);
                Assert.Equal(0, tag.ImageCount);
                Assert.NotEqual(Guid.Empty, tag.Id);


                var updatedTag = await client.UpdateTagAsync(projectId, tag.Id, new Tag()
                {
                    Name = updatedName,
                    Description = updatedDescription
                });

                Assert.Equal(updatedName, updatedTag.Name);
                Assert.Equal(updatedDescription, updatedTag.Description);
                Assert.Equal(tag.ImageCount, updatedTag.ImageCount);
                Assert.Equal(tag.Id, updatedTag.Id);


                await client.DeleteTagAsync(projectId, tag.Id);
                await client.DeleteProjectAsync(projectId);
            }
        }

        [Fact]
        public async void GetIterations()
        {
            var updatedName = "New Iteration Name";

            using (MockContext context = MockContext.Start(this.GetType().Name))
            {
                HttpMockServer.Initialize(this.GetType().Name, "GetIterations", RecorderMode);

                var projectId = CreateTrainedImageClassificationProjectAsync();

                ITrainingApi client = GetTrainingClient();

                var iterations = await client.GetIterationsAsync(projectId);

                Assert.Equal(1, iterations.Count);
                Assert.NotEmpty(iterations[0].Name);
                Assert.NotEqual(Guid.Empty, iterations[0].DomainId);
                Assert.NotEqual(Guid.Empty, iterations[0].Id);
                Assert.Equal(projectId, iterations[0].ProjectId);
                Assert.True(iterations[0].IsDefault);
                Assert.Equal("Completed", iterations[0].Status);
                Assert.False(iterations[0].Exportable);

                var iteration = await client.GetIterationAsync(projectId, iterations[0].Id);
                Assert.Equal(iteration.Name, iterations[0].Name);
                Assert.Equal(iteration.Id, iterations[0].Id);
                Assert.True(iterations[0].IsDefault);

                var updatedIteration = await client.UpdateIterationAsync(projectId, iteration.Id, new Iteration()
                {
                    Name = updatedName,
                    IsDefault = !iterations[0].IsDefault,
                });

                Assert.Equal(updatedName, updatedIteration.Name);
                Assert.Equal(!iteration.IsDefault, updatedIteration.IsDefault);

                await client.DeleteProjectAsync(projectId);
            }
        }

        [Fact]
        public async void GetIterationPerformance()
        {
            using (MockContext context = MockContext.Start(this.GetType().Name))
            {
                HttpMockServer.Initialize(this.GetType().Name, "GetIterationPerformance", RecorderMode);

                var projectId = CreateTrainedImageClassificationProjectAsync();

                ITrainingApi client = GetTrainingClient();

                var iterations = client.GetIterationsAsync(projectId).Result;

                Assert.True(iterations.Count > 0);

                var iterationPerf = client.GetIterationPerformanceAsync(projectId, iterations[iterations.Count - 1].Id, 0.9).Result;
                Assert.Equal(1, iterationPerf.Recall);
                Assert.Equal(0, iterationPerf.RecallStdDeviation);
                Assert.Equal(1, iterationPerf.Precision);
                Assert.Equal(0, iterationPerf.PrecisionStdDeviation);
                Assert.Equal(2, iterationPerf.PerTagPerformance.Count);
                Assert.Equal("Tag1", iterationPerf.PerTagPerformance[0].Name);
                Assert.Equal(1, iterationPerf.PerTagPerformance[0].Recall);
                Assert.Equal(0, iterationPerf.PerTagPerformance[0].RecallStdDeviation);
                Assert.Equal(1, iterationPerf.PerTagPerformance[0].Precision);
                Assert.Equal(0, iterationPerf.PerTagPerformance[0].PrecisionStdDeviation);
                Assert.Equal("Tag2", iterationPerf.PerTagPerformance[1].Name);
                Assert.Equal(1, iterationPerf.PerTagPerformance[1].Recall);
                Assert.Equal(0, iterationPerf.PerTagPerformance[1].RecallStdDeviation);
                Assert.Equal(1, iterationPerf.PerTagPerformance[1].Precision);
                Assert.Equal(0, iterationPerf.PerTagPerformance[1].PrecisionStdDeviation);

                await client.DeleteProjectAsync(projectId);
            }
        }

        [Fact]
        public async void ExportTests()
        {
            using (MockContext context = MockContext.Start(this.GetType().Name))
            {
                HttpMockServer.Initialize(this.GetType().Name, "ExportTests", RecorderMode);

                var projectId = CreateTrainedImageClassificationProjectAsync(ExportableDomain);

                ITrainingApi client = GetTrainingClient();

                var iterations = await client.GetIterationsAsync(projectId);
                var exportableIteration = iterations.FirstOrDefault(e => e.Exportable);
                Assert.NotNull(exportableIteration);

                var export = await client.ExportIterationAsync(projectId, exportableIteration.Id, "TensorFlow");

                Assert.Equal("Exporting", export.Status);
                Assert.Null(export.DownloadUri);
                Assert.Equal("TensorFlow", export.Platform);
                Assert.False(export.NewerVersionAvailable);

                while (export.Status != "Done")
                {
                    var exports = await client.GetExportsAsync(projectId, exportableIteration.Id);
                    Assert.Equal(1, exports.Count);
                    export = exports.Where(e => e.Platform == "TensorFlow").FirstOrDefault();
                    Assert.NotNull(export);
                    Thread.Sleep(1000);
                }
                Assert.NotEmpty(export.DownloadUri);

                await client.DeleteProjectAsync(projectId);
            }
        }

        [Fact]
        public async void TrainProject()
        {
            using (MockContext context = MockContext.Start(this.GetType().Name))
            {
                HttpMockServer.Initialize(this.GetType().Name, "TrainProject", RecorderMode);

                var projectId = CreateTrainedImageClassificationProjectAsync();

                ITrainingApi client = GetTrainingClient();

                // Remove the last iteration so we can retrain
                var iterations = await client.GetIterationsAsync(projectId);
                var iterationToDelete = iterations[iterations.Count - 1];
                await client.DeleteIterationAsync(projectId, iterationToDelete.Id);

                var trainedIteration = await client.TrainProjectAsync(projectId);

                Assert.NotEqual(iterationToDelete.Name, trainedIteration.Name);
                Assert.NotEqual(iterationToDelete.Id, trainedIteration.Id);
                Assert.NotEqual(Guid.Empty, trainedIteration.Id);
                Assert.False(trainedIteration.IsDefault);
                Assert.True("Staging" == trainedIteration.Status || "Training" == trainedIteration.Status);
                Assert.False(trainedIteration.Exportable);

                await client.DeleteProjectAsync(projectId);
            }
        }

        [Fact]
        public async void GetTaggedImages()
        {
            using (MockContext context = MockContext.Start(this.GetType().Name))
            {
                HttpMockServer.Initialize(this.GetType().Name, "GetTaggedImages", RecorderMode);

                var projectId = CreateTrainedImageClassificationProjectAsync();

                ITrainingApi client = GetTrainingClient();

                var images = client.GetTaggedImagesAsync(projectId).Result;
                var tag1 = images[0].Tags[0].TagId;

                var imagesWithTag1 = 0;

                Assert.Equal(10, images.Count);
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

                var tag1Images = client.GetTaggedImagesAsync(projectId, null, new string[] { tag1.ToString() }).Result;
                Assert.Equal(imagesWithTag1, tag1Images.Count);

                await client.DeleteProjectAsync(projectId);
            }
        }

        [Fact]
        public async void GetUntaggedImages()
        {
            using (MockContext context = MockContext.Start(this.GetType().Name))
            {
                HttpMockServer.Initialize(this.GetType().Name, "GetUntaggedImages", RecorderMode);

                var projectId = CreateTrainedImageClassificationProjectAsync();

                ITrainingApi client = GetTrainingClient();

                var images = client.GetUntaggedImagesAsync(projectId).Result;
                Assert.Equal(0, images.Count);

                await client.DeleteProjectAsync(projectId);
            }
        }

        [Fact]
        public async void ImageTagManipulation()
        {
            using (MockContext context = MockContext.Start(this.GetType().Name))
            {
                HttpMockServer.Initialize(this.GetType().Name, "ImageTagManipulation", RecorderMode);

                var projectId = CreateTrainedImageClassificationProjectAsync();

                ITrainingApi client = GetTrainingClient();

                var untaggedImages = client.GetUntaggedImagesAsync(projectId).Result;
                Assert.Equal(0, untaggedImages.Count);

                var taggedImages = client.GetTaggedImagesAsync(projectId).Result;
                Assert.Equal(10, taggedImages.Count);

                var imageToBeModified = taggedImages[0].Id;
                var tagToBeModified = taggedImages[0].Tags[0].TagId;

                await client.DeleteImageTagsAsync(projectId, new string[] { imageToBeModified.ToString() }, new string[] { tagToBeModified.ToString() });

                untaggedImages = client.GetUntaggedImagesAsync(projectId).Result;
                Assert.Equal(1, untaggedImages.Count);

                var imageTags = new ImageTagCreateEntry(imageToBeModified, tagToBeModified);
                var result = client.CreateImageTagsAsync(projectId, new ImageTagCreateBatch(new ImageTagCreateEntry[] { imageTags })).Result;

                Assert.Equal(1, result.Created.Count);
                Assert.Equal(imageToBeModified, result.Created[0].ImageId);
                Assert.Equal(tagToBeModified, result.Created[0].TagId);

                await client.DeleteProjectAsync(projectId);
            }
        }

        [Fact]
        public async void DeleteImages()
        {
            using (MockContext context = MockContext.Start(this.GetType().Name))
            {
                HttpMockServer.Initialize(this.GetType().Name, "DeleteImages", RecorderMode);

                ITrainingApi client = GetTrainingClient();

                var projectId = (await client.CreateProjectAsync(projName)).Id;

                string imageUrl = "https://raw.githubusercontent.com/Microsoft/Cognitive-CustomVision-Windows/master/Samples/Images/Test/test_image.jpg";
                var urlImages = new ImageUrlCreateEntry[] { new ImageUrlCreateEntry(imageUrl) };
                var result = client.CreateImagesFromUrlsAsync(projectId, new ImageUrlCreateBatch(urlImages)).Result;
                Assert.True(result.IsBatchSuccessful);
                Assert.Equal(1, result.Images.Count);

                await client.DeleteImagesAsync(projectId, new string[] { result.Images[0].Image.Id.ToString() });
                await client.DeleteProjectAsync(projectId);
            }
        }

        [Fact]
        public async void QuickTests()
        {
            var dataFileName = "test_image.jpg";

            using (MockContext context = MockContext.Start(this.GetType().Name))
            {
                HttpMockServer.Initialize(this.GetType().Name, "QuickTests", RecorderMode);

                var projectId = CreateTrainedImageClassificationProjectAsync();

                ITrainingApi client = GetTrainingClient();

                using (FileStream stream = new FileStream(Path.Combine("TestImages", dataFileName), FileMode.Open))
                {
                    var imageResult = await client.QuickTestImageAsync(projectId, stream);
                    Assert.NotEqual(Guid.Empty, imageResult.Id);
                    Assert.NotEqual(Guid.Empty, imageResult.Iteration);
                    Assert.Equal(projectId, imageResult.Project);
                    Assert.NotEqual(0, imageResult.Predictions.Count);
                    Assert.InRange(imageResult.Predictions[0].Probability, 0.9, 1);
                    Assert.Equal("Tag1", imageResult.Predictions[0].TagName);
                }

                string imageUrl = "https://raw.githubusercontent.com/Microsoft/Cognitive-CustomVision-Windows/master/Samples/Images/Test/test_image.jpg";
                var urlResult = await client.QuickTestImageUrlAsync(projectId, new ImageUrl(imageUrl));
                Assert.NotEqual(Guid.Empty, urlResult.Id);
                Assert.NotEqual(Guid.Empty, urlResult.Iteration);
                Assert.Equal(projectId, urlResult.Project);
                Assert.NotEqual(0, urlResult.Predictions.Count);
                Assert.InRange(urlResult.Predictions[0].Probability, 0.9, 1);
                Assert.Equal("Tag1", urlResult.Predictions[0].TagName);

                await client.DeleteProjectAsync(projectId);
            }
        }

        [Fact]
        public async void CreateImagesFromPredictions()
        {
            using (MockContext context = MockContext.Start(this.GetType().Name))
            {
                HttpMockServer.Initialize(this.GetType().Name, "CreateImagesFromPredictions", RecorderMode);

                var projectId = CreateTrainedImageClassificationProjectAsync();

                ITrainingApi client = GetTrainingClient();

                string imageUrl = "https://raw.githubusercontent.com/Microsoft/Cognitive-CustomVision-Windows/master/Samples/Images/Test/test_image.jpg";
                var predictionResult = client.QuickTestImageUrlAsync(projectId, new ImageUrl(imageUrl)).Result;

                var i = new ImageIdCreateEntry[] { new ImageIdCreateEntry(predictionResult.Id) };
                var result = client.CreateImagesFromPredictionsAsync(projectId, new ImageIdCreateBatch(i)).Result;

                Assert.Equal(1, result.Images.Count);
                Assert.NotEmpty(result.Images[0].SourceUrl);

                await client.DeleteProjectAsync(projectId);
            }
        }

        [Fact]
        public async void QueryPredictionResults()
        {
            using (MockContext context = MockContext.Start(this.GetType().Name))
            {
                HttpMockServer.Initialize(this.GetType().Name, "QueryPredictionResults", RecorderMode);

                var projectId = CreateTrainedImageClassificationProjectAsync();

                ITrainingApi client = GetTrainingClient();

                var token = new PredictionQueryToken()
                {
                    OrderBy = "Newest",
                };
                var result = client.QueryPredictionsAsync(projectId, token).Result;
                Assert.NotEqual(0, result.Results.Count);
                foreach (var prediction in result.Results)
                {
                    Assert.Equal(projectId, prediction.Project);
                    Assert.NotEqual(Guid.Empty, prediction.Id);
                    Assert.NotEqual(Guid.Empty, prediction.Iteration);
                    Assert.NotEmpty(prediction.ThumbnailUri);
                    Assert.NotEmpty(prediction.ImageUri);
                    Assert.NotEqual(0, prediction.Predictions.Count);
                }

                await client.DeleteProjectAsync(projectId);
            }
        }

        [Fact]
        public async void DeletePrediction()
        {
            using (MockContext context = MockContext.Start(this.GetType().Name))
            {
                HttpMockServer.Initialize(this.GetType().Name, "DeletePrediction", RecorderMode);

                var projectId = CreateTrainedImageClassificationProjectAsync();

                ITrainingApi client = GetTrainingClient();

                var token = new PredictionQueryToken()
                {
                    OrderBy = "Newest",
                };
                var result = client.QueryPredictionsAsync(projectId, token).Result;
                Assert.NotEqual(0, result.Results.Count);

                await client.DeletePredictionAsync(projectId, new string[] { result.Results[result.Results.Count - 1].Id.ToString() });
                await client.DeleteProjectAsync(projectId);
            }
        }

        [Fact]
        public async void GetImagesByIds()
        {
            using (MockContext context = MockContext.Start(this.GetType().Name))
            {
                HttpMockServer.Initialize(this.GetType().Name, "GetImagesByIds", RecorderMode);

                var projectId = CreateTrainedImageClassificationProjectAsync();

                ITrainingApi client = GetTrainingClient();

                var tags = await client.GetTagsAsync(projectId);
                var imagesForTag = await client.GetTaggedImagesAsync(projectId, null, new List<string>(new string[] { tags[0].Id.ToString() }));
                Assert.Equal(5, imagesForTag.Count);

                var images = await client.GetImagesByIdsAsync(projectId, imagesForTag.Select(img => img.Id.ToString()).ToList());
                Assert.Equal(5, images.Count);

                foreach (var image in images)
                {
                    Assert.Equal(1, image.Tags.Count);
                    var tag = image.Tags[0];
                    Assert.Equal(tags[0].Id, tag.TagId);
                    Assert.Equal(tags[0].Name, tag.TagName);
                    Assert.NotNull(image.ThumbnailUri);
                    Assert.NotNull(image.ImageUri);
                    Assert.True(image.Width > 0);
                    Assert.True(image.Height > 0);
                }

                await client.DeleteProjectAsync(projectId);
            }
        }

        [Fact]
        public async void ImageCounts()
        {
            using (MockContext context = MockContext.Start(this.GetType().Name))
            {
                HttpMockServer.Initialize(this.GetType().Name, "ImageCounts", RecorderMode);

                var projectId = CreateTrainedImageClassificationProjectAsync();

                ITrainingApi client = GetTrainingClient();

                var taggedImageCount = await client.GetTaggedImageCountAsync(projectId);
                Assert.Equal(10, taggedImageCount);

                var untaggedImageCount = await client.GetUntaggedImageCountAsync(projectId);
                Assert.Equal(0, untaggedImageCount);

                var iterationId = (await client.GetIterationsAsync(projectId))[0].Id;
                var imagePerfCount = await client.GetImagePerformanceCountAsync(projectId, iterationId);
                Assert.Equal(10, imagePerfCount);

                await client.DeleteProjectAsync(projectId);
            }
        }

        [Fact]
        public async void DownloadRegions()
        {
            using (MockContext context = MockContext.Start(this.GetType().Name))
            {
                HttpMockServer.Initialize(this.GetType().Name, "DownloadRegions", RecorderMode);

                var projectId = CreateTrainedObjDetectionProject();

                ITrainingApi client = GetTrainingClient();

                var images = await client.GetTaggedImagesAsync(projectId);
                foreach (var img in images)
                {
                    Assert.NotNull(img.Regions);
                    Assert.Equal(1, img.Regions.Count);
                    Assert.InRange(img.Regions[0].Left, 0, 1);
                    Assert.InRange(img.Regions[0].Top, 0, 1);
                    Assert.InRange(img.Regions[0].Width, 0, 1);
                    Assert.InRange(img.Regions[0].Height, 0, 1);
                }
            }
        }

        [Fact]
        public async void RegionManipulation()
        {
            using (MockContext context = MockContext.Start(this.GetType().Name))
            {
                HttpMockServer.Initialize(this.GetType().Name, "RegionManipulation", RecorderMode);

                var projectId = CreateTrainedObjDetectionProject();

                ITrainingApi client = GetTrainingClient();

                var existingImage = (await client.GetTaggedImagesAsync(projectId)).First();
                Assert.NotNull(existingImage);

                var testTag = await client.CreateTagAsync(projectId, tagName);

                var proposal = await client.GetImageRegionProposalsAsync(projectId, existingImage.Id);
                Assert.True(proposal.Proposals.Count > 0);
                Assert.Equal(projectId, proposal.ProjectId);
                Assert.Equal(existingImage.Id, proposal.ImageId);
                Assert.InRange(proposal.Proposals[0].Confidence, 0, 1);

                var bbox = proposal.Proposals[0].BoundingBox;
                List<ImageRegionCreateEntry> newRegions = new List<ImageRegionCreateEntry>();
                newRegions.Add(new ImageRegionCreateEntry(existingImage.Id, testTag.Id, bbox.Left, bbox.Top, bbox.Width, bbox.Height));

                var regions = await client.CreateImageRegionsAsync(projectId, new ImageRegionCreateBatch(newRegions));
                Assert.Equal(1, regions.Created.Count);
                Assert.Equal(0, regions.Duplicated.Count);
                Assert.Equal(0, regions.Exceeded.Count);
                Assert.Equal(bbox.Top, regions.Created[0].Top);
                Assert.Equal(bbox.Left, regions.Created[0].Left);
                Assert.Equal(bbox.Width, regions.Created[0].Width);
                Assert.Equal(bbox.Height, regions.Created[0].Height);
                Assert.Equal(existingImage.Id, regions.Created[0].ImageId);
                Assert.Equal(testTag.Id, regions.Created[0].TagId);
                Assert.NotEqual(Guid.Empty, regions.Created[0].RegionId);

                var image = await client.GetImagesByIdsAsync(projectId, new List<string>(new string[] { existingImage.Id.ToString() }));
                Assert.Equal(1, image.Count);
                Assert.Equal(2, image[0].Regions.Count);

                await client.DeleteImageRegionsAsync(projectId, new List<string>(new string[] { regions.Created[0].RegionId.ToString() }));

                image = await client.GetImagesByIdsAsync(projectId, new List<string>(new string[] { existingImage.Id.ToString() }));
                Assert.Equal(1, image.Count);
                Assert.Equal(1, image[0].Regions.Count);

                await client.DeleteTagAsync(projectId, testTag.Id);
            }
        }

        [Fact]
        public async void ObjDetectionPrediction()
        {
            using (MockContext context = MockContext.Start(this.GetType().Name))
            {
                HttpMockServer.Initialize(this.GetType().Name, "ObjDetectionPrediction", RecorderMode);

                var projectId = CreateTrainedObjDetectionProject();

                ITrainingApi client = GetTrainingClient();

                using (FileStream stream = new FileStream(Path.Combine("TestImages", "od_test_image.jpg"), FileMode.Open))
                {
                    var imageResult = await client.QuickTestImageAsync(projectId, stream);
                    Assert.NotEqual(Guid.Empty, imageResult.Id);
                    Assert.NotEqual(Guid.Empty, imageResult.Iteration);
                    Assert.Equal(projectId, imageResult.Project);
                    Assert.NotEqual(0, imageResult.Predictions.Count);
                    Assert.InRange(imageResult.Predictions[0].Probability, 0.5, 1);
                    Assert.NotNull(imageResult.Predictions[0].BoundingBox);
                    Assert.InRange(imageResult.Predictions[0].BoundingBox.Left, 0, 1);
                    Assert.InRange(imageResult.Predictions[0].BoundingBox.Top, 0, 1);
                    Assert.InRange(imageResult.Predictions[0].BoundingBox.Width, 0, 1);
                    Assert.InRange(imageResult.Predictions[0].BoundingBox.Height, 0, 1);
                }
            }
        }
    }
}
