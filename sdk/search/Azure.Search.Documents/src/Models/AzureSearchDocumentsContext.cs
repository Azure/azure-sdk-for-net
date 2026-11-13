// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using Azure.Search.Documents.Indexes.Models;
using Azure.Search.Documents.Models;

namespace Azure.Search.Documents
{
#pragma warning disable CS0618 // Register obsolete compatibility models for typed reads.
    [ModelReaderWriterBuildable(typeof(AzureMachineLearningParameters))]
    [ModelReaderWriterBuildable(typeof(AzureMachineLearningVectorizer))]
    [ModelReaderWriterBuildable(typeof(VectorizableImageBinaryQuery))]
    [ModelReaderWriterBuildable(typeof(VectorizableImageUrlQuery))]
#pragma warning restore CS0618
    public partial class AzureSearchDocumentsContext
    {
    }
}
