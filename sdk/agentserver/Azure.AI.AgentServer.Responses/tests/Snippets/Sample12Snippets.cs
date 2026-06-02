// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.CompilerServices;
using Azure.AI.AgentServer.Responses;
using Azure.AI.AgentServer.Responses.Models;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Responses.Tests.Snippets
{
    /// <summary>
    /// Code snippets backing Sample12_ImageGeneration.md. Compiled to prevent rot.
    /// </summary>
    [TestFixture]
    [Explicit("Snippets are compiled to prevent rot but require a running server to execute.")]
    public class Sample12Snippets
    {
        [Test]
        public void StartServer()
        {
            #region Snippet:Responses_Sample12_StartServer

            ResponsesServer.Run<ImageHandler>();

            #endregion
        }

        [Test]
        public void Implement_ImageHandler()
        {
            var handler = new ImageHandler();
            Assert.That(handler, Is.Not.Null);
        }

        [Test]
        public void Implement_StreamingImageHandler()
        {
            var handler = new StreamingImageHandler();
            Assert.That(handler, Is.Not.Null);
        }

        [Test]
        public void Implement_ImageHandlerFullControl()
        {
            var handler = new ImageHandlerFullControl();
            Assert.That(handler, Is.Not.Null);
        }

        #region Snippet:Responses_Sample12_ImageHandlerConvenience

        public class ImageHandler : ResponseHandler
        {
            public override async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
                CreateResponse request,
                ResponseContext context,
                [EnumeratorCancellation] CancellationToken cancellationToken)
            {
                var stream = new ResponseEventStream(context, request);

                yield return stream.EmitCreated();
                yield return stream.EmitInProgress();

                // Generate an image (in a real handler, this would call a model or service).
                byte[] imageBytes = await GenerateImageAsync(cancellationToken);
                string resultBase64 = Convert.ToBase64String(imageBytes);

                foreach (var evt in stream.OutputItemImageGenCall(resultBase64))
                    yield return evt;

                yield return stream.EmitCompleted();
            }

            private static Task<byte[]> GenerateImageAsync(CancellationToken cancellationToken)
            {
                // Placeholder: return a 1x1 red PNG.
                byte[] png =
                [
                    0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A, 0x00, 0x00, 0x00, 0x0D,
                    0x49, 0x48, 0x44, 0x52, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x01,
                    0x08, 0x02, 0x00, 0x00, 0x00, 0x90, 0x77, 0x53, 0xDE, 0x00, 0x00, 0x00,
                    0x0C, 0x49, 0x44, 0x41, 0x54, 0x08, 0xD7, 0x63, 0xF8, 0xCF, 0xC0, 0x00,
                    0x00, 0x00, 0x03, 0x00, 0x01, 0x36, 0x28, 0x19, 0x00, 0x00, 0x00, 0x00,
                    0x00, 0x49, 0x45, 0x4E, 0x44, 0xAE, 0x42, 0x60, 0x82,
                ];
                return Task.FromResult(png);
            }
        }

        #endregion

        #region Snippet:Responses_Sample12_ImageHandlerStreaming

        public class StreamingImageHandler : ResponseHandler
        {
            public override async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
                CreateResponse request,
                ResponseContext context,
                [EnumeratorCancellation] CancellationToken cancellationToken)
            {
                var stream = new ResponseEventStream(context, request);

                yield return stream.EmitCreated();
                yield return stream.EmitInProgress();

                var ig = stream.AddOutputItemImageGenCall();
                yield return ig.EmitAdded();
                yield return ig.EmitInProgress();
                yield return ig.EmitGenerating();

                // Stream progressive renders as they become available.
                await foreach (string partialBase64 in GeneratePartialsAsync(cancellationToken))
                {
                    yield return ig.EmitPartialImage(partialBase64);
                }

                // Final full-quality image (available only after generation completes).
                byte[] finalImage = await RenderFinalAsync(cancellationToken);
                yield return ig.EmitCompleted();
                yield return ig.EmitDone(Convert.ToBase64String(finalImage));

                yield return stream.EmitCompleted();
            }

            private static async IAsyncEnumerable<string> GeneratePartialsAsync(
                [EnumeratorCancellation] CancellationToken cancellationToken)
            {
                // In a real handler, each yield would be a progressively higher-quality render.
                for (int i = 0; i < 2; i++)
                {
                    await Task.Delay(10, cancellationToken);
                    yield return Convert.ToBase64String(OnePxPng);
                }
            }

            private static Task<byte[]> RenderFinalAsync(CancellationToken cancellationToken) =>
                Task.FromResult(OnePxPng);

            // Minimal 1×1 red PNG for demonstration.
            private static readonly byte[] OnePxPng =
            [
                0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A, 0x00, 0x00, 0x00, 0x0D,
                0x49, 0x48, 0x44, 0x52, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x01,
                0x08, 0x02, 0x00, 0x00, 0x00, 0x90, 0x77, 0x53, 0xDE, 0x00, 0x00, 0x00,
                0x0C, 0x49, 0x44, 0x41, 0x54, 0x08, 0xD7, 0x63, 0xF8, 0xCF, 0xC0, 0x00,
                0x00, 0x00, 0x03, 0x00, 0x01, 0x36, 0x28, 0x19, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x49, 0x45, 0x4E, 0x44, 0xAE, 0x42, 0x60, 0x82,
            ];
        }

        #endregion

        #region Snippet:Responses_Sample12_ImageHandlerFullControl

        public class ImageHandlerFullControl : ResponseHandler
        {
            public override async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
                CreateResponse request,
                ResponseContext context,
                [EnumeratorCancellation] CancellationToken cancellationToken)
            {
                var stream = new ResponseEventStream(context, request);

                yield return stream.EmitCreated();
                yield return stream.EmitInProgress();

                var ig = stream.AddOutputItemImageGenCall();
                yield return ig.EmitAdded();
                yield return ig.EmitInProgress();
                yield return ig.EmitGenerating();

                // Optional: stream partial images for progressive rendering.
                byte[] partial = await RenderLowResAsync(cancellationToken);
                yield return ig.EmitPartialImage(Convert.ToBase64String(partial));

                // Final high-resolution result.
                byte[] finalImage = await RenderFullResAsync(cancellationToken);
                yield return ig.EmitCompleted();
                yield return ig.EmitDone(Convert.ToBase64String(finalImage));

                yield return stream.EmitCompleted();
            }

            private static Task<byte[]> RenderLowResAsync(CancellationToken cancellationToken) =>
                Task.FromResult(OnePxPng);

            private static Task<byte[]> RenderFullResAsync(CancellationToken cancellationToken) =>
                Task.FromResult(OnePxPng);

            private static readonly byte[] OnePxPng =
            [
                0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A, 0x00, 0x00, 0x00, 0x0D,
                0x49, 0x48, 0x44, 0x52, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x01,
                0x08, 0x02, 0x00, 0x00, 0x00, 0x90, 0x77, 0x53, 0xDE, 0x00, 0x00, 0x00,
                0x0C, 0x49, 0x44, 0x41, 0x54, 0x08, 0xD7, 0x63, 0xF8, 0xCF, 0xC0, 0x00,
                0x00, 0x00, 0x03, 0x00, 0x01, 0x36, 0x28, 0x19, 0x00, 0x00, 0x00, 0x00,
                0x00, 0x49, 0x45, 0x4E, 0x44, 0xAE, 0x42, 0x60, 0x82,
            ];
        }

        #endregion
    }
}
