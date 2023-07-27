// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace Azure.DigitalTwins.Core.Tests
{
    /// <summary>
    /// Tests for DigitalTwinServiceClient methods dealing with Digital Twin operations.
    /// </summary>
    public class DigitalTwinTests : E2eTestBase
    {
        public DigitalTwinTests(bool isAsync)
            : base(isAsync)
        {
        }

        [Test]
        public async Task DigitalTwins_Lifecycle()
        {
            DigitalTwinsClient client = GetClient();

            string roomTwinId = await GetUniqueTwinIdAsync(client, TestAssetDefaults.RoomTwinIdPrefix).ConfigureAwait(false);
            string floorModelId = await GetUniqueModelIdAsync(client, TestAssetDefaults.FloorModelIdPrefix).ConfigureAwait(false);
            string roomModelId = await GetUniqueModelIdAsync(client, TestAssetDefaults.RoomModelIdPrefix).ConfigureAwait(false);

            try
            {
                // arrange

                // create room model
                string roomModel = TestAssetsHelper.GetRoomModelPayload(roomModelId, floorModelId);
                await CreateAndListModelsAsync(client, new List<string> { roomModel }).ConfigureAwait(false);

                // act

                // create room twin
                BasicDigitalTwin roomTwin = TestAssetsHelper.GetRoomTwinPayload(roomModelId);
                await client.CreateOrReplaceDigitalTwinAsync<BasicDigitalTwin>(roomTwinId, roomTwin).ConfigureAwait(false);

                // get twin
                await client.GetDigitalTwinAsync<BasicDigitalTwin>(roomTwinId).ConfigureAwait(false);

                // update twin
                JsonPatchDocument updateTwinPatchDocument = new JsonPatchDocument();
                updateTwinPatchDocument.AppendAdd("/Humidity", 30);
                updateTwinPatchDocument.AppendReplace("/Temperature", 70);
                updateTwinPatchDocument.AppendReplace("/$metadata/Temperature/sourceTime", "2022-01-20T02:03:00.0943478Z");
                updateTwinPatchDocument.AppendRemove("/EmployeeId");

                await client.UpdateDigitalTwinAsync(roomTwinId, updateTwinPatchDocument, ETag.All).ConfigureAwait(false);

                // delete a twin
                await client.DeleteDigitalTwinAsync(roomTwinId).ConfigureAwait(false);

                // assert
                Func<Task> act = async () =>
                {
                    await client.GetDigitalTwinAsync<BasicDigitalTwin>(roomTwinId).ConfigureAwait(false);
                };

                act.Should().Throw<RequestFailedException>()
                    .And.Status.Should().Be((int)HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Failure in executing a step in the test case: {ex.Message}.");
            }
            finally
            {
                // cleanup
                try
                {
                    if (!string.IsNullOrWhiteSpace(roomModelId))
                    {
                        await client.DeleteModelAsync(roomModelId).ConfigureAwait(false);
                    }
                }
                catch (Exception ex)
                {
                    Assert.Fail($"Test clean up failed: {ex.Message}");
                }
            }
        }

        [Test]
        public void DigitalTwins_IncorrectCredentials_ThrowsUnauthorizedException()
        {
            // arrange
            DigitalTwinsClient unauthorizedClient = GetFakeClient();

            // act
            Func<Task> act = async () =>
            {
                await unauthorizedClient.GetDigitalTwinAsync<BasicDigitalTwin>("someNonExistantTwin").ConfigureAwait(false);
            };

            // assert
            act.Should().Throw<RequestFailedException>()
                .And.Status.Should().Be((int)HttpStatusCode.Unauthorized);
        }

        [Test]
        public void DigitalTwins_TwinNotExist_ThrowsNotFoundException()
        {
            // arrange
            DigitalTwinsClient client = GetClient();

            // act
            Func<Task> act = async () =>
            {
                await client.GetDigitalTwinAsync<BasicDigitalTwin>("someNonExistantTwin").ConfigureAwait(false);
            };

            // assert
            act.Should().Throw<RequestFailedException>()
                .And.Status.Should().Be((int)HttpStatusCode.NotFound);
        }

        [Test]
        public async Task DigitalTwinOperationsWithCustomObjectSerializer_Succeeds()
        {
            // arrange

            var serializer = new TestObjectSerializer();
            DigitalTwinsClientOptions options = new DigitalTwinsClientOptions
            {
                Serializer = serializer
            };

            DigitalTwinsClient client = GetClient(options);

            serializer.WasDeserializeCalled.Should().BeFalse();
            serializer.WasSerializeCalled.Should().BeFalse();

            string roomTwinId = await GetUniqueTwinIdAsync(client, TestAssetDefaults.RoomTwinIdPrefix).ConfigureAwait(false);
            string floorModelId = await GetUniqueModelIdAsync(client, TestAssetDefaults.FloorModelIdPrefix).ConfigureAwait(false);
            string roomModelId = await GetUniqueModelIdAsync(client, TestAssetDefaults.RoomModelIdPrefix).ConfigureAwait(false);

            // create room model
            string roomModel = TestAssetsHelper.GetRoomModelPayload(roomModelId, floorModelId);
            await CreateAndListModelsAsync(client, new List<string> { roomModel }).ConfigureAwait(false);

            // act

            // create room twin
            BasicDigitalTwin roomTwin = TestAssetsHelper.GetRoomTwinPayload(roomModelId);
            await client.CreateOrReplaceDigitalTwinAsync(roomTwinId, roomTwin).ConfigureAwait(false);

            roomTwin = await client.GetDigitalTwinAsync<BasicDigitalTwin>(roomTwinId).ConfigureAwait(false);

            // assert
            roomTwin.Should().NotBeNull();
            serializer.WasDeserializeCalled.Should().BeTrue();
            serializer.WasSerializeCalled.Should().BeTrue();
        }

        [Test]
        public async Task DigitalTwins_CreateOrReplaceTwinFailsWhenIfNoneMatchStar()
        {
            DigitalTwinsClient client = GetClient();

            string roomTwinId = await GetUniqueTwinIdAsync(client, TestAssetDefaults.RoomTwinIdPrefix).ConfigureAwait(false);
            string floorModelId = await GetUniqueModelIdAsync(client, TestAssetDefaults.FloorModelIdPrefix).ConfigureAwait(false);
            string roomModelId = await GetUniqueModelIdAsync(client, TestAssetDefaults.RoomModelIdPrefix).ConfigureAwait(false);

            try
            {
                // arrange
                // create room model
                string roomModel = TestAssetsHelper.GetRoomModelPayload(roomModelId, floorModelId);
                await CreateAndListModelsAsync(client, new List<string> { roomModel }).ConfigureAwait(false);

                // act

                // create room twin
                BasicDigitalTwin roomTwin = TestAssetsHelper.GetRoomTwinPayload(roomModelId);
                await client.CreateOrReplaceDigitalTwinAsync<BasicDigitalTwin>(roomTwinId, roomTwin).ConfigureAwait(false);

                // act
                Func<Task> act = async () =>
                {
                    // "ifNoneMatch = *" header should cause the server to throw 412 since an entity does match
                    await client.CreateOrReplaceDigitalTwinAsync<BasicDigitalTwin>(roomTwinId, roomTwin, ETag.All).ConfigureAwait(false);
                };

                // assert
                act.Should().Throw<RequestFailedException>()
                    .And.Status.Should().Be((int)HttpStatusCode.PreconditionFailed);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Failure in executing a step in the test case: {ex.Message}.");
            }
            finally
            {
                // cleanup
                try
                {
                    if (!string.IsNullOrWhiteSpace(roomModelId))
                    {
                        await client.DeleteModelAsync(roomModelId).ConfigureAwait(false);
                    }
                }
                catch (Exception ex)
                {
                    Assert.Fail($"Test clean up failed: {ex.Message}");
                }
            }
        }

        [Test]
        public async Task DigitalTwins_CreateOrReplaceTwinSucceedsWithNoIfNoneMatchHeader()
        {
            DigitalTwinsClient client = GetClient();

            string roomTwinId = await GetUniqueTwinIdAsync(client, TestAssetDefaults.RoomTwinIdPrefix).ConfigureAwait(false);
            string floorModelId = await GetUniqueModelIdAsync(client, TestAssetDefaults.FloorModelIdPrefix).ConfigureAwait(false);
            string roomModelId = await GetUniqueModelIdAsync(client, TestAssetDefaults.RoomModelIdPrefix).ConfigureAwait(false);

            try
            {
                // arrange
                // create room model
                string roomModel = TestAssetsHelper.GetRoomModelPayload(roomModelId, floorModelId);
                await CreateAndListModelsAsync(client, new List<string> { roomModel }).ConfigureAwait(false);

                // act

                // create room twin
                BasicDigitalTwin roomTwin = TestAssetsHelper.GetRoomTwinPayload(roomModelId);
                await client.CreateOrReplaceDigitalTwinAsync<BasicDigitalTwin>(roomTwinId, roomTwin).ConfigureAwait(false);

                // Deliberately not passing in ifNoneMatch header, request should succeed because of that
                await client.CreateOrReplaceDigitalTwinAsync<BasicDigitalTwin>(roomTwinId, roomTwin).ConfigureAwait(false);
            }
            catch (RequestFailedException ex) when (ex.Status == (int)HttpStatusCode.PreconditionFailed)
            {
                throw new AssertionException("CreateOrReplaceDigitalTwin should not fail with PreconditionFailed when ifNoneMatch header wasn't set", ex);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Failure in executing a step in the test case: {ex.Message}.");
            }
            finally
            {
                // cleanup
                try
                {
                    if (!string.IsNullOrWhiteSpace(roomModelId))
                    {
                        await client.DeleteModelAsync(roomModelId).ConfigureAwait(false);
                    }
                }
                catch (Exception ex)
                {
                    Assert.Fail($"Test clean up failed: {ex.Message}");
                }
            }
        }

        [Test]
        public async Task DigitalTwins_PatchTwinFailsIfInvalidETagProvided()
        {
            DigitalTwinsClient client = GetClient();

            string roomTwinId = await GetUniqueTwinIdAsync(client, TestAssetDefaults.RoomTwinIdPrefix).ConfigureAwait(false);
            string floorModelId = await GetUniqueModelIdAsync(client, TestAssetDefaults.FloorModelIdPrefix).ConfigureAwait(false);
            string roomModelId = await GetUniqueModelIdAsync(client, TestAssetDefaults.RoomModelIdPrefix).ConfigureAwait(false);

            try
            {
                // arrange

                // create room model
                string roomModel = TestAssetsHelper.GetRoomModelPayload(roomModelId, floorModelId);
                await CreateAndListModelsAsync(client, new List<string> { roomModel }).ConfigureAwait(false);

                // act

                // create room twin
                BasicDigitalTwin roomTwin = TestAssetsHelper.GetRoomTwinPayload(roomModelId);
                await client.CreateOrReplaceDigitalTwinAsync<BasicDigitalTwin>(roomTwinId, roomTwin).ConfigureAwait(false);

                // get twin
                ETag? etagBeforeUpdate = (await client.GetDigitalTwinAsync<BasicDigitalTwin>(roomTwinId).ConfigureAwait(false)).Value.ETag;

                Assert.IsNotNull(etagBeforeUpdate);

                // update twin once to make the previous etag fall out of date
                JsonPatchDocument updateTwinPatchDocument = new JsonPatchDocument();
                updateTwinPatchDocument.AppendAdd("/Humidity", 30);
                updateTwinPatchDocument.AppendReplace("/Temperature", 70);
                updateTwinPatchDocument.AppendRemove("/EmployeeId");
                await client.UpdateDigitalTwinAsync(roomTwinId, updateTwinPatchDocument, ETag.All).ConfigureAwait(false);

                // update twin again, but with an out of date etag, which should cause a 412 from service
                JsonPatchDocument secondUpdateTwinPatchDocument = new JsonPatchDocument();
                secondUpdateTwinPatchDocument.AppendReplace("/Humidity", 80);
                Func<Task> act = async () =>
                {
                    await client.UpdateDigitalTwinAsync(roomTwinId, secondUpdateTwinPatchDocument, etagBeforeUpdate).ConfigureAwait(false);
                };

                act.Should().Throw<RequestFailedException>()
                    .And.Status.Should().Be((int)HttpStatusCode.PreconditionFailed);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Failure in executing a step in the test case: {ex.Message}.");
            }
            finally
            {
                // cleanup
                try
                {
                    if (!string.IsNullOrWhiteSpace(roomModelId))
                    {
                        await client.DeleteModelAsync(roomModelId).ConfigureAwait(false);
                    }
                }
                catch (Exception ex)
                {
                    Assert.Fail($"Test clean up failed: {ex.Message}");
                }
            }
        }

        [Test]
        public async Task DigitalTwins_PatchTwinSucceedsIfCorrectETagProvided()
        {
            DigitalTwinsClient client = GetClient();

            string roomTwinId = await GetUniqueTwinIdAsync(client, TestAssetDefaults.RoomTwinIdPrefix).ConfigureAwait(false);
            string floorModelId = await GetUniqueModelIdAsync(client, TestAssetDefaults.FloorModelIdPrefix).ConfigureAwait(false);
            string roomModelId = await GetUniqueModelIdAsync(client, TestAssetDefaults.RoomModelIdPrefix).ConfigureAwait(false);

            try
            {
                // arrange

                // create room model
                string roomModel = TestAssetsHelper.GetRoomModelPayload(roomModelId, floorModelId);
                await CreateAndListModelsAsync(client, new List<string> { roomModel }).ConfigureAwait(false);

                // act

                // create room twin
                BasicDigitalTwin roomTwin = TestAssetsHelper.GetRoomTwinPayload(roomModelId);
                await client.CreateOrReplaceDigitalTwinAsync<BasicDigitalTwin>(roomTwinId, roomTwin).ConfigureAwait(false);

                // update twin once
                JsonPatchDocument updateTwinPatchDocument = new JsonPatchDocument();
                updateTwinPatchDocument.AppendAdd("/Humidity", 30);
                updateTwinPatchDocument.AppendReplace("/Temperature", 70);
                updateTwinPatchDocument.AppendRemove("/EmployeeId");
                await client.UpdateDigitalTwinAsync(roomTwinId, updateTwinPatchDocument, ETag.All).ConfigureAwait(false);

                // get twin
                ETag? etagBeforeUpdate = (await client.GetDigitalTwinAsync<BasicDigitalTwin>(roomTwinId).ConfigureAwait(false)).Value.ETag;

                Assert.IsNotNull(etagBeforeUpdate);

                // update twin again, but with the correct etag
                JsonPatchDocument secondUpdateTwinPatchDocument = new JsonPatchDocument();
                secondUpdateTwinPatchDocument.AppendReplace("/Humidity", 80);
                try
                {
                    await client.UpdateDigitalTwinAsync(roomTwinId, secondUpdateTwinPatchDocument, etagBeforeUpdate).ConfigureAwait(false);
                }
                catch (RequestFailedException ex) when (ex.Status == (int)HttpStatusCode.PreconditionFailed)
                {
                    throw new AssertionException("UpdateDigitalTwin should not have thrown PreconditionFailed because the ETag was up to date", ex);
                }
            }
            catch (Exception ex)
            {
                Assert.Fail($"Failure in executing a step in the test case: {ex.Message}.");
            }
            finally
            {
                // cleanup
                try
                {
                    if (!string.IsNullOrWhiteSpace(roomModelId))
                    {
                        await client.DeleteModelAsync(roomModelId).ConfigureAwait(false);
                    }
                }
                catch (Exception ex)
                {
                    Assert.Fail($"Test clean up failed: {ex.Message}");
                }
            }
        }

        [Test]
        public async Task DigitalTwins_DeleteTwinFailsIfMatchProvidesOutdatedEtag()
        {
            DigitalTwinsClient client = GetClient();

            string roomTwinId = await GetUniqueTwinIdAsync(client, TestAssetDefaults.RoomTwinIdPrefix).ConfigureAwait(false);
            string floorModelId = await GetUniqueModelIdAsync(client, TestAssetDefaults.FloorModelIdPrefix).ConfigureAwait(false);
            string roomModelId = await GetUniqueModelIdAsync(client, TestAssetDefaults.RoomModelIdPrefix).ConfigureAwait(false);

            try
            {
                // arrange

                // create room model
                string roomModel = TestAssetsHelper.GetRoomModelPayload(roomModelId, floorModelId);
                await CreateAndListModelsAsync(client, new List<string> { roomModel }).ConfigureAwait(false);

                // act

                // create room twin
                BasicDigitalTwin roomTwin = TestAssetsHelper.GetRoomTwinPayload(roomModelId);
                await client.CreateOrReplaceDigitalTwinAsync<BasicDigitalTwin>(roomTwinId, roomTwin).ConfigureAwait(false);

                // get twin
                ETag? etagBeforeUpdate = (await client.GetDigitalTwinAsync<BasicDigitalTwin>(roomTwinId).ConfigureAwait(false)).Value.ETag;

                // update twin
                JsonPatchDocument updateTwinPatchDocument = new JsonPatchDocument();
                updateTwinPatchDocument.AppendAdd("/Humidity", 30);
                updateTwinPatchDocument.AppendReplace("/Temperature", 70);
                updateTwinPatchDocument.AppendRemove("/EmployeeId");

                await client.UpdateDigitalTwinAsync(roomTwinId, updateTwinPatchDocument, ETag.All).ConfigureAwait(false);

                // assert
                Func<Task> act = async () =>
                {
                    // since the ETag is out of date, this call should throw a 412
                    await client.DeleteDigitalTwinAsync(roomTwinId, etagBeforeUpdate).ConfigureAwait(false);
                };

                act.Should().Throw<RequestFailedException>()
                    .And.Status.Should().Be((int)HttpStatusCode.PreconditionFailed);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Failure in executing a step in the test case: {ex.Message}.");
            }
            finally
            {
                // cleanup
                try
                {
                    if (!string.IsNullOrWhiteSpace(roomModelId))
                    {
                        await client.DeleteModelAsync(roomModelId).ConfigureAwait(false);
                    }
                }
                catch (Exception ex)
                {
                    Assert.Fail($"Test clean up failed: {ex.Message}");
                }
            }
        }

        [Test]
        public async Task DigitalTwins_DeleteTwinSucceedsIfMatchProvidesCorrectEtag()
        {
            DigitalTwinsClient client = GetClient();

            string roomTwinId = await GetUniqueTwinIdAsync(client, TestAssetDefaults.RoomTwinIdPrefix).ConfigureAwait(false);
            string floorModelId = await GetUniqueModelIdAsync(client, TestAssetDefaults.FloorModelIdPrefix).ConfigureAwait(false);
            string roomModelId = await GetUniqueModelIdAsync(client, TestAssetDefaults.RoomModelIdPrefix).ConfigureAwait(false);

            try
            {
                // arrange

                // create room model
                string roomModel = TestAssetsHelper.GetRoomModelPayload(roomModelId, floorModelId);
                await CreateAndListModelsAsync(client, new List<string> { roomModel }).ConfigureAwait(false);

                // act

                // create room twin
                BasicDigitalTwin roomTwin = TestAssetsHelper.GetRoomTwinPayload(roomModelId);
                await client.CreateOrReplaceDigitalTwinAsync<BasicDigitalTwin>(roomTwinId, roomTwin).ConfigureAwait(false);

                // update twin
                JsonPatchDocument updateTwinPatchDocument = new JsonPatchDocument();
                updateTwinPatchDocument.AppendAdd("/Humidity", 30);
                updateTwinPatchDocument.AppendReplace("/Temperature", 70);
                updateTwinPatchDocument.AppendRemove("/EmployeeId");
                await client.UpdateDigitalTwinAsync(roomTwinId, updateTwinPatchDocument, ETag.All).ConfigureAwait(false);

                // get twin
                ETag? correctETag = (await client.GetDigitalTwinAsync<BasicDigitalTwin>(roomTwinId).ConfigureAwait(false)).Value.ETag;
                Assert.IsNotNull(correctETag);

                try
                {
                    // since the ETag is not out of date, this call should not throw a 412
                    await client.DeleteDigitalTwinAsync(roomTwinId, correctETag).ConfigureAwait(false);
                }
                catch (RequestFailedException ex) when (ex.Status == (int)HttpStatusCode.PreconditionFailed)
                {
                    throw new AssertionException("UpdateRelationship should not have thrown PreconditionFailed because the ETag was up to date", ex);
                }
            }
            catch (Exception ex)
            {
                Assert.Fail($"Failure in executing a step in the test case: {ex.Message}.");
            }
            finally
            {
                // cleanup
                try
                {
                    if (!string.IsNullOrWhiteSpace(roomModelId))
                    {
                        await client.DeleteModelAsync(roomModelId).ConfigureAwait(false);
                    }
                }
                catch (Exception ex)
                {
                    Assert.Fail($"Test clean up failed: {ex.Message}");
                }
            }
        }
    }
}
