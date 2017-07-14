// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Storage.Fluent
{
    using Microsoft.Azure.Management.Storage.Fluent.Models;

    /// <summary>
    /// An instance of this class stores the The URIs associated with a storage
    /// account that are used to perform a retrieval of a public blob, queue or
    /// table object.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnN0b3JhZ2UuUHVibGljRW5kcG9pbnRz
    public class PublicEndpoints
    {
        /// <summary>
        /// Creates an instance of PublicEndpoints with two access endpoints.
        /// </summary>
        /// <param name="primary">The primary endpoint.</param>
        /// <param name="secondary">The secondary endpoint.</param>
        ///GENMHASH:A303AEE2C9D7F0147D4261B866884843:FBABC45968C8A933D855C5B42E5ADB6A
        internal PublicEndpoints(Endpoints primary, Endpoints secondary)
        {
            Primary = primary;
            Secondary = secondary;
        }

        /// <return>
        /// The URLs that are used to perform a retrieval of a public blob,
        /// queue or table object.Note that StandardZRS and PremiumLRS accounts
        /// only return the blob endpoint.
        /// </return>
        ///GENMHASH:46645B73135AFEDAC926BE820EB4AFF7:265F211524466E40558AB295CFC0387C
        public Endpoints Primary
        {
            get; private set;
        }

        /// <return>
        /// The URLs that are used to perform a retrieval of a public blob,
        /// queue or table object from the secondary location of the storage
        /// account. Only available if the accountType is StandardRAGRS.
        /// </return>
        ///GENMHASH:BD8D51006FA39E65AA03B613332E3B24:A45A0B1AE68B70996082DCB7AD988E63
        public Endpoints Secondary
        {
            get; private set;
        }
    }
}