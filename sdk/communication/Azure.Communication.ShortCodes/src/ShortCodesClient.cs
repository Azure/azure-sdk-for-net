// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Communication.Pipeline;
using Azure.Communication.ShortCodes.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Communication.ShortCodes
{
    /// <summary>
    /// The Azure Communication Services short codes client.
    /// </summary>
    public class ShortCodesClient
    {
        internal ShortCodesRestClient RestClient { get; }
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;

        #region public constructors - all arguments need null check

        /// <summary>
        /// Initializes a short codes client with an Azure resource connection string and client options.
        /// </summary>
        public ShortCodesClient(string connectionString)
            : this(
                ConnectionString.Parse(Argument.CheckNotNullOrEmpty(connectionString, nameof(connectionString))),
                new ShortCodesClientOptions())
        { }

        /// <summary>
        /// Initializes a short codes client with an Azure resource connection string and client options.
        /// </summary>
        public ShortCodesClient(string connectionString, ShortCodesClientOptions options)
            : this(
                ConnectionString.Parse(Argument.CheckNotNullOrEmpty(connectionString, nameof(connectionString))),
                options ?? new ShortCodesClientOptions())
        { }

        /// <summary> Initializes a new instance of <see cref="ShortCodesClient"/>.</summary>
        /// <param name="endpoint">The URI of the Azure Communication Services resource.</param>
        /// <param name="keyCredential">The <see cref="AzureKeyCredential"/> used to authenticate requests.</param>
        /// <param name="options">Client option exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public ShortCodesClient(Uri endpoint, AzureKeyCredential keyCredential, ShortCodesClientOptions options = default)
            : this(
                Argument.CheckNotNull(endpoint, nameof(endpoint)).AbsoluteUri,
                Argument.CheckNotNull(keyCredential, nameof(keyCredential)),
                options ?? new ShortCodesClientOptions())
        { }

        /// <summary>
        /// Initializes a short codes client with a token credential.
        /// <param name="endpoint">The URI of the Azure Communication Services resource.</param>
        /// <param name="tokenCredential">The <see cref="TokenCredential"/> used to authenticate requests, such as DefaultAzureCredential.</param>
        /// <param name="options">Client option exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        /// </summary>
        public ShortCodesClient(Uri endpoint, TokenCredential tokenCredential, ShortCodesClientOptions options = default)
            : this(
                Argument.CheckNotNull(endpoint, nameof(endpoint)).AbsoluteUri,
                Argument.CheckNotNull(tokenCredential, nameof(tokenCredential)),
                options ?? new ShortCodesClientOptions())
        { }

        #endregion

        #region private constructors

        private ShortCodesClient(ConnectionString connectionString, ShortCodesClientOptions options)
            : this(connectionString.GetRequired("endpoint"), options.BuildHttpPipeline(connectionString), options)
        { }

        private ShortCodesClient(string endpoint, AzureKeyCredential keyCredential, ShortCodesClientOptions options)
            : this(endpoint, options.BuildHttpPipeline(keyCredential), options)
        { }

        private ShortCodesClient(string endpoint, TokenCredential tokenCredential, ShortCodesClientOptions options)
            : this(endpoint, options.BuildHttpPipeline(tokenCredential), options)
        { }

        private ShortCodesClient(string endpoint, HttpPipeline httpPipeline, ShortCodesClientOptions options)
            : this(new ClientDiagnostics(options), httpPipeline, endpoint, options.ApiVersion)
        { }

        /// <summary> Initializes a new instance of <see cref="ShortCodesClient"/>. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> The communication resource, for example https://resourcename.communication.azure.com. </param>
        /// <param name="apiVersion"> Api Version. </param>
        private ShortCodesClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string endpoint, string apiVersion = "2021-03-07")
        {
            RestClient = new ShortCodesRestClient(clientDiagnostics, pipeline, endpoint, apiVersion);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        #endregion

        #region protected constructors
        /// <summary> Initializes a new instance of <see cref="ShortCodesClient"/> for mocking. </summary>
        protected ShortCodesClient()
        {
        }
        #endregion protected constructors

        /// <summary> Gets the list of short codes for the current resource. </summary>
        /// <param name="skip"> An optional parameter for how many entries to skip, for pagination purposes. </param>
        /// <param name="top"> An optional parameter for how many entries to return, for pagination purposes. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<ShortCode> GetShortCodesAsync(int? skip = null, int? top = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<ShortCode>> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ShortCodesClient)}.{nameof(GetShortCodes)}");
                scope.Start();
                try
                {
                    var response = await RestClient.GetShortCodesAsync(skip: null, top: pageSizeHint, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.ShortCodesProperty, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<ShortCode>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ShortCodesClient)}.{nameof(GetShortCodes)}");
                scope.Start();
                try
                {
                    var response = await RestClient.GetShortCodesNextPageAsync(nextLink, skip: null, top: pageSizeHint, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.ShortCodesProperty, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Gets the list of short codes for the current resource. </summary>
        /// <param name="skip"> An optional parameter for how many entries to skip, for pagination purposes. </param>
        /// <param name="top"> An optional parameter for how many entries to return, for pagination purposes. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<ShortCode> GetShortCodes(int? skip = null, int? top = null, CancellationToken cancellationToken = default)
        {
            Page<ShortCode> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ShortCodesClient)}.{nameof(GetShortCodes)}");
                scope.Start();
                try
                {
                    var response = RestClient.GetShortCodes(skip: null, top: pageSizeHint, cancellationToken);
                    return Page.FromValues(response.Value.ShortCodesProperty, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<ShortCode> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ShortCodesClient)}.{nameof(GetShortCodes)}");
                scope.Start();
                try
                {
                    var response = RestClient.GetShortCodesNextPage(nextLink, skip: null, top: pageSizeHint, cancellationToken);
                    return Page.FromValues(response.Value.ShortCodesProperty, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Creates or updates a US Program Brief. </summary>
        /// <param name="programBriefId"> Program Brief Id. Must be a valid GUID. </param>
        /// <param name="body"> Data to create new a Program Brief or fields to update an existing Program Brief. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<USProgramBrief>> UpsertUSProgramBriefAsync(Guid programBriefId, USProgramBrief body = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ShortCodesClient)}.{nameof(UpsertUSProgramBrief)}");
            scope.Start();
            try
            {
                Argument.AssertNotNull(body, nameof(body));

                Response<USProgramBrief> response = await RestClient.UpsertUSProgramBriefAsync(programBriefId, body, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value, response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Creates or updates a US Program Brief. </summary>
        /// <param name="programBriefId"> Program Brief Id. Must be a valid GUID. </param>
        /// <param name="body"> Data to create new a Program Brief or fields to update an existing Program Brief. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<USProgramBrief> UpsertUSProgramBrief(Guid programBriefId, USProgramBrief body = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ShortCodesClient)}.{nameof(UpsertUSProgramBrief)}");
            scope.Start();
            try
            {
                Argument.AssertNotNull(body, nameof(body));

                Response<USProgramBrief> response = RestClient.UpsertUSProgramBrief(programBriefId, body, cancellationToken);
                return Response.FromValue(response.Value, response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Deletes a US Program Brief. </summary>
        /// <param name="programBriefId"> Program Brief Id. Must be a valid GUID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> DeleteUSProgramBriefAsync(Guid programBriefId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ShortCodesClient)}.{nameof(DeleteUSProgramBrief)}");
            scope.Start();
            try
            {
                return await RestClient.DeleteUSProgramBriefAsync(programBriefId, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Deletes a US Program Brief. </summary>
        /// <param name="programBriefId"> Program Brief Id. Must be a valid GUID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response DeleteUSProgramBrief(Guid programBriefId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ShortCodesClient)}.{nameof(DeleteUSProgramBrief)}");
            scope.Start();
            try
            {
                return RestClient.DeleteUSProgramBrief(programBriefId, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Get a US Program Brief by id. </summary>
        /// <param name="programBriefId"> Program Brief Id. Must be a valid GUID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<USProgramBrief>> GetUSProgramBriefAsync(Guid programBriefId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ShortCodesClient)}.{nameof(GetUSProgramBrief)}");
            scope.Start();
            try
            {
                Response<USProgramBrief> response = await RestClient.GetUSProgramBriefAsync(programBriefId, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value, response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Get a US Program Brief by id. </summary>
        /// <param name="programBriefId"> Program Brief Id. Must be a valid GUID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<USProgramBrief> GetUSProgramBrief(Guid programBriefId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ShortCodesClient)}.{nameof(GetUSProgramBrief)}");
            scope.Start();
            try
            {
                Response<USProgramBrief> response = RestClient.GetUSProgramBrief(programBriefId, cancellationToken);
                return Response.FromValue(response.Value, response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Gets the list of US Program Briefs for the current resource. </summary>
        /// <param name="skip"> An optional parameter for how many entries to skip, for pagination purposes. </param>
        /// <param name="top"> An optional parameter for how many entries to return, for pagination purposes. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<USProgramBrief> GetUSProgramBriefsAsync(int? skip = null, int? top = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<USProgramBrief>> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ShortCodesClient)}.{nameof(GetUSProgramBriefs)}");
                scope.Start();
                try
                {
                    var response = await RestClient.GetUSProgramBriefsAsync(skip: null, top: pageSizeHint, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.ProgramBriefs, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<USProgramBrief>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ShortCodesClient)}.{nameof(GetUSProgramBriefs)}");
                scope.Start();
                try
                {
                    var response = await RestClient.GetUSProgramBriefsNextPageAsync(nextLink, skip: null, top: pageSizeHint, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.ProgramBriefs, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }

            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Gets the list of US Program Briefs for the current resource. </summary>
        /// <param name="skip"> An optional parameter for how many entries to skip, for pagination purposes. </param>
        /// <param name="top"> An optional parameter for how many entries to return, for pagination purposes. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<USProgramBrief> GetUSProgramBriefs(int? skip = null, int? top = null, CancellationToken cancellationToken = default)
        {
            Page<USProgramBrief> FirstPageFunc(int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ShortCodesClient)}.{nameof(GetUSProgramBriefs)}");
                scope.Start();
                try
                {
                    var response = RestClient.GetUSProgramBriefs(skip: null, top: pageSizeHint, cancellationToken);
                    return Page.FromValues(response.Value.ProgramBriefs, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<USProgramBrief> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ShortCodesClient)}.{nameof(GetUSProgramBriefs)}");
                scope.Start();
                try
                {
                    var response = RestClient.GetUSProgramBriefsNextPage(nextLink, skip: null, top: pageSizeHint, cancellationToken);
                    return Page.FromValues(response.Value.ProgramBriefs, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Submits a US Program Brief for review. </summary>
        /// <param name="programBriefId"> Program Brief Id. Must be a valid GUID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<USProgramBrief>> SubmitUSProgramBriefAsync(Guid programBriefId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ShortCodesClient)}.{nameof(SubmitUSProgramBrief)}");
            scope.Start();
            try
            {
                Response<USProgramBrief> response = await RestClient.SubmitUSProgramBriefAsync(programBriefId, cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value, response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Submits a US Program Brief for review. </summary>
        /// <param name="programBriefId"> Program Brief Id. Must be a valid GUID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<USProgramBrief> SubmitUSProgramBrief(Guid programBriefId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(ShortCodesClient)}.{nameof(SubmitUSProgramBrief)}");
            scope.Start();
            try
            {
                Response<USProgramBrief> response = RestClient.SubmitUSProgramBrief(programBriefId, cancellationToken);
                return Response.FromValue(response.Value, response.GetRawResponse());
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }
    }
}
