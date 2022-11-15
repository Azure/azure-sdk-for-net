// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Maps.Rendering
{
    /// <summary> The RegionalCopyright. </summary>
    [CodeGenModel("RegionCopyrights")]
    public partial class RegionalCopyright
    {
        /// <summary> Initializes a new instance of RegionalCopyright. </summary>
        internal RegionalCopyright()
        {
            Copyrights = new ChangeTrackingList<string>();
        }

        /// <summary> Initializes a new instance of RegionalCopyright. </summary>
        /// <param name="copyrights"> Copyrights list. </param>
        /// <param name="country"> Country property. </param>
        internal RegionalCopyright(IReadOnlyList<string> copyrights, RegionalCopyrightCountry country)
        {
            Copyrights = copyrights;
            Country = country;
        }

        /// <summary> Copyrights list. </summary>
        public IReadOnlyList<string> Copyrights { get; }
        /// <summary> Country property. </summary>
        public RegionalCopyrightCountry Country { get; }
    }
}
