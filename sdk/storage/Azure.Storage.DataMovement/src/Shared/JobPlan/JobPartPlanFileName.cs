﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.IO;
using Azure.Core;

namespace Azure.Storage.DataMovement.Models.JobPlan
{
    /// <summary>
    /// Saved Job Part Plan File
    ///
    /// Format of the job part plan file name
    /// {transferid}--{jobpartNumber}.steV{schemaVersion}
    /// e.g. will look like
    /// 204b6e20-e642-fb40-4597-4a35ff5e199f--00001.steV17
    /// where the following information would be
    /// transfer id: 204b6e20-e642-fb40-4597-4a35ff5e199f
    /// job part number: 00001
    /// version schema: 17
    /// </summary>
    internal class JobPartPlanFileName
    {
        /// <summary>
        /// Prefix path
        /// </summary>
        public string PrefixPath { get; }

        /// <summary>
        /// Transfer Id representing the respective transfer.
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Job Part Number representing the respective job part.
        ///
        /// We don't predict this number going over 50,000 since the number of blocks
        /// limited to a blob is 50,000.
        /// </summary>
        public int JobPartNumber { get; }

        /// <summary>
        /// Schema version of the job part plan file. As the schema can change we have
        /// to keep track the version number.
        /// </summary>
        public string SchemaVersion { get; }

        /// <summary>
        /// Full path of the file.
        /// </summary>
        public string FullPath { get; }

        protected JobPartPlanFileName()
        {
        }

        /// <summary>
        /// Creates Job Part Plan File Name
        /// </summary>
        /// <param name="checkpointerPath">Path to where all checkpointer files are stored.</param>
        /// <param name="id"></param>
        /// <param name="jobPartNumber"></param>
        /// <param name="schemaVersion"></param>
        public JobPartPlanFileName(
            string checkpointerPath,
            string id,
            int jobPartNumber,
            string schemaVersion = DataMovementConstants.PlanFile.SchemaVersion)
        {
            Argument.AssertNotNullOrEmpty(checkpointerPath, nameof(checkpointerPath));
            Argument.AssertNotNullOrEmpty(id, nameof(id));
            Argument.AssertNotNull(jobPartNumber, nameof(jobPartNumber));
            PrefixPath = checkpointerPath;
            Id = id;
            JobPartNumber = jobPartNumber;
            SchemaVersion = schemaVersion;

            string fileName = $"{Id}--{JobPartNumber.ToString("D5", NumberFormatInfo.CurrentInfo)}{DataMovementConstants.PlanFile.FileExtension}{SchemaVersion}";
            FullPath = Path.Combine(PrefixPath, fileName);
        }

        public JobPartPlanFileName(string fullPath)
        {
            // Check if empty
            Argument.CheckNotNullOrEmpty(fullPath, nameof(fullPath));

            PrefixPath = Path.GetDirectoryName(fullPath);
            if (!Path.HasExtension(fullPath))
            {
                throw Errors.InvalidTransferIdFileName(fullPath);
            }
            string fileName = Path.GetFileNameWithoutExtension(fullPath);
            string extension = Path.GetExtension(fullPath);

            // Format of the job plan file name
            // {transferid}--{jobpartNumber}.steV{schemaVersion}

            // Check for valid Transfer Id
            int endTransferIdIndex = fileName.IndexOf(DataMovementConstants.PlanFile.JobPlanFileNameDelimiter, StringComparison.InvariantCultureIgnoreCase);
            if (endTransferIdIndex != DataMovementConstants.PlanFile.IdSize)
            {
                throw Errors.InvalidTransferIdFileName(fullPath);
            }
            Id = fileName.Substring(0, endTransferIdIndex);

            // Check for valid transfer part number
            int partStartIndex = endTransferIdIndex + DataMovementConstants.PlanFile.JobPlanFileNameDelimiter.Length;
            int endPartIndex = fileName.Length;

            if (endPartIndex - partStartIndex != DataMovementConstants.PlanFile.JobPartLength)
            {
                throw Errors.InvalidJobPartFileName(fullPath);
            }
            if (!int.TryParse(
                    fileName.Substring(partStartIndex, DataMovementConstants.PlanFile.JobPartLength),
                    NumberStyles.Number,
                    CultureInfo.InvariantCulture,
                    out int jobPartNumber))
            {
                throw Errors.InvalidJobPartNumberFileName(fullPath);
            }
            JobPartNumber = jobPartNumber;

            string fullExtension = string.Concat(DataMovementConstants.PlanFile.FileExtension, DataMovementConstants.PlanFile.SchemaVersion);
            if (!fullExtension.Equals(extension))
            {
                throw Errors.InvalidSchemaVersionFileName(extension);
            }
            SchemaVersion = DataMovementConstants.PlanFile.SchemaVersion;

            FullPath = fullPath;
        }

        /// <summary>
        /// Converts struct to the full file path
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return FullPath;
        }

        internal static bool TryParseJobPartPlanFileName(
            string path,
            out JobPartPlanFileName fileName)
        {
            try
            {
                fileName = new JobPartPlanFileName(path);
            }
            catch
            {
                // Was not a valid job part plan file name
                fileName = default;
                return false;
            }
            return true;
        }
    }
}
