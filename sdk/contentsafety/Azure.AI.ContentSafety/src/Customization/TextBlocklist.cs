// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.AI.ContentSafety
{
    /// <summary> Text Blocklist. </summary>
    public partial class TextBlocklist
    {
        private string _description;
        private bool _isDiscriptionChanged = false;

        /// <summary> Text blocklist description. </summary>
        public string Description
        {
            get => _description;
            set
            {
                _isDiscriptionChanged = true;
                _description = value;
            }
        }
    }
}
