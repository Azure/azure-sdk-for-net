﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Containers.ContainerRegistry
{
    /// <summary>
    /// The result from downloading a blob from the registry.
    /// </summary>
    public class DownloadRegistryBlobResult
    {
        internal DownloadRegistryBlobResult(string digest, BinaryData content)
        {
            Digest = digest;
            Content = content;
        }

        /// <summary>
        /// The blob's digest, calculated by the registry.
        /// </summary>
        public string Digest { get; }

        /// <summary>
        /// The blob content.
        /// </summary>
        public BinaryData Content { get; }
    }
}
