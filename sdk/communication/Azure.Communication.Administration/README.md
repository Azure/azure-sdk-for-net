# Azure Communication Administration client library for .NET

> Server Version:
> Identity client: 2020-07-20-preview2

> Phone number administration client: 2020-07-20-preview1

Azure Communication Administration is managing tokens and phone numbers for Azure Communication Services.

[Source code][source] | [Package (NuGet)][package] | [Product documentation][product_docs] | [Samples][source_samples]

## Getting started

### Install the package

Install the Azure Communication Administration client library for .NET with [NuGet][nuget]:

```Powershell
dotnet add package Azure.Communication.Administration --version 1.0.0-beta.3
```

### Prerequisites

You need an [Azure subscription][azure_sub] and a [Communication Service Resource][communication_resource_docs] to use this package.

To create a new Communication Service, you can use the [Azure Portal][communication_resource_create_portal], the [Azure PowerShell][communication_resource_create_power_shell], or the [.NET management client library][communication_resource_create_net].

<!--
Here's an example using the Azure CLI:

```Powershell
[To be ADDED]
```
-->

### Authenticate the client

Administration clients can be authenticated using connection string acquired from an Azure Communication Resources in the [Azure Portal][azure_portal].

```C# Snippet:CreateCommunicationIdentityClient
// Get a connection string to our Azure Communication resource.
var connectionString = "<connection_string>";
var client = new CommunicationIdentityClient(connectionString);
```

Clients also have the option to authenticate using a valid token.

```C# Snippet:CreateCommunicationIdentityFromToken
var endpoint = "<endpoint_url>";
TokenCredential tokenCredential = new DefaultAzureCredential();
var client = new CommunicationIdentityClient(new Uri(endpoint), tokenCredential);
```

### Key concepts

`CommunicationIdentityClient` provides the functionalities to manage user access tokens: creating new ones, renewing and revoking them.

## Examples

### Create a new identity

```C# Snippet:CreateCommunicationUserAsync
Response<CommunicationUserIdentifier> userResponse = await client.CreateUserAsync();
CommunicationUserIdentifier user = userResponse.Value;
Console.WriteLine($"User id: {user.Id}");
```

### Issuing or Refreshing a token for an existing identity

```C# Snippet:CreateCommunicationTokenAsync
Response<CommunicationUserToken> tokenResponse = await client.IssueTokenAsync(user, scopes: new[] { CommunicationTokenScope.Chat });
string token = tokenResponse.Value.Token;
DateTimeOffset expiresOn = tokenResponse.Value.ExpiresOn;
Console.WriteLine($"Token: {token}");
Console.WriteLine($"Expires On: {expiresOn}");
```

### Revoking a user's tokens

In case a user's tokens are compromised or need to be revoked:

```C# Snippet:RevokeCommunicationUserToken
Response revokeResponse = client.RevokeTokens(
    user,
    issuedBefore: DateTimeOffset.UtcNow.AddDays(-1) /* optional */);
```

### Deleting a user

```C# Snippet:DeleteACommunicationUser
Response deleteResponse = client.DeleteUser(user);
```

## Troubleshooting

All User token service operations will throw a RequestFailedException on failure.

```C# Snippet:CommunicationIdentityClient_Troubleshooting
// Get a connection string to our Azure Communication resource.
var connectionString = "<connection_string>";
var client = new CommunicationIdentityClient(connectionString);

try
{
    Response<CommunicationUserIdentifier> response = await client.CreateUserAsync();
}
catch (RequestFailedException ex)
{
    Console.WriteLine(ex.Message);
}
```

### Phone plans overview

Phone plans come in two types; Geographic and Toll-Free. Geographic phone plans are phone plans associated with a location, whose phone numbers' area codes are associated with the area code of a geographic location. Toll-Free phone plans are phone plans not associated location. For example, in the US, toll-free numbers can come with area codes such as 800 or 888.

All geographic phone plans within the same country are grouped into a phone plan group with a Geographic phone number type. All Toll-Free phone plans within the same country are grouped into a phone plan group.

### Reserving and acquiring numbers

Phone numbers reservation can be performed through the reservation creation API by providing a phone plan id, an area code and quantity of phone numbers. The provided quantity of phone numbers will be reserved for ten minutes. This reservation of phone numbers can either be cancelled or purchased. If the reservation is cancelled, then the phone numbers will become available to others. If the reservation is purchased, then the phone numbers are acquired for the Azure resources.

### Configuring / Assigning numbers

Phone numbers can be assigned to a callback URL via the configure number API. As part of the configuration, you will need an acquired phone number, callback URL and application id.

## Examples

### Get list of the countries that are supported by the service

```C#
string connectionString = "<connection_string>";
PhoneNumberAdministrationClient client = new PhoneNumberAdministrationClient(connectionString);
Pageable<PhoneNumberCountry> countries = client.GetAllSupportedCountries();

foreach (var country in countries)
{
    Console.WriteLine($"Country code {country.CountryCode}, Country name: {country.LocalizedName}");
}
```

### Get phone plan groups

Phone plan groups come in two types, Geographic and Toll-Free.

