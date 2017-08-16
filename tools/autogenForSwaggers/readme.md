# Code Generation

This folder contains tools to generate C# code from [Azure REST API specifications](https://github.com/Azure/azure-rest-api-specs) using [AutoRest](https://github.com/Azure/autorest).

## Commands

- [.\update.ps1](update.ps1) updates [sdkinfo.lock.json](sdkinfo.lock.json) using the latest commit from [Azure REST API specifications](https://github.com/Azure/azure-rest-api-specs).
- [.\build.ps1](build.ps1) generates and builds C# code using **AutoRest** and **sdkinfo.lock.json** file. Examples
  - `.\build.ps1 arm-cdn` generates and builds [the CDN project](../../src/SDKs/Cdn).
  - `.\build.ps1 arm-*` generates and builds all ARM projects.
- [.\test.ps1](test.ps1) runs tests. Examples
  - `.\test.ps1 arm-cdn` tests [the CDN project](../../src/SDKs/Cdn).
  - `.\test.ps1 arm-*` tests all ARM projects.

## SDK Info File

[sdkinfo.json](sdkinfo.json) is a JSON file for mapping [Azure REST API specifications](https://github.com/Azure/azure-rest-api-specs) to [Azure SDK for .Net](https://github.com/Azure/azure-sdk-for-net).
In the future, the file should be replaced by configuration files.

The file is an array of object.
Each object describes one Azure REST Api specification.
The object must have these two properties: `name` and `sources`.
For example

```json
[
    {
        "name": "arm-authorization",
        "sources": [ "2015-07-01/swagger/authorization.json" ]
    }
]
```

The object may also have several optional fields. For example

```json
{
    "name": "arm-batch",
    "sources": [ "2017-05-01/swagger/BatchManagement.json" ],
    "dotNet": {
        "name": "Batch",
        "folder": "Batch/Management",
        "test": "Management.Batch.Tests/Management.Batch.Tests.csproj",
        "output": "Management.Batch/Generated",
        "namespace" : "Microsoft.Azure.Management.Batch",
        "ft": 1,
        "commit": "19f63015ea5a8a0fc64b9d7e2cdfeac447d93eaf",
        "autorest": "AutoRest.1.0.0-Nightly20170129"
    }
}
```

Optional `dotNet` properties:

|Property          |Description                     |Default value                                       |Default value example               |
|------------------|--------------------------------|----------------------------------------------------|------------------------------------|
|`dotNet.name`     |a .Net style specification name |generated from a specification name                 |`"Batch"`                           |
|`dotNet.folder`   |a .Net solution folder          |a `dotNet.name` value                               |`"Batch"`                           |
|`dotNet.test`     |a C# test project file          |generated from a value of the `dotNet.name` property|`"Batch.Tests/Batch.Tests.csproj"`  |
|`dotNet.output`   |an output folder for AutoRest   |generated from a value of the `dotNet.name` property|`"Managed.Batch/Generated"`         |
|`dotNet.namespace`|a .Net namespace                |generated from a value of the `dotNet.name` property|`"Microsoft.Azure.Management.Batch"`|
|`dotNet.ft`       |an AutoRest flattering parameter|`0`                                                 |`0`                                 |
|`dotNet.commit`   |a specification commit id       |current commit id                                   |`undefined`                         |
|`dotNet.autorest` |an AutoRest package             |current AutoRest                                    |`undefined`                         |