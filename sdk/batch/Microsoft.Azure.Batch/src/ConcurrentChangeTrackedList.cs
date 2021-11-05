// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Microsoft.Azure.Batch
{
    internal class ConcurrentChangeTrackedList<T> : IList<T>, IPropertyMetadata, IReadOnlyList<T>
    {
        protected readonly IList<T> _list;
        protected readonly object _listLock = new object();

        protected bool _hasBeenModified;

        public ConcurrentChangeTrackedList()
        {
            this._list = new List<T>();
            this.IsReadOnly = false;
        }

        public ConcurrentChangeTrackedList(IEnumerable<T> other, bool isReadOnly = false)
        {
            this._list = new List<T>();

            foreach (T item in other)
            {
                this._list.Add(item);
            }
            this.IsReadOnly = isReadOnly;
        }

        #region IPropertyMetadata

        public virtual bool HasBeenModified
        {
            get
            {
                lock (this._listLock)
                {
                    return this._hasBeenModified;
                }
            }
        }

        public virtual bool IsReadOnly { get; set; }

        #endregion

        #region IEnumerable<T>

        public IEnumerator<T> GetEnumerator()
        {
            lock (this._listLock)
            {
                //Clone the list for enumeration -- this is best for "small" lists.  If dealing with larger lists, we should revisit
                IReadOnlyList<T> copy = new List<T>(this._list);
                return copy.GetEnumerator();
            }
        }

        #endregion

        #region IEnumerable

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        #endregion

        #region IList

        public void Add(T item)
        {
            this.ThrowOnReadOnly();

            lock (this._listLock)
            {
                this._list.Add(item);
                this._hasBeenModified = true;
            }
        }

        public void Clear()
        {
            this.ThrowOnReadOnly();

            lock (this._listLock)
            {
                this._list.Clear();
                this._hasBeenModified = true;
            }
        }

        public bool Contains(T item)
        {
            lock (this._listLock)
            {
                bool contains = this._list.Contains(item);
                return contains;
            }
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            lock (this._listLock)
            {
                this._list.CopyTo(array, arrayIndex);
            }
        }

        public bool Remove(T item)
        {
            this.ThrowOnReadOnly();

            lock (this._listLock)
            {
                bool result = this._list.Remove(item);
                this._hasBeenModified = true;
                return result;
            }
        }

        public int Count
        {
            get
            {
                lock (this._listLock)
                {
                    int count = this._list.Count;
                    return count;
                }
            }
        }

        public int IndexOf(T item)
        {
            lock (this._listLock)
            {
                int index = this._list.IndexOf(item);
                return index;
            }
        }

        public void Insert(int index, T item)
        {
            this.ThrowOnReadOnly();

            lock (this._listLock)
            {
                this._list.Insert(index, item);
                this._hasBeenModified = true;
            }
        }

        public void RemoveAt(int index)
        {
            this.ThrowOnReadOnly();

            lock (this._listLock)
            {
                this._list.RemoveAt(index);
                this._hasBeenModified = true;
            }
        }

        public T this[int index]
        {
            get
            {
                lock (this._listLock)
                {
                    T result = this._list[index];
                    return result;
                }
            }

            set
            {
                this.ThrowOnReadOnly();

                lock (this._listLock)
                {
                    this._list[index] = value;
                    this._hasBeenModified = true;
                }
            }
        }

        #endregion

        public void AddRange(IEnumerable<T> items)
        {
            this.ThrowOnReadOnly();

            lock (this._listLock)
            {
                foreach (T item in items)
                {
                    this._list.Add(item);
                }
            }
        }

        public IReadOnlyList<T> AsReadOnly()
        {
            //As per http://msdn.microsoft.com/en-us/library/ms132474%28v=vs.110%29.aspx this is a wrapper around the collection, which will disallow modification but
            //will reflect any changes made to the underlying list
            return new ReadOnlyCollection<T>(this._list);
        }

        public static ConcurrentChangeTrackedList<T> TransformEnumerableToConcurrentList(IEnumerable<T> enumerable)
        {
            if (enumerable == null)
            {
                return null;
            }

            ConcurrentChangeTrackedList<T> list = new ConcurrentChangeTrackedList<T>(enumerable);
            return list;
        }

        #region Private helpers

        private void ThrowOnReadOnly()
        {
            if (this.IsReadOnly)
            {
                throw new InvalidOperationException(BatchErrorMessages.GeneralObjectInInvalidState);
            }
        }

        #endregion

    }

    internal sealed class ConcurrentChangeTrackedModifiableList<T> : ConcurrentChangeTrackedList<T> where T : IPropertyMetadata
    {
        public ConcurrentChangeTrackedModifiableList()
        {
        }

        public ConcurrentChangeTrackedModifiableList(IEnumerable<T> other, bool isReadOnly = false) : base(other, isReadOnly)
        {
        }

        #region IModifiable

        public override bool HasBeenModified
        {
            get
            {
                lock (this._listLock)
                {
                    //Check to see if this object has been modified
                    if (this._hasBeenModified)
                    {
                        return true;
                    }

                    //Check to see if the children objects have been modified
                    foreach (T item in this._list)
                    {
                        if (item != null && item.HasBeenModified)
                        {
                            return true;
                        }
                    }

                    return false;
                }
            }
        }

        public override bool IsReadOnly
        {
            get
            {
                return base.IsReadOnly;
            }
            set
            {
                base.IsReadOnly = value;
                foreach (T readOnlyItem in this)
                {
                    if (readOnlyItem != null)
                    {
                        readOnlyItem.IsReadOnly = value;
                    }
                }
            }
        }

        #endregion

        public static ConcurrentChangeTrackedModifiableList<T> TransformEnumerableToConcurrentModifiableList(IEnumerable<T> enumerable)
        {
            if (enumerable == null)
            {
                return null;
            }

            ConcurrentChangeTrackedModifiableList<T> list = new ConcurrentChangeTrackedModifiableList<T>(enumerable);
            return list;
        }
    }
}
