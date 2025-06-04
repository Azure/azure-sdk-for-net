# Stateless face recognition

This sample demonstrates how to recognize faces in an image without data structure.

To get started you'll need an Azure AI resource or a Face resource. See [README][README] for prerequisites and instructions.

## Creating a `FaceClient`

To create a new `FaceClient` you need the endpoint and credentials from your resource. In the sample below you'll use a `DefaultAzureCredential` object to authenticate. You can set `endpoint` based on an environment variable, a configuration setting, or any way that works for your application. See [Authenticate the client][README_authticate] for instructions.

```C# Snippet:CreateFaceClient
Uri endpoint = new Uri("<your endpoint>");
DefaultAzureCredential credential = new DefaultAzureCredential();
var client = new FaceClient(endpoint, credential);
```

## Verify whether two faces belong to the same person

To verify whether two faces belong to the same person, you can use the `VerifyFaceToFaceAsync` method. This method returns a `FaceVerificationResult` object that contains a `Confidence` score indicating the similarity between the two faces.

```C# Snippet:VerifyFaceToFaceAsync
var data = new (string Name, Uri Uri)[] {
    ("Dad image 1", new Uri(FaceTestConstant.UrlFamily1Dad1Image)),
    ("Dad image 2", new Uri(FaceTestConstant.UrlFamily1Dad2Image)),
    ("Son image 1", new Uri(FaceTestConstant.UrlFamily1Son1Image))
};
var faceIds = new List<Guid>();

foreach (var tuple in data)
{
    var detectResponse = await client.DetectAsync(tuple.Uri, FaceDetectionModel.Detection03, FaceRecognitionModel.Recognition04, true);
    Console.WriteLine($"Detected {detectResponse.Value.Count} face(s) in the image '{tuple.Name}'.");
    faceIds.Add(detectResponse.Value.Single().FaceId.Value);
}

var verifyDad1Dad2Response = await client.VerifyFaceToFaceAsync(faceIds[0], faceIds[1]);
Console.WriteLine($"Verification between Dad image 1 and Dad image 2: {verifyDad1Dad2Response.Value.Confidence}");
Console.WriteLine($"Is the same person: {verifyDad1Dad2Response.Value.IsIdentical}");

var verifyDad1SonResponse = await client.VerifyFaceToFaceAsync(faceIds[0], faceIds[2]);
Console.WriteLine($"Verification between Dad image 1 and Son image 1: {verifyDad1SonResponse.Value.Confidence}");
Console.WriteLine($"Is the same person: {verifyDad1SonResponse.Value.IsIdentical}");
```

## Find similar faces from a list of faces

To find similar faces from a list of faces, you can use the `FindSimilarAsync` method. This method returns a list of `FaceFindSimilarResult` objects that contain the `FaceId` of the face and a `Confidence` score indicating the similarity between the face and the query face.

```C# Snippet:FindSimilarAsync
var dadImage = new Uri(FaceTestConstant.UrlFamily1Dad1Image);
var detectDadResponse = await client.DetectAsync(dadImage, FaceDetectionModel.Detection03, FaceRecognitionModel.Recognition04, true);
Console.WriteLine($"Detected {detectDadResponse.Value.Count} face(s) in the Dad image.");
var dadFaceId = detectDadResponse.Value.Single().FaceId.Value;

var targetImage = new Uri(FaceTestConstant.UrlIdentification1Image);
var detectResponse = await client.DetectAsync(targetImage, FaceDetectionModel.Detection03, FaceRecognitionModel.Recognition04, true);
Console.WriteLine($"Detected {detectResponse.Value.Count} face(s) in the image.");
var faceIds = detectResponse.Value.Select(face => face.FaceId.Value);

var response = await client.FindSimilarAsync(dadFaceId, faceIds);
var similarFaces = response.Value;
Console.WriteLine($"Found {similarFaces.Count} similar face(s) in the target image.");
foreach (var similarFace in similarFaces)
{
    Console.WriteLine($"Face ID: {similarFace.FaceId}, confidence: {similarFace.Confidence}");
}
```

## Group faces

To group faces, you can use the `GroupAsync` method. This method returns a `FaceGroupingResult` objects that contain a 2 dimensional array of faces. Each array represents a group of faces that belong to the same person. There is also a faces array that contains all the faces that were not grouped.

```C# Snippet:GroupAsync
var targetImages = new (string, Uri)[] {
    ("Group image", new Uri(FaceTestConstant.UrlIdentification1Image)),
    ("Dad image 1", new Uri(FaceTestConstant.UrlFamily1Dad1Image)),
    ("Dad image 2", new Uri(FaceTestConstant.UrlFamily1Dad2Image)),
    ("Son image 1", new Uri(FaceTestConstant.UrlFamily1Son1Image))
};
var faceIds = new Dictionary<Guid, (FaceDetectionResult, string)>();

foreach (var (imageName, targetImage) in targetImages)
{
    var detectResponse = await client.DetectAsync(targetImage, FaceDetectionModel.Detection03, FaceRecognitionModel.Recognition04, true);
    Console.WriteLine($"Detected {detectResponse.Value.Count} face(s) in the image '{imageName}'.");
    foreach (var face in detectResponse.Value)
    {
        faceIds[face.FaceId.Value] = (face, imageName);
    }
}

var groupResponse = await client.GroupAsync(faceIds.Keys);
var groups = groupResponse.Value;

Console.WriteLine($"Found {groups.Groups.Count} group(s) in the target images.");
foreach (var group in groups.Groups)
{
    Console.WriteLine($"Group: ");
    foreach (var faceId in group)
    {
        Console.WriteLine($" {faceId} from '{faceIds[faceId].Item2}', face rectangle: {faceIds[faceId].Item1.FaceRectangle.Left}, {faceIds[faceId].Item1.FaceRectangle.Top}, {faceIds[faceId].Item1.FaceRectangle.Width}, {faceIds[faceId].Item1.FaceRectangle.Height}");
    }
}

Console.WriteLine($"Found {groups.MessyGroup.Count} face(s) that are not in any group.");
foreach (var faceId in groups.MessyGroup)
{
    Console.WriteLine($" {faceId} from '{faceIds[faceId].Item2}', face rectangle: {faceIds[faceId].Item1.FaceRectangle.Left}, {faceIds[faceId].Item1.FaceRectangle.Top}, {faceIds[faceId].Item1.FaceRectangle.Width}, {faceIds[faceId].Item1.FaceRectangle.Height}");
}
```

[README]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/face/Azure.AI.Vision.Face#getting-started
[README_authticate]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/face/Azure.AI.Vision.Face#authenticate-the-client
