// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Globalization;
using System.Text;
using Azure.Core;
using System.Diagnostics.CodeAnalysis;

namespace Azure.DigitalTwins.Core.QueryBuilder
{
    /// <summary>
    /// Azure DigitalTwins Query builder that facilitates writing queries against ADT instances. Redirects to generic version of this class using BasicDigitalTwin as type T.
    /// </summary>
    public class DigitalTwinsQueryBuilderV2 : DigitalTwinsQueryBuilderV2<BasicDigitalTwin>
    {
        /// <summary>
        /// Create a DigitalTwins query and set the queried collection to DigitalTwins by default.
        /// </summary>
        public DigitalTwinsQueryBuilderV2() : base(DigitalTwinsCollection.DigitalTwins) { }

        /// <summary>
        /// Create a DigitalTwins query and set the queried collection to a custom string.
        /// </summary>
        /// <param name="customColection">Collection to query from.</param>
        public DigitalTwinsQueryBuilderV2(string customColection) : base(customColection) { }

        /// <summary>
        /// Create a DigitalTwins query and set the queried collection to DigitalTwins or Relationships.
        /// </summary>
        /// <param name="collection">Collection to query from.</param>
        /// <param name="alias">Optional collection alias.</param>
        public DigitalTwinsQueryBuilderV2(DigitalTwinsCollection collection, string alias = null) : base(collection, alias) { }
    }

    /// <summary>
    /// Azure DigitalTwins Query builder that facilitates writing queries against ADT instances.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:File may only contain a single type", Justification = "Required for default behavior")]
    public class DigitalTwinsQueryBuilderV2<T>
    {
        private string _collection;
        private string _customSelect;
        private int? _top;
        private bool _count;

        private List<string> _propertyNames;
        private List<string> _clauses;

        private string _queryText;

        /// <summary>
        /// Create a DigitalTwins query and set the queried collection to DigitalTwins by default.
        /// </summary>
        public DigitalTwinsQueryBuilderV2() : this(DigitalTwinsCollection.DigitalTwins) { }

        /// <summary>
        /// Create a DigitalTwins query and set the queried collection to a custom string.
        /// </summary>
        /// <param name="customCollection">Collection to query from.</param>
        public DigitalTwinsQueryBuilderV2(string customCollection)
        {
            Argument.AssertNotNull(customCollection, nameof(customCollection));

            _collection = customCollection;
        }

        /// <summary>
        /// Create a DigitalTwins query and set the queried collection to DigitalTwins or Relationships.
        /// </summary>
        /// <param name="collection">Collection to query from.</param>
        /// <param name="alias">Optional collection alias.</param>
        public DigitalTwinsQueryBuilderV2(DigitalTwinsCollection collection, string alias = null)
        {
            _collection = collection switch
            {
                DigitalTwinsCollection.DigitalTwins => "DigitalTwins",
                DigitalTwinsCollection.Relationships => "Relationships",
                _ => throw new ArgumentException("Unknown collection", nameof(collection))
            };

            if (!string.IsNullOrEmpty(alias))
            {
                _collection += $" {alias}";
            }
        }

        /// <summary>
        /// Used to add a select clause (and its corresponding argument) to the query.
        /// </summary>
        /// <param name="propertyNames">The arguments that define what we select.</param>
        /// <returns>Query that contains a select clause.</returns>
        public DigitalTwinsQueryBuilderV2<T> Select(params string[] propertyNames)
        {
            _propertyNames ??= new List<string>();
            _propertyNames.AddRange(propertyNames);

            return this;
        }

        /// <summary>
        /// Used to add a select clause (and its corresponding argument) to the query.
        /// </summary>
        /// <param name="selectors">The arguments that define what we select.</param>
        /// <returns>Query that contains a select clause.</returns>
        public DigitalTwinsQueryBuilderV2<T> Select(params Expression<Func<T, object>>[] selectors)
        {
            foreach (var propertyName in selectors.Select(GetPropertyName))
            {
                Argument.AssertNotNullOrWhiteSpace(propertyName, nameof(propertyName));
            }

            _propertyNames ??= new List<string>();
            _propertyNames.AddRange(selectors.Select(GetPropertyName));

            return this;
        }

        /// <summary>
        /// Used when overriding the query builder with the literal query string.
        /// </summary>
        /// <param name="customClause">Query in string format.</param>
        /// <returns>Query that contains a select clause.</returns>
        public DigitalTwinsQueryBuilderV2<T> SelectCustom(string customClause)
        {
            Argument.AssertNotNullOrWhiteSpace(customClause, nameof(customClause));

            _customSelect = customClause;
            return this;
        }

