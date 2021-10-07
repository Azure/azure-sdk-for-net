# Release History

## 1.1.0-beta.1 (Unreleased)


## 1.0.0 (2021-03-29)
This is the first stable release of the management library for Azure Communication Services. 

Minor changes since the public preview release:
- CheckNameAvailability has been added
- CommunicationServiceResource Update now requires a CommunicationServiceResource parameter instead of a TaggedResource
- RegenerateKeyParameters is now a required parameter to RegenerateKey
- CommunicationServiceResource now includes the property SystemData
- OperationList has been changed to use the common type for its response
- ErrorResponse has been changed to use the common type for ErrorResponse

## 1.0.0-beta.3 (2020-11-16)
Updated `Azure.ResourceManager.Communication` version.

## 1.0.0-beta.2 (2020-10-06)
Updated `Azure.ResourceManager.Communication` version.

## 1.0.0-beta.1 (2020-09-22)

This is the first release of the management library for Azure Communication Services. For more information, please see the [README][read_me].

Use the management library for Azure Communication Services to:

- Create or update a resource
- Get the keys for that resource
- Delete a resource

For more information, please see the README.

This is a Public Preview version, so breaking changes are possible in subsequent releases as we improve the product. To provide feedback, please submit an issue in our [Azure SDK for .NET GitHub repo](https://github.com/Azure/azure-sdk-for-net/issues).

<!-- LINKS -->
[read_me]: https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/communication/Azure.ResourceManager.Communication/README.md

