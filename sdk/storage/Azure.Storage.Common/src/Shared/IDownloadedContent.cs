// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;

namespace Azure.Storage.Shared
{
    internal interface IDownloadedContent
    {
        Stream Content { get; }
    }
}
