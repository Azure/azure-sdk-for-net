// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Reflection;
using Microsoft.Azure.Search.Models;
using Microsoft.Azure.Search.Tests.Utilities;
using Xunit;
using Index = Microsoft.Azure.Search.Models.Index;

namespace Microsoft.Azure.Search.Tests
{
    public sealed class CustomAnalyzerTests : SearchTestBase<IndexFixture>
    {
        [Fact]
        public void CanSearchWithCustomAnalyzer()
        {
            Run(() =>
            {
                const string CustomAnalyzerName = "my_email_analyzer";
                const string CustomCharFilterName = "my_email_filter";

                Index index = new Index()
                {
                    Name = SearchTestUtilities.GenerateName(),
                    Fields = new[]
                    {
                        new Field("id", DataType.String) { IsKey = true },
                        new Field("message", (AnalyzerName)CustomAnalyzerName) { IsSearchable = true }
                    },
                    Analyzers = new[]
                    {
                        new CustomAnalyzer()
                        {
                            Name = CustomAnalyzerName,
                            Tokenizer = TokenizerName.Standard,
                            CharFilters = new[] { (CharFilterName)CustomCharFilterName }
                        }
                    },
                    CharFilters = new[] { new PatternReplaceCharFilter(CustomCharFilterName, "@", "_") }
                };

                Data.GetSearchServiceClient().Indexes.Create(index);

                SearchIndexClient indexClient = Data.GetSearchIndexClient(index.Name);

                var documents = new[]
                {
                    new Document() { { "id", "1" }, { "message", "My email is someone@somewhere.something." } },
                    new Document() { { "id", "2" }, { "message", "His email is someone@nowhere.nothing." } },
                };

                indexClient.Documents.Index(IndexBatch.Upload(documents));
                SearchTestUtilities.WaitForIndexing();

                DocumentSearchResult<Document> result = indexClient.Documents.Search("someone@somewhere.something");

                Assert.Equal("1", result.Results.Single().Document["id"]);
            });
        }

        [Fact]
        public void CanUseAllAnalyzerNamesInIndexDefinition()
        {
            Run(() =>
            {
                SearchServiceClient client = Data.GetSearchServiceClient();

                Index index =
                    new Index()
                    {
                        Name = SearchTestUtilities.GenerateName(),
                        Fields = new[] { new Field("id", DataType.String) { IsKey = true } }.ToList()
                    };

                AnalyzerName[] allAnalyzers = GetAllExtensibleEnumValues<AnalyzerName>();

                int fieldNumber = 0;

                // All analyzer names can be set on the analyzer property.
                for (int i = 0; i < allAnalyzers.Length; i++)
                {
                    DataType fieldType = (i % 2 == 0) ? DataType.String : DataType.Collection(DataType.String);
                    index.Fields.Add(new Field($"field{fieldNumber++}", fieldType, allAnalyzers[i]));
                }

                // Only non-language analyzer names can be set on the searchAnalyzer and indexAnalyzer properties.
                // ASSUMPTION: Only language analyzers end in .lucene or .microsoft.
                var allNonLanguageAnalyzers =
                    allAnalyzers.Where(a => !a.ToString().EndsWith(".lucene") && !a.ToString().EndsWith(".microsoft")).ToArray();

                for (int i = 0; i < allNonLanguageAnalyzers.Length; i++)
                {
                    DataType fieldType = (i % 2 == 0) ? DataType.String : DataType.Collection(DataType.String);

                    var field =
                        new Field($"field{fieldNumber++}", fieldType)
                        {
                            IsSearchable = true,
                            SearchAnalyzer = allNonLanguageAnalyzers[i],
                            IndexAnalyzer = allNonLanguageAnalyzers[i]
                        };

                    index.Fields.Add(field);
                }

                client.Indexes.Create(index);
            });
        }

        [Fact]
        public void CanAnalyze()
        {
            Run(() =>
            {
                SearchServiceClient client = Data.GetSearchServiceClient();

                Index index = CreateTestIndex();
                client.Indexes.Create(index);

                var request = new AnalyzeRequest()
                {
                    Text = "One two",
                    Analyzer = AnalyzerName.Whitespace
                };

                AnalyzeResult result = client.Indexes.Analyze(index.Name, request);

                Assert.Equal(2, result.Tokens.Count);
                AssertTokenInfoEqual("One", expectedStartOffset: 0, expectedEndOffset: 3, expectedPosition: 0, actual: result.Tokens[0]);
                AssertTokenInfoEqual("two", expectedStartOffset: 4, expectedEndOffset: 7, expectedPosition: 1, actual: result.Tokens[1]);

                request = new AnalyzeRequest()
                {
                    Text = "One's <two/>",
                    Tokenizer = TokenizerName.Whitespace,
                    TokenFilters = new[] { TokenFilterName.Apostrophe },
                    CharFilters = new[] { CharFilterName.HtmlStrip }
                };

                result = client.Indexes.Analyze(index.Name, request);

                Assert.Equal(1, result.Tokens.Count);

                // End offset is based on the original token, not the one emitted by the filters.
                AssertTokenInfoEqual("One", expectedStartOffset: 0, expectedEndOffset: 5, expectedPosition: 0, actual: result.Tokens[0]);
            });
        }