```C#
var phonePlanGroups = client.GetPhonePlanGroups(countryCode);

foreach (var group in phonePlanGroups)
{
    Console.WriteLine($"PhonePlanGroupId {group.PhonePlanGroupId}, Name: {group.LocalizedName}, PhoneNumberType: {group.PhoneNumberType}");
}
```

### Get phone plans

Unlike Toll-Free phone plans, area codes for Geographic Phone Plans are empty. Area codes are found in the Area Codes API.

```C#
var phonePlans = client.GetPhonePlans(countryCode, planGroupId);

foreach (var plan in phonePlans)
{
    Console.WriteLine($"PhonePlanId {plan.PhonePlanId}, Name: {plan.LocalizedName}");
    Console.WriteLine("Top 10 area codes");
    foreach (var areaCode in plan.AreaCodes.Take(10).ToList())
    {
        Console.WriteLine($"Area code: {areaCode}");
    }
}
```

### Get location options

For Geographic phone plans, you can query the available geographic locations. The locations options are structured like the geographic hierarchy of a country. For example, the US has states and within each state are cities.

```C#
var locationOptionsResponse = client.GetPhonePlanLocationOptions(countryCode, phonePlanGroupId, phonePlanId);
var locationOprions = locationOptionsResponse.Value.LocationOptions;

Console.WriteLine($"LabelId: {locationOprions.LabelId}, LabelName: {locationOprions.LabelName}");
foreach(var locationOption in locationOprions.Options)
{
    Console.WriteLine($"Name: {locationOption.Name}, Value: {locationOption.Value}");
}
```

### Get area codes

Fetching area codes for geographic phone plans will require the the location options queries set. You must include the chain of geographic locations traversing down the location options object returned by the GetLocationOptions API.

```C#
var areaCodesResponse = client.GetAllAreaCodes(locationType, countryCode, planId, locationOptionsQueries);
var areaCodes = areaCodesResponse.Value;

foreach(var primaryAreaCode in areaCodes.PrimaryAreaCodes)
{
    Console.WriteLine("Primary area code" + primaryAreaCode);
}

foreach (var secondaryAreaCode in areaCodes.SecondaryAreaCodes)
{
    Console.WriteLine("Secondary area code" + secondaryAreaCode);
}
```

### Create reservation

```C#
var reservationOptions = new CreateReservationOptions(displayName, description, plans, areaCode) { Quantity = 1 };
var reservationOperation = await client.StartReservationAsync(reservationOptions).ConfigureAwait(false);
var reservationResponse = await reservationOperation.WaitForCompletionAsync().ConfigureAwait(false);

Console.WriteLine($"ReservationId: {reservationResponse.Value.ReservationId}, Status {reservationResponse.Value.Status}");
```

### Purchase reservation

```C#
var reservationPurchaseOperation = await client.StartPurchaseReservationAsync(reservationId).ConfigureAwait(false);
await reservationPurchaseOperation.WaitForCompletionAsync().ConfigureAwait(false);
```

### Configure phone number

```C#
var pstnConfiguration = new PstnConfiguration("<url>");
var phoneNumber = new PhoneNumber("<phone_number>");
client.ConfigureNumber(pstnConfiguration, phoneNumber);
```

### Release phone numbers

```C#
var releasePhoneNumberOperation = await client.StartReleasePhoneNumbersAsync(numbers).ConfigureAwait(false);
await releasePhoneNumberOperation.WaitForCompletionAsync().ConfigureAwait(false);

Console.WriteLine($"ReleaseId: {releasePhoneNumberOperation.Value.ReleaseId}, Status: {releasePhoneNumberOperation.Value.Status}");
```

## Next steps

[Read more about Communication user access tokens][user_access_token]

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [cla.microsoft.com][cla].

This project has adopted the [Microsoft Open Source Code of Conduct][coc]. For more information see the [Code of Conduct FAQ][coc_faq] or contact [opencode@microsoft.com][coc_contact] with any additional questions or comments.

<!-- LINKS -->

[azure_sub]: https://azure.microsoft.com/free/
[azure_portal]: https://portal.azure.com
[source]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/communication/Azure.Communication.Administration/src
[source_samples]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/communication/Azure.Communication.Administration/samples
[cla]: https://cla.microsoft.com
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com
[package]: https://www.nuget.org/packages/Azure.Communication.Administration
[product_docs]: https://docs.microsoft.com/azure/communication-services/overview
[nuget]: https://www.nuget.org/
[user_access_token]: https://docs.microsoft.com/azure/communication-services/quickstarts/access-tokens?pivots=programming-language-csharp
[communication_resource_docs]: https://docs.microsoft.com/azure/communication-services/quickstarts/create-communication-resource?tabs=windows&pivots=platform-azp
[communication_resource_create_portal]: https://docs.microsoft.com/azure/communication-services/quickstarts/create-communication-resource?tabs=windows&pivots=platform-azp
[communication_resource_create_power_shell]: https://docs.microsoft.com/powershell/module/az.communication/new-azcommunicationservice
[communication_resource_create_net]: https://docs.microsoft.com/azure/communication-services/quickstarts/create-communication-resource?tabs=windows&pivots=platform-net
