namespace Microsoft.Azure.CognitiveServices.Vision.CustomVision.Training.Tests
{
    using Microsoft.Azure.CognitiveServices.Vision.CustomVision.Training.Models;
    using Microsoft.Azure.Test.HttpRecorder;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;

    /// <summary>
    /// 
    /// </summary>
    public abstract class BaseTests : IClassFixture<ProjectIdFixture>
    {
        private static readonly string TrainingKey = "";

        /// <summary>
        /// 
        /// </summary>
        protected static HttpRecorderMode RecorderMode = HttpRecorderMode.Playback;
        
        /// <summary>
        /// 
        /// </summary>
        protected static string ObjDetectionProjectName = "Obj Detection SDK Tests";

        protected static Guid FoodDomain = Guid.Parse("C151D5B5-DD07-472A-ACC8-15D29DEA8518");
        protected static Guid GeneralDomain = Guid.Parse("EE85A74C-405E-4ADC-BB47-FFA8CA0C9F31");
        protected static Guid ExportableDomain = Guid.Parse("0732100F-1A38-4E49-A514-C9B44C697AB5");

        private ProjectIdFixture fixture;
        static BaseTests()
        {
#if RECORD_MODE
            TrainingKey = "<training key here>";
            RecorderMode = HttpRecorderMode.Record;
            HttpMockServer.FileSystemUtilsObject = new FileSystemUtils();

            string executingAssemblyPath = typeof(BaseTests).GetTypeInfo().Assembly.Location;
            HttpMockServer.RecordsDirectory = Path.Combine(Path.GetDirectoryName(executingAssemblyPath), @"..\..\..\SessionRecords");
#endif
        }

        public BaseTests(ProjectIdFixture fixture)
        {
            this.fixture = fixture;
        }

        protected ITrainingApi GetTrainingClient()
        {
            ITrainingApi client = new TrainingApi(handlers: HttpMockServer.CreateInstance())
            {
                ApiKey = TrainingKey,
            };

            return client;
        }

        public Guid CreateTrainedImageClassificationProjectAsync(Guid? domain = null)
        {
#if RECORD_MODE
            var client = GetTrainingClient();
            var projName = Guid.NewGuid().ToString();

            // Create a project
            var projDomain = domain.HasValue ? domain : GeneralDomain;
            var project = await client.CreateProjectAsync(projName, null, projDomain);

            // Create two tags
            var tagOne = await client.CreateTagAsync(project.Id, "Tag1");
            var tagTwo = await client.CreateTagAsync(project.Id, "Tag2");

            // Add five images for tag 1
            var imagePath = Path.Combine("TestImages", "tag1");
            var imageFileEntries = new List<ImageFileCreateEntry>();
            foreach (var fileName in Directory.EnumerateFiles(imagePath))
            {
                imageFileEntries.Add(new ImageFileCreateEntry(fileName, File.ReadAllBytes(fileName)));
            }
            await client.CreateImagesFromFilesAsync(project.Id, new ImageFileCreateBatch(imageFileEntries, new List<Guid>(new Guid[] { tagOne.Id })));

            // Add five images for tag 2
            imagePath = Path.Combine("TestImages", "tag2");
            imageFileEntries = new List<ImageFileCreateEntry>();
            foreach (var fileName in Directory.EnumerateFiles(imagePath))
            {
                imageFileEntries.Add(new ImageFileCreateEntry(fileName, File.ReadAllBytes(fileName)));
            }
            await client.CreateImagesFromFilesAsync(project.Id, new ImageFileCreateBatch(imageFileEntries, new List<Guid>(new Guid[] { tagTwo.Id })));

            // Train
            var iteration = await client.TrainProjectAsync(project.Id);
            while (iteration.Status != "Completed")
            {
                Thread.Sleep(1000);
                iteration = await client.GetIterationAsync(project.Id, iteration.Id);
            }
            iteration.IsDefault = true;
            await client.UpdateIterationAsync(project.Id, iteration.Id, iteration);

            // Make one prediction
            string imageUrl = "https://raw.githubusercontent.com/Microsoft/Cognitive-CustomVision-Windows/master/Samples/Images/Test/test_image.jpg";
            await client.QuickTestImageUrlAsync(project.Id, new ImageUrl(imageUrl));

            // Flush and re-init so we don't get all of the test setup in the session.
            HttpMockServer.Flush();
            HttpMockServer.Initialize(HttpMockServer.CallerIdentity, HttpMockServer.TestIdentity, RecorderMode);

            this.fixture.ProjectToGuidMapping.Add(HttpMockServer.TestIdentity, project.Id);
            return project.Id;
#else
            return this.fixture.ProjectToGuidMapping[HttpMockServer.TestIdentity];
#endif
        }

