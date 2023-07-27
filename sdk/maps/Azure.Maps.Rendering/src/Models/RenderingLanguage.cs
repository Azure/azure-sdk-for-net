// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.Maps.Rendering
{
    /// <summary> The rendered langauge showing on the map images or map tiles. </summary>
    public readonly partial struct RenderingLanguage : IEquatable<RenderingLanguage>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="RenderingLanguage"/>. </summary>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public RenderingLanguage(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string ArabicValue = "ar";
        private const string BulgarianValue = "bg-BG";
        private const string CzechValue = "cs-CZ";
        private const string DanishValue = "da-DK";
        private const string GermanValue = "de-DE";
        private const string GreekValue = "el-GR";
        private const string EnglishAustraliaValue = "en-AU";
        private const string EnglishGreatBritainValue = "en-GB";
        private const string EnglishNewZealandValue = "en-NZ";
        private const string EnglishUsaValue = "en-US";
        private const string SpanishSpainValue = "es-ES";
        private const string SpanishMexicoValue = "es-MX";
        private const string FinnishValue = "fi-FI";
        private const string FrenchFranceValue = "fr-FR";
        private const string HungarianValue = "hu-HU";
        private const string IndonesianValue = "id-ID";
        private const string ItalianValue = "it-IT";
        private const string KoreanValue = "ko-KR";
        private const string LithuanianValue = "lt-LT";
        private const string MalayValue = "ms-MY";
        private const string NorwegianValue = "nb-NO";
        private const string NeutralGroundTruthLocalValue = "NGT";
        private const string NeutralGroundTruthLatinValue = "NGT-Latn";
        private const string DutchNetherlandsValue = "nl-NL";
        private const string PolishValue = "pl-PL";
        private const string PortugueseBrazilValue = "pt-BR";
        private const string PortuguesePortugalValue = "pt-PT";
        private const string RussianValue = "ru-RU";
        private const string SlovakValue = "sk-SK";
        private const string SlovenianValue = "sl-SL";
        private const string SwedishValue = "sv-SE";
        private const string ThaiValue = "th-TH";
        private const string TurkishValue = "tr-TR";
        private const string SimplifiedChineseValue = "zh-CN";
        private const string TraditionalChineseValue = "zh-TW";

        /// <summary> Return Arabic ("ar"). </summary>
        public static RenderingLanguage Arabic { get; } = new RenderingLanguage(ArabicValue);
        /// <summary> Return Bulgarian ("bg-BG"). </summary>
        public static RenderingLanguage Bulgarian { get; } = new RenderingLanguage(BulgarianValue);
        /// <summary> Return Czech ("cs-CZ"). </summary>
        public static RenderingLanguage Czech { get; } = new RenderingLanguage(CzechValue);
        /// <summary> Return Danish ("da-DK"). </summary>
        public static RenderingLanguage Danish { get; } = new RenderingLanguage(DanishValue);
        /// <summary> Return German ("de-DE"). </summary>
        public static RenderingLanguage German { get; } = new RenderingLanguage(GermanValue);
        /// <summary> Return Greek ("el-GR"). </summary>
        public static RenderingLanguage Greek { get; } = new RenderingLanguage(GreekValue);
        /// <summary> Return English (Australia) ("en-AU"). </summary>
        public static RenderingLanguage EnglishAustralia { get; } = new RenderingLanguage(EnglishAustraliaValue);
        /// <summary> Return English (Great Britain) ("en-GB"). </summary>
        public static RenderingLanguage EnglishGreatBritain { get; } = new RenderingLanguage(EnglishGreatBritainValue);
        /// <summary> Return English (New Zealand) ("en-NZ"). </summary>
        public static RenderingLanguage EnglishNewZealand { get; } = new RenderingLanguage(EnglishNewZealandValue);
        /// <summary> Return English (USA) ("en-US"). </summary>
        public static RenderingLanguage EnglishUsa { get; } = new RenderingLanguage(EnglishUsaValue);
        /// <summary> Return Spanish (Spain) ("es-ES"). </summary>
        public static RenderingLanguage SpanishSpain { get; } = new RenderingLanguage(SpanishSpainValue);
        /// <summary> Return Spanish (Mexico) ("es-MX"). </summary>
        public static RenderingLanguage SpanishMexico { get; } = new RenderingLanguage(SpanishMexicoValue);
        /// <summary> Return Finnish ("fi-FI"). </summary>
        public static RenderingLanguage Finnish { get; } = new RenderingLanguage(FinnishValue);
        /// <summary> Return French (France) ("fr-FR"). </summary>
        public static RenderingLanguage FrenchFrance { get; } = new RenderingLanguage(FrenchFranceValue);
        /// <summary> Return Hungarian ("hu-HU"). </summary>
        public static RenderingLanguage Hungarian { get; } = new RenderingLanguage(HungarianValue);
        /// <summary> Return Indonesian ("id-ID"). </summary>
        public static RenderingLanguage Indonesian { get; } = new RenderingLanguage(IndonesianValue);
        /// <summary> Return Italian ("it-IT"). </summary>
        public static RenderingLanguage Italian { get; } = new RenderingLanguage(ItalianValue);
        /// <summary> Return Korean ("ko-KR"). </summary>
        public static RenderingLanguage Korean { get; } = new RenderingLanguage(KoreanValue);
        /// <summary> Return Lithuanian ("lt-LT"). </summary>
        public static RenderingLanguage Lithuanian { get; } = new RenderingLanguage(LithuanianValue);
        /// <summary> Return Malay ("ms-MY"). </summary>
        public static RenderingLanguage Malay { get; } = new RenderingLanguage(MalayValue);
        /// <summary> Return Norwegian ("nb-NO"). </summary>
        public static RenderingLanguage Norwegian { get; } = new RenderingLanguage(NorwegianValue);
        /// <summary> Return Neutral Ground Truth (Local) ("NGT"). </summary>
        public static RenderingLanguage NeutralGroundTruthLocal { get; } = new RenderingLanguage(NeutralGroundTruthLocalValue);
        /// <summary> Return Neutral Ground Truth (Latin) ("NGT-Latn"). </summary>
        public static RenderingLanguage NeutralGroundTruthLatin { get; } = new RenderingLanguage(NeutralGroundTruthLatinValue);
        /// <summary> Return Dutch (Netherlands) ("nl-NL"). </summary>
        public static RenderingLanguage DutchNetherlands { get; } = new RenderingLanguage(DutchNetherlandsValue);
        /// <summary> Return Polish ("pl-PL"). </summary>
        public static RenderingLanguage Polish { get; } = new RenderingLanguage(PolishValue);
        /// <summary> Return Portuguese (Brazil) ("pt-BR"). </summary>
        public static RenderingLanguage PortugueseBrazil { get; } = new RenderingLanguage(PortugueseBrazilValue);
        /// <summary> Return Portuguese (Portugal) ("pt-PT"). </summary>
        public static RenderingLanguage PortuguesePortugal { get; } = new RenderingLanguage(PortuguesePortugalValue);
        /// <summary> Return Russian ("ru-RU"). </summary>
        public static RenderingLanguage Russian { get; } = new RenderingLanguage(RussianValue);
        /// <summary> Return Slovak ("sk-SK"). </summary>
        public static RenderingLanguage Slovak { get; } = new RenderingLanguage(SlovakValue);
        /// <summary> Return Slovenian ("sl-SL"). </summary>
        public static RenderingLanguage Slovenian { get; } = new RenderingLanguage(SlovenianValue);
        /// <summary> Return Swedish ("sv-SE"). </summary>
        public static RenderingLanguage Swedish { get; } = new RenderingLanguage(SwedishValue);
        /// <summary> Return Thai ("th-TH"). </summary>
        public static RenderingLanguage Thai { get; } = new RenderingLanguage(ThaiValue);
        /// <summary> Return Turkish ("tr-TR"). </summary>
        public static RenderingLanguage Turkish { get; } = new RenderingLanguage(TurkishValue);
        /// <summary> Return Simplified Chinese ("zh-CN"). </summary>
        public static RenderingLanguage SimplifiedChinese { get; } = new RenderingLanguage(SimplifiedChineseValue);
        /// <summary> Return Traditional Chinese ("zh-TW"). </summary>
        public static RenderingLanguage TraditionalChinese { get; } = new RenderingLanguage(TraditionalChineseValue);
        /// <summary> Determines if two <see cref="RenderingLanguage"/> values are the same. </summary>
        public static bool operator ==(RenderingLanguage left, RenderingLanguage right) => left.Equals(right);
        /// <summary> Determines if two <see cref="RenderingLanguage"/> values are not the same. </summary>
        public static bool operator !=(RenderingLanguage left, RenderingLanguage right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="RenderingLanguage"/>. </summary>
        public static implicit operator RenderingLanguage(string value) => new RenderingLanguage(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is RenderingLanguage other && Equals(other);
        /// <inheritdoc />
        public bool Equals(RenderingLanguage other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
