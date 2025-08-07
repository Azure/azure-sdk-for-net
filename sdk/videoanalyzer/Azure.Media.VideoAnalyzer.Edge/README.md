# **_(Retired)_**. Azure Video Analyzer Edge client library for .NET

The Azure Video Analyzer preview service has been retired as of December, 2022.  This SDK is no longer supported or maintained.

Azure Video Analyzer is an [Azure Applied AI Service][applied-ai-service] that provides a platform for you to build intelligent video applications that can span both edge and cloud infrastructures. The platform offers the capability to capture, record, and analyze live video along with publishing the results, video and video analytics, to Azure services at the edge or in the cloud. It is designed to be an extensible platform, enabling you to connect different video inferencing edge modules such as Cognitive services modules, or custom inferencing modules that have been trained with your own data using either open-source machine learning or [Azure Machine Learning][machine-learning].

Use the client library for Video Analyzer Edge to:

-   Simplify interactions with the [Microsoft Azure IoT SDKs](https://github.com/azure/azure-iot-sdks)
-   Programmatically construct pipeline topologies and live pipelines

[Product documentation][doc_product] | [Source code][source] | [Samples][samples]

## Getting started

This is a models-only SDK. All client operations are done using the [Microsoft Azure IoT SDKs](https://github.com/azure/azure-iot-sdks). This SDK provides models you can use to interact with the Azure IoT SDKs.

### Authenticate the client

The client is coming from Azure IoT SDK. You will need to obtain an IoT device connection string in order to authenticate the Azure IoT SDK. For more information please visit: https://github.com/Azure/azure-iot-sdk-csharp.

```C# Snippet:Azure_VideoAnalyzerSamples_ConnectionString
string connectionString = System.Environment.GetEnvironmentVariable("iothub_connectionstring", EnvironmentVariableTarget.User);
var serviceClient = ServiceClient.CreateFromConnectionString(connectionString);
```

### Install the package

Install the Video Analyzer Edge client library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.Media.VideoAnalyzer.Edge --prerelease
```

Install the Azure IoT Hub SDk for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Microsoft.Azure.Devices
```

### Prerequisites

-   You need an active [Azure subscription][azure_sub] and an IoT device connection string to use this package.
-   You will need to use the version of the SDK that corresponds to the version of the Video Analyzer Edge module you are using.

    | SDK          | Video Analyzer edge module |
    | ------------ | -------------------------- |
    | 1.0.0-beta.5 | 1.1                        |
    | 1.0.0-beta.4 | 1.0                        |
    | 1.0.0-beta.3 | 1.0                        |
    | 1.0.0-beta.2 | 1.0                        |
    | 1.0.0-beta.1 | 1.0                        |

### Creating a pipeline topology and making requests

Please visit the [Examples](#examples) for starter code.

## Key concepts

### Pipeline topology vs live pipeline

A _pipeline topology_ is a blueprint or template for instantiating live pipelines. It defines the parameters of the pipeline using placeholders as values for them. A _live pipeline_ references a pipeline topology and specifies the parameters. This way you are able to have multiple live pipelines referencing the same topology but with different values for parameters.

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
[Mocking](https://learn.microsoft.com/dotnet/azure/sdk/unit-testing-mocking) |
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
pipelineTopologyProps.Sinks.Add(new VideoSink("videoSink", nodeInput, "video", "/var/lib/videoanalyzer/tmp/", "1024"));
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

var setPipelineTopResponse = await _serviceClient.InvokeDeviceMethodAsync(_deviceId, _moduleId, directMethod);
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
see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact opencode@microsoft.com with any
additional questions or comments.

<!-- LINKS -->

[azure_cli]: https://learn.microsoft.com/cli/azure
[azure_sub]: https://azure.microsoft.com/free/dotnet/
[cla]: https://cla.microsoft.com
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com
[package]: https://aka.ms/ava/sdk/client/net
[source]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/videoanalyzer/Azure.Media.VideoAnalyzer.Edge/src
[samples]: https://go.microsoft.com/fwlink/?linkid=2162276
[doc_product]: https://learn.microsoft.com/azure/azure-video-analyzer/video-analyzer-docs/
[iot-device-sdk]: https://www.nuget.org/packages/Microsoft.Azure.Devices.Client/
[iot-hub-sdk]: https://www.nuget.org/packages/Microsoft.Azure.Devices/
[github-page-issues]: https://github.com/Azure/azure-sdk-for-net/issues
[applied-ai-service]: https://azure.microsoft.com/product-categories/applied-ai-services/#services
[machine-learning]: https://azure.microsoft.com/services/machine-learning
