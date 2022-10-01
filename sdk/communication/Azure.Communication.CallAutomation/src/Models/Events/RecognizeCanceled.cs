﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The Recognize Canceled event.
    /// </summary>
    [CodeGenModel("RecognizeCanceled", Usage = new string[] { "output" }, Formats = new string[] { "json" })]
    public partial class RecognizeCanceled : CallAutomationEventBase
    {
        /// <summary>
        /// Deserialize <see cref="RecognizeCanceled"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="RecognizeCanceled"/> object.</returns>
        public static RecognizeCanceled Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            return DeserializeRecognizeCanceled(element);
        }
    }
}
