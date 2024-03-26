// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.Translation.Document
{
    /// <summary> Document Translate Request / Content. </summary>
    [CodeGenSuppress("DocumentTranslateContent", typeof(BinaryData))]
    [CodeGenSuppress("DocumentTranslateContent", typeof(BinaryData), typeof(IList<BinaryData>))]
    [CodeGenSuppress("ToRequestContent")]
    public partial class DocumentTranslateContent
    {
    }
}
