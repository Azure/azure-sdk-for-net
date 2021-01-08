# Azure Live Video Analytics for IoT Edge client library for .NET

Live Video Analytics on IoT Edge provides a platform to build intelligent video applications that span the edge and the cloud. The platform offers the capability to capture, record, and analyze live video along with publishing the results, video and video analytics, to Azure services in the cloud or the edge. It is designed to be an extensible platform, enabling you to connect different video analysis edge modules (such as Cognitive services containers, custom edge modules built by you with open-source machine learning models or custom models trained with your own data) to it and use them to analyze live video without worrying about the complexity of building and running a live video pipeline.

Use the client library for Live Video Analytics on IoT Edge to:

- Simplify interactions with the [Microsoft Azure IoT SDKs](https://github.com/azure/azure-iot-sdks) 
- Programatically construct media graph topologies and instances

[Product documentation][doc_product] | [Direct methods][doc_direct_methods] | [Media graphs][doc_media_graph] | [Source code][source] | [Samples][samples]

## Getting started

This is a models only sdk. All client operations are done using the [Microsoft Azure IoT SDKs](https://github.com/azure/azure-iot-sdks). This sdk provides models you can use to interact with the Azure Iot SDKs.

### Authenticate the client

As mentioned above the client is coming from Azure IoT SDK. You will need to obtain an [IoT device connection string][iot_device_connection_string] in order to authenticate the Azure IoT SDK. For more information please visit: https://github.com/Azure/azure-iot-sdk-csharp. 
```C# Snippet:Azure_MediaServices_Samples_ConnectionString
var connectionString = "connectionString";
this._serviceClient = ServiceClient.CreateFromConnectionString(connectionString);
```

### Install the package

Install the Live Video Analytics client library for .NET with NuGet:

`dotnet add package Azure.Media.Analytics.Edge --version 1.0.0-beta.1`

Install the Azure IoT Hub SDk for .Net with NuGet:

`dotnet add package Microsoft.Azure.Devices --version 1.28.1`

### Prerequisites

* C# is required to use this package.
* You need an active [Azure subscription][azure_sub], and an [IoT device connection string][iot_device_connection_string] to use this package.
* You will need to use the version of the SDK that corresponds to the version of the LVA Edge module you are using.

    | SDK  | LVA Edge Module  |
    |---|---|
    | 1.0.0b1  | 2.0  |

### Creating a graph topology and making requests
Please visit the [Examples](#examples) for starter code
## Key concepts

### MediaGraph Topology vs MediaGraph Instance
A _graph topology_ is a blueprint or template of a graph. It defines the parameters of the graph using placeholders as values for them. A _graph instance_ references a graph topology and specifies the parameters. This way you are able to have multiple graph instances referencing the same topology but with different values for parameters. For more information please visit [Media graph topologies and instances][doc_media_graph] 

### CloudToDeviceMethod

The `CloudToDeviceMethod` is part of the [azure-iot-hub SDk][iot-hub-sdk]. This method allows you to communicate one way notifications to a device in your IoT hub. In our case, we want to communicate various graph methods such as `MediaGraphTopologySetRequest` and `MediaGraphTopologyGetRequest`. To use `CloudToDeviceMethod` you need to pass in one parameter: `method_name` and then set the Json payload of that method. 

The parameter `method_name` is the name of the media graph request you are sending. Make sure to use each method's predefined `method_name` property. For example, `MediaGraphTopologySetRequest.method_name`. 

To set the Json payload of the cloud method, use the media graph request method's `GetPayloadAsJson()` function. For example, `directCloudMethod.SetPayloadJson(MediaGraphTopologySetRequest.GetPayloadAsJson())`

## Examples

### Creating a graph topology
To create a graph topology you need to define parameters, sources, and sinks.
```C# Snippet:Azure_MediaServices_Samples_SetParameters
// Add parameters to Topology
private void SetParameters(MediaGraphTopologyProperties graphProperties)
{
    graphProperties.Parameters.Add(new MediaGraphParameterDeclaration("rtspUserName", MediaGraphParameterType.String)
    {
        Description = "rtsp source user name.",
        Default = "dummyUserName"
    });
    graphProperties.Parameters.Add(new MediaGraphParameterDeclaration("rtspPassword", MediaGraphParameterType.SecretString)
    {
        Description = "rtsp source password.",
        Default = "dummyPassword"
    });
    graphProperties.Parameters.Add(new MediaGraphParameterDeclaration("rtspUrl", MediaGraphParameterType.String)
    {
        Description = "rtsp Url"
    });
}
```

```C# Snippet:Azure_MediaServices_Samples_SetSourcesSinks
// Add sources to Topology
private void SetSources(MediaGraphTopologyProperties graphProperties)
{
    graphProperties.Sources.Add(new MediaGraphRtspSource("rtspSource", new MediaGraphUnsecuredEndpoint("${rtspUrl}")
        {
            Credentials = new MediaGraphUsernamePasswordCredentials("${rtspUserName}", "${rtspPassword}")
        })
    );
}

// Add sinks to Topology
private void SetSinks(MediaGraphTopologyProperties graphProperties)
{
    var graphNodeInput = new List<MediaGraphNodeInput>
    {
        new MediaGraphNodeInput("rtspSource")
    };
    var cachePath = "/var/lib/azuremediaservices/tmp/";
    var cacheMaxSize = "2048";
    graphProperties.Sinks.Add(new MediaGraphAssetSink("assetSink", graphNodeInput, "sampleAsset-${System.GraphTopologyName}-${System.GraphInstanceName}", cachePath, cacheMaxSize)
    {
        SegmentLength = System.Xml.XmlConvert.ToString(TimeSpan.FromSeconds(30)),
    });
}
```

```C# Snippet:Azure_MediaServices_Samples_BuildTopology
private MediaGraphTopology BuildGraphTopology()
{
    var graphProperties = new MediaGraphTopologyProperties
    {
        Description = "Continuous video recording to an Azure Media Services Asset",
    };
    SetParameters(graphProperties);
    SetSources(graphProperties);
    SetSinks(graphProperties);
    return new MediaGraphTopology("ContinuousRecording")
    {
        Properties = graphProperties
    };
}
```

### Creating a graph instance 
To create a graph instance, you need to have an existing graph topology.
```C# Snippet:Azure_MediaServices_Samples_BuildInstance
private MediaGraphInstance BuildGraphInstance(string graphTopologyName)
{
    var graphInstanceProperties = new MediaGraphInstanceProperties
    {
        Description = "Sample graph description",
        TopologyName = graphTopologyName,
    };

    graphInstanceProperties.Parameters.Add(new MediaGraphParameterDefinition("rtspUrl", "rtsp://sample.com"));

    return new MediaGraphInstance("graphInstance")
    {
        Properties = graphInstanceProperties
    };
}
```

### Invoking a graph method request
To invoke a graph method on your device you need to first define the request using the lva sdk. Then send that method request using the iot sdk's `CloudToDeviceMethod`
```C# Snippet:Azure_MediaServices_Samples_InvokeDirectMethod
var setGraphRequest = new MediaGraphTopologySetRequest(graphTopology);

var directMethod = new CloudToDeviceMethod(setGraphRequest.MethodName);
directMethod.SetPayloadJson(setGraphRequest.GetPayloadAsJson());

var setGraphResponse = await _serviceClient.InvokeDeviceMethodAsync(_deviceId, _moduleId, directMethod);
```

To try different media graph topologies with the SDK, please see the official [Samples][samples].

## Troubleshooting

- When sending a method request using the IoT Hub's `CloudToDeviceMethod` remember to not type in the method request name directly. Instead use `[MethodRequestName.method_name]`
- Make sure to serialize the entire method request before passing it to `CloudToDeviceMethod`

## Next steps

- [Samples][samples]
- [Azure IoT Device SDK][iot-device-sdk]
- [Azure IoTHub Service SDK][iot-hub-sdk]

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

[package]: TODO://link-to-published-package
[source]: https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/mediaservices
[samples]: https://github.com/Azure-Samples/live-video-analytics-iot-edge-csharp

[doc_direct_methods]: https://docs.microsoft.com/azure/media-services/live-video-analytics-edge/direct-methods
[doc_media_graph]: https://docs.microsoft.com/azure/media-services/live-video-analytics-edge/media-graph-concept#media-graph-topologies-and-instances
[doc_product]: https://docs.microsoft.com/azure/media-services/live-video-analytics-edge/

[iot-device-sdk]: https://www.nuget.org/packages/Microsoft.Azure.Devices.Client/
[iot-hub-sdk]: https://www.nuget.org/packages/Microsoft.Azure.Devices/
[iot_device_connection_string]: https://docs.microsoft.com/azure/media-services/live-video-analytics-edge/get-started-detect-motion-emit-events-quickstart

[github-page-issues]: https://github.com/Azure/azure-sdk-for-net/issues
