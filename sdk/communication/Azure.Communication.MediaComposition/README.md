# Azure Communication Media Composition client library for .NET

Azure Communication Media Composition allows developers to compose media streams using various layouts.

[Source code][source]

## Getting started

### Install the package
> TODO

### Prerequisites
You need an [Azure subscription][azure_sub] and a [Communication Service Resource][communication_resource_docs] to use this package.

To create a new Communication Service, you can use the [Azure Portal][communication_resource_create_portal], the [Azure PowerShell][communication_resource_create_power_shell], or the [.NET management client library][communication_resource_create_net].

### Authenticate the client
The media composition client can be authenticated using a connection string acquired from an Azure Communication Resources in the [Azure Portal][azure_portal].

```C# Snippet:CreateMediaCompositionClient
var connectionString = "<connection_string>";
var client = new MediaCompositionClient(connectionString);
```

Or alternatively using the endpoint and access key acquired from an Azure Communication Resources in the [Azure Portal][azure_portal].

```C# Snippet:CreateMediaCompositionClientFromAccessKey
var endpoint = new Uri("https://my-resource.communication.azure.com");
var accessKey = "<access_key>";
var client= new MediaCompositionClient(endpoint, new AzureKeyCredential(accessKey));
```

Clients also have the option to authenticate using a valid Active Directory token.

```C# Snippet:CreateMediaCompositionClientFromToken
var resourceEndpoint = new Uri("https://my-resource.communication.azure.com");
TokenCredential tokenCredential = new DefaultAzureCredential();
var client = new MediaCompositionClient(endpoint, tokenCredential);
```

### Key concepts
`MediaCompositionComponent` provides the functionalities to create media compositions by defining inputs, layout, and outputs. The created media composition can then be updated, started, stopped, and deleted.

### Thread safety
> TODO

## Examples
### Creating the media composition

```C# Snippet:CreateMediaComposition
var layout = new GridLayout(2, 2, new List<List<string>>{ new List<string> { "jill", "jack" }, new List<string> { "jane", "jerry" } })
{
    Resolution = new(1920, 1080)
};

var inputs = new Dictionary<string, MediaInput>()
{
    ["jill"] = new ParticipantInput
    (
        id: new CommunicationUserIdentifier("f3ba9014-6dca-4456-8ec0-fa03cfa2b7b7"),
        call: "acsGroupCall")
    {
        PlaceholderImageUri = "https://imageendpoint"
    },
    ["jack"] = new ParticipantInput
    (
        id: new CommunicationUserIdentifier("fa4337b5-f13a-41c5-a34f-f2aa46699b61"),
        call: "acsGroupCall")
    {
        PlaceholderImageUri = "https://imageendpoint"
    },
    ["jane"] = new ParticipantInput
    (
        id: new CommunicationUserIdentifier("2dd69470-dc25-49cf-b5c3-f562f08bf3b2"),
        call: "acsGroupCall"
    )
    {
        PlaceholderImageUri = "https://imageendpoint"
    },
    ["jerry"] = new ParticipantInput
    (
        id: new CommunicationUserIdentifier("30e29fde-ac1c-448f-bb34-0f3448d5a677"),
        call: "acsGroupCall")
    {
        PlaceholderImageUri = "https://imageendpoint"
    },
    ["acsGroupCall"] = new GroupCallInput("d12d2277-ffec-4e22-9979-8c0d8c13d193")
};

var outputs = new Dictionary<string, MediaOutput>()
{
    ["acsGroupCall"] = new GroupCallOutput("d12d2277-ffec-4e22-9979-8c0d8c13d193")
};

var response = await mediaCompositionClient.CreateAsync(mediaCompositionId, layout, inputs, outputs);
```

### Getting an existing media composition

```C# Snippet:GetMediaComposition
var gridMediaCompositionResponse = await mediaCompositionClient.GetAsync(mediaCompositionId);
```

### Updating an existing media composition

You can update the layout:
```C# Snippet:UpdateLayout
var layout = new AutoGridLayout(new List<string>() { "acsGroupCall" })
{
    Resolution = new(720, 480),
};

var response = await mediaCompositionClient.UpdateLayoutAsync(mediaCompositionId, layout);
```

Note: Upserting `GroupCall` and `Room` input kind is currently not supported if the media composition is running. The media composition will need to be stopped if `GroupCall` or `Room` inputs need to change.
You can upsert or remove inputs:

```C# Snippet:UpsertInputs
var inputsToUpsert = new Dictionary<string, MediaInput>()
{
    ["james"] = new ParticipantInput
    (
        id: new CommunicationUserIdentifier("f3ba9014-6dca-4456-8ec0-fa03cfa2b70p"),
        call: "acsGroupCall"
    )
    {
        PlaceholderImageUri = "https://imageendpoint"
    }
};

var response = await mediaCompositionClient.UpsertInputsAsync(mediaCompositionId, inputsToUpsert);
```

```C# Snippet:RemoveInputs
var inputIdsToRemove = new List<string>()
{
    "jane", "jerry"
};
var response = await mediaCompositionClient.RemoveInputsAsync(mediaCompositionId, inputIdsToRemove);
```

You can also upsert or remove outputs:
```C# Snippet:UpsertOutputs
var outputsToUpsert = new Dictionary<string, MediaOutput>()
{
    ["youtube"] = new RtmpOutput("key", new(1920, 1080), "rtmp://a.rtmp.youtube.com/live2")
};

var response = await mediaCompositionClient.UpsertOutputsAsync(mediaCompositionId, outputsToUpsert);
```

```C# Snippet:RemoveOutputs
var outputIdsToRemove = new List<string>()
{
    "acsGroupCall"
};
var response = await mediaCompositionClient.RemoveOutputsAsync(mediaCompositionId, outputIdsToRemove);
```

### Starting the media composition to start streaming

```C# Snippet:StartMediaComposition
var compositionSteamState = await mediaCompositionClient.StartAsync(mediaCompositionId);
```

### Stopping the media composition to stop streaming

```C# Snippet:StopMediaComposition
var compositionSteamState = await mediaCompositionClient.StopAsync(mediaCompositionId);
```

### Deleting the media composition

```C# Snippet:DeleteMediaComposition
await mediaCompositionClient.DeleteAsync(mediaCompositionId);
```

## Troubleshooting
> TODO

## Next steps
> TODO

## Contributing
This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [cla.microsoft.com][cla].

This project has adopted the [Microsoft Open Source Code of Conduct][coc]. For more information see the [Code of Conduct FAQ][coc_faq] or contact [opencode@microsoft.com][coc_contact] with any additional questions or comments.

<!-- LINKS -->
[azure_sub]: https://azure.microsoft.com/free/dotnet/
[azure_portal]: https://portal.azure.com
[source]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/communication/Azure.Communication.MediaComposition/src
[cla]: https://cla.microsoft.com
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com
[communication_resource_create_portal]:  https://docs.microsoft.com/azure/communication-services/quickstarts/create-communication-resource?tabs=windows&pivots=platform-azp
[communication_resource_create_power_shell]: https://docs.microsoft.com/powershell/module/az.communication/new-azcommunicationservice
[communication_resource_create_net]: https://docs.microsoft.com/azure/communication-services/quickstarts/create-communication-resource?tabs=windows&pivots=platform-net
[communication_resource_docs]: https://docs.microsoft.com/azure/communication-services/quickstarts/create-communication-resource?tabs=windows&pivots=platform-azp
