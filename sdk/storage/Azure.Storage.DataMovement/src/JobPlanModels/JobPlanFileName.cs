// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Saved Job Plan File
    ///
    /// Format of the job plan file name
    /// {transferid}--{jobpartNumber}.steV{schemaVersion}
    /// e.g. will look like
    /// 204b6e20-e642-fb40-4597-4a35ff5e199f--00001.steV17
    /// where the following information would be
    /// transfer id: 204b6e20-e642-fb40-4597-4a35ff5e199f
    /// job part number: 00001
    /// version schema: 17
    /// </summary>
    internal struct JobPlanFileName
    {
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
        /// Creates Job Part Plan File Name
        /// </summary>
        /// <param name="id"></param>
        /// <param name="jobPartNumber"></param>
        /// <param name="schemaVersion"></param>
        public JobPlanFileName(string id, int jobPartNumber, string schemaVersion)
        {
            Id = id;
            JobPartNumber = jobPartNumber;
            SchemaVersion = schemaVersion;
        }

        public JobPlanFileName(string fullPath)
        {
            // Format of the job plan file name
            // {transferid}--{jobpartNumber}.steV{schemaVersion}
            int endTransferIdIndex = fullPath.IndexOf(Constants.DataMovement.PlanFile.JobPlanFileNameDelimiter, StringComparison.InvariantCultureIgnoreCase);
            if (endTransferIdIndex != Constants.DataMovement.PlanFile.IdSize)
            {
                throw new ArgumentException($"Mismatch Transfer Id Size contained in the transfer file name: {fullPath}");
            }
            Id = fullPath.Substring(0, endTransferIdIndex);

            int partStartIndex = endTransferIdIndex + Constants.DataMovement.PlanFile.JobPlanFileNameDelimiter.Length;
            int endPartIndex = fullPath.IndexOf(Constants.DataMovement.PlanFile.FileExtension, StringComparison.InvariantCultureIgnoreCase);

            if (partStartIndex - endPartIndex != Constants.DataMovement.PlanFile.JobPartLength)
            {
                throw new ArgumentException($"Mismatch Job Part Id contained in the transfer file name: {fullPath}");
            }
            JobPartNumber = int.Parse(fullPath.Substring(partStartIndex, endPartIndex), NumberStyles.Number, CultureInfo.InvariantCulture);

            int schemaStartIndex = endPartIndex + Constants.DataMovement.PlanFile.FileExtension.Length;

            if (schemaStartIndex + 1 >= fullPath.Length)
            {
                throw new ArgumentException($"Mismatch Job Plan Version Schema contained in the transfer file name: {fullPath}");
            }
            SchemaVersion = fullPath.Substring(schemaStartIndex);
            if (Constants.DataMovement.PlanFile.SchemaVersion != SchemaVersion)
            {
                throw new ArgumentException($"Job Part Schema version: {SchemaVersion} does not match the Schema Version supported by the package {Constants.DataMovement.PlanFile.SchemaVersion}. Please consider altering the package version that supports the respective version");
            }
        }

        public override string ToString()
        {
            return $"{Id}--{JobPartNumber.ToString("D5", NumberFormatInfo.CurrentInfo)}.{Constants.DataMovement.PlanFile.FileExtension}{SchemaVersion}";
        }
    }
}
