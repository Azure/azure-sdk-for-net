# Searching, reserving, purchasing, releasing phone numbers (Async)

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

```C# Snippet:SearchPhoneNumbersAsync
var capabilities = new PhoneNumberCapabilities(calling: PhoneNumberCapabilityType.None, sms: PhoneNumberCapabilityType.Outbound);

var searchOperation = await client.StartSearchAvailablePhoneNumbersAsync(countryCode, PhoneNumberType.TollFree, PhoneNumberAssignmentType.Application, capabilities);
await searchOperation.WaitForCompletionAsync();
```

## Purchase phone numbers

Phone numbers can be acquired through purchasing a reservation.

```C# Snippet:StartPurchaseSearchAsync
var purchaseOperation = await client.StartPurchasePhoneNumbersAsync(searchOperation.Value.SearchId);
await purchaseOperation.WaitForCompletionResponseAsync();
```

## Listing purchased phone numbers

You can list all phone numbers that have been acquired for your resource.

```C# Snippet:GetPurchasedPhoneNumbersAsync
var purchasedPhoneNumbers = client.GetPurchasedPhoneNumbersAsync();

await foreach (var phoneNumber in purchasedPhoneNumbers)
{
    Console.WriteLine($"Phone number: {phoneNumber.PhoneNumber}, monthly cost: {phoneNumber.Cost}");
}
```

## Update phone number capabilities

Phone number's capabilities can be updated by started by `StartUpdateCapabilities` function.

```C# Snippet:UpdateCapabilitiesNumbersAsync
var updateCapabilitiesOperation = await client.StartUpdateCapabilitiesAsync(purchasedPhoneNumber, calling: PhoneNumberCapabilityType.Outbound, sms: PhoneNumberCapabilityType.InboundOutbound);

await updateCapabilitiesOperation.WaitForCompletionAsync();
```

## Release phone numbers

If you no longer need a phone number you can release it.

```C# Snippet:ReleasePhoneNumbersAsync
var purchasedPhoneNumber = "<purchased_phone_number>";
var releaseOperation = await client.StartReleasePhoneNumberAsync(purchasedPhoneNumber);
await releaseOperation.WaitForCompletionResponseAsync();
await WaitForCompletionResponseAsync(releaseOperation);
```

## Browse available phone numbers

You can find phone numbers available for purchase without reserving them by using the Browse API.

```C# Snippet:BrowseAvailablePhoneNumbersAsync
var browseRequest = new PhoneNumbersBrowseOptions("US", PhoneNumberType.TollFree);
var browseResponse = await client.BrowseAvailableNumbersAsync(browseRequest);
var availablePhoneNumbers = browseResponse.Value.PhoneNumbers;
```

## Create a reservation

Once you find a phone number you want to purchase, you can create a reservation for it.

```C# Snippet:CreateReservationAsync
// Reserve the first two available phone numbers.
var phoneNumbersToReserve = availablePhoneNumbers.Take(2).ToList();

// The reservation ID needs to be a unique GUID.
var reservationId = Guid.NewGuid();

var request = new CreateOrUpdateReservationOptions(reservationId)
{
    PhoneNumbersToAdd = phoneNumbersToReserve
};
var response = await client.CreateOrUpdateReservationAsync(request);
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

```C# Snippet:StartPurchaseReservationAsync
var purchaseReservationOperation = await client.StartPurchaseReservationAsync(reservationId);
await purchaseReservationOperation.WaitForCompletionResponseAsync();
```

## Validate reservation purchase

Similarly to the Create or Update Reservation operation, the Purchase Reservation operation may also produce partial failures.

```C# Snippet:ValidateReservationPurchaseAsync
var purchasedReservationResponse = await client.GetReservationAsync(reservationId);
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
