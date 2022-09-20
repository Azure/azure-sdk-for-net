// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.Maps.Rendering
{
    /// <summary> This object is returned from a successful copyright call. </summary>
    public partial class CopyrightCaption
    {
        /// <summary> Initializes a new instance of CopyrightCaption. </summary>
        /// <param name="formatVersion"> Format Version property. </param>
        /// <param name="copyright"> Copyrights Caption property. </param>
        internal CopyrightCaption(string formatVersion, string copyright)
        {
            FormatVersion = formatVersion;
            Copyright = copyright;
        }

        /// <summary> Copyrights Caption property. </summary>
        [CodeGenMember("CopyrightsCaption")]
        public string Copyright { get; }
    }
}
