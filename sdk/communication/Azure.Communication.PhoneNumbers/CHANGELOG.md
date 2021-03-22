# Release History

## 1.0.0-beta.6 (Unreleased)

### Breaking Changes
- AcquiredPhoneNumber class is renamed to PurchasedPhoneNumber.
- PhoneNumbersClient methods renamed:
  - GetPhoneNumber -> GetPurchasedPhoneNumber.
  - GetPhoneNumberAsync -> GetPurchasedPhoneNumberAsync.
  - GetPhoneNumbers -> GetPurchasedPhoneNumbers.
  - GetPhoneNumbersAsync -> GetPurchasedPhoneNumbersAsync.
- PhoneNumbersModelFactory static method AcquiredPhoneNumber is renamed to PurchasedPhoneNumber.
- PurchasePhoneNumbersOperation extends Operation<PurchasePhoneNumbersResult> instead of Operation<Response>.
- ReleasePhoneNumberOperation extends Operation<ReleasePhoneNumberResult> instead of Operation<Response>.

## 1.0.0-beta.5 (2021-03-09)

### Added
- Added PhoneNumbersClient (originally was part of the Azure.Communication.Administration package).
- Added support for Azure Active Directory Authentication.



### Breaking Changes
- PhoneNumberAdministrationClient has been replaced with PhoneNumbersClient, which has the same functionality but different APIs. To learn more about how PhoneNumbersClient works, refer to the [README.md][read_me]

<!-- LINKS -->
[read_me]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/communication/Azure.Communication.PhoneNumbers/README.md
[documentation]: https://docs.microsoft.com/azure/communication-services/quickstarts/access-tokens?pivots=programming-language-csharp
