# Release History

## 1.1.0-beta.1 (Unreleased)


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
