﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests
{
    using Newtonsoft.Json;

    [JsonConverter(typeof(CustomBookConverter<CustomBookWithConverter>))]
    internal class CustomBookWithConverter : CustomBook
    {
    }
}
