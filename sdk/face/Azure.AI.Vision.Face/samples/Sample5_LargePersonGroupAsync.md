# Verification and identification from Large Person Group

This sample demonstrates how to verify and identify faces from a large person group.

To get started you'll need an Azure AI resource or a Face resource. See [README][README] for prerequisites and instructions.

## Create the Large Person Group

To create a large person group, you'll need `LargePersonGroupClient` object.
    
```C# Snippet:CreateLargePersonGroupClient
Uri endpoint = new Uri("<your endpoint>");
DefaultAzureCredential credential = new DefaultAzureCredential();
var groupClient = new LargePersonGroupClient(endpoint, credential, id);
```

Call `CreateAsync` to create a large person group. You need to provide the ID of the large person group you want to create with a name and optional user data.

```C# Snippet:VerifyAndIdentifyFromLargePersonGroup_CreateLargePersonGroupAsync
await groupClient.CreateAsync("Family 1", userData: "A sweet family", recognitionModel: FaceRecognitionModel.Recognition04);
```

## Create the `Person` with faces in the Large Person Group

The `Person` object is used to represent the individual you want to identify. You can call `CreateLargePersonGroupPerson` to create it within Large Person Group. Call `AddLargePersonGroupPersonFace` to add faces to the person.

```C# Snippet:VerifyAndIdentifyFromLargePersonGroup_CreatePersonAndAddFacesAsync
var persons = new[]
{
    new { Name = "Bill", UserData = "Dad", ImageUrls = new[] { FaceTestConstant.UrlFamily1Dad1Image, FaceTestConstant.UrlFamily1Dad2Image } },
    new { Name = "Clare", UserData = "Mom", ImageUrls = new[] { FaceTestConstant.UrlFamily1Mom1Image, FaceTestConstant.UrlFamily1Mom2Image } },
    new { Name = "Ron", UserData = "Son", ImageUrls = new[] { FaceTestConstant.UrlFamily1Son1Image, FaceTestConstant.UrlFamily1Son2Image } }
};
var personIds = new Dictionary<string, Guid>();

foreach (var person in persons)
{
    var createPersonResponse = await groupClient.CreatePersonAsync(person.Name, userData: person.UserData);
    var personId = createPersonResponse.Value.PersonId;
    personIds.Add(person.Name, personId);

    foreach (var imageUrl in person.ImageUrls)
    {
        await groupClient.AddFaceAsync(personId, new Uri(imageUrl), userData: $"{person.UserData}-{imageUrl}", detectionModel: FaceDetectionModel.Detection03);
    }
}
```

## Train the Large Person Group before performing identification

Before you can identify faces, you must train the large person group. Call `TrainLargePersonGroup` to start the training process. `TrainLargePersonGroup` is a long-running operation that may take a while to complete.

```C# Snippet:VerifyAndIdentifyFromLargePersonGroup_TrainAsync
var operation = await groupClient.TrainAsync(WaitUntil.Completed);
await operation.WaitForCompletionResponseAsync();
```

## Verify a face against a `Person` in the Large Person Group

To verify a face against a `Person` in the large person group, call `VerifyFromLargePersonGroup`. This method returns a `VerifyResult` object that contains the confidence score of the verification.

```C# Snippet:VerifyAndIdentifyFromLargePersonGroup_VerifyAsync
var verifyDadResponse = await faceClient.VerifyFromLargePersonGroupAsync(faceId, groupId, personIds["Bill"]);
Console.WriteLine($"Is the detected face Bill? {verifyDadResponse.Value.IsIdentical} ({verifyDadResponse.Value.Confidence})");

var verifyMomResponse = await faceClient.VerifyFromLargePersonGroupAsync(faceId, groupId, personIds["Clare"]);
Console.WriteLine($"Is the detected face Clare? {verifyMomResponse.Value.IsIdentical} ({verifyMomResponse.Value.Confidence})");
```

## Identify a face from the Large Person Group

To identify a face from the large person group, call `IdentifyFromLargePersonGroup`. This method returns a list of `IdentifyResult` objects, each containing the `Person` ID and the confidence score of the identification.

```C# Snippet:VerifyAndIdentifyFromLargePersonGroup_IdentifyAsync
var identifyResponse = await faceClient.IdentifyFromLargePersonGroupAsync(new[] { faceId }, groupId);
foreach (var candidate in identifyResponse.Value[0].Candidates)
{
    var person = await groupClient.GetPersonAsync(candidate.PersonId);
    Console.WriteLine($"The detected face belongs to {person.Value.Name} ({candidate.Confidence})");
}
```

## Delete the Large Person Group

When you no longer need the large person group, you can delete it by calling `DeleteLargePersonGroup`. The associated persons and faces will also be deleted.

```C# Snippet:VerifyAndIdentifyFromLargePersonGroup_DeleteLargePersonGroupAsync
await groupClient.DeleteAsync();
```

[README]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/face/Azure.AI.Vision.Face#getting-started