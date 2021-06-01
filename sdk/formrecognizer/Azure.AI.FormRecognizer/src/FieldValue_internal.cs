﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.FormRecognizer.Models
{
    [CodeGenModel("FieldValue")]
    internal partial class FieldValue_internal
    {
        /// <summary>Integer value.</summary>
        public long? ValueInteger { get; }

        /// <summary> Selection mark value. </summary>
        public SelectionMarkState? ValueSelectionMark { get; }

        internal FieldValue_internal(string value)
        {
            Type = FieldValueType.String;
            ValueString = value;
            Text = value;
        }
    }
}
