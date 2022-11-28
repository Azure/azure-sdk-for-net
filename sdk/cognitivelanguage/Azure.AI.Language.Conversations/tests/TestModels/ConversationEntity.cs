// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    /// <summary> The entity extraction result of a Conversation project. </summary>
    public partial class ConversationEntity
    {
        /// <summary> Initializes a new instance of ConversationEntity. </summary>
        /// <param name="category"> The entity category. </param>
        /// <param name="text"> The predicted entity text. </param>
        /// <param name="offset"> The starting index of this entity in the query. </param>
        /// <param name="length"> The length of the text. </param>
        /// <param name="confidence"> The entity confidence score. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="category"/> or <paramref name="text"/> is null. </exception>
        internal ConversationEntity(string category, string text, int offset, int length, float confidence)
        {
            Argument.AssertNotNull(category, nameof(category));
            Argument.AssertNotNull(text, nameof(text));

            Category = category;
            Text = text;
            Offset = offset;
            Length = length;
            Confidence = confidence;
            Resolutions = new ChangeTrackingList<BaseResolution>();
            ExtraInformation = new ChangeTrackingList<BaseExtraInformation>();
        }

        /// <summary> Initializes a new instance of ConversationEntity. </summary>
        /// <param name="category"> The entity category. </param>
        /// <param name="text"> The predicted entity text. </param>
        /// <param name="offset"> The starting index of this entity in the query. </param>
        /// <param name="length"> The length of the text. </param>
        /// <param name="confidence"> The entity confidence score. </param>
        /// <param name="resolutions">
        /// The collection of entity resolution objects.
        /// Please note <see cref="BaseResolution"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="AgeResolution"/>, <see cref="AreaResolution"/>, <see cref="BooleanResolution"/>, <see cref="CurrencyResolution"/>, <see cref="DateTimeResolution"/>, <see cref="InformationResolution"/>, <see cref="LengthResolution"/>, <see cref="NumberResolution"/>, <see cref="NumericRangeResolution"/>, <see cref="OrdinalResolution"/>, <see cref="SpeedResolution"/>, <see cref="TemperatureResolution"/>, <see cref="TemporalSpanResolution"/>, <see cref="VolumeResolution"/> and <see cref="WeightResolution"/>.
        /// </param>
        /// <param name="extraInformation">
        /// The collection of entity extra information objects.
        /// Please note <see cref="BaseExtraInformation"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="EntitySubtype"/>, <see cref="ListKey"/> and <see cref="RegexKey"/>.
        /// </param>
        internal ConversationEntity(string category, string text, int offset, int length, float confidence, IReadOnlyList<BaseResolution> resolutions, IReadOnlyList<BaseExtraInformation> extraInformation)
        {
            Category = category;
            Text = text;
            Offset = offset;
            Length = length;
            Confidence = confidence;
            Resolutions = resolutions;
            ExtraInformation = extraInformation;
        }

        /// <summary> The entity category. </summary>
        public string Category { get; }
        /// <summary> The predicted entity text. </summary>
        public string Text { get; }
        /// <summary> The starting index of this entity in the query. </summary>
        public int Offset { get; }
        /// <summary> The length of the text. </summary>
        public int Length { get; }
        /// <summary> The entity confidence score. </summary>
        public float Confidence { get; }
        /// <summary>
        /// The collection of entity resolution objects.
        /// Please note <see cref="BaseResolution"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="AgeResolution"/>, <see cref="AreaResolution"/>, <see cref="BooleanResolution"/>, <see cref="CurrencyResolution"/>, <see cref="DateTimeResolution"/>, <see cref="InformationResolution"/>, <see cref="LengthResolution"/>, <see cref="NumberResolution"/>, <see cref="NumericRangeResolution"/>, <see cref="OrdinalResolution"/>, <see cref="SpeedResolution"/>, <see cref="TemperatureResolution"/>, <see cref="TemporalSpanResolution"/>, <see cref="VolumeResolution"/> and <see cref="WeightResolution"/>.
        /// </summary>
        public IReadOnlyList<BaseResolution> Resolutions { get; }
        /// <summary>
        /// The collection of entity extra information objects.
        /// Please note <see cref="BaseExtraInformation"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="EntitySubtype"/>, <see cref="ListKey"/> and <see cref="RegexKey"/>.
        /// </summary>
        public IReadOnlyList<BaseExtraInformation> ExtraInformation { get; }
    }
}
