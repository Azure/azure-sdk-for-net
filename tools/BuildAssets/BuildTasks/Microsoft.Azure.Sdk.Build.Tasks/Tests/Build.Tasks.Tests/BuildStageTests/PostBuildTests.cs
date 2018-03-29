using Microsoft.Azure.Sdk.Build.Tasks.BuildStages;
using Microsoft.Build.Evaluation;
using Microsoft.Build.Framework;
using Microsoft.Build.Tasks;
using Microsoft.Build.Utilities;
using Microsoft.WindowsAzure.Build.Tasks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using nonCore = Microsoft.Build.Utilities;

namespace Build.Tasks.Tests
{
    
    public class PostBuildTests : IClassFixture<PostBuildFixture>
    {
        PostBuildFixture _postBuildFixture;

        CategorizeProjectTaskTest catProjTest;
        public PostBuildTests(PostBuildFixture postBuildFixture)
        {
            this._postBuildFixture = postBuildFixture;
            catProjTest = new CategorizeProjectTaskTest();
        }

        [Fact(Skip ="Enable after merge from psSdkJson6")]
        public void BuildOneProject()
        {
            SDKCategorizeProjects sdkCat = new SDKCategorizeProjects();
            sdkCat.SourceRootDirPath = catProjTest.sourceRootDir;
            sdkCat.BuildScope = @"SDKs\Compute";
            sdkCat.IgnoreDirNameForSearchingProjects = Path.Combine(catProjTest.ignoreDir);

            if (sdkCat.Execute())
            {
                Assert.Equal<int>(1, sdkCat.net452SdkProjectsToBuild.Count());
            }

            PostBuildTask postBldTsk = new PostBuildTask()
            {
                //InvokePostBuildTask = true,
                SdkProjects = sdkCat.net452SdkProjectsToBuild
            };

            if (postBldTsk.Execute())
            {
                string apiTag = postBldTsk.ApiTag;
                string apiTagPropsFile = postBldTsk.ApiTagPropsFile;

                Assert.NotEmpty(apiTag);
                Assert.True(File.Exists(apiTagPropsFile));

                Project proj;
                if (ProjectCollection.GlobalProjectCollection.GetLoadedProjects(apiTagPropsFile).Count != 0)
                {
                    proj = ProjectCollection.GlobalProjectCollection.GetLoadedProjects(apiTagPropsFile).FirstOrDefault<Project>();
                }
                else
                {
                    proj = new Project(apiTagPropsFile);
                }

                string apiTagProperty = proj.GetPropertyValue("AzureApiTags");
                Assert.Equal<string>(apiTag, apiTagProperty);
            }
        }


        [Fact(Skip = "Enable after merge from psSdkJson6")]
        public void BuildAzureStackScope()
        {
            SDKCategorizeProjects sdkCat = new SDKCategorizeProjects();
            sdkCat.SourceRootDirPath = catProjTest.sourceRootDir;
            sdkCat.BuildScope = @"SDKs\AnalysisServices";
            sdkCat.IgnoreDirNameForSearchingProjects = Path.Combine(catProjTest.ignoreDir);

            if (sdkCat.Execute())
            {
                Assert.True(sdkCat.net452SdkProjectsToBuild.Count() > 0);
            }

            PostBuildTask postBldTsk = new PostBuildTask()
            {
                //InvokePostBuildTask = true,
                SdkProjects = sdkCat.net452SdkProjectsToBuild
            };

            if (postBldTsk.Execute())
            {
                string apiTag = postBldTsk.ApiTag;
                string apiTagPropsFile = postBldTsk.ApiTagPropsFile;

                Assert.NotEmpty(apiTag);
                Assert.True(File.Exists(apiTagPropsFile));

                Project proj;
                if (ProjectCollection.GlobalProjectCollection.GetLoadedProjects(apiTagPropsFile).Count != 0)
                {
                    proj = ProjectCollection.GlobalProjectCollection.GetLoadedProjects(apiTagPropsFile).FirstOrDefault<Project>();
                }
                else
                {
                    proj = new Project(apiTagPropsFile);
                }

                string apiTagProperty = proj.GetPropertyValue("AzureApiTags");
                Assert.Equal<string>(apiTag, apiTagProperty);
            }
        }

        [Fact]
        public void VerifyPropsFileTest()
        {
            Assert.False(new PostBuildTask().VerifyPropsFile(null, null));
        }
        
        [Fact]
        public void GetApiMapSplitPartialClass()
        {
            string asmPath = Assembly.GetExecutingAssembly().CodeBase;

            PostBuildTask postBld = new PostBuildTask()
            {
                AssemblyFullPath = asmPath,
                FQTypeName = "TestSdkInfo.SplitInfo.ResourceSDKInfo"
            };

            if(postBld.Execute())
            {
                string apiTag = postBld.ApiTag;
                Assert.NotEmpty(apiTag);

                Assert.Equal<string>("Resource_2017-03-30;Resource_2016-03-30;Resource_2017-01-31;", apiTag);
            }
        }

        [Fact]
        public void MissingSdkInfo()
        {
            string asmPath = Assembly.GetExecutingAssembly().CodeBase;

            PostBuildTask postBld = new PostBuildTask()
            {
                AssemblyFullPath = asmPath,
                FQTypeName = "SomeRandomTypeName"
            };

            if (postBld.Execute())
            {
                string apiTag = postBld.ApiTag;
                Assert.Empty(apiTag);
            }
        }

        [Fact]
        public void MissingApiInfo()
        {
            string asmPath = Assembly.GetExecutingAssembly().CodeBase;

            PostBuildTask postBld = new PostBuildTask()
            {
                AssemblyFullPath = asmPath,
                FQTypeName = "TestSdkInfo.MissingProperty.PropMissing"
            };

            if (postBld.Execute())
            {
                string apiTag = postBld.ApiTag;
                Assert.Empty(apiTag);
            }
        }

        [Fact(Skip = "Enable way to bypass based on target framework within the task")]
        public void SkipNetCoreTargets()
        {
            string scope = @"SDKs\Compute";
            SDKCategorizeProjects sdkCat = CategorizeProjects(scope, 1);

            //string asmPath = Assembly.GetExecutingAssembly().CodeBase;
            

            PostBuildTask postBld = new PostBuildTask()
            {
                SdkProjects = sdkCat.net452SdkProjectsToBuild,
                ProjectTargetFramework = "NetStandard1.4"
            };


            if (postBld.Execute())
            {
                Assert.Empty(postBld.ApiTag);
            }
        }


        private SDKCategorizeProjects CategorizeProjects(string scope, int expectedProjectCount)
        {
            SDKCategorizeProjects sdkCat = new SDKCategorizeProjects();
            sdkCat.SourceRootDirPath = catProjTest.sourceRootDir;
            sdkCat.BuildScope = scope;
            sdkCat.IgnoreDirNameForSearchingProjects = Path.Combine(catProjTest.ignoreDir);

            if (sdkCat.Execute())
            {
                Assert.Equal<int>(expectedProjectCount, sdkCat.net452SdkProjectsToBuild.Count());
            }

            return sdkCat;
        }

    }

    public class PostBuildFixture : IDisposable
    {


        public PostBuildFixture()
        {

        }

        public void Dispose()
        {
            
        }
    }
}
