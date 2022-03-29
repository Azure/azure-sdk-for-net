// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Search.Documents.Indexes.Models
{
    public partial class DocumentExtractionSkill
    {
        /// <summary> A dictionary of configurations for the skill. </summary>
        public IDictionary<string, object> Configuration { get; }

        /// <summary> The type of data to be extracted for the skill. Will be set to &apos;contentAndMetadata&apos; if not defined. </summary>
        [CodeGenMember("DataToExtract")]
        public BlobIndexerDataToExtract? DataToExtract { get; set; }

        /// <summary> The parsingMode for the skill. Will be set to &apos;default&apos; if not defined. </summary>
        [CodeGenMember("ParsingMode")]
        public BlobIndexerParsingMode? ParsingMode { get; set; }
    }
}
