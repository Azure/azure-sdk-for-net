// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.Communication.Administration.Models;
using Azure.Communication.Pipeline;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Communication.Administration
{
    /// <summary>
    /// The Azure Communication Services phone number administration client.
    /// </summary>
    public class PhoneNumberAdministrationClient
    {
        internal ClientDiagnostics ClientDiagnostics { get; private set; }
        internal PhoneNumberAdministrationRestClient RestClient { get; }

        /// <summary>
        /// Initializes a phone number administration client with an Azure resource connection string.
        /// </summary>
        public PhoneNumberAdministrationClient(string connectionString)
            : this(new PhoneNumberAdministrationClientOptions(), ConnectionString.Parse(connectionString))
        { }

        /// <summary>
        /// Initializes a phone number administration client with an Azure resource connection string and client options.
        /// </summary>
        public PhoneNumberAdministrationClient(string connectionString, PhoneNumberAdministrationClientOptions? options = default)
            : this(
                  options ?? new PhoneNumberAdministrationClientOptions(),
                  ConnectionString.Parse(connectionString))
        { }

        internal PhoneNumberAdministrationClient(PhoneNumberAdministrationClientOptions options, ConnectionString connectionString)
            : this(new ClientDiagnostics(options), options.BuildHttpPipline(connectionString), connectionString.GetRequired("endpoint"))
        { }

        internal PhoneNumberAdministrationClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string endpointUrl)
        {
            RestClient = new PhoneNumberAdministrationRestClient(clientDiagnostics, pipeline, endpointUrl);
            ClientDiagnostics = clientDiagnostics;
        }

        /// <summary>Initializes a new instance of <see cref="PhoneNumberAdministrationClient"/> for mocking.</summary>
        protected PhoneNumberAdministrationClient()
        {
            ClientDiagnostics = null!;
            RestClient = null!;
        }

        /// <summary> Gets the list of the acquired phone numbers. </summary>
        /// <param name="locale"> A language-locale pairing which will be used to localise the names of countries. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A <see cref="AsyncPageable{AcquiredPhoneNumber}"/>. </returns>
        public virtual AsyncPageable<AcquiredPhoneNumber> GetAllPhoneNumbersAsync(string? locale = null, CancellationToken cancellationToken = default)
        {
            return ClientDiagnostics.RunScoped(() =>
                PageResponseEnumerator.CreateAsyncEnumerable(async nextLink =>
                {
                    Response<AcquiredPhoneNumbers> response = nextLink is null
                        ? await RestClient.GetAllPhoneNumbersAsync(locale, skip: null, take: null, cancellationToken).ConfigureAwait(false)
                        : await RestClient.GetAllPhoneNumbersNextPageAsync(nextLink, locale, skip: null, take: null, cancellationToken).ConfigureAwait(false);

                    return Page.FromValues(response.Value.PhoneNumbers, response.Value.NextLink, response.GetRawResponse());
                }),
                nameof(PhoneNumberAdministrationClient), nameof(GetAllPhoneNumbers));
        }

        /// <summary> Gets the list of the acquired phone numbers. </summary>
        /// <param name="locale"> A language-locale pairing which will be used to localise the names of countries. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A <see cref="Pageable{AcquiredPhoneNumber}"/>. </returns>
        public virtual Pageable<AcquiredPhoneNumber> GetAllPhoneNumbers(string? locale = null, CancellationToken cancellationToken = default)
        {
            return ClientDiagnostics.RunScoped(() =>
                PageResponseEnumerator.CreateEnumerable(nextLink =>
                {
                    Response<AcquiredPhoneNumbers> response = nextLink is null
                        ? RestClient.GetAllPhoneNumbers(locale, skip: null, take: null, cancellationToken)
                        : RestClient.GetAllPhoneNumbersNextPage(nextLink, locale, skip: null, take: null, cancellationToken);

                    return Page.FromValues(response.Value.PhoneNumbers, response.Value.NextLink, response.GetRawResponse());
                }),
                nameof(PhoneNumberAdministrationClient), nameof(GetAllPhoneNumbers)
            );
        }

        /// <summary> Gets a list of the supported area codes. </summary>
        /// <param name="locationType"> The type of location information required by the plan. </param>
        /// <param name="countryCode"> The ISO 3166-2 country code. </param>
        /// <param name="phonePlanId"> The plan id from which to search area codes. </param>
        /// <param name="locationOptions"> Represents the underlying list of countries. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A <see cref="Response{AreaCodes}"/>. </returns>
        public virtual async Task<Response<AreaCodes>> GetAllAreaCodesAsync(string locationType, string countryCode, string phonePlanId, IEnumerable<LocationOptionsQuery> locationOptions, CancellationToken cancellationToken = default)
        {
            return await ClientDiagnostics.RunScopedAsync(() =>
                RestClient.GetAllAreaCodesAsync(locationType, countryCode, phonePlanId, locationOptions, cancellationToken),
                nameof(PhoneNumberAdministrationClient), nameof(GetAllAreaCodes)).ConfigureAwait(false);
        }

        /// <summary> Gets a list of the supported area codes. </summary>
        /// <param name="locationType"> The type of location information required by the plan. </param>
        /// <param name="countryCode"> The ISO 3166-2 country code. </param>
        /// <param name="phonePlanId"> The plan id from which to search area codes. </param>
        /// <param name="locationOptions"> Represents the underlying list of countries. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A <see cref="Response{AreaCodes}"/>. </returns>
        public virtual Response<AreaCodes> GetAllAreaCodes(string locationType, string countryCode, string phonePlanId, IEnumerable<LocationOptionsQuery> locationOptions, CancellationToken cancellationToken = default)
        {
            return ClientDiagnostics.RunScoped(() =>
                RestClient.GetAllAreaCodes(locationType, countryCode, phonePlanId, locationOptions, cancellationToken),
                nameof(PhoneNumberAdministrationClient), nameof(GetAllAreaCodes));
        }

        /// <summary> Get capabilities by capabilities update id. </summary>
        /// <param name="capabilitiesUpdateId"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A <see cref="Response{UpdatePhoneNumberCapabilitiesResponse}"/>. </returns>
        public virtual async Task<Response<UpdatePhoneNumberCapabilitiesResponse>> GetCapabilitiesUpdateAsync(string capabilitiesUpdateId, CancellationToken cancellationToken = default)
        {
            return await ClientDiagnostics.RunScopedAsync(() =>
                RestClient.GetCapabilitiesUpdateAsync(capabilitiesUpdateId, cancellationToken),
                nameof(PhoneNumberAdministrationClient), nameof(GetCapabilitiesUpdate)).ConfigureAwait(false);
        }

        /// <summary> Get capabilities by capabilities update id. </summary>
        /// <param name="capabilitiesUpdateId"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A <see cref="Response{UpdatePhoneNumberCapabilitiesResponse}"/>. </returns>
        public virtual Response<UpdatePhoneNumberCapabilitiesResponse> GetCapabilitiesUpdate(string capabilitiesUpdateId, CancellationToken cancellationToken = default)
        {
            return ClientDiagnostics.RunScoped(() => RestClient.GetCapabilitiesUpdate(capabilitiesUpdateId, cancellationToken),
                nameof(PhoneNumberAdministrationClient), nameof(GetCapabilitiesUpdate));
        }

        /// <summary> Adds or removes phone number capabilities. </summary>
        /// <param name="phoneNumberUpdateCapabilities"> Dictionary of &lt;NumberUpdateCapabilities&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A <see cref="Response{UpdateNumberCapabilitiesResponse}"/>. </returns>
        public virtual async Task<Response<UpdateNumberCapabilitiesResponse>> UpdateCapabilitiesAsync(IDictionary<string, NumberUpdateCapabilities> phoneNumberUpdateCapabilities, CancellationToken cancellationToken = default)
        {
            return await ClientDiagnostics.RunScopedAsync(() =>
                RestClient.UpdateCapabilitiesAsync(phoneNumberUpdateCapabilities, cancellationToken),
                nameof(PhoneNumberAdministrationClient), nameof(UpdateCapabilities)).ConfigureAwait(false);
        }

        /// <summary> Adds or removes phone number capabilities. </summary>
        /// <param name="phoneNumberUpdateCapabilities"> Dictionary of &lt;NumberUpdateCapabilities&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A <see cref="Response{UpdateNumberCapabilitiesResponse}"/>. </returns>
        public virtual Response<UpdateNumberCapabilitiesResponse> UpdateCapabilities(IDictionary<string, NumberUpdateCapabilities> phoneNumberUpdateCapabilities, CancellationToken cancellationToken = default)
        {
            return ClientDiagnostics.RunScoped(() => RestClient.UpdateCapabilities(phoneNumberUpdateCapabilities, cancellationToken),
                nameof(PhoneNumberAdministrationClient), nameof(UpdateCapabilities));
        }

        /// <summary> Gets a list of supported countries. </summary>
        /// <param name="locale"> A language-locale pairing which will be used to localise the names of countries. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A <see cref="AsyncPageable{PhoneNumberCountry}"/>. </returns>
        public virtual AsyncPageable<PhoneNumberCountry> GetAllSupportedCountriesAsync(string? locale = null, CancellationToken cancellationToken = default)
        {
            return ClientDiagnostics.RunScoped(() =>
                PageResponseEnumerator.CreateAsyncEnumerable(async nextLink =>
                {
                    Response<PhoneNumberCountries> response = nextLink is null
                        ? await RestClient.GetAllSupportedCountriesAsync(locale, skip: null, take: null, cancellationToken).ConfigureAwait(false)
                        : await RestClient.GetAllSupportedCountriesNextPageAsync(nextLink, locale, skip: null, take: null, cancellationToken).ConfigureAwait(false);

                    return Page.FromValues(response.Value.Countries, response.Value.NextLink, response.GetRawResponse());
                }),
                nameof(PhoneNumberAdministrationClient), nameof(GetAllSupportedCountries));
        }

        /// <summary> Gets a list of supported countries. </summary>
        /// <param name="locale"> A language-locale pairing which will be used to localise the names of countries. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A <see cref="AsyncPageable{PhoneNumberCountry}"/>. </returns>
        public virtual Pageable<PhoneNumberCountry> GetAllSupportedCountries(string? locale = null, CancellationToken cancellationToken = default)
        {
            return ClientDiagnostics.RunScoped(() =>
                PageResponseEnumerator.CreateEnumerable(nextLink =>
                {
                    Response<PhoneNumberCountries> response = nextLink is null
                        ? RestClient.GetAllSupportedCountries(locale, skip: null, take: null, cancellationToken)
                        : RestClient.GetAllSupportedCountriesNextPage(nextLink, locale, skip: null, take: null, cancellationToken);

                    return Page.FromValues(response.Value.Countries, response.Value.NextLink, response.GetRawResponse());
                }),
                nameof(PhoneNumberAdministrationClient), nameof(GetAllSupportedCountries));
        }

        /// <summary> Endpoint for getting number configurations. </summary>
        /// <param name="phoneNumber"> The phone number in the E.164 format. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A <see cref="Response{NumberConfigurationResponse}"/>. </returns>
        public virtual async Task<Response<NumberConfigurationResponse>> GetNumberConfigurationAsync(PhoneNumber phoneNumber, CancellationToken cancellationToken = default)
        {
            return await ClientDiagnostics.RunScopedAsync(() =>
                RestClient.GetNumberConfigurationAsync(phoneNumber.Value, cancellationToken),
                nameof(PhoneNumberAdministrationClient), nameof(GetNumberConfiguration)).ConfigureAwait(false);
        }

        /// <summary> Endpoint for getting number configurations. </summary>
        /// <param name="phoneNumber"> The phone number in the E.164 format. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A <see cref="Response{NumberConfigurationResponse}"/>. </returns>
        public virtual Response<NumberConfigurationResponse> GetNumberConfiguration(PhoneNumber phoneNumber, CancellationToken cancellationToken = default)
        {
            return ClientDiagnostics.RunScoped(() => RestClient.GetNumberConfiguration(phoneNumber.Value, cancellationToken),
                nameof(PhoneNumberAdministrationClient), nameof(GetNumberConfiguration));
        }

        /// <summary> Endpoint for configuring a pstn number. </summary>
        /// <param name="pstnConfiguration"> Definition for pstn number configuration. </param>
        /// <param name="phoneNumber"> The phone number to configure. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A <see cref="Response"/>. </returns>
        public virtual async Task<Response> ConfigureNumberAsync(PstnConfiguration pstnConfiguration, PhoneNumber phoneNumber, CancellationToken cancellationToken = default)
        {
            return await ClientDiagnostics.RunScopedAsync(() =>
                RestClient.ConfigureNumberAsync(pstnConfiguration, phoneNumber.Value, cancellationToken),
                nameof(PhoneNumberAdministrationClient), nameof(ConfigureNumber)).ConfigureAwait(false);
        }

        /// <summary> Endpoint for configuring a pstn number. </summary>
        /// <param name="phoneNumber"> The phone number to configure. </param>
        /// <param name="pstnConfiguration"> Definition for pstn number configuration. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A <see cref="Response"/>. </returns>
        public virtual Response ConfigureNumber(PstnConfiguration pstnConfiguration, PhoneNumber phoneNumber, CancellationToken cancellationToken = default)
        {
            return ClientDiagnostics.RunScoped(() => RestClient.ConfigureNumber(pstnConfiguration, phoneNumber.Value, cancellationToken),
                nameof(PhoneNumberAdministrationClient), nameof(ConfigureNumber));
        }

        /// <summary> Endpoint for unconfiguring a pstn number by removing the configuration. </summary>
        /// <param name="phoneNumber"> The phone number in the E.164 format. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A <see cref="Response"/>. </returns>
        public virtual async Task<Response> UnconfigureNumberAsync(PhoneNumber phoneNumber, CancellationToken cancellationToken = default)
        {
            return await ClientDiagnostics.RunScopedAsync(() => RestClient.UnconfigureNumberAsync(phoneNumber.Value, cancellationToken),
                nameof(PhoneNumberAdministrationClient), nameof(UnconfigureNumber)).ConfigureAwait(false);
        }

        /// <summary> Endpoint for unconfiguring a pstn number by removing the configuration. </summary>
        /// <param name="phoneNumber"> The phone number in the E.164 format. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A <see cref="Response"/>. </returns>
        public virtual Response UnconfigureNumber(PhoneNumber phoneNumber, CancellationToken cancellationToken = default)
        {
            return ClientDiagnostics.RunScoped(() => RestClient.UnconfigureNumber(phoneNumber.Value, cancellationToken),
                nameof(PhoneNumberAdministrationClient), nameof(UnconfigureNumber));
        }

        /// <summary> Gets a list of phone plan groups for the given country. </summary>
        /// <param name="countryCode"> The ISO 3166-2 country code. </param>
        /// <param name="locale"> A language-locale pairing which will be used to localise the names of countries. </param>
        /// <param name="includeRateInformation"> The Boolean to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A <see cref="AsyncPageable{PhonePlanGroup}"/>. </returns>
        public virtual AsyncPageable<PhonePlanGroup> GetPhonePlanGroupsAsync(string countryCode, string? locale = null, bool? includeRateInformation = null, CancellationToken cancellationToken = default)
        {
            return ClientDiagnostics.RunScoped(() =>
                PageResponseEnumerator.CreateAsyncEnumerable(async nextLink =>
                {
                    Response<PhonePlanGroups> response = nextLink is null
                        ? await RestClient.GetPhonePlanGroupsAsync(countryCode, locale, includeRateInformation, skip: null, take: null, cancellationToken).ConfigureAwait(false)
                        : await RestClient.GetPhonePlanGroupsNextPageAsync(nextLink, countryCode, locale, includeRateInformation, skip: null, take: null, cancellationToken).ConfigureAwait(false);

                    return Page.FromValues(response.Value.PhonePlanGroupsValue, response.Value.NextLink, response.GetRawResponse());
                }),
                nameof(PhoneNumberAdministrationClient), nameof(GetPhonePlanGroups));
        }

        /// <summary> Gets a list of phone plan groups for the given country. </summary>
        /// <param name="countryCode"> The ISO 3166-2 country code. </param>
        /// <param name="locale"> A language-locale pairing which will be used to localise the names of countries. </param>
        /// <param name="includeRateInformation"> The Boolean to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A <see cref="Pageable{PhonePlanGroup}"/>. </returns>
        public virtual Pageable<PhonePlanGroup> GetPhonePlanGroups(string countryCode, string? locale = null, bool? includeRateInformation = null, CancellationToken cancellationToken = default)
        {
            return ClientDiagnostics.RunScoped(() =>
                PageResponseEnumerator.CreateEnumerable(nextLink =>
                {
                    Response<PhonePlanGroups> response = nextLink is null
                        ? RestClient.GetPhonePlanGroups(countryCode, locale, includeRateInformation, skip: null, take: null, cancellationToken)
                        : RestClient.GetPhonePlanGroupsNextPage(nextLink, countryCode, locale, includeRateInformation, skip: null, take: null, cancellationToken);

                    return Page.FromValues(response.Value.PhonePlanGroupsValue, response.Value.NextLink, response.GetRawResponse());
                }),
                nameof(PhoneNumberAdministrationClient), nameof(GetPhonePlanGroups));
        }

        /// <summary> Gets a list of phone plans for a phone plan group. </summary>
        /// <param name="countryCode"> The ISO 3166-2 country code. </param>
        /// <param name="phonePlanGroupId"> The String to use. </param>
        /// <param name="locale"> A language-locale pairing which will be used to localise the names of countries. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A <see cref="AsyncPageable{PhonePlan}"/>. </returns>
        public virtual AsyncPageable<PhonePlan> GetPhonePlansAsync(string countryCode, string phonePlanGroupId, string? locale = null, CancellationToken cancellationToken = default)
        {
            return ClientDiagnostics.RunScoped(() =>
                PageResponseEnumerator.CreateAsyncEnumerable(async nextLink =>
                {
                    Response<PhonePlansResponse> response = nextLink is null
                        ? await RestClient.GetPhonePlansAsync(countryCode, phonePlanGroupId, locale, skip: null, take: null, cancellationToken).ConfigureAwait(false)
                        : await RestClient.GetPhonePlansNextPageAsync(nextLink, countryCode, phonePlanGroupId, locale, skip: null, take: null, cancellationToken).ConfigureAwait(false);

                    return Page.FromValues(response.Value.PhonePlans, response.Value.NextLink, response.GetRawResponse());
                }),
                nameof(PhoneNumberAdministrationClient), nameof(GetPhonePlans));
        }

        /// <summary> Gets a list of phone plans for a phone plan group. </summary>
        /// <param name="countryCode"> The ISO 3166-2 country code. </param>
        /// <param name="phonePlanGroupId"> The String to use. </param>
        /// <param name="locale"> A language-locale pairing which will be used to localise the names of countries. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A <see cref="Pageable{PhonePlan}"/>. </returns>
        public virtual Pageable<PhonePlan> GetPhonePlans(string countryCode, string phonePlanGroupId, string? locale = null, CancellationToken cancellationToken = default)
        {
            return ClientDiagnostics.RunScoped(() =>
                PageResponseEnumerator.CreateEnumerable(nextLink =>
                {
                    Response<PhonePlansResponse> response = nextLink is null
                        ? RestClient.GetPhonePlans(countryCode, phonePlanGroupId, locale, skip: null, take: null, cancellationToken)
                        : RestClient.GetPhonePlansNextPage(nextLink, countryCode, phonePlanGroupId, locale, skip: null, take: null, cancellationToken);

                    return Page.FromValues(response.Value.PhonePlans, response.Value.NextLink, response.GetRawResponse());
                }),
                nameof(PhoneNumberAdministrationClient), nameof(GetPhonePlans));
        }

        /// <summary> Gets a list of location options for a phone plan. </summary>
        /// <param name="countryCode"> The ISO 3166-2 country code. </param>
        /// <param name="phonePlanGroupId"> The String to use. </param>
        /// <param name="phonePlanId"> The String to use. </param>
        /// <param name="locale"> A language-locale pairing which will be used to localise the names of countries. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A <see cref="Response{LocationOptionsResponse}"/>. </returns>
        public virtual async Task<Response<LocationOptionsResponse>> GetPhonePlanLocationOptionsAsync(string countryCode, string phonePlanGroupId, string phonePlanId, string? locale = null, CancellationToken cancellationToken = default)
        {
            return await ClientDiagnostics.RunScopedAsync(() =>
                RestClient.GetPhonePlanLocationOptionsAsync(countryCode, phonePlanGroupId, phonePlanId, locale, cancellationToken),
                nameof(PhoneNumberAdministrationClient), nameof(GetPhonePlanLocationOptions)).ConfigureAwait(false);
        }

        /// <summary> Gets a list of location options for a phone plan. </summary>
        /// <param name="countryCode"> The ISO 3166-2 country code. </param>
        /// <param name="phonePlanGroupId"> The String to use. </param>
        /// <param name="phonePlanId"> The String to use. </param>
        /// <param name="locale"> A language-locale pairing which will be used to localise the names of countries. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A <see cref="Response{LocationOptionsResponse}"/>. </returns>
        public virtual Response<LocationOptionsResponse> GetPhonePlanLocationOptions(string countryCode, string phonePlanGroupId, string phonePlanId, string? locale = null, CancellationToken cancellationToken = default)
        {
            return ClientDiagnostics.RunScoped(() =>
                RestClient.GetPhonePlanLocationOptions(countryCode, phonePlanGroupId, phonePlanId, locale, cancellationToken),
                nameof(PhoneNumberAdministrationClient), nameof(GetPhonePlanLocationOptions));
        }

        /// <summary> Gets a release by a release id. </summary>
        /// <param name="releaseId"> Represents the release id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A <see cref="Response{PhoneNumberRelease}"/>. </returns>
        public virtual async Task<Response<PhoneNumberRelease>> GetReleaseByIdAsync(string releaseId, CancellationToken cancellationToken = default)
        {
            return await ClientDiagnostics.RunScopedAsync(() => RestClient.GetReleaseByIdAsync(releaseId, cancellationToken),
                nameof(PhoneNumberAdministrationClient), nameof(GetReleaseById)).ConfigureAwait(false);
        }

        /// <summary> Gets a release by a release id. </summary>
        /// <param name="releaseId"> Represents the release id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A <see cref="Response{PhoneNumberRelease}"/>. </returns>
        public virtual Response<PhoneNumberRelease> GetReleaseById(string releaseId, CancellationToken cancellationToken = default)
        {
            return ClientDiagnostics.RunScoped(() => RestClient.GetReleaseById(releaseId, cancellationToken),
                nameof(PhoneNumberAdministrationClient), nameof(GetReleaseById));
        }

        /// <summary> Starts a release for the given phone numbers. </summary>
        /// <param name="phoneNumber"> The phone number in the release request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A <see cref="ReleasePhoneNumberOperation"/>. </returns>
        public virtual async Task<ReleasePhoneNumberOperation> StartReleasePhoneNumberAsync(PhoneNumber phoneNumber, CancellationToken cancellationToken = default)
        {
            return await ClientDiagnostics.RunScopedAsync(() => StartReleasePhoneNumbersAsync(new[] { phoneNumber }, cancellationToken),
                nameof(PhoneNumberAdministrationClient), nameof(StartReleasePhoneNumber)).ConfigureAwait(false);
        }

        /// <summary> Starts a release for the given phone numbers. </summary>
        /// <param name="phoneNumbers"> The list of phone numbers in the release request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A <see cref="ReleasePhoneNumberOperation"/>. </returns>
        public virtual async Task<ReleasePhoneNumberOperation> StartReleasePhoneNumbersAsync(IEnumerable<PhoneNumber> phoneNumbers, CancellationToken cancellationToken = default)
        {
            return await ClientDiagnostics.RunScopedAsync(async () =>
                {
                    var response = await RestClient.ReleasePhoneNumbersAsync(phoneNumbers.Select(phoneNumber => phoneNumber.Value), cancellationToken).ConfigureAwait(false);
                    return new ReleasePhoneNumberOperation(
                            this,
                            response.Value.ReleaseId,
                            response.GetRawResponse(),
                            cancellationToken);
                },
                nameof(PhoneNumberAdministrationClient), nameof(StartReleasePhoneNumbers)).ConfigureAwait(false);
        }

        /// <summary> Starts a release for the given phone number. </summary>
        /// <param name="phoneNumber"> The phone number in the release request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A <see cref="ReleasePhoneNumberOperation"/>. </returns>
        public virtual ReleasePhoneNumberOperation StartReleasePhoneNumber(PhoneNumber phoneNumber, CancellationToken cancellationToken = default)
        {
            return ClientDiagnostics.RunScoped(() => StartReleasePhoneNumbers(new[] { phoneNumber }, cancellationToken),
                nameof(PhoneNumberAdministrationClient), nameof(StartReleasePhoneNumber));
        }

        /// <summary> Starts a release for the given phone numbers. </summary>
        /// <param name="phoneNumbers"> The list of phone numbers in the release request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A <see cref="ReleasePhoneNumberOperation"/>. </returns>
        public virtual ReleasePhoneNumberOperation StartReleasePhoneNumbers(IEnumerable<PhoneNumber> phoneNumbers, CancellationToken cancellationToken = default)
        {
            return ClientDiagnostics.RunScoped(() =>
                {
                    var response = RestClient.ReleasePhoneNumbers(phoneNumbers.Select(phoneNumber => phoneNumber.Value), cancellationToken);
                    return new ReleasePhoneNumberOperation(
                           this,
                           response.Value.ReleaseId,
                           response.GetRawResponse(),
                           cancellationToken);
                },
                nameof(PhoneNumberAdministrationClient), nameof(StartReleasePhoneNumbers));
        }

        /// <summary> Gets a list of all releases. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A <see cref="AsyncPageable{PhoneNumberEntity}"/>. </returns>
        public virtual AsyncPageable<PhoneNumberEntity> GetAllReleasesAsync(CancellationToken cancellationToken = default)
        {
            return ClientDiagnostics.RunScoped(() =>
                PageResponseEnumerator.CreateAsyncEnumerable(async nextLink =>
                {
                    Response<PhoneNumberEntities> response = nextLink is null
                        ? await RestClient.GetAllReleasesAsync(skip: null, take: null, cancellationToken).ConfigureAwait(false)
                        : await RestClient.GetAllReleasesNextPageAsync(nextLink, skip: null, take: null, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Entities, response.Value.NextLink, response.GetRawResponse());
                }),
                nameof(PhoneNumberAdministrationClient), nameof(GetAllReleases));
        }

        /// <summary> Gets a list of all releases. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A <see cref="Pageable{PhoneNumberEntity}"/>. </returns>
        public virtual Pageable<PhoneNumberEntity> GetAllReleases(CancellationToken cancellationToken = default)
        {
            return ClientDiagnostics.RunScoped(() =>
                PageResponseEnumerator.CreateEnumerable(nextLink =>
                {
                    Response<PhoneNumberEntities> response = nextLink is null
                        ? RestClient.GetAllReleases(skip: null, take: null, cancellationToken)
                        : RestClient.GetAllReleasesNextPage(nextLink, skip: null, take: null, cancellationToken);

                    return Page.FromValues(response.Value.Entities, response.Value.NextLink, response.GetRawResponse());
                }),
                nameof(PhoneNumberAdministrationClient), nameof(GetAllReleases));
        }

        /// <summary> Get reservation by id. </summary>
        /// <param name="reservationId"> The reservation id to be searched for. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A <see cref="Response{PhoneNumberReservation}"/>. </returns>
        public virtual async Task<Response<PhoneNumberReservation>> GetReservationByIdAsync(string reservationId, CancellationToken cancellationToken = default)
        {
            return await ClientDiagnostics.RunScopedAsync(() => RestClient.GetSearchByIdAsync(reservationId, cancellationToken),
                nameof(PhoneNumberAdministrationClient), nameof(GetReservationById)).ConfigureAwait(false);
        }

        /// <summary> Get reservation by id. </summary>
        /// <param name="reservationId"> The reservation id to be searched for. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A <see cref="Response{PhoneNumberReservation}"/>. </returns>
        public virtual Response<PhoneNumberReservation> GetReservationById(string reservationId, CancellationToken cancellationToken = default)
        {
            return ClientDiagnostics.RunScoped(() => RestClient.GetSearchById(reservationId, cancellationToken),
                nameof(PhoneNumberAdministrationClient), nameof(GetReservationById));
        }

        /// <summary> Starts a phone number reservation. </summary>
        /// <param name="body"> Defines the reservation options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A <see cref="Response{PhoneNumberReservationOperation}"/>. </returns>
        public virtual async Task<PhoneNumberReservationOperation> StartReservationAsync(CreateReservationOptions body, CancellationToken cancellationToken = default)
        {
            return await ClientDiagnostics.RunScopedAsync(async () =>
                {
                    var response = await RestClient.CreateSearchAsync(body, cancellationToken).ConfigureAwait(false);
                    return new PhoneNumberReservationOperation(
                        this,
                        response.Value.ReservationId,
                        response.GetRawResponse(),
                        cancellationToken);
                },
                nameof(PhoneNumberAdministrationClient), nameof(StartReservation)).ConfigureAwait(false);
        }

        /// <summary> Starts a phone number reservation. </summary>
        /// <param name="body"> Defines the reservation options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A <see cref="PhoneNumberReservationOperation"/>. </returns>
        public virtual PhoneNumberReservationOperation StartReservation(CreateReservationOptions body, CancellationToken cancellationToken = default)
        {
            return ClientDiagnostics.RunScoped(() =>
                {
                    var response = RestClient.CreateSearch(body, cancellationToken);
                    return new PhoneNumberReservationOperation(
                        this,
                        response.Value.ReservationId,
                        response.GetRawResponse(),
                        cancellationToken);
                },
                nameof(PhoneNumberAdministrationClient), nameof(StartReservation));
        }

        /// <summary> Gets a list of all reservations. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A <see cref="AsyncPageable{PhoneNumberEntity}"/>. </returns>
        public virtual AsyncPageable<PhoneNumberEntity> GetAllReservationsAsync(CancellationToken cancellationToken = default)
        {
            return ClientDiagnostics.RunScoped(() =>
                 PageResponseEnumerator.CreateAsyncEnumerable(async nextLink =>
                 {
                     Response<PhoneNumberEntities> response = nextLink is null
                         ? await RestClient.GetAllSearchesAsync(skip: null, take: null, cancellationToken).ConfigureAwait(false)
                         : await RestClient.GetAllSearchesNextPageAsync(nextLink, skip: null, take: null, cancellationToken).ConfigureAwait(false);

                     return Page.FromValues(response.Value.Entities, response.Value.NextLink, response.GetRawResponse());
                 }),
                nameof(PhoneNumberAdministrationClient), nameof(GetAllReservations));
        }

        /// <summary> Gets a list of all reservations. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A <see cref="Pageable{PhoneNumberEntity}"/>. </returns>
        public virtual Pageable<PhoneNumberEntity> GetAllReservations(CancellationToken cancellationToken = default)
        {
            return ClientDiagnostics.RunScoped(() =>
                 PageResponseEnumerator.CreateEnumerable(nextLink =>
                 {
                     Response<PhoneNumberEntities> response = nextLink is null
                         ? RestClient.GetAllSearches(skip: null, take: null, cancellationToken)
                         : RestClient.GetAllSearchesNextPage(nextLink, skip: null, take: null, cancellationToken);

                     return Page.FromValues(response.Value.Entities, response.Value.NextLink, response.GetRawResponse());
                 }),
                nameof(PhoneNumberAdministrationClient), nameof(GetAllReservations));
        }

        /// <summary> Cancels the reservation. This means existing numbers in the reservation will be made available. </summary>
        /// <param name="reservationId"> The reservation id to be canceled. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A <see cref="Response"/>. </returns>
        public virtual async Task<Response> CancelReservationAsync(string reservationId, CancellationToken cancellationToken = default)
        {
            return await ClientDiagnostics.RunScopedAsync(() => RestClient.CancelSearchAsync(reservationId, cancellationToken),
                nameof(PhoneNumberAdministrationClient), nameof(CancelReservation)).ConfigureAwait(false);
        }

        /// <summary> Cancels the reservation. This means existing numbers in the reservation will be made available. </summary>
        /// <param name="reservationId"> The reservation id to be canceled. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A <see cref="Response"/>. </returns>
        public virtual Response CancelReservation(string reservationId, CancellationToken cancellationToken = default)
        {
            return ClientDiagnostics.RunScoped(() => RestClient.CancelSearch(reservationId, cancellationToken),
                nameof(PhoneNumberAdministrationClient), nameof(CancelReservation));
        }

        /// <summary> Starts purchase the phone number reservation. </summary>
        /// <param name="reservationId"> The reservation id to be purchased. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A <see cref="PhoneNumberReservationPurchaseOperation"/>. </returns>
        public virtual async Task<PhoneNumberReservationPurchaseOperation> StartPurchaseReservationAsync(string reservationId, CancellationToken cancellationToken = default)
        {
            return await ClientDiagnostics.RunScopedAsync(async () =>
                {
                    var response = await RestClient.PurchaseSearchAsync(reservationId, cancellationToken).ConfigureAwait(false);
                    return new PhoneNumberReservationPurchaseOperation(
                            this,
                            reservationId,
                            response,
                            cancellationToken);
                },
                nameof(PhoneNumberAdministrationClient), nameof(StartPurchaseReservation)).ConfigureAwait(false);
        }

        /// <summary> Starts purchase the phone number reservation. </summary>
        /// <param name="reservationId"> The reservation id to be purchased. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A <see cref="PhoneNumberReservationPurchaseOperation"/>. </returns>
        public virtual PhoneNumberReservationPurchaseOperation StartPurchaseReservation(string reservationId, CancellationToken cancellationToken = default)
        {
            return ClientDiagnostics.RunScoped(() =>
                {
                    var response = RestClient.PurchaseSearch(reservationId, cancellationToken);
                    return new PhoneNumberReservationPurchaseOperation(
                            this,
                            reservationId,
                            response,
                            cancellationToken);
                },
                nameof(PhoneNumberAdministrationClient), nameof(StartPurchaseReservation));
        }
    }
}
