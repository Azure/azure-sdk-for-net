// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.DocumentIntelligence
{
    public partial class AnalyzedDocument
    {
        /// <summary> Dictionary of named field values. </summary>
        public DocumentFieldDictionary Fields { get; private set; }

        [CodeGenMember("Fields")]
        private IReadOnlyDictionary<string, DocumentField> FieldsPrivate
        {
            get => Fields.Source;
            set => Fields = (value is DocumentFieldDictionary instance) ? instance : new(value);
        }
    }
}
