// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models = Microsoft.Azure.Batch.Protocol.Models;
using System.Threading;

namespace Microsoft.Azure.Batch
{
    /// <summary>
    /// Exposes methods and properties to access files from Nodes or Tasks.
    /// </summary>
    public abstract class NodeFile : IInheritedBehaviors
    {
        internal FileItemBox fileItemBox;

#region  // constructors

        private NodeFile()
        {
        }

        internal NodeFile(Models.NodeFile boundToThis, IEnumerable<BatchClientBehavior> inheritTheseBehaviors)
        {
            this.fileItemBox = new FileItemBox(boundToThis);

            // inherit from parent
            InheritUtil.InheritClientBehaviorsAndSetPublicProperty(this, inheritTheseBehaviors);
        }

#endregion

#region IInheritedBehaviors

        /// <summary>
        /// Gets or sets a list of behaviors that modify or customize requests to the Batch service
        /// made via this <see cref="NodeFile"/>.
        /// </summary>
        /// <remarks>
        /// <para>These behaviors are inherited by child objects.</para>
        /// <para>Modifications are applied in the order of the collection. The last write wins.</para>
        /// </remarks>
        public IList<BatchClientBehavior> CustomBehaviors { get; set; }

#endregion IInheritedBehaviors

#region // NodeFile

        /// <summary>
        /// Gets the value that indicates whether the file is a directory.
        /// </summary>
        public bool? IsDirectory
        {
            get
            {
                return this.fileItemBox.IsDirectory;
            }
        }

        /// <summary>
        /// Gets the name of the file.
        /// </summary>
        [Obsolete("Obsolete as of 02/2017. Use Path instead.")]
        public string Name
        {
            get
            {
                return this.fileItemBox.Name;
            }
        }

        /// <summary>
        /// Gets the path of the file.
        /// </summary>
        public string Path
        {
            get
            {
                return this.fileItemBox.Name;
            }
        }

        /// <summary>
        /// Gets the FileProperties of the file.
        /// </summary>
        public FileProperties Properties
        {
            get
            {
                return this.fileItemBox.Properties;
            }
        }


        /// <summary>
        /// Gets the URL of the file.
        /// </summary>
        public string Url
        {
            get
            {
                return this.fileItemBox.Url;
            }
        }

        /// <summary>
        /// Begins asynchronous call to return the contents of the file as a string.
        /// </summary>
        /// <param name="encoding">The encoding used to interpret the file data. If no value or null is specified, UTF8 is used.</param>
        /// <param name="byteRange">The file byte range to retrieve. If null, the entire file is retrieved.</param>
        /// <param name="additionalBehaviors">A collection of BatchClientBehavior instances that are applied after the CustomBehaviors on the current object.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> object that represents the asynchronous operation.</returns>
        public Task<string> ReadAsStringAsync(
            Encoding encoding = null,
            GetFileRequestByteRange byteRange = null,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            return UtilitiesInternal.ReadNodeFileAsStringAsync(
                CopyToStreamAsync,
                encoding,
                byteRange,
                additionalBehaviors,
                cancellationToken);
        }

        /// <summary>
        /// Blocking call to return the contents of the file as a string.
        /// </summary>
        /// <param name="encoding">The encoding used to interpret the file data. If no value or null is specified, UTF8 is used.</param>
        /// <param name="byteRange">The file byte range to retrieve. If null, the entire file is retrieved.</param>
        /// <param name="additionalBehaviors">A collection of BatchClientBehavior instances that are applied after the CustomBehaviors on the current object.</param>
        /// <returns>A string containing the contents of the file.</returns>
        public string ReadAsString(Encoding encoding = null, GetFileRequestByteRange byteRange = null, IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            Task<string> asyncTask = ReadAsStringAsync(encoding, byteRange, additionalBehaviors);
            string readAsString = asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);

            // return result
            return readAsString;
        }

