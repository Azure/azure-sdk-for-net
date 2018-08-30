namespace Microsoft.Azure.CognitiveServices.Vision.CustomVision.Training.Tests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class ProjectIdFixture : IDisposable
    {
        private const string idFilename = "ids.txt";

        public readonly Dictionary<string, Guid> ProjectToGuidMapping = new Dictionary<string, Guid>();
        public Guid ObjectDetectionProjectId = Guid.Parse("dfaa6389-4b8e-4890-b36c-26773b9e17f3");
        
        public ProjectIdFixture()
        {
#if !RECORD_MODE
            var lines = File.ReadAllLines(idFilename);

            // First line is the object detection project id
            ObjectDetectionProjectId = Guid.Parse(lines[0]);
            
            // The rest are comma delimited test, project
            for (var i = 1; i < lines.Length;i++)
            {
                var parts = lines[i].Split(',');
                ProjectToGuidMapping.Add(parts[0], Guid.Parse(parts[1]));
            }
#endif
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
            File.WriteAllText(idFilename, sb.ToString());
#endif
        }
    }
}
