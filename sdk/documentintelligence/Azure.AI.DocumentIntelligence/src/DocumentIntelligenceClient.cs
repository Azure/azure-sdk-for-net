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
    [CodeGenSuppress("FetchAnalyzeResultFromAnalyzeResultOperation", typeof(Response))]
    public partial class DocumentIntelligenceClient
    {
        // CUSTOM CODE NOTE: we're overwriting the behavior of the AnalyzeDocument API to
        // return an instance of TrainingOperation. This is a workaround since Operation.Id
        // is not supported by our generator yet (it throws a NotSupportedException), but
        // this ID is needed for the GetAnalyzeResultPdf and the GetAnalyzeResultImage APIs.

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
        /// Please try the simpler <see cref="AnalyzeDocumentAsync(WaitUntil,string,AnalyzeDocumentContent,string,string,StringIndexType?,IEnumerable{DocumentAnalysisFeature},IEnumerable{string},ContentFormat?,IEnumerable{AnalyzeOutputOption},CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="modelId"> Unique document model name. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="pages"> List of 1-based page numbers to analyze.  Ex. "1-3,5,7-9". </param>
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
        /// <include file="Generated/Docs/DocumentIntelligenceClient.xml" path="doc/members/member[@name='AnalyzeDocumentAsync(WaitUntil,string,RequestContent,string,string,string,IEnumerable{DocumentAnalysisFeature},IEnumerable{string},string,IEnumerable{AnalyzeOutputOption},RequestContext)']/*" />
        public virtual async Task<Operation<BinaryData>> AnalyzeDocumentAsync(WaitUntil waitUntil, string modelId, RequestContent content, string pages = null, string locale = null, string stringIndexType = null, IEnumerable<DocumentAnalysisFeature> features = null, IEnumerable<string> queryFields = null, string outputContentFormat = null, IEnumerable<AnalyzeOutputOption> output = null, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(modelId, nameof(modelId));

            using var scope = ClientDiagnostics.CreateScope("DocumentIntelligenceClient.AnalyzeDocument");
            scope.Start();
            try
            {
                using HttpMessage message = CreateAnalyzeDocumentRequest(modelId, content, pages, locale, stringIndexType, features, queryFields, outputContentFormat, output, context);
                var internalOperation = await ProtocolOperationHelpers.ProcessMessageAsync(_pipeline, message, ClientDiagnostics, "DocumentIntelligenceClient.AnalyzeDocument", OperationFinalStateVia.OperationLocation, context, WaitUntil.Started).ConfigureAwait(false);
                var trainingOperation = new TrainingOperation(internalOperation);

                // Workaround to obtain the operation ID. The operation-location header is only returned after
                // the first request that starts the LRO. Because of this we're setting waitUntil to 'Started'
                // above so we have time to extract the operation ID in the TrainingOperation constructor.

                if (waitUntil == WaitUntil.Completed)
                {
                    await trainingOperation.WaitForCompletionAsync(context?.CancellationToken ?? default).ConfigureAwait(false);
                }

                return trainingOperation;
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
        /// Please try the simpler <see cref="AnalyzeDocument(WaitUntil,string,AnalyzeDocumentContent,string,string,StringIndexType?,IEnumerable{DocumentAnalysisFeature},IEnumerable{string},ContentFormat?,IEnumerable{AnalyzeOutputOption},CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="modelId"> Unique document model name. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="pages"> List of 1-based page numbers to analyze.  Ex. "1-3,5,7-9". </param>
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
                var internalOperation = ProtocolOperationHelpers.ProcessMessage(_pipeline, message, ClientDiagnostics, "DocumentIntelligenceClient.AnalyzeDocument", OperationFinalStateVia.OperationLocation, context, WaitUntil.Started);
                var trainingOperation = new TrainingOperation(internalOperation);

                // Workaround to obtain the operation ID. The operation-location header is only returned after
                // the first request that starts the LRO. Because of this we're setting waitUntil to 'Started'
                // above so we have time to extract the operation ID in the TrainingOperation constructor.

                if (waitUntil == WaitUntil.Completed)
                {
                    trainingOperation.WaitForCompletion(context?.CancellationToken ?? default);
                }

                return trainingOperation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // CUSTOM CODE NOTE: code generation is mistakenly creating two copies of the
        // FetchAnalyzeResultFromAnalyzeResultOperation method, breaking the build.
        // We're forcibly suppressing their creation with the CodeGenSuppress attribute
        // and adding a single copy here.

        private AnalyzeResult FetchAnalyzeResultFromAnalyzeResultOperation(Response response)
        {
            var resultJsonElement = JsonDocument.Parse(response.Content).RootElement.GetProperty("analyzeResult");
            return AnalyzeResult.DeserializeAnalyzeResult(resultJsonElement);
        }
    }
}
