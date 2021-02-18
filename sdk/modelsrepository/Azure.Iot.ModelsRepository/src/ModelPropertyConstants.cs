// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Iot.ModelsRepository
{
    /// <summary>
    /// The <c>ModelPropertyConstants</c> class contains DTDL v2 property names and property values
    /// used by the <c>ModelQuery</c> class to parse DTDL model key indicators.
    /// </summary>
    internal static class ModelPropertyConstants
    {
        public const string Dtmi = "@id";
        public const string Type = "@type";
        public const string Extends = "extends";
        public const string Contents = "contents";
        public const string Schema = "schema";
        public const string TypeValueInterface = "Interface";
        public const string TypeValueComponent = "Component";
    }
}
