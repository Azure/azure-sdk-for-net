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
        public static readonly AnalyzerName ArLucene = new AnalyzerName("ar.lucene");

        /// <summary>
        /// Lucene analyzer for Czech.
        /// </summary>
        public static readonly AnalyzerName CsLucene = new AnalyzerName("cs.lucene");

        /// <summary>
        /// Lucene analyzer for Danish.
        /// </summary>
        public static readonly AnalyzerName DaLucene = new AnalyzerName("da.lucene");

        /// <summary>
        /// Lucene analyzer for German.
        /// </summary>
        public static readonly AnalyzerName DeLucene = new AnalyzerName("de.lucene");

        /// <summary>
        /// Lucene analyzer for Greek.
        /// </summary>
        public static readonly AnalyzerName ElLucene = new AnalyzerName("el.lucene");

        /// <summary>
        /// Lucene analyzer for English.
        /// </summary>
        public static readonly AnalyzerName EnLucene = new AnalyzerName("en.lucene");

        /// <summary>
        /// Lucene analyzer for Spanish.
        /// </summary>
        public static readonly AnalyzerName EsLucene = new AnalyzerName("es.lucene");

        /// <summary>
        /// Lucene analyzer for Finnish.
        /// </summary>
        public static readonly AnalyzerName FiLucene = new AnalyzerName("fi.lucene");

        /// <summary>
        /// Lucene analyzer for French.
        /// </summary>
        public static readonly AnalyzerName FrLucene = new AnalyzerName("fr.lucene");

        /// <summary>
        /// Lucene analyzer for Hindi.
        /// </summary>
        public static readonly AnalyzerName HiLucene = new AnalyzerName("hi.lucene");

        /// <summary>
        /// Lucene analyzer for Hungarian.
        /// </summary>
        public static readonly AnalyzerName HuLucene = new AnalyzerName("hu.lucene");

        /// <summary>
        /// Lucene analyzer for Indonesian.
        /// </summary>
        public static readonly AnalyzerName IdLucene = new AnalyzerName("id.lucene");

        /// <summary>
        /// Lucene analyzer for Italian.
        /// </summary>
        public static readonly AnalyzerName ItLucene = new AnalyzerName("it.lucene");

        /// <summary>
        /// Lucene analyzer for Japanese.
        /// </summary>
        public static readonly AnalyzerName JaLucene = new AnalyzerName("ja.lucene");

        /// <summary>
        /// Lucene analyzer for Korean.
        /// </summary>
        public static readonly AnalyzerName KoLucene = new AnalyzerName("ko.lucene");

        /// <summary>
        /// Lucene analyzer for Latvian.
        /// </summary>
        public static readonly AnalyzerName LvLucene = new AnalyzerName("lv.lucene");

        /// <summary>
        /// Lucene analyzer for Dutch.
        /// </summary>
        public static readonly AnalyzerName NlLucene = new AnalyzerName("nl.lucene");

        /// <summary>
        /// Lucene analyzer for Norwegian.
        /// </summary>
        public static readonly AnalyzerName NoLucene = new AnalyzerName("no.lucene");

        /// <summary>
        /// Lucene analyzer for Polish.
        /// </summary>
        public static readonly AnalyzerName PlLucene = new AnalyzerName("pl.lucene");

        /// <summary>
        /// Lucene analyzer for Portuguese (Brazil).
        /// </summary>
        public static readonly AnalyzerName PtBRLucene = new AnalyzerName("pt-BR.lucene");

        /// <summary>
        /// Lucene analyzer for Portuguese (Portugal).
        /// </summary>
        public static readonly AnalyzerName PtPTLucene = new AnalyzerName("pt-PT.lucene");

        /// <summary>
        /// Lucene analyzer for Romanian.
        /// </summary>
        public static readonly AnalyzerName RoLucene = new AnalyzerName("ro.lucene");

        /// <summary>
        /// Lucene analyzer for Russian.
        /// </summary>
        public static readonly AnalyzerName RuLucene = new AnalyzerName("ru.lucene");

        /// <summary>
        /// Standard Lucene analyzer.
        /// </summary>
        public static readonly AnalyzerName StandardLucene = new AnalyzerName("standard.lucene");

        /// <summary>
        /// Standard ASCII Folding Lucene analyzer.
        /// </summary>
        public static readonly AnalyzerName StandardAsciiFoldingLucene = 
            new AnalyzerName("standardasciifolding.lucene");

        /// <summary>
        /// Lucene analyzer for Swedish.
        /// </summary>
        public static readonly AnalyzerName SvLucene = new AnalyzerName("sv.lucene");

        /// <summary>
        /// Lucene analyzer for Thai.
        /// </summary>
        public static readonly AnalyzerName ThLucene = new AnalyzerName("th.lucene");

        /// <summary>
        /// Lucene analyzer for Chinese (Simplified).
        /// </summary>
        public static readonly AnalyzerName ZhHansLucene = new AnalyzerName("zh-Hans.lucene");

        /// <summary>
        /// Lucene analyzer for Chinese (Traditional).
        /// </summary>
        public static readonly AnalyzerName ZhHantLucene = new AnalyzerName("zh-Hant.lucene");

        /// <summary>
        /// Microsoft analyzer for Arabic.
        /// </summary>
        public static readonly AnalyzerName ArMicrosoft = new AnalyzerName("ar.microsoft");

        /// <summary>
        /// Microsoft analyzer for Bulgarian.
        /// </summary>
        public static readonly AnalyzerName BgMicrosoft = new AnalyzerName("bg.microsoft");

        /// <summary>
        /// Microsoft analyzer for Bangla.
        /// </summary>
        public static readonly AnalyzerName BnMicrosoft = new AnalyzerName("bn.microsoft");

        /// <summary>
        /// Microsoft analyzer for Catalan.
        /// </summary>
        public static readonly AnalyzerName CaMicrosoft = new AnalyzerName("ca.microsoft");

        /// <summary>
        /// Microsoft analyzer for Czech.
        /// </summary>
        public static readonly AnalyzerName CsMicrosoft = new AnalyzerName("cs.microsoft");

        /// <summary>
        /// Microsoft analyzer for Danish.
        /// </summary>
        public static readonly AnalyzerName DaMicrosoft = new AnalyzerName("da.microsoft");

        /// <summary>
        /// Microsoft analyzer for German.
        /// </summary>
        public static readonly AnalyzerName DeMicrosoft = new AnalyzerName("de.microsoft");

        /// <summary>
        /// Microsoft analyzer for Greek.
        /// </summary>
        public static readonly AnalyzerName ElMicrosoft = new AnalyzerName("el.microsoft");

        /// <summary>
        /// Microsoft analyzer for English.
        /// </summary>
        public static readonly AnalyzerName EnMicrosoft = new AnalyzerName("en.microsoft");

        /// <summary>
        /// Microsoft analyzer for Spanish.
        /// </summary>
        public static readonly AnalyzerName EsMicrosoft = new AnalyzerName("es.microsoft");

        /// <summary>
        /// Microsoft analyzer for Estonian.
        /// </summary>
        public static readonly AnalyzerName EtMicrosoft = new AnalyzerName("et.microsoft");

        /// <summary>
        /// Microsoft analyzer for Finnish.
        /// </summary>
        public static readonly AnalyzerName FiMicrosoft = new AnalyzerName("fi.microsoft");

        /// <summary>
        /// Microsoft analyzer for French.
        /// </summary>
        public static readonly AnalyzerName FrMicrosoft = new AnalyzerName("fr.microsoft");

        /// <summary>
        /// Microsoft analyzer for Hebrew.
        /// </summary>
        public static readonly AnalyzerName HeMicrosoft = new AnalyzerName("he.microsoft");

        /// <summary>
        /// Microsoft analyzer for Hindi.
        /// </summary>
        public static readonly AnalyzerName HiMicrosoft = new AnalyzerName("hi.microsoft");
        
        /// <summary>
        /// Microsoft analyzer for Croatian.
        /// </summary>
        public static readonly AnalyzerName HrMicrosoft = new AnalyzerName("hr.microsoft");

        /// <summary>
        /// Microsoft analyzer for Hungarian.
        /// </summary>
        public static readonly AnalyzerName HuMicrosoft = new AnalyzerName("hu.microsoft");

        /// <summary>
        /// Microsoft analyzer for Gujarati.
        /// </summary>
        public static readonly AnalyzerName GuMicrosoft = new AnalyzerName("gu.microsoft");

        /// <summary>
        /// Microsoft analyzer for Indonesian (Bahasa).
        /// </summary>
        public static readonly AnalyzerName IdMicrosoft = new AnalyzerName("id.microsoft");

        /// <summary>
        /// Microsoft analyzer for Icelandic.
        /// </summary>
        public static readonly AnalyzerName IsMicrosoft = new AnalyzerName("is.microsoft");

        /// <summary>
        /// Microsoft analyzer for Italian.
        /// </summary>
        public static readonly AnalyzerName ItMicrosoft = new AnalyzerName("it.microsoft");

        /// <summary>
        /// Microsoft analyzer for Japanese.
        /// </summary>
        public static readonly AnalyzerName JaMicrosoft = new AnalyzerName("ja.microsoft");

        /// <summary>
        /// Microsoft analyzer for Kannada.
        /// </summary>
        public static readonly AnalyzerName KnMicrosoft = new AnalyzerName("kn.microsoft");

        /// <summary>
        /// Microsoft analyzer for Lithuanian.
        /// </summary>
        public static readonly AnalyzerName LtMicrosoft = new AnalyzerName("lt.microsoft");

        /// <summary>
        /// Microsoft analyzer for Latvian.
        /// </summary>
        public static readonly AnalyzerName LvMicrosoft = new AnalyzerName("lv.microsoft");

        /// <summary>
        /// Microsoft analyzer for Dutch.
        /// </summary>
        public static readonly AnalyzerName NlMicrosoft = new AnalyzerName("nl.microsoft");

        /// <summary>
        /// Microsoft analyzer for Norwegian (Bokmål).
        /// </summary>
        public static readonly AnalyzerName NbMicrosoft = new AnalyzerName("nb.microsoft");

        /// <summary>
        /// Microsoft analyzer for Malayalam.
        /// </summary>
        public static readonly AnalyzerName MlMicrosoft = new AnalyzerName("ml.microsoft");

        /// <summary>
        /// Microsoft analyzer for Malay (Latin).
        /// </summary>
        public static readonly AnalyzerName MsMicrosoft = new AnalyzerName("ms.microsoft");

        /// <summary>
        /// Microsoft analyzer for Marathi.
        /// </summary>
        public static readonly AnalyzerName MrMicrosoft = new AnalyzerName("mr.microsoft");

        /// <summary>
        /// Microsoft analyzer for Punjabi.
        /// </summary>
        public static readonly AnalyzerName PaMicrosoft = new AnalyzerName("pa.microsoft");

        /// <summary>
        /// Microsoft analyzer for Polish.
        /// </summary>
        public static readonly AnalyzerName PlMicrosoft = new AnalyzerName("pl.microsoft");

        /// <summary>
        /// Microsoft analyzer for Portuguese (Brazil).
        /// </summary>
        public static readonly AnalyzerName PtPtMicrosoft = new AnalyzerName("pt-PT.microsoft");

        /// <summary>
        /// Microsoft analyzer for Portuguese (Portugal).
        /// </summary>        
        public static readonly AnalyzerName PtBrMicrosoft = new AnalyzerName("pt-BR.microsoft");

        /// <summary>
        /// Microsoft analyzer for Romanian.
        /// </summary>
        public static readonly AnalyzerName RoMicrosoft = new AnalyzerName("ro.microsoft");

        /// <summary>
        /// Microsoft analyzer for Russian.
        /// </summary>
        public static readonly AnalyzerName RuMicrosoft = new AnalyzerName("ru.microsoft");

        /// <summary>
        /// Microsoft analyzer for Slovak.
        /// </summary>
        public static readonly AnalyzerName SkMicrosoft = new AnalyzerName("sk.microsoft");

        /// <summary>
        /// Microsoft analyzer for Slovenian.
        /// </summary>
        public static readonly AnalyzerName SlMicrosoft = new AnalyzerName("sl.microsoft");

        /// <summary>
        /// Microsoft analyzer for Serbian (Cyrillic).
        /// </summary>
        public static readonly AnalyzerName SrCyrillicMicrosoft = new AnalyzerName("sr-cyrillic.microsoft");

        /// <summary>
        /// Microsoft analyzer for Serbian (Latin).
        /// </summary>
        public static readonly AnalyzerName SrLatinMicrosoft = new AnalyzerName("sr-latin.microsoft");

        /// <summary>
        /// Microsoft analyzer for Swedish.
        /// </summary>
        public static readonly AnalyzerName SvMicrosoft = new AnalyzerName("sv.microsoft");

        /// <summary>
        /// Microsoft analyzer for Tamil.
        /// </summary>
        public static readonly AnalyzerName TaMicrosoft = new AnalyzerName("ta.microsoft");

        /// <summary>
        /// Microsoft analyzer for Telugu.
        /// </summary>
        public static readonly AnalyzerName TeMicrosoft = new AnalyzerName("te.microsoft");

        /// <summary>
        /// Microsoft analyzer for Turkish.
        /// </summary>
        public static readonly AnalyzerName TrMicrosoft = new AnalyzerName("tr.microsoft");

        /// <summary>
        /// Microsoft analyzer for Thai.
        /// </summary>
        public static readonly AnalyzerName ThMicrosoft = new AnalyzerName("th.microsoft");

        /// <summary>
        /// Microsoft analyzer for Ukranian.
        /// </summary>
        public static readonly AnalyzerName UkMicrosoft = new AnalyzerName("uk.microsoft");

        /// <summary>
        /// Microsoft analyzer for Urdu.
        /// </summary>
        public static readonly AnalyzerName UrMicrosoft = new AnalyzerName("ur.microsoft");

        /// <summary>
        /// Microsoft analyzer for Vietnamese.
        /// </summary>
        public static readonly AnalyzerName ViMicrosoft = new AnalyzerName("vi.microsoft");

        /// <summary>
        /// Microsoft analyzer for Chinese (Simplified).
        /// </summary>
        public static readonly AnalyzerName ZhHansMicrosoft = new AnalyzerName("zh-Hans.microsoft");

        /// <summary>
        /// Microsoft analyzer for Chinese (Traditional).
        /// </summary>
        public static readonly AnalyzerName ZhHantMicrosoft = new AnalyzerName("zh-Hant.microsoft");

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
