// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MockableFrontEnd.cs" company="Microsoft">
//   Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// <summary>
//   Completely overridable FrontEnd.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Microsoft.Azure.Management.DataLake.StoreUploader.Tests
{
    using System;
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
        }

        public void CreateStream(string streamPath, bool overwrite, byte[] data, int byteCount)
        {
            this.CreateStreamImplementation(streamPath, overwrite, data, byteCount);
        }

        public Action<string, bool, byte[], int> CreateStreamImplementation { get; set; }


        public void DeleteStream(string streamPath, bool recurse = false)
        {
            this.DeleteStreamImplementation(streamPath, recurse);
        }

        public Action<string, bool> DeleteStreamImplementation { get; set; }

        public void AppendToStream(string streamPath, byte[] data, long offset, int byteCount)
        {
            this.AppendToStreamImplementation(streamPath, data, offset, byteCount);
        }

        public Action<string, byte[], long, int> AppendToStreamImplementation { get; set; }

        public bool StreamExists(string streamPath)
        {
            return this.StreamExistsImplementation(streamPath);
        }

        public Func<string, bool> StreamExistsImplementation { get; set; }

        public long GetStreamLength(string streamPath)
        {
            return this.GetStreamLengthImplementation(streamPath);
        }

        public Func<string, long> GetStreamLengthImplementation { get; set; }

        public void Concatenate(string targetStreamPath, string[] inputStreamPaths)
        {
            this.ConcatenateImplementation(targetStreamPath, inputStreamPaths);
        }

        public Action<string, string[]> ConcatenateImplementation { get; set; }
    }
}
