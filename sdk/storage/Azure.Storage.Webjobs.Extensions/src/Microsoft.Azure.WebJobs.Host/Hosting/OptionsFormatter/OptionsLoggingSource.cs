// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading.Tasks.Dataflow;

namespace Microsoft.Azure.WebJobs.Hosting
{
    internal class OptionsLoggingSource : IOptionsLoggingSource
    {
        private readonly BufferBlock<string> _buffer = new BufferBlock<string>();

        public ISourceBlock<string> LogStream => _buffer;

        public void LogOptions(string optionLog)
        {
            _buffer.Post(optionLog);
        }
    }
}
