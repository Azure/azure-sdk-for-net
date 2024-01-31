// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using Azure.Storage.DataMovement;

namespace Azure.Storage
{
    /// <summary>
    /// Exceptions throw specific to the Data Movement Library
    /// </summary>
    internal partial class Errors
    {
        public static ArgumentException InvalidSourceDestinationParams()
            => new ArgumentException($"Cannot perform transfer because neither source nor destination resource are web resources. " +
                $"Either the source or destination resource, or both resources needs to be a web resource.");

        public static ArgumentException InvalidTransferId(string command, string transferId)
            => new ArgumentException($"Cannot process {command} for transfer id: \"{transferId}\". Because " +
                $"the respective transfer job does not exist or is no longer stored in the transfer manager.");

        public static ArgumentException PlanFilesMissing(string path, string transferId)
            => new ArgumentException($"Cannot resume transfer job, \"{transferId}\", because the job plan file(s) cannot be found at the checkpointer path: \"{path}\"");

        public static ArgumentException UnableToGetLength()
            => new ArgumentException("Unable to get the length of the source storage resource");

        public static ArgumentException UnsupportedJobSchemaVersionHeader(string schemaVersion)
            => new ArgumentException($"The checkpoint file schema version {schemaVersion} is not supported by this version of the SDK.");

        public static ArgumentException UnsupportedJobPartSchemaVersionHeader(string schemaVersion)
            => new ArgumentException($"The checkpoint part file schema version {schemaVersion} is not supported by this version of the SDK.");

        public static ArgumentException MismatchTransferId(string passedTransferId, string storedTransferId)
            => throw new ArgumentException($"Mismatch Transfer Id: Transfer ID stored in the Job Plan file does not match the Transfer ID " +
                    $"passed to resume the transfer, and the job plan file name. Transfer ID passed: {passedTransferId}, Transfer ID stored in file: {storedTransferId}. ");

        public static ArgumentException CollisionTransferIdCheckpointer(string transferId)
            => throw new ArgumentException($"Transfer Id Collision Checkpointer: The transfer id, {transferId}, already exists in the checkpointer.");

        public static ArgumentException MissingTransferIdAddPartCheckpointer(string transferId, int partNumber)
            => throw new ArgumentException($"Missing Transfer Id Checkpointer: The transfer id, {transferId}, could not be found in the checkpointer when " +
                $"attempting to add a new job part, {partNumber}.");

        public static ArgumentException CannotReadMmfStream(string filePath)
            => throw new ArgumentException($"Unable to read Job Part Header from the job part plan file: {filePath}.");

        public static ArgumentException MissingPartNumberCheckpointer(string transferId, int partNumber)
            => throw new ArgumentException($"The transfer id, {transferId} and part number {partNumber} could not be found in the checkpointer.");

        public static ArgumentException MissingTransferIdCheckpointer(string transferId)
            => throw new ArgumentException($"The transfer id, {transferId}, could not be found in the checkpointer.");

        public static ArgumentException CollisionJobPart(string transferId, int jobPart)
            => throw new ArgumentException($"Job Part Collision Checkpointer: The job part {jobPart} for transfer id {transferId}, already exists in the checkpointer.");

        public static ArgumentException MissingCheckpointerPath(string directoryPath)
            => throw new ArgumentException($"Could not initialize the LocalTransferCheckpointer because the folderPath passed does not exist. Please create the {directoryPath}, folder path first.");

        public static ArgumentException InvalidJobPartFileName(string fileName)
            => new ArgumentException($"Invalid Checkpoint File: The following checkpoint file contains an invalid file name {fileName}");

        public static ArgumentException InvalidTransferIdFileName(string fileName)
            => new ArgumentException($"Invalid Checkpoint File: The following checkpoint file contains a Transfer ID that is invalid {fileName}");

        public static ArgumentException InvalidJobPartFileNameExtension(string fileName)
            => new ArgumentException($"Invalid Job Part Plan File: The following Job Part Plan file contains an invalid extension: {fileName}");

