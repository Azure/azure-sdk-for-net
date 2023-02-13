// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.IO.MemoryMappedFiles;

namespace Azure.Storage.DataMovement
{
    internal class PlanJobWriter
    {
        /// <summary>
        /// Contains file path to the job file
        /// </summary>
        public string PlanJobFilePath;

        /// <summary>
        /// Transfer ID / Memory Map Name
        /// </summary>
        public string TransferId;

        /// <summary>
        /// Memory mapped file
        /// </summary>
        private MemoryMappedFile _memoryMappedFile;

        /// <summary>
        /// Constructor.
        /// </summary>
        public PlanJobWriter(string transferId, string planFolderPath)
        {
            // To populate as jobs get added
            if (string.IsNullOrEmpty(planFolderPath))
            {
                planFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), DataMovementConstants.DefaultTransferFilesPath);
                Directory.CreateDirectory(planFolderPath);
            }
            TransferId = transferId;
            PlanJobFilePath = Path.Combine(planFolderPath, $"{transferId}{DataMovementConstants.PlanFile.FileExtension}");
            File.Create(PlanJobFilePath).Close();
            _memoryMappedFile = MemoryMappedFile.CreateFromFile(PlanJobFilePath, FileMode.Open, transferId, DataMovementConstants.PlanFile.MemoryMappedFileSize);
        }

        /// <summary>
        /// Reports progress to the plan file in the case that the progress is interuptted we know where we were last
        /// </summary>
        /// <param name="reportMessage"></param>
        /// TODO: update transferstatus in the transfer plan file threadsafely
        /// <exception cref="InvalidOperationException"></exception>
#pragma warning disable CA1801 // Review unused parameters
        public void SetTransferStatus(string reportMessage)
#pragma warning restore CA1801 // Review unused parameters
        {
            using (MemoryMappedViewAccessor accessor = _memoryMappedFile.CreateViewAccessor(0, 20))
            {
            }
            // TODO: handle all types of errors to make it clear to the user what's going on
            // e.g. if we are unable to open the file
            // print message
        }

        /// <summary>
        /// Reports progress to the plan file in the case that the progress is interuptted we know where we were last
        /// </summary>
        /// <param name="reportMessage"></param>
        /// TODO: update transferstatus in the transfer plan file threadsafely
        /// <exception cref="InvalidOperationException"></exception>
        public async Task SetTransferStatusAsync(string reportMessage)
        {
            using (StreamWriter fileStream = File.AppendText(PlanJobFilePath))
            {
                await fileStream.WriteLineAsync(reportMessage).ConfigureAwait(false);
            }
            // TODO: handle all types of errors to make it clear to the user what's going on
            // e.g. if we are unable to open the file
            // print message
        }

        public void CloseWriter()
        {
            _memoryMappedFile.Dispose();
        }

        /// <summary>
        /// Purpose is to clean all the job files. AKA this would be a clean
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void RemovePlanFile()
        {
            File.Delete(PlanJobFilePath);
        }
    }
}
