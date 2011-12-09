//-----------------------------------------------------------------------
// <copyright file="CanonicalizedString.cs" company="Microsoft">
//    Copyright 2011 Microsoft Corporation
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// <summary>
//    Contains code for the CanonicalizedString class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient.Protocol
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Globalization;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using Microsoft.WindowsAzure.StorageClient;

    /// <summary>
    /// An internal class that stores the canonicalized string version of an HTTP request.
    /// </summary>
    internal class CanonicalizedString
    {
        /// <summary>
        /// Stores the internal <see cref="StringBuilder"/> that holds the canonicalized string.
        /// </summary>
        private StringBuilder canonicalizedString = new StringBuilder();

        /// <summary>
        /// Initializes a new instance of the <see cref="CanonicalizedString"/> class.
        /// </summary>
        /// <param name="initialElement">The first canonicalized element to start the string with.</param>
        internal CanonicalizedString(string initialElement)
        {
            this.canonicalizedString.Append(initialElement);
        }

        /// <summary>
        /// Gets the canonicalized string.
        /// </summary>
        internal string Value
        {
            get
            {
                return this.canonicalizedString.ToString();
            }
        }

        /// <summary>
        /// Append additional canonicalized element to the string.
        /// </summary>
        /// <param name="element">An additional canonicalized element to append to the string.</param>
        internal void AppendCanonicalizedElement(string element)
        {
            this.canonicalizedString.Append("\n");
            this.canonicalizedString.Append(element);
        }
    }
}