        public static ArgumentException InvalidJobPartNumberFileName(string fileName)
            => new ArgumentException($"Invalid Job Part Plan File: The following Job Part Plan file contains an invalid Job Part Number, could not convert to a integer: {fileName}");

        public static ArgumentException InvalidPartHeaderElementLength(string elementName, int expectedSize, int actualSize)
            => new ArgumentException($"Invalid Job Part Plan File: Attempt to set element, \"{elementName}\" failed.\n Expected size: {expectedSize}\n Actual Size: {actualSize}");

        public static ArgumentException InvalidPartHeaderElement(string elementName, string elementValue)
            => new ArgumentException($"Invalid Job Part Plan File: Attempt to set element, \"{elementName}\" with value \"{elementValue}\" failed.");

        public static ArgumentException InvalidStringToDictionary(string elementName, string value)
            => new ArgumentException($"Invalid Job Part Plan File: Attempt to set element, \"{elementName}\" failed.\n Expected format stored was invalid, \"{value}\"");

        public static IOException LocalFileAlreadyExists(string pathName)
            => new IOException($"File path `{pathName}` already exists. Cannot overwrite file.");

        public static ArgumentException MismatchResumeTransferArguments(string elementName, string checkpointerValue, string passedValue)
            => new ArgumentException($"Mismatch Value to Resume Job: The following parameter, {elementName}, does not match the stored value in the transfer checkpointer. Please ensure the value passed to resume the transfer matches the value used when the transfer was started.\n" +
                $"Checkpointer Value: {checkpointerValue}\n" +
                $"New Value: {passedValue}");

        public static InvalidOperationException SingleDownloadLengthMismatch(long expectedLength, long actualLength)
            => new InvalidOperationException($"Download length {actualLength} did not match expected length {expectedLength}.");

        public static ArgumentException InvalidDownloadOffset(long offset, long length)
            => new ArgumentException($"Cannot find offset returned by Successful Download Range in the expected Range.\n" +
                $"Offset: \"{offset}\"\n" +
                $"Length: \"{length}\"");

        public static ArgumentException InvalidExpectedLength(long length)
            => new ArgumentException($"Expected positive non-zero length, but was given: {length}");

        public static InvalidOperationException FailedDownloadRange(long offset, long bytesTransferred, string transferId)
            => new InvalidOperationException($"Unexpected error: Experienced failed download range argument. " +
                    $"Range: {offset} - {bytesTransferred} with Transfer ID: {transferId}");

        public static FileNotFoundException TempChunkFileNotFound(long offset, long length, string filePath)
            => new FileNotFoundException($"Could not append chunk to destination file at Offset: " +
                $"\"{offset}\" and Length: \"{length}\"," +
                $"due to the chunk file missing: \"{filePath}\"");

        public static InvalidOperationException MismatchLengthTransferred(long expectedLength, long actualLength)
            => new InvalidOperationException($"Amount of bytes transferred exceeds expected length\n" +
                $"Expected Bytes Transferred Length: {expectedLength}\n" +
                $"Actual Bytes Transferred Length: {actualLength}.");

        public static InvalidOperationException FailedChunkTransfer(long offset, long bytesTransferred)
            => new InvalidOperationException($"Unexpected error: Experienced failed chunk transfer argument. " +
                    $"Offset: \"{offset}\"\n" +
                    $"Length: \"{bytesTransferred}\"");

        public static InvalidOperationException InvalidTransferResourceTypes()
            => new InvalidOperationException("Invalid source and destination resource types.");

        public static ArgumentException ResourceUriInvalid(string parameterResource)
            => new ArgumentException($"Could not perform operation because {parameterResource} was expected to be not a Local Storage Resource.");

        public static ArgumentException NoResourceProviderFound(bool isSource, string providerId)
            => new ArgumentException($"Unable to find resource provider for transfer {(isSource ? "source" : "destination")} with provider id: {providerId}. " +
                $"Please ensure you have registered the required resource provider with TransferManagerOptions.ResumeProviders.");
    }
}
