# Release History

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
[read_me]: https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/communication/Azure.Communication.Identity/README.md
[documentation]: https://docs.microsoft.com/azure/communication-services/quickstarts/access-tokens?pivots=programming-language-csharp
