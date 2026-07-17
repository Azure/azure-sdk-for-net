// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.SerialConsole.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.SerialConsole
{
    [CodeGenSuppress("DisableConsoleAsync", typeof(SubscriptionResource), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("DisableConsole", typeof(SubscriptionResource), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("EnableConsoleAsync", typeof(SubscriptionResource), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("EnableConsole", typeof(SubscriptionResource), typeof(string), typeof(CancellationToken))]
    public static partial class SerialConsoleExtensions
    {
        /// <summary> Disables the Serial Console service for all VMs and VM scale sets in the provided subscription. </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> is null. </exception>
        public static async Task<Response<DisableSerialConsoleResult>> DisableConsoleAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return await GetMockableSerialConsoleSubscriptionResource(subscriptionResource).DisableConsoleAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Disables the Serial Console service for all VMs and VM scale sets in the provided subscription. </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> is null. </exception>
        public static Response<DisableSerialConsoleResult> DisableConsole(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockableSerialConsoleSubscriptionResource(subscriptionResource).DisableConsole(cancellationToken);
        }

        /// <summary> Enables the Serial Console service for all VMs and VM scale sets in the provided subscription. </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> is null. </exception>
        public static async Task<Response<EnableSerialConsoleResult>> EnableConsoleAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return await GetMockableSerialConsoleSubscriptionResource(subscriptionResource).EnableConsoleAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Enables the Serial Console service for all VMs and VM scale sets in the provided subscription. </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="subscriptionResource"/> is null. </exception>
        public static Response<EnableSerialConsoleResult> EnableConsole(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));

            return GetMockableSerialConsoleSubscriptionResource(subscriptionResource).EnableConsole(cancellationToken);
        }
    }
}
