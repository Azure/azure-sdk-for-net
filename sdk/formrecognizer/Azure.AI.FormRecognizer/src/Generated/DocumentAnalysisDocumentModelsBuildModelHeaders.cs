// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure;
using Azure.Core;

namespace Azure.AI.FormRecognizer
{
    internal partial class DocumentAnalysisDocumentModelsBuildModelHeaders
    {
        private readonly Response _response;
        public DocumentAnalysisDocumentModelsBuildModelHeaders(Response response)
        {
            _response = response;
        }
        /// <summary> Operation result URL. </summary>
        public string OperationLocation => _response.Headers.TryGetValue("Operation-Location", out string value) ? value : null;
    }
}
