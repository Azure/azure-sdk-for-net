// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.Containers.ContainerRegistry.Storage.Models
{
    [CodeGenModel("Platform")]
    public partial class RuntimePlatform
    {
        /// <summary> CPU architecture. </summary>
        [CodeGenMember("Architecture")]
        public string CpuArchitecture { get; set; }

        /// <summary> The os field specifies the operating system, for example linux or windows. </summary>
        [CodeGenMember("Os")]
        public string OperatingSystem { get; set; }

        /// <summary> The optional features field specifies an array of strings, each listing a required CPU feature (for example sse4 or aes. </summary>
        [CodeGenMember("Features")]
        public IList<string> CpuFeatures { get; }
    }
}
