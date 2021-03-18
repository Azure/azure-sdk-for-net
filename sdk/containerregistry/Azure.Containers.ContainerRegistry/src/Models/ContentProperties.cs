// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.Containers.ContainerRegistry
{
    /// <summary>
    /// </summary>
    [CodeGenModel("ChangeableAttributes")]
    public partial class ContentProperties
    {
        /// <summary>
        /// </summary>
        [CodeGenMember("DeleteEnabled")]
        public bool CanDelete { get; set; } = true;

        /// <summary>
        /// </summary>
        [CodeGenMember("WriteEnabled")]
        public bool CanWrite { get; set; } = true;

        /// <summary>
        /// </summary>
        [CodeGenMember("ListEnabled")]
        public bool CanList { get; set; } = true;

        /// <summary>
        /// </summary>
        [CodeGenMember("ReadEnabled")]
        public bool CanRead { get; set; } = true;
    }
}
