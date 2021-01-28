// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.TextAnalytics.Models;
using Azure.Core;
using Azure.Core.Pipeline;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.AI.TextAnalytics
{
    /// <summary>
    /// The client to use for interacting with the Azure Cognitive Service, Text Analytics.
    /// </summary>
    public class TextAnalyticsClient
    {
        private readonly Uri _baseUri;
        internal readonly TextAnalyticsRestClient _serviceRestClient;
        internal readonly ClientDiagnostics _clientDiagnostics;
        private readonly TextAnalyticsClientOptions _options;
        private readonly string DefaultCognitiveScope = "https://cognitiveservices.azure.com/.default";
        private const string AuthorizationHeader = "Ocp-Apim-Subscription-Key";

        // Specifies the method used to interpret string offsets. Default to <see cref="StringIndexType.Utf16CodeUnit"/>.
        private readonly StringIndexType _stringCodeUnit = StringIndexType.Utf16CodeUnit;

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
            _clientDiagnostics = new ClientDiagnostics(options);
            _options = options;

            var pipeline = HttpPipelineBuilder.Build(options, new BearerTokenAuthenticationPolicy(credential, DefaultCognitiveScope));
            _serviceRestClient = new TextAnalyticsRestClient(_clientDiagnostics, pipeline, endpoint.AbsoluteUri);
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
            _clientDiagnostics = new ClientDiagnostics(options);
            _options = options;

            var pipeline = HttpPipelineBuilder.Build(options, new AzureKeyCredentialPolicy(credential, AuthorizationHeader));
            _serviceRestClient = new TextAnalyticsRestClient(_clientDiagnostics, pipeline, endpoint.AbsoluteUri);
        }

        #region Detect Language

        /// <summary>
        /// Runs a predictive model to determine the language the passed-in
        /// document is written in, and returns the detected language as well
        /// as a score indicating the model's confidence that the inferred
        /// language is correct. Scores close to 1 indicate high certainty in
        /// the result.
        /// <para>For document length limits, maximum batch size, and supported text encoding, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/overview#data-limits"/>.</para>
        /// </summary>
        /// <param name="document">The document to analyze.</param>
        /// <param name="countryHint">Indicates the country of origin of the
        /// document to assist the Text Analytics model in predicting the language
        /// it is written in. If unspecified, this value will be set to the
        /// default country hint in <see cref="TextAnalyticsClientOptions.DefaultCountryHint"/>
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
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response, error.Message, error.ErrorCode.ToString(), CreateAdditionalInformation(error)).ConfigureAwait(false);
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
        /// language is correct. Scores close to 1 indicate high certainty in
        /// the result.
        /// <para>For document length limits, maximum batch size, and supported text encoding, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/overview#data-limits"/>.</para>
        /// </summary>
        /// <param name="document">The document to analyze.</param>
        /// <param name="countryHint">Indicates the country of origin of the
        /// document to assist the Text Analytics model in predicting the language
        /// it is written in. If unspecified, this value will be set to the
        /// default country hint in <see cref="TextAnalyticsClientOptions.DefaultCountryHint"/>
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
        /// the inferred language is correct. Scores close to 1 indicate high
        /// certainty in the result.
        /// <para>For document length limits, maximum batch size, and supported text encoding, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/overview#data-limits"/>.</para>
        /// </summary>
        /// <param name="documents">A collection of documents to analyze.</param>
        /// <param name="countryHint">Indicates the country of origin of all of
        /// the documents to assist the Text Analytics model in predicting
        /// the language they are written in. If unspecified, this value will be
        /// set to the default country hint in <see cref="TextAnalyticsClientOptions.DefaultCountryHint"/>
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
            options ??= new TextAnalyticsRequestOptions();
            LanguageBatchInput detectLanguageInputs = ConvertToLanguageInputs(documents, countryHint);

            return await DetectLanguageBatchAsync(detectLanguageInputs, options, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Runs a predictive model to determine the language the passed-in
        /// documents are written in, and returns, for each one, the detected
        /// language as well as a score indicating the model's confidence that
        /// the inferred language is correct. Scores close to 1 indicate high
        /// certainty in the result.
        /// <para>For document length limits, maximum batch size, and supported text encoding, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/overview#data-limits"/>.</para>
        /// </summary>
        /// <param name="documents">A collection of documents to analyze.</param>
        /// <param name="countryHint">Indicates the country of origin of all of
        /// the documents to assist the Text Analytics model in predicting
        /// the language they are written in. If unspecified, this value will be
        /// set to the default country hint in <see cref="TextAnalyticsClientOptions.DefaultCountryHint"/>
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
            options ??= new TextAnalyticsRequestOptions();
            LanguageBatchInput detectLanguageInputs = ConvertToLanguageInputs(documents, countryHint);

            return DetectLanguageBatch(detectLanguageInputs, options, cancellationToken);
        }

        /// <summary>
        /// Runs a predictive model to determine the language the passed-in
        /// documents are written in, and returns, for each one, the detected
        /// language as well as a score indicating the model's confidence that
        /// the inferred language is correct. Scores close to 1 indicate high
        /// certainty in the result.
        /// <para>For document length limits, maximum batch size, and supported text encoding, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/overview#data-limits"/>.</para>
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
            options ??= new TextAnalyticsRequestOptions();
            LanguageBatchInput detectLanguageInputs = ConvertToLanguageInputs(documents);

            return await DetectLanguageBatchAsync(detectLanguageInputs, options, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Runs a predictive model to determine the language the passed-in
        /// documents are written in, and returns, for each one, the detected
        /// language as well as a score indicating the model's confidence that
        /// the inferred language is correct. Scores close to 1 indicate high
        /// certainty in the result.
        /// <para>For document length limits, maximum batch size, and supported text encoding, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/overview#data-limits"/>.</para>
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

                IDictionary<string, int> map = CreateIdToIndexMap(batchInput.Documents);
                DetectLanguageResultCollection results = Transforms.ConvertToDetectLanguageResultCollection(result.Value, map);
                return Response.FromValue(results, response);
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

                IDictionary<string, int> map = CreateIdToIndexMap(batchInput.Documents);
                DetectLanguageResultCollection results = Transforms.ConvertToDetectLanguageResultCollection(result.Value, map);
                return Response.FromValue(results, response);
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
        /// such as person, location, or organization.
        /// <para>For more information on available categories, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/Text-Analytics/named-entity-types"/>.</para>
        /// <para>For a list of languages supported by this operation, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/language-support"/>.</para>
        /// <para>For document length limits, maximum batch size, and supported text encoding, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/overview#data-limits"/>.</para>
        /// </summary>
        /// <param name="document">The document to analyze.</param>
        /// <param name="language">The language that the document is written in.
        /// If unspecified, this value will be set to the default language in
        /// <see cref="TextAnalyticsClientOptions.DefaultLanguage"/> in the request sent to the
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
                var documents = new List<MultiLanguageInput>() { ConvertToMultiLanguageInput(document, language) };

                Response<EntitiesResult> result = await _serviceRestClient.EntitiesRecognitionGeneralAsync(
                    new MultiLanguageBatchInput(documents),
                    stringIndexType: _stringCodeUnit,
                    cancellationToken: cancellationToken).ConfigureAwait(false);
                Response response = result.GetRawResponse();

                if (result.Value.Errors.Count > 0)
                {
                    // only one document, so we can ignore the id and grab the first error message.
                    var error = Transforms.ConvertToError(result.Value.Errors[0].Error);
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response, error.Message, error.ErrorCode.ToString(), CreateAdditionalInformation(error)).ConfigureAwait(false);
                }

                return Response.FromValue(Transforms.ConvertToCategorizedEntityCollection(result.Value.Documents[0]), response);
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
        /// such as person, location, or organization.
        /// <para>For more information on available categories, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/Text-Analytics/named-entity-types"/>.</para>
        /// <para>For a list of languages supported by this operation, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/language-support"/>.</para>
        /// <para>For document length limits, maximum batch size, and supported text encoding, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/overview#data-limits"/>.</para>
        /// </summary>
        /// <param name="document">The document to analyze.</param>
        /// <param name="language">The language that the document is written in.
        /// If unspecified, this value will be set to the default language in
        /// <see cref="TextAnalyticsClientOptions.DefaultLanguage"/> in the request sent to the
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
                var documents = new List<MultiLanguageInput>() { ConvertToMultiLanguageInput(document, language) };

                Response<EntitiesResult> result = _serviceRestClient.EntitiesRecognitionGeneral(
                    new MultiLanguageBatchInput(documents),
                    stringIndexType: _stringCodeUnit,
                    cancellationToken: cancellationToken);
                Response response = result.GetRawResponse();

                if (result.Value.Errors.Count > 0)
                {
                    // only one document, so we can ignore the id and grab the first error message.
                    var error = Transforms.ConvertToError(result.Value.Errors[0].Error);
                    throw _clientDiagnostics.CreateRequestFailedException(response, error.Message, error.ErrorCode.ToString(), CreateAdditionalInformation(error));
                }

                return Response.FromValue(Transforms.ConvertToCategorizedEntityCollection(result.Value.Documents[0]), response);
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
        /// <para>For more information on available categories, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/Text-Analytics/named-entity-types"/>.</para>
        /// <para>For a list of languages supported by this operation, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/language-support"/>.</para>
        /// <para>For document length limits, maximum batch size, and supported text encoding, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/overview#data-limits"/>.</para>
        /// </summary>
        /// <param name="documents">The documents to analyze.</param>
        /// <param name="language">The language that all the documents are
        /// written in. If unspecified, this value will be set to the default
        /// language in <see cref="TextAnalyticsClientOptions.DefaultLanguage"/> in the request
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
            options ??= new TextAnalyticsRequestOptions();
            MultiLanguageBatchInput documentInputs = ConvertToMultiLanguageInputs(documents, language);

            return await RecognizeEntitiesBatchAsync(documentInputs, options, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Runs a predictive model to identify a collection of named entities
        /// in the passed-in documents, and categorize those entities into types
        /// such as person, location, or organization.
        /// <para>For more information on available categories, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/Text-Analytics/named-entity-types"/>.</para>
        /// <para>For a list of languages supported by this operation, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/language-support"/>.</para>
        /// <para>For document length limits, maximum batch size, and supported text encoding, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/overview#data-limits"/>.</para>
        /// </summary>
        /// <param name="documents">The documents to analyze.</param>
        /// <param name="language">The language that all the documents are
        /// written in. If unspecified, this value will be set to the default
        /// language in <see cref="TextAnalyticsClientOptions.DefaultLanguage"/> in the request
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
            options ??= new TextAnalyticsRequestOptions();
            MultiLanguageBatchInput documentInputs = ConvertToMultiLanguageInputs(documents, language);

            return RecognizeEntitiesBatch(documentInputs, options, cancellationToken);
        }

        /// <summary>
        /// Runs a predictive model to identify a collection of named entities
        /// in the passed-in documents, and categorize those entities into types
        /// such as person, location, or organization.
        /// <para>For more information on available categories, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/Text-Analytics/named-entity-types"/>.</para>
        /// <para>For a list of languages supported by this operation, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/language-support"/>.</para>
        /// <para>For document length limits, maximum batch size, and supported text encoding, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/overview#data-limits"/>.</para>
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
            MultiLanguageBatchInput documentInputs = ConvertToMultiLanguageInputs(documents);

            return await RecognizeEntitiesBatchAsync(documentInputs, options, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Runs a predictive model to identify a collection of named entities
        /// in the passed-in documents, and categorize those entities into types
        /// such as person, location, or organization.
        /// <para>For more information on available categories, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/Text-Analytics/named-entity-types"/>.</para>
        /// <para>For a list of languages supported by this operation, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/language-support"/>.</para>
        /// <para>For document length limits, maximum batch size, and supported text encoding, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/overview#data-limits"/>.</para>
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
            MultiLanguageBatchInput documentInputs = ConvertToMultiLanguageInputs(documents);

            return RecognizeEntitiesBatch(documentInputs, options, cancellationToken);
        }

        private async Task<Response<RecognizeEntitiesResultCollection>> RecognizeEntitiesBatchAsync(MultiLanguageBatchInput batchInput, TextAnalyticsRequestOptions options, CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(RecognizeEntitiesBatch)}");
            scope.Start();

            try
            {
                Response<EntitiesResult> result = await _serviceRestClient.EntitiesRecognitionGeneralAsync(
                    batchInput,
                    options.ModelVersion,
                    options.IncludeStatistics,
                    _stringCodeUnit,
                    cancellationToken).ConfigureAwait(false);
                var response = result.GetRawResponse();

                IDictionary<string, int> map = CreateIdToIndexMap(batchInput.Documents);
                RecognizeEntitiesResultCollection results = Transforms.ConvertToRecognizeEntitiesResultCollection(result.Value, map);
                return Response.FromValue(results, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private Response<RecognizeEntitiesResultCollection> RecognizeEntitiesBatch(MultiLanguageBatchInput batchInput, TextAnalyticsRequestOptions options, CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(RecognizeEntitiesBatch)}");
            scope.Start();

            try
            {
                Response<EntitiesResult> result = _serviceRestClient.EntitiesRecognitionGeneral(
                    batchInput,
                    options.ModelVersion,
                    options.IncludeStatistics,
                    _stringCodeUnit,
                    cancellationToken);
                var response = result.GetRawResponse();

                IDictionary<string, int> map = CreateIdToIndexMap(batchInput.Documents);
                RecognizeEntitiesResultCollection results = Transforms.ConvertToRecognizeEntitiesResultCollection(result.Value, map);
                return Response.FromValue(results, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        #endregion

        #region Recognize PII Entities

        /// <summary>
        /// Runs a predictive model to identify a collection of entities containing
        /// Personally Identifiable Information found in the passed-in document,
        /// and categorize those entities into types such as US social security
        /// number, drivers license number, or credit card number.
        /// <para>For more information on available categories, see
        /// <a href="https://aka.ms/tanerpii"/>.</para>
        /// <para>For a list of languages supported by this operation, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/language-support"/>.</para>
        /// <para>For document length limits, maximum batch size, and supported text encoding, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/overview#data-limits"/>.</para>
        /// </summary>
        /// <param name="document">The document to analyze.</param>
        /// <param name="language">The language that the document is written in.
        /// If unspecified, this value will be set to the default language in
        /// <see cref="TextAnalyticsClientOptions.DefaultLanguage"/> in the request sent to the
        /// service.  If set to an empty string, the service will apply a model
        /// where the language is explicitly set to "None".</param>
        /// <param name="options">The additional configurable <see cref="RecognizePiiEntitiesOptions"/> that may be passed when
        /// recognizing PII entities. Options include entity domain filters, model version, and more.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>
        /// controlling the request lifetime.</param>
        /// <returns>A result containing the collection of entities identified
        /// in the document, as well as a score indicating the confidence
        /// that the entity correctly matches the identified substring.</returns>
        /// <exception cref="RequestFailedException">Service returned a non-success
        /// status code.</exception>
        public virtual async Task<Response<PiiEntityCollection>> RecognizePiiEntitiesAsync(string document, string language = default, RecognizePiiEntitiesOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(document, nameof(document));
            options ??= new RecognizePiiEntitiesOptions();

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(RecognizePiiEntities)}");
            scope.AddAttribute("document", document);
            scope.Start();

            try
            {
                var documents = new List<MultiLanguageInput>() { ConvertToMultiLanguageInput(document, language) };

                Response<PiiEntitiesResult> result = await _serviceRestClient.EntitiesRecognitionPiiAsync(
                    new MultiLanguageBatchInput(documents),
                    options.ModelVersion,
                    options.IncludeStatistics,
                    options.DomainFilter.GetString(),
                    _stringCodeUnit,
                    cancellationToken: cancellationToken).ConfigureAwait(false);
                Response response = result.GetRawResponse();

                if (result.Value.Errors.Count > 0)
                {
                    // only one document, so we can ignore the id and grab the first error message.
                    var error = Transforms.ConvertToError(result.Value.Errors[0].Error);
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response, error.Message, error.ErrorCode.ToString(), CreateAdditionalInformation(error)).ConfigureAwait(false);
                }

                return Response.FromValue(Transforms.ConvertToPiiEntityCollection(result.Value.Documents[0]), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Runs a predictive model to identify a collection of entities containing
        /// Personally Identifiable Information found in the passed-in document,
        /// and categorize those entities into types such as US social security
        /// number, drivers license number, or credit card number.
        /// <para>For more information on available categories, see
        /// <a href="https://aka.ms/tanerpii"/>.</para>
        /// <para>For a list of languages supported by this operation, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/language-support"/>.</para>
        /// <para>For document length limits, maximum batch size, and supported text encoding, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/overview#data-limits"/>.</para>
        /// </summary>
        /// <param name="document">The document to analyze.</param>
        /// <param name="language">The language that the document is written in.
        /// If unspecified, this value will be set to the default language in
        /// <see cref="TextAnalyticsClientOptions.DefaultLanguage"/> in the request sent to the
        /// service.  If set to an empty string, the service will apply a model
        /// where the language is explicitly set to "None".</param>
        /// <param name="options">The additional configurable <see cref="RecognizePiiEntitiesOptions"/> that may be passed when
        /// recognizing PII entities. Options include entity domain filters, model version, and more.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>
        /// controlling the request lifetime.</param>
        /// <returns>A result containing the collection of entities identified
        /// in the document, as well as a score indicating the confidence
        /// that the entity correctly matches the identified substring.</returns>
        /// <exception cref="RequestFailedException">Service returned a non-success
        /// status code.</exception>
        public virtual Response<PiiEntityCollection> RecognizePiiEntities(string document, string language = default, RecognizePiiEntitiesOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(document, nameof(document));
            options ??= new RecognizePiiEntitiesOptions();

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(RecognizePiiEntities)}");
            scope.AddAttribute("document", document);
            scope.Start();

            try
            {
                var documents = new List<MultiLanguageInput>() { ConvertToMultiLanguageInput(document, language) };

                Response<PiiEntitiesResult> result = _serviceRestClient.EntitiesRecognitionPii(
                    new MultiLanguageBatchInput(documents),
                    options.ModelVersion,
                    options.IncludeStatistics,
                    options.DomainFilter.GetString(),
                    _stringCodeUnit,
                    cancellationToken: cancellationToken);
                Response response = result.GetRawResponse();

                if (result.Value.Errors.Count > 0)
                {
                    // only one document, so we can ignore the id and grab the first error message.
                    var error = Transforms.ConvertToError(result.Value.Errors[0].Error);
                    throw _clientDiagnostics.CreateRequestFailedException(response, error.Message, error.ErrorCode.ToString(), CreateAdditionalInformation(error));
                }

                return Response.FromValue(Transforms.ConvertToPiiEntityCollection(result.Value.Documents[0]), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Runs a predictive model to identify a collection of entities containing
        /// Personally Identifiable Information found in the passed-in document,
        /// and categorize those entities into types such as US social security
        /// number, drivers license number, or credit card number.
        /// <para>For more information on available categories, see
        /// <a href="https://aka.ms/tanerpii"/>.</para>
        /// <para>For a list of languages supported by this operation, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/language-support"/>.</para>
        /// <para>For document length limits, maximum batch size, and supported text encoding, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/overview#data-limits"/>.</para>
        /// </summary>
        /// <param name="documents">The documents to analyze.</param>
        /// <param name="language">The language that the document is written in.
        /// If unspecified, this value will be set to the default language in
        /// <see cref="TextAnalyticsClientOptions.DefaultLanguage"/> in the request sent to the
        /// service.  If set to an empty string, the service will apply a model
        /// where the language is explicitly set to "None".</param>
        /// <param name="options">The additional configurable <see cref="RecognizePiiEntitiesOptions"/> that may be passed when
        /// recognizing PII entities. Options include entity domain filters, model version, and more.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>
        /// controlling the request lifetime.</param>
        /// <returns>A result containing the collection of entities identified
        /// for each of the documents, as well as scores indicating the confidence
        /// that a given entity correctly matches the identified substring.</returns>
        /// <exception cref="RequestFailedException">Service returned a non-success
        /// status code.</exception>
        public virtual async Task<Response<RecognizePiiEntitiesResultCollection>> RecognizePiiEntitiesBatchAsync(IEnumerable<string> documents, string language = default, RecognizePiiEntitiesOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            options ??= new RecognizePiiEntitiesOptions();
            MultiLanguageBatchInput documentInputs = ConvertToMultiLanguageInputs(documents, language);

            return await RecognizePiiEntitiesBatchAsync(documentInputs, options, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Runs a predictive model to identify a collection of entities containing
        /// Personally Identifiable Information found in the passed-in document,
        /// and categorize those entities into types such as US social security
        /// number, drivers license number, or credit card number.
        /// <para>For more information on available categories, see
        /// <a href="https://aka.ms/tanerpii"/>.</para>
        /// <para>For a list of languages supported by this operation, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/language-support"/>.</para>
        /// <para>For document length limits, maximum batch size, and supported text encoding, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/overview#data-limits"/>.</para>
        /// </summary>
        /// <param name="documents">The documents to analyze.</param>
        /// <param name="language">The language that the document is written in.
        /// If unspecified, this value will be set to the default language in
        /// <see cref="TextAnalyticsClientOptions.DefaultLanguage"/> in the request sent to the
        /// service.  If set to an empty string, the service will apply a model
        /// where the language is explicitly set to "None".</param>
        /// <param name="options">The additional configurable <see cref="RecognizePiiEntitiesOptions"/> that may be passed when
        /// recognizing PII entities. Options include entity domain filters, model version, and more.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>
        /// controlling the request lifetime.</param>
        /// <returns>A result containing the collection of entities identified
        /// for each of the documents, as well as scores indicating the confidence
        /// that a given entity correctly matches the identified substring.</returns>
        /// <exception cref="RequestFailedException">Service returned a non-success
        /// status code.</exception>
        public virtual Response<RecognizePiiEntitiesResultCollection> RecognizePiiEntitiesBatch(IEnumerable<string> documents, string language = default, RecognizePiiEntitiesOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            options ??= new RecognizePiiEntitiesOptions();
            MultiLanguageBatchInput documentInputs = ConvertToMultiLanguageInputs(documents, language);

            return RecognizePiiEntitiesBatch(documentInputs, options, cancellationToken);
        }

        /// <summary>
        /// Runs a predictive model to identify a collection of entities containing
        /// Personally Identifiable Information found in the passed-in document,
        /// and categorize those entities into types such as US social security
        /// number, drivers license number, or credit card number.
        /// <para>For more information on available categories, see
        /// <a href="https://aka.ms/tanerpii"/>.</para>
        /// <para>For a list of languages supported by this operation, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/language-support"/>.</para>
        /// <para>For document length limits, maximum batch size, and supported text encoding, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/overview#data-limits"/>.</para>
        /// </summary>
        /// <param name="documents">The documents to analyze.</param>
        /// <param name="options">The additional configurable <see cref="RecognizePiiEntitiesOptions"/> that may be passed when
        /// recognizing PII entities. Options include entity domain filters, model version, and more.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>
        /// controlling the request lifetime.</param>
        /// <returns>A result containing the collection of entities identified
        /// for each of the documents, as well as scores indicating the confidence
        /// that a given entity correctly matches the identified substring.</returns>
        /// <exception cref="RequestFailedException">Service returned a non-success
        /// status code.</exception>
        public virtual async Task<Response<RecognizePiiEntitiesResultCollection>> RecognizePiiEntitiesBatchAsync(IEnumerable<TextDocumentInput> documents, RecognizePiiEntitiesOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            options ??= new RecognizePiiEntitiesOptions();
            MultiLanguageBatchInput documentInputs = ConvertToMultiLanguageInputs(documents);

            return await RecognizePiiEntitiesBatchAsync(documentInputs, options, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Runs a predictive model to identify a collection of entities containing
        /// Personally Identifiable Information found in the passed-in document,
        /// and categorize those entities into types such as US social security
        /// number, drivers license number, or credit card number.
        /// <para>For more information on available categories, see
        /// <a href="https://aka.ms/tanerpii"/>.</para>
        /// <para>For a list of languages supported by this operation, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/language-support"/>.</para>
        /// <para>For document length limits, maximum batch size, and supported text encoding, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/overview#data-limits"/>.</para>
        /// </summary>
        /// <param name="documents">The documents to analyze.</param>
        /// <param name="options">The additional configurable <see cref="RecognizePiiEntitiesOptions"/> that may be passed when
        /// recognizing PII entities. Options include entity domain filters, model version, and more.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>
        /// controlling the request lifetime.</param>
        /// <returns>A result containing the collection of entities identified
        /// for each of the documents, as well as scores indicating the confidence
        /// that a given entity correctly matches the identified substring.</returns>
        /// <exception cref="RequestFailedException">Service returned a non-success
        /// status code.</exception>
        public virtual Response<RecognizePiiEntitiesResultCollection> RecognizePiiEntitiesBatch(IEnumerable<TextDocumentInput> documents, RecognizePiiEntitiesOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            options ??= new RecognizePiiEntitiesOptions();
            MultiLanguageBatchInput documentInputs = ConvertToMultiLanguageInputs(documents);

            return RecognizePiiEntitiesBatch(documentInputs, options, cancellationToken);
        }

        private async Task<Response<RecognizePiiEntitiesResultCollection>> RecognizePiiEntitiesBatchAsync(MultiLanguageBatchInput batchInput, RecognizePiiEntitiesOptions options, CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(RecognizePiiEntitiesBatch)}");
            scope.Start();

            try
            {
                Response<PiiEntitiesResult> result = await _serviceRestClient.EntitiesRecognitionPiiAsync(
                    batchInput,
                    options.ModelVersion,
                    options.IncludeStatistics,
                    options.DomainFilter.GetString(),
                    _stringCodeUnit,
                    cancellationToken).ConfigureAwait(false);
                var response = result.GetRawResponse();

                IDictionary<string, int> map = CreateIdToIndexMap(batchInput.Documents);
                RecognizePiiEntitiesResultCollection results = Transforms.ConvertToRecognizePiiEntitiesResultCollection(result.Value, map);
                return Response.FromValue(results, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private Response<RecognizePiiEntitiesResultCollection> RecognizePiiEntitiesBatch(MultiLanguageBatchInput batchInput, RecognizePiiEntitiesOptions options, CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(RecognizePiiEntitiesBatch)}");
            scope.Start();

            try
            {
                Response<PiiEntitiesResult> result = _serviceRestClient.EntitiesRecognitionPii(
                    batchInput,
                    options.ModelVersion,
                    options.IncludeStatistics,
                    options.DomainFilter.GetString(),
                    _stringCodeUnit,
                    cancellationToken);
                var response = result.GetRawResponse();

                IDictionary<string, int> map = CreateIdToIndexMap(batchInput.Documents);
                RecognizePiiEntitiesResultCollection results = Transforms.ConvertToRecognizePiiEntitiesResultCollection(result.Value, map);
                return Response.FromValue(results, response);
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
        /// <para>For a list of languages supported by this operation, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/language-support"/>.</para>
        /// <para>For document length limits, maximum batch size, and supported text encoding, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/overview#data-limits"/>.</para>
        /// </summary>
        /// <param name="document">The document to analyze.</param>
        /// <param name="language">The language that the document is written in.
        /// If unspecified, this value will be set to the default language in
        /// <see cref="TextAnalyticsClientOptions.DefaultLanguage"/> in the request sent to the
        /// service.  If set to an empty string, the service will apply a model
        /// where the language is explicitly set to "None".</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>
        /// controlling the request lifetime.</param>
        /// <returns>A result containing sentiment predictions for the document
        /// and each of the sentences it contains.</returns>
        /// <exception cref="RequestFailedException">Service returned a non-success
        /// status code.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "AZC0002:DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.", Justification = "Hidden method we don't encourage people to use.")]
        public virtual async Task<Response<DocumentSentiment>> AnalyzeSentimentAsync(string document, string language, CancellationToken cancellationToken)
        {
            return await AnalyzeSentimentAsync(document, language, new AnalyzeSentimentOptions(), cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Runs a predictive model to identify the positive, negative or neutral
        /// sentiment contained in the document, as well as a score indicating the model's
        /// confidence in the predicted sentiment.
        /// <para>For a list of languages supported by this operation, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/language-support"/>.</para>
        /// <para>For document length limits, maximum batch size, and supported text encoding, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/overview#data-limits"/>.</para>
        /// </summary>
        /// <param name="document">The text to analyze.</param>
        /// <param name="language">The language that the document is written in.
        /// If unspecified, this value will be set to the default language in
        /// <see cref="TextAnalyticsClientOptions.DefaultLanguage"/> in the request sent to the
        /// service.  If set to an empty string, the service will apply a model
        /// where the language is explicitly set to "None".</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>
        /// controlling the request lifetime.</param>
        /// <returns>A result containing sentiment predictions for the document
        /// and each of the sentences it contains.</returns>
        /// <exception cref="RequestFailedException">Service returned a non-success
        /// status code.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "AZC0002:DO ensure all service methods, both asynchronous and synchronous, take an optional CancellationToken parameter called cancellationToken.", Justification = "Hidden method we don't encourage people to use.")]
        public virtual Response<DocumentSentiment> AnalyzeSentiment(string document, string language, CancellationToken cancellationToken)
        {
            return AnalyzeSentiment(document, language, new AnalyzeSentimentOptions(), cancellationToken);
        }

        /// <summary>
        /// Runs a predictive model to identify the positive, negative, neutral
        /// or mixed sentiment contained in the document, as well as a score
        /// indicating the model's confidence in the predicted sentiment.
        /// <para>For a list of languages supported by this operation, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/language-support"/>.</para>
        /// <para>For document length limits, maximum batch size, and supported text encoding, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/overview#data-limits"/>.</para>
        /// </summary>
        /// <param name="document">The document to analyze.</param>
        /// <param name="language">The language that the document is written in.
        /// If unspecified, this value will be set to the default language in
        /// <see cref="TextAnalyticsClientOptions.DefaultLanguage"/> in the request sent to the
        /// service.  If set to an empty string, the service will apply a model
        /// where the language is explicitly set to "None".</param>
        /// <param name="options">The additional configurable <see cref="AnalyzeSentimentOptions"/> that may be passed when
        /// analyzing sentiments. Options include Opinion mining, model version, and more.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>
        /// controlling the request lifetime.</param>
        /// <returns>A result containing sentiment predictions for the document
        /// and each of the sentences it contains.</returns>
        /// <exception cref="RequestFailedException">Service returned a non-success
        /// status code.</exception>
        public virtual async Task<Response<DocumentSentiment>> AnalyzeSentimentAsync(string document, string language = default, AnalyzeSentimentOptions options = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(document, nameof(document));
            options ??= new AnalyzeSentimentOptions();

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(AnalyzeSentiment)}");
            scope.AddAttribute("document", document);
            scope.Start();

            try
            {
                var documents = new List<MultiLanguageInput>() { ConvertToMultiLanguageInput(document, language) };
                Response<SentimentResponse> result = await _serviceRestClient.SentimentAsync(
                    new MultiLanguageBatchInput(documents),
                    options.ModelVersion,
                    options.IncludeStatistics,
                    options.IncludeOpinionMining,
                    _stringCodeUnit,
                    cancellationToken).ConfigureAwait(false);
                Response response = result.GetRawResponse();

                if (result.Value.Errors.Count > 0)
                {
                    // only one document, so we can ignore the id and grab the first error message.
                    var error = Transforms.ConvertToError(result.Value.Errors[0].Error);
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response, error.Message, error.ErrorCode.ToString(), CreateAdditionalInformation(error)).ConfigureAwait(false);
                }

                return Response.FromValue(new DocumentSentiment(result.Value.Documents[0]), response);
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
        /// <para>For a list of languages supported by this operation, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/language-support"/>.</para>
        /// <para>For document length limits, maximum batch size, and supported text encoding, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/overview#data-limits"/>.</para>
        /// </summary>
        /// <param name="document">The text to analyze.</param>
        /// <param name="language">The language that the document is written in.
        /// If unspecified, this value will be set to the default language in
        /// <see cref="TextAnalyticsClientOptions.DefaultLanguage"/> in the request sent to the
        /// service.  If set to an empty string, the service will apply a model
        /// where the language is explicitly set to "None".</param>
        /// <param name="options">The additional configurable <see cref="AnalyzeSentimentOptions"/> that may be passed when
        /// analyzing sentiments. Options include Opinion mining, model version, and more.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>
        /// controlling the request lifetime.</param>
        /// <returns>A result containing sentiment predictions for the document
        /// and each of the sentences it contains.</returns>
        /// <exception cref="RequestFailedException">Service returned a non-success
        /// status code.</exception>
        public virtual Response<DocumentSentiment> AnalyzeSentiment(string document, string language = default, AnalyzeSentimentOptions options = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(document, nameof(document));
            options ??= new AnalyzeSentimentOptions();

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(AnalyzeSentiment)}");
            scope.AddAttribute("document", document);
            scope.Start();

            try
            {
                var documents = new List<MultiLanguageInput>() { ConvertToMultiLanguageInput(document, language) };
                Response<SentimentResponse> result = _serviceRestClient.Sentiment(
                    new MultiLanguageBatchInput(documents),
                    options.ModelVersion,
                    options.IncludeStatistics,
                    options.IncludeOpinionMining,
                    _stringCodeUnit,
                    cancellationToken);
                Response response = result.GetRawResponse();

                if (result.Value.Errors.Count > 0)
                {
                    // only one document, so we can ignore the id and grab the first error message.
                    var error = Transforms.ConvertToError(result.Value.Errors[0].Error);
                    throw _clientDiagnostics.CreateRequestFailedException(response, error.Message, error.ErrorCode.ToString(), CreateAdditionalInformation(error));
                }

                return Response.FromValue(new DocumentSentiment(result.Value.Documents[0]), response);
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
        /// <para>For a list of languages supported by this operation, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/language-support"/>.</para>
        /// <para>For document length limits, maximum batch size, and supported text encoding, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/overview#data-limits"/>.</para>
        /// </summary>
        /// <param name="documents">The documents to analyze.</param>
        /// <param name="language">The language that all of the documents are written in.
        /// If unspecified, this value will be set to the default language in
        /// <see cref="TextAnalyticsClientOptions.DefaultLanguage"/> in the request sent to the
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
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<AnalyzeSentimentResultCollection>> AnalyzeSentimentBatchAsync(IEnumerable<string> documents, string language, TextAnalyticsRequestOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            var analyzeSentimentOptions = options != null ? new AnalyzeSentimentOptions (options): new AnalyzeSentimentOptions();
            MultiLanguageBatchInput documentInputs = ConvertToMultiLanguageInputs(documents, language);

            return await AnalyzeSentimentBatchAsync(documentInputs, analyzeSentimentOptions, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Runs a predictive model to identify the positive, negative or neutral
        /// sentiment contained in the documents, as well as scores indicating
        /// the model's confidence in each of the predicted sentiments.
        /// <para>For a list of languages supported by this operation, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/language-support"/>.</para>
        /// <para>For document length limits, maximum batch size, and supported text encoding, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/overview#data-limits"/>.</para>
        /// </summary>
        /// <param name="documents">The documents to analyze.</param>
        /// <param name="language">The language that all of the documents are written in.
        /// If unspecified, this value will be set to the default language in
        /// <see cref="TextAnalyticsClientOptions.DefaultLanguage"/> in the request sent to the
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
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<AnalyzeSentimentResultCollection> AnalyzeSentimentBatch(IEnumerable<string> documents, string language, TextAnalyticsRequestOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            var analyzeSentimentOptions = options != null ? new AnalyzeSentimentOptions(options) : new AnalyzeSentimentOptions();
            MultiLanguageBatchInput documentInputs = ConvertToMultiLanguageInputs(documents, language);

            return AnalyzeSentimentBatch(documentInputs, analyzeSentimentOptions, cancellationToken);
        }

        /// <summary>
        /// Runs a predictive model to identify the positive, negative or neutral
        /// sentiment contained in the documents, as well as scores indicating
        /// the model's confidence in each of the predicted sentiments.
        /// <para>For a list of languages supported by this operation, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/language-support"/>.</para>
        /// <para>For document length limits, maximum batch size, and supported text encoding, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/overview#data-limits"/>.</para>
        /// </summary>
        /// <param name="documents">The documents to analyze.</param>
        /// <param name="language">The language that all of the documents are written in.
        /// If unspecified, this value will be set to the default language in
        /// <see cref="TextAnalyticsClientOptions.DefaultLanguage"/> in the request sent to the
        /// service.  If set to an empty string, the service will apply a model
        /// where the language is explicitly set to "None".</param>
        /// <param name="options">The additional configurable <see cref="AnalyzeSentimentOptions"/> that may be passed when
        /// analyzing sentiments. Options include Opinion mining, model version, and more.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>
        /// controlling the request lifetime.</param>
        /// <returns>A result containing sentiment predictions for each of the documents
        /// and predictions for each of the sentences each document contains.</returns>
        /// <exception cref="RequestFailedException">Service returned a non-success
        /// status code.</exception>
        public virtual async Task<Response<AnalyzeSentimentResultCollection>> AnalyzeSentimentBatchAsync(IEnumerable<string> documents, string language = default, AnalyzeSentimentOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            options ??= new AnalyzeSentimentOptions();
            MultiLanguageBatchInput documentInputs = ConvertToMultiLanguageInputs(documents, language);

            return await AnalyzeSentimentBatchAsync(documentInputs, options, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Runs a predictive model to identify the positive, negative or neutral
        /// sentiment contained in the documents, as well as scores indicating
        /// the model's confidence in each of the predicted sentiments.
        /// <para>For a list of languages supported by this operation, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/language-support"/>.</para>
        /// <para>For document length limits, maximum batch size, and supported text encoding, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/overview#data-limits"/>.</para>
        /// </summary>
        /// <param name="documents">The documents to analyze.</param>
        /// <param name="language">The language that all of the documents are written in.
        /// If unspecified, this value will be set to the default language in
        /// <see cref="TextAnalyticsClientOptions.DefaultLanguage"/> in the request sent to the
        /// service.  If set to an empty string, the service will apply a model
        /// where the language is explicitly set to "None".</param>
        /// <param name="options">The additional configurable <see cref="AnalyzeSentimentOptions"/> that may be passed when
        /// analyzing sentiments. Options include Opinion mining, model version, and more.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>
        /// controlling the request lifetime.</param>
        /// <returns>A result containing sentiment predictions for each of the documents
        /// and predictions for each of the sentences each document contains.</returns>
        /// <exception cref="RequestFailedException">Service returned a non-success
        /// status code.</exception>
        public virtual Response<AnalyzeSentimentResultCollection> AnalyzeSentimentBatch(IEnumerable<string> documents, string language = default, AnalyzeSentimentOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            options ??= new AnalyzeSentimentOptions();
            MultiLanguageBatchInput documentInputs = ConvertToMultiLanguageInputs(documents, language);

            return AnalyzeSentimentBatch(documentInputs, options, cancellationToken);
        }

        /// <summary>
        /// Runs a predictive model to identify the positive, negative or neutral
        /// sentiment contained in the documents, as well as scores indicating
        /// the model's confidence in each of the predicted sentiments.
        /// <para>For a list of languages supported by this operation, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/language-support"/>.</para>
        /// <para>For document length limits, maximum batch size, and supported text encoding, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/overview#data-limits"/>.</para>
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
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<AnalyzeSentimentResultCollection>> AnalyzeSentimentBatchAsync(IEnumerable<TextDocumentInput> documents, TextAnalyticsRequestOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            var analyzeSentimentOptions = options != null ? new AnalyzeSentimentOptions(options) : new AnalyzeSentimentOptions();
            MultiLanguageBatchInput documentInputs = ConvertToMultiLanguageInputs(documents);

            return await AnalyzeSentimentBatchAsync(documentInputs, analyzeSentimentOptions, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Runs a predictive model to identify the positive, negative or neutral
        /// sentiment contained in the documents, as well as scores indicating
        /// the model's confidence in each of the predicted sentiments.
        /// <para>For a list of languages supported by this operation, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/language-support"/>.</para>
        /// <para>For document length limits, maximum batch size, and supported text encoding, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/overview#data-limits"/>.</para>
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
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<AnalyzeSentimentResultCollection> AnalyzeSentimentBatch(IEnumerable<TextDocumentInput> documents, TextAnalyticsRequestOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            var analyzeSentimentOptions = options != null ? new AnalyzeSentimentOptions(options) : new AnalyzeSentimentOptions();
            MultiLanguageBatchInput documentInputs = ConvertToMultiLanguageInputs(documents);

            return AnalyzeSentimentBatch(documentInputs, analyzeSentimentOptions, cancellationToken);
        }

        /// <summary>
        /// Runs a predictive model to identify the positive, negative or neutral
        /// sentiment contained in the documents, as well as scores indicating
        /// the model's confidence in each of the predicted sentiments.
        /// <para>For a list of languages supported by this operation, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/language-support"/>.</para>
        /// <para>For document length limits, maximum batch size, and supported text encoding, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/overview#data-limits"/>.</para>
        /// </summary>
        /// <param name="documents">The documents to analyze.</param>
        /// <param name="options">The additional configurable <see cref="AnalyzeSentimentOptions"/> that may be passed when
        /// analyzing sentiments. Options include Opinion mining, model version, and more.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>
        /// controlling the request lifetime.</param>
        /// <returns>A result containing sentiment predictions for each of the documents
        /// and predictions for each of the sentences each document contains.</returns>
        /// <exception cref="RequestFailedException">Service returned a non-success
        /// status code.</exception>
        public virtual async Task<Response<AnalyzeSentimentResultCollection>> AnalyzeSentimentBatchAsync(IEnumerable<TextDocumentInput> documents, AnalyzeSentimentOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            options ??= new AnalyzeSentimentOptions();
            MultiLanguageBatchInput documentInputs = ConvertToMultiLanguageInputs(documents);

            return await AnalyzeSentimentBatchAsync(documentInputs, options, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Runs a predictive model to identify the positive, negative or neutral
        /// sentiment contained in the documents, as well as scores indicating
        /// the model's confidence in each of the predicted sentiments.
        /// <para>For a list of languages supported by this operation, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/language-support"/>.</para>
        /// <para>For document length limits, maximum batch size, and supported text encoding, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/overview#data-limits"/>.</para>
        /// </summary>
        /// <param name="documents">The documents to analyze.</param>
        /// <param name="options">The additional configurable <see cref="AnalyzeSentimentOptions"/> that may be passed when
        /// analyzing sentiments. Options include Opinion mining, model version, and more.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>
        /// controlling the request lifetime.</param>
        /// <returns>A result containing sentiment predictions for each of the documents
        /// and predictions for each of the sentences each document contains.</returns>
        /// <exception cref="RequestFailedException">Service returned a non-success
        /// status code.</exception>
        public virtual Response<AnalyzeSentimentResultCollection> AnalyzeSentimentBatch(IEnumerable<TextDocumentInput> documents, AnalyzeSentimentOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            options ??= new AnalyzeSentimentOptions();
            MultiLanguageBatchInput documentInputs = ConvertToMultiLanguageInputs(documents);

            return AnalyzeSentimentBatch(documentInputs, options, cancellationToken);
        }

        private async Task<Response<AnalyzeSentimentResultCollection>> AnalyzeSentimentBatchAsync(MultiLanguageBatchInput batchInput, AnalyzeSentimentOptions options, CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(AnalyzeSentimentBatch)}");
            scope.Start();

            try
            {
                Response<SentimentResponse> result = await _serviceRestClient.SentimentAsync(
                    batchInput,
                    options.ModelVersion,
                    options.IncludeStatistics,
                    options.IncludeOpinionMining,
                    _stringCodeUnit,
                    cancellationToken).ConfigureAwait(false);
                var response = result.GetRawResponse();

                IDictionary<string, int> map = CreateIdToIndexMap(batchInput.Documents);
                AnalyzeSentimentResultCollection results = Transforms.ConvertToAnalyzeSentimentResultCollection(result.Value, map);
                return Response.FromValue(results, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private Response<AnalyzeSentimentResultCollection> AnalyzeSentimentBatch(MultiLanguageBatchInput batchInput, AnalyzeSentimentOptions options, CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(AnalyzeSentimentBatch)}");
            scope.Start();

            try
            {
                Response<SentimentResponse> result = _serviceRestClient.Sentiment(
                    batchInput,
                    options.ModelVersion,
                    options.IncludeStatistics,
                    options.IncludeOpinionMining,
                    _stringCodeUnit,
                    cancellationToken);
                var response = result.GetRawResponse();

                IDictionary<string, int> map = CreateIdToIndexMap(batchInput.Documents);
                AnalyzeSentimentResultCollection results = Transforms.ConvertToAnalyzeSentimentResultCollection(result.Value, map);
                return Response.FromValue(results, response);
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
        /// <para>For example, for the document "The food was delicious and there
        /// were wonderful staff", the API returns the main talking points: "food"
        /// and "wonderful staff".</para>
        /// <para>For a list of languages supported by this operation, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/language-support"/>.</para>
        /// <para>For document length limits, maximum batch size, and supported text encoding, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/overview#data-limits"/>.</para>
        /// </summary>
        /// <param name="document">The document to analyze.</param>
        /// <param name="language">The language that the document is written in.
        /// If unspecified, this value will be set to the default language in
        /// <see cref="TextAnalyticsClientOptions.DefaultLanguage"/> in the request sent to the
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
                var documents = new List<MultiLanguageInput>() { ConvertToMultiLanguageInput(document, language) };
                Response<KeyPhraseResult> result = await _serviceRestClient.KeyPhrasesAsync(new MultiLanguageBatchInput(documents), cancellationToken: cancellationToken).ConfigureAwait(false);
                Response response = result.GetRawResponse();

                if (result.Value.Errors.Count > 0)
                {
                    // only one document, so we can ignore the id and grab the first error message.
                    var error = Transforms.ConvertToError(result.Value.Errors[0].Error);
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response, error.Message, error.ErrorCode.ToString(), CreateAdditionalInformation(error)).ConfigureAwait(false);
                }

                return Response.FromValue(Transforms.ConvertToKeyPhraseCollection(result.Value.Documents[0]), response);
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
        /// <para>For example, for the document "The food was delicious and there
        /// were wonderful staff", the API returns the main talking points: "food"
        /// and "wonderful staff".</para>
        /// <para>For a list of languages supported by this operation, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/language-support"/>.</para>
        /// <para>For document length limits, maximum batch size, and supported text encoding, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/overview#data-limits"/>.</para>
        /// </summary>
        /// <param name="document">The document to analyze.</param>
        /// <param name="language">The language that the document is written in.
        /// If unspecified, this value will be set to the default language in
        /// <see cref="TextAnalyticsClientOptions.DefaultLanguage"/> in the request sent to the
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
                var documents = new List<MultiLanguageInput>() { ConvertToMultiLanguageInput(document, language) };
                Response<KeyPhraseResult> result = _serviceRestClient.KeyPhrases(new MultiLanguageBatchInput(documents), cancellationToken: cancellationToken);
                Response response = result.GetRawResponse();

                if (result.Value.Errors.Count > 0)
                {
                    // only one document, so we can ignore the id and grab the first error message.
                    var error = Transforms.ConvertToError(result.Value.Errors[0].Error);
                    throw _clientDiagnostics.CreateRequestFailedException(response, error.Message, error.ErrorCode.ToString(), CreateAdditionalInformation(error));
                }

                return Response.FromValue(Transforms.ConvertToKeyPhraseCollection(result.Value.Documents[0]), response);
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
        /// <para>For example, for the document "The food was delicious and there
        /// were wonderful staff", the API returns the main talking points: "food"
        /// and "wonderful staff".</para>
        /// <para>For a list of languages supported by this operation, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/language-support"/>.</para>
        /// <para>For document length limits, maximum batch size, and supported text encoding, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/overview#data-limits"/>.</para>
        /// </summary>
        /// <param name="documents">The documents to analyze.</param>
        /// <param name="language">The language that all the documents are
        /// written in. If unspecified, this value will be set to the default
        /// language in <see cref="TextAnalyticsClientOptions.DefaultLanguage"/> in the request
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
            options ??= new TextAnalyticsRequestOptions();
            MultiLanguageBatchInput documentInputs = ConvertToMultiLanguageInputs(documents, language);

            return await ExtractKeyPhrasesBatchAsync(documentInputs, options, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Runs a model to identify a collection of significant phrases
        /// found in the passed-in documents.
        /// <para>For example, for the document "The food was delicious and there
        /// were wonderful staff", the API returns the main talking points: "food"
        /// and "wonderful staff".</para>
        /// <para>For a list of languages supported by this operation, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/language-support"/>.</para>
        /// <para>For document length limits, maximum batch size, and supported text encoding, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/overview#data-limits"/>.</para>
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
            options ??= new TextAnalyticsRequestOptions();
            MultiLanguageBatchInput documentInputs = ConvertToMultiLanguageInputs(documents, language);

            return ExtractKeyPhrasesBatch(documentInputs, options, cancellationToken);
        }

        /// <summary>
        /// Runs a model to identify a collection of significant phrases
        /// found in the passed-in documents.
        /// <para>For example, for the document "The food was delicious and there
        /// were wonderful staff", the API returns the main talking points: "food"
        /// and "wonderful staff".</para>
        /// <para>For a list of languages supported by this operation, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/language-support"/>.</para>
        /// <para>For document length limits, maximum batch size, and supported text encoding, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/overview#data-limits"/>.</para>
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
            MultiLanguageBatchInput documentInputs = ConvertToMultiLanguageInputs(documents);

            return await ExtractKeyPhrasesBatchAsync(documentInputs, options, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Runs a model to identify a collection of significant phrases
        /// found in the passed-in documents.
        /// <para>For example, for the document "The food was delicious and there
        /// were wonderful staff", the API returns the main talking points: "food"
        /// and "wonderful staff".</para>
        /// <para>For a list of languages supported by this operation, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/language-support"/>.</para>
        /// <para>For document length limits, maximum batch size, and supported text encoding, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/overview#data-limits"/>.</para>
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
            MultiLanguageBatchInput documentInputs = ConvertToMultiLanguageInputs(documents);

            return ExtractKeyPhrasesBatch(documentInputs, options, cancellationToken);
        }

        private async Task<Response<ExtractKeyPhrasesResultCollection>> ExtractKeyPhrasesBatchAsync(MultiLanguageBatchInput batchInput, TextAnalyticsRequestOptions options, CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(ExtractKeyPhrasesBatch)}");
            scope.Start();

            try
            {
                Response<KeyPhraseResult> result = await _serviceRestClient.KeyPhrasesAsync(batchInput, options.ModelVersion, options.IncludeStatistics, cancellationToken).ConfigureAwait(false);
                var response = result.GetRawResponse();

                IDictionary<string, int> map = CreateIdToIndexMap(batchInput.Documents);
                ExtractKeyPhrasesResultCollection results = Transforms.ConvertToExtractKeyPhrasesResultCollection(result.Value, map);
                return Response.FromValue(results, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private Response<ExtractKeyPhrasesResultCollection> ExtractKeyPhrasesBatch(MultiLanguageBatchInput batchInput, TextAnalyticsRequestOptions options, CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(ExtractKeyPhrasesBatch)}");
            scope.Start();

            try
            {
                Response<KeyPhraseResult> result = _serviceRestClient.KeyPhrases(batchInput, options.ModelVersion, options.IncludeStatistics, cancellationToken);
                var response = result.GetRawResponse();

                IDictionary<string, int> map = CreateIdToIndexMap(batchInput.Documents);
                ExtractKeyPhrasesResultCollection results = Transforms.ConvertToExtractKeyPhrasesResultCollection(result.Value, map);
                return Response.FromValue(results, response);
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
        /// <para>For a list of languages supported by this operation, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/language-support"/>.</para>
        /// <para>For document length limits, maximum batch size, and supported text encoding, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/overview#data-limits"/>.</para>
        /// </summary>
        /// <param name="document">The document to analyze.</param>
        /// <param name="language">The language that the document is written in.
        /// If unspecified, this value will be set to the default language in
        /// <see cref="TextAnalyticsClientOptions.DefaultLanguage"/> in the request sent to the
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
                var documents = new List<MultiLanguageInput>() { ConvertToMultiLanguageInput(document, language) };

                Response<EntityLinkingResult> result = await _serviceRestClient.EntitiesLinkingAsync(
                    new MultiLanguageBatchInput(documents),
                    stringIndexType: _stringCodeUnit,
                    cancellationToken: cancellationToken).ConfigureAwait(false);
                Response response = result.GetRawResponse();

                if (result.Value.Errors.Count > 0)
                {
                    // only one document, so we can ignore the id and grab the first error message.
                    var error = Transforms.ConvertToError(result.Value.Errors[0].Error);
                    throw await _clientDiagnostics.CreateRequestFailedExceptionAsync(response, error.Message, error.ErrorCode.ToString(), CreateAdditionalInformation(error)).ConfigureAwait(false);
                }

                return Response.FromValue(Transforms.ConvertToLinkedEntityCollection(result.Value.Documents[0]), response);
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
        /// <para>For a list of languages supported by this operation, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/language-support"/>.</para>
        /// <para>For document length limits, maximum batch size, and supported text encoding, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/overview#data-limits"/>.</para>
        /// </summary>
        /// <param name="document">The document to analyze.</param>
        /// <param name="language">The language that the document is written in.
        /// If unspecified, this value will be set to the default language in
        /// <see cref="TextAnalyticsClientOptions.DefaultLanguage"/> in the request sent to the
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
                var documents = new List<MultiLanguageInput>() { ConvertToMultiLanguageInput(document, language) };

                Response<EntityLinkingResult> result = _serviceRestClient.EntitiesLinking(
                    new MultiLanguageBatchInput(documents),
                    stringIndexType: _stringCodeUnit,
                    cancellationToken: cancellationToken);
                Response response = result.GetRawResponse();

                if (result.Value.Errors.Count > 0)
                {
                    // only one document, so we can ignore the id and grab the first error message.
                    var error = Transforms.ConvertToError(result.Value.Errors[0].Error);
                    throw _clientDiagnostics.CreateRequestFailedException(response, error.Message, error.ErrorCode.ToString(), CreateAdditionalInformation(error));
                }

                return Response.FromValue(Transforms.ConvertToLinkedEntityCollection(result.Value.Documents[0]), response);
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
        /// <para>For a list of languages supported by this operation, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/language-support"/>.</para>
        /// <para>For document length limits, maximum batch size, and supported text encoding, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/overview#data-limits"/>.</para>
        /// </summary>
        /// <param name="documents">The documents to analyze.</param>
        /// <param name="language">The language that the documents are written in.
        /// If unspecified, this value will be set to the default language in
        /// <see cref="TextAnalyticsClientOptions.DefaultLanguage"/> in the request sent to the
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
            options ??= new TextAnalyticsRequestOptions();
            MultiLanguageBatchInput documentInputs = ConvertToMultiLanguageInputs(documents, language);

            return await RecognizeLinkedEntitiesBatchAsync(documentInputs, options, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Runs a predictive model to identify a collection of entities
        /// found in the passed-in documents, and include information linking the
        /// entities to their corresponding entries in a well-known knowledge base.
        /// <para>For a list of languages supported by this operation, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/language-support"/>.</para>
        /// <para>For document length limits, maximum batch size, and supported text encoding, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/overview#data-limits"/>.</para>
        /// </summary>
        /// <param name="documents">The documents to analyze.</param>
        /// <param name="language">The language that the documents are written in.
        /// If unspecified, this value will be set to the default language in
        /// <see cref="TextAnalyticsClientOptions.DefaultLanguage"/> in the request sent to the
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
            options ??= new TextAnalyticsRequestOptions();
            MultiLanguageBatchInput documentInputs = ConvertToMultiLanguageInputs(documents, language);

            return RecognizeLinkedEntitiesBatch(documentInputs, options, cancellationToken);
        }

        /// <summary>
        /// Runs a predictive model to identify a collection of entities
        /// found in the passed-in documents, and include information linking the
        /// entities to their corresponding entries in a well-known knowledge base.
        /// <para>For a list of languages supported by this operation, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/language-support"/>.</para>
        /// <para>For document length limits, maximum batch size, and supported text encoding, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/overview#data-limits"/>.</para>
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
            MultiLanguageBatchInput documentInputs = ConvertToMultiLanguageInputs(documents);

            return await RecognizeLinkedEntitiesBatchAsync(documentInputs, options, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Runs a predictive model to identify a collection of entities
        /// found in the passed-in documents, and include information linking the
        /// entities to their corresponding entries in a well-known knowledge base.
        /// <para>For a list of languages supported by this operation, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/language-support"/>.</para>
        /// <para>For document length limits, maximum batch size, and supported text encoding, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/overview#data-limits"/>.</para>
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
            MultiLanguageBatchInput documentInputs = ConvertToMultiLanguageInputs(documents);

            return RecognizeLinkedEntitiesBatch(documentInputs, options, cancellationToken);
        }

        private async Task<Response<RecognizeLinkedEntitiesResultCollection>> RecognizeLinkedEntitiesBatchAsync(MultiLanguageBatchInput batchInput, TextAnalyticsRequestOptions options, CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(RecognizeLinkedEntitiesBatch)}");
            scope.Start();

            try
            {
                Response<EntityLinkingResult> result = await _serviceRestClient.EntitiesLinkingAsync(
                    batchInput,
                    options.ModelVersion,
                    options.IncludeStatistics,
                    _stringCodeUnit,
                    cancellationToken).ConfigureAwait(false);
                var response = result.GetRawResponse();

                IDictionary<string, int> map = CreateIdToIndexMap(batchInput.Documents);
                RecognizeLinkedEntitiesResultCollection results = Transforms.ConvertToRecognizeLinkedEntitiesResultCollection(result.Value, map);
                return Response.FromValue(results, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private Response<RecognizeLinkedEntitiesResultCollection> RecognizeLinkedEntitiesBatch(MultiLanguageBatchInput batchInput, TextAnalyticsRequestOptions options, CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(RecognizeLinkedEntitiesBatch)}");
            scope.Start();

            try
            {
                Response<EntityLinkingResult> result = _serviceRestClient.EntitiesLinking(batchInput,
                    options.ModelVersion,
                    options.IncludeStatistics,
                    _stringCodeUnit,
                    cancellationToken);
                var response = result.GetRawResponse();

                IDictionary<string, int> map = CreateIdToIndexMap(batchInput.Documents);
                RecognizeLinkedEntitiesResultCollection results = Transforms.ConvertToRecognizeLinkedEntitiesResultCollection(result.Value, map);
                return Response.FromValue(results, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        #endregion

        #region Healthcare

        /// <summary>
        /// Runs a predictive model to identify a collection of healthcare entities
        /// found in the passed-in document, and include information linking the
        /// entities to their corresponding entries in a well-known knowledge base.
        /// For a list of languages supported by this operation, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/language-support"/>.
        /// For document length limits, maximum batch size, and supported text encoding, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/overview#data-limits"/>.
        /// <remarks><para>
        /// Note: In order to use this functionality, request to access public preview is required.
        /// Azure Active Directory (AAD) is not currently supported. For more information see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/how-tos/text-analytics-for-health?tabs=ner#request-access-to-the-public-preview"/>.
        /// </para></remarks>
        /// </summary>
        /// <param name="document">The document to analyze.</param>
        /// <param name="language">The language that the document is written in.</param>
        /// <param name="options">The additional configurable <see cref="HealthcareOptions"/> </param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>
        /// controlling the request lifetime.</param>
        /// <exception cref="RequestFailedException">Service returned a non-success
        /// status code.</exception>
        public virtual async Task<HealthcareOperation> StartHealthcareAsync(string document, string language = default, HealthcareOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(document, nameof(document));
            options ??= new HealthcareOptions();

            var documents = new List<string>() { document };

            MultiLanguageBatchInput documentInputs = ConvertToMultiLanguageInputs(documents, language);

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(StartHealthcare)}");
            scope.Start();

            try
            {
                ResponseWithHeaders<TextAnalyticsHealthHeaders> response = await _serviceRestClient.HealthAsync(documentInputs, options.ModelVersion, _stringCodeUnit, cancellationToken).ConfigureAwait(false);
                string location = response.Headers.OperationLocation;

                IDictionary<string, int> idToIndexMap = CreateIdToIndexMap(documentInputs.Documents);

                return new HealthcareOperation(_serviceRestClient, _clientDiagnostics, location, idToIndexMap, options.Top, options.Skip, options.IncludeStatistics);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Runs a predictive model to identify a collection of healthcare entities
        /// found in the passed-in document, and include information linking the
        /// entities to their corresponding entries in a well-known knowledge base.
        /// For a list of languages supported by this operation, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/language-support"/>.
        /// For document length limits, maximum batch size, and supported text encoding, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/overview#data-limits"/>.
        /// <remarks><para>
        /// Note: In order to use this functionality, request to access public preview is required.
        /// Azure Active Directory (AAD) is not currently supported. For more information see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/how-tos/text-analytics-for-health?tabs=ner#request-access-to-the-public-preview"/>.
        /// </para></remarks>
        /// </summary>
        /// <param name="document">The document to analyze.</param>
        /// <param name="language">The language that the document is written in.</param>
        /// <param name="options">The additional configurable <see cref="HealthcareOptions"/> </param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>
        /// controlling the request lifetime.</param>
        /// <exception cref="RequestFailedException">Service returned a non-success
        /// status code.</exception>
        public virtual HealthcareOperation StartHealthcare(string document, string language = default, HealthcareOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(document, nameof(document));
            options ??= new HealthcareOptions();

            var documents = new List<string>() { document };

            MultiLanguageBatchInput documentInputs = ConvertToMultiLanguageInputs(documents, language);

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(StartHealthcare)}");
            scope.Start();

            try
            {
                ResponseWithHeaders<TextAnalyticsHealthHeaders> response = _serviceRestClient.Health(documentInputs, options.ModelVersion, _stringCodeUnit, cancellationToken);
                string location = response.Headers.OperationLocation;

                IDictionary<string, int> idToIndexMap = CreateIdToIndexMap(documentInputs.Documents);

                return new HealthcareOperation(_serviceRestClient, _clientDiagnostics, location, idToIndexMap, options.Top, options.Skip, options.IncludeStatistics);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Runs a predictive model to identify a collection of healthcare entities
        /// found in the passed-in document, and include information linking the
        /// entities to their corresponding entries in a well-known knowledge base.
        /// For a list of languages supported by this operation, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/language-support"/>.
        /// For document length limits, maximum batch size, and supported text encoding, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/overview#data-limits"/>.
        /// <remarks><para>
        /// Note: In order to use this functionality, request to access public preview is required.
        /// Azure Active Directory (AAD) is not currently supported. For more information see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/how-tos/text-analytics-for-health?tabs=ner#request-access-to-the-public-preview"/>.
        /// </para></remarks>
        /// </summary>
        /// <param name="documents">The documents to analyze.</param>
        /// <param name="language">The language that the document is written in.</param>
        /// <param name="options">The additional configurable <see cref="HealthcareOptions"/> </param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>
        /// controlling the request lifetime.</param>
        /// <exception cref="RequestFailedException">Service returned a non-success
        /// status code.</exception>
        public virtual async Task<HealthcareOperation> StartHealthcareBatchAsync(IEnumerable<string> documents, string language = default, HealthcareOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            options ??= new HealthcareOptions();
            MultiLanguageBatchInput documentInputs = ConvertToMultiLanguageInputs(documents, language);

            return await StartHealthcareBatchAsync(documentInputs, options, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Runs a predictive model to identify a collection of healthcare entities
        /// found in the passed-in document, and include information linking the
        /// entities to their corresponding entries in a well-known knowledge base.
        /// For a list of languages supported by this operation, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/language-support"/>.
        /// For document length limits, maximum batch size, and supported text encoding, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/overview#data-limits"/>.
        /// <remarks><para>
        /// Note: In order to use this functionality, request to access public preview is required.
        /// Azure Active Directory (AAD) is not currently supported. For more information see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/how-tos/text-analytics-for-health?tabs=ner#request-access-to-the-public-preview"/>.
        /// </para></remarks>
        /// </summary>
        /// <param name="documents">The documents to analyze.</param>
        /// <param name="language">The language that the document is written in.
        /// If unspecified, this value will be set to the default language in
        /// <see cref="TextAnalyticsClientOptions"/> in the request sent to the
        /// service.  If set to an empty string, the service will apply a model
        /// where the language is explicitly set to "None".</param>
        /// <param name="options">The additional configurable options<see cref="HealthcareOptions"/></param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>
        /// controlling the request lifetime.</param>
        /// <returns>A result containing the collection of entities identified
        /// for each of the documents, as well as scores indicating the confidence
        /// that a given entity correctly matches the identified substring.</returns>
        /// <exception cref="RequestFailedException">Service returned a non-success
        /// status code.</exception>
        public virtual HealthcareOperation StartHealthcareBatch(IEnumerable<string> documents, string language = default, HealthcareOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            options ??= new HealthcareOptions();
            MultiLanguageBatchInput documentInputs = ConvertToMultiLanguageInputs(documents, language);

            return StartHealthcareBatch(documentInputs, options, cancellationToken);
        }

        /// <summary>
        /// Runs a predictive model to identify a collection of healthcare entities
        /// found in the passed-in document, and include information linking the
        /// entities to their corresponding entries in a well-known knowledge base.
        /// For a list of languages supported by this operation, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/language-support"/>.
        /// For document length limits, maximum batch size, and supported text encoding, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/overview#data-limits"/>.
        /// <remarks><para>
        /// Note: In order to use this functionality, request to access public preview is required.
        /// Azure Active Directory (AAD) is not currently supported. For more information see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/how-tos/text-analytics-for-health?tabs=ner#request-access-to-the-public-preview"/>.
        /// </para></remarks>
        /// </summary>
        /// <param name="documents">The documents to analyze.</param>
        /// <param name="options">The additional configurable options<see cref="HealthcareOptions"/></param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="HealthcareOperation"/> to wait on this long-running operation.  Its <see cref="HealthcareOperation.Value"/> upon successful
        /// completion will contain layout elements extracted from the form.</returns>
        public virtual HealthcareOperation StartHealthcareBatch(IEnumerable<TextDocumentInput> documents, HealthcareOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(documents, nameof(documents));

            options ??= new HealthcareOptions();

            MultiLanguageBatchInput documentInputs = ConvertToMultiLanguageInputs(documents);

            return StartHealthcareBatch(documentInputs, options, cancellationToken);
        }

        /// <summary>
        /// Runs a predictive model to identify a collection of healthcare entities
        /// found in the passed-in document, and include information linking the
        /// entities to their corresponding entries in a well-known knowledge base.
        /// For a list of languages supported by this operation, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/language-support"/>.
        /// For document length limits, maximum batch size, and supported text encoding, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/overview#data-limits"/>.
        /// <remarks><para>
        /// Note: In order to use this functionality, request to access public preview is required.
        /// Azure Active Directory (AAD) is not currently supported. For more information see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/how-tos/text-analytics-for-health?tabs=ner#request-access-to-the-public-preview"/>.
        /// </para></remarks>
        /// </summary>
        /// <param name="documents">The documents to analyze.</param>
        /// <param name="options">The additional configurable options<see cref="HealthcareOptions"/></param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A <see cref="HealthcareOperation"/> to wait on this long-running operation.  Its <see cref="HealthcareOperation.Value"/> upon successful
        /// completion will contain layout elements extracted from the form.</returns>
        public virtual async Task<HealthcareOperation> StartHealthcareBatchAsync(IEnumerable<TextDocumentInput> documents, HealthcareOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(documents, nameof(documents));

            options ??= new HealthcareOptions();

            MultiLanguageBatchInput documentInputs = ConvertToMultiLanguageInputs(documents);

            return await StartHealthcareBatchAsync(documentInputs, options, cancellationToken).ConfigureAwait(false);
        }

        private HealthcareOperation StartHealthcareBatch(MultiLanguageBatchInput batchInput, HealthcareOptions options, CancellationToken cancellationToken = default)
        {
            options ??= new HealthcareOptions();

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(StartHealthcareBatch)}");
            scope.Start();

            try
            {
                ResponseWithHeaders<TextAnalyticsHealthHeaders> response = _serviceRestClient.Health(batchInput, options.ModelVersion, _stringCodeUnit, cancellationToken);
                string location = response.Headers.OperationLocation;

                var _idToIndexMap = CreateIdToIndexMap(batchInput.Documents);

                return new HealthcareOperation(_serviceRestClient, _clientDiagnostics, location, _idToIndexMap, options.Top, options.Skip, options.IncludeStatistics);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private async Task<HealthcareOperation> StartHealthcareBatchAsync(MultiLanguageBatchInput batchInput, HealthcareOptions options, CancellationToken cancellationToken = default)
        {
            options ??= new HealthcareOptions();

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(StartHealthcareBatch)}");
            scope.Start();

            try
            {
                ResponseWithHeaders<TextAnalyticsHealthHeaders> response = await _serviceRestClient.HealthAsync(batchInput, options.ModelVersion, _stringCodeUnit, cancellationToken).ConfigureAwait(false);
                string location = response.Headers.OperationLocation;

                var _idToIndexMap = CreateIdToIndexMap(batchInput.Documents);

                return new HealthcareOperation(_serviceRestClient, _clientDiagnostics, location, _idToIndexMap, options.Top, options.Skip, options.IncludeStatistics);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Runs the cancel job for healthcare operation which was initialzed using <see cref="StartHealthcareBatchAsync(IEnumerable{string}, string, HealthcareOptions, CancellationToken)"/> or <see cref="StartHealthcareAsync"/> </summary>
        /// <param name="operation"> Healthcare operation class object which is returned when operation is started. <see cref="HealthcareOperation"/></param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A long running operation id once the operation is in calcelled state upon successful.</returns>
        #pragma warning disable AZC0015 // Unexpected client method return type.
        public virtual async Task<string> StartCancelHealthJobAsync(HealthcareOperation operation, CancellationToken cancellationToken = default)
        #pragma warning restore AZC0015 // Unexpected client method return type.
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(StartCancelHealthJobAsync)}");
            scope.Start();

            try
            {
                ResponseWithHeaders<TextAnalyticsCancelHealthJobHeaders> response = await _serviceRestClient.CancelHealthJobAsync(new Guid(operation.Id), cancellationToken).ConfigureAwait(false);

                return response.Headers.OperationLocation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Runs the cancel job for healthcare operation which was initialized using <see cref="StartHealthcareBatch(IEnumerable{string}, string, HealthcareOptions, CancellationToken)"/> or <see cref="StartHealthcare"/> </summary>
        /// <param name="operation"> Healthcare operation class object which is returned when operation is started. <see cref="HealthcareOperation"/></param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A long running operation id once the operation is in calcelled state upon successful.</returns>
        #pragma warning disable AZC0015 // Unexpected client method return type.
        public virtual string StartCancelHealthJob(HealthcareOperation operation, CancellationToken cancellationToken = default)
        #pragma warning restore AZC0015 // Unexpected client method return type.
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(StartCancelHealthJobAsync)}");
            scope.Start();

            try
            {
                ResponseWithHeaders<TextAnalyticsCancelHealthJobHeaders> response = _serviceRestClient.CancelHealthJob(new Guid(operation.Id), cancellationToken);

                return response.Headers.OperationLocation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets collection of healthcare entities from the HealthOperation using async pageable.
        /// </summary>
        /// <param name="operation"> Healthcare operation class object which is returned when operation is started. <see cref="HealthcareOperation"/></param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns>A collection of <see cref="DocumentHealthcareResult"/> items.</returns>
        public virtual AsyncPageable<DocumentHealthcareResult> GetHealthcareEntities(HealthcareOperation operation, CancellationToken cancellationToken = default)
        {
            async Task<Page<DocumentHealthcareResult>> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(GetHealthcareEntities)}");
                scope.Start();

                try
                {
                    Response<RecognizeHealthcareEntitiesResultCollection> response = await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);

                    RecognizeHealthcareEntitiesResultCollection result = operation.Value;
                    return Page.FromValues(result.AsEnumerable(), operation.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<DocumentHealthcareResult>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(GetHealthcareEntities)}");
                scope.Start();

                try
                {
                    int top = default;
                    int skip = default;
                    bool showStats = default;

                    // Extracting Job ID and parameters from the URL.
                    // TODO - Update with Regex for cleaner implementation
                    // nextLink - https://cognitiveusw2dev.azure-api.net/text/analytics/v3.1-preview.3/entities/health/jobs/8002878d-2e43-4675-ad20-455fe004641b?$skip=20&$top=0&showStats=true

                    string[] nextLinkSplit = nextLink.Split('/');
                    // nextLinkSplit = [ 'https:', '', 'cognitiveusw2dev.azure-api.net', 'text', ..., '8002878d-2e43-4675-ad20-455fe004641b?$skip=20&$top=0']

                    string[] jobIdParams = nextLinkSplit.Last().Split('?');
                    // jobIdParams = ['8002878d-2e43-4675-ad20-455fe004641b', '$skip=20&$top=0']

                    if (jobIdParams.Length != 2)
                    {
                        throw new InvalidOperationException($"Failed to parse element reference: {nextLink}");
                    }

                    // The Id for the Job i.e. the first index of the list
                    string jobId = jobIdParams[0];
                    // '8002878d-2e43-4675-ad20-455fe004641b'

                    // Extracting Top and Skip parameter values
                    string[] parameters = jobIdParams[1].Split('&');
                    // '$skip=20', '$top=0', 'showStats=true'

                    foreach (string paramater in parameters)
                    {
                        if (paramater.Contains("top"))
                        {
                            _ = int.TryParse(paramater.Split('=')[1], out top);
                            // 0
                        }
                        if (paramater.Contains("skip"))
                        {
                            _ = int.TryParse(paramater.Split('=')[1], out skip);
                            // 20
                        }
                        if (paramater.Contains("showStats"))
                        {
                            _ = bool.TryParse(paramater.Split('=')[1], out showStats);
                            // 20
                        }
                    }

                    Response<HealthcareJobState> jobState = await _serviceRestClient.HealthStatusAsync(new Guid(jobId), top, skip, showStats, cancellationToken).ConfigureAwait(false);

                    RecognizeHealthcareEntitiesResultCollection result = Transforms.ConvertToRecognizeHealthcareEntitiesResultCollection(jobState.Value.Results, operation._idToIndexMap);
                    return Page.FromValues(result.AsEnumerable(), jobState.Value.NextLink, jobState.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        #endregion

        #region Analyze Operation

        /// <summary>
        /// StartAnalyzeOperationBatchAsync enables the application to have multiple tasks including NER, PII and KPE.
        /// Accepts a list of strings which are analyzed asynchronously.
        /// For document length limits, maximum batch size, and supported text encoding, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/overview#data-limits"/>.
        /// </summary>
        /// <param name="documents">The list of documents to analyze.</param>
        /// <param name="language">The language that the document is written in.</param>
        /// <param name="options"> The different operations to pass as options.
        /// You can use it to have multiple tasks to analyze as well as multiple task item per each individual task.
        /// For example -
        ///    AnalyzeOperationOptions operationOptions = new AnalyzeOperationOptions()
        ///    {
        ///        KeyPhrasesTaskParameters = new KeyPhrasesTaskParameters(),
        ///        EntitiesTaskParameters = new EntitiesTaskParameters(),
        ///        PiiTaskParameters = new PiiTaskParameters(),
        ///        DisplayName = "AnalyzeOperation"
        ///    };
        /// By default ModelVersion is set as 'latest' and it can set from the task parameters.
        /// KeyPhrasesTaskParameters = new KeyPhrasesTaskParameters()
        /// {
        ///     ModelVersion = "latest"
        /// },
        /// For additional configurable options see <see cref="AnalyzeOperationOptions"/> </param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="RequestFailedException">Service returned a non-success
        /// status code.</exception>
        public virtual async Task<AnalyzeOperation> StartAnalyzeOperationBatchAsync(IEnumerable<string> documents, AnalyzeOperationOptions options, string language = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            Argument.AssertNotNull(options, nameof(options));
            MultiLanguageBatchInput documentInputs = ConvertToMultiLanguageInputs(documents, language);

            return await StartAnalyzeOperationBatchAsync(documentInputs, options, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Analyze Operation enables the application to have multiple tasks including NER, PII and KPE.
        /// Accepts a list of strings which are analyzed asynchronously.
        /// For document length limits, maximum batch size, and supported text encoding, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/overview#data-limits"/>.
        /// </summary>
        /// <param name="documents">The list of documents to analyze.</param>
        /// <param name="language">The language that the document is written in.</param>
        /// <param name="options"> The different operations to pass as options.
        /// You can use it to have multiple tasks to analyze as well as multiple task item per each individual task.
        /// For example -
        ///    AnalyzeOperationOptions operationOptions = new AnalyzeOperationOptions()
        ///    {
        ///        KeyPhrasesTaskParameters = new KeyPhrasesTaskParameters(),
        ///        EntitiesTaskParameters = new EntitiesTaskParameters(),
        ///        PiiTaskParameters = new PiiTaskParameters(),
        ///        DisplayName = "AnalyzeOperation"
        ///    };
        /// By default ModelVersion is set as 'latest' and it can set from the task parameters.
        /// KeyPhrasesTaskParameters = new KeyPhrasesTaskParameters()
        /// {
        ///     ModelVersion = "latest"
        /// },
        /// For additional configurable options see <see cref="AnalyzeOperationOptions"/> </param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="RequestFailedException">Service returned a non-success
        /// status code.</exception>
        public virtual AnalyzeOperation StartAnalyzeOperationBatch(IEnumerable<string> documents, AnalyzeOperationOptions options, string language = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            Argument.AssertNotNull(options, nameof(options));
            MultiLanguageBatchInput documentInputs = ConvertToMultiLanguageInputs(documents, language);

            return StartAnalyzeOperationBatch(documentInputs, options, cancellationToken);
        }

        /// <summary>
        /// Analyze Operation enables the application to have multiple tasks including NER, PII and KPE.
        /// Accepts a list of strings which are analyzed asynchronously.
        /// For document length limits, maximum batch size, and supported text encoding, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/overview#data-limits"/>.
        /// </summary>
        /// <param name="documents">The list of documents to analyze.</param>
        /// <param name="options"> The different operations to pass as options.
        /// You can use it to have multiple tasks to analyze as well as multiple task item per each individual task.
        /// For example -
        ///    AnalyzeOperationOptions operationOptions = new AnalyzeOperationOptions()
        ///    {
        ///        KeyPhrasesTaskParameters = new KeyPhrasesTaskParameters(),
        ///        EntitiesTaskParameters = new EntitiesTaskParameters(),
        ///        PiiTaskParameters = new PiiTaskParameters(),
        ///        DisplayName = "AnalyzeOperation"
        ///    };
        /// By default ModelVersion is set as 'latest' and it can set from the task parameters.
        /// KeyPhrasesTaskParameters = new KeyPhrasesTaskParameters()
        /// {
        ///     ModelVersion = "latest"
        /// },
        /// For additional configurable options see <see cref="AnalyzeOperationOptions"/> </param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="RequestFailedException">Service returned a non-success
        /// status code.</exception>
        public virtual AnalyzeOperation StartAnalyzeOperationBatch(IEnumerable<TextDocumentInput> documents, AnalyzeOperationOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            Argument.AssertNotNull(options, nameof(options));
            MultiLanguageBatchInput documentInputs = ConvertToMultiLanguageInputs(documents);

            return StartAnalyzeOperationBatch(documentInputs, options, cancellationToken);
        }

        /// <summary>
        /// Analyze Operation enables the application to have multiple tasks including NER, PII and KPE.
        /// Accepts a list of strings which are analyzed asynchronously.
        /// For document length limits, maximum batch size, and supported text encoding, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/text-analytics/overview#data-limits"/>.
        /// </summary>
        /// <param name="documents">The list of documents to analyze.</param>
        /// <param name="options"> The different operations to pass as options.
        /// You can use it to have multiple tasks to analyze as well as multiple task item per each individual task.
        /// For example -
        ///    AnalyzeOperationOptions operationOptions = new AnalyzeOperationOptions()
        ///    {
        ///        KeyPhrasesTaskParameters = new KeyPhrasesTaskParameters(),
        ///        EntitiesTaskParameters = new EntitiesTaskParameters(),
        ///        PiiTaskParameters = new PiiTaskParameters(),
        ///        DisplayName = "AnalyzeOperation"
        ///    };
        /// By default ModelVersion is set as 'latest' and it can set from the task parameters.
        /// KeyPhrasesTaskParameters = new KeyPhrasesTaskParameters()
        /// {
        ///     ModelVersion = "latest"
        /// },
        /// For additional configurable options see <see cref="AnalyzeOperationOptions"/> </param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="RequestFailedException">Service returned a non-success
        /// status code.</exception>
        public virtual async Task<AnalyzeOperation> StartAnalyzeOperationBatchAsync(IEnumerable<TextDocumentInput> documents, AnalyzeOperationOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(documents, nameof(documents));
            Argument.AssertNotNull(options, nameof(options));
            MultiLanguageBatchInput documentInputs = ConvertToMultiLanguageInputs(documents);

            return await StartAnalyzeOperationBatchAsync(documentInputs, options, cancellationToken).ConfigureAwait(false);
        }

        private AnalyzeOperation StartAnalyzeOperationBatch(MultiLanguageBatchInput batchInput, AnalyzeOperationOptions options, CancellationToken cancellationToken = default)
        {
            JobManifestTasks tasks = new JobManifestTasks();

            if (options.PiiTaskParameters != null)
            {
                tasks.EntityRecognitionPiiTasks = new List<PiiTask>() { new PiiTask() { Parameters = options.PiiTaskParameters } };
            }
            if (options.EntitiesTaskParameters != null)
            {
                tasks.EntityRecognitionTasks = new List<EntitiesTask>() { new EntitiesTask() { Parameters = options.EntitiesTaskParameters } };
            }
            if (options.KeyPhrasesTaskParameters != null)
            {
                tasks.KeyPhraseExtractionTasks = new List<KeyPhrasesTask>() { new KeyPhrasesTask() { Parameters = options.KeyPhrasesTaskParameters } };
            }

            AnalyzeBatchInput analyzeDocumentInputs = new AnalyzeBatchInput(batchInput, tasks, options.DisplayName);

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(StartAnalyzeOperationBatch)}");
            scope.Start();

            try
            {
                // TODO - Add Top and Skip once pagination is implemented for Analyze operation
                // Github issue - https://github.com/Azure/azure-sdk-for-net/issues/16958
                int _top = default;
                int _skip = default;

                ResponseWithHeaders<TextAnalyticsAnalyzeHeaders> response = _serviceRestClient.Analyze(analyzeDocumentInputs, cancellationToken);
                string location = response.Headers.OperationLocation;

                IDictionary<string, int> idToIndexMap = CreateIdToIndexMap(batchInput.Documents);

                return new AnalyzeOperation(_serviceRestClient, _clientDiagnostics, location, idToIndexMap, _top, _skip, options.IncludeStatistics);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private async Task<AnalyzeOperation> StartAnalyzeOperationBatchAsync(MultiLanguageBatchInput batchInput, AnalyzeOperationOptions options, CancellationToken cancellationToken = default)
        {
            JobManifestTasks tasks = new JobManifestTasks();

            if (options.PiiTaskParameters != null)
            {
                tasks.EntityRecognitionPiiTasks = new List<PiiTask>() { new PiiTask() { Parameters = options.PiiTaskParameters } };
            }
            if (options.EntitiesTaskParameters != null)
            {
                tasks.EntityRecognitionTasks = new List<EntitiesTask>() { new EntitiesTask() { Parameters = options.EntitiesTaskParameters } };
            }
            if (options.KeyPhrasesTaskParameters != null)
            {
                tasks.KeyPhraseExtractionTasks = new List<KeyPhrasesTask>() { new KeyPhrasesTask() { Parameters = options.KeyPhrasesTaskParameters } };
            }

            AnalyzeBatchInput analyzeDocumentInputs = new AnalyzeBatchInput(batchInput, tasks, options.DisplayName);

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(StartAnalyzeOperationBatch)}");
            scope.Start();

            try
            {
                // TODO - Add Top and Skip once pagination is implemented for Analyze operation
                // Github issue - https://github.com/Azure/azure-sdk-for-net/issues/16958
                int _top = default;
                int _skip = default;

                ResponseWithHeaders<TextAnalyticsAnalyzeHeaders> response = await _serviceRestClient.AnalyzeAsync(analyzeDocumentInputs, cancellationToken).ConfigureAwait(false);
                string location = response.Headers.OperationLocation;

                IDictionary<string, int> idToIndexMap = CreateIdToIndexMap(batchInput.Documents);

                return new AnalyzeOperation(_serviceRestClient, _clientDiagnostics, location, idToIndexMap, _top, _skip, options.IncludeStatistics);
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
                    LanguageInput li => li.Id,
                    MultiLanguageInput mli => mli.Id,
                    _ => throw new NotSupportedException(),
                };

                map[id] = i++;
            }

            return map;
        }

        private MultiLanguageInput ConvertToMultiLanguageInput(string document, string language, int id = 0)
            => new MultiLanguageInput($"{id}", document) { Language = language ?? _options.DefaultLanguage};

        private MultiLanguageBatchInput ConvertToMultiLanguageInputs(IEnumerable<string> documents, string language)
            => new MultiLanguageBatchInput(documents.Select((document, i) => ConvertToMultiLanguageInput(document, language, i)).ToList());

        private MultiLanguageBatchInput ConvertToMultiLanguageInputs(IEnumerable<TextDocumentInput> documents)
            => new MultiLanguageBatchInput(documents.Select((document) => new MultiLanguageInput(document.Id, document.Text) { Language = document.Language ?? _options.DefaultLanguage}).ToList());

        private LanguageInput ConvertToLanguageInput(string document, string countryHint, int id = 0)
            => new LanguageInput($"{id}", document) { CountryHint = countryHint ?? _options.DefaultCountryHint };

        private LanguageBatchInput ConvertToLanguageInputs(IEnumerable<string> documents, string countryHint)
            => new LanguageBatchInput(documents.Select((document, i) => ConvertToLanguageInput(document, countryHint, i)).ToList());

        private LanguageBatchInput ConvertToLanguageInputs(IEnumerable<DetectLanguageInput> documents)
            => new LanguageBatchInput(documents.Select((document) => new LanguageInput(document.Id, document.Text) { CountryHint = document.CountryHint ?? _options.DefaultCountryHint }).ToList());

        private static IDictionary<string,string> CreateAdditionalInformation(TextAnalyticsError error)
        {
            if (string.IsNullOrEmpty(error.Target))
                return null;
            return new Dictionary<string, string> { { "Target", error.Target } };
        }

        #endregion

        #region nobody wants to see these
        /// <summary>
        /// Check if two TextAnalyticsClient instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => base.Equals(obj);

        /// <summary>
        /// Get a hash code for the TextAnalyticsClient.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();

        /// <summary>
        /// TextAnalyticsClient ToString.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() => base.ToString();
        #endregion
    }
}
