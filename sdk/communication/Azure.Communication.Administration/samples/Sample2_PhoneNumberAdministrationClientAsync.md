# Searching, reserving, purchasing, releasing phone numbers (Async)

This sample demonstrates how to search, reserve, purchase and release phone numbers in Azure Communication Services.
To get started, you'll need a URI to an Azure Communication Services. See the [README](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/communication/Azure.Communication.Administration/README.md) for links and instructions.

## Creating a PhoneNumberAdministrationClient

To create a new `PhoneNumberAdministrationClient` you need a connection string to the Azure Communication Services resource that you can get from the Azure Portal once you have created the resource.

You can set `connectionString` based on an environment variable, a configuration setting, or any way that works for your application.

```C# Snippet:CreatePhoneNumberAdministrationClient
// Get a connection string to our Azure Communication resource.
var connectionString = "<connection_string>";
var client = new PhoneNumberAdministrationClient(connectionString);
```

## Listing all supported countries

In order to acquire a phone number you will need to know if Azure Communication Services are available in a particular country. You can find out by retrieving a list of supported countries.

```C# Snippet:GetAllSupportedCountriesAsync
var supportedCountries = client.GetAllSupportedCountriesAsync(locale);
await foreach (var country in supportedCountries)
{
    Console.WriteLine($"Supported country code: {country.CountryCode}, name: {country.LocalizedName}");
}
```

## Listing phone plan groups

Phone plan groups come in two types, Geographic and Toll-Free.

```C# Snippet:GetPhonePlanGroupsAsync
var phonePlanGroups = client.GetPhonePlanGroupsAsync(countryCode, locale);

await foreach (var phonePlanGroup in phonePlanGroups)
{
    Console.WriteLine($"Plan group: {phonePlanGroup.LocalizedName}, type: {phonePlanGroup.PhoneNumberType}");
}
```

## Listing phone plans

Unlike Toll-Free phone plans, area codes for Geographic phone plans are empty. Area codes are found in the Area Codes API.

```C# Snippet:GetPhonePlansAsync
var phonePlans = client.GetPhonePlansAsync(countryCode, phonePlanGroupId, locale);
await foreach (var phonePlan in phonePlans)
{
    Console.WriteLine($"Plan: {phonePlan.LocalizedName}, {phonePlan.LocationType}");
}
```

## Get location options

For Geographic phone plans, you can query the available geographic locations. The locations options are structured like the geographic hierarchy of a country. For example, the US has states and within each state are cities.

```C# Snippet:GetPhonePlanLocationOptionsAsync
var locationOptionsResponse = await client.GetPhonePlanLocationOptionsAsync(countryCode, geographicPhonePlanGroupId, phonePlanId);

void PrintLocationOption(LocationOptions locationOptions)
{
    Console.WriteLine($"LabelId: {locationOptions.LabelId}, LabelName: {locationOptions.LabelName}");

    foreach (var locationOption in locationOptions.Options)
    {
        Console.WriteLine($"Name: {locationOption.Name}, Value: {locationOption.Value}");

        foreach (var subLocationOption in locationOption.LocationOptions)
            PrintLocationOption(subLocationOption);
    }
}
PrintLocationOption(locationOptionsResponse.Value.LocationOptions);
```

## Get area codes

Fetching area codes for geographic phone plans will require the location options queries set. You must include the chain of geographic locations traversing down the location options object returned by the `GetPhonePlanLocationOptions`.

```C# Snippet:GeographicalAreaCodesAsync
var locationOptionsResponse = await client.GetPhonePlanLocationOptionsAsync(countryCode, geographicPhonePlanGroupId, geographicPhonePlanId);
var state = locationOptionsResponse.Value.LocationOptions.Options.First();

var locationOptionsQueries = new List<LocationOptionsQuery>
{
    new LocationOptionsQuery
    {
        LabelId = "state",
        OptionsValue = state.Value
    },
    new LocationOptionsQuery
    {
        LabelId = "city",
        OptionsValue = state.LocationOptions.First().Options.First().Value
    }
};

var areaCodes = await client.GetAllAreaCodesAsync(geographicPhonePlan.LocationType.ToString(), countryCode, geographicPhonePlan.PhonePlanId, locationOptionsQueries);

foreach (var areaCode in areaCodes.Value.PrimaryAreaCodes)
{
    Console.WriteLine($"Primary area code: {areaCode}");
}
```

Area codes for toll-free phone plans can be found in the plan.

```C# Snippet:TollFreePlanAreaCodesAsync
var phonePlans = client.GetPhonePlansAsync(countryCode, tollFreePhonePlanGroup.PhonePlanGroupId, locale);
var tollFreePhonePlan = (await phonePlans.ToEnumerableAsync()).First();

foreach (var areaCode in tollFreePhonePlan.AreaCodes)
{
    Console.WriteLine($"Area code: {areaCode}");
}
```

## Reserve phone numbers

Phone numbers need to be reserved before they can be purchased. Reservation is a long running operation that can be started by `CreateReservationOptions` function that returns an `PhoneNumberReservationOperation` object. `PhoneNumberReservationOperation` can be used to update status of the operation and to check for completeness.

```C# Snippet:ReservePhoneNumbersAsync
var reservationName = "My reservation";
var reservationDescription = "reservation description";
var reservationOptions = new CreateReservationOptions(reservationName, reservationDescription, new[] { phonePlanId }, areaCode);
reservationOptions.Quantity = 1;

var reserveOperation = await client.StartReservationAsync(reservationOptions);
await reserveOperation.WaitForCompletionAsync();
```

## Persist reserve phone numbers operation

You can persist the operation Id of the phone number reservation so that you can come back and check the operation status later.

```C# Snippet:PersistReservePhoneNumbersOperationAsync
var reservationId = reserveOperation.Id;

// persist reservationId and then continue with a new operation

var reserveOperation = new PhoneNumberReservationOperation(client, reservationId);
await reserveOperation.WaitForCompletionAsync();
```

## Purchase phone numbers

Phone numbers can be acquired through purchasing a reservation.

```C# Snippet:StartPurchaseReservationAsync
var purchaseOperation = await client.StartPurchaseReservationAsync(reservationId);
await purchaseOperation.WaitForCompletionAsync();
```

## Listing acquired phone numbers

You can list all phone numbers that have been acquired for your resource.

```C# Snippet:ListAcquiredPhoneNumbersAsync
var acquiredPhoneNumbers = client.GetAllPhoneNumbersAsync(locale);

await foreach (var phoneNumber in acquiredPhoneNumbers)
{
    Console.WriteLine($"Phone number: {phoneNumber.PhoneNumber}, activation state: {phoneNumber.ActivationState}");
}
```

## Release phone numbers

If you no longer need a phone number you can release it.

```C# Snippet:ReleasePhoneNumbersAsync
var acquiredPhoneNumber = "<acquired_phone_number>";
var releaseOperation = client.StartReleasePhoneNumber(new PhoneNumberIdentifier(acquiredPhoneNumber));
await releaseOperation.WaitForCompletionAsync();
```
