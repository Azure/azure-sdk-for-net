//-----------------------------------------------------------------------
// <copyright file="CanonicalizedString.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
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
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage.Core
{
    using System.Text;

    /// <summary>
    /// Represents a canonicalized string used in authenticating a request against the azure service.
    /// </summary>
    internal class CanonicalizedString
    {
        private const int DefaultCapacity = 300;
        private const char ElementDelimiter = '\n';

        /// <summary>
        /// Stores the internal <see cref="StringBuilder"/> that holds the canonicalized string.
        /// </summary>
        private readonly StringBuilder canonicalizedString;

        /// <summary>
        /// Initializes a new instance of the <see cref="CanonicalizedString"/> class.
        /// </summary>
        /// <param name="initialElement">The first canonicalized element to start the string with.</param>
        public CanonicalizedString(string initialElement)
            : this(initialElement, CanonicalizedString.DefaultCapacity)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CanonicalizedString"/> class.
        /// </summary>
        /// <param name="initialElement">The first canonicalized element to start the string with.</param>
        /// <param name="capacity">The starting size of the string.</param>
        public CanonicalizedString(string initialElement, int capacity)
        {
            this.canonicalizedString = new StringBuilder(initialElement, capacity);
        }

        /// <summary>
        /// Append additional canonicalized element to the string.
        /// </summary>
        /// <param name="element">An additional canonicalized element to append to the string.</param>
        public void AppendCanonicalizedElement(string element)
        {
            this.canonicalizedString.Append(CanonicalizedString.ElementDelimiter);
            this.canonicalizedString.Append(element);
        }

        /// <summary>
        /// Converts the value of this instance to a string.
        /// </summary>
        /// <returns>A string whose value is the same as this instance.</returns>
        public override string ToString()
        {
            return this.canonicalizedString.ToString();
        }
    }
}
