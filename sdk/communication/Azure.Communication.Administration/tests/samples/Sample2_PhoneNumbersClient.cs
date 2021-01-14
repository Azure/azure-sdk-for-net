// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Communication.Administration.Models;
using Azure.Communication.Administration.Tests;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Communication.Administration.Samples
{
    /// <summary>
    /// Basic Azure Communication Administration samples.
    /// </summary>
    public class Sample2_PhoneNumbersClient : PhoneNumbersClientLiveTestBase
    {
        public Sample2_PhoneNumbersClient(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        [AsyncOnly]
        public async Task PurchaseAndReleaseAsync()
        {
            if (!IncludePhoneNumberLiveTests)
                Assert.Ignore("Include phone number live tests flag is off.");

            var client = CreateClient(false);

            const string countryCode = "US";

            #region Snippet:StartSearchPhoneNumbersAsync

            PhoneNumberCapabilitiesRequest capabilitiesRequest = new PhoneNumberCapabilitiesRequest();
            capabilitiesRequest.Calling = PhoneNumberCapabilityValue.InboundOutbound;

            var searchOperation = await client.StartSearchAvailablePhoneNumbersAsync(countryCode, PhoneNumberType.Geographic, PhoneNumberAssignmentType.Person, capabilitiesRequest);
            await searchOperation.WaitForCompletionAsync();

            #endregion Snippet:ReservePhoneNumbersAsync

            #region Snippet:StartPurchaseReservationAsync

            var purchaseOperation = await client.StartPurchasePhoneNumbersAsync(searchOperation.Id);
            await purchaseOperation.WaitForCompletionAsync();

            #endregion Snippet:StartPurchaseReservationAsync

            #region Snippet:ListAcquiredPhoneNumbersAsync
            var acquiredPhoneNumbers = client.ListPhoneNumbersAsync();

            await foreach (var phoneNumber in acquiredPhoneNumbers)
            {
                Console.WriteLine($"Phone number: {phoneNumber.PhoneNumber}, monthly cost: {phoneNumber.Cost}");
            }
            #endregion Snippet:ListAcquiredPhoneNumbersAsync

            var acquiredPhoneNumber = acquiredPhoneNumbers.ToEnumerableAsync().Result.Single().PhoneNumber;
            acquiredPhoneNumbers = client.ListPhoneNumbersAsync();

            var beforeReleaseNumberCount = (await acquiredPhoneNumbers.ToEnumerableAsync()).Count;

            #region Snippet:ReleasePhoneNumbersAsync

            //@@var acquiredPhoneNumber = "<acquired_phone_number>";
            var releaseOperation = client.StartReleasePhoneNumber(acquiredPhoneNumber);
            await releaseOperation.WaitForCompletionAsync();

            #endregion Snippet:ReleasePhoneNumbersAsync

            acquiredPhoneNumbers = client.ListPhoneNumbersAsync();
            var afterReleaseNumberCount = (await acquiredPhoneNumbers.ToEnumerableAsync()).Count;
            Assert.AreEqual(1, beforeReleaseNumberCount - afterReleaseNumberCount);
        }

        [Test]
        [SyncOnly]
        public void PurchaseAndRelease()
        {
            if (!IncludePhoneNumberLiveTests)
                Assert.Ignore("Include phone number live tests flag is off.");

            var connectionString = TestEnvironment.ConnectionString;

            #region Snippet:CreatePhoneNumbersClient
            // Get a connection string to our Azure Communication resource.
            //@@var connectionString = "<connection_string>";
            var client = new PhoneNumbersClient(connectionString);
            #endregion Snippet:CreatePhoneNumbersClient

            client = CreateClient(false);

            const string countryCode = "US";

            #region Snippet:SearchPhoneNumbers

            PhoneNumberCapabilitiesRequest capabilitiesRequest = new PhoneNumberCapabilitiesRequest();
            capabilitiesRequest.Calling = PhoneNumberCapabilityValue.InboundOutbound;

            var searchOperation = client.StartSearchAvailablePhoneNumbers(countryCode, PhoneNumberType.Geographic, PhoneNumberAssignmentType.Person, capabilitiesRequest);

            while (!searchOperation.HasCompleted)
            {
                Thread.Sleep(2000);

                searchOperation.UpdateStatus();
            }

            #endregion Snippet:SearchPhoneNumbers

            #region Snippet:StartPurchaseSearch
            var purchaseOperation = client.StartPurchasePhoneNumbers(searchOperation.Id);

            while (!purchaseOperation.HasCompleted)
            {
                Thread.Sleep(2000);

                purchaseOperation.UpdateStatus();
            }
            #endregion Snippet:StartPurchaseSearch

            #region Snippet:ListAcquiredPhoneNumbers
            var acquiredPhoneNumbers = client.ListPhoneNumbers();

            foreach (var phoneNumber in acquiredPhoneNumbers)
            {
                Console.WriteLine($"Phone number: {phoneNumber.PhoneNumber}, monthly cost: {phoneNumber.Cost}");
            }
            #endregion Snippet:ListAcquiredPhoneNumbers

            var acquiredPhoneNumber = searchOperation.Value.PhoneNumbers.Single();
            acquiredPhoneNumbers = client.ListPhoneNumbers();
            var beforeReleaseNumberCount = acquiredPhoneNumbers.Count();

            #region Snippet:ReleasePhoneNumbers
            //@@var acquiredPhoneNumber = "<acquired_phone_number>";
            var releaseOperation = client.StartReleasePhoneNumber(acquiredPhoneNumber);

            while (!releaseOperation.HasCompleted)
            {
                Thread.Sleep(2000);

                releaseOperation.UpdateStatus();
            }
            #endregion Snippet:ReleasePhoneNumbers

            acquiredPhoneNumbers = client.ListPhoneNumbers();
            var afterReleaseNumberCount = acquiredPhoneNumbers.Count();
            Assert.AreEqual(1, beforeReleaseNumberCount - afterReleaseNumberCount);
        }
    }
}
