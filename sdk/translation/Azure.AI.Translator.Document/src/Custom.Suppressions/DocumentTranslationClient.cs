// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using Azure.Core;

namespace Azure.AI.Translator.Document
{
    [CodeGenSuppress("CreateDocumentTranslateRequest", typeof(string), typeof(RequestContent), typeof(string), typeof(string), typeof(bool?), typeof(RequestContext))]
    [CodeGenSuppress("DocumentTranslate", typeof(string), typeof(DocumentContent), typeof(string), typeof(string), typeof(bool?), typeof(CancellationToken))]
    [CodeGenSuppress("DocumentTranslateAsync", typeof(string), typeof(DocumentContent), typeof(string), typeof(string), typeof(bool?), typeof(CancellationToken))]
    [CodeGenSuppress("DocumentTranslate", typeof(string), typeof(RequestContent), typeof(string), typeof(string), typeof(bool?), typeof(RequestContext))]
    [CodeGenSuppress("DocumentTranslateAsync", typeof(string), typeof(RequestContent), typeof(string), typeof(string), typeof(bool?), typeof(RequestContext))]
    public partial class DocumentTranslationClient
    {
    }
}
