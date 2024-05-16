# Verification and identification from Person Directory

This sample demonstrates how to identify and verify faces from Person Directory.

To get started you'll need an Azure AI resource or a Face resource. See [README][README] for prerequisites and instructions.

## Face verification with person in Person Directory

Face verification is a process of comparing a face detected in an image. User can create `Person` in Person Directory and add faces into it. The face in the image is compared to the person in the Person Directory and the result is returned as a confidence score.

### Create the `Person` with faces for verification

To create a Person, you need to call the `CreatePerson` API and provide a name with optional user data. The `CreatePerson` API is a long-running operation and returns a `Person` object with a unique `PersonId`. You can add faces to the `Person` by calling the `AddFace` API with the `PersonId` and the image stream. `AddFace` API is also a long-running operation and returns a `PersonDirectoryFace` object with a unique `PersistedFaceId`.

```C# Snippet:VerifyFromPersonDirectory_CreatePersonAndAddFace
var personData = new[]
{
    new { Name = "Bill", UserData = "Family1,singing", ImageUrls = new[] { FaceTestConstant.UrlFamily1Dad1Image, FaceTestConstant.UrlFamily1Dad2Image } },
    new { Name = "Ron", UserData = "Family1", ImageUrls = new[] { FaceTestConstant.UrlFamily1Son1Image, FaceTestConstant.UrlFamily1Son2Image } }
};

var personIds = new Dictionary<string, Guid>();

foreach (var person in personData)
{
    var createPersonOperation = administrationClient.CreatePerson(WaitUntil.Started, person.Name, userData: person.UserData);
    var personId = createPersonOperation.Value.PersonId;
    personIds.Add(person.Name, personId);

    foreach (var imageUrl in person.ImageUrls)
    {
        administrationClient.AddPersonFaceFromUrl(
            WaitUntil.Started,
            personId,
            FaceRecognitionModel.Recognition04,
            new Uri(imageUrl),
            detectionModel: FaceDetectionModel.Detection03);
    }
}
```

### Verify the face with the `Person`

With a face ID returned from a `Detect` call, you can verify if the face belongs to a specific `Person` enrolled inside the Person Directory.

```C# Snippet:VerifyFromPersonDirectory_VerifyPerson
var detectResponse = faceClient.DetectFromUrl(
    new Uri(FaceTestConstant.UrlFamily1Dad3Image),
    recognitionModel: FaceRecognitionModel.Recognition04,
    detectionModel: FaceDetectionModel.Detection03,
    returnFaceId: true);
var targetFaceId = detectResponse.Value[0].FaceId.Value;

var verifyBillResponse = faceClient.VerifyFromPersonDirectory(targetFaceId, personIds["Bill"]);
Console.WriteLine($"Face verification result for person Bill. IsIdentical: {verifyBillResponse.Value.IsIdentical}, Confidence: {verifyBillResponse.Value.Confidence}");

var verifyRonResponse = faceClient.VerifyFromPersonDirectory(targetFaceId, personIds["Ron"]);
Console.WriteLine($"Face verification result for person Ron. IsIdentical: {verifyRonResponse.Value.IsIdentical}, Confidence: {verifyRonResponse.Value.Confidence}");
```

### Delete the `Person` from Person Directory

You can delete the `Person` from the Person Directory by calling the `DeletePerson` API with the `PersonId`. `DeletePerson` API is a long-running operation and returns an empty response.

```C# Snippet:VerifyFromPersonDirectory_DeletePerson
administrationClient.DeletePerson(WaitUntil.Started, personIds["Bill"]);
administrationClient.DeletePerson(WaitUntil.Started, personIds["Ron"]);
```

## Face identification with persons in Person Directory

The most common way to use face data in a Person Directory is to compare the enrolled `Person` objects against a given face and identify the most likely candidate it belongs to. Multiple faces can be provided in the request, and each will receive its own set of comparison results in the response.

### Create the `Person` with faces for identification

The process of creating a `Person` with faces is the same as for verification. While verification does not require the long-running operation to complete, identification does. The `CreatePerson` and `AddFace` operations need to be completed before performing identification. When adding multiple faces to the same `Person`, we can optimize the process by waiting for the completion of the last `AddFace` operation.

