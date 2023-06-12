﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
            => new ArgumentException($"Cannot perform transfer because neither source and destination resource cannot produce a Uri. " +
                $"Either the source or destination resource, or both resources needs to produce a Uri.");

        public static ArgumentException InvalidTransferId(string command, string transferId)
            => new ArgumentException($"Cannot process {command} for transfer id: \"{transferId}\". Because " +
                $"the respective transfer job does not exist or is no longer stored in the transfer manager.");

        public static ArgumentException PlanFilesMissing(string path, string transferId)
            => new ArgumentException($"Cannot resume transfer job, \"{transferId}\", because the job plan file(s) cannot be found at the checkpointer path: \"{path}\"");

        public static ArgumentException UnableToGetLength()
            => new ArgumentException("Unable to get the length of the source storage resource");

        public static ArgumentException MismatchSchemaVersionHeader(string schemaVersion)
            => throw new ArgumentException($"Mismatch Schema Version: Schema Version of the Job Plan file does not match the Schema Version supported by " +
                    $"the SDK: {DataMovementConstants.PlanFile.SchemaVersion}. Please update to the Azure.Storage.DataMovement version which supports this Job Plan file Version Schema: {schemaVersion}.");

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

        public static ArgumentException MismatchIdSingleContainer(string transferId)
            => throw new ArgumentException($"Cannot Resume Error: Transfer Id, {transferId} is being attempted as a single transfer when it's a container transfer.");

        public static ArgumentException CollisionJobPart(string transferId, int jobPart)
            => throw new ArgumentException($"Job Part Collision Checkpointer: The job part {jobPart} for transfer id {transferId}, already exists in the checkpointer.");

        public static ArgumentException MissingCheckpointerPath(string directoryPath)
            => throw new ArgumentException($"Could not initialize the LocalTransferCheckpointer because the folderPath passed does not exist. Please create the {directoryPath}, folder path first.");

        public static ArgumentException InvalidTransferIdFileName(string fileName)
            => new ArgumentException($"Invalid Job Part Plan File: The following Job Part Plan file contains a Transfer ID that is either too long or short: {fileName}");

        public static ArgumentException InvalidJobPartFileName(string fileName)
            => new ArgumentException($"Invalid Job Part Plan File: The following Job Part Plan file contains an invalid Job Part Number: {fileName}");

        public static ArgumentException InvalidJobPartNumberFileName(string fileName)
            => new ArgumentException($"Invalid Job Part Plan File: The following Job Part Plan file contains an invalid Job Part Number, could not convert to a integer: {fileName}");

        public static ArgumentException InvalidSchemaVersionFileName(string schemaVersion)
            => new ArgumentException($"Invalid Job Part Plan File: Job Part Schema version: {schemaVersion} does not match the Schema Version supported by the package: {DataMovementConstants.PlanFile.SchemaVersion}. Please consider altering the package version that supports the respective version.");

        public static ArgumentException InvalidPlanFileElement(string elementName, int expectedSize, int actualSize)
            => throw new ArgumentException($"Invalid Job Part Plan File: Attempt to set element, \"{elementName}\" failed.\n Expected size: {expectedSize}\n Actual Size: {actualSize}");

        public static ArgumentException InvalidStringToDictionary(string elementName, string value)
            => throw new ArgumentException($"Invalid Job Part Plan File: Attempt to set element, \"{elementName}\" failed.\n Expected format stored was invalid, \"{value}\"");

        public static IOException LocalFileAlreadyExists(string pathName)
            => new IOException($"File path `{pathName}` already exists. Cannot overwrite file.");

        public static ArgumentException MismatchResumeTransferArguments(string elementName, string checkpointerValue, string passedValue)
            => new ArgumentException($"Mismatch Value to Resume Job: The following parameter, {elementName}, does not match the stored value in the transfer checkpointer. Please ensure the value passed to resume the transfer matches the value used when the transfer was started.\n" +
                $"Checkpointer Value: {checkpointerValue}\n" +
                $"New Value: {passedValue}");

        public static ArgumentException MismatchResumeCreateMode(bool checkpointerValue, StorageResourceCreateMode passedValue)
            => new ArgumentException($"Mismatch Value to Resume Job: The value to overwrite / create files when they exist does not match the stored value in the transfer checkpointer. Please ensure the value passed to resume the transfer matches the value in order to prevent overwriting or failing files.\n" +
                $"Checkpointer Value to overwrite was set to {checkpointerValue.ToString()}.\n" +
                $"The value passed in was {passedValue.ToString()}");

        public static InvalidOperationException SingleDownloadLengthMismatch(long expectedLength, long actualLength)
            => new InvalidOperationException($"Download length {actualLength} did not match expected length {expectedLength}.");
    }
}
