## Microsoft.Azure.Management.ApiManagment release notes

### Changes in 6.0.0-preview

- Fixed `quotas` update contract

### Changes in 5.0.0-preview

- Switch the .NET client to use api-version `2019-12-01`
- `properties` entity renamed to `namedValues` 
- new `gateway` entity added
- Added POST operations to get entities secret properties. Secret properties will not be returned with GET or LIST operations anymore. Entities are: `accessInformation`, `authorizationServers`, `delegationSettings`, `identityProviders`, `namedValues`, `openIdConnectProviders`, `subscriptions`. 
- `diagnostics` entity: `enableHttpCorrelationHeaders` property is not supported, `loggerId` is a required property now.
- Breaking Change: `capacity` is a required parameter with creating ApiManagement service.
- Added support for creating `userAssignedIdentity`. 
- Added support for `disableGateway` property, which allows taking a region out of a multi-region premium sku ApiManagement service
- Added support for `apiVersionConstraint` property which allows limiting all control plane calls higher than a specific api-version
- Breaking Change: Exception thrown in case of failure changed from `CloudException` to `ErrorResponseException`.

### Changes in 4.12.0-preview

- Added support for `developerPortal` endpoint in apimanagement service resource.
- Added support for overriding the `common` tenant when configuring AAD identity provider.
- Added support for specifying `httpCorrelationProtocol` and `verbosity` when configuring diagnostics on global and api level.
- Added support for importing OpenApi 3.0 document in Json format.

### Changes in 4.11.0-preview

- Removed id validation on `groups`, `apis`, `products`, `users` and `backend` to unblock existing customers to onboard to new sdks

### Changes in 4.10.0-preview

- Fixed support for creating, updating Swagger, WSDL and Open Api Schema.

### Changes in 4.9.0-preview

- Added support for retrieving Policies from Global, Api, Product and Operation level in Raw Xml format.

### Changes in 4.8.0-preview

- Switch the .NET client to use api-version `2019-01-01`
- Add support for cloning Apis from an ApiRevision and ApiVersionSet
- Enabled support for Importing and Exporting Apis based on OpenApi specification
- Add support for creating Api Diagnostics
- Diagnostics support configuring detailed sampling and Header configuration
- Add support for creating and update Cache entity.
- Subscription Contract has breaking change. The ProductId property is replaced with Scope and UserId is replaced with OwnerId.
- Added support for creating Global Scope Subscriptions
- Added support for managing `Consumption` Sku services.
- Deprecated Api UpdateHostName and UploadCertificate for configurating ApiManagement service. Use CreateOrUpdate service instead.

### Changes in 4.0.6-preview

- Added support of OpenId authentication in ApiContract
- Fixed bug in UserContract which prevented setting the UserIdentities
- Added API for updating an API Issue

### Changes in 4.0.5-preview

- Added ApiRevisionDescription and ApiVersionDescription to ApiContract
- Fixed bug in ApiManagementService contract. The CertificateInformation has a setter for Update scenarios.

### Changes in 4.0.4-preview

- Added ApiRevisionDescription and ApiVersionDescription to ApiContract
- Fixed bug in ApiManagementService contract. The CertificateInformation has a setter for Update scenarios.

### Changes in 4.0.3-preview

- Fixed contract for Error in OperationResultContract
- Fixed validation for adding Apis to Product

### Changes in 4.0.2-preview

- Fixed Contract for ErrorResponse for Management Apis

### Changes in 4.0.1-preview

*** Resource Management APIs ***

- Added missing privateIP address in Additional Location

*** Management APIs ****

- Added support for Issue, Issue Comments and Issue Attachments
- Added support for accepting non-Xml Encoded policies.

### Changes in 4.0.0-preview

**Notes**

*** Resource Management APIs ***
- Added support for Basic Sku
- Added support for Intermediate Certificates
- Added support for creating MSI and KeyVault integration
- Added support for querying NetworkStatus endpoint

*** Management APIs ***
- Added support for creating an API by importing a WSDL document, containing multiple Service endpoints
- GetEntityTag API for all resources, to retrieve the ETag of the entity, to be used when Updating/Deleting the Entity.
- API support for API Revisions, API Releases and Api VersionSets
- API support for API Schemas.
- API support for Backend Reconnect.
- API support for Tag.
- API support for Diagnostics
- API support for Application insights Logger
- API support for managing Notifications, Notification Recipients and Notification Users.
- API support for Portal settings including SignIn, Signup and Delegation.
- API support for Importing Policies using Link
- Added support for Exporting Soap APIs in WSDL Format.