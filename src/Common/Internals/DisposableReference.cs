//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;

namespace Microsoft.WindowsAzure.Common.Internals
{
    public class DisposableReference<T>
        : IDisposable
        where T : class, IDisposable
    {
        public T Reference { get; private set; }
        public uint ReferenceCount { get; private set; }
        private object _lock = new object();

        public DisposableReference(T reference)
        {
            if (reference == null)
            {
                throw new ArgumentNullException("reference");
            }

            Reference = reference;
            ReferenceCount = 1;
        }

        public void AddReference()
        {
            lock (_lock)
            {
               ReferenceCount++;
            }
        }

        public void ReleaseReference()
        {
            lock (_lock)
            {                
                if (ReferenceCount == 0)
                {
                    throw new ObjectDisposedException(typeof(T).FullName);
                }

                if (--ReferenceCount == 0)
                {
                    Reference.Dispose();
                    Reference = null;
                }
            }
        }

        void IDisposable.Dispose()
        {
            ReleaseReference();
        }
    }
}
