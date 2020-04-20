// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.AI.FormRecognizer.Models
{
    [CodeGenModel("FieldValue")]
    internal partial class FieldValue_internal
    {
        internal FieldValue_internal(string value)
        {
            Type = FieldValueType.StringType;
            ValueString = value;
            Text = value;
        }
    }
}
