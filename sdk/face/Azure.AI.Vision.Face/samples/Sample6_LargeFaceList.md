# Find similar faces from a large face list

This sample demonstrates how to find similar faces from a large face list.

To get started you'll need an Azure AI resource or a Face resource. See [README][README] for prerequisites and instructions.

## Create the Large Face List

To create a large face list, you'll need `LargeFaceListClient` object.

```C# Snippet:CreateLargeFaceListClient
Uri endpoint = new Uri("<your endpoint>");
DefaultAzureCredential credential = new DefaultAzureCredential();
var listClient = new LargeFaceListClient(endpoint, credential, id);
```

Call `Create` to create a large face list. You can specify the `name` and `userData` for the large face list.

```C# Snippet:CreateLargeFaceList
listClient.Create("Family 1", userData: "A sweet family", recognitionModel: FaceRecognitionModel.Recognition04);
```

## Add faces to the Large Face List

To add faces to the large face list, call `AddFace`. You can specify the `imageUri` and `userData` for the face.

```C# Snippet:AddFacesToLargeFaceList
var faces = new[]
{
    new { UserData = "Dad", ImageUrl = new Uri(FaceTestConstant.UrlFamily1Dad1Image) },
    new { UserData = "Mom", ImageUrl = new Uri(FaceTestConstant.UrlFamily1Mom1Image) },
    new { UserData = "Son", ImageUrl = new Uri(FaceTestConstant.UrlFamily1Son1Image) }
};
var faceIds = new Dictionary<Guid, string>();

foreach (var face in faces)
{
    var addFaceResponse = listClient.AddFace(face.ImageUrl, userData: face.UserData);
    faceIds[addFaceResponse.Value.PersistedFaceId] = face.UserData;
}
```

## Train the Large Face List before finding similar faces

Before you can identify faces, you must train the large face list by calling `Train`. This method is asynchronous and returns an `Operation` object that you can use to wait for the training to complete.

```C# Snippet:TrainLargeFaceList
var operation = listClient.Train(WaitUntil.Completed);
operation.WaitForCompletionResponse();
```

## Find similar faces from the Large Face List

To find similar faces from the large face list, call `FindSimilar`. This method returns a list of `FaceSimilarResult` objects that contain the `FaceId` of the face and a `Confidence` score indicating the similarity between the face and the query face.

```C# Snippet:FindSimilarFromLargeFaceList
var faceClient = CreateClient();
var detectResponse = faceClient.Detect(new Uri(FaceTestConstant.UrlFamily1Dad3Image), FaceDetectionModel.Detection03, FaceRecognitionModel.Recognition04, true);
var faceId = detectResponse.Value[0].FaceId.Value;

var findSimilarResponse = faceClient.FindSimilarFromLargeFaceList(faceId, listId);
foreach (var similarFace in findSimilarResponse.Value)
{
    Console.WriteLine($"The detected face is similar to the face with '{faceIds[similarFace.PersistedFaceId.Value]}' ID {similarFace.PersistedFaceId} ({similarFace.Confidence})");
}
```

## Delete the Large Face List

When you no longer need the large face list, you can delete it by calling `Delete`.

```C# Snippet:DeleteLargeFaceList
listClient.Delete();
```

[README]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/face/Azure.AI.Vision.Face#getting-started