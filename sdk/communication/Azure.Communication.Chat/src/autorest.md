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
tag: package-chat-2023-11-07
model-namespace: false
require:
    -  https://raw.githubusercontent.com/Azure/azure-rest-api-specs/731138d0505c02fcee05d7b5a1417fd10ef5efc3/specification/communication/data-plane/Chat/readme.md
payload-flattening-threshold: 10
generation1-convenience-client: true
directive:
  # Temporarily remove retention policy changes
  - where-model: ChatMessageContent
    remove-property: attachments
  - remove-model: AttachmentType
  - remove-model: ChatAttachment
