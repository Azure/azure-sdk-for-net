// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.MixedReality.Authentication;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace Azure.MixedReality.ObjectAnchors.Conversion
{
    /// <summary>
    /// Represents a client for Azure Object Anchors.
    /// </summary>
    public class ObjectAnchorsConversionClient
    {
        private HashSet<AssetFileType> _supportedAssetFileTypesSet;

        /// <summary>
        /// The Account ID to be used by the Client
        /// </summary>
        public Guid AccountId { get; }

        /// <summary>
        /// The list of supported asset file types
        /// </summary>
        public IReadOnlyList<AssetFileType> SupportedAssetFileTypes { get; private set; }

        internal HashSet<AssetFileType> SupportedAssetFileTypesSet
        {
            get
            {
                return _supportedAssetFileTypesSet;
            }
            set
            {
                _supportedAssetFileTypesSet = value;
                SupportedAssetFileTypes = value.ToList();
            }
        }

        /// <summary>
        /// The Account Domain to be used by the Client
        /// </summary>
        public string AccountDomain { get; }

        private readonly HttpPipeline _pipeline;

        private readonly BlobUploadEndpointRestClient _getBlobUploadEndpointRestClient;

        private readonly IngestionJobRestClient _ingestionJobRestClient;

        internal readonly ClientDiagnostics _clientDiagnostics;

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectAnchorsConversionClient" /> class.
        /// </summary>
        /// <param name="accountId">The Azure Object Anchors account ID.</param>
        /// <param name="accountDomain">The Azure Object Anchors account domain.</param>
        /// <param name="keyCredential">The Azure Object Anchors account primary or secondary key credential.</param>
        public ObjectAnchorsConversionClient(Guid accountId, string accountDomain, AzureKeyCredential keyCredential)
            : this(accountId, accountDomain, new MixedRealityAccountKeyCredential(accountId, keyCredential), null) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectAnchorsConversionClient" /> class.
        /// </summary>
        /// <param name="accountId">The Azure Object Anchors account ID.</param>
        /// <param name="accountDomain">The Azure Object Anchors account domain.</param>
        /// <param name="keyCredential">The Azure Object Anchors account primary or secondary key credential.</param>
        /// <param name="options">The options.</param>
        public ObjectAnchorsConversionClient(Guid accountId, string accountDomain, AzureKeyCredential keyCredential, ObjectAnchorsConversionClientOptions options)
            : this(accountId, accountDomain, new MixedRealityAccountKeyCredential(accountId, keyCredential), options) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectAnchorsConversionClient" /> class.
        /// </summary>
        /// <param name="accountId">The Azure Object Anchors account ID.</param>
        /// <param name="accountDomain">The Azure Object Anchors account domain.</param>
        /// <param name="token">An access token used to access the specified Azure Object Anchors account.</param>
        /// <param name="options">The options.</param>
        public ObjectAnchorsConversionClient(Guid accountId, string accountDomain, AccessToken token, ObjectAnchorsConversionClientOptions options = null)
            : this(accountId, accountDomain, new StaticAccessTokenCredential(token), options) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectAnchorsConversionClient" /> class.
        /// </summary>
        /// <param name="accountId">The Azure Object Anchors account ID.</param>
        /// <param name="accountDomain">The Azure Object Anchors account domain.</param>
        /// <param name="credential">The credential used to access the Mixed Reality service.</param>
        /// <param name="options">The options.</param>
        public ObjectAnchorsConversionClient(Guid accountId, string accountDomain, TokenCredential credential, ObjectAnchorsConversionClientOptions options = null)
        {
            Argument.AssertNotDefault(ref accountId, nameof(accountId));
            Argument.AssertNotNullOrWhiteSpace(accountDomain, nameof(accountDomain));
            Argument.AssertNotNull(credential, nameof(credential));

            options = options ?? new ObjectAnchorsConversionClientOptions();
            Uri authenticationEndpoint = options.MixedRealityAuthenticationEndpoint ?? AuthenticationEndpoint.ConstructFromDomain(accountDomain);
            TokenCredential mrTokenCredential = MixedRealityTokenCredential.GetMixedRealityCredential(accountId, authenticationEndpoint, credential, options.MixedRealityAuthenticationOptions);
            Uri serviceEndpoint = options.ServiceEndpoint ?? ConstructObjectAnchorsEndpointUrl(accountDomain);

            AccountId = accountId;
            SupportedAssetFileTypesSet = options.SupportedAssetFileTypes;
            _clientDiagnostics = new ClientDiagnostics(options);
            _pipeline = HttpPipelineBuilder.Build(options, new BearerTokenAuthenticationPolicy(mrTokenCredential, GetDefaultScope(serviceEndpoint)));
            _getBlobUploadEndpointRestClient = new BlobUploadEndpointRestClient(_clientDiagnostics, _pipeline, serviceEndpoint, options.Version);
            _ingestionJobRestClient = new IngestionJobRestClient(_clientDiagnostics, _pipeline, serviceEndpoint, options.Version);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectAnchorsConversionClient"/> class.
        /// </summary>
        /// <remarks>
        /// Required for mocking.
        /// </remarks>
        protected ObjectAnchorsConversionClient()
        {
        }

        /// <summary>
        /// Creates an Object Anchors asset conversion job request.
        /// </summary>
        /// <param name="options">The asset conversion job creation options</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The asset conversion operation</returns>
        public virtual AssetConversionOperation StartAssetConversion(AssetConversionOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ObjectAnchorsConversionClient)}.{nameof(StartAssetConversion)}");
            scope.Start();
            try
            {
                if (!SupportedAssetFileTypes.Contains(options.InputAssetFileType))
                {
                    throw new AssetFileTypeNotSupportedException(options.InputAssetFileType, SupportedAssetFileTypes);
                }

                AssetConversionProperties properties = new AssetConversionProperties
            {
                InputAssetFileType = options.InputAssetFileType,
                ConversionConfiguration = options.ConversionConfiguration,
                InputAssetUri = options.InputAssetUri
            };

            _ingestionJobRestClient.Create(AccountId, options.JobId, body: properties, cancellationToken: cancellationToken);
            return new AssetConversionOperation(options.JobId, this);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Creates an Object Anchors asset conversion job request.
        /// </summary>
        /// <param name="options">The asset conversion job creation options</param>
        /// <param name="cancellationToken">The cancellation toke</param>
        /// <returns>The asset conversion operation</returns>
        public virtual async Task<AssetConversionOperation> StartAssetConversionAsync(AssetConversionOptions options, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ObjectAnchorsConversionClient)}.{nameof(StartAssetConversion)}");
            scope.Start();
            try
            {
                if (!SupportedAssetFileTypes.Contains(options.InputAssetFileType))
                {
                    throw new AssetFileTypeNotSupportedException(options.InputAssetFileType, SupportedAssetFileTypes);
                }

                AssetConversionProperties properties = new AssetConversionProperties
            {
                InputAssetFileType = options.InputAssetFileType,
                ConversionConfiguration = options.ConversionConfiguration,
                InputAssetUri = options.InputAssetUri
            };

            await _ingestionJobRestClient.CreateAsync(AccountId, options.JobId, body: properties, cancellationToken: cancellationToken).ConfigureAwait(false);
            return new AssetConversionOperation(options.JobId, this);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Retrieves an upload URI intended to house the model to be ingested
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns><see cref="Response{GetAssetUploadUriResult}"/>.</returns>
        public virtual Response<AssetUploadUriResult> GetAssetUploadUri(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ObjectAnchorsConversionClient)}.{nameof(GetAssetUploadUri)}");
            scope.Start();
            try
            {
                return _getBlobUploadEndpointRestClient.Get(AccountId, xMrcCv: GenerateCv(), cancellationToken: cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Retrieves an upload URI intended to house the model to be ingested
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns><see cref="Response{GetAssetUploadUriResult}"/>.</returns>
        public virtual async Task<Response<AssetUploadUriResult>> GetAssetUploadUriAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ObjectAnchorsConversionClient)}.{nameof(GetAssetUploadUri)}");
            scope.Start();
            try
            {
                return await _getBlobUploadEndpointRestClient.GetAsync(AccountId, xMrcCv: GenerateCv(), cancellationToken: cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets the status of an Object Anchors asset conversion job
        /// </summary>
        /// <param name="JobId">The asset conversion job's ID</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns><see cref="Response{AssetConversionProperties}"/>.</returns>
        internal virtual Response<AssetConversionProperties> GetAssetConversionStatus(Guid JobId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ObjectAnchorsConversionClient)}.{nameof(GetAssetConversionStatus)}");
            scope.Start();
            try
            {
                var properties = _ingestionJobRestClient.Get(AccountId, JobId, xMrcCv: GenerateCv(), cancellationToken: cancellationToken);
                properties.Value.JobId = JobId;
                properties.Value.AccountId = AccountId;
                return properties;
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary>
        /// Gets the status of an Object Anchors asset conversion job
        /// </summary>
        /// <param name="JobId">The asset conversion job's ID</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns><see cref="Response{AssetConversionProperties}"/>.</returns>
        internal virtual async Task<Response<AssetConversionProperties>> GetAssetConversionStatusAsync(Guid JobId, CancellationToken cancellationToken = default)
        {
            var properties = await _ingestionJobRestClient.GetAsync(AccountId, JobId, xMrcCv: GenerateCv(), cancellationToken: cancellationToken).ConfigureAwait(false);
            properties.Value.JobId = JobId;
            properties.Value.AccountId = AccountId;
            return properties;
        }

        private static string GetDefaultScope(Uri uri)
            => $"{uri.GetComponents(UriComponents.SchemeAndServer, UriFormat.SafeUnescaped)}/.default";

        private static string GenerateCv()
            => Convert.ToBase64String(Guid.NewGuid().ToByteArray()).TrimEnd('=');

        private static Uri ConstructObjectAnchorsEndpointUrl(string accountDomain)
        {
            Argument.AssertNotNullOrWhiteSpace(accountDomain, nameof(accountDomain));
            Uri result = new Uri($"https://{accountDomain}");
            if (result.IsLoopback)
            {
                return result;
            }
            if (!Uri.TryCreate($"https://aoa.{accountDomain}", UriKind.Absolute, out result))
            {
                throw new ArgumentException("The value could not be used to construct a valid endpoint.", nameof(accountDomain));
            }

            return result;
        }
    }
}
