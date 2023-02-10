// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    /// <summary> Represents the prediction section of a Conversation project. </summary>
    public partial class ConversationPrediction : BasePrediction
    {
        /// <summary> Initializes a new instance of ConversationPrediction. </summary>
        /// <param name="intents"> The intent classification results. </param>
        /// <param name="entities"> The entity extraction results. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="intents"/> or <paramref name="entities"/> is null. </exception>
        internal ConversationPrediction(IEnumerable<ConversationIntent> intents, IEnumerable<ConversationEntity> entities)
        {
            Argument.AssertNotNull(intents, nameof(intents));
            Argument.AssertNotNull(entities, nameof(entities));

            Intents = intents.ToList();
            Entities = entities.ToList();
            ProjectKind = ProjectKind.Conversation;
        }

        /// <summary> Initializes a new instance of ConversationPrediction. </summary>
        /// <param name="projectKind"> The type of the project. </param>
        /// <param name="topIntent"> The intent with the highest score. </param>
        /// <param name="intents"> The intent classification results. </param>
        /// <param name="entities"> The entity extraction results. </param>
        internal ConversationPrediction(ProjectKind projectKind, string topIntent, IReadOnlyList<ConversationIntent> intents, IReadOnlyList<ConversationEntity> entities) : base(projectKind, topIntent)
        {
            Intents = intents;
            Entities = entities;
            ProjectKind = projectKind;
        }

        /// <summary> The intent classification results. </summary>
        public IReadOnlyList<ConversationIntent> Intents { get; }
        /// <summary> The entity extraction results. </summary>
        public IReadOnlyList<ConversationEntity> Entities { get; }
    }
}
