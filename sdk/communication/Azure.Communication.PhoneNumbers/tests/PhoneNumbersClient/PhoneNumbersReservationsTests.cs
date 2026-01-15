// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Communication.Tests;
using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;
using NUnit.Framework;

namespace Azure.Communication.PhoneNumbers.Tests
{
    /// <summary>
    /// The suite of tests for the PhoneNumbersReservation functionality from the <see cref="PhoneNumbersClient"/> class.
    /// </summary>
    /// <remarks>
    /// These tests have a dependency on live Azure services and may incur costs for the associated
    /// Azure subscription.
    /// </remarks>
    public class PhoneNumbersReservationsTests : PhoneNumbersClientLiveTestBase
    {
        private PhoneNumbersReservation? _initialReservationState;
        private readonly Guid _staticReservationId = Guid.Parse("6227aeb8-8086-4824-9586-05c04e96f37b");
        private Guid _reservationId;

        /// <summary>
        /// Initializes a new instance of <see cref="PhoneNumbersReservationsTests" />.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public PhoneNumbersReservationsTests(bool isAsync) : base(isAsync)
        {
        }

        /// <summary>
        /// Initializes the GUID that will be used for reservations created during this test run.
        /// It also ensures that it is properly sanitized for playback mode.
        /// </summary>
        [OneTimeSetUp]
        public void Setup()
        {
            _reservationId = Guid.NewGuid();

            // Replace any GUIDs in the request/response bodies with a static GUID for playback mode.
            // This will only be applied to the recordings of this test class.
            // NOTE: We are adding the new sanitizers at the start so that they are applied before the PhoneNumbers sanitization, which can malform the GUIDs.
            string guidPattern = @"[a-fA-F0-9]{8}-[a-fA-F0-9]{4}-[a-fA-F0-9]{4}-[a-fA-F0-9]{4}-[a-fA-F0-9]{12}";
            BodyRegexSanitizers.Insert(0, new BodyRegexSanitizer(guidPattern) { Value = _staticReservationId.ToString() });
            UriRegexSanitizers.Insert(0, new UriRegexSanitizer(guidPattern) { Value = _staticReservationId.ToString() });
            HeaderRegexSanitizers.Insert(0, new HeaderRegexSanitizer("Location") { Regex = guidPattern, Value = _staticReservationId.ToString() });
            HeaderRegexSanitizers.Insert(0, new HeaderRegexSanitizer("Operation-Location") { Regex = guidPattern, Value = _staticReservationId.ToString() });
            HeaderRegexSanitizers.Insert(0, new HeaderRegexSanitizer("operation-id") { Regex = guidPattern, Value = _staticReservationId.ToString() });
            HeaderRegexSanitizers.Insert(0, new HeaderRegexSanitizer("reservation-purchase-id") { Regex = guidPattern, Value = _staticReservationId.ToString() });
        }

        [TestCase]
        [AsyncOnly]
        [Order(0)] // This is run first to ensure that at least one active reservation exists before running the tests.
        public async Task CreateReservationAsync()
        {
            PhoneNumbersClient client = CreateClient();
            var reservationId = GetReservationId();
            var request = new CreateOrUpdateReservationOptions(reservationId);

            var reservationResponse = await client.CreateOrUpdateReservationAsync(request).ConfigureAwait(false);

            // The response should be a 201 Created.
            Assert.That(reservationResponse.GetRawResponse().Status, Is.EqualTo(201));
            Assert.IsNotNull(reservationResponse.Value);
            Assert.That(reservationResponse.Value.Id, Is.EqualTo(reservationId));
            Assert.That(reservationResponse.Value.Status, Is.EqualTo(ReservationStatus.Active));
            Assert.IsEmpty(reservationResponse.Value.PhoneNumbers);
            if (Mode != RecordedTestMode.Playback)
            {
                Assert.Greater(reservationResponse.Value.ExpiresAt, DateTimeOffset.UtcNow);
            }

            _initialReservationState = reservationResponse.Value;
        }

