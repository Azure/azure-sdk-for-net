// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Azure.Core;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.AI.Language.Text
{
    /// <summary> The language service API is a suite of natural language processing (NLP) skills built with best-in-class Microsoft machine learning algorithms.  The API can be used to analyze unstructured text for tasks such as sentiment analysis, key phrase extraction, language detection and question answering. Further documentation can be found in &lt;a href=\"https://docs.microsoft.com/azure/cognitive-services/language-service/overview\"&gt;https://docs.microsoft.com/azure/cognitive-services/language-service/overview&lt;/a&gt;.0. </summary>
    public partial class TextAnalysisClient
    {
        /// <summary> Initializes a new instance of TextAnalysisClient. </summary>
        /// <param name="endpoint"> Supported Cognitive Services endpoint (e.g., https://&lt;resource-name&gt;.cognitiveservices.azure.com). </param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> or <paramref name="credential"/> is null. </exception>
        public TextAnalysisClient(Uri endpoint, TokenCredential credential, TextAnalysisClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            options ??= new TextAnalysisClientOptions();

            var authorizationScope = $"{(string.IsNullOrEmpty(options.Audience?.ToString()) ? TextAudience.AzurePublicCloud : options.Audience)}/.default";

            _tokenCredential = credential;

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _pipeline = HttpPipelineBuilder.Build(options, new HttpPipelinePolicy[] { new BearerTokenAuthenticationPolicy(credential, authorizationScope) }, Array.Empty<HttpPipelinePolicy>(), new ResponseClassifier());
            _endpoint = endpoint;
            _apiVersion = options.Version;
        }

        /// <summary> Submit a collection of text documents for analysis and get the results. Specify one or more unique tasks to be executed as a long-running operation. </summary>
        /// <param name="textInput"> Contains the input to be analyzed. </param>
        /// <param name="actions"> List of tasks to be performed as part of the LRO. </param>
        /// <param name="displayName"> Name for the task. </param>
        /// <param name="defaultLanguage"> Default language to use for records requesting automatic language detection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="textInput"/> or <paramref name="actions"/> is null. </exception>
        public virtual Response<AnalyzeTextOperationState> AnalyzeTextOperation(MultiLanguageTextInput textInput, IEnumerable<AnalyzeTextOperationAction> actions, string displayName = null, string defaultLanguage = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(textInput, nameof(textInput));
            Argument.AssertNotNull(actions, nameof(actions));

            string scopeName = $"{nameof(TextAnalysisClient)}.{nameof(AnalyzeTextOperation)}";
            using var scope = ClientDiagnostics.CreateScope(scopeName);
            scope.Start();

            AnalyzeTextSubmitJobRequest analyzeTextOperationInput = new AnalyzeTextSubmitJobRequest(displayName, textInput, actions.ToList(), defaultLanguage, cancelAfter: null, serializedAdditionalRawData: null);
            RequestContext context = FromCancellationToken(cancellationToken);

            try
            {
                using HttpMessage message = CreateAnalyzeTextSubmitOperationRequest(analyzeTextOperationInput.ToRequestContent(), context);
                var operation = ProtocolOperationHelpers.ProcessMessage(_pipeline, message, ClientDiagnostics, scopeName, OperationFinalStateVia.OperationLocation, context, WaitUntil.Completed);
                Response response = operation.GetRawResponse();
                return Response.FromValue(AnalyzeTextOperationState.FromResponse(response), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Submit a collection of text documents for analysis and get the results. Specify one or more unique tasks to be executed as a long-running operation. </summary>
        /// <param name="textInput"> Contains the input to be analyzed. </param>
        /// <param name="actions"> List of tasks to be performed as part of the LRO. </param>
        /// <param name="displayName"> Name for the task. </param>
        /// <param name="defaultLanguage"> Default language to use for records requesting automatic language detection. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="textInput"/> or <paramref name="actions"/> is null. </exception>
        public virtual async Task<Response<AnalyzeTextOperationState>> AnalyzeTextOperationAsync(MultiLanguageTextInput textInput, IEnumerable<AnalyzeTextOperationAction> actions, string displayName = null, string defaultLanguage = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(textInput, nameof(textInput));
            Argument.AssertNotNull(actions, nameof(actions));

            string scopeName = $"{nameof(TextAnalysisClient)}.{nameof(AnalyzeTextOperation)}";
            using var scope = ClientDiagnostics.CreateScope(scopeName);
            scope.Start();

            AnalyzeTextSubmitJobRequest analyzeTextOperationInput = new AnalyzeTextSubmitJobRequest(displayName, textInput, actions.ToList(), defaultLanguage, cancelAfter: null, serializedAdditionalRawData: null);
            RequestContext context = FromCancellationToken(cancellationToken);

            try
            {
                using HttpMessage message = CreateAnalyzeTextSubmitOperationRequest(analyzeTextOperationInput.ToRequestContent(), context);
                var operation = await ProtocolOperationHelpers.ProcessMessageAsync(_pipeline, message, ClientDiagnostics, scopeName, OperationFinalStateVia.OperationLocation, context, WaitUntil.Completed).ConfigureAwait(false);
                Response response = operation.GetRawResponse();
                return Response.FromValue(AnalyzeTextOperationState.FromResponse(response), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
