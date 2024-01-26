# Azure.Communication.Chat
When a new version of the swagger needs to be updated:
1. Go to sdk\communication, and run `dotnet build /t:GenerateCode` to generate code.
2. Upload the Azure.Communication.Chat.dll to the apiview.dev tool.
If any of the new objects needs to be overwritten, add the required changes to the 'Models' folder.

3. Repeat 2 and 3 until the desided interface is reflected in the apiview.dev

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
title: Chat
tag: package-2024-03-07
model-namespace: false
require:
    -  https://raw.githubusercontent.com/Azure/azure-rest-api-specs/f579ddcd291d55b0a2a32ee81995432458db3da9/specification/communication/data-plane/Chat/readme.md
payload-flattening-threshold: 10
generation1-convenience-client: true
