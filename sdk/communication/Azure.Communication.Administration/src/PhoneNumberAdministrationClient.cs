// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly ClientDiagnostics _clientDiagnostics;
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
            _clientDiagnostics = clientDiagnostics;
        }

        /// <summary>Initializes a new instance of <see cref="PhoneNumberAdministrationClient"/> for mocking.</summary>
        protected PhoneNumberAdministrationClient()
        {
            _clientDiagnostics = null!;
            RestClient = null!;
        }

        /// <summary> Gets the list of the acquired phone numbers. </summary>
        /// <param name="locale"> A language-locale pairing which will be used to localise the names of countries. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<AcquiredPhoneNumber> GetAllPhoneNumbersAsync(string? locale = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumberAdministrationClient)}.{nameof(GetAllPhoneNumbers)}");
            scope.Start();

            try
            {
                return PageResponseEnumerator.CreateAsyncEnumerable(async s =>
                {
                    Response<AcquiredPhoneNumbers> response = await RestClient.GetAllPhoneNumbersAsync(locale, skip: null, take: null, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.PhoneNumbers, continuationToken: null!, response.GetRawResponse());
                });
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Gets the list of the acquired phone numbers. </summary>
        /// <param name="locale"> A language-locale pairing which will be used to localise the names of countries. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<AcquiredPhoneNumber> GetAllPhoneNumbers(string? locale = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumberAdministrationClient)}.{nameof(GetAllPhoneNumbers)}");
            scope.Start();

            try
            {
                Response<AcquiredPhoneNumbers> response = RestClient.GetAllPhoneNumbers(locale, skip: null, take: null, cancellationToken);
                return PageResponseEnumerator.CreateEnumerable(s => Page.FromValues(response.Value.PhoneNumbers, continuationToken: null!, response.GetRawResponse()));
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Gets a list of the supported area codes. </summary>
        /// <param name="locationType"> The type of location information required by the plan. </param>
        /// <param name="countryCode"> The ISO 3166-2 country code. </param>
        /// <param name="phonePlanId"> The plan id from which to search area codes. </param>
        /// <param name="locationOptions"> Represents the underlying list of countries. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<AreaCodes>> GetAllAreaCodesAsync(string locationType, string countryCode, string phonePlanId, IEnumerable<LocationOptionsQuery> locationOptions, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumberAdministrationClient)}.{nameof(GetAllAreaCodes)}");
            scope.Start();
            try
            {
                return await RestClient.GetAllAreaCodesAsync(locationType, countryCode, phonePlanId, locationOptions, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Gets a list of the supported area codes. </summary>
        /// <param name="locationType"> The type of location information required by the plan. </param>
        /// <param name="countryCode"> The ISO 3166-2 country code. </param>
        /// <param name="phonePlanId"> The plan id from which to search area codes. </param>
        /// <param name="locationOptions"> Represents the underlying list of countries. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<AreaCodes> GetAllAreaCodes(string locationType, string countryCode, string phonePlanId, IEnumerable<LocationOptionsQuery> locationOptions, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumberAdministrationClient)}.{nameof(GetAllAreaCodes)}");
            scope.Start();
            try
            {
                return RestClient.GetAllAreaCodes(locationType, countryCode, phonePlanId, locationOptions, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Get capabilities by capabilities update id. </summary>
        /// <param name="capabilitiesUpdateId"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<UpdatePhoneNumberCapabilitiesResponse>> GetCapabilitiesUpdateAsync(string capabilitiesUpdateId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumberAdministrationClient)}.{nameof(GetCapabilitiesUpdate)}");
            scope.Start();
            try
            {
                return await RestClient.GetCapabilitiesUpdateAsync(capabilitiesUpdateId, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Get capabilities by capabilities update id. </summary>
        /// <param name="capabilitiesUpdateId"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<UpdatePhoneNumberCapabilitiesResponse> GetCapabilitiesUpdate(string capabilitiesUpdateId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumberAdministrationClient)}.{nameof(GetCapabilitiesUpdate)}");
            scope.Start();
            try
            {
                return RestClient.GetCapabilitiesUpdate(capabilitiesUpdateId, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Adds or removes phone number capabilities. </summary>
        /// <param name="phoneNumberUpdateCapabilities"> Dictionary of &lt;NumberUpdateCapabilities&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<UpdateNumberCapabilitiesResponse>> UpdateCapabilitiesAsync(IDictionary<string, NumberUpdateCapabilities> phoneNumberUpdateCapabilities, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumberAdministrationClient)}.{nameof(UpdateCapabilities)}");
            scope.Start();
            try
            {
                return await RestClient.UpdateCapabilitiesAsync(phoneNumberUpdateCapabilities, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Adds or removes phone number capabilities. </summary>
        /// <param name="phoneNumberUpdateCapabilities"> Dictionary of &lt;NumberUpdateCapabilities&gt;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<UpdateNumberCapabilitiesResponse> UpdateCapabilities(IDictionary<string, NumberUpdateCapabilities> phoneNumberUpdateCapabilities, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(UpdateCapabilities)}.{nameof(UpdateCapabilities)}");
            scope.Start();
            try
            {
                return RestClient.UpdateCapabilities(phoneNumberUpdateCapabilities, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Gets a list of supported countries. </summary>
        /// <param name="locale"> A language-locale pairing which will be used to localise the names of countries. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<PhoneNumberCountry> GetAllSupportedCountriesAsync(string? locale = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumberAdministrationClient)}.{nameof(GetAllSupportedCountries)}");
            scope.Start();
            try
            {
                return PageResponseEnumerator.CreateAsyncEnumerable(async s =>
                {
                    Response<PhoneNumberCountries> response = await RestClient.GetAllSupportedCountriesAsync(locale, skip: null, take: null, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Countries, continuationToken: null!, response.GetRawResponse());
                });
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Gets a list of supported countries. </summary>
        /// <param name="locale"> A language-locale pairing which will be used to localise the names of countries. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<PhoneNumberCountry> GetAllSupportedCountries(string? locale = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumberAdministrationClient)}.{nameof(GetAllSupportedCountries)}");
            scope.Start();
            try
            {
                Response<PhoneNumberCountries> response = RestClient.GetAllSupportedCountries(locale, skip: null, take: null, cancellationToken);
                return PageResponseEnumerator.CreateEnumerable(s => Page.FromValues(response.Value.Countries, continuationToken: null!, response.GetRawResponse()));
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Endpoint for getting number configurations. </summary>
        /// <param name="phoneNumber"> The phone number in the E.164 format. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<NumberConfigurationResponse>> GetNumberConfigurationAsync(PhoneNumber phoneNumber, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumberAdministrationClient)}.{nameof(GetNumberConfiguration)}");
            scope.Start();
            try
            {
                return await RestClient.GetNumberConfigurationAsync(phoneNumber.Value, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Endpoint for getting number configurations. </summary>
        /// <param name="phoneNumber"> The phone number in the E.164 format. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<NumberConfigurationResponse> GetNumberConfiguration(PhoneNumber phoneNumber, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumberAdministrationClient)}.{nameof(GetNumberConfiguration)}");
            scope.Start();
            try
            {
                return RestClient.GetNumberConfiguration(phoneNumber.Value, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Endpoint for configuring a pstn number. </summary>
        /// <param name="pstnConfiguration"> Definition for pstn number configuration. </param>
        /// <param name="phoneNumber"> The phone number to configure. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> ConfigureNumberAsync(PstnConfiguration pstnConfiguration, PhoneNumber phoneNumber, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumberAdministrationClient)}.{nameof(ConfigureNumber)}");
            scope.Start();
            try
            {
                return await RestClient.ConfigureNumberAsync(pstnConfiguration, phoneNumber.Value, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Endpoint for configuring a pstn number. </summary>
        /// <param name="phoneNumber"> The phone number to configure. </param>
        /// <param name="pstnConfiguration"> Definition for pstn number configuration. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response ConfigureNumber(PstnConfiguration pstnConfiguration, PhoneNumber phoneNumber, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumberAdministrationClient)}.{nameof(ConfigureNumber)}");
            scope.Start();
            try
            {
                return RestClient.ConfigureNumber(pstnConfiguration, phoneNumber.Value, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Endpoint for unconfiguring a pstn number by removing the configuration. </summary>
        /// <param name="phoneNumber"> The phone number in the E.164 format. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> UnconfigureNumberAsync(PhoneNumber phoneNumber, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumberAdministrationClient)}.{nameof(UnconfigureNumber)}");
            scope.Start();
            try
            {
                return await RestClient.UnconfigureNumberAsync(phoneNumber.Value, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Endpoint for unconfiguring a pstn number by removing the configuration. </summary>
        /// <param name="phoneNumber"> The phone number in the E.164 format. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response UnconfigureNumber(PhoneNumber phoneNumber, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumberAdministrationClient)}.{nameof(UnconfigureNumber)}");
            scope.Start();
            try
            {
                return RestClient.UnconfigureNumber(phoneNumber.Value, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Gets a list of phone plan groups for the given country. </summary>
        /// <param name="countryCode"> The ISO 3166-2 country code. </param>
        /// <param name="locale"> A language-locale pairing which will be used to localise the names of countries. </param>
        /// <param name="includeRateInformation"> The Boolean to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<PhonePlanGroup> GetPhonePlanGroupsAsync(string countryCode, string? locale = null, bool? includeRateInformation = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumberAdministrationClient)}.{nameof(GetPhonePlanGroups)}");
            scope.Start();
            try
            {
                return PageResponseEnumerator.CreateAsyncEnumerable(async s =>
                {
                    Response<PhonePlanGroups> response = await RestClient.GetPhonePlanGroupsAsync(countryCode, locale, includeRateInformation, skip: null, take: null, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.PhonePlanGroupsValue, continuationToken: null!, response.GetRawResponse());
                });
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Gets a list of phone plan groups for the given country. </summary>
        /// <param name="countryCode"> The ISO 3166-2 country code. </param>
        /// <param name="locale"> A language-locale pairing which will be used to localise the names of countries. </param>
        /// <param name="includeRateInformation"> The Boolean to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<PhonePlanGroup> GetPhonePlanGroups(string countryCode, string? locale = null, bool? includeRateInformation = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumberAdministrationClient)}.{nameof(GetPhonePlanGroups)}");
            scope.Start();
            try
            {
                Response<PhonePlanGroups> response = RestClient.GetPhonePlanGroups(countryCode, locale, includeRateInformation, skip: null, take: null, cancellationToken);
                return PageResponseEnumerator.CreateEnumerable(s => Page.FromValues(response.Value.PhonePlanGroupsValue, continuationToken: null!, response.GetRawResponse()));
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Gets a list of phone plans for a phone plan group. </summary>
        /// <param name="countryCode"> The ISO 3166-2 country code. </param>
        /// <param name="phonePlanGroupId"> The String to use. </param>
        /// <param name="locale"> A language-locale pairing which will be used to localise the names of countries. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<PhonePlan> GetPhonePlansAsync(string countryCode, string phonePlanGroupId, string? locale = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumberAdministrationClient)}.{nameof(GetPhonePlans)}");
            scope.Start();
            try
            {
                return PageResponseEnumerator.CreateAsyncEnumerable(async s =>
                {
                    Response<PhonePlansResponse> response = await RestClient.GetPhonePlansAsync(countryCode, phonePlanGroupId, locale, skip: null, take: null, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.PhonePlans, continuationToken: null!, response.GetRawResponse());
                });
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Gets a list of phone plans for a phone plan group. </summary>
        /// <param name="countryCode"> The ISO 3166-2 country code. </param>
        /// <param name="phonePlanGroupId"> The String to use. </param>
        /// <param name="locale"> A language-locale pairing which will be used to localise the names of countries. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<PhonePlan> GetPhonePlans(string countryCode, string phonePlanGroupId, string? locale = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumberAdministrationClient)}.{nameof(GetPhonePlans)}");
            scope.Start();
            try
            {
                Response<PhonePlansResponse> response = RestClient.GetPhonePlans(countryCode, phonePlanGroupId, locale, skip: null, take: null, cancellationToken);
                return PageResponseEnumerator.CreateEnumerable(s => Page.FromValues(response.Value.PhonePlans, continuationToken: null!, response.GetRawResponse()));
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Gets a list of location options for a phone plan. </summary>
        /// <param name="countryCode"> The ISO 3166-2 country code. </param>
        /// <param name="phonePlanGroupId"> The String to use. </param>
        /// <param name="phonePlanId"> The String to use. </param>
        /// <param name="locale"> A language-locale pairing which will be used to localise the names of countries. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<LocationOptionsResponse>> GetPhonePlanLocationOptionsAsync(string countryCode, string phonePlanGroupId, string phonePlanId, string? locale = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumberAdministrationClient)}.{nameof(GetPhonePlanLocationOptions)}");
            scope.Start();
            try
            {
                return await RestClient.GetPhonePlanLocationOptionsAsync(countryCode, phonePlanGroupId, phonePlanId, locale, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Gets a list of location options for a phone plan. </summary>
        /// <param name="countryCode"> The ISO 3166-2 country code. </param>
        /// <param name="phonePlanGroupId"> The String to use. </param>
        /// <param name="phonePlanId"> The String to use. </param>
        /// <param name="locale"> A language-locale pairing which will be used to localise the names of countries. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<LocationOptionsResponse> GetPhonePlanLocationOptions(string countryCode, string phonePlanGroupId, string phonePlanId, string? locale = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumberAdministrationClient)}.{nameof(GetPhonePlanLocationOptions)}");
            scope.Start();
            try
            {
                return RestClient.GetPhonePlanLocationOptions(countryCode, phonePlanGroupId, phonePlanId, locale, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Gets a release by a release id. </summary>
        /// <param name="releaseId"> Represents the release id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<PhoneNumberRelease>> GetReleaseByIdAsync(string releaseId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumberAdministrationClient)}.{nameof(GetReleaseById)}");
            scope.Start();
            try
            {
                return await RestClient.GetReleaseByIdAsync(releaseId, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Gets a release by a release id. </summary>
        /// <param name="releaseId"> Represents the release id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<PhoneNumberRelease> GetReleaseById(string releaseId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumberAdministrationClient)}.{nameof(GetReleaseById)}");
            scope.Start();
            try
            {
                return RestClient.GetReleaseById(releaseId, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Creates a release for the given phone numbers. </summary>
        /// <param name="phoneNumbers"> The list of phone numbers in the release request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<ReleaseResponse>> ReleasePhoneNumbersAsync(IEnumerable<PhoneNumber> phoneNumbers, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumberAdministrationClient)}.{nameof(ReleasePhoneNumbers)}");
            scope.Start();
            try
            {
                return await RestClient.ReleasePhoneNumbersAsync(phoneNumbers.Select(phoneNumber => phoneNumber.Value), cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Creates a release for the given phone numbers. </summary>
        /// <param name="phoneNumbers"> The list of phone numbers in the release request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ReleaseResponse> ReleasePhoneNumbers(IEnumerable<PhoneNumber> phoneNumbers, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumberAdministrationClient)}.{nameof(ReleasePhoneNumbers)}");
            scope.Start();
            try
            {
                return RestClient.ReleasePhoneNumbers(phoneNumbers.Select(phoneNumber => phoneNumber.Value), cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Gets a list of all releases. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<PhoneNumberEntity> GetAllReleasesAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumberAdministrationClient)}.{nameof(GetAllReleases)}");
            scope.Start();
            try
            {
                return PageResponseEnumerator.CreateAsyncEnumerable(async s =>
                {
                    Response<PhoneNumberEntities> response = await RestClient.GetAllReleasesAsync(skip: null, take: null, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Entities, continuationToken: null!, response.GetRawResponse());
                });
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Gets a list of all releases. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<PhoneNumberEntity> GetAllReleases(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumberAdministrationClient)}.{nameof(GetAllReleases)}");
            scope.Start();
            try
            {
                Response<PhoneNumberEntities> response = RestClient.GetAllReleases(skip: null, take: null, cancellationToken);
                return PageResponseEnumerator.CreateEnumerable(s => Page.FromValues(response.Value.Entities, continuationToken: null!, response.GetRawResponse()));
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Get search by search id. </summary>
        /// <param name="searchId"> The search id to be searched for. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<PhoneNumberSearch>> GetSearchByIdAsync(string searchId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumberAdministrationClient)}.{nameof(GetSearchById)}");
            scope.Start();
            try
            {
                return await RestClient.GetSearchByIdAsync(searchId, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Get search by search id. </summary>
        /// <param name="searchId"> The search id to be searched for. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<PhoneNumberSearch> GetSearchById(string searchId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumberAdministrationClient)}.{nameof(GetSearchById)}");
            scope.Start();
            try
            {
                return RestClient.GetSearchById(searchId, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Creates a phone number search. </summary>
        /// <param name="body"> Defines the search options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<CreateSearchResponse>> CreateSearchAsync(CreateSearchOptions body, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumberAdministrationClient)}.{nameof(CreateSearch)}");
            scope.Start();
            try
            {
                return await RestClient.CreateSearchAsync(body, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Creates a phone number search. </summary>
        /// <param name="body"> Defines the search options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<CreateSearchResponse> CreateSearch(CreateSearchOptions body, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumberAdministrationClient)}.{nameof(CreateSearch)}");
            scope.Start();
            try
            {
                return RestClient.CreateSearch(body, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Gets a list of all searches. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<PhoneNumberEntity> GetAllSearchesAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumberAdministrationClient)}.{nameof(GetAllSearches)}");
            scope.Start();
            try
            {
                return PageResponseEnumerator.CreateAsyncEnumerable(async s =>
                {
                    Response<PhoneNumberEntities> response = await RestClient.GetAllSearchesAsync(skip: null, take: null, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Entities, continuationToken: null!, response.GetRawResponse());
                });
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Gets a list of all searches. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<PhoneNumberEntity> GetAllSearches(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumberAdministrationClient)}.{nameof(GetAllSearches)}");
            scope.Start();
            try
            {
                Response<PhoneNumberEntities> response = RestClient.GetAllSearches(skip: null, take: null, cancellationToken);
                return PageResponseEnumerator.CreateEnumerable(s => Page.FromValues(response.Value.Entities, continuationToken: null!, response.GetRawResponse()));
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Cancels the search. This means existing numbers in the search will be made available. </summary>
        /// <param name="searchId"> The search id to be canceled. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> CancelSearchAsync(string searchId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumberAdministrationClient)}.{nameof(CancelSearch)}");
            scope.Start();
            try
            {
                return await RestClient.CancelSearchAsync(searchId, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Cancels the search. This means existing numbers in the search will be made available. </summary>
        /// <param name="searchId"> The search id to be canceled. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response CancelSearch(string searchId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumberAdministrationClient)}.{nameof(CancelSearch)}");
            scope.Start();
            try
            {
                return RestClient.CancelSearch(searchId, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Purchases the phone number search. </summary>
        /// <param name="searchId"> The search id to be purchased. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PurchaseSearchAsync(string searchId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumberAdministrationClient)}.{nameof(PurchaseSearch)}");
            scope.Start();
            try
            {
                return await RestClient.PurchaseSearchAsync(searchId, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Purchases the phone number search. </summary>
        /// <param name="searchId"> The search id to be purchased. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PurchaseSearch(string searchId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _clientDiagnostics.CreateScope($"{nameof(PhoneNumberAdministrationClient)}.{nameof(PurchaseSearch)}");
            scope.Start();
            try
            {
                return RestClient.PurchaseSearch(searchId, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }
    }
}
