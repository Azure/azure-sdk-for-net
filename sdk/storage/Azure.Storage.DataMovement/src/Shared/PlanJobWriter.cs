// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Azure.Storage.DataMovement
{
    internal class PlanJobWriter
    {
        /// <summary>
        /// Contains file path to the job file
        /// </summary>
        internal string planJobFilePath;

        /// <summary>
        /// Constructor.
        /// </summary>
        public PlanJobWriter(string jobId, string planFolderPath)
        {
            // To populate as jobs get added
            planJobFilePath = Path.Combine(planFolderPath, $"{jobId}.{Constants.DataMovement.PlanFile.FileExtension}");
        }

        /// <summary>
        /// Reports progress to the plan file in the case that the progress is interuptted we know where we were last
        /// </summary>
        /// <param name="reportMessage"></param>
        /// TODO: update transferstatus in the transfer plan file threadsafely
        /// <exception cref="InvalidOperationException"></exception>
        public async Task ReportProgress(string reportMessage /*StorageTransferStatus transferStatus = default*/)
        {
            using (StreamWriter fileStream = File.AppendText(planJobFilePath))
            {
                await fileStream.WriteLineAsync(reportMessage).ConfigureAwait(false);
            }
            // TODO: handle all types of errors to make it clear to the user what's going on
            // e.g. if we are unable to open the file
            // print message
        }

        /// <summary>
        /// Purpose is to clean all the job files. AKA this would be a clean
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void RemovePlanFile()
        {
            File.Delete(planJobFilePath);
        }
    }
}
