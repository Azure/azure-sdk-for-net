// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.AI.DocumentIntelligence
{
    [CodeGenSuppress("FetchAnalyzeResultFromAnalyzeOperation", typeof(Response))]
    [CodeGenSuppress("AnalyzeDocumentAsync", typeof(WaitUntil), typeof(string), typeof(AnalyzeDocumentOptions), typeof(string), typeof(string), typeof(StringIndexType?), typeof(IEnumerable<DocumentAnalysisFeature>), typeof(IEnumerable<string>), typeof(DocumentContentFormat?), typeof(IEnumerable<AnalyzeOutputOption>), typeof(CancellationToken))]
    [CodeGenSuppress("AnalyzeDocument", typeof(WaitUntil), typeof(string), typeof(AnalyzeDocumentOptions), typeof(string), typeof(string), typeof(StringIndexType?), typeof(IEnumerable<DocumentAnalysisFeature>), typeof(IEnumerable<string>), typeof(DocumentContentFormat?), typeof(IEnumerable<AnalyzeOutputOption>), typeof(CancellationToken))]
    [CodeGenSuppress("AnalyzeBatchDocumentsAsync", typeof(WaitUntil), typeof(string), typeof(AnalyzeBatchDocumentsOptions), typeof(string), typeof(string), typeof(StringIndexType?), typeof(IEnumerable<DocumentAnalysisFeature>), typeof(IEnumerable<string>), typeof(DocumentContentFormat?), typeof(IEnumerable<AnalyzeOutputOption>), typeof(CancellationToken))]
    [CodeGenSuppress("AnalyzeBatchDocuments", typeof(WaitUntil), typeof(string), typeof(AnalyzeBatchDocumentsOptions), typeof(string), typeof(string), typeof(StringIndexType?), typeof(IEnumerable<DocumentAnalysisFeature>), typeof(IEnumerable<string>), typeof(DocumentContentFormat?), typeof(IEnumerable<AnalyzeOutputOption>), typeof(CancellationToken))]
    [CodeGenSuppress("ClassifyDocumentAsync", typeof(WaitUntil), typeof(string), typeof(ClassifyDocumentOptions), typeof(StringIndexType?), typeof(SplitMode?), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("ClassifyDocument", typeof(WaitUntil), typeof(string), typeof(ClassifyDocumentOptions), typeof(StringIndexType?), typeof(SplitMode?), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetAnalyzeResultPdfAsync", typeof(string), typeof(Guid), typeof(CancellationToken))]
    [CodeGenSuppress("GetAnalyzeResultPdf", typeof(string), typeof(Guid), typeof(CancellationToken))]
    [CodeGenSuppress("GetAnalyzeResultPdfAsync", typeof(string), typeof(Guid), typeof(RequestContext))]
    [CodeGenSuppress("GetAnalyzeResultPdf", typeof(string), typeof(Guid), typeof(RequestContext))]
    [CodeGenSuppress("GetAnalyzeResultFigureAsync", typeof(string), typeof(Guid), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetAnalyzeResultFigure", typeof(string), typeof(Guid), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetAnalyzeResultFigureAsync", typeof(string), typeof(Guid), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("GetAnalyzeResultFigure", typeof(string), typeof(Guid), typeof(string), typeof(RequestContext))]
    [CodeGenSuppress("DeleteAnalyzeResultAsync", typeof(string), typeof(Guid), typeof(RequestContext))]
    [CodeGenSuppress("DeleteAnalyzeResult", typeof(string), typeof(Guid), typeof(RequestContext))]
    [CodeGenSuppress("DeleteAnalyzeResultAsync", typeof(string), typeof(Guid), typeof(CancellationToken))]
    [CodeGenSuppress("DeleteAnalyzeResult", typeof(string), typeof(Guid), typeof(CancellationToken))]
    [CodeGenSuppress("DeleteAnalyzeBatchResultAsync", typeof(string), typeof(Guid), typeof(RequestContext))]
    [CodeGenSuppress("DeleteAnalyzeBatchResult", typeof(string), typeof(Guid), typeof(RequestContext))]
    [CodeGenSuppress("DeleteAnalyzeBatchResultAsync", typeof(string), typeof(Guid), typeof(CancellationToken))]
    [CodeGenSuppress("DeleteAnalyzeBatchResult", typeof(string), typeof(Guid), typeof(CancellationToken))]
    [CodeGenSuppress("GetAnalyzeBatchResultAsync", typeof(string), typeof(Guid), typeof(CancellationToken))]
    [CodeGenSuppress("GetAnalyzeBatchResult", typeof(string), typeof(Guid), typeof(CancellationToken))]
    [CodeGenSuppress("GetAnalyzeBatchResultAsync", typeof(string), typeof(Guid), typeof(RequestContext))]
    [CodeGenSuppress("GetAnalyzeBatchResult", typeof(string), typeof(Guid), typeof(RequestContext))]
    public partial class DocumentIntelligenceClient
    {
        // CUSTOM CODE NOTE: we're suppressing the generation of the AnalyzeDocument,
        // AnalyzeBatchDocuments, and ClassifyDocument methods and adding methods manually
        // below for the following reasons:
        //   - Hiding the StringIndexType parameter. We're making its value default to 'utf16CodeUnit'.
        //   - Hiding other parameters (e.g. 'modelId', 'pages') inside the 'options' property bag.
        //   - Renaming 'request' parameters to 'options'.
        //   - Making the 'options' parameter required in all methods.

        private const string DefaultStringIndexType = "utf16CodeUnit";

        /// <summary> Analyzes document with document model. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="options"> Analyze request options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        public virtual async Task<Operation<AnalyzeResult>> AnalyzeDocumentAsync(WaitUntil waitUntil, AnalyzeDocumentOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            using RequestContent content = options;
            RequestContext context = FromCancellationToken(cancellationToken);
            Operation<BinaryData> response = await AnalyzeDocumentAsync(waitUntil, options.ModelId, content, options.Pages, options.Locale, DefaultStringIndexType, options.Features, options.QueryFields, options.OutputContentFormat?.ToString(), options.Output, context).ConfigureAwait(false);
            return ProtocolOperationHelpers.Convert(response, FetchAnalyzeResultFromAnalyzeOperation, ClientDiagnostics, "DocumentIntelligenceClient.AnalyzeDocument");
        }

        /// <summary> Analyzes document with document model. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="options"> Analyze request options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        public virtual Operation<AnalyzeResult> AnalyzeDocument(WaitUntil waitUntil, AnalyzeDocumentOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            using RequestContent content = options;
            RequestContext context = FromCancellationToken(cancellationToken);
            Operation<BinaryData> response = AnalyzeDocument(waitUntil, options.ModelId, content, options.Pages, options.Locale, DefaultStringIndexType, options.Features, options.QueryFields, options.OutputContentFormat?.ToString(), options.Output, context);
            return ProtocolOperationHelpers.Convert(response, FetchAnalyzeResultFromAnalyzeOperation, ClientDiagnostics, "DocumentIntelligenceClient.AnalyzeDocument");
        }

        /// <summary> Analyzes batch documents with document model. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="options"> Analyze batch request options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        public virtual async Task<Operation<AnalyzeBatchResult>> AnalyzeBatchDocumentsAsync(WaitUntil waitUntil, AnalyzeBatchDocumentsOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            using RequestContent content = options;
            RequestContext context = FromCancellationToken(cancellationToken);
            Operation<BinaryData> result = await AnalyzeBatchDocumentsAsync(waitUntil, options.ModelId, content, options.Pages, options.Locale, DefaultStringIndexType, options.Features, options.QueryFields, options.OutputContentFormat?.ToString(), options.Output, context).ConfigureAwait(false);
            return ProtocolOperationHelpers.Convert(result, response => (AnalyzeBatchResult)response, ClientDiagnostics, "DocumentIntelligenceClient.AnalyzeBatchDocuments");
        }

        /// <summary> Analyzes batch documents with document model. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="options"> Analyze batch request parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        public virtual Operation<AnalyzeBatchResult> AnalyzeBatchDocuments(WaitUntil waitUntil, AnalyzeBatchDocumentsOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            using RequestContent content = options;
            RequestContext context = FromCancellationToken(cancellationToken);
            Operation<BinaryData> response = AnalyzeBatchDocuments(waitUntil, options.ModelId, content, options.Pages, options.Locale, DefaultStringIndexType, options.Features, options.QueryFields, options.OutputContentFormat?.ToString(), options.Output, context);
            return ProtocolOperationHelpers.Convert(response, FetchAnalyzeBatchResultFromAnalyzeBatchOperationDetails, ClientDiagnostics, "DocumentIntelligenceClient.AnalyzeBatchDocuments");
        }

        /// <summary> Classifies document with document classifier. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="options"> Classify request options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        public virtual async Task<Operation<AnalyzeResult>> ClassifyDocumentAsync(WaitUntil waitUntil, ClassifyDocumentOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            using RequestContent content = options;
            RequestContext context = FromCancellationToken(cancellationToken);
            Operation<BinaryData> result = await ClassifyDocumentAsync(waitUntil, options.ClassifierId, content, DefaultStringIndexType, options.Split?.ToString(), options.Pages, context).ConfigureAwait(false);
            return ProtocolOperationHelpers.Convert(result, response => (AnalyzeResult)response, ClientDiagnostics, "DocumentIntelligenceClient.ClassifyDocument");
        }

        /// <summary> Classifies document with document classifier. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="options"> Classify request options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        public virtual Operation<AnalyzeResult> ClassifyDocument(WaitUntil waitUntil, ClassifyDocumentOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));

            using RequestContent content = options;
            RequestContext context = FromCancellationToken(cancellationToken);
            Operation<BinaryData> response = ClassifyDocument(waitUntil, options.ClassifierId, content, DefaultStringIndexType, options.Split?.ToString(), options.Pages, context);
            return ProtocolOperationHelpers.Convert(response, FetchAnalyzeResultFromAnalyzeOperation, ClientDiagnostics, "DocumentIntelligenceClient.ClassifyDocument");
        }

        // CUSTOM CODE NOTE: adding overloads for common scenarios of the AnalyzeDocument method.

        /// <summary> Analyzes document with document model. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="modelId"> Unique document model name. </param>
        /// <param name="uriSource"> Document URL to analyze. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="modelId"/> or <paramref name="uriSource"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="modelId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<Operation<AnalyzeResult>> AnalyzeDocumentAsync(WaitUntil waitUntil, string modelId, Uri uriSource, CancellationToken cancellationToken = default)
        {
            var options = new AnalyzeDocumentOptions(modelId, uriSource);

            return await AnalyzeDocumentAsync(waitUntil, options, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Analyzes document with document model. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="modelId"> Unique document model name. </param>
        /// <param name="uriSource"> Document URL to analyze. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="modelId"/> or <paramref name="uriSource"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="modelId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Operation<AnalyzeResult> AnalyzeDocument(WaitUntil waitUntil, string modelId, Uri uriSource, CancellationToken cancellationToken = default)
        {
            var options = new AnalyzeDocumentOptions(modelId, uriSource);

            return AnalyzeDocument(waitUntil, options, cancellationToken);
        }

        /// <summary> Analyzes document with document model. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="modelId"> Unique document model name. </param>
        /// <param name="bytesSource">
        /// Bytes of the document to analyze.
        /// <para>
        /// To assign a byte[] to this property use <see cref="BinaryData.FromBytes(byte[])"/>.
        /// The byte[] will be serialized to a Base64 encoded string.
        /// </para>
        /// <para>
        /// Examples:
        /// <list type="bullet">
        /// <item>
        /// <term>BinaryData.FromBytes(new byte[] { 1, 2, 3 })</term>
        /// <description>Creates a payload of "AQID".</description>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="modelId"/> or <paramref name="bytesSource"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="modelId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<Operation<AnalyzeResult>> AnalyzeDocumentAsync(WaitUntil waitUntil, string modelId, BinaryData bytesSource, CancellationToken cancellationToken = default)
        {
            var options = new AnalyzeDocumentOptions(modelId, bytesSource);

            return await AnalyzeDocumentAsync(waitUntil, options, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Analyzes document with document model. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="modelId"> Unique document model name. </param>
        /// <param name="bytesSource">
        /// Bytes of the document to analyze.
        /// <para>
        /// To assign a byte[] to this property use <see cref="BinaryData.FromBytes(byte[])"/>.
        /// The byte[] will be serialized to a Base64 encoded string.
        /// </para>
        /// <para>
        /// Examples:
        /// <list type="bullet">
        /// <item>
        /// <term>BinaryData.FromBytes(new byte[] { 1, 2, 3 })</term>
        /// <description>Creates a payload of "AQID".</description>
        /// </item>
        /// </list>
        /// </para>
        /// </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="modelId"/> or <paramref name="bytesSource"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="modelId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Operation<AnalyzeResult> AnalyzeDocument(WaitUntil waitUntil, string modelId, BinaryData bytesSource, CancellationToken cancellationToken = default)
        {
            var options = new AnalyzeDocumentOptions(modelId, bytesSource);

            return AnalyzeDocument(waitUntil, options, cancellationToken);
        }

        // CUSTOM CODE NOTE: we're overwriting the behavior of the AnalyzeDocument,
        // AnalyzeBatchDocuments, and ClassifyDocument protocol methods to return an
        // instance of OperationWithId. This is a workaround since Operation.Id is not
        // supported by our generator yet (it throws a NotSupportedException), but this
        // ID is needed for multiple APIs.

        /// <summary>
        /// [Protocol Method] Analyzes document with document model.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="AnalyzeDocumentAsync(WaitUntil,AnalyzeDocumentOptions,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="modelId"> Unique document model name. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="pages"> 1-based page numbers to analyze.  Ex. "1-3,5,7-9". </param>
        /// <param name="locale">
        /// Locale hint for text recognition and document analysis.  Value may contain only
        /// the language code (ex. "en", "fr") or BCP 47 language tag (ex. "en-US").
        /// </param>
        /// <param name="stringIndexType"> Method used to compute string offset and length. Allowed values: "textElements" | "unicodeCodePoint" | "utf16CodeUnit". </param>
        /// <param name="features"> List of optional analysis features. </param>
        /// <param name="queryFields"> List of additional fields to extract.  Ex. "NumberOfGuests,StoreNumber". </param>
        /// <param name="outputContentFormat"> Format of the analyze result top-level content. Allowed values: "text" | "markdown". </param>
        /// <param name="output"> Additional outputs to generate during analysis. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="modelId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="modelId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation"/> representing an asynchronous operation on the service. </returns>
        public virtual async Task<Operation<BinaryData>> AnalyzeDocumentAsync(WaitUntil waitUntil, string modelId, RequestContent content, string pages = null, string locale = null, string stringIndexType = null, IEnumerable<DocumentAnalysisFeature> features = null, IEnumerable<string> queryFields = null, string outputContentFormat = null, IEnumerable<AnalyzeOutputOption> output = null, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(modelId, nameof(modelId));

            using var scope = ClientDiagnostics.CreateScope("DocumentIntelligenceClient.AnalyzeDocument");
            scope.Start();
            try
            {
                using HttpMessage message = CreateAnalyzeDocumentRequest(modelId, content, pages, locale, stringIndexType, features, queryFields, outputContentFormat, output, context);
                var internalOperation = await ProtocolOperationHelpers.ProcessMessageAsync(Pipeline, message, ClientDiagnostics, "DocumentIntelligenceClient.AnalyzeDocument", OperationFinalStateVia.OperationLocation, context, WaitUntil.Started).ConfigureAwait(false);
                var operationWithId = new OperationWithId(internalOperation);

                // Workaround to obtain the operation ID. The operation-location header is only returned after
                // the first request that starts the LRO. Because of this we're setting waitUntil to 'Started'
                // above so we have time to extract the operation ID in the OperationWithId constructor.

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

        /// <summary>
        /// [Protocol Method] Analyzes document with document model.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="AnalyzeDocument(WaitUntil,AnalyzeDocumentOptions,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="modelId"> Unique document model name. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="pages"> 1-based page numbers to analyze.  Ex. "1-3,5,7-9". </param>
        /// <param name="locale">
        /// Locale hint for text recognition and document analysis.  Value may contain only
        /// the language code (ex. "en", "fr") or BCP 47 language tag (ex. "en-US").
        /// </param>
        /// <param name="stringIndexType"> Method used to compute string offset and length. Allowed values: "textElements" | "unicodeCodePoint" | "utf16CodeUnit". </param>
        /// <param name="features"> List of optional analysis features. </param>
        /// <param name="queryFields"> List of additional fields to extract.  Ex. "NumberOfGuests,StoreNumber". </param>
        /// <param name="outputContentFormat"> Format of the analyze result top-level content. Allowed values: "text" | "markdown". </param>
        /// <param name="output"> Additional outputs to generate during analysis. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="modelId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="modelId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation"/> representing an asynchronous operation on the service. </returns>
        /// <include file="Generated/Docs/DocumentIntelligenceClient.xml" path="doc/members/member[@name='AnalyzeDocument(WaitUntil,string,RequestContent,string,string,string,IEnumerable{DocumentAnalysisFeature},IEnumerable{string},string,IEnumerable{AnalyzeOutputOption},RequestContext)']/*" />
        public virtual Operation<BinaryData> AnalyzeDocument(WaitUntil waitUntil, string modelId, RequestContent content, string pages = null, string locale = null, string stringIndexType = null, IEnumerable<DocumentAnalysisFeature> features = null, IEnumerable<string> queryFields = null, string outputContentFormat = null, IEnumerable<AnalyzeOutputOption> output = null, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(modelId, nameof(modelId));

            using var scope = ClientDiagnostics.CreateScope("DocumentIntelligenceClient.AnalyzeDocument");
            scope.Start();
            try
            {
                using HttpMessage message = CreateAnalyzeDocumentRequest(modelId, content, pages, locale, stringIndexType, features, queryFields, outputContentFormat, output, context);
                var internalOperation = ProtocolOperationHelpers.ProcessMessage(Pipeline, message, ClientDiagnostics, "DocumentIntelligenceClient.AnalyzeDocument", OperationFinalStateVia.OperationLocation, context, WaitUntil.Started);
                var operationWithId = new OperationWithId(internalOperation);

                // Workaround to obtain the operation ID. The operation-location header is only returned after
                // the first request that starts the LRO. Because of this we're setting waitUntil to 'Started'
                // above so we have time to extract the operation ID in the OperationWithId constructor.

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

        /// <summary>
        /// [Protocol Method] Analyzes batch documents with document model.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="AnalyzeBatchDocumentsAsync(WaitUntil,AnalyzeBatchDocumentsOptions,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="modelId"> Unique document model name. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="pages"> 1-based page numbers to analyze.  Ex. "1-3,5,7-9". </param>
        /// <param name="locale">
        /// Locale hint for text recognition and document analysis.  Value may contain only
        /// the language code (ex. "en", "fr") or BCP 47 language tag (ex. "en-US").
        /// </param>
        /// <param name="stringIndexType"> Method used to compute string offset and length. Allowed values: "textElements" | "unicodeCodePoint" | "utf16CodeUnit". </param>
        /// <param name="features"> List of optional analysis features. </param>
        /// <param name="queryFields"> List of additional fields to extract.  Ex. "NumberOfGuests,StoreNumber". </param>
        /// <param name="outputContentFormat"> Format of the analyze result top-level content. Allowed values: "text" | "markdown". </param>
        /// <param name="output"> Additional outputs to generate during analysis. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="modelId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="modelId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation"/> representing an asynchronous operation on the service. </returns>
        /// <include file="Generated/Docs/DocumentIntelligenceClient.xml" path="doc/members/member[@name='AnalyzeBatchDocumentsAsync(WaitUntil,string,RequestContent,string,string,string,IEnumerable{DocumentAnalysisFeature},IEnumerable{string},string,IEnumerable{AnalyzeOutputOption},RequestContext)']/*" />
        public virtual async Task<Operation<BinaryData>> AnalyzeBatchDocumentsAsync(WaitUntil waitUntil, string modelId, RequestContent content, string pages = null, string locale = null, string stringIndexType = null, IEnumerable<DocumentAnalysisFeature> features = null, IEnumerable<string> queryFields = null, string outputContentFormat = null, IEnumerable<AnalyzeOutputOption> output = null, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(modelId, nameof(modelId));

            using var scope = ClientDiagnostics.CreateScope("DocumentIntelligenceClient.AnalyzeBatchDocuments");
            scope.Start();
            try
            {
                using HttpMessage message = CreateAnalyzeBatchDocumentsRequest(modelId, content, pages, locale, stringIndexType, features, queryFields, outputContentFormat, output, context);
                var internalOperation = await ProtocolOperationHelpers.ProcessMessageAsync(Pipeline, message, ClientDiagnostics, "DocumentIntelligenceClient.AnalyzeBatchDocuments", OperationFinalStateVia.OperationLocation, context, WaitUntil.Started).ConfigureAwait(false);
                var operationWithId = new OperationWithId(internalOperation);

                // Workaround to obtain the operation ID. The operation-location header is only returned after
                // the first request that starts the LRO. Because of this we're setting waitUntil to 'Started'
                // above so we have time to extract the operation ID in the OperationWithId constructor.

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

        /// <summary>
        /// [Protocol Method] Analyzes batch documents with document model.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="AnalyzeBatchDocuments(WaitUntil,AnalyzeBatchDocumentsOptions,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="modelId"> Unique document model name. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="pages"> 1-based page numbers to analyze.  Ex. "1-3,5,7-9". </param>
        /// <param name="locale">
        /// Locale hint for text recognition and document analysis.  Value may contain only
        /// the language code (ex. "en", "fr") or BCP 47 language tag (ex. "en-US").
        /// </param>
        /// <param name="stringIndexType"> Method used to compute string offset and length. Allowed values: "textElements" | "unicodeCodePoint" | "utf16CodeUnit". </param>
        /// <param name="features"> List of optional analysis features. </param>
        /// <param name="queryFields"> List of additional fields to extract.  Ex. "NumberOfGuests,StoreNumber". </param>
        /// <param name="outputContentFormat"> Format of the analyze result top-level content. Allowed values: "text" | "markdown". </param>
        /// <param name="output"> Additional outputs to generate during analysis. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="modelId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="modelId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation"/> representing an asynchronous operation on the service. </returns>
        /// <include file="Generated/Docs/DocumentIntelligenceClient.xml" path="doc/members/member[@name='AnalyzeBatchDocuments(WaitUntil,string,RequestContent,string,string,string,IEnumerable{DocumentAnalysisFeature},IEnumerable{string},string,IEnumerable{AnalyzeOutputOption},RequestContext)']/*" />
        public virtual Operation<BinaryData> AnalyzeBatchDocuments(WaitUntil waitUntil, string modelId, RequestContent content, string pages = null, string locale = null, string stringIndexType = null, IEnumerable<DocumentAnalysisFeature> features = null, IEnumerable<string> queryFields = null, string outputContentFormat = null, IEnumerable<AnalyzeOutputOption> output = null, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(modelId, nameof(modelId));

            using var scope = ClientDiagnostics.CreateScope("DocumentIntelligenceClient.AnalyzeBatchDocuments");
            scope.Start();
            try
            {
                using HttpMessage message = CreateAnalyzeBatchDocumentsRequest(modelId, content, pages, locale, stringIndexType, features, queryFields, outputContentFormat, output, context);
                var internalOperation = ProtocolOperationHelpers.ProcessMessage(Pipeline, message, ClientDiagnostics, "DocumentIntelligenceClient.AnalyzeBatchDocuments", OperationFinalStateVia.OperationLocation, context, WaitUntil.Started);
                var operationWithId = new OperationWithId(internalOperation);

                // Workaround to obtain the operation ID. The operation-location header is only returned after
                // the first request that starts the LRO. Because of this we're setting waitUntil to 'Started'
                // above so we have time to extract the operation ID in the OperationWithId constructor.

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

        /// <summary>
        /// [Protocol Method] Classifies document with document classifier.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="ClassifyDocumentAsync(WaitUntil,ClassifyDocumentOptions,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="classifierId"> Unique document classifier name. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="stringIndexType"> Method used to compute string offset and length. Allowed values: "textElements" | "unicodeCodePoint" | "utf16CodeUnit". </param>
        /// <param name="split"> Document splitting mode. Allowed values: "auto" | "none" | "perPage". </param>
        /// <param name="pages"> 1-based page numbers to analyze.  Ex. "1-3,5,7-9". </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="classifierId"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="classifierId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation"/> representing an asynchronous operation on the service. </returns>
        /// <include file="Generated/Docs/DocumentIntelligenceClient.xml" path="doc/members/member[@name='ClassifyDocumentAsync(WaitUntil,string,RequestContent,string,string,string,RequestContext)']/*" />
        public virtual async Task<Operation<BinaryData>> ClassifyDocumentAsync(WaitUntil waitUntil, string classifierId, RequestContent content, string stringIndexType = null, string split = null, string pages = null, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(classifierId, nameof(classifierId));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("DocumentIntelligenceClient.ClassifyDocument");
            scope.Start();
            try
            {
                using HttpMessage message = CreateClassifyDocumentRequest(classifierId, content, stringIndexType, split, pages, context);
                var internalOperation = await ProtocolOperationHelpers.ProcessMessageAsync(_pipeline, message, ClientDiagnostics, "DocumentIntelligenceClient.ClassifyDocument", OperationFinalStateVia.OperationLocation, context, WaitUntil.Started).ConfigureAwait(false);
                var operationWithId = new OperationWithId(internalOperation);

                // Workaround to obtain the operation ID. The operation-location header is only returned after
                // the first request that starts the LRO. Because of this we're setting waitUntil to 'Started'
                // above so we have time to extract the operation ID in the OperationWithId constructor.

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

        /// <summary>
        /// [Protocol Method] Classifies document with document classifier.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="ClassifyDocument(WaitUntil,ClassifyDocumentOptions,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="classifierId"> Unique document classifier name. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="stringIndexType"> Method used to compute string offset and length. Allowed values: "textElements" | "unicodeCodePoint" | "utf16CodeUnit". </param>
        /// <param name="split"> Document splitting mode. Allowed values: "auto" | "none" | "perPage". </param>
        /// <param name="pages"> 1-based page numbers to analyze.  Ex. "1-3,5,7-9". </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="classifierId"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="classifierId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation"/> representing an asynchronous operation on the service. </returns>
        /// <include file="Generated/Docs/DocumentIntelligenceClient.xml" path="doc/members/member[@name='ClassifyDocument(WaitUntil,string,RequestContent,string,string,string,RequestContext)']/*" />
        public virtual Operation<BinaryData> ClassifyDocument(WaitUntil waitUntil, string classifierId, RequestContent content, string stringIndexType = null, string split = null, string pages = null, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(classifierId, nameof(classifierId));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("DocumentIntelligenceClient.ClassifyDocument");
            scope.Start();
            try
            {
                using HttpMessage message = CreateClassifyDocumentRequest(classifierId, content, stringIndexType, split, pages, context);
                var internalOperation = ProtocolOperationHelpers.ProcessMessage(Pipeline, message, ClientDiagnostics, "DocumentIntelligenceClient.ClassifyDocument", OperationFinalStateVia.OperationLocation, context, WaitUntil.Started);
                var operationWithId = new OperationWithId(internalOperation);

                // Workaround to obtain the operation ID. The operation-location header is only returned after
                // the first request that starts the LRO. Because of this we're setting waitUntil to 'Started'
                // above so we have time to extract the operation ID in the OperationWithId constructor.

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

        // CUSTOM CODE: we're suppressing the generation of GetAnalyzeResultPdf, GetAnalyzeResultFigure,
        // DeleteAnalyzeResult, DeleteAnalyzeBatchResult, and GetAnalyzeBatchResult and overwriting their
        // behavior below to make the parameter 'resultId' to accept a string instead of a Guid.

        /// <summary> Gets the generated searchable PDF output from document analysis. </summary>
        /// <param name="modelId"> Unique document model name. </param>
        /// <param name="resultId"> Analyze operation result ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="modelId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="modelId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <include file="Generated/Docs/DocumentIntelligenceClient.xml" path="doc/members/member[@name='GetAnalyzeResultPdfAsync(string,string,CancellationToken)']/*" />
        public virtual async Task<Response<BinaryData>> GetAnalyzeResultPdfAsync(string modelId, string resultId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(modelId, nameof(modelId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await GetAnalyzeResultPdfAsync(modelId, resultId, context).ConfigureAwait(false);
            return Response.FromValue(response.Content, response);
        }

        /// <summary> Gets the generated searchable PDF output from document analysis. </summary>
        /// <param name="modelId"> Unique document model name. </param>
        /// <param name="resultId"> Analyze operation result ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="modelId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="modelId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <include file="Generated/Docs/DocumentIntelligenceClient.xml" path="doc/members/member[@name='GetAnalyzeResultPdf(string,string,CancellationToken)']/*" />
        public virtual Response<BinaryData> GetAnalyzeResultPdf(string modelId, string resultId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(modelId, nameof(modelId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = GetAnalyzeResultPdf(modelId, resultId, context);
            return Response.FromValue(response.Content, response);
        }

        /// <summary>
        /// [Protocol Method] Gets the generated searchable PDF output from document analysis.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetAnalyzeResultPdfAsync(string,string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="modelId"> Unique document model name. </param>
        /// <param name="resultId"> Analyze operation result ID. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="modelId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="modelId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Generated/Docs/DocumentIntelligenceClient.xml" path="doc/members/member[@name='GetAnalyzeResultPdfAsync(string,string,RequestContext)']/*" />
        public virtual async Task<Response> GetAnalyzeResultPdfAsync(string modelId, string resultId, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(modelId, nameof(modelId));

            using var scope = ClientDiagnostics.CreateScope("DocumentIntelligenceClient.GetAnalyzeResultPdf");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetAnalyzeResultPdfRequest(modelId, resultId, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Gets the generated searchable PDF output from document analysis.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetAnalyzeResultPdf(string,string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="modelId"> Unique document model name. </param>
        /// <param name="resultId"> Analyze operation result ID. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="modelId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="modelId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Generated/Docs/DocumentIntelligenceClient.xml" path="doc/members/member[@name='GetAnalyzeResultPdf(string,string,RequestContext)']/*" />
        public virtual Response GetAnalyzeResultPdf(string modelId, string resultId, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(modelId, nameof(modelId));

            using var scope = ClientDiagnostics.CreateScope("DocumentIntelligenceClient.GetAnalyzeResultPdf");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetAnalyzeResultPdfRequest(modelId, resultId, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets the generated cropped image of specified figure from document analysis. </summary>
        /// <param name="modelId"> Unique document model name. </param>
        /// <param name="resultId"> Analyze operation result ID. </param>
        /// <param name="figureId"> Figure ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="modelId"/> or <paramref name="figureId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="modelId"/> or <paramref name="figureId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <include file="Generated/Docs/DocumentIntelligenceClient.xml" path="doc/members/member[@name='GetAnalyzeResultFigureAsync(string,string,string,CancellationToken)']/*" />
        public virtual async Task<Response<BinaryData>> GetAnalyzeResultFigureAsync(string modelId, string resultId, string figureId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(modelId, nameof(modelId));
            Argument.AssertNotNullOrEmpty(figureId, nameof(figureId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await GetAnalyzeResultFigureAsync(modelId, resultId, figureId, context).ConfigureAwait(false);
            return Response.FromValue(response.Content, response);
        }

        /// <summary> Gets the generated cropped image of specified figure from document analysis. </summary>
        /// <param name="modelId"> Unique document model name. </param>
        /// <param name="resultId"> Analyze operation result ID. </param>
        /// <param name="figureId"> Figure ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="modelId"/> or <paramref name="figureId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="modelId"/> or <paramref name="figureId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <include file="Generated/Docs/DocumentIntelligenceClient.xml" path="doc/members/member[@name='GetAnalyzeResultFigure(string,string,string,CancellationToken)']/*" />
        public virtual Response<BinaryData> GetAnalyzeResultFigure(string modelId, string resultId, string figureId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(modelId, nameof(modelId));
            Argument.AssertNotNullOrEmpty(figureId, nameof(figureId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = GetAnalyzeResultFigure(modelId, resultId, figureId, context);
            return Response.FromValue(response.Content, response);
        }

        /// <summary>
        /// [Protocol Method] Gets the generated cropped image of specified figure from document analysis.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetAnalyzeResultFigureAsync(string,string,string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="modelId"> Unique document model name. </param>
        /// <param name="resultId"> Analyze operation result ID. </param>
        /// <param name="figureId"> Figure ID. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="modelId"/> or <paramref name="figureId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="modelId"/> or <paramref name="figureId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Generated/Docs/DocumentIntelligenceClient.xml" path="doc/members/member[@name='GetAnalyzeResultFigureAsync(string,string,string,RequestContext)']/*" />
        public virtual async Task<Response> GetAnalyzeResultFigureAsync(string modelId, string resultId, string figureId, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(modelId, nameof(modelId));
            Argument.AssertNotNullOrEmpty(figureId, nameof(figureId));

            using var scope = ClientDiagnostics.CreateScope("DocumentIntelligenceClient.GetAnalyzeResultFigure");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetAnalyzeResultFigureRequest(modelId, resultId, figureId, context);
                return await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Gets the generated cropped image of specified figure from document analysis.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetAnalyzeResultFigure(string,string,string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="modelId"> Unique document model name. </param>
        /// <param name="resultId"> Analyze operation result ID. </param>
        /// <param name="figureId"> Figure ID. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="modelId"/> or <paramref name="figureId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="modelId"/> or <paramref name="figureId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Generated/Docs/DocumentIntelligenceClient.xml" path="doc/members/member[@name='GetAnalyzeResultFigure(string,string,string,RequestContext)']/*" />
        public virtual Response GetAnalyzeResultFigure(string modelId, string resultId, string figureId, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(modelId, nameof(modelId));
            Argument.AssertNotNullOrEmpty(figureId, nameof(figureId));

            using var scope = ClientDiagnostics.CreateScope("DocumentIntelligenceClient.GetAnalyzeResultFigure");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetAnalyzeResultFigureRequest(modelId, resultId, figureId, context);
                return Pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // The convenience method is omitted here because it has exactly the same parameter list as the corresponding protocol method
        /// <summary>
        /// [Protocol Method] Mark the result of document analysis for deletion.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="modelId"> Unique document model name. </param>
        /// <param name="resultId"> Analyze operation result ID. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="modelId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="modelId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Generated/Docs/DocumentIntelligenceClient.xml" path="doc/members/member[@name='DeleteAnalyzeResultAsync(string,string,RequestContext)']/*" />
        public virtual async Task<Response> DeleteAnalyzeResultAsync(string modelId, string resultId, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(modelId, nameof(modelId));

            using var scope = ClientDiagnostics.CreateScope("DocumentIntelligenceClient.DeleteAnalyzeResult");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDeleteAnalyzeResultRequest(modelId, resultId, context);
                return await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // The convenience method is omitted here because it has exactly the same parameter list as the corresponding protocol method
        /// <summary>
        /// [Protocol Method] Mark the result of document analysis for deletion.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="modelId"> Unique document model name. </param>
        /// <param name="resultId"> Analyze operation result ID. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="modelId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="modelId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Generated/Docs/DocumentIntelligenceClient.xml" path="doc/members/member[@name='DeleteAnalyzeResult(string,string,RequestContext)']/*" />
        public virtual Response DeleteAnalyzeResult(string modelId, string resultId, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(modelId, nameof(modelId));

            using var scope = ClientDiagnostics.CreateScope("DocumentIntelligenceClient.DeleteAnalyzeResult");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDeleteAnalyzeResultRequest(modelId, resultId, context);
                return Pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // The convenience method is omitted here because it has exactly the same parameter list as the corresponding protocol method
        /// <summary>
        /// [Protocol Method] Mark the batch document analysis result for deletion.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="modelId"> Unique document model name. </param>
        /// <param name="resultId"> Analyze batch operation result ID. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="modelId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="modelId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Generated/Docs/DocumentIntelligenceClient.xml" path="doc/members/member[@name='DeleteAnalyzeBatchResultAsync(string,string,RequestContext)']/*" />
        public virtual async Task<Response> DeleteAnalyzeBatchResultAsync(string modelId, string resultId, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(modelId, nameof(modelId));

            using var scope = ClientDiagnostics.CreateScope("DocumentIntelligenceClient.DeleteAnalyzeBatchResult");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDeleteAnalyzeBatchResultRequest(modelId, resultId, context);
                return await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // The convenience method is omitted here because it has exactly the same parameter list as the corresponding protocol method
        /// <summary>
        /// [Protocol Method] Mark the batch document analysis result for deletion.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="modelId"> Unique document model name. </param>
        /// <param name="resultId"> Analyze batch operation result ID. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="modelId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="modelId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Generated/Docs/DocumentIntelligenceClient.xml" path="doc/members/member[@name='DeleteAnalyzeBatchResult(string,string,RequestContext)']/*" />
        public virtual Response DeleteAnalyzeBatchResult(string modelId, string resultId, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(modelId, nameof(modelId));

            using var scope = ClientDiagnostics.CreateScope("DocumentIntelligenceClient.DeleteAnalyzeBatchResult");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDeleteAnalyzeBatchResultRequest(modelId, resultId, context);
                return Pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets the result of batch document analysis. </summary>
        /// <param name="modelId"> Unique document model name. </param>
        /// <param name="resultId"> Analyze batch operation result ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="modelId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="modelId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <include file="Generated/Docs/DocumentIntelligenceClient.xml" path="doc/members/member[@name='GetAnalyzeBatchResultAsync(string,string,CancellationToken)']/*" />
        public virtual async Task<Response<AnalyzeBatchOperationDetails>> GetAnalyzeBatchResultAsync(string modelId, string resultId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(modelId, nameof(modelId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await GetAnalyzeBatchResultAsync(modelId, resultId, context).ConfigureAwait(false);
            return Response.FromValue(AnalyzeBatchOperationDetails.FromResponse(response), response);
        }

        /// <summary> Gets the result of batch document analysis. </summary>
        /// <param name="modelId"> Unique document model name. </param>
        /// <param name="resultId"> Analyze batch operation result ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="modelId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="modelId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <include file="Generated/Docs/DocumentIntelligenceClient.xml" path="doc/members/member[@name='GetAnalyzeBatchResult(string,string,CancellationToken)']/*" />
        public virtual Response<AnalyzeBatchOperationDetails> GetAnalyzeBatchResult(string modelId, string resultId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(modelId, nameof(modelId));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = GetAnalyzeBatchResult(modelId, resultId, context);
            return Response.FromValue(AnalyzeBatchOperationDetails.FromResponse(response), response);
        }

        /// <summary>
        /// [Protocol Method] Gets the result of batch document analysis.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetAnalyzeBatchResultAsync(string,string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="modelId"> Unique document model name. </param>
        /// <param name="resultId"> Analyze batch operation result ID. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="modelId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="modelId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Generated/Docs/DocumentIntelligenceClient.xml" path="doc/members/member[@name='GetAnalyzeBatchResultAsync(string,string,RequestContext)']/*" />
        public virtual async Task<Response> GetAnalyzeBatchResultAsync(string modelId, string resultId, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(modelId, nameof(modelId));

            using var scope = ClientDiagnostics.CreateScope("DocumentIntelligenceClient.GetAnalyzeBatchResult");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetAnalyzeBatchResultRequest(modelId, resultId, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Gets the result of batch document analysis.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetAnalyzeBatchResult(string,string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="modelId"> Unique document model name. </param>
        /// <param name="resultId"> Analyze batch operation result ID. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="modelId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="modelId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Generated/Docs/DocumentIntelligenceClient.xml" path="doc/members/member[@name='GetAnalyzeBatchResult(string,string,RequestContext)']/*" />
        public virtual Response GetAnalyzeBatchResult(string modelId, string resultId, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(modelId, nameof(modelId));

            using var scope = ClientDiagnostics.CreateScope("DocumentIntelligenceClient.GetAnalyzeBatchResult");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetAnalyzeBatchResultRequest(modelId, resultId, context);
                return Pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateGetAnalyzeResultPdfRequest(string modelId, string resultId, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRaw("/documentintelligence", false);
            uri.AppendPath("/documentModels/", false);
            uri.AppendPath(modelId, true);
            uri.AppendPath("/analyzeResults/", false);
            uri.AppendPath(resultId, true);
            uri.AppendPath("/pdf", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/pdf");
            return message;
        }

        internal HttpMessage CreateGetAnalyzeResultFigureRequest(string modelId, string resultId, string figureId, RequestContext context)
        {
            var message = Pipeline.CreateMessage(context, PipelineMessageClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRaw("/documentintelligence", false);
            uri.AppendPath("/documentModels/", false);
            uri.AppendPath(modelId, true);
            uri.AppendPath("/analyzeResults/", false);
            uri.AppendPath(resultId, true);
            uri.AppendPath("/figures/", false);
            uri.AppendPath(figureId, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "image/png");
            return message;
        }

        internal HttpMessage CreateDeleteAnalyzeResultRequest(string modelId, string resultId, RequestContext context)
        {
            var message = Pipeline.CreateMessage(context, PipelineMessageClassifier204);
            var request = message.Request;
            request.Method = RequestMethod.Delete;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRaw("/documentintelligence", false);
            uri.AppendPath("/documentModels/", false);
            uri.AppendPath(modelId, true);
            uri.AppendPath("/analyzeResults/", false);
            uri.AppendPath(resultId, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateDeleteAnalyzeBatchResultRequest(string modelId, string resultId, RequestContext context)
        {
            var message = Pipeline.CreateMessage(context, ResponseClassifier204);
            var request = message.Request;
            request.Method = RequestMethod.Delete;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRaw("/documentintelligence", false);
            uri.AppendPath("/documentModels/", false);
            uri.AppendPath(modelId, true);
            uri.AppendPath("/analyzeBatchResults/", false);
            uri.AppendPath(resultId, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetAnalyzeBatchResultRequest(string modelId, string resultId, RequestContext context)
        {
            var message = Pipeline.CreateMessage(context, PipelineMessageClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRaw("/documentintelligence", false);
            uri.AppendPath("/documentModels/", false);
            uri.AppendPath(modelId, true);
            uri.AppendPath("/analyzeBatchResults/", false);
            uri.AppendPath(resultId, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        // CUSTOM CODE NOTE: code generation is mistakenly creating two copies of the
        // FetchAnalyzeResultFromAnalyzeOperation method, breaking the build.
        // We're forcibly suppressing their creation with the CodeGenSuppress attribute
        // and adding a single copy here.

        private AnalyzeResult FetchAnalyzeResultFromAnalyzeOperation(Response response)
        {
            var resultJsonElement = JsonDocument.Parse(response.Content).RootElement.GetProperty("analyzeResult");
            return AnalyzeResult.DeserializeAnalyzeResult(resultJsonElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
