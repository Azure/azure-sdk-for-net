# C# Azure SDK Clients that Contain Protocol Methods

## Introduction

Azure SDK clients provide an interface to Azure services by translating library calls to REST requests. 

The schematized body in the request or response, known as the message body, can be exposed in the Azure SDK client one of two ways:

Most Azure SDK Clients expose methods that take ['model types'](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-model-types) as parameters, C# classes which map to the message body of the REST call. Those methods can be called here '**standard model methods**',

However, some clients expose methods that mirror the message body directly. Those methods are called here '**protocol methods**', as they provide more direct access to the REST protocol used by the client library.

### Pet's Example 

To compare the two approaches, imagine a service that stores information about pets, with a GetDog and SetDog pair of operations. 

Pets are represented in the message body as a JSON object:

```json
{
        "name": "Buddy",
        "id": 2,
        "color": "Brown"
}
```

An API using model types could be:

```csharp
        // This is an example model class
        public class Pet
        {
                string Name { get; }
                int Id { get; }
                string Color { get; }
        }

        Response<Pet> GetDog(string dogName);
        Response SetDog(Pet dog);
```

While the protocol methods version would be:

```csharp
        // Request: {
        //      "name": "Buddy",
        // }
        // Response: {
        //      "name": "Buddy",
        //      "id": 2,
        //      "color": "Brown"
        // }
        Response GetDog(RequestContent requestBody, RequestOptions options = default);
        // Request: {
        //      "name": "Buddy",
        //      "id": 2,
        //      "color": "Brown"
        // }
        // Response: {}
        Response SetDog(RequestContent requestBody, RequestOptions options = default);
```

This document will be a general quickstart in using SDK Clients that expose 'protocol methods'.

## Usage

The basic structure of calls with clients remain the same if they use protocol methods or standard model methods:

1. [Initialize your client](#1-initialize-your-client "Initialize Your Client")
2. [Create a request](#2-create-a-request "Create a Request")
3. [Send the request](#3-send-the-request "Send the Request")
4. [Handle the response](#4-handle-the-response "Handle the Response")

## 1. Initialize Your Client

The first step in interacting with a service via protocol methods is to create a client instance. 

```csharp
using Azure.Pets;
using Azure.Core;
using Azure.Identity;

const string endpoint = "http://localhost:3000";
var credential = new AzureKeyCredential(/*SERVICE-API-KEY*/);
var client = new PetsClient(endpoint, credential);
```

## 2. Create and Send a Request

Protocol methods need a JSON object of the shape required by the schema of the service.

See the specific service documentation for details, but as an example:

```csharp
	var data = new {
                name = "Buddy",
                id = 2,
                color = "Brown"
        };
        /*
        {
            "name": "Buddy",
            "id": 2,
            "color": "Brown"
        }
        */
        client.SetDog(RequestContent.Create(data));
```

## 3. Handle the Response

Protocol methods all return a `Response` object that contains information returned from the service request. 

The most important field on Response contains the REST content returned from the service:

```csharp
        Response response = client.GetDog(RequestContent.Create(new {
                name = "Buddy"
        }));
        var content = response.Content;

        var doc = JsonDocument.Parse(content.ToMemory());
        string name = doc.RootElement.GetProperty("name").GetString();
```

Protocol methods, just like other methods that use models, throw a `RequestFailedException` when an error code is returned. This default behavior can be changed using `RequestOptions` discussed below.

## Using `RequestOptions` to customize behavior

`RequestOptions` has some advanced features which allow users to customize behavior:

- [Exception Behavior](#exception-behavior "Exception Behavior")
- [Request Callback](#request-callback "Request Callback")

### Exception Behavior

Protocol methods allow customization of exception behavior by use of the optional `RequestOptions` parameter:

```csharp
        RequestOptions options = new RequestOptions(ResponseStatusOption.NoThrow);
        Response response = client.GetDog(RequestContent.Create(new {
                name = "Buddy"
        }), options);
        int code = response.Status;
```

### Request Callback

The `RequestOptions` type also allows registering for a callback that is called when the request is sent:

```csharp
        RequestOptions options = new RequestOptions(message => Console.WriteLine ("Sending dog request: " + message)));
        return client.GetDog(RequestContent.Create(new {
                name = "Buddy"
        }), options);
```
