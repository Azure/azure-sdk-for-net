// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.WebJobs.Host.Config
{
    /// <summary>
    /// Used to register a converter that applies a New value to an existing value. 
    /// This is semantically like a TNew to TExisting converter, but used when TExisting already exists. 
    /// This is common for Streams. The converter doesn't create the stream, instead it just 
    /// applies the new value onto an existing stream instantation. 
    /// </summary>
    /// <typeparam name="TNew">A new value </typeparam>
    /// <typeparam name="TExisting">An existing object that the new Value is getting applied to. </typeparam>
    public class ApplyConversion<TNew, TExisting>
    {
        public TNew Value;
        public TExisting Existing;
    }
}
