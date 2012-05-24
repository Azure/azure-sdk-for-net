using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;

namespace Microsoft.WindowsAzure.MediaServices.Client
{
    public class OutputAssetCollection : IEnumerable<IAsset>
    {
        private readonly List<IAsset> _assets;
        private ITask _task;

        /// <summary>
        /// Initializes a new instance of the <see cref="OutputAssetCollection"/> class.
        /// </summary>
        public OutputAssetCollection()
        {
            _assets = new List<IAsset>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OutputAssetCollection"/> class.
        /// </summary>
        /// <param name="task">The task.</param>
        /// <param name="assets">The assets.</param>
        internal OutputAssetCollection(ITask task, IEnumerable<IAsset> assets)
        {
            _assets = new List<IAsset>(assets);
            _task = task;
        }

        /// <summary>
        /// Gets the count.
        /// </summary>
        public int Count
        {
            get { return _assets.Count; }
        }

        /// <summary>
        /// Gets the <see cref="Microsoft.WindowsAzure.MediaServices.Client.IAsset"/> at the specified index.
        /// </summary>
        public IAsset this[int index]
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
        public IEnumerator<IAsset> GetEnumerator()
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
        /// Adds the new output asset
        /// </summary>
        /// <param name="assetName">The asset name.</param>
        /// <param name="shouldPersistOutputOnCompletion">if set to <c>true</c> output asset will be pesrsisted in a system after job execution.</param>
        /// <param name="options">The options.</param>
        /// <returns></returns>
        public IAsset AddNew(string assetName, bool shouldPersistOutputOnCompletion, AssetCreationOptions options)
        {
            CheckIfTaskIsPersistedAndThrowNotSupported();
            var asset = new OutputAsset
                            {
                                Name = assetName,
                                IsTemporary = !shouldPersistOutputOnCompletion,
                                Options = options
                            };
            _assets.Add(asset);
            return asset;
        }
         /// <summary>
        /// Adds the new output asset
        /// </summary>
        /// <param name="assetName">The asset name.</param>
        /// <param name="shouldPersistOutputOnCompletion">if set to <c>true</c> output asset will be pesrsisted in a system after job execution.</param>
        
        /// <returns></returns>
        public IAsset AddNew(string assetName, bool shouldPersistOutputOnCompletion)
         {
             return AddNew(assetName, shouldPersistOutputOnCompletion, AssetCreationOptions.StorageEncrypted);
         }

        /// <summary>
        /// Gets a value indicating whether this collection is read only.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is read only; otherwise, <c>false</c>.
        /// </value>
        public bool IsReadOnly
        {
            get { return !string.IsNullOrEmpty(_task.Id); }
        }

        private void CheckIfTaskIsPersistedAndThrowNotSupported()
        {
            //TODO:find a better way to detect if task has been persisted
            if (IsReadOnly)
            {
                throw new NotSupportedException(String.Format(CultureInfo.InvariantCulture,StringTable.ErrorReadOnlyCollectionToSubmittedTask, "OutputMediaAssets"));
            }
        }

       
    }
}