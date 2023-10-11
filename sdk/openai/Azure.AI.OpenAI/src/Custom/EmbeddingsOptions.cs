// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.AI.OpenAI
{
    /// <summary> Schema to create a prompt completion from a deployment. </summary>
    public partial class EmbeddingsOptions
    {
        internal string InternalNonAzureModelName { get; set; }

        /// <inheritdoc cref="EmbeddingsOptions.EmbeddingsOptions(System.Collections.Generic.IEnumerable{string})"/>
        public EmbeddingsOptions(string input)
            : this(new string[] { input })
        {
        }

        /// <inheritdoc cref="EmbeddingsOptions.EmbeddingsOptions(System.Collections.Generic.IEnumerable{string})"/>
        public EmbeddingsOptions()
        {
            // CUSTOM CODE NOTE: Empty constructors are added to options classes to facilitate property-only use; this
            //                      may be reconsidered for required payload constituents in the future.
        }
    }
}
