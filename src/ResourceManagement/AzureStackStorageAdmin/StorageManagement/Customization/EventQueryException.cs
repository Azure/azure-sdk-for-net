//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using System.Globalization;
using System.Runtime.Serialization;

namespace Microsoft.AzureStack.AzureConsistentStorage
{
    /// <summary>
    /// Exception thrown when query event by azure sdk.
    /// </summary>    
    public class EventQueryException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EventQueryException"/> class.
        /// </summary>
        public EventQueryException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EventQueryException"/> class.
        /// </summary>
        /// <param name="message">error message</param>
        public EventQueryException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EventQueryException"/> class.
        /// </summary>
        /// <param name="format">msg formated string</param>
        /// <param name="args">arguments in formated string</param>
        public EventQueryException(string format, params object[] args)
            : base(string.Format(CultureInfo.InvariantCulture, format, args))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EventQueryException"/> class.
        /// </summary>
        /// <param name="message">error message</param>
        /// <param name="innerException">inner exception</param>
        public EventQueryException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
        
    }
}
