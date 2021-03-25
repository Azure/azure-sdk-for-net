// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.DocumentTranslation
{
    [CodeGenModel("FileFormat")]
    public partial class FileFormat
    {
        /// <summary> Supported Version. </summary>
        [CodeGenMember("Versions")]
        public IReadOnlyList<string> FormatVersions { get; }
    }
}
