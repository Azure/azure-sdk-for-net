// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.AI.Translation.Text.Models
{
    /// <summary> Input Text Element for Translator Requests. </summary>
    internal class InputText
    {
        public string Text { get; set; }

        public InputText(string inputText)
        {
            this.Text = inputText;
        }
    }
}
