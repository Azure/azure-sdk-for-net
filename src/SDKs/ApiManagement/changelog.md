## Microsoft.Azure.Management.ApiManagment release notes

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