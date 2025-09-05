# Release History

## 1.4.0-beta.2 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.4.0-beta.1 (2025-06-09)

### Features Added

- Identity Management: Added support for creating identities with an associated customId.
- Identity Operations: Introduced the get identity operation.

## 1.3.1 (2024-03-22)
- Dependency versions updated.

## 1.3.0 (2023-11-28)

### Features Added
- Introduction of new scopes for token generation.
    - `ChatJoin` (Access to Chat APIs but without the authorization to create, delete or update chat threads)
    - `ChatJoinLimited` (A more limited version of `ChatJoin` that doesn't allow to add or remove participants)
    - `VoIPJoin` (Access to Calling APIs but without the authorization to start new calls)
- Added a new API version `ServiceVersion.V2023_10_01` that is now the default API version.

## 1.2.0 (2022-10-11)

### Features Added
- Added support to customize the Communication Identity access token’s validity period:
    - Added method overloads that provide the ability to create a Communication Identity access token with custom expiration:
        - `CreateUserAndToken(IEnumerable<CommunicationTokenScope> scopes, TimeSpan tokenExpiresIn, CancellationToken cancellationToken = default)`
        - `CreateUserAndTokenAsync(IEnumerable<CommunicationTokenScope> scopes, TimeSpan tokenExpiresIn, CancellationToken cancellationToken = default)`
        - `GetToken(CommunicationUserIdentifier communicationUser, IEnumerable<CommunicationTokenScope> scopes, TimeSpan tokenExpiresIn, CancellationToken cancellationToken = default)`
        - `GetTokenAsync(CommunicationUserIdentifier communicationUser, IEnumerable<CommunicationTokenScope> scopes, TimeSpan tokenExpiresIn, CancellationToken cancellationToken = default)`
- Added a new API version `ServiceVersion.V2022_10_01` that is now the default API version.

## 1.1.0 (2022-07-19)

### Features Added
- Added support to integrate communication as Teams user with Azure Communication Services:
    - Added `GetTokenForTeamsUser(GetTokenForTeamsUserOptions options, CancellationToken cancellationToken = default)` method that provides the ability to exchange an Azure AD access token of a Teams user for a Communication Identity access token to `CommunicationIdentityClient`.
- Removed `ServiceVersion.V2021_10_31_preview`
- Added a new API version `ServiceVersion.V2022_06_01` that is now the default API version

## 1.1.0-beta.1 (2021-10-29)
- Updated version of Identity API to enable to to integrate communication as Teams user with Azure Communication Services

## 1.0.1 (2021-05-25)
- Dependency versions updated.

## 1.0.0 (2021-03-29)
Updated `Azure.Communication.Identity` version.


## 1.0.0-beta.5 (2021-03-09)
### Breaking
- CommunicationIdentityClient.IssueToken and CommunicationIdentityClient.IssueTokenAsync are renamed to GetToken and GetTokenAsync, respectively.
- CommunicationIdentityClient.CreateUserWithToken and CommunicationIdentityClient.CreateUserWithTokenAsync are renamed to CreateUserAndToken and CreateUserAndTokenAsync, respectively. Their return value is also changed from Tuple<CommunicationUserIdentifier, string> to CommunicationUserIdentifierAndToken.

## 1.0.0-beta.4 (2021-02-09)

### Added
- Added CommunicationIdentityClient (originally was part of the Azure.Communication.Administration package).
- Added support to create CommunicationIdentityClient with TokenCredential.
- Added support to create CommunicationIdentityClient with AzureKeyCredential.
- Added ability to create a user and issue token for it at the same time.

### Breaking
- CommunicationTokenScope.Pstn is removed.
- CommunicationIdentityClient.RevokeTokens now revoke all the currently issued tokens instead of revoking tokens issued prior to a given time.
- CommunicationIdentityClient.IssueToken returns an instance of `Azure.Core.AccessToken` instead of `CommunicationUserToken`.

<!-- LINKS -->
[read_me]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/communication/Azure.Communication.Identity/README.md
[documentation]: https://learn.microsoft.com/azure/communication-services/quickstarts/access-tokens?pivots=programming-language-csharp
