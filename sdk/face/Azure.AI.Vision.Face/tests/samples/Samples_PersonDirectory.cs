// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.AI.Vision.Face.Tests;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Vision.Face.Samples
{
    public partial class FaceSamples
    {
        [RecordedTest]
        public async Task Sample_VerifyFromPersonDirectory()
        {
            var administrationClient = CreateAdministrationClient();

            var personData = new[]
            {
                new { Name = "Bill", UserData = "Family1,singing", ImageUrls = new[] { FaceTestConstant.UrlFamily1Dad1Image, FaceTestConstant.UrlFamily1Dad2Image } },
                new { Name = "Ron", UserData = "Family1", ImageUrls = new[] { FaceTestConstant.UrlFamily1Son1Image, FaceTestConstant.UrlFamily1Son2Image } }
            };

            var personIds = new Dictionary<string, Guid>();

            foreach (var person in personData)
            {
                var createPersonOperation = await administrationClient.CreatePersonAsync(WaitUntil.Started, person.Name, userData: person.UserData);
                var personId = createPersonOperation.Value.PersonId;
                personIds.Add(person.Name, personId);

                foreach (var imageUrl in person.ImageUrls)
                {
                    await administrationClient.AddPersonFaceFromUrlAsync(
                        WaitUntil.Started,
                        personId,
                        FaceRecognitionModel.Recognition04,
                        new Uri(imageUrl),
                        detectionModel: FaceDetectionModel.Detection03);
                }
            }

            var faceClient = CreateClient();
            var detectResponse = await faceClient.DetectFromUrlAsync(
                new Uri(FaceTestConstant.UrlFamily1Dad3Image),
                recognitionModel: FaceRecognitionModel.Recognition04,
                detectionModel: FaceDetectionModel.Detection03,
                returnFaceId: true);
            var targetFaceId = detectResponse.Value[0].FaceId.Value;

            var verifyBillResponse = await faceClient.VerifyFromPersonDirectoryAsync(targetFaceId, personIds["Bill"]);
            Console.WriteLine($"Face verification result for person Bill. IsIdentical: {verifyBillResponse.Value.IsIdentical}, Confidence: {verifyBillResponse.Value.Confidence}");

            var verifyRonResponse = await faceClient.VerifyFromPersonDirectoryAsync(targetFaceId, personIds["Ron"]);
            Console.WriteLine($"Face verification result for person Ron. IsIdentical: {verifyRonResponse.Value.IsIdentical}, Confidence: {verifyRonResponse.Value.Confidence}");

            await administrationClient.DeletePersonAsync(WaitUntil.Started, personIds["Bill"]);
            await administrationClient.DeletePersonAsync(WaitUntil.Started, personIds["Ron"]);
        }

        [RecordedTest]
        public async Task Sample_IdentifyFromPersonDirectory()
        {
            var administrationClient = CreateAdministrationClient();

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
                var createPersonOperation = await administrationClient.CreatePersonAsync(WaitUntil.Started, person.Name, userData: person.UserData);
                createPersonOperations.Add(createPersonOperation);
                var personId = createPersonOperation.Value.PersonId;
                personIds.Add(person.Name, personId);

                // It is an optimization to wait till the last added face is finished processing in a series as all faces for person are processed in series.
                Operation<PersonDirectoryFace> lastAddFaceOperation = null;
                foreach (var imageUrl in person.ImageUrls)
                {
                    lastAddFaceOperation = await administrationClient.AddPersonFaceFromUrlAsync(
                        WaitUntil.Started,
                        personId,
                        FaceRecognitionModel.Recognition04,
                        new Uri(imageUrl),
                        detectionModel: FaceDetectionModel.Detection03);
                }
                lastAddFaceOperations.Add(lastAddFaceOperation);
            }

            createPersonOperations.ForEach(async operation => await operation.WaitForCompletionAsync());
            lastAddFaceOperations.ForEach(async operation => await operation.WaitForCompletionAsync());

            var faceClient = CreateClient();
            var detectResponse = await faceClient.DetectFromUrlAsync(
                new Uri(FaceTestConstant.UrlFamily1Daughter3Image),
                recognitionModel: FaceRecognitionModel.Recognition04,
                detectionModel: FaceDetectionModel.Detection03,
                returnFaceId: true);
            var targetFaceId = detectResponse.Value[0].FaceId.Value;

            var identifyPersonResponse = await faceClient.IdentifyFromPersonDirectoryAsync(new[] { targetFaceId }, personIds.Values.ToArray());
            foreach (var facesIdentifyResult in identifyPersonResponse.Value)
            {
                Console.WriteLine($"For face {facesIdentifyResult.FaceId}, candidate number: {facesIdentifyResult.Candidates.Count}");
                foreach (var candidate in facesIdentifyResult.Candidates)
                {
                    Console.WriteLine($"Candidate {candidate.PersonId} with confidence {candidate.Confidence}");
                }
            }

            var identifyAllPersonResponse = await faceClient.IdentifyFromEntirePersonDirectoryAsync(new[] { targetFaceId });
            foreach (var facesIdentifyResult in identifyAllPersonResponse.Value)
            {
                Console.WriteLine($"For face {facesIdentifyResult.FaceId}, candidate number: {facesIdentifyResult.Candidates.Count}");
                foreach (var candidate in facesIdentifyResult.Candidates)
                {
                    Console.WriteLine($"Candidate {candidate.PersonId} with confidence {candidate.Confidence}");
                }
            }

            foreach (var personId in personIds.Values)
            {
                await administrationClient.DeletePersonAsync(WaitUntil.Started, personId);
            }
        }

        [RecordedTest]
        public async Task Sample_IdentifyFromDynamicPersonGroup()
        {
            var administrationClient = CreateAdministrationClient();

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
                var createPersonOperation = await administrationClient.CreatePersonAsync(WaitUntil.Started, person.Name, userData: person.UserData);
                createPersonOperations.Add(createPersonOperation);
                var personId = createPersonOperation.Value.PersonId;
                personIds.Add(person.Name, personId);

                // It is an optimization to wait till the last added face is finished processing in a series as all faces for person are processed in series.
                Operation<PersonDirectoryFace> lastAddFaceOperation = null;
                foreach (var imageUrl in person.ImageUrls)
                {
                    lastAddFaceOperation = await administrationClient.AddPersonFaceFromUrlAsync(
                        WaitUntil.Started,
                        personId,
                        FaceRecognitionModel.Recognition04,
                        new Uri(imageUrl),
                        detectionModel: FaceDetectionModel.Detection03);
                }
                lastAddFaceOperations.Add(lastAddFaceOperation);
            }

            createPersonOperations.Take(3).ToList().ForEach(async operation => await operation.WaitForCompletionAsync());
            var familyGroupId = "pd_family1";
            await administrationClient.CreateDynamicPersonGroupWithPersonAsync(WaitUntil.Started, familyGroupId, "Dynamic Person Group for Family 1", new[] { personIds["Bill"], personIds["Clare"], personIds["Ron"] });

            await createPersonOperations[3].WaitForCompletionAsync();
            var hikingGroupId = "pd_hiking_club";
            await administrationClient.CreateDynamicPersonGroupWithPersonAsync(WaitUntil.Started, hikingGroupId, "Dynamic Person Group for hiking club", new[] { personIds["Clare"], personIds["Anna"] });

            lastAddFaceOperations.ForEach(async operation => await operation.WaitForCompletionAsync());

            var faceClient = CreateClient();
            var detectResponse = await faceClient.DetectFromUrlAsync(
                new Uri(FaceTestConstant.UrlIdentification1Image),
                recognitionModel: FaceRecognitionModel.Recognition04,
                detectionModel: FaceDetectionModel.Detection03,
                returnFaceId: true);
            var faceIds = detectResponse.Value.Select(face => face.FaceId.Value);

            var identifyFamilyPersonResponse = await faceClient.IdentifyFromDynamicPersonGroupAsync(faceIds, familyGroupId);
            foreach (var facesIdentifyResult in identifyFamilyPersonResponse.Value)
            {
                Console.WriteLine($"For face {facesIdentifyResult.FaceId}, candidate number: {facesIdentifyResult.Candidates.Count}");
                foreach (var candidate in facesIdentifyResult.Candidates)
                {
                    Console.WriteLine($"Candidate {candidate.PersonId} with confidence {candidate.Confidence}");
                }
            }

            var identifyHikingPersonResponse = await faceClient.IdentifyFromDynamicPersonGroupAsync(faceIds, hikingGroupId);
            foreach (var facesIdentifyResult in identifyHikingPersonResponse.Value)
            {
                Console.WriteLine($"For face {facesIdentifyResult.FaceId}, candidate number: {facesIdentifyResult.Candidates.Count}");
                foreach (var candidate in facesIdentifyResult.Candidates)
                {
                    Console.WriteLine($"Candidate {candidate.PersonId} with confidence {candidate.Confidence}");
                }
            }

            var createPersonGillOperation = await administrationClient.CreatePersonAsync(WaitUntil.Started, "Gill", userData: "Family1");
            var gillPersonId = createPersonGillOperation.Value.PersonId;
            await administrationClient.AddPersonFaceFromUrlAsync(
                WaitUntil.Started,
                gillPersonId,
                FaceRecognitionModel.Recognition04,
                new Uri(FaceTestConstant.UrlFamily1Daughter1Image),
                detectionModel: FaceDetectionModel.Detection03);
            var lastAddFaceForGillOperation = await administrationClient.AddPersonFaceFromUrlAsync(
                WaitUntil.Started,
                gillPersonId,
                FaceRecognitionModel.Recognition04,
                new Uri(FaceTestConstant.UrlFamily1Daughter2Image),
                detectionModel: FaceDetectionModel.Detection03);

            await createPersonGillOperation.WaitForCompletionAsync();
            await lastAddFaceForGillOperation.WaitForCompletionAsync();

            await administrationClient.UpdateDynamicPersonGroupWithPersonChangesAsync(WaitUntil.Started, familyGroupId, RequestContent.Create(
                new Dictionary<string, List<Guid>> {
                    { "addPersonIds", new List<Guid> { gillPersonId } },
                    { "removePersonIds", new List<Guid> { personIds["Bill"] } }
                }
            ));
            var lastUpdateDynamicPersonGroupOperation = await administrationClient.UpdateDynamicPersonGroupWithPersonChangesAsync(WaitUntil.Started, familyGroupId, RequestContent.Create(
                new Dictionary<string, List<Guid>> {
                    { "addPersonIds", new List<Guid> { personIds["Bill"] } }
                }
            ));

            var identifyUpdatedGroupResponse = await faceClient.IdentifyFromDynamicPersonGroupAsync(faceIds, familyGroupId);
            foreach (var facesIdentifyResult in identifyUpdatedGroupResponse.Value)
            {
                Console.WriteLine($"For face {facesIdentifyResult.FaceId}, candidate number: {facesIdentifyResult.Candidates.Count}");
                foreach (var candidate in facesIdentifyResult.Candidates)
                {
                    Console.WriteLine($"Candidate {candidate.PersonId} with confidence {candidate.Confidence}");
                }
            }

            // The LRO of dynamicPersonGroup Create/Update is only used for creating DynamicPersonGroupReferences. This is useful if you want to determine which groups a person is referenced in.
            // It is an optimization to wait till the last update operation is finished processing in a series as all DPG changes are processed in series.
            await lastUpdateDynamicPersonGroupOperation.WaitForCompletionResponseAsync();
            var getGroupForBillResponse = await administrationClient.GetDynamicPersonGroupReferencesAsync(personIds["Bill"]);
            Console.WriteLine($"Person Bill is in {getGroupForBillResponse.Value.DynamicPersonGroupIds.Count} groups: {string.Join(", ", getGroupForBillResponse.Value.DynamicPersonGroupIds)}");
            var getGroupForClareResponse = await administrationClient.GetDynamicPersonGroupReferencesAsync(personIds["Clare"]);
            Console.WriteLine($"Person Clare is in {getGroupForClareResponse.Value.DynamicPersonGroupIds.Count} groups: {string.Join(", ", getGroupForClareResponse.Value.DynamicPersonGroupIds)}");

            foreach (var personId in personIds.Values)
            {
                await administrationClient.DeletePersonAsync(WaitUntil.Started, personId);
            }
            await administrationClient.DeleteDynamicPersonGroupAsync(WaitUntil.Started, familyGroupId);
            await administrationClient.DeleteDynamicPersonGroupAsync(WaitUntil.Started, hikingGroupId);
        }
    }
}
