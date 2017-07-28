using Microsoft.WindowsAzure.Build.Tasks;
using Microsoft.WindowsAzure.Build.Tasks.ExecProcess;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Build.Tasks.Tests.PublishNugetTests
{
    
    public class PublishTests
    {
        const string NUGET_PKG_NAME = "Build.Tasks.Tests";

        string _nugetPkgBuiltDir;
        string _publishToDir;

        public string NugetPkgBuiltDir
        {
            get
            {
                if(string.IsNullOrEmpty(_nugetPkgBuiltDir))
                {
                    string codeBasePath = Assembly.GetExecutingAssembly().CodeBase;
                    var uri = new UriBuilder(codeBasePath);
                    string path = Uri.UnescapeDataString(uri.Path);
                    path = Path.GetDirectoryName(path);

                    _nugetPkgBuiltDir = Directory.GetParent(path).FullName;
                }

                return _nugetPkgBuiltDir;
            }
        }

        public string PublishToDir
        {
            get
            {
                return _publishToDir;
            }
        }

        public PublishTests()
        {
            if(Directory.Exists(NugetPkgBuiltDir))
            {
                string pubDir = Path.Combine(NugetPkgBuiltDir, "testPublish");
                if(!Directory.Exists(pubDir))
                {
                    Directory.CreateDirectory(pubDir);
                }

                _publishToDir = pubDir;
            }
        }

        
        [Fact]
        public void PublishSingleNuget()
        {
            PublishSDKNuget pubNug = new PublishSDKNuget();
            pubNug.PackageOutputPath = NugetPkgBuiltDir;
            pubNug.NugetPackageName = NUGET_PKG_NAME;
            pubNug.PublishNugetToPath = PublishToDir;

            pubNug.Execute();

            List<NugetPublishStatus> statusList = pubNug.NugetPublishStatus;

            foreach(NugetPublishStatus status in statusList)
            {
                Assert.Equal(0, status.NugetPublishExitCode);
            }
        }

        [Fact]
        public void NonExistentPublishLocation()
        {
            PublishSDKNuget pubNug = new PublishSDKNuget();
            pubNug.PackageOutputPath = NugetPkgBuiltDir;
            pubNug.NugetPackageName = NUGET_PKG_NAME;
            pubNug.PublishNugetToPath = "http://somelocation";
            pubNug.SkipSymbolPublishing = true;
            pubNug.ApiKey = "1234";

            Assert.ThrowsAny<Exception>(() => pubNug.Execute());
        }

        [Fact]
        public void SkipPublishingSymbols()
        {
            PublishSDKNuget pubNug = new PublishSDKNuget();
            pubNug.PackageOutputPath = NugetPkgBuiltDir;
            pubNug.NugetPackageName = NUGET_PKG_NAME;
            pubNug.PublishNugetToPath = PublishToDir;
            pubNug.SkipSymbolPublishing = true;

            pubNug.Execute();

            List<NugetPublishStatus> statusList = pubNug.NugetPublishStatus;

            Assert.Equal(1, statusList?.Count);

            foreach (NugetPublishStatus status in statusList)
            {
                Assert.Equal(0, status.NugetPublishExitCode);
            }
        }

        [Fact]
        public void DefaultPublishPaths()
        {
            NugetExec nugEx = new NugetExec();
            Assert.Equal("https://www.nuget.org/api/v2/package/", nugEx.PublishToPath);
            Assert.Equal("https://nuget.smbsrc.net", nugEx.PublishSymbolToPath);
        }

        #region Error Tests

        [Fact]
        public void PublishOnlySymbol()
        {
            PublishSDKNuget pubNug = new PublishSDKNuget();
            pubNug.PackageOutputPath = NugetPkgBuiltDir;
            pubNug.NugetPackageName = NUGET_PKG_NAME;
            pubNug.PublishNugetToPath = "https://www.nuget.org/api/v2/package/";
            pubNug.SkipNugetPublishing = true;
            pubNug.ApiKey = "1234";
            Assert.ThrowsAny<ApplicationException>(() => pubNug.Execute());
        }

        [Fact]
        public void PublishWithUnAuthenticatedKey()
        {
            PublishSDKNuget pubNug = new PublishSDKNuget();
            pubNug.PackageOutputPath = NugetPkgBuiltDir;
            pubNug.NugetPackageName = NUGET_PKG_NAME;
            pubNug.PublishNugetToPath = "https://www.nuget.org/api/v2/package/";
            pubNug.SkipSymbolPublishing = false;
            pubNug.ApiKey = "1234";
            
            try
            {
                pubNug.Execute();
            }
            catch(Exception ex)
            {
                if(!ex.Message.Contains("The specified API key is invalid"))
                {
                    Assert.Equal("The specified API key is invalid", ex.Message);
                }
            }
        }

        [Fact]
        public void IncorrectNugetExePath()
        {
            PublishSDKNuget pubNug = new PublishSDKNuget();
            pubNug.PackageOutputPath = NugetPkgBuiltDir;
            pubNug.NugetPackageName = NUGET_PKG_NAME;
            pubNug.PublishNugetToPath = PublishToDir;
            pubNug.SkipSymbolPublishing = true;
            pubNug.NugetExePath = @"C:\Foo\NoExistantPath\nuget.exe";
            Assert.ThrowsAny<Exception>(() => pubNug.Execute());
        }

        [Fact]
        public void MissingNugetPackageName()
        {
            PublishSDKNuget pubNug = new PublishSDKNuget();
            pubNug.PackageOutputPath = NugetPkgBuiltDir;
            pubNug.PublishNugetToPath = PublishToDir;
            pubNug.SkipSymbolPublishing = true;
            Assert.ThrowsAny<NullReferenceException>(() => pubNug.Execute());
        }

        [Fact]
        public void PublishAllNugetUnderScope()
        {
            PublishSDKNuget pubNug = new PublishSDKNuget();
            pubNug.publishAllNugetsUnderScope = true;
            Assert.Throws<NotSupportedException>(() => pubNug.Execute());
        }

        [Fact]
        public void MissingRequiredProperties()
        {
            PublishSDKNuget pubNug = new PublishSDKNuget();
            Assert.ThrowsAny<NullReferenceException>(() => pubNug.Execute());
        }

        [Fact]
        public void SkipPublishingCompletely()
        {
            PublishSDKNuget pubNug = new PublishSDKNuget();
            pubNug.PackageOutputPath = NugetPkgBuiltDir;
            pubNug.NugetPackageName = NUGET_PKG_NAME;
            pubNug.PublishNugetToPath = PublishToDir;
            pubNug.SkipSymbolPublishing = true;
            pubNug.SkipNugetPublishing = true;
            Assert.Throws<ApplicationException>(() => pubNug.Execute());
        }
        
        #endregion
    }
}
