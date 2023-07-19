// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using System;
    using Microsoft.Azure.Search.Common;
    using Newtonsoft.Json;
    using Serialization;

    /// <summary>
    /// Defines the names of all text analyzers supported by Azure Cognitive Search.
    /// <see href="https://docs.microsoft.com/rest/api/searchservice/Language-support"/>
    /// </summary>
    [JsonConverter(typeof(ExtensibleEnumConverter<AnalyzerName>))]
    public struct AnalyzerName : IEquatable<AnalyzerName>
    {
        private readonly string _value;

        // MAINTENANCE NOTE: Keep the language analyzers ordered the same as the table on this page:
        // https://docs.microsoft.com/rest/api/searchservice/Language-support
        // The other pre-defined analyzers come next, and should be ordered the same as the table on this page:
        // https://docs.microsoft.com/rest/api/searchservice/Custom-analyzers-in-Azure-Search

        /// <summary>
        /// Microsoft analyzer for Arabic.
        /// </summary>
        public static readonly AnalyzerName ArMicrosoft = new AnalyzerName(AsString.ArMicrosoft);

        /// <summary>
        /// Lucene analyzer for Arabic.
        /// </summary>
        public static readonly AnalyzerName ArLucene = new AnalyzerName(AsString.ArLucene);

        /// <summary>
        /// Lucene analyzer for Armenian.
        /// </summary>
        public static readonly AnalyzerName HyLucene = new AnalyzerName(AsString.HyLucene);

        /// <summary>
        /// Microsoft analyzer for Bangla.
        /// </summary>
        public static readonly AnalyzerName BnMicrosoft = new AnalyzerName(AsString.BnMicrosoft);

        /// <summary>
        /// Lucene analyzer for Basque.
        /// </summary>
        public static readonly AnalyzerName EuLucene = new AnalyzerName(AsString.EuLucene);

        /// <summary>
        /// Microsoft analyzer for Bulgarian.
        /// </summary>
        public static readonly AnalyzerName BgMicrosoft = new AnalyzerName(AsString.BgMicrosoft);

        /// <summary>
        /// Lucene analyzer for Bulgarian.
        /// </summary>
        public static readonly AnalyzerName BgLucene = new AnalyzerName(AsString.BgLucene);

        /// <summary>
        /// Microsoft analyzer for Catalan.
        /// </summary>
        public static readonly AnalyzerName CaMicrosoft = new AnalyzerName(AsString.CaMicrosoft);

        /// <summary>
        /// Lucene analyzer for Catalan.
        /// </summary>
        public static readonly AnalyzerName CaLucene = new AnalyzerName(AsString.CaLucene);

        /// <summary>
        /// Microsoft analyzer for Chinese (Simplified).
        /// </summary>
        public static readonly AnalyzerName ZhHansMicrosoft = new AnalyzerName(AsString.ZhHansMicrosoft);

        /// <summary>
        /// Lucene analyzer for Chinese (Simplified).
        /// </summary>
        public static readonly AnalyzerName ZhHansLucene = new AnalyzerName(AsString.ZhHansLucene);

        /// <summary>
        /// Microsoft analyzer for Chinese (Traditional).
        /// </summary>
        public static readonly AnalyzerName ZhHantMicrosoft = new AnalyzerName(AsString.ZhHantMicrosoft);

        /// <summary>
        /// Lucene analyzer for Chinese (Traditional).
        /// </summary>
        public static readonly AnalyzerName ZhHantLucene = new AnalyzerName(AsString.ZhHantLucene);

        /// <summary>
        /// Microsoft analyzer for Croatian.
        /// </summary>
        public static readonly AnalyzerName HrMicrosoft = new AnalyzerName(AsString.HrMicrosoft);

        /// <summary>
        /// Microsoft analyzer for Czech.
        /// </summary>
        public static readonly AnalyzerName CsMicrosoft = new AnalyzerName(AsString.CsMicrosoft);

        /// <summary>
        /// Lucene analyzer for Czech.
        /// </summary>
        public static readonly AnalyzerName CsLucene = new AnalyzerName(AsString.CsLucene);

        /// <summary>
        /// Microsoft analyzer for Danish.
        /// </summary>
        public static readonly AnalyzerName DaMicrosoft = new AnalyzerName(AsString.DaMicrosoft);

        /// <summary>
        /// Lucene analyzer for Danish.
        /// </summary>
        public static readonly AnalyzerName DaLucene = new AnalyzerName(AsString.DaLucene);

        /// <summary>
        /// Microsoft analyzer for Dutch.
        /// </summary>
        public static readonly AnalyzerName NlMicrosoft = new AnalyzerName(AsString.NlMicrosoft);

        /// <summary>
        /// Lucene analyzer for Dutch.
        /// </summary>
        public static readonly AnalyzerName NlLucene = new AnalyzerName(AsString.NlLucene);

        /// <summary>
        /// Microsoft analyzer for English.
        /// </summary>
        public static readonly AnalyzerName EnMicrosoft = new AnalyzerName(AsString.EnMicrosoft);

        /// <summary>
        /// Lucene analyzer for English.
        /// </summary>
        public static readonly AnalyzerName EnLucene = new AnalyzerName(AsString.EnLucene);

        /// <summary>
        /// Microsoft analyzer for Estonian.
        /// </summary>
        public static readonly AnalyzerName EtMicrosoft = new AnalyzerName(AsString.EtMicrosoft);

        /// <summary>
        /// Microsoft analyzer for Finnish.
        /// </summary>
        public static readonly AnalyzerName FiMicrosoft = new AnalyzerName(AsString.FiMicrosoft);

        /// <summary>
        /// Lucene analyzer for Finnish.
        /// </summary>
        public static readonly AnalyzerName FiLucene = new AnalyzerName(AsString.FiLucene);

        /// <summary>
        /// Microsoft analyzer for French.
        /// </summary>
        public static readonly AnalyzerName FrMicrosoft = new AnalyzerName(AsString.FrMicrosoft);

        /// <summary>
        /// Lucene analyzer for French.
        /// </summary>
        public static readonly AnalyzerName FrLucene = new AnalyzerName(AsString.FrLucene);

        /// <summary>
        /// Lucene analyzer for Galician.
        /// </summary>
        public static readonly AnalyzerName GlLucene = new AnalyzerName(AsString.GlLucene);

        /// <summary>
        /// Microsoft analyzer for German.
        /// </summary>
        public static readonly AnalyzerName DeMicrosoft = new AnalyzerName(AsString.DeMicrosoft);

        /// <summary>
        /// Lucene analyzer for German.
        /// </summary>
        public static readonly AnalyzerName DeLucene = new AnalyzerName(AsString.DeLucene);

        /// <summary>
        /// Microsoft analyzer for Greek.
        /// </summary>
        public static readonly AnalyzerName ElMicrosoft = new AnalyzerName(AsString.ElMicrosoft);

        /// <summary>
        /// Lucene analyzer for Greek.
        /// </summary>
        public static readonly AnalyzerName ElLucene = new AnalyzerName(AsString.ElLucene);

        /// <summary>
        /// Microsoft analyzer for Gujarati.
        /// </summary>
        public static readonly AnalyzerName GuMicrosoft = new AnalyzerName(AsString.GuMicrosoft);

        /// <summary>
        /// Microsoft analyzer for Hebrew.
        /// </summary>
        public static readonly AnalyzerName HeMicrosoft = new AnalyzerName(AsString.HeMicrosoft);

        /// <summary>
        /// Microsoft analyzer for Hindi.
        /// </summary>
        public static readonly AnalyzerName HiMicrosoft = new AnalyzerName(AsString.HiMicrosoft);

        /// <summary>
        /// Lucene analyzer for Hindi.
        /// </summary>
        public static readonly AnalyzerName HiLucene = new AnalyzerName(AsString.HiLucene);

        /// <summary>
        /// Microsoft analyzer for Hungarian.
        /// </summary>
        public static readonly AnalyzerName HuMicrosoft = new AnalyzerName(AsString.HuMicrosoft);

        /// <summary>
        /// Lucene analyzer for Hungarian.
        /// </summary>
        public static readonly AnalyzerName HuLucene = new AnalyzerName(AsString.HuLucene);

        /// <summary>
        /// Microsoft analyzer for Icelandic.
        /// </summary>
        public static readonly AnalyzerName IsMicrosoft = new AnalyzerName(AsString.IsMicrosoft);

        /// <summary>
        /// Microsoft analyzer for Indonesian (Bahasa).
        /// </summary>
        public static readonly AnalyzerName IdMicrosoft = new AnalyzerName(AsString.IdMicrosoft);

        /// <summary>
        /// Lucene analyzer for Indonesian.
        /// </summary>
        public static readonly AnalyzerName IdLucene = new AnalyzerName(AsString.IdLucene);

        /// <summary>
        /// Lucene analyzer for Irish.
        /// </summary>
        public static readonly AnalyzerName GaLucene = new AnalyzerName(AsString.GaLucene);

        /// <summary>
        /// Microsoft analyzer for Italian.
        /// </summary>
        public static readonly AnalyzerName ItMicrosoft = new AnalyzerName(AsString.ItMicrosoft);

        /// <summary>
        /// Lucene analyzer for Italian.
        /// </summary>
        public static readonly AnalyzerName ItLucene = new AnalyzerName(AsString.ItLucene);

        /// <summary>
        /// Microsoft analyzer for Japanese.
        /// </summary>
        public static readonly AnalyzerName JaMicrosoft = new AnalyzerName(AsString.JaMicrosoft);

        /// <summary>
        /// Lucene analyzer for Japanese.
        /// </summary>
        public static readonly AnalyzerName JaLucene = new AnalyzerName(AsString.JaLucene);

        /// <summary>
        /// Microsoft analyzer for Kannada.
        /// </summary>
        public static readonly AnalyzerName KnMicrosoft = new AnalyzerName(AsString.KnMicrosoft);

        /// <summary>
        /// Microsoft analyzer for Korean.
        /// </summary>
        public static readonly AnalyzerName KoMicrosoft = new AnalyzerName(AsString.KoMicrosoft);

        /// <summary>
        /// Lucene analyzer for Korean.
        /// </summary>
        public static readonly AnalyzerName KoLucene = new AnalyzerName(AsString.KoLucene);

        /// <summary>
        /// Microsoft analyzer for Latvian.
        /// </summary>
        public static readonly AnalyzerName LvMicrosoft = new AnalyzerName(AsString.LvMicrosoft);

        /// <summary>
        /// Lucene analyzer for Latvian.
        /// </summary>
        public static readonly AnalyzerName LvLucene = new AnalyzerName(AsString.LvLucene);

        /// <summary>
        /// Microsoft analyzer for Lithuanian.
        /// </summary>
        public static readonly AnalyzerName LtMicrosoft = new AnalyzerName(AsString.LtMicrosoft);

        /// <summary>
        /// Microsoft analyzer for Malayalam.
        /// </summary>
        public static readonly AnalyzerName MlMicrosoft = new AnalyzerName(AsString.MlMicrosoft);

        /// <summary>
        /// Microsoft analyzer for Malay (Latin).
        /// </summary>
        public static readonly AnalyzerName MsMicrosoft = new AnalyzerName(AsString.MsMicrosoft);

        /// <summary>
        /// Microsoft analyzer for Marathi.
        /// </summary>
        public static readonly AnalyzerName MrMicrosoft = new AnalyzerName(AsString.MrMicrosoft);

        /// <summary>
        /// Microsoft analyzer for Norwegian (Bokmål).
        /// </summary>
        public static readonly AnalyzerName NbMicrosoft = new AnalyzerName(AsString.NbMicrosoft);

        /// <summary>
        /// Lucene analyzer for Norwegian.
        /// </summary>
        public static readonly AnalyzerName NoLucene = new AnalyzerName(AsString.NoLucene);

        /// <summary>
        /// Lucene analyzer for Persian.
        /// </summary>
        public static readonly AnalyzerName FaLucene = new AnalyzerName(AsString.FaLucene);

        /// <summary>
        /// Microsoft analyzer for Polish.
        /// </summary>
        public static readonly AnalyzerName PlMicrosoft = new AnalyzerName(AsString.PlMicrosoft);

        /// <summary>
        /// Lucene analyzer for Polish.
        /// </summary>
        public static readonly AnalyzerName PlLucene = new AnalyzerName(AsString.PlLucene);

        /// <summary>
        /// Microsoft analyzer for Portuguese (Brazil).
        /// </summary>        
        public static readonly AnalyzerName PtBrMicrosoft = new AnalyzerName(AsString.PtBrMicrosoft);

        /// <summary>
        /// Lucene analyzer for Portuguese (Brazil).
        /// </summary>
        public static readonly AnalyzerName PtBRLucene = new AnalyzerName(AsString.PtBRLucene);

        /// <summary>
        /// Microsoft analyzer for Portuguese (Portugal).
        /// </summary>
        public static readonly AnalyzerName PtPtMicrosoft = new AnalyzerName(AsString.PtPtMicrosoft);

        /// <summary>
        /// Lucene analyzer for Portuguese (Portugal).
        /// </summary>
        public static readonly AnalyzerName PtPTLucene = new AnalyzerName(AsString.PtPTLucene);

        /// <summary>
        /// Microsoft analyzer for Punjabi.
        /// </summary>
        public static readonly AnalyzerName PaMicrosoft = new AnalyzerName(AsString.PaMicrosoft);

        /// <summary>
        /// Microsoft analyzer for Romanian.
        /// </summary>
        public static readonly AnalyzerName RoMicrosoft = new AnalyzerName(AsString.RoMicrosoft);

        /// <summary>
        /// Lucene analyzer for Romanian.
        /// </summary>
        public static readonly AnalyzerName RoLucene = new AnalyzerName(AsString.RoLucene);

        /// <summary>
        /// Microsoft analyzer for Russian.
        /// </summary>
        public static readonly AnalyzerName RuMicrosoft = new AnalyzerName(AsString.RuMicrosoft);

        /// <summary>
        /// Lucene analyzer for Russian.
        /// </summary>
        public static readonly AnalyzerName RuLucene = new AnalyzerName(AsString.RuLucene);

        /// <summary>
        /// Microsoft analyzer for Serbian (Cyrillic).
        /// </summary>
        public static readonly AnalyzerName SrCyrillicMicrosoft = new AnalyzerName(AsString.SrCyrillicMicrosoft);

        /// <summary>
        /// Microsoft analyzer for Serbian (Latin).
        /// </summary>
        public static readonly AnalyzerName SrLatinMicrosoft = new AnalyzerName(AsString.SrLatinMicrosoft);

        /// <summary>
        /// Microsoft analyzer for Slovak.
        /// </summary>
        public static readonly AnalyzerName SkMicrosoft = new AnalyzerName(AsString.SkMicrosoft);

        /// <summary>
        /// Microsoft analyzer for Slovenian.
        /// </summary>
        public static readonly AnalyzerName SlMicrosoft = new AnalyzerName(AsString.SlMicrosoft);

        /// <summary>
        /// Microsoft analyzer for Spanish.
        /// </summary>
        public static readonly AnalyzerName EsMicrosoft = new AnalyzerName(AsString.EsMicrosoft);

        /// <summary>
        /// Lucene analyzer for Spanish.
        /// </summary>
        public static readonly AnalyzerName EsLucene = new AnalyzerName(AsString.EsLucene);

        /// <summary>
        /// Microsoft analyzer for Swedish.
        /// </summary>
        public static readonly AnalyzerName SvMicrosoft = new AnalyzerName(AsString.SvMicrosoft);

        /// <summary>
        /// Lucene analyzer for Swedish.
        /// </summary>
        public static readonly AnalyzerName SvLucene = new AnalyzerName(AsString.SvLucene);

        /// <summary>
        /// Microsoft analyzer for Tamil.
        /// </summary>
        public static readonly AnalyzerName TaMicrosoft = new AnalyzerName(AsString.TaMicrosoft);

        /// <summary>
        /// Microsoft analyzer for Telugu.
        /// </summary>
        public static readonly AnalyzerName TeMicrosoft = new AnalyzerName(AsString.TeMicrosoft);

        /// <summary>
        /// Microsoft analyzer for Thai.
        /// </summary>
        public static readonly AnalyzerName ThMicrosoft = new AnalyzerName(AsString.ThMicrosoft);

        /// <summary>
        /// Lucene analyzer for Thai.
        /// </summary>
        public static readonly AnalyzerName ThLucene = new AnalyzerName(AsString.ThLucene);

        /// <summary>
        /// Microsoft analyzer for Turkish.
        /// </summary>
        public static readonly AnalyzerName TrMicrosoft = new AnalyzerName(AsString.TrMicrosoft);

        /// <summary>
        /// Lucene analyzer for Turkish.
        /// </summary>
        public static readonly AnalyzerName TrLucene = new AnalyzerName(AsString.TrLucene);

        /// <summary>
        /// Microsoft analyzer for Ukranian.
        /// </summary>
        public static readonly AnalyzerName UkMicrosoft = new AnalyzerName(AsString.UkMicrosoft);

        /// <summary>
        /// Microsoft analyzer for Urdu.
        /// </summary>
        public static readonly AnalyzerName UrMicrosoft = new AnalyzerName(AsString.UrMicrosoft);

        /// <summary>
        /// Microsoft analyzer for Vietnamese.
        /// </summary>
        public static readonly AnalyzerName ViMicrosoft = new AnalyzerName(AsString.ViMicrosoft);

        /// <summary>
        /// Standard Lucene analyzer.
        /// </summary>
        public static readonly AnalyzerName StandardLucene = new AnalyzerName(AsString.StandardLucene);

        /// <summary>
        /// Standard ASCII Folding Lucene analyzer.
        /// <see href="https://docs.microsoft.com/rest/api/searchservice/Custom-analyzers-in-Azure-Search#Analyzers" /> 
        /// </summary>
        public static readonly AnalyzerName StandardAsciiFoldingLucene =
            new AnalyzerName(AsString.StandardAsciiFoldingLucene);

        /// <summary>
        /// Treats the entire content of a field as a single token. This is useful
        /// for data like zip codes, ids, and some product names.
        /// <see href="http://lucene.apache.org/core/4_10_3/analyzers-common/org/apache/lucene/analysis/core/KeywordAnalyzer.html" />
        /// </summary>
        public static readonly AnalyzerName Keyword = new AnalyzerName(AsString.Keyword);

        /// <summary>
        /// Flexibly separates text into terms via a regular expression pattern.
        /// <see href="http://lucene.apache.org/core/4_10_3/analyzers-common/org/apache/lucene/analysis/miscellaneous/PatternAnalyzer.html" />
        /// </summary>
        public static readonly AnalyzerName Pattern = new AnalyzerName(AsString.Pattern);

        /// <summary>
        /// Divides text at non-letters and converts them to lower case.
        /// <see href="http://lucene.apache.org/core/4_10_3/analyzers-common/org/apache/lucene/analysis/core/SimpleAnalyzer.html" />
        /// </summary>
        public static readonly AnalyzerName Simple = new AnalyzerName(AsString.Simple);

        /// <summary>
        /// Divides text at non-letters; Applies the lowercase and stopword token filters.
        /// <see href="http://lucene.apache.org/core/4_10_3/analyzers-common/org/apache/lucene/analysis/core/StopAnalyzer.html" />
        /// </summary>
        public static readonly AnalyzerName Stop = new AnalyzerName(AsString.Stop);

        /// <summary>
        /// An analyzer that uses the whitespace tokenizer.
        /// <see href="http://lucene.apache.org/core/4_10_3/analyzers-common/org/apache/lucene/analysis/core/WhitespaceAnalyzer.html" />
        /// </summary>
        public static readonly AnalyzerName Whitespace = new AnalyzerName(AsString.Whitespace);

        /// <summary>
        /// The names of all of the analyzers as plain strings.
        /// </summary>
        /// <remarks>
        /// When defining an index with an attributed model, you need to specify analyzers by name, because
        /// .NET custom attributes cannot be constructed with a reference to a static field. (Only constant
        /// values from a limited range of types are supported.)
        /// </remarks>
        public static class AsString
        {
            /// <summary>
            /// Microsoft analyzer for Arabic.
            /// </summary>
            public const string ArMicrosoft = "ar.microsoft";

            /// <summary>
            /// Lucene analyzer for Arabic.
            /// </summary>
            public const string ArLucene = "ar.lucene";

            /// <summary>
            /// Lucene analyzer for Armenian.
            /// </summary>
            public const string HyLucene = "hy.lucene";

            /// <summary>
            /// Microsoft analyzer for Bangla.
            /// </summary>
            public const string BnMicrosoft = "bn.microsoft";

            /// <summary>
            /// Lucene analyzer for Basque.
            /// </summary>
            public const string EuLucene = "eu.lucene";

            /// <summary>
            /// Microsoft analyzer for Bulgarian.
            /// </summary>
            public const string BgMicrosoft = "bg.microsoft";

            /// <summary>
            /// Lucene analyzer for Bulgarian.
            /// </summary>
            public const string BgLucene = "bg.lucene";

            /// <summary>
            /// Microsoft analyzer for Catalan.
            /// </summary>
            public const string CaMicrosoft = "ca.microsoft";

            /// <summary>
            /// Lucene analyzer for Catalan.
            /// </summary>
            public const string CaLucene = "ca.lucene";

            /// <summary>
            /// Microsoft analyzer for Chinese (Simplified).
            /// </summary>
            public const string ZhHansMicrosoft = "zh-Hans.microsoft";

            /// <summary>
            /// Lucene analyzer for Chinese (Simplified).
            /// </summary>
            public const string ZhHansLucene = "zh-Hans.lucene";

            /// <summary>
            /// Microsoft analyzer for Chinese (Traditional).
            /// </summary>
            public const string ZhHantMicrosoft = "zh-Hant.microsoft";

            /// <summary>
            /// Lucene analyzer for Chinese (Traditional).
            /// </summary>
            public const string ZhHantLucene = "zh-Hant.lucene";

            /// <summary>
            /// Microsoft analyzer for Croatian.
            /// </summary>
            public const string HrMicrosoft = "hr.microsoft";

            /// <summary>
            /// Microsoft analyzer for Czech.
            /// </summary>
            public const string CsMicrosoft = "cs.microsoft";

            /// <summary>
            /// Lucene analyzer for Czech.
            /// </summary>
            public const string CsLucene = "cs.lucene";

            /// <summary>
            /// Microsoft analyzer for Danish.
            /// </summary>
            public const string DaMicrosoft = "da.microsoft";

            /// <summary>
            /// Lucene analyzer for Danish.
            /// </summary>
            public const string DaLucene = "da.lucene";

            /// <summary>
            /// Microsoft analyzer for Dutch.
            /// </summary>
            public const string NlMicrosoft = "nl.microsoft";

            /// <summary>
            /// Lucene analyzer for Dutch.
            /// </summary>
            public const string NlLucene = "nl.lucene";

            /// <summary>
            /// Microsoft analyzer for English.
            /// </summary>
            public const string EnMicrosoft = "en.microsoft";

            /// <summary>
            /// Lucene analyzer for English.
            /// </summary>
            public const string EnLucene = "en.lucene";

            /// <summary>
            /// Microsoft analyzer for Estonian.
            /// </summary>
            public const string EtMicrosoft = "et.microsoft";

            /// <summary>
            /// Microsoft analyzer for Finnish.
            /// </summary>
            public const string FiMicrosoft = "fi.microsoft";

            /// <summary>
            /// Lucene analyzer for Finnish.
            /// </summary>
            public const string FiLucene = "fi.lucene";

            /// <summary>
            /// Microsoft analyzer for French.
            /// </summary>
            public const string FrMicrosoft = "fr.microsoft";

            /// <summary>
            /// Lucene analyzer for French.
            /// </summary>
            public const string FrLucene = "fr.lucene";

            /// <summary>
            /// Lucene analyzer for Galician.
            /// </summary>
            public const string GlLucene = "gl.lucene";

            /// <summary>
            /// Microsoft analyzer for German.
            /// </summary>
            public const string DeMicrosoft = "de.microsoft";

            /// <summary>
            /// Lucene analyzer for German.
            /// </summary>
            public const string DeLucene = "de.lucene";

            /// <summary>
            /// Microsoft analyzer for Greek.
            /// </summary>
            public const string ElMicrosoft = "el.microsoft";

            /// <summary>
            /// Lucene analyzer for Greek.
            /// </summary>
            public const string ElLucene = "el.lucene";

            /// <summary>
            /// Microsoft analyzer for Gujarati.
            /// </summary>
            public const string GuMicrosoft = "gu.microsoft";

            /// <summary>
            /// Microsoft analyzer for Hebrew.
            /// </summary>
            public const string HeMicrosoft = "he.microsoft";

            /// <summary>
            /// Microsoft analyzer for Hindi.
            /// </summary>
            public const string HiMicrosoft = "hi.microsoft";

            /// <summary>
            /// Lucene analyzer for Hindi.
            /// </summary>
            public const string HiLucene = "hi.lucene";

            /// <summary>
            /// Microsoft analyzer for Hungarian.
            /// </summary>
            public const string HuMicrosoft = "hu.microsoft";

            /// <summary>
            /// Lucene analyzer for Hungarian.
            /// </summary>
            public const string HuLucene = "hu.lucene";

            /// <summary>
            /// Microsoft analyzer for Icelandic.
            /// </summary>
            public const string IsMicrosoft = "is.microsoft";

            /// <summary>
            /// Microsoft analyzer for Indonesian (Bahasa).
            /// </summary>
            public const string IdMicrosoft = "id.microsoft";

            /// <summary>
            /// Lucene analyzer for Indonesian.
            /// </summary>
            public const string IdLucene = "id.lucene";

            /// <summary>
            /// Lucene analyzer for Irish.
            /// </summary>
            public const string GaLucene = "ga.lucene";

            /// <summary>
            /// Microsoft analyzer for Italian.
            /// </summary>
            public const string ItMicrosoft = "it.microsoft";

            /// <summary>
            /// Lucene analyzer for Italian.
            /// </summary>
            public const string ItLucene = "it.lucene";

            /// <summary>
            /// Microsoft analyzer for Japanese.
            /// </summary>
            public const string JaMicrosoft = "ja.microsoft";

            /// <summary>
            /// Lucene analyzer for Japanese.
            /// </summary>
            public const string JaLucene = "ja.lucene";

            /// <summary>
            /// Microsoft analyzer for Kannada.
            /// </summary>
            public const string KnMicrosoft = "kn.microsoft";

            /// <summary>
            /// Microsoft analyzer for Korean.
            /// </summary>
            public const string KoMicrosoft = "ko.microsoft";

            /// <summary>
            /// Lucene analyzer for Korean.
            /// </summary>
            public const string KoLucene = "ko.lucene";

            /// <summary>
            /// Microsoft analyzer for Latvian.
            /// </summary>
            public const string LvMicrosoft = "lv.microsoft";

            /// <summary>
            /// Lucene analyzer for Latvian.
            /// </summary>
            public const string LvLucene = "lv.lucene";

            /// <summary>
            /// Microsoft analyzer for Lithuanian.
            /// </summary>
            public const string LtMicrosoft = "lt.microsoft";

            /// <summary>
            /// Microsoft analyzer for Malayalam.
            /// </summary>
            public const string MlMicrosoft = "ml.microsoft";

            /// <summary>
            /// Microsoft analyzer for Malay (Latin).
            /// </summary>
            public const string MsMicrosoft = "ms.microsoft";

            /// <summary>
            /// Microsoft analyzer for Marathi.
            /// </summary>
            public const string MrMicrosoft = "mr.microsoft";

            /// <summary>
            /// Microsoft analyzer for Norwegian (Bokmål).
            /// </summary>
            public const string NbMicrosoft = "nb.microsoft";

            /// <summary>
            /// Lucene analyzer for Norwegian.
            /// </summary>
            public const string NoLucene = "no.lucene";

            /// <summary>
            /// Lucene analyzer for Persian.
            /// </summary>
            public const string FaLucene = "fa.lucene";

            /// <summary>
            /// Microsoft analyzer for Polish.
            /// </summary>
            public const string PlMicrosoft = "pl.microsoft";

            /// <summary>
            /// Lucene analyzer for Polish.
            /// </summary>
            public const string PlLucene = "pl.lucene";

            /// <summary>
            /// Microsoft analyzer for Portuguese (Brazil).
            /// </summary>        
            public const string PtBrMicrosoft = "pt-BR.microsoft";

            /// <summary>
            /// Lucene analyzer for Portuguese (Brazil).
            /// </summary>
            public const string PtBRLucene = "pt-BR.lucene";

            /// <summary>
            /// Microsoft analyzer for Portuguese (Portugal).
            /// </summary>
            public const string PtPtMicrosoft = "pt-PT.microsoft";

            /// <summary>
            /// Lucene analyzer for Portuguese (Portugal).
            /// </summary>
            public const string PtPTLucene = "pt-PT.lucene";

            /// <summary>
            /// Microsoft analyzer for Punjabi.
            /// </summary>
            public const string PaMicrosoft = "pa.microsoft";

            /// <summary>
            /// Microsoft analyzer for Romanian.
            /// </summary>
            public const string RoMicrosoft = "ro.microsoft";

            /// <summary>
            /// Lucene analyzer for Romanian.
            /// </summary>
            public const string RoLucene = "ro.lucene";

            /// <summary>
            /// Microsoft analyzer for Russian.
            /// </summary>
            public const string RuMicrosoft = "ru.microsoft";

            /// <summary>
            /// Lucene analyzer for Russian.
            /// </summary>
            public const string RuLucene = "ru.lucene";

            /// <summary>
            /// Microsoft analyzer for Serbian (Cyrillic).
            /// </summary>
            public const string SrCyrillicMicrosoft = "sr-cyrillic.microsoft";

            /// <summary>
            /// Microsoft analyzer for Serbian (Latin).
            /// </summary>
            public const string SrLatinMicrosoft = "sr-latin.microsoft";

            /// <summary>
            /// Microsoft analyzer for Slovak.
            /// </summary>
            public const string SkMicrosoft = "sk.microsoft";

            /// <summary>
            /// Microsoft analyzer for Slovenian.
            /// </summary>
            public const string SlMicrosoft = "sl.microsoft";

            /// <summary>
            /// Microsoft analyzer for Spanish.
            /// </summary>
            public const string EsMicrosoft = "es.microsoft";

            /// <summary>
            /// Lucene analyzer for Spanish.
            /// </summary>
            public const string EsLucene = "es.lucene";

            /// <summary>
            /// Microsoft analyzer for Swedish.
            /// </summary>
            public const string SvMicrosoft = "sv.microsoft";

            /// <summary>
            /// Lucene analyzer for Swedish.
            /// </summary>
            public const string SvLucene = "sv.lucene";

            /// <summary>
            /// Microsoft analyzer for Tamil.
            /// </summary>
            public const string TaMicrosoft = "ta.microsoft";

            /// <summary>
            /// Microsoft analyzer for Telugu.
            /// </summary>
            public const string TeMicrosoft = "te.microsoft";

            /// <summary>
            /// Microsoft analyzer for Thai.
            /// </summary>
            public const string ThMicrosoft = "th.microsoft";

            /// <summary>
            /// Lucene analyzer for Thai.
            /// </summary>
            public const string ThLucene = "th.lucene";

            /// <summary>
            /// Microsoft analyzer for Turkish.
            /// </summary>
            public const string TrMicrosoft = "tr.microsoft";

            /// <summary>
            /// Lucene analyzer for Turkish.
            /// </summary>
            public const string TrLucene = "tr.lucene";

            /// <summary>
            /// Microsoft analyzer for Ukranian.
            /// </summary>
            public const string UkMicrosoft = "uk.microsoft";

            /// <summary>
            /// Microsoft analyzer for Urdu.
            /// </summary>
            public const string UrMicrosoft = "ur.microsoft";

            /// <summary>
            /// Microsoft analyzer for Vietnamese.
            /// </summary>
            public const string ViMicrosoft = "vi.microsoft";

            /// <summary>
            /// Standard Lucene analyzer.
            /// </summary>
            public const string StandardLucene = "standard.lucene";

            /// <summary>
            /// Standard ASCII Folding Lucene analyzer.
            /// <see href="https://docs.microsoft.com/rest/api/searchservice/Custom-analyzers-in-Azure-Search#Analyzers" /> 
            /// </summary>
            public const string StandardAsciiFoldingLucene = "standardasciifolding.lucene";

            /// <summary>
            /// Treats the entire content of a field as a single token. This is useful
            /// for data like zip codes, ids, and some product names.
            /// <see href="http://lucene.apache.org/core/4_10_3/analyzers-common/org/apache/lucene/analysis/core/KeywordAnalyzer.html" />
            /// </summary>
            public const string Keyword = "keyword";

            /// <summary>
            /// Flexibly separates text into terms via a regular expression pattern.
            /// <see href="http://lucene.apache.org/core/4_10_3/analyzers-common/org/apache/lucene/analysis/miscellaneous/PatternAnalyzer.html" />
            /// </summary>
            public const string Pattern = "pattern";

            /// <summary>
            /// Divides text at non-letters and converts them to lower case.
            /// <see href="http://lucene.apache.org/core/4_10_3/analyzers-common/org/apache/lucene/analysis/core/SimpleAnalyzer.html" />
            /// </summary>
            public const string Simple = "simple";

            /// <summary>
            /// Divides text at non-letters; Applies the lowercase and stopword token filters.
            /// <see href="http://lucene.apache.org/core/4_10_3/analyzers-common/org/apache/lucene/analysis/core/StopAnalyzer.html" />
            /// </summary>
            public const string Stop = "stop";

            /// <summary>
            /// An analyzer that uses the whitespace tokenizer.
            /// <see href="http://lucene.apache.org/core/4_10_3/analyzers-common/org/apache/lucene/analysis/core/WhitespaceAnalyzer.html" />
            /// </summary>
            public const string Whitespace = "whitespace";
        }

        private AnalyzerName(string name)
        {
            Throw.IfArgumentNull(name, nameof(name));
            _value = name;
        }

        /// <summary>
        /// Defines implicit conversion from string to AnalyzerName.
        /// </summary>
        /// <param name="value">string to convert.</param>
        /// <returns>The string as an AnalyzerName.</returns>
        public static implicit operator AnalyzerName(string value) => new AnalyzerName(value);

        /// <summary>
        /// Defines explicit conversion from AnalyzerName to string.
        /// </summary>
        /// <param name="name">AnalyzerName to convert.</param>
        /// <returns>The AnalyzerName as a string.</returns>
        public static explicit operator string(AnalyzerName name) => name.ToString();

        /// <summary>
        /// Compares two AnalyzerName values for equality.
        /// </summary>
        /// <param name="lhs">The first AnalyzerName to compare.</param>
        /// <param name="rhs">The second AnalyzerName to compare.</param>
        /// <returns>true if the AnalyzerName objects are equal or are both null; false otherwise.</returns>
        public static bool operator ==(AnalyzerName lhs, AnalyzerName rhs) => Equals(lhs, rhs);

        /// <summary>
        /// Compares two AnalyzerName values for inequality.
        /// </summary>
        /// <param name="lhs">The first AnalyzerName to compare.</param>
        /// <param name="rhs">The second AnalyzerName to compare.</param>
        /// <returns>true if the AnalyzerName objects are not equal; false otherwise.</returns>
        public static bool operator !=(AnalyzerName lhs, AnalyzerName rhs) => !Equals(lhs, rhs);

        /// <summary>
        /// Compares the AnalyzerName for equality with another AnalyzerName.
        /// </summary>
        /// <param name="other">The AnalyzerName with which to compare.</param>
        /// <returns><c>true</c> if the AnalyzerName objects are equal; otherwise, <c>false</c>.</returns>
        public bool Equals(AnalyzerName other) => _value == other._value;

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><c>true</c> if the specified object is equal to the current object; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj) => obj is AnalyzerName ? Equals((AnalyzerName)obj) : false;

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode() => _value.GetHashCode();

        /// <summary>
        /// Returns a string representation of the AnalyzerName.
        /// </summary>
        /// <returns>The AnalyzerName as a string.</returns>
        public override string ToString() => _value;
    }
}
