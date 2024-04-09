# Migrate from Purview Catalog to Purview DataMap

This guide is intended to assist in the migration to Azure Purview DataMap client library [`Azure.Analytics.Purview.DataMap`](https://www.nuget.org/packages/Azure.Analytics.Purview.DataMap) from [`Azure.Analytics.Purview.Catalog`](https://www.nuget.org/packages/Azure.Analytics.Purview.Catalog). It will focus on side-by-side comparisons for similar operations between the two packages.

For those new to the Purview DataMAP library for .NET, please refer to the [`Azure.Analytics.Purview.DataMap` README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/purview/Azure.Analytics.Purview.DataMap/README.md) and [`Azure.Analytics.Purview.DataMap` samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/purview/Azure.Analytics.Purview.DataMap/samples) for the `Azure.Analytics.Purview.DataMap` library rather than this guide.

## Table of contents

- [Migration benefits](#migration-benefits)
- [General changes](#general-changes)
  - [Package and client name](#package-and-client-name)
- [Additional samples](#additional-samples)

## Migration benefits

> Note: `Azure.Analytics.Purview.Catalog` has been <b>deprecated</b>. Please upgrade to `Azure.Analytics.Purview.DataMap` for continued support.

A natural question to ask when considering whether or not to adopt a new version or library is what the benefits of doing so would be. As Azure has matured and been embraced by a more diverse group of developers, we have been focused on learning the patterns and practices to best support developer productivity and to understand the gaps that the .NET client libraries have.

There were several areas of consistent feedback expressed across the Azure client library ecosystem. One of the most important is that the client libraries for different Azure services have not had a consistent approach to organization, naming, and API structure. Additionally, many developers have felt that the learning curve was difficult, and the APIs did not offer a good, approachable, and consistent onboarding story for those learning Azure or exploring a specific Azure service.

To try and improve the development experience across Azure services, a set of uniform [design guidelines](https://azure.github.io/azure-sdk/general_introduction.html) was created for all languages to drive a consistent experience with established API patterns for all services. A set of [.NET-specific guidelines](https://azure.github.io/azure-sdk/dotnet_introduction.html) was also introduced to ensure that .NET clients have a natural and idiomatic feel that mirrors that of the .NET base class libraries. Further details are available in the guidelines for those interested.

The new Purview DataMap library `Azure.Analytics.Purview.DataMap` includes the service models together with the DataMap APIs [API Document](https://learn.microsoft.com/rest/api/purview/datamapdataplane/operation-groups?view=rest-purview-datamapdataplane-2023-09-01). The client name and the operation names have slightly changed but the main functionality remains the same.

## General changes

### Package and client name

Previously in `Azure.Analytics.Purview.Catalog`, the service client name is PurviewCatalogClient.

```C#
var credential = new DefaultAzureCredential();
var client = new PurviewCatalogClient(new Uri("https://<my-account-name>.purview.azure.com"), credential);
```

Now in `Azure.Analytics.Purview.DataMap`, the service client name is DataMapClient.

```C#
var credential = new DefaultAzureCredential();
var dataMapClient = new DataMapClient(endpoint, credential);
```

## Additional samples

For more examples, see [Samples for Purview DataMap](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/purview/Azure.Analytics.Purview.DataMap#examples).