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

        /// <summary> Initializes a new instance of TextBlocklist. </summary>
        /// <param name="blocklistName"> Text blocklist name. </param>
        /// <param name="description"> Text blocklist description. </param>
        internal TextBlocklist(string blocklistName, string description)
        {
            BlocklistName = blocklistName;
            _description = description;
        }

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