        [Fact]
        public void CanAnalyzeWithAllPossibleNames()
        {
            Run(() =>
            {
                SearchServiceClient client = Data.GetSearchServiceClient();

                Index index = CreateTestIndex();
                client.Indexes.Create(index);

                AnalyzerName[] allAnalyzerNames = GetAllExtensibleEnumValues<AnalyzerName>();

                var requests = allAnalyzerNames.Select(an => new AnalyzeRequest() { Text = "One two", Analyzer = an });

                foreach (var req in requests)
                {
                    client.Indexes.Analyze(index.Name, req);
                }

                TokenizerName[] allTokenizerNames = GetAllExtensibleEnumValues<TokenizerName>();
                requests = allTokenizerNames.Select(tn => new AnalyzeRequest() { Text = "One two", Tokenizer = tn });

                foreach (var req in requests)
                {
                    client.Indexes.Analyze(index.Name, req);
                }

                TokenFilterName[] allTokenFilterNames = GetAllExtensibleEnumValues<TokenFilterName>();
                CharFilterName[] allCharFilterNames = GetAllExtensibleEnumValues<CharFilterName>();

                var request =
                    new AnalyzeRequest(
                        "One two",
                        tokenizer: TokenizerName.Whitespace,
                        tokenFilters: allTokenFilterNames,
                        charFilters: allCharFilterNames);

                client.Indexes.Analyze(index.Name, request);
            });
        }

        [Fact]
        public void AddingCustomAnalyzerThrowsCloudExceptionByDefault()
        {
            Run(() =>
            {
                SearchServiceClient client = Data.GetSearchServiceClient();

                Index index = CreateTestIndex();
                index.Analyzers = new List<Analyzer>() { new StopAnalyzer("a1") };

                client.Indexes.Create(index);

                index.Analyzers.Add(new StopAnalyzer("a2"));

                SearchAssert.ThrowsCloudException(() => client.Indexes.CreateOrUpdate(index), HttpStatusCode.BadRequest);
            });
        }

        [Fact]
        public void CanAddCustomAnalyzerWithIndexDowntime()
        {
            Run(() =>
            {
                SearchServiceClient client = Data.GetSearchServiceClient();

                Index index = CreateTestIndex();
                index.Analyzers = new List<Analyzer>() { new StopAnalyzer("a1") };

                client.Indexes.Create(index);

                index.Analyzers.Add(new StopAnalyzer("a2"));

                Index updatedIndex = client.Indexes.CreateOrUpdate(index, allowIndexDowntime: true);

                AssertAnalysisComponentsEqual(index, updatedIndex);
            });
        }

