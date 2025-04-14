// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
            var reservation = new PhoneNumbersReservation(reservationId);

            var reservationResponse = await client.CreateOrUpdateReservationAsync(reservation).ConfigureAwait(false);

            // The response should be a 201 Created.
            Assert.AreEqual(201, reservationResponse.GetRawResponse().Status);
            Assert.IsNotNull(reservationResponse.Value);
            Assert.AreEqual(reservationId, reservationResponse.Value.Id);
            Assert.AreEqual(ReservationStatus.Active, reservationResponse.Value.Status);
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
            var reservation = new PhoneNumbersReservation(reservationId);

            var reservationResponse = client.CreateOrUpdateReservation(reservation);

            // The response should be a 201 Created.
            Assert.AreEqual(201, reservationResponse.GetRawResponse().Status);
            Assert.IsNotNull(reservationResponse.Value);
            Assert.AreEqual(reservationId, reservationResponse.Value.Id);
            Assert.AreEqual(ReservationStatus.Active, reservationResponse.Value.Status);
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
            var browseRequest = new PhoneNumbersBrowseRequest(PhoneNumberType.TollFree);

            var response = await client.BrowseAvailableNumbersAsync("US", browseRequest);

            Assert.IsNotNull(response.Value);
            var availableNumbers = response.Value.PhoneNumbers;
            Assert.Greater(availableNumbers.Count, 0);
        }

        [TestCase(AuthMethod.ConnectionString, TestName = "BrowseAvailableNumbersUsingConnectionString")]
        [TestCase(AuthMethod.KeyCredential, TestName = "BrowseAvailableNumbersUsingAzureKeyCredential")]
        [TestCase(AuthMethod.TokenCredential, TestName = "BrowseAvailableNumbersUsingTokenCredential")]
        [SyncOnly]
        public void BrowseAvailableNumbers(AuthMethod authMethod)
        {
            PhoneNumbersClient client = CreateClient(authMethod);
            var browseRequest = new PhoneNumbersBrowseRequest(PhoneNumberType.TollFree);

            var response = client.BrowseAvailableNumbers("US", browseRequest);

            Assert.IsNotNull(response.Value);
            var availableNumbers = response.Value.PhoneNumbers;
            Assert.Greater(availableNumbers.Count, 0);
        }

        [TestCase(AuthMethod.ConnectionString, TestName = "GetPhoneNumbersReservationsAsyncWithConnectionString")]
        [TestCase(AuthMethod.KeyCredential, TestName = "GetPhoneNumbersReservationsAsyncWithAzureKeyCredential")]
        [TestCase(AuthMethod.TokenCredential, TestName = "GetPhoneNumbersReservationsAsyncWithTokenCredential")]
        [AsyncOnly]
        [Order(1)] // This test is executed before any other test that could alter the initial reservation state.
        public async Task GetPhoneNumbersReservationsAsync(AuthMethod authMethod)
        {
            PhoneNumbersClient client = CreateClient(authMethod);

            var reservationsPageable = client.GetPhoneNumbersReservationsAsync();
            var reservations = await reservationsPageable.ToEnumerableAsync();

            Assert.IsNotNull(reservations);
            Assert.Greater(reservations.Count, 0);
            Assert.True(reservations.Any(reservations => reservations.Id == _initialReservationState?.Id));
        }

        [TestCase(AuthMethod.ConnectionString, TestName = "GetPhoneNumbersReservationsWithConnectionString")]
        [TestCase(AuthMethod.KeyCredential, TestName = "GetPhoneNumbersReservationsWithAzureKeyCredential")]
        [TestCase(AuthMethod.TokenCredential, TestName = "GetPhoneNumbersReservationsWithTokenCredential")]
        [SyncOnly]
        [Order(1)] // This test is executed before any other test that could alter the initial reservation state.
        public void GetPhoneNumbersReservations(AuthMethod authMethod)
        {
            PhoneNumbersClient client = CreateClient(authMethod);

            var reservations = client.GetPhoneNumbersReservations();

            Assert.IsNotNull(reservations);
            Assert.Greater(reservations.Count(), 0);
            Assert.True(reservations.Any(reservations => reservations.Id == _initialReservationState?.Id));
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
            Assert.AreEqual(_initialReservationState!.Id, reservation.Id);
            Assert.AreEqual(_initialReservationState!.ExpiresAt, reservation.ExpiresAt);
            Assert.AreEqual(_initialReservationState!.Status, reservation.Status);
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
            Assert.AreEqual(_initialReservationState!.Id, reservation.Id);
            Assert.AreEqual(_initialReservationState!.ExpiresAt, reservation.ExpiresAt);
            Assert.AreEqual(_initialReservationState!.Status, reservation.Status);
        }

        [TestCase(AuthMethod.ConnectionString, TestName = "CreateOrUpdateReservationAsyncUsingConnectionString")]
        [TestCase(AuthMethod.KeyCredential, TestName = "CreateOrUpdateReservationAsyncUsingAzureKeyCredential")]
        [TestCase(AuthMethod.TokenCredential, TestName = "CreateOrUpdateReservationAsyncUsingTokenCredential")]
        [AsyncOnly]
        [Order(2)] // This test is executed after tests that depend on the initial reservation state.
        public async Task CreateOrUpdateReservationAsync(AuthMethod authMethod)
        {
            PhoneNumbersClient client = CreateClient(authMethod);
            var browseRequest = new PhoneNumbersBrowseRequest(PhoneNumberType.TollFree);
            var response = await client.BrowseAvailableNumbersAsync("US", browseRequest);
            var availablePhoneNumbers = response.Value.PhoneNumbers;

            // Reserve the first available phone number.
            var phoneNumberToReserve = availablePhoneNumbers.First();
            var reservationBeforeAdd = CopyReservation(_initialReservationState!);
            reservationBeforeAdd.AddPhoneNumber(phoneNumberToReserve);

            var reservationResponse = await client.CreateOrUpdateReservationAsync(reservationBeforeAdd).ConfigureAwait(false);
            var reservationAfterAdd = reservationResponse.Value;

            Assert.IsNotNull(reservationAfterAdd);
            Assert.AreEqual(_initialReservationState!.Id, reservationAfterAdd.Id);
            Assert.AreEqual(ReservationStatus.Active, reservationAfterAdd.Status);
            Assert.Greater(reservationAfterAdd.ExpiresAt, _initialReservationState.ExpiresAt);
            Assert.IsTrue(reservationAfterAdd.PhoneNumbers.Values.All(number => number.Status != AvailablePhoneNumberStatus.Error));
            Assert.IsTrue(reservationAfterAdd.PhoneNumbers.ContainsKey(phoneNumberToReserve.Id));

            // Now remove the reserved number
            var phoneNumberIdToRemove = phoneNumberToReserve.Id;
            var reservationBeforeRemove = CopyReservation(reservationAfterAdd);
            reservationBeforeRemove.RemovePhoneNumber(phoneNumberIdToRemove);

            reservationResponse = await client.CreateOrUpdateReservationAsync(reservationBeforeRemove).ConfigureAwait(false);
            var reservationAfterRemove = reservationResponse.Value;
            Assert.IsNotNull(reservationAfterRemove);
            Assert.AreEqual(_initialReservationState!.Id, reservationAfterRemove.Id);
            Assert.AreEqual(ReservationStatus.Active, reservationAfterRemove.Status);
            Assert.Greater(reservationAfterRemove.ExpiresAt, reservationAfterAdd.ExpiresAt);
            Assert.IsTrue(reservationAfterRemove.PhoneNumbers.Values.All(number => number.Status != AvailablePhoneNumberStatus.Error));
            Assert.IsFalse(reservationAfterRemove.PhoneNumbers.ContainsKey(phoneNumberIdToRemove));
        }

        [TestCase(AuthMethod.ConnectionString, TestName = "CreateOrUpdateReservationUsingConnectionString")]
        [TestCase(AuthMethod.KeyCredential, TestName = "CreateOrUpdateReservationUsingAzureKeyCredential")]
        [TestCase(AuthMethod.TokenCredential, TestName = "CreateOrUpdateReservationUsingTokenCredential")]
        [SyncOnly]
        [Order(2)] // This test is executed after tests that depend on the initial reservation state.
        public void CreateOrUpdateReservation(AuthMethod authMethod)
        {
            PhoneNumbersClient client = CreateClient(authMethod);
            var browseRequest = new PhoneNumbersBrowseRequest(PhoneNumberType.TollFree);
            var response = client.BrowseAvailableNumbers("US", browseRequest);
            var availablePhoneNumbers = response.Value.PhoneNumbers;

            // Reserve the first available phone number.
            var phoneNumberToReserve = availablePhoneNumbers.First();
            var reservationBeforeAdd = CopyReservation(_initialReservationState!);
            reservationBeforeAdd.AddPhoneNumber(phoneNumberToReserve);

            var reservationResponse = client.CreateOrUpdateReservation(reservationBeforeAdd);
            var reservationAfterAdd = reservationResponse.Value;

            Assert.IsNotNull(reservationAfterAdd);
            Assert.AreEqual(reservationBeforeAdd.Id, reservationAfterAdd.Id);
            Assert.AreEqual(ReservationStatus.Active, reservationAfterAdd.Status);
            Assert.Greater(reservationAfterAdd.ExpiresAt, reservationBeforeAdd.ExpiresAt);
            Assert.IsTrue(reservationAfterAdd.PhoneNumbers.Values.All(number => number.Status != AvailablePhoneNumberStatus.Error));
            Assert.IsTrue(reservationAfterAdd.PhoneNumbers.ContainsKey(phoneNumberToReserve.Id));

            // Now remove the reserved number
            var phoneNumberIdToRemove = phoneNumberToReserve.Id;
            var reservationBeforeRemove = CopyReservation(reservationAfterAdd);
            reservationBeforeRemove.RemovePhoneNumber(phoneNumberIdToRemove);

            reservationResponse = client.CreateOrUpdateReservation(reservationBeforeRemove);
            var reservationAfterRemove = reservationResponse.Value;

            Assert.IsNotNull(reservationAfterRemove);
            Assert.AreEqual(reservationBeforeRemove.Id, reservationAfterRemove.Id);
            Assert.AreEqual(ReservationStatus.Active, reservationAfterRemove.Status);
            Assert.Greater(reservationAfterRemove.ExpiresAt, reservationBeforeRemove.ExpiresAt);
            Assert.IsTrue(reservationAfterRemove.PhoneNumbers.Values.All(number => number.Status != AvailablePhoneNumberStatus.Error));
            Assert.IsFalse(reservationAfterRemove.PhoneNumbers.ContainsKey(phoneNumberIdToRemove));
        }

        [TestCase]
        [AsyncOnly]
        [Order(3)] // This test is executed after tests that depend on the initial reservation state.
        public async Task DeleteReservationAsync()
        {
            PhoneNumbersClient client = CreateClient();

            await client.DeleteReservationAsync(_initialReservationState!.Id);

            var exception = Assert.ThrowsAsync<RequestFailedException>(async () => await client.GetReservationAsync(_initialReservationState!.Id));
            Assert.AreEqual(404, exception!.Status);
        }

        [TestCase]
        [SyncOnly]
        [Order(3)] // This test is executed after tests that depend on the initial reservation state.
        public void DeleteReservation()
        {
            PhoneNumbersClient client = CreateClient();

            client.DeleteReservation(_initialReservationState!.Id);

            var exception = Assert.Throws<RequestFailedException>(() => client.GetReservation(_initialReservationState!.Id));
            Assert.AreEqual(404, exception!.Status);
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
            var browseRequest = new PhoneNumbersBrowseRequest(PhoneNumberType.TollFree);
            var response = await client.BrowseAvailableNumbersAsync("FR", browseRequest);
            var availablePhoneNumbers = response.Value.PhoneNumbers;

            // Reserve the first available phone number.
            var phoneNumberToReserve = availablePhoneNumbers.First();

            // The phone number should require an agreement to not resell.
            Assert.IsTrue(phoneNumberToReserve.IsAgreementToNotResellRequired);

            var reservationId = GetReservationId();
            var reservation = new PhoneNumbersReservation(reservationId);
            reservation.AddPhoneNumber(phoneNumberToReserve);

            var reservationResponse = await client.CreateOrUpdateReservationAsync(reservation).ConfigureAwait(false);

            // The phone number was successfully reserved.
            Assert.IsTrue(reservationResponse.Value.PhoneNumbers.ContainsKey(phoneNumberToReserve.Id));
            Assert.AreNotEqual(AvailablePhoneNumberStatus.Error, reservationResponse.Value.PhoneNumbers[phoneNumberToReserve.Id]);

            // The phone number should not be purchasable without agreeing to not resell.
            var exception = Assert.ThrowsAsync<RequestFailedException>(async () => await client.StartPurchaseReservationAsync(reservationId, agreeToNotResell: false));
            Assert.AreEqual(400, exception!.Status);

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
            var browseRequest = new PhoneNumbersBrowseRequest(PhoneNumberType.TollFree);
            var response = client.BrowseAvailableNumbers("FR", browseRequest);
            var availablePhoneNumbers = response.Value.PhoneNumbers;

            // Reserve the first available phone number.
            var phoneNumberToReserve = availablePhoneNumbers.First();

            // The phone number should require an agreement to not resell.
            Assert.IsTrue(phoneNumberToReserve.IsAgreementToNotResellRequired);

            var reservationId = GetReservationId();
            var reservation = new PhoneNumbersReservation(reservationId);
            reservation.AddPhoneNumber(phoneNumberToReserve);

            var reservationResponse = client.CreateOrUpdateReservation(reservation);

            // The phone number was successfully reserved.
            Assert.IsTrue(reservationResponse.Value.PhoneNumbers.ContainsKey(phoneNumberToReserve.Id));
            Assert.AreNotEqual(AvailablePhoneNumberStatus.Error, reservationResponse.Value.PhoneNumbers[phoneNumberToReserve.Id]);

            // The phone number should not be purchasable without agreeing to not resell.
            var exception = Assert.Throws<RequestFailedException>(() => client.StartPurchaseReservation(reservationId, agreeToNotResell: false));
            Assert.AreEqual(400, exception!.Status);

            // Clean up the reservation.
            client.DeleteReservation(reservationId);
        }

        [TestCase]
        [AsyncOnly]
        [Order(5)] // Since a purchased reservation cannot be deleted, this needs to be the last test executed if not skipped.
        public async Task StartPurchaseReservationAsync()
        {
            if (TestEnvironment.ShouldIgnorePhoneNumbersTests)
            {
                Assert.Ignore("Skip phone number live tests flag is on.");
            }

            PhoneNumbersClient client = CreateClient();
            var browseRequest = new PhoneNumbersBrowseRequest(PhoneNumberType.TollFree);
            var response = await client.BrowseAvailableNumbersAsync("US", browseRequest);
            var availablePhoneNumbers = response.Value.PhoneNumbers;

            // Reserve the first available phone number.
            var phoneNumberToReserve = availablePhoneNumbers.First();

            var reservationId = GetReservationId();
            var reservation = new PhoneNumbersReservation(reservationId);
            reservation.AddPhoneNumber(phoneNumberToReserve);

            var reservationResponse = await client.CreateOrUpdateReservationAsync(reservation).ConfigureAwait(false);

            // The phone number was successfully reserved.
            Assert.IsTrue(reservationResponse.Value.PhoneNumbers.ContainsKey(phoneNumberToReserve.Id));
            Assert.AreNotEqual(AvailablePhoneNumberStatus.Error, reservationResponse.Value.PhoneNumbers[phoneNumberToReserve.Id]);

            // Purchase the reservation.
            var purchaseReservationOperation = await client.StartPurchaseReservationAsync(reservationId, agreeToNotResell: true);
            while (!purchaseReservationOperation.HasCompleted)
            {
                SleepIfNotInPlaybackMode();
                await purchaseReservationOperation.UpdateStatusAsync();
            }

            // The phone number should now be purchased.
            var purchasedPhoneNumbers = await client.GetPurchasedPhoneNumbersAsync().ToEnumerableAsync();
            Assert.IsTrue(purchasedPhoneNumbers.Any(purchasedNumber => purchasedNumber.Id == phoneNumberToReserve.Id));

            // Release the number to prevent additional costs.
            var releaseOperation = await client.StartReleasePhoneNumberAsync(phoneNumberToReserve.Id);
            while (!releaseOperation.HasCompleted)
            {
                SleepIfNotInPlaybackMode();
                await releaseOperation.UpdateStatusAsync();
            }
        }

        [TestCase]
        [SyncOnly]
        [Order(5)] // Since a purchased reservation cannot be deleted, this needs to be the last test executed if not skipped.
        public void StartPurchaseReservation()
        {
            if (TestEnvironment.ShouldIgnorePhoneNumbersTests)
            {
                Assert.Ignore("Skip phone number live tests flag is on.");
            }

            PhoneNumbersClient client = CreateClient();

            var browseRequest = new PhoneNumbersBrowseRequest(PhoneNumberType.TollFree);
            var response = client.BrowseAvailableNumbers("US", browseRequest);
            var availablePhoneNumbers = response.Value.PhoneNumbers;

            // Reserve the first available phone number.
            var phoneNumberToReserve = availablePhoneNumbers.First();
            var reservationId = GetReservationId();
            var reservation = new PhoneNumbersReservation(reservationId);
            reservation.AddPhoneNumber(phoneNumberToReserve);

            var reservationResponse = client.CreateOrUpdateReservation(reservation);

            // The phone number was successfully reserved.
            Assert.IsTrue(reservationResponse.Value.PhoneNumbers.ContainsKey(phoneNumberToReserve.Id));
            Assert.AreNotEqual(AvailablePhoneNumberStatus.Error, reservationResponse.Value.PhoneNumbers[phoneNumberToReserve.Id]);

            // Purchase the reservation.
            var purchaseReservationOperation = client.StartPurchaseReservation(reservationId, agreeToNotResell: true);
            while (!purchaseReservationOperation.HasCompleted)
            {
                SleepIfNotInPlaybackMode();
                purchaseReservationOperation.UpdateStatus();
            }

            // The phone number should now be purchased.
            var purchasedPhoneNumbers = client.GetPurchasedPhoneNumbers().ToList();
            Assert.IsTrue(purchasedPhoneNumbers.Any(purchasedNumber => purchasedNumber.Id == phoneNumberToReserve.Id));

            // Release the number to prevent additional costs.
            var releaseOperation = client.StartReleasePhoneNumber(phoneNumberToReserve.Id);
            while (!releaseOperation.HasCompleted) {
                SleepIfNotInPlaybackMode();
                releaseOperation.UpdateStatus();
            }
        }

        // This is used to make it easier to track in the reservation state.
        // It allows us to add and remove numbers from the reservation without affecting the initial state.
        private PhoneNumbersReservation CopyReservation(PhoneNumbersReservation reservation)
        {
            var newReservation = PhoneNumbersModelFactory.PhoneNumbersReservation(id: reservation.Id, expiresAt: reservation.ExpiresAt, status: reservation.Status);
            new PhoneNumbersReservation(reservation.Id);
            foreach (var number in reservation.PhoneNumbers)
            {
                newReservation.PhoneNumbers.Add(number.Key, number.Value);
            }
            return newReservation;
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
