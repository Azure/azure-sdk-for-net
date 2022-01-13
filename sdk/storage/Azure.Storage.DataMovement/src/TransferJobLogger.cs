// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Text;
using Azure.Storage.DataMovement.Models;
using System.IO;
using System.Threading.Tasks;

namespace Azure.Storage.DataMovement
{
    internal class TransferJobLogger
    {
        /// <summary>
        /// Log file to the particular job
        /// </summary>
        internal readonly string LoggerFilePath;

        /// <summary>
        /// Defines the level of logging that will occur.
        /// </summary>
        internal readonly DataMovementLogLevel LogLevelLimit;

        /// <summary>
        /// Constructor of individual job logger.
        /// </summary>
        /// <param name="loggerFolderPath"></param>
        /// <param name="jobId"></param>
        /// <param name="logLevel"></param>
        public TransferJobLogger(string loggerFolderPath, string jobId, DataMovementLogLevel logLevel = DataMovementLogLevel.None)
        {
            // Create Logger file path name
            LoggerFilePath = loggerFolderPath + jobId + Constants.DataMovement.Log.FileExtension;
            // If the file already exists, keep incrementing until we find a unique file name
            int fileIncrement = 1;
            while (File.Exists(LoggerFilePath))
            {
                if (fileIncrement < Constants.DataMovement.DuplicateFileNameLimit)
                {
                    LoggerFilePath = $"{loggerFolderPath}{jobId}({fileIncrement}){Constants.DataMovement.Log.FileExtension}";
                }
                else
                {
                    throw Errors.TooManyLogFiles(loggerFolderPath, jobId);
                }
            }
            // Create Job Log file
            File.Create(LoggerFilePath);

            LogLevelLimit = logLevel;
        }

        /// <summary>
        /// Logs message to the log job file based on the level. If the level is too high, no message will be logged.
        /// </summary>
        /// <param name="logLevel"></param>
        /// <param name="message"></param>
        public async Task LogAsync(DataMovementLogLevel logLevel, string message)
        {
            if (LogLevelLimit >= logLevel)
            {
                using (StreamWriter fileStream = File.AppendText(LoggerFilePath))
                {
                    await fileStream.WriteLineAsync(message).ConfigureAwait(false);
                }
                // TODO: handle all types of errors to make it clear to the user what's going on
                // e.g. if we are unable to open the file
                // print message
            }
            // do not print message otherwise if the log level is not high enough
        }

        /// <summary>
        /// Purpose is to delete individual plan files
        /// </summary>
        /// <param name="jobId"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void RemoveLogFile(string jobId)
        {
            // Look for the job plan file that we are looking to delete in the folder

            // If not throw an exception
            throw new NotImplementedException();
        }

        /// <summary>
        /// Purpose is to clean all the job files. AKA this would be a clean
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void removeAllLogFiles()
        {
            throw new NotImplementedException();
        }
    }
}
