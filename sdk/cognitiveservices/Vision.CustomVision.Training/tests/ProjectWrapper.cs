namespace Microsoft.Azure.CognitiveServices.Vision.CustomVision.Training.Tests
{
    using Microsoft.Azure.CognitiveServices.Vision.CustomVision.Training;
    using System;
    using System.IO;
    using Xunit;

    public class ProjectWrapper : IDisposable
    {
        public Guid ProjectId { get; private set; }
        public Guid IterationId { get; set; }

        public ProjectWrapper(Guid projectId, Guid iterationId)
        {
            Assert.NotEqual(Guid.Empty, projectId);
            Assert.NotEqual(Guid.Empty, iterationId);

            this.ProjectId = projectId;
            this.IterationId = iterationId;
        }

        public void Dispose()
        {
#if RECORD_MODE
            ICustomVisionTrainingClient client = BaseTests.GetTrainingClient(false);

            foreach (var iter in client.GetIterations(this.ProjectId))
            {
                if (!string.IsNullOrEmpty(iter.PublishName))
                {
                    client.UnpublishIteration(this.ProjectId, iter.Id);
                }
            }
            client.DeleteProject(this.ProjectId);
#endif
        }
    }
}
