# Searching, reserving, purchasing, releasing phone numbers

This sample demonstrates how to search, reserve, purchase and release phone numbers in Azure Communication Services.
To get started, you'll need a URI to an Azure Communication Services. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/communication/Azure.Communication.PhoneNumbers/README.md) for links and instructions.

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
var capabilities = new PhoneNumberCapabilities(calling:PhoneNumberCapabilityType.None, sms:PhoneNumberCapabilityType.Outbound);

var searchOperation = client.StartSearchAvailablePhoneNumbers(countryCode, PhoneNumberType.TollFree, PhoneNumberAssignmentType.Application, capabilities);

while (!searchOperation.HasCompleted)
{
    Thread.Sleep(2000);
    searchOperation.UpdateStatus();
}
```

## Purchase phone numbers

Phone numbers can be acquired through purchasing a reservation.

```C# Snippet:StartPurchaseSearch
var purchaseOperation = client.StartPurchasePhoneNumbers(searchOperation.Value.SearchId);

while (!purchaseOperation.HasCompleted)
{
    Thread.Sleep(2000);
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
var updateCapabilitiesOperation = client.StartUpdateCapabilities(purchasedPhoneNumber, calling:PhoneNumberCapabilityType.Outbound, sms:PhoneNumberCapabilityType.InboundOutbound);

while (!updateCapabilitiesOperation.HasCompleted)
{
    Thread.Sleep(2000);
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
    releaseOperation.UpdateStatus();
}
```
