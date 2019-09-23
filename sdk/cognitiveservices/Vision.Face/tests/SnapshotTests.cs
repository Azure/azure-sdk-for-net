using Microsoft.Azure.CognitiveServices.Vision.Face;
using Microsoft.Azure.CognitiveServices.Vision.Face.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using Xunit;

namespace FaceSDK.Tests
{
    public class SnapshotTests : BaseTests
    {
        // Set the apply scope of the snapshot here, which should be a list of Azure subscription ids
        // of Cognitive Service Face. We can leave it as `Guid.Empty` in the `playback` test mode.
        private static readonly List<Guid> ApplyScope = new List<Guid> { Guid.Empty };

        private static readonly string detectionModel = DetectionModel.Detection01;

        private static readonly string recognitionModel = RecognitionModel.Recognition02;

        [Fact]
        public void FaceSnapshotTestFaceList()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "FaceSnapshotTestFaceList");

                var sourceFaceListId = "source-face-list-id";
                var name = $"name{sourceFaceListId}";
                var userdata = $"userdata{sourceFaceListId}";

                IFaceClient client = GetFaceClient(HttpMockServer.CreateInstance());
                client.FaceList.CreateAsync(sourceFaceListId, name, userdata, recognitionModel: recognitionModel).Wait();

                using (FileStream stream = new FileStream(Path.Combine("TestImages", "Satya4.jpg"), FileMode.Open))
                {
                    var persistedFace = client.FaceList.AddFaceFromStreamAsync(sourceFaceListId, stream, detectionModel: detectionModel).Result;
                    Assert.NotNull(persistedFace);
                }

                var objectType = SnapshotObjectType.FaceList;
                var objectId = sourceFaceListId;
                var snapshotUserData = "User provided data for the snapshot.";

                var takeSnapshotResult = client.Snapshot.TakeAsync(objectType, objectId, ApplyScope, snapshotUserData).Result;
                Assert.NotNull(takeSnapshotResult.OperationLocation);

                var operationStatus = GetOperationResult(client, takeSnapshotResult.OperationLocation);
                Assert.NotNull(operationStatus);
                Assert.Equal(OperationStatusType.Succeeded, operationStatus.Status);

                var resourceId = Guid.Parse(operationStatus.ResourceLocation.Split('/').Last());

                var targetFacelistId = "target-face-list-id";
                var applyMode = SnapshotApplyMode.CreateNew;
                var applySnapshotResult = client.Snapshot.ApplyAsync(resourceId, targetFacelistId, applyMode).Result;
                Assert.NotNull(applySnapshotResult.OperationLocation);

                operationStatus = GetOperationResult(client, applySnapshotResult.OperationLocation);
                Assert.NotNull(operationStatus);
                Assert.Equal(operationStatus.Status.ToString(), OperationStatusType.Succeeded.ToString());

                var targetObjectId = operationStatus.ResourceLocation.Split('/').Last();
                Assert.Equal(targetFacelistId, targetObjectId);

                var targetFacelist = client.FaceList.GetAsync(targetFacelistId).Result;
                Assert.NotNull(targetFacelist);
                Assert.True(targetFacelist.PersistedFaces.Count == 1);

