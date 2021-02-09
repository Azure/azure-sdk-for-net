// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Communication.PhoneNumbers.Models;
using Azure.Communication.Pipeline;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Communication.PhoneNumbers
{
    /// <summary>
    /// The Azure Communication Services phone numbers client.
    /// </summary>
    [CodeGenSuppress("GetByNumberAsync", typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetByNumber", typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetSearchResultAsync", typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetSearchResult", typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetOperationAsync", typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetOperation", typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("CancelOperationAsync", typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("CancelOperation", typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("UpdateAsync", typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("Update", typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("ListPhoneNumbersAsync", typeof(int?), typeof(int?),typeof(CancellationToken))]
    [CodeGenSuppress("ListPhoneNumbers", typeof(int?), typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("StartSearchAvailablePhoneNumbersAsync", typeof(string), typeof(PhoneNumberSearchRequest), typeof(CancellationToken))]
    [CodeGenSuppress("StartSearchAvailablePhoneNumbers", typeof(string), typeof(PhoneNumberSearchRequest), typeof(CancellationToken))]
    public partial class PhoneNumbersClient
    {
        #region public constructors - all arguments need null check

        /// <summary>
        /// Initializes a phone numbers client with an Azure resource connection string and client options.
        /// </summary>
        public PhoneNumbersClient(string connectionString)
            : this(
                ConnectionString.Parse(AssertNotNullOrEmpty(connectionString, nameof(connectionString))),
                new PhoneNumbersClientOptions())
        { }

        /// <summary>
        /// Initializes a phone numbers client with an Azure resource connection string and client options.
        /// </summary>
        public PhoneNumbersClient(string connectionString, PhoneNumbersClientOptions options)
            : this(
                ConnectionString.Parse(AssertNotNullOrEmpty(connectionString, nameof(connectionString))),
                options ?? new PhoneNumbersClientOptions())
        { }

        /// <summary> Initializes a new instance of <see cref="PhoneNumbersClient"/>.</summary>
        /// <param name="endpoint">The URI of the Azure Communication Services resource.</param>
        /// <param name="keyCredential">The <see cref="AzureKeyCredential"/> used to authenticate requests.</param>
        /// <param name="options">Client option exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public PhoneNumbersClient(Uri endpoint, AzureKeyCredential keyCredential, PhoneNumbersClientOptions options = default)
            : this(
                AssertNotNull(endpoint, nameof(endpoint)).AbsoluteUri,
                AssertNotNull(keyCredential, nameof(keyCredential)),
                options ?? new PhoneNumbersClientOptions())
        { }

        /// <summary>
        /// Initializes a phone numbers client with a token credential.
        /// <param name="endpoint">The URI of the Azure Communication Services resource.</param>
        /// <param name="tokenCredential">The <see cref="TokenCredential"/> used to authenticate requests, such as DefaultAzureCredential.</param>
        /// <param name="options">Client option exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        /// </summary>
        public PhoneNumbersClient(Uri endpoint, TokenCredential tokenCredential, PhoneNumbersClientOptions options = default)
            : this(
                AssertNotNull(endpoint, nameof(endpoint)).AbsoluteUri,
                AssertNotNull(tokenCredential, nameof(tokenCredential)),
                options ?? new PhoneNumbersClientOptions())
        { }

        #endregion

        #region private constructors

        private PhoneNumbersClient(ConnectionString connectionString, PhoneNumbersClientOptions options)
            : this(connectionString.GetRequired("endpoint"), options.BuildHttpPipeline(connectionString), options)
        { }

        private PhoneNumbersClient(string endpoint, AzureKeyCredential keyCredential, PhoneNumbersClientOptions options)
            : this(endpoint, options.BuildHttpPipeline(keyCredential), options)
        { }

        private PhoneNumbersClient(string endpoint, TokenCredential tokenCredential, PhoneNumbersClientOptions options)
            : this(endpoint, options.BuildHttpPipeline(tokenCredential), options)
        { }

        private PhoneNumbersClient(string endpoint, HttpPipeline httpPipeline, PhoneNumbersClientOptions options)
            : this(new ClientDiagnostics(options), httpPipeline, endpoint, options.ApiVersion)
        { }

        #endregion

        /// <summary> Gets the details of the given acquired phone number. </summary>
        /// <param name="phoneNumber"> The acquired phone number whose details are to be fetched in E.164 format, e.g. +11234567890. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<AcquiredPhoneNumber>> GetPhoneNumberAsync(string phoneNumber, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PhoneNumbersClient.GetPhoneNumber");
            scope.Start();
            try
            {
                return await RestClient.GetByNumberAsync(phoneNumber, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets the details of the given acquired phone number. </summary>
        /// <param name="phoneNumber"> The acquired phone number whose details are to be fetched in E.164 format, e.g. +11234567890. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<AcquiredPhoneNumber> GetPhoneNumber(string phoneNumber, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PhoneNumbersClient.GetPhoneNumber");
            scope.Start();
            try
            {
                return RestClient.GetByNumber(phoneNumber, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Purchases phone numbers. </summary>
        /// <param name="searchId"> The search id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<PurchasePhoneNumbersOperation> StartPurchasePhoneNumbersAsync(string searchId, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PhoneNumbersClient.StartPurchasePhoneNumbers");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.PurchasePhoneNumbersAsync(searchId, cancellationToken).ConfigureAwait(false);
                return new PurchasePhoneNumbersOperation(_clientDiagnostics, _pipeline, RestClient.CreatePurchasePhoneNumbersRequest(searchId).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Purchases phone numbers. </summary>
        /// <param name="searchId"> The search id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual PurchasePhoneNumbersOperation StartPurchasePhoneNumbers(string searchId, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("PhoneNumbersClient.StartPurchasePhoneNumbers");
            scope.Start();
            try
            {
                var originalResponse = RestClient.PurchasePhoneNumbers(searchId, cancellationToken);
                return new PurchasePhoneNumbersOperation(_clientDiagnostics, _pipeline, RestClient.CreatePurchasePhoneNumbersRequest(searchId).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Search for available phone numbers to purchase. </summary>
        /// <param name="threeLetterISOCountryName"> The ISO 3166-2 country code, e.g. US. </param>
        /// <param name="phoneNumberType"> The type of phone numbers to search for. </param>
        /// <param name="phoneNumberAssignmentType"> The assignment type of the phone numbers to search for. </param>
        /// <param name="capabilities"> Capabilities of a phone number. </param>
        /// <param name="searchOptions"> The phone number search options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="threeLetterISOCountryName"/> is null. </exception>
        public virtual async Task<SearchAvailablePhoneNumbersOperation> StartSearchAvailablePhoneNumbersAsync(string threeLetterISOCountryName, PhoneNumberType phoneNumberType, PhoneNumberAssignmentType phoneNumberAssignmentType,
            PhoneNumberCapabilities capabilities, PhoneNumberSearchOptions searchOptions = null, CancellationToken cancellationToken = default)
        {
            if (threeLetterISOCountryName == null)
            {
                throw new ArgumentNullException(nameof(threeLetterISOCountryName));
            }
            if (capabilities == null)
            {
                throw new ArgumentNullException(nameof(capabilities));
            }

            using var scope = _clientDiagnostics.CreateScope("PhoneNumbersClient.StartSearchAvailablePhoneNumbers");
            scope.Start();
            try
            {
                var searchRequest = new PhoneNumberSearchRequest(phoneNumberType, phoneNumberAssignmentType, capabilities) { AreaCode = searchOptions?.AreaCode, Quantity = searchOptions?.Quantity };
                var originalResponse = await RestClient.SearchAvailablePhoneNumbersAsync(threeLetterISOCountryName, searchRequest, cancellationToken).ConfigureAwait(false);
                return new SearchAvailablePhoneNumbersOperation(_clientDiagnostics, _pipeline, RestClient.CreateSearchAvailablePhoneNumbersRequest(threeLetterISOCountryName, searchRequest).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Search for available phone numbers to purchase. </summary>
        /// <param name="threeLetterISOCountryName"> The ISO 3166-2 country code, e.g. US. </param>
        /// <param name="phoneNumberType"> The type of phone numbers to search for. </param>
        /// <param name="phoneNumberAssignmentType"> The assignment type of the phone numbers to search for. </param>
        /// <param name="capabilities"> Capabilities of a phone number. </param>
        /// <param name="searchOptions"> The phone number search options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="threeLetterISOCountryName"/> is null. </exception>
        public virtual SearchAvailablePhoneNumbersOperation StartSearchAvailablePhoneNumbers(string threeLetterISOCountryName, PhoneNumberType phoneNumberType, PhoneNumberAssignmentType phoneNumberAssignmentType,
            PhoneNumberCapabilities capabilities, PhoneNumberSearchOptions searchOptions = null, CancellationToken cancellationToken = default)
        {
            if (threeLetterISOCountryName == null)
            {
                throw new ArgumentNullException(nameof(threeLetterISOCountryName));
            }
            if (capabilities == null)
            {
                throw new ArgumentNullException(nameof(capabilities));
            }

            using var scope = _clientDiagnostics.CreateScope("PhoneNumbersClient.StartSearchAvailablePhoneNumbers");
            scope.Start();
            try
            {
                var searchRequest = new PhoneNumberSearchRequest(phoneNumberType, phoneNumberAssignmentType, capabilities) { AreaCode = searchOptions?.AreaCode, Quantity = searchOptions?.Quantity };
                var originalResponse = RestClient.SearchAvailablePhoneNumbers(threeLetterISOCountryName, searchRequest, cancellationToken);
                return new SearchAvailablePhoneNumbersOperation(_clientDiagnostics, _pipeline, RestClient.CreateSearchAvailablePhoneNumbersRequest(threeLetterISOCountryName, searchRequest).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets the list of all acquired phone numbers. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<AcquiredPhoneNumber> ListPhoneNumbersAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<AcquiredPhoneNumber>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("PhoneNumbersClient.ListPhoneNumbers");
                scope.Start();
                try
                {
                    var response = await RestClient.ListPhoneNumbersAsync(skip: null, top: null, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.PhoneNumbers, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<AcquiredPhoneNumber>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("PhoneNumbersClient.ListPhoneNumbers");
                scope.Start();
                try
                {
                    var response = await RestClient.ListPhoneNumbersNextPageAsync(nextLink, skip: null, top: null, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.PhoneNumbers, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Gets the list of all acquired phone numbers. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<AcquiredPhoneNumber> ListPhoneNumbers(CancellationToken cancellationToken = default)
        {
            Page<AcquiredPhoneNumber> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("PhoneNumbersClient.ListPhoneNumbers");
                scope.Start();
                try
                {
                    var response = RestClient.ListPhoneNumbers(skip: null, top: null, cancellationToken);
                    return Page.FromValues(response.Value.PhoneNumbers, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<AcquiredPhoneNumber> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("PhoneNumbersClient.ListPhoneNumbers");
                scope.Start();
                try
                {
                    var response = RestClient.ListPhoneNumbersNextPage(nextLink, skip: null, top: null, cancellationToken);
                    return Page.FromValues(response.Value.PhoneNumbers, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        private static T AssertNotNull<T>(T argument, string argumentName)
            where T : class
        {
            Argument.AssertNotNull(argument, argumentName);
            return argument;
        }

        private static string AssertNotNullOrEmpty(string argument, string argumentName)
        {
            Argument.AssertNotNullOrEmpty(argument, argumentName);
            return argument;
        }
    }
}