        [Fact]
        public void CanCreateAllAnalysisComponents()
        {
            Run(() =>
            {
                // Declare some custom component names to use with CustomAnalyzer. All other names will be randomly generated.
                const string CustomTokenizerName = "my_tokenizer";
                const string CustomTokenFilterName = "my_tokenfilter";
                const string CustomCharFilterName = "my_charfilter";

                Index index = CreateTestIndex();
                index.Analyzers = new Analyzer[]
                {
                    new CustomAnalyzer(
                        SearchTestUtilities.GenerateName(),
                        CustomTokenizerName,
                        new TokenFilterName[] { CustomTokenFilterName },
                        new CharFilterName[] { CustomCharFilterName }),
                    new CustomAnalyzer(
                        SearchTestUtilities.GenerateName(),
                        TokenizerName.EdgeNGram),
                    new PatternAnalyzer(
                        SearchTestUtilities.GenerateName(),
                        lowerCaseTerms: false,
                        pattern: "abc",
                        flags: RegexFlags.DotAll,
                        stopwords: new[] { "the" }),
                    new StandardAnalyzer(SearchTestUtilities.GenerateName(), maxTokenLength: 100, stopwords: new[] { "the" }),
                    new StopAnalyzer(SearchTestUtilities.GenerateName(), stopwords: new[] { "the" }),
                    new StopAnalyzer(SearchTestUtilities.GenerateName())
                };

                index.Tokenizers = new Tokenizer[]
                {
                    new EdgeNGramTokenizer(CustomTokenizerName, minGram: 1, maxGram: 2),    // One custom tokenizer for CustomAnalyzer above.
                    new EdgeNGramTokenizer(
                        SearchTestUtilities.GenerateName(),
                        minGram: 2,
                        maxGram: 4,
                        tokenChars: new[] { TokenCharacterKind.Letter }),
                    new NGramTokenizer(SearchTestUtilities.GenerateName(), minGram: 2, maxGram: 4, tokenChars: new[] { TokenCharacterKind.Letter }),
                    new ClassicTokenizer(SearchTestUtilities.GenerateName(), maxTokenLength: 100),
                    new KeywordTokenizerV2(SearchTestUtilities.GenerateName(), maxTokenLength: 100),
                    new MicrosoftLanguageStemmingTokenizer(
                        SearchTestUtilities.GenerateName(),
                        maxTokenLength: 100,
                        isSearchTokenizer: true,
                        language: MicrosoftStemmingTokenizerLanguage.Croatian),
                    new MicrosoftLanguageTokenizer(
                        SearchTestUtilities.GenerateName(),
                        maxTokenLength: 100,
                        isSearchTokenizer: true,
                        language: MicrosoftTokenizerLanguage.Thai),
                    new PathHierarchyTokenizerV2(
                        SearchTestUtilities.GenerateName(),
                        delimiter: ':',
                        replacement: '_',
                        maxTokenLength: 300,
                        reverseTokenOrder: true,
                        numberOfTokensToSkip: 2),
                    new PatternTokenizer(
                        SearchTestUtilities.GenerateName(),
                        pattern: ".*",
                        flags: RegexFlags.Multiline | RegexFlags.Literal,
                        group: 0),
                    new StandardTokenizerV2(SearchTestUtilities.GenerateName(), maxTokenLength: 100),
                    new UaxUrlEmailTokenizer(SearchTestUtilities.GenerateName(), maxTokenLength: 100)
                };

                index.TokenFilters = new TokenFilter[]
                {
                    new CjkBigramTokenFilter(CustomTokenFilterName),    // One custom token filter for CustomAnalyzer above.
                    new CjkBigramTokenFilter(
                        SearchTestUtilities.GenerateName(),
                        ignoreScripts: new[] { CjkBigramTokenFilterScripts.Han },
                        outputUnigrams: true),
                    new CjkBigramTokenFilter(SearchTestUtilities.GenerateName()),
                    new AsciiFoldingTokenFilter(SearchTestUtilities.GenerateName(), preserveOriginal: true),
                    new AsciiFoldingTokenFilter(SearchTestUtilities.GenerateName()),
                    new CommonGramTokenFilter(
                        SearchTestUtilities.GenerateName(),
                        commonWords: new[] { "hello", "goodbye" },
                        ignoreCase: true,
                        useQueryMode: true),
                    new CommonGramTokenFilter(SearchTestUtilities.GenerateName(), commonWords: new[] { "at" }),
                    new DictionaryDecompounderTokenFilter(
                        SearchTestUtilities.GenerateName(),
                        wordList: new[] { "Schadenfreude" },
                        minWordSize: 10,
                        minSubwordSize: 5,
                        maxSubwordSize: 13,
                        onlyLongestMatch: true),
                    new EdgeNGramTokenFilterV2(SearchTestUtilities.GenerateName(), minGram: 2, maxGram: 10, side: EdgeNGramTokenFilterSide.Back),
                    new ElisionTokenFilter(SearchTestUtilities.GenerateName(), articles: new[] { "a" }),
                    new ElisionTokenFilter(SearchTestUtilities.GenerateName()),
                    new KeepTokenFilter(SearchTestUtilities.GenerateName(), keepWords: new[] { "aloha" }, lowerCaseKeepWords: true),
                    new KeepTokenFilter(SearchTestUtilities.GenerateName(), keepWords: new[] { "e", "komo", "mai" }),
                    new KeywordMarkerTokenFilter(SearchTestUtilities.GenerateName(), keywords: new[] { "key", "words" }, ignoreCase: true),
                    new KeywordMarkerTokenFilter(SearchTestUtilities.GenerateName(), keywords: new[] { "essential" }),
                    new LengthTokenFilter(SearchTestUtilities.GenerateName(), min: 5, max: 10),
                    new LimitTokenFilter(SearchTestUtilities.GenerateName(), maxTokenCount: 10, consumeAllTokens: true),
                    new NGramTokenFilterV2(SearchTestUtilities.GenerateName(), minGram: 2, maxGram: 3),
                    new PatternCaptureTokenFilter(SearchTestUtilities.GenerateName(), patterns: new[] { ".*" }, preserveOriginal: false),
                    new PatternReplaceTokenFilter(SearchTestUtilities.GenerateName(), pattern: "abc", replacement: "123"),
                    new PhoneticTokenFilter(SearchTestUtilities.GenerateName(), encoder: PhoneticEncoder.Soundex, replaceOriginalTokens: false),
                    new ShingleTokenFilter(
                        SearchTestUtilities.GenerateName(),
                        maxShingleSize: 10,
                        minShingleSize: 5,
                        outputUnigrams: false,
                        outputUnigramsIfNoShingles: true,
                        tokenSeparator: " ",
                        filterToken: "|"),
                    new SnowballTokenFilter(SearchTestUtilities.GenerateName(), SnowballTokenFilterLanguage.English),
                    new StemmerOverrideTokenFilter(SearchTestUtilities.GenerateName(), rules: new[] { "ran => run" }),
                    new StemmerTokenFilter(SearchTestUtilities.GenerateName(), StemmerTokenFilterLanguage.French),
                    new StopwordsTokenFilter(
                        SearchTestUtilities.GenerateName(),
                        stopwords: new[] { "a", "the" },
                        ignoreCase: true,
                        removeTrailingStopWords: false),
                    new StopwordsTokenFilter(
                        SearchTestUtilities.GenerateName(),
                        stopwordsList: StopwordsList.Italian,
                        ignoreCase: true,
                        removeTrailingStopWords: false),
                    new SynonymTokenFilter(SearchTestUtilities.GenerateName(), synonyms: new[] { "great, good" }, ignoreCase: true, expand: false),
                    new TruncateTokenFilter(SearchTestUtilities.GenerateName(), length: 10),
                    new UniqueTokenFilter(SearchTestUtilities.GenerateName(), onlyOnSamePosition: true),
                    new UniqueTokenFilter(SearchTestUtilities.GenerateName()),
                    new WordDelimiterTokenFilter(
                        SearchTestUtilities.GenerateName(),
                        generateWordParts: false,
                        generateNumberParts: false,
                        catenateWords: true,
                        catenateNumbers: true,
                        catenateAll: true,
                        splitOnCaseChange: false,
                        preserveOriginal: true,
                        splitOnNumerics: false,
                        stemEnglishPossessive: false,
                        protectedWords: new[] { "protected" })
                };

                index.CharFilters = new CharFilter[]
                {
                    new MappingCharFilter(CustomCharFilterName, mappings: new[] { "a => b" }),    // One custom char filter for CustomAnalyzer above.
                    new MappingCharFilter(SearchTestUtilities.GenerateName(), mappings: new[] { "s => $", "S => $" }),
                    new PatternReplaceCharFilter(SearchTestUtilities.GenerateName(), pattern: "abc", replacement: "123")
                };

                // We have to split up analysis components into two indexes, one where any components with optional properties have defaults that
                // are zero or null (default(T)), and another where we need to specify the default values we expect to get back from the REST API.

                string GenerateSimpleName(int n) => string.Format(CultureInfo.InvariantCulture, "a{0}", n);

                int i = 0;

                Index indexWithSpecialDefaults = CreateTestIndex();
                indexWithSpecialDefaults.Analyzers = new Analyzer[]
                {
                    new PatternAnalyzer(GenerateSimpleName(i++)),
                    new StandardAnalyzer(GenerateSimpleName(i++))
                };

                indexWithSpecialDefaults.Tokenizers = new Tokenizer[]
                {
                    new EdgeNGramTokenizer(GenerateSimpleName(i++)),
                    new NGramTokenizer(GenerateSimpleName(i++)),
                    new ClassicTokenizer(GenerateSimpleName(i++)),
                    new KeywordTokenizerV2(GenerateSimpleName(i++)),
                    new MicrosoftLanguageStemmingTokenizer(GenerateSimpleName(i++)),
                    new MicrosoftLanguageTokenizer(GenerateSimpleName(i++)),
                    new PathHierarchyTokenizerV2(GenerateSimpleName(i++)),
                    new PatternTokenizer(GenerateSimpleName(i++)),
                    new StandardTokenizerV2(GenerateSimpleName(i++)),
                    new UaxUrlEmailTokenizer(GenerateSimpleName(i++))
                };

                indexWithSpecialDefaults.TokenFilters = new TokenFilter[]
                {
                    new DictionaryDecompounderTokenFilter(
                        GenerateSimpleName(i++),
                        wordList: new[] { "Bahnhof" }),
                    new EdgeNGramTokenFilterV2(GenerateSimpleName(i++)),
                    new LengthTokenFilter(GenerateSimpleName(i++)),
                    new LimitTokenFilter(GenerateSimpleName(i++)),
                    new NGramTokenFilterV2(GenerateSimpleName(i++)),
                    new PatternCaptureTokenFilter(GenerateSimpleName(i++), patterns: new[] { "[a-z]*" }),
                    new PhoneticTokenFilter(GenerateSimpleName(i++)),
                    new ShingleTokenFilter(GenerateSimpleName(i++)),
                    new StopwordsTokenFilter(GenerateSimpleName(i++)),
                    new SynonymTokenFilter(GenerateSimpleName(i++), synonyms: new[] { "mutt, canine => dog" }),
                    new TruncateTokenFilter(GenerateSimpleName(i++)),
                    new WordDelimiterTokenFilter(GenerateSimpleName(i++))
                };

                i = 0;

                Index expectedIndexWithSpecialDefaults = CreateTestIndex();
                expectedIndexWithSpecialDefaults.Name = indexWithSpecialDefaults.Name;
                expectedIndexWithSpecialDefaults.Analyzers = new Analyzer[]
                {
                    new PatternAnalyzer(GenerateSimpleName(i++), lowerCaseTerms: true, pattern: @"\W+"),
                    new StandardAnalyzer(GenerateSimpleName(i++), maxTokenLength: 255)
                };

                expectedIndexWithSpecialDefaults.Tokenizers = new Tokenizer[]
                {
                    new EdgeNGramTokenizer(GenerateSimpleName(i++), minGram: 1, maxGram: 2),
                    new NGramTokenizer(GenerateSimpleName(i++), minGram: 1, maxGram: 2),
                    new ClassicTokenizer(GenerateSimpleName(i++), maxTokenLength: 255),
                    new KeywordTokenizerV2(GenerateSimpleName(i++), maxTokenLength: 256),
                    new MicrosoftLanguageStemmingTokenizer(
                        GenerateSimpleName(i++),
                        maxTokenLength: 255,
                        isSearchTokenizer: false,
                        language: MicrosoftStemmingTokenizerLanguage.English),
                    new MicrosoftLanguageTokenizer(
                        GenerateSimpleName(i++),
                        maxTokenLength: 255,
                        isSearchTokenizer: false,
                        language: MicrosoftTokenizerLanguage.English),
                    new PathHierarchyTokenizerV2(GenerateSimpleName(i++), delimiter: '/', replacement: '/', maxTokenLength: 300),
                    new PatternTokenizer(GenerateSimpleName(i++), pattern: @"\W+", group: -1),
                    new StandardTokenizerV2(GenerateSimpleName(i++), maxTokenLength: 255),
                    new UaxUrlEmailTokenizer(GenerateSimpleName(i++), maxTokenLength: 255)
                };

                expectedIndexWithSpecialDefaults.TokenFilters = new TokenFilter[]
                {
                    new DictionaryDecompounderTokenFilter(
                        GenerateSimpleName(i++),
                        wordList: new[] { "Bahnhof" },
                        minWordSize: 5,
                        minSubwordSize: 2,
                        maxSubwordSize: 15),
                    new EdgeNGramTokenFilterV2(GenerateSimpleName(i++), minGram: 1, maxGram: 2, side: EdgeNGramTokenFilterSide.Front),
                    new LengthTokenFilter(GenerateSimpleName(i++), max: 300),
                    new LimitTokenFilter(GenerateSimpleName(i++), maxTokenCount: 1),
                    new NGramTokenFilterV2(GenerateSimpleName(i++), minGram: 1, maxGram: 2),
                    new PatternCaptureTokenFilter(GenerateSimpleName(i++), patterns: new[] { "[a-z]*" }, preserveOriginal: true),
                    new PhoneticTokenFilter(GenerateSimpleName(i++), encoder: PhoneticEncoder.Metaphone, replaceOriginalTokens: true),
                    new ShingleTokenFilter(
                        GenerateSimpleName(i++),
                        maxShingleSize: 2,
                        minShingleSize: 2,
                        outputUnigrams: true,
                        tokenSeparator: " ",
                        filterToken: "_"),
                    new StopwordsTokenFilter(GenerateSimpleName(i++), stopwordsList: StopwordsList.English, removeTrailingStopWords: true),
                    new SynonymTokenFilter(GenerateSimpleName(i++), synonyms: new[] { "mutt, canine => dog" }, expand: true),
                    new TruncateTokenFilter(GenerateSimpleName(i++), length: 300),
                    new WordDelimiterTokenFilter(
                        GenerateSimpleName(i++),
                        generateWordParts: true,
                        generateNumberParts: true,
                        splitOnCaseChange: true,
                        splitOnNumerics: true,
                        stemEnglishPossessive: true)
                };

                // This is to make sure we didn't forget any components in this test.
                AssertIndexContainsAllAnalysisComponents(index, indexWithSpecialDefaults);

                TestAnalysisComponents(index);
                TestAnalysisComponents(indexWithSpecialDefaults, expectedIndexWithSpecialDefaults);
            });
        }

