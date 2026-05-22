// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.CompilerServices;
using Azure.AI.AgentServer.Responses;
using Azure.AI.AgentServer.Responses.Models;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Responses.Tests.Snippets
{
    /// <summary>
    /// Code snippets backing Sample15_Annotations.md. Compiled to prevent rot.
    /// </summary>
    [TestFixture]
    [Explicit("Snippets are compiled to prevent rot but require a running server to execute.")]
    public class Sample15Snippets
    {
        [Test]
        public void StartServer()
        {
            #region Snippet:Responses_Sample15_StartServer

            ResponsesServer.Run<FileAnnotationsHandler>();

            #endregion
        }

        [Test]
        public void Implement_FileAnnotationsHandler()
        {
        }

        #region Snippet:Responses_Sample15_FileAnnotationsHandler

        public class FileAnnotationsHandler : ResponseHandler
        {
            public override async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
                CreateResponse request,
                ResponseContext context,
                [EnumeratorCancellation] CancellationToken cancellationToken)
            {
                var stream = new ResponseEventStream(context, request);

                yield return stream.EmitCreated();
                yield return stream.EmitInProgress();

                // Mix different annotation types on the same message.
                // file_path — references a file by ID in your own store.
                // file_citation — cites a file stored in your own file store.
                // url_citation — cites a web URL referenced in the text.
                var annotations = new Annotation[]
                {
                    new FilePath(fileId: "/reports/monthly-summary.pdf", index: 0),
                    new FilePath(fileId: "/exports/data.csv", index: 1),
                    new FilePath(fileId: "/images/chart.png", index: 2),
                    new FileCitationBody(fileId: "/sources/research-paper.pdf", index: 3, filename: "research-paper.pdf"),
                    new UrlCitationBody(url: new Uri("https://example.com/docs/guide"), startIndex: 0, endIndex: 29, title: "Developer Guide"),
                };

                // Emit a message with the annotations attached to the text content.
                foreach (var evt in stream.OutputItemMessage(
                    "Here are your files and sources.",
                    annotations))
                {
                    yield return evt;
                }

                yield return stream.EmitCompleted();
                await Task.CompletedTask;
            }
        }

        #endregion
    }
}
