# Release History

## 1.2.0-beta.2 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.2.0-beta.1 (2023-08-08)

### Features Added
- Added custom page sizes to PurchasedPhoneNumbers, Countries, Localities, AreaCodes and Offerings. 

## 1.1.0 (2023-03-28)

### Features Added
- Added support for SIP routing API version `2023-03-01`, releasing SIP routing functionality from public preview to GA.
- Added environment variable `AZURE_TEST_DOMAIN` for SIP routing tests to support domain verification.

## 1.1.0-beta.3 (2023-01-10)
- Adds support for Azure Communication Services Phone Numbers Browse API Methods.

### Features Added
- Added support for API version `2022-12-01`, giving users the ability to: 
  - Get all supported countries
  - Get all supported localities given a country code.
  - Get all Toll-Free area codes from a given country code.
  - Get all Geographic area codes from a given country code / locality.
  - Get all offerings from a given country code.
- Added new SIP routing client for handling Direct routing numbers.

## 1.1.0-beta.2 (2022-03-30)
### Features Added
- Added environment variable `AZURE_USERAGENT_OVERRIDE`, that overrides the HTTP header `x-ms-useragent` on the tests

### Other Changes
- 'Deprecates' (read discourage) the use of PhoneNumbersModelFactory.PhoneNumberCost(double amount, string currencyCode, string billingFrequency)

## 1.1.0-beta.1 (2022-01-24)
### Features Added
- Add support of Denmark (DK) and United Kingdom (GB) phone number acquisitions.

## 1.0.2 (2021-10-05)
- Dependency versions updated.

## 1.0.1 (2021-05-25)
- Dependency versions updated.

## 1.0.0 (2021-04-26)
Updated `Azure.Communication.PhoneNumbers` version.

## 1.0.0-beta.6 (2021-03-29)

### Added
- Added protected constructor to PurchasePhoneNumbersOperation and ReleasePhoneNumberOperation for mocking.

### Breaking Changes
- All models are moved from Azure.Communication.PhoneNumbers.Models namespace to Azure.Communication.PhoneNumbers.
- AcquiredPhoneNumber class is renamed to PurchasedPhoneNumber.
- PhoneNumbersClient methods renamed:
  - GetPhoneNumber -> GetPurchasedPhoneNumber.
  - GetPhoneNumberAsync -> GetPurchasedPhoneNumberAsync.
  - GetPhoneNumbers -> GetPurchasedPhoneNumbers.
  - GetPhoneNumbersAsync -> GetPurchasedPhoneNumbersAsync.
- PhoneNumbersModelFactory static method AcquiredPhoneNumber is renamed to PurchasedPhoneNumber.
- PurchasePhoneNumbersOperation and ReleasePhoneNumberOperation extend Operation instead of Operation<Response>.
- Removed PhoneNumberOperationStatus and PhoneNumberOperationType.
- Renamed ISOCurrencySymbol property to IsoCurrencySymbol in PhoneNumberCost.
- Renamed threeLetterISOCountryName parameter to twoLetterIsoCountryName in PhoneNumbersClient.StartSearchAvailablePhoneNumbers and PhoneNumbersClient.StartSearchAvailablePhoneNumbersAsync.

## 1.0.0-beta.5 (2021-03-09)

### Added
- Added PhoneNumbersClient (originally was part of the Azure.Communication.Administration package).
- Added support for Azure Active Directory Authentication.

### Breaking Changes
- PhoneNumberAdministrationClient has been replaced with PhoneNumbersClient, which has the same functionality but different APIs. To learn more about how PhoneNumbersClient works, refer to the [README.md][read_me]

<!-- LINKS -->
[read_me]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/communication/Azure.Communication.PhoneNumbers/README.md
[documentation]: https://docs.microsoft.com/azure/communication-services/quickstarts/access-tokens?pivots=programming-language-csharp
