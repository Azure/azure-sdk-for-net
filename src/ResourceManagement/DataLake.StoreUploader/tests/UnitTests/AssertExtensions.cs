// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AssertExtensions.cs" company="Microsoft">
//   Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
// <summary>
//   Unit tests for the  class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Xunit;

namespace Microsoft.Azure.Management.DataLake.StoreUploader.Tests
{
    /// <summary>
    /// Helpful additions to the NUnit Assert class.
    /// </summary>
    internal static class AssertExtensions
    {
        /// <summary>
        /// Verifies that the given two arrays contain the same elements at the same indices.
        /// </summary>
        /// <typeparam name="T">The type of the parameter to test.</typeparam>
        /// <param name="expected">The expected value.</param>
        /// <param name="actual">The actual value from the test.</param>
        /// <param name="message">The message to issue.</param>
        /// <param name="args">Any message formatting arguments.</param>
        public static void AreEqual<T>(T[] expected, T[] actual, string message, params object[] args) 
        {
            message = string.Format(message, args);
            Assert.Equal(expected.Length, actual.Length);

            for (int i = 0; i < expected.Length; i++)
            {
                Assert.True(expected[i].Equals(actual[i]), string.Format(message + " Elements differ at index {0}", i));
            }
        }
    }
}
