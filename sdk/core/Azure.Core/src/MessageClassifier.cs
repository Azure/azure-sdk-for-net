// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core
{
    /// <summary>
    /// </summary>
    public abstract class MessageClassifier
    {
        /// <summary>
        /// </summary>
        /// <param name="message"></param>
        /// <param name="isError"></param>
        /// <returns></returns>
        public abstract bool TryClassify(HttpMessage message, out bool isError);
    }
}
