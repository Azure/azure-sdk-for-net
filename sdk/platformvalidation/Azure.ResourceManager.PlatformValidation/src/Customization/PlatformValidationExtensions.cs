// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.PlatformValidation.Mocking;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.PlatformValidation
{
    public static partial class PlatformValidationExtensions
    {
        /// <summary>
        /// Get a validation test catalog entry
        /// <item>
        /// <term> Mocking. </term>
        /// <description> To mock this method, please mock <see cref="MockablePlatformValidationSubscriptionResource.GetValidationTestAsync(string, CancellationToken)"/> instead. </description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> the method will execute against. </param>
        /// <param name="validationTestName"> The name of the ValidationTest. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<ValidationTestResource>> GetValidationTestAsync(this SubscriptionResource subscriptionResource, string validationTestName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return await GetMockablePlatformValidationSubscriptionResource(subscriptionResource).GetValidationTestAsync(validationTestName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get a validation test catalog entry
        /// <item>
        /// <term> Mocking. </term>
        /// <description> To mock this method, please mock <see cref="MockablePlatformValidationSubscriptionResource.GetValidationTest(string, CancellationToken)"/> instead. </description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> the method will execute against. </param>
        /// <param name="validationTestName"> The name of the ValidationTest. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<ValidationTestResource> GetValidationTest(this SubscriptionResource subscriptionResource, string validationTestName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockablePlatformValidationSubscriptionResource(subscriptionResource).GetValidationTest(validationTestName, cancellationToken);
        }

        /// <summary>
        /// Get a validation test category catalog entry
        /// <item>
        /// <term> Mocking. </term>
        /// <description> To mock this method, please mock <see cref="MockablePlatformValidationSubscriptionResource.GetValidationTestCategoryAsync(string, CancellationToken)"/> instead. </description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> the method will execute against. </param>
        /// <param name="validationTestCategoryName"> The name of the ValidationTestCategory. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<ValidationTestCategoryResource>> GetValidationTestCategoryAsync(this SubscriptionResource subscriptionResource, string validationTestCategoryName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return await GetMockablePlatformValidationSubscriptionResource(subscriptionResource).GetValidationTestCategoryAsync(validationTestCategoryName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get a validation test category catalog entry
        /// <item>
        /// <term> Mocking. </term>
        /// <description> To mock this method, please mock <see cref="MockablePlatformValidationSubscriptionResource.GetValidationTestCategory(string, CancellationToken)"/> instead. </description>
        /// </item>
        /// </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> the method will execute against. </param>
        /// <param name="validationTestCategoryName"> The name of the ValidationTestCategory. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<ValidationTestCategoryResource> GetValidationTestCategory(this SubscriptionResource subscriptionResource, string validationTestCategoryName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockablePlatformValidationSubscriptionResource(subscriptionResource).GetValidationTestCategory(validationTestCategoryName, cancellationToken);
        }
    }
}
