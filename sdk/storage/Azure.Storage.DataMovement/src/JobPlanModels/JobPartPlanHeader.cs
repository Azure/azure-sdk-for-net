// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Runtime.InteropServices;
using System.Text.Json;
using Azure.Storage.DataMovement.JobPlanModels;
using Azure.Storage.DataMovement.Models;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Stores the Job Part Header information to resume from.
    ///
    /// This matching the JobPartPlanHeader of azcopy
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet=CharSet.Unicode, Pack=1)]
    internal class JobPartPlanHeader
    {
        internal const string currentVersion = "b1";
        private const string startTimeName = "startTime";
        private const string transferIdName = "transferIdName";
        private const string partNumberName = "partNumber";
        private const string sourceRootName = "sourceRoot";
        private const string sourceQueryName = "sourceQuery";
        private const string destinationRootName = "destinationRoot";
        private const string destinationQueryName = "destinationQuery";
        private const string isFinalPartName = "isFinalPart";
        private const string forceWriteName = "forceWrite";
        private const string forceIfReadOnlyName = "forceIfReadOnly";
        private const string autoDecompressName = "autoDecompress";
        private const string priorityName = "priority";
        private const string ttlAfterCompletionName = "ttlAfterCompletion";
        private const string fromToName = "fromTo";
        private const string folderPropertyOptionName = "folderPropertyOption";
        private const string numTransfersName = "numTransfers";
        private const string dstBlobDataName = "dstBlobData";
        private const string dstLocalDataName = "dstLocalData";
        private const string preserveSMBPermissionsName = "preserveSmbPermissions";
        private const string preserveSMBInfoName = "preserveSmbInfo";
        private const string s2sGetPropertiesInBackendName = "s2sGetPropertiesInBackend";
        private const string destLengthValidationName = "DestLengthValidation";
        private const string s2sInvalidMetadataHandleOptionName = "s2sInvalidMetadataHandleOption";
        private const string deleteSnapshotsOptionName = "deleteSnapshotsOption";
        private const string permanentDeleteOptionName = "permanentDeleteOption";
        private const string rehydratePriorityTypeName = "rehydratePriorityType";
        private const string atomicJobStatusName = "atomicJobStatus";
        private const string atomicPartStatusName = "atomicPartStatus";

        private static readonly JsonEncodedText s_startTimeNameBytes = JsonEncodedText.Encode(startTimeName);
        private static readonly JsonEncodedText s_transferIdNameBytes = JsonEncodedText.Encode(transferIdName);
        private static readonly JsonEncodedText s_partNumberNameBytes = JsonEncodedText.Encode(partNumberName);
        private static readonly JsonEncodedText s_sourceRootNameBytes = JsonEncodedText.Encode(sourceRootName);
        private static readonly JsonEncodedText s_sourceQueryNameBytes = JsonEncodedText.Encode(sourceQueryName);
        private static readonly JsonEncodedText s_destinationRootNameBytes = JsonEncodedText.Encode(destinationRootName);
        private static readonly JsonEncodedText s_destinationQueryNameBytes = JsonEncodedText.Encode(destinationQueryName);
        private static readonly JsonEncodedText s_isFinalPartNameBytes = JsonEncodedText.Encode(isFinalPartName);
        private static readonly JsonEncodedText s_forceWriteNameBytes = JsonEncodedText.Encode(forceWriteName);
        private static readonly JsonEncodedText s_forceIfReadOnlyNameBytes = JsonEncodedText.Encode(forceIfReadOnlyName);
        private static readonly JsonEncodedText s_autoDecompressNameBytes = JsonEncodedText.Encode(autoDecompressName);
        private static readonly JsonEncodedText s_priorityNameBytes = JsonEncodedText.Encode(priorityName);
        private static readonly JsonEncodedText s_ttlAfterCompletionNameBytes = JsonEncodedText.Encode(ttlAfterCompletionName);
        private static readonly JsonEncodedText s_fromToNameBytes = JsonEncodedText.Encode(fromToName);
        private static readonly JsonEncodedText s_folderPropertyOptionNameBytes = JsonEncodedText.Encode(folderPropertyOptionName);
        private static readonly JsonEncodedText s_numTransfersNameBytes = JsonEncodedText.Encode(numTransfersName);
        private static readonly JsonEncodedText s_dstBlobDataNameBytes = JsonEncodedText.Encode(dstBlobDataName);
        private static readonly JsonEncodedText s_dstLocalDataNameBytes = JsonEncodedText.Encode(dstLocalDataName);
        private static readonly JsonEncodedText s_preserveSMBPermissionsNameBytes = JsonEncodedText.Encode(preserveSMBPermissionsName);
        private static readonly JsonEncodedText s_preserveSMBInfoNameBytes = JsonEncodedText.Encode(preserveSMBInfoName);
        private static readonly JsonEncodedText s_s2sGetPropertiesInBackendNameBytes = JsonEncodedText.Encode(s2sGetPropertiesInBackendName);
        private static readonly JsonEncodedText s_destLengthValidationNameBytes = JsonEncodedText.Encode(destLengthValidationName);
        private static readonly JsonEncodedText s_s2sInvalidMetadataHandleOptionNameBytes = JsonEncodedText.Encode(s2sInvalidMetadataHandleOptionName);
        private static readonly JsonEncodedText s_deleteSnapshotsOptionNameBytes = JsonEncodedText.Encode(deleteSnapshotsOptionName);
        private static readonly JsonEncodedText s_permanentDeleteOptionNameBytes = JsonEncodedText.Encode(permanentDeleteOptionName);
        private static readonly JsonEncodedText s_rehydratePriorityTypeNameBytes = JsonEncodedText.Encode(rehydratePriorityTypeName);
        private static readonly JsonEncodedText s_atomicJobStatusNameBytes = JsonEncodedText.Encode(atomicJobStatusName);
        private static readonly JsonEncodedText s_atomicPartStatusNameBytes = JsonEncodedText.Encode(atomicPartStatusName);

        /// <summary>
        /// The version of data schema format of header
        /// This will seem weird because we will have a schema for how we store the data
        /// when the schema changes this verison will increment
        ///
        /// Set to a size of 3
        /// TODO: Consider changing to an int when GA comes. In public preview we should
        /// leave the version as "b1", instead of complete ints.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] Version;

        /// <summary>
        /// The start time of the job part.
        /// </summary>
        [MarshalAs(UnmanagedType.U8)]
        public long StartTime;

        /// <summary>
        /// The Transfer/Job Id
        ///
        /// Size of a GUID.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = DataMovementConstants.PlanFile.IdSize)]
        public string TransferId;

        /// <summary>
        /// Job Part's part number (0+)
        ///
        /// We don't expect there to be more than 50,000 job parts
        /// So reaching int.MAX is extremely unlikely
        /// </summary>
        [MarshalAs(UnmanagedType.U4)]
        public uint PartNum;

        /// <summary>
        /// The length of the source root path
        /// </summary>
        [MarshalAs(UnmanagedType.U2)]
        public ushort SourceRootLength;

        /// <summary>
        /// The root directory of the source
        ///
        /// Size of byte[] in azcopy is 1000 bytes.
        /// TODO: consider a different number, the max name of a blob cannot exceed 254
        /// however the max length of a path in linux is 4096.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1000)]
        public byte[] SourceRoot;

        /// <summary>
        /// Length of the extra source query params if the source is a URL.
        /// </summary>
        [MarshalAs(UnmanagedType.U2)]
	    public ushort SourceExtraQueryLength;

        /// <summary>
        /// Extra query params applicable to the source
        ///
        /// Size of byte array in azcopy is 1000 bytes.
        /// TODO: consider changing this to something like 2048 because the max a url could be
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1000)]
        public byte[] SourceExtraQuery;

        /// <summary>
        /// The length of the destination root path
        /// </summary>
        [MarshalAs(UnmanagedType.U2)]
	    public ushort DestinationRootLength;

        /// <summary>
        /// The root directory of the destination.
        ///
        /// Size of byte array in azcopy is 1000 bytes
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1000)]
        public byte[] DestinationRoot;

        /// <summary>
        /// Length of the extra destination query params if applicable.
        /// </summary>
        [MarshalAs(UnmanagedType.U2)]
	    public ushort DestExtraQueryLength;

        /// <summary>
        /// Extra query params applicable to the dest
        ///
        /// Size of byte array in azcopy is 1000 bytes
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1000)]
        public byte[] DestExtraQuery;

        /// <summary>
        /// True if this is the Job's last part; else false
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
	    public bool IsFinalPart;

        /// <summary>
        /// True if the existing blobs needs to be overwritten.
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        public bool ForceWrite;

        /// <summary>
        /// Supplements ForceWrite with an additional setting for Azure Files. If true, the read-only attribute will be cleared before we overwrite
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        public bool ForceIfReadOnly;

        /// <summary>
        /// if true, source data with encodings that represent compression are automatically decompressed when downloading
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        public bool AutoDecompress;

        /// <summary>
        /// The Job Part's priority
        /// </summary>
        [MarshalAs(UnmanagedType.U1)]
        public byte Priority;

        /// <summary>
        /// Time to live after completion is used to persists the file on disk of specified time after the completion of JobPartOrder
        ///
        /// TODO: change to DateTimeOffset object, and make convert from DateTimeOffset to UInt32
        /// </summary>
        [MarshalAs(UnmanagedType.U4)]
        public uint TTLAfterCompletion;

        /// <summary>
        /// The location of the transfer's source and destination
        ///
        /// TODO: change to object for storing transfer source and destination
        /// </summary>
        [MarshalAs(UnmanagedType.U4)]
        public JobPlanFromTo FromTo;

        /// <summary>
        /// option specifying how folders will be handled
        ///
        /// TODO: change to struct for FolderPropertyOptions
        /// </summary>
        [MarshalAs(UnmanagedType.U4)]
        public FolderPropertiesMode FolderPropertyOption;

        /// <summary>
        /// The number of transfers in the Job part
        /// </summary>
        [MarshalAs(UnmanagedType.U4)]
        public uint NumTransfers;

        /// <summary>
        /// This Job Part's minimal log level
        /// </summary>
        /// TODO: use core diagnostics log level instead
        ///public DataMovementLogLevel LogLevel;

        /// <summary>
        /// Additional data for blob destinations
        ///
        /// holds the additional information about the blob, see BlobProperties and request conditions
        /// </summary>
        public JobPartPlanDestinationBlob DstBlobData;

        /// <summary>
        /// Additional data for local destinations
        /// </summary>
        public JobPartPlanDestinationLocal DstLocalData;

        /// <summary>
        /// If applicable the SMB information
        /// </summary>
        [MarshalAs(UnmanagedType.U1)]
        public byte PreserveSMBPermissions;

        /// <summary>
        /// Whether to preserve SMB info
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        public bool PreserveSMBInfo;

        /// <summary>
        /// S2SGetPropertiesInBackend represents whether to enable get S3 objects' or Azure files' properties during s2s copy in backend.
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        public bool S2SGetPropertiesInBackend;

        /// <summary>
        /// S2SSourceChangeValidation represents whether user wants to check if source has changed after enumerating.
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        public bool S2SSourceChangeValidation;

        /// <summary>
        /// DestLengthValidation represents whether the user wants to check if the destination has a different content-length
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        public bool DestLengthValidation;

        /// <summary>
        /// S2SInvalidMetadataHandleOption represents how user wants to handle invalid metadata.
        ///
        /// TODO: update to a struc tto handle the S2S Invalid metadata handle option
        /// </summary>
        [MarshalAs(UnmanagedType.U1)]
        public byte S2SInvalidMetadataHandleOption;

        /// <summary>
        /// For delete operation specify what to do with snapshots
        /// </summary>
        [MarshalAs(UnmanagedType.U4)]
        public JobPartDeleteSnapshotsOption DeleteSnapshotsOption;

        /// <summary>
        /// Permanent Delete Option
        /// </summary>
        [MarshalAs(UnmanagedType.U4)]
        public JobPartPermanentDeleteOption PermanentDeleteOption;

        /// <summary>
        /// Rehydrate Priority type
        /// </summary>
        [MarshalAs(UnmanagedType.U4)]
        public JobPartPlanRehydratePriorityType RehydratePriorityType;

        // Any fields below this comment are NOT constants; they may change over as the job part is processed.
        // Care must be taken to read/write to these fields in a thread-safe way!

        // jobStatus_doNotUse represents the current status of JobPartPlan
        // jobStatus_doNotUse is a private member whose value can be accessed by Status and SetJobStatus
        // jobStatus_doNotUse should not be directly accessed anywhere except by the Status and SetJobStatus
        [MarshalAs(UnmanagedType.U4)]
        public uint atomicJobStatus;

        [MarshalAs(UnmanagedType.U4)]
        public uint atomicPartStatus;
    }
}
