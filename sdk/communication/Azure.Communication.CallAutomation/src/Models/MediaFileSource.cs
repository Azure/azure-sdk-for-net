// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    /// <summary> The File Source. </summary>
    public class MediaFileSource : PlaySource
    {
        /// <summary> The Uri of the file. </summary>
        public Uri FileUri { get; }

        /// <summary>
        /// Initializes a new instance of <see cref="MediaFileSource"/>.
        /// </summary>
        /// <param name="fileUri">File Uri.</param>
        public MediaFileSource(Uri fileUri)
        {
            FileUri = fileUri;
        }
    }
}
