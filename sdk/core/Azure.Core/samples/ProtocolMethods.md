# C# Azure SDK Clients that Contain Protocol Methods

## Introduction

Azure SDK clients provide an interface to Azure services by translating library calls to REST requests.

In Azure SDK clients, there are two ways to expose the schematized body in the request or response, known as the `message body`:

- Most Azure SDK Clients expose methods that take ['model types'](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-model-types) as parameters, C# classes which map to the `message body` of the REST call. Those methods can be called here '**convenience methods**'.

- However, some clients expose methods that mirror the message body directly. Those methods are called here '**protocol methods**', as they provide more direct access to the REST protocol used by the client library.

### Pet's Example

To compare the two approaches, imagine a service that stores information about pets, with a pair of `GetPet`  and `SetPet` operations.

Pets are represented in the message body as a JSON object:

```json
{
    "name": "snoopy",
    "species": "beagle"
}
```

An API using model types could be:

```csharp
// This is an example model class
public class Pet
{
    string Name { get; }
    string Species { get; }
}

Response<Pet> GetPet(string dogName);
Response SetPet(Pet dog);
```

While the protocol methods version would be:

```csharp
// Request: "id" in the context path, like "/pets/{id}"
// Response: {
//      "name": "snoopy",
//      "species": "beagle"
// }
Response GetPet(string id, RequestContext context = null)
// Request: {
//      "name": "snoopy",
//      "species": "beagle"
// }
// Response: {
//      "name": "snoopy",
//      "species": "beagle"
// }
Response SetPet(RequestContent requestBody, RequestContext context = null);
```

**[Note]**: This document is a general quickstart in using SDK Clients that expose '**protocol methods**'.

## Usage

The basic structure of calling protocol methods remains the same as that of convenience methods:

1. [Initialize Your Client](#1-initialize-your-client "Initialize Your Client")

2. [Create and Send a request](#2-create-and-send-a-request "Create and Send a Request")

3. [Handle the Response](#3-handle-the-response "Handle the Response")

### 1. Initialize Your Client

The first step in interacting with a service via protocol methods is to create a client instance.

```csharp
using System;
using Azure.Pets;
using Azure.Core;
using Azure.Identity;

const string endpoint = "http://localhost:3000";
var credential = new AzureKeyCredential(/*SERVICE-API-KEY*/);
var client = new PetStoreClient(new Uri(endpoint), credential, new PetStoreClientOptions());
```

### 2. Create and Send a Request

Protocol methods need a JSON object of the shape required by the schema of the service.

See the specific service documentation for details, but as an example:

```csharp
// anonymous class is serialized by System.Text.Json using runtime reflection
var data = new {
    name = "snoopy",
    species = "beagle"
};
/*
{
    "name": "snoopy",
    "species": "beagle"
}
*/
client.SetPet(RequestContent.Create(data));
```

### 3. Handle the Response

Protocol methods all return a `Response` object that contains information returned from the service request.

The most important field on Response contains the REST content returned from the service:

```C# Snippet:GetPetAsync
Response response = await client.GetPetAsync("snoopy", new RequestContext());

var doc = JsonDocument.Parse(response.Content.ToMemory());
var name = doc.RootElement.GetProperty("name").GetString();
```

JSON properties can also be accessed using a dynamic layer.

```C# Snippet:AzureCoreGetDynamicJsonProperty
Response response = client.GetWidget();
dynamic widget = response.Content.ToDynamicFromJson();
string name = widget.name;
```

## Configuration And Customization

**Protocol methods** share the same configuration and customization as **convenience methods**. For details, see the [ReadMe](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md). You can find more samples [here](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/README.md).
