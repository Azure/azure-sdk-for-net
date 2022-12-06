// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Communication.CallingServer
{
    /// <summary> The group call locator. </summary>
    public class FileSource : PlaySource
    {
        /// <summary> The Uri of the file. </summary>
        public Uri FileUri { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="FileSource"/>.
        /// </summary>
        /// <param name="fileUri">File Uri.</param>
        public FileSource(Uri fileUri)
        {
            FileUri = fileUri;
        }
    }
}
