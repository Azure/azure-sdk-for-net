// 
// Copyright (c) Microsoft.  All rights reserved. 
// 
// Licensed under the Apache License, Version 2.0 (the "License"); 
// you may not use this file except in compliance with the License. 
// You may obtain a copy of the License at 
//   http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software 
// distributed under the License is distributed on an "AS IS" BASIS, 
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
// See the License for the specific language governing permissions and 
// limitations under the License. 
// 

using System;

namespace Microsoft.Azure.Search.Models
{
    /// <summary>
    /// Defines the names of all text analyzers supported by Azure Search.
    /// <see href="https://msdn.microsoft.com/library/azure/dn879793.aspx"/>
    /// </summary>
    public sealed class AnalyzerName
    {
        /// <summary>
        /// Lucene analyzer for Arabic.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item>
        /// <description>Implements Arabic orthographic normalization</description>
        /// </item>
        /// <item>
        /// <description>Applies light algorithmic stemming</description>
        /// </item>
        /// <item>
        /// <description>Filters out Arabic stop words</description>
        /// </item>
        /// </list>
        /// </remarks>
        public static readonly AnalyzerName ArLucene = new AnalyzerName("ar.lucene");

        /// <summary>
        /// Lucene analyzer for Czech.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item>
        /// <description>Applies light stemming</description>
        /// </item>
        /// <item>
        /// <description>Filters out Czech stop words</description>
        /// </item>
        /// </list>
        /// </remarks>
        public static readonly AnalyzerName CsLucene = new AnalyzerName("cs.lucene");

        /// <summary>
        /// Lucene analyzer for Danish.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item>
        /// <description>Applies light stemming</description>
        /// </item>
        /// <item>
        /// <description>Filters out Danish stop words</description>
        /// </item>
        /// </list>
        /// </remarks>
        public static readonly AnalyzerName DaLucene = new AnalyzerName("da.lucene");

        /// <summary>
        /// Lucene analyzer for German.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item>
        /// <description>Applies light stemming</description>
        /// </item>
        /// <item>
        /// <description>Filters out German stop words</description>
        /// </item>
        /// </list>
        /// </remarks>
        public static readonly AnalyzerName DeLucene = new AnalyzerName("de.lucene");

        /// <summary>
        /// Lucene analyzer for Greek.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item>
        /// <description>Applies light stemming</description>
        /// </item>
        /// <item>
        /// <description>Filters out Greek stop words</description>
        /// </item>
        /// </list>
        /// </remarks>
        public static readonly AnalyzerName ElLucene = new AnalyzerName("el.lucene");

        /// <summary>
        /// Lucene analyzer for English.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item>
        /// <description>Applies light stemming</description>
        /// </item>
        /// <item>
        /// <description>Filters out English stop words</description>
        /// </item>
        /// <item>
        /// <description>Removes possessives</description>
        /// </item>
        /// </list>
        /// </remarks>
        public static readonly AnalyzerName EnLucene = new AnalyzerName("en.lucene");

        /// <summary>
        /// Lucene analyzer for Spanish.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item>
        /// <description>Applies light stemming</description>
        /// </item>
        /// <item>
        /// <description>Filters out Spanish stop words</description>
        /// </item>
        /// </list>
        /// </remarks>
        public static readonly AnalyzerName EsLucene = new AnalyzerName("es.lucene");

        /// <summary>
        /// Lucene analyzer for Finnish.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item>
        /// <description>Applies light stemming</description>
        /// </item>
        /// <item>
        /// <description>Filters out Finnish stop words</description>
        /// </item>
        /// </list>
        /// </remarks>
        public static readonly AnalyzerName FiLucene = new AnalyzerName("fi.lucene");

        /// <summary>
        /// Lucene analyzer for French.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item>
        /// <description>Applies light stemming</description>
        /// </item>
        /// <item>
        /// <description>Filters out French stop words</description>
        /// </item>
        /// <item>
        /// <description>Removes ellisions</description>
        /// </item>
        /// </list>
        /// </remarks>
        public static readonly AnalyzerName FrLucene = new AnalyzerName("fr.lucene");

