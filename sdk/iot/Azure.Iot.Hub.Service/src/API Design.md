



# Azure Iot Hub Service API Design Doc
This document outlines the APIs for the Azure Iot Hub Service SDK

## Azure.Core usage
Within this SDK, we will make use of several Azure.Core library classes

[AsyncPageable\<T>](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/src/AsyncPageable.cs): An enumerable set of items that are retrieved asynchronously over multiple http requests

[Pageable\<T>](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/src/Pageable.cs): An enumerable set of items that are retrieved synchronously over multiple http requests

[Page\<T>](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/src/Page.cs): A single page within a Pageable. Should not be exposed to the user, since we strive to abstract out the pagination

[Response](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/src/Response.cs): Contains the raw HTTP response details

[Response\<T>](https://github.com/Azure/azure-sdk-for-net/blob/master/sdk/core/Azure.Core/src/Response%7BT%7D.cs): Contains a Response instance and a parsed type derived from that HTTP response (for instance, Response\<ModelData> when retrieving models)
<details><summary><b>Sample</b></summary>

```csharp

```
</details>
