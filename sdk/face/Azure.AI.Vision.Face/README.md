# Azure AI Face client library for .NET

The Azure AI Face service provides AI algorithms that detect, recognize, and analyze human faces in images. It includes the following main features:

- Face detection and analysis
- Liveness detection
- Face recognition
  - Face verification ("one-to-one" matching)
  - Face identification ("one-to-many" matching)
- Find similar faces
- Group faces

[Source code][source_code] | [Package (NuGet)][face_nuget] | [API reference documentation][face_ref_docs] | [Product documentation][face_product_docs] | [Samples][face_samples]

## Getting started

### Install the package

Install the client library for .NET with [NuGet][nuget]:

```dotnetcli
dotnet add package Azure.AI.Vision.Face --prerelease
```

### Prerequisites

- Your Azure account must have a `Cognitive Services Contributor` role assigned in order for you to agree to the responsible AI terms and create a resource. To get this role assigned to your account, follow the steps in the [Assign roles][steps_assign_an_azure_role] documentation, or contact your administrator.
- You need an [Azure subscription][azure_sub] to use this package and either
  - an [Azure Face account][azure_portal_list_face_account] or
  - an [Azure AI services multi-service account][azure_portal_list_cognitive_service_account]

### Create a Face or an Azure AI services multi-service account

Azure AI Face supports both [multi-service][azure_ai_account] and single-service access. Create an Azure AI services multi-service account if you plan to access multiple cognitive services under a single endpoint/key. For Face access only, create a Face resource.

- To create a new Face or Azure AI services multi-service account, you can use [Azure Portal][azure_portal_create_face_account], [Azure PowerShell][quick_start_create_account_via_azure_powershell], or [Azure CLI][quick_start_create_account_via_azure_cli].

### Authenticate the client

In order to interact with the Face service, you will need to create an instance of a client.
An **endpoint** and **credential** are necessary to instantiate the client object.
For enhanced security, we strongly recommend utilizing Microsoft Entra ID credential for authentication in the production environment, while AzureKeyCredential should be reserved exclusively for the testing environment.

#### Get the endpoint

You can find the endpoint for your Face resource using the [Azure Portal][get_endpoint_via_azure_portal] or [Azure CLI][get_endpoint_via_azure_cli]:

```bash
# Get the endpoint for the Face resource
az cognitiveservices account show --name "resource-name" --resource-group "resource-group-name" --query "properties.endpoint"
```

Either a regional endpoint or a custom subdomain can be used for authentication. They are formatted as follows:

```
Regional endpoint: https://<region>.api.cognitive.microsoft.com/
Custom subdomain: https://<resource-name>.cognitiveservices.azure.com/
```

A regional endpoint is the same for every resource in a region. A complete list of supported regional endpoints can be consulted [here][regional_endpoints]. Please note that regional endpoints do not support Microsoft Entra ID authentication. If you'd like migrate your resource to use custom subdomain, follow the instructions [here][how_to_migrate_resource_to_custom_subdomain].

A custom subdomain, on the other hand, is a name that is unique to the resource. Once created and linked to a resource, it cannot be modified.

#### Create the client with a Microsoft Entra ID credential

You can authenticate our service with Microsoft Entra ID using the [Azure Identity][azure_sdk_net_identity] library.
Note that regional endpoints do not support Microsoft Entra ID authentication. Create a [custom subdomain][custom_subdomain] name for your resource in order to use this type of authentication.

To use the [DefaultAzureCredential][azure_sdk_net_default_azure_credential] type shown below, or other credential types provided with the Azure SDK, please install the `azure-identity` package:

```dotnetcli
dotnet add package Azure.Identity
```

You will also need to [register a new AAD application and grant access][register_aad_app] to Face by assigning the `"Cognitive Services User"` role to your service principal.

Once completed, set the values of the client ID, tenant ID, and client secret of the AAD application as environment variables:
`AZURE_CLIENT_ID`, `AZURE_TENANT_ID`, `AZURE_CLIENT_SECRET`.

```C# Snippet:CreateFaceClient
Uri endpoint = new Uri("<your endpoint>");
DefaultAzureCredential credential = new DefaultAzureCredential();
var client = new FaceClient(endpoint, credential);
```

#### Create the client with AzureKeyCredential

To use an API key as the `credential` parameter, pass the key as a string into an instance of [AzureKeyCredential][azure_sdk_net_azure_key_credential]. You can find the key for your Face resource using the [Azure Portal][get_endpoint_via_azure_portal] or [Azure CLI][get_endpoint_via_azure_cli]:

