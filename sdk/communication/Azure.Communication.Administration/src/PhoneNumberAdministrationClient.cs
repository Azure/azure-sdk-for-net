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
            : this(new ClientDiagnostics(options), options.BuildHttpPipeline(connectionString), connectionString.GetRequired("endpoint"))
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
            return PageResponseEnumerator.CreateAsyncEnumerable(async nextLink =>
            {
                using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(PhoneNumberAdministrationClient)}.{nameof(GetAllPhoneNumbers)}");
                scope.Start();
                try
                {
                    Response<AcquiredPhoneNumbers> response = nextLink is null
                        ? await RestClient.GetAllPhoneNumbersAsync(locale, skip: null, take: null, cancellationToken).ConfigureAwait(false)
                        : await RestClient.GetAllPhoneNumbersNextPageAsync(nextLink, locale, skip: null, take: null, cancellationToken).ConfigureAwait(false);

                    return Page.FromValues(response.Value.PhoneNumbers, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            });
        }

        /// <summary> Gets the list of the acquired phone numbers. </summary>
        /// <param name="locale"> A language-locale pairing which will be used to localise the names of countries. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A <see cref="Pageable{AcquiredPhoneNumber}"/>. </returns>
        public virtual Pageable<AcquiredPhoneNumber> GetAllPhoneNumbers(string? locale = null, CancellationToken cancellationToken = default)
        {
            return PageResponseEnumerator.CreateEnumerable(nextLink =>
            {
                using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(PhoneNumberAdministrationClient)}.{nameof(GetAllPhoneNumbers)}");
                scope.Start();
                try
                {
                    Response<AcquiredPhoneNumbers> response = nextLink is null
                        ? RestClient.GetAllPhoneNumbers(locale, skip: null, take: null, cancellationToken)
                        : RestClient.GetAllPhoneNumbersNextPage(nextLink, locale, skip: null, take: null, cancellationToken);

                    return Page.FromValues(response.Value.PhoneNumbers, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            });
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
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(PhoneNumberAdministrationClient)}.{nameof(GetAllAreaCodes)}");
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
        /// <returns> A <see cref="Response{AreaCodes}"/>. </returns>
        public virtual Response<AreaCodes> GetAllAreaCodes(string locationType, string countryCode, string phonePlanId, IEnumerable<LocationOptionsQuery> locationOptions, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(PhoneNumberAdministrationClient)}.{nameof(GetAllAreaCodes)}");
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
        /// <returns> A <see cref="Response{UpdatePhoneNumberCapabilitiesResponse}"/>. </returns>
        public virtual async Task<Response<UpdatePhoneNumberCapabilitiesResponse>> GetCapabilitiesUpdateAsync(string capabilitiesUpdateId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(PhoneNumberAdministrationClient)}.{nameof(GetCapabilitiesUpdate)}");
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
        /// <returns> A <see cref="Response{UpdatePhoneNumberCapabilitiesResponse}"/>. </returns>
        public virtual Response<UpdatePhoneNumberCapabilitiesResponse> GetCapabilitiesUpdate(string capabilitiesUpdateId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(PhoneNumberAdministrationClient)}.{nameof(GetCapabilitiesUpdate)}");
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
        /// <returns> A <see cref="Response{UpdateNumberCapabilitiesResponse}"/>. </returns>
        public virtual async Task<Response<UpdateNumberCapabilitiesResponse>> UpdateCapabilitiesAsync(IDictionary<string, NumberUpdateCapabilities> phoneNumberUpdateCapabilities, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(PhoneNumberAdministrationClient)}.{nameof(UpdateCapabilities)}");
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
        /// <returns> A <see cref="Response{UpdateNumberCapabilitiesResponse}"/>. </returns>
        public virtual Response<UpdateNumberCapabilitiesResponse> UpdateCapabilities(IDictionary<string, NumberUpdateCapabilities> phoneNumberUpdateCapabilities, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(UpdateCapabilities)}.{nameof(UpdateCapabilities)}");
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
        /// <returns> A <see cref="AsyncPageable{PhoneNumberCountry}"/>. </returns>
        public virtual AsyncPageable<PhoneNumberCountry> GetAllSupportedCountriesAsync(string? locale = null, CancellationToken cancellationToken = default)
        {
            return PageResponseEnumerator.CreateAsyncEnumerable(async nextLink =>
            {
                using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(PhoneNumberAdministrationClient)}.{nameof(GetAllSupportedCountries)}");
                scope.Start();
                try
                {
                    Response<PhoneNumberCountries> response = nextLink is null
                        ? await RestClient.GetAllSupportedCountriesAsync(locale, skip: null, take: null, cancellationToken).ConfigureAwait(false)
                        : await RestClient.GetAllSupportedCountriesNextPageAsync(nextLink, locale, skip: null, take: null, cancellationToken).ConfigureAwait(false);

                    return Page.FromValues(response.Value.Countries, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            });
        }

        /// <summary> Gets a list of supported countries. </summary>
        /// <param name="locale"> A language-locale pairing which will be used to localise the names of countries. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A <see cref="AsyncPageable{PhoneNumberCountry}"/>. </returns>
        public virtual Pageable<PhoneNumberCountry> GetAllSupportedCountries(string? locale = null, CancellationToken cancellationToken = default)
        {
            return PageResponseEnumerator.CreateEnumerable(nextLink =>
            {
                using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(PhoneNumberAdministrationClient)}.{nameof(GetAllSupportedCountries)}");
                scope.Start();
                try
                {
                    Response<PhoneNumberCountries> response = nextLink is null
                        ? RestClient.GetAllSupportedCountries(locale, skip: null, take: null, cancellationToken)
                        : RestClient.GetAllSupportedCountriesNextPage(nextLink, locale, skip: null, take: null, cancellationToken);

                    return Page.FromValues(response.Value.Countries, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            });
        }

        /// <summary> Endpoint for getting number configurations. </summary>
        /// <param name="phoneNumber"> The phone number in the E.164 format. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A <see cref="Response{NumberConfigurationResponse}"/>. </returns>
        public virtual async Task<Response<NumberConfigurationResponse>> GetNumberConfigurationAsync(PhoneNumberIdentifier phoneNumber, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(PhoneNumberAdministrationClient)}.{nameof(GetNumberConfiguration)}");
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
        /// <returns> A <see cref="Response{NumberConfigurationResponse}"/>. </returns>
        public virtual Response<NumberConfigurationResponse> GetNumberConfiguration(PhoneNumberIdentifier phoneNumber, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(PhoneNumberAdministrationClient)}.{nameof(GetNumberConfiguration)}");
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
        /// <returns> A <see cref="Response"/>. </returns>
        public virtual async Task<Response> ConfigureNumberAsync(PstnConfiguration pstnConfiguration, PhoneNumberIdentifier phoneNumber, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(PhoneNumberAdministrationClient)}.{nameof(ConfigureNumber)}");
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
        /// <returns> A <see cref="Response"/>. </returns>
        public virtual Response ConfigureNumber(PstnConfiguration pstnConfiguration, PhoneNumberIdentifier phoneNumber, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(PhoneNumberAdministrationClient)}.{nameof(ConfigureNumber)}");
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
        /// <returns> A <see cref="Response"/>. </returns>
        public virtual async Task<Response> UnconfigureNumberAsync(PhoneNumberIdentifier phoneNumber, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(PhoneNumberAdministrationClient)}.{nameof(UnconfigureNumber)}");
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
        /// <returns> A <see cref="Response"/>. </returns>
        public virtual Response UnconfigureNumber(PhoneNumberIdentifier phoneNumber, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(PhoneNumberAdministrationClient)}.{nameof(UnconfigureNumber)}");
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
        /// <returns> A <see cref="AsyncPageable{PhonePlanGroup}"/>. </returns>
        public virtual AsyncPageable<PhonePlanGroup> GetPhonePlanGroupsAsync(string countryCode, string? locale = null, bool? includeRateInformation = null, CancellationToken cancellationToken = default)
        {
            return PageResponseEnumerator.CreateAsyncEnumerable(async nextLink =>
            {
                using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(PhoneNumberAdministrationClient)}.{nameof(GetPhonePlanGroups)}");
                scope.Start();
                try
                {
                    Response<PhonePlanGroups> response = nextLink is null
                        ? await RestClient.GetPhonePlanGroupsAsync(countryCode, locale, includeRateInformation, skip: null, take: null, cancellationToken).ConfigureAwait(false)
                        : await RestClient.GetPhonePlanGroupsNextPageAsync(nextLink, countryCode, locale, includeRateInformation, skip: null, take: null, cancellationToken).ConfigureAwait(false);

                    return Page.FromValues(response.Value.PhonePlanGroupsValue, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            });
        }

        /// <summary> Gets a list of phone plan groups for the given country. </summary>
        /// <param name="countryCode"> The ISO 3166-2 country code. </param>
        /// <param name="locale"> A language-locale pairing which will be used to localise the names of countries. </param>
        /// <param name="includeRateInformation"> The Boolean to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A <see cref="Pageable{PhonePlanGroup}"/>. </returns>
        public virtual Pageable<PhonePlanGroup> GetPhonePlanGroups(string countryCode, string? locale = null, bool? includeRateInformation = null, CancellationToken cancellationToken = default)
        {
            return PageResponseEnumerator.CreateEnumerable(nextLink =>
            {
                using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(PhoneNumberAdministrationClient)}.{nameof(GetPhonePlanGroups)}");
                scope.Start();
                try
                {
                    Response<PhonePlanGroups> response = nextLink is null
                        ? RestClient.GetPhonePlanGroups(countryCode, locale, includeRateInformation, skip: null, take: null, cancellationToken)
                        : RestClient.GetPhonePlanGroupsNextPage(nextLink, countryCode, locale, includeRateInformation, skip: null, take: null, cancellationToken);

                    return Page.FromValues(response.Value.PhonePlanGroupsValue, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            });
        }

        /// <summary> Gets a list of phone plans for a phone plan group. </summary>
        /// <param name="countryCode"> The ISO 3166-2 country code. </param>
        /// <param name="phonePlanGroupId"> The String to use. </param>
        /// <param name="locale"> A language-locale pairing which will be used to localise the names of countries. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A <see cref="AsyncPageable{PhonePlan}"/>. </returns>
        public virtual AsyncPageable<PhonePlan> GetPhonePlansAsync(string countryCode, string phonePlanGroupId, string? locale = null, CancellationToken cancellationToken = default)
        {
            return PageResponseEnumerator.CreateAsyncEnumerable(async nextLink =>
            {
                using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(PhoneNumberAdministrationClient)}.{nameof(GetPhonePlans)}");
                scope.Start();
                try
                {
                    Response<PhonePlansResponse> response = nextLink is null
                        ? await RestClient.GetPhonePlansAsync(countryCode, phonePlanGroupId, locale, skip: null, take: null, cancellationToken).ConfigureAwait(false)
                        : await RestClient.GetPhonePlansNextPageAsync(nextLink, countryCode, phonePlanGroupId, locale, skip: null, take: null, cancellationToken).ConfigureAwait(false);

                    return Page.FromValues(response.Value.PhonePlans, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            });
        }

        /// <summary> Gets a list of phone plans for a phone plan group. </summary>
        /// <param name="countryCode"> The ISO 3166-2 country code. </param>
        /// <param name="phonePlanGroupId"> The String to use. </param>
        /// <param name="locale"> A language-locale pairing which will be used to localise the names of countries. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A <see cref="Pageable{PhonePlan}"/>. </returns>
        public virtual Pageable<PhonePlan> GetPhonePlans(string countryCode, string phonePlanGroupId, string? locale = null, CancellationToken cancellationToken = default)
        {
            return PageResponseEnumerator.CreateEnumerable(nextLink =>
            {
                using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(PhoneNumberAdministrationClient)}.{nameof(GetPhonePlans)}");
                scope.Start();
                try
                {
                    Response<PhonePlansResponse> response = nextLink is null
                            ? RestClient.GetPhonePlans(countryCode, phonePlanGroupId, locale, skip: null, take: null, cancellationToken)
                            : RestClient.GetPhonePlansNextPage(nextLink, countryCode, phonePlanGroupId, locale, skip: null, take: null, cancellationToken);

                    return Page.FromValues(response.Value.PhonePlans, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            });
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
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(PhoneNumberAdministrationClient)}.{nameof(GetPhonePlanLocationOptions)}");
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
        /// <returns> A <see cref="Response{LocationOptionsResponse}"/>. </returns>
        public virtual Response<LocationOptionsResponse> GetPhonePlanLocationOptions(string countryCode, string phonePlanGroupId, string phonePlanId, string? locale = null, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(PhoneNumberAdministrationClient)}.{nameof(GetPhonePlanLocationOptions)}");
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
        /// <returns> A <see cref="Response{PhoneNumberRelease}"/>. </returns>
        public virtual async Task<Response<PhoneNumberRelease>> GetReleaseByIdAsync(string releaseId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(PhoneNumberAdministrationClient)}.{nameof(GetReleaseById)}");
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
        /// <returns> A <see cref="Response{PhoneNumberRelease}"/>. </returns>
        public virtual Response<PhoneNumberRelease> GetReleaseById(string releaseId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(PhoneNumberAdministrationClient)}.{nameof(GetReleaseById)}");
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

        /// <summary> Starts a release for the given phone numbers. </summary>
        /// <param name="phoneNumber"> The phone number in the release request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A <see cref="ReleasePhoneNumberOperation"/>. </returns>
        public virtual async Task<ReleasePhoneNumberOperation> StartReleasePhoneNumberAsync(PhoneNumberIdentifier phoneNumber, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(PhoneNumberAdministrationClient)}.{nameof(StartReleasePhoneNumber)}");
            scope.Start();
            try
            {
                return await StartReleasePhoneNumbersAsync(new[] { phoneNumber }, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Starts a release for the given phone numbers. </summary>
        /// <param name="phoneNumbers"> The list of phone numbers in the release request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A <see cref="ReleasePhoneNumberOperation"/>. </returns>
        public virtual async Task<ReleasePhoneNumberOperation> StartReleasePhoneNumbersAsync(IEnumerable<PhoneNumberIdentifier> phoneNumbers, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(PhoneNumberAdministrationClient)}.{nameof(StartReleasePhoneNumbers)}");
            scope.Start();
            try
            {
                var response = await RestClient.ReleasePhoneNumbersAsync(phoneNumbers.Select(phoneNumber => phoneNumber.Value), cancellationToken).ConfigureAwait(false);
                return new ReleasePhoneNumberOperation(
                       this,
                       response.Value.ReleaseId,
                       response.GetRawResponse(),
                       cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Starts a release for the given phone number. </summary>
        /// <param name="phoneNumber"> The phone number in the release request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A <see cref="ReleasePhoneNumberOperation"/>. </returns>
        public virtual ReleasePhoneNumberOperation StartReleasePhoneNumber(PhoneNumberIdentifier phoneNumber, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(PhoneNumberAdministrationClient)}.{nameof(StartReleasePhoneNumber)}");
            scope.Start();
            try
            {
                return StartReleasePhoneNumbers(new[] { phoneNumber }, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Starts a release for the given phone numbers. </summary>
        /// <param name="phoneNumbers"> The list of phone numbers in the release request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A <see cref="ReleasePhoneNumberOperation"/>. </returns>
        public virtual ReleasePhoneNumberOperation StartReleasePhoneNumbers(IEnumerable<PhoneNumberIdentifier> phoneNumbers, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(PhoneNumberAdministrationClient)}.{nameof(StartReleasePhoneNumbers)}");
            scope.Start();
            try
            {
                var response = RestClient.ReleasePhoneNumbers(phoneNumbers.Select(phoneNumber => phoneNumber.Value), cancellationToken);
                return new ReleasePhoneNumberOperation(
                       this,
                       response.Value.ReleaseId,
                       response.GetRawResponse(),
                       cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Gets a list of all releases. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A <see cref="AsyncPageable{PhoneNumberEntity}"/>. </returns>
        public virtual AsyncPageable<PhoneNumberEntity> GetAllReleasesAsync(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(PhoneNumberAdministrationClient)}.{nameof(GetAllReleases)}");
            scope.Start();
            try
            {
                return PageResponseEnumerator.CreateAsyncEnumerable(async nextLink =>
                {
                    Response<PhoneNumberEntities> response = nextLink is null
                        ? await RestClient.GetAllReleasesAsync(skip: null, take: null, cancellationToken).ConfigureAwait(false)
                        : await RestClient.GetAllReleasesNextPageAsync(nextLink, skip: null, take: null, cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Entities, response.Value.NextLink, response.GetRawResponse());
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
        /// <returns> A <see cref="Pageable{PhoneNumberEntity}"/>. </returns>
        public virtual Pageable<PhoneNumberEntity> GetAllReleases(CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(PhoneNumberAdministrationClient)}.{nameof(GetAllReleases)}");
            scope.Start();
            try
            {
                return PageResponseEnumerator.CreateEnumerable(nextLink =>
                {
                    Response<PhoneNumberEntities> response = nextLink is null
                        ? RestClient.GetAllReleases(skip: null, take: null, cancellationToken)
                        : RestClient.GetAllReleasesNextPage(nextLink, skip: null, take: null, cancellationToken);

                    return Page.FromValues(response.Value.Entities, response.Value.NextLink, response.GetRawResponse());
                });
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Get reservation by id. </summary>
        /// <param name="reservationId"> The reservation id to be searched for. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A <see cref="Response{PhoneNumberReservation}"/>. </returns>
        public virtual async Task<Response<PhoneNumberReservation>> GetReservationByIdAsync(string reservationId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(PhoneNumberAdministrationClient)}.{nameof(GetReservationById)}");
            scope.Start();
            try
            {
                return await RestClient.GetSearchByIdAsync(reservationId, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Get reservation by id. </summary>
        /// <param name="reservationId"> The reservation id to be searched for. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A <see cref="Response{PhoneNumberReservation}"/>. </returns>
        public virtual Response<PhoneNumberReservation> GetReservationById(string reservationId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(PhoneNumberAdministrationClient)}.{nameof(GetReservationById)}");
            scope.Start();
            try
            {
                return RestClient.GetSearchById(reservationId, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Starts a phone number reservation. </summary>
        /// <param name="body"> Defines the reservation options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A <see cref="Response{PhoneNumberReservationOperation}"/>. </returns>
        public virtual async Task<PhoneNumberReservationOperation> StartReservationAsync(CreateReservationOptions body, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(PhoneNumberAdministrationClient)}.{nameof(StartReservation)}");
            scope.Start();
            try
            {
                var response = await RestClient.CreateSearchAsync(body, cancellationToken).ConfigureAwait(false);
                return new PhoneNumberReservationOperation(
                    this,
                    response.Value.ReservationId,
                    response.GetRawResponse(),
                    cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Starts a phone number reservation. </summary>
        /// <param name="body"> Defines the reservation options. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A <see cref="PhoneNumberReservationOperation"/>. </returns>
        public virtual PhoneNumberReservationOperation StartReservation(CreateReservationOptions body, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(PhoneNumberAdministrationClient)}.{nameof(StartReservation)}");
            scope.Start();
            try
            {
                var response = RestClient.CreateSearch(body, cancellationToken);
                return new PhoneNumberReservationOperation(
                    this,
                    response.Value.ReservationId,
                    response.GetRawResponse(),
                    cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Gets a list of all reservations. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A <see cref="AsyncPageable{PhoneNumberEntity}"/>. </returns>
        public virtual AsyncPageable<PhoneNumberEntity> GetAllReservationsAsync(CancellationToken cancellationToken = default)
        {
            return PageResponseEnumerator.CreateAsyncEnumerable(async nextLink =>
            {
                using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(PhoneNumberAdministrationClient)}.{nameof(GetAllReservations)}");
                scope.Start();
                try
                {
                    Response<PhoneNumberEntities> response = nextLink is null
                        ? await RestClient.GetAllSearchesAsync(skip: null, take: null, cancellationToken).ConfigureAwait(false)
                        : await RestClient.GetAllSearchesNextPageAsync(nextLink, skip: null, take: null, cancellationToken).ConfigureAwait(false);

                    return Page.FromValues(response.Value.Entities, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            });
        }

        /// <summary> Gets a list of all reservations. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A <see cref="Pageable{PhoneNumberEntity}"/>. </returns>
        public virtual Pageable<PhoneNumberEntity> GetAllReservations(CancellationToken cancellationToken = default)
        {
            return PageResponseEnumerator.CreateEnumerable(nextLink =>
            {
                using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(PhoneNumberAdministrationClient)}.{nameof(GetAllReservations)}");
                scope.Start();
                try
                {
                    Response<PhoneNumberEntities> response = nextLink is null
                        ? RestClient.GetAllSearches(skip: null, take: null, cancellationToken)
                        : RestClient.GetAllSearchesNextPage(nextLink, skip: null, take: null, cancellationToken);

                    return Page.FromValues(response.Value.Entities, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception ex)
                {
                    scope.Failed(ex);
                    throw;
                }
            });
        }

        /// <summary> Cancels the reservation. This means existing numbers in the reservation will be made available. </summary>
        /// <param name="reservationId"> The reservation id to be canceled. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A <see cref="Response"/>. </returns>
        public virtual async Task<Response> CancelReservationAsync(string reservationId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(PhoneNumberAdministrationClient)}.{nameof(CancelReservation)}");
            scope.Start();
            try
            {
                return await RestClient.CancelSearchAsync(reservationId, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Cancels the reservation. This means existing numbers in the reservation will be made available. </summary>
        /// <param name="reservationId"> The reservation id to be canceled. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A <see cref="Response"/>. </returns>
        public virtual Response CancelReservation(string reservationId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(PhoneNumberAdministrationClient)}.{nameof(CancelReservation)}");
            scope.Start();
            try
            {
                return RestClient.CancelSearch(reservationId, cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Starts purchase the phone number reservation. </summary>
        /// <param name="reservationId"> The reservation id to be purchased. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A <see cref="PhoneNumberReservationPurchaseOperation"/>. </returns>
        public virtual async Task<PhoneNumberReservationPurchaseOperation> StartPurchaseReservationAsync(string reservationId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(PhoneNumberAdministrationClient)}.{nameof(StartPurchaseReservation)}");
            scope.Start();
            try
            {
                var response = await RestClient.PurchaseSearchAsync(reservationId, cancellationToken).ConfigureAwait(false);
                return new PhoneNumberReservationPurchaseOperation(
                        this,
                        reservationId,
                        response,
                        cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }

        /// <summary> Starts purchase the phone number reservation. </summary>
        /// <param name="reservationId"> The reservation id to be purchased. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A <see cref="PhoneNumberReservationPurchaseOperation"/>. </returns>
        public virtual PhoneNumberReservationPurchaseOperation StartPurchaseReservation(string reservationId, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = ClientDiagnostics.CreateScope($"{nameof(PhoneNumberAdministrationClient)}.{nameof(StartPurchaseReservation)}");
            scope.Start();
            try
            {
                var response = RestClient.PurchaseSearch(reservationId, cancellationToken);
                return new PhoneNumberReservationPurchaseOperation(
                        this,
                        reservationId,
                        response,
                        cancellationToken);
            }
            catch (Exception ex)
            {
                scope.Failed(ex);
                throw;
            }
        }
    }
}
