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
tag: package-chat-2024-03-07
model-namespace: false
require:
    -  https://raw.githubusercontent.com/Azure/azure-rest-api-specs/72d4c8cae964a12dc27ad4684b0bddf493225338/specification/communication/data-plane/Chat/readme.md
payload-flattening-threshold: 10
generation1-convenience-client: true
