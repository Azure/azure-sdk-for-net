// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Text;
using System.Text.Json;
using Azure.Core;

namespace Azure.Media.LiveVideoAnalytics.Edge.Models
{
    public partial class ItemNonSetRequestBase
    {
        /// <summary>
        ///  Serialize .
        /// </summary>
        /// <returns></returns>
        public string GetPayloadAsJSON()
        {
            return Data.Serialize();
        }
    }
}
