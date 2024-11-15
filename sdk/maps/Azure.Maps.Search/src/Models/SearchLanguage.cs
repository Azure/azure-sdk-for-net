// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.Maps.Search
{
    /// <summary> The langauge of search result returned by the requests. </summary>
    public partial class SearchLanguage
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="SearchLanguage"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public SearchLanguage(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string AfrikaansValue = "af-ZA";
        private const string ArabicValue = "ar";
        private const string BulgarianValue = "bg-BG";
        private const string CatalanValue = "ca-ES";
        private const string CzechValue = "cs-CZ";
        private const string DanishValue = "da-DK";
        private const string GermanValue = "de-DE";
        private const string GreekValue = "el-GR";
        private const string EnglishAustraliaValue = "en-AU";
        private const string EnglishGreatBritainValue = "en-GB";
        private const string EnglishNewZealandValue = "en-NZ";
        private const string EnglishUsaValue = "en-US";
        private const string SpanishLatinAmericaValue = "es-419";
        private const string SpanishSpainValue = "es-ES";
        private const string EstonianValue = "et-EE";
        private const string BasqueValue = "eu-ES";
        private const string FinnishValue = "fi-FI";
        private const string FrenchCanadaValue = "fr-CA";
        private const string FrenchFranceValue = "fr-FR";
        private const string GalicianValue = "gl-ES";
        private const string HebrewValue = "he-IL";
        private const string CroatianValue = "hr-HR";
        private const string HungarianValue = "hu-HU";
        private const string IndonesianValue = "id-ID";
        private const string ItalianValue = "it-IT";
        private const string KazakhValue = "kk-KZ";
        private const string LithuanianValue = "lt-LT";
        private const string LatvianValue = "lv-LV";
        private const string MalayValue = "ms-MY";
        private const string NorwegianValue = "nb-NO";
        private const string NeutralGroundTruthLocalValue = "NGT";
        private const string NeutralGroundTruthLatinValue = "NGT-Latn";
        private const string DutchNetherlandsValue = "nl-NL";
        private const string PolishValue = "pl-PL";
        private const string PortugueseBrazilValue = "pt-BR";
        private const string PortuguesePortugalValue = "pt-PT";
        private const string RomanianValue = "ro-RO";
        private const string RussianValue = "ru-RU";
        private const string SlovakValue = "sk-SK";
        private const string SlovenianValue = "sl-SI";
        private const string SerbianCyrillicValue = "sl-Cyrl-RS";
        private const string SwedishValue = "sv-SE";
        private const string ThaiValue = "th-TH";
        private const string TurkishValue = "tr-TR";
        private const string UkrainianValue = "uk-UA";
        private const string VietnameseValue = "vi-VN";
        private const string SimplifiedChineseValue = "zh-CN";
        private const string TraditionalChineseValue = "zh-TW";

        /// <summary> Return Afrikaans ("af-ZA"). </summary>
        public static SearchLanguage Afrikaans { get; } = new SearchLanguage(AfrikaansValue);
        /// <summary> Return Arabic ("ar"). </summary>
        public static SearchLanguage Arabic { get; } = new SearchLanguage(ArabicValue);
        /// <summary> Return Bulgarian ("bg-BG"). </summary>
        public static SearchLanguage Bulgarian { get; } = new SearchLanguage(BulgarianValue);
        /// <summary> Return Czech ("ca-ES"). </summary>
        public static SearchLanguage Catalan { get; } = new SearchLanguage(CatalanValue);
        /// <summary> Return Czech ("cs-CZ"). </summary>
        public static SearchLanguage Czech { get; } = new SearchLanguage(CzechValue);
        /// <summary> Return Danish ("da-DK"). </summary>
        public static SearchLanguage Danish { get; } = new SearchLanguage(DanishValue);
        /// <summary> Return German ("de-DE"). </summary>
        public static SearchLanguage German { get; } = new SearchLanguage(GermanValue);
        /// <summary> Return Greek ("el-GR"). </summary>
        public static SearchLanguage Greek { get; } = new SearchLanguage(GreekValue);
        /// <summary> Return English (Australia) ("en-AU"). </summary>
        public static SearchLanguage EnglishAustralia { get; } = new SearchLanguage(EnglishAustraliaValue);
        /// <summary> Return English (Great Britain) ("en-GB"). </summary>
        public static SearchLanguage EnglishGreatBritain { get; } = new SearchLanguage(EnglishGreatBritainValue);
        /// <summary> Return English (New Zealand) ("en-NZ"). </summary>
        public static SearchLanguage EnglishNewZealand { get; } = new SearchLanguage(EnglishNewZealandValue);
        /// <summary> Return English (USA) ("en-US"). </summary>
        public static SearchLanguage EnglishUsa { get; } = new SearchLanguage(EnglishUsaValue);
        /// <summary> Return Spanish (Latin America) ("es-419"). </summary>
        public static SearchLanguage SpanishLatinAmerica { get; } = new SearchLanguage(SpanishLatinAmericaValue);
        /// <summary> Return Spanish (Spain) ("es-ES"). </summary>
        public static SearchLanguage SpanishSpain { get; } = new SearchLanguage(SpanishSpainValue);
        /// <summary> Return Estonian ("et-EE"). </summary>
        public static SearchLanguage Estonian { get; } = new SearchLanguage(EstonianValue);
        /// <summary> Return Basque ("eu-ES"). </summary>
        public static SearchLanguage Basque { get; } = new SearchLanguage(BasqueValue);
        /// <summary> Return Finnish ("fi-FI"). </summary>
        public static SearchLanguage Finnish { get; } = new SearchLanguage(FinnishValue);
        /// <summary> Return French (Canada) ("fr-CA"). </summary>
        public static SearchLanguage FrenchCanada { get; } = new SearchLanguage(FrenchCanadaValue);
        /// <summary> Return French (France) ("fr-FR"). </summary>
        public static SearchLanguage FrenchFrance { get; } = new SearchLanguage(FrenchFranceValue);
        /// <summary> Return Galician ("gl-ES"). </summary>
        public static SearchLanguage Galician { get; } = new SearchLanguage(GalicianValue);
        /// <summary> Return Hebrew ("he-IL"). </summary>
        public static SearchLanguage Hebrew { get; } = new SearchLanguage(HebrewValue);
        /// <summary> Return Croatian ("hr-HR"). </summary>
        public static SearchLanguage Croatian { get; } = new SearchLanguage(CroatianValue);
        /// <summary> Return Hungarian ("hu-HU"). </summary>
        public static SearchLanguage Hungarian { get; } = new SearchLanguage(HungarianValue);
        /// <summary> Return Indonesian ("id-ID"). </summary>
        public static SearchLanguage Indonesian { get; } = new SearchLanguage(IndonesianValue);
        /// <summary> Return Italian ("it-IT"). </summary>
        public static SearchLanguage Italian { get; } = new SearchLanguage(ItalianValue);
        /// <summary> Return Kazakh ("kk-KZ"). </summary>
        public static SearchLanguage Kazakh { get; } = new SearchLanguage(KazakhValue);
        /// <summary> Return Lithuanian ("lt-LT"). </summary>
        public static SearchLanguage Lithuanian { get; } = new SearchLanguage(LithuanianValue);
        /// <summary> Return Latvian ("lv-LV"). </summary>
        public static SearchLanguage Latvian { get; } = new SearchLanguage(LatvianValue);
        /// <summary> Return Malay ("ms-MY"). </summary>
        public static SearchLanguage Malay { get; } = new SearchLanguage(MalayValue);
        /// <summary> Return Norwegian ("nb-NO"). </summary>
        public static SearchLanguage Norwegian { get; } = new SearchLanguage(NorwegianValue);
        /// <summary> Return Neutral Ground Truth (Local) ("NGT"). </summary>
        public static SearchLanguage NeutralGroundTruthLocal { get; } = new SearchLanguage(NeutralGroundTruthLocalValue);
        /// <summary> Return Neutral Ground Truth (Latin) ("NGT-Latn"). </summary>
        public static SearchLanguage NeutralGroundTruthLatin { get; } = new SearchLanguage(NeutralGroundTruthLatinValue);
        /// <summary> Return Dutch (Netherlands) ("nl-NL"). </summary>
        public static SearchLanguage DutchNetherlands { get; } = new SearchLanguage(DutchNetherlandsValue);
        /// <summary> Return Polish ("pl-PL"). </summary>
        public static SearchLanguage Polish { get; } = new SearchLanguage(PolishValue);
        /// <summary> Return Portuguese (Brazil) ("pt-BR"). </summary>
        public static SearchLanguage PortugueseBrazil { get; } = new SearchLanguage(PortugueseBrazilValue);
        /// <summary> Return Portuguese (Portugal) ("pt-PT"). </summary>
        public static SearchLanguage PortuguesePortugal { get; } = new SearchLanguage(PortuguesePortugalValue);
        /// <summary> Return Romanian ("ro-RO"). </summary>
        public static SearchLanguage Romanian { get; } = new SearchLanguage(RomanianValue);
        /// <summary> Return Russian ("ru-RU"). </summary>
        public static SearchLanguage Russian { get; } = new SearchLanguage(RussianValue);
        /// <summary> Return Slovak ("sk-SK"). </summary>
        public static SearchLanguage Slovak { get; } = new SearchLanguage(SlovakValue);
        /// <summary> Return Slovenian ("sl-SI"). </summary>
        public static SearchLanguage Slovenian { get; } = new SearchLanguage(SlovenianValue);
        /// <summary> Return Serbian (Cyrillic) ("sr-Cyrl-RS"). </summary>
        public static SearchLanguage SerbianCyrillic { get; } = new SearchLanguage(SerbianCyrillicValue);
        /// <summary> Return Swedish ("sv-SE"). </summary>
        public static SearchLanguage Swedish { get; } = new SearchLanguage(SwedishValue);
        /// <summary> Return Thai ("th-TH"). </summary>
        public static SearchLanguage Thai { get; } = new SearchLanguage(ThaiValue);
        /// <summary> Return Turkish ("tr-TR"). </summary>
        public static SearchLanguage Turkish { get; } = new SearchLanguage(TurkishValue);
        /// <summary> Return Ukrainian ("uk-UA"). </summary>
        public static SearchLanguage Ukrainian { get; } = new SearchLanguage(UkrainianValue);
        /// <summary> Return Vietnamese ("vi-VN"). </summary>
        public static SearchLanguage Vietnamese { get; } = new SearchLanguage(VietnameseValue);
        /// <summary> Return Simplified Chinese ("zh-CN"). </summary>
        public static SearchLanguage SimplifiedChinese { get; } = new SearchLanguage(SimplifiedChineseValue);
        /// <summary> Return Traditional Chinese ("zh-TW"). </summary>
        public static SearchLanguage TraditionalChinese { get; } = new SearchLanguage(TraditionalChineseValue);

        /// <summary> Converts a string to a <see cref="SearchLanguage"/>. </summary>
        public static implicit operator SearchLanguage(string value) => new SearchLanguage(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
