// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.AI.Language.QuestionAnswering.Authoring
{
    public partial class QuestionAnsweringAuthoringClient
    {
        /// <summary> Import project assets - helper overload. </summary>
        private Operation Import(WaitUntil waitUntil, string projectName, ImportJobOptions body, string format, string assetKind, string contentType, RequestContext context)
        {
            RequestContent content = body != null ? RequestContent.Create(body, ModelSerializationExtensions.WireOptions) : null;
            return Import(waitUntil, projectName, content, format, assetKind, context);
        }

        /// <summary> Import project assets - helper overload. </summary>
        private async Task<Operation> ImportAsync(WaitUntil waitUntil, string projectName, ImportJobOptions body, string format, string assetKind, string contentType, RequestContext context)
        {
            RequestContent content = body != null ? RequestContent.Create(body, ModelSerializationExtensions.WireOptions) : null;
            return await ImportAsync(waitUntil, projectName, content, format, assetKind, context).ConfigureAwait(false);
        }
    }
}
