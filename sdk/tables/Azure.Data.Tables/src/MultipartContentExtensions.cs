// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.Data.Tables
{
    internal static class MultipartContentExtensions
    {
        private const string CteHeaderName = "Content-Transfer-Encoding";
        private const string Binary = "binary";
        private const string ApplicationHttp = "application/http";

        internal static MultipartContent AddChangeset(this MultipartContent batch, Guid changesetGuid)
        {
            var guid = changesetGuid == default ? Guid.NewGuid() : changesetGuid;
            var changeset = new MultipartContent("mixed", $"changeset_{guid}");
            batch.Add(changeset, changeset._headers);
            return changeset;
        }

        internal static void AddContent(this MultipartContent changeset, RequestRequestContent content)
        {
            changeset.Add(content, new Dictionary<string, string> { { HttpHeader.Names.ContentType, ApplicationHttp }, { CteHeaderName, Binary } });
        }
    }
}
