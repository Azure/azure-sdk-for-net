// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Data.AppConfiguration
{
    internal partial class SnapshotUpdateParameters
    {
        // Mapping model to raw request
        internal static RequestContent ToRequestContent(SnapshotUpdateParameters snapshotUpdateParameters)
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(snapshotUpdateParameters);
            return content;
        }
    }
}
