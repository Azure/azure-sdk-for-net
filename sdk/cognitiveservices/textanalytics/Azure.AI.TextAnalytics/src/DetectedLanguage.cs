using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Data.TextAnalytics
{
    /// <summary>
    /// 
    /// </summary>
    public partial class DetectedLanguage
    {
        /// <summary>
        /// Initializes a new instance of the DetectedLanguage class.
        /// </summary>
        internal DetectedLanguage()
        {
        }

        /// <summary>
        /// Initializes a new instance of the DetectedLanguage class.
        /// </summary>
        /// <param name="name">Long name of a detected language (e.g. English,
        /// French).</param>
        /// <param name="iso6391Name">A two letter representation of the
        /// detected language according to the ISO 639-1 standard (e.g. en,
        /// fr).</param>
        /// <param name="score">A confidence score between 0 and 1. Scores
        /// close to 1 indicate 100% certainty that the identified language is
        /// true.</param>
        public DetectedLanguage(string name = default(string), string iso6391Name = default(string), double? score = default(double?))
        {
            Name = name;
            Iso6391Name = iso6391Name;
            Score = score;
        }

        /// <summary>
        /// Gets or sets long name of a detected language (e.g. English,
        /// French).
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a two letter representation of the detected language
        /// according to the ISO 639-1 standard (e.g. en, fr).
        /// </summary>
        public string Iso6391Name { get; set; }

        /// <summary>
        /// Gets or sets a confidence score between 0 and 1. Scores close to 1
        /// indicate 100% certainty that the identified language is true.
        /// </summary>
        public double? Score { get; set; }
    }
}
