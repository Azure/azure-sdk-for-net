// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Microsoft.Azure.Management.StorSimple8000Series;
using Microsoft.Azure.Management.StorSimple8000Series.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace StorSimple8000Series.Tests
{
    public static class TestUtilities
    {
        public static string GetDoubleEncoded(this string input)
        {
            return Uri.EscapeDataString(Uri.EscapeDataString(input));
        }
    }
}
