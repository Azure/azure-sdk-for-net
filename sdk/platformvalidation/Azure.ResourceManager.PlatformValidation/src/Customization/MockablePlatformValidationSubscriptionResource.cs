// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.PlatformValidation.Mocking
{
    public partial class MockablePlatformValidationSubscriptionResource
    {
        /// <summary>
        /// Get a validation test catalog entry
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/providers/Microsoft.PlatformValidation/validationTests/{validationTestName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> ValidationTests_Get. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2026-08-01-preview. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="validationTestName"> The name of the ValidationTest. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="validationTestName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="validationTestName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<ValidationTestResource>> GetValidationTestAsync(string validationTestName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(validationTestName, nameof(validationTestName));

            return await GetValidationTests().GetAsync(validationTestName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get a validation test catalog entry
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/providers/Microsoft.PlatformValidation/validationTests/{validationTestName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> ValidationTests_Get. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2026-08-01-preview. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="validationTestName"> The name of the ValidationTest. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="validationTestName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="validationTestName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual Response<ValidationTestResource> GetValidationTest(string validationTestName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(validationTestName, nameof(validationTestName));

            return GetValidationTests().Get(validationTestName, cancellationToken);
        }

        /// <summary>
        /// Get a validation test category catalog entry
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/providers/Microsoft.PlatformValidation/validationTestCategories/{validationTestCategoryName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> ValidationTestCategories_Get. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2026-08-01-preview. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="validationTestCategoryName"> The name of the ValidationTestCategory. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="validationTestCategoryName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="validationTestCategoryName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<ValidationTestCategoryResource>> GetValidationTestCategoryAsync(string validationTestCategoryName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(validationTestCategoryName, nameof(validationTestCategoryName));

            return await GetValidationTestCategories().GetAsync(validationTestCategoryName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get a validation test category catalog entry
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/providers/Microsoft.PlatformValidation/validationTestCategories/{validationTestCategoryName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> ValidationTestCategories_Get. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2026-08-01-preview. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="validationTestCategoryName"> The name of the ValidationTestCategory. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="validationTestCategoryName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="validationTestCategoryName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        public virtual Response<ValidationTestCategoryResource> GetValidationTestCategory(string validationTestCategoryName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(validationTestCategoryName, nameof(validationTestCategoryName));

            return GetValidationTestCategories().Get(validationTestCategoryName, cancellationToken);
        }
    }
}
