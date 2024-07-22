// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Azure.Core;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Language.Text.Models;

namespace Azure.AI.Language.Text
{
    /// <summary> The language service API is a suite of natural language processing (NLP) skills built with best-in-class Microsoft machine learning algorithms.  The API can be used to analyze unstructured text for tasks such as sentiment analysis, key phrase extraction, language detection and question answering. Further documentation can be found in &lt;a href=\"https://docs.microsoft.com/azure/cognitive-services/language-service/overview\"&gt;https://docs.microsoft.com/azure/cognitive-services/language-service/overview&lt;/a&gt;.0. </summary>
    public partial class TextAnalysisClient
    {
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

            AnalyzeTextOperationInput analyzeTextOperationInput = new AnalyzeTextOperationInput(displayName, textInput, actions.ToList(), defaultLanguage, null);
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

            AnalyzeTextOperationInput analyzeTextOperationInput = new AnalyzeTextOperationInput(displayName, textInput, actions.ToList(), defaultLanguage, null);
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