        [TestCase]
        [SyncOnly]
        [Order(0)] // This is run first to ensure that at least one active reservation exists before running the tests.
        public void CreateReservation()
        {
            PhoneNumbersClient client = CreateClient();
            var reservationId = GetReservationId();
            var request = new CreateOrUpdateReservationOptions(reservationId);

            var reservationResponse = client.CreateOrUpdateReservation(request);

            // The response should be a 201 Created.
            Assert.That(reservationResponse.GetRawResponse().Status, Is.EqualTo(201));
            Assert.IsNotNull(reservationResponse.Value);
            Assert.That(reservationResponse.Value.Id, Is.EqualTo(reservationId));
            Assert.That(reservationResponse.Value.Status, Is.EqualTo(ReservationStatus.Active));
            Assert.IsEmpty(reservationResponse.Value.PhoneNumbers);
            if (Mode != RecordedTestMode.Playback)
            {
                Assert.Greater(reservationResponse.Value.ExpiresAt, DateTimeOffset.UtcNow);
            }

            _initialReservationState = reservationResponse.Value;
        }

        [TestCase(AuthMethod.ConnectionString, TestName = "BrowseAvailableNumbersAsyncUsingConnectionString")]
        [TestCase(AuthMethod.KeyCredential, TestName = "BrowseAvailableNumbersAsyncUsingAzureKeyCredential")]
        [TestCase(AuthMethod.TokenCredential, TestName = "BrowseAvailableNumbersAsyncUsingTokenCredential")]
        [AsyncOnly]
        public async Task BrowseAvailableNumbersAsync(AuthMethod authMethod)
        {
            PhoneNumbersClient client = CreateClient(authMethod);
            var browseRequest = new PhoneNumbersBrowseOptions("US", PhoneNumberType.TollFree);

            var response = await client.BrowseAvailableNumbersAsync(browseRequest);

            Assert.IsNotNull(response.Value);
            Assert.Greater(response.Value.PhoneNumbers.Count, 0);

            browseRequest = new PhoneNumbersBrowseOptions("IE", PhoneNumberType.Mobile);

            response = await client.BrowseAvailableNumbersAsync(browseRequest);

            Assert.IsNotNull(response.Value);
            Assert.Greater(response.Value.PhoneNumbers.Count, 0);
            Assert.That(response.Value.PhoneNumbers[0].PhoneNumberType == PhoneNumberType.Mobile, Is.True);
        }

        [TestCase(AuthMethod.ConnectionString, TestName = "BrowseAvailableNumbersUsingConnectionString")]
        [TestCase(AuthMethod.KeyCredential, TestName = "BrowseAvailableNumbersUsingAzureKeyCredential")]
        [TestCase(AuthMethod.TokenCredential, TestName = "BrowseAvailableNumbersUsingTokenCredential")]
        [SyncOnly]
        public void BrowseAvailableNumbers(AuthMethod authMethod)
        {
            PhoneNumbersClient client = CreateClient(authMethod);
            var browseRequest = new PhoneNumbersBrowseOptions("US", PhoneNumberType.TollFree);

            var response = client.BrowseAvailableNumbers(browseRequest);

            Assert.IsNotNull(response.Value);
            Assert.Greater(response.Value.PhoneNumbers.Count, 0);
            Assert.That(response.Value.PhoneNumbers[0].PhoneNumberType == PhoneNumberType.TollFree, Is.True);

            browseRequest = new PhoneNumbersBrowseOptions("IE", PhoneNumberType.Mobile);

            response = client.BrowseAvailableNumbers(browseRequest);

            Assert.IsNotNull(response.Value);
            Assert.Greater(response.Value.PhoneNumbers.Count, 0);
            Assert.That(response.Value.PhoneNumbers[0].PhoneNumberType == PhoneNumberType.Mobile, Is.True);
        }

        [TestCase(AuthMethod.ConnectionString, TestName = "GetPhoneNumbersReservationsAsyncWithConnectionString")]
        [TestCase(AuthMethod.KeyCredential, TestName = "GetPhoneNumbersReservationsAsyncWithAzureKeyCredential")]
        [TestCase(AuthMethod.TokenCredential, TestName = "GetPhoneNumbersReservationsAsyncWithTokenCredential")]
        [AsyncOnly]
        [Order(1)] // This test is executed before any other test that could alter the initial reservation state.
        public async Task GetPhoneNumbersReservationsAsync(AuthMethod authMethod)
        {
            PhoneNumbersClient client = CreateClient(authMethod);

            var reservationsPageable = client.GetReservationsAsync();
            var reservations = await reservationsPageable.ToEnumerableAsync();

            Assert.IsNotNull(reservations);
            Assert.Greater(reservations.Count, 0);
            Assert.That(reservations.Any(reservations => reservations.Id == _initialReservationState?.Id), Is.True);
        }