        [Fact]
        public void CanUseAllAnalysisComponentNames()
        {
            Run(() =>
            {
                TokenizerName[] allTokenizerNames = GetAllExtensibleEnumValues<TokenizerName>();
                TokenFilterName[] allTokenFilterNames = GetAllExtensibleEnumValues<TokenFilterName>();
                CharFilterName[] allCharFilterNames = GetAllExtensibleEnumValues<CharFilterName>();

                var analyzerWithAllTokenFiltersAndCharFilters =
                    new CustomAnalyzer(SearchTestUtilities.GenerateName(), TokenizerName.Lowercase, allTokenFilterNames, allCharFilterNames);

                IEnumerable<Analyzer> analyzersWithAllTokenizers =
                    allTokenizerNames.Select(tn => new CustomAnalyzer(SearchTestUtilities.GenerateName(), tn));

                Index index = CreateTestIndex();
                index.Analyzers = new[] { analyzerWithAllTokenFiltersAndCharFilters }.Concat(analyzersWithAllTokenizers).ToArray();

                TestAnalysisComponents(index);
            });
        }

        [Fact]
        public void CanUseAllRegexFlags()
        {
            Run(() =>
            {
                RegexFlags[] allRegexFlags = GetAllExtensibleEnumValues<RegexFlags>();

                Analyzer CreatePatternAnalyzer(RegexFlags rf) =>
                    new PatternAnalyzer(SearchTestUtilities.GenerateName(), lowerCaseTerms: true, pattern: ".*", flags: rf);

                Index index = CreateTestIndex();
                index.Analyzers = allRegexFlags.Select(CreatePatternAnalyzer).ToArray();

                TestAnalysisComponents(index);
            });
        }

