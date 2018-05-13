// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Build.Tasks.Tests.Signing
{
    using Microsoft.Azure.Sdk.Build.Tasks.BuildStages.PostBuild;
    using Microsoft.Azure.Sdk.Build.Tasks.Models.Esrp.Sign;
    using Microsoft.Build.Framework;
    using Microsoft.WindowsAzure.Build.Tasks;
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
    }
}
