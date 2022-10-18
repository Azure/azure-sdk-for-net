// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Developer.LoadTesting.Tests.Samples
{
    public partial class LoadTestingSamples: SamplesBase<LoadTestingClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void UploadTestFile()
        {
            string endpoint = TestEnvironment.Endpoint;
            TokenCredential credential = TestEnvironment.Credential;

            // creating LoadTesting Client
            LoadTestingClient loadTestingClient = new LoadTestingClient(endpoint, credential);

            // getting appropriate Subclient
            LoadTestAdministrationClient loadTestAdministrationClient = loadTestingClient.getLoadTestAdministration();

            #region Snippet:Azure_Developer_LoadTesting_UploadTestFile

            // provide unique identifier for your test
            string testId = "my-test-id";

            // provide unique identifier for your file
            string fileId = "my-file-id";

            try
            {
                // uploading file
                Response response = loadTestAdministrationClient.UploadTestFile(testId, fileId, File.OpenRead(
                    Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "sample.jmx")
                    ));

                // if the file is uploaded successfully, printing response
                Console.WriteLine(response.Content);
            }
            catch (Exception e)
            {
                Console.WriteLine(String.Format("Error : ", e.Message));
            }
            #endregion
        }
    }
}
