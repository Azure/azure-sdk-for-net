// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;

namespace Azure.Storage.Tests.Shared
{
    /// <summary>
    /// A file stream that will have its corresponding file deleted
    /// as part of its Dispose method.
    /// </summary>
    public class TemporaryFileStream : FileStream
    {
        public TemporaryFileStream(string path, FileMode mode)
            : base(path, mode)
        {
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (File.Exists(Name))
            {
                File.Delete(Name);
            }
        }
    }
}