                client.FaceList.DeleteAsync(sourceFaceListId).Wait();
                client.FaceList.DeleteAsync(targetFacelistId).Wait();
                client.Snapshot.DeleteAsync(resourceId).Wait();
            }
        }

        [Fact]
        public void FaceSnapshotTestLargeFaceList()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "FaceSnapshotTestLargeFaceList");

                var sourceLargeFacelistId = "source-large-face-list-id";
                var name = $"name{sourceLargeFacelistId}";
                var userdata = $"userdata{sourceLargeFacelistId}";

                IFaceClient client = GetFaceClient(HttpMockServer.CreateInstance());
                client.LargeFaceList.CreateAsync(sourceLargeFacelistId, name, userdata, recognitionModel: recognitionModel).Wait();

                using (FileStream stream = new FileStream(Path.Combine("TestImages", "Satya4.jpg"), FileMode.Open))
                {
                    var persistedFace = client.LargeFaceList.AddFaceFromStreamAsync(sourceLargeFacelistId, stream, detectionModel: detectionModel).Result;
                    Assert.NotNull(persistedFace);
                }

                var trainingResult = GetTrainingResult(client, sourceLargeFacelistId, "LargeFaceList");
                Assert.NotNull(trainingResult);
                Assert.Equal(TrainingStatusType.Succeeded, trainingResult.Status);

                var objectType = SnapshotObjectType.LargeFaceList;
                var objectId = sourceLargeFacelistId;
                var snapshotUserData = "User provided data for the snapshot.";

                var takeSnapshotResult = client.Snapshot.TakeAsync(objectType, objectId, ApplyScope, snapshotUserData).Result;
                Assert.NotNull(takeSnapshotResult.OperationLocation);

                var operationStatus = GetOperationResult(client, takeSnapshotResult.OperationLocation);
                Assert.NotNull(operationStatus);
                Assert.Equal(OperationStatusType.Succeeded, operationStatus.Status);

                var resourceId = Guid.Parse(operationStatus.ResourceLocation.Split('/').Last());

                var targetLargeFacelistId = "target-large-face-list-id";
                var applyMode = SnapshotApplyMode.CreateNew;
                var applySnapshotResult = client.Snapshot.ApplyAsync(resourceId, targetLargeFacelistId, applyMode).Result;
                Assert.NotNull(applySnapshotResult.OperationLocation);

                operationStatus = GetOperationResult(client, applySnapshotResult.OperationLocation);
                Assert.NotNull(operationStatus);
                Assert.Equal(operationStatus.Status.ToString(), OperationStatusType.Succeeded.ToString());

                var targetObjectId = operationStatus.ResourceLocation.Split('/').Last();
                Assert.Equal(targetLargeFacelistId, targetObjectId);

                var targetLargeFacelist = client.LargeFaceList.GetAsync(targetLargeFacelistId).Result;
                Assert.NotNull(targetLargeFacelist);

                var targetLargeFacelistFaces = client.LargeFaceList.ListFacesAsync(targetLargeFacelistId).Result;
                Assert.True(targetLargeFacelistFaces.Count == 1);

                client.LargeFaceList.DeleteAsync(sourceLargeFacelistId).Wait();
                client.LargeFaceList.DeleteAsync(targetLargeFacelistId).Wait();
                client.Snapshot.DeleteAsync(resourceId).Wait();
            }
        }

        [Fact]
        public void FaceSnapshotTestLargePersonGroup()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "FaceSnapshotTestLargePersonGroup");

                var sourceLargePersonGroupId = "source-large-person-group-id";
                var name = $"name{sourceLargePersonGroupId}";
                var userdata = $"userdata{sourceLargePersonGroupId}";

                IFaceClient client = GetFaceClient(HttpMockServer.CreateInstance());
                client.LargePersonGroup.CreateAsync(sourceLargePersonGroupId, name, userdata, recognitionModel: recognitionModel).Wait();

                var personName = $"personName{sourceLargePersonGroupId}";
                var personUserdata = $"personUserdata{sourceLargePersonGroupId}";
                var largePersonGroupPersonId = client.LargePersonGroupPerson.CreateAsync(sourceLargePersonGroupId, personName, personUserdata).Result.PersonId;

                Guid largePersonGroupPersonFaceId;

                using (FileStream stream = new FileStream(Path.Combine("TestImages", "Satya4.jpg"), FileMode.Open))
                {
                    var persistedFace = client.LargePersonGroupPerson.AddFaceFromStreamAsync(sourceLargePersonGroupId, largePersonGroupPersonId, stream, detectionModel: detectionModel).Result;
                    Assert.NotNull(persistedFace);
                    largePersonGroupPersonFaceId = persistedFace.PersistedFaceId;
                }

                var trainingResult = GetTrainingResult(client, sourceLargePersonGroupId, "LargePersonGroup");
                Assert.NotNull(trainingResult);
                Assert.Equal(trainingResult.Status.ToString(), TrainingStatusType.Succeeded.ToString());

                var objectType = SnapshotObjectType.LargePersonGroup;
                var objectId = sourceLargePersonGroupId;
                var snapshotUserData = "User provided data for the snapshot.";

                var takeSnapshotResult = client.Snapshot.TakeAsync(objectType, objectId, ApplyScope, snapshotUserData).Result;
                Assert.NotNull(takeSnapshotResult.OperationLocation);

                var operationStatus = GetOperationResult(client, takeSnapshotResult.OperationLocation);
                Assert.NotNull(operationStatus);
                Assert.Equal(OperationStatusType.Succeeded, operationStatus.Status);

                var resourceId = Guid.Parse(operationStatus.ResourceLocation.Split('/').Last());

                var targetLargePersonGroupId = Guid.NewGuid().ToString();
                var applyMode = SnapshotApplyMode.CreateNew;
                var applySnapshotResult = client.Snapshot.ApplyAsync(resourceId, targetLargePersonGroupId, applyMode).Result;
                Assert.NotNull(applySnapshotResult.OperationLocation);

                operationStatus = GetOperationResult(client, applySnapshotResult.OperationLocation);
                Assert.NotNull(operationStatus);
                Assert.Equal(OperationStatusType.Succeeded, operationStatus.Status);

                var targetObjectId = operationStatus.ResourceLocation.Split('/').Last();

                var targetLargePersonGroup = client.LargePersonGroup.GetAsync(targetObjectId).Result;
                Assert.NotNull(targetLargePersonGroup);

                var targetLargePersonGroupPerson = client.LargePersonGroupPerson.GetAsync(targetObjectId, largePersonGroupPersonId).Result;
                Assert.NotNull(targetLargePersonGroupPerson);

                var targetLargePersonGroupPersonFace = client.LargePersonGroupPerson.GetFaceAsync(targetObjectId, largePersonGroupPersonId, largePersonGroupPersonFaceId).Result;
                Assert.NotNull(targetLargePersonGroupPersonFace);

                client.LargePersonGroup.DeleteAsync(sourceLargePersonGroupId).Wait();
                client.LargePersonGroup.DeleteAsync(targetObjectId).Wait();
                client.Snapshot.DeleteAsync(resourceId).Wait();
            }
        }

        [Fact]
        public void FaceSnapshotTestPersonGroup()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "FaceSnapshotTestPersonGroup");

                var sourcePersonGroupId = "source-person-group-id";
                var name = $"name{sourcePersonGroupId}";
                var userdata = $"userdata{sourcePersonGroupId}";

                IFaceClient client = GetFaceClient(HttpMockServer.CreateInstance());
                client.PersonGroup.CreateAsync(sourcePersonGroupId, name, userdata, recognitionModel: recognitionModel).Wait();

                var personName = $"personName{sourcePersonGroupId}";
                var personUserdata = $"personUserdata{sourcePersonGroupId}";
                var personGroupPersonId = client.PersonGroupPerson.CreateAsync(sourcePersonGroupId, personName, personUserdata).Result.PersonId;

                Guid personGroupPersonFaceId;

                using (FileStream stream = new FileStream(Path.Combine("TestImages", "Satya4.jpg"), FileMode.Open))
                {
                    var persistedFace = client.PersonGroupPerson.AddFaceFromStreamAsync(sourcePersonGroupId, personGroupPersonId, stream, detectionModel: detectionModel).Result;
                    Assert.NotNull(persistedFace);
                    personGroupPersonFaceId = persistedFace.PersistedFaceId;
                }

                var trainingResult = GetTrainingResult(client, sourcePersonGroupId, "PersonGroup");
                Assert.NotNull(trainingResult);
                Assert.Equal(TrainingStatusType.Succeeded, trainingResult.Status);

                var objectType = SnapshotObjectType.PersonGroup;
                var objectId = sourcePersonGroupId;
                var snapshotUserData = "User provided data for the snapshot.";

                var takeSnapshotResult = client.Snapshot.TakeAsync(objectType, objectId, ApplyScope, snapshotUserData).Result;
                Assert.NotNull(takeSnapshotResult.OperationLocation);

                var operationStatus = GetOperationResult(client, takeSnapshotResult.OperationLocation);
                Assert.NotNull(operationStatus);
                Assert.Equal(OperationStatusType.Succeeded, operationStatus.Status);

                var resourceId = Guid.Parse(operationStatus.ResourceLocation.Split('/').Last());

                var targetPersonGroupId = "target-person-group-id";
                var applyMode = SnapshotApplyMode.CreateNew;
                var applySnapshotResult = client.Snapshot.ApplyAsync(resourceId, targetPersonGroupId, applyMode).Result;
                Assert.NotNull(applySnapshotResult.OperationLocation);

                operationStatus = GetOperationResult(client, applySnapshotResult.OperationLocation);
                Assert.NotNull(operationStatus);
                Assert.Equal(operationStatus.Status.ToString(), OperationStatusType.Succeeded.ToString());

                var targetObjectId = operationStatus.ResourceLocation.Split('/').Last();
                Assert.Equal(targetPersonGroupId, targetObjectId);

                var targetPersonGroup = client.PersonGroup.GetAsync(targetPersonGroupId).Result;
                Assert.NotNull(targetPersonGroup);

                var targetPersonGroupPerson = client.PersonGroupPerson.GetAsync(targetPersonGroupId, personGroupPersonId).Result;
                Assert.NotNull(targetPersonGroupPerson);

                var targetPersonGroupPersonFace = client.PersonGroupPerson.GetFaceAsync(targetPersonGroupId, personGroupPersonId, personGroupPersonFaceId).Result;
                Assert.NotNull(targetPersonGroupPersonFace);

                client.PersonGroup.DeleteAsync(sourcePersonGroupId).Wait();
                client.PersonGroup.DeleteAsync(targetPersonGroupId).Wait();
                client.Snapshot.DeleteAsync(resourceId).Wait();
            }
        }

        private static OperationStatus GetOperationResult(IFaceClient client, string operationLocation, int timeIntervalInMilliSeconds = 1000)
        {
            Assert.True(Uri.IsWellFormedUriString(operationLocation, UriKind.RelativeOrAbsolute));
            var operationId = Guid.Parse(operationLocation.Split('/').Last());

            var operationStatus = client.Snapshot.GetOperationStatusAsync(operationId).Result;

            while (operationStatus != null
                   && !operationStatus.Status.Equals(OperationStatusType.Succeeded)
                   && !operationStatus.Status.Equals(OperationStatusType.Failed))
            {
                Thread.Sleep(timeIntervalInMilliSeconds);

                operationStatus = client.Snapshot.GetOperationStatusAsync(operationId).Result;
            }

            return operationStatus;
        }

        private static TrainingStatus GetTrainingResult(IFaceClient client, string resourceId, string resourceType, int timeIntervalInMilliSeconds = 1000)
        {
            TrainingStatus trainStatus;

            switch (resourceType)
            {
                case "LargeFaceList":
                    client.LargeFaceList.TrainAsync(resourceId).Wait();
                    trainStatus = client.LargeFaceList.GetTrainingStatusAsync(resourceId).Result;
                    break;
                case "PersonGroup":
                    client.PersonGroup.TrainAsync(resourceId).Wait();
                    trainStatus = client.PersonGroup.GetTrainingStatusAsync(resourceId).Result;
                    break;
                case "LargePersonGroup":
                    client.LargePersonGroup.TrainAsync(resourceId).Wait();
                    trainStatus = client.LargePersonGroup.GetTrainingStatusAsync(resourceId).Result;
                    break;
                default:
                    return null;
            }

            while (trainStatus != null
                   && !trainStatus.Status.Equals(TrainingStatusType.Succeeded)
                   && !trainStatus.Status.Equals(TrainingStatusType.Failed))
            {
                Thread.Sleep(timeIntervalInMilliSeconds);

                switch (resourceType)
                {
                    case "LargeFaceList":
                        trainStatus = client.LargeFaceList.GetTrainingStatusAsync(resourceId).Result;
                        break;
                    case "PersonGroup":
                        trainStatus = client.PersonGroup.GetTrainingStatusAsync(resourceId).Result;
                        break;
                    case "LargePersonGroup":
                        trainStatus = client.LargePersonGroup.GetTrainingStatusAsync(resourceId).Result;
                        break;
                }
            }

            return trainStatus;
        }
    }
}
