// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Messaging
{
    internal class CloudEventConstants
    {
        // Reserved property names
        public const string SpecVersion = "specversion";
        public const string Id = "id";
        public const string Source = "source";
        public const string Type = "type";
        public const string DataContentType = "datacontenttype";
        public const string DataSchema = "dataschema";
        public const string Subject = "subject";
        public const string Time = "time";
        public const string Data = "data";
        public const string DataBase64 = "data_base64";

        // Error constants
        public const string ErrorStrictSuggestion =
            "The strict parameter can be set to 'false' in the CloudEvent.Parse method to relax this requirement.";
    }
}
