// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.ClientModel.TestFramework;

/// <summary>
/// TODO.
/// </summary>
public class RecordEntryMessage
{
    /// <summary>
    /// TODO.
    /// </summary>
    public SortedDictionary<string, string[]> Headers { get; set; } = new SortedDictionary<string, string[]>(StringComparer.InvariantCultureIgnoreCase);

    /// <summary>
    /// TODO.
    /// </summary>
    public byte[]? Body { get; set; }

    /// <summary>
    /// TODO.
    /// </summary>
    /// <param name="contentType"></param>
    /// <returns></returns>
    public bool TryGetContentType(out string contentType)
    {
        throw new NotImplementedException();
        //contentType = null;
        //if (Headers.TryGetValue("Content-Type", out var contentTypes) &&
        //    contentTypes.Length == 1)
        //{
        //    contentType = contentTypes[0];
        //    return true;
        //}
        //return false;
    }

    /// <summary>
    /// TODO.
    /// </summary>
    /// <param name="encoding"></param>
    /// <returns></returns>
    public bool IsTextContentType(out Encoding encoding)
    {
        throw new NotImplementedException();
        //encoding = null;
        //return TryGetContentType(out string contentType) &&
        //       ContentTypeUtilities.TryGetTextEncoding(contentType, out encoding);
    }

    /// <summary>
    /// TODO.
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public bool TryGetBodyAsText(out string text)
    {
        throw new NotImplementedException();
        //text = null;

        //if (IsTextContentType(out Encoding encoding))
        //{
        //    text = encoding.GetString(Body);

        //    return true;
        //}

        //return false;
    }
}
