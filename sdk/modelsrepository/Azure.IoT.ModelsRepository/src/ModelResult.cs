// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Azure.IoT.ModelsRepository
{
    /// <summary>
    /// Type encompassing repository fetched digital twin model content.
    /// </summary>
    public class ModelResult
    {
        /// <summary>
        /// Digital twin model content where each key-value pair consists
        /// of a digital twin model Id and the corresponding model definition.
        /// </summary>
        public IReadOnlyDictionary<string, string> Content { get; }

        internal ModelResult(IReadOnlyDictionary<string, string> content)
        {
            Content = content;
        }
    }
}