```C# Snippet:IdentifyFromPersonDirectory_CreatePersonAndAddFace
var personData = new[]
{
    new { Name = "Ron", UserData = "Family1", ImageUrls = new[] { FaceTestConstant.UrlFamily1Son1Image, FaceTestConstant.UrlFamily1Son2Image } },
    new { Name = "Gill", UserData = "Family1", ImageUrls = new[] { FaceTestConstant.UrlFamily1Daughter1Image, FaceTestConstant.UrlFamily1Daughter2Image } },
    new { Name = "Anna", UserData = "Family2,singing", ImageUrls = new[] { FaceTestConstant.UrlFamily2Lady1Image, FaceTestConstant.UrlFamily2Lady2Image } }
};

var personIds = new Dictionary<string, Guid>();
var createPersonOperations = new List<Operation<PersonDirectoryPerson>>();
var lastAddFaceOperations = new List<Operation<PersonDirectoryFace>>();

foreach (var person in personData)
{
    var createPersonOperation = administrationClient.CreatePerson(WaitUntil.Started, person.Name, userData: person.UserData);
    createPersonOperations.Add(createPersonOperation);
    var personId = createPersonOperation.Value.PersonId;
    personIds.Add(person.Name, personId);

    // It is an optimization to wait till the last added face is finished processing in a series as all faces for person are processed in series.
    Operation<PersonDirectoryFace> lastAddFaceOperation = null;
    foreach (var imageUrl in person.ImageUrls)
    {
        lastAddFaceOperation = administrationClient.AddPersonFaceFromUrl(
            WaitUntil.Started,
            personId,
            FaceRecognitionModel.Recognition04,
            new Uri(imageUrl),
            detectionModel: FaceDetectionModel.Detection03);
    }
    lastAddFaceOperations.Add(lastAddFaceOperation);
}

createPersonOperations.ForEach(operation => operation.WaitForCompletion());
lastAddFaceOperations.ForEach(operation => operation.WaitForCompletion());
```

### Identify the face with the specific `Person`

You can specify a list of `Person` IDs to compare the face against each of them.

```C# Snippet:IdentifyFromPersonDirectory_IdentifyFromSpecificPerson
var detectResponse = faceClient.DetectFromUrl(
    new Uri(FaceTestConstant.UrlFamily1Daughter3Image),
    recognitionModel: FaceRecognitionModel.Recognition04,
    detectionModel: FaceDetectionModel.Detection03,
    returnFaceId: true);
var targetFaceId = detectResponse.Value[0].FaceId.Value;

var identifyPersonResponse = faceClient.IdentifyFromPersonDirectory(new[] { targetFaceId }, personIds.Values.ToArray());
foreach (var facesIdentifyResult in identifyPersonResponse.Value)
{
    Console.WriteLine($"For face {facesIdentifyResult.FaceId}, candidate number: {facesIdentifyResult.Candidates.Count}");
    foreach (var candidate in facesIdentifyResult.Candidates)
    {
        Console.WriteLine($"Candidate {candidate.PersonId} with confidence {candidate.Confidence}");
    }
}
```

### Identify the face with all `Person` in Person Directory

You can also identify the face against all the `Person` in the Person Directory.

```C# Snippet:IdentifyFromPersonDirectory_IdentifyFromEntirePersonDirectory
var identifyAllPersonResponse = faceClient.IdentifyFromEntirePersonDirectory(new[] { targetFaceId });
foreach (var facesIdentifyResult in identifyAllPersonResponse.Value)
{
    Console.WriteLine($"For face {facesIdentifyResult.FaceId}, candidate number: {facesIdentifyResult.Candidates.Count}");
    foreach (var candidate in facesIdentifyResult.Candidates)
    {
        Console.WriteLine($"Candidate {candidate.PersonId} with confidence {candidate.Confidence}");
    }
}
```

## Face identification with dynamic person group

`DynamicPersonGroup` are collections of references to `Person` objects within a Person Directory; they're used to create subsets of the directory. A common use is when you want to get fewer false positives and increased accuracy in an Identify operation by limiting the scope to just the Person objects you expect to match. Practical use cases include directories for specific building access among a larger campus or organization. The organization directory may contain 5 million individuals, but you only need to search a specific 800 people for a particular building, so you would create a `DynamicPersonGroup` containing those specific individuals.

### Prepare the `Person` in Person Directory

Similar to the previous examples, you need to create `Person` and add faces to it.

