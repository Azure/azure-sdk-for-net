# Detect liveness in faces with verify with session

This sample demonstrates how to create a liveness with verify session and query the liveness detection with face verification result. For more information about the liveness solution, see the [service documentation][face_liveness].

![liveness with verify diagram](https://learn.microsoft.com/en-us/azure/ai-services/computer-vision/media/liveness/liveness-verify-diagram.jpg)

To get started you'll need an Azure AI resource or a Face resource. See [README][README] for prerequisites and instructions.

## 1. Start liveness check

A client device will send a request to app server to start liveness check.

## 2. Create session

App server send a request to Face API to create a liveness session.

### Creating a `FaceSessionClient`

To create a new `FaceSessionClient` you need the endpoint and credentials from your resource. In the sample below you'll use a `DefaultAzureCredential` object to authenticate. You can set `endpoint` based on an environment variable, a configuration setting, or any way that works for your application. See [Authenticate the client][README_authticate] for instructions.

```C# Snippet:CreateFaceSessionClient
Uri endpoint = new Uri("<your endpoint>");
DefaultAzureCredential credential = new DefaultAzureCredential();
var sessionClient = new FaceSessionClient(endpoint, credential);
```

### Create a liveness detection with verification session

Before you can detect liveness in a face, you need to create a liveness detection session with Azure AI Face Service. The service creates a liveness-session and responds back with a session-authorization-token.

```C# Snippet:CreateLivenessWithVerifySessionAsync
var parameters = new CreateLivenessWithVerifySessionContent(LivenessOperationMode.Passive) {
    SendResultsToClient = true,
    DeviceCorrelationId = Guid.NewGuid().ToString(),
};

using var fileStream = new FileStream(FaceTestConstant.LocalSampleImage, FileMode.Open, FileAccess.Read);

var createResponse = await sessionClient.CreateLivenessWithVerifySessionAsync(parameters, fileStream);

var sessionId = createResponse.Value.SessionId;
Console.WriteLine($"Session created, SessionId: {sessionId}");
Console.WriteLine($"AuthToken: {createResponse.Value.AuthToken}");
Console.WriteLine($"VerifyImage.FaceRectangle: {createResponse.Value.VerifyImage.FaceRectangle.Top}, {createResponse.Value.VerifyImage.FaceRectangle.Left}, {createResponse.Value.VerifyImage.FaceRectangle.Width}, {createResponse.Value.VerifyImage.FaceRectangle.Height}");
Console.WriteLine($"VerifyImage.QualityForRecognition: {createResponse.Value.VerifyImage.QualityForRecognition}");
```

## 3. Pass the AuthToken to client device

Client device will process the step 4, 5, 6 in the documentation [Perform liveness detection with face verification
][perform_liveness_detection_with_face_verification].

## 7. Wait for liveness session to complete

Client device should notify app server that liveness session has completed.

## 8. Query for liveness result

After you've performed liveness detection with verification , you can retrieve the result by providing the session ID.

```C# Snippet:GetLivenessWithVerifySessionResultAsync
var getResultResponse = await sessionClient.GetLivenessWithVerifySessionResultAsync(sessionId);
var sessionResult = getResultResponse.Value;
Console.WriteLine($"Id: {sessionResult.Id}");
Console.WriteLine($"CreatedDateTime: {sessionResult.CreatedDateTime}");
Console.WriteLine($"SessionExpired: {sessionResult.SessionExpired}");
Console.WriteLine($"DeviceCorrelationId: {sessionResult.DeviceCorrelationId}");
Console.WriteLine($"AuthTokenTimeToLiveInSeconds: {sessionResult.AuthTokenTimeToLiveInSeconds}");
Console.WriteLine($"Status: {sessionResult.Status}");
Console.WriteLine($"SessionStartDateTime: {sessionResult.SessionStartDateTime}");
if (sessionResult.Result != null) {
    WriteLivenessWithVerifySessionAuditEntry(sessionResult.Result);
}
```

```C# Snippet:WriteLivenessWithVerifySessionAuditEntry
public void WriteLivenessWithVerifySessionAuditEntry(LivenessSessionAuditEntry auditEntry)
{
    Console.WriteLine($"Id: {auditEntry.Id}");
    Console.WriteLine($"SessionId: {auditEntry.SessionId}");
    Console.WriteLine($"RequestId: {auditEntry.RequestId}");
    Console.WriteLine($"ClientRequestId: {auditEntry.ClientRequestId}");
    Console.WriteLine($"ReceivedDateTime: {auditEntry.ReceivedDateTime}");
    Console.WriteLine($"Digest: {auditEntry.Digest}");

    Console.WriteLine($"    Request Url: {auditEntry.Request.Url}");
    Console.WriteLine($"    Request Method: {auditEntry.Request.Method}");
    Console.WriteLine($"    Request ContentLength: {auditEntry.Request.ContentLength}");
    Console.WriteLine($"    Request ContentType: {auditEntry.Request.ContentType}");
    Console.WriteLine($"    Request UserAgent: {auditEntry.Request.UserAgent}");

    Console.WriteLine($"    Response StatusCode: {auditEntry.Response.StatusCode}");
    Console.WriteLine($"    Response LatencyInMilliseconds: {auditEntry.Response.LatencyInMilliseconds}");
    Console.WriteLine($"        Response Body LivenessDecision: {auditEntry.Response.Body.LivenessDecision}");
    Console.WriteLine($"        Response Body ModelVersionUsed: {auditEntry.Response.Body.ModelVersionUsed}");
    Console.WriteLine($"        Response Body Target FaceRectangle: {auditEntry.Response.Body.Target.FaceRectangle.Top}, {auditEntry.Response.Body.Target.FaceRectangle.Left}, {auditEntry.Response.Body.Target.FaceRectangle.Width}, {auditEntry.Response.Body.Target.FaceRectangle.Height}");
    Console.WriteLine($"        Response Body Target FileName: {auditEntry.Response.Body.Target.FileName}");
    Console.WriteLine($"        Response Body Target TimeOffsetWithinFile: {auditEntry.Response.Body.Target.TimeOffsetWithinFile}");
    Console.WriteLine($"        Response Body Target FaceImageType: {auditEntry.Response.Body.Target.ImageType}");

    Console.WriteLine($"        Response Body VerifyResult IsIdentical: {auditEntry.Response.Body.VerifyResult.IsIdentical}");
    Console.WriteLine($"        Response Body VerifyResult MatchConfidence: {auditEntry.Response.Body.VerifyResult.MatchConfidence}");
    Console.WriteLine($"        Response Body VerifyResult VerifyImage.FaceRectangle: {auditEntry.Response.Body.VerifyResult.VerifyImage.FaceRectangle.Top}, {auditEntry.Response.Body.VerifyResult.VerifyImage.FaceRectangle.Left}, {auditEntry.Response.Body.VerifyResult.VerifyImage.FaceRectangle.Width}, {auditEntry.Response.Body.VerifyResult.VerifyImage.FaceRectangle.Height}");
    Console.WriteLine($"        Response Body VerifyResult VerifyImage.QualityForRecognition: {auditEntry.Response.Body.VerifyResult.VerifyImage.QualityForRecognition}");
}
```

If there are multiple liveness calls, you can retrieve the result by getting liveness audit entries.

```C# Snippet:GetLivenessWithVerifySessionAuditEntriesAsync
var getAuditEntriesResponse = await sessionClient.GetLivenessWithVerifySessionAuditEntriesAsync(sessionId);
foreach (var auditEntry in getAuditEntriesResponse.Value)
{
    WriteLivenessWithVerifySessionAuditEntry(auditEntry);
}
```

## List all liveness sessions

All existing sessions can be listed by sending a request to the service.

```C# Snippet:GetLivenessWithVerifySessionsAsync
var listResponse = await sessionClient.GetLivenessWithVerifySessionsAsync();
foreach (var session in listResponse.Value)
{
    Console.WriteLine($"SessionId: {session.Id}");
    Console.WriteLine($"CreatedDateTime: {session.CreatedDateTime}");
    Console.WriteLine($"SessionExpired: {session.SessionExpired}");
    Console.WriteLine($"DeviceCorrelationId: {session.DeviceCorrelationId}");
    Console.WriteLine($"AuthTokenTimeToLiveInSeconds: {session.AuthTokenTimeToLiveInSeconds}");
    Console.WriteLine($"SessionStartDateTime: {session.SessionStartDateTime}");
}
```

## Delete session

Session can be revoked by sending delete request to the service. Corresponding authorization token will no longer have access to the service.

```C# Snippet:DeleteLivenessWithVerifySessionAsync
await sessionClient.DeleteLivenessWithVerifySessionAsync(sessionId);
```

[README]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/face/Azure.AI.Vision.Face#getting-started
[README_authticate]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/face/Azure.AI.Vision.Face#authenticate-the-client
[face_liveness]: https://learn.microsoft.com/azure/ai-services/computer-vision/tutorials/liveness
[perform_liveness_detection_with_face_verification]: https://learn.microsoft.com/azure/ai-services/computer-vision/tutorials/liveness#perform-liveness-detection-with-face-verification
