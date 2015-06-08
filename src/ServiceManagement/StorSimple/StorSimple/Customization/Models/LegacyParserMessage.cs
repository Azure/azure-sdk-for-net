// ----------------------------------------------------------------------------------
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

using System.Collections.Generic;

namespace Microsoft.WindowsAzure.Management.StorSimple.Customization.Models
{
    /// <summary>
    /// Parser message
    /// </summary>
    public class LegacyParserMessage
    {
        /// <summary>
        /// Gets or sets Message type indicating the criticality of message to be displayed
        /// </summary>
        public MessageType Type { get; set; }

        /// <summary>
        /// Gets or sets Object type which can be parsed by the parser for which the message is logged
        /// </summary>
        public LegacyObjectsSupported ObjectType {get;set;}

        /// <summary>
        /// Gets or sets the common reason for which the message is logged
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// Gets or sets custom messages to be displayed
        /// </summary>
        public List<string> CustomMessageList { get; set; }
    }
}