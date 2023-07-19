namespace Microsoft.Azure.ApplicationInsights.Query.Models
{
    public class ApiPreferences
    {
        /// <summary>
        /// See https://dev.applicationinsights.io/documentation/Using-the-API/RequestOptions
        /// </summary>
        public bool IncludeRender { get; set; } = false;

        /// <summary>
        ///  See https://dev.applicationinsights.io/documentation/Using-the-API/RequestOptions
        /// </summary>
        public bool IncludeStatistics { get; set; } = false;

        /// <summary>
        /// Puts an upper bound on the amount of time the server will spend processing the query. See: https://dev.applicationinsights.io/documentation/Using-the-API/Timeouts
        /// </summary>
        public int Wait { get; set; } = int.MinValue;

        public override string ToString()
        {
            var pref = "response-v1=true";
            if (IncludeRender)
            {
                pref += ",include-render=true";
            }
            if (IncludeStatistics)
            {
                pref += ",include-statistics=true";
            }
            if (Wait != int.MinValue)
            {
                pref += $",wait={Wait}";
            }

            return pref;
        }
    }
}
