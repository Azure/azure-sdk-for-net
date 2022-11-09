// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    [CodeGenModel("CallingOperationResultDetails", Usage = new string[] { "output" }, Formats = new string[] { "json" })]
    public partial class CallingOperationResultDetails
    {
        /// <summary>
        /// Deserialize <see cref="CallingOperationResultDetails"/> event.
        /// </summary>
        /// <param name="content">The json content.</param>
        /// <returns>The new <see cref="CallingOperationResultDetails"/> object.</returns>
        public static CallingOperationResultDetails Deserialize(string content)
        {
            using var document = JsonDocument.Parse(content);
            JsonElement element = document.RootElement;

            var internalEvent = CallingOperationResultDetails.DeserializeCallingOperationResultDetailsInternal(element);
            return new CallingOperationResultDetails(internalEvent);
        }
    }
}
