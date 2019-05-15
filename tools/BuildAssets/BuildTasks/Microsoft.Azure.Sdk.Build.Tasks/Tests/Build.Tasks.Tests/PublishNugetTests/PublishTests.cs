// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Sdk.Build.ExecProcess;
using Microsoft.WindowsAzure.Build.Tasks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Xunit;

namespace Build.Tasks.Tests.PublishNugetTests
{
    public class PublishTests : BuildTestBase
    {
        const string NUGET_PKG_NAME = "Build.Tasks.Tests";
        const string COMPUTE_PKG_NAME = "Microsoft.Azure.Management.Compute";

        string _nugetPkgBuiltDir;
        string _publishToDir;

        public string NugetPkgBuiltDir
        {
            get
            {
                if (string.IsNullOrEmpty(_nugetPkgBuiltDir))
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
            if (Directory.Exists(NugetPkgBuiltDir))
            {
                string pubDir = Path.Combine(NugetPkgBuiltDir, "testPublish");
                if (!Directory.Exists(pubDir))
                {
                    Directory.CreateDirectory(pubDir);
                }

                _publishToDir = pubDir;
            }
        }

        [Fact]
        public void PublishSingleNuget()
        {
            PublishSDKNugetTask pubNug = new PublishSDKNugetTask();
            pubNug.PackageOutputPath = NugetPkgBuiltDir;
            pubNug.ScopePath = Path.GetDirectoryName(NugetPkgBuiltDir);
            pubNug.NugetPackageName = NUGET_PKG_NAME;
            pubNug.PublishNugetToPath = PublishToDir;

            pubNug.Execute();

            var statusList = pubNug.NugetPublishStatus;
            VerifyNugetPublishStatus(statusList, expectedExitCode: 0);

        }

        [Fact]
        public void NonExistentPublishLocation()
        {
            PublishSDKNugetTask pubNug = new PublishSDKNugetTask();
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
            PublishSDKNugetTask pubNug = new PublishSDKNugetTask();
            pubNug.PackageOutputPath = NugetPkgBuiltDir;
            pubNug.ScopePath = Path.GetDirectoryName(NugetPkgBuiltDir);
            pubNug.NugetPackageName = NUGET_PKG_NAME;
            pubNug.PublishNugetToPath = PublishToDir;
            pubNug.SkipSymbolPublishing = true;

            pubNug.Execute();

            var statusList = pubNug.NugetPublishStatus;

            Assert.Equal(1, statusList?.Count);

            //VerifyNugetPublishStatus(statusList, expectedExitCode: 0);
        }

        [Fact]
        public void DefaultPublishPaths()
        {
            NugetExec nugEx = new NugetExec();
            Assert.Equal("https://api.nuget.org/v3/index.json", nugEx.PublishToPath);
            //TODO: Enabled this once we switch to the new snupkg symbol publishing after the VS upgrade
            //Assert.Equal("https://nuget.smbsrc.net", nugEx.PublishSymbolToPath);
        }

        #region publishing multi-packages
        [Fact(Skip ="Skiping test to be run by auth users")]
        //[Fact]
        public void PublishMultiPackageUnderScope()
        {
            //msbuild .\build.proj /t:PublishNuget /p:Scope=SDKs\KeyVault /p:MultiPackagePublish=true /p:PublishNugetToPath=D:\myFork\BuildToolsForSdk\binaries\testPublish /p:PackageOutputPath=D:\myFork\BuildToolsForSdk\binaries\packages

            //This test can be run when SDKs\KeyVault is built and it's nuget packages are created using /t:CreateNugetPackages
            PublishSDKNugetTask pubNug = new PublishSDKNugetTask();
            pubNug.MultiPackagePublish = true;
            pubNug.PackageOutputPath = Path.Combine(BinariesRootDir, "packages");
            pubNug.PublishNugetToPath = PublishToDir;
            pubNug.ScopePath = @"SDKs\KeyVault";

            pubNug.Execute();

            List<Tuple<NugetPublishStatus, NugetPublishStatus>> statusList = pubNug.NugetPublishStatus;
            Assert.Equal(6, statusList.Count);
            VerifyNugetPublishStatus(statusList, expectedExitCode: 0);
        }

        [Fact]
        public void PublishMultiPkgsForAllScope()
        {
            PublishSDKNugetTask pubNug = new PublishSDKNugetTask();
            pubNug.MultiPackagePublish = true;
            pubNug.PackageOutputPath = Path.Combine(BinariesRootDir, "packages");
            pubNug.PublishNugetToPath = PublishToDir;

            pubNug.ScopePath = @"all";
            Assert.Throws<NotSupportedException>(() => pubNug.Execute());

            pubNug.ScopePath = @"sdks";
            Assert.Throws<NotSupportedException>(() => pubNug.Execute());
        }


        [Fact(Skip = "Skiping test to be run by auth users")]
        //[Fact]
        public void SkipNugetPublishForAllScope()
        {
            PublishSDKNugetTask pubNug = new PublishSDKNugetTask();
            pubNug.MultiPackagePublish = true;
            pubNug.PackageOutputPath = Path.Combine(BinariesRootDir, "packages");
            pubNug.PublishNugetToPath = PublishToDir;
            pubNug.SkipNugetPublishing = true;
            pubNug.SkipSymbolPublishing = true;

            pubNug.ScopePath = @"all";
            Assert.Throws<ApplicationException>(() => pubNug.Execute());
        }

        [Fact]
        public void PublishMultiPkgsWithUser()
        {
            PublishSDKNugetTask pubNug = new PublishSDKNugetTask();
            pubNug.MultiPackagePublish = true;
            pubNug.PackageOutputPath = Path.Combine(BinariesRootDir, "packages");
            pubNug.PublishNugetToPath = PublishToDir;
            pubNug.CIUserId = "foo";
            pubNug.ScopePath = @"sdkcommon";
            Assert.Throws<NotSupportedException>(() => pubNug.Execute());
        }

        #endregion

        #region Error Tests

        [Fact]
        public void PublishOnlySymbol()
        {
            PublishSDKNugetTask pubNug = new PublishSDKNugetTask();
            //pubNug.ScopePath = string.Empty;
            pubNug.PackageOutputPath = NugetPkgBuiltDir;
            pubNug.ScopePath = Path.GetDirectoryName(NugetPkgBuiltDir);
            pubNug.NugetPackageName = NUGET_PKG_NAME;
            pubNug.PublishNugetToPath = "https://www.nuget.org/api/v2/package/";
            pubNug.SkipNugetPublishing = true;
            pubNug.ApiKey = "1234";
            Assert.ThrowsAny<ApplicationException>(() => pubNug.Execute());
        }

        [Fact]
        public void PublishWithUnAuthenticatedKey()
        {
            PublishSDKNugetTask pubNug = new PublishSDKNugetTask();
            pubNug.PackageOutputPath = NugetPkgBuiltDir;
            pubNug.ScopePath = Path.GetDirectoryName(NugetPkgBuiltDir);
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
            PublishSDKNugetTask pubNug = new PublishSDKNugetTask();
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
            PublishSDKNugetTask pubNug = new PublishSDKNugetTask();
            pubNug.PackageOutputPath = NugetPkgBuiltDir;
            pubNug.PublishNugetToPath = PublishToDir;
            pubNug.SkipSymbolPublishing = true;
            Assert.ThrowsAny<NullReferenceException>(() => pubNug.Execute());
        }

        [Fact]
        public void RestrictPublishAllNugetUnderScope()
        {
            PublishSDKNugetTask pubNug = new PublishSDKNugetTask();
            pubNug.MultiPackagePublish = true;
            pubNug.ScopePath = Path.GetDirectoryName(NugetPkgBuiltDir);
            pubNug.PackageOutputPath = NugetPkgBuiltDir;
            pubNug.PublishNugetToPath = PublishToDir;
            pubNug.CIUserId = "foo";
            Assert.Throws<NotSupportedException>(() => pubNug.Execute());
        }

        [Fact]
        public void MissingRequiredProperties()
        {
            PublishSDKNugetTask pubNug = new PublishSDKNugetTask();
            Assert.ThrowsAny<NullReferenceException>(() => pubNug.Execute());
        }

        [Fact]
        public void SkipPublishingCompletely()
        {
            PublishSDKNugetTask pubNug = new PublishSDKNugetTask();
            pubNug.PackageOutputPath = NugetPkgBuiltDir;
            pubNug.NugetPackageName = NUGET_PKG_NAME;
            pubNug.PublishNugetToPath = PublishToDir;
            pubNug.SkipSymbolPublishing = true;
            pubNug.SkipNugetPublishing = true;
            Assert.Throws<ApplicationException>(() => pubNug.Execute());
        }


        [Fact]
        public void GetInnerExceptionWhilePublishing()
        {
            PublishSDKNugetTask pubNug = new PublishSDKNugetTask();
            pubNug.ScopePath = string.Empty;
            pubNug.PackageOutputPath = NugetPkgBuiltDir;
            pubNug.NugetPackageName = NUGET_PKG_NAME;
            pubNug.PublishNugetToPath = PublishToDir;
            pubNug.NugetExePath = @"C:\Foo\NoExistantPath\nuget.exe";
            try
            {
                pubNug.Execute();

                //If we reach at this point, something was not right, we should have got an exception
                Assert.True(false);
            }
            catch (ApplicationException appEx)
            {
                Assert.NotNull(appEx.InnerException);
            }
            //Assert.Throws<ApplicationException>(() => pubNug.Execute());
        }

        #endregion

        private void VerifyNugetPublishStatus(List<Tuple<NugetPublishStatus, NugetPublishStatus>> statusList, int expectedExitCode)
        {
            foreach (Tuple<NugetPublishStatus, NugetPublishStatus> status in statusList)
            {
                Assert.Equal(expectedExitCode, status?.Item1.NugetPublishExitCode);
                //Assert.Equal(expectedExitCode, status?.Item2.NugetPublishExitCode);
            }
        }
    }
}
