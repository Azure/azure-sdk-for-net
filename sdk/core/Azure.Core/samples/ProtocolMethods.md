# C# Azure SDK Clients that Contain Protocol Methods

## Introduction

Most Azure SDK Clients expose methods that take 'model' parameters, C# classes which map to the request or response content of the REST call.

Imagine a service that stores information about pets, with a GetDog and SetDog pair of operations. 

Pets are represented in the request by a JSON object:

```json
{
        "name": "Buddy",
        "id": 2,
        "color": "Brown"
}
```

An API using models might be:

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

Some SDK Clients however expose methods which take a RequestContent instead of a model type, and return Response instead of returning Response<Model>.

For example:

```csharp
        Response GetDog(RequestContent requestBody, RequestOptions options = default);
        Response SetDog(RequestContent requestBody, RequestOptions options = default);
```

Those methods are called '**protocol methods**', as they provide more direct access to the REST protocol used by the client library.

This quick start is designed to review their use.

## Usage

The basic structure of calls with clients remain the same if they use protocol methods or methods with models:

1. [Initialize your client](#1-initialize-your-client "Initialize Your Client")
2. [Create a request](#2-create-a-request "Create a Request")
3. [Send the request](#3-send-the-request "Send the Request")
4. [Handle the response](#4-handle-the-response "Handle the Response")

## 1. Initialize Your Client

The first step in interacting with a service is to create a client instance. 

```csharp
using Azure.Pets;
using Azure.Core;
using Azure.Identity;

const string endpoint = "http://localhost:3000";
var credential = new AzureKeyCredential(/*..*/);
var client = new PetsClient(endpoint, credential);
```

## 2. Create and Send a Request

Protocol methods need a JSON object of the shape required by the service in question.

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

Protocol methods all return a `Response` object which contains information returned from the service request. 

The most important field on Response contains the REST content returned from the service:

```csharp
        Response response = client.GetDog(RequestContent.Create(new {
                name = "Buddy"
        }));
        var content = response.Content;

        var doc = JsonDocument.Parse(content.ToMemory());
        var responseBody = JsonData.FromBytes(response.Content.ToMemory());
        string name = doc.RootElement.GetProperty("name").GetString();
```

Protocol methods, just like other methods that use models, throw a C# exception when an error code is returned. This default behavior can be changed using RequestOptions discussed below.

## Using `RequestOptions` to customize behavior

`RequestOptions` has some advanced features which allow users to customize its behavior.

### Exception Behavior

Protocol methods allow customization of exception behavior by use of the optional `RequestOptions` parameter:

```csharp
        RequestOptions options = new RequestOptions (ResponseStatusOption.NoThrow);
        Response response = client.GetDog(RequestContent.Create(new {
                name = "Buddy"
        }), options);
        int code = response.Status;
```

Some service methods return detailed information within the response. An easy way to access that is to convert it to `JsonDocument`.

See the service documentation for details, but as an example:

```csharp
        Response response = client.GetDog(RequestContent.Create(new {
                name = "Buddy"
        }));
        var doc = JsonDocument.Parse(result.Content.ToMemory());
        var responseBody = JsonData.FromBytes(response.Content.ToMemory());
        string name = doc.RootElement.GetProperty("name").GetString();
```

### Request Callback

The `RequestOptions` type also allows registering for a callback that is called when the request is sent:

```csharp
        RequestOptions options = new RequestOptions (message => Console.WriteLine ("Sending dog request: " + message)));
        return client.GetDog(RequestContent.Create(new {
                name = "Buddy"
        }), options);
```