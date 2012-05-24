using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;

namespace Microsoft.WindowsAzure.MediaServices.Client
{
    /// <summary>
    /// Enumerable for task input assets
    /// </summary>
    public class InputAssetCollection<T> : ICollection<T>
    {
        private readonly List<T> _assets;
        private ITask _task;

        /// <summary>
        /// Initializes a new instance of the <see cref="InputAssetCollection"/> class.
        /// </summary>
        public InputAssetCollection()
        {
            _assets = new List<T>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InputAssetCollection"/> class.
        /// </summary>
        /// <param name="task">The task.</param>
        /// <param name="assets">The assets.</param>
        internal InputAssetCollection(ITask task, IEnumerable<T> assets)
        {
            _assets = new List<T>(assets);
            _task = task;
        }

        public bool Remove(T item)
        {
            CheckIfTaskIsPersistedAndThrowNotSupported();
            return _assets.Remove(item);
        }

        /// <summary>
        /// Gets the count of element within a enumerable.
        /// </summary>
        public int Count
        {
            get { return _assets.Count; }
        }

        /// <summary>
        /// Gets a value indicating whether the <see cref="T:System.Collections.Generic.ICollection`1"/> is read-only.
        /// </summary>
        /// <returns>true if the <see cref="T:System.Collections.Generic.ICollection`1"/> is read-only; otherwise, false.
        ///   </returns>
        public bool IsReadOnly
        {
            get { return !string.IsNullOrEmpty(_task.Id); }
        }

        /// <summary>
        /// Gets the <see cref="Microsoft.WindowsAzure.MediaServices.Client.IAsset"/> at the specified index.
        /// </summary>
        public T this[int index]
        {
            get { return _assets[index]; }
        }

        #region IEnumerable<IAsset> Members

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<T> GetEnumerator()
        {
            return _assets.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        /// <summary>
        /// Adds the specified item to a collection.
        /// </summary>
        /// <param name="item">The asset.</param>
        public void Add(T item)
        {
            CheckIfTaskIsPersistedAndThrowNotSupported();
            _assets.Add(item);
        }

        public void Clear()
        {
            CheckIfTaskIsPersistedAndThrowNotSupported();
            _assets.Clear();
        }

        public bool Contains(T item)
        {
            return _assets.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _assets.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Adds the range of assets to a collection
        /// </summary>
        /// <param name="assets">The assets to add.</param>
        public void AddRange(IEnumerable<T> assets)
        {
            CheckIfTaskIsPersistedAndThrowNotSupported();
            _assets.AddRange(assets);
        }

        /// <summary>
        /// Checks if task is persisted and throw not supported exception.
        /// </summary>
        private void CheckIfTaskIsPersistedAndThrowNotSupported()
        {
            //TODO:find a better way to detect if task has been persisted
            if (IsReadOnly)
            {
                throw new NotSupportedException(String.Format(CultureInfo.InvariantCulture, StringTable.ErrorReadOnlyCollectionToSubmittedTask, "InputMediaAssets"));
            }
        }

    }
}