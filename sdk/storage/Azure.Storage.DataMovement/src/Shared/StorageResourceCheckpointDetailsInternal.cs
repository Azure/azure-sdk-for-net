// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Storage.DataMovement
{
    /// <summary>
    /// Middle class between the public type and implementation class.
    /// Gives internal hook methods to protected methods of
    /// <see cref="StorageResourceCheckpointDetails"/>, allowing for internal
    /// package use as well as testing access.
    /// </summary>
    internal abstract class StorageResourceCheckpointDetailsInternal : StorageResourceCheckpointDetails
    {
        internal void SerializeInternal(Stream stream) => Serialize(stream);
    }
}
