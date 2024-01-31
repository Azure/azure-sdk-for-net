// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace Azure.Maps.Rendering
{
    /// <summary> This object is returned from a successful copyright request. </summary>
    [CodeGenModel("Copyright")]
    public partial class RenderCopyright
    {
        /// <summary> Initializes a new instance of RenderCopyright. </summary>
        /// <param name="formatVersion"> Format Version property. </param>
        /// <param name="generalCopyrights"> General Copyrights array. </param>
        /// <param name="regionalCopyright"> Regions array. </param>
        internal RenderCopyright(string formatVersion, IReadOnlyList<string> generalCopyrights, IReadOnlyList<RegionalCopyright> regionalCopyright)
        {
            FormatVersion = formatVersion;
            GeneralCopyrights = generalCopyrights;
            RegionalCopyrights = regionalCopyright;
        }

        /// <summary> Regions array. </summary>
        [CodeGenMember("Regions")]
        public IReadOnlyList<RegionalCopyright> RegionalCopyrights { get; }
    }
}
