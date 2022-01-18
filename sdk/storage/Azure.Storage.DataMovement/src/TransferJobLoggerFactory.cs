// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.Collections.Generic;
using System.Text;
using Azure.Storage.DataMovement.Models;

namespace Azure.Storage.DataMovement
{
    internal class TransferJobLoggerFactory
    {
        private readonly string _loggerFilePath;
        private readonly DataMovementLogLevel _logLevelLimit;
        private readonly string _jobId;

        public TransferJobLoggerFactory(
            string loggerFilePath,
            string jobId,
            DataMovementLogLevel logLevellimit = DataMovementLogLevel.None)
        {
            _loggerFilePath = loggerFilePath;
            _jobId = jobId;
            _logLevelLimit = logLevellimit;
        }

        public TransferJobLogger BuildTransferJobLogger()
        {
            return new TransferJobLogger(_loggerFilePath, _jobId, _logLevelLimit);
        }
    }
}
