// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using Azure.Search.Documents.Models;

namespace Azure.Search.Documents
{
    [ModelReaderWriterBuildable(typeof(VectorizableImageBinaryQuery))]
    [ModelReaderWriterBuildable(typeof(VectorizableImageUrlQuery))]
    public partial class AzureSearchDocumentsContext
    {
    }
}
