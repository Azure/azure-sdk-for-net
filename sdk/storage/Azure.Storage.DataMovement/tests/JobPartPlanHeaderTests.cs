// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Azure.Storage.DataMovement.Models.JobPlan;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Tests
{
    public class JobPartPlanHeaderTests : DataMovementTestBase
    {
        private static string DictionaryToString(IDictionary<string, string> dict)
        {
            string concatStr = "";
            foreach (KeyValuePair<string, string> kv in dict)
            {
                // e.g. store like "header=value;"
                concatStr = string.Concat(concatStr, $"{kv.Key}={kv.Value};");
            }
            return concatStr;
        }

        public JobPartPlanHeaderTests(bool async) : base(async, default)
        {
        }

        [Test]
        public void Ctor()
        {
            IDictionary<string, string> metadata = BuildMetadata();
            IDictionary<string, string> blobTags = BuildTags();

            JobPartPlanHeader header = CreateDefaultJobPartHeader(
                metadata: metadata,
                blobTags: blobTags);

            Assert.AreEqual(header.Version, DataMovementConstants.PlanFile.SchemaVersion);
            Assert.AreEqual(header.StartTime, _testStartTime);
            Assert.AreEqual(header.TransferId, _testTransferId);
            Assert.AreEqual(header.PartNumber, _testPartNumber);
            Assert.AreEqual(header.SourceResourceId, _testSourceResourceId);
            Assert.AreEqual(header.SourcePath, _testSourcePath);
            Assert.AreEqual(header.SourcePathLength, _testSourcePath.Length);
            Assert.AreEqual(header.SourceExtraQuery, _testSourceQuery);
            Assert.AreEqual(header.SourceExtraQueryLength, _testSourceQuery.Length);
            Assert.AreEqual(header.DestinationResourceId, _testDestinationResourceId);
            Assert.AreEqual(header.DestinationPath, _testDestinationPath);
            Assert.AreEqual(header.DestinationPathLength, _testDestinationPath.Length);
            Assert.AreEqual(header.DestinationExtraQuery, _testDestinationQuery);
            Assert.AreEqual(header.DestinationExtraQueryLength, _testDestinationQuery.Length);
            Assert.IsFalse(header.IsFinalPart);
            Assert.IsFalse(header.ForceWrite);
            Assert.IsFalse(header.ForceIfReadOnly);
            Assert.IsFalse(header.AutoDecompress);
            Assert.AreEqual(header.Priority, _testPriority);
            Assert.AreEqual(header.TTLAfterCompletion, _testTtlAfterCompletion);
            Assert.AreEqual(header.JobPlanOperation, _testJobPlanOperation);
            Assert.AreEqual(header.FolderPropertyMode, _testFolderPropertiesMode);
            Assert.AreEqual(header.NumberChunks, _testNumberChunks);
            Assert.AreEqual(header.DstBlobData.BlobType, _testBlobType);
            Assert.IsFalse(header.DstBlobData.NoGuessMimeType);
            Assert.AreEqual(header.DstBlobData.ContentType, _testContentType);
            Assert.AreEqual(header.DstBlobData.ContentTypeLength, _testContentType.Length);
            Assert.AreEqual(header.DstBlobData.ContentEncoding, _testContentEncoding);
            Assert.AreEqual(header.DstBlobData.ContentEncodingLength, _testContentEncoding.Length);
            Assert.AreEqual(header.DstBlobData.ContentLanguage, _testContentLanguage);
            Assert.AreEqual(header.DstBlobData.ContentLanguageLength, _testContentLanguage.Length);
            Assert.AreEqual(header.DstBlobData.ContentDisposition, _testContentDisposition);
            Assert.AreEqual(header.DstBlobData.ContentDispositionLength, _testContentDisposition.Length);
            Assert.AreEqual(header.DstBlobData.CacheControl, _testCacheControl);
            Assert.AreEqual(header.DstBlobData.CacheControlLength, _testCacheControl.Length);
            Assert.AreEqual(header.DstBlobData.BlockBlobTier, _testBlockBlobTier);
            Assert.AreEqual(header.DstBlobData.PageBlobTier, _testPageBlobTier);
            Assert.IsFalse(header.DstBlobData.PutMd5);
            string metadataStr = DictionaryToString(metadata);
            Assert.AreEqual(header.DstBlobData.Metadata, metadataStr);
            Assert.AreEqual(header.DstBlobData.MetadataLength, metadataStr.Length);
            string blobTagsStr = DictionaryToString(blobTags);
            Assert.AreEqual(header.DstBlobData.BlobTags, blobTagsStr);
            Assert.AreEqual(header.DstBlobData.BlobTagsLength, blobTagsStr.Length);
            Assert.IsFalse(header.DstBlobData.IsSourceEncrypted);
            Assert.AreEqual(header.DstBlobData.CpkScopeInfo, _testCpkScopeInfo);
            Assert.AreEqual(header.DstBlobData.CpkScopeInfoLength, _testCpkScopeInfo.Length);
            Assert.AreEqual(header.DstBlobData.BlockSize, _testBlockSize);
            Assert.IsFalse(header.DstLocalData.PreserveLastModifiedTime);
            Assert.AreEqual(header.DstLocalData.ChecksumVerificationOption, _testChecksumVerificationOption);
            Assert.IsFalse(header.PreserveSMBPermissions);
            Assert.IsFalse(header.PreserveSMBInfo);
            Assert.IsFalse(header.S2SGetPropertiesInBackend);
            Assert.IsFalse(header.S2SSourceChangeValidation);
            Assert.IsFalse(header.DestLengthValidation);
            Assert.AreEqual(header.S2SInvalidMetadataHandleOption, _testS2sInvalidMetadataHandleOption);
            Assert.AreEqual(header.DeleteSnapshotsOption, _testDeleteSnapshotsOption);
            Assert.AreEqual(header.PermanentDeleteOption, _testPermanentDeleteOption);
            Assert.AreEqual(header.RehydratePriorityType, _testRehydratePriorityType);
            Assert.AreEqual(header.AtomicJobStatus, _testJobStatus);
            Assert.AreEqual(header.AtomicPartStatus, _testPartStatus);
        }

        [Test]
        public async Task Serialize()
        {
            // Arrange
            IDictionary<string, string> metadata = BuildMetadata();
            IDictionary<string, string> blobTags = BuildTags();

            JobPartPlanHeader header = CreateDefaultJobPartHeader(
                metadata: metadata,
                blobTags: blobTags);

            using (Stream stream = new MemoryStream(DataMovementConstants.PlanFile.JobPartHeaderSizeInBytes))
            {
                // Act
                header.Serialize(stream);

                // Assert
                stream.Position = 0;

                int versionSize = DataMovementConstants.PlanFile.VersionStrNumBytes;
                byte[] versionBuffer = new byte[versionSize];
                await stream.ReadAsync(versionBuffer, 0, versionSize);
                Assert.AreEqual(DataMovementConstants.PlanFile.SchemaVersion.ToByteArray(versionSize), versionBuffer);

                int startTimeSize = DataMovementConstants.PlanFile.LongSizeInBytes;
                byte[] startTimeBuffer = new byte[startTimeSize];
                await stream.ReadAsync(startTimeBuffer, 0, startTimeSize);
                Assert.AreEqual(_testStartTime.Ticks.ToByteArray(startTimeSize), startTimeBuffer);

                int transferIdSize = DataMovementConstants.PlanFile.TransferIdStrNumBytes;
                byte[] transferIdBuffer = new byte[transferIdSize];
                await stream.ReadAsync(transferIdBuffer, 0, transferIdSize);
                Assert.AreEqual(_testTransferId.ToByteArray(transferIdSize), transferIdBuffer);

                int partNumberSize = DataMovementConstants.PlanFile.LongSizeInBytes;
                byte[] partNumberBuffer = new byte[partNumberSize];
                await stream.ReadAsync(partNumberBuffer, 0, partNumberSize);
                Assert.AreEqual(_testPartNumber.ToByteArray(partNumberSize), partNumberBuffer);

                int sourceResourceIdLengthSize = DataMovementConstants.PlanFile.UShortSizeInBytes;
                byte[] sourceResourceIdLengthBuffer = new byte[sourceResourceIdLengthSize];
                await stream.ReadAsync(sourceResourceIdLengthBuffer, 0, sourceResourceIdLengthSize);
                Assert.AreEqual(((ushort)_testSourceResourceId.Length).ToByteArray(sourceResourceIdLengthSize), sourceResourceIdLengthBuffer);

                int sourceResourceIdSize = DataMovementConstants.PlanFile.ResourceIdNumBytes;
                byte[] sourceResourceIdBuffer = new byte[sourceResourceIdSize];
                await stream.ReadAsync(sourceResourceIdBuffer, 0, sourceResourceIdSize);
                Assert.AreEqual(_testSourceResourceId.ToByteArray(sourceResourceIdSize), sourceResourceIdBuffer);

                int sourcePathLengthSize = DataMovementConstants.PlanFile.UShortSizeInBytes;
                byte[] sourcePathLengthBuffer = new byte[sourcePathLengthSize];
                await stream.ReadAsync(sourcePathLengthBuffer, 0, sourcePathLengthSize);
                Assert.AreEqual(((ushort)_testSourcePath.Length).ToByteArray(sourcePathLengthSize), sourcePathLengthBuffer);

                int sourcePathSize = DataMovementConstants.PlanFile.PathStrNumBytes;
                byte[] sourcePathBuffer = new byte[sourcePathSize];
                await stream.ReadAsync(sourcePathBuffer, 0, sourcePathSize);
                Assert.AreEqual(_testSourcePath.ToByteArray(sourcePathSize), sourcePathBuffer);

                int sourceExtraQueryLengthSize = DataMovementConstants.PlanFile.UShortSizeInBytes;
                byte[] sourceExtraQueryLengthBuffer = new byte[sourceExtraQueryLengthSize];
                await stream.ReadAsync(sourceExtraQueryLengthBuffer, 0, sourceExtraQueryLengthSize);
                Assert.AreEqual(((ushort)_testSourceQuery.Length).ToByteArray(sourceExtraQueryLengthSize), sourceExtraQueryLengthBuffer);

                int sourceExtraQuerySize = DataMovementConstants.PlanFile.ExtraQueryNumBytes;
                byte[] sourceExtraQueryBuffer = new byte[sourceExtraQuerySize];
                await stream.ReadAsync(sourceExtraQueryBuffer, 0, sourceExtraQuerySize);
                Assert.AreEqual(_testSourceQuery.ToByteArray(sourceExtraQuerySize), sourceExtraQueryBuffer);

                int destinationResourceIdLengthSize = DataMovementConstants.PlanFile.UShortSizeInBytes;
                byte[] destinationResourceIdLengthBuffer = new byte[destinationResourceIdLengthSize];
                await stream.ReadAsync(destinationResourceIdLengthBuffer, 0, destinationResourceIdLengthSize);
                Assert.AreEqual(((ushort)_testDestinationResourceId.Length).ToByteArray(destinationResourceIdLengthSize), destinationResourceIdLengthBuffer);

                int destinationResourceIdSize = DataMovementConstants.PlanFile.ResourceIdNumBytes;
                byte[] destinationResourceIdBuffer = new byte[destinationResourceIdSize];
                await stream.ReadAsync(destinationResourceIdBuffer, 0, destinationResourceIdSize);
                Assert.AreEqual(_testDestinationResourceId.ToByteArray(destinationResourceIdSize), destinationResourceIdBuffer);

                int destinationPathLengthSize = DataMovementConstants.PlanFile.UShortSizeInBytes;
                byte[] destinationPathLengthBuffer = new byte[destinationPathLengthSize];
                await stream.ReadAsync(destinationPathLengthBuffer, 0, destinationPathLengthSize);
                Assert.AreEqual(((ushort)_testDestinationPath.Length).ToByteArray(destinationPathLengthSize), destinationPathLengthBuffer);

                int destinationPathSize = DataMovementConstants.PlanFile.PathStrNumBytes;
                byte[] destinationPathBuffer = new byte[destinationPathSize];
                await stream.ReadAsync(destinationPathBuffer, 0, destinationPathSize);
                Assert.AreEqual(_testDestinationPath.ToByteArray(destinationPathSize), destinationPathBuffer);

                int destinationExtraQueryLengthSize = DataMovementConstants.PlanFile.UShortSizeInBytes;
                byte[] destinationExtraQueryLengthBuffer = new byte[destinationExtraQueryLengthSize];
                await stream.ReadAsync(destinationExtraQueryLengthBuffer, 0, destinationExtraQueryLengthSize);
                Assert.AreEqual(((ushort)_testDestinationQuery.Length).ToByteArray(destinationExtraQueryLengthSize), destinationExtraQueryLengthBuffer);

                int destinationExtraQuerySize = DataMovementConstants.PlanFile.ExtraQueryNumBytes;
                byte[] destinationExtraQueryBuffer = new byte[destinationExtraQuerySize];
                await stream.ReadAsync(destinationExtraQueryBuffer, 0, destinationExtraQuerySize);
                Assert.AreEqual(_testDestinationQuery.ToByteArray(destinationExtraQuerySize), destinationExtraQueryBuffer);

                int oneByte = DataMovementConstants.PlanFile.OneByte;
                byte[] isFinalPartBuffer = new byte[oneByte];
                await stream.ReadAsync(isFinalPartBuffer, 0, oneByte);
                Assert.AreEqual(0, isFinalPartBuffer[0]);

                byte[] forceWriteBuffer = new byte[oneByte];
                await stream.ReadAsync(forceWriteBuffer, 0, forceWriteBuffer.Length);
                Assert.AreEqual(0, forceWriteBuffer[0]);

                byte[] forceIfReadOnlyBuffer = new byte[oneByte];
                await stream.ReadAsync(forceIfReadOnlyBuffer, 0, oneByte);
                Assert.AreEqual(0, forceIfReadOnlyBuffer[0]);

                byte[] autoDecompressBuffer = new byte[oneByte];
                await stream.ReadAsync(autoDecompressBuffer, 0, oneByte);
                Assert.AreEqual(0, autoDecompressBuffer[0]);

                byte[] priorityBuffer = new byte[oneByte];
                await stream.ReadAsync(priorityBuffer, 0, oneByte);
                Assert.AreEqual(0, priorityBuffer[0]);

                int ttlAfterCompletionSize = DataMovementConstants.PlanFile.LongSizeInBytes;
                byte[] ttlAfterCompletionBuffer = new byte[ttlAfterCompletionSize];
                await stream.ReadAsync(ttlAfterCompletionBuffer, 0, ttlAfterCompletionSize);
                Assert.AreEqual(_testTtlAfterCompletion.Ticks.ToByteArray(ttlAfterCompletionSize), ttlAfterCompletionBuffer);

                byte[] fromToBuffer = new byte[oneByte];
                await stream.ReadAsync(fromToBuffer, 0, oneByte);
                Assert.AreEqual((byte)_testJobPlanOperation, fromToBuffer[0]);

                byte[] folderPropertyModeBuffer = new byte[oneByte];
                await stream.ReadAsync(folderPropertyModeBuffer, 0, oneByte);
                Assert.AreEqual((byte)_testFolderPropertiesMode, folderPropertyModeBuffer[0]);

                int numberChunksSize = DataMovementConstants.PlanFile.LongSizeInBytes;
                byte[] numberChunksBuffer = new byte[numberChunksSize];
                await stream.ReadAsync(numberChunksBuffer, 0, numberChunksSize);
                Assert.AreEqual(_testNumberChunks.ToByteArray(numberChunksSize), numberChunksBuffer);

                byte[] blobTypeBuffer = new byte[oneByte];
                await stream.ReadAsync(blobTypeBuffer, 0, oneByte);
                Assert.AreEqual((byte)_testBlobType, blobTypeBuffer[0]);

                byte[] noGuessMimeTypeBuffer = new byte[oneByte];
                await stream.ReadAsync(noGuessMimeTypeBuffer, 0, oneByte);
                Assert.AreEqual(0, noGuessMimeTypeBuffer[0]);

                int contentTypeLengthSize = DataMovementConstants.PlanFile.UShortSizeInBytes;
                byte[] contentTypeLengthBuffer = new byte[contentTypeLengthSize];
                await stream.ReadAsync(contentTypeLengthBuffer, 0, contentTypeLengthSize);
                Assert.AreEqual(((ushort)_testContentType.Length).ToByteArray(contentTypeLengthSize), contentTypeLengthBuffer);

                int contentTypeSize = DataMovementConstants.PlanFile.HeaderValueNumBytes;
                byte[] contentTypeBuffer = new byte[contentTypeSize];
                await stream.ReadAsync(contentTypeBuffer, 0, contentTypeSize);
                Assert.AreEqual(_testContentType.ToByteArray(contentTypeSize), contentTypeBuffer);

                int contentEncodingLengthSize = DataMovementConstants.PlanFile.UShortSizeInBytes;
                byte[] contentEncodingLengthBuffer = new byte[contentEncodingLengthSize];
                await stream.ReadAsync(contentEncodingLengthBuffer, 0, contentEncodingLengthSize);
                Assert.AreEqual(((ushort)_testContentEncoding.Length).ToByteArray(contentEncodingLengthSize), contentEncodingLengthBuffer);

                int contentEncodingSize = DataMovementConstants.PlanFile.HeaderValueNumBytes;
                byte[] contentEncodingBuffer = new byte[contentEncodingSize];
                await stream.ReadAsync(contentEncodingBuffer, 0, contentEncodingSize);
                Assert.AreEqual(_testContentEncoding.ToByteArray(contentEncodingSize), contentEncodingBuffer);

                int contentLanguageLengthSize = DataMovementConstants.PlanFile.UShortSizeInBytes;
                byte[] contentLanguageLengthBuffer = new byte[contentLanguageLengthSize];
                await stream.ReadAsync(contentLanguageLengthBuffer, 0, contentLanguageLengthSize);
                Assert.AreEqual(((ushort)_testContentLanguage.Length).ToByteArray(contentLanguageLengthSize), contentLanguageLengthBuffer);

                int contentLanguageSize = DataMovementConstants.PlanFile.HeaderValueNumBytes;
                byte[] contentLanguageBuffer = new byte[contentLanguageSize];
                await stream.ReadAsync(contentLanguageBuffer, 0, contentLanguageSize);
                Assert.AreEqual(_testContentLanguage.ToByteArray(contentLanguageSize), contentLanguageBuffer);

                int contentDispositionLengthSize = DataMovementConstants.PlanFile.UShortSizeInBytes;
                byte[] contentDispositionLengthBuffer = new byte[contentDispositionLengthSize];
                await stream.ReadAsync(contentDispositionLengthBuffer, 0, contentDispositionLengthSize);
                Assert.AreEqual(((ushort)_testContentDisposition.Length).ToByteArray(contentDispositionLengthSize), contentDispositionLengthBuffer);

                int contentDispositionSize = DataMovementConstants.PlanFile.HeaderValueNumBytes;
                byte[] contentDispositionBuffer = new byte[contentDispositionSize];
                await stream.ReadAsync(contentDispositionBuffer, 0, contentDispositionSize);
                Assert.AreEqual(_testContentDisposition.ToByteArray(contentDispositionSize), contentDispositionBuffer);

                int cacheControlLengthSize = DataMovementConstants.PlanFile.UShortSizeInBytes;
                byte[] cacheControlLengthBuffer = new byte[cacheControlLengthSize];
                await stream.ReadAsync(cacheControlLengthBuffer, 0, cacheControlLengthSize);
                Assert.AreEqual(((ushort)_testCacheControl.Length).ToByteArray(cacheControlLengthSize), cacheControlLengthBuffer);

                int cacheControlSize = DataMovementConstants.PlanFile.HeaderValueNumBytes;
                byte[] cacheControlBuffer = new byte[cacheControlSize];
                await stream.ReadAsync(cacheControlBuffer, 0, cacheControlSize);
                Assert.AreEqual(_testCacheControl.ToByteArray(cacheControlSize), cacheControlBuffer);

                byte[] blockBlobTierBuffer = new byte[oneByte];
                await stream.ReadAsync(blockBlobTierBuffer, 0, oneByte);
                Assert.AreEqual((byte)_testBlockBlobTier, blockBlobTierBuffer[0]);

                byte[] pageBlobTierBuffer = new byte[oneByte];
                await stream.ReadAsync(pageBlobTierBuffer, 0, oneByte);
                Assert.AreEqual((byte)_testPageBlobTier, pageBlobTierBuffer[0]);

                byte[] putMd5Buffer = new byte[oneByte];
                await stream.ReadAsync(putMd5Buffer, 0, oneByte);
                Assert.AreEqual(0, putMd5Buffer[0]);

                string metadataStr = DictionaryToString(metadata);
                int metadataLengthSize = DataMovementConstants.PlanFile.UShortSizeInBytes;
                byte[] metadataLengthBuffer = new byte[metadataLengthSize];
                await stream.ReadAsync(metadataLengthBuffer, 0, metadataLengthSize);
                Assert.AreEqual(((ushort)metadataStr.Length).ToByteArray(metadataLengthSize), metadataLengthBuffer);

                int metadataSize = DataMovementConstants.PlanFile.MetadataStrNumBytes;
                byte[] metadataBuffer = new byte[metadataSize];
                await stream.ReadAsync(metadataBuffer, 0, metadataSize);
                Assert.AreEqual(metadataStr.ToByteArray(metadataSize), metadataBuffer);

                string blobTagsStr = DictionaryToString(blobTags);
                int blobTagsLengthSize = DataMovementConstants.PlanFile.LongSizeInBytes;
                byte[] blobTagsLengthBuffer = new byte[blobTagsLengthSize];
                await stream.ReadAsync(blobTagsLengthBuffer, 0, blobTagsLengthSize);
                Assert.AreEqual(((long)blobTagsStr.Length).ToByteArray(blobTagsLengthSize), blobTagsLengthBuffer);

                int blobTagsSize = DataMovementConstants.PlanFile.BlobTagsStrNumBytes;
                byte[] blobTagsBuffer = new byte[blobTagsSize];
                await stream.ReadAsync(blobTagsBuffer, 0, blobTagsSize);
                Assert.AreEqual(blobTagsStr.ToByteArray(blobTagsSize), blobTagsBuffer);

                byte[] isSourceEncryptedBuffer = new byte[oneByte];
                await stream.ReadAsync(isSourceEncryptedBuffer, 0, oneByte);
                Assert.AreEqual(0, isSourceEncryptedBuffer[0]);

                int cpkScopeInfoLengthSize = DataMovementConstants.PlanFile.UShortSizeInBytes;
                byte[] cpkScopeInfoLengthBuffer = new byte[cpkScopeInfoLengthSize];
                await stream.ReadAsync(cpkScopeInfoLengthBuffer, 0, cpkScopeInfoLengthSize);
                Assert.AreEqual(((ushort)_testCpkScopeInfo.Length).ToByteArray(cpkScopeInfoLengthSize), cpkScopeInfoLengthBuffer);

                int cpkScopeInfoSize = DataMovementConstants.PlanFile.HeaderValueNumBytes;
                byte[] cpkScopeInfoBuffer = new byte[cpkScopeInfoSize];
                await stream.ReadAsync(cpkScopeInfoBuffer, 0, cpkScopeInfoSize);
                Assert.AreEqual(_testCpkScopeInfo.ToByteArray(cpkScopeInfoSize), cpkScopeInfoBuffer);

                int blockSizeLengthSize = DataMovementConstants.PlanFile.LongSizeInBytes;
                byte[] blockSizeLengthBuffer = new byte[blockSizeLengthSize];
                await stream.ReadAsync(blockSizeLengthBuffer, 0, blockSizeLengthSize);
                Assert.AreEqual(_testBlockSize.ToByteArray(blockSizeLengthSize), blockSizeLengthBuffer);

                byte[] preserveLastModifiedTimeBuffer = new byte[oneByte];
                await stream.ReadAsync(preserveLastModifiedTimeBuffer, 0, oneByte);
                Assert.AreEqual(0, preserveLastModifiedTimeBuffer[0]);

                byte[] checksumVerificationOptionBuffer = new byte[oneByte];
                await stream.ReadAsync(checksumVerificationOptionBuffer, 0, oneByte);
                Assert.AreEqual(_testChecksumVerificationOption, checksumVerificationOptionBuffer[0]);

                byte[] preserveSMBPermissionsBuffer = new byte[oneByte];
                await stream.ReadAsync(preserveSMBPermissionsBuffer, 0, oneByte);
                Assert.AreEqual(0, preserveSMBPermissionsBuffer[0]);

                byte[] preserveSMBInfoBuffer = new byte[oneByte];
                await stream.ReadAsync(preserveSMBInfoBuffer, 0, oneByte);
                Assert.AreEqual(0, preserveSMBInfoBuffer[0]);

                byte[] s2sGetPropertiesInBackendBuffer = new byte[oneByte];
                await stream.ReadAsync(s2sGetPropertiesInBackendBuffer, 0, oneByte);
                Assert.AreEqual(0, s2sGetPropertiesInBackendBuffer[0]);

                byte[] s2sSourceChangeValidationBuffer = new byte[oneByte];
                await stream.ReadAsync(s2sSourceChangeValidationBuffer, 0, oneByte);
                Assert.AreEqual(0, s2sSourceChangeValidationBuffer[0]);

                byte[] destLengthValidationBuffer = new byte[oneByte];
                await stream.ReadAsync(destLengthValidationBuffer, 0, oneByte);
                Assert.AreEqual(0, destLengthValidationBuffer[0]);

                byte[] s2sInvalidMetadataHandleOptionBuffer = new byte[oneByte];
                await stream.ReadAsync(s2sInvalidMetadataHandleOptionBuffer, 0, oneByte);
                Assert.AreEqual(_testS2sInvalidMetadataHandleOption, s2sInvalidMetadataHandleOptionBuffer[0]);

                byte[] deleteSnapshotsOptionBuffer = new byte[oneByte];
                await stream.ReadAsync(deleteSnapshotsOptionBuffer, 0, oneByte);
                Assert.AreEqual((byte)_testDeleteSnapshotsOption, deleteSnapshotsOptionBuffer[0]);

                byte[] permanentDeleteOptionBuffer = new byte[oneByte];
                await stream.ReadAsync(permanentDeleteOptionBuffer, 0, oneByte);
                Assert.AreEqual((byte)_testPermanentDeleteOption, permanentDeleteOptionBuffer[0]);

                byte[] rehydratePriorityTypeBuffer = new byte[oneByte];
                await stream.ReadAsync(rehydratePriorityTypeBuffer, 0, oneByte);
                Assert.AreEqual((byte)_testRehydratePriorityType, rehydratePriorityTypeBuffer[0]);

                byte[] atomicJobStatusBuffer = new byte[oneByte];
                await stream.ReadAsync(atomicJobStatusBuffer, 0, oneByte);
                Assert.AreEqual((byte)_testJobStatus, atomicJobStatusBuffer[0]);

                byte[] atomicPartStatusBuffer = new byte[oneByte];
                await stream.ReadAsync(atomicPartStatusBuffer, 0, oneByte);
                Assert.AreEqual((byte)_testPartStatus, atomicPartStatusBuffer[0]);
            }
        }

        [Test]
        public void Serialize_Error()
        {
            // Arrange
            JobPartPlanHeader header = CreateDefaultJobPartHeader();

            // Act / Assert
            Assert.Catch<ArgumentNullException>(
                () => header.Serialize(default),
                "Stream cannot be null");
        }

        [Test]
        public void Deserialize()
        {
            // Arrange
            IDictionary<string, string> metadata = BuildMetadata();
            IDictionary<string, string> blobTags = BuildTags();

            JobPartPlanHeader header = CreateDefaultJobPartHeader(
                metadata: metadata,
                blobTags: blobTags);

            using (Stream stream = new MemoryStream(DataMovementConstants.PlanFile.JobPartHeaderSizeInBytes))
            {
                header.Serialize(stream);

                // Act / Assert
                DeserializeAndVerify(stream, DataMovementConstants.PlanFile.SchemaVersion, metadata, blobTags);
            }
        }

        [Test]
        public void Deserialize_File_Version_b1()
        {
            // Arrange
            string samplePath = Path.Combine("Resources", "SampleJobPartPlanFile.steVb1");
            using (FileStream stream = File.OpenRead(samplePath))
            {
                // Act / Assert
                Assert.Catch<ArgumentException>(
                    () => JobPartPlanHeader.Deserialize(stream),
                    $"The checkpoint file schema version {DataMovementConstants.PlanFile.SchemaVersion_b1} is not supported by this version of the SDK.");
            }
        }

        [Test]
        public void Deserialize_File_Version_b2()
        {
            // Arrange
            string samplePath = Path.Combine("Resources", "SampleJobPartPlanFile.steVb2");
            using (FileStream stream = File.OpenRead(samplePath))
            {
                // Act / Assert
                DeserializeAndVerify(stream, DataMovementConstants.PlanFile.SchemaVersion_b2, BuildMetadata(), BuildTags());
            }
        }

        [Test]
        public void Deserialize_Error()
        {
            // Arrange
            JobPartPlanHeader header = CreateDefaultJobPartHeader();

            // Act / Assert
            Assert.Catch<ArgumentNullException>(
                () => JobPartPlanHeader.Deserialize(default));
        }

        private void DeserializeAndVerify(
            Stream stream,
            string schemaVersion,
            IDictionary<string, string> metadata,
            IDictionary<string, string> blobTags)
        {
            JobPartPlanHeader deserializedHeader = JobPartPlanHeader.Deserialize(stream);

            // Assert
            Assert.AreEqual(deserializedHeader.Version, schemaVersion);
            Assert.AreEqual(deserializedHeader.StartTime, _testStartTime);
            Assert.AreEqual(deserializedHeader.TransferId, _testTransferId);
            Assert.AreEqual(deserializedHeader.PartNumber, _testPartNumber);
            Assert.AreEqual(deserializedHeader.SourcePath, _testSourcePath);
            Assert.AreEqual(deserializedHeader.SourcePathLength, _testSourcePath.Length);
            Assert.AreEqual(deserializedHeader.SourceExtraQuery, _testSourceQuery);
            Assert.AreEqual(deserializedHeader.SourceExtraQueryLength, _testSourceQuery.Length);
            Assert.AreEqual(deserializedHeader.DestinationPath, _testDestinationPath);
            Assert.AreEqual(deserializedHeader.DestinationPathLength, _testDestinationPath.Length);
            Assert.AreEqual(deserializedHeader.DestinationExtraQuery, _testDestinationQuery);
            Assert.AreEqual(deserializedHeader.DestinationExtraQueryLength, _testDestinationQuery.Length);
            Assert.IsFalse(deserializedHeader.IsFinalPart);
            Assert.IsFalse(deserializedHeader.ForceWrite);
            Assert.IsFalse(deserializedHeader.ForceIfReadOnly);
            Assert.IsFalse(deserializedHeader.AutoDecompress);
            Assert.AreEqual(deserializedHeader.Priority, _testPriority);
            Assert.AreEqual(deserializedHeader.TTLAfterCompletion, _testTtlAfterCompletion);
            Assert.AreEqual(deserializedHeader.JobPlanOperation, _testJobPlanOperation);
            Assert.AreEqual(deserializedHeader.FolderPropertyMode, _testFolderPropertiesMode);
            Assert.AreEqual(deserializedHeader.NumberChunks, _testNumberChunks);
            Assert.AreEqual(deserializedHeader.DstBlobData.BlobType, _testBlobType);
            Assert.IsFalse(deserializedHeader.DstBlobData.NoGuessMimeType);
            Assert.AreEqual(deserializedHeader.DstBlobData.ContentType, _testContentType);
            Assert.AreEqual(deserializedHeader.DstBlobData.ContentTypeLength, _testContentType.Length);
            Assert.AreEqual(deserializedHeader.DstBlobData.ContentEncoding, _testContentEncoding);
            Assert.AreEqual(deserializedHeader.DstBlobData.ContentEncodingLength, _testContentEncoding.Length);
            Assert.AreEqual(deserializedHeader.DstBlobData.ContentLanguage, _testContentLanguage);
            Assert.AreEqual(deserializedHeader.DstBlobData.ContentLanguageLength, _testContentLanguage.Length);
            Assert.AreEqual(deserializedHeader.DstBlobData.ContentDisposition, _testContentDisposition);
            Assert.AreEqual(deserializedHeader.DstBlobData.ContentDispositionLength, _testContentDisposition.Length);
            Assert.AreEqual(deserializedHeader.DstBlobData.CacheControl, _testCacheControl);
            Assert.AreEqual(deserializedHeader.DstBlobData.CacheControlLength, _testCacheControl.Length);
            Assert.AreEqual(deserializedHeader.DstBlobData.BlockBlobTier, _testBlockBlobTier);
            Assert.AreEqual(deserializedHeader.DstBlobData.PageBlobTier, _testPageBlobTier);
            Assert.IsFalse(deserializedHeader.DstBlobData.PutMd5);
            string metadataStr = DictionaryToString(metadata);
            Assert.AreEqual(deserializedHeader.DstBlobData.Metadata, metadataStr);
            Assert.AreEqual(deserializedHeader.DstBlobData.MetadataLength, metadataStr.Length);
            string blobTagsStr = DictionaryToString(blobTags);
            Assert.AreEqual(deserializedHeader.DstBlobData.BlobTags, blobTagsStr);
            Assert.AreEqual(deserializedHeader.DstBlobData.BlobTagsLength, blobTagsStr.Length);
            Assert.IsFalse(deserializedHeader.DstBlobData.IsSourceEncrypted);
            Assert.AreEqual(deserializedHeader.DstBlobData.CpkScopeInfo, _testCpkScopeInfo);
            Assert.AreEqual(deserializedHeader.DstBlobData.CpkScopeInfoLength, _testCpkScopeInfo.Length);
            Assert.AreEqual(deserializedHeader.DstBlobData.BlockSize, _testBlockSize);
            Assert.IsFalse(deserializedHeader.DstLocalData.PreserveLastModifiedTime);
            Assert.AreEqual(deserializedHeader.DstLocalData.ChecksumVerificationOption, _testChecksumVerificationOption);
            Assert.IsFalse(deserializedHeader.PreserveSMBPermissions);
            Assert.IsFalse(deserializedHeader.PreserveSMBInfo);
            Assert.IsFalse(deserializedHeader.S2SGetPropertiesInBackend);
            Assert.IsFalse(deserializedHeader.S2SSourceChangeValidation);
            Assert.IsFalse(deserializedHeader.DestLengthValidation);
            Assert.AreEqual(deserializedHeader.S2SInvalidMetadataHandleOption, _testS2sInvalidMetadataHandleOption);
            Assert.AreEqual(deserializedHeader.DeleteSnapshotsOption, _testDeleteSnapshotsOption);
            Assert.AreEqual(deserializedHeader.PermanentDeleteOption, _testPermanentDeleteOption);
            Assert.AreEqual(deserializedHeader.RehydratePriorityType, _testRehydratePriorityType);
            Assert.AreEqual(deserializedHeader.AtomicJobStatus, _testJobStatus);
            Assert.AreEqual(deserializedHeader.AtomicPartStatus, _testPartStatus);
        }
    }
}