        [Fact]
        public void CanUseAllAnalysisComponentOptions()
        {
            Run(() =>
            {
                var tokenizerWithAllTokenCharacterKinds =
                    new EdgeNGramTokenizer(
                        SearchTestUtilities.GenerateName(),
                        minGram: 1,
                        maxGram: 2,
                        tokenChars: GetAllEnumValues<TokenCharacterKind>());

                Tokenizer CreateMicrosoftLanguageTokenizer(MicrosoftTokenizerLanguage mtl) =>
                    new MicrosoftLanguageTokenizer(
                        SearchTestUtilities.GenerateName(),
                        maxTokenLength: 200,
                        isSearchTokenizer: false,
                        language: mtl);

                IEnumerable<Tokenizer> tokenizersWithAllMicrosoftLanguages =
                    GetAllEnumValues<MicrosoftTokenizerLanguage>().Select(CreateMicrosoftLanguageTokenizer);

                Tokenizer CreateMicrosoftStemmingLanguageTokenizer(MicrosoftStemmingTokenizerLanguage mtl) =>
                    new MicrosoftLanguageStemmingTokenizer(
                        SearchTestUtilities.GenerateName(),
                        maxTokenLength: 200,
                        isSearchTokenizer: false,
                        language: mtl);

                IEnumerable<Tokenizer> tokenizersWithAllMicrosoftStemmingLanguages =
                    GetAllEnumValues<MicrosoftStemmingTokenizerLanguage>().Select(CreateMicrosoftStemmingLanguageTokenizer);

                var tokenFilterWithAllCjkScripts =
                    new CjkBigramTokenFilter(
                        SearchTestUtilities.GenerateName(),
                        ignoreScripts: GetAllEnumValues<CjkBigramTokenFilterScripts>(),
                        outputUnigrams: true);

                TokenFilter CreateEdgeNGramTokenFilter(EdgeNGramTokenFilterSide s) =>
                    new EdgeNGramTokenFilterV2(SearchTestUtilities.GenerateName(), minGram: 1, maxGram: 2, side: s);

                IEnumerable<TokenFilter> tokenFiltersWithAllEdgeNGramSides =
                    GetAllEnumValues<EdgeNGramTokenFilterSide>().Select(CreateEdgeNGramTokenFilter);

                TokenFilter CreatePhoneticTokenFilter(PhoneticEncoder pe) =>
                    new PhoneticTokenFilter(SearchTestUtilities.GenerateName(), encoder: pe, replaceOriginalTokens: false);

                IEnumerable<TokenFilter> tokenFiltersWithAllPhoneticEncoders =
                    GetAllEnumValues<PhoneticEncoder>().Select(CreatePhoneticTokenFilter);

                IEnumerable<TokenFilter> tokenFiltersWithAllSnowballLanguages =
                    GetAllEnumValues<SnowballTokenFilterLanguage>().Select(l => new SnowballTokenFilter(SearchTestUtilities.GenerateName(), l));

                IEnumerable<TokenFilter> tokenFiltersWithAllStemmerLanguages =
                    GetAllEnumValues<StemmerTokenFilterLanguage>().Select(l => new StemmerTokenFilter(SearchTestUtilities.GenerateName(), l));

                TokenFilter CreateStopTokenFilter(StopwordsList l) =>
                    new StopwordsTokenFilter(
                        SearchTestUtilities.GenerateName(),
                        stopwordsList: l,
                        ignoreCase: false,
                        removeTrailingStopWords: true);

                IEnumerable<TokenFilter> tokenFiltersWithAllStopwordLists = GetAllEnumValues<StopwordsList>().Select(CreateStopTokenFilter);

                // Split the tokenizers and token filters into different indexes to get around the 50-item limit.
                Index index = CreateTestIndex();

                index.Tokenizers =
                    new[] { tokenizerWithAllTokenCharacterKinds }
                    .Concat(tokenizersWithAllMicrosoftLanguages)
                    .Concat(tokenizersWithAllMicrosoftStemmingLanguages).ToArray();

                index.TokenFilters =
                    new[] { tokenFilterWithAllCjkScripts }
                    .Concat(tokenFiltersWithAllEdgeNGramSides)
                    .Concat(tokenFiltersWithAllPhoneticEncoders)
                    .Concat(tokenFiltersWithAllSnowballLanguages)
                    .Concat(tokenFiltersWithAllStemmerLanguages)
                    .Concat(tokenFiltersWithAllStopwordLists).ToArray();

                TestAnalysisComponents(index);
            });
        }

