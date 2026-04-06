// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;
using Azure.Core;

namespace Azure.Search.Documents.KnowledgeBases
{
    /// <summary>
    /// Azure Cognitive Search client that can be used to query an knowledge base.
    /// </summary>
    public partial class KnowledgeBaseRetrievalClient
    {
        /// <summary>
        /// Gets the URI endpoint of the Search service.  This is likely
        /// to be similar to "https://{search_service}.search.windows.net".
        /// </summary>
        public virtual Uri Endpoint => _endpoint;

        /// <summary>
        /// Gets the name of the knowledge base.
        /// </summary>
        public virtual string KnowledgeBaseName => _knowledgeBaseName;

        /// <summary> Initializes a new instance of KnowledgeBaseRetrievalClient from a <see cref="KnowledgeBaseRetrievalClientSettings"/>. </summary>
        /// <param name="settings"> The settings for KnowledgeBaseRetrievalClient. </param>
        [Experimental("SCME0002")] // Bug in emitter that causes paramaeters to not work well with clien.tsp customization.
        public KnowledgeBaseRetrievalClient(KnowledgeBaseRetrievalClientSettings settings) : this(settings?.Endpoint, settings?.KnowledgeBaseName, settings?.CredentialProvider as TokenCredential, settings?.Options) { }
    }
}
