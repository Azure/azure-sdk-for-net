// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.CompilerServices;
using Azure.AI.AgentServer.Responses;
using Azure.AI.AgentServer.Responses.Models;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Responses.Tests.Snippets
{
    /// <summary>
    /// Code snippets backing Sample16_StructuredOutputs.md. Compiled to prevent rot.
    /// </summary>
    [TestFixture]
    [Explicit("Snippets are compiled to prevent rot but require a running server to execute.")]
    public class Sample16Snippets
    {
        [Test]
        public void StartServer()
        {
            #region Snippet:Responses_Sample16_StartServer

            ResponsesServer.Run<StructuredOutputHandler>();

            #endregion
        }

        [Test]
        public void Implement_StructuredOutputHandler()
        {
        }

        #region Snippet:Responses_Sample16_StructuredOutputHandler

        public class StructuredOutputHandler : ResponseHandler
        {
            public override async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
                CreateResponse request,
                ResponseContext context,
                [EnumeratorCancellation] CancellationToken cancellationToken)
            {
                var stream = new ResponseEventStream(context, request);

                yield return stream.EmitCreated();
                yield return stream.EmitInProgress();

                // Build structured data — any serializable object works.
                // This example returns analytics alongside generated file references
                // to demonstrate that the payload shape is entirely up to the developer.
                var result = new
                {
                    sentiment = "positive",
                    confidence = 0.95,
                    topics = new[] { "product-quality", "customer-service" },
                    files = new object[]
                    {
                        new { name = "report.pdf", url = "https://storage.example.com/files/report.pdf", mediaType = "application/pdf" },
                        new { name = "chart.png", url = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUg...", mediaType = "image/png" },
                    },
                };

                // Emit as a structured outputs item.
                foreach (var evt in stream.OutputItemStructuredOutputs(
                    BinaryData.FromObjectAsJson(result)))
                {
                    yield return evt;
                }

                yield return stream.EmitCompleted();
                await Task.CompletedTask;
            }
        }

        #endregion

        [Test]
        public void Implement_StructuredOutputFullControlHandler()
        {
        }

        #region Snippet:Responses_Sample16_StructuredOutputFullControl

        public class StructuredOutputFullControlHandler : ResponseHandler
        {
            public override async IAsyncEnumerable<ResponseStreamEvent> CreateAsync(
                CreateResponse request,
                ResponseContext context,
                [EnumeratorCancellation] CancellationToken cancellationToken)
            {
                var stream = new ResponseEventStream(context, request);

                yield return stream.EmitCreated();
                yield return stream.EmitInProgress();

                // Get a builder for explicit event control.
                var builder = stream.AddOutputItemStructuredOutputs();

                var payload = BinaryData.FromObjectAsJson(new
                {
                    classification = "urgent",
                    entities = new[]
                    {
                        new { name = "Order #12345", type = "order_id" },
                        new { name = "2024-01-15", type = "date" },
                    },
                });

                var item = new StructuredOutputsOutputItem(payload, builder.ItemId);
                yield return builder.EmitAdded(item);
                yield return builder.EmitDone(item);

                yield return stream.EmitCompleted();
                await Task.CompletedTask;
            }
        }

        #endregion
    }
}
