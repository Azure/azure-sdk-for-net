// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.Data.Batch.Models
{
    public static class ModelHelpers
    {
        public static RequestContent ToRequestContent(Object modelContent)
        {
            Utf8JsonRequestContent content = new();
            content.JsonWriter.WriteObjectValue(modelContent);
            return content;
        }
    }
}
