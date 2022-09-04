# Azure.Communication.Messaging
When a new version of the swagger needs to be updated:
1. Go to sdk\communication, and run `dotnet msbuild /t:GenerateCode` to generate code.
2. Upload the Azure.Communication.Messaging.dll to the apiview.dev tool.
If any of the new objects needs to be overwritten, add the required changes to the 'Models' folder.
3. Repeat 2 and 3 until the desided interface is reflected in the apiview.dev 
### AutoRest Configuration
> see https://aka.ms/autorest
``` yaml
input-file:
    - swagger.json
payload-flattening-threshold: 10
generation1-convenience-client: true
directive:
  from: swagger-document
  where: $.definitions.*
  transform: >
    $["x-namespace"] = "Azure.Communication.Messaging"
