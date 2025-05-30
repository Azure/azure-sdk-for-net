# Searching, reserving, purchasing, releasing phone numbers

This sample demonstrates how to search, reserve, purchase and release phone numbers in Azure Communication Services.
To get started, you'll need a URI to an Azure Communication Services. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/communication/Azure.Communication.PhoneNumbers/README.md) for links and instructions.

## Creating a PhoneNumbersClient

To create a new `PhoneNumbersClient` you need a connection string to the Azure Communication Services resource that you can get from the Azure Portal once you have created the resource.

You can set `connectionString` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:CreatePhoneNumbersClient
// Get a connection string to our Azure Communication resource.
var connectionString = "<connection_string>";
var client = new PhoneNumbersClient(connectionString);
```

## Search phone numbers

Phone numbers need to be searched before they can be purchased. Search is a long running operation that can be started by `StartSearchAvailablePhoneNumbers` function that returns an `SearchAvailablePhoneNumbersOperation` object. `SearchAvailablePhoneNumbersOperation` can be used to update status of the operation and to check for completeness.

```C# Snippet:SearchPhoneNumbers
var capabilities = new PhoneNumberCapabilities(calling: PhoneNumberCapabilityType.None, sms: PhoneNumberCapabilityType.Outbound);

var searchOperation = client.StartSearchAvailablePhoneNumbers(countryCode, PhoneNumberType.TollFree, PhoneNumberAssignmentType.Application, capabilities);

while (!searchOperation.HasCompleted)
{
    Thread.Sleep(2000);
    SleepIfNotInPlaybackMode();
    searchOperation.UpdateStatus();
}
```

## Purchase phone numbers

Phone numbers can be acquired through purchasing a search.

```C# Snippet:StartPurchaseSearch
var purchaseOperation = client.StartPurchasePhoneNumbers(searchOperation.Value.SearchId);
while (!purchaseOperation.HasCompleted)
{
    Thread.Sleep(2000);
    SleepIfNotInPlaybackMode();
    purchaseOperation.UpdateStatus();
}
```

## Listing purchased phone numbers

You can list all phone numbers that have been acquired for your resource.

```C# Snippet:GetPurchasedPhoneNumbers
var purchasedPhoneNumbers = client.GetPurchasedPhoneNumbers();

foreach (var phoneNumber in purchasedPhoneNumbers)
{
    Console.WriteLine($"Phone number: {phoneNumber.PhoneNumber}, monthly cost: {phoneNumber.Cost}");
}
```

## Update phone number capabilities

Phone number's capabilities can be updated by started by `StartUpdateCapabilities` function.

```C# Snippet:UpdateCapabilitiesNumbers
var updateCapabilitiesOperation = client.StartUpdateCapabilities(purchasedPhoneNumber, calling: PhoneNumberCapabilityType.Outbound, sms: PhoneNumberCapabilityType.InboundOutbound);

while (!updateCapabilitiesOperation.HasCompleted)
{
    Thread.Sleep(2000);
    SleepIfNotInPlaybackMode();
    updateCapabilitiesOperation.UpdateStatus();
}
```

## Release phone numbers

If you no longer need a phone number you can release it.

```C# Snippet:ReleasePhoneNumbers
var purchasedPhoneNumber = "<purchased_phone_number>";
var releaseOperation = client.StartReleasePhoneNumber(purchasedPhoneNumber);

while (!releaseOperation.HasCompleted)
{
    Thread.Sleep(2000);
    SleepIfNotInPlaybackMode();
    releaseOperation.UpdateStatus();
}
```

## Browse available phone numbers

You can find phone numbers available for purchase without reserving them by using the Browse API.

```C# Snippet:BrowseAvailablePhoneNumbers
var browseRequest = new PhoneNumbersBrowseOptions("US", PhoneNumberType.TollFree);
var browseResponse = client.BrowseAvailableNumbers(browseRequest);
var availablePhoneNumbers = browseResponse.Value.PhoneNumbers;
```

## Create a reservation

Once you find a phone number you want to purchase, you can create a reservation for it.

```C# Snippet:CreateReservation
// Reserve the first two available phone numbers.
var phoneNumbersToReserve = availablePhoneNumbers.Take(2).ToList();

// The reservation ID needs to be a unique GUID.
var reservationId = Guid.NewGuid();

var request = new CreateOrUpdateReservationOptions(reservationId)
{
    PhoneNumbersToAdd = phoneNumbersToReserve
};
var response = client.CreateOrUpdateReservation(request);
var reservation = response.Value;
```

## Checking for partial failures

The Reservations API may produce partial failures, even if the operation itself is successful.
Look at the `Error` property of each phone number to check for partial failures.

```C# Snippet:CheckForPartialFailure
var phoneNumbersWithError = reservation.PhoneNumbers.Values
    .Where(n => n.Status == PhoneNumberAvailabilityStatus.Error);

if (phoneNumbersWithError.Any())
{
    // Handle the error for the phone numbers that failed to reserve.
    foreach (var phoneNumber in phoneNumbersWithError)
    {
        Console.WriteLine($"Failed to reserve phone number {phoneNumber.Id}. Error Code: {phoneNumber.Error?.Code} - Message: {phoneNumber.Error?.Message}");
    }
}
```

## Purchase a reservation

Once all the desired phone numbers are in a reservation, you can purchase the reservation.

```C# Snippet:StartPurchaseReservation
var purchaseReservationOperation = client.StartPurchaseReservation(reservationId);
purchaseReservationOperation.WaitForCompletionResponse();
```

## Validate reservation purchase

Similarly to the Create or Update Reservation operation, the Purchase Reservation operation may also produce partial failures.

```C# Snippet:ValidateReservationPurchase
var purchasedReservationResponse = client.GetReservation(reservationId);
var purchasedReservation = purchasedReservationResponse.Value;

var failedPhoneNumbers = purchasedReservation.PhoneNumbers.Values
    .Where(n => n.Status == PhoneNumberAvailabilityStatus.Error);

if (failedPhoneNumbers.Any())
{
    // Handle the error for the phone numbers that failed to reserve.
    foreach (var phoneNumber in failedPhoneNumbers)
    {
        Console.WriteLine($"Failed to purchase phone number {phoneNumber.Id}. Error Code: {phoneNumber.Error?.Code} - Message: {phoneNumber.Error?.Message}");
    }
}
```
