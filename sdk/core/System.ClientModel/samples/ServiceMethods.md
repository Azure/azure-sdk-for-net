# System.ClientModel-based client service methods

## Introduction

`System.ClientModel`-based clients , or **service clients**, provide an interface to cloud services by translating library calls to HTTP requests.

In service clients, there are two ways to expose the schematized body in the request or response, known as the **message body**:

- Most service clients expose methods that take strongly-typed models as parameters, C# classes which map to the message body of the REST call.  These methods are called **convenience methods**.

- However, some clients expose methods that mirror the message body directly. Those methods are called here **protocol methods**, as they provide more direct access to the HTTP API protocol used by the service.

## Convenience methods

**Convenience methods** provide a convenient way to invoke a service operation.  They are service methods that take a strongly-typed model representing schematized data sent to the service as input, and return a strongly-typed model representing the payload from the service response as output. Having strongly-typed models that represent service concepts provides a layer of convenience over working with the raw payload format. This is because these models unify the client user experience when cloud services differ in payload formats.  That is, a client-user can learn the patterns for strongly-typed models that `System.ClientModel`-based clients provide, and use them together without having to reason about whether a cloud service represents resources using, for example, JSON or XML formats.

The following sample illustrates how to call a convenience method and access both the strongly-typed output model and the details of the HTTP response.

```C# Snippet:ClientResultTReadme
// create a client
var client = new SecretClient(new Uri("http://example.com"), new DefaultAzureCredential());

// call a service method, which returns Response<T>
Response<KeyVaultSecret> response = await client.GetSecretAsync("SecretName");

// Response<T> has two main accessors.
// Value property for accessing the deserialized result of the call
KeyVaultSecret secret = response.Value;

// .. and GetRawResponse method for accessing all the details of the HTTP response
Response http = response.GetRawResponse();

// for example, you can access HTTP status
int status = http.Status;

// or the headers
foreach (HttpHeader header in http.Headers)
{
    Console.WriteLine($"{header.Name} {header.Value}");
}
```

## Protocol methods

In contrast to convenience methods, **protocol methods** are service methods that provide very little convenience over the raw HTTP APIs a cloud service exposes. They represent request and response message bodies using types that are very thin layers over raw JSON/binary/other formats. Users of client protocol methods must reference a service's API documentation directly, rather than relying on the client to provide developer conveniences via strongly-typing service schemas.

The following sample illustrates how to call a protocol method, including creating the request payload, accessing the details of the HTTP response.

```C# Snippet:ServiceMethodsProtocolMethod
```

### Protocol method concepts

To compare the convenience and protocol method approaches, let's look more closely at a `System.ClientModel`-based client implementation of a [Geolocation](https://learn.microsoft.com/rest/api/maps/geolocation/get-ip-to-location?view=rest-maps-2023-06-01&tabs=HTTP) service operation.

The [IpAddressToLocation]() operation result is Pets are represented in the message body as a JSON object:

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


## Handling exceptions

When a service call fails, service clients throw a `ClientResultException`.  The exception exposes the HTTP status code and the details of the service response if available.

```C# Snippet:ClientResultExceptionReadme
try
{
    KeyVaultSecret secret = client.GetSecret("NonexistentSecret");
}
// handle exception with status code 404
catch (RequestFailedException e) when (e.Status == 404)
{
    // handle not found error
    Console.WriteLine("ErrorCode " + e.ErrorCode);
}
```
