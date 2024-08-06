// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.Vision.Face;
using Azure.AI.Vision.Face.Tests;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.AI.Vision.Face.Samples
{
    public class FaceSamplesBase : SamplesBase<FaceTestEnvironment>
    {
        public FaceClient CreateClient()
        {
            #region Snippet:CreateFaceClient
#if SNIPPET
            Uri endpoint = new Uri("<your endpoint>");
#else
            var endpoint = TestEnvironment.GetUrlVariable("FACE_ENDPOINT");
#endif
            DefaultAzureCredential credential = new DefaultAzureCredential();
            var client = new FaceClient(endpoint, credential);
            #endregion
            return client;
        }

        public FaceSessionClient CreateSessionClient()
        {
            #region Snippet:CreateFaceSessionClient
#if SNIPPET
            Uri endpoint = new Uri("<your endpoint>");
#else
            var endpoint = TestEnvironment.GetUrlVariable("FACE_ENDPOINT");
#endif
            DefaultAzureCredential credential = new DefaultAzureCredential();
            var sessionClient = new FaceSessionClient(endpoint, credential);
            #endregion
            return sessionClient;
        }

        public FaceClient CreateClientWithKey()
        {
            #region Snippet:CreateFaceClientWithKey
            Uri endpoint = new Uri("<your endpoint>");
            AzureKeyCredential credential = new AzureKeyCredential("<your apiKey>");
            var client = new FaceClient(endpoint, credential);
            #endregion
            return client;
        }
    }
}
