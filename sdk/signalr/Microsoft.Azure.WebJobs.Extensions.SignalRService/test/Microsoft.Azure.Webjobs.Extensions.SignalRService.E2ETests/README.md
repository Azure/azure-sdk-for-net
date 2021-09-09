# Configuration

The functions project tested located in `e2etest-functions` folder under root directory. The following is a subtree of the folder structure. `simple-chat` is a function projects collections, containing function projects that provide the same interfaces and thus can be tested in the same way. `csharpv2` is a C# implementation running in Function V2 runtime, `csharpv3` is a Function V3 runtime version.

```
e2e-functions
└───simple-chat
    ├───csharpv2
    └───csharpv3
```

After deploying the function projects or running it locally, set the base URLs in the `appsettings.json` file. `FunctionBaseUrl` is contains the whole configuration section. `SimpleChat` section contains all the URLs of function instances under `simple-chat` folder. `csharpv2` is the name of function instance and won't effect the test result. The URL should be like "http://localhost:7071" on localhost.
```json
{
  "FunctionBaseUrl": {
    "SimpleChat": {
        "csharpv2":"url1",
        "csharpv3":"url2"
    }
  }
}
```