// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Identity
{
    internal interface IFileSystemService
    {
        bool FileExists(string path);
        string ReadAllText(string path);
    }
}
