// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Build.Tasks.Tests.Signing
{
    using Microsoft.Azure.Sdk.Build.ExecProcess;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Xunit;

    public class NugetSigningTaskTest
    {
        [Fact]
        public void SignOneNuet()
        {
            SignClientExec signExec = new SignClientExec();
            signExec.CiToolsRootDir = @"D:\myFork\ci-signing\adxsdk";
            signExec.SigningInputManifestFilePath = @"D:\myFork\netSdkBuild\binaries\SignManifest\RootDirFiles_SigningRequest.json";
            signExec.SigningResultOutputFilePath = @"D:\myFork\netSdkBuild\binaries\SignManifest\SignServiceOutput.json";

            int foo = signExec.ExecuteCommand();
            Assert.Equal(0, foo);
        }
    }
}