        private static void AssertIndexContainsAllAnalysisComponents(params Index[] indexes)
        {
            IEnumerable<Analyzer> GetAnalyzers(Index index) => index.Analyzers ?? Enumerable.Empty<Analyzer>();
            IEnumerable<Tokenizer> GetTokenizers(Index index) => index.Tokenizers ?? Enumerable.Empty<Tokenizer>();
            IEnumerable<TokenFilter> GetTokenFilters(Index index) => index.TokenFilters ?? Enumerable.Empty<TokenFilter>();
            IEnumerable<CharFilter> GetCharFilters(Index index) => index.CharFilters ?? Enumerable.Empty<CharFilter>();

            IEnumerable<Type> GetAnalysisTypesPresentInIndex(Index index) =>
                GetAnalyzers(index).Select(a => a.GetType())
                .Concat(GetTokenizers(index).Select(t => t.GetType()))
                .Concat(GetTokenFilters(index).Select(tf => tf.GetType()))
                .Concat(GetCharFilters(index).Select(c => c.GetType()));

            var analysisTypesPresentInAllIndexes =
                from index in indexes
                from t in GetAnalysisTypesPresentInIndex(index)
                select t;

            // Count how many instances of each type appear in the given index definitions.
            var analysisTypeCounts =
                from t in analysisTypesPresentInAllIndexes
                group t by t into typeGroup
                select new { Type = typeGroup.Key, Count = typeGroup.Count() };

            Dictionary<Type, int> instanceCountMap = analysisTypeCounts.ToDictionary(tc => tc.Type, tc => tc.Count);
            IEnumerable<Type> allAnalysisComponentTypes = typeof(Index).GetTypeInfo().Assembly.ExportedTypes.Where((Type type) => IsAnalysisComponentType(type) && !IsDeprecatedType(type));
            IEnumerable<Type> missingTypes = allAnalysisComponentTypes.Where(t => !IsTypePresentAtLeastOnce(instanceCountMap, t));

            if (missingTypes.Any())
            {
                const string MessageFormat =
                    "Logic error in test. Test must include at least one case for each analysis component type. Missing types:{0}{0}{1}";

                string message =
                    String.Format(
                        CultureInfo.InvariantCulture,
                        MessageFormat,
                        Environment.NewLine,
                        String.Join(Environment.NewLine, missingTypes.Select(t => t.Name)));

                Assert.True(false, message);
            }
        }

