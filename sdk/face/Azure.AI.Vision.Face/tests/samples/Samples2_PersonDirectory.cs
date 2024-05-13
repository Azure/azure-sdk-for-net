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
    public partial class Samples2_PersonDirectory : FaceSamplesBase
    {
        [Test]
        public void VerifyFromPersonDirectory()
        {
            var administrationClient = CreateAdministrationClient();

            #region Snippet:VerifyFromPersonDirectory_CreatePersonAndAddFace
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
            #endregion

            var faceClient = CreateClient();

            #region Snippet:VerifyFromPersonDirectory_VerifyPerson
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
            #endregion

            #region Snippet:VerifyFromPersonDirectory_DeletePerson
            administrationClient.DeletePerson(WaitUntil.Started, personIds["Bill"]);
            administrationClient.DeletePerson(WaitUntil.Started, personIds["Ron"]);
            #endregion
        }

        [Test]
        public void IdentifyFromPersonDirectory()
        {
            var administrationClient = CreateAdministrationClient();

            #region Snippet:IdentifyFromPersonDirectory_CreatePersonAndAddFace
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
            #endregion

            var faceClient = CreateClient();

            #region Snippet:IdentifyFromPersonDirectory_IdentifyFromSpecificPerson
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
            #endregion

            #region Snippet:IdentifyFromPersonDirectory_IdentifyFromEntirePersonDirectory
            var identifyAllPersonResponse = faceClient.IdentifyFromEntirePersonDirectory(new[] { targetFaceId });
            foreach (var facesIdentifyResult in identifyAllPersonResponse.Value)
            {
                Console.WriteLine($"For face {facesIdentifyResult.FaceId}, candidate number: {facesIdentifyResult.Candidates.Count}");
                foreach (var candidate in facesIdentifyResult.Candidates)
                {
                    Console.WriteLine($"Candidate {candidate.PersonId} with confidence {candidate.Confidence}");
                }
            }
            #endregion

            foreach (var personId in personIds.Values)
            {
                administrationClient.DeletePerson(WaitUntil.Started, personId);
            }
        }

        [Test]
        public void IdentifyFromDynamicPersonGroup()
        {
            var administrationClient = CreateAdministrationClient();

            #region Snippet:IdentifyFromDynamicPersonGroup_CreatePersonAndAddFace
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
            #endregion

            var familyGroupId = "pd_family1";
            var hikingGroupId = "pd_hiking_club";

            // Perform cleanup if the group already exists
            try {
                administrationClient.DeleteDynamicPersonGroup(WaitUntil.Completed, familyGroupId);
            } catch (RequestFailedException ex) when (ex.Status == 404)
            {
            }

            try {
                administrationClient.DeleteDynamicPersonGroup(WaitUntil.Completed, hikingGroupId);
            } catch (RequestFailedException ex) when (ex.Status == 404)
            {
            }

            #region Snippet:IdentifyFromDynamicPersonGroup_CreateDynamicPersonGroupAndAddPerson
            createPersonOperations.Take(3).ToList().ForEach(operation => operation.WaitForCompletion());
            administrationClient.CreateDynamicPersonGroupWithPerson(WaitUntil.Started, familyGroupId, "Dynamic Person Group for Family 1", new[] { personIds["Bill"], personIds["Clare"], personIds["Ron"] });

            createPersonOperations[3].WaitForCompletion();
            administrationClient.CreateDynamicPersonGroupWithPerson(WaitUntil.Started, hikingGroupId, "Dynamic Person Group for hiking club", new[] { personIds["Clare"], personIds["Anna"] });
            #endregion

            lastAddFaceOperations.ForEach(operation => operation.WaitForCompletion());

            var faceClient = CreateClient();

            #region Snippet:IdentifyFromDynamicPersonGroup_IdentifyFromDynamicPersonGroup
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
            #endregion

            #region Snippet:IdentifyFromDynamicPersonGroup_UpdateDynamicPersonGroup
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
            #endregion

            // The LRO of dynamicPersonGroup Create/Update is only used for creating DynamicPersonGroupReferences. This is useful if you want to determine which groups a person is referenced in.
            // It is an optimization to wait till the last update operation is finished processing in a series as all DPG changes are processed in series.
            #region Snippet:IdentifyFromDynamicPersonGroup_GetDynamicPersonGroupReferences
            lastUpdateDynamicPersonGroupOperation.WaitForCompletionResponse();
            var getGroupForBillResponse = administrationClient.GetDynamicPersonGroupReferences(personIds["Bill"]);
            Console.WriteLine($"Person Bill is in {getGroupForBillResponse.Value.DynamicPersonGroupIds.Count} groups: {string.Join(", ", getGroupForBillResponse.Value.DynamicPersonGroupIds)}");
            var getGroupForClareResponse = administrationClient.GetDynamicPersonGroupReferences(personIds["Clare"]);
            Console.WriteLine($"Person Clare is in {getGroupForClareResponse.Value.DynamicPersonGroupIds.Count} groups: {string.Join(", ", getGroupForClareResponse.Value.DynamicPersonGroupIds)}");
            #endregion

            #region Snippet:IdentifyFromDynamicPersonGroup_DeleteDynamicPersonGroup
            foreach (var personId in personIds.Values)
            {
                administrationClient.DeletePerson(WaitUntil.Started, personId);
            }
            #endregion
            administrationClient.DeleteDynamicPersonGroup(WaitUntil.Started, familyGroupId);
            administrationClient.DeleteDynamicPersonGroup(WaitUntil.Started, hikingGroupId);
        }
    }
}
