# Azure.Communication.Chat
1. When a new version of the swagger needs to be updated:
- Go to the 'Swagger' folder, and update the swagger.json file with the new version.

2. Go to sdk\communication, and run `dotnet msbuild /t:GenerateCode` to generate code.

3. Upload the Azure.Communication.Chat.dll to the apiview.dev tool.
If any of the new objects needs to be overwritten, add the required changes to the 'Models' folder.

4. Repeat 2 and 3 until the desided interface is reflected in the apiview.dev 

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
input-file:
    -  $(this-folder)/swagger/swagger.json
payload-flattening-threshold: 10
directive:
  from: swagger-document
  where: $.definitions.*
  transform: >
    $["x-namespace"] = "Azure.Communication.Chat"
```