        private static bool IsAnalysisComponentType(Type candidateType)
        {
            Type baseType = candidateType.GetTypeInfo().BaseType;
            return
                baseType == typeof(Analyzer) || baseType == typeof(Tokenizer) ||
                baseType == typeof(TokenFilter) || baseType == typeof(CharFilter);
        }

        private static bool IsDeprecatedType(Type candidateType)
        {
            return candidateType.GetTypeInfo().GetCustomAttribute<ObsoleteAttribute>() != null;
        }

        private static bool IsTypePresentAtLeastOnce(Dictionary<Type, int> instanceCountMap, Type analysisType)
        {
            if (instanceCountMap.TryGetValue(analysisType, out int count))
            {
                return count >= 1;
            }

            return false;
        }

        private static Index CreateTestIndex() => IndexManagementTests.CreateTestIndex();

        private static void AssertTokenInfoEqual(
            string expectedToken,
            int expectedStartOffset,
            int expectedEndOffset,
            int expectedPosition,
            TokenInfo actual)
        {
            Assert.NotNull(actual);

            Assert.Equal(expectedToken, actual.Token);
            Assert.Equal(expectedStartOffset, actual.StartOffset);
            Assert.Equal(expectedEndOffset, actual.EndOffset);
            Assert.Equal(expectedPosition, actual.Position);
        }