        [TestCase(AuthMethod.ConnectionString, TestName = "GetPhoneNumbersReservationsWithConnectionString")]
        [TestCase(AuthMethod.KeyCredential, TestName = "GetPhoneNumbersReservationsWithAzureKeyCredential")]
        [TestCase(AuthMethod.TokenCredential, TestName = "GetPhoneNumbersReservationsWithTokenCredential")]
        [SyncOnly]
        [Order(1)] // This test is executed before any other test that could alter the initial reservation state.
        public void GetPhoneNumbersReservations(AuthMethod authMethod)
        {
            PhoneNumbersClient client = CreateClient(authMethod);

            var reservations = client.GetReservations();

            Assert.IsNotNull(reservations);
            Assert.Greater(reservations.Count(), 0);
            Assert.That(reservations.Any(reservations => reservations.Id == _initialReservationState?.Id), Is.True);
        }

        [TestCase(AuthMethod.ConnectionString, TestName = "GetReservationAsyncUsingConnectionString")]
        [TestCase(AuthMethod.KeyCredential, TestName = "GetReservationAsyncUsingAzureKeyCredential")]
        [TestCase(AuthMethod.TokenCredential, TestName = "GetReservationAsyncUsingTokenCredential")]
        [AsyncOnly]
        [Order(1)] // This test is executed before any other test that could alter the initial reservation state.
        public async Task GetReservationAsync(AuthMethod authMethod)
        {
            PhoneNumbersClient client = CreateClient(authMethod);

            var reservationResponse = await client.GetReservationAsync((Guid)(_initialReservationState!.Id)!);
            var reservation = reservationResponse.Value;

            Assert.IsNotNull(reservation);
            Assert.That(reservation.Id, Is.EqualTo(_initialReservationState!.Id));
            Assert.That(reservation.ExpiresAt, Is.EqualTo(_initialReservationState!.ExpiresAt));
            Assert.That(reservation.Status, Is.EqualTo(_initialReservationState!.Status));
        }

        [TestCase(AuthMethod.ConnectionString, TestName = "GetReservationUsingConnectionString")]
        [TestCase(AuthMethod.KeyCredential, TestName = "GetReservationUsingAzureKeyCredential")]
        [TestCase(AuthMethod.TokenCredential, TestName = "GetReservationUsingTokenCredential")]
        [SyncOnly]
        [Order(1)] // This test is executed before any other test that could alter the initial reservation state.
        public void GetReservation(AuthMethod authMethod)
        {
            PhoneNumbersClient client = CreateClient(authMethod);

            var reservationResponse = client.GetReservation((Guid)(_initialReservationState!.Id)!);
            var reservation = reservationResponse.Value;

            Assert.IsNotNull(reservation);
            Assert.That(reservation.Id, Is.EqualTo(_initialReservationState!.Id));
            Assert.That(reservation.ExpiresAt, Is.EqualTo(_initialReservationState!.ExpiresAt));
            Assert.That(reservation.Status, Is.EqualTo(_initialReservationState!.Status));
        }

