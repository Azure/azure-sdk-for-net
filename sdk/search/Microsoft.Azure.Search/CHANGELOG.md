# GA SDK Releases

Every minor version release targets the same (GA) REST API version as that of the corresponding major version release. The REST API version targeted by the major version releases are listed where appropriate.

Features and improvements in a GA SDK are considered generally available.

## 10.1.0 (2019-10-29)

### Breaking Changes

None

### Improvements

- Re-branded "Azure Search" to "Azure Cognitive Search" (when appropriate) in doc comments. [PR 8316](https://github.com/Azure/azure-sdk-for-net/pull/8316)

### Bug fixes

None

## 10.0.1

### Breaking Changes

None

### Improvements

None

### Bug fixes

- Fixed missing Intellisense and reference documentation. This was caused by missing XML doc files in the NuGet packages. [PR 6298](https://github.com/Azure/azure-sdk-for-net/pull/7786).

<a name="10.0.0"></a>

## 10.0.0

### Target API Version

2019-05-06

### Breaking Changes

For more details, visit the [SDK migration guide](https://docs.microsoft.com/azure/search/search-dotnet-sdk-migration-version-10).

- Fixed the definition of `WebApiSkill` so that `HttpHeaders` is a top-level dictionary property. [PR 7080](https://github.com/Azure/azure-sdk-for-net/pull/7080).
- Allow recursive inputs for `InputFieldMappingEntry`. [PR 7204](https://github.com/Azure/azure-sdk-for-net/pull/7204).
- Skills can be optionally identified by `Name` property. [PR 7265](https://github.com/Azure/azure-sdk-for-net/pull/7265).

### Improvements

- Introduce `urlEncode` and `urlDecode` field mapping functions. [PR 7126](https://github.com/Azure/azure-sdk-for-net/pull/7126).
- Introduce conditional skill. [PR 7204](https://github.com/Azure/azure-sdk-for-net/pull/7204).
- Introduce text translate skill. [PR 7204](https://github.com/Azure/azure-sdk-for-net/pull/7204).
- Indexer execution status adds more detail for errors and warnings. [PR 7265](https://github.com/Azure/azure-sdk-for-net/pull/7265).
- Service limits expose complex type limits and indexer execution status includes indexer limits/quotas. [PR 7031](https://github.com/Azure/azure-sdk-for-net/pull/7031).

### Bug fixes

- Fix Web API skill validation error on creating a skillset. See first item in "Breaking changes". [Issue 6468](https://github.com/Azure/azure-sdk-for-net/issues/6468).

## 9.1.0

### Breaking Changes

None

### Improvements

- Improvements in error handling for `FieldBuilder`. [PR 6833](https://github.com/Azure/azure-sdk-for-net/pull/6833).

### Bug fixes

- Prevent ObjectDisposedException when Indexing using "Merge" operation. [PR 7011](https://github.com/Azure/azure-sdk-for-net/pull/7011). [Issue 6910](https://github.com/Azure/azure-sdk-for-net/issues/6910).
- Handle enum conversion exceptions gracefully in `FieldBuilder`. See first item in "Improvements". [Issue 6380](https://github.com/Azure/azure-sdk-for-net/issues/6380).

## 9.0.1

### Breaking Changes

None

### Improvements

None

### Bug fixes

- Fix deadlock in Search when using POST. [PR 6298](https://github.com/Azure/azure-sdk-for-net/pull/6298). [Issue 6254](https://github.com/Azure/azure-sdk-for-net/issues/6254).

<a name="9.0.0"></a>

## 9.0.0

### Target API Version

2019-05-06

### Breaking Changes

For more details, visit the [SDK migration guide](https://docs.microsoft.com/azure/search/search-dotnet-sdk-migration-version-9).

- Public properties of several model classes are immutable. [PR 6009](https://github.com/Azure/azure-sdk-for-net/pull/6009).
- Several `bool` properties of `Field` class are now nullable. [PR 6009](https://github.com/Azure/azure-sdk-for-net/pull/6009).
- Batch and result types have a simplified hierarchy. [PR 6009](https://github.com/Azure/azure-sdk-for-net/pull/6009).
- `ExtensibleEnum` has been removed. [PR 6009](https://github.com/Azure/azure-sdk-for-net/pull/6009).
- Removed `FacetResults` and `HitHighlights` classes. [PR 6009](https://github.com/Azure/azure-sdk-for-net/pull/6009).
- `SynonymMap` constructor no longer has the redundant `enum` parameter for `SynonymMapFormat`. [PR 6009](https://github.com/Azure/azure-sdk-for-net/pull/6009).
- `DataSourceType.DocumentDb` is deprecated in favor of `DataSourceType.CosmosDb`. [PR 5223](https://github.com/Azure/azure-sdk-for-net/pull/5223).

### Improvements

- Introduces [cognitive search](https://docs.microsoft.com/azure/search/cognitive-search-concept-intro) capabilities as part of the SDK. [PR 6009](https://github.com/Azure/azure-sdk-for-net/pull/6009). This includes:
    - The ability to create skillsets with one or more predefined or customer skills.
    - Attach a cognitive service resource to the skillset to remove restrictions on document limit count for enrichments.
- Support for [complex types](https://docs.microsoft.com/azure/search/search-howto-complex-data-types) that allows you to model almost any nested JSON structure in an Azure Search index. [PR 6009](https://github.com/Azure/azure-sdk-for-net/pull/6009).
- Introduction of [Autocomplete](https://docs.microsoft.com/en-us/azure/search/search-autocomplete-tutorial) as an alternative to the **Suggest API**. [PR 6009](https://github.com/Azure/azure-sdk-for-net/pull/6009).
- General availability of [JsonLines parsing mode](https://docs.microsoft.com/azure/search/search-howto-index-json-blobs). [PR 6009](https://github.com/Azure/azure-sdk-for-net/pull/6009).

### Bug fixes

None

## 5.0.3

### Breaking Changes

None

### Improvements

- Add further support for .NET Core 2 in project target files. [PR 5171](https://github.com/Azure/azure-sdk-for-net/pull/5171).

### Bug fixes

None

## 5.0.2

### Breaking Changes

None

### Improvements

- Add XML summary documentation for classes, methods and properties where it was missed. [PR 4601](https://github.com/Azure/azure-sdk-for-net/pull/4601).

### Bug fixes

None

## 5.0.1

### Breaking Changes

None

### Improvements

None

### Bug fixes

- Fix deadlock issue in `Documents.CountWithHttpMessagesAsync`. [PR 4495](https://github.com/Azure/azure-sdk-for-net/pull/4495).

<a name="5.0.0"></a>

## 5.0.0

### Target API Version
2017-11-11

### Breaking Changes

For more details, visit the [SDK migration guide](https://docs.microsoft.com/azure/search/search-dotnet-sdk-migration-version-5).

- Reorganized the package structure of `Microsoft.Azure.Search` into four separate assemblies. [PR 4246](https://github.com/Azure/azure-sdk-for-net/pull/4246).
- `Suggester` constructor no longer has the redundant `enum` parameters for `SuggesterSearchMode`. [PR 4246](https://github.com/Azure/azure-sdk-for-net/pull/4246).
- Members marked as `[Obsolete]` in previous API versions were removed. [PR 4246](https://github.com/Azure/azure-sdk-for-net/pull/4246).

### Improvements

- [Synonyms](https://docs.microsoft.com/azure/search/search-synonyms). [PR 4246](https://github.com/Azure/azure-sdk-for-net/pull/4246).
- Indexer execution history can be accessed via the SDK. [PR 4246](https://github.com/Azure/azure-sdk-for-net/pull/4246).
- Support for .NET Core 2. [PR 4246](https://github.com/Azure/azure-sdk-for-net/pull/4246).

### Bug fixes

None

## Preview SDK Releases

Every minor version release targets the same (preview) REST API version as that of the corresponding major version release. The REST API version targeted by the major version releases are listed when appropriate.

Features and improvements offered in a preview SDK are in a preview capacity. They may or may not be shipped in a subsequent GA SDK. We advise not to use them in production environments.

<a name="8.0.0-preview"></a>

## 8.0.0-preview
### Target API Version
2017-11-11-Preview

### Breaking Changes

For more details, visit the [section dedicated to the 8.0-preview API](https://docs.microsoft.com/azure/search/search-dotnet-sdk-migration-version-9#new-preview-features-in-version-80-preview) in the [SDK migration guide](https://docs.microsoft.com/azure/search/search-dotnet-sdk-migration-version-9).

The list of breaking changes are identical to the breaking changes in [version 9.0](#9.0.0).

### Improvements

- Introduces [customer-managed encryption keys](https://docs.microsoft.com/azure/search/search-security-manage-encryption-keys), to perform service-side encryption-at-rest for indexes. [PR 5858](https://github.com/Azure/azure-sdk-for-net/pull/5858).
- Introduces [JsonLines parsing mode](https://docs.microsoft.com/azure/search/search-howto-index-json-blobs) for indexers. [PR 5223](https://github.com/Azure/azure-sdk-for-net/pull/5223).

### Bug fixes

None

<a name="7.0.0-preview"></a>

## 7.0.0-preview

### Target API Version

2017-11-11-Preview

### Breaking Changes

The list of breaking changes are identical to the breaking changes in [version 9.0](#9.0.0).

### Improvements

- Introduces [cognitive search](https://docs.microsoft.com/azure/search/cognitive-search-concept-intro) and the ability to create skillsets. [PR 5223](https://github.com/Azure/azure-sdk-for-net/pull/5223)

### Bug fixes

None

<a name="6.0.0-preview"></a>

# 6.0.0-preview
## Target API Version
2017-11-11-Preview

### Breaking Changes

The list of breaking changes are identical to the breaking changes in [version 9.0](#9.0.0).

### Improvements

- Introduces [Autocomplete](https://docs.microsoft.com/en-us/azure/search/search-autocomplete-tutorial) as an alternative to the **Suggest API**. [PR 4283](https://github.com/Azure/azure-sdk-for-net/pull/4283).

### Bug fixes

None