        public Guid CreateTrainedObjDetectionProject()
        {
#if RECORD_MODE
            Dictionary<string, double[]> fileToRegionMap = new Dictionary<string, double[]>()
            {
                // FileName, Left, Top, Width, Height
                {"fork_1", new double[] { 0.219362751, 0.141781077, 0.5919118, 0.6683006 } },
                {"fork_2", new double[] { 0.115196079, 0.341127485, 0.819852948, 0.222222224 } },
                {"fork_3", new double[] { 0.107843138, 0.128709182, 0.727941155, 0.71405226 } },
                {"fork_4", new double[] { 0.148284316, 0.318251669, 0.7879902, 0.3970588 } },
                {"fork_5", new double[] { 0.08210784, 0.07805559, 0.759803951, 0.593137264 } },
                {"fork_6", new double[] { 0.2977941, 0.220212445, 0.5355392, 0.6013072 } },
                {"fork_7", new double[] { 0.143382356, 0.346029431, 0.590686262, 0.256535947 } },
                {"fork_8", new double[] { 0.294117659, 0.216944471, 0.49142158, 0.5980392 } },
                {"fork_9", new double[] { 0.240196079, 0.1385131, 0.5955882, 0.643790841 } },
                {"fork_10", new double[] { 0.25, 0.149951011, 0.534313738, 0.642156839 } },
                {"fork_11", new double[] { 0.234068632, 0.445702642, 0.6127451, 0.344771236 } },
                {"fork_12", new double[] { 0.180147052, 0.239820287, 0.6887255, 0.235294119 } },
                {"fork_13", new double[] { 0.140931368, 0.480016381, 0.6838235, 0.240196079 } },
                {"fork_14", new double[] { 0.186274514, 0.0633497, 0.579656839, 0.8611111 } },
                {"fork_15", new double[] { 0.243872553, 0.212042511, 0.470588237, 0.6683006 } },
                {"fork_16", new double[] { 0.143382356, 0.218578458, 0.7977941, 0.295751631 } },
                {"fork_17", new double[] { 0.3345588, 0.07315363, 0.375, 0.9150327 } },
                {"fork_18", new double[] { 0.05759804, 0.0894935, 0.9007353, 0.3251634 } },
                {"fork_19", new double[] { 0.05269608, 0.282303959, 0.8088235, 0.452614367 } },
                {"fork_20", new double[] { 0.18259804, 0.2136765, 0.6335784, 0.643790841 } },
                {"scissors_1", new double[] { 0.169117644, 0.3378595, 0.780637264, 0.393790841 } },
                {"scissors_2", new double[] { 0.145833328, 0.06661768, 0.6838235, 0.8153595 } },
                {"scissors_3", new double[] { 0.3125, 0.09766343, 0.435049027, 0.71405226 } },
                {"scissors_4", new double[] { 0.432598025, 0.177728787, 0.18259804, 0.576797366 } },
                {"scissors_5", new double[] { 0.354166657, 0.210408524, 0.305147052, 0.625817 } },
                {"scissors_6", new double[] { 0.368872553, 0.234918326, 0.3394608, 0.5833333 } },
                {"scissors_7", new double[] { 0.4007353, 0.184264734, 0.2720588, 0.6862745 } },
                {"scissors_8", new double[] { 0.319852948, 0.0339379422, 0.455882341, 0.843137264 } },
                {"scissors_9", new double[] { 0.295343131, 0.259428144, 0.403186262, 0.421568632 } },
                {"scissors_10", new double[] { 0.341911763, 0.0894935, 0.351715684, 0.828431368 } },
                {"scissors_11", new double[] { 0.2720588, 0.131977156, 0.4987745, 0.6911765 } },
                {"scissors_12", new double[] { 0.186274514, 0.14504905, 0.7022059, 0.748366 } },
                {"scissors_13", new double[] { 0.05759804, 0.05027781, 0.75, 0.882352948 } },
                {"scissors_14", new double[] { 0.181372553, 0.112369314, 0.629901946, 0.71405226 } },
                {"scissors_15", new double[] { 0.256127447, 0.190800682, 0.441176474, 0.6862745 } },
                {"scissors_16", new double[] { 0.261029422, 0.153218985, 0.513480365, 0.6388889 } },
                {"scissors_17", new double[] { 0.113970585, 0.2643301, 0.6666667, 0.504901946 } },
                {"scissors_18", new double[] { 0.05514706, 0.159754932, 0.799019635, 0.730392158 } },
                {"scissors_19", new double[] { 0.204656869, 0.120539248, 0.5245098, 0.743464053 } },
                {"scissors_20", new double[] { 0.231617644, 0.08459154, 0.504901946, 0.8480392 } }
            };

            var client = GetTrainingClient();

            // Find the object detection domain
            var domains = await client.GetDomainsAsync();
            var objDetectionDomain = domains.FirstOrDefault(d => d.Type == "ObjectDetection");
            Assert.NotNull(objDetectionDomain);

            // See if we already created this project and can re-use it.
            var projects = await client.GetProjectsAsync();
            var existingProject = projects.FirstOrDefault(proj => proj.Name == ObjDetectionProjectName && proj.Settings.DomainId == objDetectionDomain.Id);
            if (existingProject != null)
            {
                this.fixture.ObjectDetectionProjectId = existingProject.Id;
                return existingProject.Id;
            }

            // Create a new project
            var project = await client.CreateProjectAsync(ObjDetectionProjectName, null, objDetectionDomain.Id);

            // Create two tags
            var forkTag = await client.CreateTagAsync(project.Id, "fork");
            var scissorsTag = await client.CreateTagAsync(project.Id, "scissors");

            // Add all images for fork
            var imagePath = Path.Combine("TestImages", "fork");
            var imageFileEntries = new List<ImageFileCreateEntry>();
            foreach (var fileName in Directory.EnumerateFiles(imagePath))
            {
                var region = fileToRegionMap[Path.GetFileNameWithoutExtension(fileName)];
                imageFileEntries.Add(new ImageFileCreateEntry(fileName, File.ReadAllBytes(fileName), null, new List<Region>(new Region[] { new Region(forkTag.Id, region[0], region[1], region[2], region[3]) })));
            }
            await client.CreateImagesFromFilesAsync(project.Id, new ImageFileCreateBatch(imageFileEntries));

            // Add all images for scissors
            imagePath = Path.Combine("TestImages", "scissors");
            imageFileEntries = new List<ImageFileCreateEntry>();
            foreach (var fileName in Directory.EnumerateFiles(imagePath))
            {
                var region = fileToRegionMap[Path.GetFileNameWithoutExtension(fileName)];
                imageFileEntries.Add(new ImageFileCreateEntry(fileName, File.ReadAllBytes(fileName), null, new List<Region>(new Region[] { new Region(scissorsTag.Id, region[0], region[1], region[2], region[3]) })));
            }
            await client.CreateImagesFromFilesAsync(project.Id, new ImageFileCreateBatch(imageFileEntries));

            // Train
            var iteration = await client.TrainProjectAsync(project.Id);
            while (iteration.Status != "Completed")
            {
                Thread.Sleep(1000);
                iteration = await client.GetIterationAsync(project.Id, iteration.Id);
            }
            iteration.IsDefault = true;
            await client.UpdateIterationAsync(project.Id, iteration.Id, iteration);

            // Flush and re-init so we don't get all of the test setup in the session.
            HttpMockServer.Flush();
            HttpMockServer.Initialize(HttpMockServer.CallerIdentity, HttpMockServer.TestIdentity, RecorderMode);

            this.fixture.ObjectDetectionProjectId = project.Id;
            return project.Id;
#else
            return this.fixture.ObjectDetectionProjectId;
#endif
        }
    }
}
