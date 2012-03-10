//
// Copyright 2012 Microsoft Corporation
// 
// Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.
//

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.ServiceLayer
{
    /// <summary>
    /// Helper class for saving and restoring position in a stream.
    /// </summary>
    internal class StreamPositionGuard: IDisposable
    {
        private Stream _stream;                             // Guarded stream.
        private long _position;                             // Saved position.

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="stream">Stream to be guarded.</param>
        internal StreamPositionGuard(Stream stream)
        {
            Debug.Assert(stream.CanSeek);
            _stream = stream;
            _position = stream.Position;
        }

        /// <summary>
        /// Disposes the guard and restores saved position.
        /// </summary>
        void IDisposable.Dispose()
        {
            _stream.Position = _position;
        }
    }
}
