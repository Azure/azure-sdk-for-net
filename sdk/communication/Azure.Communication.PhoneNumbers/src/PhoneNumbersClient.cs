﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
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
        internal InternalPhoneNumbersClient InternalClient { get; }
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
            : this(new ClientDiagnostics(options, suppressNestedClientActivities: false), httpPipeline, endpoint, options.AcceptedLanguage, options.Version)
        { }

        /// <summary> Initializes a new instance of PhoneNumbersClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> The communication resource, for example https://resourcename.communication.azure.com. </param>
        /// <param name="acceptedLanguage"> The accepted language to be used for response localization. </param>
        /// <param name="apiVersion"> Api Version. </param>
        private PhoneNumbersClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string endpoint, string acceptedLanguage, string apiVersion = "2021-03-07")
        {
            InternalClient = new InternalPhoneNumbersClient(clientDiagnostics, pipeline, endpoint, apiVersion);
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
            using var scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumbersClient)}.{nameof(StartReleasePhoneNumber)}");
            scope.Start();
            try
            {
                var originalResponse = await InternalClient.StartReleasePhoneNumberAsync(phoneNumber, cancellationToken).ConfigureAwait(false);
                return new ReleasePhoneNumberOperation(originalResponse);
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
                var originalResponse = InternalClient.StartReleasePhoneNumber(phoneNumber, cancellationToken);
                return new ReleasePhoneNumberOperation(originalResponse);
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
            using var scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumbersClient)}.{nameof(StartUpdateCapabilities)}");
            scope.Start();
            try
            {
                return await InternalClient.StartUpdateCapabilitiesAsync(phoneNumber, calling, sms, cancellationToken).ConfigureAwait(false);
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
            using var scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumbersClient)}.{nameof(StartUpdateCapabilities)}");
            scope.Start();
            try
            {
                return InternalClient.StartUpdateCapabilities(phoneNumber, calling, sms, cancellationToken);
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
                return await InternalClient.GetByNumberAsync(phoneNumber, cancellationToken).ConfigureAwait(false);
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
                return InternalClient.GetByNumber(phoneNumber, cancellationToken);
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
                var originalResponse = await InternalClient.StartPurchasePhoneNumbersAsync(searchId, cancellationToken).ConfigureAwait(false);
                return new PurchasePhoneNumbersOperation(originalResponse);
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
                var originalResponse = InternalClient.StartPurchasePhoneNumbers(searchId, cancellationToken);
                return new PurchasePhoneNumbersOperation(originalResponse);
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
            using var scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumbersClient)}.{nameof(StartSearchAvailablePhoneNumbers)}");
            scope.Start();
            try
            {
                var searchRequest = new PhoneNumberSearchRequest(phoneNumberType, phoneNumberAssignmentType, capabilities) { AreaCode = options?.AreaCode, Quantity = options?.Quantity };
                return await InternalClient.StartSearchAvailablePhoneNumbersAsync(twoLetterIsoCountryName, searchRequest, cancellationToken).ConfigureAwait(false);
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
            using var scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumbersClient)}.{nameof(StartSearchAvailablePhoneNumbers)}");
            scope.Start();
            try
            {
                var searchRequest = new PhoneNumberSearchRequest(phoneNumberType, phoneNumberAssignmentType, capabilities) { AreaCode = options?.AreaCode, Quantity = options?.Quantity };
                return InternalClient.StartSearchAvailablePhoneNumbers(twoLetterIsoCountryName, searchRequest, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Retrieve the search result details. </summary>
        /// <param name="searchId"> The id of the search to retrieve the phone numbers. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<PhoneNumberSearchResult>> GetPhoneNumberSearchResultAsync(string searchId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(searchId, nameof(searchId));

            using var scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumbersClient)}.{nameof(GetPhoneNumberSearchResult)}");
            scope.Start();
            try
            {
                return await InternalClient.GetSearchResultAsync(searchId, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Retrieve the search result details. </summary>
        /// <param name="searchId"> The id of the search to retrieve the phone numbers. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<PhoneNumberSearchResult> GetPhoneNumberSearchResult(string searchId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(searchId, nameof(searchId));

            using var scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumbersClient)}.{nameof(GetPhoneNumberSearchResult)}");
            scope.Start();
            try
            {
                return InternalClient.GetSearchResult(searchId, cancellationToken);
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
            HttpMessage FirstPageRequest(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumbersClient)}.{nameof(GetPurchasedPhoneNumbers)}");
                scope.Start();
                try
                {
                    return RestClient.CreateListPhoneNumbersRequest(null, pageSizeHint);
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            }
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink)
            {
                using var scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumbersClient)}.{nameof(GetPurchasedPhoneNumbers)}");
                scope.Start();
                try
                {
                    int skip = int.Parse(HttpUtility.ParseQueryString(nextLink).Get("skip"));

                    return RestClient.CreateListPhoneNumbersNextPageRequest(nextLink, skip, pageSizeHint);
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, PurchasedPhoneNumber.DeserializePurchasedPhoneNumber, _clientDiagnostics, _pipeline, "InternalPhoneNumbersClient.ListPhoneNumbers", "phoneNumbers", "nextLink", cancellationToken);
        }

        /// <summary> Gets the list of all purchased phone numbers. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<PurchasedPhoneNumber> GetPurchasedPhoneNumbers(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumbersClient)}.{nameof(GetPurchasedPhoneNumbers)}");
                scope.Start();
                try
                {
                    return RestClient.CreateListPhoneNumbersRequest(null, pageSizeHint);
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            }
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink)
            {
                using var scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumbersClient)}.{nameof(GetPurchasedPhoneNumbers)}");
                scope.Start();
                try
                {
                    int skip = int.Parse(HttpUtility.ParseQueryString(nextLink).Get("skip"));

                    return RestClient.CreateListPhoneNumbersNextPageRequest(nextLink, skip, pageSizeHint);
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            }
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, PurchasedPhoneNumber.DeserializePurchasedPhoneNumber, _clientDiagnostics, _pipeline, "InternalPhoneNumbersClient.ListPhoneNumbers", "phoneNumbers", "nextLink", cancellationToken);
        }

        /// <summary> Lists the available countries from which to purchase phone numbers. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<PhoneNumberCountry> GetAvailableCountriesAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumbersClient)}.{nameof(GetAvailableCountries)}");
                scope.Start();
                try
                {
                    return RestClient.CreateListAvailableCountriesRequest(null, pageSizeHint, null);
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            }
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink)
            {
                using var scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumbersClient)}.{nameof(GetAvailableCountries)}");
                scope.Start();
                try
                {
                    int skip = int.Parse(HttpUtility.ParseQueryString(nextLink).Get("skip"));

                    return RestClient.CreateListAvailableCountriesNextPageRequest(nextLink, skip, pageSizeHint, null);
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, PhoneNumberCountry.DeserializePhoneNumberCountry, _clientDiagnostics, _pipeline, "InternalPhoneNumbersClient.ListAvailableCountries", "countries", "nextLink", cancellationToken);
        }

        /// <summary> Lists the available countries from which to purchase phone numbers. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<PhoneNumberCountry> GetAvailableCountries(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumbersClient)}.{nameof(GetAvailableCountries)}");
                scope.Start();
                try
                {
                    return RestClient.CreateListAvailableCountriesRequest(null, pageSizeHint, null);
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            }
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink)
            {
                using var scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumbersClient)}.{nameof(GetAvailableCountries)}");
                scope.Start();
                try
                {
                    int skip = int.Parse(HttpUtility.ParseQueryString(nextLink).Get("skip"));

                    return RestClient.CreateListAvailableCountriesNextPageRequest(nextLink, skip, pageSizeHint, null);
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            }
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, PhoneNumberCountry.DeserializePhoneNumberCountry, _clientDiagnostics, _pipeline, "InternalPhoneNumbersClient.ListAvailableCountries", "countries", "nextLink", cancellationToken);
        }

        /// <summary> Lists the available localities (e.g. city or town) in the given country from which to purchase phone numbers. </summary>
        /// <param name="twoLetterIsoCountryName"> The ISO 3166-2 country code, e.g. US. </param>
        /// <param name="administrativeDivision"> The administrative division within the country within which to list localities. This is also known as the state or province. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<PhoneNumberLocality> GetAvailableLocalitiesAsync(string twoLetterIsoCountryName, string administrativeDivision = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumbersClient)}.{nameof(GetAvailableLocalities)}");
                scope.Start();
                try
                {
                    return RestClient.CreateListAvailableLocalitiesRequest(twoLetterIsoCountryName, null, pageSizeHint, administrativeDivision, null);
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            }
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink)
            {
                using var scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumbersClient)}.{nameof(GetAvailableLocalities)}");
                scope.Start();
                try
                {
                    int skip = int.Parse(HttpUtility.ParseQueryString(nextLink).Get("skip"));

                    return RestClient.CreateListAvailableLocalitiesNextPageRequest(nextLink, twoLetterIsoCountryName, skip, pageSizeHint, administrativeDivision, null);
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, PhoneNumberLocality.DeserializePhoneNumberLocality, _clientDiagnostics, _pipeline, "InternalPhoneNumbersClient.ListAvailableLocalities", "phoneNumberLocalities", "nextLink", cancellationToken);
        }

        /// <summary> Lists the available localities (e.g. city or town) in the given country from which to purchase phone numbers. </summary>
        /// <param name="twoLetterIsoCountryName"> The ISO 3166-2 country code, e.g. US. </param>
        /// <param name="administrativeDivision"> The administrative division within the country within which to list localities. This is also known as the state or province. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<PhoneNumberLocality> GetAvailableLocalities(string twoLetterIsoCountryName, string administrativeDivision = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumbersClient)}.{nameof(GetAvailableLocalities)}");
                scope.Start();
                try
                {
                    return RestClient.CreateListAvailableLocalitiesRequest(twoLetterIsoCountryName, null, pageSizeHint, administrativeDivision, null);
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            }
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink)
            {
                using var scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumbersClient)}.{nameof(GetAvailableLocalities)}");
                scope.Start();
                try
                {
                    int skip = int.Parse(HttpUtility.ParseQueryString(nextLink).Get("skip"));

                    return RestClient.CreateListAvailableLocalitiesNextPageRequest(nextLink, twoLetterIsoCountryName, skip, pageSizeHint, administrativeDivision, null);
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            }
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, PhoneNumberLocality.DeserializePhoneNumberLocality, _clientDiagnostics, _pipeline, "InternalPhoneNumbersClient.ListAvailableLocalities", "phoneNumberLocalities", "nextLink", cancellationToken);
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
            HttpMessage FirstPageRequest(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumbersClient)}.{nameof(GetAvailableOfferings)}");
                scope.Start();
                try
                {
                    return RestClient.CreateListOfferingsRequest(twoLetterIsoCountryName, null, pageSizeHint, phoneNumberType, phoneNumberAssignmentType, null);
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            }
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink)
            {
                using var scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumbersClient)}.{nameof(GetAvailableOfferings)}");
                scope.Start();
                try
                {
                    int skip = int.Parse(HttpUtility.ParseQueryString(nextLink).Get("skip"));

                    return RestClient.CreateListOfferingsNextPageRequest(nextLink, twoLetterIsoCountryName, skip, pageSizeHint, phoneNumberType, phoneNumberAssignmentType, null);
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, PhoneNumberOffering.DeserializePhoneNumberOffering, _clientDiagnostics, _pipeline, "InternalPhoneNumbersClient.ListOfferings", "phoneNumberOfferings", "nextLink", cancellationToken);
        }

        /// <summary> Lists the available offerings in the given country. </summary>
        /// <param name="twoLetterIsoCountryName"> The ISO 3166-2 country code, e.g. US. </param>
        /// <param name="phoneNumberType"> The type of phone numbers to search for. </param>
        /// <param name="phoneNumberAssignmentType"> The assignment type of the phone numbers to search for. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<PhoneNumberOffering> GetAvailableOfferings(string twoLetterIsoCountryName, PhoneNumberType? phoneNumberType = null, PhoneNumberAssignmentType? phoneNumberAssignmentType = null, CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumbersClient)}.{nameof(GetAvailableOfferings)}");
                scope.Start();
                try
                {
                    return RestClient.CreateListOfferingsRequest(twoLetterIsoCountryName, null, pageSizeHint, phoneNumberType, phoneNumberAssignmentType, null);
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            }
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink)
            {
                using var scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumbersClient)}.{nameof(GetAvailableOfferings)}");
                scope.Start();
                try
                {
                    int skip = int.Parse(HttpUtility.ParseQueryString(nextLink).Get("skip"));

                    return RestClient.CreateListOfferingsNextPageRequest(nextLink, twoLetterIsoCountryName, skip, pageSizeHint, phoneNumberType, phoneNumberAssignmentType, null);
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            }
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, PhoneNumberOffering.DeserializePhoneNumberOffering, _clientDiagnostics, _pipeline, "InternalPhoneNumbersClient.ListOfferings", "phoneNumberOfferings", "nextLink", cancellationToken);
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
            var operationName = "";
            if (phoneNumberType == "geographic")
            {
                operationName = "GetAvailableAreaCodesGeographic";
            }
            else if (phoneNumberType == "tollFree")
            {
                operationName = "GetAvailableAreaCodesTollFree";
            }

            HttpMessage FirstPageRequest(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumbersClient)}.{operationName}");
                scope.Start();

                try
                {
                    return RestClient.CreateListAreaCodesRequest(twoLetterIsoCountryName, phoneNumberType, null, pageSizeHint, phoneNumberAssignmentType, locality, administrativeDivision, null);
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            }
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink)
            {
                using var scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumbersClient)}.{operationName}");
                scope.Start();

                try
                {
                    int skip = int.Parse(HttpUtility.ParseQueryString(nextLink).Get("skip"));
                    if (skip > pageSizeHint)
                    {
                        return null;
                    }

                    return RestClient.CreateListAreaCodesNextPageRequest(nextLink, twoLetterIsoCountryName, phoneNumberType, skip, pageSizeHint, phoneNumberAssignmentType, locality, administrativeDivision, null);
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, PhoneNumberAreaCode.DeserializePhoneNumberAreaCode, _clientDiagnostics, _pipeline, "InternalPhoneNumbersClient.ListAreaCodes", "areaCodes", "nextLink", cancellationToken);
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
            var operationName = "";
            if (phoneNumberType == "geographic")
            {
                operationName = "GetAvailableAreaCodesGeographic";
            }
            else if (phoneNumberType == "tollFree")
            {
                operationName = "GetAvailableAreaCodesTollFree";
            }
            HttpMessage FirstPageRequest(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumbersClient)}.{operationName}");
                scope.Start();

                try
                {
                    return RestClient.CreateListAreaCodesRequest(twoLetterIsoCountryName, phoneNumberType, null, pageSizeHint, phoneNumberAssignmentType, locality, administrativeDivision, null);
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            }
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink)
            {
                using var scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumbersClient)}.{operationName}");
                scope.Start();

                try
                {
                    int skip = int.Parse(HttpUtility.ParseQueryString(nextLink).Get("skip"));
                    if (skip > pageSizeHint)
                    {
                        return null;
                    }

                    return RestClient.CreateListAreaCodesNextPageRequest(nextLink, twoLetterIsoCountryName, phoneNumberType, skip, pageSizeHint, phoneNumberAssignmentType, locality, administrativeDivision, null);
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            }
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, PhoneNumberAreaCode.DeserializePhoneNumberAreaCode, _clientDiagnostics, _pipeline, "InternalPhoneNumbersClient.ListAreaCodes", "areaCodes", "nextLink", cancellationToken);
        }
    }
}
