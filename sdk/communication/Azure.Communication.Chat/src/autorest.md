# Azure.Communication.Chat
When a new version of the swagger needs to be updated:
1. Go to sdk\communication, and run `dotnet msbuild /t:GenerateCode` to generate code.
2. Upload the Azure.Communication.Chat.dll to the apiview.dev tool.
If any of the new objects needs to be overwritten, add the required changes to the 'Models' folder.

3. Repeat 2 and 3 until the desided interface is reflected in the apiview.dev 

### AutoRest Configuration
> see https://aka.ms/autorest

``` yaml
title: Chat
tag: package-chat-2023-07-01-preview
model-namespace: false
require:
    -  https://github.com/Azure/azure-rest-api-specs/blob/320e44c22609a1921424f6da30fa8fe4518bd5ca/specification/communication/data-plane/Chat/readme.md
payload-flattening-threshold: 10
generation1-convenience-client: true
directive:
  # Temporarily remove retention policy changes
  - where-model: ChatMessageContent
    remove-property: attachments
  - remove-model: AttachmentType
  - remove-model: ChatAttachment
