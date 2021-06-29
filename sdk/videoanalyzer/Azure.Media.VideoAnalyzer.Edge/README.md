# Azure Video Analyzer Edge client library for .NET

Azure Video Analyzer provides a platform to build intelligent video applications that span the edge and the cloud. The platform offers the capability to capture, record, and analyze live video along with publishing the results, video and video analytics, to Azure services in the cloud or the edge. It is designed to be an extensible platform, enabling you to connect different video analysis edge modules such as Cognitive services containers, custom edge modules built by you with open source machine learning models or custom models trained with your own data. You can then use them to analyze live video without worrying about the complexity of building and running a live video pipeline.

Use the client library for Video Analyzer Edge to:

-   Simplify interactions with the [Microsoft Azure IoT SDKs](https://github.com/azure/azure-iot-sdks)
-   Programmatically construct pipeline topologies and live pipelines

[Product documentation][doc_product] | [Direct methods][doc_direct_methods] | [Pipelines][doc_pipelines] | [Source code][source] | [Samples][samples]

## Getting started

This is a models-only SDK. All client operations are done using the [Microsoft Azure IoT SDKs](https://github.com/azure/azure-iot-sdks). This SDK provides models you can use to interact with the Azure IoT SDKs.

### Authenticate the client

The client is coming from Azure IoT SDK. You will need to obtain an IoT device connection string in order to authenticate the Azure IoT SDK. For more information please visit: [https://github.com/Azure/azure-iot-sdk-csharp].

```C# Snippet:Azure_VideoAnalyzerSamples_ConnectionString
String connectionString = "connectionString";
ServiceClient serviceClient = ServiceClient.CreateFromConnectionString(connectionString);
```

### Install the package

Install the Video Analyzer Edge client library for .NET with NuGet:

```bash
dotnet add package Azure.Media.VideoAnalyzer.Edge --prerelease
```

Install the Azure IoT Hub SDk for .NET with NuGet:

```bash
dotnet add package Microsoft.Azure.Devices
```

### Prerequisites

-   You need an active [Azure subscription][azure_sub] and an IoT device connection string to use this package.
-   You will need to use the version of the SDK that corresponds to the version of the Video Analyzer Edge module you are using.

    | SDK          | Video Analyzer edge module |
    | ------------ | -------------------------- |
    | 1.0.0-beta.x | 1.0                        |

### Creating a pipeline topology and making requests

Please visit the [Examples](#examples) for starter code.

## Key concepts

### Pipeline topology vs live pipeline

A _pipeline topology_ is a blueprint or template for instantiating live pipelines. It defines the parameters of the pipeline using placeholders as values for them. A _live pipeline_ references a pipeline topology and specifies the parameters. This way you are able to have multiple live pipelines referencing the same topology but with different values for parameters. For more information please visit [pipeline topologies and live pipelines][doc_pipelines].

### CloudToDeviceMethod

The `CloudToDeviceMethod` is part of the [azure-iot-hub SDk][iot-hub-sdk]. This method allows you to communicate one way notifications to a device in your IoT hub. In our case, we want to communicate various methods such as `PipelineTopologySetRequest` and `PipelineTopologyGetRequest`. To use `CloudToDeviceMethod` you need to pass in one parameter: `MethodName` and then set the JSON payload of that method.

The parameter `MethodName` is the name of the request you are sending. Make sure to use each method's predefined `MethodName` property. For example, `PipelineTopologySetRequest.MethodName`.

To set the Json payload of the cloud method, use the pipeline request method's `GetPayloadAsJson()` function. For example, `directCloudMethod.SetPayloadJson(PipelineTopologySetRequest.GetPayloadAsJson())`

### Thread safety

We guarantee that all client instance methods are thread-safe and independent of each other ([guideline](https://azure.github.io/azure-sdk/dotnet_introduction.html#dotnet-service-methods-thread-safety)). This ensures that the recommendation of reusing client instances is always safe, even across threads.

### Additional concepts

<!-- CLIENT COMMON BAR -->

[Client options](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#configuring-service-clients-using-clientoptions) |
[Accessing the response](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#accessing-http-response-details-using-responset) |
[Long-running operations](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#consuming-long-running-operations-using-operationt) |
[Handling failures](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#reporting-errors-requestfailedexception) |
[Diagnostics](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/Diagnostics.md) |
[Mocking](https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/README.md#mocking) |
[Client lifetime](https://devblogs.microsoft.com/azure-sdk/lifetime-management-and-thread-safety-guarantees-of-azure-sdk-net-clients/)

<!-- CLIENT COMMON BAR -->

## Examples

### Creating a pipeline topology

To create a pipeline topology you need to define sources and sinks.

### Define Parameters

```C# Snippet:Azure_VideoAnalyzerSamples_SetParameters
pipelineTopologyProperties.Parameters.Add(new ParameterDeclaration("rtspUserName", ParameterType.String)
{
    Description = "rtsp source user name.",
    Default = "exampleUserName"
});
pipelineTopologyProperties.Parameters.Add(new ParameterDeclaration("rtspPassword", ParameterType.SecretString)
{
    Description = "rtsp source password.",
    Default = "examplePassword"
});
pipelineTopologyProperties.Parameters.Add(new ParameterDeclaration("rtspUrl", ParameterType.String)
{
    Description = "rtsp Url"
});
pipelineTopologyProperties.Parameters.Add(new ParameterDeclaration("hubSinkOutputName", ParameterType.String)
{
    Description = "hub sink output"
});
```

### Define a Source

```C# Snippet:Azure_VideoAnalyzerSamples_SetSourcesSinks1
pipelineTopologyProps.Sources.Add(new RtspSource("rtspSource", new UnsecuredEndpoint("${rtspUrl}")
{
    Credentials = new UsernamePasswordCredentials("${rtspUserName}", "${rtspPassword}")
})
);
```

### Define a Sink

```C# Snippet:Azure_VideoAnalyzerSamples_SetSourcesSinks2
var nodeInput = new List<NodeInput>
{
    new NodeInput("rtspSource")
};
pipelineTopologyProps.Sinks.Add(new IotHubMessageSink("msgSink", nodeInput, "${hubSinkOutputName}"));
```

### Set the topology properties and create a topology

```C# Snippet:Azure_VideoAnalyzerSamples_BuildPipelineTopology
var pipelineTopologyProps = new PipelineTopologyProperties
{
    Description = "Continuous video recording to a Video Analyzer video",
};
SetParameters(pipelineTopologyProps);
SetSources(pipelineTopologyProps);
SetSinks(pipelineTopologyProps);
return new PipelineTopology("ContinuousRecording")
{
    Properties = pipelineTopologyProps
};
```

### Creating a live pipeline

To create a live pipeline, you need to have an existing pipeline topology.

```C# Snippet:Azure_VideoAnalyzerSamples_BuildLivePipeline
var livePipelineProps = new LivePipelineProperties
{
    Description = "Sample description",
    TopologyName = topologyName,
};

livePipelineProps.Parameters.Add(new ParameterDefinition("rtspUrl", "rtsp://sample.com"));

return new LivePipeline("livePIpeline")
{
    Properties = livePipelineProps
};
```

### Invoking a direct method

To invoke a direct method on your device you need to first define the request using the Video Analyzer Edge SDK, then send that method request using the IoT SDK's `CloudToDeviceMethod`.

```C# Snippet:Azure_VideoAnalyzerSamples_InvokeDirectMethod
var setPipelineTopRequest = new PipelineTopologySetRequest(pipelineTopology);

var directMethod = new CloudToDeviceMethod(setPipelineTopRequest.MethodName);
directMethod.SetPayloadJson(setPipelineTopRequest.GetPayloadAsJson());

var setPipelineTopResponse = await serviceClient.InvokeDeviceMethodAsync(deviceId, moduleId, directMethod);
```

To try different pipeline topologies with the SDK, please see the official [Samples][samples].

## Troubleshooting

-   When sending a method request using the IoT Hub's `CloudToDeviceMethod` remember to not type in the method request name directly. Instead use `MethodRequestName.MethodName`

## Next steps

-   [Samples][samples]
-   [Azure IoT Device SDK][iot-device-sdk]
-   [Azure IoTHub Service SDK][iot-hub-sdk]

## Contributing

This project welcomes contributions and suggestions. Most contributions require
you to agree to a Contributor License Agreement (CLA) declaring that you have
the right to, and actually do, grant us the rights to use your contribution.
For details, visit https://cla.microsoft.com.

If you encounter any issues, please open an issue on our [Github][github-page-issues].

When you submit a pull request, a CLA-bot will automatically determine whether
you need to provide a CLA and decorate the PR appropriately (e.g., label,
comment). Simply follow the instructions provided by the bot. You will only
need to do this once across all repos using our CLA.

This project has adopted the
[Microsoft Open Source Code of Conduct][code_of_conduct]. For more information,
see the Code of Conduct FAQ or contact opencode@microsoft.com with any
additional questions or comments.

<!-- LINKS -->

[azure_cli]: https://docs.microsoft.com/cli/azure
[azure_sub]: https://azure.microsoft.com/free/
[cla]: https://cla.microsoft.com
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com
[package]: https://aka.ms/ava/sdk/client/net
[source]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/videoanalyzer
[samples]: https://github.com/Azure-Samples/live-video-analytics-iot-edge-csharp
[doc_direct_methods]: https://go.microsoft.com/fwlink/?linkid=2162396
[doc_pipelines]: https://go.microsoft.com/fwlink/?linkid=2162396
[doc_product]: https://go.microsoft.com/fwlink/?linkid=2162396
[iot-device-sdk]: https://www.nuget.org/packages/Microsoft.Azure.Devices.Client/
[iot-hub-sdk]: https://www.nuget.org/packages/Microsoft.Azure.Devices/
[github-page-issues]: https://github.com/Azure/azure-sdk-for-net/issues

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Fvideoanalyzer%2Fazure-media-videoanalyzer-edge%2FREADME.png)
