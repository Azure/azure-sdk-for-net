// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Translation.Document.Models;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.AI.Translation.Document
{
    /// <summary>
    /// The client to use for interacting with the Azure Document Translation Service.
    /// </summary>
    public class DocumentTranslationClient
    {
        internal readonly DocumentTranslationRestClient _serviceRestClient;
        internal readonly ClientDiagnostics _clientDiagnostics;
        internal readonly DocumentTranslationClientOptions _options;

        /// <summary>
        /// Protected constructor to allow mocking.
        /// </summary>
        protected DocumentTranslationClient()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentTranslationClient"/>
        /// class for the specified service instance.
        /// </summary>
        /// <param name="endpoint">A <see cref="Uri"/> to the service the client
        /// sends requests to.  Endpoint can be found in the Azure portal.</param>
        /// <param name="credential">A <see cref="TokenCredential"/> used to
        /// authenticate requests to the service, such as DefaultAzureCredential.</param>
        public DocumentTranslationClient(Uri endpoint, TokenCredential credential)
            : this(endpoint, credential, new DocumentTranslationClientOptions())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentTranslationClient"/>
        /// class for the specified service instance.
        /// </summary>
        /// <param name="endpoint">A <see cref="Uri"/> to the service the client
        /// sends requests to.  Endpoint can be found in the Azure portal.</param>
        /// <param name="credential">A <see cref="TokenCredential"/> used to
        /// authenticate requests to the service, such as DefaultAzureCredential.</param>
        /// <param name="options"><see cref="DocumentTranslationClientOptions"/> that allow
        /// callers to configure how requests are sent to the service.</param>
        public DocumentTranslationClient(Uri endpoint, TokenCredential credential, DocumentTranslationClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNull(options, nameof(options));

            _clientDiagnostics = new ClientDiagnostics(options);
            _options = options;
            string defaultScope = $"{(string.IsNullOrEmpty(options.Audience?.ToString()) ? DocumentTranslationAudience.AzurePublicCloud : options.Audience)}/.default";

            DocumentTranslationRestClientOptions restClientOptions = new DocumentTranslationRestClientOptions()
            {
                // etc
                Transport = options.Transport
            };

            _serviceRestClient = new DocumentTranslationRestClient(endpoint, credential, restClientOptions);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="DocumentTranslationClient"/> class for the specified service instance.
        /// </summary>
        /// <param name="endpoint">A <see cref="Uri"/> to the service the client
        /// sends requests to.</param>
        /// <param name="credential">The API key used to access
        /// the service. This will allow you to update the API key
        /// without creating a new client.</param>
        /// <param name="options"><see cref="DocumentTranslationClientOptions"/> that allow
        /// callers to configure how requests are sent to the service.</param>
        public DocumentTranslationClient(Uri endpoint, AzureKeyCredential credential, DocumentTranslationClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNull(options, nameof(options));

            _options = options;

            DocumentTranslationRestClientOptions restClientOptions = new DocumentTranslationRestClientOptions()
            {
                // etc
                Transport = options.Transport
            };

            _serviceRestClient = new DocumentTranslationRestClient(endpoint, credential, restClientOptions);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="DocumentTranslationClient"/> class for the specified service instance.
        /// </summary>
        /// <param name="endpoint">A <see cref="Uri"/> to the service the client
        /// sends requests to.</param>
        /// <param name="credential">The API key used to access
        /// the service. This will allow you to update the API key
        /// without creating a new client.</param>
        public DocumentTranslationClient(Uri endpoint, AzureKeyCredential credential)
            : this(endpoint, credential, new DocumentTranslationClientOptions())
        {
        }

        /// <summary>
        /// Starts a translation operation which translates the document(s) in your source container
        /// to your <see cref="TranslationTarget"/>(s) in the given language.
        /// <para>For document length limits, maximum batch size, and supported document formats, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/translator/document-translation/overview"/>.</para>
        /// </summary>
        /// <param name="inputs">Sets the inputs for the translation operation
        /// including source and target containers for documents to be translated. </param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="RequestFailedException">Service returned a non-success status code. </exception>
        public virtual DocumentTranslationOperation StartTranslation(IEnumerable<DocumentTranslationInput> inputs, CancellationToken cancellationToken = default)
        {
            var request = new StartTranslationDetails(inputs);
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DocumentTranslationClient)}.{nameof(StartTranslation)}");
            scope.Start();

            try
            {
                Response response = _serviceRestClient.GetDocumentTranslationClient().StartTranslation(request, cancellationToken);
                var operationLocation = response.Headers.TryGetValue("Operation-Location", out string value) ? value : null;
                return new DocumentTranslationOperation(_serviceRestClient, _clientDiagnostics, operationLocation);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Starts a translation operation which translates the document(s) in your source container
        /// to your <see cref="TranslationTarget"/>(s) in the given language.
        /// <para>For document length limits, maximum batch size, and supported document formats, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/translator/document-translation/overview"/>.</para>
        /// </summary>
        /// <param name="inputs">Sets the inputs for the translation operation
        /// including source and target containers for documents to be translated. </param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="RequestFailedException">Service returned a non-success status code. </exception>
        public virtual async Task<DocumentTranslationOperation> StartTranslationAsync(IEnumerable<DocumentTranslationInput> inputs, CancellationToken cancellationToken = default)
        {
            var request = new StartTranslationDetails(inputs);
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DocumentTranslationClient)}.{nameof(StartTranslation)}");
            scope.Start();

            try
            {
                var response = await _serviceRestClient.GetDocumentTranslationClient().StartTranslationAsync(request, cancellationToken).ConfigureAwait(false);
                var operationLocation = response.Headers.TryGetValue("Operation-Location", out string value) ? value : null;
                return new DocumentTranslationOperation(_serviceRestClient, _clientDiagnostics, operationLocation);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Starts a translation operation which translates the document(s) in your source container
        /// to your <see cref="TranslationTarget"/>(s) in the given language.
        /// <para>For document length limits, maximum batch size, and supported document formats, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/translator/document-translation/overview"/>.</para>
        /// </summary>
        /// <param name="input">Sets the input for the translation operation
        /// including source and target containers for documents to be translated. </param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="RequestFailedException">Service returned a non-success status code. </exception>
        public virtual DocumentTranslationOperation StartTranslation(DocumentTranslationInput input, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(input, nameof(input));
            var request = new StartTranslationDetails(new List<DocumentTranslationInput> { input });
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DocumentTranslationClient)}.{nameof(StartTranslation)}");
            scope.Start();

            try
            {
                var response = _serviceRestClient.GetDocumentTranslationClient().StartTranslation(request, cancellationToken);
                var operationLocation = response.Headers.TryGetValue("Operation-Location", out string value) ? value : null;
                return new DocumentTranslationOperation(_serviceRestClient, _clientDiagnostics, operationLocation);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Starts a translation operation which translates the document(s) in your source container
        /// to your <see cref="TranslationTarget"/>(s) in the given language.
        /// <para>For document length limits, maximum batch size, and supported document formats, see
        /// <a href="https://docs.microsoft.com/azure/cognitive-services/translator/document-translation/overview"/>.</para>
        /// </summary>
        /// <param name="input">Sets the input for the translation operation
        /// including source and target containers for documents to be translated. </param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        /// <exception cref="RequestFailedException">Service returned a non-success status code. </exception>
        public virtual async Task<DocumentTranslationOperation> StartTranslationAsync(DocumentTranslationInput input, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(input, nameof(input));
            var request = new StartTranslationDetails(new List<DocumentTranslationInput> { input });
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DocumentTranslationClient)}.{nameof(StartTranslation)}");
            scope.Start();

            try
            {
                var response = await _serviceRestClient.GetDocumentTranslationClient().StartTranslationAsync(request, cancellationToken).ConfigureAwait(false);
                var operationLocation = response.Headers.TryGetValue("Operation-Location", out string value) ? value : null;
                return new DocumentTranslationOperation(_serviceRestClient, _clientDiagnostics, operationLocation);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get the status results for submitted translation operations.
        /// </summary>
        /// <param name="options">Options to use when filtering result.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual Pageable<TranslationStatusResult> GetTranslationStatuses(GetTranslationStatusesOptions options = default, CancellationToken cancellationToken = default)
        {
            var statusList = options?.Statuses.Count > 0 ? options.Statuses.Select(status => status.ToString()) : null;
            var idList = options?.Ids.Count > 0 ? options.Ids.Select(id => ClientCommon.ValidateModelId(id, "Id Filter")) : null;
            var orderByList = options?.OrderBy.Count > 0 ? options.OrderBy.Select(order => order.ToGenerated()) : null;

            return _serviceRestClient.GetDocumentTranslationClient().GetTranslationsStatus(
                        ids: idList,
                        statuses: statusList,
                        createdDateTimeUtcStart: options?.CreatedAfter,
                        createdDateTimeUtcEnd: options?.CreatedBefore,
                        orderBy: orderByList,
                        cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Get the status results for submitted translation operations.
        /// </summary>
        /// <param name="options">Options to use when filtering result.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual AsyncPageable<TranslationStatusResult> GetTranslationStatusesAsync(GetTranslationStatusesOptions options = default, CancellationToken cancellationToken = default)
        {
            var statusList = options?.Statuses.Count > 0 ? options.Statuses.Select(status => status.ToString()) : null;
            var idList = options?.Ids.Count > 0 ? options.Ids.Select(id => ClientCommon.ValidateModelId(id, "Id Filter")) : null;
            var orderByList = options?.OrderBy.Count > 0 ? options.OrderBy.Select(order => order.ToGenerated()) : null;

            return _serviceRestClient.GetDocumentTranslationClient().GetTranslationsStatusAsync(
                ids: idList,
                statuses: statusList,
                createdDateTimeUtcStart: options?.CreatedAfter,
                createdDateTimeUtcEnd: options?.CreatedBefore,
                orderBy: orderByList,
                cancellationToken: cancellationToken);
        }

        #region supported formats functions

        /// <summary>
        /// Get the list of the glossary formats supported by the Document Translation service.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual Response<IReadOnlyList<DocumentTranslationFileFormat>> GetSupportedGlossaryFormats(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DocumentTranslationClient)}.{nameof(GetSupportedGlossaryFormats)}");
            scope.Start();

            try
            {
                var response = _serviceRestClient.GetDocumentTranslationClient().GetSupportedGlossaryFormats(cancellationToken);
                return Response.FromValue(response.Value.Value, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get the list of the glossary formats supported by the Document Translation service.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual async Task<Response<IReadOnlyList<DocumentTranslationFileFormat>>> GetSupportedGlossaryFormatsAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DocumentTranslationClient)}.{nameof(GetSupportedGlossaryFormats)}");
            scope.Start();

            try
            {
                var response = await _serviceRestClient.GetDocumentTranslationClient().GetSupportedGlossaryFormatsAsync(cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value.Value, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get the list of the document formats supported by the Document Translation service.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual Response<IReadOnlyList<DocumentTranslationFileFormat>> GetSupportedDocumentFormats(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DocumentTranslationClient)}.{nameof(GetSupportedDocumentFormats)}");
            scope.Start();

            try
            {
                var response = _serviceRestClient.GetDocumentTranslationClient().GetSupportedDocumentFormats(cancellationToken);
                return Response.FromValue(response.Value.Value, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get the list of the document formats supported by the Document Translation service.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual async Task<Response<IReadOnlyList<DocumentTranslationFileFormat>>> GetSupportedDocumentFormatsAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(DocumentTranslationClient)}.{nameof(GetSupportedDocumentFormats)}");
            scope.Start();

            try
            {
                var response = await _serviceRestClient.GetDocumentTranslationClient().GetSupportedDocumentFormatsAsync(cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value.Value, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
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