        [TestCase(AuthMethod.ConnectionString, "US", "tollFree", TestName = "CreateOrUpdateReservationAsyncTollFreeUsingConnectionString")]
        [TestCase(AuthMethod.ConnectionString, "US", "geographic", TestName = "CreateOrUpdateReservationAsyncGeographicUsingConnectionString")]
        [TestCase(AuthMethod.ConnectionString, "IE", "mobile", TestName = "CreateOrUpdateReservationAsyncMobileUsingConnectionString")]
        [TestCase(AuthMethod.KeyCredential, "US", "tollFree", TestName = "CreateOrUpdateReservationAsyncTollFreeUsingKeyCredential")]
        [TestCase(AuthMethod.KeyCredential, "US", "geographic", TestName = "CreateOrUpdateReservationAsyncGeographicUsingKeyCredential")]
        [TestCase(AuthMethod.KeyCredential, "IE", "mobile", TestName = "CreateOrUpdateReservationAsyncMobileUsingKeyCredential")]
        [TestCase(AuthMethod.TokenCredential, "US", "tollFree", TestName = "CreateOrUpdateReservationAsyncTollFreeUsingTokenCredential")]
        [TestCase(AuthMethod.TokenCredential, "US", "geographic", TestName = "CreateOrUpdateReservationAsyncGeographicUsingTokenCredential")]
        [TestCase(AuthMethod.TokenCredential, "IE", "mobile", TestName = "CreateOrUpdateReservationAsyncMobileUsingTokenCredential")]
        [AsyncOnly]
        [Order(2)] // This test is executed after tests that depend on the initial reservation state.
        public async Task CreateOrUpdateReservationAsync(AuthMethod authMethod, string countryCode, string phoneNumberType)
        {
            PhoneNumbersClient client = CreateClient(authMethod);
            var browseRequest = new PhoneNumbersBrowseOptions(countryCode, phoneNumberType);
            var response = await client.BrowseAvailableNumbersAsync(browseRequest);
            var availablePhoneNumbers = response.Value.PhoneNumbers;

            // Reserve the first available phone number.
            var phoneNumberToReserve = availablePhoneNumbers.First();
            var reservationBeforeAdd = _initialReservationState!;
            var updateRequest = new CreateOrUpdateReservationOptions(_reservationId)
            {
                PhoneNumbersToAdd = new List<AvailablePhoneNumber>() { phoneNumberToReserve },
            };

            var reservationResponse = await client.CreateOrUpdateReservationAsync(updateRequest).ConfigureAwait(false);
            var reservationAfterAdd = reservationResponse.Value;

            Assert.IsNotNull(reservationAfterAdd);
            Assert.That(reservationAfterAdd.Id, Is.EqualTo(_initialReservationState!.Id));
            Assert.That(reservationAfterAdd.Status, Is.EqualTo(ReservationStatus.Active));
            Assert.Greater(reservationAfterAdd.ExpiresAt, _initialReservationState.ExpiresAt);
            Assert.That(reservationAfterAdd.PhoneNumbers.Values.All(number => number.Status != PhoneNumberAvailabilityStatus.Error), Is.True);
            Assert.That(reservationAfterAdd.PhoneNumbers.ContainsKey(phoneNumberToReserve.Id), Is.True);

            // Now remove the reserved number
            var phoneNumberIdToRemove = phoneNumberToReserve.Id;
            var reservationBeforeRemove = reservationAfterAdd;
            var removeRequest = new CreateOrUpdateReservationOptions(_reservationId)
            {
                PhoneNumbersToRemove = new List<string>() { phoneNumberIdToRemove },
            };

            reservationResponse = await client.CreateOrUpdateReservationAsync(removeRequest).ConfigureAwait(false);
            var reservationAfterRemove = reservationResponse.Value;
            Assert.IsNotNull(reservationAfterRemove);
            Assert.That(reservationAfterRemove.Id, Is.EqualTo(_initialReservationState!.Id));
            Assert.That(reservationAfterRemove.Status, Is.EqualTo(ReservationStatus.Active));
            Assert.Greater(reservationAfterRemove.ExpiresAt, reservationAfterAdd.ExpiresAt);
            Assert.That(reservationAfterRemove.PhoneNumbers.Values.All(number => number.Status != PhoneNumberAvailabilityStatus.Error), Is.True);
            Assert.That(reservationAfterRemove.PhoneNumbers.ContainsKey(phoneNumberIdToRemove), Is.False);
        }

