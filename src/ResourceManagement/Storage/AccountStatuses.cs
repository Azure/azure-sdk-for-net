// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Storage.Fluent
{
    using Microsoft.Azure.Management.Storage.Fluent.Models;

    /// <summary>
    /// An instance of this class stores the availability of a storage account.
    /// </summary>
///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LnN0b3JhZ2UuaW1wbGVtZW50YXRpb24uQWNjb3VudFN0YXR1c2Vz
    public class AccountStatuses
    {
        /// <summary>
        /// Creates an instance of AccountStatuses class.
        /// </summary>
        /// <param name="primary">The status of the primary location.</param>
        /// <param name="secondary">The status of the secondary location.</param>
        ///GENMHASH:CEF8F82F6532A191697319055FF17B8E:FBABC45968C8A933D855C5B42E5ADB6A
        internal AccountStatuses(AccountStatus? primary, AccountStatus? secondary)
        {
            this.Primary = primary;
            this.Secondary = secondary;
        }

        /// <return>
        /// The status indicating whether the primary location of the storage
        /// account is available or unavailable.
        /// </return>
        ///GENMHASH:46645B73135AFEDAC926BE820EB4AFF7:265F211524466E40558AB295CFC0387C
        public AccountStatus? Primary
        {
            get; private set;
        }

        /// <return>
        /// The status indicating whether the secondary location of the
        /// storage account is available or unavailable. Only available if the
        /// accountType is StandardGRS or StandardRAGRS.
        /// </return>
        ///GENMHASH:BD8D51006FA39E65AA03B613332E3B24:A45A0B1AE68B70996082DCB7AD988E63
        public AccountStatus? Secondary
        {
            get; private set;
        }
    }
}