```C# Snippet:IdentifyFromDynamicPersonGroup_CreatePersonAndAddFace
var personData = new[]
{
    new { Name = "Bill", UserData = "Family1,singing", ImageUrls = new[] { FaceTestConstant.UrlFamily1Dad1Image, FaceTestConstant.UrlFamily1Dad2Image } },
    new { Name = "Clare", UserData = "Family1,singing", ImageUrls = new[] { FaceTestConstant.UrlFamily1Mom1Image, FaceTestConstant.UrlFamily1Mom2Image } },
    new { Name = "Ron", UserData = "Family1", ImageUrls = new[] { FaceTestConstant.UrlFamily1Son1Image, FaceTestConstant.UrlFamily1Son2Image } },
    new { Name = "Anna", UserData = "Family2,singing", ImageUrls = new[] { FaceTestConstant.UrlFamily2Lady1Image, FaceTestConstant.UrlFamily2Lady2Image } },
};

var personIds = new Dictionary<string, Guid>();
var createPersonOperations = new List<Operation<PersonDirectoryPerson>>();
var lastAddFaceOperations = new List<Operation<PersonDirectoryFace>>();

foreach (var person in personData)
{
    var createPersonOperation = administrationClient.CreatePerson(WaitUntil.Started, person.Name, userData: person.UserData);
    createPersonOperations.Add(createPersonOperation);
    var personId = createPersonOperation.Value.PersonId;
    personIds.Add(person.Name, personId);

    // It is an optimization to wait till the last added face is finished processing in a series as all faces for person are processed in series.
    Operation<PersonDirectoryFace> lastAddFaceOperation = null;
    foreach (var imageUrl in person.ImageUrls)
    {
        lastAddFaceOperation = administrationClient.AddPersonFaceFromUrl(
            WaitUntil.Started,
            personId,
            FaceRecognitionModel.Recognition04,
            new Uri(imageUrl),
            detectionModel: FaceDetectionModel.Detection03);
    }
    lastAddFaceOperations.Add(lastAddFaceOperation);
}
```

### Create the `DynamicPersonGroup` with `Person` references

You can create a `DynamicPersonGroup` by calling the `CreateDynamicPersonGroup` API and providing a ID, a name with optional user data. The `CreateDynamicPersonGroup` API is a long-running operation. You can add `Person` references to the `DynamicPersonGroup` when during `CreateDynamicPersonGroup`. The `Person` to be added needs to complete the `CreatePerson` long-running operation.

```C# Snippet:IdentifyFromDynamicPersonGroup_CreateDynamicPersonGroupAndAddPerson
createPersonOperations.Take(3).ToList().ForEach(operation => operation.WaitForCompletion());
administrationClient.CreateDynamicPersonGroupWithPerson(WaitUntil.Started, familyGroupId, "Dynamic Person Group for Family 1", new[] { personIds["Bill"], personIds["Clare"], personIds["Ron"] });

createPersonOperations[3].WaitForCompletion();
administrationClient.CreateDynamicPersonGroupWithPerson(WaitUntil.Started, hikingGroupId, "Dynamic Person Group for hiking club", new[] { personIds["Clare"], personIds["Anna"] });
```

### Identify the face with the `DynamicPersonGroup`

Specifying the `DynamicPersonGroup` ID to compare the face against every `Person` referenced in the group. Only a single `DynamicPersonGroup` can be identified against in a call.

```C# Snippet:IdentifyFromDynamicPersonGroup_IdentifyFromDynamicPersonGroup
var detectResponse = faceClient.DetectFromUrl(
    new Uri(FaceTestConstant.UrlIdentification1Image),
    recognitionModel: FaceRecognitionModel.Recognition04,
    detectionModel: FaceDetectionModel.Detection03,
    returnFaceId: true);
var faceIds = detectResponse.Value.Select(face => face.FaceId.Value);

var identifyFamilyPersonResponse = faceClient.IdentifyFromDynamicPersonGroup(faceIds, familyGroupId);
foreach (var facesIdentifyResult in identifyFamilyPersonResponse.Value)
{
    Console.WriteLine($"For face {facesIdentifyResult.FaceId}, candidate number: {facesIdentifyResult.Candidates.Count}");
    foreach (var candidate in facesIdentifyResult.Candidates)
    {
        Console.WriteLine($"Candidate {candidate.PersonId} with confidence {candidate.Confidence}");
    }
}

var identifyHikingPersonResponse = faceClient.IdentifyFromDynamicPersonGroup(faceIds, hikingGroupId);
foreach (var facesIdentifyResult in identifyHikingPersonResponse.Value)
{
    Console.WriteLine($"For face {facesIdentifyResult.FaceId}, candidate number: {facesIdentifyResult.Candidates.Count}");
    foreach (var candidate in facesIdentifyResult.Candidates)
    {
        Console.WriteLine($"Candidate {candidate.PersonId} with confidence {candidate.Confidence}");
    }
}
```