        [TestCase(AuthMethod.ConnectionString, "US", "tollFree", TestName = "CreateOrUpdateReservationTollFreeUsingConnectionString")]
        [TestCase(AuthMethod.ConnectionString, "US", "geographic", TestName = "CreateOrUpdateReservationGeographicUsingConnectionString")]
        [TestCase(AuthMethod.ConnectionString, "IE", "mobile", TestName = "CreateOrUpdateReservationMobileUsingConnectionString")]
        [TestCase(AuthMethod.KeyCredential, "US", "tollFree", TestName = "CreateOrUpdateReservationTollFreeUsingKeyCredential")]
        [TestCase(AuthMethod.KeyCredential, "US", "geographic", TestName = "CreateOrUpdateReservationGeographicUsingKeyCredential")]
        [TestCase(AuthMethod.KeyCredential, "IE", "mobile", TestName = "CreateOrUpdateReservationMobileUsingKeyCredential")]
        [TestCase(AuthMethod.TokenCredential, "US", "tollFree", TestName = "CreateOrUpdateReservationTollFreeUsingTokenCredential")]
        [TestCase(AuthMethod.TokenCredential, "US", "geographic", TestName = "CreateOrUpdateReservationGeographicUsingTokenCredential")]
        [TestCase(AuthMethod.TokenCredential, "IE", "mobile", TestName = "CreateOrUpdateReservationMobileUsingTokenCredential")]
        [SyncOnly]
        [Order(2)] // This test is executed after tests that depend on the initial reservation state.
        public void CreateOrUpdateReservation(AuthMethod authMethod, string countryCode, string phoneNumberType)
        {
            PhoneNumbersClient client = CreateClient(authMethod);
            var browseRequest = new PhoneNumbersBrowseOptions(countryCode, phoneNumberType);
            var response = client.BrowseAvailableNumbers(browseRequest);
            var availablePhoneNumbers = response.Value.PhoneNumbers;

            // Reserve the first available phone number.
            var phoneNumberToReserve = availablePhoneNumbers.First();
            var reservationBeforeAdd = _initialReservationState!;
            var updateRequest = new CreateOrUpdateReservationOptions(_reservationId)
            {
                PhoneNumbersToAdd = new List<AvailablePhoneNumber>() { phoneNumberToReserve }
            };

            var reservationResponse = client.CreateOrUpdateReservation(updateRequest);
            var reservationAfterAdd = reservationResponse.Value;

            Assert.IsNotNull(reservationAfterAdd);
            Assert.That(reservationAfterAdd.Id, Is.EqualTo(reservationBeforeAdd.Id));
            Assert.That(reservationAfterAdd.Status, Is.EqualTo(ReservationStatus.Active));
            Assert.Greater(reservationAfterAdd.ExpiresAt, reservationBeforeAdd.ExpiresAt);
            Assert.That(reservationAfterAdd.PhoneNumbers.Values.All(number => number.Status != PhoneNumberAvailabilityStatus.Error), Is.True);
            Assert.That(reservationAfterAdd.PhoneNumbers.ContainsKey(phoneNumberToReserve.Id), Is.True);

            // Now remove the reserved number
            var phoneNumberIdToRemove = phoneNumberToReserve.Id;
            var reservationBeforeRemove = reservationAfterAdd;
            var removeRequest = new CreateOrUpdateReservationOptions(_reservationId)
            {
                PhoneNumbersToRemove = new List<string>() { phoneNumberIdToRemove }
            };

            reservationResponse = client.CreateOrUpdateReservation(removeRequest);
            var reservationAfterRemove = reservationResponse.Value;

            Assert.IsNotNull(reservationAfterRemove);
            Assert.That(reservationAfterRemove.Id, Is.EqualTo(reservationBeforeRemove.Id));
            Assert.That(reservationAfterRemove.Status, Is.EqualTo(ReservationStatus.Active));
            Assert.Greater(reservationAfterRemove.ExpiresAt, reservationBeforeRemove.ExpiresAt);
            Assert.That(reservationAfterRemove.PhoneNumbers.Values.All(number => number.Status != PhoneNumberAvailabilityStatus.Error), Is.True);
            Assert.That(reservationAfterRemove.PhoneNumbers.ContainsKey(phoneNumberIdToRemove), Is.False);
        }

        [TestCase]
        [AsyncOnly]
        [Order(3)] // This test is executed after tests that depend on the initial reservation state.
        public async Task DeleteReservationAsync()
        {
            PhoneNumbersClient client = CreateClient();

            await client.DeleteReservationAsync(_initialReservationState!.Id);

            var exception = Assert.ThrowsAsync<RequestFailedException>(async () => await client.GetReservationAsync(_initialReservationState!.Id));
            Assert.That(exception!.Status, Is.EqualTo(404));
        }

        [TestCase]
        [SyncOnly]
        [Order(3)] // This test is executed after tests that depend on the initial reservation state.
        public void DeleteReservation()
        {
            PhoneNumbersClient client = CreateClient();

            client.DeleteReservation(_initialReservationState!.Id);

            var exception = Assert.Throws<RequestFailedException>(() => client.GetReservation(_initialReservationState!.Id));
            Assert.That(exception!.Status, Is.EqualTo(404));
        }

