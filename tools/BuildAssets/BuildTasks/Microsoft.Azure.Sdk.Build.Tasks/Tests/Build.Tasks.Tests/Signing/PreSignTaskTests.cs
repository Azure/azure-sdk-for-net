// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Build.Tasks.Tests.Signing
{
    using Microsoft.Azure.Sdk.Build.Tasks.BuildStages.PostBuild;
    using Microsoft.Azure.Sdk.Build.Tasks.Models.Esrp.Sign;
    using Microsoft.Build.Framework;
    using Microsoft.WindowsAzure.Build.Tasks;
    using System.IO;
    using System.Linq;
    using Xunit;
    public class PreSignTaskTests : BuildTestBase
    {
        public PreSignTaskTests() { }

        [Fact]
        public void PreSignOneProject()
        {
            PreSignTask pst = new PreSignTask();

            SDKCategorizeProjects sdkProj = GetCategorizedProjects(@"SDKs\Compute");            
            pst.InSdkProjects = sdkProj.net452SdkProjectsToBuild.Concat(sdkProj.netStd14SdkProjectsToBuild).ToArray();
            pst.InSignManifestDirPath = this.SignManifestDir;
            pst.InSignBuildName = "TestSignBuildJob";

            pst.Execute();
            Assert.Collection<string>(pst.OutSignManifestFiles, (elem) => { });

            SignRequest signReq = SignRequest.FromJsonFile(pst.OutSignManifestFiles[0]);
            Assert.Collection<SignBatch>(signReq.SignBatches, (elem) => { });
            Assert.Equal(pst.InSdkProjects.Count<ITaskItem>(), signReq.SignBatches[0].SignRequestFiles.Count);
        }

        [Fact]
        public void PreSignOnNugetPackage()
        {
            PreSignTask pst = new PreSignTask();
            //pst.InSignedFilesRootDirPath = Path.Combine(this.TestDataRuntimeDir, "PublishedNugets");
            pst.InSignedFilesRootDirPath = Path.GetDirectoryName(this.TestBinaryOutputDir);
            pst.InSearchExtensionToSearch = ".nupkg";
            pst.InSignBuildName = "TestSignBuildJob";
            pst.InSignManifestDirPath = this.SignManifestDir;
            pst.InSigningOperation = "nuget";

            pst.Execute();
            Assert.Collection<string>(pst.OutSignManifestFiles, (elem) => { });

            SignRequest signReq = SignRequest.FromJsonFile(pst.OutSignManifestFiles[0]);
            Assert.Collection<SignBatch>(signReq.SignBatches, (elem) => { });
            Assert.Collection<SignRequestFile>(signReq.SignBatches[0].SignRequestFiles, (col1Elm) => { }, (col2Elm) => { });

            Assert.Collection<Operation>(signReq.SignBatches[0].SigningInfo.Operations, (col1Elm) => { }, (col2Elm) => { });
        }

        /// <summary>
        /// Trying to create manifest file from non-existant directory root
        /// </summary>
        [Fact(Skip = "Code Moved to SignNugetTask")]
        public void PreSignTaskNonExistantDirectory()
        {
            PreSignTask pst = new PreSignTask();
            pst.InSignedFilesRootDirPath = Path.Combine(this.TestDataRuntimeDir, "Foo");
            
            pst.InSearchExtensionToSearch = ".nupkg";
            pst.InSignBuildName = "TestSignBuildJob";
            pst.InSignManifestDirPath = this.SignManifestDir;

            pst.Execute();
            Assert.Empty(pst.OutSignManifestFiles);
        }

        /// <summary>
        /// Trying to create manifest file with non-existant file extensions
        /// </summary>
        [Fact(Skip = "Code Moved to SignNugetTask")]
        public void PreSignTaskNoFilesToSign()
        {
            PreSignTask pst = new PreSignTask();
            pst.InSignedFilesRootDirPath = this.TestDataRuntimeDir;
            pst.InSearchExtensionToSearch = ".foo";
            pst.InSignBuildName = "TestSignBuildJob";
            pst.InSignManifestDirPath = this.SignManifestDir;

            pst.Execute();
            Assert.Empty(pst.OutSignManifestFiles);
        }

    }
}
