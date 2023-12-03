// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.IO;
using Azure.Core;

namespace Azure.Storage.DataMovement.JobPlan
{
    /// <summary>
    /// Saved Job Part Plan File
    ///
    /// Format of the job part plan file name
    /// {transferid}.{jobpartNumber}.ndmpart
    /// e.g. will look like
    /// 204b6e20-e642-fb40-4597-4a35ff5e199f.00001.ndmpart
    /// where the following information would be
    /// transfer id: 204b6e20-e642-fb40-4597-4a35ff5e199f
    /// job part number: 00001
    /// </summary>
    internal class JobPartPlanFileName
    {
        /// <summary>
        /// Prefix path.
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
        /// <param name="id">The transfer id.</param>
        /// <param name="jobPartNumber">The job part number.</param>
        public JobPartPlanFileName(
            string checkpointerPath,
            string id,
            int jobPartNumber)
        {
            Argument.AssertNotNullOrEmpty(checkpointerPath, nameof(checkpointerPath));
            Argument.AssertNotNullOrEmpty(id, nameof(id));
            Argument.AssertNotNull(jobPartNumber, nameof(jobPartNumber));
            PrefixPath = checkpointerPath;
            Id = id;
            JobPartNumber = jobPartNumber;

            string fileName = $"{Id}.{JobPartNumber.ToString("D5", NumberFormatInfo.CurrentInfo)}{DataMovementConstants.JobPartPlanFile.FileExtension}";
            FullPath = Path.Combine(PrefixPath, fileName);
        }

        public JobPartPlanFileName(string fullPath)
        {
            // Check if empty
            Argument.CheckNotNullOrEmpty(fullPath, nameof(fullPath));

            PrefixPath = Path.GetDirectoryName(fullPath);
            if (!Path.HasExtension(fullPath) ||
                !Path.GetExtension(fullPath).Equals(DataMovementConstants.JobPartPlanFile.FileExtension))
            {
                throw Errors.InvalidJobPartFileNameExtension(fullPath);
            }
            string fileName = Path.GetFileNameWithoutExtension(fullPath);

            // Format of the job plan file name
            // {transferid}.{jobpartNumber}.ndmpart

            string[] fileNameSplit = fileName.Split('.');
            if (fileNameSplit.Length != 2)
            {
                throw Errors.InvalidJobPartFileName(fullPath);
            }

            // Check for valid Transfer Id
            if (fileNameSplit[0].Length != DataMovementConstants.JobPartPlanFile.IdSize)
            {
                throw Errors.InvalidTransferIdFileName(fullPath);
            }
            Id = fileNameSplit[0];

            // Check for valid transfer part number
            if (fileNameSplit[1].Length != DataMovementConstants.JobPartPlanFile.JobPartLength)
            {
                throw Errors.InvalidJobPartNumberFileName(fullPath);
            }
            if (!int.TryParse(fileNameSplit[1], NumberStyles.Number, CultureInfo.InvariantCulture, out int jobPartNumber))
            {
                throw Errors.InvalidJobPartNumberFileName(fullPath);
            }
            JobPartNumber = jobPartNumber;

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
