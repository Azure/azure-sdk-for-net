// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Azure.ResourceManager.TestFramework
{
    public class ApiVersionHelper
    {
        public static readonly DateTime ApiVersionTagLroAsynOperation = new DateTime(2022, 09, 01);
        public static bool IsApiVersionGreaterThan(string apiVersionInput, DateTime dateTimeToCompare)
        {
            var dateTime = DateTime.Parse(apiVersionInput);
            return dateTime >= dateTimeToCompare;
        }
    }
}
