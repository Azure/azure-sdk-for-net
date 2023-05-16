// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core.Json;

namespace Azure.Core.Dynamic
{
    /// <summary>
    /// </summary>
    public enum DynamicDateTimeHandling
    {
        /// <summary>
        /// </summary>
        Rfc3339,

        ///// <summary>
        ///// </summary>
        //Rfc1123,

        /// <summary>
        /// </summary>
        UnixTime,
    }
}
