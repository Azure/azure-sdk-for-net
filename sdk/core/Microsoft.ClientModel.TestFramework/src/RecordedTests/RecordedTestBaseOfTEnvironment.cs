// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Microsoft.ClientModel.TestFramework;

/// <summary>
/// tODO.
/// </summary>
/// <typeparam name="TEnvironment"></typeparam>
#pragma warning disable SA1649 // File name should match first type name
public abstract class RecordedTestBase<TEnvironment> : RecordedTestBase where TEnvironment : TestEnvironment, new()
#pragma warning restore SA1649 // File name should match first type name
{
    /// <summary>
    /// TODO.
    /// </summary>
    /// <param name="isAsync"></param>
    /// <param name="mode"></param>
    protected RecordedTestBase(bool isAsync, RecordedTestMode? mode = null)// : base(isAsync, mode)
    {
        throw new NotImplementedException();
        //TestEnvironment = new TEnvironment();
        //TestEnvironment.Mode = Mode;
    }

    ///// <summary>
    ///// TODO.
    ///// </summary>
    ///// <returns></returns>
    //public override async Task StartTestRecordingAsync()
    //{
    //    await Task.Yield();
    //    throw new NotImplementedException();
    //    //// Set the TestEnvironment Mode here so that any Mode changes in RecordedTestBase are picked up here also.
    //    //TestEnvironment.Mode = Mode;

    //    //await base.StartTestRecordingAsync().ConfigureAwait(false)  ;
    //    //TestEnvironment.SetRecording(Recording);
    //}

    /// <summary>
    /// TODO.
    /// </summary>
    public TEnvironment TestEnvironment { get; }

    ///// <summary>
    ///// TODO.
    ///// </summary>
    ///// <returns></returns>
    //[OneTimeSetUp]
    //public async ValueTask WaitForEnvironment()
    //{
    //    throw new NotImplementedException();
    //    //await TestEnvironment.WaitForEnvironmentAsync();
    //}
}
