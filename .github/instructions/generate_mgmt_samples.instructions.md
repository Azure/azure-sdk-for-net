---
applyTo: '**/*.cs'
---
# Generate Samples

This instruction set guides you through generating sample code snippets for C# files.

The following inputs will be provided to you:
- A working directory
- A `json` file containing details about the sample to be generated

If any of the above pre-requisites are missing, please notify the user and halt further processing.

The working directory should have a structure of the directory like this:
```
- api
- src
- tests
```
The generated samples should be placed in the `tests/Samples` directory. The `src` directory contains the source code of the library, the generated samples should be calling APIs from this library in `src`.

This `json` file will contain everything about its corresponding rest API, it looks like this:
```json
{
  "operationId": "StorageTasks_Create",
  "parameters": {
    "api-version": "2023-01-01",
    "monitor": "true",
    "parameters": {
      "identity": {
        "type": "SystemAssigned"
      },
      "location": "westus",
      "properties": {
        "description": "My Storage task",
        "action": {
          "else": {
            "operations": [
              {
                "name": "DeleteBlob",
                "onFailure": "break",
                "onSuccess": "continue"
              }
            ]
          },
          "if": {
            "condition": "[[equals(AccessTier, 'Cool')]]",
            "operations": [
              {
                "name": "SetBlobTier",
                "onFailure": "break",
                "onSuccess": "continue",
                "parameters": {
                  "tier": "Hot"
                }
              }
            ]
          }
        },
        "enabled": true
      }
    },
    "resourceGroupName": "res4228",
    "storageTaskName": "mytask1",
    "subscriptionId": "1f31ba14-ce16-4281-b9b4-3e78da6e1616"
  },
  "title": "PutStorageTask",
  "responses": {
    "200": {
        // omitted for brevity
    },
    "201": {
        // omitted for brevity
    },
    "202": {
        // omitted for brevity
    }
  }
}
```
The `operationId` indicates which method from the library you should call in the sample. The `parameters` section contains all the parameters you need to call that method. Usually you could just ignore the `responses` section.

About the structure of the source code in `src`:
1. All the service methods in the source code have an xml documentation comment that contains a paragraph indicating the `operationId`, you should use this to map the `operationId` from the `json` file to the corresponding method in the source code.
2. All the service methods are organized in classes named `*Resource.cs`, `*Collection.cs` or `<ServiceName>Extensions.cs`. Other classes might also contain service methods, but please consider them as helper methods.
3. The resource structure is hierarchical. A pair classes of `*Resource.cs` and `*Collection.cs` represent an ARM resource. Each resource should have a factory method in its parent resource to get its collection or resource instance. There are two types of factory methods:
    - If the parent resource exists in this library, the factory method is on the `*Resource.cs` class of the parent resource, and it returns the `*Collection.cs` class (or `*Resource.cs` class only when it does not have a collection class) of the child resource.
    - If the parent resource does not exist in this library, the factory method is in the `<ServiceName>Extensions.cs` class, and it returns the `*Collection.cs` class (or `*Resource.cs` class only when it does not have a collection class) of the child resource.

You need to follow the following steps to generate the sample:
1. **Analyze the JSON File**: Read the provided `json` file to understand the `operationId` and its parameters.
2. **Map Operation ID to Method**: Identify the corresponding method in the source code (`src` directory) that matches the `operationId`. Prioritize the methods on `*Resource.cs` class over those on `*Collection.cs` class, and those on `*Collection.cs` class over those on `<ServiceName>Extensions.cs` class.
3. **Identify the Resource Structure**: Determine the resource structure of how we could get to the resource where the method is defined. This involves identifying the parent resources and how to instantiate them using the factory methods.
4. **Generate Sample Code**:
    1. Determine the class name for this sample. The sample class should be named as `Sample_<TypeName>.cs` where `<TypeName>` is the name of the class where the method is defined.
    2. Determine the method name of this sample. The sample method name should be `<MethodName>_<TitleOfJsonFile>`, where `<MethodName>` is the name of the method being called, and `<TitleOfJsonFile>` is the `title` field from the `json` file.
    3. Write the sample code that demonstrates how to call the identified method with the parameters from the `json` file. The sample code contains three parts which will elaborate with more details below:
        - **Initialization**: Get an instance of the type which holds the method.
        - **Parameter Preparation**: Prepare the parameters needed for the method call.
        - **Method Invocation**: Call the method with the prepared parameters and handle the response.

The following details are steps about each part of the sample code:
- **Initialization**:
    - Before everything starts, we need to write
    ```
    // get your azure access token, for more details of how Azure SDK get your access token, please refer to https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line
    TokenCredential cred = new DefaultAzureCredential();
    // authenticate your client
    ArmClient client = new ArmClient(cred);
    ```
    - Determine the type of the class where the method is defined.
        - If the class is a `*Resource.cs` class, we need to get an instance of this resource first. To do this, we need to find its `CreateResourceIdentifier` method, and call it with its parameters. Then we call `client.Get<ResourceName>(resourceId)` to get the resource instance.
        - If the class is a `*Collection.cs` class, we need to get its parent resource first, then call the factory method on the parent resource to get the collection instance. To get the instance of the parent resource, follow the same way as above.
        - If the class is a `<ServiceName>Extensions.cs` class, because every method in this class is a static extension method, we need to get its first parameter's type instance first, and it should be a `*Resource.cs` class, then follow the same way as above to get the instance of this resource.
- **Parameter Preparation**:
    - For each parameter needed for the method call, check its type.
        - If it is a primitive type (string, int, bool, etc.), directly use the value from the `json` file.
        - If it is a complex type (a class defined in this library), create an instance of this class, and set its properties with the values from the `json` file.
        - If it is an enum type, use the enum value defined in this library that matches the value from the `json` file.
        - If it is a collection type (List, Dictionary, etc.), create an instance of this collection type, and populate it with the values from the `json` file.
- **Method Invocation**:
    - Call the identified method with the prepared parameters.

Some additional notes:
1. The service methods always come with both synchronous and asynchronous versions. Please always use the asynchronous version (the one with `Async` suffix).
2. Always include necessary `using` directives at the top of the sample file.
3. Never use `var` keyword in the sample code, always use explicit types.
4. Always use public members in the sample code, never use internal or private members.
5. Make sure the generated sample code is properly formatted and follows C# coding conventions.
6. When constructing complex types, use the object initializer syntax for better readability.
7. If a property of a complex type is another complex type, make sure to initialize it properly using nested object initializers.
8. If a property of a complex type is a collection, make sure to initialize it properly using collection initializers. Collection properties in the source code usually do not have setters, please make sure we never construct a new instance.
9. If a parameter is optional and not provided in the `json` file, you can omit setting that property in the sample code.
10. If a parameter is required and not provided in the `json` file, please notify the user about the missing required parameter and use `(T)default` as a placeholder for such occurrences.
11. Once the code is generated, call `dotnet build` on the working directory to verify the code could build successfully. If there are any build errors, fix them before finalizing the code.
