using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Build.Tasks.Tests
{
    public class BuildTestBase
    {
        internal string rootDir = string.Empty;
        internal string sourceRootDir = string.Empty;

        public string RootDir { get; private set; }
        public string SourceRootDir { get; private set; }

        public BuildTestBase()
        {
            RootDir = GetSourceRootDir();
            SourceRootDir = Path.Combine(RootDir, "src");
        }

        internal string GetSourceRootDir()
        {
            string srcRootDir = string.Empty;
            string currDir = Directory.GetCurrentDirectory();

            if (!Directory.Exists(currDir))
            {
                currDir = Path.GetDirectoryName(this.GetType().GetTypeInfo().Assembly.Location);
            }

            string dirRoot = Directory.GetDirectoryRoot(currDir);

            var buildProjFile = Directory.EnumerateFiles(currDir, "build.proj", SearchOption.TopDirectoryOnly);

            while (currDir != dirRoot)
            {
                if (buildProjFile.Any<string>())
                {
                    srcRootDir = Path.GetDirectoryName(buildProjFile.First<string>());
                    break;
                }

                currDir = Directory.GetParent(currDir).FullName;
                buildProjFile = Directory.EnumerateFiles(currDir, "build.proj", SearchOption.TopDirectoryOnly);
            }

            if (string.IsNullOrEmpty(srcRootDir))
            {
                srcRootDir = @"C:\MyFork\vs17Dev";
            }

            return srcRootDir;
        }
    }
}
