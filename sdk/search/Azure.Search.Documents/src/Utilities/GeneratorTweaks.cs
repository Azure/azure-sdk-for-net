// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Search.Documents.Models;

#pragma warning disable SA1402 // File may only contain a single type

namespace Azure.Search.Documents
{
    // Hide the unused ServiceClient class.
    [CodeGenClient("")]
    internal partial class ServiceClient { }

    // Hide the unused DataSourcesClient class.
    [CodeGenClient("DataSources")]
    internal partial class DataSourcesClient { }

    // Hide the unused DocumentsClient class.
    [CodeGenClient("Documents")]
    internal partial class DocumentsClient { }

    // Hide the unused IndexersClient class.
    [CodeGenClient("Indexers")]
    internal partial class IndexersClient { }

    // Hide the unused IndexesClient class.
    [CodeGenClient("Indexes")]
    internal partial class IndexesClient { }

    // Hide the unused SkillsetsClient class.
    [CodeGenClient("Skillsets")]
    internal partial class SkillsetsClient { }

    // Hide the unused SynonymMapsClient class.
    [CodeGenClient("SynonymMaps")]
    internal partial class SynonymMapsClient { }

    // https://github.com/Azure/autorest.csharp/issues/486
    // Work-around the generator not enjoying mixing model types between the
    // main and .Models namespaces.
    internal static partial class SearchExtensions
    {
        public static string ToSerialString(this AutocompleteMode value) =>
            AutocompleteModeExtensions.ToSerialString(value);

        public static AutocompleteMode ToAutocompleteMode(this string value) =>
            AutocompleteModeExtensions.ToAutocompleteMode(value);

        public static string ToSerialString(this SearchMode value) =>
            SearchModeExtensions.ToSerialString(value);

        public static SearchMode ToSearchMode(this string value) =>
            SearchModeExtensions.ToSearchMode(value);

        public static string ToSerialString(this SearchQueryType value) =>
            SearchQueryTypeExtensions.ToSerialString(value);

        public static SearchQueryType ToSearchQueryType(this string value) =>
            SearchQueryTypeExtensions.ToSearchQueryType(value);
    }
}