        [TestCase]
        [AsyncOnly]
        [Order(4)] // Because we are using the same reservationId, this test should be executed after the rest of the happy path tests.
        public async Task ReservationPurchaseWithoutAgreementToNotResellAsync()
        {
            if (TestEnvironment.ShouldIgnorePhoneNumbersTests)
            {
                Assert.Ignore("Skip phone number live tests flag is on.");
            }

            PhoneNumbersClient client = CreateClient();

            // France doesn't allow reselling phone numbers.
            var browseRequest = new PhoneNumbersBrowseOptions("FR", PhoneNumberType.TollFree);
            var response = await client.BrowseAvailableNumbersAsync(browseRequest);
            var availablePhoneNumbers = response.Value.PhoneNumbers;

            // Reserve the first available phone number.
            var phoneNumberToReserve = availablePhoneNumbers.First();

            // The phone number should require an agreement to not resell.
            Assert.That(phoneNumberToReserve.IsAgreementToNotResellRequired, Is.True);

            var reservationId = GetReservationId();
            var request = new CreateOrUpdateReservationOptions(reservationId)
            {
                PhoneNumbersToAdd = new List<AvailablePhoneNumber>() { phoneNumberToReserve }
            };

            var reservationResponse = await client.CreateOrUpdateReservationAsync(request).ConfigureAwait(false);

            // The phone number was successfully reserved.
            Assert.That(reservationResponse.Value.PhoneNumbers.ContainsKey(phoneNumberToReserve.Id), Is.True);
            Assert.That(reservationResponse.Value.PhoneNumbers[phoneNumberToReserve.Id], Is.Not.EqualTo(PhoneNumberAvailabilityStatus.Error));

            // The phone number should not be purchasable without agreeing to not resell.
            var exception = Assert.ThrowsAsync<RequestFailedException>(async () => await client.StartPurchaseReservationAsync(reservationId, agreeToNotResell: false));
            Assert.That(exception!.Status, Is.EqualTo(400));

            // Clean up the reservation.
            await client.DeleteReservationAsync(reservationId);
        }

        [TestCase]
        [SyncOnly]
        [Order(4)] // Because we are using the same reservationId, this test should be executed after the rest of the happy path tests.
        public void ReservationPurchaseWithoutAgreementToNotResell()
        {
            if (TestEnvironment.ShouldIgnorePhoneNumbersTests)
            {
                Assert.Ignore("Skip phone number live tests flag is on.");
            }

            PhoneNumbersClient client = CreateClient();

            // France doesn't allow reselling phone numbers.
            var browseRequest = new PhoneNumbersBrowseOptions("FR", PhoneNumberType.TollFree);
            var response = client.BrowseAvailableNumbers(browseRequest);
            var availablePhoneNumbers = response.Value.PhoneNumbers;

            // Reserve the first available phone number.
            var phoneNumberToReserve = availablePhoneNumbers.First();

            // The phone number should require an agreement to not resell.
            Assert.That(phoneNumberToReserve.IsAgreementToNotResellRequired, Is.True);

            var reservationId = GetReservationId();
            var request = new CreateOrUpdateReservationOptions(reservationId)
            {
                PhoneNumbersToAdd = new List<AvailablePhoneNumber>() { phoneNumberToReserve }
            };

            var reservationResponse = client.CreateOrUpdateReservation(request);

            // The phone number was successfully reserved.
            Assert.That(reservationResponse.Value.PhoneNumbers.ContainsKey(phoneNumberToReserve.Id), Is.True);
            Assert.That(reservationResponse.Value.PhoneNumbers[phoneNumberToReserve.Id], Is.Not.EqualTo(PhoneNumberAvailabilityStatus.Error));

            // The phone number should not be purchasable without agreeing to not resell.
            var exception = Assert.Throws<RequestFailedException>(() => client.StartPurchaseReservation(reservationId, agreeToNotResell: false));
            Assert.That(exception!.Status, Is.EqualTo(400));

            // Clean up the reservation.
            client.DeleteReservation(reservationId);
        }

        // Gets either the static reservation ID for playback or a new reservation ID for live tests.
        protected Guid GetReservationId()
        {
            if (TestEnvironment.Mode == RecordedTestMode.Playback)
                return _staticReservationId;
            return _reservationId;
        }
    }
}
