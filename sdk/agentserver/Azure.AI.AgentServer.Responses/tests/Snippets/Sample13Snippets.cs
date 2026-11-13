// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.CompilerServices;
using Azure.AI.AgentServer.Responses;
using Azure.AI.AgentServer.Responses.Models;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Responses.Tests.Snippets
{
    /// <summary>
    /// Code snippets backing Sample13_ImageInput.md. Compiled to prevent rot.
    /// </summary>
    [TestFixture]
    [Explicit("Snippets are compiled to prevent rot but require a running server to execute.")]
    public class Sample13Snippets
    {
        [Test]
        public void StartUrlHandler()
        {
            #region Snippet:Responses_Sample13_StartUrlHandler

            ResponsesServer.Run<ImageUrlHandler>();

            #endregion
        }

        [Test]
        public void Implement_ImageUrlHandler()
        {
            var handler = new ImageUrlHandler();
            Assert.That(handler, Is.Not.Null);
        }

        [Test]
        public void Implement_ImageBase64Handler()
        {
            var handler = new ImageBase64Handler();
            Assert.That(handler, Is.Not.Null);
        }

        [Test]
        public void Implement_ImageFileIdHandler()
        {
            var handler = new ImageFileIdHandler();
            Assert.That(handler, Is.Not.Null);
        }

        #region Snippet:Responses_Sample13_ImageUrlHandler

        public class ImageUrlHandler : ResponseHandler
        {
            public override async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
                CreateResponse request,
                ResponseContext context,
                [EnumeratorCancellation] CancellationToken cancellationToken)
            {
                var stream = new ResponseEventStream(context, request);

                yield return stream.EmitCreated();
                yield return stream.EmitInProgress();

                // Retrieve the resolved input items and expand message content.
                var items = await context.GetInputItemsAsync(cancellationToken: cancellationToken);
                var imageUrls = items
                    .OfType<ItemMessage>()
                    .SelectMany(msg => msg.GetContentExpanded())
                    .OfType<MessageContentInputImageContent>()
                    .Where(img => img.ImageUrl != null)
                    .Select(img => img.ImageUrl)
                    .ToList();

                // Describe what we received (a real handler would call a vision model).
                string description = imageUrls.Count > 0
                    ? $"I received {imageUrls.Count} image(s). First URL: {imageUrls[0]}"
                    : "No images found in the input.";

                foreach (var evt in stream.OutputItemMessage(description))
                    yield return evt;

                yield return stream.EmitCompleted();
            }
        }

        #endregion

        #region Snippet:Responses_Sample13_ImageBase64Handler

        public class ImageBase64Handler : ResponseHandler
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

                // Find all image content parts.
                var images = items
                    .OfType<ItemMessage>()
                    .SelectMany(msg => msg.GetContentExpanded())
                    .OfType<MessageContentInputImageContent>()
                    .Where(img => img.ImageUrl != null)
                    .ToList();

                string reply;
                if (images.Count > 0 && DataUrl.TryDecodeBytes(images[0].ImageUrl, out byte[] imageBytes))
                {
                    string? mediaType = DataUrl.GetMediaType(images[0].ImageUrl);
                    reply = $"Received a {mediaType ?? "unknown"} image ({imageBytes.Length} bytes).";
                }
                else
                {
                    reply = "No base64 images found in the input.";
                }

                foreach (var evt in stream.OutputItemMessage(reply))
                    yield return evt;

                yield return stream.EmitCompleted();
            }
        }

        #endregion

        #region Snippet:Responses_Sample13_ImageFileIdHandler

        public class ImageFileIdHandler : ResponseHandler
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

                // Find image content parts that use file_id (a path in your file store).
                var images = items
                    .OfType<ItemMessage>()
                    .SelectMany(msg => msg.GetContentExpanded())
                    .OfType<MessageContentInputImageContent>()
                    .Where(img => img.FileId != null)
                    .ToList();

                string reply = images.Count > 0
                    ? $"Received {images.Count} image(s) by file ID. First: {images[0].FileId}"
                    : "No file_id images found in the input.";

                foreach (var evt in stream.OutputItemMessage(reply))
                    yield return evt;

                yield return stream.EmitCompleted();
            }
        }

        #endregion
    }
}
