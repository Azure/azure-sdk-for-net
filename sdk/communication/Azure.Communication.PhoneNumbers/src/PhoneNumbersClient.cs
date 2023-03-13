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
    public class PhoneNumbersClient : IPhoneNumbersClient
    {
        internal InternalPhoneNumbersRestClient RestClient { get; }
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;
        private readonly string _acceptedLanguage;

        #region public constructors - all arguments need null check

        /// <summary>
        /// Initializes a phone numbers client with an Azure resource connection string and client options.
        /// </summary>
        public PhoneNumbersClient(string connectionString)
            : this(
                ConnectionString.Parse(Argument.CheckNotNullOrEmpty(connectionString, nameof(connectionString))),
                new PhoneNumbersClientOptions())
        { }

        /// <summary>
        /// Initializes a phone numbers client with an Azure resource connection string and client options.
        /// </summary>
        public PhoneNumbersClient(string connectionString, PhoneNumbersClientOptions options)
            : this(
                ConnectionString.Parse(Argument.CheckNotNullOrEmpty(connectionString, nameof(connectionString))),
                options ?? new PhoneNumbersClientOptions())
        { }

        /// <summary> Initializes a new instance of <see cref="PhoneNumbersClient"/>.</summary>
        /// <param name="endpoint">The URI of the Azure Communication Services resource.</param>
        /// <param name="keyCredential">The <see cref="AzureKeyCredential"/> used to authenticate requests.</param>
        /// <param name="options">Client option exposing <see cref="ClientOptions.Diagnostics"/>, <see cref="ClientOptions.Retry"/>, <see cref="ClientOptions.Transport"/>, etc.</param>
        public PhoneNumbersClient(Uri endpoint, AzureKeyCredential keyCredential, PhoneNumbersClientOptions options = default)
            : this(
                Argument.CheckNotNull(endpoint, nameof(endpoint)).AbsoluteUri,
                Argument.CheckNotNull(keyCredential, nameof(keyCredential)),
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
                Argument.CheckNotNull(endpoint, nameof(endpoint)).AbsoluteUri,
                Argument.CheckNotNull(tokenCredential, nameof(tokenCredential)),
                options ?? new PhoneNumbersClientOptions())
        { }

        #endregion

        #region private constructors

        private PhoneNumbersClient(ConnectionString connectionString, PhoneNumbersClientOptions options)
            : this(connectionString.GetRequired("endpoint"), options.BuildPhoneNumbersHttpPipeline(connectionString), options)
        { }

        private PhoneNumbersClient(string endpoint, AzureKeyCredential keyCredential, PhoneNumbersClientOptions options)
            : this(endpoint, options.BuildPhoneNumbersHttpPipeline(keyCredential), options)
        { }

        private PhoneNumbersClient(string endpoint, TokenCredential tokenCredential, PhoneNumbersClientOptions options)
            : this(endpoint, options.BuildPhoneNumbersHttpPipeline(tokenCredential), options)
        { }

        private PhoneNumbersClient(string endpoint, HttpPipeline httpPipeline, PhoneNumbersClientOptions options)
            : this(new ClientDiagnostics(options), httpPipeline, endpoint, options.AcceptedLanguage, options.Version)
        { }

        /// <summary> Initializes a new instance of PhoneNumbersClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> The communication resource, for example https://resourcename.communication.azure.com. </param>
        /// <param name="acceptedLanguage"> The accepted language to be used for response localization. </param>
        /// <param name="apiVersion"> Api Version. </param>
        private PhoneNumbersClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string endpoint, string acceptedLanguage, string apiVersion = "2021-03-07")
        {
            RestClient = new InternalPhoneNumbersRestClient(clientDiagnostics, pipeline, endpoint, apiVersion);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
            _acceptedLanguage = acceptedLanguage;
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

        /// <summary> Lists the available countries from which to purchase phone numbers. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<PhoneNumberCountry> GetAvailableCountriesAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<PhoneNumberCountry>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumbersClient)}.{nameof(GetAvailableCountries)}");
                scope.Start();
                try
                {
                    var response = await RestClient.ListAvailableCountriesAsync( skip: null, maxPageSize: null, acceptLanguage: _acceptedLanguage, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Countries, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<PhoneNumberCountry>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumbersClient)}.{nameof(GetPurchasedPhoneNumbers)}");
                scope.Start();
                try
                {
                    var response = await RestClient.ListAvailableCountriesNextPageAsync(nextLink, skip: null, maxPageSize: null, acceptLanguage: _acceptedLanguage, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Countries, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Lists the available countries from which to purchase phone numbers. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<PhoneNumberCountry> GetAvailableCountries(CancellationToken cancellationToken = default)
        {
            Page<PhoneNumberCountry> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumbersClient)}.{nameof(GetAvailableCountries)}");
                scope.Start();
                try
                {
                    var response = RestClient.ListAvailableCountries(skip: null, maxPageSize: null, acceptLanguage: _acceptedLanguage, cancellationToken);
                    return Page.FromValues(response.Value.Countries, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<PhoneNumberCountry> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumbersClient)}.{nameof(GetPurchasedPhoneNumbers)}");
                scope.Start();
                try
                {
                    var response = RestClient.ListAvailableCountriesNextPage(nextLink, skip: null, maxPageSize: null, acceptLanguage: _acceptedLanguage, cancellationToken);
                    return Page.FromValues(response.Value.Countries, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Lists the available localities (e.g. city or town) in the given country from which to purchase phone numbers. </summary>
        /// <param name="twoLetterIsoCountryName"> The ISO 3166-2 country code, e.g. US. </param>
        /// <param name="administrativeDivision"> The administrative division within the country within which to list localities. This is also known as the state or province. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<PhoneNumberLocality> GetAvailableLocalitiesAsync(string twoLetterIsoCountryName, string administrativeDivision = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<PhoneNumberLocality>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumbersClient)}.{nameof(GetAvailableLocalities)}");
                scope.Start();
                try
                {
                    var response = await RestClient.ListAvailableLocalitiesAsync(twoLetterIsoCountryName, skip: null, maxPageSize: null, administrativeDivision, acceptLanguage: _acceptedLanguage, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.PhoneNumberLocalitiesValue, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<PhoneNumberLocality>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumbersClient)}.{nameof(GetAvailableLocalities)}");
                scope.Start();
                try
                {
                    var response = await RestClient.ListAvailableLocalitiesNextPageAsync(nextLink, twoLetterIsoCountryName, skip: null, maxPageSize: null, administrativeDivision, acceptLanguage: _acceptedLanguage, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.PhoneNumberLocalitiesValue, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Lists the available localities (e.g. city or town) in the given country from which to purchase phone numbers. </summary>
        /// <param name="twoLetterIsoCountryName"> The ISO 3166-2 country code, e.g. US. </param>
        /// <param name="administrativeDivision"> The administrative division within the country within which to list localities. This is also known as the state or province. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<PhoneNumberLocality> GetAvailableLocalities(string twoLetterIsoCountryName, string administrativeDivision = null, CancellationToken cancellationToken = default)
        {
            Page<PhoneNumberLocality> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumbersClient)}.{nameof(GetAvailableLocalities)}");
                scope.Start();
                try
                {
                    var response = RestClient.ListAvailableLocalities(twoLetterIsoCountryName, skip: null, maxPageSize: null, administrativeDivision, acceptLanguage: _acceptedLanguage, cancellationToken);
                    return Page.FromValues(response.Value.PhoneNumberLocalitiesValue, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<PhoneNumberLocality> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumbersClient)}.{nameof(GetAvailableLocalities)}");
                scope.Start();
                try
                {
                    var response = RestClient.ListAvailableLocalitiesNextPage(nextLink, twoLetterIsoCountryName, skip: null, maxPageSize: null, administrativeDivision, acceptLanguage: _acceptedLanguage, cancellationToken);
                    return Page.FromValues(response.Value.PhoneNumberLocalitiesValue, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Lists the available area codes within a given country and locality. </summary>
        /// <param name="twoLetterIsoCountryName"> The ISO 3166-2 country code, e.g. US. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<PhoneNumberAreaCode> GetAvailableAreaCodesTollFreeAsync(string twoLetterIsoCountryName, CancellationToken cancellationToken = default)
        {
            return GetAvailableAreaCodesAsync(twoLetterIsoCountryName, PhoneNumberType.TollFree, PhoneNumberAssignmentType.Application, null, null, cancellationToken);
        }

        /// <summary> Lists the available area codes within a given country and locality. </summary>
        /// <param name="twoLetterIsoCountryName"> The ISO 3166-2 country code, e.g. US. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<PhoneNumberAreaCode>GetAvailableAreaCodesTollFree(string twoLetterIsoCountryName, CancellationToken cancellationToken = default)
        {
            return GetAvailableAreaCodes(twoLetterIsoCountryName, PhoneNumberType.TollFree, PhoneNumberAssignmentType.Application, null, null, cancellationToken);
        }

        /// <summary> Lists the available area codes within a given country and locality. </summary>
        /// <param name="twoLetterIsoCountryName"> The ISO 3166-2 country code, e.g. US. </param>
        /// <param name="phoneNumberAssignmentType"> The assignment type of the phone numbers to search for. </param>
        /// <param name="locality"> The locality in which to list area codes. This is also known as the state or province. </param>
        /// <param name="administrativeDivision"> Optionally, the administrative division of the locality. This is also known as the state or province. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<PhoneNumberAreaCode> GetAvailableAreaCodesGeographicAsync(string twoLetterIsoCountryName, PhoneNumberAssignmentType phoneNumberAssignmentType, string locality, string administrativeDivision = null, CancellationToken cancellationToken = default)
        {
            return GetAvailableAreaCodesAsync(twoLetterIsoCountryName, PhoneNumberType.Geographic, phoneNumberAssignmentType, locality, administrativeDivision, cancellationToken);
        }

        /// <summary> Lists the available area codes within a given country and locality. </summary>
        /// <param name="twoLetterIsoCountryName"> The ISO 3166-2 country code, e.g. US. </param>
        /// <param name="phoneNumberAssignmentType"> The assignment type of the phone numbers to search for. </param>
        /// <param name="locality"> The locality in which to list area codes. This is also known as the state or province. </param>
        /// <param name="administrativeDivision"> Optionally, the administrative division of the locality. This is also known as the state or province. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<PhoneNumberAreaCode> GetAvailableAreaCodesGeographic(string twoLetterIsoCountryName, PhoneNumberAssignmentType phoneNumberAssignmentType, string locality, string administrativeDivision = null, CancellationToken cancellationToken = default)
        {
            return GetAvailableAreaCodes(twoLetterIsoCountryName, PhoneNumberType.Geographic, phoneNumberAssignmentType, locality, administrativeDivision, cancellationToken);
        }

        /// <summary> Lists the available offerings in the given country. </summary>
        /// <param name="twoLetterIsoCountryName"> The ISO 3166-2 country code, e.g. US. </param>
        /// <param name="phoneNumberType"> The type of phone numbers to search for. </param>
        /// <param name="phoneNumberAssignmentType"> The assignment type of the phone numbers to search for. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<PhoneNumberOffering> GetAvailableOfferingsAsync(string twoLetterIsoCountryName, PhoneNumberType? phoneNumberType = null, PhoneNumberAssignmentType? phoneNumberAssignmentType = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<PhoneNumberOffering>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumbersClient)}.{nameof(GetAvailableOfferings)}");
                scope.Start();
                try
                {
                    var response = await RestClient.ListOfferingsAsync(twoLetterIsoCountryName, skip: null, maxPageSize: null, phoneNumberType, phoneNumberAssignmentType, acceptLanguage: _acceptedLanguage, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.PhoneNumberOfferings, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<PhoneNumberOffering>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumbersClient)}.{nameof(GetAvailableOfferings)}");
                scope.Start();
                try
                {
                    var response = await RestClient.ListOfferingsNextPageAsync(nextLink, twoLetterIsoCountryName, skip: null, maxPageSize: null, phoneNumberType, phoneNumberAssignmentType, acceptLanguage: _acceptedLanguage, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.PhoneNumberOfferings, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Lists the available offerings in the given country. </summary>
        /// <param name="twoLetterIsoCountryName"> The ISO 3166-2 country code, e.g. US. </param>
        /// <param name="phoneNumberType"> The type of phone numbers to search for. </param>
        /// <param name="phoneNumberAssignmentType"> The assignment type of the phone numbers to search for. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<PhoneNumberOffering> GetAvailableOfferings(string twoLetterIsoCountryName, PhoneNumberType? phoneNumberType = null, PhoneNumberAssignmentType? phoneNumberAssignmentType = null, CancellationToken cancellationToken = default)
        {
            Page<PhoneNumberOffering> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumbersClient)}.{nameof(GetAvailableOfferings)}");
                scope.Start();
                try
                {
                    var response = RestClient.ListOfferings(twoLetterIsoCountryName, skip: null, maxPageSize: null, phoneNumberType, phoneNumberAssignmentType, acceptLanguage: _acceptedLanguage, cancellationToken);
                    return Page.FromValues(response.Value.PhoneNumberOfferings, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<PhoneNumberOffering> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumbersClient)}.{nameof(GetAvailableOfferings)}");
                scope.Start();
                try
                {
                    var response = RestClient.ListOfferingsNextPage(nextLink, twoLetterIsoCountryName, skip: null, maxPageSize: null, phoneNumberType, phoneNumberAssignmentType, acceptLanguage: _acceptedLanguage, cancellationToken);
                    return Page.FromValues(response.Value.PhoneNumberOfferings, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Lists the available area codes within a given country and locality. </summary>
        /// <param name="twoLetterIsoCountryName"> The ISO 3166-2 country code, e.g. US. </param>
        /// <param name="phoneNumberType"> The type of phone numbers to search for. </param>
        /// <param name="phoneNumberAssignmentType"> The assignment type of the phone numbers to search for. </param>
        /// <param name="locality"> The locality in which to list area codes. This is also known as the state or province. </param>
        /// <param name="administrativeDivision"> Optionally, the administrative division of the locality. This is also known as the state or province. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        private AsyncPageable<PhoneNumberAreaCode> GetAvailableAreaCodesAsync(string twoLetterIsoCountryName, PhoneNumberType phoneNumberType, PhoneNumberAssignmentType phoneNumberAssignmentType, string locality, string administrativeDivision = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<PhoneNumberAreaCode>> FirstPageFunc(int? pageSizeHint)
            {
                var operationName = "";
                if (phoneNumberType == "geographic")
                {
                    operationName = "GetAvailableAreaCodesGeographic";
                }
                else if (phoneNumberType == "tollFree")
                {
                    operationName = "GetAvailableAreaCodesTollFree";
                }
                using var scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumbersClient)}.{operationName}");
                scope.Start();
                try
                {
                    var response = await RestClient.ListAreaCodesAsync(twoLetterIsoCountryName, phoneNumberType, skip: null, maxPageSize: null, phoneNumberAssignmentType, locality, administrativeDivision, acceptLanguage: _acceptedLanguage, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.AreaCodes, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<PhoneNumberAreaCode>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var operationName = "";
                if (phoneNumberType == "geographic")
                {
                    operationName = "GetAvailableAreaCodesGeographic";
                }
                else if (phoneNumberType == "tollFree")
                {
                    operationName = "GetAvailableAreaCodesTollFree";
                }
                using var scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumbersClient)}.{operationName}");
                scope.Start();
                try
                {
                    var response = await RestClient.ListAreaCodesNextPageAsync(nextLink, twoLetterIsoCountryName, phoneNumberType, skip: null, maxPageSize: null, phoneNumberAssignmentType, locality, administrativeDivision, acceptLanguage: _acceptedLanguage, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.AreaCodes, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Lists the available area codes within a given country and locality. </summary>
        /// <param name="twoLetterIsoCountryName"> The ISO 3166-2 country code, e.g. US. </param>
        /// <param name="phoneNumberType"> The type of phone numbers to search for. </param>
        /// <param name="phoneNumberAssignmentType"> The assignment type of the phone numbers to search for. </param>
        /// <param name="locality"> The locality in which to list area codes. This is also known as the state or province. </param>
        /// <param name="administrativeDivision"> Optionally, the administrative division of the locality. This is also known as the state or province. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        private Pageable<PhoneNumberAreaCode> GetAvailableAreaCodes(string twoLetterIsoCountryName, PhoneNumberType phoneNumberType, PhoneNumberAssignmentType phoneNumberAssignmentType, string locality, string administrativeDivision = null, CancellationToken cancellationToken = default)
        {
            Page<PhoneNumberAreaCode> FirstPageFunc(int? pageSizeHint)
            {
                var operationName = "";
                if (phoneNumberType == "geographic")
                {
                    operationName = "GetAvailableAreaCodesGeographic";
                }
                else if (phoneNumberType == "tollFree")
                {
                    operationName = "GetAvailableAreaCodesTollFree";
                }
                using var scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumbersClient)}.{operationName}");
                scope.Start();
                try
                {
                    var response = RestClient.ListAreaCodes(twoLetterIsoCountryName, phoneNumberType, skip: null, maxPageSize: null, phoneNumberAssignmentType, locality, administrativeDivision, acceptLanguage: _acceptedLanguage, cancellationToken);
                    return Page.FromValues(response.Value.AreaCodes, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<PhoneNumberAreaCode> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                var operationName = "";
                if (phoneNumberType == "geographic")
                {
                    operationName = "GetAvailableAreaCodesGeographic";
                }
                else if (phoneNumberType == "tollFree")
                {
                    operationName = "GetAvailableAreaCodesTollFree";
                }
                using var scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumbersClient)}.{operationName}");
                scope.Start();
                try
                {
                    var response = RestClient.ListAreaCodesNextPage(nextLink, twoLetterIsoCountryName, phoneNumberType, skip: null, maxPageSize: null, phoneNumberAssignmentType, locality, administrativeDivision, acceptLanguage: _acceptedLanguage, cancellationToken);
                    return Page.FromValues(response.Value.AreaCodes, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Gets the result of a search </summary>
        /// <param name="searchId"> The cancellation token to use. </param>
        public AsyncPageable<PhoneNumberSearchResult> GetPhoneNumberSearchResult(string searchId)
        {
            throw new NotImplementedException();
        }
    }
}
