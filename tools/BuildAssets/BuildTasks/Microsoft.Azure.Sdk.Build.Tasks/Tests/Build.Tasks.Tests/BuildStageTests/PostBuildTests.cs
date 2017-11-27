using Microsoft.Azure.Sdk.Build.Tasks.BuildStages;
using Microsoft.Build.Evaluation;
using Microsoft.WindowsAzure.Build.Tasks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;

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

        [Fact]
        public void BuildOneProject()
        {
            SDKCategorizeProjects sdkCat = new SDKCategorizeProjects();
            sdkCat.SourceRootDirPath = catProjTest.sourceRootDir;
            sdkCat.BuildScope = @"SDKs\Compute";
            sdkCat.IgnoreDirNameForSearchingProjects = Path.Combine(catProjTest.ignoreDir);

            if(sdkCat.Execute())
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
                if(ProjectCollection.GlobalProjectCollection.GetLoadedProjects(apiTagPropsFile).Count != 0)
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
        public void GetApiMapSplitPartialClass()
        {
            string asmPath = Assembly.GetExecutingAssembly().CodeBase;

            PostBuildTask postBld = new PostBuildTask()
            {
                AssemblyFullPath = asmPath,
                FQTypeName = "ResourceSDKInfo"
            };

            if(postBld.Execute())
            {
                string apiTag = postBld.ApiTag;
                Assert.NotEmpty(apiTag);

                Assert.Equal<string>("Resource_2017-03-30;Resource_2016-03-30;Resource_2017-01-31;", apiTag);
            }
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