### Add more `Person` to the existing `DynamicPersonGroup`

After the initial creation, you can add and remove `Person` references from the `DynamicPersonGroup` with the `UpdateDynamicPersonGroup`. To add Person objects to the group, list the Person IDs in the addPersonsIds argument. To remove Person objects, list them in the removePersonIds argument. Both adding and removing can be performed in a single call.

```C# Snippet:IdentifyFromDynamicPersonGroup_UpdateDynamicPersonGroup
var createPersonGillOperation = administrationClient.CreatePerson(WaitUntil.Started, "Gill", userData: "Family1");
var gillPersonId = createPersonGillOperation.Value.PersonId;
administrationClient.AddPersonFaceFromUrl(
    WaitUntil.Started,
    gillPersonId,
    FaceRecognitionModel.Recognition04,
    new Uri(FaceTestConstant.UrlFamily1Daughter1Image),
    detectionModel: FaceDetectionModel.Detection03);
var lastAddFaceForGillOperation = administrationClient.AddPersonFaceFromUrl(
    WaitUntil.Started,
    gillPersonId,
    FaceRecognitionModel.Recognition04,
    new Uri(FaceTestConstant.UrlFamily1Daughter2Image),
    detectionModel: FaceDetectionModel.Detection03);

createPersonGillOperation.WaitForCompletion();
lastAddFaceForGillOperation.WaitForCompletion();

administrationClient.UpdateDynamicPersonGroupWithPersonChanges(WaitUntil.Started, familyGroupId, RequestContent.Create(
    new Dictionary<string, List<Guid>> {
        { "addPersonIds", new List<Guid> { gillPersonId } },
        { "removePersonIds", new List<Guid> { personIds["Bill"] } }
    }
));
var lastUpdateDynamicPersonGroupOperation = administrationClient.UpdateDynamicPersonGroupWithPersonChanges(WaitUntil.Started, familyGroupId, RequestContent.Create(
    new Dictionary<string, List<Guid>> {
        { "addPersonIds", new List<Guid> { personIds["Bill"] } }
    }
));

var identifyUpdatedGroupResponse = faceClient.IdentifyFromDynamicPersonGroup(faceIds, familyGroupId);
foreach (var facesIdentifyResult in identifyUpdatedGroupResponse.Value)
{
    Console.WriteLine($"For face {facesIdentifyResult.FaceId}, candidate number: {facesIdentifyResult.Candidates.Count}");
    foreach (var candidate in facesIdentifyResult.Candidates)
    {
        Console.WriteLine($"Candidate {candidate.PersonId} with confidence {candidate.Confidence}");
    }
}
```

### Get the `DynamicPersonGroup` reference of the `Person`

You can get the `DynamicPersonGroup` reference of the `Person` by calling the `GetDynamicPersonGroupReferences` API with the `PersonId`. The `UpdateDynamicPersonGroup` long-running operation needs to be completed before calling this API.

```C# Snippet:IdentifyFromDynamicPersonGroup_GetDynamicPersonGroupReferences
lastUpdateDynamicPersonGroupOperation.WaitForCompletionResponse();
var getGroupForBillResponse = administrationClient.GetDynamicPersonGroupReferences(personIds["Bill"]);
Console.WriteLine($"Person Bill is in {getGroupForBillResponse.Value.DynamicPersonGroupIds.Count} groups: {string.Join(", ", getGroupForBillResponse.Value.DynamicPersonGroupIds)}");
var getGroupForClareResponse = administrationClient.GetDynamicPersonGroupReferences(personIds["Clare"]);
Console.WriteLine($"Person Clare is in {getGroupForClareResponse.Value.DynamicPersonGroupIds.Count} groups: {string.Join(", ", getGroupForClareResponse.Value.DynamicPersonGroupIds)}");
```

### Delete the `DynamicPersonGroup`

You can delete the `DynamicPersonGroup` by calling the `DeleteDynamicPersonGroup` API with the `DynamicPersonGroupId`. The `DeleteDynamicPersonGroup` API is a long-running operation and returns an empty response.

```C# Snippet:IdentifyFromDynamicPersonGroup_DeleteDynamicPersonGroup
foreach (var personId in personIds.Values)
{
    administrationClient.DeletePerson(WaitUntil.Started, personId);
}
```

[README]: https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/vision/Azure.AI.Vision.Face#getting-started
