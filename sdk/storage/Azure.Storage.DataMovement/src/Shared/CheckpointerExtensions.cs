// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Storage.DataMovement.Models;

namespace Azure.Storage.DataMovement
{
    internal static class CheckpointerExtensions
    {
        public static TransferCheckpointer GetCheckpointer(this TransferCheckpointerOptions options)
        {
            if (!string.IsNullOrEmpty(options.CheckpointerPath))
            {
                return new LocalTransferCheckpointer(options.CheckpointerPath);
            }
            else
            {
                // Default TransferCheckpointer
                return new LocalTransferCheckpointer(default);
            }
        }
    }
}
