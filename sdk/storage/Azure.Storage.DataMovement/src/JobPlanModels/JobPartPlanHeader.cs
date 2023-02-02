// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Runtime.InteropServices;
using Azure.Storage.DataMovement.JobPlanModels;
using Azure.Storage.DataMovement.Models;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// This matching the JobPartPlanHeader of azcopy
    ///
    /// TODO: check if we want to set the pack and/or size for the struct layout
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet=CharSet.Unicode, Pack=1)]
    internal struct JobPartPlanHeader
    {
        /// <summary>
        /// The version of data schema format of header
        /// This will seem weird because we will have a schema for how we store the data
        /// when the schema changes this verison will increment
        ///
        /// Set to a size of 3
        /// TODO: Consider changing to an int when GA comes. In public preview we should
        /// leave the version as "b1", instead of complete ints.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
        public byte[] Version;

        /// <summary>
        /// The start time of the job part.
        /// </summary>
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
        public uint PartNum;

        /// <summary>
        /// The length of the source root path
        /// </summary>
        public ushort SourceRootLength;

        /// <summary>
        /// The root directory of the source
        ///
        /// Size of byte[] in azcopy is 1000 bytes.
        /// TODO: consider a different number, the max name of a blob cannot exceed 254
        /// however the max length of a path in linux is 4096.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1000)]
        public byte[] SourceRoot;

        /// <summary>
        /// Length of the extra source query params if the source is a URL.
        /// </summary>
	    public ushort SourceExtraQueryLength;

        /// <summary>
        /// Extra query params applicable to the source
        ///
        /// Size of byte array in azcopy is 1000 bytes.
        /// TODO: consider changing this to something like 2048 because the max a url could be
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1000)]
        public byte[] SourceExtraQuery;

        /// <summary>
        /// The length of the destination root path
        /// </summary>
	    public ushort DestinationRootLength;

        /// <summary>
        /// The root directory of the destination.
        ///
        /// Size of byte array in azcopy is 1000 bytes
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1000)]
        public byte[] DestinationRoot;

        /// <summary>
        /// Length of the extra destination query params if applicable.
        /// </summary>
	    public ushort DestExtraQueryLength;

        /// <summary>
        /// Extra query params applicable to the dest
        ///
        /// Size of byte array in azcopy is 1000 bytes
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1000)]
        public byte[] DestExtraQuery;

        /// <summary>
        /// True if this is the Job's last part; else false
        /// </summary>
	    public bool IsFinalPart;

        /// <summary>
        /// True if the existing blobs needs to be overwritten.
        /// </summary>
        public bool ForceWrite;

        /// <summary>
        /// Supplements ForceWrite with an additional setting for Azure Files. If true, the read-only attribute will be cleared before we overwrite
        /// </summary>
        public bool ForceIfReadOnly;

        /// <summary>
        /// if true, source data with encodings that represent compression are automatically decompressed when downloading
        /// </summary>
        public bool AutoDecompress;

        /// <summary>
        /// The Job Part's priority
        /// </summary>
        public byte Priority;

        /// <summary>
        /// Time to live after completion is used to persists the file on disk of specified time after the completion of JobPartOrder
        ///
        /// TODO: change to DateTimeOffset object, and make convert from DateTimeOffset to UInt32
        /// </summary>
        public uint TTLAfterCompletion;

        /// <summary>
        /// The location of the transfer's source and destination
        ///
        /// TODO: change to object for storing transfer source and destination
        /// </summary>
        public JobPlanFromTo FromTo;

        /// <summary>
        /// option specifying how folders will be handled
        ///
        /// TODO: change to struct for FolderPropertyOptions
        /// </summary>
        public FolderPropertiesMode FolderPropertyOption;

        /// <summary>
        /// The number of transfers in the Job part
        /// </summary>
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
        public byte PreserveSMBPermissions;

        /// <summary>
        /// Whether to preserve SMB info
        /// </summary>
        public bool PreserveSMBInfo;

        /// <summary>
        /// S2SGetPropertiesInBackend represents whether to enable get S3 objects' or Azure files' properties during s2s copy in backend.
        /// </summary>
        public bool S2SGetPropertiesInBackend;

        /// <summary>
        /// S2SSourceChangeValidation represents whether user wants to check if source has changed after enumerating.
        /// </summary>
        public bool S2SSourceChangeValidation;

        /// <summary>
        /// DestLengthValidation represents whether the user wants to check if the destination has a different content-length
        /// </summary>
        public bool DestLengthValidation;

        /// <summary>
        /// S2SInvalidMetadataHandleOption represents how user wants to handle invalid metadata.
        ///
        /// TODO: update to a struc tto handle the S2S Invalid metadata handle option
        /// </summary>
        public byte S2SInvalidMetadataHandleOption;

        /// <summary>
        /// For delete operation specify what to do with snapshots
        /// </summary>
        public JobPartDeleteSnapshotsOption DeleteSnapshotsOption;

        /// <summary>
        /// Permanent Delete Option
        /// </summary>
        public JobPartPermanentDeleteOption PermanentDeleteOption;

        /// <summary>
        /// Rehydrate Priority type
        /// </summary>
        public JobPartPlanRehydratePriorityType RehydratePriorityType;

        // Any fields below this comment are NOT constants; they may change over as the job part is processed.
        // Care must be taken to read/write to these fields in a thread-safe way!

        // jobStatus_doNotUse represents the current status of JobPartPlan
        // jobStatus_doNotUse is a private member whose value can be accessed by Status and SetJobStatus
        // jobStatus_doNotUse should not be directly accessed anywhere except by the Status and SetJobStatus
        public uint atomicJobStatus;

        public uint atomicPartStatus;
    }
}
