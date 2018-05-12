// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Build.Tasks.Tests.SigningManifestTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Xunit;
    using Microsoft.Azure.Sdk.Build.Tasks.Models.Esrp.Sign;
    using System.IO;

    public class SignRequestTests : SdkBuildTestBase
    {

        public SignRequestTests() { }

        [Fact]
        public void SerializeSignRequest()
        {
            SignRequest sr = CreateSampleSignRequest();

            string signJson = sr.ToJson();
        }

        private SignRequest CreateSampleSignRequest()
        {
            SignRequest signReq = new SignRequest();

            signReq.Version = "1.0.0";
            signReq.ContextData = new ContextData();
            signReq.DriEmail = new List<string>() { "abhishah@microsoft.com" };
            signReq.SignBatches = new List<SignBatch>();

            SignBatch sbatch = new SignBatch();
            sbatch.SourceLocationType = "UNC";
            sbatch.SourceRootDirectory = @"C:\signFiles\Input";
            sbatch.DestinationLocationType = "UNC";
            sbatch.DestinationRootDirectory = @"C:\signFiles\Output";

            SignRequestFile srf = new SignRequestFile();
            srf.Name = "ClientRuntime.dll";
            srf.SourceLocation = @"InputFile\ClientRuntime.dll";
            srf.DestinationLocation = @"OutputFile\ClientRuntime.dll";
            srf.HashType = null;
            srf.SizeInBytes = 0;

            sbatch.SignRequestFiles.Add(srf);

            Operation op = new Operation();
            op.KeyCode = "CodeSignTestCertSha2TestRoot";
            op.OperationCode = "Authenticode_SignTool6.2.9304_NPH";

            sbatch.SigningInfo.Operations.Add(op);

            signReq.SignBatches.Add(sbatch);

            return signReq;

        }


        [Fact]
        public void DeSerializeSignRequest()
        {
            string testSignRequestManifestFilePath = Path.Combine(TestDataRuntimeDir, "SigningManifests", "SingleFileSignRequestManifest.json");

            Assert.True(File.Exists(testSignRequestManifestFilePath));


            SignRequest sr = SignRequest.FromJson(testSignRequestManifestFilePath);
            Assert.Equal("1.0.0", sr.Version);
        }
    }
}
