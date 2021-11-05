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

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "CreateUpdateDeleteProject", RecorderMode);

                using (ICustomVisionTrainingClient client = GetTrainingClient())
                {
                    var newProject = client.CreateProjectAsync(projName, projDescription).Result;

                    Assert.Contains(projName, newProject.Name);
                    Assert.Equal(projDescription, newProject.Description);
                    Assert.NotEqual(Guid.Empty, newProject.Id);
                    Assert.False(newProject.DrModeEnabled);
                    Assert.NotNull(newProject.Settings);
                    Assert.True(newProject.Settings.UseNegativeSet);
                    Assert.Null(newProject.Settings.DetectionParameters);
                    Assert.NotEqual(Guid.Empty, newProject.Settings.DomainId);
                    Assert.NotNull(newProject.Settings.ImageProcessingSettings);
                    Assert.Equal(Classifier.Multilabel, newProject.Settings.ClassificationType);

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
        }

        [Fact]
        public async void CreateDeleteProjectWithDomain()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "CreateDeleteProjectWithDomain", RecorderMode);

                using (ICustomVisionTrainingClient client = GetTrainingClient())
                {
                    var newProject = await client.CreateProjectAsync(projName, projDescription, ProjectBuilderHelper.FoodDomain);

                    Assert.Contains(projName, newProject.Name);
                    Assert.Equal(projDescription, newProject.Description);
                    Assert.Equal(ProjectBuilderHelper.FoodDomain, newProject.Settings.DomainId);
                    Assert.NotEqual(Guid.Empty, newProject.Id);

                    await client.DeleteProjectAsync(newProject.Id);
                }
            }
        }

        [Fact]
        public async void CreateImageFromUrl()
        {
            string imageUrl = "https://raw.githubusercontent.com/Microsoft/Cognitive-CustomVision-Windows/master/Samples/Images/Hemlock/hemlock_1.jpg";

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "CreateImageFromUrl", RecorderMode);

                using (ICustomVisionTrainingClient client = GetTrainingClient())
                {
                    var newProject = client.CreateProjectAsync(projName, projDescription, ProjectBuilderHelper.FoodDomain).Result;
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
                    Assert.NotEmpty(imageCreatedFromUrl.Images[0].Image.OriginalImageUri);
                    Assert.NotEmpty(imageCreatedFromUrl.Images[0].Image.ResizedImageUri);
                    Assert.NotEmpty(imageCreatedFromUrl.Images[0].Image.ThumbnailUri);

                    await client.DeleteProjectAsync(newProject.Id);
                }
            }
        }

        [Fact]
        public async void CreateImagesFromFiles()
        {
            var dataFileName = "hemlock_1.jpg";

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "CreateImagesFromFiles", RecorderMode);

                using (ICustomVisionTrainingClient client = GetTrainingClient())
                {
                    var newProject = client.CreateProjectAsync(projName, projDescription, ProjectBuilderHelper.FoodDomain).Result;
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
                    Assert.NotEmpty(imageCreatedFromFile.Images[0].Image.OriginalImageUri);
                    Assert.NotEmpty(imageCreatedFromFile.Images[0].Image.ResizedImageUri);
                    Assert.NotEmpty(imageCreatedFromFile.Images[0].Image.ThumbnailUri);

                    await client.DeleteProjectAsync(newProject.Id);
                }
            }
        }

        [Fact]
        public async void CreateImagesFromData()
        {
            var dataFileName = "hemlock_1.jpg";

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "CreateImagesFromData", RecorderMode);

                using (ICustomVisionTrainingClient client = GetTrainingClient())
                {
                    var newProject = client.CreateProjectAsync(projName, projDescription, ProjectBuilderHelper.FoodDomain).Result;
                    var tag = client.CreateTagAsync(newProject.Id, tagName).Result;
                    using (FileStream stream = new FileStream(Path.Combine("TestImages", "tag1", dataFileName), FileMode.Open))
                    {
                        var imageCreatedFromData = client.CreateImagesFromDataAsync(newProject.Id, stream, new Guid[] { tag.Id }).Result;

                        Assert.True(imageCreatedFromData.IsBatchSuccessful);
                        Assert.Equal(1, imageCreatedFromData.Images.Count);
                        Assert.Contains(dataFileName, imageCreatedFromData.Images[0].SourceUrl);
                        Assert.Equal("OK", imageCreatedFromData.Images[0].Status);
                        Assert.NotEqual(Guid.Empty, imageCreatedFromData.Images[0].Image.Id);
                        Assert.NotEqual(0, imageCreatedFromData.Images[0].Image.Width);
                        Assert.NotEqual(0, imageCreatedFromData.Images[0].Image.Height);
                        Assert.NotEmpty(imageCreatedFromData.Images[0].Image.OriginalImageUri);
                        Assert.NotEmpty(imageCreatedFromData.Images[0].Image.ResizedImageUri);
                        Assert.NotEmpty(imageCreatedFromData.Images[0].Image.ThumbnailUri);
                    }
                    await client.DeleteProjectAsync(newProject.Id);
                }
            }
        }

        [Fact]
        public async void ProjectRetrieval()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "ProjectRetrieval", RecorderMode);

                using (ICustomVisionTrainingClient client = GetTrainingClient())
                {
                    var newProject = await client.CreateProjectAsync(projName, projDescription, ProjectBuilderHelper.FoodDomain);
                    var projects = await client.GetProjectsAsync();

                    Assert.True(projects.Count > 0);
                    Assert.Contains(projects, p => p.Id == newProject.Id);

                    var firstProject = await client.GetProjectAsync(projects[0].Id);

                    Assert.Equal(projects[0].Id, firstProject.Id);
                    Assert.Equal(projects[0].Name, firstProject.Name);
                    Assert.Equal(projects[0].Description, firstProject.Description);
                    Assert.Equal(projects[0].Settings.DomainId, firstProject.Settings.DomainId);
                    Assert.Equal(projects[0].Settings.TargetExportPlatforms.Count, firstProject.Settings.TargetExportPlatforms.Count);
                    Assert.Equal(projects[0].DrModeEnabled, firstProject.DrModeEnabled);

                    await client.DeleteProjectAsync(newProject.Id);
                }
            }
        }

        [Fact]
        public async void TagRetrieval()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "TagRetrieval", RecorderMode);

                using (ICustomVisionTrainingClient client = GetTrainingClient())
                {
                    var newProject = await client.CreateProjectAsync("TagRetrievalTest", projDescription, ProjectBuilderHelper.GeneralDomain);
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
        }

        [Fact]
        public void DomainsApiTests()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "DomainsApiTests", RecorderMode);

                using (ICustomVisionTrainingClient client = GetTrainingClient())
                {
                    var domains = client.GetDomainsAsync().Result;
                    Assert.Equal(14, domains.Count);

                    var foodDomain = domains.FirstOrDefault(d => d.Id == ProjectBuilderHelper.FoodDomain);
                    Assert.NotNull(foodDomain);
                    Assert.False(foodDomain.Exportable);
                    Assert.Contains("food", foodDomain.Name.ToLowerInvariant());
                    Assert.Null(foodDomain.ModelInformation);

                    var generalDomain = client.GetDomainAsync(ProjectBuilderHelper.GeneralDomain).Result;
                    Assert.Equal(ProjectBuilderHelper.GeneralDomain, generalDomain.Id);
                    Assert.False(generalDomain.Exportable);
                    Assert.Contains("general", generalDomain.Name.ToLowerInvariant());
                    Assert.Null(generalDomain.ModelInformation);

                    // Verify exportable domains have model information
                    foreach(var domain in domains)
                    {
                        if (domain.Exportable)
                        {
                            Assert.NotNull(domain.ModelInformation);
                            Assert.NotEmpty(domain.ModelInformation.Description);
                            Assert.True(domain.ModelInformation.EstimatedModelSizeInMegabytes > 0);
                        }
                    }
                }
            }
        }

        [Fact]
        public async void CreateUpdateDeleteTag()
        {
            var updatedName = "New Tag Name";
            var updatedDescription = "Updated Description";

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "CreateUpdateDeleteTag", RecorderMode);

                using (ICustomVisionTrainingClient client = GetTrainingClient())
                {
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
        }

        [Fact]
        public async void GetIterations()
        {
            var updatedName = "New Iteration Name";

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "GetIterations", RecorderMode);

                using (var project = CreateTrainedImageClassificationProject())
                {
                    ICustomVisionTrainingClient client = BaseTests.GetTrainingClient();

                    var iterations = await client.GetIterationsAsync(project.ProjectId);

                    Assert.Equal(1, iterations.Count);
                    Assert.NotEmpty(iterations[0].Name);
                    Assert.NotEqual(Guid.Empty, iterations[0].DomainId);
                    Assert.NotEqual(Guid.Empty, iterations[0].Id);
                    Assert.Equal(project.ProjectId, iterations[0].ProjectId);
                    Assert.Equal("Completed", iterations[0].Status);
                    Assert.False(iterations[0].Exportable);

                    var iteration = await client.GetIterationAsync(project.ProjectId, iterations[0].Id);
                    Assert.Equal(iteration.Name, iterations[0].Name);
                    Assert.Equal(iteration.Id, iterations[0].Id);
                    Assert.Equal(TrainingType.Regular, iteration.TrainingType);
                    Assert.Equal(0, iteration.ReservedBudgetInHours);
                    Assert.NotEmpty(iteration.PublishName);
                    Assert.Equal(1, iteration.TrainingTimeInMinutes);
                    Assert.Equal(BaseTests.PredictionResourceId, iteration.OriginalPublishResourceId);

                    var updatedIteration = await client.UpdateIterationAsync(project.ProjectId, iteration.Id, new Iteration()
                    {
                        Name = updatedName
                    });

                    Assert.Equal(updatedName, updatedIteration.Name);

                }
            }
        }

        [Fact]
        public async void GetIterationPerformance()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "GetIterationPerformance", RecorderMode);

                using (var project = CreateTrainedImageClassificationProject())
                {
                    ICustomVisionTrainingClient client = BaseTests.GetTrainingClient();

                    var iterations = await client.GetIterationsAsync(project.ProjectId);

                    Assert.True(iterations.Count > 0);

                    var iterationPerf = await client.GetIterationPerformanceAsync(project.ProjectId, iterations[iterations.Count - 1].Id, 0.9);
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
                }
            }
        }

        [Fact]
        public async void ExportTests()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "ExportTests", RecorderMode);

                using (var project = CreateTrainedImageClassificationProject(ProjectBuilderHelper.ExportableDomain))
                {
                    ICustomVisionTrainingClient client = BaseTests.GetTrainingClient();

                    var iterations = await client.GetIterationsAsync(project.ProjectId);
                    var exportableIteration = iterations.FirstOrDefault(e => e.Exportable);
                    Assert.NotNull(exportableIteration);

                    var export = await client.ExportIterationAsync(project.ProjectId, exportableIteration.Id, ExportPlatform.TensorFlow);

                    Assert.Equal("Exporting", export.Status);
                    Assert.Null(export.DownloadUri);
                    Assert.Equal(ExportPlatform.TensorFlow, export.Platform);
                    Assert.False(export.NewerVersionAvailable);

                    while (export.Status != "Done")
                    {
                        var exports = await client.GetExportsAsync(project.ProjectId, exportableIteration.Id);
                        Assert.Equal(1, exports.Count);
                        export = exports.Where(e => e.Platform == ExportPlatform.TensorFlow).FirstOrDefault();
                        Assert.NotNull(export);
#if RECORD_MODE
                        Thread.Sleep(1000);
#endif
                    }
                    Assert.NotEmpty(export.DownloadUri);
                }
            }
        }

        [Fact]
        public async void TrainAndPublishProject()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "TrainAndPublishProject", RecorderMode);

                using (var project = CreateTrainedImageClassificationProject())
                {
                    ICustomVisionTrainingClient client = BaseTests.GetTrainingClient();

                    // Remove the last trained iteration so we can retrain
                    var iterationToDelete = client.GetIteration(project.ProjectId, project.IterationId);

                    var originalPublishName = iterationToDelete.PublishName;
                    await client.UnpublishIterationAsync(project.ProjectId, iterationToDelete.Id);
                    await client.DeleteIterationAsync(project.ProjectId, iterationToDelete.Id);

                    // Need to ensure we wait 1 second between training calls from the previous project.Or
                    // We get 429s.
#if RECORD_MODE
                    Thread.Sleep(1000);
#endif
                    var trainedIteration = await client.TrainProjectAsync(project.ProjectId);

                    Assert.NotEqual(iterationToDelete.Name, trainedIteration.Name);
                    Assert.NotEqual(iterationToDelete.Id, trainedIteration.Id);
                    Assert.NotEqual(Guid.Empty, trainedIteration.Id);
                    Assert.True("Staging" == trainedIteration.Status || "Training" == trainedIteration.Status);
                    Assert.False(trainedIteration.Exportable);
                    Assert.Null(trainedIteration.PublishName);

                    // Wait for training to complete.
                    while (trainedIteration.Status != "Completed")
                    {
#if RECORD_MODE
                        Thread.Sleep(1000);
#endif
                        trainedIteration = client.GetIteration(project.ProjectId, trainedIteration.Id);
                    }

                    // Verify we can republish using same name
                    Assert.True(client.PublishIteration(project.ProjectId, trainedIteration.Id, originalPublishName, BaseTests.PredictionResourceId));
                    project.IterationId = trainedIteration.Id;
                }
            }
        }

        [Fact]
        public async void GetTaggedImages()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "GetTaggedImages", RecorderMode);

                using (var project = CreateTrainedImageClassificationProject())
                using (ICustomVisionTrainingClient client = GetTrainingClient())
                {
                    var images = await client.GetTaggedImagesAsync(project.ProjectId);
                    var tag1 = images[0].Tags[0].TagId;

                    var imagesWithTag1 = 0;

                    Assert.Equal(10, images.Count);
                    foreach (var image in images)
                    {
                        Assert.NotEqual(Guid.Empty, image.Id);
                        Assert.NotEmpty(image.OriginalImageUri);
                        Assert.NotEmpty(image.ResizedImageUri);
                        Assert.NotEmpty(image.ThumbnailUri);
                        Assert.NotEqual(0, image.Width);
                        Assert.NotEqual(0, image.Height);
                        Assert.Equal(1, image.Tags.Count);
                        if (image.Tags[0].TagId == tag1)
                            imagesWithTag1++;
                    }

                    var tag1Images = await client.GetTaggedImagesAsync(project.ProjectId, null, new Guid[] { tag1 });
                    Assert.Equal(imagesWithTag1, tag1Images.Count);
                }
            }
        }

        [Fact]
        public async void GetUntaggedImages()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "GetUntaggedImages", RecorderMode);

                using (var project = CreateTrainedImageClassificationProject())
                {
                    ICustomVisionTrainingClient client = BaseTests.GetTrainingClient();

                    var images = await client.GetUntaggedImagesAsync(project.ProjectId);
                    Assert.Equal(0, images.Count);
                }
            }
        }

        [Fact]
        public async void ImageTagManipulation()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "ImageTagManipulation", RecorderMode);

                using (var project = CreateTrainedImageClassificationProject())
                {
                    ICustomVisionTrainingClient client = BaseTests.GetTrainingClient();

                    var untaggedImages = client.GetUntaggedImagesAsync(project.ProjectId).Result;
                    Assert.Equal(0, untaggedImages.Count);

                    var taggedImages = client.GetTaggedImagesAsync(project.ProjectId).Result;
                    Assert.Equal(10, taggedImages.Count);

                    var imageToBeModified = taggedImages[0].Id;
                    var tagToBeModified = taggedImages[0].Tags[0].TagId;

                    await client.DeleteImageTagsAsync(project.ProjectId, new Guid[] { imageToBeModified }, new Guid[] { tagToBeModified });

                    untaggedImages = client.GetUntaggedImagesAsync(project.ProjectId).Result;
                    Assert.Equal(1, untaggedImages.Count);

                    var imageTags = new ImageTagCreateEntry(imageToBeModified, tagToBeModified);
                    var result = client.CreateImageTagsAsync(project.ProjectId, new ImageTagCreateBatch(new ImageTagCreateEntry[] { imageTags })).Result;

                    Assert.Equal(1, result.Created.Count);
                    Assert.Equal(imageToBeModified, result.Created[0].ImageId);
                    Assert.Equal(tagToBeModified, result.Created[0].TagId);
                }
            }
        }

        [Fact]
        public async void DeleteImages()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "DeleteImages", RecorderMode);

                using (ICustomVisionTrainingClient client = BaseTests.GetTrainingClient())
                {
                    var projectId = (await client.CreateProjectAsync(projName)).Id;

                    string imageUrl = "https://raw.githubusercontent.com/Microsoft/Cognitive-CustomVision-Windows/master/Samples/Images/Test/test_image.jpg";
                    var urlImages = new ImageUrlCreateEntry[] { new ImageUrlCreateEntry(imageUrl) };
                    var result = client.CreateImagesFromUrlsAsync(projectId, new ImageUrlCreateBatch(urlImages)).Result;
                    Assert.True(result.IsBatchSuccessful);
                    Assert.Equal(1, result.Images.Count);

                    await client.DeleteImagesAsync(projectId, new Guid[] { result.Images[0].Image.Id });
                    await client.DeleteProjectAsync(projectId);
                }
            }
        }

        [Fact]
        public async void QuickTests()
        {
            var dataFileName = "test_image.jpg";

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "QuickTests", RecorderMode);

                using (var project = CreateTrainedImageClassificationProject())
                using (ICustomVisionTrainingClient client = BaseTests.GetTrainingClient())
                {
                    using (FileStream stream = new FileStream(Path.Combine("TestImages", dataFileName), FileMode.Open))
                    {
                        var imageResult = await client.QuickTestImageAsync(project.ProjectId, stream, project.IterationId);
                        Assert.NotEqual(Guid.Empty, imageResult.Id);
                        Assert.NotEqual(Guid.Empty, imageResult.Iteration);
                        Assert.Equal(project.ProjectId, imageResult.Project);
                        Assert.NotEqual(0, imageResult.Predictions.Count);
                        Assert.InRange(imageResult.Predictions[0].Probability, 0.9, 1);
                        Assert.Equal("Tag1", imageResult.Predictions[0].TagName);
                    }

                    string imageUrl = "https://raw.githubusercontent.com/Microsoft/Cognitive-CustomVision-Windows/master/Samples/Images/Test/test_image.jpg";
                    var urlResult = await client.QuickTestImageUrlAsync(project.ProjectId, new ImageUrl(imageUrl), project.IterationId);
                    Assert.NotEqual(Guid.Empty, urlResult.Id);
                    Assert.NotEqual(Guid.Empty, urlResult.Iteration);
                    Assert.Equal(project.ProjectId, urlResult.Project);
                    Assert.NotEqual(0, urlResult.Predictions.Count);
                    Assert.InRange(urlResult.Predictions[0].Probability, 0.9, 1);
                    Assert.Equal("Tag1", urlResult.Predictions[0].TagName);
                }
            }
        }

        [Fact]
        public async void CreateImagesFromPredictions()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "CreateImagesFromPredictions", RecorderMode);

                using (var project = CreateTrainedImageClassificationProject())
                {
                    ICustomVisionTrainingClient client = BaseTests.GetTrainingClient();

                    string imageUrl = "https://raw.githubusercontent.com/Microsoft/Cognitive-CustomVision-Windows/master/Samples/Images/Test/test_image.jpg";
                    var predictionResult = await client.QuickTestImageUrlAsync(project.ProjectId, new ImageUrl(imageUrl), project.IterationId);

                    var i = new ImageIdCreateEntry[] { new ImageIdCreateEntry(predictionResult.Id) };
                    var result = await client.CreateImagesFromPredictionsAsync(project.ProjectId, new ImageIdCreateBatch(i));

                    Assert.Equal(1, result.Images.Count);
                    Assert.NotEmpty(result.Images[0].SourceUrl);
                }
            }
        }

        [Fact]
        public async void QueryPredictionResults()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "QueryPredictionResults", RecorderMode);

                using (var project = CreateTrainedImageClassificationProject())
                {
                    ICustomVisionTrainingClient client = BaseTests.GetTrainingClient();

#if RECORD_MODE
                    // Give time for the predictio nto show up.
                    Thread.Sleep(5000);
#endif
                    var token = new PredictionQueryToken()
                    {
                        OrderBy = "Newest",
                    };
                    var result = await client.QueryPredictionsAsync(project.ProjectId, token);
                    Assert.NotEqual(0, result.Results.Count);
                    foreach (var prediction in result.Results)
                    {
                        Assert.Equal(project.ProjectId, prediction.Project);
                        Assert.NotEqual(Guid.Empty, prediction.Id);
                        Assert.NotEqual(Guid.Empty, prediction.Iteration);
                        Assert.NotEmpty(prediction.ThumbnailUri);
                        Assert.NotEmpty(prediction.OriginalImageUri);
                        Assert.NotEmpty(prediction.ResizedImageUri);

                        Assert.NotEqual(0, prediction.Predictions.Count);
                    }
                }
            }
        }

        [Fact]
        public async void DeletePrediction()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "DeletePrediction", RecorderMode);

                using (var project = CreateTrainedImageClassificationProject())
                {
                    ICustomVisionTrainingClient client = BaseTests.GetTrainingClient();

                    var token = new PredictionQueryToken()
                    {
                        OrderBy = "Newest",
                    };
                    var result = client.QueryPredictionsAsync(project.ProjectId, token).Result;
                    Assert.NotEqual(0, result.Results.Count);

                    await client.DeletePredictionAsync(project.ProjectId, new Guid[] { result.Results[result.Results.Count - 1].Id });
                }
            }
        }

        [Fact]
        public async void GetImagesByIds()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "GetImagesByIds", RecorderMode);

                using (var project = CreateTrainedImageClassificationProject())
                {
                    ICustomVisionTrainingClient client = BaseTests.GetTrainingClient();

                    var tags = await client.GetTagsAsync(project.ProjectId);
                    var imagesForTag = await client.GetTaggedImagesAsync(project.ProjectId, null, new List<Guid>(new Guid[] { tags[0].Id }));
                    Assert.Equal(5, imagesForTag.Count);

                    var images = await client.GetImagesByIdsAsync(project.ProjectId, imagesForTag.Select(img => img.Id).ToList());
                    Assert.Equal(5, images.Count);

                    foreach (var image in images)
                    {
                        Assert.Equal(1, image.Tags.Count);
                        var tag = image.Tags[0];
                        Assert.Equal(tags[0].Id, tag.TagId);
                        Assert.Equal(tags[0].Name, tag.TagName);
                        Assert.NotNull(image.ThumbnailUri);
                        Assert.NotEmpty(image.OriginalImageUri);
                        Assert.NotEmpty(image.ResizedImageUri);
                        Assert.True(image.Width > 0);
                        Assert.True(image.Height > 0);
                    }
                }
            }
        }

        [Fact]
        public async void ImageCounts()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "ImageCounts", RecorderMode);

                using (var project = CreateTrainedImageClassificationProject())
                {
                    ICustomVisionTrainingClient client = BaseTests.GetTrainingClient();

                    var taggedImageCount = await client.GetTaggedImageCountAsync(project.ProjectId);
                    Assert.Equal(10, taggedImageCount);

                    var untaggedImageCount = await client.GetUntaggedImageCountAsync(project.ProjectId);
                    Assert.Equal(0, untaggedImageCount);

                    var iterationId = (await client.GetIterationsAsync(project.ProjectId))[0].Id;
                    var imagePerfCount = await client.GetImagePerformanceCountAsync(project.ProjectId, iterationId);
                    Assert.Equal(2, imagePerfCount);
                }
            }
        }

        [Fact]
        public async void DownloadRegions()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "DownloadRegions", RecorderMode);

                using (var project = CreateTrainedObjDetectionProject())
                {
                    ICustomVisionTrainingClient client = BaseTests.GetTrainingClient();

                    var images = await client.GetTaggedImagesAsync(project.ProjectId);
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
        }

        [Fact]
        public async void RegionManipulation()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "RegionManipulation", RecorderMode);

                using (var project = CreateTrainedObjDetectionProject())
                using (ICustomVisionTrainingClient client = BaseTests.GetTrainingClient())
                {
                    var existingImage = (await client.GetTaggedImagesAsync(project.ProjectId)).First();
                    Assert.NotNull(existingImage);

                    var testTag = await client.CreateTagAsync(project.ProjectId, tagName);

                    var proposal = await client.GetImageRegionProposalsAsync(project.ProjectId, existingImage.Id);
                    Assert.True(proposal.Proposals.Count > 0);
                    Assert.Equal(project.ProjectId, proposal.ProjectId);
                    Assert.Equal(existingImage.Id, proposal.ImageId);
                    Assert.InRange(proposal.Proposals[0].Confidence, 0, 1);

                    var bbox = proposal.Proposals[0].BoundingBox;
                    List<ImageRegionCreateEntry> newRegions = new List<ImageRegionCreateEntry>();
                    newRegions.Add(new ImageRegionCreateEntry(existingImage.Id, testTag.Id, bbox.Left, bbox.Top, bbox.Width, bbox.Height));

                    var regions = await client.CreateImageRegionsAsync(project.ProjectId, new ImageRegionCreateBatch(newRegions));
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

                    var image = await client.GetImagesByIdsAsync(project.ProjectId, new List<Guid>(new Guid[] { existingImage.Id }));
                    Assert.Equal(1, image.Count);
                    Assert.Equal(2, image[0].Regions.Count);

                    await client.DeleteImageRegionsAsync(project.ProjectId, new List<Guid>(new Guid[] { regions.Created[0].RegionId }));

                    image = await client.GetImagesByIdsAsync(project.ProjectId, new List<Guid>(new Guid[] { existingImage.Id }));
                    Assert.Equal(1, image.Count);
                    Assert.Equal(1, image[0].Regions.Count);

                    await client.DeleteTagAsync(project.ProjectId, testTag.Id);
                }
            }
        }

        [Fact]
        public async void ObjDetectionPrediction()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "ObjDetectionPrediction", RecorderMode);

                using (var project = CreateTrainedObjDetectionProject())
                using (ICustomVisionTrainingClient client = BaseTests.GetTrainingClient())
                using (FileStream stream = new FileStream(Path.Combine("TestImages", "od_test_image.jpg"), FileMode.Open))
                {
                    var imageResult = await client.QuickTestImageAsync(project.ProjectId, stream, project.IterationId);
                    Assert.NotEqual(Guid.Empty, imageResult.Id);
                    Assert.NotEqual(Guid.Empty, imageResult.Iteration);
                    Assert.Equal(project.ProjectId, imageResult.Project);
                    Assert.NotEqual(0, imageResult.Predictions.Count);
                    Assert.InRange(imageResult.Predictions[0].Probability, 0.25, 1);
                    Assert.NotNull(imageResult.Predictions[0].BoundingBox);
                    Assert.InRange(imageResult.Predictions[0].BoundingBox.Left, 0, 1);
                    Assert.InRange(imageResult.Predictions[0].BoundingBox.Top, 0, 1);
                    Assert.InRange(imageResult.Predictions[0].BoundingBox.Width, 0, 1);
                    Assert.InRange(imageResult.Predictions[0].BoundingBox.Height, 0, 1);
                }
            }
        }

        [Fact]
        public async void SuggestTagAndRegions()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "SuggestTagAndRegions", RecorderMode);

                using (var project = CreateTrainedImageClassificationProject())
                using (ICustomVisionTrainingClient client = BaseTests.GetTrainingClient())
                {
                    // Add an untagged image we expect to be classified as tag1
                    var images = new ImageFileCreateEntry[] {
                        new ImageFileCreateEntry("suggest_ic.jpg", File.ReadAllBytes(Path.Combine("TestImages", "suggest_ic.jpg")))
                    };
                    var imageResult = await client.CreateImagesFromFilesAsync(project.ProjectId, new ImageFileCreateBatch(images));
                    Assert.True(imageResult.IsBatchSuccessful);
                    Assert.Equal(1, imageResult.Images.Count);

                    // Ask for suggestions
                    var suggestions = client.SuggestTagsAndRegions(project.ProjectId, project.IterationId, new Guid[] { imageResult.Images[0].Image.Id });

                    // Validate result
                    Assert.Equal(1, suggestions.Count);
                    Assert.Equal(project.ProjectId, suggestions[0].Project);
                    Assert.Equal(project.IterationId, suggestions[0].Iteration);
                    Assert.NotEqual(0, suggestions[0].Predictions.Count);

                    foreach (var prediction in suggestions[0].Predictions)
                    {
                        var tag = await client.GetTagAsync(project.ProjectId, prediction.TagId, project.IterationId);
                        Assert.Equal(tag.Name, prediction.TagName);
                        Assert.Equal(tag.Id, prediction.TagId);
                        Assert.InRange(prediction.Probability, 0, 1);
                    }

                    // We expect Tag1 to have the highest probability
                    Assert.Equal("Tag1", suggestions[0].Predictions.OrderByDescending(p => p.Probability).First().TagName);
                }
            }
        }

        [Fact]
        public async void QuerySuggestedImageCount()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "QuerySuggestedImageCount", RecorderMode);

                using (var project = CreateTrainedImageClassificationProject())
                using (ICustomVisionTrainingClient client = BaseTests.GetTrainingClient())
                {
                    // Add an untagged image we expect to be classified as tag1
                    var images = new ImageFileCreateEntry[] {
                        new ImageFileCreateEntry("suggest_ic.jpg", File.ReadAllBytes(Path.Combine("TestImages", "suggest_ic.jpg")))
                    };
                    var imageResult = await client.CreateImagesFromFilesAsync(project.ProjectId, new ImageFileCreateBatch(images));
                    Assert.True(imageResult.IsBatchSuccessful);
                    Assert.Equal(1, imageResult.Images.Count);

                    // Ask for suggestions
                    var suggestions = client.SuggestTagsAndRegions(project.ProjectId, project.IterationId, new Guid[] { imageResult.Images[0].Image.Id });

                    // Validate result
                    Assert.Equal(1, suggestions.Count);

                    var tags = await client.GetTagsAsync(project.ProjectId, project.IterationId);

                    // We expect to get Tag1 as the primary suggestion, so query with a high prediction
                    IDictionary<string, int?> countMapping;
                    var loopCount = 0;
                    do
                    {
#if RECORD_MODE
                        Thread.Sleep(5000);
#endif
                        countMapping = await client.QuerySuggestedImageCountAsync(project.ProjectId, project.IterationId, new TagFilter()
                        {
                            Threshold = 0.75,
                            TagIds = new Guid[] { tags[0].Id }
                        });
                        loopCount++;
                    } while (countMapping.Count == 0 && loopCount < 5);

                    Assert.Equal(1, countMapping.Count);
                    Assert.Equal(1, countMapping[tags[0].Id.ToString()]);

                    // We expect to get Tag2 to have a low probabilty, make sure we don't find it with a high threshold
                    countMapping = await client.QuerySuggestedImageCountAsync(project.ProjectId, project.IterationId, new TagFilter()
                    {
                        Threshold = 0.75,
                        TagIds = new Guid[] { tags[1].Id }
                    });
                    Assert.Equal(1, countMapping.Count);
                    Assert.Equal(0, countMapping[tags[1].Id.ToString()]);

                    // Get results for all tags with a high threshold.
                    countMapping = await client.QuerySuggestedImageCountAsync(project.ProjectId, project.IterationId, new TagFilter()
                    {
                        Threshold = 0.75,
                        TagIds = tags.Select(t => t.Id).ToList()
                    });
                    Assert.Equal(2, countMapping.Count);
                    Assert.Equal(1, countMapping[tags[0].Id.ToString()]);
                    Assert.Equal(0, countMapping[tags[1].Id.ToString()]);
                }
            }
        }

        [Fact]
        public async void QuerySuggestedImages()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "QuerySuggestedImages", RecorderMode);

                using (var project = CreateTrainedImageClassificationProject())
                using (ICustomVisionTrainingClient client = BaseTests.GetTrainingClient())
                {
                    // Add an untagged image we expect to be classified as tag1
                    var images = new ImageFileCreateEntry[] {
                        new ImageFileCreateEntry("suggest_ic.jpg", File.ReadAllBytes(Path.Combine("TestImages", "suggest_ic.jpg")))
                    };
                    var imageResult = await client.CreateImagesFromFilesAsync(project.ProjectId, new ImageFileCreateBatch(images));
                    Assert.True(imageResult.IsBatchSuccessful);
                    Assert.Equal(1, imageResult.Images.Count);

                    // Ask for suggestions
                    var suggestions = client.SuggestTagsAndRegions(project.ProjectId, project.IterationId, new Guid[] { imageResult.Images[0].Image.Id });

                    // Validate result
                    Assert.Equal(1, suggestions.Count);

                    // Get tags and build a query
                    var tags = await client.GetTagsAsync(project.ProjectId, project.IterationId);
                    var query = new SuggestedTagAndRegionQueryToken()
                    {
                        MaxCount = 10,
                        TagIds = tags.Select(t => t.Id).ToList(),
                        Threshold = 0
                    };

                    // This will return all suggested images (1 in this case)
                    SuggestedTagAndRegionQuery suggestedImages;
                    var loopCount = 0;
                    do
                    {
#if RECORD_MODE
                        Thread.Sleep(5000);
#endif
                        suggestedImages = await client.QuerySuggestedImagesAsync(project.ProjectId, project.IterationId, query); loopCount++;
                    } while (suggestedImages.Results.Count == 0 && loopCount < 5);

                    Assert.Equal(1, suggestedImages.Results.Count);
                }
            }
        }

        [Fact]
        public async void ImportExportProject()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "ImportExportProject", RecorderMode);

                using (var project = CreateTrainedImageClassificationProject())
                using (ICustomVisionTrainingClient client = BaseTests.GetTrainingClient())
                {
                    var exportInfo = await client.ExportProjectAsync(project.ProjectId);
                    Assert.NotEmpty(exportInfo.Token);

                    var importProject = await client.ImportProjectAsync(exportInfo.Token);
                    int loopCount = 0;
                    while (loopCount < 5 && importProject.Status != ProjectStatus.Succeeded)
                    {
#if RECORD_MODE
                        Thread.Sleep(20000);
#endif
                        importProject = await client.GetProjectAsync(importProject.Id);
                        loopCount++;
                    }

                    Assert.Equal(ProjectStatus.Succeeded, importProject.Status);
                    Assert.Equal(client.GetTaggedImageCount(importProject.Id), client.GetTaggedImageCount(project.ProjectId));
                    Assert.Equal(client.GetTags(importProject.Id).Count, client.GetTags(project.ProjectId).Count);
                    Assert.Equal(client.GetIterations(importProject.Id).Count, client.GetIterations(project.ProjectId).Count);
                }
            }
        }

        [Fact]
        public async void GetArtifacts()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "GetArtifacts", RecorderMode);

                using (var project = CreateTrainedImageClassificationProject())
                using (ICustomVisionTrainingClient client = BaseTests.GetTrainingClient())
                {
                    var images = await client.GetImagesAsync(project.ProjectId);
                    var imageData = await client.GetArtifactAsync(project.ProjectId, images[0].OriginalImageUri);
                    Assert.NotNull(imageData);
                }
            }
        }

        [Fact]
        public async void GetImagesAndCount()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "GetImagesAndCount", RecorderMode);

                using (var project = CreateTrainedImageClassificationProject())
                using (ICustomVisionTrainingClient client = BaseTests.GetTrainingClient())
                {
                    var imageData = await client.GetImageCountAsync(project.ProjectId, null, taggingStatus: "All");
                    Assert.Equal(10, imageData);

                    var images = await client.GetImagesAsync(project.ProjectId, null, null, taggingStatus: "All", null, null, 5, 0);
                    Assert.Equal(5, images.Count);
                }
            }
        }

        [Fact]
        public async void UpdateImageMetadata()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "UpdateImageMetadata", RecorderMode);

                using (var project = CreateTrainedImageClassificationProject())
                using (ICustomVisionTrainingClient client = BaseTests.GetTrainingClient())
                {
                    var images = await client.GetImagesAsync(project.ProjectId, null, null, taggingStatus: "All", null, null, 1, 0);
                    Assert.Equal(1, images.Count);

                    var metadata = new Dictionary<string, string>()
                    {
                        { "type", "unit test" },
                        { "value", "30" }
                    };
                    var results = await client.UpdateImageMetadataAsync(project.ProjectId, new Guid[] { images[0].Id }, metadata);
                    Assert.True(results.IsBatchSuccessful);
                    Assert.Equal(1, results.Images.Count);
                    Assert.Equal(metadata.Keys.Count, results.Images[0].Metadata.Keys.Count);
                    Assert.Equal(metadata["type"], results.Images[0].Metadata["type"]);
                    Assert.Equal(metadata["value"], results.Images[0].Metadata["value"]);
                }
            }
        }

        [Fact]
        public async void TrainWithCustomBaseModelInfo()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "TrainWithCustomBaseModelInfo", RecorderMode);

                using (var project = CreateTrainedImageClassificationProject())
                using (ICustomVisionTrainingClient client = BaseTests.GetTrainingClient())
                {
                    var trainingParams = new TrainingParameters()
                    {
                        CustomBaseModelInfo = new CustomBaseModelInfo()
                        {
                            ProjectId = project.ProjectId,
                            IterationId = project.IterationId
                        }
                    };
                    var newIteration = await client.TrainProjectAsync(project.ProjectId, "Regular", null, true, null, trainingParams);
                    while (newIteration.Status != "Completed")
                    {
#if RECORD_MODE
                        Thread.Sleep(1000);
#endif
                        newIteration = client.GetIteration(project.ProjectId, newIteration.Id);
                    }
                    Assert.NotNull(newIteration.CustomBaseModelInfo);
                    Assert.Equal(newIteration.CustomBaseModelInfo.ProjectId, project.ProjectId);
                    Assert.Equal(newIteration.CustomBaseModelInfo.IterationId, project.IterationId);
                }
            }
        }
    }
}
