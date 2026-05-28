// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.ClientModel.Primitives;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Azure;
using Azure.AI.ContentUnderstanding;
using Azure.AI.ContentUnderstanding.Tests;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.ContentUnderstanding.Samples
{
    public partial class ContentUnderstandingSamples
    {
        /// <summary>
        /// Demonstrates how to use rehydration tokens to resume a long-running analysis
        /// operation from a different process or after a restart.
        ///
        /// Rehydration is useful when:
        /// - The analysis takes a long time and you can't keep the process alive.
        /// - You need to start the operation in one service (e.g., a web API) and poll
        ///   for completion in another (e.g., a background worker).
        /// - You want to persist the operation state across application restarts.
        ///
        /// The workflow is:
        /// 1. Start the operation with <c>WaitUntil.Started</c>.
        /// 2. Get a <see cref="RehydrationToken"/> via <c>GetRehydrationToken()</c>.
        /// 3. Serialize and persist the token (e.g., to a database, queue, or file).
        /// 4. In another process, deserialize the token and call <c>Operation.RehydrateAsync()</c>
        ///    to reconstruct the operation and resume polling.
        ///
        /// This sample simulates this two-process handoff by saving the token to a temporary
        /// file and reading it back, as you would in a real distributed system.
        /// </summary>
        [RecordedTest]
        public async Task RehydrateOperationAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            var options = InstrumentClientOptions(new ContentUnderstandingClientOptions());
            var client = InstrumentClient(new ContentUnderstandingClient(new Uri(endpoint), TestEnvironment.Credential, options));

            #region Snippet:ContentUnderstandingRehydrateStartAndSaveToken
            // Start a long-running analysis without waiting for completion.
            Uri uriSource = new Uri("https://raw.githubusercontent.com/Azure-Samples/azure-ai-content-understanding-assets/main/document/invoice.pdf");

            Operation<AnalysisResult> operation = await client.AnalyzeAsync(
                WaitUntil.Started,
                "prebuilt-read",
                inputs: new[] { new AnalysisInput { Uri = uriSource } });

            Console.WriteLine($"Operation started with ID: {operation.Id}");

            // Get the rehydration token — this captures the full operation state
            // (polling URI, operation ID, HTTP method, etc.) so it can be resumed later.
            RehydrationToken? rehydrationToken = operation.GetRehydrationToken();
            RehydrationToken tokenValue = rehydrationToken!.Value;
            Console.WriteLine($"Rehydration token obtained. Token ID: {tokenValue.Id}");

            // Save the token to a file. In a real application, you might store this in
            // a database, queue message, or any durable medium. The token is a lightweight
            // JSON object (~300 bytes).
            string tokenFilePath = Path.Combine(Path.GetTempPath(), $"cu-operation-{operation.Id}.json");
            string serializedToken = ModelReaderWriter.Write(tokenValue).ToString();
            File.WriteAllText(tokenFilePath, serializedToken);
            Console.WriteLine($"Token saved to {tokenFilePath} ({serializedToken.Length} chars)");

            // Process A can now exit. The operation continues running on the server.
            #endregion

            try
            {
                #region Snippet:ContentUnderstandingRehydrateResumePolling
                // Read the saved token from file.
                string savedToken = File.ReadAllText(tokenFilePath);
                RehydrationToken restoredToken = ModelReaderWriter
                    .Read<RehydrationToken>(BinaryData.FromString(savedToken))!;
                Console.WriteLine($"Token loaded from file. Operation ID: {restoredToken.Id}");

                // Rehydrate the operation from the saved token.
                // This reconstructs the polling state machine without re-sending the original request.
                Operation rehydratedOp = await Operation.RehydrateAsync(client.Pipeline, restoredToken);
                Console.WriteLine($"Operation rehydrated. Completed: {rehydratedOp.HasCompleted}");

                // Resume polling until the operation completes.
                Response completionResponse = await rehydratedOp.WaitForCompletionResponseAsync();
                Console.WriteLine($"Operation completed: {rehydratedOp.HasCompleted}");

                // Parse the result from the response body and access the extracted markdown.
                // The LRO response contains a "result" property with the AnalysisResult.
                using JsonDocument document = JsonDocument.Parse(completionResponse.Content);
                JsonElement resultElement = document.RootElement.GetProperty("result");
                AnalysisResult result = ModelReaderWriter.Read<AnalysisResult>(
                    BinaryData.FromString(resultElement.GetRawText()))!;

                foreach (AnalysisContent content in result.Contents!)
                {
                    Console.WriteLine($"--- Content (MIME: {content.MimeType}) ---");
                    Console.WriteLine(content.Markdown);
                }

                // Clean up the token file.
                File.Delete(tokenFilePath);
                #endregion

                #region Assertion:ContentUnderstandingRehydrateOperationAsync
                // Verify the operation started successfully
                Assert.IsNotNull(operation, "Operation should not be null");
                Assert.IsNotNull(operation.Id, "Operation ID should not be null");
                Assert.IsFalse(string.IsNullOrWhiteSpace(operation.Id), "Operation ID should not be empty");

                // Verify the rehydration token matches the operation
                Assert.AreEqual(operation.Id, tokenValue.Id,
                    "Rehydration token ID should match the operation ID");

                // Verify the token was serialized and deserialized correctly
                Assert.AreEqual(tokenValue.Id, restoredToken.Id,
                    "Restored token ID should match the original token ID");

                // Verify the rehydrated operation completed successfully
                Assert.IsTrue(rehydratedOp.HasCompleted,
                    "Rehydrated operation should be completed after WaitForCompletionResponseAsync");
                Assert.IsNotNull(rehydratedOp.GetRawResponse(),
                    "Rehydrated operation should have a raw response");
                Assert.IsTrue(rehydratedOp.GetRawResponse().Status >= 200 && rehydratedOp.GetRawResponse().Status < 300,
                    $"Rehydrated operation response should be successful, but was {rehydratedOp.GetRawResponse().Status}");

                // Verify the result was parsed correctly from the rehydrated response
                Assert.IsNotNull(result, "Analysis result should not be null");
                Assert.IsNotNull(result.Contents, "Result should contain contents");
                Assert.IsTrue(result.Contents!.Count > 0, "Result should have at least one content");
                Assert.IsNotNull(result.Contents[0].Markdown, "Content should have markdown");
                Assert.IsTrue(result.Contents[0].Markdown!.Length > 0, "Markdown should not be empty");

                // Verify the rehydration token is also available after completion
                RehydrationToken? tokenAfterCompletion = operation.GetRehydrationToken();
                Assert.IsNotNull(tokenAfterCompletion,
                    "Rehydration token should still be available after operation completes");
                Assert.AreEqual(operation.Id, tokenAfterCompletion!.Value.Id,
                    "Rehydration token ID should still match after completion");
                #endregion
            }
            finally
            {
                if (File.Exists(tokenFilePath))
                {
                    File.Delete(tokenFilePath);
                }
            }
        }
    }
}
