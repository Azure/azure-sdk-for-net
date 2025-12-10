// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable
using System;
using System.Collections.Generic;
using System.ClientModel.Primitives;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.AI.ContentUnderstanding
{
    /// <summary>
    /// Partial class for ContentUnderstandingClient to customize generated methods.
    /// </summary>
    // Suppress convenience methods with stringEncoding parameter - we'll implement custom versions without it
    // Note: The suppression must match the exact generated signature including return type differences
    // Generated methods return Operation<AnalyzeResult>, custom methods return AnalyzeResultOperation
    [CodeGenSuppress("AnalyzeAsync", typeof(WaitUntil), typeof(string), typeof(IEnumerable<AnalyzeInput>), typeof(IDictionary<string, string>), typeof(string), typeof(ProcessingLocation?), typeof(CancellationToken))]
    [CodeGenSuppress("Analyze", typeof(WaitUntil), typeof(string), typeof(IEnumerable<AnalyzeInput>), typeof(IDictionary<string, string>), typeof(string), typeof(ProcessingLocation?), typeof(CancellationToken))]
    [CodeGenSuppress("AnalyzeBinaryAsync", typeof(WaitUntil), typeof(string), typeof(string), typeof(BinaryData), typeof(string), typeof(ProcessingLocation?), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("AnalyzeBinary", typeof(WaitUntil), typeof(string), typeof(string), typeof(BinaryData), typeof(string), typeof(ProcessingLocation?), typeof(string), typeof(CancellationToken))]
    public partial class ContentUnderstandingClient
    {
        // CUSTOM CODE NOTE: we're suppressing the generation of the Analyze and AnalyzeBinary
        // convenience methods and adding methods manually below for the following reasons:
        //   - Hiding the stringEncoding parameter. We're making its value default to 'utf16' (appropriate for .NET).
        //   - Exposing operation ID via the Id property on the returned Operation<AnalyzeResult> via AnalyzeResultOperation wrapper.

        private const string DefaultStringEncoding = "utf16";

        /// <summary> Extract content and fields from input. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="analyzerId"> The unique identifier of the analyzer. </param>
        /// <param name="inputs"> Inputs to analyze.  Currently, only pro mode supports multiple inputs. </param>
        /// <param name="modelDeployments">
        /// Override default mapping of model names to deployments.
        /// Ex. { "gpt-4.1": "myGpt41Deployment", "text-embedding-3-large": "myTextEmbedding3LargeDeployment" }.
        /// </param>
        /// <param name="processingLocation"> The location where the data may be processed.  Defaults to global. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="analyzerId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="analyzerId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <returns> The <see cref="AnalyzeResultOperation"/> with operation ID accessible via the <c>Id</c> property. </returns>
        public virtual async Task<AnalyzeResultOperation> AnalyzeAsync(WaitUntil waitUntil, string analyzerId, IEnumerable<AnalyzeInput>? inputs = default, IDictionary<string, string>? modelDeployments = default, ProcessingLocation? processingLocation = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(analyzerId, nameof(analyzerId));

            AnalyzeRequest1 spreadModel = new AnalyzeRequest1(inputs?.ToList() as IList<AnalyzeInput> ?? new ChangeTrackingList<AnalyzeInput>(), modelDeployments ?? new ChangeTrackingDictionary<string, string>(), new ChangeTrackingDictionary<string, BinaryData>());
            Operation<BinaryData> result = await AnalyzeAsync(waitUntil, analyzerId, spreadModel, DefaultStringEncoding, processingLocation?.ToString(), cancellationToken.ToRequestContext()).ConfigureAwait(false);
            // Extract operation ID from the original operation before conversion, as the converted operation might not preserve the Operation-Location header
            string? operationId = ExtractOperationIdFromBinaryDataOperation(result);
            Operation<AnalyzeResult> converted = ProtocolOperationHelpers.Convert(result, response => AnalyzeResult.FromLroResponse(response), ClientDiagnostics, "ContentUnderstandingClient.AnalyzeAsync");
            return new AnalyzeResultOperation(converted, operationId);
        }

        /// <summary> Extract content and fields from input. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="analyzerId"> The unique identifier of the analyzer. </param>
        /// <param name="inputs"> Inputs to analyze.  Currently, only pro mode supports multiple inputs. </param>
        /// <param name="modelDeployments">
        /// Override default mapping of model names to deployments.
        /// Ex. { "gpt-4.1": "myGpt41Deployment", "text-embedding-3-large": "myTextEmbedding3LargeDeployment" }.
        /// </param>
        /// <param name="processingLocation"> The location where the data may be processed.  Defaults to global. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="analyzerId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="analyzerId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <returns> The <see cref="AnalyzeResultOperation"/> with operation ID accessible via the <c>Id</c> property. </returns>
        public virtual AnalyzeResultOperation Analyze(WaitUntil waitUntil, string analyzerId, IEnumerable<AnalyzeInput>? inputs = default, IDictionary<string, string>? modelDeployments = default, ProcessingLocation? processingLocation = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(analyzerId, nameof(analyzerId));

            AnalyzeRequest1 spreadModel = new AnalyzeRequest1(inputs?.ToList() as IList<AnalyzeInput> ?? new ChangeTrackingList<AnalyzeInput>(), modelDeployments ?? new ChangeTrackingDictionary<string, string>(), new ChangeTrackingDictionary<string, BinaryData>());
            Operation<BinaryData> result = Analyze(waitUntil, analyzerId, spreadModel, DefaultStringEncoding, processingLocation?.ToString(), cancellationToken.ToRequestContext());
            // Extract operation ID from the original operation before conversion, as the converted operation might not preserve the Operation-Location header
            string? operationId = ExtractOperationIdFromBinaryDataOperation(result);
            Operation<AnalyzeResult> converted = ProtocolOperationHelpers.Convert(result, response => AnalyzeResult.FromLroResponse(response), ClientDiagnostics, "ContentUnderstandingClient.Analyze");
            return new AnalyzeResultOperation(converted, operationId);
        }

        /// <summary> Extract content and fields from binary input. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="analyzerId"> The unique identifier of the analyzer. </param>
        /// <param name="contentType"> Request content type. </param>
        /// <param name="binaryInput"> The binary content of the document to analyze. </param>
        /// <param name="stringEncoding"> This parameter is ignored. The SDK always uses "utf16" encoding for .NET. </param>
        /// <param name="processingLocation"> The location where the data may be processed.  Defaults to global. </param>
        /// <param name="inputRange"> Range of the input to analyze (ex. `1-3,5,9-`).  Document content uses 1-based page numbers, while audio visual content uses integer milliseconds. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="analyzerId"/>, <paramref name="contentType"/> or <paramref name="binaryInput"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="analyzerId"/> or <paramref name="contentType"/> is an empty string, and was expected to be non-empty. </exception>
        /// <returns> The <see cref="AnalyzeResultOperation"/> with operation ID accessible via the <c>Id</c> property. </returns>
        /// <remarks>
        /// To avoid ambiguity with the protocol method, explicitly specify the return type as <c>AnalyzeResultOperation</c> when calling this method.
        /// </remarks>
        public virtual async Task<AnalyzeResultOperation> AnalyzeBinaryAsync(WaitUntil waitUntil, string analyzerId, string contentType, BinaryData binaryInput, string? stringEncoding = default, ProcessingLocation? processingLocation = default, string? inputRange = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(analyzerId, nameof(analyzerId));
            Argument.AssertNotNullOrEmpty(contentType, nameof(contentType));
            Argument.AssertNotNull(binaryInput, nameof(binaryInput));

            // Ignore stringEncoding parameter - always use utf16 for .NET
            Operation<BinaryData> result = await AnalyzeBinaryAsync(waitUntil, analyzerId, contentType, RequestContent.Create(binaryInput), DefaultStringEncoding, processingLocation?.ToString(), inputRange, cancellationToken.ToRequestContext()).ConfigureAwait(false);
            // Extract operation ID from the original operation before conversion, as the converted operation might not preserve the Operation-Location header
            string? operationId = ExtractOperationIdFromBinaryDataOperation(result);
            Operation<AnalyzeResult> converted = ProtocolOperationHelpers.Convert(result, response => AnalyzeResult.FromLroResponse(response), ClientDiagnostics, "ContentUnderstandingClient.AnalyzeBinaryAsync");
            return new AnalyzeResultOperation(converted, operationId);
        }

        /// <summary> Extract content and fields from binary input. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="analyzerId"> The unique identifier of the analyzer. </param>
        /// <param name="contentType"> Request content type. </param>
        /// <param name="binaryInput"> The binary content of the document to analyze. </param>
        /// <param name="stringEncoding"> This parameter is ignored. The SDK always uses "utf16" encoding for .NET. </param>
        /// <param name="processingLocation"> The location where the data may be processed.  Defaults to global. </param>
        /// <param name="inputRange"> Range of the input to analyze (ex. `1-3,5,9-`).  Document content uses 1-based page numbers, while audio visual content uses integer milliseconds. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="analyzerId"/>, <paramref name="contentType"/> or <paramref name="binaryInput"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="analyzerId"/> or <paramref name="contentType"/> is an empty string, and was expected to be non-empty. </exception>
        /// <returns> The <see cref="AnalyzeResultOperation"/> with operation ID accessible via the <c>Id</c> property. </returns>
        /// <remarks>
        /// To avoid ambiguity with the protocol method, explicitly specify the return type as <c>AnalyzeResultOperation</c> when calling this method.
        /// </remarks>
        public virtual AnalyzeResultOperation AnalyzeBinary(WaitUntil waitUntil, string analyzerId, string contentType, BinaryData binaryInput, string? stringEncoding = default, ProcessingLocation? processingLocation = default, string? inputRange = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(analyzerId, nameof(analyzerId));
            Argument.AssertNotNullOrEmpty(contentType, nameof(contentType));
            Argument.AssertNotNull(binaryInput, nameof(binaryInput));

            // Ignore stringEncoding parameter - always use utf16 for .NET
            Operation<BinaryData> result = AnalyzeBinary(waitUntil, analyzerId, contentType, RequestContent.Create(binaryInput), DefaultStringEncoding, processingLocation?.ToString(), inputRange, cancellationToken.ToRequestContext());
            // Extract operation ID from the original operation before conversion, as the converted operation might not preserve the Operation-Location header
            string? operationId = ExtractOperationIdFromBinaryDataOperation(result);
            Operation<AnalyzeResult> converted = ProtocolOperationHelpers.Convert(result, response => AnalyzeResult.FromLroResponse(response), ClientDiagnostics, "ContentUnderstandingClient.AnalyzeBinary");
            return new AnalyzeResultOperation(converted, operationId);
        }

        /// <summary>
        /// Extracts the operation ID from an Operation&lt;BinaryData&gt; by reading the Operation-Location header.
        /// </summary>
        private static string? ExtractOperationIdFromBinaryDataOperation(Operation<BinaryData> operation)
        {
            var rawResponse = operation.GetRawResponse();
            if (rawResponse != null && rawResponse.Headers.TryGetValue("Operation-Location", out var operationLocation))
            {
                // Extract operation ID from the URL: .../analyzerResults/{operationId}
                // Use the same approach as the old extension method for consistency
                if (Uri.TryCreate(operationLocation, UriKind.Absolute, out var uri))
                {
                    var segments = uri.Segments;
                    if (segments.Length > 0)
                    {
                        return segments[segments.Length - 1].TrimEnd('/');
                    }
                }
            }

            return null;
        }
    }
}
