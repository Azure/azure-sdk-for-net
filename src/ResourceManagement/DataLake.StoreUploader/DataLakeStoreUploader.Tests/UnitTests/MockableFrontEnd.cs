// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MockableFrontEnd.cs" company="Microsoft">
//   Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// <summary>
//   Completely overridable FrontEnd.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.IO;

namespace Microsoft.Azure.Management.DataLake.StoreUploader.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using Microsoft.Azure.Management.DataLake.StoreUploader;

    /// <summary>
    /// Represents a completely overridable front end.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.NamingRules", "*")]
    [SuppressMessage("StyleCop.CSharp.LayoutRules", "*")]
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "*")]
    [SuppressMessage("StyleCop.CSharp.OrderingRules", "*")]
    [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "*")]
    [SuppressMessage("StyleCop.CSharp.SpacingRules", "*")]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "*")]
    internal class MockableFrontEnd : IFrontEndAdapter
    {

        /// <summary>
        /// Default constructor.
        /// </summary>
        public MockableFrontEnd()
        {
        }

        public InMemoryFrontEnd BaseAdapter { get; set; }

        /// <summary>
        /// Constructor with base front end.
        /// </summary>
        /// <param name="baseAdapter">The front end.</param>
        public MockableFrontEnd(IFrontEndAdapter baseAdapter)
        {
            this.AppendToStreamImplementation = baseAdapter.AppendToStream;
            this.ConcatenateImplementation = baseAdapter.Concatenate;
            this.CreateStreamImplementation = baseAdapter.CreateStream;
            this.DeleteStreamImplementation = baseAdapter.DeleteStream;
            this.GetStreamLengthImplementation = baseAdapter.GetStreamLength;
            this.StreamExistsImplementation = baseAdapter.StreamExists;
            this.ReadStreamImplementation = baseAdapter.ReadStream;
            this.IsDirectoryImplementation = baseAdapter.IsDirectory;
            this.ListDirectoryImplementation = baseAdapter.ListDirectory;

            BaseAdapter = baseAdapter as InMemoryFrontEnd;
        }

        public void CreateStream(string streamPath, bool overwrite, byte[] data, int byteCount)
        {
            this.CreateStreamImplementation(streamPath, overwrite, data, byteCount);
        }

        public Action<string, bool, byte[], int> CreateStreamImplementation { get; set; }


        public void DeleteStream(string streamPath, bool recurse = false, bool isDownload = false)
        {
            this.DeleteStreamImplementation(streamPath, recurse, isDownload);
        }

        public Action<string, bool, bool> DeleteStreamImplementation { get; set; }

        public void AppendToStream(string streamPath, byte[] data, long offset, int byteCount)
        {
            this.AppendToStreamImplementation(streamPath, data, offset, byteCount);
        }

        public Action<string, byte[], long, int> AppendToStreamImplementation { get; set; }

        public bool StreamExists(string streamPath, bool isDownload = false)
        {
            return this.StreamExistsImplementation(streamPath, isDownload);
        }

        public Func<string, bool, bool> StreamExistsImplementation { get; set; }

        public long GetStreamLength(string streamPath, bool isDownload = false)
        {
            return this.GetStreamLengthImplementation(streamPath, isDownload);
        }

        public Func<string, bool, long> GetStreamLengthImplementation { get; set; }

        public void Concatenate(string targetStreamPath, string[] inputStreamPaths, bool isDownload = false)
        {
            this.ConcatenateImplementation(targetStreamPath, inputStreamPaths, isDownload);
        }

        public Action<string, string[], bool> ConcatenateImplementation { get; set; }

        public Stream ReadStream(string streamPath, long offset, long length, bool isDownload = false)
        {
            return this.ReadStreamImplementation(streamPath, offset, length, isDownload);
        }

        public bool IsDirectory(string streamPath)
        {
            return this.IsDirectoryImplementation(streamPath);
        }

        public Func<string, bool> IsDirectoryImplementation { get; set; }

        public IDictionary<string, long> ListDirectory(string directoryPath, bool recursive)
        {
            // download folder not currently tested here.
            return this.ListDirectoryImplementation(directoryPath, recursive);
        }

        public Func<string, bool, IDictionary<string, long>> ListDirectoryImplementation { get; set; }

        public Func<string, long, long, bool, Stream> ReadStreamImplementation { get; set; }
    }
}
