// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.Language.Conversations.Authoring
{
    /// <remarks>
    /// See <see href="https://learn.microsoft.com/rest/api/language/2023-04-01/conversational-analysis-authoring"/> for more information about models you can pass to this client.
    /// </remarks>
    /// <seealso href="https://learn.microsoft.com/rest/api/language/2023-04-01/conversational-analysis-authoring"/>
    [CodeGenClient("ConversationalAnalysisAuthoringClient")]
    public partial class ConversationAuthoringClient
    {
        /// <summary> Initializes a new instance of ConversationAnalysisClient. </summary>
        /// <param name="endpoint"> Supported Cognitive Services endpoint (e.g., https://&lt;resource-name&gt;.cognitiveservices.azure.com). </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public ConversationAuthoringClient(Uri endpoint, TokenCredential credential) : this(endpoint, credential, new ConversationsClientOptions())
        {
        }

        /// <summary> Initializes a new instance of ConversationAnalysisClient. </summary>
        /// <param name="endpoint"> Supported Cognitive Services endpoint (e.g., https://&lt;resource-name&gt;.cognitiveservices.azure.com). </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public ConversationAuthoringClient(Uri endpoint, TokenCredential credential, ConversationsClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            options ??= new ConversationsClientOptions();

            var authorizationScope = $"{(string.IsNullOrEmpty(options.Audience?.ToString()) ? ConversationsAudience.AzurePublicCloud : options.Audience)}/.default";

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _pipeline = HttpPipelineBuilder.Build(options, new HttpPipelinePolicy[] { new BearerTokenAuthenticationPolicy(credential, authorizationScope) }, Array.Empty<HttpPipelinePolicy>(), new ResponseClassifier());
            _endpoint = endpoint;
            _apiVersion = options.Version;
        }

        /// <summary>
        /// Gets the service endpoint for this client.
        /// </summary>
        public virtual Uri Endpoint => _endpoint;

        /// <summary> Triggers a job to export a project&apos;s data. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="projectName"> The name of the project to use. </param>
        /// <param name="exportedProjectFormat"> The format of the exported project file to use. Allowed values: &quot;Conversation&quot; | &quot;Luis&quot;. </param>
        /// <param name="assetKind"> Kind of asset to export. </param>
        /// <param name="stringIndexType"> Specifies the method used to interpret string offsets. Set this to &quot;Utf16CodeUnit&quot; for .NET strings, which are encoded as UTF-16. Allowed values: &quot;Utf16CodeUnit&quot;. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/> or <paramref name="stringIndexType"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="projectName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation{T}"/> from the service that will contain a <see cref="BinaryData"/> object once the asynchronous operation on the service has completed. Details of the body schema for the operation's final value are in the Remarks section below. </returns>
        /// <example>
        /// This sample shows how to call ExportProjectAsync with required parameters and parse the result.
        /// <code><![CDATA[
        /// var credential = new AzureKeyCredential("<key>");
        /// var endpoint = new Uri("<https://my-service.azure.com>");
        /// var client = new ConversationAuthoringClient(endpoint, credential);
        ///
        /// var operation = await client.ExportProjectAsync(WaitUntil.Completed, "<projectName>");
        ///
        /// BinaryData data = await operation.WaitForCompletionAsync();
        /// JsonElement result = JsonDocument.Parse(data.ToStream()).RootElement;
        /// Console.WriteLine(result.ToString());
        /// ]]></code>
        /// This sample shows how to call ExportProjectAsync with all parameters, and how to parse the result.
        /// <code><![CDATA[
        /// var credential = new AzureKeyCredential("<key>");
        /// var endpoint = new Uri("<https://my-service.azure.com>");
        /// var client = new ConversationAuthoringClient(endpoint, credential);
        ///
        /// var operation = await client.ExportProjectAsync(WaitUntil.Completed, "<projectName>", "<exportedProjectFormat>", "<assetKind>", <Utf16CodeUnit>);
        ///
        /// BinaryData data = await operation.WaitForCompletionAsync();
        /// JsonElement result = JsonDocument.Parse(data.ToStream()).RootElement;
        /// Console.WriteLine(result.GetProperty("resultUrl").ToString());
        /// Console.WriteLine(result.GetProperty("jobId").ToString());
        /// Console.WriteLine(result.GetProperty("createdDateTime").ToString());
        /// Console.WriteLine(result.GetProperty("lastUpdatedDateTime").ToString());
        /// Console.WriteLine(result.GetProperty("expirationDateTime").ToString());
        /// Console.WriteLine(result.GetProperty("status").ToString());
        /// Console.WriteLine(result.GetProperty("warnings")[0].GetProperty("code").ToString());
        /// Console.WriteLine(result.GetProperty("warnings")[0].GetProperty("message").ToString());
        /// Console.WriteLine(result.GetProperty("errors")[0].GetProperty("code").ToString());
        /// Console.WriteLine(result.GetProperty("errors")[0].GetProperty("message").ToString());
        /// Console.WriteLine(result.GetProperty("errors")[0].GetProperty("target").ToString());
        /// Console.WriteLine(result.GetProperty("errors")[0].GetProperty("details")[0].GetProperty("code").ToString());
        /// Console.WriteLine(result.GetProperty("errors")[0].GetProperty("details")[0].GetProperty("message").ToString());
        /// Console.WriteLine(result.GetProperty("errors")[0].GetProperty("details")[0].GetProperty("target").ToString());
        /// Console.WriteLine(result.GetProperty("errors")[0].GetProperty("details")[0].GetProperty("innererror").GetProperty("code").ToString());
        /// Console.WriteLine(result.GetProperty("errors")[0].GetProperty("details")[0].GetProperty("innererror").GetProperty("message").ToString());
        /// Console.WriteLine(result.GetProperty("errors")[0].GetProperty("details")[0].GetProperty("innererror").GetProperty("details").GetProperty("<test>").ToString());
        /// Console.WriteLine(result.GetProperty("errors")[0].GetProperty("details")[0].GetProperty("innererror").GetProperty("target").ToString());
        /// Console.WriteLine(result.GetProperty("errors")[0].GetProperty("innererror").GetProperty("code").ToString());
        /// Console.WriteLine(result.GetProperty("errors")[0].GetProperty("innererror").GetProperty("message").ToString());
        /// Console.WriteLine(result.GetProperty("errors")[0].GetProperty("innererror").GetProperty("details").GetProperty("<test>").ToString());
        /// Console.WriteLine(result.GetProperty("errors")[0].GetProperty("innererror").GetProperty("target").ToString());
        /// ]]></code>
        /// </example>
        /// <remarks>
        /// Below is the JSON schema for the response payload.
        /// Additional information can be found in the service REST API documentation:
        /// https://learn.microsoft.com/rest/api/language/2023-04-01/conversational-analysis-authoring/export
        ///
        /// Response Body:
        ///
        /// Schema for <c>ExportProjectJobState</c>:
        /// <code>{
        ///   resultUrl: string, # Optional. The URL to use in order to download the exported project.
        ///   jobId: string, # Required. The job ID.
        ///   createdDateTime: string (ISO 8601 Format), # Required. The creation date time of the job.
        ///   lastUpdatedDateTime: string (ISO 8601 Format), # Required. The last date time the job was updated.
        ///   expirationDateTime: string (ISO 8601 Format), # Optional. The expiration date time of the job.
        ///   status: &quot;notStarted&quot; | &quot;running&quot; | &quot;succeeded&quot; | &quot;failed&quot; | &quot;cancelled&quot; | &quot;cancelling&quot; | &quot;partiallyCompleted&quot;, # Required. The job status.
        ///   warnings: [
        ///     {
        ///       code: string, # Required. The warning code.
        ///       message: string, # Required. The warning message.
        ///     }
        ///   ], # Optional. The warnings that were encountered while executing the job.
        ///   errors: [
        ///     {
        ///       code: &quot;InvalidRequest&quot; | &quot;InvalidArgument&quot; | &quot;Unauthorized&quot; | &quot;Forbidden&quot; | &quot;NotFound&quot; | &quot;ProjectNotFound&quot; | &quot;OperationNotFound&quot; | &quot;AzureCognitiveSearchNotFound&quot; | &quot;AzureCognitiveSearchIndexNotFound&quot; | &quot;TooManyRequests&quot; | &quot;AzureCognitiveSearchThrottling&quot; | &quot;AzureCognitiveSearchIndexLimitReached&quot; | &quot;InternalServerError&quot; | &quot;ServiceUnavailable&quot; | &quot;Timeout&quot; | &quot;QuotaExceeded&quot; | &quot;Conflict&quot; | &quot;Warning&quot;, # Required. One of a server-defined set of error codes.
        ///       message: string, # Required. A human-readable representation of the error.
        ///       target: string, # Optional. The target of the error.
        ///       details: [Error], # Optional. An array of details about specific errors that led to this reported error.
        ///       innererror: {
        ///         code: &quot;InvalidRequest&quot; | &quot;InvalidParameterValue&quot; | &quot;KnowledgeBaseNotFound&quot; | &quot;AzureCognitiveSearchNotFound&quot; | &quot;AzureCognitiveSearchThrottling&quot; | &quot;ExtractionFailure&quot; | &quot;InvalidRequestBodyFormat&quot; | &quot;EmptyRequest&quot; | &quot;MissingInputDocuments&quot; | &quot;InvalidDocument&quot; | &quot;ModelVersionIncorrect&quot; | &quot;InvalidDocumentBatch&quot; | &quot;UnsupportedLanguageCode&quot; | &quot;InvalidCountryHint&quot;, # Required. One of a server-defined set of error codes.
        ///         message: string, # Required. Error message.
        ///         details: Dictionary&lt;string, string&gt;, # Optional. Error details.
        ///         target: string, # Optional. Error target.
        ///         innererror: InnerErrorModel, # Optional. An object containing more specific information than the current object about the error.
        ///       }, # Optional. An object containing more specific information than the current object about the error.
        ///     }
        ///   ], # Optional. The errors encountered while executing the job.
        /// }
        /// </code>
        ///
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Operation<BinaryData>> ExportProjectAsync(WaitUntil waitUntil, string projectName, string exportedProjectFormat, string assetKind, string stringIndexType, RequestContext context) =>
            await ExportProjectAsync(waitUntil, projectName, exportedProjectFormat, assetKind, stringIndexType, default, context).ConfigureAwait(false);

        /// <summary> Triggers a job to export a project&apos;s data. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="projectName"> The name of the project to use. </param>
        /// <param name="exportedProjectFormat"> The format of the exported project file to use. Allowed values: &quot;Conversation&quot; | &quot;Luis&quot;. </param>
        /// <param name="assetKind"> Kind of asset to export. </param>
        /// <param name="stringIndexType"> Specifies the method used to interpret string offsets. Set this to &quot;Utf16CodeUnit&quot; for .NET strings, which are encoded as UTF-16. Allowed values: &quot;Utf16CodeUnit&quot;. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="projectName"/> or <paramref name="stringIndexType"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="projectName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Operation{T}"/> from the service that will contain a <see cref="BinaryData"/> object once the asynchronous operation on the service has completed. Details of the body schema for the operation's final value are in the Remarks section below. </returns>
        /// <example>
        /// This sample shows how to call ExportProject with required parameters and parse the result.
        /// <code><![CDATA[
        /// var credential = new AzureKeyCredential("<key>");
        /// var endpoint = new Uri("<https://my-service.azure.com>");
        /// var client = new ConversationAuthoringClient(endpoint, credential);
        ///
        /// var operation = client.ExportProject(WaitUntil.Completed, "<projectName>");
        ///
        /// BinaryData data = operation.WaitForCompletion();
        /// JsonElement result = JsonDocument.Parse(data.ToStream()).RootElement;
        /// Console.WriteLine(result.ToString());
        /// ]]></code>
        /// This sample shows how to call ExportProject with all parameters, and how to parse the result.
        /// <code><![CDATA[
        /// var credential = new AzureKeyCredential("<key>");
        /// var endpoint = new Uri("<https://my-service.azure.com>");
        /// var client = new ConversationAuthoringClient(endpoint, credential);
        ///
        /// var operation = client.ExportProject(WaitUntil.Completed, "<projectName>", "<exportedProjectFormat>", "<assetKind>", <Utf16CodeUnit>);
        ///
        /// BinaryData data = operation.WaitForCompletion();
        /// JsonElement result = JsonDocument.Parse(data.ToStream()).RootElement;
        /// Console.WriteLine(result.GetProperty("resultUrl").ToString());
        /// Console.WriteLine(result.GetProperty("jobId").ToString());
        /// Console.WriteLine(result.GetProperty("createdDateTime").ToString());
        /// Console.WriteLine(result.GetProperty("lastUpdatedDateTime").ToString());
        /// Console.WriteLine(result.GetProperty("expirationDateTime").ToString());
        /// Console.WriteLine(result.GetProperty("status").ToString());
        /// Console.WriteLine(result.GetProperty("warnings")[0].GetProperty("code").ToString());
        /// Console.WriteLine(result.GetProperty("warnings")[0].GetProperty("message").ToString());
        /// Console.WriteLine(result.GetProperty("errors")[0].GetProperty("code").ToString());
        /// Console.WriteLine(result.GetProperty("errors")[0].GetProperty("message").ToString());
        /// Console.WriteLine(result.GetProperty("errors")[0].GetProperty("target").ToString());
        /// Console.WriteLine(result.GetProperty("errors")[0].GetProperty("details")[0].GetProperty("code").ToString());
        /// Console.WriteLine(result.GetProperty("errors")[0].GetProperty("details")[0].GetProperty("message").ToString());
        /// Console.WriteLine(result.GetProperty("errors")[0].GetProperty("details")[0].GetProperty("target").ToString());
        /// Console.WriteLine(result.GetProperty("errors")[0].GetProperty("details")[0].GetProperty("innererror").GetProperty("code").ToString());
        /// Console.WriteLine(result.GetProperty("errors")[0].GetProperty("details")[0].GetProperty("innererror").GetProperty("message").ToString());
        /// Console.WriteLine(result.GetProperty("errors")[0].GetProperty("details")[0].GetProperty("innererror").GetProperty("details").GetProperty("<test>").ToString());
        /// Console.WriteLine(result.GetProperty("errors")[0].GetProperty("details")[0].GetProperty("innererror").GetProperty("target").ToString());
        /// Console.WriteLine(result.GetProperty("errors")[0].GetProperty("innererror").GetProperty("code").ToString());
        /// Console.WriteLine(result.GetProperty("errors")[0].GetProperty("innererror").GetProperty("message").ToString());
        /// Console.WriteLine(result.GetProperty("errors")[0].GetProperty("innererror").GetProperty("details").GetProperty("<test>").ToString());
        /// Console.WriteLine(result.GetProperty("errors")[0].GetProperty("innererror").GetProperty("target").ToString());
        /// ]]></code>
        /// </example>
        /// <remarks>
        /// Below is the JSON schema for the response payload.
        /// Additional information can be found in the service REST API documentation:
        /// https://learn.microsoft.com/rest/api/language/2023-04-01/conversational-analysis-authoring/export
        ///
        /// Response Body:
        ///
        /// Schema for <c>ExportProjectJobState</c>:
        /// <code>{
        ///   resultUrl: string, # Optional. The URL to use in order to download the exported project.
        ///   jobId: string, # Required. The job ID.
        ///   createdDateTime: string (ISO 8601 Format), # Required. The creation date time of the job.
        ///   lastUpdatedDateTime: string (ISO 8601 Format), # Required. The last date time the job was updated.
        ///   expirationDateTime: string (ISO 8601 Format), # Optional. The expiration date time of the job.
        ///   status: &quot;notStarted&quot; | &quot;running&quot; | &quot;succeeded&quot; | &quot;failed&quot; | &quot;cancelled&quot; | &quot;cancelling&quot; | &quot;partiallyCompleted&quot;, # Required. The job status.
        ///   warnings: [
        ///     {
        ///       code: string, # Required. The warning code.
        ///       message: string, # Required. The warning message.
        ///     }
        ///   ], # Optional. The warnings that were encountered while executing the job.
        ///   errors: [
        ///     {
        ///       code: &quot;InvalidRequest&quot; | &quot;InvalidArgument&quot; | &quot;Unauthorized&quot; | &quot;Forbidden&quot; | &quot;NotFound&quot; | &quot;ProjectNotFound&quot; | &quot;OperationNotFound&quot; | &quot;AzureCognitiveSearchNotFound&quot; | &quot;AzureCognitiveSearchIndexNotFound&quot; | &quot;TooManyRequests&quot; | &quot;AzureCognitiveSearchThrottling&quot; | &quot;AzureCognitiveSearchIndexLimitReached&quot; | &quot;InternalServerError&quot; | &quot;ServiceUnavailable&quot; | &quot;Timeout&quot; | &quot;QuotaExceeded&quot; | &quot;Conflict&quot; | &quot;Warning&quot;, # Required. One of a server-defined set of error codes.
        ///       message: string, # Required. A human-readable representation of the error.
        ///       target: string, # Optional. The target of the error.
        ///       details: [Error], # Optional. An array of details about specific errors that led to this reported error.
        ///       innererror: {
        ///         code: &quot;InvalidRequest&quot; | &quot;InvalidParameterValue&quot; | &quot;KnowledgeBaseNotFound&quot; | &quot;AzureCognitiveSearchNotFound&quot; | &quot;AzureCognitiveSearchThrottling&quot; | &quot;ExtractionFailure&quot; | &quot;InvalidRequestBodyFormat&quot; | &quot;EmptyRequest&quot; | &quot;MissingInputDocuments&quot; | &quot;InvalidDocument&quot; | &quot;ModelVersionIncorrect&quot; | &quot;InvalidDocumentBatch&quot; | &quot;UnsupportedLanguageCode&quot; | &quot;InvalidCountryHint&quot;, # Required. One of a server-defined set of error codes.
        ///         message: string, # Required. Error message.
        ///         details: Dictionary&lt;string, string&gt;, # Optional. Error details.
        ///         target: string, # Optional. Error target.
        ///         innererror: InnerErrorModel, # Optional. An object containing more specific information than the current object about the error.
        ///       }, # Optional. An object containing more specific information than the current object about the error.
        ///     }
        ///   ], # Optional. The errors encountered while executing the job.
        /// }
        /// </code>
        ///
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Operation<BinaryData> ExportProject(WaitUntil waitUntil, string projectName, string exportedProjectFormat, string assetKind, string stringIndexType, RequestContext context) =>
            ExportProject(waitUntil, projectName, exportedProjectFormat, assetKind, stringIndexType, default, context);
    }
}
