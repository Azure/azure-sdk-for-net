// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Management.Sql.Models
{
    using System;
    using System.Linq;
    using Newtonsoft.Json;

    public partial class DatabaseUpdate : TrackedResource
    {
        /// <summary>
        /// Gets the edition of the database. If createMode is OnlineSecondary, this value is
        /// ignored.To see possible values, query the capabilities API
        /// (/subscriptions/{subscriptionId}/providers/Microsoft.Sql/locations/{locationID}/capabilities)
        /// referred to by operationId: "Capabilities_ListByLocation." or use the Azure CLI
        /// command az sql db list-editions -l westus --query[].name. Possible values include:
        /// 'Web', 'Business', 'Basic', 'Standard', 'Premium', 'PremiumRS', 'Free', 'Stretch',
        /// 'DataWarehouse', 'System', 'System2'
        /// </summary>
        public string Edition
        {
            get
            {
                return Sku?.Tier;
            }
        }

        /// <summary>
        /// Gets the current service level objective of the database.
        /// </summary>
        public string ServiceLevelObjective
        {
            get
            {
                return CurrentServiceObjectiveName;
            }
        }

        /// <summary>
        /// Gets the name of the elastic pool the database is in. If elasticPoolName and
        /// requestedServiceObjectiveName are both updated, the value of
        /// requestedServiceObjectiveName is ignored. Not supported for DataWarehouse
        /// edition.
        /// </summary>
        public string ElasticPoolName
        {
            get
            {
                return ResourceIdHelpers.GetLastSegment(ElasticPoolId);
            }
        }
    }
}
