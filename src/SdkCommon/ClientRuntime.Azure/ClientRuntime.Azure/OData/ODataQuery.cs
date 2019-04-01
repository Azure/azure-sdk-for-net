// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;

namespace Microsoft.Rest.Azure.OData
{
    /// <summary>
    /// Handles OData query generation.
    /// </summary>
    public class ODataQuery<T>
    {
        /// <summary>
        /// Initializes a new instance of empty ODataQuery.
        /// </summary>
        public ODataQuery()
        {
            SkipNullFilterParameters = true;
        }

        /// <summary>
        /// Initializes a new instance of ODataQuery with filter.
        /// </summary>
        /// <param name="odataExpression">OData expression.</param>
        public ODataQuery(string odataExpression) : this()
        {
            if (odataExpression != null)
            {
                var odataElements = odataExpression.Split(new[] {"&"}, StringSplitOptions.RemoveEmptyEntries);
                
                if (odataElements.Length == 1)
                {
                    // If there is only query expression assume it's filter
                    if (odataExpression.StartsWith("$filter=", StringComparison.OrdinalIgnoreCase))
                    {
                        Filter = odataExpression.Substring("$filter=".Length);
                    }
                    else
                    {
                        Filter = odataExpression;
                    }
                }
                else
                {
                    // Go through each query expression and parse it
                    foreach (var element in odataElements)
                    {
                        if (element.StartsWith("$filter=", StringComparison.OrdinalIgnoreCase))
                        {
                            Filter = element.Substring("$filter=".Length);
                        }
                        else if (element.StartsWith("$orderby=", StringComparison.OrdinalIgnoreCase))
                        {
                            OrderBy = element.Substring("$orderby=".Length);
                        }
                        else if (element.StartsWith("$expand=", StringComparison.OrdinalIgnoreCase))
                        {
                            Expand = element.Substring("$expand=".Length);
                        }
                        else if (element.StartsWith("$top=", StringComparison.OrdinalIgnoreCase))
                        {
                            int top = 0;
                            if (int.TryParse(element.Substring("$top=".Length), out top))
                            {
                                Top = top;
                            }
                        }
                        else if (element.StartsWith("$skip=", StringComparison.OrdinalIgnoreCase))
                        {
                            int skip = 0;
                            if (int.TryParse(element.Substring("$skip=".Length), out skip))
                            {
                                Skip = skip;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of ODataQuery with filter.
        /// </summary>
        /// <param name="filter">Filter expression.</param>
        public ODataQuery(Expression<Func<T, bool>> filter) : this()
        {
            SetFilter(filter);
        }

        /// <summary>
        /// Gets or sets query $filter expression.
        /// </summary>
        public string Filter { get; set; }

        /// <summary>
        /// Gets or sets query $orderby expression.
        /// </summary>
        public string OrderBy { get; set; }

        /// <summary>
        /// Gets or sets query $expand expression.
        /// </summary>
        public string Expand { get; set; }
        
        /// <summary>
        /// Gets or sets query $top value.
        /// </summary>
        public int? Top { get; set; }

        /// <summary>
        /// Gets or sets query $skip value.
        /// </summary>
        public int? Skip { get; set; }

        /// <summary>
        /// Indicates whether null values in the Filter should be skipped. Default value is True.
        /// </summary>
        public bool SkipNullFilterParameters { get; set; }

        /// <summary>
        /// Sets Filter from an expression.
        /// </summary>
        /// <param name="filter">Filter expression.</param>
        public void SetFilter(Expression<Func<T, bool>> filter)
        {
            Filter = FilterString.Generate(filter, SkipNullFilterParameters);
        }

        /// <summary>
        /// Implicit operator that creates an ODataQuery from a string filter.
        /// </summary>
        /// <param name="filter">Filter expression</param>
        /// <returns>ODataQuery</returns>
        public static implicit operator ODataQuery<T>(string filter)
        {
            return new ODataQuery<T>(filter);
        }

        public override string ToString()
        {
            var queryStringList = new List<string>();
            if (!string.IsNullOrEmpty(Filter))
            {
                queryStringList.Add(string.Format(CultureInfo.InvariantCulture,
                    "$filter={0}", Filter));
            }
            if (!string.IsNullOrEmpty(OrderBy))
            {
                queryStringList.Add(string.Format(CultureInfo.InvariantCulture,
                    "$orderby={0}", OrderBy));
            }
            if (!string.IsNullOrEmpty(Expand))
            {
                queryStringList.Add(string.Format(CultureInfo.InvariantCulture,
                    "$expand={0}", Expand));
            }
            if (Top != null)
            {
                queryStringList.Add(string.Format(CultureInfo.InvariantCulture,
                    "$top={0}", Top));
            }
            if (Skip != null)
            {
                queryStringList.Add(string.Format(CultureInfo.InvariantCulture,
                    "$skip={0}", Skip));
            }

            return string.Join("&", queryStringList);
        }
    }
}
