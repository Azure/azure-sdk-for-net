// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.Data.Tables
{
    internal static class MultipartContentExtensions
    {
        internal static MultipartContent AddChangeset(this MultipartContent batch)
        {
            var changeset = new MultipartContent("mixed", $"changeset_{Guid.NewGuid()}");
            batch.Add(changeset, changeset._headers);
            return changeset;
        }
    }
}
