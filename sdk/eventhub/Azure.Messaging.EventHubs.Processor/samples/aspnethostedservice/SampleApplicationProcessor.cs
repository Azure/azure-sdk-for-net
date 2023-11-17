// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
namespace Azure.Messaging.EventHubs.Samples.Processor.HostedService
{
    public class SampleApplicationProcessor : ISampleApplicationProcessor
    {
        private readonly ILogger<SampleApplicationProcessor> _logger;
        public SampleApplicationProcessor(ILogger<SampleApplicationProcessor> logger)
        {
            _logger = logger;
        }
        public async Task Process(string body)
        {
            _logger.LogInformation("Event body has been processed: {body}", body);
            await Task.CompletedTask;
        }
    }

    public interface ISampleApplicationProcessor
    {
        Task Process(string body);
    }
}
