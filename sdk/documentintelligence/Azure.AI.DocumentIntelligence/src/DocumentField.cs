// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.AI.DocumentIntelligence
{
    public partial class DocumentField
    {
        /// <summary> Dictionary of named field values. </summary>
        public DocumentFieldDictionary ValueDictionary { get; private set; }

        private IReadOnlyDictionary<string, DocumentField> ValueObject
        {
            get => ValueDictionary.Source;
            set => ValueDictionary = (value is DocumentFieldDictionary instance) ? instance : new(value);
        }
    }
}
