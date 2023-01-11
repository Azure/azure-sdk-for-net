// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using Azure.Core.TestFramework;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace Azure.AI.Language.Conversations.Tests
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// Determines whether the asserted type contains a property named "ParamName" with the value of <paramref name="paramName"/>.
        /// </summary>
        /// <param name="constraint"></param>
        /// <param name="paramName"></param>
        /// <returns></returns>
        public static EqualConstraint WithParamName(this ExactTypeConstraint constraint, string paramName)
        {
            return constraint.With.Property(nameof(ArgumentException.ParamName)).EqualTo(paramName);
        }

        /// <summary>
        /// Work around <see href="https://github.com/Azure/azure-sdk-for-net/issues/29140">Azure/azure-sdk-for-net#29140</see>
        /// by disabling recording of status requests and returning immediately during playback.
        /// </summary>
        /// <typeparam name="T">The type returned by an operation.</typeparam>
        /// <param name="operation">The operation to extend.</param>
        /// <param name="fixture">The test fixture.</param>
        public static void WaitForCompletionWithoutRecording<T>(this Operation<T> operation, RecordedTestBase fixture, CancellationToken cancellationToken = default)
        {
            // Record the first status response for better coverage.
            operation.UpdateStatus(cancellationToken);

            if (fixture.Mode != RecordedTestMode.Playback)
            {
                using (fixture.Recording.DisableRecording())
                {
                    operation.WaitForCompletion();
                }
            }

            // Call UpdateStatus again to get the terminal status recorded.
            operation.UpdateStatus(cancellationToken);
        }
    }
}
