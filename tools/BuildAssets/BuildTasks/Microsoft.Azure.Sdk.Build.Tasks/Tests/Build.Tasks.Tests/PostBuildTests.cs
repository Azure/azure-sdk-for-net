using Microsoft.Azure.Sdk.Build.Tasks.BuildStages;
using Microsoft.Build.Evaluation;
using Microsoft.WindowsAzure.Build.Tasks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

            PostBuildTask postBldTsk = new PostBuildTask();
            postBldTsk.InvokePostBuildTask = true;
            postBldTsk.SdkProjects = sdkCat.net452SdkProjectsToBuild;
            
            if(postBldTsk.Execute())
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
