// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Text;
using System.Text.Json;
using Azure.Core;

namespace Azure.Media.LiveVideoAnalytics.Edge.Models
{
    public partial class OperationBase
    {
        /// <summary>
        /// Method name
        /// </summary>
        public string MethodName { get; set; }

        /// <summary>
        /// GetPayloadAsJSON function.
        /// </summary>
        /// <returns></returns>
        public virtual string GetPayloadAsJSON() { return string.Empty; }
    }
}
