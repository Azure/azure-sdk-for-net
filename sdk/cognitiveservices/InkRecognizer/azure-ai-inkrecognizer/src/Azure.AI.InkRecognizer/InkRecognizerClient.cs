// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Azure.AI.InkRecognizer.Models;
using Azure.Core;
using Azure.Core.Pipeline;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

[assembly: AzureSdkClientLibrary(".Net")]

namespace Azure.AI.InkRecognizer
{
    /// <summary>
    /// The client to use for interacting with the Azure Ink Recognizer service.
    /// </summary>
    public class InkRecognizerClient
    {
        private readonly Uri _endpoint;
        private readonly InkRecognizerCredential _credential;

        private readonly InkRecognizerClientOptions _options;

        /// <summary>
        /// Protected constructor to allow mocking
        /// </summary>
        protected InkRecognizerClient()
        {

        }

        ///<summary>
        /// Initializes a new instance of <see cref="InkRecognizerClient"/>.
        ///</summary>
        ///<param name="endpoint">Endpoint URI for InkRecognizer service.</param>
        ///<param name="credentials">The application key received after signing up for the service.</param>
        public InkRecognizerClient(Uri endpoint, InkRecognizerCredential credential)
            : this(endpoint, credential, new InkRecognizerClientOptions())
        {}

        /// <summary>
        /// Initializes a new instance of <see cref="InkRecognizerClient"/>.
        /// </summary>
        /// <param name="endPoint">Endpoint URI for InkRecognizer service.</param>
        /// <param name="credentials">The application key received after signing up for the service.</param>
        /// <param name="options">Options that allow to configure the request sent to the InkRecognizer service.</param>
        public InkRecognizerClient(
            Uri endpoint,
            InkRecognizerCredential credential,
            InkRecognizerClientOptions options)
        {
            var destination = endpoint.AbsoluteUri;
            var serviceVersion = _getServiceVersion(options.Version);
            _endpoint = new Uri(destination + serviceVersion);
            _options = options;
            _credential = credential;
        }

        /// <summary>
        /// Synchronously sends data to the service and generates a tree structure containing the model results.
        /// </summary>
        /// <param name="strokes">The list of ink strokes to recognize.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns> RecognitionRoot containing the model results in a hierarchy.</returns>
        /// <exception cref="RequestFailedException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual Response<RecognitionRoot> RecognizeInk(
            IEnumerable<InkStroke> strokes,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return RecognizeInk(strokes,
                _options.InkPointUnit,
                _options.UnitMultiple,
                _options.Language,
                cancellationToken);
        }

        /// <summary>
        /// Synchronously sends data to the service and generates a tree structure containing the model results.
        /// </summary>
        /// <param name="strokes">The list of ink strokes to recognize.</param>
        /// <param name="unit"> The physical unit for the points in the stroke.</param>
        /// <param name="unitMultiple"> A multiplier applied to the unit value to indicate the true unit being used.
        /// This allows the caller to specify values in a fraction or multiple of a unit.</param>
        /// <param name="language"> IETF BCP 47 language code (for ex. en-US, en-GB, hi-IN etc.) for the strokes.
        /// This is only needed when the language is different from the default set when the client was instantiated.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns> RecognitionRoot containing the model results in a hierarchy. </returns>
        /// <exception cref="RequestFailedException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual Response<RecognitionRoot> RecognizeInk(
            IEnumerable<InkStroke> strokes,
            InkPointUnit unit,
            float unitMultiple,
            string language,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            if (strokes == null) throw new ArgumentNullException(nameof(strokes));

