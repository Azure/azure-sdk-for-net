// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.DataMovement.Tests
{
    internal class TransferUtility
    {
        public static string GetNewTransferId() => Guid.NewGuid().ToString();
    }
}
