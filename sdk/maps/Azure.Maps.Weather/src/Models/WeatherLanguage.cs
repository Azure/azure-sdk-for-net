// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.Maps.Weather
{
    /// <summary> The langauge of search result returned by the requests. </summary>
    public partial class WeatherLanguage
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="WeatherLanguage"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public WeatherLanguage(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string ArabicValue = "ar";
        private const string BulgarianValue = "bg-BG";
        private const string BanglaBangladeshValue = "bn-BD";
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
        private const string SlovenianValue = "sl-SL";
        private const string SerbianCyrillicValue = "sl-Cyrl-RS";
        private const string SwedishValue = "sv-SE";
        private const string ThaiValue = "th-TH";
        private const string TurkishValue = "tr-TR";
        private const string UkrainianValue = "uk-UA";
        private const string VietnameseValue = "vi-VN";
        private const string SimplifiedChineseValue = "zh-CN";
        private const string TraditionalChineseValue = "zh-TW";

        /// <summary> Return Afrikaans ("af-ZA"). </summary>
        public static WeatherLanguage Afrikaans { get; } = new WeatherLanguage(AfrikaansValue);
        /// <summary> Return Arabic ("ar"). </summary>
        public static WeatherLanguage Arabic { get; } = new WeatherLanguage(ArabicValue);
        /// <summary> Return Bulgarian ("bg-BG"). </summary>
        public static WeatherLanguage Bulgarian { get; } = new WeatherLanguage(BulgarianValue);
        /// <summary> Return Czech ("ca-ES"). </summary>
        public static WeatherLanguage Catalan { get; } = new WeatherLanguage(CatalanValue);
        /// <summary> Return Czech ("cs-CZ"). </summary>
        public static WeatherLanguage Czech { get; } = new WeatherLanguage(CzechValue);
        /// <summary> Return Danish ("da-DK"). </summary>
        public static WeatherLanguage Danish { get; } = new WeatherLanguage(DanishValue);
        /// <summary> Return German ("de-DE"). </summary>
        public static WeatherLanguage German { get; } = new WeatherLanguage(GermanValue);
        /// <summary> Return Greek ("el-GR"). </summary>
        public static WeatherLanguage Greek { get; } = new WeatherLanguage(GreekValue);
        /// <summary> Return English (Australia) ("en-AU"). </summary>
        public static WeatherLanguage EnglishAustralia { get; } = new WeatherLanguage(EnglishAustraliaValue);
        /// <summary> Return English (Great Britain) ("en-GB"). </summary>
        public static WeatherLanguage EnglishGreatBritain { get; } = new WeatherLanguage(EnglishGreatBritainValue);
        /// <summary> Return English (New Zealand) ("en-NZ"). </summary>
        public static WeatherLanguage EnglishNewZealand { get; } = new WeatherLanguage(EnglishNewZealandValue);
        /// <summary> Return English (USA) ("en-US"). </summary>
        public static WeatherLanguage EnglishUsa { get; } = new WeatherLanguage(EnglishUsaValue);
        /// <summary> Return Spanish (Latin America) ("es-419"). </summary>
        public static WeatherLanguage SpanishLatinAmerica { get; } = new WeatherLanguage(SpanishLatinAmericaValue);
        /// <summary> Return Spanish (Spain) ("es-ES"). </summary>
        public static WeatherLanguage SpanishSpain { get; } = new WeatherLanguage(SpanishSpainValue);
        /// <summary> Return Estonian ("et-EE"). </summary>
        public static WeatherLanguage Estonian { get; } = new WeatherLanguage(EstonianValue);
        /// <summary> Return Basque ("eu-ES"). </summary>
        public static WeatherLanguage Basque { get; } = new WeatherLanguage(BasqueValue);
        /// <summary> Return Finnish ("fi-FI"). </summary>
        public static WeatherLanguage Finnish { get; } = new WeatherLanguage(FinnishValue);
        /// <summary> Return French (Canada) ("fr-CA"). </summary>
        public static WeatherLanguage FrenchCanada { get; } = new WeatherLanguage(FrenchCanadaValue);
        /// <summary> Return French (France) ("fr-FR"). </summary>
        public static WeatherLanguage FrenchFrance { get; } = new WeatherLanguage(FrenchFranceValue);
        /// <summary> Return Galician ("gl-ES"). </summary>
        public static WeatherLanguage Galician { get; } = new WeatherLanguage(GalicianValue);
        /// <summary> Return Hebrew ("he-IL"). </summary>
        public static WeatherLanguage Hebrew { get; } = new WeatherLanguage(HebrewValue);
        /// <summary> Return Croatian ("hr-HR"). </summary>
        public static WeatherLanguage Croatian { get; } = new WeatherLanguage(CroatianValue);
        /// <summary> Return Hungarian ("hu-HU"). </summary>
        public static WeatherLanguage Hungarian { get; } = new WeatherLanguage(HungarianValue);
        /// <summary> Return Indonesian ("id-ID"). </summary>
        public static WeatherLanguage Indonesian { get; } = new WeatherLanguage(IndonesianValue);
        /// <summary> Return Italian ("it-IT"). </summary>
        public static WeatherLanguage Italian { get; } = new WeatherLanguage(ItalianValue);
        /// <summary> Return Kazakh ("kk-KZ"). </summary>
        public static WeatherLanguage Kazakh { get; } = new WeatherLanguage(KazakhValue);
        /// <summary> Return Lithuanian ("lt-LT"). </summary>
        public static WeatherLanguage Lithuanian { get; } = new WeatherLanguage(LithuanianValue);
        /// <summary> Return Latvian ("lv-LV"). </summary>
        public static WeatherLanguage Latvian { get; } = new WeatherLanguage(LatvianValue);
        /// <summary> Return Malay ("ms-MY"). </summary>
        public static WeatherLanguage Malay { get; } = new WeatherLanguage(MalayValue);
        /// <summary> Return Norwegian ("nb-NO"). </summary>
        public static WeatherLanguage Norwegian { get; } = new WeatherLanguage(NorwegianValue);
        /// <summary> Return Neutral Ground Truth (Local) ("NGT"). </summary>
        public static WeatherLanguage NeutralGroundTruthLocal { get; } = new WeatherLanguage(NeutralGroundTruthLocalValue);
        /// <summary> Return Neutral Ground Truth (Latin) ("NGT-Latn"). </summary>
        public static WeatherLanguage NeutralGroundTruthLatin { get; } = new WeatherLanguage(NeutralGroundTruthLatinValue);
        /// <summary> Return Dutch (Netherlands) ("nl-NL"). </summary>
        public static WeatherLanguage DutchNetherlands { get; } = new WeatherLanguage(DutchNetherlandsValue);
        /// <summary> Return Polish ("pl-PL"). </summary>
        public static WeatherLanguage Polish { get; } = new WeatherLanguage(PolishValue);
        /// <summary> Return Portuguese (Brazil) ("pt-BR"). </summary>
        public static WeatherLanguage PortugueseBrazil { get; } = new WeatherLanguage(PortugueseBrazilValue);
        /// <summary> Return Portuguese (Portugal) ("pt-PT"). </summary>
        public static WeatherLanguage PortuguesePortugal { get; } = new WeatherLanguage(PortuguesePortugalValue);
        /// <summary> Return Romanian ("ro-RO"). </summary>
        public static WeatherLanguage Romanian { get; } = new WeatherLanguage(RomanianValue);
        /// <summary> Return Russian ("ru-RU"). </summary>
        public static WeatherLanguage Russian { get; } = new WeatherLanguage(RussianValue);
        /// <summary> Return Slovak ("sk-SK"). </summary>
        public static WeatherLanguage Slovak { get; } = new WeatherLanguage(SlovakValue);
        /// <summary> Return Slovenian ("sl-SL"). </summary>
        public static WeatherLanguage Slovenian { get; } = new WeatherLanguage(SlovenianValue);
        /// <summary> Return Serbian (Cyrillic) ("sr-Cyrl-RS"). </summary>
        public static WeatherLanguage SerbianCyrillic { get; } = new WeatherLanguage(SerbianCyrillicValue);
        /// <summary> Return Swedish ("sv-SE"). </summary>
        public static WeatherLanguage Swedish { get; } = new WeatherLanguage(SwedishValue);
        /// <summary> Return Thai ("th-TH"). </summary>
        public static WeatherLanguage Thai { get; } = new WeatherLanguage(ThaiValue);
        /// <summary> Return Turkish ("tr-TR"). </summary>
        public static WeatherLanguage Turkish { get; } = new WeatherLanguage(TurkishValue);
        /// <summary> Return Ukrainian ("uk-UA"). </summary>
        public static WeatherLanguage Ukrainian { get; } = new WeatherLanguage(UkrainianValue);
        /// <summary> Return Vietnamese ("vi-VN"). </summary>
        public static WeatherLanguage Vietnamese { get; } = new WeatherLanguage(VietnameseValue);
        /// <summary> Return Simplified Chinese ("zh-CN"). </summary>
        public static WeatherLanguage SimplifiedChinese { get; } = new WeatherLanguage(SimplifiedChineseValue);
        /// <summary> Return Traditional Chinese ("zh-TW"). </summary>
        public static WeatherLanguage TraditionalChinese { get; } = new WeatherLanguage(TraditionalChineseValue);

        /// <summary> Converts a string to a <see cref="WeatherLanguage"/>. </summary>
        public static implicit operator WeatherLanguage(string value) => new WeatherLanguage(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
