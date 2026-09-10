// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.CompilerServices;
using Azure.AI.AgentServer.Responses;
using Azure.AI.AgentServer.Responses.Models;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Responses.Tests.Snippets
{
    /// <summary>
    /// Code snippets backing Sample14_FileInputs.md. Compiled to prevent rot.
    /// </summary>
    [TestFixture]
    [Explicit("Snippets are compiled to prevent rot but require a running server to execute.")]
    public class Sample14Snippets
    {
        [Test]
        public void StartFileHandler()
        {
            #region Snippet:Responses_Sample14_StartFileHandler

            ResponsesServer.Run<FileBase64Handler>();

            #endregion
        }

        [Test]
        public void Implement_FileBase64Handler()
        {
            var handler = new FileBase64Handler();
            Assert.That(handler, Is.Not.Null);
        }

        [Test]
        public void Implement_FileUrlHandler()
        {
            var handler = new FileUrlHandler();
            Assert.That(handler, Is.Not.Null);
        }

        [Test]
        public void Implement_FileIdHandler()
        {
            var handler = new FileIdHandler();
            Assert.That(handler, Is.Not.Null);
        }

        #region Snippet:Responses_Sample14_FileBase64Handler

        public class FileBase64Handler : ResponseHandler
        {
            public override async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
                CreateResponse request,
                ResponseContext context,
                [EnumeratorCancellation] CancellationToken cancellationToken)
            {
                var stream = new ResponseEventStream(context, request);

                yield return stream.EmitCreated();
                yield return stream.EmitInProgress();

                var items = await context.GetInputItemsAsync(cancellationToken: cancellationToken);

                // Find file content parts from user messages.
                var files = items
                    .OfType<ItemMessage>()
                    .SelectMany(msg => msg.GetContentExpanded())
                    .OfType<MessageContentInputFileContent>()
                    .ToList();

                string reply;
                if (files.Count > 0 && DataUrl.TryDecodeBytes(files[0].FileData, out byte[] fileBytes))
                {
                    string filename = files[0].Filename ?? "unknown";
                    reply = $"Received file '{filename}' ({fileBytes.Length} bytes inline).";
                }
                else
                {
                    reply = "No inline file data found in the input.";
                }

                foreach (var evt in stream.OutputItemMessage(reply))
                    yield return evt;

                yield return stream.EmitCompleted();
            }
        }

        #endregion

        #region Snippet:Responses_Sample14_FileUrlHandler

        public class FileUrlHandler : ResponseHandler
        {
            public override async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
                CreateResponse request,
                ResponseContext context,
                [EnumeratorCancellation] CancellationToken cancellationToken)
            {
                var stream = new ResponseEventStream(context, request);

                yield return stream.EmitCreated();
                yield return stream.EmitInProgress();

                var items = await context.GetInputItemsAsync(cancellationToken: cancellationToken);

                var files = items
                    .OfType<ItemMessage>()
                    .SelectMany(msg => msg.GetContentExpanded())
                    .OfType<MessageContentInputFileContent>()
                    .ToList();

                string reply;
                if (files.Count > 0 && files[0].FileUrl != null)
                {
                    string filename = files[0].Filename ?? "unknown";
                    reply = $"Received file '{filename}' via URL: {files[0].FileUrl}";
                }
                else
                {
                    reply = "No file URL found in the input.";
                }

                foreach (var evt in stream.OutputItemMessage(reply))
                    yield return evt;

                yield return stream.EmitCompleted();
            }
        }

        #endregion

        #region Snippet:Responses_Sample14_FileIdHandler

        public class FileIdHandler : ResponseHandler
        {
            public override async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
                CreateResponse request,
                ResponseContext context,
                [EnumeratorCancellation] CancellationToken cancellationToken)
            {
                var stream = new ResponseEventStream(context, request);

                yield return stream.EmitCreated();
                yield return stream.EmitInProgress();

                var items = await context.GetInputItemsAsync(cancellationToken: cancellationToken);

                var files = items
                    .OfType<ItemMessage>()
                    .SelectMany(msg => msg.GetContentExpanded())
                    .OfType<MessageContentInputFileContent>()
                    .ToList();

                string reply;
                if (files.Count > 0 && files[0].FileId != null)
                {
                    string filename = files[0].Filename ?? "unknown";
                    reply = $"Received file '{filename}' with ID: {files[0].FileId}";
                }
                else
                {
                    reply = "No file ID found in the input.";
                }

                foreach (var evt in stream.OutputItemMessage(reply))
                    yield return evt;

                yield return stream.EmitCompleted();
            }
        }

        #endregion
    }
}