        /// <summary>
        /// Begins an asynchronous call to copy the contents of the file into the given Stream.
        /// </summary>
        /// <param name="stream">The stream into which the contents of the file are copied.</param>
        /// <param name="byteRange">The file byte range to retrieve. If null, the entire file is retrieved.</param>
        /// <param name="additionalBehaviors">A collection of BatchClientBehavior instances that are applied after the CustomBehaviors on the current object.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> object that represents the asynchronous operation.</returns>
        public abstract Task CopyToStreamAsync(Stream stream,
            GetFileRequestByteRange byteRange = null,
            IEnumerable<BatchClientBehavior> additionalBehaviors = null,
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Blocking call to copy the contents of the file into the given Stream.
        /// </summary>
        /// <param name="stream">The stream into which the contents of the file are copied.</param>
        /// <param name="byteRange">The file byte range to retrieve. If null, the entire file is retrieved.</param>
        /// <param name="additionalBehaviors">A collection of BatchClientBehavior instances that are applied after the CustomBehaviors on the current object.</param>
        public virtual void CopyToStream(Stream stream, GetFileRequestByteRange byteRange = null, IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            Task asyncTask = CopyToStreamAsync(stream, byteRange, additionalBehaviors);
            asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
        }

        /// <summary>
        /// Begins an asynchronous call to delete the file.
        /// </summary>
        /// <param name="recursive">
        /// If the file-path parameter represents a directory instead of a file, you can set the optional 
        /// recursive parameter to true to delete the directory and all of the files and subdirectories in it. If recursive is false 
        /// then the directory must be empty or deletion will fail.
        /// </param>
        /// <param name="additionalBehaviors">A collection of BatchClientBehavior instances that are applied after the CustomBehaviors on the current object.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="System.Threading.Tasks.Task"/> object that represents the asynchronous operation.</returns>
        public abstract Task DeleteAsync(bool? recursive = null, IEnumerable<BatchClientBehavior> additionalBehaviors = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Blocking call to delete the file.
        /// </summary>
        /// <param name="recursive">
        /// If the file-path parameter represents a directory instead of a file, you can set the optional 
        /// recursive parameter to true to delete the directory and all of the files and subdirectories in it. If recursive is false 
        /// then the directory must be empty or deletion will fail.
        /// </param>
        /// <param name="additionalBehaviors">A collection of BatchClientBehavior instances that are applied after the CustomBehaviors on the current object.</param>
        public virtual void Delete(bool? recursive = null, IEnumerable<BatchClientBehavior> additionalBehaviors = null)
        {
            Task asyncTask = DeleteAsync(recursive, additionalBehaviors);
            asyncTask.WaitAndUnaggregateException(this.CustomBehaviors, additionalBehaviors);
        }

        #endregion

        #region IRefreshable

        /// <summary>
        /// Refreshes the current <see cref="NodeFile"/>.
        /// </summary>
        /// <param name="detailLevel">The detail level for the refresh.  If a detail level which omits the <see cref="Name"/> property is specified, refresh will fail.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> for controlling the lifetime of the asynchronous operation.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous refresh operation.</returns>
        public abstract Task RefreshAsync(DetailLevel detailLevel = null, IEnumerable<BatchClientBehavior> additionalBehaviors = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Refreshes the current <see cref="NodeFile"/>.
        /// </summary>
        /// <param name="detailLevel">The detail level for the refresh.  If a detail level which omits the <see cref="Name"/> property is specified, refresh will fail.</param>
        /// <param name="additionalBehaviors">A collection of <see cref="BatchClientBehavior"/> instances that are applied to the Batch service request after the <see cref="CustomBehaviors"/>.</param>
        public abstract void Refresh(DetailLevel detailLevel = null, IEnumerable<BatchClientBehavior> additionalBehaviors = null);

#endregion

        /// <summary>
        /// Encapsulates the properties of a FileItem so as to allow atomic replacement for Refresh().
        /// </summary>
        internal class FileItemBox
        {
            protected Models.NodeFile _boundFileItem; // the protocol object to which this instance is bound
            protected FileProperties _wrappedFileProperties;

            public FileItemBox(Models.NodeFile file)
            {
                this._boundFileItem = file;
                if (file.Properties != null)
                {
                    this._wrappedFileProperties = new FileProperties(file.Properties);
                }
            }

            public bool? IsDirectory
            {
                get
                {
                    return _boundFileItem.IsDirectory;
                }
            }

            public string Name
            {
                get
                {
                    return _boundFileItem.Name;
                }
            }

            public FileProperties Properties
            {
                get
                {
                    return _wrappedFileProperties;
                }
            }

            public string Url
            {
                get
                {
                    return _boundFileItem.Url;
                }
            }
        }

    }
}
