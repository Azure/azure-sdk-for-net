// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.Vision.Face;
using Azure.AI.Vision.Face.Tests;
using Azure.Core.TestFramework;
using Azure.Identity;

namespace Azure.AI.Vision.Face.Samples
{
    [LiveOnly]
    [AsyncOnly]
    public partial class FaceSamples : RecordedTestBase<FaceTestEnvironment>
    {
        public FaceSamples(bool isAsync) : base(isAsync, RecordedTestMode.Live)
        {
        }

        public FaceClient CreateClient()
        {
            #region Snippet:CreateFaceClient
#if SNIPPET
            Uri endpoint = new Uri("<your endpoint>");
            AzureKeyCredential credential = new AzureKeyCredential("<your apiKey>");
#else
            var endpoint = TestEnvironment.GetUrlVariable("FACE_ENDPOINT");
            var credential = TestEnvironment.GetKeyVariable("FACE_KEY");
#endif

            var client = new FaceClient(endpoint, credential);
            #endregion
            return client;
        }

        public FaceAdministrationClient CreateAdministrationClient()
        {
#if SNIPPET
            Uri endpoint = new Uri("<your endpoint>");
            AzureKeyCredential credential = new AzureKeyCredential("<your apiKey>");
#else
            var endpoint = TestEnvironment.GetUrlVariable("FACE_ENDPOINT");
            var credential = TestEnvironment.GetKeyVariable("FACE_KEY");
#endif

            var client = new FaceAdministrationClient(endpoint, credential);
            return client;
        }

        public FaceSessionClient CreateSessionClient()
        {
            #region Snippet:CreateFaceSessionClient
#if SNIPPET
            Uri endpoint = new Uri("<your endpoint>");
            AzureKeyCredential credential = new AzureKeyCredential("<your apiKey>");
#else
            var endpoint = TestEnvironment.GetUrlVariable("FACE_ENDPOINT");
            var credential = TestEnvironment.GetKeyVariable("FACE_KEY");
#endif

            var sessionClient = new FaceSessionClient(endpoint, credential);
            #endregion
            return sessionClient;
        }

        public FaceClient CreateClientWithAzureDefaultCredential()
        {
            #region Snippet:CreateFaceClientWithDefaultAzureCredential
            Uri endpoint = new Uri("<your endpoint>");
            DefaultAzureCredential credential = new DefaultAzureCredential();
            var client = new FaceClient(endpoint, credential);
            #endregion
            return client;
        }
    }
}
