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

using System.Collections;
using System.Collections.Generic;

namespace Microsoft.WindowsAzure.Common.Internals
{
    public class LazyList<T> : IList<T>, ILazyCollection
    {
        private IList<T> _internalList;
        private IList<T> InternalList
        {
            get
            {
                if (_internalList == null)
                {
                    _internalList = new List<T>();
                }

                return _internalList;
            }

            set
            {
                _internalList = value;
            }
        }

        public bool IsInitialized
        {
            get { return _internalList != null; }
        }

        public LazyList()
        {
            // Default constructor is lazy so it doesn't initialize the list
        }

        public LazyList(IEnumerable<T> collection)
        {
            InternalList = new List<T>(collection);
        }

        public LazyList(int capacity)
        {
            InternalList = new List<T>(capacity);
        }

        public int IndexOf(T item)
        {
            return InternalList.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            InternalList.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            InternalList.RemoveAt(index);
        }

        public T this[int index]
        {
            get { return InternalList[index]; }
            set { InternalList[index] = value; }
        }

        public void Add(T item)
        {
            InternalList.Add(item);
        }

        public void Clear()
        {
            InternalList.Clear();
        }

        public bool Contains(T item)
        {
            return InternalList.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            InternalList.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return InternalList.Count; }
        }

        public bool IsReadOnly
        {
            get { return InternalList.IsReadOnly; }
        }

        public bool Remove(T item)
        {
            return InternalList.Remove(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return InternalList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return InternalList.GetEnumerator();
        }
    }
}
