// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.AI.Language.Conversations.Authoring
{
    /// <summary> Represents the options used to create or update a project. </summary>
    public partial class CreateProjectDetails
    {
        /// <summary> The new project name. </summary>
        public string ProjectName { get; set; }
    }
}
