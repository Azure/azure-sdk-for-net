// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using static Azure.Storage.DataMovement.DataMovementConstants;

namespace Azure.Storage.DataMovement.Files.Shares
{
    internal class DataMovementShareConstants
    {
        public const int KB = 1024;
        public const int MB = KB * 1024;

        internal const int MaxRange = 4 * MB;

        internal class SourceCheckpointData
        {
            internal const int SchemaVersion = 1;

            internal const int VersionIndex = 0;
            internal const int DataSize = VersionIndex + OneByte;
        }

        internal class DestinationCheckpointData
        {
            internal const int SchemaVersion = 1;
        }
    }
}
