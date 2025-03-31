// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Communication.Tests;
using Azure.Core.TestFramework;
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

        /// <summary>
        /// Initializes a new instance of <see cref="PhoneNumbersReservationsTests" />.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public PhoneNumbersReservationsTests(bool isAsync) : base(isAsync)
        {
        }

        [TestCase]
        [AsyncOnly]
        [Order(0)] // This is run first to ensure that at least one active reservation exists before running the tests.
        public async Task CreateReservationAsync()
        {
            PhoneNumbersClient client = CreateClient(AuthMethod.ConnectionString);
            var reservationId = Guid.NewGuid();
            var reservation = new PhoneNumbersReservation(reservationId, new Dictionary<string, AvailablePhoneNumber>());

            var reservationResponse = await client.CreateOrUpdateReservationAsync(reservation).ConfigureAwait(false);

            // The response should be a 201 Created.
            Assert.AreEqual(201, reservationResponse.GetRawResponse().Status);
            Assert.IsNotNull(reservationResponse.Value);
            Assert.AreEqual(reservationId, reservationResponse.Value.Id);
            Assert.AreEqual(ReservationStatus.Active, reservationResponse.Value.Status);
            Assert.Greater(reservationResponse.Value.ExpiresAt, DateTimeOffset.UtcNow);
            Assert.IsEmpty(reservationResponse.Value.PhoneNumbers);

            _initialReservationState = reservationResponse.Value;
        }

        [TestCase]
        [SyncOnly]
        [Order(0)] // This is run first to ensure that at least one active reservation exists before running the tests.
        public void CreateReservation()
        {
            PhoneNumbersClient client = CreateClient(AuthMethod.ConnectionString);
            var reservationId = Guid.NewGuid();
            var reservation = new PhoneNumbersReservation(reservationId, new Dictionary<string, AvailablePhoneNumber>());

            var reservationResponse = client.CreateOrUpdateReservation(reservation);

            // The response should be a 201 Created.
            Assert.AreEqual(201, reservationResponse.GetRawResponse().Status);
            Assert.IsNotNull(reservationResponse.Value);
            Assert.AreEqual(reservationId, reservationResponse.Value.Id);
            Assert.AreEqual(ReservationStatus.Active, reservationResponse.Value.Status);
            Assert.Greater(reservationResponse.Value.ExpiresAt, DateTimeOffset.UtcNow);
            Assert.IsEmpty(reservationResponse.Value.PhoneNumbers);

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

            // Reserve the first two available phone numbers.
            var phoneNumbersToReserve = availablePhoneNumbers
                .Take(2)
                .ToList();

            var reservationBeforeAdd = CreateReservationFrom(_initialReservationState!);
            phoneNumbersToReserve
                .ForEach(number => reservationBeforeAdd.PhoneNumbers.Add(number.Id, number));

            var reservationResponse = await client.CreateOrUpdateReservationAsync(reservationBeforeAdd).ConfigureAwait(false);
            var reservationAfterAdd = reservationResponse.Value;

            Assert.IsNotNull(reservationAfterAdd);
            Assert.AreEqual(_initialReservationState!.Id, reservationAfterAdd.Id);
            Assert.AreEqual(ReservationStatus.Active, reservationAfterAdd.Status);
            Assert.Greater(reservationAfterAdd.ExpiresAt, _initialReservationState.ExpiresAt);
            Assert.IsTrue(reservationAfterAdd.PhoneNumbers.Values.All(number => number.Status != AvailablePhoneNumberStatus.Error));
            // All numbers in the request should be in the reservation.
            Assert.IsTrue(phoneNumbersToReserve.Select(n => n.Id).All(reservationAfterAdd.PhoneNumbers.ContainsKey));

            // Now remove the reserved numbers
            var phoneNumbersToRemove = phoneNumbersToReserve
                .Select(number => number.Id)
                .ToList();
            var reservationBeforeRemove = CreateReservationFrom(reservationAfterAdd);
            phoneNumbersToRemove
                .ForEach(number => reservationBeforeRemove.PhoneNumbers.Remove(number));

            reservationResponse = await client.CreateOrUpdateReservationAsync(reservationBeforeRemove).ConfigureAwait(false);
            var reservationAfterRemove = reservationResponse.Value;
            Assert.IsNotNull(reservationAfterRemove);
            Assert.AreEqual(_initialReservationState!.Id, reservationAfterRemove.Id);
            Assert.AreEqual(ReservationStatus.Active, reservationAfterRemove.Status);
            Assert.Greater(reservationAfterRemove.ExpiresAt, reservationAfterAdd.ExpiresAt);
            Assert.IsTrue(reservationAfterRemove.PhoneNumbers.Values.All(number => number.Status != AvailablePhoneNumberStatus.Error));
            // None of the numbers that were removed should be in the reservation.
            Assert.IsFalse(phoneNumbersToRemove.Any(reservationAfterRemove.PhoneNumbers.ContainsKey));
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

            // Reserve the first two available phone numbers.
            var phoneNumbersToReserve = availablePhoneNumbers
                .Take(2)
                .ToList();

            var reservationBeforeAdd = CreateReservationFrom(_initialReservationState!);
            phoneNumbersToReserve
                .ForEach(number => reservationBeforeAdd.PhoneNumbers.Add(number.Id, number));

            var reservationResponse = client.CreateOrUpdateReservation(reservationBeforeAdd);
            var reservationAfterAdd = reservationResponse.Value;

            Assert.IsNotNull(reservationAfterAdd);
            Assert.AreEqual(_initialReservationState!.Id, reservationAfterAdd.Id);
            Assert.AreEqual(ReservationStatus.Active, reservationAfterAdd.Status);
            Assert.Greater(reservationAfterAdd.ExpiresAt, _initialReservationState.ExpiresAt);
            Assert.IsTrue(reservationAfterAdd.PhoneNumbers.Values.All(number => number.Status != AvailablePhoneNumberStatus.Error));
            // All numbers in the request should be in the reservation.
            Assert.IsTrue(phoneNumbersToReserve.Select(n => n.Id).All(reservationAfterAdd.PhoneNumbers.ContainsKey));

            // Now remove the reserved numbers
            var phoneNumbersToRemove = phoneNumbersToReserve
                .Select(number => number.Id)
                .ToList();
            var reservationBeforeRemove = CreateReservationFrom(reservationAfterAdd);
            phoneNumbersToRemove
                .ForEach(number => reservationBeforeRemove.PhoneNumbers.Remove(number));

            reservationResponse = client.CreateOrUpdateReservation(reservationBeforeRemove);
            var reservationAfterRemove = reservationResponse.Value;

            Assert.IsNotNull(reservationAfterRemove);
            Assert.AreEqual(_initialReservationState!.Id, reservationAfterRemove.Id);
            Assert.AreEqual(ReservationStatus.Active, reservationAfterRemove.Status);
            Assert.Greater(reservationAfterRemove.ExpiresAt, reservationAfterAdd.ExpiresAt);
            Assert.IsTrue(reservationAfterRemove.PhoneNumbers.Values.All(number => number.Status != AvailablePhoneNumberStatus.Error));
            // None of the numbers that were removed should be in the reservation.
            Assert.IsFalse(phoneNumbersToRemove.Any(reservationAfterRemove.PhoneNumbers.ContainsKey));
        }

        [TestCase]
        [AsyncOnly]
        [Order(3)] // This test is executed after tests that depend on the initial reservation state.
        public async Task DeleteReservationAsync()
        {
            PhoneNumbersClient client = CreateClient(AuthMethod.ConnectionString);

            await client.DeleteReservationAsync(_initialReservationState!.Id);

            var exception = Assert.ThrowsAsync<RequestFailedException>(async () => await client.GetReservationAsync(_initialReservationState!.Id));
            Assert.AreEqual(404, exception!.Status);
        }

        [TestCase]
        [SyncOnly]
        [Order(3)] // This test is executed after tests that depend on the initial reservation state.
        public void DeleteReservation()
        {
            PhoneNumbersClient client = CreateClient(AuthMethod.ConnectionString);

            client.DeleteReservation(_initialReservationState!.Id);

            var exception = Assert.Throws<RequestFailedException>(() => client.GetReservation(_initialReservationState!.Id));
            Assert.AreEqual(404, exception!.Status);
        }

        // This is used to make it easier to track in the reservation state.
        // It allows us to add and remove numbers from the reservation without affecting the initial state.
        private PhoneNumbersReservation CreateReservationFrom(PhoneNumbersReservation reservation)
        {
            var newReservation = new PhoneNumbersReservation(reservation.Id, new Dictionary<string, AvailablePhoneNumber>());
            foreach (var number in reservation.PhoneNumbers)
            {
                newReservation.PhoneNumbers.Add(number.Key, number.Value);
            }
            return newReservation;
        }
    }
}
