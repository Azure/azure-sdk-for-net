// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.DigitalTwins.Core
{
    /// <summary>
    /// The service-defined fields of a digital twin.
    /// </summary>
    public interface IDigitalTwin
    {
        /// <summary>
        /// The unique Id of the digital twin in a digital twins instance. This field is present on every digital twin.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// A string representing a weak ETag for the entity that this request performs an operation against, as per RFC7232.
        /// </summary>
        public ETag ETag { get; set; }
    }
}
