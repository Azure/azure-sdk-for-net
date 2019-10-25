// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Azure.Storage.Files.DataLake.Models;

namespace Azure.Storage.Files.DataLake
{
    internal static class PathUpdateResultExtensions
    {
        internal static PathContentInfo ToPathContentInfo(this PathUpdateResult pathUpdateResult) =>
            new PathContentInfo()
            {
                ContentHash = pathUpdateResult.ContentMD5,
                ETag = pathUpdateResult.ETag,
                LastModified = pathUpdateResult.LastModified,
                AcceptRanges = pathUpdateResult.AcceptRanges,
                CacheControl = pathUpdateResult.CacheControl,
                ContentDisposition = pathUpdateResult.ContentDisposition,
                ContentEncoding = pathUpdateResult.ContentEncoding,
                ContentLanguage = pathUpdateResult.ContentLanguage,
                ContentLength = pathUpdateResult.ContentLength,
                ContentRange = pathUpdateResult.ContentRange,
                ContentType = pathUpdateResult.ContentType,
                Metadata = ToMetadata(pathUpdateResult.Properties)
            };

        private static IDictionary<string, string> ToMetadata(string rawMetdata)
        {
            if (rawMetdata == null)
            {
                return null;
            }

            IDictionary<string, string> metadataDictionary = new Dictionary<string, string>();
            string[] metadataArray = rawMetdata.Split(',');
            foreach (string entry in metadataArray)
            {
                string[] entryArray = entry.Split('=');
                byte[] valueArray = Convert.FromBase64String(entryArray[1]);
                metadataDictionary.Add(entryArray[0], Encoding.UTF8.GetString(valueArray));
            }
            return metadataDictionary;
        }
    }
}
