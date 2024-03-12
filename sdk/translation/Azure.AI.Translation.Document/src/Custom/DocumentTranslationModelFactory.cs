﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using Azure.AI.Translation.Document.Models;
using Azure.Core;

namespace Azure.AI.Translation.Document
{
    [CodeGenSuppress("SupportedFileFormats", typeof(IEnumerable<DocumentTranslationFileFormat>))]
    [CodeGenSuppress("DocumentTranslationFileFormat", typeof(string), typeof(IEnumerable<string>), typeof(IEnumerable<string>), typeof(string), typeof(IEnumerable<string>))]
    [CodeGenSuppress("SupportedStorageSources", typeof(IEnumerable<StorageSource>))]
    public static partial class DocumentTranslationModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Models.SupportedFileFormats"/>. </summary>
        /// <param name="value"> list of objects. </param>
        /// <returns> A new <see cref="Models.SupportedFileFormats"/> instance for mocking. </returns>
        public static SupportedFileFormats SupportedFileFormats(IEnumerable<DocumentTranslationFileFormat> value = null)
        {
            value ??= new List<DocumentTranslationFileFormat>();

            return new SupportedFileFormats(value?.ToList());
        }

        /// <summary> Initializes a new instance of <see cref="Document.DocumentTranslationFileFormat"/>. </summary>
        /// <param name="format"> Name of the format. </param>
        /// <param name="fileExtensions"> Supported file extension for this format. </param>
        /// <param name="contentTypes"> Supported Content-Types for this format. </param>
        /// <param name="defaultFormatVersion"> Default version if none is specified. </param>
        /// <param name="formatVersions"> Supported Version. </param>
        /// <returns> A new <see cref="Document.DocumentTranslationFileFormat"/> instance for mocking. </returns>
        public static DocumentTranslationFileFormat DocumentTranslationFileFormat(string format = null, IEnumerable<string> fileExtensions = null, IEnumerable<string> contentTypes = null, string defaultFormatVersion = null, IEnumerable<string> formatVersions = null)
        {
            fileExtensions ??= new List<string>();
            contentTypes ??= new List<string>();
            formatVersions ??= new List<string>();

            return new DocumentTranslationFileFormat(format, fileExtensions?.ToList(), contentTypes?.ToList(), defaultFormatVersion, formatVersions?.ToList());
        }

        /// <summary> Initializes a new instance of <see cref="Models.SupportedStorageSources"/>. </summary>
        /// <param name="value"> list of objects. </param>
        /// <returns> A new <see cref="Models.SupportedStorageSources"/> instance for mocking. </returns>
        public static SupportedStorageSources SupportedStorageSources(IEnumerable<StorageSource> value = null)
        {
            value ??= new List<StorageSource>();

            return new SupportedStorageSources(value?.ToList());
        }
    }
}
