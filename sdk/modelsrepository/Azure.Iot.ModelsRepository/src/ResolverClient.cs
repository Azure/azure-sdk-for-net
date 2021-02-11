// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Iot.ModelsRepository
{
    /// <summary>
    /// The <c>ResolverClient</c> class supports DTDL model resolution providing functionality to
    /// resolve models by retrieving model definitions and their dependencies.
    /// </summary>
    public class ResolverClient
    {
        internal const string DefaultRepository = "https://devicemodels.azure.com";
        private readonly RepositoryHandler _repositoryHandler;

        /// <summary>
        /// Initializes the <c>ResolverClient</c> with default client options while pointing to
        /// the Azure IoT Plug and Play Model repository https://devicemodels.azure.com for resolution.
        /// </summary>
        public ResolverClient() : this(new Uri(DefaultRepository), null) { }

        /// <summary>
        /// Initializes the <c>ResolverClient</c> with default client options while pointing to
        /// a custom <paramref name="repositoryUri"/> for resolution.
        /// </summary>
        /// <param name="repositoryUri">
        /// The model repository <c>Uri</c> value. This can be a remote endpoint or local directory.
        /// </param>
        public ResolverClient(Uri repositoryUri) : this(repositoryUri, null) { }

        /// <summary>
        /// Initializes the <c>ResolverClient</c> with custom client <paramref name="options"/> while pointing to
        /// the Azure IoT Plug and Play Model repository https://devicemodels.azure.com for resolution.
        /// </summary>
        /// <param name="options">
        /// <c>ResolverClientOptions</c> to configure resolution and client behavior.
        /// </param>
        public ResolverClient(ResolverClientOptions options) : this(new Uri(DefaultRepository), options) { }

        /// <summary>
        /// Initializes the <c>ResolverClient</c> with custom client <paramref name="options"/> while pointing to
        /// a custom <paramref name="repositoryUri"/> for resolution.
        /// </summary>
        /// <param name="repositoryUri">
        /// The model repository <c>Uri</c>. This can be a remote endpoint or local directory.
        /// </param>
        /// <param name="options">
        /// <c>ResolverClientOptions</c> to configure resolution and client behavior.
        /// </param>
        public ResolverClient(Uri repositoryUri, ResolverClientOptions options)
        {
            _repositoryHandler = new RepositoryHandler(repositoryUri, options);
        }

        /// <summary>
        /// Initializes the <c>ResolverClient</c> with default client options while pointing to
        /// a custom <paramref name="repositoryUriStr"/> for resolution.
        /// </summary>
        /// <param name="repositoryUriStr">
        /// The model repository <c>Uri</c> in string format. This can be a remote endpoint or local directory.
        /// </param>
        public ResolverClient(string repositoryUriStr) : this(repositoryUriStr, null) { }

        /// <summary>
        /// Initializes the <c>ResolverClient</c> with custom client <paramref name="options"/> while pointing to
        /// a custom <paramref name="repositoryUriStr"/> for resolution.
        /// </summary>
        /// <param name="repositoryUriStr">
        /// The model repository <c>Uri</c> in string format. This can be a remote endpoint or local directory.
        /// </param>
        /// <param name="options">
        /// <c>ResolverClientOptions</c> to configure resolution and client behavior.
        /// </param>
        public ResolverClient(string repositoryUriStr, ResolverClientOptions options) : this(new Uri(repositoryUriStr), options) { }

        /// <summary>
        /// Resolves a model definition identified by <paramref name="dtmi"/> and optionally its dependencies.
        /// </summary>
        /// <returns>
        /// An <c>IDictionary</c> containing the model definition(s) where the key is the dtmi
        /// and the value is the raw model definition string.
        /// </returns>
        /// <exception cref="ResolverException">Thrown when a resolution failure occurs.</exception>
        /// <param name="dtmi">A well-formed DTDL model Id. For example 'dtmi:com:example:Thermostat;1'.</param>
        /// <param name="cancellationToken">The cancellationToken.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "AZC0004:DO provide both asynchronous and synchronous variants for all service methods.", Justification = "<Pending>")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "AZC0015:Unexpected client method return type.", Justification = "<Pending>")]
        public virtual async Task<IDictionary<string, string>> ResolveAsync(string dtmi, CancellationToken cancellationToken = default)
        {
            return await _repositoryHandler.ProcessAsync(dtmi, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Resolves a collection of model definitions identified by <paramref name="dtmis"/> and optionally their dependencies.
        /// </summary>
        /// <returns>
        /// An <c>IDictionary</c> containing the model definition(s) where the key is the dtmi
        /// and the value is the raw model definition string.
        /// </returns>
        /// <exception cref="ResolverException">Thrown when a resolution failure occurs.</exception>
        /// <param name="dtmis">A collection of well-formed DTDL model Ids.</param>
        /// <param name="cancellationToken">The cancellationToken.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "AZC0004:DO provide both asynchronous and synchronous variants for all service methods.", Justification = "<Pending>")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "AZC0015:Unexpected client method return type.", Justification = "<Pending>")]
        public virtual async Task<IDictionary<string, string>> ResolveAsync(IEnumerable<string> dtmis, CancellationToken cancellationToken = default)
        {
            return await _repositoryHandler.ProcessAsync(dtmis, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Evaluates whether an input <paramref name="dtmi"/> is valid.
        /// </summary>
        public static bool IsValidDtmi(string dtmi) => DtmiConventions.IsDtmi(dtmi);

        /// <summary>
        /// Gets the <c>Uri</c> associated with the ResolverClient instance.
        /// </summary>
        public Uri RepositoryUri => _repositoryHandler.RepositoryUri;

        /// <summary>
        /// Gets the <c>ResolverClientOptions</c> associated with the ResolverClient instance.
        /// </summary>
        public ResolverClientOptions ClientOptions => _repositoryHandler.ClientOptions;
    }
}
