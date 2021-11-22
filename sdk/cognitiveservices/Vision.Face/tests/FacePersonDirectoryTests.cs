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
    public class FacePersonDirectoryTests : BaseTests
    {
        private static readonly string detectionModel = DetectionModel.Detection01;

        private static readonly string recognitionModel = RecognitionModel.Recognition02;

        [Fact]
        public void FacePersonDirectoryCreatePersonPositive()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "FacePersonDirectoryCreatePersonPositive");

                IFaceClient client = GetFaceClient(HttpMockServer.CreateInstance());

                var person = new EnrolledPerson
                {
                    Name = "Person",
                    UserData = "UserData"
                };
                var result = client.PersonDirectory.CreatePersonAsync(person).Result;
                var personId = result.Body.PersonId;
                Assert.NotNull(personId);
                var operationLocation = result.Headers.OperationLocation;
                Assert.NotNull(operationLocation);
                var operationResult = GetOperationResult(client, operationLocation).Status;
                Assert.Equal(OperationStatusType.Succeeded, operationResult);

                try
                {
                    using (FileStream stream = new FileStream(Path.Combine("TestImages", "Satya4.jpg"), FileMode.Open))
                    {
                        var faceId1 = client.PersonDirectory.AddPersonFaceFromStreamAsync(personId.ToString(), recognitionModel, stream, detectionModel).Result.Body.PersistedFaceId;
                        Assert.NotNull(faceId1);
                    }
                }
                finally
                {
                    var deleteResult = client.PersonDirectory.DeletePersonAsync(personId.ToString()).Result;
                    Assert.NotNull(deleteResult.OperationLocation);
                }
            }
        }

        [Fact]
        public void FacePersonDirectoryCreateDynamicPersonGroupPositive()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "FacePersonDirectoryCreateDynamicPersonGroupPositive");

                IFaceClient client = GetFaceClient(HttpMockServer.CreateInstance());

                var person1 = new EnrolledPerson
                {
                    Name = "Person1",
                    UserData = "UserData1"
                };
                var personResult1 = client.PersonDirectory.CreatePersonAsync(person1).Result;
                var personId1 = personResult1.Body.PersonId;
                Assert.NotNull(personId1);
                var operationLocation1 = personResult1.Headers.OperationLocation;
                Assert.NotNull(operationLocation1);
                var personOperationResult1 = GetOperationResult(client, operationLocation1).Status;
                Assert.Equal(OperationStatusType.Succeeded, personOperationResult1);

                var person2 = new EnrolledPerson
                {
                    Name = "Person2",
                    UserData = "UserData2"
                };
                var personResult2 = client.PersonDirectory.CreatePersonAsync(person2).Result;
                var personId2 = personResult2.Body.PersonId;
                Assert.NotNull(personId2);
                var operationLocation2 = personResult2.Headers.OperationLocation;
                Assert.NotNull(operationLocation2);
                var personOperationResult2 = GetOperationResult(client, operationLocation2).Status;
                Assert.Equal(OperationStatusType.Succeeded, personOperationResult2);

                string groupId = "dynamic-person-group-id";
                var createGroupRequest = new DynamicPersonGroupCreateRequest
                {
                    Name = "DynamicPersonGroupName",
                    UserData = "User data",
                    AddPersonIds = new List<string> { personId1.ToString() }
                };
                var createGroupResult = client.PersonDirectory.CreateDynamicPersonGroupAsync(groupId, createGroupRequest).Result;
                var createGroupOperationLocation = createGroupResult.OperationLocation;
                Assert.NotNull(createGroupOperationLocation);
                var createGroupOperationResult = GetOperationResult(client, createGroupOperationLocation).Status;
                Assert.Equal(OperationStatusType.Succeeded, createGroupOperationResult);

                var updateGroupRequest = new DynamicPersonGroupUpdateRequest
                {
                    Name = "UpdatedDynamicPersonGroupName",
                    UserData = "Updated user data",
                    AddPersonIds = new List<string> { personId2.ToString() }
                };
                var updateGroupResult = client.PersonDirectory.UpdateDynamicPersonGroupAsync(groupId, updateGroupRequest).Result;
                var updateGroupOperationLocation = updateGroupResult.OperationLocation;
                Assert.NotNull(updateGroupOperationLocation);
                var updateGroupOperationResult = GetOperationResult(client, updateGroupOperationLocation).Status;
                Assert.Equal(OperationStatusType.Succeeded, updateGroupOperationResult);

                var deleteGroupResult = client.PersonDirectory.DeleteDynamicPersonGroupAsync(groupId).Result;
                var deleteGroupOperationLocation = deleteGroupResult.OperationLocation;
                Assert.NotNull(deleteGroupOperationLocation);
            }
        }

        private static OperationStatus GetOperationResult(IFaceClient client, string operationLocation, int timeIntervalInMilliSeconds = 1000)
        {
            Assert.True(Uri.IsWellFormedUriString(operationLocation, UriKind.RelativeOrAbsolute));
            var operationId = Guid.Parse(operationLocation.Split('/').Last());

            var operationStatus = client.PersonDirectory.GetOperationStatusAsync(operationId).Result;

            while (operationStatus != null
                   && !operationStatus.Status.Equals(OperationStatusType.Succeeded)
                   && !operationStatus.Status.Equals(OperationStatusType.Failed))
            {
                Thread.Sleep(timeIntervalInMilliSeconds);

                operationStatus = client.Snapshot.GetOperationStatusAsync(operationId).Result;
            }

            return operationStatus;
        }
    }
}
