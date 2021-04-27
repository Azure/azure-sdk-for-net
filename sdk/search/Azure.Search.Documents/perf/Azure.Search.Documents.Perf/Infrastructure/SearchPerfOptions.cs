// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Test.Perf;
using CommandLine;

namespace Azure.Search.Documents.Perf.Infrastructure
{
    /// <summary>
    /// Options specific to search performance tests.
    /// </summary>
    public class SearchPerfOptions : CountOptions
    {
        /// <summary>
        /// Size of the documents used in the performance tests.
        /// </summary>
        [Option('s', "document-size", Default = DocumentSize.Small, HelpText = "Size of Search documents (Small, Large)")]
        public DocumentSize DocumentSize { get; set; }
    }
}
