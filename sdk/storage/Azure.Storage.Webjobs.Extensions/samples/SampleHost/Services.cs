// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Extensions.Logging;

namespace SampleHost
{
    /// <summary>
    /// Sample services used to demonstrate DI capabilities
    /// </summary>
#pragma warning disable SA1649 // File name should match first type name
    public interface ISampleServiceA
#pragma warning restore SA1649 // File name should match first type name
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

#pragma warning disable SA1402 // File may only contain a single type
    public class SampleServiceB : ISampleServiceB
#pragma warning restore SA1402 // File may only contain a single type
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
