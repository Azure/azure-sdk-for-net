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

namespace Azure.AI.ContentUnderstanding
{
    /// <summary>
    /// Partial class for ContentUnderstandingClient to customize generated methods.
    /// </summary>
    // Suppress convenience methods with stringEncoding parameter - we'll implement custom versions without it
    [CodeGenSuppress("AnalyzeAsync", typeof(WaitUntil), typeof(string), typeof(IEnumerable<AnalyzeInput>), typeof(IDictionary<string, string>), typeof(string), typeof(ProcessingLocation?), typeof(CancellationToken))]
    [CodeGenSuppress("Analyze", typeof(WaitUntil), typeof(string), typeof(IEnumerable<AnalyzeInput>), typeof(IDictionary<string, string>), typeof(string), typeof(ProcessingLocation?), typeof(CancellationToken))]
    [CodeGenSuppress("AnalyzeBinaryAsync", typeof(WaitUntil), typeof(string), typeof(string), typeof(BinaryData), typeof(string), typeof(ProcessingLocation?), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("AnalyzeBinary", typeof(WaitUntil), typeof(string), typeof(string), typeof(BinaryData), typeof(string), typeof(ProcessingLocation?), typeof(string), typeof(CancellationToken))]
    // SDK-FIX: Suppress CreateCopyAnalyzerRequest to fix copy endpoint path (emitter generates ":copyAnalyzer" instead of ":copy") and status code handling (service returns both 201 and 202)
    [CodeGenSuppress("CreateCopyAnalyzerRequest", typeof(string), typeof(RequestContent), typeof(bool?), typeof(RequestContext))]
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

        // SDK-FIX: Response classifier to accept both 201 and 202 status codes (service inconsistently returns both)
        private static ResponseClassifier? _pipelineMessageClassifier201202;
        private static ResponseClassifier PipelineMessageClassifier201202 =>
            _pipelineMessageClassifier201202 ??= new StatusCodeClassifier(stackalloc ushort[] { 201, 202 });

        /// <summary>
        /// Creates the HTTP message for the copy analyzer request.
        /// </summary>
        /// <remarks>
        /// SDK-FIX: Customized to fix copy endpoint path (emitter generates ":copyAnalyzer" instead of ":copy") 
        /// and status code handling (service returns both 201 and 202 instead of just 202).
        /// </remarks>
        internal HttpMessage CreateCopyAnalyzerRequest(string analyzerId, RequestContent content, bool? allowReplace, RequestContext context)
        {
            RawRequestUriBuilder uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/contentunderstanding", false);
            uri.AppendPath("/analyzers/", false);
            uri.AppendPath(analyzerId, true);
            uri.AppendPath(":copy", false);  // SDK-FIX Issue #1: Changed from ":copyAnalyzer" to ":copy"
            uri.AppendQuery("api-version", _apiVersion, true);
            if (allowReplace != null)
            {
                uri.AppendQuery("allowReplace", TypeFormatters.ConvertToString(allowReplace), true);
            }
            HttpMessage message = Pipeline.CreateMessage(context, PipelineMessageClassifier201202);  // SDK-FIX Issue #2: Changed from PipelineMessageClassifier202 to accept both 201 and 202
            Request request = message.Request;
            request.Uri = uri;
            request.Method = RequestMethod.Post;
            request.Headers.SetValue("Content-Type", "application/json");
            request.Headers.SetValue("Accept", "application/json");
            request.Content = content;
            return message;
        }

        // TODO: Uncomment these methods when ready to regenerate the SDK.
        // These methods are currently commented out because the generated code has been manually
        // edited to make UpdateDefaults methods internal. Once the SDK is regenerated with the
        // proper configuration to generate them as internal, uncomment these to ensure they
        // remain internal even after regeneration.
        //
        // According to autorest.csharp customization pattern (https://github.com/Azure/autorest.csharp#replace-any-generated-member),
        // defining a partial class with the same method signature but different accessibility
        // replaces the generated public method with this internal version.

        /*
        // TODO: Uncomment these methods when ready to regenerate the SDK.
        // These methods are currently commented out because the generated code has been manually
        // edited to make UpdateDefaults methods internal. Once the SDK is regenerated with the
        // proper configuration to generate them as internal, uncomment these to ensure they
        // remain internal even after regeneration.
        //
        // According to autorest.csharp customization pattern (https://github.com/Azure/autorest.csharp#replace-any-generated-member),
        // defining a partial class with the same method signature but different accessibility
        // replaces the generated public method with this internal version.

        /*
        /// <summary>
        /// [Protocol Method] Update default model deployment settings.
        /// <list type="bullet">
        /// <item>
        /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <remarks>
        /// This method is internal. Use the convenience extension methods <see cref="ContentUnderstandingClientExtensions.UpdateDefaults(ContentUnderstandingClient, System.Collections.Generic.IDictionary{string, string}, System.Threading.CancellationToken)"/> or
        /// <see cref="ContentUnderstandingClientExtensions.UpdateDefaultsAsync(ContentUnderstandingClient, System.Collections.Generic.IDictionary{string, string}, System.Threading.CancellationToken)"/> instead.
        /// </remarks>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        internal virtual Response UpdateDefaults(RequestContent content, RequestContext? context = null)
        {
            // The generated implementation will be inserted here by autorest.csharp
            // This method signature replaces the public version from the generated code
            throw new NotImplementedException();
        }

        /// <summary>
        /// [Protocol Method] Update default model deployment settings asynchronously.
        /// <list type="bullet">
        /// <item>
        /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <remarks>
        /// This method is internal. Use the convenience extension methods <see cref="ContentUnderstandingClientExtensions.UpdateDefaults(ContentUnderstandingClient, System.Collections.Generic.IDictionary{string, string}, System.Threading.CancellationToken)"/> or
        /// <see cref="ContentUnderstandingClientExtensions.UpdateDefaultsAsync(ContentUnderstandingClient, System.Collections.Generic.IDictionary{string, string}, System.Threading.CancellationToken)"/> instead.
        /// </remarks>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        internal virtual async Task<Response> UpdateDefaultsAsync(RequestContent content, RequestContext? context = null)
        {
            // The generated implementation will be inserted here by autorest.csharp
            // This method signature replaces the public version from the generated code
            throw new NotImplementedException();
        }
        */
    }
}
