# Microsoft.Azure.Management.VideoAnalyzer release notes

## Changes in 1.0.0-beta.3

We're retiring the Azure Video Analyzer preview service, you're advised to transition your applications off of Video Analyzer by 01 December 2022. This SDK is no longer maintained or supported.

## Changes in 1.0.0-beta.2

This SDK is using 2021-11-01-preview version fo the Azure Video Analyzer API

- Support for async account creation.
- Addition of Iot Hub entity.
- Addition of public network access properties.
- Addition of private endpoint connections.
- Management of pipeline topology entity.
- Management of live pipeline entity.
- Management of pipeline job entity.
- Support of retention period on the video entity.
- Support of new File type for the video entity.

### Breaking changes

- Parameter id of model StorageAccount is now required
- Operation EdgeModulesOperations.list has a new signature
- Removed operation sync_storage_keys on Video Analyzer account.
- streaming property has been renamed to contentUrls.
- is_recording property on VideoFlags has been renamed to is_in_use.
- listStreamingToken operation on video entity has been renamed to listContentToken.


## Changes in 1.0.0-beta.1

This SDK is using 2021-05-01-preview version of the Azure Video Analyzer API

- Management of Azure Video Analyzer account.
- Management of Video entity.
- Management of access policy entity.
- Management of edge module entity.