        /// <summary>
        /// Used to select properties with the desired alias.
        /// </summary>
        /// <param name="propertyName">The proper name for the selectable property in the DigitalTwins Query Language.</param>
        /// <param name="alias">The alias to be assigned to the return contents in the query response.</param>
        /// <returns>Query that contains an aliased select clause.</returns>
        public DigitalTwinsQueryBuilderV2<T> SelectAs(string propertyName, string alias)
        {
            Argument.AssertNotNullOrWhiteSpace(propertyName, nameof(propertyName));
            Argument.AssertNotNullOrWhiteSpace(alias, nameof(alias));

            _propertyNames ??= new List<string>();

            // insert AS between propertyName and alias
            string aliasedPropertyName = $"{propertyName} {QueryConstants.As} {alias}";
            _propertyNames.Add(aliasedPropertyName);

            return this;
        }
        /// <summary>
        /// Used when applying the <see href="https://docs.microsoft.com/azure/digital-twins/reference-query-clause-select#select-top">TOP()</see> aggregate from the DigitalTwins query language. Same functionality as select
        /// but inserts TOP() into the query structure as well.
        /// </summary>
        /// <param name="count">The argument for TOP(), i.e. the number of results to return.</param>
        /// <returns>Query that contains a select clause.</returns>
        public DigitalTwinsQueryBuilderV2<T> Take(int count)
        {
            _top = count;
            return this;
        }

        /// <summary>
        /// Used when applying the <see href="https://docs.microsoft.com/azure/digital-twins/reference-query-clause-select#select-count">COUNT()</see> aggregate from the DigitalTwins query language.
        /// </summary>
        /// <returns>Query that contains a select clause.</returns>
        public DigitalTwinsQueryBuilderV2<T> Count()
        {
            _count = true;
            return this;
        }

        /// <summary>
        /// Used to add a from clause into a DigitalTwins query.
        /// </summary>
        /// <param name="collection">Collection to query from.</param>
        /// <param name="alias">Optional alias for collection.</param>
        /// <returns>Query that contains a from clause.</returns>
        public DigitalTwinsQueryBuilderV2<T> From(DigitalTwinsCollection collection, string alias = null)
        {
            if (string.IsNullOrEmpty(alias))
            {
                _collection = collection.ToString();
            }
            else
            {
                _collection = $"{collection} {alias}";
            }

            return this;
        }

        /// <summary>
        /// Used to add a custom-written from clause into a DigitalTwins query.
        /// </summary>
        /// <param name="collection">Collection to query from.</param>
        /// <returns>Query that contains a from clause.</returns>
        public DigitalTwinsQueryBuilderV2<T> FromCustom(string collection)
        {
            _collection = collection;
            return this;
        }

        private DigitalTwinsQueryBuilderV2<T> Where(string filter)
        {
            _clauses ??= new List<string>();
            _clauses.Add(filter);

            return this;
        }

        /// <summary>
        /// An alternative way to add a WHERE clause to the query by directly providing a string that contains the condition.
        /// </summary>
        /// <param name="filter">The verbatim condition in string format.</param>
        /// <returns>Query that contains a WHERE clause and conditional arguments.</returns>
        public DigitalTwinsQueryBuilderV2<T> WhereCustom(string filter)
        {
            if (!string.IsNullOrEmpty(filter))
            {
                _clauses ??= new List<string>();
                _clauses.Add(filter);
            }

            return this;
        }

        /// <summary>
        /// Adds a WHERE clause to a query along with conditions defined with formatted strings.
        /// </summary>
        /// <param name="filter">Conditional argument relevant to a DigitalTwins query (e.g. comparisons, DigitalTwins Functions, etc.)</param>
        /// <returns>Query that contains a WHERE clause and conditional arguments.</returns>
        public DigitalTwinsQueryBuilderV2<T> Where(FormattableString filter) => Where(filter, null);

