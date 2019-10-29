// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;

namespace Subscriptions.Tests.src.Helpers
{
    /// <summary>
    /// The global test context configuration.
    /// </summary>
    public static class TestContext
    {
        /// <summary>
        /// The active directory tenant identifier.
        /// </summary>
        public static string DirectoryTenantId => Environment.GetEnvironmentVariable("AADTenant");

        /// <summary>
        /// The default provider subscription identifier.
        /// </summary>
        public static string DefaultProviderSubscriptionId => Environment.GetEnvironmentVariable("SubscriptionId"); // 45ec4d39-8dea-4d26-a373-c176ec53717a

        /// <summary>
        /// The location of the live Azure Stack stamp.
        /// </summary>
        public const string LocationName = "local";

        /// <summary>
        /// The azure stack infrastructure resource group name.
        /// </summary>
        public const string InfrastructureResourceGroupName = "system." + TestContext.LocationName;

        /// <summary>
        /// The tenant subscription identifier.
        /// </summary>
        /// <remarks>
        /// Created from offer <see cref="OfferToDelegateName"/>.
        /// </remarks>
        public const string TenantSubscriptionId = "ae8c4250-2121-41ba-a126-551b08befdcf";

        /// <summary>
        /// The delegated provider subscription identifier.
        /// </summary>
        public const string DelegatedProviderSubscriptionId = "798568b7-c6f1-4bf7-bb8f-2c8bebc7c777";

        /// <summary>
        /// The second delegated provider subscription identifier.
        /// </summary>
        public const string SecondDelegatedProviderSubscriptionId = "4e81ef7e-c0db-431d-abfa-29f982a8e549";

        /// <summary>
        /// The resource group that test fixtures are provisioned into.
        /// </summary>
        public const string ResourceGroupName = "rg";

        /// <summary>
        /// The name of the plan that contains quota for Microsoft.Storage.
        /// </summary>
        public const string StoragePlanName = "p1";

        /// <summary>
        /// The name of the plan that contains quota for Microsoft.Subscriptions.
        /// </summary>
        public const string SubscriptionsPlanName = "p2";

        /// <summary>
        /// The name of the offer containing quota for Microsoft.Storage (delegatable) and is delegated
        /// to multiple delegated providers.
        /// </summary>
        public const string MoveOfferName = "o1";

        /// <summary>
        /// The name of the offer containing quota for Microsoft.Subscriptions (non-delegatable).
        /// </summary>
        public const string SubscriptionsOfferName = "o2";

        /// <summary>
        /// The name of the offer that is intended for delegation. Contains quota for Microsoft.Storage.
        /// </summary>
        public const string OfferToDelegateName = "o3";

        /// <summary>
        /// The name of the delegated provider offer under the first delegated provider subscription.
        /// </summary>
        public const string DelegatedProviderOfferName = "ro1";

        /// <summary>
        /// The name of the delegated provider offer under the second delegated provider subscription.
        /// </summary>
        public const string SecondDelegatedProviderOfferName = "ro2";

        /// <summary>
        /// The tenant user principal name.
        /// </summary>
        public const string TenantUpn = "tenantadmin1@msazurestack.onmicrosoft.com";
    }
}
