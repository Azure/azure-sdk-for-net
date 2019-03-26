using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.CognitiveServices.Vision.Face.Models;

namespace Microsoft.Azure.CognitiveServices.Vision.Face
{
    /// <summary>
    /// Extension methods for Emotion.
    /// </summary>
    public static partial class EmotionExtensions
    {
        /// <summary>
        /// Create a sorted key-value pair of emotions and the corresponding scores, sorted from highest score on down.
        /// Sorting criteria: Score is the primary key sorted descending, and the name is the secondary key sorted alphabetically.
        /// </summary>
        public static IEnumerable<KeyValuePair<string, double>> ToRankedList(this Emotion emotionScores)
        {
            return new Dictionary<string, double>()
            {
                { "Anger", emotionScores.Anger },
                { "Contempt", emotionScores.Contempt },
                { "Disgust", emotionScores.Disgust },
                { "Fear", emotionScores.Fear },
                { "Happiness", emotionScores.Happiness },
                { "Neutral", emotionScores.Neutral },
                { "Sadness", emotionScores.Sadness },
                { "Surprise", emotionScores.Surprise }
            }
            .OrderByDescending(emotion => emotion.Value)
            .ThenBy(emotion => emotion.Key);
        }
    }
}
