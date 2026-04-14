// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.CostManagement.Models;

namespace Azure.ResourceManager.CostManagement
{
    /// <summary> Backward-compat: expose Timeframe and TypePropertiesQueryType as nullable. </summary>
    public partial class CostManagementViewData
    {
        /// <summary> The time frame for pulling data for the report. If custom, then a specific time period must be provided. </summary>
        public ReportTimeframeType? Timeframe
        {
            get => Properties is null ? default(ReportTimeframeType?) : Properties.Timeframe;
            set
            {
                if (Properties is null)
                {
                    Properties = new ViewProperties();
                }
                Properties.Timeframe = value ?? default;
            }
        }

        /// <summary> The type of the report. Usage represents actual usage, forecast represents forecasted data and UsageAndForecast represents both usage and forecasted data. Actual usage and forecasted data can be differentiated based on dates. </summary>
        public ViewReportType? TypePropertiesQueryType
        {
            get => Properties is null ? default(ViewReportType?) : Properties.TypePropertiesQueryType;
            set
            {
                if (Properties is null)
                {
                    Properties = new ViewProperties();
                }
                Properties.TypePropertiesQueryType = value ?? default;
            }
        }
    }
}
