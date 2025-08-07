// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Security.CodeTransparency
{
    /// <summary>
    /// The client to fetch the service certificate for the use in TLS connection.
    /// Very similar to the one used in Azure.Security.ConfidentialLedger.
    /// Certificate responses get cached for a configured time.
    /// </summary>
    public partial class CodeTransparencyCertificateClient
    {
        private readonly Uri _certificateEndpoint;
        private readonly HttpPipeline _pipeline;
        // Caches the fetched certs json for a specified amount of time
        private readonly ConcurrentDictionary<string, ServiceIdentityResult> _results;
        private readonly double _cacheTTLSec;
        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary>
        /// Constructor to facilitate mocking.
        /// </summary>
        protected CodeTransparencyCertificateClient()
        {
        }

        /// <summary> Initializes a new instance of CertificateClient.</summary>
        /// <param name="endpoint"> The Identity Service URL. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> </exception>
        public CodeTransparencyCertificateClient(Uri endpoint) : this(endpoint, new CodeTransparencyClientOptions())
        {
        }

        /// <summary> Initializes a new instance of CertificateClient.</summary>
        /// <param name="endpoint"> The Identity Service URL. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> </exception>
        public CodeTransparencyCertificateClient(Uri endpoint, CodeTransparencyClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            Argument.AssertNotNull(options, nameof(options));
            ClientDiagnostics = new(options, true);
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), Array.Empty<HttpPipelinePolicy>(), new ResponseClassifier());
            _certificateEndpoint = endpoint;
            _results = new ConcurrentDictionary<string, ServiceIdentityResult>();
            _cacheTTLSec = options.CacheTTLSeconds;
        }

        /// <summary>
        /// A helper method to retrieve the cached result. The TTL acts as a self healing
        /// mechanism for the long lived clients.
        /// </summary>
        /// <param name="ledgerId"></param>
        /// <returns>An entry in the cache if it exists and if it is still deemed reusable.</returns>
        private ServiceIdentityResult getFromCache(string ledgerId)
        {
            Argument.AssertNotNullOrEmpty(ledgerId, nameof(ledgerId));
            if (_results.TryGetValue(ledgerId, out ServiceIdentityResult serviceIdentity))
            {
                TimeSpan age = DateTime.Now - serviceIdentity.CreatedAt;
                if (age < TimeSpan.FromSeconds(_cacheTTLSec))
                {
                    return serviceIdentity;
                }
            }
            return null;
        }

        /// <summary>
        /// Gets identity information (TLS cert) for a service instance.
        /// Raw response could be null if the value is from cache.
        /// </summary>
        /// <param name="ledgerId"> Id of the  service instance to get information for. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="ledgerId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="ledgerId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<Response<ServiceIdentityResult>> GetServiceIdentityAsync(string ledgerId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(ledgerId, nameof(ledgerId));
            ServiceIdentityResult serviceIdentity = getFromCache(ledgerId);
            if (serviceIdentity != null)
            {
                return Response.FromValue(serviceIdentity, null);
            }
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await GetServiceIdentityAsync(ledgerId, context).ConfigureAwait(false);
            serviceIdentity = ServiceIdentityResult.FromResponse(response);
            if (!response.IsError)
                _results.AddOrUpdate(ledgerId, serviceIdentity, (key, oldValue) => serviceIdentity);
            return Response.FromValue(serviceIdentity, response);
        }

        /// <summary>
        /// Gets identity information (TLS cert) for a service instance.
        /// Raw response could be null if the value is from cache.
        /// </summary>
        /// <param name="ledgerId"> Id of the  service instance to get information for. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="ledgerId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="ledgerId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Response<ServiceIdentityResult> GetServiceIdentity(string ledgerId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(ledgerId, nameof(ledgerId));
            ServiceIdentityResult serviceIdentity = getFromCache(ledgerId);
            if (serviceIdentity != null)
            {
                return Response.FromValue(serviceIdentity, null);
            }
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = GetServiceIdentity(ledgerId, context);
            serviceIdentity = ServiceIdentityResult.FromResponse(response);
            if (!response.IsError)
                _results.AddOrUpdate(ledgerId, serviceIdentity, (key, oldValue) => serviceIdentity);
            return Response.FromValue(serviceIdentity, response);
        }

        /// <summary>
        /// Gets identity information (TLS cert) for a service instance.
        /// </summary>
        /// <param name="ledgerId"> Id of the  service instance to get information for. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="ledgerId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="ledgerId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<Response> GetServiceIdentityAsync(string ledgerId, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(ledgerId, nameof(ledgerId));

            using DiagnosticScope scope = ClientDiagnostics.CreateScope("CodeTransparencyCertificateClient.GetServiceIdentity");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetLedgerIdentityRequest(ledgerId, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets identity information (TLS cert) for a service instance.
        /// </summary>
        /// <param name="ledgerId"> Id of the  service instance to get information for. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="ledgerId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="ledgerId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Response GetServiceIdentity(string ledgerId, RequestContext context)
        {
            Argument.AssertNotNullOrEmpty(ledgerId, nameof(ledgerId));

            using DiagnosticScope scope = ClientDiagnostics.CreateScope("CodeTransparencyCertificateClient.GetServiceIdentity");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetLedgerIdentityRequest(ledgerId, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateGetLedgerIdentityRequest(string ledgerId, RequestContext context)
        {
            HttpMessage message = _pipeline.CreateMessage(context);
            Request request = message.Request;
            request.Method = RequestMethod.Get;
            RawRequestUriBuilder uri = new();
            uri.Reset(_certificateEndpoint);
            uri.AppendPath("/ledgerIdentity/", false);
            uri.AppendPath(ledgerId, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }
        private static RequestContext DefaultRequestContext = new RequestContext();
        internal static RequestContext FromCancellationToken(CancellationToken cancellationToken = default)
        {
            if (!cancellationToken.CanBeCanceled)
            {
                return DefaultRequestContext;
            }

            return new RequestContext() { CancellationToken = cancellationToken };
        }
    }
}