```bash
# Get the API keys for the Face resource
az cognitiveservices account keys list --name "<resource-name>" --resource-group "<resource-group-name>"
```

```C# Snippet:CreateFaceClientWithKey
Uri endpoint = new Uri("<your endpoint>");
AzureKeyCredential credential = new AzureKeyCredential("<your apiKey>");
var client = new FaceClient(endpoint, credential);
```

### Service API versions

The client library targets the latest service API version by default. A client instance accepts an optional service API version parameter from its options to specify which API version service to communicate.

#### Select a service API version

You have the flexibility to explicitly select a supported service API version when instantiating a client by configuring its associated options. This ensures that the client can communicate with services using the specified API version.

For example,

```C# Snippet:CreateFaceClientWithVersion
Uri endpoint = new Uri("<your endpoint>");
DefaultAzureCredential credential = new DefaultAzureCredential();
AzureAIVisionFaceClientOptions options = new AzureAIVisionFaceClientOptions(AzureAIVisionFaceClientOptions.ServiceVersion.V1_2_Preview_1);
FaceClient client = new FaceClient(endpoint, credential, options);
```

When selecting an API version, it's important to verify that there are no breaking changes compared to the latest API version. If there are significant differences, API calls may fail due to incompatibility.

Always ensure that the chosen API version is fully supported and operational for your specific use case and that it aligns with the service's versioning policy.


## Key concepts

### FaceClient

`FaceClient` provides operations for:

- Face detection and analysis: Detect human faces in an image and return the rectangle coordinates of their locations, and optionally with landmarks, and face-related attributes. This operation is required as a first step in all the other face recognition scenarios.
- Face recognition: Confirm that a user is who they claim to be based on how closely their face data matches the target face. It includes Face verification ("one-to-one" matching) and Face identification ("one-to-many" matching).
- Finding similar faces from a smaller set of faces that look similar to the target face.
- Grouping faces into several smaller groups based on similarity.

### FaceAdministrationClient

`FaceAdministrationClient` is provided to interact with the following data structures that hold data on faces and
persons for Face recognition:

- LargeFaceList
- LargePersonGroup

### FaceSessionClient

`FaceSessionClient` is provided to interact with sessions which is used for Liveness detection.

- Create, query, and delete the session.
- Query the liveness and verification result.
- Query the audit result.

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

The following section provides several code snippets covering some of the most common Face tasks, including:

