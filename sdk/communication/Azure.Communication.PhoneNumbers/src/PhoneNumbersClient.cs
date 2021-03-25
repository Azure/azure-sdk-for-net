// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Communication.Pipeline;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Communication.PhoneNumbers
{
    /// <summary>
    /// The Azure Communication Services phone numbers client.
    /// </summary>
    public class PhoneNumbersClient
    {
        internal InternalPhoneNumbersRestClient RestClient { get; }
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;

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
            : this(new ClientDiagnostics(options), httpPipeline, endpoint, options.Version)
        { }

        /// <summary> Initializes a new instance of PhoneNumbersClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> The communication resource, for example https://resourcename.communication.azure.com. </param>
        /// <param name="apiVersion"> Api Version. </param>
        private PhoneNumbersClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string endpoint, string apiVersion = "2021-03-07")
        {
            RestClient = new InternalPhoneNumbersRestClient(clientDiagnostics, pipeline, endpoint, apiVersion);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        #endregion

        #region protected constructors
        /// <summary> Initializes a new instance of PhoneNumbersClient for mocking. </summary>
        protected PhoneNumbersClient()
        {
        }
        #endregion protected constructors

        /// <summary> Releases an purchased phone number. </summary>
        /// <param name="phoneNumber"> Phone number to be released, e.g. +14255550123. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="phoneNumber"/> is null. </exception>
        public virtual async Task<ReleasePhoneNumberOperation> StartReleasePhoneNumberAsync(string phoneNumber, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(phoneNumber, nameof(phoneNumber));

            using var scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumbersClient)}.{nameof(StartReleasePhoneNumber)}");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.ReleasePhoneNumberAsync(phoneNumber, cancellationToken).ConfigureAwait(false);
                return new ReleasePhoneNumberOperation(
                    new InternalReleasePhoneNumberOperation(_clientDiagnostics, _pipeline, RestClient.CreateReleasePhoneNumberRequest(phoneNumber).Request, originalResponse));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Releases an purchased phone number. </summary>
        /// <param name="phoneNumber"> Phone number to be released, e.g. +14255550123. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="phoneNumber"/> is null. </exception>
        public virtual ReleasePhoneNumberOperation StartReleasePhoneNumber(string phoneNumber, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(phoneNumber, nameof(phoneNumber));

            using var scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumbersClient)}.{nameof(StartReleasePhoneNumber)}");
            scope.Start();
            try
            {
                var originalResponse = RestClient.ReleasePhoneNumber(phoneNumber, cancellationToken);
                return new ReleasePhoneNumberOperation(
                    new InternalReleasePhoneNumberOperation(_clientDiagnostics, _pipeline, RestClient.CreateReleasePhoneNumberRequest(phoneNumber).Request, originalResponse));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Updates the capabilities of a phone number. </summary>
        /// <param name="phoneNumber"> The phone number id in E.164 format. The leading plus can be either + or encoded as %2B, e.g. +14255550123. </param>
        /// <param name="calling"> Capability value for calling. </param>
        /// <param name="sms"> Capability value for SMS. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="phoneNumber"/> is null. </exception>
        public virtual async Task<UpdatePhoneNumberCapabilitiesOperation> StartUpdateCapabilitiesAsync(string phoneNumber, PhoneNumberCapabilityType? calling = null, PhoneNumberCapabilityType? sms = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(phoneNumber, nameof(phoneNumber));

            using var scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumbersClient)}.{nameof(StartUpdateCapabilities)}");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.UpdateCapabilitiesAsync(phoneNumber, calling, sms, cancellationToken).ConfigureAwait(false);
                return new UpdatePhoneNumberCapabilitiesOperation(_clientDiagnostics, _pipeline, RestClient.CreateUpdateCapabilitiesRequest(phoneNumber, calling, sms).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Updates the capabilities of a phone number. </summary>
        /// <param name="phoneNumber"> The phone number id in E.164 format. The leading plus can be either + or encoded as %2B, e.g. +14255550123. </param>
        /// <param name="calling"> Capability value for calling. </param>
        /// <param name="sms"> Capability value for SMS. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="phoneNumber"/> is null. </exception>
        public virtual UpdatePhoneNumberCapabilitiesOperation StartUpdateCapabilities(string phoneNumber, PhoneNumberCapabilityType? calling = null, PhoneNumberCapabilityType? sms = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(phoneNumber, nameof(phoneNumber));

            using var scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumbersClient)}.{nameof(StartUpdateCapabilities)}");
            scope.Start();
            try
            {
                var originalResponse = RestClient.UpdateCapabilities(phoneNumber, calling, sms, cancellationToken);
                return new UpdatePhoneNumberCapabilitiesOperation(_clientDiagnostics, _pipeline, RestClient.CreateUpdateCapabilitiesRequest(phoneNumber, calling, sms).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets the details of the given purchased phone number. </summary>
        /// <param name="phoneNumber"> The acquired phone number whose details are to be fetched in E.164 format, e.g. +14255550123. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<PurchasedPhoneNumber>> GetPurchasedPhoneNumberAsync(string phoneNumber, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumbersClient)}.{nameof(GetPurchasedPhoneNumber)}");
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

        /// <summary> Gets the details of the given purchased phone number. </summary>
        /// <param name="phoneNumber"> The acquired phone number whose details are to be fetched in E.164 format, e.g. +14255550123. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<PurchasedPhoneNumber> GetPurchasedPhoneNumber(string phoneNumber, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumbersClient)}.{nameof(GetPurchasedPhoneNumber)}");
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
            using var scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumbersClient)}.{nameof(StartPurchasePhoneNumbers)}");
            scope.Start();
            try
            {
                var originalResponse = await RestClient.PurchasePhoneNumbersAsync(searchId, cancellationToken).ConfigureAwait(false);
                return new PurchasePhoneNumbersOperation(
                    new InternalPurchasePhoneNumbersOperation(_clientDiagnostics, _pipeline, RestClient.CreatePurchasePhoneNumbersRequest(searchId).Request, originalResponse));
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
            using var scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumbersClient)}.{nameof(StartPurchasePhoneNumbers)}");
            scope.Start();
            try
            {
                var originalResponse = RestClient.PurchasePhoneNumbers(searchId, cancellationToken);
                return new PurchasePhoneNumbersOperation(
                    new InternalPurchasePhoneNumbersOperation(_clientDiagnostics, _pipeline, RestClient.CreatePurchasePhoneNumbersRequest(searchId).Request, originalResponse));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Search for available phone numbers to purchase. </summary>
        /// <param name="twoLetterIsoCountryName"> The ISO 3166-2 country code, e.g. US. </param>
        /// <param name="phoneNumberType"> The type of phone numbers to search for. </param>
        /// <param name="phoneNumberAssignmentType"> The assignment type of the phone numbers to search for. </param>
        /// <param name="capabilities"> Capabilities of a phone number. </param>
        /// <param name="options"> The phone number search options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="twoLetterIsoCountryName"/> is null. </exception>
        public virtual async Task<SearchAvailablePhoneNumbersOperation> StartSearchAvailablePhoneNumbersAsync(string twoLetterIsoCountryName, PhoneNumberType phoneNumberType, PhoneNumberAssignmentType phoneNumberAssignmentType,
            PhoneNumberCapabilities capabilities, PhoneNumberSearchOptions options = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(twoLetterIsoCountryName, nameof(twoLetterIsoCountryName));
            Argument.AssertNotNull(capabilities, nameof(capabilities));

            using var scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumbersClient)}.{nameof(StartSearchAvailablePhoneNumbers)}");
            scope.Start();
            try
            {
                var searchRequest = new PhoneNumberSearchRequest(phoneNumberType, phoneNumberAssignmentType, capabilities) { AreaCode = options?.AreaCode, Quantity = options?.Quantity };
                var originalResponse = await RestClient.SearchAvailablePhoneNumbersAsync(twoLetterIsoCountryName, searchRequest, cancellationToken).ConfigureAwait(false);
                return new SearchAvailablePhoneNumbersOperation(_clientDiagnostics, _pipeline, RestClient.CreateSearchAvailablePhoneNumbersRequest(twoLetterIsoCountryName, searchRequest).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Search for available phone numbers to purchase. </summary>
        /// <param name="twoLetterIsoCountryName"> The ISO 3166-2 country code, e.g. US. </param>
        /// <param name="phoneNumberType"> The type of phone numbers to search for. </param>
        /// <param name="phoneNumberAssignmentType"> The assignment type of the phone numbers to search for. </param>
        /// <param name="capabilities"> Capabilities of a phone number. </param>
        /// <param name="options"> The phone number search options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="twoLetterIsoCountryName"/> is null. </exception>
        public virtual SearchAvailablePhoneNumbersOperation StartSearchAvailablePhoneNumbers(string twoLetterIsoCountryName, PhoneNumberType phoneNumberType, PhoneNumberAssignmentType phoneNumberAssignmentType,
            PhoneNumberCapabilities capabilities, PhoneNumberSearchOptions options = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(twoLetterIsoCountryName, nameof(twoLetterIsoCountryName));
            Argument.AssertNotNull(capabilities, nameof(capabilities));

            using var scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumbersClient)}.{nameof(StartSearchAvailablePhoneNumbers)}");
            scope.Start();
            try
            {
                var searchRequest = new PhoneNumberSearchRequest(phoneNumberType, phoneNumberAssignmentType, capabilities) { AreaCode = options?.AreaCode, Quantity = options?.Quantity };
                var originalResponse = RestClient.SearchAvailablePhoneNumbers(twoLetterIsoCountryName, searchRequest, cancellationToken);
                return new SearchAvailablePhoneNumbersOperation(_clientDiagnostics, _pipeline, RestClient.CreateSearchAvailablePhoneNumbersRequest(twoLetterIsoCountryName, searchRequest).Request, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets the list of all purchased phone numbers. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<PurchasedPhoneNumber> GetPurchasedPhoneNumbersAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<PurchasedPhoneNumber>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumbersClient)}.{nameof(GetPurchasedPhoneNumbers)}");
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
            async Task<Page<PurchasedPhoneNumber>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumbersClient)}.{nameof(GetPurchasedPhoneNumbers)}");
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

        /// <summary> Gets the list of all purchased phone numbers. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<PurchasedPhoneNumber> GetPurchasedPhoneNumbers(CancellationToken cancellationToken = default)
        {
            Page<PurchasedPhoneNumber> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumbersClient)}.{nameof(GetPurchasedPhoneNumbers)}");
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
            Page<PurchasedPhoneNumber> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumbersClient)}.{nameof(GetPurchasedPhoneNumbers)}");
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
