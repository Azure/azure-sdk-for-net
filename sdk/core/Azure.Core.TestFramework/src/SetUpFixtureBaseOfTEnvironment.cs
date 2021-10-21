// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Core.TestFramework
{
    [SetUpFixture]
#pragma warning disable SA1649 // File name should match first type name
    public abstract class SetUpFixtureBase<TEnvironment> where TEnvironment : TestEnvironment, new()
#pragma warning restore SA1649 // File name should match first type name
    {
        protected SetUpFixtureBase(RecordedTestMode? mode = null)
        {
            Environment = new TEnvironment();
            Environment.Mode = mode ?? TestEnvironment.GlobalTestMode;
        }

        public TEnvironment Environment { get; }

        [OneTimeSetUp]
        public virtual Task SetUp()
        {
            return Task.CompletedTask;
        }

        [OneTimeTearDown]
        public virtual Task TearDown()
        {
            return Task.CompletedTask;
        }
    }
}
