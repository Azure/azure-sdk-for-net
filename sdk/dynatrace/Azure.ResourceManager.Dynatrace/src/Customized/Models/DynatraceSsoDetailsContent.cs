// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.Dynatrace.Models
{
    public partial class DynatraceSsoDetailsContent
    {
        /// <summary> Initializes a new instance of <see cref="DynatraceSsoDetailsContent"/>. </summary>
        public DynatraceSsoDetailsContent()
        {
        }

        /// <summary> user principal id of the user. </summary>
        public string UserPrincipal { get; set; }
    }
}
