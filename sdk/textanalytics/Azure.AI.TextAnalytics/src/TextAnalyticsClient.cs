// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.TextAnalytics.Models;
using Azure.Core;
using Azure.Core.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// The client to use for interacting with the Azure Cognitive Service, Text Analytics.
    /// </summary>
    public partial class TextAnalyticsClient
    {
        private readonly Uri _baseUri;
        private readonly HttpPipeline _pipeline;
        private readonly ServiceRestClient _serviceRestClient;
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly string _apiVersion;
        private readonly TextAnalyticsClientOptions _options;
        private readonly string DefaultCognitiveScope = "https://cognitiveservices.azure.com/.default";

        /// <summary>
        /// Protected constructor to allow mocking.
        /// </summary>
        protected TextAnalyticsClient()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TextAnalyticsClient"/>
        /// class for the specified service instance.
        /// </summary>
        /// <param name="endpoint">A <see cref="Uri"/> to the service the client
        /// sends requests to.  Endpoint can be found in the Azure portal.</param>
        /// <param name="credential">A <see cref="TokenCredential"/> used to
        /// authenticate requests to the service, such as DefaultAzureCredential.</param>
        public TextAnalyticsClient(Uri endpoint, TokenCredential credential)
            : this(endpoint, credential, new TextAnalyticsClientOptions())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TextAnalyticsClient"/>
        /// class for the specified service instance.
        /// </summary>
        /// <param name="endpoint">A <see cref="Uri"/> to the service the client
        /// sends requests to.  Endpoint can be found in the Azure portal.</param>
        /// <param name="credential">A <see cref="TokenCredential"/> used to
        /// authenticate requests to the service, such as DefaultAzureCredential.</param>
        /// <param name="options"><see cref="TextAnalyticsClientOptions"/> that allow
        /// callers to configure how requests are sent to the service.</param>
        public TextAnalyticsClient(Uri endpoint, TokenCredential credential, TextAnalyticsClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNull(options, nameof(options));

            _baseUri = endpoint;
            _apiVersion = options.GetVersionString();
            _pipeline = HttpPipelineBuilder.Build(options, new BearerTokenAuthenticationPolicy(credential, DefaultCognitiveScope));
            _clientDiagnostics = new ClientDiagnostics(options);
            _options = options;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AzureKeyCredential"/>
        /// class for the specified service instance.
        /// </summary>
        /// <param name="endpoint">A <see cref="Uri"/> to the service the client
        /// sends requests to.  Endpoint can be found in the Azure portal.</param>
        /// <param name="credential">The API key used to access
        /// the service. This will allow you to update the API key
        /// without creating a new client.</param>
        public TextAnalyticsClient(Uri endpoint, AzureKeyCredential credential)
            : this(endpoint, credential, new TextAnalyticsClientOptions())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AzureKeyCredential"/>
        /// class for the specified service instance.
        /// </summary>
        /// <param name="endpoint">A <see cref="Uri"/> to the service the client
        /// sends requests to.  Endpoint can be found in the Azure portal.</param>
        /// <param name="credential">The API key used to access
        /// the service. This will allow you to update the API key
        /// without creating a new client.</param>
        /// <param name="options"><see cref="TextAnalyticsClientOptions"/> that allow
        /// callers to configure how requests are sent to the service.</param>
        public TextAnalyticsClient(Uri endpoint, AzureKeyCredential credential, TextAnalyticsClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNull(options, nameof(options));

            _baseUri = endpoint;
            _apiVersion = options.GetVersionString();
            _pipeline = HttpPipelineBuilder.Build(options, new AzureKeyCredentialPolicy(credential, AuthorizationHeader));
            _clientDiagnostics = new ClientDiagnostics(options);
            _options = options;

            // codegen
            _serviceRestClient = new ServiceRestClient(_clientDiagnostics, _pipeline, endpoint.AbsoluteUri);
        }

        #region Detect Language

        /// <summary>
        /// Runs a predictive model to determine the language the passed-in
        /// document is written in, and returns the detected language as well
        /// as a score indicating the model's confidence that the inferred
        /// language is correct.  Scores close to 1 indicate high certainty in
        /// the result.  120 languages are supported.
        /// For document length limits, maximum batch size, and supported text encoding, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/overview#data-limits"/>.
        /// </summary>
        /// <param name="document">The document to analyze.</param>
        /// <param name="countryHint">Indicates the country of origin of the
        /// document to assist the Text Analytics model in predicting the language
        /// it is written in.  If unspecified, this value will be set to the
        /// default country hint in <see cref="TextAnalyticsClientOptions"/>
        /// in the request sent to the service.
        /// To remove this behavior, set to <see cref="DetectLanguageInput.None"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>
        /// controlling the request lifetime.</param>
        /// <returns>A result containing the detected language or an error if
        /// the model could not analyze the document.</returns>
        /// <exception cref="RequestFailedException">Service returned a non-success
        /// status code.</exception>
        public virtual async Task<Response<DetectedLanguage>> DetectLanguageAsync(string document, string countryHint = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(document, nameof(document));
            countryHint ??= _options.DefaultCountryHint;

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(DetectLanguage)}");
            scope.AddAttribute("document", document);
            scope.Start();

            try
            {
                var documents = new List<LanguageInput>() { ConvertToLanguageInput(document, countryHint) };

                Response<LanguageResult> result = await _serviceRestClient.LanguagesAsync(new LanguageBatchInput(documents), cancellationToken: cancellationToken).ConfigureAwait(false);
                Response response = result.GetRawResponse();

                if (result.Value.Errors.Count > 0)
                {
                    // only one document, so we can ignore the id and grab the first error message.
                    var error = Transforms.ConvertToError(result.Value.Errors[0].Error);
                    throw _clientDiagnostics.CreateRequestFailedException(response, error.Message, error.ErrorCode.ToString(), CreateAdditionalInformation(error));
                }

                return Response.FromValue(Transforms.ConvertToDetectedLanguage(result.Value.Documents[0]), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Runs a predictive model to determine the language the passed-in
        /// document is written in, and returns the detected language as well
        /// as a score indicating the model's confidence that the inferred
        /// language is correct.  Scores close to 1 indicate high certainty in
        /// the result.  120 languages are supported.
        /// For document length limits, maximum batch size, and supported text encoding, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/overview#data-limits"/>.
        /// </summary>
        /// <param name="document">The document to analyze.</param>
        /// <param name="countryHint">Indicates the country of origin of the
        /// document to assist the Text Analytics model in predicting the language
        /// it is written in.  If unspecified, this value will be set to the
        /// default country hint in <see cref="TextAnalyticsClientOptions"/>
        /// in the request sent to the service.
        /// To remove this behavior, set to <see cref="DetectLanguageInput.None"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>
        /// controlling the request lifetime.</param>
        /// <returns>A result containing the detected language or an error if
        /// the model could not analyze the document.</returns>
        /// <exception cref="RequestFailedException">Service returned a non-success
        /// status code.</exception>
        public virtual Response<DetectedLanguage> DetectLanguage(string document, string countryHint = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(document, nameof(document));
            countryHint ??= _options.DefaultCountryHint;

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(DetectLanguage)}");
            scope.AddAttribute("document", document);
            scope.Start();

            try
            {
                var documents = new List<LanguageInput>() { ConvertToLanguageInput(document, countryHint) };
                Response<LanguageResult> result = _serviceRestClient.Languages(new LanguageBatchInput(documents), cancellationToken: cancellationToken);
                Response response = result.GetRawResponse();

                if (result.Value.Errors.Count > 0)
                {
                    // only one document, so we can ignore the id and grab the first error message.
                    var error = Transforms.ConvertToError(result.Value.Errors[0].Error);
                    throw _clientDiagnostics.CreateRequestFailedException(response, error.Message, error.ErrorCode.ToString(), CreateAdditionalInformation(error));
                }

                return Response.FromValue(Transforms.ConvertToDetectedLanguage(result.Value.Documents[0]), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Runs a predictive model to determine the language the passed-in
        /// documents are written in, and returns, for each one, the detected
        /// language as well as a score indicating the model's confidence that
        /// the inferred language is correct.  Scores close to 1 indicate high
        /// certainty in the result.  120 languages are supported.
        /// For document length limits, maximum batch size, and supported text encoding, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/overview#data-limits"/>.
        /// </summary>
        /// <param name="documents">A collection of documents to analyze.</param>
        /// <param name="countryHint">Indicates the country of origin of all of
        /// the documents to assist the Text Analytics model in predicting
        /// the language they are written in.  If unspecified, this value will be
        /// set to the default country hint in <see cref="TextAnalyticsClientOptions"/>
        /// in the request sent to the service.
        /// To remove this behavior, set to <see cref="DetectLanguageInput.None"/>.</param>
        /// <param name="options"><see cref="TextAnalyticsRequestOptions"/> used to
        /// select the version of the predictive model to run, and whether
        /// statistics are returned in the response.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>
        /// controlling the request lifetime.</param>
        /// <returns>A result containing the detected language or an error if
        /// the model could not analyze the documents.</returns>
        /// <exception cref="RequestFailedException">Service returned a non-success
        /// status code.</exception>
        public virtual async Task<Response<DetectLanguageResultCollection>> DetectLanguageBatchAsync(IEnumerable<string> documents, string countryHint = default, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            LanguageBatchInput detectLanguageInputs = ConvertToLanguageInputs(documents, countryHint);
            options ??= new TextAnalyticsRequestOptions();

            return await DetectLanguageBatchAsync(detectLanguageInputs, options, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Runs a predictive model to determine the language the passed-in
        /// documents are written in, and returns, for each one, the detected
        /// language as well as a score indicating the model's confidence that
        /// the inferred language is correct.  Scores close to 1 indicate high
        /// certainty in the result.  120 languages are supported.
        /// For document length limits, maximum batch size, and supported text encoding, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/overview#data-limits"/>.
        /// </summary>
        /// <param name="documents">A collection of documents to analyze.</param>
        /// <param name="countryHint">Indicates the country of origin of all of
        /// the documents to assist the Text Analytics model in predicting
        /// the language they are written in.  If unspecified, this value will be
        /// set to the default country hint in <see cref="TextAnalyticsClientOptions"/>
        /// in the request sent to the service.
        /// To remove this behavior, set to <see cref="DetectLanguageInput.None"/>.</param>
        /// <param name="options"><see cref="TextAnalyticsRequestOptions"/> used to
        /// select the version of the predictive model to run, and whether
        /// statistics are returned in the response.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>
        /// controlling the request lifetime.</param>
        /// <returns>A result containing the detected language or an error if
        /// the model could not analyze the documents.</returns>
        /// <exception cref="RequestFailedException">Service returned a non-success
        /// status code.</exception>
        public virtual Response<DetectLanguageResultCollection> DetectLanguageBatch(IEnumerable<string> documents, string countryHint = default, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            LanguageBatchInput detectLanguageInputs = ConvertToLanguageInputs(documents, countryHint);
            options ??= new TextAnalyticsRequestOptions();

            return DetectLanguageBatch(detectLanguageInputs, options, cancellationToken);
        }

        /// <summary>
        /// Runs a predictive model to determine the language the passed-in
        /// documents are written in, and returns, for each one, the detected
        /// language as well as a score indicating the model's confidence that
        /// the inferred language is correct.  Scores close to 1 indicate high
        /// certainty in the result.  120 languages are supported.
        /// For document length limits, maximum batch size, and supported text encoding, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/overview#data-limits"/>.
        /// </summary>
        /// <param name="documents">A collection of documents to analyze.</param>
        /// <param name="options"><see cref="TextAnalyticsRequestOptions"/> used to
        /// select the version of the predictive model to run, and whether
        /// statistics are returned in the response.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>
        /// controlling the request lifetime.</param>
        /// <returns>A result containing the detected language or an error if
        /// the model could not analyze the documents.</returns>
        /// <exception cref="RequestFailedException">Service returned a non-success
        /// status code.</exception>
        public virtual async Task<Response<DetectLanguageResultCollection>> DetectLanguageBatchAsync(IEnumerable<DetectLanguageInput> documents, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            LanguageBatchInput detectLanguageInputs = ConvertToLanguageInputs(documents);
            options ??= new TextAnalyticsRequestOptions();

            return await DetectLanguageBatchAsync(detectLanguageInputs, options, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Runs a predictive model to determine the language the passed-in
        /// documents are written in, and returns, for each one, the detected
        /// language as well as a score indicating the model's confidence that
        /// the inferred language is correct.  Scores close to 1 indicate high
        /// certainty in the result.  120 languages are supported.
        /// For document length limits, maximum batch size, and supported text encoding, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/overview#data-limits"/>.
        /// </summary>
        /// <param name="documents">A collection of documents to analyze.</param>
        /// <param name="options"><see cref="TextAnalyticsRequestOptions"/> used to
        /// select the version of the predictive model to run, and whether
        /// statistics are returned in the response.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>
        /// controlling the request lifetime.</param>
        /// <returns>A result containing the detected language or an error if
        /// the model could not analyze the document.</returns>
        /// <exception cref="RequestFailedException">Service returned a non-success
        /// status code.</exception>
        public virtual Response<DetectLanguageResultCollection> DetectLanguageBatch(IEnumerable<DetectLanguageInput> documents, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            options ??= new TextAnalyticsRequestOptions();
            LanguageBatchInput detectLanguageInputs = ConvertToLanguageInputs(documents);

            return DetectLanguageBatch(detectLanguageInputs, options, cancellationToken);
        }

        private async Task<Response<DetectLanguageResultCollection>> DetectLanguageBatchAsync(LanguageBatchInput batchInput, TextAnalyticsRequestOptions options, CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(DetectLanguageBatch)}");
            scope.Start();

            try
            {
                Response<LanguageResult> result = await _serviceRestClient.LanguagesAsync(batchInput, options.ModelVersion, options.IncludeStatistics, cancellationToken).ConfigureAwait(false);
                var response = result.GetRawResponse();

                switch (response.Status)
                {
                    case 200:
                        IDictionary<string, int> map = CreateIdToIndexMap(batchInput.Documents);
                        DetectLanguageResultCollection results = Transforms.ConvertLanguageResult(result.Value, map);
                        return Response.FromValue(results, response);
                    default:
                        throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private Response<DetectLanguageResultCollection> DetectLanguageBatch(LanguageBatchInput batchInput, TextAnalyticsRequestOptions options, CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(DetectLanguageBatch)}");
            scope.Start();

            try
            {
                Response<LanguageResult> result = _serviceRestClient.Languages(batchInput, options.ModelVersion, options.IncludeStatistics, cancellationToken);
                var response = result.GetRawResponse();

                switch (response.Status)
                {
                    case 200:
                        IDictionary<string, int> map = CreateIdToIndexMap(batchInput.Documents);
                        DetectLanguageResultCollection results = Transforms.ConvertLanguageResult(result.Value, map);
                        return Response.FromValue(results, response);
                    default:
                        throw _clientDiagnostics.CreateRequestFailedException(response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        #endregion

        #region Recognize Entities

        /// <summary>
        /// Runs a predictive model to identify a collection of named entities
        /// in the passed-in document, and categorize those entities into types
        /// such as person, location, or organization.  For more information on
        /// available categories, see
        /// <a href="https://docs.microsoft.com/en-us/azure/cognitive-services/Text-Analytics/named-entity-types"/>.
        /// For a list of languages supported by this operation, see
        /// <a href="https://docs.microsoft.com/en-us/azure/cognitive-services/text-analytics/language-support"/>.
        /// For document length limits, maximum batch size, and supported text encoding, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/overview#data-limits"/>.
        /// </summary>
        /// <param name="document">The document to analyze.</param>
        /// <param name="language">The language that the document is written in.
        /// If unspecified, this value will be set to the default language in
        /// <see cref="TextAnalyticsClientOptions"/> in the request sent to the
        /// service.  If set to an empty string, the service will apply a model
        /// where the language is explicitly set to "None".</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>
        /// controlling the request lifetime.</param>
        /// <returns>A result containing the collection of entities identified
        /// in the document, as well as a score indicating the confidence
        /// that the entity correctly matches the identified substring.</returns>
        /// <exception cref="RequestFailedException">Service returned a non-success
        /// status code.</exception>
        public virtual async Task<Response<CategorizedEntityCollection>> RecognizeEntitiesAsync(string document, string language = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(document, nameof(document));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(RecognizeEntities)}");
            scope.AddAttribute("document", document);
            scope.Start();

            try
            {
                TextDocumentInput[] documents = new TextDocumentInput[] { ConvertToDocumentInput(document, language) };
                using Request request = CreateDocumentInputRequest(documents, new TextAnalyticsRequestOptions(), EntitiesRoute);
                Response response = await _pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);

                switch (response.Status)
                {
                    case 200:
                        IDictionary<string, int> map = CreateIdToIndexMap(documents);
                        RecognizeEntitiesResultCollection results = await CreateRecognizeEntitiesResponseAsync(response, map, cancellationToken).ConfigureAwait(false);
                        if (results[0].HasError)
                        {
                            // only one document, so we can ignore the id and grab the first error message.
                            TextAnalyticsError error = results[0].Error;
                            throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response, error.Message, error.ErrorCode.ToString(), CreateAdditionalInformation(error)).ConfigureAwait(false);
                        }
                        return Response.FromValue((CategorizedEntityCollection)results[0].Entities, response);
                    default:
                        throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Runs a predictive model to identify a collection of named entities
        /// in the passed-in document, and categorize those entities into types
        /// such as person, location, or organization.  For more information on
        /// available categories, see
        /// <a href="https://docs.microsoft.com/en-us/azure/cognitive-services/Text-Analytics/named-entity-types"/>.
        /// For a list of languages supported by this operation, see
        /// <a href="https://docs.microsoft.com/en-us/azure/cognitive-services/text-analytics/language-support"/>.
        /// For document length limits, maximum batch size, and supported text encoding, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/overview#data-limits"/>.
        /// </summary>
        /// <param name="document">The text to analyze.</param>
        /// <param name="language">The language that the document is written in.
        /// If unspecified, this value will be set to the default language in
        /// <see cref="TextAnalyticsClientOptions"/> in the request sent to the
        /// service.  If set to an empty string, the service will apply a model
        /// where the language is explicitly set to "None".</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>
        /// controlling the request lifetime.</param>
        /// <returns>A result containing the collection of entities identified
        /// in the document, as well as a score indicating the confidence
        /// that the entity correctly matches the identified substring.</returns>
        /// <exception cref="RequestFailedException">Service returned a non-success
        /// status code.</exception>
        public virtual Response<CategorizedEntityCollection> RecognizeEntities(string document, string language = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(document, nameof(document));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(RecognizeEntities)}");
            scope.AddAttribute("document", document);
            scope.Start();

            try
            {
                TextDocumentInput[] documents = new TextDocumentInput[] { ConvertToDocumentInput(document, language) };
                using Request request = CreateDocumentInputRequest(documents, new TextAnalyticsRequestOptions(), EntitiesRoute);
                Response response = _pipeline.SendRequest(request, cancellationToken);

                switch (response.Status)
                {
                    case 200:
                        IDictionary<string, int> map = CreateIdToIndexMap(documents);
                        RecognizeEntitiesResultCollection results = CreateRecognizeEntitiesResponse(response, map);
                        if (results[0].HasError)
                        {
                            // only one document, so we can ignore the id and grab the first error message.
                            TextAnalyticsError error = results[0].Error;
                            throw _clientDiagnostics.CreateRequestFailedException(response, error.Message, error.ErrorCode.ToString(), CreateAdditionalInformation(error));
                        }
                        return Response.FromValue((CategorizedEntityCollection)results[0].Entities, response);
                    default:
                        throw _clientDiagnostics.CreateRequestFailedException(response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Runs a predictive model to identify a collection of named entities
        /// in the passed-in documents, and categorize those entities into types
        /// such as person, location, or organization.
        /// For more information on available categories, see
        /// <a href="https://docs.microsoft.com/en-us/azure/cognitive-services/Text-Analytics/named-entity-types"/>.
        /// For a list of languages supported by this operation, see
        /// <a href="https://docs.microsoft.com/en-us/azure/cognitive-services/text-analytics/language-support"/>.
        /// For document length limits, maximum batch size, and supported text encoding, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/overview#data-limits"/>.
        /// </summary>
        /// <param name="documents">The documents to analyze.</param>
        /// <param name="language">The language that all the documents are
        /// written in. If unspecified, this value will be set to the default
        /// language in <see cref="TextAnalyticsClientOptions"/> in the request
        /// sent to the service.  If set to an empty string, the service will apply a model
        /// where the language is explicitly set to "None".</param>
        /// <param name="options"><see cref="TextAnalyticsRequestOptions"/> used to
        /// select the version of the predictive model to run, and whether
        /// statistics are returned in the response.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>
        /// controlling the request lifetime.</param>
        /// <returns>A result containing the collection of entities identified
        /// for each of the documents, as well as scores indicating the confidence
        /// that a given entity correctly matches the identified substring.</returns>
        /// <exception cref="RequestFailedException">Service returned a non-success
        /// status code.</exception>
        public virtual async Task<Response<RecognizeEntitiesResultCollection>> RecognizeEntitiesBatchAsync(IEnumerable<string> documents, string language = default, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            List<TextDocumentInput> documentInputs = ConvertToDocumentInputs(documents, language);
            options ??= new TextAnalyticsRequestOptions();

            return await RecognizeEntitiesBatchAsync(documentInputs, options, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Runs a predictive model to identify a collection of named entities
        /// in the passed-in documents, and categorize those entities into types
        /// such as person, location, or organization.
        /// For more information on available categories, see
        /// <a href="https://docs.microsoft.com/en-us/azure/cognitive-services/Text-Analytics/named-entity-types"/>.
        /// For a list of languages supported by this operation, see
        /// <a href="https://docs.microsoft.com/en-us/azure/cognitive-services/text-analytics/language-support"/>.
        /// For document length limits, maximum batch size, and supported text encoding, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/overview#data-limits"/>.
        /// </summary>
        /// <param name="documents">The documents to analyze.</param>
        /// <param name="language">The language that all the documents are
        /// written in. If unspecified, this value will be set to the default
        /// language in <see cref="TextAnalyticsClientOptions"/> in the request
        /// sent to the service.  If set to an empty string, the service will apply a model
        /// where the language is explicitly set to "None".</param>
        /// <param name="options"><see cref="TextAnalyticsRequestOptions"/> used to
        /// select the version of the predictive model to run, and whether
        /// statistics are returned in the response.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>
        /// controlling the request lifetime.</param>
        /// <returns>A result containing the collection of entities identified
        /// for each of the documents, as well as scores indicating the confidence
        /// that a given entity correctly matches the identified substring.</returns>
        /// <exception cref="RequestFailedException">Service returned a non-success
        /// status code.</exception>
        public virtual Response<RecognizeEntitiesResultCollection> RecognizeEntitiesBatch(IEnumerable<string> documents, string language = default, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            List<TextDocumentInput> documentInputs = ConvertToDocumentInputs(documents, language);
            options ??= new TextAnalyticsRequestOptions();

            return RecognizeEntitiesBatch(documentInputs, options, cancellationToken);
        }

        /// <summary>
        /// Runs a predictive model to identify a collection of named entities
        /// in the passed-in documents, and categorize those entities into types
        /// such as person, location, or organization.
        /// For more information on available categories, see
        /// <a href="https://docs.microsoft.com/en-us/azure/cognitive-services/Text-Analytics/named-entity-types"/>.
        /// For a list of languages supported by this operation, see
        /// <a href="https://docs.microsoft.com/en-us/azure/cognitive-services/text-analytics/language-support"/>.
        /// For document length limits, maximum batch size, and supported text encoding, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/overview#data-limits"/>.
        /// </summary>
        /// <param name="documents">The documents to analyze.</param>
        /// <param name="options"><see cref="TextAnalyticsRequestOptions"/> used to
        /// select the version of the predictive model to run, and whether
        /// statistics are returned in the response.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>
        /// controlling the request lifetime.</param>
        /// <returns>A result containing the collection of entities identified
        /// for each of the documents, as well as scores indicating the confidence
        /// that a given entity correctly matches the identified substring.</returns>
        /// <exception cref="RequestFailedException">Service returned a non-success
        /// status code.</exception>
        public virtual async Task<Response<RecognizeEntitiesResultCollection>> RecognizeEntitiesBatchAsync(IEnumerable<TextDocumentInput> documents, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            options ??= new TextAnalyticsRequestOptions();

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(RecognizeEntitiesBatch)}");
            scope.Start();

            try
            {
                using Request request = CreateDocumentInputRequest(documents, options, EntitiesRoute);
                Response response = await _pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);

                switch (response.Status)
                {
                    case 200:
                        IDictionary<string, int> map = CreateIdToIndexMap(documents);
                        RecognizeEntitiesResultCollection results = await CreateRecognizeEntitiesResponseAsync(response, map, cancellationToken).ConfigureAwait(false);
                        return Response.FromValue(results, response);
                    default:
                        throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Runs a predictive model to identify a collection of named entities
        /// in the passed-in documents, and categorize those entities into types
        /// such as person, location, or organization.
        /// For more information on available categories, see
        /// <a href="https://docs.microsoft.com/en-us/azure/cognitive-services/Text-Analytics/named-entity-types"/>.
        /// For a list of languages supported by this operation, see
        /// <a href="https://docs.microsoft.com/en-us/azure/cognitive-services/text-analytics/language-support"/>.
        /// For document length limits, maximum batch size, and supported text encoding, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/overview#data-limits"/>.
        /// </summary>
        /// <param name="documents">The documents to analyze.</param>
        /// <param name="options"><see cref="TextAnalyticsRequestOptions"/> used to
        /// select the version of the predictive model to run, and whether
        /// statistics are returned in the response.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>
        /// controlling the request lifetime.</param>
        /// <returns>A result containing the collection of entities identified
        /// for each of the documents, as well as scores indicating the confidence
        /// that a given entity correctly matches the identified substring.</returns>
        /// <exception cref="RequestFailedException">Service returned a non-success
        /// status code.</exception>
        public virtual Response<RecognizeEntitiesResultCollection> RecognizeEntitiesBatch(IEnumerable<TextDocumentInput> documents, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            options ??= new TextAnalyticsRequestOptions();

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(RecognizeEntitiesBatch)}");
            scope.Start();

            try
            {
                using Request request = CreateDocumentInputRequest(documents, options, EntitiesRoute);
                Response response = _pipeline.SendRequest(request, cancellationToken);

                switch (response.Status)
                {
                    case 200:
                        IDictionary<string, int> map = CreateIdToIndexMap(documents);
                        RecognizeEntitiesResultCollection results = CreateRecognizeEntitiesResponse(response, map);
                        return Response.FromValue(results, response);
                    default:
                        throw _clientDiagnostics.CreateRequestFailedException(response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        #endregion

        #region Analyze Sentiment

        /// <summary>
        /// Runs a predictive model to identify the positive, negative, neutral
        /// or mixed sentiment contained in the document, as well as a score
        /// indicating the model's confidence in the predicted sentiment.
        /// For a list of languages supported by this operation, see
        /// <a href="https://docs.microsoft.com/en-us/azure/cognitive-services/text-analytics/language-support"/>.
        /// For document length limits, maximum batch size, and supported text encoding, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/overview#data-limits"/>.
        /// </summary>
        /// <param name="document">The document to analyze.</param>
        /// <param name="language">The language that the document is written in.
        /// If unspecified, this value will be set to the default language in
        /// <see cref="TextAnalyticsClientOptions"/> in the request sent to the
        /// service.  If set to an empty string, the service will apply a model
        /// where the language is explicitly set to "None".</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>
        /// controlling the request lifetime.</param>
        /// <returns>A result containing sentiment predictions for the document
        /// and each of the sentences it contains.</returns>
        /// <exception cref="RequestFailedException">Service returned a non-success
        /// status code.</exception>
        public virtual async Task<Response<DocumentSentiment>> AnalyzeSentimentAsync(string document, string language = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(document, nameof(document));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(AnalyzeSentiment)}");
            scope.AddAttribute("document", document);
            scope.Start();

            try
            {
                TextDocumentInput[] documents = new TextDocumentInput[] { ConvertToDocumentInput(document, language) };
                using Request request = CreateDocumentInputRequest(documents, new TextAnalyticsRequestOptions(), SentimentRoute);
                Response response = await _pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);

                switch (response.Status)
                {
                    case 200:
                        IDictionary<string, int> map = CreateIdToIndexMap(documents);
                        AnalyzeSentimentResultCollection results = await CreateAnalyzeSentimentResponseAsync(response, map, cancellationToken).ConfigureAwait(false);
                        if (results[0].HasError)
                        {
                            // only one document, so we can ignore the id and grab the first error message.
                            TextAnalyticsError error = results[0].Error;
                            throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response, error.Message, error.ErrorCode.ToString(), CreateAdditionalInformation(error)).ConfigureAwait(false);
                        }
                        return Response.FromValue(results[0].DocumentSentiment, response);
                    default:
                        throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Runs a predictive model to identify the positive, negative or neutral
        /// sentiment contained in the document, as well as a score indicating the model's
        /// confidence in the predicted sentiment.
        /// For a list of languages supported by this operation, see
        /// <a href="https://docs.microsoft.com/en-us/azure/cognitive-services/text-analytics/language-support"/>.
        /// For document length limits, maximum batch size, and supported text encoding, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/overview#data-limits"/>.
        /// </summary>
        /// <param name="document">The text to analyze.</param>
        /// <param name="language">The language that the document is written in.
        /// If unspecified, this value will be set to the default language in
        /// <see cref="TextAnalyticsClientOptions"/> in the request sent to the
        /// service.  If set to an empty string, the service will apply a model
        /// where the language is explicitly set to "None".</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>
        /// controlling the request lifetime.</param>
        /// <returns>A result containing sentiment predictions for the document
        /// and each of the sentences it contains.</returns>
        /// <exception cref="RequestFailedException">Service returned a non-success
        /// status code.</exception>
        public virtual Response<DocumentSentiment> AnalyzeSentiment(string document, string language = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(document, nameof(document));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(AnalyzeSentiment)}");
            scope.AddAttribute("document", document);
            scope.Start();

            try
            {
                TextDocumentInput[] documents = new TextDocumentInput[] { ConvertToDocumentInput(document, language) };
                using Request request = CreateDocumentInputRequest(documents, new TextAnalyticsRequestOptions(), SentimentRoute);
                Response response = _pipeline.SendRequest(request, cancellationToken);

                switch (response.Status)
                {
                    case 200:
                        IDictionary<string, int> map = CreateIdToIndexMap(documents);
                        AnalyzeSentimentResultCollection results = CreateAnalyzeSentimentResponse(response, map);
                        if (results[0].HasError)
                        {
                            // only one document, so we can ignore the id and grab the first error message.
                            TextAnalyticsError error = results[0].Error;
                            throw _clientDiagnostics.CreateRequestFailedException(response, error.Message, error.ErrorCode.ToString(), CreateAdditionalInformation(error));
                        }
                        return Response.FromValue(results[0].DocumentSentiment, response);
                    default:
                        throw _clientDiagnostics.CreateRequestFailedException(response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Runs a predictive model to identify the positive, negative or neutral
        /// sentiment contained in the documents, as well as scores indicating
        /// the model's confidence in each of the predicted sentiments.
        /// For a list of languages supported by this operation, see
        /// <a href="https://docs.microsoft.com/en-us/azure/cognitive-services/text-analytics/language-support"/>.
        /// For document length limits, maximum batch size, and supported text encoding, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/overview#data-limits"/>.
        /// </summary>
        /// <param name="documents">The documents to analyze.</param>
        /// <param name="language">The language that all of the documents are written in.
        /// If unspecified, this value will be set to the default language in
        /// <see cref="TextAnalyticsClientOptions"/> in the request sent to the
        /// service.  If set to an empty string, the service will apply a model
        /// where the language is explicitly set to "None".</param>
        /// <param name="options"><see cref="TextAnalyticsRequestOptions"/> used to
        /// select the version of the predictive model to run, and whether
        /// statistics are returned in the response.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>
        /// controlling the request lifetime.</param>
        /// <returns>A result containing sentiment predictions for each of the documents
        /// and predictions for each of the sentences each document contains.</returns>
        /// <exception cref="RequestFailedException">Service returned a non-success
        /// status code.</exception>
        public virtual async Task<Response<AnalyzeSentimentResultCollection>> AnalyzeSentimentBatchAsync(IEnumerable<string> documents, string language = default, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            List<TextDocumentInput> documentInputs = ConvertToDocumentInputs(documents, language);
            options ??= new TextAnalyticsRequestOptions();

            return await AnalyzeSentimentBatchAsync(documentInputs, options, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Runs a predictive model to identify the positive, negative or neutral
        /// sentiment contained in the documents, as well as scores indicating
        /// the model's confidence in each of the predicted sentiments.
        /// For a list of languages supported by this operation, see
        /// <a href="https://docs.microsoft.com/en-us/azure/cognitive-services/text-analytics/language-support"/>.
        /// For document length limits, maximum batch size, and supported text encoding, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/overview#data-limits"/>.
        /// </summary>
        /// <param name="documents">The documents to analyze.</param>
        /// <param name="language">The language that all of the documents are written in.
        /// If unspecified, this value will be set to the default language in
        /// <see cref="TextAnalyticsClientOptions"/> in the request sent to the
        /// service.  If set to an empty string, the service will apply a model
        /// where the language is explicitly set to "None".</param>
        /// <param name="options"><see cref="TextAnalyticsRequestOptions"/> used to
        /// select the version of the predictive model to run, and whether
        /// statistics are returned in the response.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>
        /// controlling the request lifetime.</param>
        /// <returns>A result containing sentiment predictions for each of the documents
        /// and predictions for each of the sentences each document contains.</returns>
        /// <exception cref="RequestFailedException">Service returned a non-success
        /// status code.</exception>
        public virtual Response<AnalyzeSentimentResultCollection> AnalyzeSentimentBatch(IEnumerable<string> documents, string language = default, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            List<TextDocumentInput> documentInputs = ConvertToDocumentInputs(documents, language);
            options ??= new TextAnalyticsRequestOptions();

            return AnalyzeSentimentBatch(documentInputs, options, cancellationToken);
        }

        /// <summary>
        /// Runs a predictive model to identify the positive, negative or neutral
        /// sentiment contained in the documents, as well as scores indicating
        /// the model's confidence in each of the predicted sentiments.
        /// For a list of languages supported by this operation, see
        /// <a href="https://docs.microsoft.com/en-us/azure/cognitive-services/text-analytics/language-support"/>.
        /// For document length limits, maximum batch size, and supported text encoding, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/overview#data-limits"/>.
        /// </summary>
        /// <param name="documents">The documents to analyze.</param>
        /// <param name="options"><see cref="TextAnalyticsRequestOptions"/> used to
        /// select the version of the predictive model to run, and whether
        /// statistics are returned in the response.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>
        /// controlling the request lifetime.</param>
        /// <returns>A result containing sentiment predictions for each of the documents
        /// and predictions for each of the sentences each document contains.</returns>
        /// <exception cref="RequestFailedException">Service returned a non-success
        /// status code.</exception>
        public virtual async Task<Response<AnalyzeSentimentResultCollection>> AnalyzeSentimentBatchAsync(IEnumerable<TextDocumentInput> documents, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            options ??= new TextAnalyticsRequestOptions();

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(AnalyzeSentimentBatch)}");
            scope.Start();

            try
            {
                using Request request = CreateDocumentInputRequest(documents, options, SentimentRoute);
                Response response = await _pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);

                switch (response.Status)
                {
                    case 200:
                        IDictionary<string, int> map = CreateIdToIndexMap(documents);
                        AnalyzeSentimentResultCollection results = await CreateAnalyzeSentimentResponseAsync(response, map, cancellationToken).ConfigureAwait(false);
                        return Response.FromValue(results, response);
                    default:
                        throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Runs a predictive model to identify the positive, negative or neutral
        /// sentiment contained in the documents, as well as scores indicating
        /// the model's confidence in each of the predicted sentiments.
        /// For a list of languages supported by this operation, see
        /// <a href="https://docs.microsoft.com/en-us/azure/cognitive-services/text-analytics/language-support"/>.
        /// For document length limits, maximum batch size, and supported text encoding, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/overview#data-limits"/>.
        /// </summary>
        /// <param name="documents">The documents to analyze.</param>
        /// <param name="options"><see cref="TextAnalyticsRequestOptions"/> used to
        /// select the version of the predictive model to run, and whether
        /// statistics are returned in the response.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>
        /// controlling the request lifetime.</param>
        /// <returns>A result containing sentiment predictions for each of the documents
        /// and predictions for each of the sentences each document contains.</returns>
        /// <exception cref="RequestFailedException">Service returned a non-success
        /// status code.</exception>
        public virtual Response<AnalyzeSentimentResultCollection> AnalyzeSentimentBatch(IEnumerable<TextDocumentInput> documents, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            options ??= new TextAnalyticsRequestOptions();

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(AnalyzeSentimentBatch)}");
            scope.Start();

            try
            {
                using Request request = CreateDocumentInputRequest(documents, options, SentimentRoute);
                Response response = _pipeline.SendRequest(request, cancellationToken);

                switch (response.Status)
                {
                    case 200:
                        IDictionary<string, int> map = CreateIdToIndexMap(documents);
                        AnalyzeSentimentResultCollection results = CreateAnalyzeSentimentResponse(response, map);
                        return Response.FromValue(results, response);
                    default:
                        throw _clientDiagnostics.CreateRequestFailedException(response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        #endregion

        #region Extract Key Phrases

        /// <summary>
        /// Runs a model to identify a collection of significant phrases
        /// found in the passed-in document.
        /// For example, for the document "The food was delicious and there
        /// were wonderful staff", the API returns the main talking points: "food"
        /// and "wonderful staff".
        /// For a list of languages supported by this operation, see
        /// <a href="https://docs.microsoft.com/en-us/azure/cognitive-services/text-analytics/language-support"/>.
        /// For document length limits, maximum batch size, and supported text encoding, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/overview#data-limits"/>.
        /// </summary>
        /// <param name="document">The document to analyze.</param>
        /// <param name="language">The language that the document is written in.
        /// If unspecified, this value will be set to the default language in
        /// <see cref="TextAnalyticsClientOptions"/> in the request sent to the
        /// service.  If set to an empty string, the service will apply a model
        /// where the language is explicitly set to "None".</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>
        /// controlling the request lifetime.</param>
        /// <returns>A result containing the collection of key phrases identified
        /// in the document.</returns>
        /// <exception cref="RequestFailedException">Service returned a non-success
        /// status code.</exception>
        public virtual async Task<Response<KeyPhraseCollection>> ExtractKeyPhrasesAsync(string document, string language = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(document, nameof(document));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(ExtractKeyPhrases)}");
            scope.AddAttribute("document", document);
            scope.Start();

            try
            {
                TextDocumentInput[] documents = new TextDocumentInput[] { ConvertToDocumentInput(document, language) };
                using Request request = CreateDocumentInputRequest(documents, new TextAnalyticsRequestOptions(), KeyPhrasesRoute);
                Response response = await _pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);

                switch (response.Status)
                {
                    case 200:
                        IDictionary<string, int> map = CreateIdToIndexMap(documents);
                        ExtractKeyPhrasesResultCollection results = await CreateKeyPhraseResponseAsync(response, map, cancellationToken).ConfigureAwait(false);
                        if (results[0].HasError)
                        {
                            // only one document, so we can ignore the id and grab the first error message.
                            TextAnalyticsError error = results[0].Error;
                            throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response, error.Message, error.ErrorCode.ToString(), CreateAdditionalInformation(error)).ConfigureAwait(false);
                        }
                        return Response.FromValue((KeyPhraseCollection) results[0].KeyPhrases, response);
                    default:
                        throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Runs a model to identify a collection of significant phrases
        /// found in the passed-in document.
        /// For example, for the document "The food was delicious and there
        /// were wonderful staff", the API returns the main talking points: "food"
        /// and "wonderful staff".
        /// For a list of languages supported by this operation, see
        /// <a href="https://docs.microsoft.com/en-us/azure/cognitive-services/text-analytics/language-support"/>.
        /// For document length limits, maximum batch size, and supported text encoding, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/overview#data-limits"/>.
        /// </summary>
        /// <param name="document">The document to analyze.</param>
        /// <param name="language">The language that the document is written in.
        /// If unspecified, this value will be set to the default language in
        /// <see cref="TextAnalyticsClientOptions"/> in the request sent to the
        /// service.  If set to an empty string, the service will apply a model
        /// where the language is explicitly set to "None".</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>
        /// controlling the request lifetime.</param>
        /// <returns>A result containing the collection of key phrases identified
        /// in the document.</returns>
        /// <exception cref="RequestFailedException">Service returned a non-success
        /// status code.</exception>
        public virtual Response<KeyPhraseCollection> ExtractKeyPhrases(string document, string language = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(document, nameof(document));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(ExtractKeyPhrases)}");
            scope.AddAttribute("document", document);
            scope.Start();

            try
            {
                TextDocumentInput[] documents = new TextDocumentInput[] { ConvertToDocumentInput(document, language) };
                using Request request = CreateDocumentInputRequest(documents, new TextAnalyticsRequestOptions(), KeyPhrasesRoute);
                Response response = _pipeline.SendRequest(request, cancellationToken);

                switch (response.Status)
                {
                    case 200:
                        IDictionary<string, int> map = CreateIdToIndexMap(documents);
                        ExtractKeyPhrasesResultCollection results = CreateKeyPhraseResponse(response, map);
                        if (results[0].HasError)
                        {
                            // only one document, so we can ignore the id and grab the first error message.
                            TextAnalyticsError error = results[0].Error;
                            throw _clientDiagnostics.CreateRequestFailedException(response, error.Message, error.ErrorCode.ToString(), CreateAdditionalInformation(error));
                        }
                        return Response.FromValue((KeyPhraseCollection)results[0].KeyPhrases, response);
                    default:
                        throw _clientDiagnostics.CreateRequestFailedException(response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Runs a model to identify a collection of significant phrases
        /// found in the passed-in documents.
        /// For example, for the document "The food was delicious and there
        /// were wonderful staff", the API returns the main talking points: "food"
        /// and "wonderful staff".
        /// For a list of languages supported by this operation, see
        /// <a href="https://docs.microsoft.com/en-us/azure/cognitive-services/text-analytics/language-support"/>.
        /// For document length limits, maximum batch size, and supported text encoding, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/overview#data-limits"/>.
        /// </summary>
        /// <param name="documents">The documents to analyze.</param>
        /// <param name="language">The language that all the documents are
        /// written in. If unspecified, this value will be set to the default
        /// language in <see cref="TextAnalyticsClientOptions"/> in the request
        /// sent to the service.  If set to an empty string, the service will apply a model
        /// where the language is explicitly set to "None".</param>
        /// <param name="options"><see cref="TextAnalyticsRequestOptions"/> used to
        /// select the version of the predictive model to run, and whether
        /// statistics are returned in the response.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>
        /// controlling the request lifetime.</param>
        /// <returns>A result containing the collection of key phrases identified
        /// in each of the documents.</returns>
        /// <exception cref="RequestFailedException">Service returned a non-success
        /// status code.</exception>
        public virtual async Task<Response<ExtractKeyPhrasesResultCollection>> ExtractKeyPhrasesBatchAsync(IEnumerable<string> documents, string language = default, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            List<TextDocumentInput> documentInputs = ConvertToDocumentInputs(documents, language);
            options ??= new TextAnalyticsRequestOptions();

            return await ExtractKeyPhrasesBatchAsync(documentInputs, options, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Runs a model to identify a collection of significant phrases
        /// found in the passed-in documents.
        /// For example, for the document "The food was delicious and there
        /// were wonderful staff", the API returns the main talking points: "food"
        /// and "wonderful staff".
        /// For a list of languages supported by this operation, see
        /// <a href="https://docs.microsoft.com/en-us/azure/cognitive-services/text-analytics/language-support"/>.
        /// For document length limits, maximum batch size, and supported text encoding, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/overview#data-limits"/>.
        /// </summary>
        /// <param name="documents">The documents to analyze.</param>
        /// <param name="language">The language that all the documents are
        /// written in. If unspecified, this value will be set to the default
        /// language in <see cref="TextAnalyticsClientOptions"/> in the request
        /// sent to the service.  If set to an empty string, the service will apply a model
        /// where the language is explicitly set to "None".</param>
        /// <param name="options"><see cref="TextAnalyticsRequestOptions"/> used to
        /// select the version of the predictive model to run, and whether
        /// statistics are returned in the response.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>
        /// controlling the request lifetime.</param>
        /// <returns>A result containing the collection of key phrases identified
        /// in each of the documents.</returns>
        /// <exception cref="RequestFailedException">Service returned a non-success
        /// status code.</exception>
        public virtual Response<ExtractKeyPhrasesResultCollection> ExtractKeyPhrasesBatch(IEnumerable<string> documents, string language = default, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            List<TextDocumentInput> documentInputs = ConvertToDocumentInputs(documents, language);
            options ??= new TextAnalyticsRequestOptions();

            return ExtractKeyPhrasesBatch(documentInputs, options, cancellationToken);
        }

        /// <summary>
        /// Runs a model to identify a collection of significant phrases
        /// found in the passed-in documents.
        /// For example, for the document "The food was delicious and there
        /// were wonderful staff", the API returns the main talking points: "food"
        /// and "wonderful staff".
        /// For a list of languages supported by this operation, see
        /// <a href="https://docs.microsoft.com/en-us/azure/cognitive-services/text-analytics/language-support"/>.
        /// For document length limits, maximum batch size, and supported text encoding, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/overview#data-limits"/>.
        /// </summary>
        /// <param name="documents">The documents to analyze.</param>
        /// <param name="options"><see cref="TextAnalyticsRequestOptions"/> used to
        /// select the version of the predictive model to run, and whether
        /// statistics are returned in the response.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>
        /// controlling the request lifetime.</param>
        /// <returns>A result containing the collection of key phrases identified
        /// in each of the documents.</returns>
        /// <exception cref="RequestFailedException">Service returned a non-success
        /// status code.</exception>
        public virtual async Task<Response<ExtractKeyPhrasesResultCollection>> ExtractKeyPhrasesBatchAsync(IEnumerable<TextDocumentInput> documents, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            options ??= new TextAnalyticsRequestOptions();

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(ExtractKeyPhrasesBatch)}");
            scope.Start();

            try
            {
                using Request request = CreateDocumentInputRequest(documents, options, KeyPhrasesRoute);
                Response response = await _pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);

                switch (response.Status)
                {
                    case 200:
                        IDictionary<string, int> map = CreateIdToIndexMap(documents);
                        ExtractKeyPhrasesResultCollection results = await CreateKeyPhraseResponseAsync(response, map, cancellationToken).ConfigureAwait(false);
                        return Response.FromValue(results, response);
                    default:
                        throw _clientDiagnostics.CreateRequestFailedException(response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Runs a model to identify a collection of significant phrases
        /// found in the passed-in documents.
        /// For example, for the document "The food was delicious and there
        /// were wonderful staff", the API returns the main talking points: "food"
        /// and "wonderful staff".
        /// For a list of languages supported by this operation, see
        /// <a href="https://docs.microsoft.com/en-us/azure/cognitive-services/text-analytics/language-support"/>.
        /// For document length limits, maximum batch size, and supported text encoding, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/overview#data-limits"/>.
        /// </summary>
        /// <param name="documents">The documents to analyze.</param>
        /// <param name="options"><see cref="TextAnalyticsRequestOptions"/> used to
        /// select the version of the predictive model to run, and whether
        /// statistics are returned in the response.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>
        /// controlling the request lifetime.</param>
        /// <returns>A result containing the collection of key phrases identified
        /// in each of the documents.</returns>
        /// <exception cref="RequestFailedException">Service returned a non-success
        /// status code.</exception>
        public virtual Response<ExtractKeyPhrasesResultCollection> ExtractKeyPhrasesBatch(IEnumerable<TextDocumentInput> documents, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            options ??= new TextAnalyticsRequestOptions();

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(ExtractKeyPhrasesBatch)}");
            scope.Start();

            try
            {
                using Request request = CreateDocumentInputRequest(documents, options, KeyPhrasesRoute);
                Response response = _pipeline.SendRequest(request, cancellationToken);

                switch (response.Status)
                {
                    case 200:
                        IDictionary<string, int> map = CreateIdToIndexMap(documents);
                        ExtractKeyPhrasesResultCollection results = CreateKeyPhraseResponse(response, map);
                        return Response.FromValue(results, response);
                    default:
                        throw _clientDiagnostics.CreateRequestFailedException(response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        #endregion

        #region Linked Entities

        /// <summary>
        /// Runs a predictive model to identify a collection of entities
        /// found in the passed-in document, and include information linking the
        /// entities to their corresponding entries in a well-known knowledge base.
        /// For a list of languages supported by this operation, see
        /// <a href="https://docs.microsoft.com/en-us/azure/cognitive-services/text-analytics/language-support"/>.
        /// For document length limits, maximum batch size, and supported text encoding, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/overview#data-limits"/>.
        /// </summary>
        /// <param name="document">The document to analyze.</param>
        /// <param name="language">The language that the document is written in.
        /// If unspecified, this value will be set to the default language in
        /// <see cref="TextAnalyticsClientOptions"/> in the request sent to the
        /// service.  If set to an empty string, the service will apply a model
        /// where the language is explicitly set to "None".</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>
        /// controlling the request lifetime.</param>
        /// <returns>A result containing the collection of linked entities identified
        /// in the document, as well as scores indicating the confidence
        /// that the entity correctly matches the identified substring.</returns>
        /// <exception cref="RequestFailedException">Service returned a non-success
        /// status code.</exception>
        public virtual async Task<Response<LinkedEntityCollection>> RecognizeLinkedEntitiesAsync(string document, string language = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(document, nameof(document));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(RecognizeLinkedEntities)}");
            scope.AddAttribute("document", document);
            scope.Start();

            try
            {
                TextDocumentInput[] documents = new TextDocumentInput[] { ConvertToDocumentInput(document, language) };
                using Request request = CreateDocumentInputRequest(documents, new TextAnalyticsRequestOptions(), EntityLinkingRoute);
                Response response = await _pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);

                switch (response.Status)
                {
                    case 200:
                        IDictionary<string, int> map = CreateIdToIndexMap(documents);
                        RecognizeLinkedEntitiesResultCollection results = await CreateLinkedEntityResponseAsync(response, map, cancellationToken).ConfigureAwait(false);
                        if (results[0].HasError)
                        {
                            // only one document, so we can ignore the id and grab the first error message.
                            TextAnalyticsError error = results[0].Error;
                            throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response, error.Message, error.ErrorCode.ToString(), CreateAdditionalInformation(error)).ConfigureAwait(false);
                        }
                        return Response.FromValue((LinkedEntityCollection)results[0].Entities, response);
                    default:
                        throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Runs a predictive model to identify a collection of entities
        /// found in the passed-in document, and include information linking the
        /// entities to their corresponding entries in a well-known knowledge base.
        /// For a list of languages supported by this operation, see
        /// <a href="https://docs.microsoft.com/en-us/azure/cognitive-services/text-analytics/language-support"/>.
        /// For document length limits, maximum batch size, and supported text encoding, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/overview#data-limits"/>.
        /// </summary>
        /// <param name="document">The document to analyze.</param>
        /// <param name="language">The language that the document is written in.
        /// If unspecified, this value will be set to the default language in
        /// <see cref="TextAnalyticsClientOptions"/> in the request sent to the
        /// service.  If set to an empty string, the service will apply a model
        /// where the language is explicitly set to "None".</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>
        /// controlling the request lifetime.</param>
        /// <returns>A result containing the collection of linked entities identified
        /// in the document, as well as scores indicating the confidence
        /// that the entity correctly matches the identified substring.</returns>
        /// <exception cref="RequestFailedException">Service returned a non-success
        /// status code.</exception>
        public virtual Response<LinkedEntityCollection> RecognizeLinkedEntities(string document, string language = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(document, nameof(document));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(RecognizeLinkedEntities)}");
            scope.AddAttribute("document", document);
            scope.Start();

            try
            {
                TextDocumentInput[] documents = new TextDocumentInput[] { ConvertToDocumentInput(document, language) };
                using Request request = CreateDocumentInputRequest(documents, new TextAnalyticsRequestOptions(), EntityLinkingRoute);
                Response response = _pipeline.SendRequest(request, cancellationToken);

                switch (response.Status)
                {
                    case 200:
                        IDictionary<string, int> map = CreateIdToIndexMap(documents);
                        RecognizeLinkedEntitiesResultCollection results = CreateLinkedEntityResponse(response, map);
                        if (results[0].HasError)
                        {
                            // only one document, so we can ignore the id and grab the first error message.
                            TextAnalyticsError error = results[0].Error;
                            throw _clientDiagnostics.CreateRequestFailedException(response, error.Message, error.ErrorCode.ToString(), CreateAdditionalInformation(error));
                        }
                        return Response.FromValue((LinkedEntityCollection)results[0].Entities, response);
                    default:
                        throw _clientDiagnostics.CreateRequestFailedException(response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Runs a predictive model to identify a collection of entities
        /// found in the passed-in documents, and include information linking the
        /// entities to their corresponding entries in a well-known knowledge base.
        /// For a list of languages supported by this operation, see
        /// <a href="https://docs.microsoft.com/en-us/azure/cognitive-services/text-analytics/language-support"/>.
        /// For document length limits, maximum batch size, and supported text encoding, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/overview#data-limits"/>.
        /// </summary>
        /// <param name="documents">The documents to analyze.</param>
        /// <param name="language">The language that the documents are written in.
        /// If unspecified, this value will be set to the default language in
        /// <see cref="TextAnalyticsClientOptions"/> in the request sent to the
        /// service.  If set to an empty string, the service will apply a model
        /// where the language is explicitly set to "None".</param>
        /// <param name="options"><see cref="TextAnalyticsRequestOptions"/> used to
        /// select the version of the predictive model to run, and whether
        /// statistics are returned in the response.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>
        /// controlling the request lifetime.</param>
        /// <returns>A result containing the collection of entities identified
        /// for each of the documents, as well as scores indicating the confidence
        /// that a given entity correctly matches the identified substring.</returns>
        /// <exception cref="RequestFailedException">Service returned a non-success
        /// status code.</exception>
        public virtual async Task<Response<RecognizeLinkedEntitiesResultCollection>> RecognizeLinkedEntitiesBatchAsync(IEnumerable<string> documents, string language = default, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            List<TextDocumentInput> documentInputs = ConvertToDocumentInputs(documents, language);
            options ??= new TextAnalyticsRequestOptions();

            return await RecognizeLinkedEntitiesBatchAsync(documentInputs, options, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Runs a predictive model to identify a collection of entities
        /// found in the passed-in documents, and include information linking the
        /// entities to their corresponding entries in a well-known knowledge base.
        /// For a list of languages supported by this operation, see
        /// <a href="https://docs.microsoft.com/en-us/azure/cognitive-services/text-analytics/language-support"/>.
        /// For document length limits, maximum batch size, and supported text encoding, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/overview#data-limits"/>.
        /// </summary>
        /// <param name="documents">The documents to analyze.</param>
        /// <param name="language">The language that the documents are written in.
        /// If unspecified, this value will be set to the default language in
        /// <see cref="TextAnalyticsClientOptions"/> in the request sent to the
        /// service.  If set to an empty string, the service will apply a model
        /// where the language is explicitly set to "None".</param>
        /// <param name="options"><see cref="TextAnalyticsRequestOptions"/> used to
        /// select the version of the predictive model to run, and whether
        /// statistics are returned in the response.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>
        /// controlling the request lifetime.</param>
        /// <returns>A result containing the collection of entities identified
        /// for each of the documents, as well as scores indicating the confidence
        /// that a given entity correctly matches the identified substring.</returns>
        /// <exception cref="RequestFailedException">Service returned a non-success
        /// status code.</exception>
        public virtual Response<RecognizeLinkedEntitiesResultCollection> RecognizeLinkedEntitiesBatch(IEnumerable<string> documents, string language = default, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            List<TextDocumentInput> documentInputs = ConvertToDocumentInputs(documents, language);
            options ??= new TextAnalyticsRequestOptions();

            return RecognizeLinkedEntitiesBatch(documentInputs, options, cancellationToken);
        }

        /// <summary>
        /// Runs a predictive model to identify a collection of entities
        /// found in the passed-in documents, and include information linking the
        /// entities to their corresponding entries in a well-known knowledge base.
        /// For a list of languages supported by this operation, see
        /// <a href="https://docs.microsoft.com/en-us/azure/cognitive-services/text-analytics/language-support"/>.
        /// For document length limits, maximum batch size, and supported text encoding, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/overview#data-limits"/>.
        /// </summary>
        /// <param name="documents">The documents to analyze.</param>
        /// <param name="options"><see cref="TextAnalyticsRequestOptions"/> used to
        /// select the version of the predictive model to run, and whether
        /// statistics are returned in the response.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>
        /// controlling the request lifetime.</param>
        /// <returns>A result containing the collection of entities identified
        /// for each of the documents, as well as scores indicating the confidence
        /// that a given entity correctly matches the identified substring.</returns>
        /// <exception cref="RequestFailedException">Service returned a non-success
        /// status code.</exception>
        public virtual async Task<Response<RecognizeLinkedEntitiesResultCollection>> RecognizeLinkedEntitiesBatchAsync(IEnumerable<TextDocumentInput> documents, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            options ??= new TextAnalyticsRequestOptions();

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(RecognizeLinkedEntitiesBatch)}");
            scope.Start();

            try
            {
                using Request request = CreateDocumentInputRequest(documents, options, EntityLinkingRoute);
                Response response = await _pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);

                switch (response.Status)
                {
                    case 200:
                        IDictionary<string, int> map = CreateIdToIndexMap(documents);
                        RecognizeLinkedEntitiesResultCollection results = await CreateLinkedEntityResponseAsync(response, map, cancellationToken).ConfigureAwait(false);
                        return Response.FromValue(results, response);
                    default:
                        throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response).ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Runs a predictive model to identify a collection of entities
        /// found in the passed-in documents, and include information linking the
        /// entities to their corresponding entries in a well-known knowledge base.
        /// For a list of languages supported by this operation, see
        /// <a href="https://docs.microsoft.com/en-us/azure/cognitive-services/text-analytics/language-support"/>.
        /// For document length limits, maximum batch size, and supported text encoding, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/overview#data-limits"/>.
        /// </summary>
        /// <param name="documents">The documents to analyze.</param>
        /// <param name="options"><see cref="TextAnalyticsRequestOptions"/> used to
        /// select the version of the predictive model to run, and whether
        /// statistics are returned in the response.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>
        /// controlling the request lifetime.</param>
        /// <returns>A result containing the collection of entities identified
        /// for each of the documents, as well as scores indicating the confidence
        /// that a given entity correctly matches the identified substring.</returns>
        /// <exception cref="RequestFailedException">Service returned a non-success
        /// status code.</exception>
        public virtual Response<RecognizeLinkedEntitiesResultCollection> RecognizeLinkedEntitiesBatch(IEnumerable<TextDocumentInput> documents, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            options ??= new TextAnalyticsRequestOptions();

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(RecognizeLinkedEntitiesBatch)}");
            scope.Start();

            try
            {
                using Request request = CreateDocumentInputRequest(documents, options, EntityLinkingRoute);
                Response response = _pipeline.SendRequest(request, cancellationToken);

                switch (response.Status)
                {
                    case 200:
                        IDictionary<string, int> map = CreateIdToIndexMap(documents);
                        RecognizeLinkedEntitiesResultCollection results = CreateLinkedEntityResponse(response, map);
                        return Response.FromValue(results, response);
                    default:
                        throw _clientDiagnostics.CreateRequestFailedException(response);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        #endregion

        #region Common

        private static IDictionary<string, int> CreateIdToIndexMap<T>(IEnumerable<T> documents)
        {
            var map = new Dictionary<string, int>(documents.Count());

            int i = 0;
            foreach (T item in documents)
            {
                string id = item switch
                {
                    TextDocumentInput tdi => tdi.Id,
                    LanguageInput ldi => ldi.Id,
                    _ => throw new NotSupportedException(),
                };

                map[id] = i++;
            }

            return map;
        }

        internal virtual TextDocumentInput ConvertToDocumentInput(string document, string language, int id = 0)
            => new TextDocumentInput($"{id}", document) { Language = language ?? _options.DefaultLanguage };

        private List<TextDocumentInput> ConvertToDocumentInputs(IEnumerable<string> documents, string language)
            => documents.Select((document, i) => ConvertToDocumentInput(document, language, i)).ToList();

        private LanguageInput ConvertToLanguageInput(string document, string countryHint, int id = 0)
            => new LanguageInput($"{id}", document) { CountryHint = countryHint ?? _options.DefaultCountryHint };

        private LanguageBatchInput ConvertToLanguageInputs(IEnumerable<string> documents, string countryHint)
            => new LanguageBatchInput(documents.Select((document, i) => ConvertToLanguageInput(document, countryHint, i)).ToList());

        private LanguageBatchInput ConvertToLanguageInputs(IEnumerable<DetectLanguageInput> documents)
            => new LanguageBatchInput(documents.Select((document) => new LanguageInput(document.Id, document.Text) { CountryHint = document.CountryHint }).ToList());

        private Request CreateDocumentInputRequest(IEnumerable<TextDocumentInput> documents, TextAnalyticsRequestOptions options, string route)
        {
            Request request = _pipeline.CreateRequest();

            ReadOnlyMemory<byte> content = TextAnalyticsServiceSerializer.SerializeDocumentInputs(documents, _options.DefaultLanguage);

            request.Method = RequestMethod.Post;
            BuildUriForRoute(route, request.Uri, options);

            request.Headers.Add(HttpHeader.Common.JsonContentType);
            request.Content = RequestContent.Create(content);

            return request;
        }

        private IDictionary<string,string> CreateAdditionalInformation(TextAnalyticsError error)
        {
            if (string.IsNullOrEmpty(error.Target))
                return null;
            return new Dictionary<string, string> { { "Target", error.Target } };
        }

        #endregion
    }
}