        private static void AssertAnalysisComponentsEqual(Index expected, Index actual)
        {
            // Compare analysis components directly so that test failures show better comparisons.

            Assert.Equal(expected.Analyzers?.Count ?? 0, actual.Analyzers?.Count ?? 0);
            for (int i = 0; i < expected.Analyzers?.Count; i++)
            {
                Assert.Equal(expected.Analyzers[i], actual.Analyzers[i], new DataPlaneModelComparer<Analyzer>());
            }

            Assert.Equal(expected.Tokenizers?.Count ?? 0, actual.Tokenizers?.Count ?? 0);
            for (int i = 0; i < expected.Tokenizers?.Count; i++)
            {
                Assert.Equal(expected.Tokenizers[i], actual.Tokenizers[i], new DataPlaneModelComparer<Tokenizer>());
            }

            Assert.Equal(expected.TokenFilters?.Count ?? 0, actual.TokenFilters?.Count ?? 0);
            for (int i = 0; i < expected.TokenFilters?.Count; i++)
            {
                Assert.Equal(expected.TokenFilters[i], actual.TokenFilters[i], new DataPlaneModelComparer<TokenFilter>());
            }

            Assert.Equal(expected.CharFilters?.Count ?? 0, actual.CharFilters?.Count ?? 0);
            for (int i = 0; i < expected.CharFilters?.Count; i++)
            {
                Assert.Equal(expected.CharFilters[i], actual.CharFilters[i], new DataPlaneModelComparer<CharFilter>());
            }
        }

        private static T[] GetAllExtensibleEnumValues<T>() =>
            (from field in typeof(T).GetFields()
             where field.FieldType == typeof(T) && field.IsStatic
             select field.GetValue(null)).Cast<T>().ToArray();   // Force eager evaluation.

        private static T[] GetAllEnumValues<T>() where T : struct => Enum.GetValues(typeof(T)).Cast<T>().ToArray();

        // If the Index has too many analysis components, split it up.
        private static IEnumerable<Index> SplitIndex(Index index)
        {
            IEnumerable<IEnumerable<Analyzer>> analyzerGroups = SplitAnalysisComponents(index.Analyzers);
            IEnumerable<IEnumerable<Tokenizer>> tokenizerGroups = SplitAnalysisComponents(index.Tokenizers);
            IEnumerable<IEnumerable<TokenFilter>> tokenFilterGroups = SplitAnalysisComponents(index.TokenFilters);
            IEnumerable<IEnumerable<CharFilter>> charFilterGroups = SplitAnalysisComponents(index.CharFilters);

            int biggestGroupSize =
                new[] { analyzerGroups.Count(), tokenizerGroups.Count(), tokenFilterGroups.Count(), charFilterGroups.Count() }.Max();

            if (biggestGroupSize == 1)
            {
                // No splitting necessary; Return the original index.
                yield return index;
                yield break;
            }

            foreach (var analyzers in analyzerGroups)
            {
                Index smallerIndex = CreateTestIndex();
                smallerIndex.Analyzers = analyzers.ToArray();
                yield return smallerIndex;
            }

            foreach (var tokenizers in tokenizerGroups)
            {
                Index smallerIndex = CreateTestIndex();
                smallerIndex.Tokenizers = tokenizers.ToArray();
                yield return smallerIndex;
            }

            foreach (var tokenFilters in tokenFilterGroups)
            {
                Index smallerIndex = CreateTestIndex();
                smallerIndex.TokenFilters = tokenFilters.ToArray();
                yield return smallerIndex;
            }

            foreach (var charFilters in charFilterGroups)
            {
                Index smallerIndex = CreateTestIndex();
                smallerIndex.CharFilters = charFilters.ToArray();
                yield return smallerIndex;
            }
        }

        private static IEnumerable<IEnumerable<T>> SplitAnalysisComponents<T>(IEnumerable<T> components)
        {
            const int AnalysisComponentLimit = 50;

            components = components ?? Enumerable.Empty<T>();
            if (components.Count() <= AnalysisComponentLimit)
            {
                yield return components;
                yield break;
            }

            while (components.Any())
            {
                yield return components.Take(AnalysisComponentLimit);
                components = components.Skip(AnalysisComponentLimit);
            }
        }

        private void TestAnalysisComponents(Index index, Index expectedIndex = null)
        {
            expectedIndex = expectedIndex ?? index;

            SearchServiceClient client = Data.GetSearchServiceClient();

            foreach (var testCase in SplitIndex(index).Zip(SplitIndex(expectedIndex), (i, e) => new { Index = i, ExpectedIndex = e }))
            {
                Index createdIndex = client.Indexes.Create(testCase.Index);

                try
                {
                    AssertAnalysisComponentsEqual(testCase.ExpectedIndex, createdIndex);
                }
                finally
                {
                    client.Indexes.Delete(createdIndex.Name);
                }
            }
        }
    }
}
