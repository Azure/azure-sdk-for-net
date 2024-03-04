// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text;

namespace Azure.Core
{
    /// <summary>
    /// A collection of extension methods for <see cref="RequestContent"/>.
    /// </summary>
    public static class RequestContentExtensions
    {
        /// <summary>
        /// Converts a <see cref="MultipartContent"/> to a <see cref="RequestContent"/>.
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static RequestContent ToRequestContent(this MultipartContent content)
        {
            throw new NotImplementedException();
        }
    }
}
