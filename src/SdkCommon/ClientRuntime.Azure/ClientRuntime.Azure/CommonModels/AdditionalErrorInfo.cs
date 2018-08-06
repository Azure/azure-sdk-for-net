// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Rest.ClientRuntime.Azure.CommonModels
{
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// This class represents additional info Resource Providers pass when an error occurs
    /// </summary>
    public class AdditionalErrorInfo
    {
        /// <summary>
        /// Type of error occured (e.g. PolicyViolation, SecurityViolation)
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Additional information of the type of error that occured
        /// </summary>
        public JObject Info { get; set; }
    }
}
