// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.TestFramework;
#region Snippet:Azure_Template
using Azure.Identity;
#endregion
using NUnit.Framework;

namespace Azure.Template.Tests.Samples
{
    public partial class TemplateSamples: SamplesBase<TemplateClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        [Ignore("Template sample - update with actual client methods")]
        public void ExampleOperation()
        {
            // TODO: Update this sample with actual client operations from your generated library
            #region Snippet:Azure_Template_ExampleOperation
#if SNIPPET
            string endpoint = "https://your-service-endpoint";
            var credential = new DefaultAzureCredential();
#else
            string endpoint = TestEnvironment.Endpoint;
            var credential = TestEnvironment.Credential;
#endif
            var client = new TemplateClient(endpoint, credential);

            // TODO: Replace with actual client method calls
            // Example:
            // var response = client.YourMethod("parameter");
            // Console.WriteLine(response.Value);
            #endregion

            // Assert.NotNull(response);
        }
    }
}
