# Migrate from Microsoft.Azure.Search to Azure.Search.Documents

This guide is intended to assist in the migration to version 11 of the Azure Cognitive Search client library [`Azure.Search.Documents`](https://www.nuget.org/packages/Azure.Search.Documents/) from version 10 of [`Microsoft.Azure.Search`](https://www.nuget.org/packages/Microsoft.Azure.Search/).

To learn more about the Azure Cognitive Search client library for .NET, please refer to the [`Azure.Search.Documents` README](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/search/README.md) and [`Azure.Search.Documents` samples](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/search/Azure.Search.Documents/samples) for the `Azure.Search.Documents` library.

## Migration Guide
Details about the migration can be found in the [upgrade document](https://docs.microsoft.com/azure/search/search-dotnet-sdk-migration-version-11). It describes the API differences, code changes involved in the upgrade and the breaking changes.

## Migration benefits

A natural question to ask when considering whether or not to adopt a new version or library is what the benefits of doing so would be. As Azure has matured and been embraced by a more diverse group of developers, we have been focused on learning the patterns and practices to best support developer productivity and to understand the gaps that the .NET client libraries have.

There were several areas of consistent feedback expressed across the Azure client library ecosystem. One of the most important is that the client libraries for different Azure services have not had a consistent approach to organization, naming, and API structure. Additionally, many developers have felt that the learning curve was difficult, and the APIs did not offer a good, approachable, and consistent onboarding story for those learning Azure or exploring a specific Azure service.

To try and improve the development experience across Azure services, including Cognitive Search, a set of uniform [design guidelines](https://azure.github.io/azure-sdk/general_introduction.html) was created for all languages to drive a consistent experience with established API patterns for all services. A set of [.NET-specific guidelines](https://azure.github.io/azure-sdk/dotnet_introduction.html) was also introduced to ensure that .NET clients have a natural and idiomatic feel that mirrors that of the .NET base class libraries. Further details are available in the guidelines for those interested.
