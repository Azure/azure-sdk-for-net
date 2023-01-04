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
    public partial class LoadTestingSamples : SamplesBase<LoadTestingClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void BeginUploadTestFile()
        {
            string endpoint = TestEnvironment.Endpoint;
            Uri enpointUrl = new Uri("https://" + endpoint);
            TokenCredential credential = TestEnvironment.Credential;

            // creating LoadTesting Administration Client
            LoadTestAdministrationClient loadTestAdministrationClient = new LoadTestAdministrationClient(enpointUrl, credential);

            #region Snippet:Azure_Developer_LoadTesting_BeginUploadTestFile

            string testId = "my-loadtest";

            try
            {
                // poller object
                FileUploadOperation operation = loadTestAdministrationClient.BeginUploadTestFile(testId, "sample.jmx", RequestContent.Create(
                        Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "sample.jmx")
                    ));

                // get the intial reponse for uploading file
                Response initialResponse = operation.GetRawResponse();
                Console.WriteLine(initialResponse.Content.ToString());

                // run lro to check the validation of file uploaded
                operation.WaitForCompletion();

                // printing final response
                Response validatedFileResponse = operation.GetRawResponse();
                Console.WriteLine(validatedFileResponse.Content.ToString());
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            #endregion
        }
    }
}
