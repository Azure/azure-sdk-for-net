// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.Language.Text.Authoring
{
    /// <summary> Represents the options used to create or update a project. </summary>
    [CodeGenSuppress("TextAuthoringCreateProjectDetails", typeof(TextAuthoringProjectKind), typeof(string), typeof(string), typeof(string))]
    public partial class TextAuthoringCreateProjectDetails
    {
        /// <summary> Initializes a new instance of <see cref="TextAuthoringCreateProjectDetails"/>. </summary>
        /// <param name="projectKind"> The project kind. </param>
        /// <param name="storageInputContainerName"> The storage container name. </param>
        /// <param name="language"> The project language. This is BCP-47 representation of a language. For example, use "en" for English, "en-gb" for English (UK), "es" for Spanish etc. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="storageInputContainerName"/> or <paramref name="language"/> is null. </exception>
        public TextAuthoringCreateProjectDetails(TextAuthoringProjectKind projectKind, string storageInputContainerName, string language)
        {
            Argument.AssertNotNull(storageInputContainerName, nameof(storageInputContainerName));
            Argument.AssertNotNull(language, nameof(language));

            ProjectKind = projectKind;
            StorageInputContainerName = storageInputContainerName;
            Language = language;
        }

        /// <summary> The new project name. </summary>
        public string ProjectName { get; set; }
    }
}
