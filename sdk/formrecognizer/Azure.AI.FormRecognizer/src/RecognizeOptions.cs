// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.AI.FormRecognizer.Models
{
    /// <summary>
    /// </summary>
    public class RecognizeOptions
    {
        internal RecognizeOptions()
        {
        }

        /// <summary>
        /// </summary>
        public bool IncludeTextContent { get; set; } = false;

        /// <summary>
        /// </summary>
        public bool IncludeCheckboxes { get; set; } = true;

        /// <summary>
        /// </summary>
        public bool IncludeTables { get; set; } = true;

        /// <summary>
        /// </summary>
        public string ModelVersion { get; set; }
    }
}
