namespace Microsoft.Azure.CognitiveServices.Vision.CustomVision.Training.Tests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    using System.Text;
    using Microsoft.Azure.CognitiveServices.Vision.CustomVision.Training;
    using Microsoft.Azure.CognitiveServices.Vision.CustomVision.Training.Models;
    using Microsoft.Rest.Serialization;
    using Newtonsoft.Json;

    public class ProjectIdFixture : IDisposable
    {
        private const string idFilename = "ids.txt";
        public readonly Dictionary<string, Iteration> TestToIterationMapping = new Dictionary<string, Iteration>();

        public ProjectIdFixture()
        {
            try
            {
                var lines = File.ReadAllLines(idFilename);
                for (var i = 0; i < lines.Length; i++)
                {
                    var parts = lines[i].Split(',');
                    TestToIterationMapping.Add(parts[0], new Iteration("ut iteration place holder", Guid.Parse(parts[2]), default(string), default(System.DateTime), default(System.DateTime), default(System.DateTime), Guid.Parse(parts[1])));
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
            foreach(var kvp in TestToIterationMapping)
            {
                sb.AppendLine($"{kvp.Key}, {kvp.Value.ProjectId}, {kvp.Value.Id}");
            }

            // Write the info back into the project ids.txt
            File.WriteAllText(idFilename, sb.ToString());
#endif
        }
    }
}
