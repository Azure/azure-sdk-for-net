namespace Microsoft.Azure.CognitiveServices.Vision.CustomVision.Training.Tests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    using System.Text;

    public class ProjectIdFixture : IDisposable
    {
        private const string idFilename = "ids.txt";

        public readonly Dictionary<string, Guid> ProjectToGuidMapping = new Dictionary<string, Guid>();
        public Guid ObjectDetectionProjectId = Guid.Parse("dfaa6389-4b8e-4890-b36c-26773b9e17f3");
        
        public ProjectIdFixture()
        {
            try
            {
                var lines = File.ReadAllLines(GetIdsFileName());

                // First line is the object detection project id
                ObjectDetectionProjectId = Guid.Parse(lines[0]);

                // The rest are comma delimited test, project
                for (var i = 1; i < lines.Length; i++)
                {
                    var parts = lines[i].Split(',');
                    ProjectToGuidMapping.Add(parts[0], Guid.Parse(parts[1]));
                }
            }
            catch (System.IO.FileNotFoundException)
            {
                // If file not found, just assume we're reseting.
            }
        }

        public void Dispose()
        {
#if RECORD_MODE
            // Write out project ids so they are available during playback.
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(ObjectDetectionProjectId.ToString());
            foreach(var kvp in ProjectToGuidMapping)
            {
                sb.AppendLine($"{kvp.Key}, {kvp.Value.ToString()}");
            }

            // Write the info back into the project ids.txt
            File.WriteAllText(GetIdsFileName(), sb.ToString());
#endif
        }

        private string GetIdsFileName()
        {
            var executingAssemblyPath = new Uri(typeof(BaseTests).GetTypeInfo().Assembly.CodeBase);
            var projectRoot = Path.Combine(Path.GetDirectoryName(executingAssemblyPath.AbsolutePath), @"..\..\..");
            return Path.Combine(projectRoot, idFilename);
        }
    }
}
