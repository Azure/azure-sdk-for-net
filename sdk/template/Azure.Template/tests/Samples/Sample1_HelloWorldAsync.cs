// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Template.Tests.Samples
{
    public partial class TemplateSamples: SamplesBase<TemplateClientTestEnvironment>
    {
        [Test]
        [AsyncOnly]
        [Ignore("Template sample - update with actual client methods")]
        public async Task ExampleOperationAsync()
        {
            // TODO: Update this sample with actual client operations from your generated library
            #region Snippet:Azure_Template_ExampleOperationAsync
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
            // var response = await client.YourMethodAsync("parameter");
            // Console.WriteLine(response.Value);
            #endregion

            // Assert.NotNull(response);
            await Task.CompletedTask; // Remove this line when adding actual async operations
        }
    }
}
