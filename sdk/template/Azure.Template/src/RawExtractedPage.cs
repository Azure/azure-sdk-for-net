// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;
using System.Linq;

namespace Azure.AI.FormRecognizer.Models
{
    [CodeGenSchema("ReadResult")]
    public partial class RawExtractedPage
    {
        // TODO: perf!!  Don't use Linq.  Could we get a List directly?

        public RawExtractedWord GetRawExtractedWord(RawExtractedWordReference reference) => Lines.ToList()[reference.LineIndex].Words.ToList()[reference.WordIndex];
    }
}
