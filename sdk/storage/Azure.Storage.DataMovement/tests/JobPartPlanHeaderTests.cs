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
        private const string _transferId = "c591bacc-5552-4c5c-b068-552685ec5cd5";
        private const long _partNumber = 5;
        private static readonly DateTimeOffset _startTime = new DateTimeOffset(2023, 03, 13, 15, 24, 6, default);
        private const string _sourcePath = "C:/sample-source";
        private const string _sourceQuery = "sourcequery";
        private const string _destinationPath = "C:/sample-destination";
        private const string _destinationQuery = "destquery";
        private const byte _priority = 0;
        private static readonly DateTimeOffset _ttlAfterCompletion = DateTimeOffset.MaxValue;
        private const JobPlanFromTo _fromTo = JobPlanFromTo.Upload;
        private const FolderPropertiesMode _folderPropertiesMode = FolderPropertiesMode.None;
        private const long _numberChunks = 1;
        private const JobPlanBlobType _blobType = JobPlanBlobType.BlockBlob;
        private const string _contentType = "ContentType / type";
        private const string _contentEncoding = "UTF8";
        private const string _contentLanguage = "content-language";
        private const string _contentDisposition = "content-disposition";
        private const string _cacheControl = "cache-control";
        private const JobPartPlanBlockBlobTier _blockBlobTier = JobPartPlanBlockBlobTier.None;
        private const JobPartPlanPageBlobTier _pageBlobTier = JobPartPlanPageBlobTier.None;
        private const string _cpkInfo = "cpk-info";
        private const string _cpkScopeInfo = "cpk-scope-info";
        private const long _blockSize = 4 * Constants.KB;
        private const byte _s2sInvalidMetadataHandleOption = 0;
        private const byte _md5VerificationOption = 0;
        private const JobPartDeleteSnapshotsOption _jobPartDeleteSnapshotsOption = JobPartDeleteSnapshotsOption.None;
        private const JobPartPermanentDeleteOption _jobPartPermanentDeleteOption = JobPartPermanentDeleteOption.None;
        private const JobPartPlanRehydratePriorityType _jobPartPlanRehydratePriorityType = JobPartPlanRehydratePriorityType.None;
        private const StorageTransferStatus _atomicJobStatus = StorageTransferStatus.Queued;
        private const StorageTransferStatus _atomicPartStatus = StorageTransferStatus.Queued;

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

        private JobPartPlanHeader CreateDefaultHeader(
            string version = DataMovementConstants.PlanFile.SchemaVersion,
            DateTimeOffset startTime = default,
            string transferId = _transferId,
            long partNumber = _partNumber,
            string sourcePath = _sourcePath,
            string sourceExtraQuery = _sourceQuery,
            string destinationPath = _destinationPath,
            string destinationExtraQuery = _destinationQuery,
            bool isFinalPart = false,
            bool forceWrite = false,
            bool forceIfReadOnly = false,
            bool autoDecompress = false,
            byte priority = _priority,
            DateTimeOffset ttlAfterCompletion = default,
            JobPlanFromTo fromTo = _fromTo,
            FolderPropertiesMode folderPropertyMode = _folderPropertiesMode,
            long numberChunks = _numberChunks,
            JobPlanBlobType blobType = _blobType,
            bool noGuessMimeType = false,
            string contentType = _contentType,
            string contentEncoding = _contentEncoding,
            string contentLanguage = _contentLanguage,
            string contentDisposition = _contentDisposition,
            string cacheControl = _cacheControl,
            JobPartPlanBlockBlobTier blockBlobTier = _blockBlobTier,
            JobPartPlanPageBlobTier pageBlobTier = _pageBlobTier,
            bool putMd5 = false,
            IDictionary<string, string> metadata = default,
            IDictionary<string, string> blobTags = default,
            string cpkInfo = _cpkInfo,
            bool isSourceEncrypted = false,
            string cpkScopeInfo = _cpkScopeInfo,
            long blockSize = _blockSize,
            bool preserveLastModifiedTime = false,
            byte md5VerificationOption = _md5VerificationOption,
            bool preserveSMBPermissions = false,
            bool preserveSMBInfo = false,
            bool s2sGetPropertiesInBackend = false,
            bool s2sSourceChangeValidation = false,
            bool destLengthValidation = false,
            byte s2sInvalidMetadataHandleOption = _s2sInvalidMetadataHandleOption,
            JobPartDeleteSnapshotsOption deleteSnapshotsOption = _jobPartDeleteSnapshotsOption,
            JobPartPermanentDeleteOption permanentDeleteOption = _jobPartPermanentDeleteOption,
            JobPartPlanRehydratePriorityType rehydratePriorityType = _jobPartPlanRehydratePriorityType,
            StorageTransferStatus atomicJobStatus = _atomicJobStatus,
            StorageTransferStatus atomicPartStatus = _atomicPartStatus)
        {
            if (startTime == default)
            {
                startTime = _startTime;
            }
            if (ttlAfterCompletion == default)
            {
                ttlAfterCompletion = _ttlAfterCompletion;
            }
            metadata ??= BuildMetadata();
            blobTags ??= BuildTags();

            JobPartPlanDestinationBlob dstBlobData = new JobPartPlanDestinationBlob(
                blobType: blobType,
                noGuessMimeType: noGuessMimeType,
                contentType: contentType,
                contentEncoding: contentEncoding,
                contentLanguage: contentLanguage,
                contentDisposition: contentDisposition,
                cacheControl: cacheControl,
                blockBlobTier: blockBlobTier,
                pageBlobTier: pageBlobTier,
                putMd5: putMd5,
                metadata: metadata,
                blobTags: blobTags,
                cpkInfo: cpkInfo,
                isSourceEncrypted: isSourceEncrypted,
                cpkScopeInfo: cpkScopeInfo,
                blockSize: blockSize);

            JobPartPlanDestinationLocal dstLocalData = new JobPartPlanDestinationLocal(
                preserveLastModifiedTime: preserveLastModifiedTime,
                md5VerificationOption: md5VerificationOption);

            return new JobPartPlanHeader(
                version: version,
                startTime: startTime,
                transferId: transferId,
                partNumber: partNumber,
                sourcePath: sourcePath,
                sourceExtraQuery: sourceExtraQuery,
                destinationPath: destinationPath,
                destinationExtraQuery: destinationExtraQuery,
                isFinalPart: isFinalPart,
                forceWrite: forceWrite,
                forceIfReadOnly: forceIfReadOnly,
                autoDecompress: autoDecompress,
                priority: priority,
                ttlAfterCompletion: ttlAfterCompletion,
                fromTo: fromTo,
                folderPropertyMode: folderPropertyMode,
                numberChunks: numberChunks,
                dstBlobData: dstBlobData,
                dstLocalData: dstLocalData,
                preserveSMBPermissions: preserveSMBPermissions,
                preserveSMBInfo: preserveSMBInfo,
                s2sGetPropertiesInBackend: s2sGetPropertiesInBackend,
                s2sSourceChangeValidation: s2sSourceChangeValidation,
                destLengthValidation: destLengthValidation,
                s2sInvalidMetadataHandleOption: s2sInvalidMetadataHandleOption,
                deleteSnapshotsOption: deleteSnapshotsOption,
                permanentDeleteOption: permanentDeleteOption,
                rehydratePriorityType: rehydratePriorityType,
                atomicJobStatus: atomicJobStatus,
                atomicPartStatus: atomicPartStatus);
        }
        public JobPartPlanHeaderTests(bool async) : base(async, default)
        {
        }

        [Test]
        public void Ctor()
        {
            IDictionary<string, string> metadata = BuildMetadata();
            IDictionary<string, string> blobTags = BuildTags();

            JobPartPlanHeader header = CreateDefaultHeader(
                metadata: metadata,
                blobTags: blobTags);

            Assert.AreEqual(header.Version, DataMovementConstants.PlanFile.SchemaVersion);
            Assert.AreEqual(header.StartTime, _startTime);
            Assert.AreEqual(header.TransferId, _transferId);
            Assert.AreEqual(header.PartNumber, _partNumber);
            Assert.AreEqual(header.SourcePath, _sourcePath);
            Assert.AreEqual(header.SourcePathLength, _sourcePath.Length);
            Assert.AreEqual(header.SourceExtraQuery, _sourceQuery);
            Assert.AreEqual(header.SourceExtraQueryLength, _sourceQuery.Length);
            Assert.AreEqual(header.DestinationPath, _destinationPath);
            Assert.AreEqual(header.DestinationPathLength, _destinationPath.Length);
            Assert.AreEqual(header.DestinationExtraQuery, _destinationQuery);
            Assert.AreEqual(header.DestinationExtraQueryLength, _destinationQuery.Length);
            Assert.IsFalse(header.IsFinalPart);
            Assert.IsFalse(header.ForceWrite);
            Assert.IsFalse(header.ForceIfReadOnly);
            Assert.IsFalse(header.AutoDecompress);
            Assert.AreEqual(header.Priority, _priority);
            Assert.AreEqual(header.TTLAfterCompletion, _ttlAfterCompletion);
            Assert.AreEqual(header.FromTo, _fromTo);
            Assert.AreEqual(header.FolderPropertyMode, _folderPropertiesMode);
            Assert.AreEqual(header.NumberChunks, _numberChunks);
            Assert.AreEqual(header.DstBlobData.BlobType, _blobType);
            Assert.IsFalse(header.DstBlobData.NoGuessMimeType);
            Assert.AreEqual(header.DstBlobData.ContentType, _contentType);
            Assert.AreEqual(header.DstBlobData.ContentTypeLength, _contentType.Length);
            Assert.AreEqual(header.DstBlobData.ContentEncoding, _contentEncoding);
            Assert.AreEqual(header.DstBlobData.ContentEncodingLength, _contentEncoding.Length);
            Assert.AreEqual(header.DstBlobData.ContentLanguage, _contentLanguage);
            Assert.AreEqual(header.DstBlobData.ContentLanguageLength, _contentLanguage.Length);
            Assert.AreEqual(header.DstBlobData.ContentDisposition, _contentDisposition);
            Assert.AreEqual(header.DstBlobData.ContentDispositionLength, _contentDisposition.Length);
            Assert.AreEqual(header.DstBlobData.CacheControl, _cacheControl);
            Assert.AreEqual(header.DstBlobData.CacheControlLength, _cacheControl.Length);
            Assert.AreEqual(header.DstBlobData.BlockBlobTier, _blockBlobTier);
            Assert.AreEqual(header.DstBlobData.PageBlobTier, _pageBlobTier);
            Assert.IsFalse(header.DstBlobData.PutMd5);
            string metadataStr = DictionaryToString(metadata);
            Assert.AreEqual(header.DstBlobData.Metadata, metadataStr);
            Assert.AreEqual(header.DstBlobData.MetadataLength, metadataStr.Length);
            string blobTagsStr = DictionaryToString(blobTags);
            Assert.AreEqual(header.DstBlobData.BlobTags, blobTagsStr);
            Assert.AreEqual(header.DstBlobData.BlobTagsLength, blobTagsStr.Length);
            Assert.AreEqual(header.DstBlobData.CpkInfo, _cpkInfo);
            Assert.AreEqual(header.DstBlobData.CpkInfoLength, _cpkInfo.Length);
            Assert.IsFalse(header.DstBlobData.IsSourceEncrypted);
            Assert.AreEqual(header.DstBlobData.CpkScopeInfo, _cpkScopeInfo);
            Assert.AreEqual(header.DstBlobData.CpkScopeInfoLength, _cpkScopeInfo.Length);
            Assert.AreEqual(header.DstBlobData.BlockSize, _blockSize);
            Assert.IsFalse(header.DstLocalData.PreserveLastModifiedTime);
            Assert.AreEqual(header.DstLocalData.MD5VerificationOption, _md5VerificationOption);
            Assert.IsFalse(header.PreserveSMBPermissions);
            Assert.IsFalse(header.PreserveSMBInfo);
            Assert.IsFalse(header.S2SGetPropertiesInBackend);
            Assert.IsFalse(header.S2SSourceChangeValidation);
            Assert.IsFalse(header.DestLengthValidation);
            Assert.AreEqual(header.S2SInvalidMetadataHandleOption, _s2sInvalidMetadataHandleOption);
            Assert.AreEqual(header.DeleteSnapshotsOption, _jobPartDeleteSnapshotsOption);
            Assert.AreEqual(header.PermanentDeleteOption, _jobPartPermanentDeleteOption);
            Assert.AreEqual(header.RehydratePriorityType, _jobPartPlanRehydratePriorityType);
            Assert.AreEqual(header.AtomicJobStatus, _atomicJobStatus);
            Assert.AreEqual(header.AtomicPartStatus, _atomicPartStatus);
        }

        [Test]
        public void Serialize()
        {
            // Arrange
            IDictionary<string, string> metadata = BuildMetadata();
            IDictionary<string, string> blobTags = BuildTags();

            JobPartPlanHeader header = CreateDefaultHeader(
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
                Assert.AreEqual(_startTime.Ticks.ToByteArray(startTimeSize), startTimeBuffer);

                int transferIdSize = DataMovementConstants.PlanFile.TransferIdStrMaxSize;
                byte[] transferIdBuffer = new byte[transferIdSize];
                stream.ReadAsync(transferIdBuffer, 0, transferIdSize);
                Assert.AreEqual(_transferId.ToByteArray(transferIdSize), transferIdBuffer);

                int partNumberSize = DataMovementConstants.PlanFile.LongSizeInBytes;
                byte[] partNumberBuffer = new byte[partNumberSize];
                stream.ReadAsync(partNumberBuffer, 0, partNumberSize);
                Assert.AreEqual(_partNumber.ToByteArray(partNumberSize), partNumberBuffer);

                int sourcePathLengthSize = DataMovementConstants.PlanFile.LongSizeInBytes;
                byte[] sourcePathLengthBuffer = new byte[sourcePathLengthSize];
                stream.ReadAsync(sourcePathLengthBuffer, 0, sourcePathLengthSize);
                Assert.AreEqual(((long)_sourcePath.Length).ToByteArray(sourcePathLengthSize), sourcePathLengthBuffer);

                int sourcePathSize = DataMovementConstants.PlanFile.PathStrMaxSize;
                byte[] sourcePathBuffer = new byte[sourcePathSize];
                stream.ReadAsync(sourcePathBuffer, 0, sourcePathSize);
                Assert.AreEqual(_sourcePath.ToByteArray(sourcePathSize), sourcePathBuffer);

                int sourceExtraQueryLengthSize = DataMovementConstants.PlanFile.LongSizeInBytes;
                byte[] sourceExtraQueryLengthBuffer = new byte[sourceExtraQueryLengthSize];
                stream.ReadAsync(sourceExtraQueryLengthBuffer, 0, sourceExtraQueryLengthSize);
                Assert.AreEqual(((long)_sourceQuery.Length).ToByteArray(sourceExtraQueryLengthSize), sourceExtraQueryLengthBuffer);

                int sourceExtraQuerySize = DataMovementConstants.PlanFile.ExtraQueryMaxSize;
                byte[] sourceExtraQueryBuffer = new byte[sourceExtraQuerySize];
                stream.ReadAsync(sourceExtraQueryBuffer, 0, sourceExtraQuerySize);
                Assert.AreEqual(_sourceQuery.ToByteArray(sourceExtraQuerySize), sourceExtraQueryBuffer);

                int destinationPathLengthSize = DataMovementConstants.PlanFile.LongSizeInBytes;
                byte[] destinationPathLengthBuffer = new byte[destinationPathLengthSize];
                stream.ReadAsync(destinationPathLengthBuffer, 0, destinationPathLengthSize);
                Assert.AreEqual(((long)_destinationPath.Length).ToByteArray(destinationPathLengthSize), destinationPathLengthBuffer);

                int destinationPathSize = DataMovementConstants.PlanFile.PathStrMaxSize;
                byte[] destinationPathBuffer = new byte[destinationPathSize];
                stream.ReadAsync(destinationPathBuffer, 0, destinationPathSize);
                Assert.AreEqual(_destinationPath.ToByteArray(destinationPathSize), destinationPathBuffer);

                int destinationExtraQueryLengthSize = DataMovementConstants.PlanFile.LongSizeInBytes;
                byte[] destinationExtraQueryLengthBuffer = new byte[destinationExtraQueryLengthSize];
                stream.ReadAsync(destinationExtraQueryLengthBuffer, 0, destinationExtraQueryLengthSize);
                Assert.AreEqual(((long)_destinationQuery.Length).ToByteArray(destinationExtraQueryLengthSize), destinationExtraQueryLengthBuffer);

                int destinationExtraQuerySize = DataMovementConstants.PlanFile.ExtraQueryMaxSize;
                byte[] destinationExtraQueryBuffer = new byte[destinationExtraQuerySize];
                stream.ReadAsync(destinationExtraQueryBuffer, 0, destinationExtraQuerySize);
                Assert.AreEqual(_destinationQuery.ToByteArray(destinationExtraQuerySize), destinationExtraQueryBuffer);

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
                Assert.AreEqual(_ttlAfterCompletion.Ticks.ToByteArray(ttlAfterCompletionSize), ttlAfterCompletionBuffer);

                byte[] fromToBuffer = new byte[oneByte];
                stream.ReadAsync(fromToBuffer, 0, oneByte);
                Assert.AreEqual((byte)_fromTo, fromToBuffer[0]);

                byte[] folderPropertyModeBuffer = new byte[oneByte];
                stream.ReadAsync(folderPropertyModeBuffer, 0, oneByte);
                Assert.AreEqual((byte)_folderPropertiesMode, folderPropertyModeBuffer[0]);

                int numberChunksSize = DataMovementConstants.PlanFile.LongSizeInBytes;
                byte[] numberChunksBuffer = new byte[numberChunksSize];
                stream.ReadAsync(numberChunksBuffer, 0, numberChunksSize);
                Assert.AreEqual(_numberChunks.ToByteArray(numberChunksSize), numberChunksBuffer);

                byte[] blobTypeBuffer = new byte[oneByte];
                stream.ReadAsync(blobTypeBuffer, 0, oneByte);
                Assert.AreEqual((byte)_blobType, blobTypeBuffer[0]);

                byte[] noGuessMimeTypeBuffer = new byte[oneByte];
                stream.ReadAsync(noGuessMimeTypeBuffer, 0, oneByte);
                Assert.AreEqual(0, noGuessMimeTypeBuffer[0]);

                int contentTypeLengthSize = DataMovementConstants.PlanFile.LongSizeInBytes;
                byte[] contentTypeLengthBuffer = new byte[contentTypeLengthSize];
                stream.ReadAsync(contentTypeLengthBuffer, 0, contentTypeLengthSize);
                Assert.AreEqual(((long)_contentType.Length).ToByteArray(contentTypeLengthSize), contentTypeLengthBuffer);

                int contentTypeSize = DataMovementConstants.PlanFile.HeaderValueMaxSize;
                byte[] contentTypeBuffer = new byte[contentTypeSize];
                stream.ReadAsync(contentTypeBuffer, 0, contentTypeSize);
                Assert.AreEqual(_contentType.ToByteArray(contentTypeSize), contentTypeBuffer);

                int contentEncodingLengthSize = DataMovementConstants.PlanFile.LongSizeInBytes;
                byte[] contentEncodingLengthBuffer = new byte[contentEncodingLengthSize];
                stream.ReadAsync(contentEncodingLengthBuffer, 0, contentEncodingLengthSize);
                Assert.AreEqual(((long)_contentEncoding.Length).ToByteArray(contentEncodingLengthSize), contentEncodingLengthBuffer);

                int contentEncodingSize = DataMovementConstants.PlanFile.HeaderValueMaxSize;
                byte[] contentEncodingBuffer = new byte[contentEncodingSize];
                stream.ReadAsync(contentEncodingBuffer, 0, contentEncodingSize);
                Assert.AreEqual(_contentEncoding.ToByteArray(contentEncodingSize), contentEncodingBuffer);

                int contentLanguageLengthSize = DataMovementConstants.PlanFile.LongSizeInBytes;
                byte[] contentLanguageLengthBuffer = new byte[contentLanguageLengthSize];
                stream.ReadAsync(contentLanguageLengthBuffer, 0, contentLanguageLengthSize);
                Assert.AreEqual(((long)_contentLanguage.Length).ToByteArray(contentLanguageLengthSize), contentLanguageLengthBuffer);

                int contentLanguageSize = DataMovementConstants.PlanFile.HeaderValueMaxSize;
                byte[] contentLanguageBuffer = new byte[contentLanguageSize];
                stream.ReadAsync(contentLanguageBuffer, 0, contentLanguageSize);
                Assert.AreEqual(_contentLanguage.ToByteArray(contentLanguageSize), contentLanguageBuffer);

                int contentDispositionLengthSize = DataMovementConstants.PlanFile.LongSizeInBytes;
                byte[] contentDispositionLengthBuffer = new byte[contentDispositionLengthSize];
                stream.ReadAsync(contentDispositionLengthBuffer, 0, contentDispositionLengthSize);
                Assert.AreEqual(((long)_contentDisposition.Length).ToByteArray(contentDispositionLengthSize), contentDispositionLengthBuffer);

                int contentDispositionSize = DataMovementConstants.PlanFile.HeaderValueMaxSize;
                byte[] contentDispositionBuffer = new byte[contentDispositionSize];
                stream.ReadAsync(contentDispositionBuffer, 0, contentDispositionSize);
                Assert.AreEqual(_contentDisposition.ToByteArray(contentDispositionSize), contentDispositionBuffer);

                int cacheControlLengthSize = DataMovementConstants.PlanFile.LongSizeInBytes;
                byte[] cacheControlLengthBuffer = new byte[cacheControlLengthSize];
                stream.ReadAsync(cacheControlLengthBuffer, 0, cacheControlLengthSize);
                Assert.AreEqual(((long)_cacheControl.Length).ToByteArray(cacheControlLengthSize), cacheControlLengthBuffer);

                int cacheControlSize = DataMovementConstants.PlanFile.HeaderValueMaxSize;
                byte[] cacheControlBuffer = new byte[cacheControlSize];
                stream.ReadAsync(cacheControlBuffer, 0, cacheControlSize);
                Assert.AreEqual(_cacheControl.ToByteArray(cacheControlSize), cacheControlBuffer);

                byte[] blockBlobTierBuffer = new byte[oneByte];
                stream.ReadAsync(blockBlobTierBuffer, 0, oneByte);
                Assert.AreEqual((byte)_blockBlobTier, blockBlobTierBuffer[0]);

                byte[] pageBlobTierBuffer = new byte[oneByte];
                stream.ReadAsync(pageBlobTierBuffer, 0, oneByte);
                Assert.AreEqual((byte)_pageBlobTier, pageBlobTierBuffer[0]);

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
                Assert.AreEqual(((long)_cpkInfo.Length).ToByteArray(cpkInfoLengthSize), cpkInfoLengthBuffer);

                int cpkInfoSize = DataMovementConstants.PlanFile.HeaderValueMaxSize;
                byte[] cpkInfoBuffer = new byte[cpkInfoSize];
                stream.ReadAsync(cpkInfoBuffer, 0, cpkInfoSize);
                Assert.AreEqual(_cpkInfo.ToByteArray(cpkInfoSize), cpkInfoBuffer);

                byte[] isSourceEncryptedBuffer = new byte[oneByte];
                stream.ReadAsync(isSourceEncryptedBuffer, 0, oneByte);
                Assert.AreEqual(0, isSourceEncryptedBuffer[0]);

                int cpkScopeInfoLengthSize = DataMovementConstants.PlanFile.LongSizeInBytes;
                byte[] cpkScopeInfoLengthBuffer = new byte[cpkScopeInfoLengthSize];
                stream.ReadAsync(cpkScopeInfoLengthBuffer, 0, cpkScopeInfoLengthSize);
                Assert.AreEqual(((long)_cpkScopeInfo.Length).ToByteArray(cpkScopeInfoLengthSize), cpkScopeInfoLengthBuffer);

                int cpkScopeInfoSize = DataMovementConstants.PlanFile.HeaderValueMaxSize;
                byte[] cpkScopeInfoBuffer = new byte[cpkScopeInfoSize];
                stream.ReadAsync(cpkScopeInfoBuffer, 0, cpkScopeInfoSize);
                Assert.AreEqual(_cpkScopeInfo.ToByteArray(cpkScopeInfoSize), cpkScopeInfoBuffer);

                int blockSizeLengthSize = DataMovementConstants.PlanFile.LongSizeInBytes;
                byte[] blockSizeLengthBuffer = new byte[blockSizeLengthSize];
                stream.ReadAsync(blockSizeLengthBuffer, 0, blockSizeLengthSize);
                Assert.AreEqual(_blockSize.ToByteArray(blockSizeLengthSize), blockSizeLengthBuffer);

                byte[] preserveLastModifiedTimeBuffer = new byte[oneByte];
                stream.ReadAsync(preserveLastModifiedTimeBuffer, 0, oneByte);
                Assert.AreEqual(0, preserveLastModifiedTimeBuffer[0]);

                byte[] md5VerificationOptionBuffer = new byte[oneByte];
                stream.ReadAsync(md5VerificationOptionBuffer, 0, oneByte);
                Assert.AreEqual(_md5VerificationOption, md5VerificationOptionBuffer[0]);

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
                Assert.AreEqual(_s2sInvalidMetadataHandleOption, s2sInvalidMetadataHandleOptionBuffer[0]);

                byte[] deleteSnapshotsOptionBuffer = new byte[oneByte];
                stream.ReadAsync(deleteSnapshotsOptionBuffer, 0, oneByte);
                Assert.AreEqual((byte)_jobPartDeleteSnapshotsOption, deleteSnapshotsOptionBuffer[0]);

                byte[] permanentDeleteOptionBuffer = new byte[oneByte];
                stream.ReadAsync(permanentDeleteOptionBuffer, 0, oneByte);
                Assert.AreEqual((byte)_jobPartPermanentDeleteOption, permanentDeleteOptionBuffer[0]);

                byte[] rehydratePriorityTypeBuffer = new byte[oneByte];
                stream.ReadAsync(rehydratePriorityTypeBuffer, 0, oneByte);
                Assert.AreEqual((byte)_jobPartPlanRehydratePriorityType, rehydratePriorityTypeBuffer[0]);

                byte[] atomicJobStatusBuffer = new byte[oneByte];
                stream.ReadAsync(atomicJobStatusBuffer, 0, oneByte);
                Assert.AreEqual((byte)_atomicJobStatus, atomicJobStatusBuffer[0]);

                byte[] atomicPartStatusBuffer = new byte[oneByte];
                stream.ReadAsync(atomicPartStatusBuffer, 0, oneByte);
                Assert.AreEqual((byte)_atomicPartStatus, atomicPartStatusBuffer[0]);
            }
        }

        [Test]
        public void Serialize_Error()
        {
            // Arrange
            JobPartPlanHeader header = CreateDefaultHeader();

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

            JobPartPlanHeader header = CreateDefaultHeader(
                metadata: metadata,
                blobTags: blobTags);

            using (Stream stream = new MemoryStream(DataMovementConstants.PlanFile.JobPartHeaderSizeInBytes))
            {
                header.Serialize(stream);

                // Act
                JobPartPlanHeader deserializedHeader = JobPartPlanHeader.Deserialize(stream);

                // Assert
                Assert.AreEqual(deserializedHeader.Version, DataMovementConstants.PlanFile.SchemaVersion);
                Assert.AreEqual(deserializedHeader.StartTime, _startTime);
                Assert.AreEqual(deserializedHeader.TransferId, _transferId);
                Assert.AreEqual(deserializedHeader.PartNumber, _partNumber);
                Assert.AreEqual(deserializedHeader.SourcePath, _sourcePath);
                Assert.AreEqual(deserializedHeader.SourcePathLength, _sourcePath.Length);
                Assert.AreEqual(deserializedHeader.SourceExtraQuery, _sourceQuery);
                Assert.AreEqual(deserializedHeader.SourceExtraQueryLength, _sourceQuery.Length);
                Assert.AreEqual(deserializedHeader.DestinationPath, _destinationPath);
                Assert.AreEqual(deserializedHeader.DestinationPathLength, _destinationPath.Length);
                Assert.AreEqual(deserializedHeader.DestinationExtraQuery, _destinationQuery);
                Assert.AreEqual(deserializedHeader.DestinationExtraQueryLength, _destinationQuery.Length);
                Assert.IsFalse(deserializedHeader.IsFinalPart);
                Assert.IsFalse(deserializedHeader.ForceWrite);
                Assert.IsFalse(deserializedHeader.ForceIfReadOnly);
                Assert.IsFalse(deserializedHeader.AutoDecompress);
                Assert.AreEqual(deserializedHeader.Priority, _priority);
                Assert.AreEqual(deserializedHeader.TTLAfterCompletion, _ttlAfterCompletion);
                Assert.AreEqual(deserializedHeader.FromTo, _fromTo);
                Assert.AreEqual(deserializedHeader.FolderPropertyMode, _folderPropertiesMode);
                Assert.AreEqual(deserializedHeader.NumberChunks, _numberChunks);
                Assert.AreEqual(deserializedHeader.DstBlobData.BlobType, _blobType);
                Assert.IsFalse(deserializedHeader.DstBlobData.NoGuessMimeType);
                Assert.AreEqual(deserializedHeader.DstBlobData.ContentType, _contentType);
                Assert.AreEqual(deserializedHeader.DstBlobData.ContentTypeLength, _contentType.Length);
                Assert.AreEqual(deserializedHeader.DstBlobData.ContentEncoding, _contentEncoding);
                Assert.AreEqual(deserializedHeader.DstBlobData.ContentEncodingLength, _contentEncoding.Length);
                Assert.AreEqual(deserializedHeader.DstBlobData.ContentLanguage, _contentLanguage);
                Assert.AreEqual(deserializedHeader.DstBlobData.ContentLanguageLength, _contentLanguage.Length);
                Assert.AreEqual(deserializedHeader.DstBlobData.ContentDisposition, _contentDisposition);
                Assert.AreEqual(deserializedHeader.DstBlobData.ContentDispositionLength, _contentDisposition.Length);
                Assert.AreEqual(deserializedHeader.DstBlobData.CacheControl, _cacheControl);
                Assert.AreEqual(deserializedHeader.DstBlobData.CacheControlLength, _cacheControl.Length);
                Assert.AreEqual(deserializedHeader.DstBlobData.BlockBlobTier, _blockBlobTier);
                Assert.AreEqual(deserializedHeader.DstBlobData.PageBlobTier, _pageBlobTier);
                Assert.IsFalse(deserializedHeader.DstBlobData.PutMd5);
                string metadataStr = DictionaryToString(metadata);
                Assert.AreEqual(deserializedHeader.DstBlobData.Metadata, metadataStr);
                Assert.AreEqual(deserializedHeader.DstBlobData.MetadataLength, metadataStr.Length);
                string blobTagsStr = DictionaryToString(blobTags);
                Assert.AreEqual(deserializedHeader.DstBlobData.BlobTags, blobTagsStr);
                Assert.AreEqual(deserializedHeader.DstBlobData.BlobTagsLength, blobTagsStr.Length);
                Assert.AreEqual(deserializedHeader.DstBlobData.CpkInfo, _cpkInfo);
                Assert.AreEqual(deserializedHeader.DstBlobData.CpkInfoLength, _cpkInfo.Length);
                Assert.IsFalse(deserializedHeader.DstBlobData.IsSourceEncrypted);
                Assert.AreEqual(deserializedHeader.DstBlobData.CpkScopeInfo, _cpkScopeInfo);
                Assert.AreEqual(deserializedHeader.DstBlobData.CpkScopeInfoLength, _cpkScopeInfo.Length);
                Assert.AreEqual(deserializedHeader.DstBlobData.BlockSize, _blockSize);
                Assert.IsFalse(deserializedHeader.DstLocalData.PreserveLastModifiedTime);
                Assert.AreEqual(deserializedHeader.DstLocalData.MD5VerificationOption, _md5VerificationOption);
                Assert.IsFalse(deserializedHeader.PreserveSMBPermissions);
                Assert.IsFalse(deserializedHeader.PreserveSMBInfo);
                Assert.IsFalse(deserializedHeader.S2SGetPropertiesInBackend);
                Assert.IsFalse(deserializedHeader.S2SSourceChangeValidation);
                Assert.IsFalse(deserializedHeader.DestLengthValidation);
                Assert.AreEqual(deserializedHeader.S2SInvalidMetadataHandleOption, _s2sInvalidMetadataHandleOption);
                Assert.AreEqual(deserializedHeader.DeleteSnapshotsOption, _jobPartDeleteSnapshotsOption);
                Assert.AreEqual(deserializedHeader.PermanentDeleteOption, _jobPartPermanentDeleteOption);
                Assert.AreEqual(deserializedHeader.RehydratePriorityType, _jobPartPlanRehydratePriorityType);
                Assert.AreEqual(deserializedHeader.AtomicJobStatus, _atomicJobStatus);
                Assert.AreEqual(deserializedHeader.AtomicPartStatus, _atomicPartStatus);
            }
        }

        [Test]
        public void Deserialize_Error()
        {
            // Arrange
            JobPartPlanHeader header = CreateDefaultHeader();

            // Act / Assert
            using (MemoryStream stream = new MemoryStream())
            {
                Assert.Catch(
                    () => JobPartPlanHeader.Deserialize(stream));
            }
        }
    }
}
