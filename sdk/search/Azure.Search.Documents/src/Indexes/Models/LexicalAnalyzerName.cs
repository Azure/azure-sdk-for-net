// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Search.Documents.Indexes.Models
{
    public readonly partial struct LexicalAnalyzerName
    {
#pragma warning disable CA1034 // Nested types should not be visible
        /// <summary>
        /// The values of all declared <see cref="LexicalAnalyzerName"/> properties as string constants.
        /// These can be used in <see cref="SearchableFieldAttribute"/> and anywhere else constants are required.
        /// </summary>
        public static class Values
        {
            /// <summary> Microsoft analyzer for Arabic. </summary>
            public const string ArMicrosoft = LexicalAnalyzerName.ArMicrosoftValue;
            /// <summary> Lucene analyzer for Arabic. </summary>
            public const string ArLucene = LexicalAnalyzerName.ArLuceneValue;
            /// <summary> Lucene analyzer for Armenian. </summary>
            public const string HyLucene = LexicalAnalyzerName.HyLuceneValue;
            /// <summary> Microsoft analyzer for Bangla. </summary>
            public const string BnMicrosoft = LexicalAnalyzerName.BnMicrosoftValue;
            /// <summary> Lucene analyzer for Basque. </summary>
            public const string EuLucene = LexicalAnalyzerName.EuLuceneValue;
            /// <summary> Microsoft analyzer for Bulgarian. </summary>
            public const string BgMicrosoft = LexicalAnalyzerName.BgMicrosoftValue;
            /// <summary> Lucene analyzer for Bulgarian. </summary>
            public const string BgLucene = LexicalAnalyzerName.BgLuceneValue;
            /// <summary> Microsoft analyzer for Catalan. </summary>
            public const string CaMicrosoft = LexicalAnalyzerName.CaMicrosoftValue;
            /// <summary> Lucene analyzer for Catalan. </summary>
            public const string CaLucene = LexicalAnalyzerName.CaLuceneValue;
            /// <summary> Microsoft analyzer for Chinese (Simplified). </summary>
            public const string ZhHansMicrosoft = LexicalAnalyzerName.ZhHansMicrosoftValue;
            /// <summary> Lucene analyzer for Chinese (Simplified). </summary>
            public const string ZhHansLucene = LexicalAnalyzerName.ZhHansLuceneValue;
            /// <summary> Microsoft analyzer for Chinese (Traditional). </summary>
            public const string ZhHantMicrosoft = LexicalAnalyzerName.ZhHantMicrosoftValue;
            /// <summary> Lucene analyzer for Chinese (Traditional). </summary>
            public const string ZhHantLucene = LexicalAnalyzerName.ZhHantLuceneValue;
            /// <summary> Microsoft analyzer for Croatian. </summary>
            public const string HrMicrosoft = LexicalAnalyzerName.HrMicrosoftValue;
            /// <summary> Microsoft analyzer for Czech. </summary>
            public const string CsMicrosoft = LexicalAnalyzerName.CsMicrosoftValue;
            /// <summary> Lucene analyzer for Czech. </summary>
            public const string CsLucene = LexicalAnalyzerName.CsLuceneValue;
            /// <summary> Microsoft analyzer for Danish. </summary>
            public const string DaMicrosoft = LexicalAnalyzerName.DaMicrosoftValue;
            /// <summary> Lucene analyzer for Danish. </summary>
            public const string DaLucene = LexicalAnalyzerName.DaLuceneValue;
            /// <summary> Microsoft analyzer for Dutch. </summary>
            public const string NlMicrosoft = LexicalAnalyzerName.NlMicrosoftValue;
            /// <summary> Lucene analyzer for Dutch. </summary>
            public const string NlLucene = LexicalAnalyzerName.NlLuceneValue;
            /// <summary> Microsoft analyzer for English. </summary>
            public const string EnMicrosoft = LexicalAnalyzerName.EnMicrosoftValue;
            /// <summary> Lucene analyzer for English. </summary>
            public const string EnLucene = LexicalAnalyzerName.EnLuceneValue;
            /// <summary> Microsoft analyzer for Estonian. </summary>
            public const string EtMicrosoft = LexicalAnalyzerName.EtMicrosoftValue;
            /// <summary> Microsoft analyzer for Finnish. </summary>
            public const string FiMicrosoft = LexicalAnalyzerName.FiMicrosoftValue;
            /// <summary> Lucene analyzer for Finnish. </summary>
            public const string FiLucene = LexicalAnalyzerName.FiLuceneValue;
            /// <summary> Microsoft analyzer for French. </summary>
            public const string FrMicrosoft = LexicalAnalyzerName.FrMicrosoftValue;
            /// <summary> Lucene analyzer for French. </summary>
            public const string FrLucene = LexicalAnalyzerName.FrLuceneValue;
            /// <summary> Lucene analyzer for Galician. </summary>
            public const string GlLucene = LexicalAnalyzerName.GlLuceneValue;
            /// <summary> Microsoft analyzer for German. </summary>
            public const string DeMicrosoft = LexicalAnalyzerName.DeMicrosoftValue;
            /// <summary> Lucene analyzer for German. </summary>
            public const string DeLucene = LexicalAnalyzerName.DeLuceneValue;
            /// <summary> Microsoft analyzer for Greek. </summary>
            public const string ElMicrosoft = LexicalAnalyzerName.ElMicrosoftValue;
            /// <summary> Lucene analyzer for Greek. </summary>
            public const string ElLucene = LexicalAnalyzerName.ElLuceneValue;
            /// <summary> Microsoft analyzer for Gujarati. </summary>
            public const string GuMicrosoft = LexicalAnalyzerName.GuMicrosoftValue;
            /// <summary> Microsoft analyzer for Hebrew. </summary>
            public const string HeMicrosoft = LexicalAnalyzerName.HeMicrosoftValue;
            /// <summary> Microsoft analyzer for Hindi. </summary>
            public const string HiMicrosoft = LexicalAnalyzerName.HiMicrosoftValue;
            /// <summary> Lucene analyzer for Hindi. </summary>
            public const string HiLucene = LexicalAnalyzerName.HiLuceneValue;
            /// <summary> Microsoft analyzer for Hungarian. </summary>
            public const string HuMicrosoft = LexicalAnalyzerName.HuMicrosoftValue;
            /// <summary> Lucene analyzer for Hungarian. </summary>
            public const string HuLucene = LexicalAnalyzerName.HuLuceneValue;
            /// <summary> Microsoft analyzer for Icelandic. </summary>
            public const string IsMicrosoft = LexicalAnalyzerName.IsMicrosoftValue;
            /// <summary> Microsoft analyzer for Indonesian (Bahasa). </summary>
            public const string IdMicrosoft = LexicalAnalyzerName.IdMicrosoftValue;
            /// <summary> Lucene analyzer for Indonesian. </summary>
            public const string IdLucene = LexicalAnalyzerName.IdLuceneValue;
            /// <summary> Lucene analyzer for Irish. </summary>
            public const string GaLucene = LexicalAnalyzerName.GaLuceneValue;
            /// <summary> Microsoft analyzer for Italian. </summary>
            public const string ItMicrosoft = LexicalAnalyzerName.ItMicrosoftValue;
            /// <summary> Lucene analyzer for Italian. </summary>
            public const string ItLucene = LexicalAnalyzerName.ItLuceneValue;
            /// <summary> Microsoft analyzer for Japanese. </summary>
            public const string JaMicrosoft = LexicalAnalyzerName.JaMicrosoftValue;
            /// <summary> Lucene analyzer for Japanese. </summary>
            public const string JaLucene = LexicalAnalyzerName.JaLuceneValue;
            /// <summary> Microsoft analyzer for Kannada. </summary>
            public const string KnMicrosoft = LexicalAnalyzerName.KnMicrosoftValue;
            /// <summary> Microsoft analyzer for Korean. </summary>
            public const string KoMicrosoft = LexicalAnalyzerName.KoMicrosoftValue;
            /// <summary> Lucene analyzer for Korean. </summary>
            public const string KoLucene = LexicalAnalyzerName.KoLuceneValue;
            /// <summary> Microsoft analyzer for Latvian. </summary>
            public const string LvMicrosoft = LexicalAnalyzerName.LvMicrosoftValue;
            /// <summary> Lucene analyzer for Latvian. </summary>
            public const string LvLucene = LexicalAnalyzerName.LvLuceneValue;
            /// <summary> Microsoft analyzer for Lithuanian. </summary>
            public const string LtMicrosoft = LexicalAnalyzerName.LtMicrosoftValue;
            /// <summary> Microsoft analyzer for Malayalam. </summary>
            public const string MlMicrosoft = LexicalAnalyzerName.MlMicrosoftValue;
            /// <summary> Microsoft analyzer for Malay (Latin). </summary>
            public const string MsMicrosoft = LexicalAnalyzerName.MsMicrosoftValue;
            /// <summary> Microsoft analyzer for Marathi. </summary>
            public const string MrMicrosoft = LexicalAnalyzerName.MrMicrosoftValue;
            /// <summary> Microsoft analyzer for Norwegian (Bokmål). </summary>
            public const string NbMicrosoft = LexicalAnalyzerName.NbMicrosoftValue;
            /// <summary> Lucene analyzer for Norwegian. </summary>
            public const string NoLucene = LexicalAnalyzerName.NoLuceneValue;
            /// <summary> Lucene analyzer for Persian. </summary>
            public const string FaLucene = LexicalAnalyzerName.FaLuceneValue;
            /// <summary> Microsoft analyzer for Polish. </summary>
            public const string PlMicrosoft = LexicalAnalyzerName.PlMicrosoftValue;
            /// <summary> Lucene analyzer for Polish. </summary>
            public const string PlLucene = LexicalAnalyzerName.PlLuceneValue;
            /// <summary> Microsoft analyzer for Portuguese (Brazil). </summary>
            public const string PtBrMicrosoft = LexicalAnalyzerName.PtBrMicrosoftValue;
            /// <summary> Lucene analyzer for Portuguese (Brazil). </summary>
            public const string PtBrLucene = LexicalAnalyzerName.PtBrLuceneValue;
            /// <summary> Microsoft analyzer for Portuguese (Portugal). </summary>
            public const string PtPtMicrosoft = LexicalAnalyzerName.PtPtMicrosoftValue;
            /// <summary> Lucene analyzer for Portuguese (Portugal). </summary>
            public const string PtPtLucene = LexicalAnalyzerName.PtPtLuceneValue;
            /// <summary> Microsoft analyzer for Punjabi. </summary>
            public const string PaMicrosoft = LexicalAnalyzerName.PaMicrosoftValue;
            /// <summary> Microsoft analyzer for Romanian. </summary>
            public const string RoMicrosoft = LexicalAnalyzerName.RoMicrosoftValue;
            /// <summary> Lucene analyzer for Romanian. </summary>
            public const string RoLucene = LexicalAnalyzerName.RoLuceneValue;
            /// <summary> Microsoft analyzer for Russian. </summary>
            public const string RuMicrosoft = LexicalAnalyzerName.RuMicrosoftValue;
            /// <summary> Lucene analyzer for Russian. </summary>
            public const string RuLucene = LexicalAnalyzerName.RuLuceneValue;
            /// <summary> Microsoft analyzer for Serbian (Cyrillic). </summary>
            public const string SrCyrillicMicrosoft = LexicalAnalyzerName.SrCyrillicMicrosoftValue;
            /// <summary> Microsoft analyzer for Serbian (Latin). </summary>
            public const string SrLatinMicrosoft = LexicalAnalyzerName.SrLatinMicrosoftValue;
            /// <summary> Microsoft analyzer for Slovak. </summary>
            public const string SkMicrosoft = LexicalAnalyzerName.SkMicrosoftValue;
            /// <summary> Microsoft analyzer for Slovenian. </summary>
            public const string SlMicrosoft = LexicalAnalyzerName.SlMicrosoftValue;
            /// <summary> Microsoft analyzer for Spanish. </summary>
            public const string EsMicrosoft = LexicalAnalyzerName.EsMicrosoftValue;
            /// <summary> Lucene analyzer for Spanish. </summary>
            public const string EsLucene = LexicalAnalyzerName.EsLuceneValue;
            /// <summary> Microsoft analyzer for Swedish. </summary>
            public const string SvMicrosoft = LexicalAnalyzerName.SvMicrosoftValue;
            /// <summary> Lucene analyzer for Swedish. </summary>
            public const string SvLucene = LexicalAnalyzerName.SvLuceneValue;
            /// <summary> Microsoft analyzer for Tamil. </summary>
            public const string TaMicrosoft = LexicalAnalyzerName.TaMicrosoftValue;
            /// <summary> Microsoft analyzer for Telugu. </summary>
            public const string TeMicrosoft = LexicalAnalyzerName.TeMicrosoftValue;
            /// <summary> Microsoft analyzer for Thai. </summary>
            public const string ThMicrosoft = LexicalAnalyzerName.ThMicrosoftValue;
            /// <summary> Lucene analyzer for Thai. </summary>
            public const string ThLucene = LexicalAnalyzerName.ThLuceneValue;
            /// <summary> Microsoft analyzer for Turkish. </summary>
            public const string TrMicrosoft = LexicalAnalyzerName.TrMicrosoftValue;
            /// <summary> Lucene analyzer for Turkish. </summary>
            public const string TrLucene = LexicalAnalyzerName.TrLuceneValue;
            /// <summary> Microsoft analyzer for Ukrainian. </summary>
            public const string UkMicrosoft = LexicalAnalyzerName.UkMicrosoftValue;
            /// <summary> Microsoft analyzer for Urdu. </summary>
            public const string UrMicrosoft = LexicalAnalyzerName.UrMicrosoftValue;
            /// <summary> Microsoft analyzer for Vietnamese. </summary>
            public const string ViMicrosoft = LexicalAnalyzerName.ViMicrosoftValue;
            /// <summary> Standard Lucene analyzer. </summary>
            public const string StandardLucene = LexicalAnalyzerName.StandardLuceneValue;
            /// <summary> Standard ASCII Folding Lucene analyzer. See <see href="https://docs.microsoft.com/rest/api/searchservice/Custom-analyzers-in-Azure-Search#Analyzers">Add custom analyzers to string fields in an Azure Cognitive Search index</see>. </summary>
            public const string StandardAsciiFoldingLucene = LexicalAnalyzerName.StandardAsciiFoldingLuceneValue;
            /// <summary> Treats the entire content of a field as a single token. This is useful for data like zip codes, ids, and some product names. See <see href="http://lucene.apache.org/core/4_10_3/analyzers-common/org/apache/lucene/analysis/core/KeywordAnalyzer.html">KeywordAnalyzer (Lucene API)</see>. </summary>
            public const string Keyword = LexicalAnalyzerName.KeywordValue;
            /// <summary> Flexibly separates text into terms via a regular expression pattern. See <see href="http://lucene.apache.org/core/4_10_3/analyzers-common/org/apache/lucene/analysis/miscellaneous/PatternAnalyzer.html">PatternAnalyzer (Lucene API)</see>. </summary>
            public const string Pattern = LexicalAnalyzerName.PatternValue;
            /// <summary> Divides text at non-letters and converts them to lower case. See <see href="http://lucene.apache.org/core/4_10_3/analyzers-common/org/apache/lucene/analysis/core/SimpleAnalyzer.html">SimpleAnalyzer (Lucene API)</see>. </summary>
            public const string Simple = LexicalAnalyzerName.SimpleValue;
            /// <summary> Divides text at non-letters; Applies the lowercase and stopword token filters. See <see href="http://lucene.apache.org/core/4_10_3/analyzers-common/org/apache/lucene/analysis/core/StopAnalyzer.html">StopAnalyzer (Lucene API)</see>. </summary>
            public const string Stop = LexicalAnalyzerName.StopValue;
            /// <summary> An analyzer that uses the whitespace tokenizer. See <see href="http://lucene.apache.org/core/4_10_3/analyzers-common/org/apache/lucene/analysis/core/WhitespaceAnalyzer.html">WhitespaceAnalyzer (Lucene API)</see>. </summary>
            public const string Whitespace = LexicalAnalyzerName.WhitespaceValue;
        }
#pragma warning restore CA1034 // Nested types should not be visible
    }
}
