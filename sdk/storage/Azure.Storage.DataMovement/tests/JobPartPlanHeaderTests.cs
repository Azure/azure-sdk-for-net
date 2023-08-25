// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Azure.Storage.DataMovement.JobPlan;
using Azure.Storage.Test;
using NUnit.Framework;
using static Azure.Storage.DataMovement.Tests.CheckpointerTesting;

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
            IDictionary<string, string> metadata = DataProvider.BuildMetadata();
            IDictionary<string, string> blobTags = DataProvider.BuildTags();

            JobPartPlanHeader header = CreateDefaultJobPartHeader(
                metadata: metadata,
                blobTags: blobTags);

            Assert.AreEqual(header.Version, DataMovementConstants.JobPartPlanFile.SchemaVersion);
            Assert.AreEqual(header.StartTime, DefaultStartTime);
            Assert.AreEqual(header.TransferId, DefaultTransferId);
            Assert.AreEqual(header.PartNumber, DefaultPartNumber);
            Assert.AreEqual(header.SourceResourceId, DefaultSourceResourceId);
            Assert.AreEqual(header.SourcePath, DefaultSourcePath);
            Assert.AreEqual(header.SourcePathLength, DefaultSourcePath.Length);
            Assert.AreEqual(header.SourceExtraQuery, DefaultSourceQuery);
            Assert.AreEqual(header.SourceExtraQueryLength, DefaultSourceQuery.Length);
            Assert.AreEqual(header.DestinationResourceId, DefaultDestinationResourceId);
            Assert.AreEqual(header.DestinationPath, DefaultDestinationPath);
            Assert.AreEqual(header.DestinationPathLength, DefaultDestinationPath.Length);
            Assert.AreEqual(header.DestinationExtraQuery, DefaultDestinationQuery);
            Assert.AreEqual(header.DestinationExtraQueryLength, DefaultDestinationQuery.Length);
            Assert.IsFalse(header.IsFinalPart);
            Assert.IsFalse(header.ForceWrite);
            Assert.IsFalse(header.ForceIfReadOnly);
            Assert.IsFalse(header.AutoDecompress);
            Assert.AreEqual(header.Priority, DefaultPriority);
            Assert.AreEqual(header.TTLAfterCompletion, DefaultTtlAfterCompletion);
            Assert.AreEqual(header.JobPlanOperation, DefaultJobPlanOperation);
            Assert.AreEqual(header.FolderPropertyMode, DefaultFolderPropertiesMode);
            Assert.AreEqual(header.NumberChunks, DefaultNumberChunks);
            Assert.AreEqual(header.DstBlobData.BlobType, DefaultBlobType);
            Assert.IsFalse(header.DstBlobData.NoGuessMimeType);
            Assert.AreEqual(header.DstBlobData.ContentType, DefaultContentType);
            Assert.AreEqual(header.DstBlobData.ContentTypeLength, DefaultContentType.Length);
            Assert.AreEqual(header.DstBlobData.ContentEncoding, DefaultContentEncoding);
            Assert.AreEqual(header.DstBlobData.ContentEncodingLength, DefaultContentEncoding.Length);
            Assert.AreEqual(header.DstBlobData.ContentLanguage, DefaultContentLanguage);
            Assert.AreEqual(header.DstBlobData.ContentLanguageLength, DefaultContentLanguage.Length);
            Assert.AreEqual(header.DstBlobData.ContentDisposition, DefaultContentDisposition);
            Assert.AreEqual(header.DstBlobData.ContentDispositionLength, DefaultContentDisposition.Length);
            Assert.AreEqual(header.DstBlobData.CacheControl, DefaultCacheControl);
            Assert.AreEqual(header.DstBlobData.CacheControlLength, DefaultCacheControl.Length);
            Assert.AreEqual(header.DstBlobData.BlockBlobTier, DefaultBlockBlobTier);
            Assert.AreEqual(header.DstBlobData.PageBlobTier, DefaultPageBlobTier);
            Assert.IsFalse(header.DstBlobData.PutMd5);
            string metadataStr = DictionaryToString(metadata);
            Assert.AreEqual(header.DstBlobData.Metadata, metadataStr);
            Assert.AreEqual(header.DstBlobData.MetadataLength, metadataStr.Length);
            string blobTagsStr = DictionaryToString(blobTags);
            Assert.AreEqual(header.DstBlobData.BlobTags, blobTagsStr);
            Assert.AreEqual(header.DstBlobData.BlobTagsLength, blobTagsStr.Length);
            Assert.IsFalse(header.DstBlobData.IsSourceEncrypted);
            Assert.AreEqual(header.DstBlobData.CpkScopeInfo, DefaultCpkScopeInfo);
            Assert.AreEqual(header.DstBlobData.CpkScopeInfoLength, DefaultCpkScopeInfo.Length);
            Assert.AreEqual(header.DstBlobData.BlockSize, DefaultBlockSize);
            Assert.IsFalse(header.DstLocalData.PreserveLastModifiedTime);
            Assert.AreEqual(header.DstLocalData.ChecksumVerificationOption, DefaultChecksumVerificationOption);
            Assert.IsFalse(header.PreserveSMBPermissions);
            Assert.IsFalse(header.PreserveSMBInfo);
            Assert.IsFalse(header.S2SGetPropertiesInBackend);
            Assert.IsFalse(header.S2SSourceChangeValidation);
            Assert.IsFalse(header.DestLengthValidation);
            Assert.AreEqual(header.S2SInvalidMetadataHandleOption, DefaultS2sInvalidMetadataHandleOption);
            Assert.AreEqual(header.DeleteSnapshotsOption, DefaultDeleteSnapshotsOption);
            Assert.AreEqual(header.PermanentDeleteOption, DefaultPermanentDeleteOption);
            Assert.AreEqual(header.RehydratePriorityType, DefaultRehydratePriorityType);
            Assert.AreEqual(header.AtomicJobStatus, DefaultJobStatus);
            Assert.AreEqual(header.AtomicPartStatus, DefaultPartStatus);
        }

        [Test]
        public async Task Serialize()
        {
            // Arrange
            IDictionary<string, string> metadata = DataProvider.BuildMetadata();
            IDictionary<string, string> blobTags = DataProvider.BuildTags();

            JobPartPlanHeader header = CreateDefaultJobPartHeader(
                metadata: metadata,
                blobTags: blobTags);

            using (Stream stream = new MemoryStream(DataMovementConstants.JobPartPlanFile.JobPartHeaderSizeInBytes))
            {
                // Act
                header.Serialize(stream);

                // Assert
                stream.Position = 0;

                int versionSize = DataMovementConstants.JobPartPlanFile.VersionStrNumBytes;
                byte[] versionBuffer = new byte[versionSize];
                await stream.ReadAsync(versionBuffer, 0, versionSize);
                Assert.AreEqual(DataMovementConstants.JobPartPlanFile.SchemaVersion.ToByteArray(versionSize), versionBuffer);

                int startTimeSize = DataMovementConstants.LongSizeInBytes;
                byte[] startTimeBuffer = new byte[startTimeSize];
                await stream.ReadAsync(startTimeBuffer, 0, startTimeSize);
                Assert.AreEqual(DefaultStartTime.Ticks.ToByteArray(startTimeSize), startTimeBuffer);

                int transferIdSize = DataMovementConstants.JobPartPlanFile.TransferIdStrNumBytes;
                byte[] transferIdBuffer = new byte[transferIdSize];
                await stream.ReadAsync(transferIdBuffer, 0, transferIdSize);
                Assert.AreEqual(DefaultTransferId.ToByteArray(transferIdSize), transferIdBuffer);

                int partNumberSize = DataMovementConstants.LongSizeInBytes;
                byte[] partNumberBuffer = new byte[partNumberSize];
                await stream.ReadAsync(partNumberBuffer, 0, partNumberSize);
                Assert.AreEqual(DefaultPartNumber.ToByteArray(partNumberSize), partNumberBuffer);

                int sourceResourceIdLengthSize = DataMovementConstants.UShortSizeInBytes;
                byte[] sourceResourceIdLengthBuffer = new byte[sourceResourceIdLengthSize];
                await stream.ReadAsync(sourceResourceIdLengthBuffer, 0, sourceResourceIdLengthSize);
                Assert.AreEqual(((ushort)DefaultSourceResourceId.Length).ToByteArray(sourceResourceIdLengthSize), sourceResourceIdLengthBuffer);

                int sourceResourceIdSize = DataMovementConstants.JobPartPlanFile.ResourceIdNumBytes;
                byte[] sourceResourceIdBuffer = new byte[sourceResourceIdSize];
                await stream.ReadAsync(sourceResourceIdBuffer, 0, sourceResourceIdSize);
                Assert.AreEqual(DefaultSourceResourceId.ToByteArray(sourceResourceIdSize), sourceResourceIdBuffer);

                int sourcePathLengthSize = DataMovementConstants.UShortSizeInBytes;
                byte[] sourcePathLengthBuffer = new byte[sourcePathLengthSize];
                await stream.ReadAsync(sourcePathLengthBuffer, 0, sourcePathLengthSize);
                Assert.AreEqual(((ushort)DefaultSourcePath.Length).ToByteArray(sourcePathLengthSize), sourcePathLengthBuffer);

                int sourcePathSize = DataMovementConstants.JobPartPlanFile.PathStrNumBytes;
                byte[] sourcePathBuffer = new byte[sourcePathSize];
                await stream.ReadAsync(sourcePathBuffer, 0, sourcePathSize);
                Assert.AreEqual(DefaultSourcePath.ToByteArray(sourcePathSize), sourcePathBuffer);

                int sourceExtraQueryLengthSize = DataMovementConstants.UShortSizeInBytes;
                byte[] sourceExtraQueryLengthBuffer = new byte[sourceExtraQueryLengthSize];
                await stream.ReadAsync(sourceExtraQueryLengthBuffer, 0, sourceExtraQueryLengthSize);
                Assert.AreEqual(((ushort)DefaultSourceQuery.Length).ToByteArray(sourceExtraQueryLengthSize), sourceExtraQueryLengthBuffer);

                int sourceExtraQuerySize = DataMovementConstants.JobPartPlanFile.ExtraQueryNumBytes;
                byte[] sourceExtraQueryBuffer = new byte[sourceExtraQuerySize];
                await stream.ReadAsync(sourceExtraQueryBuffer, 0, sourceExtraQuerySize);
                Assert.AreEqual(DefaultSourceQuery.ToByteArray(sourceExtraQuerySize), sourceExtraQueryBuffer);

                int destinationResourceIdLengthSize = DataMovementConstants.UShortSizeInBytes;
                byte[] destinationResourceIdLengthBuffer = new byte[destinationResourceIdLengthSize];
                await stream.ReadAsync(destinationResourceIdLengthBuffer, 0, destinationResourceIdLengthSize);
                Assert.AreEqual(((ushort)DefaultDestinationResourceId.Length).ToByteArray(destinationResourceIdLengthSize), destinationResourceIdLengthBuffer);

                int destinationResourceIdSize = DataMovementConstants.JobPartPlanFile.ResourceIdNumBytes;
                byte[] destinationResourceIdBuffer = new byte[destinationResourceIdSize];
                await stream.ReadAsync(destinationResourceIdBuffer, 0, destinationResourceIdSize);
                Assert.AreEqual(DefaultDestinationResourceId.ToByteArray(destinationResourceIdSize), destinationResourceIdBuffer);

                int destinationPathLengthSize = DataMovementConstants.UShortSizeInBytes;
                byte[] destinationPathLengthBuffer = new byte[destinationPathLengthSize];
                await stream.ReadAsync(destinationPathLengthBuffer, 0, destinationPathLengthSize);
                Assert.AreEqual(((ushort)DefaultDestinationPath.Length).ToByteArray(destinationPathLengthSize), destinationPathLengthBuffer);

                int destinationPathSize = DataMovementConstants.JobPartPlanFile.PathStrNumBytes;
                byte[] destinationPathBuffer = new byte[destinationPathSize];
                await stream.ReadAsync(destinationPathBuffer, 0, destinationPathSize);
                Assert.AreEqual(DefaultDestinationPath.ToByteArray(destinationPathSize), destinationPathBuffer);

                int destinationExtraQueryLengthSize = DataMovementConstants.UShortSizeInBytes;
                byte[] destinationExtraQueryLengthBuffer = new byte[destinationExtraQueryLengthSize];
                await stream.ReadAsync(destinationExtraQueryLengthBuffer, 0, destinationExtraQueryLengthSize);
                Assert.AreEqual(((ushort)DefaultDestinationQuery.Length).ToByteArray(destinationExtraQueryLengthSize), destinationExtraQueryLengthBuffer);

                int destinationExtraQuerySize = DataMovementConstants.JobPartPlanFile.ExtraQueryNumBytes;
                byte[] destinationExtraQueryBuffer = new byte[destinationExtraQuerySize];
                await stream.ReadAsync(destinationExtraQueryBuffer, 0, destinationExtraQuerySize);
                Assert.AreEqual(DefaultDestinationQuery.ToByteArray(destinationExtraQuerySize), destinationExtraQueryBuffer);

                int oneByte = DataMovementConstants.OneByte;
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

                int ttlAfterCompletionSize = DataMovementConstants.LongSizeInBytes;
                byte[] ttlAfterCompletionBuffer = new byte[ttlAfterCompletionSize];
                await stream.ReadAsync(ttlAfterCompletionBuffer, 0, ttlAfterCompletionSize);
                Assert.AreEqual(DefaultTtlAfterCompletion.Ticks.ToByteArray(ttlAfterCompletionSize), ttlAfterCompletionBuffer);

                byte[] fromToBuffer = new byte[oneByte];
                await stream.ReadAsync(fromToBuffer, 0, oneByte);
                Assert.AreEqual((byte)DefaultJobPlanOperation, fromToBuffer[0]);

                byte[] folderPropertyModeBuffer = new byte[oneByte];
                await stream.ReadAsync(folderPropertyModeBuffer, 0, oneByte);
                Assert.AreEqual((byte)DefaultFolderPropertiesMode, folderPropertyModeBuffer[0]);

                int numberChunksSize = DataMovementConstants.LongSizeInBytes;
                byte[] numberChunksBuffer = new byte[numberChunksSize];
                await stream.ReadAsync(numberChunksBuffer, 0, numberChunksSize);
                Assert.AreEqual(DefaultNumberChunks.ToByteArray(numberChunksSize), numberChunksBuffer);

                byte[] blobTypeBuffer = new byte[oneByte];
                await stream.ReadAsync(blobTypeBuffer, 0, oneByte);
                Assert.AreEqual((byte)DefaultBlobType, blobTypeBuffer[0]);

                byte[] noGuessMimeTypeBuffer = new byte[oneByte];
                await stream.ReadAsync(noGuessMimeTypeBuffer, 0, oneByte);
                Assert.AreEqual(0, noGuessMimeTypeBuffer[0]);

                int contentTypeLengthSize = DataMovementConstants.UShortSizeInBytes;
                byte[] contentTypeLengthBuffer = new byte[contentTypeLengthSize];
                await stream.ReadAsync(contentTypeLengthBuffer, 0, contentTypeLengthSize);
                Assert.AreEqual(((ushort)DefaultContentType.Length).ToByteArray(contentTypeLengthSize), contentTypeLengthBuffer);

                int contentTypeSize = DataMovementConstants.JobPartPlanFile.HeaderValueNumBytes;
                byte[] contentTypeBuffer = new byte[contentTypeSize];
                await stream.ReadAsync(contentTypeBuffer, 0, contentTypeSize);
                Assert.AreEqual(DefaultContentType.ToByteArray(contentTypeSize), contentTypeBuffer);

                int contentEncodingLengthSize = DataMovementConstants.UShortSizeInBytes;
                byte[] contentEncodingLengthBuffer = new byte[contentEncodingLengthSize];
                await stream.ReadAsync(contentEncodingLengthBuffer, 0, contentEncodingLengthSize);
                Assert.AreEqual(((ushort)DefaultContentEncoding.Length).ToByteArray(contentEncodingLengthSize), contentEncodingLengthBuffer);

                int contentEncodingSize = DataMovementConstants.JobPartPlanFile.HeaderValueNumBytes;
                byte[] contentEncodingBuffer = new byte[contentEncodingSize];
                await stream.ReadAsync(contentEncodingBuffer, 0, contentEncodingSize);
                Assert.AreEqual(DefaultContentEncoding.ToByteArray(contentEncodingSize), contentEncodingBuffer);

                int contentLanguageLengthSize = DataMovementConstants.UShortSizeInBytes;
                byte[] contentLanguageLengthBuffer = new byte[contentLanguageLengthSize];
                await stream.ReadAsync(contentLanguageLengthBuffer, 0, contentLanguageLengthSize);
                Assert.AreEqual(((ushort)DefaultContentLanguage.Length).ToByteArray(contentLanguageLengthSize), contentLanguageLengthBuffer);

                int contentLanguageSize = DataMovementConstants.JobPartPlanFile.HeaderValueNumBytes;
                byte[] contentLanguageBuffer = new byte[contentLanguageSize];
                await stream.ReadAsync(contentLanguageBuffer, 0, contentLanguageSize);
                Assert.AreEqual(DefaultContentLanguage.ToByteArray(contentLanguageSize), contentLanguageBuffer);

                int contentDispositionLengthSize = DataMovementConstants.UShortSizeInBytes;
                byte[] contentDispositionLengthBuffer = new byte[contentDispositionLengthSize];
                await stream.ReadAsync(contentDispositionLengthBuffer, 0, contentDispositionLengthSize);
                Assert.AreEqual(((ushort)DefaultContentDisposition.Length).ToByteArray(contentDispositionLengthSize), contentDispositionLengthBuffer);

                int contentDispositionSize = DataMovementConstants.JobPartPlanFile.HeaderValueNumBytes;
                byte[] contentDispositionBuffer = new byte[contentDispositionSize];
                await stream.ReadAsync(contentDispositionBuffer, 0, contentDispositionSize);
                Assert.AreEqual(DefaultContentDisposition.ToByteArray(contentDispositionSize), contentDispositionBuffer);

                int cacheControlLengthSize = DataMovementConstants.UShortSizeInBytes;
                byte[] cacheControlLengthBuffer = new byte[cacheControlLengthSize];
                await stream.ReadAsync(cacheControlLengthBuffer, 0, cacheControlLengthSize);
                Assert.AreEqual(((ushort)DefaultCacheControl.Length).ToByteArray(cacheControlLengthSize), cacheControlLengthBuffer);

                int cacheControlSize = DataMovementConstants.JobPartPlanFile.HeaderValueNumBytes;
                byte[] cacheControlBuffer = new byte[cacheControlSize];
                await stream.ReadAsync(cacheControlBuffer, 0, cacheControlSize);
                Assert.AreEqual(DefaultCacheControl.ToByteArray(cacheControlSize), cacheControlBuffer);

                byte[] blockBlobTierBuffer = new byte[oneByte];
                await stream.ReadAsync(blockBlobTierBuffer, 0, oneByte);
                Assert.AreEqual((byte)DefaultBlockBlobTier, blockBlobTierBuffer[0]);

                byte[] pageBlobTierBuffer = new byte[oneByte];
                await stream.ReadAsync(pageBlobTierBuffer, 0, oneByte);
                Assert.AreEqual((byte)DefaultPageBlobTier, pageBlobTierBuffer[0]);

                byte[] putMd5Buffer = new byte[oneByte];
                await stream.ReadAsync(putMd5Buffer, 0, oneByte);
                Assert.AreEqual(0, putMd5Buffer[0]);

                string metadataStr = DictionaryToString(metadata);
                int metadataLengthSize = DataMovementConstants.UShortSizeInBytes;
                byte[] metadataLengthBuffer = new byte[metadataLengthSize];
                await stream.ReadAsync(metadataLengthBuffer, 0, metadataLengthSize);
                Assert.AreEqual(((ushort)metadataStr.Length).ToByteArray(metadataLengthSize), metadataLengthBuffer);

                int metadataSize = DataMovementConstants.JobPartPlanFile.MetadataStrNumBytes;
                byte[] metadataBuffer = new byte[metadataSize];
                await stream.ReadAsync(metadataBuffer, 0, metadataSize);
                Assert.AreEqual(metadataStr.ToByteArray(metadataSize), metadataBuffer);

                string blobTagsStr = DictionaryToString(blobTags);
                int blobTagsLengthSize = DataMovementConstants.LongSizeInBytes;
                byte[] blobTagsLengthBuffer = new byte[blobTagsLengthSize];
                await stream.ReadAsync(blobTagsLengthBuffer, 0, blobTagsLengthSize);
                Assert.AreEqual(((long)blobTagsStr.Length).ToByteArray(blobTagsLengthSize), blobTagsLengthBuffer);

                int blobTagsSize = DataMovementConstants.JobPartPlanFile.BlobTagsStrNumBytes;
                byte[] blobTagsBuffer = new byte[blobTagsSize];
                await stream.ReadAsync(blobTagsBuffer, 0, blobTagsSize);
                Assert.AreEqual(blobTagsStr.ToByteArray(blobTagsSize), blobTagsBuffer);

                byte[] isSourceEncryptedBuffer = new byte[oneByte];
                await stream.ReadAsync(isSourceEncryptedBuffer, 0, oneByte);
                Assert.AreEqual(0, isSourceEncryptedBuffer[0]);

                int cpkScopeInfoLengthSize = DataMovementConstants.UShortSizeInBytes;
                byte[] cpkScopeInfoLengthBuffer = new byte[cpkScopeInfoLengthSize];
                await stream.ReadAsync(cpkScopeInfoLengthBuffer, 0, cpkScopeInfoLengthSize);
                Assert.AreEqual(((ushort)DefaultCpkScopeInfo.Length).ToByteArray(cpkScopeInfoLengthSize), cpkScopeInfoLengthBuffer);

                int cpkScopeInfoSize = DataMovementConstants.JobPartPlanFile.HeaderValueNumBytes;
                byte[] cpkScopeInfoBuffer = new byte[cpkScopeInfoSize];
                await stream.ReadAsync(cpkScopeInfoBuffer, 0, cpkScopeInfoSize);
                Assert.AreEqual(DefaultCpkScopeInfo.ToByteArray(cpkScopeInfoSize), cpkScopeInfoBuffer);

                int blockSizeLengthSize = DataMovementConstants.LongSizeInBytes;
                byte[] blockSizeLengthBuffer = new byte[blockSizeLengthSize];
                await stream.ReadAsync(blockSizeLengthBuffer, 0, blockSizeLengthSize);
                Assert.AreEqual(DefaultBlockSize.ToByteArray(blockSizeLengthSize), blockSizeLengthBuffer);

                byte[] preserveLastModifiedTimeBuffer = new byte[oneByte];
                await stream.ReadAsync(preserveLastModifiedTimeBuffer, 0, oneByte);
                Assert.AreEqual(0, preserveLastModifiedTimeBuffer[0]);

                byte[] checksumVerificationOptionBuffer = new byte[oneByte];
                await stream.ReadAsync(checksumVerificationOptionBuffer, 0, oneByte);
                Assert.AreEqual(DefaultChecksumVerificationOption, checksumVerificationOptionBuffer[0]);

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
                Assert.AreEqual(DefaultS2sInvalidMetadataHandleOption, s2sInvalidMetadataHandleOptionBuffer[0]);

                byte[] deleteSnapshotsOptionBuffer = new byte[oneByte];
                await stream.ReadAsync(deleteSnapshotsOptionBuffer, 0, oneByte);
                Assert.AreEqual((byte)DefaultDeleteSnapshotsOption, deleteSnapshotsOptionBuffer[0]);

                byte[] permanentDeleteOptionBuffer = new byte[oneByte];
                await stream.ReadAsync(permanentDeleteOptionBuffer, 0, oneByte);
                Assert.AreEqual((byte)DefaultPermanentDeleteOption, permanentDeleteOptionBuffer[0]);

                byte[] rehydratePriorityTypeBuffer = new byte[oneByte];
                await stream.ReadAsync(rehydratePriorityTypeBuffer, 0, oneByte);
                Assert.AreEqual((byte)DefaultRehydratePriorityType, rehydratePriorityTypeBuffer[0]);

                byte[] atomicJobStatusBuffer = new byte[oneByte];
                await stream.ReadAsync(atomicJobStatusBuffer, 0, oneByte);
                Assert.AreEqual((byte)DefaultJobStatus, atomicJobStatusBuffer[0]);

                byte[] atomicPartStatusBuffer = new byte[oneByte];
                await stream.ReadAsync(atomicPartStatusBuffer, 0, oneByte);
                Assert.AreEqual((byte)DefaultPartStatus, atomicPartStatusBuffer[0]);
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
            IDictionary<string, string> metadata = DataProvider.BuildMetadata();
            IDictionary<string, string> blobTags = DataProvider.BuildTags();

            JobPartPlanHeader header = CreateDefaultJobPartHeader(
                metadata: metadata,
                blobTags: blobTags);

            using (Stream stream = new MemoryStream(DataMovementConstants.JobPartPlanFile.JobPartHeaderSizeInBytes))
            {
                header.Serialize(stream);

                // Act / Assert
                DeserializeAndVerify(stream, DataMovementConstants.JobPartPlanFile.SchemaVersion, metadata, blobTags);
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
                    $"The checkpoint file schema version {DataMovementConstants.JobPartPlanFile.SchemaVersion_b1} is not supported by this version of the SDK.");
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
                DeserializeAndVerify(stream, DataMovementConstants.JobPartPlanFile.SchemaVersion_b2, DataProvider.BuildMetadata(), DataProvider.BuildTags());
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
            Assert.AreEqual(deserializedHeader.StartTime, DefaultStartTime);
            Assert.AreEqual(deserializedHeader.TransferId, DefaultTransferId);
            Assert.AreEqual(deserializedHeader.PartNumber, DefaultPartNumber);
            Assert.AreEqual(deserializedHeader.SourcePath, DefaultSourcePath);
            Assert.AreEqual(deserializedHeader.SourcePathLength, DefaultSourcePath.Length);
            Assert.AreEqual(deserializedHeader.SourceExtraQuery, DefaultSourceQuery);
            Assert.AreEqual(deserializedHeader.SourceExtraQueryLength, DefaultSourceQuery.Length);
            Assert.AreEqual(deserializedHeader.DestinationPath, DefaultDestinationPath);
            Assert.AreEqual(deserializedHeader.DestinationPathLength, DefaultDestinationPath.Length);
            Assert.AreEqual(deserializedHeader.DestinationExtraQuery, DefaultDestinationQuery);
            Assert.AreEqual(deserializedHeader.DestinationExtraQueryLength, DefaultDestinationQuery.Length);
            Assert.IsFalse(deserializedHeader.IsFinalPart);
            Assert.IsFalse(deserializedHeader.ForceWrite);
            Assert.IsFalse(deserializedHeader.ForceIfReadOnly);
            Assert.IsFalse(deserializedHeader.AutoDecompress);
            Assert.AreEqual(deserializedHeader.Priority, DefaultPriority);
            Assert.AreEqual(deserializedHeader.TTLAfterCompletion, DefaultTtlAfterCompletion);
            Assert.AreEqual(deserializedHeader.JobPlanOperation, DefaultJobPlanOperation);
            Assert.AreEqual(deserializedHeader.FolderPropertyMode, DefaultFolderPropertiesMode);
            Assert.AreEqual(deserializedHeader.NumberChunks, DefaultNumberChunks);
            Assert.AreEqual(deserializedHeader.DstBlobData.BlobType, DefaultBlobType);
            Assert.IsFalse(deserializedHeader.DstBlobData.NoGuessMimeType);
            Assert.AreEqual(deserializedHeader.DstBlobData.ContentType, DefaultContentType);
            Assert.AreEqual(deserializedHeader.DstBlobData.ContentTypeLength, DefaultContentType.Length);
            Assert.AreEqual(deserializedHeader.DstBlobData.ContentEncoding, DefaultContentEncoding);
            Assert.AreEqual(deserializedHeader.DstBlobData.ContentEncodingLength, DefaultContentEncoding.Length);
            Assert.AreEqual(deserializedHeader.DstBlobData.ContentLanguage, DefaultContentLanguage);
            Assert.AreEqual(deserializedHeader.DstBlobData.ContentLanguageLength, DefaultContentLanguage.Length);
            Assert.AreEqual(deserializedHeader.DstBlobData.ContentDisposition, DefaultContentDisposition);
            Assert.AreEqual(deserializedHeader.DstBlobData.ContentDispositionLength, DefaultContentDisposition.Length);
            Assert.AreEqual(deserializedHeader.DstBlobData.CacheControl, DefaultCacheControl);
            Assert.AreEqual(deserializedHeader.DstBlobData.CacheControlLength, DefaultCacheControl.Length);
            Assert.AreEqual(deserializedHeader.DstBlobData.BlockBlobTier, DefaultBlockBlobTier);
            Assert.AreEqual(deserializedHeader.DstBlobData.PageBlobTier, DefaultPageBlobTier);
            Assert.IsFalse(deserializedHeader.DstBlobData.PutMd5);
            string metadataStr = DictionaryToString(metadata);
            Assert.AreEqual(deserializedHeader.DstBlobData.Metadata, metadataStr);
            Assert.AreEqual(deserializedHeader.DstBlobData.MetadataLength, metadataStr.Length);
            string blobTagsStr = DictionaryToString(blobTags);
            Assert.AreEqual(deserializedHeader.DstBlobData.BlobTags, blobTagsStr);
            Assert.AreEqual(deserializedHeader.DstBlobData.BlobTagsLength, blobTagsStr.Length);
            Assert.IsFalse(deserializedHeader.DstBlobData.IsSourceEncrypted);
            Assert.AreEqual(deserializedHeader.DstBlobData.CpkScopeInfo, DefaultCpkScopeInfo);
            Assert.AreEqual(deserializedHeader.DstBlobData.CpkScopeInfoLength, DefaultCpkScopeInfo.Length);
            Assert.AreEqual(deserializedHeader.DstBlobData.BlockSize, DefaultBlockSize);
            Assert.IsFalse(deserializedHeader.DstLocalData.PreserveLastModifiedTime);
            Assert.AreEqual(deserializedHeader.DstLocalData.ChecksumVerificationOption, DefaultChecksumVerificationOption);
            Assert.IsFalse(deserializedHeader.PreserveSMBPermissions);
            Assert.IsFalse(deserializedHeader.PreserveSMBInfo);
            Assert.IsFalse(deserializedHeader.S2SGetPropertiesInBackend);
            Assert.IsFalse(deserializedHeader.S2SSourceChangeValidation);
            Assert.IsFalse(deserializedHeader.DestLengthValidation);
            Assert.AreEqual(deserializedHeader.S2SInvalidMetadataHandleOption, DefaultS2sInvalidMetadataHandleOption);
            Assert.AreEqual(deserializedHeader.DeleteSnapshotsOption, DefaultDeleteSnapshotsOption);
            Assert.AreEqual(deserializedHeader.PermanentDeleteOption, DefaultPermanentDeleteOption);
            Assert.AreEqual(deserializedHeader.RehydratePriorityType, DefaultRehydratePriorityType);
            Assert.AreEqual(deserializedHeader.AtomicJobStatus, DefaultJobStatus);
            Assert.AreEqual(deserializedHeader.AtomicPartStatus, DefaultPartStatus);
        }
    }
}
