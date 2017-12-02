using Microsoft.Build.Evaluation;
using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Sdk.Build.Tasks.Models
{
    public class SdkProjectMetaData
    {
        public TargetFrameworkMoniker FxMoniker { get; set; }

        public string FxMonikerString { get; set; }
        public string FullProjectPath { get; set; }

        public string TargetOutputFullPath { get; set; }

        public bool IsTargetFxSupported { get; set; }

        public SdkProjctType ProjectType { get; set; }

        public ITaskItem ProjectTaskItem { get; set; }

        public SdkProjectMetaData() { }

        public Project MsBuildProject { get; set; }

        public SdkProjectMetaData(ITaskItem project, Project msbuildProject, TargetFrameworkMoniker fxMoniker, string fxMonikerString, string fullProjectPath, string targetOutputPath, bool isTargetFxSupported, SdkProjctType projectType = SdkProjctType.Sdk)
        {
            ProjectTaskItem = project;
            FxMoniker = fxMoniker;
            FullProjectPath = fullProjectPath;
            IsTargetFxSupported = isTargetFxSupported;
            ProjectType = projectType;
            TargetOutputFullPath = targetOutputPath;
            FxMonikerString = fxMonikerString;
            MsBuildProject = msbuildProject;
        }


        public string GetFxMonikerString(TargetFrameworkMoniker fxMoniker)
        {
            string monikerString = string.Empty;
            switch (fxMoniker)
            {
                case TargetFrameworkMoniker.net452:
                    monikerString = "net452";
                    break;

                case TargetFrameworkMoniker.netcoreapp11:
                    monikerString = "netcoreapp1.1";
                    break;

                case TargetFrameworkMoniker.netstandard14:
                    monikerString = "netstandard1.4";
                    break;

                case TargetFrameworkMoniker.net46:
                    monikerString = "net46";
                    break;

                case TargetFrameworkMoniker.net461:
                    monikerString = "net461";
                    break;
            }

            return monikerString;
        }
    }

    public enum TargetFrameworkMoniker
    {
        net45,
        net452,
        net46,
        net461,
        netcoreapp11,
        netstandard14,
        UnSupported
    }

    public enum SdkProjctType
    {
        Sdk,
        Test
    }
}
