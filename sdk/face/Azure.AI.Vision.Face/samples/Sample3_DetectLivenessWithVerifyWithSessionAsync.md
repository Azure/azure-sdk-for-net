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
using var fileStream = new FileStream(FaceTestConstant.LocalSampleImage, FileMode.Open, FileAccess.Read);
var parameters = new CreateLivenessWithVerifySessionContent(LivenessOperationMode.Passive, fileStream)
{
    DeviceCorrelationId = Guid.NewGuid().ToString(),
};

var createResponse = await sessionClient.CreateLivenessWithVerifySessionAsync(parameters);

var sessionId = createResponse.Value.SessionId;
Console.WriteLine($"Session created, SessionId: {sessionId}");
Console.WriteLine($"AuthToken: {createResponse.Value.AuthToken}");

var results = createResponse.Value.Results;
if (results.VerifyReferences.Count > 0)
{
    var verifyReference = results.VerifyReferences[0];
    Console.WriteLine($"VerifyImage.FaceRectangle: {verifyReference.FaceRectangle.Top}, {verifyReference.FaceRectangle.Left}, {verifyReference.FaceRectangle.Width}, {verifyReference.FaceRectangle.Height}");
    Console.WriteLine($"VerifyImage.QualityForRecognition: {verifyReference.QualityForRecognition}");
}
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
Console.WriteLine($"Id: {sessionResult.SessionId}");
Console.WriteLine($"Status: {sessionResult.Status}");
if (sessionResult.Results != null)
{
    WriteLivenessWithVerifySessionResults(sessionResult.Results);
}
```

```C# Snippet:WriteLivenessWithVerifySessionResults
public void WriteLivenessWithVerifySessionResults(LivenessWithVerifySessionResults results)
{
    if (results.Attempts?.Count == 0)
    {
        Console.WriteLine("No attempts found in the session results.");
        return;
    }

    var firstAttempt = results.Attempts[0];
    Console.WriteLine($"Attempt ID: {firstAttempt.AttemptId}");
    Console.WriteLine($"Attempt Status: {firstAttempt.AttemptStatus}");

    if (firstAttempt.Result != null)
    {
        var result = firstAttempt.Result;
        Console.WriteLine($"    Liveness Decision: {result.LivenessDecision}");
        Console.WriteLine($"    Digest: {result.Digest}");
        Console.WriteLine($"    Session Image ID: {result.SessionImageId}");

        if (result.Targets?.Color?.FaceRectangle != null)
        {
            var faceRect = result.Targets.Color.FaceRectangle;
            Console.WriteLine($"    Target Face Rectangle: Top={faceRect.Top}, Left={faceRect.Left}, Width={faceRect.Width}, Height={faceRect.Height}");
        }

        if (result.VerifyResult != null)
        {
            Console.WriteLine($"    Verify Result IsIdentical: {result.VerifyResult.IsIdentical}");
            Console.WriteLine($"    Verify Result MatchConfidence: {result.VerifyResult.MatchConfidence}");
        }

        Console.WriteLine($"    Verify Image Hash: {result.VerifyImageHash}");
    }

    if (results.VerifyReferences != null && results.VerifyReferences.Count > 0)
    {
        var verifyRef = results.VerifyReferences[0];
        if (verifyRef.FaceRectangle != null)
        {
            Console.WriteLine($"    Verify Reference Face Rectangle: Top={verifyRef.FaceRectangle.Top}, Left={verifyRef.FaceRectangle.Left}, Width={verifyRef.FaceRectangle.Width}, Height={verifyRef.FaceRectangle.Height}");
        }
        Console.WriteLine($"    Verify Reference Quality For Recognition: {verifyRef.QualityForRecognition}");
    }

    if (firstAttempt.ClientInformation != null && firstAttempt.ClientInformation.Count > 0)
    {
        Console.WriteLine($"    Client Information Count: {firstAttempt.ClientInformation.Count}");
    }
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
