// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Extensions.Logging;

namespace SampleHost
{
    /// <summary>
    /// Sample services used to demonstrate DI capabilities
    /// </summary>
    public interface ISampleServiceA
    {
        void DoIt();
    }

    public class SampleServiceA : ISampleServiceA
    {
        private readonly ILogger _logger;

        public SampleServiceA(ILogger<SampleServiceA> logger)
        {
            _logger = logger;
        }

        public void DoIt()
        {
            _logger.LogInformation("SampleServiceA.DoIt invoked!");
        }
    }

    public interface ISampleServiceB
    {
        void DoIt();
    }

    public class SampleServiceB : ISampleServiceB
    {
        private readonly ILogger _logger;

        public SampleServiceB(ILogger<SampleServiceB> logger)
        {
            _logger = logger;
        }

        public void DoIt()
        {
            _logger.LogInformation("SampleServiceB.DoIt invoked!");
        }
    }
}
