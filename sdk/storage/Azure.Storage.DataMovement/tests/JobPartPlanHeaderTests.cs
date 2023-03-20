// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Storage.DataMovement.JobPlanModels;
using Microsoft.CodeAnalysis;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Tests
{
    public class JobPartPlanHeaderTests : DataMovementTestBase
    {
        private static IDictionary<string, string> StringToDictionary(string str, string elementName)
        {
            IDictionary<string, string> dictionary = new Dictionary<string, string>();
            string[] splitSemiColon = str.Split(';');
            foreach (string value in splitSemiColon)
            {
                string[] splitEqual = value.Split('=');
                if (splitEqual.Length != 2)
                {
                    throw Errors.InvalidStringToDictionary(elementName, str);
                }
                dictionary.Add(splitEqual[0], splitEqual[1]);
            }
            return dictionary;
        }

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
            Assert.AreEqual(header.SourcePath, _testSourcePath);
            Assert.AreEqual(header.SourcePathLength, _testSourcePath.Length);
            Assert.AreEqual(header.SourceExtraQuery, _testSourceQuery);
            Assert.AreEqual(header.SourceExtraQueryLength, _testSourceQuery.Length);
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
            Assert.AreEqual(header.FromTo, _testFromTo);
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
            Assert.AreEqual(header.DstBlobData.CpkInfo, _testCpkInfo);
            Assert.AreEqual(header.DstBlobData.CpkInfoLength, _testCpkInfo.Length);
            Assert.IsFalse(header.DstBlobData.IsSourceEncrypted);
            Assert.AreEqual(header.DstBlobData.CpkScopeInfo, _testCpkScopeInfo);
            Assert.AreEqual(header.DstBlobData.CpkScopeInfoLength, _testCpkScopeInfo.Length);
            Assert.AreEqual(header.DstBlobData.BlockSize, _testBlockSize);
            Assert.IsFalse(header.DstLocalData.PreserveLastModifiedTime);
            Assert.AreEqual(header.DstLocalData.MD5VerificationOption, _testMd5VerificationOption);
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
        public void Serialize()
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

                int versionSize = DataMovementConstants.PlanFile.VersionStrMaxSize;
                byte[] versionBuffer = new byte[versionSize];
                stream.ReadAsync(versionBuffer, 0, versionSize);
                Assert.AreEqual(DataMovementConstants.PlanFile.SchemaVersion.ToByteArray(versionSize), versionBuffer);

                int startTimeSize = DataMovementConstants.PlanFile.LongSizeInBytes;
                byte[] startTimeBuffer = new byte[startTimeSize];
                stream.ReadAsync(startTimeBuffer, 0, startTimeSize);
                Assert.AreEqual(_testStartTime.Ticks.ToByteArray(startTimeSize), startTimeBuffer);

                int transferIdSize = DataMovementConstants.PlanFile.TransferIdStrMaxSize;
                byte[] transferIdBuffer = new byte[transferIdSize];
                stream.ReadAsync(transferIdBuffer, 0, transferIdSize);
                Assert.AreEqual(_testTransferId.ToByteArray(transferIdSize), transferIdBuffer);

                int partNumberSize = DataMovementConstants.PlanFile.LongSizeInBytes;
                byte[] partNumberBuffer = new byte[partNumberSize];
                stream.ReadAsync(partNumberBuffer, 0, partNumberSize);
                Assert.AreEqual(_testPartNumber.ToByteArray(partNumberSize), partNumberBuffer);

                int sourcePathLengthSize = DataMovementConstants.PlanFile.LongSizeInBytes;
                byte[] sourcePathLengthBuffer = new byte[sourcePathLengthSize];
                stream.ReadAsync(sourcePathLengthBuffer, 0, sourcePathLengthSize);
                Assert.AreEqual(((long)_testSourcePath.Length).ToByteArray(sourcePathLengthSize), sourcePathLengthBuffer);

                int sourcePathSize = DataMovementConstants.PlanFile.PathStrMaxSize;
                byte[] sourcePathBuffer = new byte[sourcePathSize];
                stream.ReadAsync(sourcePathBuffer, 0, sourcePathSize);
                Assert.AreEqual(_testSourcePath.ToByteArray(sourcePathSize), sourcePathBuffer);

                int sourceExtraQueryLengthSize = DataMovementConstants.PlanFile.LongSizeInBytes;
                byte[] sourceExtraQueryLengthBuffer = new byte[sourceExtraQueryLengthSize];
                stream.ReadAsync(sourceExtraQueryLengthBuffer, 0, sourceExtraQueryLengthSize);
                Assert.AreEqual(((long)_testSourceQuery.Length).ToByteArray(sourceExtraQueryLengthSize), sourceExtraQueryLengthBuffer);

                int sourceExtraQuerySize = DataMovementConstants.PlanFile.ExtraQueryMaxSize;
                byte[] sourceExtraQueryBuffer = new byte[sourceExtraQuerySize];
                stream.ReadAsync(sourceExtraQueryBuffer, 0, sourceExtraQuerySize);
                Assert.AreEqual(_testSourceQuery.ToByteArray(sourceExtraQuerySize), sourceExtraQueryBuffer);

                int destinationPathLengthSize = DataMovementConstants.PlanFile.LongSizeInBytes;
                byte[] destinationPathLengthBuffer = new byte[destinationPathLengthSize];
                stream.ReadAsync(destinationPathLengthBuffer, 0, destinationPathLengthSize);
                Assert.AreEqual(((long)_testDestinationPath.Length).ToByteArray(destinationPathLengthSize), destinationPathLengthBuffer);

                int destinationPathSize = DataMovementConstants.PlanFile.PathStrMaxSize;
                byte[] destinationPathBuffer = new byte[destinationPathSize];
                stream.ReadAsync(destinationPathBuffer, 0, destinationPathSize);
                Assert.AreEqual(_testDestinationPath.ToByteArray(destinationPathSize), destinationPathBuffer);

                int destinationExtraQueryLengthSize = DataMovementConstants.PlanFile.LongSizeInBytes;
                byte[] destinationExtraQueryLengthBuffer = new byte[destinationExtraQueryLengthSize];
                stream.ReadAsync(destinationExtraQueryLengthBuffer, 0, destinationExtraQueryLengthSize);
                Assert.AreEqual(((long)_testDestinationQuery.Length).ToByteArray(destinationExtraQueryLengthSize), destinationExtraQueryLengthBuffer);

                int destinationExtraQuerySize = DataMovementConstants.PlanFile.ExtraQueryMaxSize;
                byte[] destinationExtraQueryBuffer = new byte[destinationExtraQuerySize];
                stream.ReadAsync(destinationExtraQueryBuffer, 0, destinationExtraQuerySize);
                Assert.AreEqual(_testDestinationQuery.ToByteArray(destinationExtraQuerySize), destinationExtraQueryBuffer);

                int oneByte = DataMovementConstants.PlanFile.OneByte;

                byte[] isFinalPartBuffer = new byte[oneByte];
                stream.ReadAsync(isFinalPartBuffer, 0, oneByte);
                Assert.AreEqual(0, isFinalPartBuffer[0]);

                byte[] forceWriteBuffer = new byte[oneByte];
                stream.ReadAsync(forceWriteBuffer, 0, forceWriteBuffer.Length);
                Assert.AreEqual(0, forceWriteBuffer[0]);

                byte[] forceIfReadOnlyBuffer = new byte[oneByte];
                stream.ReadAsync(forceIfReadOnlyBuffer, 0, oneByte);
                Assert.AreEqual(0, forceIfReadOnlyBuffer[0]);

                byte[] autoDecompressBuffer = new byte[oneByte];
                stream.ReadAsync(autoDecompressBuffer, 0, oneByte);
                Assert.AreEqual(0, autoDecompressBuffer[0]);

                byte[] priorityBuffer = new byte[oneByte];
                stream.ReadAsync(priorityBuffer, 0, oneByte);
                Assert.AreEqual(0, priorityBuffer[0]);

                int ttlAfterCompletionSize = DataMovementConstants.PlanFile.LongSizeInBytes;
                byte[] ttlAfterCompletionBuffer = new byte[ttlAfterCompletionSize];
                stream.ReadAsync(ttlAfterCompletionBuffer, 0, ttlAfterCompletionSize);
                Assert.AreEqual(_testTtlAfterCompletion.Ticks.ToByteArray(ttlAfterCompletionSize), ttlAfterCompletionBuffer);

                byte[] fromToBuffer = new byte[oneByte];
                stream.ReadAsync(fromToBuffer, 0, oneByte);
                Assert.AreEqual((byte)_testFromTo, fromToBuffer[0]);

                byte[] folderPropertyModeBuffer = new byte[oneByte];
                stream.ReadAsync(folderPropertyModeBuffer, 0, oneByte);
                Assert.AreEqual((byte)_testFolderPropertiesMode, folderPropertyModeBuffer[0]);

                int numberChunksSize = DataMovementConstants.PlanFile.LongSizeInBytes;
                byte[] numberChunksBuffer = new byte[numberChunksSize];
                stream.ReadAsync(numberChunksBuffer, 0, numberChunksSize);
                Assert.AreEqual(_testNumberChunks.ToByteArray(numberChunksSize), numberChunksBuffer);

                byte[] blobTypeBuffer = new byte[oneByte];
                stream.ReadAsync(blobTypeBuffer, 0, oneByte);
                Assert.AreEqual((byte)_testBlobType, blobTypeBuffer[0]);

                byte[] noGuessMimeTypeBuffer = new byte[oneByte];
                stream.ReadAsync(noGuessMimeTypeBuffer, 0, oneByte);
                Assert.AreEqual(0, noGuessMimeTypeBuffer[0]);

                int contentTypeLengthSize = DataMovementConstants.PlanFile.LongSizeInBytes;
                byte[] contentTypeLengthBuffer = new byte[contentTypeLengthSize];
                stream.ReadAsync(contentTypeLengthBuffer, 0, contentTypeLengthSize);
                Assert.AreEqual(((long)_testContentType.Length).ToByteArray(contentTypeLengthSize), contentTypeLengthBuffer);

                int contentTypeSize = DataMovementConstants.PlanFile.HeaderValueMaxSize;
                byte[] contentTypeBuffer = new byte[contentTypeSize];
                stream.ReadAsync(contentTypeBuffer, 0, contentTypeSize);
                Assert.AreEqual(_testContentType.ToByteArray(contentTypeSize), contentTypeBuffer);

                int contentEncodingLengthSize = DataMovementConstants.PlanFile.LongSizeInBytes;
                byte[] contentEncodingLengthBuffer = new byte[contentEncodingLengthSize];
                stream.ReadAsync(contentEncodingLengthBuffer, 0, contentEncodingLengthSize);
                Assert.AreEqual(((long)_testContentEncoding.Length).ToByteArray(contentEncodingLengthSize), contentEncodingLengthBuffer);

                int contentEncodingSize = DataMovementConstants.PlanFile.HeaderValueMaxSize;
                byte[] contentEncodingBuffer = new byte[contentEncodingSize];
                stream.ReadAsync(contentEncodingBuffer, 0, contentEncodingSize);
                Assert.AreEqual(_testContentEncoding.ToByteArray(contentEncodingSize), contentEncodingBuffer);

                int contentLanguageLengthSize = DataMovementConstants.PlanFile.LongSizeInBytes;
                byte[] contentLanguageLengthBuffer = new byte[contentLanguageLengthSize];
                stream.ReadAsync(contentLanguageLengthBuffer, 0, contentLanguageLengthSize);
                Assert.AreEqual(((long)_testContentLanguage.Length).ToByteArray(contentLanguageLengthSize), contentLanguageLengthBuffer);

                int contentLanguageSize = DataMovementConstants.PlanFile.HeaderValueMaxSize;
                byte[] contentLanguageBuffer = new byte[contentLanguageSize];
                stream.ReadAsync(contentLanguageBuffer, 0, contentLanguageSize);
                Assert.AreEqual(_testContentLanguage.ToByteArray(contentLanguageSize), contentLanguageBuffer);

                int contentDispositionLengthSize = DataMovementConstants.PlanFile.LongSizeInBytes;
                byte[] contentDispositionLengthBuffer = new byte[contentDispositionLengthSize];
                stream.ReadAsync(contentDispositionLengthBuffer, 0, contentDispositionLengthSize);
                Assert.AreEqual(((long)_testContentDisposition.Length).ToByteArray(contentDispositionLengthSize), contentDispositionLengthBuffer);

                int contentDispositionSize = DataMovementConstants.PlanFile.HeaderValueMaxSize;
                byte[] contentDispositionBuffer = new byte[contentDispositionSize];
                stream.ReadAsync(contentDispositionBuffer, 0, contentDispositionSize);
                Assert.AreEqual(_testContentDisposition.ToByteArray(contentDispositionSize), contentDispositionBuffer);

                int cacheControlLengthSize = DataMovementConstants.PlanFile.LongSizeInBytes;
                byte[] cacheControlLengthBuffer = new byte[cacheControlLengthSize];
                stream.ReadAsync(cacheControlLengthBuffer, 0, cacheControlLengthSize);
                Assert.AreEqual(((long)_testCacheControl.Length).ToByteArray(cacheControlLengthSize), cacheControlLengthBuffer);

                int cacheControlSize = DataMovementConstants.PlanFile.HeaderValueMaxSize;
                byte[] cacheControlBuffer = new byte[cacheControlSize];
                stream.ReadAsync(cacheControlBuffer, 0, cacheControlSize);
                Assert.AreEqual(_testCacheControl.ToByteArray(cacheControlSize), cacheControlBuffer);

                byte[] blockBlobTierBuffer = new byte[oneByte];
                stream.ReadAsync(blockBlobTierBuffer, 0, oneByte);
                Assert.AreEqual((byte)_testBlockBlobTier, blockBlobTierBuffer[0]);

                byte[] pageBlobTierBuffer = new byte[oneByte];
                stream.ReadAsync(pageBlobTierBuffer, 0, oneByte);
                Assert.AreEqual((byte)_testPageBlobTier, pageBlobTierBuffer[0]);

                byte[] putMd5Buffer = new byte[oneByte];
                stream.ReadAsync(putMd5Buffer, 0, oneByte);
                Assert.AreEqual(0, putMd5Buffer[0]);

                string metadataStr = DictionaryToString(metadata);
                int metadataLengthSize = DataMovementConstants.PlanFile.LongSizeInBytes;
                byte[] metadataLengthBuffer = new byte[metadataLengthSize];
                stream.ReadAsync(metadataLengthBuffer, 0, metadataLengthSize);
                Assert.AreEqual(((long)metadataStr.Length).ToByteArray(metadataLengthSize), metadataLengthBuffer);

                int metadataSize = DataMovementConstants.PlanFile.MetadataStrMaxSize;
                byte[] metadataBuffer = new byte[metadataSize];
                stream.ReadAsync(metadataBuffer, 0, metadataSize);
                Assert.AreEqual(metadataStr.ToByteArray(metadataSize), metadataBuffer);

                string blobTagsStr = DictionaryToString(blobTags);
                int blobTagsLengthSize = DataMovementConstants.PlanFile.LongSizeInBytes;
                byte[] blobTagsLengthBuffer = new byte[blobTagsLengthSize];
                stream.ReadAsync(blobTagsLengthBuffer, 0, blobTagsLengthSize);
                Assert.AreEqual(((long)blobTagsStr.Length).ToByteArray(blobTagsLengthSize), blobTagsLengthBuffer);

                int blobTagsSize = DataMovementConstants.PlanFile.BlobTagsStrMaxSize;
                byte[] blobTagsBuffer = new byte[blobTagsSize];
                stream.ReadAsync(blobTagsBuffer, 0, blobTagsSize);
                Assert.AreEqual(blobTagsStr.ToByteArray(blobTagsSize), blobTagsBuffer);

                int cpkInfoLengthSize = DataMovementConstants.PlanFile.LongSizeInBytes;
                byte[] cpkInfoLengthBuffer = new byte[cpkInfoLengthSize];
                stream.ReadAsync(cpkInfoLengthBuffer, 0, cpkInfoLengthSize);
                Assert.AreEqual(((long)_testCpkInfo.Length).ToByteArray(cpkInfoLengthSize), cpkInfoLengthBuffer);

                int cpkInfoSize = DataMovementConstants.PlanFile.HeaderValueMaxSize;
                byte[] cpkInfoBuffer = new byte[cpkInfoSize];
                stream.ReadAsync(cpkInfoBuffer, 0, cpkInfoSize);
                Assert.AreEqual(_testCpkInfo.ToByteArray(cpkInfoSize), cpkInfoBuffer);

                byte[] isSourceEncryptedBuffer = new byte[oneByte];
                stream.ReadAsync(isSourceEncryptedBuffer, 0, oneByte);
                Assert.AreEqual(0, isSourceEncryptedBuffer[0]);

                int cpkScopeInfoLengthSize = DataMovementConstants.PlanFile.LongSizeInBytes;
                byte[] cpkScopeInfoLengthBuffer = new byte[cpkScopeInfoLengthSize];
                stream.ReadAsync(cpkScopeInfoLengthBuffer, 0, cpkScopeInfoLengthSize);
                Assert.AreEqual(((long)_testCpkScopeInfo.Length).ToByteArray(cpkScopeInfoLengthSize), cpkScopeInfoLengthBuffer);

                int cpkScopeInfoSize = DataMovementConstants.PlanFile.HeaderValueMaxSize;
                byte[] cpkScopeInfoBuffer = new byte[cpkScopeInfoSize];
                stream.ReadAsync(cpkScopeInfoBuffer, 0, cpkScopeInfoSize);
                Assert.AreEqual(_testCpkScopeInfo.ToByteArray(cpkScopeInfoSize), cpkScopeInfoBuffer);

                int blockSizeLengthSize = DataMovementConstants.PlanFile.LongSizeInBytes;
                byte[] blockSizeLengthBuffer = new byte[blockSizeLengthSize];
                stream.ReadAsync(blockSizeLengthBuffer, 0, blockSizeLengthSize);
                Assert.AreEqual(_testBlockSize.ToByteArray(blockSizeLengthSize), blockSizeLengthBuffer);

                byte[] preserveLastModifiedTimeBuffer = new byte[oneByte];
                stream.ReadAsync(preserveLastModifiedTimeBuffer, 0, oneByte);
                Assert.AreEqual(0, preserveLastModifiedTimeBuffer[0]);

                byte[] md5VerificationOptionBuffer = new byte[oneByte];
                stream.ReadAsync(md5VerificationOptionBuffer, 0, oneByte);
                Assert.AreEqual(_testMd5VerificationOption, md5VerificationOptionBuffer[0]);

                byte[] preserveSMBPermissionsBuffer = new byte[oneByte];
                stream.ReadAsync(preserveSMBPermissionsBuffer, 0, oneByte);
                Assert.AreEqual(0, preserveSMBPermissionsBuffer[0]);

                byte[] preserveSMBInfoBuffer = new byte[oneByte];
                stream.ReadAsync(preserveSMBInfoBuffer, 0, oneByte);
                Assert.AreEqual(0, preserveSMBInfoBuffer[0]);

                byte[] s2sGetPropertiesInBackendBuffer = new byte[oneByte];
                stream.ReadAsync(s2sGetPropertiesInBackendBuffer, 0, oneByte);
                Assert.AreEqual(0, s2sGetPropertiesInBackendBuffer[0]);

                byte[] s2sSourceChangeValidationBuffer = new byte[oneByte];
                stream.ReadAsync(s2sSourceChangeValidationBuffer, 0, oneByte);
                Assert.AreEqual(0, s2sSourceChangeValidationBuffer[0]);

                byte[] destLengthValidationBuffer = new byte[oneByte];
                stream.ReadAsync(destLengthValidationBuffer, 0, oneByte);
                Assert.AreEqual(0, destLengthValidationBuffer[0]);

                byte[] s2sInvalidMetadataHandleOptionBuffer = new byte[oneByte];
                stream.ReadAsync(s2sInvalidMetadataHandleOptionBuffer, 0, oneByte);
                Assert.AreEqual(_testS2sInvalidMetadataHandleOption, s2sInvalidMetadataHandleOptionBuffer[0]);

                byte[] deleteSnapshotsOptionBuffer = new byte[oneByte];
                stream.ReadAsync(deleteSnapshotsOptionBuffer, 0, oneByte);
                Assert.AreEqual((byte)_testDeleteSnapshotsOption, deleteSnapshotsOptionBuffer[0]);

                byte[] permanentDeleteOptionBuffer = new byte[oneByte];
                stream.ReadAsync(permanentDeleteOptionBuffer, 0, oneByte);
                Assert.AreEqual((byte)_testPermanentDeleteOption, permanentDeleteOptionBuffer[0]);

                byte[] rehydratePriorityTypeBuffer = new byte[oneByte];
                stream.ReadAsync(rehydratePriorityTypeBuffer, 0, oneByte);
                Assert.AreEqual((byte)_testRehydratePriorityType, rehydratePriorityTypeBuffer[0]);

                byte[] atomicJobStatusBuffer = new byte[oneByte];
                stream.ReadAsync(atomicJobStatusBuffer, 0, oneByte);
                Assert.AreEqual((byte)_testJobStatus, atomicJobStatusBuffer[0]);

                byte[] atomicPartStatusBuffer = new byte[oneByte];
                stream.ReadAsync(atomicPartStatusBuffer, 0, oneByte);
                Assert.AreEqual((byte)_testPartStatus, atomicPartStatusBuffer[0]);
            }
        }

        [Test]
        public void Serialize_Error()
        {
            // Arrange
            JobPartPlanHeader header = CreateDefaultJobPartHeader();

            // Act / Assert
            Assert.Catch(
                () => header.Serialize(default));
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

                // Act
                JobPartPlanHeader deserializedHeader = JobPartPlanHeader.Deserialize(stream);

                // Assert
                Assert.AreEqual(deserializedHeader.Version, DataMovementConstants.PlanFile.SchemaVersion);
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
                Assert.AreEqual(deserializedHeader.FromTo, _testFromTo);
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
                Assert.AreEqual(deserializedHeader.DstBlobData.CpkInfo, _testCpkInfo);
                Assert.AreEqual(deserializedHeader.DstBlobData.CpkInfoLength, _testCpkInfo.Length);
                Assert.IsFalse(deserializedHeader.DstBlobData.IsSourceEncrypted);
                Assert.AreEqual(deserializedHeader.DstBlobData.CpkScopeInfo, _testCpkScopeInfo);
                Assert.AreEqual(deserializedHeader.DstBlobData.CpkScopeInfoLength, _testCpkScopeInfo.Length);
                Assert.AreEqual(deserializedHeader.DstBlobData.BlockSize, _testBlockSize);
                Assert.IsFalse(deserializedHeader.DstLocalData.PreserveLastModifiedTime);
                Assert.AreEqual(deserializedHeader.DstLocalData.MD5VerificationOption, _testMd5VerificationOption);
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

        [Test]
        public void Deserialize_Error()
        {
            // Arrange
            JobPartPlanHeader header = CreateDefaultJobPartHeader();

            // Act / Assert
            using (MemoryStream stream = new MemoryStream())
            {
                Assert.Catch(
                    () => JobPartPlanHeader.Deserialize(stream));
            }
        }
    }
}
