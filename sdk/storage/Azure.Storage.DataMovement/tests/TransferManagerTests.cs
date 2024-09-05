// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;

namespace Azure.Storage.DataMovement.Tests;

internal class TransferManagerTests
{
    [Test]
    public void CtorConfiguresProcessors()
    {
        Mock<IProcessor<TransferJobInternal>> jobsProcessor = new();
        Mock<IProcessor<JobPartInternal>> partsProcessor = new();
        Mock<IProcessor<Func<Task>>> chunksProcessor = new();

        TransferManager _ = new(
            jobsProcessor.Object,
            partsProcessor.Object,
            chunksProcessor.Object,
            default, default, default);

        jobsProcessor.VerifySet(p => p.Process = It.IsNotNull<ChannelProcessing.ProcessAsync<TransferJobInternal>>(), Times.Once());
        partsProcessor.VerifySet(p => p.Process = It.IsNotNull<ChannelProcessing.ProcessAsync<JobPartInternal>>(), Times.Once());
        chunksProcessor.VerifySet(p => p.Process = It.IsNotNull<ChannelProcessing.ProcessAsync<Func<Task>>>(), Times.Once());

        jobsProcessor.VerifyNoOtherCalls();
        partsProcessor.VerifyNoOtherCalls();
        chunksProcessor.VerifyNoOtherCalls();
    }
}
