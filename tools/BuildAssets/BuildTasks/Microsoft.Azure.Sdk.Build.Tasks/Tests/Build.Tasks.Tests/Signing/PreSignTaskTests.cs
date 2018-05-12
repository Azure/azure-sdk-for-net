// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Build.Tasks.Tests.Signing
{
    using Microsoft.Azure.Sdk.Build.Tasks.BuildStages.PostBuild;
    using Microsoft.WindowsAzure.Build.Tasks;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Xunit;
    public class PreSignTaskTests : BuildTestBase
    {
        public PreSignTaskTests() { }

        [Fact]
        public void PreSignOneProject()
        {
            PreSignTask pst = new PreSignTask();

            SDKCategorizeProjects sdkProj = GetCategorizedProjects(@"SDKs\Compute");            
            pst.SdkProjects = sdkProj.net452SdkProjectsToBuild.Concat(sdkProj.netStd14SdkProjectsToBuild).ToArray();

            pst.Execute();

            Assert.True(true);

        }
    }
}
