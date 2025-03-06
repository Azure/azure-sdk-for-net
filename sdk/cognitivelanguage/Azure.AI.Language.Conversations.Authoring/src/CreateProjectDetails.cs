// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.Language.Conversations.Authoring
{
    /// <summary> Represents the options used to create or update a project. </summary>
    [CodeGenSuppress("CreateProjectDetails", typeof(ConversationAuthoringProjectKind), typeof(string), typeof(string))]
    public partial class ConversationAuthoringCreateProjectDetails
    {
        /// <summary> The new project name. </summary>
        public string ProjectName { get; set; }

        /// <summary> Initializes a new instance of <see cref="ConversationAuthoringCreateProjectDetails"/>. </summary>
        /// <param name="projectKind"> Represents the project kind. </param>
        /// <param name="language"> The project language. This is BCP-47 representation of a language. For example, use "en" for English, "en-gb" for English (UK), "es" for Spanish etc. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="language"/> is null. </exception>
        public ConversationAuthoringCreateProjectDetails(ConversationAuthoringProjectKind projectKind, string language)
        {
            Argument.AssertNotNull(language, nameof(language));

            ProjectKind = projectKind;
            Language = language;
        }
    }
}
