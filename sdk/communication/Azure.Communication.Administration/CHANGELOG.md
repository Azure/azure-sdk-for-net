# Release History

## 1.0.0-beta.4 (Unreleased)

### Added
- Added support to create CommunicationIdentityClient with TokenCredential
### Fixed
- Issue with paging results not pulling next pages


## 1.0.0-beta.3 (2020-11-16)

### Added
- Support for mocking all client methods that use models with internal constructors.
- Added support for long-running operations. More detail under Breaking Changes.

### Breaking

#### Model Types
- Renamed `CreateSearchOptions` to `CreateReservationOptions`.
- Renamed `CreateSearchResponse` to `CreateReservationResponse`.
- Renamed `ReleaseResponse` to `PhoneNumberReleaseResponse`.
- Renamed `SearchStatus` to `ReservationStatus`.
- Added `PhoneNumberReservationOperation`.
- Added `PhoneNumberReservationPurchaseOperation`.
- Added `ReleasePhoneNumberOperation`.
- Renamed `PhoneNumberSearch` to `PhoneNumberReservation`.

#### PhoneNumberReservation
- Renamed `searchId` to `reservationId`.

#### PhoneNumberAdministrationClient
- Renamed `CancelSearch` to `CancelReservation`.
- Renamed `CancelSearchAsync` to `CancelReservationAsync`.
- Renamed `GetAllSearches` to `GetAllReservations`.
- Renamed `GetAllSearchesAsync` to `GetAllReservationsAsync`.
- Renamed `GetSearchByIdAsync` to `GetReservationByIdAsync`.
- Renamed `GetSearchById` to `GetReservationById`.
- Renamed `CancelSearch` to `CancelReservation`.
- Renamed `CancelSearchAsync` to `CancelReservationAsync`.
- Replaced `CreateSearchAsync` with `StartReservationAsync` which returns a poller for the long-running operation.
- Replaced `CreateSearch` with `StartReservation` which is a long-running operation.
- Replaced `PurchaseSearchAsync` with `StartPurchaseReservationAsync` which returns a poller for the long-running operation.
- Replaced `PurchaseSearch` with `StartPurchaseReservation` which is a long-running operation.
- Replaced `ReleasePhoneNumbersAsync` with `StartReleasePhoneNumbersAsync` which returns a poller for the long-running operation.
- Replaced `ReleasePhoneNumbers` with `StartReleasePhoneNumbers` which is a long-running operation.


## 1.0.0-beta.2 (2020-10-06)
Added phone number administration. For more information, please see the [README][read_me] and [documentation][documentation].

## 1.0.0-beta.1 (2020-09-22)
This is the first release of Azure Communication Administration, which manages users, tokens, and phone numbers for Azure Communication Services. For more information, please see the [README][read_me] and [documentation][documentation].

This is a Public Preview version, so breaking changes are possible in subsequent releases as we improve the product. To provide feedback, please submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

<!-- LINKS -->
[read_me]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/communication/Azure.Communication.Administration/README.md
[documentation]: https://docs.microsoft.com/azure/communication-services/quickstarts/access-tokens?pivots=programming-language-csharp