        /// <summary>
        /// Lucene analyzer for Hindi.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item>
        /// <description>Applies light stemming</description>
        /// </item>
        /// <item>
        /// <description>Filters out Hindi stop words</description>
        /// </item>
        /// <item>
        /// <description>Removes some differences in spelling variations</description>
        /// </item>
        /// <item>
        /// <description>Normalizes the Unicode representation of text in Indian languages</description>
        /// </item>
        /// </list>
        /// </remarks>
        public static readonly AnalyzerName HiLucene = new AnalyzerName("hi.lucene");

        /// <summary>
        /// Lucene analyzer for Hungarian.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item>
        /// <description>Applies light stemming</description>
        /// </item>
        /// <item>
        /// <description>Filters out Hungarian stop words</description>
        /// </item>
        /// </list>
        /// </remarks>
        public static readonly AnalyzerName HuLucene = new AnalyzerName("hu.lucene");

        /// <summary>
        /// Lucene analyzer for Indonesian.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item>
        /// <description>Applies light stemming</description>
        /// </item>
        /// <item>
        /// <description>Filters out Indonesian stop words</description>
        /// </item>
        /// </list>
        /// </remarks>
        public static readonly AnalyzerName IdLucene = new AnalyzerName("id.lucene");

        /// <summary>
        /// Lucene analyzer for Italian.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item>
        /// <description>Applies light stemming</description>
        /// </item>
        /// <item>
        /// <description>Filters out Italian stop words</description>
        /// </item>
        /// <item>
        /// <description>Removes ellisions</description>
        /// </item>
        /// </list>
        /// </remarks>
        public static readonly AnalyzerName ItLucene = new AnalyzerName("it.lucene");

        /// <summary>
        /// Lucene analyzer for Japanese.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item>
        /// <description>Uses morphological analysis</description>
        /// </item>
        /// <item>
        /// <description>Normalizes common katakana spelling variations</description>
        /// </item>
        /// <item>
        /// <description>Light stopwords/stoptags removal</description>
        /// </item>
        /// <item>
        /// <description>Character width-normalization</description>
        /// </item>
        /// <item>
        /// <description>Lemmatization - reduces inflected adjectives and verbs to their base form</description>
        /// </item>
        /// </list>
        /// </remarks>
        public static readonly AnalyzerName JaLucene = new AnalyzerName("ja.lucene");

        /// <summary>
        /// Lucene analyzer for Korean.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item>
        /// <description>Indexes bigrams (overlapping groups of two adjacent Hangul characters)</description>
        /// </item>
        /// <item>
        /// <description>Normalizes character width differences</description>
        /// </item>
        /// </list>
        /// </remarks>
        public static readonly AnalyzerName KoLucene = new AnalyzerName("ko.lucene");

        /// <summary>
        /// Lucene analyzer for Latvian.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item>
        /// <description>Applies light stemming</description>
        /// </item>
        /// <item>
        /// <description>Filters out Latvian stop words</description>
        /// </item>
        /// </list>
        /// </remarks>
        public static readonly AnalyzerName LvLucene = new AnalyzerName("lv.lucene");

        /// <summary>
        /// Lucene analyzer for Dutch.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item>
        /// <description>Applies light stemming</description>
        /// </item>
        /// <item>
        /// <description>Filters out Dutch stop words</description>
        /// </item>
        /// </list>
        /// </remarks>
        public static readonly AnalyzerName NlLucene = new AnalyzerName("nl.lucene");

        /// <summary>
        /// Lucene analyzer for Norwegian.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item>
        /// <description>Applies light stemming</description>
        /// </item>
        /// <item>
        /// <description>Filters out Norwegian stop words</description>
        /// </item>
        /// </list>
        /// </remarks>
        public static readonly AnalyzerName NoLucene = new AnalyzerName("no.lucene");

        /// <summary>
        /// Lucene analyzer for Polish.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item>
        /// <description>Applies algorithmic stemming (Stempel)</description>
        /// </item>
        /// <item>
        /// <description>Filters out Polish stop words</description>
        /// </item>
        /// </list>
        /// </remarks>
        public static readonly AnalyzerName PlLucene = new AnalyzerName("pl.lucene");

        /// <summary>
        /// Lucene analyzer for Portuguese (Brazil).
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item>
        /// <description>Applies light stemming</description>
        /// </item>
        /// <item>
        /// <description>Filters out Portuguese stop words</description>
        /// </item>
        /// </list>
        /// </remarks>
        public static readonly AnalyzerName PtBRLucene = new AnalyzerName("pt-BR.lucene");

