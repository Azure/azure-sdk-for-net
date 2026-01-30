// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable
using System;
using System.Collections.Generic;
using System.ClientModel.Primitives;
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
    [CodeGenSuppress("AnalyzeAsync", typeof(WaitUntil), typeof(string), typeof(string), typeof(IEnumerable<AnalyzeInput>), typeof(IDictionary<string, string>), typeof(ProcessingLocation?), typeof(CancellationToken))]
    [CodeGenSuppress("Analyze", typeof(WaitUntil), typeof(string), typeof(string), typeof(IEnumerable<AnalyzeInput>), typeof(IDictionary<string, string>), typeof(ProcessingLocation?), typeof(CancellationToken))]
    [CodeGenSuppress("AnalyzeBinaryAsync", typeof(WaitUntil), typeof(string), typeof(string), typeof(BinaryData), typeof(string), typeof(string), typeof(ProcessingLocation?), typeof(CancellationToken))]
    [CodeGenSuppress("AnalyzeBinary", typeof(WaitUntil), typeof(string), typeof(string), typeof(BinaryData), typeof(string), typeof(string), typeof(ProcessingLocation?), typeof(CancellationToken))]
    // Suppress protocol methods - we'll implement custom versions that wrap with OperationWithId
    [CodeGenSuppress("AnalyzeAsync", typeof(WaitUntil), typeof(string), typeof(RequestContent), typeof(string), typeof(string), typeof(Guid?), typeof(RequestContext))]
    [CodeGenSuppress("Analyze", typeof(WaitUntil), typeof(string), typeof(RequestContent), typeof(string), typeof(string), typeof(Guid?), typeof(RequestContext))]
    [CodeGenSuppress("AnalyzeBinaryAsync", typeof(WaitUntil), typeof(string), typeof(string), typeof(RequestContent), typeof(string), typeof(string), typeof(string), typeof(Guid?), typeof(RequestContext))]
    [CodeGenSuppress("AnalyzeBinary", typeof(WaitUntil), typeof(string), typeof(string), typeof(RequestContent), typeof(string), typeof(string), typeof(string), typeof(Guid?), typeof(RequestContext))]
    public partial class ContentUnderstandingClient
    {
        // CUSTOM CODE NOTE: we're suppressing the generation of the Analyze and AnalyzeBinary
        // convenience methods and adding methods manually below for the following reasons:
        //
        //   - Hiding the stringEncoding parameter. We're making its value default to 'utf16' (appropriate for .NET).
        //   - For AnalyzeBinary methods: Automatically determining contentType from BinaryData.MediaType if not
        //     explicitly provided, defaulting to "application/octet-stream" if neither is available.
        //   - We're also overriding the protocol methods to wrap the result in OperationWithId
        //     so that the operation ID is accessible via the Id property.
        private const string DefaultStringEncoding = "utf16";
        private const string DefaultContentType = "application/octet-stream";

        #region Convenience Methods

        /// <summary> Extract content and fields from input. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="analyzerId"> The unique identifier of the analyzer. </param>
        /// <param name="inputs"> Inputs to analyze. </param>
        /// <param name="modelDeployments">
        /// Override default mapping of model names to deployments.
        /// Ex. { "gpt-4.1": "myGpt41Deployment", "text-embedding-3-large": "myTextEmbedding3LargeDeployment" }.
        /// </param>
        /// <param name="processingLocation"> The location where the data may be processed.  Defaults to global. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="analyzerId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="analyzerId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <returns> The <see cref="Operation{AnalyzeResult}"/> representing the long-running operation. </returns>
        public virtual async Task<Operation<AnalyzeResult>> AnalyzeAsync(WaitUntil waitUntil, string analyzerId, IEnumerable<AnalyzeInput>? inputs = default, IDictionary<string, string>? modelDeployments = default, ProcessingLocation? processingLocation = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(analyzerId, nameof(analyzerId));

            AnalyzeRequest1 spreadModel = new AnalyzeRequest1(inputs?.ToList() as IList<AnalyzeInput> ?? new ChangeTrackingList<AnalyzeInput>(), modelDeployments ?? new ChangeTrackingDictionary<string, string>(), new ChangeTrackingDictionary<string, BinaryData>());
            // SDK-EXT: Use DefaultStringEncoding to hide the stringEncoding parameter from the public API (defaults to 'utf16' for .NET)
            Operation<BinaryData> result = await AnalyzeAsync(waitUntil, analyzerId, RequestContent.Create(spreadModel), DefaultStringEncoding, processingLocation?.ToString()!, null, cancellationToken.ToRequestContext()).ConfigureAwait(false);
            return ProtocolOperationHelpers.Convert(result, response => AnalyzeResult.FromLroResponse(response), ClientDiagnostics, "ContentUnderstandingClient.AnalyzeAsync");
        }

        /// <summary> Extract content and fields from input. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="analyzerId"> The unique identifier of the analyzer. </param>
        /// <param name="inputs"> Inputs to analyze. </param>
        /// <param name="modelDeployments">
        /// Override default mapping of model names to deployments.
        /// Ex. { "gpt-4.1": "myGpt41Deployment", "text-embedding-3-large": "myTextEmbedding3LargeDeployment" }.
        /// </param>
        /// <param name="processingLocation"> The location where the data may be processed.  Defaults to global. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="analyzerId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="analyzerId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <returns> The <see cref="Operation{AnalyzeResult}"/> representing the long-running operation. </returns>
        public virtual Operation<AnalyzeResult> Analyze(WaitUntil waitUntil, string analyzerId, IEnumerable<AnalyzeInput>? inputs = default, IDictionary<string, string>? modelDeployments = default, ProcessingLocation? processingLocation = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(analyzerId, nameof(analyzerId));

            AnalyzeRequest1 spreadModel = new AnalyzeRequest1(inputs?.ToList() as IList<AnalyzeInput> ?? new ChangeTrackingList<AnalyzeInput>(), modelDeployments ?? new ChangeTrackingDictionary<string, string>(), new ChangeTrackingDictionary<string, BinaryData>());
            // SDK-EXT: Use DefaultStringEncoding to hide the stringEncoding parameter from the public API (defaults to 'utf16' for .NET)
            Operation<BinaryData> result = Analyze(waitUntil, analyzerId, RequestContent.Create(spreadModel), DefaultStringEncoding, processingLocation?.ToString()!, null, cancellationToken.ToRequestContext());
            return ProtocolOperationHelpers.Convert(result, response => AnalyzeResult.FromLroResponse(response), ClientDiagnostics, "ContentUnderstandingClient.Analyze");
        }

        /// <summary> Extract content and fields from binary input. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="analyzerId"> The unique identifier of the analyzer. </param>
        /// <param name="binaryInput"> The binary content of the document to analyze. </param>
        /// <param name="inputRange"> Range of the input to analyze (ex. `1-3,5,9-`).  Document content uses 1-based page numbers, while audio visual content uses integer milliseconds. </param>
        /// <param name="contentType"> Request content type. If not specified, uses <paramref name="binaryInput"/>'s <see cref="BinaryData.MediaType"/> if available, otherwise defaults to "application/octet-stream". </param>
        /// <param name="processingLocation"> The location where the data may be processed.  Defaults to global. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="analyzerId"/> or <paramref name="binaryInput"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="analyzerId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <returns> The <see cref="Operation{AnalyzeResult}"/> representing the long-running operation. </returns>
        public virtual async Task<Operation<AnalyzeResult>> AnalyzeBinaryAsync(WaitUntil waitUntil, string analyzerId, BinaryData binaryInput, string? inputRange = default, string? contentType = default, ProcessingLocation? processingLocation = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(analyzerId, nameof(analyzerId));
            Argument.AssertNotNull(binaryInput, nameof(binaryInput));

            // SDK-EXT: Determine contentType with priority: explicit parameter > BinaryData.MediaType (if set by user) > "application/octet-stream" default.
            // BinaryData.MediaType does not auto-detect and must be optionally set by users.
            string effectiveContentType = contentType ?? binaryInput.MediaType ?? DefaultContentType;

            // SDK-EXT: Use DefaultStringEncoding to hide the stringEncoding parameter from the public API (defaults to 'utf16' for .NET)
            Operation<BinaryData> result = await AnalyzeBinaryAsync(waitUntil, analyzerId, effectiveContentType, RequestContent.Create(binaryInput), DefaultStringEncoding, processingLocation?.ToString()!, inputRange!, null, cancellationToken.ToRequestContext()).ConfigureAwait(false);
            return ProtocolOperationHelpers.Convert(result, response => AnalyzeResult.FromLroResponse(response), ClientDiagnostics, "ContentUnderstandingClient.AnalyzeBinaryAsync");
        }

        /// <summary> Extract content and fields from binary input. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="analyzerId"> The unique identifier of the analyzer. </param>
        /// <param name="binaryInput"> The binary content of the document to analyze. </param>
        /// <param name="inputRange"> Range of the input to analyze (ex. `1-3,5,9-`).  Document content uses 1-based page numbers, while audio visual content uses integer milliseconds. </param>
        /// <param name="contentType"> Request content type. If not specified, uses <paramref name="binaryInput"/>'s <see cref="BinaryData.MediaType"/> if available, otherwise defaults to "application/octet-stream". </param>
        /// <param name="processingLocation"> The location where the data may be processed.  Defaults to global. </param>
        /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="analyzerId"/> or <paramref name="binaryInput"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="analyzerId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <returns> The <see cref="Operation{AnalyzeResult}"/> representing the long-running operation. </returns>
        public virtual Operation<AnalyzeResult> AnalyzeBinary(WaitUntil waitUntil, string analyzerId, BinaryData binaryInput, string? inputRange = default, string? contentType = default, ProcessingLocation? processingLocation = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(analyzerId, nameof(analyzerId));
            Argument.AssertNotNull(binaryInput, nameof(binaryInput));

            // SDK-EXT: Determine contentType with priority: explicit parameter > BinaryData.MediaType (if set by user) > "application/octet-stream" default.
            // BinaryData.MediaType does not auto-detect and must be optionally set by users.
            string effectiveContentType = contentType ?? binaryInput.MediaType ?? DefaultContentType;

            // SDK-EXT: Use DefaultStringEncoding to hide the stringEncoding parameter from the public API (defaults to 'utf16' for .NET)
            Operation<BinaryData> result = AnalyzeBinary(waitUntil, analyzerId, effectiveContentType, RequestContent.Create(binaryInput), DefaultStringEncoding, processingLocation?.ToString()!, inputRange!, null, cancellationToken.ToRequestContext());
            return ProtocolOperationHelpers.Convert(result, response => AnalyzeResult.FromLroResponse(response), ClientDiagnostics, "ContentUnderstandingClient.AnalyzeBinary");
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
        ///   Possible values are 'codePoint', 'utf16', and `utf8`.  Default is `codePoint`.")
        /// </param>
        /// <param name="processingLocation"> The location where the data may be processed.  Defaults to global. </param>
        /// <param name="clientRequestId"> An opaque, globally-unique, client-generated string identifier for the request. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="analyzerId"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="analyzerId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <returns> The <see cref="Operation{BinaryData}"/> representing an asynchronous operation on the service. </returns>
        public virtual async Task<Operation<BinaryData>> AnalyzeAsync(WaitUntil waitUntil, string analyzerId, RequestContent content, string stringEncoding = default!, string processingLocation = default!, Guid? clientRequestId = default, RequestContext context = null!)
        {
            Argument.AssertNotNullOrEmpty(analyzerId, nameof(analyzerId));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("ContentUnderstandingClient.Analyze");
            scope.Start();
            try
            {
                using HttpMessage message = CreateAnalyzeRequest(analyzerId, content, stringEncoding, processingLocation, clientRequestId, context);

                // Always use WaitUntil.Started to ensure we get the initial response with Operation-Location header.
                var internalOperation = await ProtocolOperationHelpers.ProcessMessageAsync(Pipeline, message, ClientDiagnostics, "ContentUnderstandingClient.Analyze", OperationFinalStateVia.OperationLocation, context, WaitUntil.Started).ConfigureAwait(false);

                // Wrap in OperationWithId to extract the operation ID from the Operation-Location header.
                // This ID is needed for GetResultFile() and DeleteResult() APIs.
                var operationWithId = new OperationWithId(internalOperation);

                // Now honor the caller's original waitUntil preference.
                if (waitUntil == WaitUntil.Completed)
                {
                    await operationWithId.WaitForCompletionAsync(context?.CancellationToken ?? default).ConfigureAwait(false);
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
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="stringEncoding">
        ///   The string encoding format for content spans in the response.
        ///   Possible values are 'codePoint', 'utf16', and `utf8`.  Default is `codePoint`.")
        /// </param>
        /// <param name="processingLocation"> The location where the data may be processed.  Defaults to global. </param>
        /// <param name="clientRequestId"> An opaque, globally-unique, client-generated string identifier for the request. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="analyzerId"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="analyzerId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <returns> The <see cref="Operation{BinaryData}"/> representing an asynchronous operation on the service. </returns>
        public virtual Operation<BinaryData> Analyze(WaitUntil waitUntil, string analyzerId, RequestContent content, string stringEncoding = default!, string processingLocation = default!, Guid? clientRequestId = default, RequestContext context = null!)
        {
            Argument.AssertNotNullOrEmpty(analyzerId, nameof(analyzerId));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("ContentUnderstandingClient.Analyze");
            scope.Start();
            try
            {
                using HttpMessage message = CreateAnalyzeRequest(analyzerId, content, stringEncoding, processingLocation, clientRequestId, context);

                // Always use WaitUntil.Started to ensure we get the initial response with Operation-Location header.
                var internalOperation = ProtocolOperationHelpers.ProcessMessage(Pipeline, message, ClientDiagnostics, "ContentUnderstandingClient.Analyze", OperationFinalStateVia.OperationLocation, context, WaitUntil.Started);

                // Wrap in OperationWithId to extract the operation ID from the Operation-Location header.
                // This ID is needed for GetResultFile() and DeleteResult() APIs.
                var operationWithId = new OperationWithId(internalOperation);

                // Now honor the caller's original waitUntil preference.
                if (waitUntil == WaitUntil.Completed)
                {
                    operationWithId.WaitForCompletion(context?.CancellationToken ?? default);
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
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="contentType"> Request content type. Defaults to "application/octet-stream" if not specified. </param>
        /// <param name="stringEncoding">
        ///   The string encoding format for content spans in the response.
        ///   Possible values are 'codePoint', 'utf16', and `utf8`.  Default is `codePoint`.")
        /// </param>
        /// <param name="processingLocation"> The location where the data may be processed.  Defaults to global. </param>
        /// <param name="inputRange"> Range of the input to analyze (ex. `1-3,5,9-`).  Document content uses 1-based page numbers, while audio visual content uses integer milliseconds. </param>
        /// <param name="clientRequestId"> An opaque, globally-unique, client-generated string identifier for the request. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="analyzerId"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="analyzerId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <returns> The <see cref="Operation{BinaryData}"/> representing an asynchronous operation on the service. </returns>
        public virtual async Task<Operation<BinaryData>> AnalyzeBinaryAsync(WaitUntil waitUntil, string analyzerId, string contentType, RequestContent content, string stringEncoding = default!, string processingLocation = default!, string inputRange = default!, Guid? clientRequestId = default, RequestContext context = null!)
        {
            Argument.AssertNotNullOrEmpty(analyzerId, nameof(analyzerId));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("ContentUnderstandingClient.AnalyzeBinary");
            scope.Start();
            try
            {
                using HttpMessage message = CreateAnalyzeBinaryRequest(analyzerId, contentType ?? DefaultContentType, content, stringEncoding, processingLocation, inputRange, clientRequestId, context);

                // Always use WaitUntil.Started to ensure we get the initial response with Operation-Location header.
                var internalOperation = await ProtocolOperationHelpers.ProcessMessageAsync(Pipeline, message, ClientDiagnostics, "ContentUnderstandingClient.AnalyzeBinary", OperationFinalStateVia.OperationLocation, context, WaitUntil.Started).ConfigureAwait(false);

                // Wrap in OperationWithId to extract the operation ID from the Operation-Location header.
                // This ID is needed for GetResultFile() and DeleteResult() APIs.
                var operationWithId = new OperationWithId(internalOperation);

                // Now honor the caller's original waitUntil preference.
                if (waitUntil == WaitUntil.Completed)
                {
                    await operationWithId.WaitForCompletionAsync(context?.CancellationToken ?? default).ConfigureAwait(false);
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
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="contentType"> Request content type. Defaults to "application/octet-stream" if not specified. </param>
        /// <param name="stringEncoding">
        ///   The string encoding format for content spans in the response.
        ///   Possible values are 'codePoint', 'utf16', and `utf8`.  Default is `codePoint`.")
        /// </param>
        /// <param name="processingLocation"> The location where the data may be processed.  Defaults to global. </param>
        /// <param name="inputRange"> Range of the input to analyze (ex. `1-3,5,9-`).  Document content uses 1-based page numbers, while audio visual content uses integer milliseconds. </param>
        /// <param name="clientRequestId"> An opaque, globally-unique, client-generated string identifier for the request. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="analyzerId"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="analyzerId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <returns> The <see cref="Operation{BinaryData}"/> representing an asynchronous operation on the service. </returns>
        public virtual Operation<BinaryData> AnalyzeBinary(WaitUntil waitUntil, string analyzerId, string contentType, RequestContent content, string stringEncoding = default!, string processingLocation = default!, string inputRange = default!, Guid? clientRequestId = default, RequestContext context = null!)
        {
            Argument.AssertNotNullOrEmpty(analyzerId, nameof(analyzerId));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("ContentUnderstandingClient.AnalyzeBinary");
            scope.Start();
            try
            {
                using HttpMessage message = CreateAnalyzeBinaryRequest(analyzerId, contentType ?? DefaultContentType, content, stringEncoding, processingLocation, inputRange, clientRequestId, context);

                // Always use WaitUntil.Started to ensure we get the initial response with Operation-Location header.
                var internalOperation = ProtocolOperationHelpers.ProcessMessage(Pipeline, message, ClientDiagnostics, "ContentUnderstandingClient.AnalyzeBinary", OperationFinalStateVia.OperationLocation, context, WaitUntil.Started);

                // Wrap in OperationWithId to extract the operation ID from the Operation-Location header.
                // This ID is needed for GetResultFile() and DeleteResult() APIs.
                var operationWithId = new OperationWithId(internalOperation);

                // Now honor the caller's original waitUntil preference.
                if (waitUntil == WaitUntil.Completed)
                {
                    operationWithId.WaitForCompletion(context?.CancellationToken ?? default);
                }

                return operationWithId;
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
        /// <param name="modelDeployments"> Mapping of model names to deployment names. For example: { "gpt-4.1": "myGpt41Deployment", "text-embedding-3-large": "myTextEmbedding3LargeDeployment" }. </param>
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
        /// <param name="modelDeployments"> Mapping of model names to deployment names. For example: { "gpt-4.1": "myGpt41Deployment", "text-embedding-3-large": "myTextEmbedding3LargeDeployment" }. </param>
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
