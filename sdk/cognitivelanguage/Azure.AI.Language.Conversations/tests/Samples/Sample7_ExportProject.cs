// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading.Tasks;
using Azure.AI.Language.Conversations.Authoring;
using Azure.Core;
using Azure.Core.Serialization;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Language.Conversations.Tests.Samples
{
    public partial class ConversationAnalysisClientSamples
    {
        [SyncOnly]
        [RecordedTest]
        public async Task ExportProject()
        {
            ConversationAuthoringClient client = ProjectsClient;

            #region Snippet:ConversationAuthoringClient_ExportProject
            string projectName = "project-to-export";
#if !SNIPPET
            projectName = TestEnvironment.ProjectName;
#endif
#if SNIPPET
            Operation<BinaryData> exportOperation = client.ExportProject(WaitUntil.Completed, projectName);
#else
            // BUGBUG: https://github.com/Azure/azure-sdk-for-net/issues/29140
            Operation<BinaryData> exportOperation = client.ExportProject(WaitUntil.Started, projectName);
            await InstrumentOperation(exportOperation).WaitForCompletionAsync();
#endif

            // Get the resultUrl from the response, which contains the exported project.
            dynamic result = exportOperation.Value.ToDynamicFromJson(JsonPropertyNames.CamelCase);
            Uri resultUrl = result.resultUrl;

            // Use the client pipeline to create and send a request to download the raw URL.
            RequestUriBuilder builder = new RequestUriBuilder();
            builder.Reset(resultUrl);

            Request request = client.Pipeline.CreateRequest();
            request.Method = RequestMethod.Get;
            request.Uri = builder;

            // Save the project to a file in the current working directory.
            Response response = client.Pipeline.SendRequest(request, cancellationToken: default);

            string path = "project.json";
#if !SNIPPET
            path = Path.GetTempFileName();
#endif
            response.ContentStream.CopyTo(File.Create(path));
            #endregion

            Assert.That(response.Status, Is.EqualTo(200));
            Assert.That(resultUrl.Host, Is.EqualTo(client.Endpoint.Host));

            // Prevent compiler errors when building with SNIPPET.
            await Task.Yield();
        }

        [AsyncOnly]
        [RecordedTest]
        public async Task ExportProjectAsync()
        {
            ConversationAuthoringClient client = ProjectsClient;

            #region Snippet:ConversationAuthoringClient_ExportProjectAsync
            string projectName = "project-to-export";
#if !SNIPPET
            projectName = TestEnvironment.ProjectName;
#endif
            Operation<BinaryData> exportOperation = await client.ExportProjectAsync(WaitUntil.Completed, projectName);

            // Get the resultUrl from the response, which contains the exported project.
            dynamic result = exportOperation.Value.ToDynamicFromJson(JsonPropertyNames.CamelCase);
            Uri resultUrl = result.resultUrl;

            // Use the client pipeline to create and send a request to download the raw URL.
            RequestUriBuilder builder = new RequestUriBuilder();
            builder.Reset(resultUrl);

            Request request = client.Pipeline.CreateRequest();
            request.Method = RequestMethod.Get;
            request.Uri = builder;

            // Save the project to a file in the current working directory.
            Response response = await client.Pipeline.SendRequestAsync(request, cancellationToken: default);

            string path = "project.json";
#if !SNIPPET
            path = Path.GetTempFileName();
#endif
            await response.ContentStream.CopyToAsync(File.Create(path));
            #endregion

            Assert.That(response.Status, Is.EqualTo(200));
            Assert.That(resultUrl.Host, Is.EqualTo(client.Endpoint.Host));
        }
    }
}
