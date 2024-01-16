// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.Translator.Document
{
    [CodeGenModel("DocumentTranslateContent")]
    [CodeGenSuppress("DocumentContent", typeof(BinaryData))]
    [CodeGenSuppress("DocumentContent", typeof(BinaryData), typeof(IList<BinaryData>))]
    [CodeGenSuppress("ToRequestContent")]
    public partial class DocumentContent
    {
    }
}
