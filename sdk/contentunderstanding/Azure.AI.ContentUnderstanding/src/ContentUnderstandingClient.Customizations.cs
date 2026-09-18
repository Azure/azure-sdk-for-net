// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable
using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.AI.ContentUnderstanding
{
    /// <summary>
    /// Partial class for ContentUnderstandingClient to customize generated methods.
    /// </summary>
    // Suppress convenience methods with stringEncoding parameter - we'll implement custom versions without it
    [CodeGenSuppress("AnalyzeAsync", typeof(WaitUntil), typeof(string), typeof(string), typeof(IEnumerable<AnalysisInput>), typeof(IDictionary<string, string>), typeof(ProcessingLocation?), typeof(bool?), typeof(CancellationToken))]
    [CodeGenSuppress("Analyze", typeof(WaitUntil), typeof(string), typeof(string), typeof(IEnumerable<AnalysisInput>), typeof(IDictionary<string, string>), typeof(ProcessingLocation?), typeof(bool?), typeof(CancellationToken))]
    [CodeGenSuppress("AnalyzeBinaryAsync", typeof(WaitUntil), typeof(string), typeof(string), typeof(string), typeof(BinaryData), typeof(string), typeof(ProcessingLocation?), typeof(bool?), typeof(CancellationToken))]
    [CodeGenSuppress("AnalyzeBinary", typeof(WaitUntil), typeof(string), typeof(string), typeof(string), typeof(BinaryData), typeof(string), typeof(ProcessingLocation?), typeof(bool?), typeof(CancellationToken))]
    [CodeGenSuppress("AnalyzeInline", typeof(string), typeof(string), typeof(IEnumerable<AnalysisInput>), typeof(IDictionary<string, string>), typeof(ProcessingLocation?), typeof(bool?), typeof(CancellationToken))]
    [CodeGenSuppress("AnalyzeInlineAsync", typeof(string), typeof(string), typeof(IEnumerable<AnalysisInput>), typeof(IDictionary<string, string>), typeof(ProcessingLocation?), typeof(bool?), typeof(CancellationToken))]
    [CodeGenSuppress("AnalyzeBinaryInline", typeof(string), typeof(string), typeof(BinaryData), typeof(string), typeof(string), typeof(ProcessingLocation?), typeof(bool?), typeof(CancellationToken))]
    [CodeGenSuppress("AnalyzeBinaryInlineAsync", typeof(string), typeof(string), typeof(BinaryData), typeof(string), typeof(string), typeof(ProcessingLocation?), typeof(bool?), typeof(CancellationToken))]
    // Suppress protocol methods - we'll implement custom versions that wrap with OperationWithId
    [CodeGenSuppress("AnalyzeAsync", typeof(WaitUntil), typeof(string), typeof(RequestContent), typeof(string), typeof(string), typeof(bool?), typeof(Guid?), typeof(RequestContext))]
    [CodeGenSuppress("Analyze", typeof(WaitUntil), typeof(string), typeof(RequestContent), typeof(string), typeof(string), typeof(bool?), typeof(Guid?), typeof(RequestContext))]
    [CodeGenSuppress("AnalyzeBinaryAsync", typeof(WaitUntil), typeof(string), typeof(string), typeof(RequestContent), typeof(string), typeof(string), typeof(bool?), typeof(string), typeof(Guid?), typeof(RequestContext))]
    [CodeGenSuppress("AnalyzeBinary", typeof(WaitUntil), typeof(string), typeof(string), typeof(RequestContent), typeof(string), typeof(string), typeof(bool?), typeof(string), typeof(Guid?), typeof(RequestContext))]
    [CodeGenSuppress("AnalyzeBinaryInline", typeof(string), typeof(RequestContent), typeof(string), typeof(string), typeof(string), typeof(bool?), typeof(string), typeof(Guid?), typeof(RequestContext))]
    [CodeGenSuppress("AnalyzeBinaryInlineAsync", typeof(string), typeof(RequestContent), typeof(string), typeof(string), typeof(string), typeof(bool?), typeof(string), typeof(Guid?), typeof(RequestContext))]
    public partial class ContentUnderstandingClient
    {
        // CUSTOM CODE NOTE: we're suppressing the generation of the Analyze, AnalyzeBinary,
        // AnalyzeInline, and AnalyzeBinaryInline convenience methods and adding methods manually
        // below for the following reasons:
        //
        //   - Hiding the stringEncoding parameter. We're making its value default to 'utf16' (appropriate for .NET).
        //   - For AnalyzeBinary methods: Automatically determining contentType from BinaryData.MediaType if not
        //     explicitly provided, defaulting to "application/octet-stream" if neither is available.
        //   - AnalyzeBinary / AnalyzeBinaryInline convenience methods accept ContentRange? instead of string
        //     for a self-documenting range API (e.g., ContentRange.Pages(1, 3) instead of "1-3").
        //   - AnalyzeOptions / AnalyzeBinaryOptions include the analyzer ID and required input so their
        //     overloads have a distinct, extensible shape (including AllowInputTruncation) while preserving
        //     existing scalar convenience overloads.
        //   - Inline convenience methods throw RequestFailedException when the inline status is not Succeeded,
        //     matching completed LRO analyze behavior.
        //   - We're also overriding the Analyze/AnalyzeBinary protocol methods to wrap the result in
        //     OperationWithId so that the operation ID is accessible via the Id property.
        private const string DefaultStringEncoding = "utf16";
        private const string DefaultContentType = "application/octet-stream";
        private static readonly TimeSpan DefaultLroPollingInterval = TimeSpan.FromSeconds(3);

        #region Convenience Methods

        /// <summary> Extract content and fields from input. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="analyzerId"> The unique identifier of the analyzer. </param>
        /// <param name="inputs"> Inputs to analyze. </param>
        /// <param name="modelDeployments">
        /// Override default mapping of model names to deployments.
        /// Ex. { "gpt-5.2": "myGpt52Deployment", "text-embedding-3-large": "myTextEmbedding3LargeDeployment" }.
        /// </param>
        /// <param name="processingLocation"> The location where the data may be processed.  Defaults to global. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="analyzerId"/> or <paramref name="inputs"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="analyzerId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <returns> The <see cref="Operation{AnalysisResult}"/> with operation ID accessible via the <c>Id</c> property. </returns>
        public virtual async Task<Operation<AnalysisResult>> AnalyzeAsync(WaitUntil waitUntil, string analyzerId, IEnumerable<AnalysisInput> inputs, IDictionary<string, string>? modelDeployments = default, ProcessingLocation? processingLocation = default, CancellationToken cancellationToken = default)
        {
            var options = new AnalyzeOptions(analyzerId, inputs)
            {
                ProcessingLocation = processingLocation
            };
            if (modelDeployments != null)
            {
                foreach (KeyValuePair<string, string> pair in modelDeployments)
                {
                    options.ModelDeployments[pair.Key] = pair.Value;
                }
            }
            return await AnalyzeAsync(waitUntil, options, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Extract content and fields from input. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="analyzerId"> The unique identifier of the analyzer. </param>
        /// <param name="inputs"> Inputs to analyze. </param>
        /// <param name="modelDeployments">
        /// Override default mapping of model names to deployments.
        /// Ex. { "gpt-5.2": "myGpt52Deployment", "text-embedding-3-large": "myTextEmbedding3LargeDeployment" }.
        /// </param>
        /// <param name="processingLocation"> The location where the data may be processed.  Defaults to global. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="analyzerId"/> or <paramref name="inputs"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="analyzerId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <returns> The <see cref="Operation{AnalysisResult}"/> with operation ID accessible via the <c>Id</c> property. </returns>
        public virtual Operation<AnalysisResult> Analyze(WaitUntil waitUntil, string analyzerId, IEnumerable<AnalysisInput> inputs, IDictionary<string, string>? modelDeployments = default, ProcessingLocation? processingLocation = default, CancellationToken cancellationToken = default)
        {
            var options = new AnalyzeOptions(analyzerId, inputs)
            {
                ProcessingLocation = processingLocation
            };
            if (modelDeployments != null)
            {
                foreach (KeyValuePair<string, string> pair in modelDeployments)
                {
                    options.ModelDeployments[pair.Key] = pair.Value;
                }
            }
            return Analyze(waitUntil, options, cancellationToken);
        }

        /// <summary> Extract content and fields from input. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="options"> Options for the analysis request. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        /// <returns> The <see cref="Operation{AnalysisResult}"/> with operation ID accessible via the <c>Id</c> property. </returns>
        public virtual async Task<Operation<AnalysisResult>> AnalyzeAsync(WaitUntil waitUntil, AnalyzeOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            AnalyzeRequest1 spreadModel = new AnalyzeRequest1(
                options.Inputs.ToList(),
                options.ModelDeployments,
                new ChangeTrackingDictionary<string, BinaryData>());
            Operation<BinaryData> result = await AnalyzeOperationAsync(
                waitUntil,
                options.AnalyzerId,
                spreadModel,
                DefaultStringEncoding,
                options.ProcessingLocation?.ToString()!,
                clientRequestId: default,
                allowInputTruncation: options.AllowInputTruncation,
                cancellationToken.ToRequestContext()).ConfigureAwait(false);
            return ProtocolOperationHelpers.Convert(result, response => AnalysisResult.FromLroResponse(response), ClientDiagnostics, "ContentUnderstandingClient.AnalyzeAsync");
        }

        /// <summary> Extract content and fields from input. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="options"> Options for the analysis request. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        /// <returns> The <see cref="Operation{AnalysisResult}"/> with operation ID accessible via the <c>Id</c> property. </returns>
        public virtual Operation<AnalysisResult> Analyze(WaitUntil waitUntil, AnalyzeOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            AnalyzeRequest1 spreadModel = new AnalyzeRequest1(
                options.Inputs.ToList(),
                options.ModelDeployments,
                new ChangeTrackingDictionary<string, BinaryData>());
            Operation<BinaryData> result = AnalyzeOperation(
                waitUntil,
                options.AnalyzerId,
                spreadModel,
                DefaultStringEncoding,
                options.ProcessingLocation?.ToString()!,
                clientRequestId: default,
                allowInputTruncation: options.AllowInputTruncation,
                cancellationToken.ToRequestContext());
            return ProtocolOperationHelpers.Convert(result, response => AnalysisResult.FromLroResponse(response), ClientDiagnostics, "ContentUnderstandingClient.Analyze");
        }

        /// <summary> Extract content and fields from binary input. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="analyzerId"> The unique identifier of the analyzer. </param>
        /// <param name="binaryInput"> The binary content of the document to analyze. </param>
        /// <param name="contentRange"> Range of the input to analyze. Use factory methods such as <see cref="ContentRange.Pages(int, int)"/>, <see cref="ContentRange.TimeRange(TimeSpan, TimeSpan)"/>, or <see cref="ContentRange.Combine(ContentRange[])"/> to build the range. </param>
        /// <param name="contentType"> Request content type. If not specified, uses <paramref name="binaryInput"/>'s <see cref="BinaryData.MediaType"/> if available, otherwise defaults to "application/octet-stream". </param>
        /// <param name="processingLocation"> The location where the data may be processed. Defaults to global. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="analyzerId"/> or <paramref name="binaryInput"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="analyzerId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <returns> The <see cref="Operation{AnalysisResult}"/> with operation ID accessible via the <c>Id</c> property. </returns>
        public virtual async Task<Operation<AnalysisResult>> AnalyzeBinaryAsync(WaitUntil waitUntil, string analyzerId, BinaryData binaryInput, ContentRange? contentRange = default, string? contentType = default, ProcessingLocation? processingLocation = default, CancellationToken cancellationToken = default)
        {
            var options = new AnalyzeBinaryOptions(analyzerId, binaryInput)
            {
                ContentRange = contentRange,
                ContentType = contentType,
                ProcessingLocation = processingLocation
            };
            return await AnalyzeBinaryAsync(waitUntil, options, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Extract content and fields from binary input. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="analyzerId"> The unique identifier of the analyzer. </param>
        /// <param name="binaryInput"> The binary content of the document to analyze. </param>
        /// <param name="contentRange"> Range of the input to analyze. Use factory methods such as <see cref="ContentRange.Pages(int, int)"/>, <see cref="ContentRange.TimeRange(TimeSpan, TimeSpan)"/>, or <see cref="ContentRange.Combine(ContentRange[])"/> to build the range. </param>
        /// <param name="contentType"> Request content type. If not specified, uses <paramref name="binaryInput"/>'s <see cref="BinaryData.MediaType"/> if available, otherwise defaults to "application/octet-stream". </param>
        /// <param name="processingLocation"> The location where the data may be processed. Defaults to global. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="analyzerId"/> or <paramref name="binaryInput"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="analyzerId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <returns> The <see cref="Operation{AnalysisResult}"/> with operation ID accessible via the <c>Id</c> property. </returns>
        public virtual Operation<AnalysisResult> AnalyzeBinary(WaitUntil waitUntil, string analyzerId, BinaryData binaryInput, ContentRange? contentRange = default, string? contentType = default, ProcessingLocation? processingLocation = default, CancellationToken cancellationToken = default)
        {
            var options = new AnalyzeBinaryOptions(analyzerId, binaryInput)
            {
                ContentRange = contentRange,
                ContentType = contentType,
                ProcessingLocation = processingLocation
            };
            return AnalyzeBinary(waitUntil, options, cancellationToken);
        }

        /// <summary> Extract content and fields from binary input. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="options"> Additional options for the binary analysis request. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        /// <returns> The <see cref="Operation{AnalysisResult}"/> with operation ID accessible via the <c>Id</c> property. </returns>
        public virtual async Task<Operation<AnalysisResult>> AnalyzeBinaryAsync(WaitUntil waitUntil, AnalyzeBinaryOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            string effectiveContentType = options.ContentType ?? options.BinaryInput.MediaType ?? DefaultContentType;
            string? contentRange = options.ContentRange?.ToString();
            string? processingLocation = options.ProcessingLocation?.ToString();

            Operation<BinaryData> result = await AnalyzeBinaryOperationAsync(waitUntil, options.AnalyzerId, effectiveContentType, RequestContent.Create(options.BinaryInput), DefaultStringEncoding, processingLocation!, contentRange!, clientRequestId: default, allowInputTruncation: options.AllowInputTruncation, cancellationToken.ToRequestContext()).ConfigureAwait(false);
            return ProtocolOperationHelpers.Convert(result, response => AnalysisResult.FromLroResponse(response), ClientDiagnostics, "ContentUnderstandingClient.AnalyzeBinaryAsync");
        }

        /// <summary> Extract content and fields from binary input. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="options"> Additional options for the binary analysis request. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        /// <returns> The <see cref="Operation{AnalysisResult}"/> with operation ID accessible via the <c>Id</c> property. </returns>
        public virtual Operation<AnalysisResult> AnalyzeBinary(WaitUntil waitUntil, AnalyzeBinaryOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            string effectiveContentType = options.ContentType ?? options.BinaryInput.MediaType ?? DefaultContentType;
            string? contentRange = options.ContentRange?.ToString();
            string? processingLocation = options.ProcessingLocation?.ToString();

            Operation<BinaryData> result = AnalyzeBinaryOperation(waitUntil, options.AnalyzerId, effectiveContentType, RequestContent.Create(options.BinaryInput), DefaultStringEncoding, processingLocation!, contentRange!, clientRequestId: default, allowInputTruncation: options.AllowInputTruncation, cancellationToken.ToRequestContext());
            return ProtocolOperationHelpers.Convert(result, response => AnalysisResult.FromLroResponse(response), ClientDiagnostics, "ContentUnderstandingClient.AnalyzeBinary");
        }

        /// <summary> Extract content and fields from input. The analysis result is embedded inline in the JSON response body (HTTP 200) without creating a long-running operation. </summary>
        /// <param name="analyzerId"> The unique identifier of the analyzer. </param>
        /// <param name="inputs"> Inputs to analyze. </param>
        /// <param name="modelDeployments">
        /// Override default mapping of model names to deployments.
        /// Ex. { "gpt-5.2": "myGpt52Deployment", "text-embedding-3-large": "myTextEmbedding3LargeDeployment" }.
        /// </param>
        /// <param name="processingLocation"> The location where the data may be processed. Defaults to global. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="analyzerId"/> or <paramref name="inputs"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="analyzerId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code, or the inline operation status was not Succeeded. </exception>
        /// <remarks> Available only when the client is configured for service API version <c>2026-06-01-preview</c>. </remarks>
        public virtual async Task<Response<AnalysisResult>> AnalyzeInlineAsync(string analyzerId, IEnumerable<AnalysisInput> inputs, IDictionary<string, string>? modelDeployments = default, ProcessingLocation? processingLocation = default, CancellationToken cancellationToken = default)
        {
            var options = new AnalyzeOptions(analyzerId, inputs)
            {
                ProcessingLocation = processingLocation
            };
            if (modelDeployments != null)
            {
                foreach (KeyValuePair<string, string> pair in modelDeployments)
                {
                    options.ModelDeployments[pair.Key] = pair.Value;
                }
            }
            return await AnalyzeInlineAsync(options, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Extract content and fields from input. The analysis result is embedded inline in the JSON response body (HTTP 200) without creating a long-running operation. </summary>
        /// <param name="analyzerId"> The unique identifier of the analyzer. </param>
        /// <param name="inputs"> Inputs to analyze. </param>
        /// <param name="modelDeployments">
        /// Override default mapping of model names to deployments.
        /// Ex. { "gpt-5.2": "myGpt52Deployment", "text-embedding-3-large": "myTextEmbedding3LargeDeployment" }.
        /// </param>
        /// <param name="processingLocation"> The location where the data may be processed. Defaults to global. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="analyzerId"/> or <paramref name="inputs"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="analyzerId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code, or the inline operation status was not Succeeded. </exception>
        /// <remarks> Available only when the client is configured for service API version <c>2026-06-01-preview</c>. </remarks>
        public virtual Response<AnalysisResult> AnalyzeInline(string analyzerId, IEnumerable<AnalysisInput> inputs, IDictionary<string, string>? modelDeployments = default, ProcessingLocation? processingLocation = default, CancellationToken cancellationToken = default)
        {
            var options = new AnalyzeOptions(analyzerId, inputs)
            {
                ProcessingLocation = processingLocation
            };
            if (modelDeployments != null)
            {
                foreach (KeyValuePair<string, string> pair in modelDeployments)
                {
                    options.ModelDeployments[pair.Key] = pair.Value;
                }
            }
            return AnalyzeInline(options, cancellationToken);
        }

        /// <summary> Extract content and fields from input. The analysis result is embedded inline in the JSON response body (HTTP 200) without creating a long-running operation. </summary>
        /// <param name="options"> Options for the analysis request. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code, or the inline operation status was not Succeeded. </exception>
        /// <remarks> Available only when the client is configured for service API version <c>2026-06-01-preview</c>. </remarks>
        public virtual async Task<Response<AnalysisResult>> AnalyzeInlineAsync(AnalyzeOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            AnalyzeInlineRequest spreadModel = new AnalyzeInlineRequest(
                options.Inputs.ToList(),
                options.ModelDeployments,
                new ChangeTrackingDictionary<string, BinaryData>());
            Response result = await AnalyzeInlineAsync(
                options.AnalyzerId,
                spreadModel,
                DefaultStringEncoding,
                options.ProcessingLocation?.ToString()!,
                allowInputTruncation: options.AllowInputTruncation,
                clientRequestId: default,
                cancellationToken.ToRequestContext()).ConfigureAwait(false);
            return Response.FromValue(GetSucceededInlineResult((ContentAnalyzerInlineResponse)result, result), result);
        }

        /// <summary> Extract content and fields from input. The analysis result is embedded inline in the JSON response body (HTTP 200) without creating a long-running operation. </summary>
        /// <param name="options"> Options for the analysis request. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code, or the inline operation status was not Succeeded. </exception>
        /// <remarks> Available only when the client is configured for service API version <c>2026-06-01-preview</c>. </remarks>
        public virtual Response<AnalysisResult> AnalyzeInline(AnalyzeOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            AnalyzeInlineRequest spreadModel = new AnalyzeInlineRequest(
                options.Inputs.ToList(),
                options.ModelDeployments,
                new ChangeTrackingDictionary<string, BinaryData>());
            Response result = AnalyzeInline(
                options.AnalyzerId,
                spreadModel,
                DefaultStringEncoding,
                options.ProcessingLocation?.ToString()!,
                allowInputTruncation: options.AllowInputTruncation,
                clientRequestId: default,
                cancellationToken.ToRequestContext());
            return Response.FromValue(GetSucceededInlineResult((ContentAnalyzerInlineResponse)result, result), result);
        }

        /// <summary> Extract content and fields from binary input. The analysis result is embedded inline in the JSON response body (HTTP 200) without creating a long-running operation. </summary>
        /// <param name="analyzerId"> The unique identifier of the analyzer. </param>
        /// <param name="binaryInput"> The binary content of the document to analyze. </param>
        /// <param name="contentRange"> Range of the input to analyze. Use factory methods such as <see cref="ContentRange.Pages(int, int)"/>, <see cref="ContentRange.TimeRange(TimeSpan, TimeSpan)"/>, or <see cref="ContentRange.Combine(ContentRange[])"/> to build the range. </param>
        /// <param name="contentType"> Request content type. If not specified, uses <paramref name="binaryInput"/>'s <see cref="BinaryData.MediaType"/> if available, otherwise defaults to "application/octet-stream". </param>
        /// <param name="processingLocation"> The location where the data may be processed. Defaults to global. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="analyzerId"/> or <paramref name="binaryInput"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="analyzerId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code, or the inline operation status was not Succeeded. </exception>
        /// <remarks> Available only when the client is configured for service API version <c>2026-06-01-preview</c>. </remarks>
        public virtual async Task<Response<AnalysisResult>> AnalyzeBinaryInlineAsync(string analyzerId, BinaryData binaryInput, ContentRange? contentRange = default, string? contentType = default, ProcessingLocation? processingLocation = default, CancellationToken cancellationToken = default)
        {
            var options = new AnalyzeBinaryOptions(analyzerId, binaryInput)
            {
                ContentRange = contentRange,
                ContentType = contentType,
                ProcessingLocation = processingLocation
            };
            return await AnalyzeBinaryInlineAsync(options, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Extract content and fields from binary input. The analysis result is embedded inline in the JSON response body (HTTP 200) without creating a long-running operation. </summary>
        /// <param name="analyzerId"> The unique identifier of the analyzer. </param>
        /// <param name="binaryInput"> The binary content of the document to analyze. </param>
        /// <param name="contentRange"> Range of the input to analyze. Use factory methods such as <see cref="ContentRange.Pages(int, int)"/>, <see cref="ContentRange.TimeRange(TimeSpan, TimeSpan)"/>, or <see cref="ContentRange.Combine(ContentRange[])"/> to build the range. </param>
        /// <param name="contentType"> Request content type. If not specified, uses <paramref name="binaryInput"/>'s <see cref="BinaryData.MediaType"/> if available, otherwise defaults to "application/octet-stream". </param>
        /// <param name="processingLocation"> The location where the data may be processed. Defaults to global. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="analyzerId"/> or <paramref name="binaryInput"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="analyzerId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code, or the inline operation status was not Succeeded. </exception>
        /// <remarks> Available only when the client is configured for service API version <c>2026-06-01-preview</c>. </remarks>
        public virtual Response<AnalysisResult> AnalyzeBinaryInline(string analyzerId, BinaryData binaryInput, ContentRange? contentRange = default, string? contentType = default, ProcessingLocation? processingLocation = default, CancellationToken cancellationToken = default)
        {
            var options = new AnalyzeBinaryOptions(analyzerId, binaryInput)
            {
                ContentRange = contentRange,
                ContentType = contentType,
                ProcessingLocation = processingLocation
            };
            return AnalyzeBinaryInline(options, cancellationToken);
        }

        /// <summary> Extract content and fields from binary input using an options bag. The analysis result is embedded inline in the JSON response body (HTTP 200) without creating a long-running operation. </summary>
        /// <param name="options"> Additional options for the binary analysis request. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code, or the inline operation status was not Succeeded. </exception>
        /// <remarks> Available only when the client is configured for service API version <c>2026-06-01-preview</c>. </remarks>
        public virtual async Task<Response<AnalysisResult>> AnalyzeBinaryInlineAsync(AnalyzeBinaryOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            string effectiveContentType = options.ContentType ?? options.BinaryInput.MediaType ?? DefaultContentType;
            string? contentRange = options.ContentRange?.ToString();
            string? processingLocation = options.ProcessingLocation?.ToString();

            Response result = await AnalyzeBinaryInlineOperationAsync(options.AnalyzerId, RequestContent.Create(options.BinaryInput), effectiveContentType, DefaultStringEncoding, processingLocation!, contentRange!, clientRequestId: default, allowInputTruncation: options.AllowInputTruncation, context: cancellationToken.ToRequestContext()).ConfigureAwait(false);
            return Response.FromValue(GetSucceededInlineResult((ContentAnalyzerInlineResponse)result, result), result);
        }

        /// <summary> Extract content and fields from binary input using an options bag. The analysis result is embedded inline in the JSON response body (HTTP 200) without creating a long-running operation. </summary>
        /// <param name="options"> Additional options for the binary analysis request. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code, or the inline operation status was not Succeeded. </exception>
        /// <remarks> Available only when the client is configured for service API version <c>2026-06-01-preview</c>. </remarks>
        public virtual Response<AnalysisResult> AnalyzeBinaryInline(AnalyzeBinaryOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            string effectiveContentType = options.ContentType ?? options.BinaryInput.MediaType ?? DefaultContentType;
            string? contentRange = options.ContentRange?.ToString();
            string? processingLocation = options.ProcessingLocation?.ToString();

            Response result = AnalyzeBinaryInlineOperation(options.AnalyzerId, RequestContent.Create(options.BinaryInput), effectiveContentType, DefaultStringEncoding, processingLocation!, contentRange!, clientRequestId: default, allowInputTruncation: options.AllowInputTruncation, context: cancellationToken.ToRequestContext());
            return Response.FromValue(GetSucceededInlineResult((ContentAnalyzerInlineResponse)result, result), result);
        }

        /// <summary>
        /// Throws <see cref="RequestFailedException"/> when the inline analyze envelope is not Succeeded,
        /// matching completed LRO analyze behavior for failed operation status payloads.
        /// </summary>
        private static AnalysisResult GetSucceededInlineResult(ContentAnalyzerInlineResponse inlineResponse, Response rawResponse)
        {
            if (inlineResponse.Status == OperationState.Succeeded)
            {
                return inlineResponse.Result;
            }

            throw new RequestFailedException(rawResponse);
        }

        #endregion

        #region Protocol Methods with OperationWithId

        // SDK-EXT: we're overriding the behavior of the Analyze and AnalyzeBinary
        // protocol methods to return an instance of OperationWithId.
        /// <summary> Extract content and fields from input. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="analyzerId"> The unique identifier of the analyzer. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="stringEncoding">
        ///   The string encoding format for content spans in the response.
        ///   Possible values are 'codePoint', 'utf16', and `utf8`.  Default is `codePoint`.
        /// </param>
        /// <param name="processingLocation"> The location where the data may be processed.  Defaults to global. </param>
        /// <param name="allowInputTruncation"> Overrides the analyzer's allowInputTruncation setting for this request. When omitted, the analyzer's configured value applies. </param>
        /// <param name="clientRequestId"> An optional, client-generated GUID that uniquely identifies the request. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="analyzerId"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="analyzerId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <returns> The <see cref="Operation{BinaryData}"/> representing an asynchronous operation on the service. </returns>
        public virtual async Task<Operation<BinaryData>> AnalyzeAsync(WaitUntil waitUntil, string analyzerId, RequestContent content, string stringEncoding = default!, string processingLocation = default!, bool? allowInputTruncation = default, Guid? clientRequestId = default, RequestContext context = null!)
            => await AnalyzeOperationAsync(waitUntil, analyzerId, content, stringEncoding, processingLocation, clientRequestId, allowInputTruncation, context).ConfigureAwait(false);

        /// <summary> Extract content and fields from input. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="analyzerId"> The unique identifier of the analyzer. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="stringEncoding">
        ///   The string encoding format for content spans in the response.
        ///   Possible values are 'codePoint', 'utf16', and `utf8`.  Default is `codePoint`.
        /// </param>
        /// <param name="processingLocation"> The location where the data may be processed.  Defaults to global. </param>
        /// <param name="allowInputTruncation"> Overrides the analyzer's allowInputTruncation setting for this request. When omitted, the analyzer's configured value applies. </param>
        /// <param name="clientRequestId"> An optional, client-generated GUID that uniquely identifies the request. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="analyzerId"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="analyzerId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <returns> The <see cref="Operation{BinaryData}"/> representing an asynchronous operation on the service. </returns>
        public virtual Operation<BinaryData> Analyze(WaitUntil waitUntil, string analyzerId, RequestContent content, string stringEncoding = default!, string processingLocation = default!, bool? allowInputTruncation = default, Guid? clientRequestId = default, RequestContext context = null!)
            => AnalyzeOperation(waitUntil, analyzerId, content, stringEncoding, processingLocation, clientRequestId, allowInputTruncation, context);

        /// <summary> Compatibility overload retained for ApiCompat with the previous protocol signature. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Operation<BinaryData>> AnalyzeAsync(WaitUntil waitUntil, string analyzerId, RequestContent content, string stringEncoding, string processingLocation, Guid? clientRequestId, RequestContext context)
            => AnalyzeAsync(waitUntil, analyzerId, content, stringEncoding, processingLocation, allowInputTruncation: default, clientRequestId, context);

        /// <summary> Compatibility overload retained for ApiCompat with the previous protocol signature. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Operation<BinaryData> Analyze(WaitUntil waitUntil, string analyzerId, RequestContent content, string stringEncoding, string processingLocation, Guid? clientRequestId, RequestContext context)
            => Analyze(waitUntil, analyzerId, content, stringEncoding, processingLocation, allowInputTruncation: default, clientRequestId, context);

        private async Task<Operation<BinaryData>> AnalyzeOperationAsync(WaitUntil waitUntil, string analyzerId, RequestContent content, string stringEncoding = default!, string processingLocation = default!, Guid? clientRequestId = default, bool? allowInputTruncation = default, RequestContext context = null!)
        {
            Argument.AssertNotNullOrEmpty(analyzerId, nameof(analyzerId));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("ContentUnderstandingClient.Analyze");
            scope.Start();
            try
            {
                using HttpMessage message = CreateAnalyzeRequest(analyzerId, content, stringEncoding, processingLocation, allowInputTruncation, clientRequestId, context);

                // Always use WaitUntil.Started to ensure we get the initial response with Operation-Location header.
                var internalOperation = await ProtocolOperationHelpers.ProcessMessageAsync(Pipeline, message, ClientDiagnostics, "ContentUnderstandingClient.Analyze", OperationFinalStateVia.OperationLocation, context, WaitUntil.Started).ConfigureAwait(false);

                // Wrap in OperationWithId to extract the operation ID from the Operation-Location header.
                // This ID is needed for GetResultFile() and DeleteResult() APIs.
                var operationWithId = new OperationWithId(internalOperation);

                // Now honor the caller's original waitUntil preference.
                if (waitUntil == WaitUntil.Completed)
                {
                    // SDK-CUSTOMIZATION: Use a longer polling interval than the generated default (1 second)
                    // when waiting for completion in these protocol wrappers.
                    await operationWithId.WaitForCompletionAsync(DefaultLroPollingInterval, context?.CancellationToken ?? default).ConfigureAwait(false);
                }

                return operationWithId;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private Operation<BinaryData> AnalyzeOperation(WaitUntil waitUntil, string analyzerId, RequestContent content, string stringEncoding = default!, string processingLocation = default!, Guid? clientRequestId = default, bool? allowInputTruncation = default, RequestContext context = null!)
        {
            Argument.AssertNotNullOrEmpty(analyzerId, nameof(analyzerId));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("ContentUnderstandingClient.Analyze");
            scope.Start();
            try
            {
                using HttpMessage message = CreateAnalyzeRequest(analyzerId, content, stringEncoding, processingLocation, allowInputTruncation, clientRequestId, context);

                // Always use WaitUntil.Started to ensure we get the initial response with Operation-Location header.
                var internalOperation = ProtocolOperationHelpers.ProcessMessage(Pipeline, message, ClientDiagnostics, "ContentUnderstandingClient.Analyze", OperationFinalStateVia.OperationLocation, context, WaitUntil.Started);

                // Wrap in OperationWithId to extract the operation ID from the Operation-Location header.
                // This ID is needed for GetResultFile() and DeleteResult() APIs.
                var operationWithId = new OperationWithId(internalOperation);

                // Now honor the caller's original waitUntil preference.
                if (waitUntil == WaitUntil.Completed)
                {
                    // SDK-CUSTOMIZATION: Use a longer polling interval than the generated default (1 second)
                    // when waiting for completion in these protocol wrappers.
                    operationWithId.WaitForCompletion(DefaultLroPollingInterval, context?.CancellationToken ?? default);
                }

                return operationWithId;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Extract content and fields from binary input. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="analyzerId"> The unique identifier of the analyzer. </param>
        /// <param name="contentType"> Request content type. Defaults to application/octet-stream if not specified. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="stringEncoding"> The string encoding format for content spans in the response. </param>
        /// <param name="processingLocation"> The location where the data may be processed. Defaults to global. </param>
        /// <param name="allowInputTruncation"> Overrides the analyzer's allowInputTruncation setting for this request. When omitted, the analyzer's configured value applies. </param>
        /// <param name="contentRange"> Range of the input to analyze. </param>
        /// <param name="clientRequestId"> An optional, client-generated GUID that uniquely identifies the request. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <returns> The <see cref="Operation{BinaryData}"/> representing an asynchronous operation on the service. </returns>
        public virtual Task<Operation<BinaryData>> AnalyzeBinaryAsync(WaitUntil waitUntil, string analyzerId, string contentType, RequestContent content, string stringEncoding = default!, string processingLocation = default!, bool? allowInputTruncation = default, string contentRange = default!, Guid? clientRequestId = default, RequestContext context = null!)
            => AnalyzeBinaryOperationAsync(waitUntil, analyzerId, contentType, content, stringEncoding, processingLocation, contentRange, clientRequestId, allowInputTruncation, context);

        /// <summary> Extract content and fields from binary input. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="analyzerId"> The unique identifier of the analyzer. </param>
        /// <param name="contentType"> Request content type. Defaults to application/octet-stream if not specified. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="stringEncoding"> The string encoding format for content spans in the response. </param>
        /// <param name="processingLocation"> The location where the data may be processed. Defaults to global. </param>
        /// <param name="allowInputTruncation"> Overrides the analyzer's allowInputTruncation setting for this request. When omitted, the analyzer's configured value applies. </param>
        /// <param name="contentRange"> Range of the input to analyze. </param>
        /// <param name="clientRequestId"> An optional, client-generated GUID that uniquely identifies the request. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <returns> The <see cref="Operation{BinaryData}"/> representing an asynchronous operation on the service. </returns>
        public virtual Operation<BinaryData> AnalyzeBinary(WaitUntil waitUntil, string analyzerId, string contentType, RequestContent content, string stringEncoding = default!, string processingLocation = default!, bool? allowInputTruncation = default, string contentRange = default!, Guid? clientRequestId = default, RequestContext context = null!)
            => AnalyzeBinaryOperation(waitUntil, analyzerId, contentType, content, stringEncoding, processingLocation, contentRange, clientRequestId, allowInputTruncation, context);

        /// <summary> Compatibility overload retained for ApiCompat with the previous protocol signature. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Operation<BinaryData>> AnalyzeBinaryAsync(WaitUntil waitUntil, string analyzerId, string contentType, RequestContent content, string stringEncoding, string processingLocation, string contentRange, Guid? clientRequestId, RequestContext context)
            => AnalyzeBinaryAsync(waitUntil, analyzerId, contentType, content, stringEncoding, processingLocation, allowInputTruncation: default, contentRange, clientRequestId, context);

        /// <summary> Compatibility overload retained for ApiCompat with the previous protocol signature. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Operation<BinaryData> AnalyzeBinary(WaitUntil waitUntil, string analyzerId, string contentType, RequestContent content, string stringEncoding, string processingLocation, string contentRange, Guid? clientRequestId, RequestContext context)
            => AnalyzeBinary(waitUntil, analyzerId, contentType, content, stringEncoding, processingLocation, allowInputTruncation: default, contentRange, clientRequestId, context);

        /// <summary> Extract content and fields from input. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="analyzerId"> The unique identifier of the analyzer. </param>
        /// <param name="contentType"> Request content type. Defaults to "application/octet-stream" if not specified. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="stringEncoding">
        ///   The string encoding format for content spans in the response.
        ///   Possible values are 'codePoint', 'utf16', and `utf8`.  Default is `codePoint`.
        /// </param>
        /// <param name="processingLocation"> The location where the data may be processed.  Defaults to global. </param>
        /// <param name="contentRange"> Range of the input to analyze (ex. `1-3,5,9-`).  Document content uses 1-based page numbers, while audio visual content uses integer milliseconds. </param>
        /// <param name="clientRequestId"> An optional, client-generated GUID that uniquely identifies the request. </param>
        /// <param name="allowInputTruncation"> Overrides the analyzer's allowInputTruncation setting for this request. When omitted, the analyzer's configured value applies. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="analyzerId"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="analyzerId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <returns> The <see cref="Operation{BinaryData}"/> representing an asynchronous operation on the service. </returns>
        private async Task<Operation<BinaryData>> AnalyzeBinaryOperationAsync(WaitUntil waitUntil, string analyzerId, string contentType, RequestContent content, string stringEncoding = default!, string processingLocation = default!, string contentRange = default!, Guid? clientRequestId = default, bool? allowInputTruncation = default, RequestContext context = null!)
        {
            Argument.AssertNotNullOrEmpty(analyzerId, nameof(analyzerId));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("ContentUnderstandingClient.AnalyzeBinary");
            scope.Start();
            try
            {
                using HttpMessage message = CreateAnalyzeBinaryRequest(analyzerId, contentType ?? DefaultContentType, content, stringEncoding, processingLocation, allowInputTruncation, contentRange, clientRequestId, context);

                // Always use WaitUntil.Started to ensure we get the initial response with Operation-Location header.
                var internalOperation = await ProtocolOperationHelpers.ProcessMessageAsync(Pipeline, message, ClientDiagnostics, "ContentUnderstandingClient.AnalyzeBinary", OperationFinalStateVia.OperationLocation, context, WaitUntil.Started).ConfigureAwait(false);

                // Wrap in OperationWithId to extract the operation ID from the Operation-Location header.
                // This ID is needed for GetResultFile() and DeleteResult() APIs.
                var operationWithId = new OperationWithId(internalOperation);

                // Now honor the caller's original waitUntil preference.
                if (waitUntil == WaitUntil.Completed)
                {
                    // SDK-CUSTOMIZATION: Use a longer polling interval than the generated default (1 second)
                    // when waiting for completion in these protocol wrappers.
                    await operationWithId.WaitForCompletionAsync(DefaultLroPollingInterval, context?.CancellationToken ?? default).ConfigureAwait(false);
                }

                return operationWithId;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Extract content and fields from input. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="analyzerId"> The unique identifier of the analyzer. </param>
        /// <param name="contentType"> Request content type. Defaults to "application/octet-stream" if not specified. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="stringEncoding">
        ///   The string encoding format for content spans in the response.
        ///   Possible values are 'codePoint', 'utf16', and `utf8`.  Default is `codePoint`.
        /// </param>
        /// <param name="processingLocation"> The location where the data may be processed.  Defaults to global. </param>
        /// <param name="contentRange"> Range of the input to analyze (ex. `1-3,5,9-`).  Document content uses 1-based page numbers, while audio visual content uses integer milliseconds. </param>
        /// <param name="clientRequestId"> An optional, client-generated GUID that uniquely identifies the request. </param>
        /// <param name="allowInputTruncation"> Overrides the analyzer's allowInputTruncation setting for this request. When omitted, the analyzer's configured value applies. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="analyzerId"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="analyzerId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <returns> The <see cref="Operation{BinaryData}"/> representing an asynchronous operation on the service. </returns>
        private Operation<BinaryData> AnalyzeBinaryOperation(WaitUntil waitUntil, string analyzerId, string contentType, RequestContent content, string stringEncoding = default!, string processingLocation = default!, string contentRange = default!, Guid? clientRequestId = default, bool? allowInputTruncation = default, RequestContext context = null!)
        {
            Argument.AssertNotNullOrEmpty(analyzerId, nameof(analyzerId));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("ContentUnderstandingClient.AnalyzeBinary");
            scope.Start();
            try
            {
                using HttpMessage message = CreateAnalyzeBinaryRequest(analyzerId, contentType ?? DefaultContentType, content, stringEncoding, processingLocation, allowInputTruncation, contentRange, clientRequestId, context);

                // Always use WaitUntil.Started to ensure we get the initial response with Operation-Location header.
                var internalOperation = ProtocolOperationHelpers.ProcessMessage(Pipeline, message, ClientDiagnostics, "ContentUnderstandingClient.AnalyzeBinary", OperationFinalStateVia.OperationLocation, context, WaitUntil.Started);

                // Wrap in OperationWithId to extract the operation ID from the Operation-Location header.
                // This ID is needed for GetResultFile() and DeleteResult() APIs.
                var operationWithId = new OperationWithId(internalOperation);

                // Now honor the caller's original waitUntil preference.
                if (waitUntil == WaitUntil.Completed)
                {
                    // SDK-CUSTOMIZATION: Use a longer polling interval than the generated default (1 second)
                    // when waiting for completion in these protocol wrappers.
                    operationWithId.WaitForCompletion(DefaultLroPollingInterval, context?.CancellationToken ?? default);
                }

                return operationWithId;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Extract content and fields from binary input. The analysis result is embedded inline in the JSON response body (HTTP 200) without creating a long-running operation.
        /// <list type="bullet">
        /// <item>
        /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="analyzerId"> The unique identifier of the analyzer. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="contentType"> Request content type. </param>
        /// <param name="stringEncoding">
        ///   The string encoding format for content spans in the response.
        ///   Possible values are 'codePoint', 'utf16', and `utf8`.  Default is `codePoint`.
        /// </param>
        /// <param name="processingLocation"> The location where the data may be processed. Defaults to global. </param>
        /// <param name="allowInputTruncation"> Overrides the analyzer's allowInputTruncation setting for this request. When omitted, the analyzer's configured value applies. </param>
        /// <param name="contentRange"> Range of the input to analyze (ex. `1-3,5,9-`). Document content uses 1-based page numbers, while audio visual content uses integer milliseconds. </param>
        /// <param name="clientRequestId"> An opaque, globally-unique, client-generated string identifier for the request. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="analyzerId"/>, <paramref name="content"/> or <paramref name="contentType"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="analyzerId"/> or <paramref name="contentType"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <remarks> Available only when the client is configured for service API version <c>2026-06-01-preview</c>. </remarks>
        public virtual Response AnalyzeBinaryInline(string analyzerId, RequestContent content, string contentType, string stringEncoding = default!, string processingLocation = default!, bool? allowInputTruncation = default, string contentRange = default!, Guid? clientRequestId = default, RequestContext context = null!)
            => AnalyzeBinaryInlineOperation(analyzerId, content, contentType, stringEncoding, processingLocation, contentRange, clientRequestId, allowInputTruncation, context);

        /// <summary>
        /// [Protocol Method] Extract content and fields from binary input. The analysis result is embedded inline in the JSON response body (HTTP 200) without creating a long-running operation.
        /// <list type="bullet">
        /// <item>
        /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="analyzerId"> The unique identifier of the analyzer. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="contentType"> Request content type. </param>
        /// <param name="stringEncoding">
        ///   The string encoding format for content spans in the response.
        ///   Possible values are 'codePoint', 'utf16', and `utf8`.  Default is `codePoint`.
        /// </param>
        /// <param name="processingLocation"> The location where the data may be processed. Defaults to global. </param>
        /// <param name="allowInputTruncation"> Overrides the analyzer's allowInputTruncation setting for this request. When omitted, the analyzer's configured value applies. </param>
        /// <param name="contentRange"> Range of the input to analyze (ex. `1-3,5,9-`). Document content uses 1-based page numbers, while audio visual content uses integer milliseconds. </param>
        /// <param name="clientRequestId"> An opaque, globally-unique, client-generated string identifier for the request. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="analyzerId"/>, <paramref name="content"/> or <paramref name="contentType"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="analyzerId"/> or <paramref name="contentType"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <remarks> Available only when the client is configured for service API version <c>2026-06-01-preview</c>. </remarks>
        public virtual Task<Response> AnalyzeBinaryInlineAsync(string analyzerId, RequestContent content, string contentType, string stringEncoding = default!, string processingLocation = default!, bool? allowInputTruncation = default, string contentRange = default!, Guid? clientRequestId = default, RequestContext context = null!)
            => AnalyzeBinaryInlineOperationAsync(analyzerId, content, contentType, stringEncoding, processingLocation, contentRange, clientRequestId, allowInputTruncation, context);

        /// <summary> Compatibility overload retained for ApiCompat with the previous protocol signature. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response AnalyzeBinaryInline(string analyzerId, RequestContent content, string contentType, string stringEncoding, string processingLocation, string contentRange, Guid? clientRequestId, RequestContext context)
            => AnalyzeBinaryInline(analyzerId, content, contentType, stringEncoding, processingLocation, allowInputTruncation: default, contentRange, clientRequestId, context);

        /// <summary> Compatibility overload retained for ApiCompat with the previous protocol signature. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response> AnalyzeBinaryInlineAsync(string analyzerId, RequestContent content, string contentType, string stringEncoding, string processingLocation, string contentRange, Guid? clientRequestId, RequestContext context)
            => AnalyzeBinaryInlineAsync(analyzerId, content, contentType, stringEncoding, processingLocation, allowInputTruncation: default, contentRange, clientRequestId, context);

        private Response AnalyzeBinaryInlineOperation(string analyzerId, RequestContent content, string contentType, string stringEncoding, string processingLocation, string contentRange, Guid? clientRequestId, bool? allowInputTruncation, RequestContext context)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope("ContentUnderstandingClient.AnalyzeBinaryInline");
            scope.Start();
            try
            {
                Argument.AssertNotNullOrEmpty(analyzerId, nameof(analyzerId));
                Argument.AssertNotNull(content, nameof(content));
                Argument.AssertNotNullOrEmpty(contentType, nameof(contentType));

                using HttpMessage message = CreateAnalyzeBinaryInlineRequest(analyzerId, content, contentType, stringEncoding, processingLocation, allowInputTruncation, contentRange, clientRequestId, context);
                return Pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private async Task<Response> AnalyzeBinaryInlineOperationAsync(string analyzerId, RequestContent content, string contentType, string stringEncoding, string processingLocation, string contentRange, Guid? clientRequestId, bool? allowInputTruncation, RequestContext context)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope("ContentUnderstandingClient.AnalyzeBinaryInline");
            scope.Start();
            try
            {
                Argument.AssertNotNullOrEmpty(analyzerId, nameof(analyzerId));
                Argument.AssertNotNull(content, nameof(content));
                Argument.AssertNotNullOrEmpty(contentType, nameof(contentType));

                using HttpMessage message = CreateAnalyzeBinaryInlineRequest(analyzerId, content, contentType, stringEncoding, processingLocation, allowInputTruncation, contentRange, clientRequestId, context);
                return await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        #endregion
        #region Update Operations

        // EMITTER-FIX: These methods are manually implemented because the TypeSpec emitter does not generate
        // convenience methods for PATCH operations using Operations.ResourceUpdate and Foundations.Operation
        // with MergePatchUpdate input.

        /// <summary> Update analyzer properties. </summary>
        /// <param name="analyzerId"> The unique identifier of the analyzer. </param>
        /// <param name="resource"> The resource instance with properties to update. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="analyzerId"/> or <paramref name="resource"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="analyzerId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Response UpdateAnalyzer(string analyzerId, ContentAnalyzer resource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(analyzerId, nameof(analyzerId));
            Argument.AssertNotNull(resource, nameof(resource));

            return UpdateAnalyzer(analyzerId, RequestContent.Create(resource), cancellationToken.ToRequestContext());
        }

        /// <summary> Update analyzer properties asynchronously. </summary>
        /// <param name="analyzerId"> The unique identifier of the analyzer. </param>
        /// <param name="resource"> The resource instance with properties to update. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="analyzerId"/> or <paramref name="resource"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="analyzerId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<Response> UpdateAnalyzerAsync(string analyzerId, ContentAnalyzer resource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(analyzerId, nameof(analyzerId));
            Argument.AssertNotNull(resource, nameof(resource));

            return await UpdateAnalyzerAsync(analyzerId, RequestContent.Create(resource), cancellationToken.ToRequestContext()).ConfigureAwait(false);
        }

        /// <summary> Update default model deployment settings. </summary>
        /// <remarks>
        /// This is the recommended public API for updating default model deployment settings.
        /// The generated protocol methods (UpdateDefaults/UpdateDefaultsAsync with RequestContent) should not be used directly.
        /// This method provides a simpler API that accepts a dictionary mapping model names to deployment names.
        /// </remarks>
        /// <param name="modelDeployments"> Mapping of model names to deployment names. For example: { "gpt-5.2": "myGpt52Deployment", "text-embedding-3-large": "myTextEmbedding3LargeDeployment" }. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="modelDeployments"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Response<ContentUnderstandingDefaults> UpdateDefaults(IDictionary<string, string> modelDeployments, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(modelDeployments, nameof(modelDeployments));

            var defaults = ContentUnderstandingModelFactory.ContentUnderstandingDefaults(modelDeployments);
            var writerOptions = new ModelReaderWriterOptions("W");
            var requestContent = RequestContent.Create(
                ModelReaderWriter.Write(defaults, writerOptions, AzureAIContentUnderstandingContext.Default));

            Response response = UpdateDefaults(requestContent, cancellationToken.ToRequestContext());
            return Response.FromValue((ContentUnderstandingDefaults)response, response);
        }

        /// <summary> Update default model deployment settings asynchronously. </summary>
        /// <remarks>
        /// This is the recommended public API for updating default model deployment settings.
        /// The generated protocol methods (UpdateDefaults/UpdateDefaultsAsync with RequestContent) should not be used directly.
        /// This method provides a simpler API that accepts a dictionary mapping model names to deployment names.
        /// </remarks>
        /// <param name="modelDeployments"> Mapping of model names to deployment names. For example: { "gpt-5.2": "myGpt52Deployment", "text-embedding-3-large": "myTextEmbedding3LargeDeployment" }. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="modelDeployments"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<Response<ContentUnderstandingDefaults>> UpdateDefaultsAsync(IDictionary<string, string> modelDeployments, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(modelDeployments, nameof(modelDeployments));

            var defaults = ContentUnderstandingModelFactory.ContentUnderstandingDefaults(modelDeployments);
            var writerOptions = new ModelReaderWriterOptions("W");
            var requestContent = RequestContent.Create(
                ModelReaderWriter.Write(defaults, writerOptions, AzureAIContentUnderstandingContext.Default));

            Response response = await UpdateDefaultsAsync(requestContent, cancellationToken.ToRequestContext()).ConfigureAwait(false);
            return Response.FromValue((ContentUnderstandingDefaults)response, response);
        }

        #endregion

    }
}
