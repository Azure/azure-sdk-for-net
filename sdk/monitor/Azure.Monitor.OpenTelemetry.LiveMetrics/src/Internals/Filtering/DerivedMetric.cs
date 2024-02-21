// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Monitor.OpenTelemetry.LiveMetrics.Internals.Filtering
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq.Expressions;
    using System.Reflection;
    using Azure.Monitor.OpenTelemetry.LiveMetrics.Models;

    /// <summary>
    /// Represents a single configured metric that needs to be calculated and reported on top of the telemetry items
    /// that pass through the pipeline. Includes a set of filters that define which telemetry items to consider, a projection
    /// which defines which field to use as a value, and an aggregation which dictates the algorithm of arriving at
    /// a single reportable value within a second.
    /// </summary>
    internal class DerivedMetric<TTelemetry>
    {
        private const string ProjectionCount = "Count()";

        private static readonly MethodInfo DoubleParseMethodInfo = typeof(double).GetMethod(
           "Parse",
           new[] { typeof(string), typeof(IFormatProvider) });

        private static readonly MethodInfo ObjectToStringMethodInfo = typeof(object).GetMethod(
            "ToString",
            BindingFlags.Public | BindingFlags.Instance);

        private static readonly MethodInfo DoubleToStringMethodInfo = typeof(double).GetMethod(
            "ToString",
            new[] { typeof(IFormatProvider) });

        private readonly DerivedMetricInfo info;

        /// <summary>
        /// OR-connected collection of AND-connected filter groups.
        /// </summary>
        private readonly List<FilterConjunctionGroup<TTelemetry>> filterGroups = new List<FilterConjunctionGroup<TTelemetry>>();

        private Func<TTelemetry, double>? projectionLambda;
        public DerivedMetric(DerivedMetricInfo info, out CollectionConfigurationError[] errors)
        {
            if (info == null)
            {
                throw new ArgumentNullException(nameof(info));
            }

            this.info = info;

            CreateFilters(out errors);

            CreateProjection();
        }

        public string Id => this.info.Id;

        public DerivedMetricInfoAggregation? AggregationType => this.info.Aggregation;  // TODO: this was enum. Need to double check new type is parsed and used correctly.

        public bool CheckFilters(TTelemetry document, out CollectionConfigurationError[] errors)
        {
            if (this.filterGroups.Count < 1)
            {
                errors = Array.Empty<CollectionConfigurationError>();
                return true;
            }

            var errorList = new List<CollectionConfigurationError>(this.filterGroups.Count);

            // iterate over OR-connected groups
            foreach (FilterConjunctionGroup<TTelemetry> conjunctionFilterGroup in this.filterGroups)
            {
                CollectionConfigurationError[] groupErrors;
                bool groupPassed = conjunctionFilterGroup.CheckFilters(document, out groupErrors);

                errorList.AddRange(groupErrors);

                if (groupPassed)
                {
                    // one group has passed, we don't care about others
                    errors = errorList.ToArray();
                    return true;
                }
            }

            errors = errorList.ToArray();
            return false;
        }

        public double Project(TTelemetry document)
        {
            if (this.projectionLambda == null)
            {
                throw new ArgumentException("Projection lambda is not initialized.");
            }

            try
            {
                return this.projectionLambda(document);
            }
            catch (FormatException e)
            {
                // the projected value could not be parsed by double.Parse()
                throw new ArgumentOutOfRangeException(
                    string.Format(CultureInfo.InvariantCulture, "Projected field {0} was not a number", this.info.Projection),
                    e);
            }
        }

        public override string ToString()
        {
            return this.info.ToString();
        }

        private void CreateFilters(out CollectionConfigurationError[] errors)
        {
            var errorList = new List<CollectionConfigurationError>();
            if (this.info.FilterGroups != null)
            {
                foreach (FilterConjunctionGroupInfo filterConjunctionGroupInfo in this.info.FilterGroups)
                {
                    CollectionConfigurationError[]? groupErrors = null;
                    try
                    {
                        var conjunctionFilterGroup = new FilterConjunctionGroup<TTelemetry>(filterConjunctionGroupInfo, out groupErrors);
                        this.filterGroups.Add(conjunctionFilterGroup);
                    }
                    catch (System.Exception e)
                    {
                        errorList.Add(
                            CollectionConfigurationError.CreateError(
                                CollectionConfigurationErrorType.MetricFailureToCreateFilterUnexpected,
                                string.Format(CultureInfo.InvariantCulture, "Failed to create a filter group {0}.", filterConjunctionGroupInfo),
                                e,
                                Tuple.Create("MetricId", this.info.Id)));
                    }

                    if (groupErrors != null)
                    {
                        foreach (var error in groupErrors)
                        {
                            UpdateMetricIdOfError(error, this.info.Id);
                        }

                        errorList.AddRange(groupErrors);
                    }
                }
            }

            errors = errorList.ToArray();
        }

        private void UpdateMetricIdOfError(CollectionConfigurationError error, string id)
        {
            for (int i = 0; i < error.Data.Count; i++)
            {
                if (error.Data[i].Key == "MetricId")
                {
                    error.Data[i].Value = id;
                    return;
                }
            }
        }

        private void CreateProjection()
        {
            ParameterExpression documentExpression = Expression.Variable(typeof(TTelemetry));

            Expression projectionExpression;

            try
            {
                Expression fieldExpression;

                if (string.Equals(this.info.Projection, ProjectionCount, StringComparison.OrdinalIgnoreCase))
                {
                    fieldExpression = Expression.Constant(1, typeof(int));
                }
                else
                {
                    Filter<TTelemetry>.FieldNameType fieldNameType;
                    Type? fieldType = Filter<TTelemetry>.GetFieldType(this.info.Projection, out fieldNameType);
                    if (fieldNameType == Filter<TTelemetry>.FieldNameType.AnyField)
                    {
                        throw new ArgumentOutOfRangeException(
                            string.Format(CultureInfo.InvariantCulture, "Unsupported field type for projection: {0}", this.info.Projection));
                    }

                    fieldExpression = Filter<TTelemetry>.ProduceFieldExpression(documentExpression, this.info.Projection, fieldNameType);

                    // special case - for TimeSpan values ToString() will not result in a value convertable to double, so we must take care of that ourselves
                    if (fieldType == typeof(TimeSpan))
                    {
                        fieldExpression = Expression.Property(fieldExpression, "TotalMilliseconds");
                    }
                }

                ConstantExpression invariantCulture = Expression.Constant(CultureInfo.InvariantCulture);
                if (fieldExpression.Type == typeof(double))
                {
                    // Expression fieldAsObjectExpression = Expression.ConvertChecked(fieldExpression, typeof(object));
                    MethodCallExpression fieldExpressionToString = Expression.Call(fieldExpression, DoubleToStringMethodInfo, invariantCulture);
                    projectionExpression = Expression.Call(DoubleParseMethodInfo, fieldExpressionToString, invariantCulture);
                }
                else
                {
                    Expression fieldAsObjectExpression = Expression.ConvertChecked(fieldExpression, typeof(object));
                    MethodCallExpression fieldExpressionToString = Expression.Call(fieldExpression, ObjectToStringMethodInfo);
                    projectionExpression = Expression.Call(DoubleParseMethodInfo, fieldExpressionToString, invariantCulture);
                }
            }
            catch (System.Exception e)
            {
                throw new ArgumentOutOfRangeException(string.Format(CultureInfo.InvariantCulture, "Could not construct the projection."), e);
            }

            try
            {
                Expression<Func<TTelemetry, double>> lambdaExpression = Expression.Lambda<Func<TTelemetry, double>>(projectionExpression, documentExpression);

                this.projectionLambda = lambdaExpression.Compile();
            }
            catch (System.Exception e)
            {
                throw new ArgumentOutOfRangeException(string.Format(CultureInfo.InvariantCulture, "Could not compile the projection."), e);
            }
        }
    }
}
