// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace Azure.AI.Translation.Document
{
    /// <summary>
    /// Possible file formats supported by the Document Translation service.
    /// </summary>
    [CodeGenModel("FileFormat")]
    public partial class DocumentTranslationFileFormat
    {
        /// <summary> Supported format versions. </summary>
        [CodeGenMember("Versions")]
        public IReadOnlyList<string> FormatVersions { get; }

        /// <summary> Default format version if none is specified. </summary>
        [CodeGenMember("DefaultVersion")]
        public string DefaultFormatVersion { get; }

        /// <summary> Initializes a new instance of <see cref="DocumentTranslationFileFormat"/>. </summary>
        /// <param name="format"> Name of the format. </param>
        /// <param name="fileExtensions"> Supported file extension for this format. </param>
        /// <param name="contentTypes"> Supported Content-Types for this format. </param>
        /// <param name="defaultFormatVersion"> Default version if none is specified. </param>
        /// <param name="formatVersions"> Supported Version. </param>
        internal DocumentTranslationFileFormat(string format, IReadOnlyList<string> fileExtensions, IReadOnlyList<string> contentTypes, string defaultFormatVersion, IReadOnlyList<string> formatVersions)
        {
            Format = format;
            FileExtensions = fileExtensions;
            ContentTypes = contentTypes;
            DefaultFormatVersion = defaultFormatVersion;
            FormatVersions = formatVersions;
        }
    }
}
