// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// 
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.
namespace Microsoft.Hadoop.Avro.Container
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    /// <summary>
    /// Represents a codec factory.
    /// </summary>
    public class CodecFactory
    {
        private readonly Dictionary<string, Func<Codec>> codecs = new Dictionary<string, Func<Codec>>
        {
            { NullCodec.CodecName, () => new NullCodec() },
            { DeflateCodec.CodecName, () => new DeflateCodec() }
        };

        /// <summary>
        /// Creates a codec by name.
        /// </summary>
        /// <param name="codecName">The name of the codec.</param>
        /// <returns>A new instance of the codec.</returns>
        /// <exception cref="System.ArgumentNullException">If <paramref name="codecName"/> is null.</exception>
        /// <exception cref="System.ArgumentException">If a codec with name <paramref name="codecName"/> does not exists.</exception>
        public virtual Codec Create(string codecName)
        {
            if (string.IsNullOrEmpty(codecName))
            {
                throw new ArgumentNullException("codecName");
            }

            if (!this.codecs.ContainsKey(codecName))
            {
                throw new ArgumentException(
                    string.Format(CultureInfo.InvariantCulture, "Codec name '{0}' is unknown.", codecName),
                    "codecName");
            }

            return this.codecs[codecName]();
        }
    }
}