        /// <summary>
        /// Adds a WHERE clause to a query along with conditions defined with LINQ expressions.
        /// </summary>
        /// <param name="filter">Conditional argument relevant to a DigitalTwins query (e.g. comparisons, DigitalTwins Functions, etc.)</param>
        /// <param name="formatProvider">Culture-specific formatting information for DigitalTwins queries.</param>
        /// <returns>Query that contains a WHERE clause and conditional arguments.</returns>
        public DigitalTwinsQueryBuilderV2<T> Where(FormattableString filter, IFormatProvider formatProvider)
        {
            formatProvider ??= CultureInfo.InvariantCulture;

            if (filter == null)
            {
                throw new ArgumentNullException(nameof(filter));
            }

            string[] args = new string[filter.ArgumentCount];

            for (int i = 0; i < args.Length; i++)
            {
                args[i] = DigitalTwinsFunctions.Convert(filter.GetArgument(i), formatProvider);

                if (args[i] == "null")
                {
                    throw new InvalidOperationException();
                }
            }

            string text = string.Format(formatProvider, filter.Format, args);
            return Where(text);
        }

        /// <summary>
        /// Adds a WHERE clause to a query along with conditions defined with LINQ expressions.
        /// </summary>
        /// <param name="filter">Conditional argument relevant to a DigitalTwins query (e.g. comparisons, DigitalTwins Functions, etc.)</param>
        /// <returns>Query that contains a WHERE clause and conditional arguments.</returns>
        public DigitalTwinsQueryBuilderV2<T> Where(Expression<Func<T, bool>> filter)
        {
            string query = string.Empty;
            Expression e = Evaluator.PartialEval(filter, CanEvaluate);
            e = ExpressionNormalizer.Normalize(e, new Dictionary<Expression, Expression>());

            LambdaExpression l = e as LambdaExpression;
            Ensure(l != null);
            Ensure(l.Parameters.Count == 1);

            query = QueryFilterVisitor.Translate(l.Body);

            return Where(query);

            bool CanEvaluate(Expression e)
            {
                if (e is MethodCallExpression call && call.Method.DeclaringType == typeof(DigitalTwinsFunctions))
                {
                    return false;
                }

                return Evaluator.CanBeEvaluatedLocally(e);
            }
        }

        private static void Ensure(bool condition, string message = null)
        {
            if (!condition)
            {
                throw new InvalidOperationException(message ?? "Invalid expression.");
            }
        }

        private static string GetPropertyName(Expression<Func<T, object>> selector)
        {
            LambdaExpression lambda = selector as LambdaExpression;
            Ensure(lambda != null);
            Ensure(lambda.Parameters.Count == 1);

            ParameterExpression param = lambda.Parameters[0];
            Ensure(param.Type == typeof(T));

            Expression body = lambda.Body;
            UnaryExpression conversion = body as UnaryExpression;

            if (conversion != null)
            {
                Ensure(conversion.NodeType == ExpressionType.Convert);
                body = conversion.Operand;
            }

            MemberExpression member = body as MemberExpression;
            Ensure(member != null);
            Ensure(member.Expression == param);
            Ensure(member.Member.MemberType == System.Reflection.MemberTypes.Property);

            return member.Member.Name;
        }

        /// <summary>
        /// Gets the string representation of the built query.
        /// </summary>
        /// <returns>String represenation of query.</returns>
        public string GetQueryText()
        {
            if (string.IsNullOrEmpty(_queryText))
            {
                Build();
            }

            return _queryText;
        }

        /// <summary>
        /// Gets the string representation of the built query.
        /// </summary>
        /// <returns>String represenation of query.</returns>
        public override string ToString() => GetQueryText();

        /// <summary>
        /// Updates the string representation of the query.
        /// </summary>
        /// <returns>Query with updated string representation.</returns>
        public DigitalTwinsQueryBuilderV2<T> Build()
        {
            QueryAssembler query = new QueryAssembler();
            SelectClauseAssembler selectClause = _count
                ? query.SelectCount()
                : _top != null && _propertyNames != null
                    ? query.SelectTop(_top.Value, _propertyNames.ToArray())
                    : _top != null
                        ? query.SelectTopAll(_top.Value)
                        : _customSelect != null
                            ? query.SelectCustom(_customSelect)
                            : _propertyNames != null
                                ? query.Select(_propertyNames.ToArray())
                                : query.SelectAll();

            WhereClauseAssembler whereClause = selectClause.FromCustom(_collection);

            if (_clauses?.Count > 0)
            {
                var custom = _clauses
                     .Skip(1)
                     .Aggregate(
                         whereClause
                             .Where()
                             .CustomClause(_clauses[0]), (expr, clause) => expr.And().CustomClause(clause));
            }

            _queryText = whereClause
                .Build()
                .GetQueryText();

            return this;
        }
    }
}
