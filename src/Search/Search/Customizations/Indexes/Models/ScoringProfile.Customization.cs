// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Models
{
    using System;
    using Newtonsoft.Json;

    public partial class ScoringProfile
    {
        /// <summary>
        /// Gets or sets parameters that boost scoring based on text
        /// matches in certain index fields.
        /// </summary>
        [JsonIgnore]
        public TextWeights TextWeights
        {
            get { return this.Text; }
            set { this.Text = value; }
        }
    }
}