            try
            {
                var policies = new HttpPipelinePolicy[] { _options.TelemetryPolicy, _options.LoggingPolicy, _options.RetryPolicy };

                var pipeline = HttpPipelineBuilder.Build(_options, true, policies);
                var request = _createInkRecognitionRequest(pipeline,
                    strokes,
                    _options.ApplicationKind,
                    language,
                    unit,
                    unitMultiple,
                    cancellationToken);
                var response = pipeline.SendRequest(request, cancellationToken);

                var reader = new StreamReader(response.ContentStream);
                string responseText = reader.ReadToEnd();

                if (response.Status == 200)
                {
                    var root = InkRecognitionResponse.Parse(responseText);
                    return new Response<RecognitionRoot>(response, root);
                }
                // For bad requests and internal server errors
                else if (response.Status >= 400 && response.Status < 600)
                {
                    var serverError = new HttpErrorDetails(responseText);
                    var responseFailedException = response.CreateRequestFailedException(serverError.ToString());
                    throw responseFailedException;
                }
                // For all other http errors
                {
                    var responseFailedException = response.CreateRequestFailedException(responseText);
                    throw responseFailedException;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Asynchronously sends data to the service and generates a tree structure containing the model results.
        /// </summary>
        /// <param name="strokes">The list of ink strokes to recognize.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns> RecognitionRoot containing the model results in a hierarchy.</returns>
        /// <exception cref="RequestFailedException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<Response<RecognitionRoot>> RecognizeInkAsync(
            IEnumerable<InkStroke> strokes,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return await RecognizeInkAsync(strokes,
                _options.InkPointUnit,
                _options.UnitMultiple,
                _options.Language,
                cancellationToken);
        }

        /// <summary>
        /// Asynchronously sends data to the service and generates a tree structure containing the model results.
        /// </summary>
        /// <param name="strokes">The list of ink strokes to recognize.</param>
        /// <param name="unit"> The physical unit for the points in the stroke.</param>
        /// <param name="unitMultiple"> A multiplier applied to the unit value to indicate the true unit being used.
        /// This allows the caller to specify values in a fraction or multiple of a unit.</param>
        /// <param name="language"> IETF BCP 47 language code (for ex. en-US, en-GB, hi-IN etc.) for the strokes.
        /// This is only needed when the language is different from the default set when the client was instantiated.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <returns> RecognitionRoot containing the model results in a hierarchy. </returns>
        /// <exception cref="RequestFailedException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public virtual async Task<Response<RecognitionRoot>> RecognizeInkAsync(
            IEnumerable<InkStroke> strokes,
            InkPointUnit unit,
            float unitMultiple,
            string language,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            if (strokes == null) throw new ArgumentNullException(nameof(strokes));

            try
            {
                var policies = new HttpPipelinePolicy[] {_options.TelemetryPolicy, _options.LoggingPolicy, _options.RetryPolicy};

                var pipeline = HttpPipelineBuilder.Build(_options, true, policies);
                var request = _createInkRecognitionRequest(pipeline,
                    strokes,
                    _options.ApplicationKind,
                    language,
                    unit,
                    unitMultiple,
                    cancellationToken);
                var response = await pipeline.SendRequestAsync(request, cancellationToken);

                var reader = new StreamReader(response.ContentStream);
                string responseText = reader.ReadToEnd();

                if (response.Status == 200)
                {
                    var root = InkRecognitionResponse.Parse(responseText);
                    return new Response<RecognitionRoot>(response, root);
                }
                // For bad requests and internal server errors
                else if (response.Status >= 400 && response.Status < 600)
                {
                    var serverError = new HttpErrorDetails(responseText);
                    var responseFailedException = await response.CreateRequestFailedExceptionAsync(serverError.ToString());
                    throw responseFailedException;
                }
                else
                {
                    // For all other http errors
                    var responseFailedException = await response.CreateRequestFailedExceptionAsync(responseText);
                    throw responseFailedException;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private Request _createInkRecognitionRequest(HttpPipeline pipeline,
            IEnumerable<InkStroke> strokes,
            ApplicationKind applicationKind,
            string language,
            InkPointUnit inkPointUnit,
            float unitMultiple,
            CancellationToken cancellationToken)
        {
            Request request = pipeline.CreateRequest();

            // add content
            var inkRecognitionRequest = new InkRecognitionRequest(strokes,
                applicationKind,
                language,
                inkPointUnit,
                unitMultiple);
            var content = new MemoryStream(Encoding.UTF8.GetBytes(inkRecognitionRequest.ToJson()));
            request.Content = HttpPipelineRequestContent.Create(content);

            // specify HTTP request line
            request.SetRequestLine(HttpPipelineMethod.Put, _endpoint);

            // add headers for authentication
            _credential.SetRequestCredentials(request, cancellationToken);

            return request;
        }

        private string _getServiceVersion(InkRecognizerClientOptions.ServiceVersion version)
        {
            switch (version)
            {
                case InkRecognizerClientOptions.ServiceVersion.Preview_1_0_0:
                    return "/v1.0-preview/recognize";

                default:
                    throw new InvalidEnumArgumentException("Invalid Service version");
            }
        }
    }

    public class InkRecognizerCredential
    {
        private readonly string _appKey;

        /// <summary>
        /// Initializes a new instance of <see cref="InkRecognizerClient"/>.
        /// </summary>
        /// <param name="subscriptionKey">Subscription key for authenticating with InkRecognizer service.</param>
        public InkRecognizerCredential(string subscriptionKey)
        {
            _appKey = subscriptionKey;
        }

        /// <summary>
        /// Sets the required credential on the request.
        /// </summary>
        /// <param name="request">The request to set the credentials on</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        internal void SetRequestCredentials(Request request, CancellationToken cancellationToken)
        {
            request.Headers.Add("Ocp-Apim-Subscription-Key", _appKey);
        }
    }
}
