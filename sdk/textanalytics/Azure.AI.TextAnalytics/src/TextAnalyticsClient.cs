﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
        /// Initializes a new instance of the <see cref="TextAnalyticsClient"/>
        /// class for the specified service instance.
        /// </summary>
        /// <param name="endpoint">A <see cref="Uri"/> to the service the client
        /// sends requests to.  Endpoint can be found in the Azure portal.</param>
        /// <param name="credential">The API key used to access
        /// the service. This will allow you to update the API key
        /// without creating a new client.</param>
        public TextAnalyticsClient(Uri endpoint, TextAnalyticsApiKeyCredential credential)
            : this(endpoint, credential, new TextAnalyticsClientOptions())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TextAnalyticsClient"/>
        /// class for the specified service instance.
        /// </summary>
        /// <param name="endpoint">A <see cref="Uri"/> to the service the client
        /// sends requests to.  Endpoint can be found in the Azure portal.</param>
        /// <param name="credential">The API key used to access
        /// the service. This will allow you to update the API key
        /// without creating a new client.</param>
        /// <param name="options"><see cref="TextAnalyticsClientOptions"/> that allow
        /// callers to configure how requests are sent to the service.</param>
        public TextAnalyticsClient(Uri endpoint, TextAnalyticsApiKeyCredential credential, TextAnalyticsClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNull(options, nameof(options));

            _baseUri = endpoint;
            _apiVersion = options.GetVersionString();
            _pipeline = HttpPipelineBuilder.Build(options, new ApiKeyAuthenticationPolicy(credential));
            _clientDiagnostics = new ClientDiagnostics(options);
            _options = options;
        }

        #region Detect Language

        /// <summary>
        /// Runs a predictive model to determine the language that the passed-in
        /// input text is written in, and returns the detected language as well
        /// as a score indicating the model's confidence that the inferred
        /// language is correct.  Scores close to 1 indicate high certainty in
        /// the result.  120 languages are supported.
        /// </summary>
        /// <param name="inputText">The text to analyze.</param>
        /// <param name="countryHint">Indicates the country of origin of the text
        /// input to assist the text analytics model in predicting the language
        /// it is written in.  If unspecified, this value will be set to the
        /// default country hint in <see cref="TextAnalyticsClientOptions"/>
        /// in the request sent to the service.  If set to an empty string, the
        /// service will apply a model where the country is explicitly set to
        /// "None".</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>
        /// controlling the request lifetime.</param>
        /// <returns>A result containing the detected language or an error if
        /// the model could not analyze the input text.</returns>
        /// <exception cref="RequestFailedException">Service returned a non-success
        /// status code.</exception>
        public virtual async Task<Response<DetectLanguageResult>> DetectLanguageAsync(string inputText, string countryHint = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputText, nameof(inputText));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(DetectLanguage)}");
            scope.AddAttribute("inputText", inputText);
            scope.Start();

            try
            {
                DetectLanguageInput[] inputs = new DetectLanguageInput[] { ConvertToDetectLanguageInput(inputText, countryHint) };
                using Request request = CreateDetectLanguageRequest(inputs, new TextAnalyticsRequestOptions());
                Response response = await _pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);

                switch (response.Status)
                {
                    case 200:
                        IDictionary<string, int> map = CreateIdToIndexMap(inputs);
                        DetectLanguageResultCollection result = await CreateDetectLanguageResponseAsync(response, map, cancellationToken).ConfigureAwait(false);
                        if (result[0].ErrorMessage != default)
                        {
                            // only one input, so we can ignore the id and grab the first error message.
                            throw await response.CreateRequestFailedExceptionAsync(result[0].ErrorMessage).ConfigureAwait(false);
                        }
                        return Response.FromValue(result[0], response);
                    default:
                        throw await response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Runs a predictive model to determine the language that the passed-in
        /// input text is written in, and returns the detected language as well
        /// as a score indicating the model's confidence that the inferred
        /// language is correct.  Scores close to 1 indicate high certainty in
        /// the result.  120 languages are supported.
        /// </summary>
        /// <param name="inputText">The text to analyze.</param>
        /// <param name="countryHint">Indicates the country of origin of the text
        /// input to assist the text analytics model in predicting the language
        /// it is written in.  If unspecified, this value will be set to the
        /// default country hint in <see cref="TextAnalyticsClientOptions"/>
        /// in the request sent to the service.  If set to an empty string, the
        /// service will apply a model where the country is explicitly set to
        /// "None".</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>
        /// controlling the request lifetime.</param>
        /// <returns>A result containing the detected language or an error if
        /// the model could not analyze the input text.</returns>
        /// <exception cref="RequestFailedException">Service returned a non-success
        /// status code.</exception>
        public virtual Response<DetectLanguageResult> DetectLanguage(string inputText, string countryHint = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputText, nameof(inputText));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(DetectLanguage)}");
            scope.AddAttribute("inputText", inputText);
            scope.Start();

            try
            {
                List<DetectLanguageInput> inputs = ConvertToDetectLanguageInputs(new string[] { inputText }, countryHint);
                using Request request = CreateDetectLanguageRequest(inputs, new TextAnalyticsRequestOptions());
                Response response = _pipeline.SendRequest(request, cancellationToken);

                switch (response.Status)
                {
                    case 200:
                        IDictionary<string, int> map = CreateIdToIndexMap(inputs);
                        DetectLanguageResultCollection result = CreateDetectLanguageResponse(response, map);
                        if (result[0].ErrorMessage != default)
                        {
                            // only one input, so we can ignore the id and grab the first error message.
                            throw response.CreateRequestFailedException(result[0].ErrorMessage);
                        }
                        return Response.FromValue(result[0], response);
                    default:
                        throw response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Runs a predictive model to determine the language that the passed-in
        /// input strings are written in, and returns, for each one, the detected
        /// language as well as a score indicating the model's confidence that
        /// the inferred language is correct.  Scores close to 1 indicate high
        /// certainty in the result.  120 languages are supported.
        /// </summary>
        /// <param name="inputs">A collection of input strings to analyze.</param>
        /// <param name="countryHint">Indicates the country of origin of all of
        /// the input strings to assist the text analytics model in predicting
        /// the language they is written in.  If unspecified, this value will be
        /// set to the default country hint in <see cref="TextAnalyticsClientOptions"/>
        /// in the request sent to the service.  If set to an empty string, the
        /// service will apply a model where the country is explicitly set to
        /// "None".  The same country hint is applied to all strings in the
        /// input collection.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>
        /// controlling the request lifetime.</param>
        /// <returns>A result containing the detected language or an error if
        /// the model could not analyze the input text.</returns>
        /// <exception cref="RequestFailedException">Service returned a non-success
        /// status code.</exception>
        public virtual async Task<Response<DetectLanguageResultCollection>> DetectLanguageAsync(IEnumerable<string> inputs, string countryHint = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));
            List<DetectLanguageInput> detectLanguageInputs = ConvertToDetectLanguageInputs(inputs, countryHint);
            return await DetectLanguageAsync(detectLanguageInputs, new TextAnalyticsRequestOptions(), cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Runs a predictive model to determine the language that the passed-in
        /// input strings are written in, and returns, for each one, the detected
        /// language as well as a score indicating the model's confidence that
        /// the inferred language is correct.  Scores close to 1 indicate high
        /// certainty in the result.  120 languages are supported.
        /// </summary>
        /// <param name="inputs">A collection of input strings to analyze.</param>
        /// <param name="countryHint">Indicates the country of origin of all of
        /// the input strings to assist the text analytics model in predicting
        /// the language they is written in.  If unspecified, this value will be
        /// set to the default country hint in <see cref="TextAnalyticsClientOptions"/>
        /// in the request sent to the service.  If set to an empty string, the
        /// service will apply a model where the country is explicitly set to
        /// "None".  The same country hint is applied to all strings in the
        /// input collection.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>
        /// controlling the request lifetime.</param>
        /// <returns>A result containing the detected language or an error if
        /// the model could not analyze the input text.</returns>
        /// <exception cref="RequestFailedException">Service returned a non-success
        /// status code.</exception>
        public virtual Response<DetectLanguageResultCollection> DetectLanguage(IEnumerable<string> inputs, string countryHint = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));
            List<DetectLanguageInput> detectLanguageInputs = ConvertToDetectLanguageInputs(inputs, countryHint);
            return DetectLanguage(detectLanguageInputs, new TextAnalyticsRequestOptions(), cancellationToken);
        }

        /// <summary>
        /// Runs a predictive model to determine the language that the passed-in
        /// input documents are written in, and returns, for each one, the detected
        /// language as well as a score indicating the model's confidence that
        /// the inferred language is correct.  Scores close to 1 indicate high
        /// certainty in the result.  120 languages are supported.
        /// </summary>
        /// <param name="inputs">A collection of input documents to analyze.</param>
        /// <param name="options"><see cref="TextAnalyticsRequestOptions"/> used to
        /// select the version of the predictive model to run, and whether
        /// statistics are returned in the response.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>
        /// controlling the request lifetime.</param>
        /// <returns>A result containing the detected language or an error if
        /// the model could not analyze the input text.</returns>
        /// <exception cref="RequestFailedException">Service returned a non-success
        /// status code.</exception>
        public virtual async Task<Response<DetectLanguageResultCollection>> DetectLanguageAsync(IEnumerable<DetectLanguageInput> inputs, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));
            options ??= new TextAnalyticsRequestOptions();

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(DetectLanguage)}");
            scope.Start();

            try
            {
                using Request request = CreateDetectLanguageRequest(inputs, options);
                Response response = await _pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);

                switch (response.Status)
                {
                    case 200:
                        IDictionary<string, int> map = CreateIdToIndexMap(inputs);
                        return await CreateDetectLanguageResponseAsync(response, map, cancellationToken).ConfigureAwait(false);
                    default:
                        throw await response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Runs a predictive model to determine the language that the passed-in
        /// input documents are written in, and returns, for each one, the detected
        /// language as well as a score indicating the model's confidence that
        /// the inferred language is correct.  Scores close to 1 indicate high
        /// certainty in the result.  120 languages are supported.
        /// </summary>
        /// <param name="inputs">A collection of input documents to analyze.</param>
        /// <param name="options"><see cref="TextAnalyticsRequestOptions"/> used to
        /// select the version of the predictive model to run, and whether
        /// statistics are returned in the response.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>
        /// controlling the request lifetime.</param>
        /// <returns>A result containing the detected language or an error if
        /// the model could not analyze the input text.</returns>
        /// <exception cref="RequestFailedException">Service returned a non-success
        /// status code.</exception>
        public virtual Response<DetectLanguageResultCollection> DetectLanguage(IEnumerable<DetectLanguageInput> inputs, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));
            options ??= new TextAnalyticsRequestOptions();

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(DetectLanguage)}");
            scope.Start();

            try
            {
                using Request request = CreateDetectLanguageRequest(inputs, options);
                Response response = _pipeline.SendRequest(request, cancellationToken);

                switch (response.Status)
                {
                    case 200:
                        IDictionary<string, int> map = CreateIdToIndexMap(inputs);
                        return CreateDetectLanguageResponse(response, map);
                    default:
                        throw response.CreateRequestFailedException();
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
        /// in the passed-in input text, and categorize those entities into types
        /// such as person, location, or organization.  For more information on
        /// available categories, see
        /// <a href="https://docs.microsoft.com/en-us/azure/cognitive-services/Text-Analytics/named-entity-types"/>.
        /// For a list of languages supported by this operation, see
        /// <a href="https://docs.microsoft.com/en-us/azure/cognitive-services/text-analytics/language-support"/>.
        /// </summary>
        /// <param name="inputText">The text to analyze.</param>
        /// <param name="language">The language that the input text is written in.
        /// If unspecified, this value will be set to the default language in
        /// <see cref="TextAnalyticsClientOptions"/> in the request sent to the
        /// service.  If set to an empty string, the service will apply a model
        /// where the language is explicitly set to "None".</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>
        /// controlling the request lifetime.</param>
        /// <returns>A result containing the collection of entities identified
        /// in the input text, as well as a score indicating the confidence
        /// that the entity correctly matches the identified substring.</returns>
        /// <exception cref="RequestFailedException">Service returned a non-success
        /// status code.</exception>
        public virtual async Task<Response<RecognizeEntitiesResult>> RecognizeEntitiesAsync(string inputText, string language = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputText, nameof(inputText));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(RecognizeEntities)}");
            scope.AddAttribute("inputText", inputText);
            scope.Start();

            try
            {
                TextDocumentInput[] inputs = new TextDocumentInput[] { ConvertToDocumentInput(inputText, language) };
                using Request request = CreateDocumentInputRequest(inputs, new TextAnalyticsRequestOptions(), EntitiesRoute);
                Response response = await _pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);

                switch (response.Status)
                {
                    case 200:
                        IDictionary<string, int> map = CreateIdToIndexMap(inputs);
                        RecognizeEntitiesResultCollection results = await CreateRecognizeEntitiesResponseAsync(response, map, cancellationToken).ConfigureAwait(false);
                        if (results[0].ErrorMessage != default)
                        {
                            // only one input, so we can ignore the id and grab the first error message.
                            throw await response.CreateRequestFailedExceptionAsync(results[0].ErrorMessage).ConfigureAwait(false);
                        }
                        return Response.FromValue(results[0], response);
                    default:
                        throw await response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
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
        /// in the passed-in input text, and categorize those entities into types
        /// such as person, location, or organization.  For more information on
        /// available categories, see
        /// <a href="https://docs.microsoft.com/en-us/azure/cognitive-services/Text-Analytics/named-entity-types"/>.
        /// For a list of languages supported by this operation, see
        /// <a href="https://docs.microsoft.com/en-us/azure/cognitive-services/text-analytics/language-support"/>.
        /// </summary>
        /// <param name="inputText">The text to analyze.</param>
        /// <param name="language">The language that the input text is written in.
        /// If unspecified, this value will be set to the default language in
        /// <see cref="TextAnalyticsClientOptions"/> in the request sent to the
        /// service.  If set to an empty string, the service will apply a model
        /// where the language is explicitly set to "None".</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>
        /// controlling the request lifetime.</param>
        /// <returns>A result containing the collection of entities identified
        /// in the input text, as well as a score indicating the confidence
        /// that the entity correctly matches the identified substring.</returns>
        /// <exception cref="RequestFailedException">Service returned a non-success
        /// status code.</exception>
        public virtual Response<RecognizeEntitiesResult> RecognizeEntities(string inputText, string language = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputText, nameof(inputText));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(RecognizeEntities)}");
            scope.AddAttribute("inputText", inputText);
            scope.Start();

            try
            {
                TextDocumentInput[] inputs = new TextDocumentInput[] { ConvertToDocumentInput(inputText, language) };
                using Request request = CreateDocumentInputRequest(inputs, new TextAnalyticsRequestOptions(), EntitiesRoute);
                Response response = _pipeline.SendRequest(request, cancellationToken);

                switch (response.Status)
                {
                    case 200:
                        IDictionary<string, int> map = CreateIdToIndexMap(inputs);
                        RecognizeEntitiesResultCollection results = CreateRecognizeEntitiesResponse(response, map);
                        if (results[0].ErrorMessage != default)
                        {
                            // only one input, so we can ignore the id and grab the first error message.
                            throw response.CreateRequestFailedException(results[0].ErrorMessage);
                        }
                        return Response.FromValue(results[0], response);
                    default:
                        throw response.CreateRequestFailedException();
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
        /// in the passed-in input strings, and categorize those entities into types
        /// such as person, location, or organization.  For more information on
        /// available categories, see
        /// https://docs.microsoft.com/en-us/azure/cognitive-services/Text-Analytics/named-entity-types.
        /// For a list of languages supported by this operation, see
        /// https://docs.microsoft.com/en-us/azure/cognitive-services/text-analytics/language-support.
        /// </summary>
        /// <param name="inputs">The input strings to analyze.</param>
        /// <param name="language">The language that all the input strings are
        /// written in. If unspecified, this value will be set to the default
        /// language in <see cref="TextAnalyticsClientOptions"/> in the request
        /// sent to the service.  If set to an empty string, the service will apply a model
        /// where the language is explicitly set to "None".</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>
        /// controlling the request lifetime.</param>
        /// <returns>A result containing the collection of entities identified
        /// for each of the inputs, as well as scores indicating the confidence
        /// that a given entity correctly matches the identified substring.</returns>
        /// <exception cref="RequestFailedException">Service returned a non-success
        /// status code.</exception>
        public virtual async Task<Response<RecognizeEntitiesResultCollection>> RecognizeEntitiesAsync(IEnumerable<string> inputs, string language = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));
            List<TextDocumentInput> documentInputs = ConvertToDocumentInputs(inputs, language);
            return await RecognizeEntitiesAsync(documentInputs, new TextAnalyticsRequestOptions(), cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Runs a predictive model to identify a collection of named entities
        /// in the passed-in input strings, and categorize those entities into types
        /// such as person, location, or organization.  For more information on
        /// available categories, see
        /// https://docs.microsoft.com/en-us/azure/cognitive-services/Text-Analytics/named-entity-types.
        /// For a list of languages supported by this operation, see
        /// https://docs.microsoft.com/en-us/azure/cognitive-services/text-analytics/language-support.
        /// </summary>
        /// <param name="inputs">The input strings to analyze.</param>
        /// <param name="language">The language that all the input strings are
        /// written in. If unspecified, this value will be set to the default
        /// language in <see cref="TextAnalyticsClientOptions"/> in the request
        /// sent to the service.  If set to an empty string, the service will apply a model
        /// where the language is explicitly set to "None".</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>
        /// controlling the request lifetime.</param>
        /// <returns>A result containing the collection of entities identified
        /// for each of the inputs, as well as scores indicating the confidence
        /// that a given entity correctly matches the identified substring.</returns>
        /// <exception cref="RequestFailedException">Service returned a non-success
        /// status code.</exception>
        public virtual Response<RecognizeEntitiesResultCollection> RecognizeEntities(IEnumerable<string> inputs, string language = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));
            List<TextDocumentInput> documentInputs = ConvertToDocumentInputs(inputs, language);
            return RecognizeEntities(documentInputs, new TextAnalyticsRequestOptions(), cancellationToken);
        }

        /// <summary>
        /// Runs a predictive model to identify a collection of named entities
        /// in the passed-in input documents, and categorize those entities into types
        /// such as person, location, or organization.  For more information on
        /// available categories, see
        /// https://docs.microsoft.com/en-us/azure/cognitive-services/Text-Analytics/named-entity-types.
        /// For a list of languages supported by this operation, see
        /// https://docs.microsoft.com/en-us/azure/cognitive-services/text-analytics/language-support.
        /// </summary>
        /// <param name="inputs">The input documents to analyze.</param>
        /// <param name="options"><see cref="TextAnalyticsRequestOptions"/> used to
        /// select the version of the predictive model to run, and whether
        /// statistics are returned in the response.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>
        /// controlling the request lifetime.</param>
        /// <returns>A result containing the collection of entities identified
        /// for each of the inputs, as well as scores indicating the confidence
        /// that a given entity correctly matches the identified substring.</returns>
        /// <exception cref="RequestFailedException">Service returned a non-success
        /// status code.</exception>
        public virtual async Task<Response<RecognizeEntitiesResultCollection>> RecognizeEntitiesAsync(IEnumerable<TextDocumentInput> inputs, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));
            options ??= new TextAnalyticsRequestOptions();

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(RecognizeEntities)}");
            scope.Start();

            try
            {
                using Request request = CreateDocumentInputRequest(inputs, options, EntitiesRoute);
                Response response = await _pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);

                switch (response.Status)
                {
                    case 200:
                        IDictionary<string, int> map = CreateIdToIndexMap(inputs);
                        return await CreateRecognizeEntitiesResponseAsync(response, map, cancellationToken).ConfigureAwait(false);
                    default:
                        throw await response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
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
        /// in the passed-in input documents, and categorize those entities into types
        /// such as person, location, or organization.  For more information on
        /// available categories, see
        /// https://docs.microsoft.com/en-us/azure/cognitive-services/Text-Analytics/named-entity-types.
        /// For a list of languages supported by this operation, see
        /// https://docs.microsoft.com/en-us/azure/cognitive-services/text-analytics/language-support.
        /// </summary>
        /// <param name="inputs">The input documents to analyze.</param>
        /// <param name="options"><see cref="TextAnalyticsRequestOptions"/> used to
        /// select the version of the predictive model to run, and whether
        /// statistics are returned in the response.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>
        /// controlling the request lifetime.</param>
        /// <returns>A result containing the collection of entities identified
        /// for each of the inputs, as well as scores indicating the confidence
        /// that a given entity correctly matches the identified substring.</returns>
        /// <exception cref="RequestFailedException">Service returned a non-success
        /// status code.</exception>
        public virtual Response<RecognizeEntitiesResultCollection> RecognizeEntities(IEnumerable<TextDocumentInput> inputs, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));
            options ??= new TextAnalyticsRequestOptions();

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(RecognizeEntities)}");
            scope.Start();

            try
            {
                using Request request = CreateDocumentInputRequest(inputs, options, EntitiesRoute);
                Response response = _pipeline.SendRequest(request, cancellationToken);

                switch (response.Status)
                {
                    case 200:
                        IDictionary<string, int> map = CreateIdToIndexMap(inputs);
                        return CreateRecognizeEntitiesResponse(response, map);
                    default:
                        throw response.CreateRequestFailedException();
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
        /// or mixed sentiment contained in the input text, as well as a score
        /// indicating the model's confidence in the predicted sentiment.
        /// For a list of languages supported by this operation, see
        /// <a href="https://docs.microsoft.com/en-us/azure/cognitive-services/text-analytics/language-support"/>.
        /// </summary>
        /// <param name="inputText">The text to analyze.</param>
        /// <param name="language">The language that the input text is written in.
        /// If unspecified, this value will be set to the default language in
        /// <see cref="TextAnalyticsClientOptions"/> in the request sent to the
        /// service.  If set to an empty string, the service will apply a model
        /// where the language is explicitly set to "None".</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>
        /// controlling the request lifetime.</param>
        /// <returns>A result containing sentiment predictions for the input text
        /// and each of the sentences it contains.</returns>
        /// <exception cref="RequestFailedException">Service returned a non-success
        /// status code.</exception>
        public virtual async Task<Response<AnalyzeSentimentResult>> AnalyzeSentimentAsync(string inputText, string language = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputText, nameof(inputText));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(AnalyzeSentiment)}");
            scope.AddAttribute("inputText", inputText);
            scope.Start();

            try
            {
                TextDocumentInput[] inputs = new TextDocumentInput[] { ConvertToDocumentInput(inputText, language) };
                using Request request = CreateDocumentInputRequest(inputs, new TextAnalyticsRequestOptions(), SentimentRoute);
                Response response = await _pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);

                switch (response.Status)
                {
                    case 200:
                        IDictionary<string, int> map = CreateIdToIndexMap(inputs);
                        AnalyzeSentimentResultCollection results = await CreateAnalyzeSentimentResponseAsync(response, map, cancellationToken).ConfigureAwait(false);
                        if (results[0].ErrorMessage != default)
                        {
                            // only one input, so we can ignore the id and grab the first error message.
                            throw await response.CreateRequestFailedExceptionAsync(results[0].ErrorMessage).ConfigureAwait(false);
                        }
                        return Response.FromValue(results[0], response);
                    default:
                        throw await response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
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
        /// sentiment contained in the input text, as well as a score indicating the model's
        /// confidence in the predicted sentiment.
        /// For a list of languages supported by this operation, see
        /// <a href="https://docs.microsoft.com/en-us/azure/cognitive-services/text-analytics/language-support"/>.
        /// </summary>
        /// <param name="inputText">The text to analyze.</param>
        /// <param name="language">The language that the input text is written in.
        /// If unspecified, this value will be set to the default language in
        /// <see cref="TextAnalyticsClientOptions"/> in the request sent to the
        /// service.  If set to an empty string, the service will apply a model
        /// where the language is explicitly set to "None".</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>
        /// controlling the request lifetime.</param>
        /// <returns>A result containing sentiment predictions for the input text
        /// and each of the sentences it contains.</returns>
        /// <exception cref="RequestFailedException">Service returned a non-success
        /// status code.</exception>
        public virtual Response<AnalyzeSentimentResult> AnalyzeSentiment(string inputText, string language = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputText, nameof(inputText));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(AnalyzeSentiment)}");
            scope.AddAttribute("inputText", inputText);
            scope.Start();

            try
            {
                TextDocumentInput[] inputs = new TextDocumentInput[] { ConvertToDocumentInput(inputText, language) };
                using Request request = CreateDocumentInputRequest(inputs, new TextAnalyticsRequestOptions(), SentimentRoute);
                Response response = _pipeline.SendRequest(request, cancellationToken);

                switch (response.Status)
                {
                    case 200:
                        IDictionary<string, int> map = CreateIdToIndexMap(inputs);
                        AnalyzeSentimentResultCollection results = CreateAnalyzeSentimentResponse(response, map);
                        if (results[0].ErrorMessage != default)
                        {
                            // only one input, so we can ignore the id and grab the first error message.
                            throw response.CreateRequestFailedException(results[0].ErrorMessage);
                        }
                        return Response.FromValue(results[0], response);
                    default:
                        throw response.CreateRequestFailedException();
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
        /// sentiment contained in the input strings, as well as scores indicating
        /// the model's confidence in each of the predicted sentiments.
        /// For a list of languages supported by this operation, see
        /// https://docs.microsoft.com/en-us/azure/cognitive-services/text-analytics/language-support.
        /// </summary>
        /// <param name="inputs">The input strings to analyze.</param>
        /// <param name="language">The language that all of the input strings are written in.
        /// If unspecified, this value will be set to the default language in
        /// <see cref="TextAnalyticsClientOptions"/> in the request sent to the
        /// service.  If set to an empty string, the service will apply a model
        /// where the language is explicitly set to "None".</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>
        /// controlling the request lifetime.</param>
        /// <returns>A result containing sentiment predictions for each of the input strings
        /// and predictions for each of the sentences each input contains.</returns>
        /// <exception cref="RequestFailedException">Service returned a non-success
        /// status code.</exception>
        public virtual async Task<Response<AnalyzeSentimentResultCollection>> AnalyzeSentimentAsync(IEnumerable<string> inputs, string language = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));
            List<TextDocumentInput> documentInputs = ConvertToDocumentInputs(inputs, language);
            return await AnalyzeSentimentAsync(documentInputs, new TextAnalyticsRequestOptions(), cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Runs a predictive model to identify the positive, negative or neutral
        /// sentiment contained in the input strings, as well as scores indicating
        /// the model's confidence in each of the predicted sentiments.
        /// For a list of languages supported by this operation, see
        /// https://docs.microsoft.com/en-us/azure/cognitive-services/text-analytics/language-support.
        /// </summary>
        /// <param name="inputs">The input strings to analyze.</param>
        /// <param name="language">The language that all of the input strings are written in.
        /// If unspecified, this value will be set to the default language in
        /// <see cref="TextAnalyticsClientOptions"/> in the request sent to the
        /// service.  If set to an empty string, the service will apply a model
        /// where the language is explicitly set to "None".</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>
        /// controlling the request lifetime.</param>
        /// <returns>A result containing sentiment predictions for each of the input strings
        /// and predictions for each of the sentences each input contains.</returns>
        /// <exception cref="RequestFailedException">Service returned a non-success
        /// status code.</exception>
        public virtual Response<AnalyzeSentimentResultCollection> AnalyzeSentiment(IEnumerable<string> inputs, string language = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));
            List<TextDocumentInput> documentInputs = ConvertToDocumentInputs(inputs, language);
            return AnalyzeSentiment(documentInputs, new TextAnalyticsRequestOptions(), cancellationToken);
        }

        /// <summary>
        /// Runs a predictive model to identify the positive, negative or neutral
        /// sentiment contained in the input documents, as well as scores indicating
        /// the model's confidence in each of the predicted sentiments.
        /// For a list of languages supported by this operation, see
        /// https://docs.microsoft.com/en-us/azure/cognitive-services/text-analytics/language-support.
        /// </summary>
        /// <param name="inputs">The input strings to analyze.</param>
        /// <param name="options"><see cref="TextAnalyticsRequestOptions"/> used to
        /// select the version of the predictive model to run, and whether
        /// statistics are returned in the response.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>
        /// controlling the request lifetime.</param>
        /// <returns>A result containing sentiment predictions for each of the input documents
        /// and predictions for each of the sentences each input contains.</returns>
        /// <exception cref="RequestFailedException">Service returned a non-success
        /// status code.</exception>
        public virtual async Task<Response<AnalyzeSentimentResultCollection>> AnalyzeSentimentAsync(IEnumerable<TextDocumentInput> inputs, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));
            options ??= new TextAnalyticsRequestOptions();

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(AnalyzeSentiment)}");
            scope.Start();

            try
            {
                using Request request = CreateDocumentInputRequest(inputs, options, SentimentRoute);
                Response response = await _pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);

                switch (response.Status)
                {
                    case 200:
                        IDictionary<string, int> map = CreateIdToIndexMap(inputs);
                        return await CreateAnalyzeSentimentResponseAsync(response, map, cancellationToken).ConfigureAwait(false);
                    default:
                        throw await response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
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
        /// sentiment contained in the input documents, as well as scores indicating
        /// the model's confidence in each of the predicted sentiments.
        /// For a list of languages supported by this operation, see
        /// https://docs.microsoft.com/en-us/azure/cognitive-services/text-analytics/language-support.
        /// </summary>
        /// <param name="inputs">The input strings to analyze.</param>
        /// <param name="options"><see cref="TextAnalyticsRequestOptions"/> used to
        /// select the version of the predictive model to run, and whether
        /// statistics are returned in the response.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>
        /// controlling the request lifetime.</param>
        /// <returns>A result containing sentiment predictions for each of the input documents
        /// and predictions for each of the sentences each input contains.</returns>
        /// <exception cref="RequestFailedException">Service returned a non-success
        /// status code.</exception>
        public virtual Response<AnalyzeSentimentResultCollection> AnalyzeSentiment(IEnumerable<TextDocumentInput> inputs, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));
            options ??= new TextAnalyticsRequestOptions();

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(AnalyzeSentiment)}");
            scope.Start();

            try
            {
                using Request request = CreateDocumentInputRequest(inputs, options, SentimentRoute);
                Response response = _pipeline.SendRequest(request, cancellationToken);

                switch (response.Status)
                {
                    case 200:
                        IDictionary<string, int> map = CreateIdToIndexMap(inputs);
                        return CreateAnalyzeSentimentResponse(response, map);
                    default:
                        throw response.CreateRequestFailedException();
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
        /// found in the passed-in input text.
        /// For a list of languages supported by this operation, see
        /// <a href="https://docs.microsoft.com/en-us/azure/cognitive-services/text-analytics/language-support"/>.
        /// </summary>
        /// <param name="inputText">The text to analyze.</param>
        /// <param name="language">The language that the input text is written in.
        /// If unspecified, this value will be set to the default language in
        /// <see cref="TextAnalyticsClientOptions"/> in the request sent to the
        /// service.  If set to an empty string, the service will apply a model
        /// where the language is explicitly set to "None".</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>
        /// controlling the request lifetime.</param>
        /// <returns>A result containing the collection of key phrases identified
        /// in the input text.</returns>
        /// <exception cref="RequestFailedException">Service returned a non-success
        /// status code.</exception>
        public virtual async Task<Response<ExtractKeyPhrasesResult>> ExtractKeyPhrasesAsync(string inputText, string language = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputText, nameof(inputText));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(ExtractKeyPhrases)}");
            scope.AddAttribute("inputText", inputText);
            scope.Start();

            try
            {
                TextDocumentInput[] inputs = new TextDocumentInput[] { ConvertToDocumentInput(inputText, language) };
                using Request request = CreateDocumentInputRequest(inputs, new TextAnalyticsRequestOptions(), KeyPhrasesRoute);
                Response response = await _pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);

                switch (response.Status)
                {
                    case 200:
                        IDictionary<string, int> map = CreateIdToIndexMap(inputs);
                        ExtractKeyPhrasesResultCollection result = await CreateKeyPhraseResponseAsync(response, map, cancellationToken).ConfigureAwait(false);
                        if (result[0].ErrorMessage != default)
                        {
                            // only one input, so we can ignore the id and grab the first error message.
                            throw await response.CreateRequestFailedExceptionAsync(result[0].ErrorMessage).ConfigureAwait(false);
                        }
                        return Response.FromValue(result[0], response);
                    default:
                        throw await response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
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
        /// found in the passed-in input text.
        /// For a list of languages supported by this operation, see
        /// <a href="https://docs.microsoft.com/en-us/azure/cognitive-services/text-analytics/language-support"/>.
        /// </summary>
        /// <param name="inputText">The text to analyze.</param>
        /// <param name="language">The language that the input text is written in.
        /// If unspecified, this value will be set to the default language in
        /// <see cref="TextAnalyticsClientOptions"/> in the request sent to the
        /// service.  If set to an empty string, the service will apply a model
        /// where the language is explicitly set to "None".</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>
        /// controlling the request lifetime.</param>
        /// <returns>A result containing the collection of key phrases identified
        /// in the input text.</returns>
        /// <exception cref="RequestFailedException">Service returned a non-success
        /// status code.</exception>
        public virtual Response<ExtractKeyPhrasesResult> ExtractKeyPhrases(string inputText, string language = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputText, nameof(inputText));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(ExtractKeyPhrases)}");
            scope.AddAttribute("inputText", inputText);
            scope.Start();

            try
            {
                TextDocumentInput[] inputs = new TextDocumentInput[] { ConvertToDocumentInput(inputText, language) };
                using Request request = CreateDocumentInputRequest(inputs, new TextAnalyticsRequestOptions(), KeyPhrasesRoute);
                Response response = _pipeline.SendRequest(request, cancellationToken);

                switch (response.Status)
                {
                    case 200:
                        IDictionary<string, int> map = CreateIdToIndexMap(inputs);
                        ExtractKeyPhrasesResultCollection result = CreateKeyPhraseResponse(response, map);
                        if (result[0].ErrorMessage != default)
                        {
                            // only one input, so we can ignore the id and grab the first error message.
                            throw response.CreateRequestFailedException(result[0].ErrorMessage);
                        }
                        return Response.FromValue(result[0], response);
                    default:
                        throw response.CreateRequestFailedException();
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
        /// found in the passed-in input text.
        /// For a list of languages supported by this operation, see
        /// https://docs.microsoft.com/en-us/azure/cognitive-services/text-analytics/language-support.
        /// </summary>
        /// <param name="inputs">The input strings to analyze.</param>
        /// <param name="language">The language that all the input strings are
        /// written in. If unspecified, this value will be set to the default
        /// language in <see cref="TextAnalyticsClientOptions"/> in the request
        /// sent to the service.  If set to an empty string, the service will apply a model
        /// where the language is explicitly set to "None".</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>
        /// controlling the request lifetime.</param>
        /// <returns>A result containing the collection of key phrases identified
        /// in each of the inputs.</returns>
        /// <exception cref="RequestFailedException">Service returned a non-success
        /// status code.</exception>
        public virtual async Task<Response<ExtractKeyPhrasesResultCollection>> ExtractKeyPhrasesAsync(IEnumerable<string> inputs, string language = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));
            List<TextDocumentInput> documentInputs = ConvertToDocumentInputs(inputs, language);
            return await ExtractKeyPhrasesAsync(documentInputs, new TextAnalyticsRequestOptions(), cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Runs a model to identify a collection of significant phrases
        /// found in the passed-in input text.
        /// For a list of languages supported by this operation, see
        /// https://docs.microsoft.com/en-us/azure/cognitive-services/text-analytics/language-support.
        /// </summary>
        /// <param name="inputs">The input strings to analyze.</param>
        /// <param name="language">The language that all the input strings are
        /// written in. If unspecified, this value will be set to the default
        /// language in <see cref="TextAnalyticsClientOptions"/> in the request
        /// sent to the service.  If set to an empty string, the service will apply a model
        /// where the language is explicitly set to "None".</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>
        /// controlling the request lifetime.</param>
        /// <returns>A result containing the collection of key phrases identified
        /// in each of the inputs.</returns>
        /// <exception cref="RequestFailedException">Service returned a non-success
        /// status code.</exception>
        public virtual Response<ExtractKeyPhrasesResultCollection> ExtractKeyPhrases(IEnumerable<string> inputs, string language = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));
            List<TextDocumentInput> documentInputs = ConvertToDocumentInputs(inputs, language);
            return ExtractKeyPhrases(documentInputs, new TextAnalyticsRequestOptions(), cancellationToken);
        }

        /// <summary>
        /// Runs a model to identify a collection of significant phrases
        /// found in the passed-in input text.
        /// For a list of languages supported by this operation, see
        /// https://docs.microsoft.com/en-us/azure/cognitive-services/text-analytics/language-support.
        /// </summary>
        /// <param name="inputs">The input documents to analyze.</param>
        /// <param name="options"><see cref="TextAnalyticsRequestOptions"/> used to
        /// select the version of the predictive model to run, and whether
        /// statistics are returned in the response.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>
        /// controlling the request lifetime.</param>
        /// <returns>A result containing the collection of key phrases identified
        /// in each of the input documents.</returns>
        /// <exception cref="RequestFailedException">Service returned a non-success
        /// status code.</exception>
        public virtual async Task<Response<ExtractKeyPhrasesResultCollection>> ExtractKeyPhrasesAsync(IEnumerable<TextDocumentInput> inputs, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));
            options ??= new TextAnalyticsRequestOptions();

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(ExtractKeyPhrases)}");
            scope.Start();

            try
            {
                using Request request = CreateDocumentInputRequest(inputs, options, KeyPhrasesRoute);
                Response response = await _pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);

                switch (response.Status)
                {
                    case 200:
                        IDictionary<string, int> map = CreateIdToIndexMap(inputs);
                        return await CreateKeyPhraseResponseAsync(response, map, cancellationToken).ConfigureAwait(false);
                    default:
                        throw response.CreateRequestFailedException();
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
        /// found in the passed-in input text.
        /// For a list of languages supported by this operation, see
        /// https://docs.microsoft.com/en-us/azure/cognitive-services/text-analytics/language-support.
        /// </summary>
        /// <param name="inputs">The input documents to analyze.</param>
        /// <param name="options"><see cref="TextAnalyticsRequestOptions"/> used to
        /// select the version of the predictive model to run, and whether
        /// statistics are returned in the response.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>
        /// controlling the request lifetime.</param>
        /// <returns>A result containing the collection of key phrases identified
        /// in each of the input documents.</returns>
        /// <exception cref="RequestFailedException">Service returned a non-success
        /// status code.</exception>
        public virtual Response<ExtractKeyPhrasesResultCollection> ExtractKeyPhrases(IEnumerable<TextDocumentInput> inputs, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));
            options ??= new TextAnalyticsRequestOptions();

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(ExtractKeyPhrases)}");
            scope.Start();

            try
            {
                using Request request = CreateDocumentInputRequest(inputs, options, KeyPhrasesRoute);
                Response response = _pipeline.SendRequest(request, cancellationToken);

                switch (response.Status)
                {
                    case 200:
                        IDictionary<string, int> map = CreateIdToIndexMap(inputs);
                        return CreateKeyPhraseResponse(response, map);
                    default:
                        throw response.CreateRequestFailedException();
                }
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
        /// Personally Identifiable Information found in the passed-in input text,
        /// and categorize those entities into types such as US social security
        /// number, drivers license number, or credit card number.
        /// For a list of languages supported by this operation, see
        /// <a href="https://docs.microsoft.com/en-us/azure/cognitive-services/text-analytics/language-support"/>.
        /// </summary>
        /// <param name="inputText">The text to analyze.</param>
        /// <param name="language">The language that the input text is written in.
        /// If unspecified, this value will be set to the default language in
        /// <see cref="TextAnalyticsClientOptions"/> in the request sent to the
        /// service.  If set to an empty string, the service will apply a model
        /// where the language is explicitly set to "None".</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>
        /// controlling the request lifetime.</param>
        /// <returns>A result containing the collection of entities identified
        /// in the input text, as well as a score indicating the confidence
        /// that the entity correctly matches the identified substring.</returns>
        /// <exception cref="RequestFailedException">Service returned a non-success
        /// status code.</exception>
        public virtual async Task<Response<RecognizePiiEntitiesResult>> RecognizePiiEntitiesAsync(string inputText, string language = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputText, nameof(inputText));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(RecognizePiiEntities)}");
            scope.AddAttribute("inputText", inputText);
            scope.Start();

            try
            {
                TextDocumentInput[] inputs = new TextDocumentInput[] { ConvertToDocumentInput(inputText, language) };
                using Request request = CreateDocumentInputRequest(inputs, new TextAnalyticsRequestOptions(), PiiEntitiesRoute);
                Response response = await _pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);

                switch (response.Status)
                {
                    case 200:
                        IDictionary<string, int> map = CreateIdToIndexMap(inputs);
                        RecognizePiiEntitiesResultCollection results = await CreateRecognizePiiEntitiesResponseAsync(response, map, cancellationToken).ConfigureAwait(false);
                        if (results[0].ErrorMessage != default)
                        {
                            // only one input, so we can ignore the id and grab the first error message.
                            throw await response.CreateRequestFailedExceptionAsync(results[0].ErrorMessage).ConfigureAwait(false);
                        }
                        return Response.FromValue(results[0], response);
                    default:
                        throw await response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Runs a predictive model to identify a collection of entities containing
        /// Personally Identifiable Information found in the passed-in input text,
        /// and categorize those entities into types such as US social security
        /// number, drivers license number, or credit card number.
        /// For a list of languages supported by this operation, see
        /// <a href="https://docs.microsoft.com/en-us/azure/cognitive-services/text-analytics/language-support"/>.
        /// </summary>
        /// <param name="inputText">The text to analyze.</param>
        /// <param name="language">The language that the input text is written in.
        /// If unspecified, this value will be set to the default language in
        /// <see cref="TextAnalyticsClientOptions"/> in the request sent to the
        /// service.  If set to an empty string, the service will apply a model
        /// where the language is explicitly set to "None".</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>
        /// controlling the request lifetime.</param>
        /// <returns>A result containing the collection of entities identified
        /// in the input text, as well as a score indicating the confidence
        /// that the entity correctly matches the identified substring.</returns>
        /// <exception cref="RequestFailedException">Service returned a non-success
        /// status code.</exception>
        public virtual Response<RecognizePiiEntitiesResult> RecognizePiiEntities(string inputText, string language = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputText, nameof(inputText));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(RecognizePiiEntities)}");
            scope.AddAttribute("inputText", inputText);
            scope.Start();

            try
            {
                TextDocumentInput[] inputs = new TextDocumentInput[] { ConvertToDocumentInput(inputText, language) };
                using Request request = CreateDocumentInputRequest(inputs, new TextAnalyticsRequestOptions(), PiiEntitiesRoute);
                Response response = _pipeline.SendRequest(request, cancellationToken);

                switch (response.Status)
                {
                    case 200:
                        IDictionary<string, int> map = CreateIdToIndexMap(inputs);
                        RecognizePiiEntitiesResultCollection results = CreateRecognizePiiEntitiesResponse(response, map);
                        if (results[0].ErrorMessage != default)
                        {
                            // only one input, so we can ignore the id and grab the first error message.
                            throw response.CreateRequestFailedException(results[0].ErrorMessage);
                        }
                        return Response.FromValue(results[0], response);
                    default:
                        throw response.CreateRequestFailedException();
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Runs a predictive model to identify a collection of entities containing
        /// Personally Identifiable Information found in the passed-in input strings,
        /// and categorize those entities into types such as US social security
        /// number, drivers license number, or credit card number.
        /// For a list of languages supported by this operation, see
        /// https://docs.microsoft.com/en-us/azure/cognitive-services/text-analytics/language-support.
        /// </summary>
        /// <param name="inputs">The input strings to analyze.</param>
        /// <param name="language">The language that the input text is written in.
        /// If unspecified, this value will be set to the default language in
        /// <see cref="TextAnalyticsClientOptions"/> in the request sent to the
        /// service.  If set to an empty string, the service will apply a model
        /// where the language is explicitly set to "None".</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>
        /// controlling the request lifetime.</param>
        /// <returns>A result containing the collection of entities identified
        /// for each of the inputs, as well as scores indicating the confidence
        /// that a given entity correctly matches the identified substring.</returns>
        /// <exception cref="RequestFailedException">Service returned a non-success
        /// status code.</exception>
        public virtual async Task<Response<RecognizePiiEntitiesResultCollection>> RecognizePiiEntitiesAsync(IEnumerable<string> inputs, string language = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));
            List<TextDocumentInput> documentInputs = ConvertToDocumentInputs(inputs, language);
            return await RecognizePiiEntitiesAsync(documentInputs, new TextAnalyticsRequestOptions(), cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Runs a predictive model to identify a collection of entities containing
        /// Personally Identifiable Information found in the passed-in input strings,
        /// and categorize those entities into types such as US social security
        /// number, drivers license number, or credit card number.
        /// For a list of languages supported by this operation, see
        /// https://docs.microsoft.com/en-us/azure/cognitive-services/text-analytics/language-support.
        /// </summary>
        /// <param name="inputs">The input strings to analyze.</param>
        /// <param name="language">The language that the input text is written in.
        /// If unspecified, this value will be set to the default language in
        /// <see cref="TextAnalyticsClientOptions"/> in the request sent to the
        /// service.  If set to an empty string, the service will apply a model
        /// where the language is explicitly set to "None".</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>
        /// controlling the request lifetime.</param>
        /// <returns>A result containing the collection of entities identified
        /// for each of the inputs, as well as scores indicating the confidence
        /// that a given entity correctly matches the identified substring.</returns>
        /// <exception cref="RequestFailedException">Service returned a non-success
        /// status code.</exception>
        public virtual Response<RecognizePiiEntitiesResultCollection> RecognizePiiEntities(IEnumerable<string> inputs, string language = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));
            List<TextDocumentInput> documentInputs = ConvertToDocumentInputs(inputs, language);
            return RecognizePiiEntities(documentInputs, new TextAnalyticsRequestOptions(), cancellationToken);
        }

        /// <summary>
        /// Runs a predictive model to identify a collection of entities containing
        /// Personally Identifiable Information found in the passed-in input documents,
        /// and categorize those entities into types such as US social security
        /// number, drivers license number, or credit card number.
        /// For a list of languages supported by this operation, see
        /// https://docs.microsoft.com/en-us/azure/cognitive-services/text-analytics/language-support.
        /// </summary>
        /// <param name="inputs">The input documents to analyze.</param>
        /// <param name="options"><see cref="TextAnalyticsRequestOptions"/> used to
        /// select the version of the predictive model to run, and whether
        /// statistics are returned in the response.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>
        /// controlling the request lifetime.</param>
        /// <returns>A result containing the collection of entities identified
        /// for each of the inputs, as well as scores indicating the confidence
        /// that a given entity correctly matches the identified substring.</returns>
        /// <exception cref="RequestFailedException">Service returned a non-success
        /// status code.</exception>
        public virtual async Task<Response<RecognizePiiEntitiesResultCollection>> RecognizePiiEntitiesAsync(IEnumerable<TextDocumentInput> inputs, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));
            options ??= new TextAnalyticsRequestOptions();

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(RecognizePiiEntities)}");
            scope.Start();

            try
            {
                using Request request = CreateDocumentInputRequest(inputs, options, PiiEntitiesRoute);
                Response response = await _pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);

                switch (response.Status)
                {
                    case 200:
                        IDictionary<string, int> map = CreateIdToIndexMap(inputs);
                        return await CreateRecognizePiiEntitiesResponseAsync(response, map, cancellationToken).ConfigureAwait(false);
                    default:
                        throw await response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Runs a predictive model to identify a collection of entities containing
        /// Personally Identifiable Information found in the passed-in input documents,
        /// and categorize those entities into types such as US social security
        /// number, drivers license number, or credit card number.
        /// For a list of languages supported by this operation, see
        /// https://docs.microsoft.com/en-us/azure/cognitive-services/text-analytics/language-support.
        /// </summary>
        /// <param name="inputs">The input documents to analyze.</param>
        /// <param name="options"><see cref="TextAnalyticsRequestOptions"/> used to
        /// select the version of the predictive model to run, and whether
        /// statistics are returned in the response.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>
        /// controlling the request lifetime.</param>
        /// <returns>A result containing the collection of entities identified
        /// for each of the inputs, as well as scores indicating the confidence
        /// that a given entity correctly matches the identified substring.</returns>
        /// <exception cref="RequestFailedException">Service returned a non-success
        /// status code.</exception>
        public virtual Response<RecognizePiiEntitiesResultCollection> RecognizePiiEntities(IEnumerable<TextDocumentInput> inputs, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));
            options ??= new TextAnalyticsRequestOptions();

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(RecognizePiiEntities)}");
            scope.Start();

            try
            {
                using Request request = CreateDocumentInputRequest(inputs, options, PiiEntitiesRoute);
                Response response = _pipeline.SendRequest(request, cancellationToken);

                switch (response.Status)
                {
                    case 200:
                        IDictionary<string, int> map = CreateIdToIndexMap(inputs);
                        return CreateRecognizePiiEntitiesResponse(response, map);
                    default:
                        throw response.CreateRequestFailedException();
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
        /// found in the passed-in input text, and include information linking the
        /// entities to their corresponding entries in a well-known knowledge base.
        /// For a list of languages supported by this operation, see
        /// <a href="https://docs.microsoft.com/en-us/azure/cognitive-services/text-analytics/language-support"/>.
        /// </summary>
        /// <param name="inputText">The text to analyze.</param>
        /// <param name="language">The language that the input text is written in.
        /// If unspecified, this value will be set to the default language in
        /// <see cref="TextAnalyticsClientOptions"/> in the request sent to the
        /// service.  If set to an empty string, the service will apply a model
        /// where the language is explicitly set to "None".</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>
        /// controlling the request lifetime.</param>
        /// <returns>A result containing the collection of linked entities identified
        /// in the input text, as well as scores indicating the confidence
        /// that the entity correctly matches the identified substring.</returns>
        /// <exception cref="RequestFailedException">Service returned a non-success
        /// status code.</exception>
        public virtual async Task<Response<RecognizeLinkedEntitiesResult>> RecognizeLinkedEntitiesAsync(string inputText, string language = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputText, nameof(inputText));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(RecognizeLinkedEntities)}");
            scope.AddAttribute("inputText", inputText);
            scope.Start();

            try
            {
                TextDocumentInput[] inputs = new TextDocumentInput[] { ConvertToDocumentInput(inputText, language) };
                using Request request = CreateDocumentInputRequest(inputs, new TextAnalyticsRequestOptions(), EntityLinkingRoute);
                Response response = await _pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);

                switch (response.Status)
                {
                    case 200:
                        IDictionary<string, int> map = CreateIdToIndexMap(inputs);
                        RecognizeLinkedEntitiesResultCollection result = await CreateLinkedEntityResponseAsync(response, map, cancellationToken).ConfigureAwait(false);
                        if (result[0].ErrorMessage != default)
                        {
                            // only one input, so we can ignore the id and grab the first error message.
                            throw await response.CreateRequestFailedExceptionAsync(result[0].ErrorMessage).ConfigureAwait(false);
                        }
                        return Response.FromValue(result[0], response);
                    default:
                        throw await response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
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
        /// found in the passed-in input text, and include information linking the
        /// entities to their corresponding entries in a well-known knowledge base.
        /// For a list of languages supported by this operation, see
        /// <a href="https://docs.microsoft.com/en-us/azure/cognitive-services/text-analytics/language-support"/>.
        /// </summary>
        /// <param name="inputText">The text to analyze.</param>
        /// <param name="language">The language that the input text is written in.
        /// If unspecified, this value will be set to the default language in
        /// <see cref="TextAnalyticsClientOptions"/> in the request sent to the
        /// service.  If set to an empty string, the service will apply a model
        /// where the language is explicitly set to "None".</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>
        /// controlling the request lifetime.</param>
        /// <returns>A result containing the collection of linked entities identified
        /// in the input text, as well as scores indicating the confidence
        /// that the entity correctly matches the identified substring.</returns>
        /// <exception cref="RequestFailedException">Service returned a non-success
        /// status code.</exception>
        public virtual Response<RecognizeLinkedEntitiesResult> RecognizeLinkedEntities(string inputText, string language = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputText, nameof(inputText));

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(RecognizeLinkedEntities)}");
            scope.AddAttribute("inputText", inputText);
            scope.Start();

            try
            {
                TextDocumentInput[] inputs = new TextDocumentInput[] { ConvertToDocumentInput(inputText, language) };
                using Request request = CreateDocumentInputRequest(inputs, new TextAnalyticsRequestOptions(), EntityLinkingRoute);
                Response response = _pipeline.SendRequest(request, cancellationToken);

                switch (response.Status)
                {
                    case 200:
                        IDictionary<string, int> map = CreateIdToIndexMap(inputs);
                        RecognizeLinkedEntitiesResultCollection results = CreateLinkedEntityResponse(response, map);
                        if (results[0].ErrorMessage != default)
                        {
                            // only one input, so we can ignore the id and grab the first error message.
                            throw response.CreateRequestFailedException(results[0].ErrorMessage);
                        }
                        return Response.FromValue(results[0], response);
                    default:
                        throw response.CreateRequestFailedException();
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
        /// found in the passed-in input strings, and include information linking the
        /// entities to their corresponding entries in a well-known knowledge base.
        /// For a list of languages supported by this operation, see
        /// <a href="https://docs.microsoft.com/en-us/azure/cognitive-services/text-analytics/language-support"/>.
        /// </summary>
        /// <param name="inputs">The input strings to analyze.</param>
        /// <param name="language">The language that the input text is written in.
        /// If unspecified, this value will be set to the default language in
        /// <see cref="TextAnalyticsClientOptions"/> in the request sent to the
        /// service.  If set to an empty string, the service will apply a model
        /// where the language is explicitly set to "None".</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>
        /// controlling the request lifetime.</param>
        /// <returns>A result containing the collection of entities identified
        /// for each of the inputs, as well as scores indicating the confidence
        /// that a given entity correctly matches the identified substring.</returns>
        /// <exception cref="RequestFailedException">Service returned a non-success
        /// status code.</exception>
        public virtual async Task<Response<RecognizeLinkedEntitiesResultCollection>> RecognizeLinkedEntitiesAsync(IEnumerable<string> inputs, string language = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));
            List<TextDocumentInput> documentInputs = ConvertToDocumentInputs(inputs, language);
            return await RecognizeLinkedEntitiesAsync(documentInputs, new TextAnalyticsRequestOptions(), cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Runs a predictive model to identify a collection of entities
        /// found in the passed-in input strings, and include information linking the
        /// entities to their corresponding entries in a well-known knowledge base.
        /// For a list of languages supported by this operation, see
        /// <a href="https://docs.microsoft.com/en-us/azure/cognitive-services/text-analytics/language-support"/>.
        /// </summary>
        /// <param name="inputs">The input strings to analyze.</param>
        /// <param name="language">The language that the input text is written in.
        /// If unspecified, this value will be set to the default language in
        /// <see cref="TextAnalyticsClientOptions"/> in the request sent to the
        /// service.  If set to an empty string, the service will apply a model
        /// where the language is explicitly set to "None".</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>
        /// controlling the request lifetime.</param>
        /// <returns>A result containing the collection of entities identified
        /// for each of the inputs, as well as scores indicating the confidence
        /// that a given entity correctly matches the identified substring.</returns>
        /// <exception cref="RequestFailedException">Service returned a non-success
        /// status code.</exception>
        public virtual Response<RecognizeLinkedEntitiesResultCollection> RecognizeLinkedEntities(IEnumerable<string> inputs, string language = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));
            List<TextDocumentInput> documentInputs = ConvertToDocumentInputs(inputs, language);
            return RecognizeLinkedEntities(documentInputs, new TextAnalyticsRequestOptions(), cancellationToken);
        }

        /// <summary>
        /// Runs a predictive model to identify a collection of entities
        /// found in the passed-in input documents, and include information linking the
        /// entities to their corresponding entries in a well-known knowledge base.
        /// For a list of languages supported by this operation, see
        /// <a href="https://docs.microsoft.com/en-us/azure/cognitive-services/text-analytics/language-support"/>.
        /// </summary>
        /// <param name="inputs">The input documents to analyze.</param>
        /// <param name="options"><see cref="TextAnalyticsRequestOptions"/> used to
        /// select the version of the predictive model to run, and whether
        /// statistics are returned in the response.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>
        /// controlling the request lifetime.</param>
        /// <returns>A result containing the collection of entities identified
        /// for each of the inputs, as well as scores indicating the confidence
        /// that a given entity correctly matches the identified substring.</returns>
        /// <exception cref="RequestFailedException">Service returned a non-success
        /// status code.</exception>
        public virtual async Task<Response<RecognizeLinkedEntitiesResultCollection>> RecognizeLinkedEntitiesAsync(IEnumerable<TextDocumentInput> inputs, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));
            options ??= new TextAnalyticsRequestOptions();

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(RecognizeLinkedEntities)}");
            scope.Start();

            try
            {
                using Request request = CreateDocumentInputRequest(inputs, options, EntityLinkingRoute);
                Response response = await _pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);

                switch (response.Status)
                {
                    case 200:
                        IDictionary<string, int> map = CreateIdToIndexMap(inputs);
                        return await CreateLinkedEntityResponseAsync(response, map, cancellationToken).ConfigureAwait(false);
                    default:
                        throw await response.CreateRequestFailedExceptionAsync().ConfigureAwait(false);
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
        /// found in the passed-in input documents, and include information linking the
        /// entities to their corresponding entries in a well-known knowledge base.
        /// For a list of languages supported by this operation, see
        /// <a href="https://docs.microsoft.com/en-us/azure/cognitive-services/text-analytics/language-support"/>.
        /// </summary>
        /// <param name="inputs">The input documents to analyze.</param>
        /// <param name="options"><see cref="TextAnalyticsRequestOptions"/> used to
        /// select the version of the predictive model to run, and whether
        /// statistics are returned in the response.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>
        /// controlling the request lifetime.</param>
        /// <returns>A result containing the collection of entities identified
        /// for each of the inputs, as well as scores indicating the confidence
        /// that a given entity correctly matches the identified substring.</returns>
        /// <exception cref="RequestFailedException">Service returned a non-success
        /// status code.</exception>
        public virtual Response<RecognizeLinkedEntitiesResultCollection> RecognizeLinkedEntities(IEnumerable<TextDocumentInput> inputs, TextAnalyticsRequestOptions options = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));
            options ??= new TextAnalyticsRequestOptions();

            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(TextAnalyticsClient)}.{nameof(RecognizeLinkedEntities)}");
            scope.Start();

            try
            {
                using Request request = CreateDocumentInputRequest(inputs, options, EntityLinkingRoute);
                Response response = _pipeline.SendRequest(request, cancellationToken);

                switch (response.Status)
                {
                    case 200:
                        IDictionary<string, int> map = CreateIdToIndexMap(inputs);
                        return CreateLinkedEntityResponse(response, map);
                    default:
                        throw response.CreateRequestFailedException();
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

        private static IDictionary<string, int> CreateIdToIndexMap<T>(IEnumerable<T> inputs)
        {
            var map = new Dictionary<string, int>(inputs.Count());

            int i = 0;
            foreach (T item in inputs)
            {
                string id = item switch
                {
                    TextDocumentInput tdi => tdi.Id,
                    DetectLanguageInput dli => dli.Id,
                    _ => throw new NotSupportedException(),
                };

                map[id] = i++;
            }

            return map;
        }

        internal virtual TextDocumentInput ConvertToDocumentInput(string input, string language, int id = 0)
            => new TextDocumentInput($"{id}", input) { Language = language ?? _options.DefaultLanguage };

        private List<TextDocumentInput> ConvertToDocumentInputs(IEnumerable<string> inputs, string language)
            => inputs.Select((input, i) => ConvertToDocumentInput(input, language, i)).ToList();

        private DetectLanguageInput ConvertToDetectLanguageInput(string input, string countryHint, int id = 0)
            => new DetectLanguageInput($"{id}", input) { CountryHint = countryHint ?? _options.DefaultCountryHint };

        private List<DetectLanguageInput> ConvertToDetectLanguageInputs(IEnumerable<string> inputs, string countryHint)
            => inputs.Select((input, i) => ConvertToDetectLanguageInput(input, countryHint, i)).ToList();

        private Request CreateDocumentInputRequest(IEnumerable<TextDocumentInput> inputs, TextAnalyticsRequestOptions options, string route)
        {
            Request request = _pipeline.CreateRequest();

            ReadOnlyMemory<byte> content = TextAnalyticsServiceSerializer.SerializeDocumentInputs(inputs, _options.DefaultLanguage);

            request.Method = RequestMethod.Post;
            BuildUriForRoute(route, request.Uri, options);

            request.Headers.Add(HttpHeader.Common.JsonContentType);
            request.Content = RequestContent.Create(content);

            return request;
        }

        private Request CreateDetectLanguageRequest(IEnumerable<DetectLanguageInput> inputs, TextAnalyticsRequestOptions options)
        {
            Request request = _pipeline.CreateRequest();

            ReadOnlyMemory<byte> content = TextAnalyticsServiceSerializer.SerializeDetectLanguageInputs(inputs, _options.DefaultCountryHint);

            request.Method = RequestMethod.Post;
            BuildUriForRoute(LanguagesRoute, request.Uri, options);

            request.Headers.Add(HttpHeader.Common.JsonContentType);
            request.Content = RequestContent.Create(content);

            return request;
        }
        #endregion
    }
}