- [Detecting faces in an image](#face-detection "Face Detection")

- [Determining if a face in an video is real (live) or fake (spoof)](#liveness-detection "Liveness Detection")

### Face Detection

Detect faces and analyze them from an binary data.

```C# Snippet:DetectFaces
using var stream = new FileStream(imagePath, FileMode.Open, FileAccess.Read);

var detectResponse = client.Detect(
    BinaryData.FromStream(stream),
    FaceDetectionModel.Detection03,
    FaceRecognitionModel.Recognition04,
    returnFaceId: false,
    returnFaceAttributes: new[] { FaceAttributeType.Detection03.HeadPose, FaceAttributeType.Detection03.Mask, FaceAttributeType.Recognition04.QualityForRecognition },
    returnFaceLandmarks: true,
    returnRecognitionModel: true,
    faceIdTimeToLive: 120);

var detectedFaces = detectResponse.Value;
Console.WriteLine($"Detected {detectedFaces.Count} face(s) in the image.");
foreach (var detectedFace in detectedFaces)
{
    Console.WriteLine($"Face Rectangle: left={detectedFace.FaceRectangle.Left}, top={detectedFace.FaceRectangle.Top}, width={detectedFace.FaceRectangle.Width}, height={detectedFace.FaceRectangle.Height}");
    Console.WriteLine($"Head pose: pitch={detectedFace.FaceAttributes.HeadPose.Pitch}, roll={detectedFace.FaceAttributes.HeadPose.Roll}, yaw={detectedFace.FaceAttributes.HeadPose.Yaw}");
    Console.WriteLine($"Mask: NoseAndMouthCovered={detectedFace.FaceAttributes.Mask.NoseAndMouthCovered}, Type={detectedFace.FaceAttributes.Mask.Type}");
    Console.WriteLine($"Quality: {detectedFace.FaceAttributes.QualityForRecognition}");
    Console.WriteLine($"Recognition model: {detectedFace.RecognitionModel}");
    Console.WriteLine($"Landmarks: ");

    Console.WriteLine($"    PupilLeft: ({detectedFace.FaceLandmarks.PupilLeft.X}, {detectedFace.FaceLandmarks.PupilLeft.Y})");
    Console.WriteLine($"    PupilRight: ({detectedFace.FaceLandmarks.PupilRight.X}, {detectedFace.FaceLandmarks.PupilRight.Y})");
    Console.WriteLine($"    NoseTip: ({detectedFace.FaceLandmarks.NoseTip.X}, {detectedFace.FaceLandmarks.NoseTip.Y})");
    Console.WriteLine($"    MouthLeft: ({detectedFace.FaceLandmarks.MouthLeft.X}, {detectedFace.FaceLandmarks.MouthLeft.Y})");
    Console.WriteLine($"    MouthRight: ({detectedFace.FaceLandmarks.MouthRight.X}, {detectedFace.FaceLandmarks.MouthRight.Y})");
    Console.WriteLine($"    EyebrowLeftOuter: ({detectedFace.FaceLandmarks.EyebrowLeftOuter.X}, {detectedFace.FaceLandmarks.EyebrowLeftOuter.Y})");
    Console.WriteLine($"    EyebrowLeftInner: ({detectedFace.FaceLandmarks.EyebrowLeftInner.X}, {detectedFace.FaceLandmarks.EyebrowLeftInner.Y})");
    Console.WriteLine($"    EyeLeftOuter: ({detectedFace.FaceLandmarks.EyeLeftOuter.X}, {detectedFace.FaceLandmarks.EyeLeftOuter.Y})");
    Console.WriteLine($"    EyeLeftTop: ({detectedFace.FaceLandmarks.EyeLeftTop.X}, {detectedFace.FaceLandmarks.EyeLeftTop.Y})");
    Console.WriteLine($"    EyeLeftBottom: ({detectedFace.FaceLandmarks.EyeLeftBottom.X}, {detectedFace.FaceLandmarks.EyeLeftBottom.Y})");
    Console.WriteLine($"    EyeLeftInner: ({detectedFace.FaceLandmarks.EyeLeftInner.X}, {detectedFace.FaceLandmarks.EyeLeftInner.Y})");
    Console.WriteLine($"    EyebrowRightInner: ({detectedFace.FaceLandmarks.EyebrowRightInner.X}, {detectedFace.FaceLandmarks.EyebrowRightInner.Y})");
    Console.WriteLine($"    EyebrowRightOuter: ({detectedFace.FaceLandmarks.EyebrowRightOuter.X}, {detectedFace.FaceLandmarks.EyebrowRightOuter.Y})");
    Console.WriteLine($"    EyeRightInner: ({detectedFace.FaceLandmarks.EyeRightInner.X}, {detectedFace.FaceLandmarks.EyeRightInner.Y})");
    Console.WriteLine($"    EyeRightTop: ({detectedFace.FaceLandmarks.EyeRightTop.X}, {detectedFace.FaceLandmarks.EyeRightTop.Y})");
    Console.WriteLine($"    EyeRightBottom: ({detectedFace.FaceLandmarks.EyeRightBottom.X}, {detectedFace.FaceLandmarks.EyeRightBottom.Y})");
    Console.WriteLine($"    EyeRightOuter: ({detectedFace.FaceLandmarks.EyeRightOuter.X}, {detectedFace.FaceLandmarks.EyeRightOuter.Y})");
    Console.WriteLine($"    NoseRootLeft: ({detectedFace.FaceLandmarks.NoseRootLeft.X}, {detectedFace.FaceLandmarks.NoseRootLeft.Y})");
    Console.WriteLine($"    NoseRootRight: ({detectedFace.FaceLandmarks.NoseRootRight.X}, {detectedFace.FaceLandmarks.NoseRootRight.Y})");
    Console.WriteLine($"    NoseLeftAlarTop: ({detectedFace.FaceLandmarks.NoseLeftAlarTop.X}, {detectedFace.FaceLandmarks.NoseLeftAlarTop.Y})");
    Console.WriteLine($"    NoseRightAlarTop: ({detectedFace.FaceLandmarks.NoseRightAlarTop.X}, {detectedFace.FaceLandmarks.NoseRightAlarTop.Y})");
    Console.WriteLine($"    NoseLeftAlarOutTip: ({detectedFace.FaceLandmarks.NoseLeftAlarOutTip.X}, {detectedFace.FaceLandmarks.NoseLeftAlarOutTip.Y})");
    Console.WriteLine($"    NoseRightAlarOutTip: ({detectedFace.FaceLandmarks.NoseRightAlarOutTip.X}, {detectedFace.FaceLandmarks.NoseRightAlarOutTip.Y})");
    Console.WriteLine($"    UpperLipTop: ({detectedFace.FaceLandmarks.UpperLipTop.X}, {detectedFace.FaceLandmarks.UpperLipTop.Y})");
    Console.WriteLine($"    UpperLipBottom: ({detectedFace.FaceLandmarks.UpperLipBottom.X}, {detectedFace.FaceLandmarks.UpperLipBottom.Y})");
    Console.WriteLine($"    UnderLipTop: ({detectedFace.FaceLandmarks.UnderLipTop.X}, {detectedFace.FaceLandmarks.UnderLipTop.Y})");
    Console.WriteLine($"    UnderLipBottom: ({detectedFace.FaceLandmarks.UnderLipBottom.X}, {detectedFace.FaceLandmarks.UnderLipBottom.Y})");
}
```

For more information, see [Face Detection Sample][face_sample_detection].

### Liveness detection

Face Liveness detection can be used to determine if a face in an input video stream is real (live) or fake (spoof).
The goal of liveness detection is to ensure that the system is interacting with a physically present live person at
the time of authentication. The whole process of authentication is called a session.

There're two different components in the authentication: a frontend application and an app server/orchestrator.
Before uploading the video stream, the app server has to create a session, and then the frontend client could upload
the payload with a `session authorization token` to call the liveness detection. The app server can query for the
liveness detection result and audit logs anytime until the session is deleted.

The Liveness detection operation can not only confirm if the input is live or spoof, but also verify whether the input
belongs to the expected person's face, which is called **liveness detection with face verification**. For the detail
information, please refer to the [tutorial][liveness_tutorial].

This package is only responsible for app server to create, query, delete a session and get audit logs. For how to
integrate the UI and the code into your native frontend application, please follow instructions in the [tutorial][liveness_tutorial].

Here is an example to create the session for liveness detection.

```C# Snippet:CreateLivenessSession
var createContent = new CreateLivenessSessionContent(LivenessOperationMode.Passive) {
    SendResultsToClient = true,
    DeviceCorrelationId = Guid.NewGuid().ToString(),
};

var createResponse = sessionClient.CreateLivenessSession(createContent);

var sessionId = createResponse.Value.SessionId;
Console.WriteLine($"Session created, SessionId: {sessionId}");
Console.WriteLine($"AuthToken: {createResponse.Value.AuthToken}");
```

After you've performed liveness detection, you can retrieve the result by providing the session ID.

```C# Snippet:GetLivenessSessionResult
var getResultResponse = sessionClient.GetLivenessSessionResult(sessionId);
var sessionResult = getResultResponse.Value;
Console.WriteLine($"Id: {sessionResult.Id}");
Console.WriteLine($"CreatedDateTime: {sessionResult.CreatedDateTime}");
Console.WriteLine($"SessionExpired: {sessionResult.SessionExpired}");
Console.WriteLine($"DeviceCorrelationId: {sessionResult.DeviceCorrelationId}");
Console.WriteLine($"AuthTokenTimeToLiveInSeconds: {sessionResult.AuthTokenTimeToLiveInSeconds}");
Console.WriteLine($"Status: {sessionResult.Status}");
Console.WriteLine($"SessionStartDateTime: {sessionResult.SessionStartDateTime}");
if (sessionResult.Result != null) {
    WriteLivenessSessionAuditEntry(sessionResult.Result);
}
```

For more information, see [Liveness Detection Sample][face_sample_liveness_session].
There is also a sample for [Liveness Detection with Face Verification][face_sample_liveness_with_verify_session].

## Troubleshooting

### General

When you interact with the Face client library using the .NET SDK, errors returned by the service will result in a `RequestFailedException` with the same HTTP status code returned by the REST API request.

For example, if you submit a image with an invalid `Uri`, a `400` error is returned, indicating "Bad Request".

```C# Snippet:DetectFacesInvalidUrl
var invalidUri = new Uri("http://invalid.uri");
try {
    var detectResponse = client.Detect(
        invalidUri,
        FaceDetectionModel.Detection01,
        FaceRecognitionModel.Recognition04,
        returnFaceId: false);
}
catch (RequestFailedException ex)
{
    Console.WriteLine(ex.ToString());
}
```

You will notice that additional information is logged, like the client request ID of the operation.

```
Azure.RequestFailedException: Invalid image URL or error downloading from target server. Remote server error returned: "Name or service not known"
Status: 400 (Bad Request)
ErrorCode: InvalidURL

Content:
{"error":{"code":"InvalidURL","message":"Invalid image URL or error downloading from target server. Remote server error returned: \"Name or service not known\""}}

Headers:
Date: Fri, 03 May 2024 07:34:53 GMT
Server: istio-envoy
x-envoy-upstream-service-time: REDACTED
apim-request-id: REDACTED
Strict-Transport-Security: REDACTED
X-Content-Type-Options: REDACTED
x-ms-region: REDACTED
CSP-Billing-Usage: REDACTED
Content-Length: 162
Content-Type: application/json; charset=utf-8
```

### Setting up console logging

The simplest way to see the logs is to enable the console logging.

To create an Azure SDK log listener that outputs messages to console use the AzureEventSourceListener.CreateConsoleLogger method.

```C#
// Setup a listener to monitor logged events.
using AzureEventSourceListener listener = AzureEventSourceListener.CreateConsoleLogger();
```

To learn more about other logging mechanisms see [Diagnostics Samples][logging].

## Next steps

### More sample code

See the [Samples][face_samples] for several code snippets illustrating common patterns used in the Face .NET SDK.

### Additional documentation

For more extensive documentation on Azure AI Face, see the [Face documentation][face_product_docs] on learn.microsoft.com.

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit [cla.microsoft.com][cla].

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct][code_of_conduct]. For more information see the [Code of Conduct FAQ][coc_faq] or contact [opencode@microsoft.com][coc_contact] with any additional questions or comments.

<!-- LINKS -->
[source_code]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/face/Azure.AI.Vision.Face/src
[face_nuget]: https://aka.ms/azsdk-csharp-face-pkg
[face_ref_docs]: https://aka.ms/azsdk-csharp-face-ref
[face_product_docs]: https://learn.microsoft.com/azure/ai-services/computer-vision/overview-identity
[face_samples]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/face/Azure.AI.Vision.Face/samples

[nuget]: https://www.nuget.org/
[steps_assign_an_azure_role]: https://learn.microsoft.com/azure/role-based-access-control/role-assignments-steps
[azure_sub]: https://azure.microsoft.com/free/
[azure_portal_list_face_account]: https://portal.azure.com/#blade/Microsoft_Azure_ProjectOxford/CognitiveServicesHub/Face
[azure_ai_account]: https://learn.microsoft.com/azure/ai-services/multi-service-resource?tabs=windows&pivots=azportal
[azure_portal_list_cognitive_service_account]: https://portal.azure.com/#view/Microsoft_Azure_ProjectOxford/CognitiveServicesHub/~/AllInOne
[azure_portal_create_face_account]: https://portal.azure.com/#create/Microsoft.CognitiveServicesFace
[quick_start_create_account_via_azure_cli]: https://learn.microsoft.com/azure/ai-services/multi-service-resource?tabs=windows&pivots=azcli
[quick_start_create_account_via_azure_powershell]: https://learn.microsoft.com/azure/ai-services/multi-service-resource?tabs=windows&pivots=azpowershell

[regional_endpoints]: https://azure.microsoft.com/global-infrastructure/services/?products=cognitive-services
[how_to_migrate_resource_to_custom_subdomain]: https://learn.microsoft.com/azure/ai-services/cognitive-services-custom-subdomains#how-does-this-impact-existing-resources
[get_endpoint_via_azure_portal]: https://learn.microsoft.com/azure/ai-services/multi-service-resource?tabs=windows&pivots=azportal#get-the-keys-for-your-resource
[get_endpoint_via_azure_cli]: https://learn.microsoft.com/azure/ai-services/multi-service-resource?tabs=windows&pivots=azcli#get-the-keys-for-your-resource
[azure_sdk_net_azure_key_credential]: https://learn.microsoft.com/dotnet/api/azure.azurekeycredential?view=azure-dotnet
[azure_sdk_net_identity]: https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet
[custom_subdomain]: https://learn.microsoft.com/azure/cognitive-services/authentication#create-a-resource-with-a-custom-subdomain
[azure_sdk_net_default_azure_credential]: https://learn.microsoft.com/dotnet/api/azure.identity.defaultazurecredential?view=azure-dotnet
[register_aad_app]: https://learn.microsoft.com/azure/cognitive-services/authentication#assign-a-role-to-a-service-principal

[face_sample_detection]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/face/Azure.AI.Vision.Face/samples/Sample1_FaceDetection.md
[liveness_tutorial]: https://learn.microsoft.com/azure/ai-services/computer-vision/tutorials/liveness
[face_sample_liveness_session]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/face/Azure.AI.Vision.Face/samples/Sample2_DetectLivenessWithSession.md
[face_sample_liveness_with_verify_session]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/face/Azure.AI.Vision.Face/samples/Sample3_DetectLivenessWithVerifyWithSession.md

[logging]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/core/Azure.Core/samples/Diagnostics.md

[cla]: https://cla.microsoft.com
[code_of_conduct]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com