        /// <summary>
        /// Lucene analyzer for Portuguese (Portugal).
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item>
        /// <description>Applies light stemming</description>
        /// </item>
        /// <item>
        /// <description>Filters out Portuguese stop words</description>
        /// </item>
        /// </list>
        /// </remarks>
        public static readonly AnalyzerName PtPTLucene = new AnalyzerName("pt-PT.lucene");

        /// <summary>
        /// Lucene analyzer for Romanian.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item>
        /// <description>Applies light stemming</description>
        /// </item>
        /// <item>
        /// <description>Filters out Romanian stop words</description>
        /// </item>
        /// </list>
        /// </remarks>
        public static readonly AnalyzerName RoLucene = new AnalyzerName("ro.lucene");

        /// <summary>
        /// Lucene analyzer for Russian.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item>
        /// <description>Applies light stemming</description>
        /// </item>
        /// <item>
        /// <description>Filters out Russian stop words</description>
        /// </item>
        /// </list>
        /// </remarks>
        public static readonly AnalyzerName RuLucene = new AnalyzerName("ru.lucene");

        /// <summary>
        /// Standard Lucene analyzer.
        /// </summary>
        /// <remarks>
        /// This is the default analyzer for fields in an Azure Search index.
        /// </remarks>
        public static readonly AnalyzerName StandardLucene = new AnalyzerName("standard.lucene");

        /// <summary>
        /// Standard ASCII Folding Lucene analyzer.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item>
        /// <description>Unicode text segmentation (Standard Tokenizer)</description>
        /// </item>
        /// <item>
        /// <description>
        /// ASCII folding filter - converts Unicode characters that don't belong to the set of first 127 ASCII
        /// characters into their ASCII equivalents. This is useful for removing diacritics.
        /// </description>
        /// </item>
        /// </list>
        /// </remarks>
        public static readonly AnalyzerName StandardAsciiFoldingLucene = 
            new AnalyzerName("standardasciifolding.lucene");

        /// <summary>
        /// Lucene analyzer for Swedish.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item>
        /// <description>Applies light stemming</description>
        /// </item>
        /// <item>
        /// <description>Filters out Swedish stop words</description>
        /// </item>
        /// </list>
        /// </remarks>
        public static readonly AnalyzerName SvLucene = new AnalyzerName("sv.lucene");

        /// <summary>
        /// Lucene analyzer for Thai.
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item>
        /// <description>Applies light stemming</description>
        /// </item>
        /// <item>
        /// <description>Filters out Thai stop words</description>
        /// </item>
        /// </list>
        /// </remarks>
        public static readonly AnalyzerName ThLucene = new AnalyzerName("th.lucene");

        /// <summary>
        /// Lucene analyzer for Chinese (Simplified).
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item>
        /// <description>Uses probabilistic knowledge models to find the optimal word segmentation</description>
        /// </item>
        /// <item>
        /// <description>Filters out Chinese stop words</description>
        /// </item>
        /// </list>
        /// </remarks>
        public static readonly AnalyzerName ZhHansLucene = new AnalyzerName("zh-Hans.lucene");

        /// <summary>
        /// Lucene analyzer for Chinese (Traditional).
        /// </summary>
        /// <remarks>
        /// <list type="bullet">
        /// <item>
        /// <description>Indexes bigrams (overlapping groups of two adjacent Chinese characters)</description>
        /// </item>
        /// <item>
        /// <description>Normalizes character width differences</description>
        /// </item>
        /// </list>
        /// </remarks>
        public static readonly AnalyzerName ZhHantLucene = new AnalyzerName("zh-Hant.lucene");

        private string _name;

        private AnalyzerName(string name)
        {
            _name = name;
        }

        /// <summary>
        /// Defines implicit conversion from AnalyzerName to string.
        /// </summary>
        /// <param name="name">AnalyzerName to convert.</param>
        /// <returns>The AnalyzerName as a string.</returns>
        public static implicit operator string(AnalyzerName name)
        {
            return name.ToString();
        }

        /// <summary>
        /// Returns the AnalyzerName in a form that can be used in an Azure Search index definition.
        /// </summary>
        /// <returns>The AnalyzerName as a string.</returns>
        public override string ToString()
        {
            return _name;
        }
    }
}
