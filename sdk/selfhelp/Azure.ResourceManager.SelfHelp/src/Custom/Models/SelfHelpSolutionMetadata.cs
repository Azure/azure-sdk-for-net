// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.SelfHelp.Models
{
    public partial class SelfHelpSolutionMetadata
    {
        /// <summary> Solution Id. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string SolutionId
        {
            get => throw new NotSupportedException("SolutionId property is not supported.");
            set => throw new NotSupportedException("SolutionId property is not supported.");
        }

        /// <summary> Solution Type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string SolutionType
        {
            get => throw new NotSupportedException("SolutionType property is not supported.");
            set => throw new NotSupportedException("SolutionType property is not supported.");
        }

        /// <summary> A detailed description of solution. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Description
        {
            get => throw new NotSupportedException("Description property is not supported.");
            set => throw new NotSupportedException("Description property is not supported.");
        }

        /// <summary> Required parameters for invoking this particular solution. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<IList<string>> RequiredParameterSets => throw new NotSupportedException("RequiredParameterSets property is not supported.");
    }
}
