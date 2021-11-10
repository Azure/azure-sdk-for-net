// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Template.LLC.Tests.Samples
{
    public class TemplateLLCSamples : SamplesBase<TemplateLLCTestEnvironment>
    {
        public void Authenticate()
        {
            var endpoint = TestEnvironment.Endpoint;

            #region Snippet:TemplateLLCAuthenticate
            var serviceClient = new TemplateLLCClient(new DefaultAzureCredential(), new Uri(endpoint));
            #endregion
        }

        // Add sample tests here
    }
}
