﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.DocumentTranslation
{
    [CodeGenModel("FileFormat")]
    public partial class FileFormat
    {
        /// <summary> Supported format versions. </summary>
        [CodeGenMember("Versions")]
        public IReadOnlyList<string> FormatVersions { get; }

        /// <summary> Default format version if none is specified. </summary>
        [CodeGenMember("DefaultVersion")]
        internal string DefaultFormatVersion { get; }
    }
}
