// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using Azure.Core;

namespace Azure.AI.Translator.Document
{
    [CodeGenSuppress("DocumentTranslate", typeof(string), typeof(DocumentTranslateContent), typeof(string), typeof(string), typeof(bool), typeof(CancellationToken))]
    public partial class DocumentTranslationClient
    {
    }
}
