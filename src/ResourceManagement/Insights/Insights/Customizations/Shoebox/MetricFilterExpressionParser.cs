//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;

namespace Microsoft.Azure.Insights
{
    /// <summary>
    /// The expression parser creates an Expression that represents an expression in disjunctive-normal-form
    /// Each Expression contains a set of Subexpressions (the conjunctions) with the total expression being the disjunction of them
    /// </summary>
    [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
    public static class MetricFilterExpressionParser
    {
        private static Dictionary<Type, IEnumerable<PropertyInfo>> ExpressionElementPropertyCache = new Dictionary<Type, IEnumerable<PropertyInfo>>();
        private static Dictionary<Type, IEnumerable<Tuple<PropertyInfo, ExpressionElementCollectionPropertyAttribute>>> ExpressionElementCollectionPropertyCache =
            new Dictionary<Type, IEnumerable<Tuple<PropertyInfo, ExpressionElementCollectionPropertyAttribute>>>();

        [AttributeUsage(AttributeTargets.Property)]
        private sealed class ExpressionElementPropertyAttribute : Attribute
        {
        }

        // This attribute marks relevant properties of ExpressionElements that are actually collections of elements
        [AttributeUsage(AttributeTargets.Property)]
        private sealed class ExpressionElementCollectionPropertyAttribute : Attribute
        {
            // The Union and Intersect methods must be static
            private const BindingFlags Flags = BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;

            private MethodInfo unionMethod;
            private MethodInfo intersectMethod;

            internal Type UnionMethodDeclaringType { get; set; }

            internal Type IntersectMethodDeclaringType { get; set; }

            internal string UnionMethodName { get; set; }

            internal string IntersectMethodName { get; set; }

            // The constructor assumes both methods are declared in the same class, but different classes can be specified
            internal ExpressionElementCollectionPropertyAttribute(Type unionMethodDeclaringType, string unionMethodName, string intersectMethodName)
            {
                this.UnionMethodDeclaringType = unionMethodDeclaringType;
                this.IntersectMethodDeclaringType = this.UnionMethodDeclaringType;
                this.UnionMethodName = unionMethodName;
                this.IntersectMethodName = intersectMethodName;
            }

            // Since the Union method is static, it does not require an instance object
            internal object InvokeUnionMethod(object[] parameters)
            {
                if (this.unionMethod == null)
                {
                    this.InitializeUnionMethod();
                }

                return this.unionMethod.Invoke(null, parameters);
            }

            // Since the Intersect method is static, it does not require an instance object
            internal object InvokeIntersectMethod(object[] parameters)
            {
                if (this.intersectMethod == null)
                {
                    this.InitializeIntersectMethod();
                }

                return this.intersectMethod.Invoke(null, parameters);
            }

            private void InitializeUnionMethod()
            {
                this.unionMethod = this.UnionMethodDeclaringType.GetMethod(this.UnionMethodName, Flags);

                if (this.unionMethod == null)
                {
                    throw new InvalidOperationException(string.Format("Could not find Union Method {0} in type {1}", this.UnionMethodName, this.UnionMethodDeclaringType));
                }
            }

            private void InitializeIntersectMethod()
            {
                this.intersectMethod = this.IntersectMethodDeclaringType.GetMethod(this.IntersectMethodName, Flags);

                if (this.intersectMethod == null)
                {
                    throw new InvalidOperationException(
                        string.Format("Could not find Intersect Method {0} in type {1}", this.IntersectMethodName, this.IntersectMethodDeclaringType));
                }
            }
        }

        private class ExpressionElement<T> where T : ExpressionElement<T>
        {
            private const BindingFlags Flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

            private IEnumerable<PropertyInfo> ExpressionElementProperties
            {
                get
                {
                    if (!ExpressionElementPropertyCache.ContainsKey(typeof(T)))
                    {
                        this.InitializeProperties();
                    }

                    return ExpressionElementPropertyCache[typeof(T)];
                }
            }

            private IEnumerable<Tuple<PropertyInfo, ExpressionElementCollectionPropertyAttribute>> ExpressionElementCollectionProperties
            {
                get
                {
                    if (!ExpressionElementCollectionPropertyCache.ContainsKey(typeof(T)))
                    {
                        this.InitializeProperties();
                    }

                    return ExpressionElementCollectionPropertyCache[typeof(T)];
                }
            }

            internal virtual T And(T other)
            {
                // start with a deep copy both elements
                T result = this.Clone();
                other = other.Clone();

                // for AND, the non-collection properties cannot conflict
                foreach (PropertyInfo property in this.ExpressionElementProperties)
                {
                    // Get values
                    var thisVal = property.GetValue(result, null);
                    var otherVal = property.GetValue(other, null);

                    // if other has a constraint
                    if (otherVal != null)
                    {
                        // AND this has a constraint
                        if (thisVal != null)
                        {
                            // then they must be the same
                            if (!object.Equals(thisVal, otherVal))
                            {
                                return default(T);
                            }
                        }
                        else
                        {
                            // other has one, but this doesn't simply add the constraint
                            property.SetValue(result, otherVal, null);
                        }
                    }
                }

                // for the collection properties, the result will have the intersection
                foreach (Tuple<PropertyInfo, ExpressionElementCollectionPropertyAttribute> tuple in this.ExpressionElementCollectionProperties)
                {
                    // Get property and attribute
                    PropertyInfo property = tuple.Item1;
                    ExpressionElementCollectionPropertyAttribute attribute = tuple.Item2;

                    // Get values
                    var thisVal = property.GetValue(result, null);
                    var otherVal = property.GetValue(other, null);

                    // if other has a constraint
                    if (otherVal != null)
                    {
                        // Take other's constraint in the absence of one on this, otherwise take the intersection
                        if (thisVal == null)
                        {
                            property.SetValue(result, otherVal, null);
                        }
                        else
                        {
                            // Find Intersect function and invoke to get the intersection
                            object intersect = attribute.InvokeIntersectMethod(new[] { thisVal, otherVal });

                            property.SetValue(result, intersect, null);
                        }
                    }
                }

                return result;
            }

            internal virtual T Or(T other)
            {
                if (!this.CanOr(other))
                {
                    return default(T);
                }

                // start with a deep copy of this
                T result = this.Clone();

                // Or will only affect the collection properties since CanOr requires the non-collection properties to have equivalent values
                foreach (Tuple<PropertyInfo, ExpressionElementCollectionPropertyAttribute> tuple in this.ExpressionElementCollectionProperties)
                {
                    // Get property and attribute
                    PropertyInfo property = tuple.Item1;
                    ExpressionElementCollectionPropertyAttribute attribute = tuple.Item2;

                    // Get the value of the collection
                    object thisVal = property.GetValue(result, null);

                    // CanOr ensures that the collections are either both null or neither null so only one needs to be tested
                    if (thisVal != null)
                    {
                        object otherVal = property.GetValue(other, null);

                        // Find Union function and invoke to get the union
                        object union = attribute.InvokeUnionMethod(new[] { thisVal, otherVal });

                        // set the union value on the copy (result)
                        property.SetValue(result, union, null);
                    }
                }

                return result;
            }

            internal virtual bool CanOr(T other)
            {
                foreach (PropertyInfo elementProperty in this.ExpressionElementProperties)
                {
                    // Get values
                    object thisVal = elementProperty.GetValue(this, null);
                    object otherVal = elementProperty.GetValue(other, null);

                    // Values must be equal (or both null)
                    if (!((thisVal == null && otherVal == null) || object.Equals(thisVal, otherVal)))
                    {
                        return false;
                    }
                }

                foreach (PropertyInfo collectionProperty in this.ExpressionElementCollectionProperties.Select(t => t.Item1))
                {
                    // Get values
                    object thisVal = collectionProperty.GetValue(this, null);
                    object otherVal = collectionProperty.GetValue(other, null);

                    // Values must be both null or neither null
                    if ((thisVal == null) != (otherVal == null))
                    {
                        return false;
                    }
                }

                return true;
            }

            // All subclasses must implement Clone for deep copy
            internal virtual T Clone()
            {
                throw new NotImplementedException();
            }

            private void InitializeProperties()
            {
                PropertyInfo[] properties = typeof(T).GetProperties(Flags);
                ExpressionElementPropertyCache[typeof(T)] = properties.Where(p => p.GetCustomAttributes(typeof(ExpressionElementPropertyAttribute), true).Any());
                ExpressionElementCollectionPropertyCache[typeof(T)] = properties
                    .Select(p => new Tuple<PropertyInfo, ExpressionElementCollectionPropertyAttribute>(
                        p,
                        p.GetCustomAttributes(typeof(ExpressionElementCollectionPropertyAttribute), true).FirstOrDefault() as ExpressionElementCollectionPropertyAttribute))
                    .Where(t => t.Item2 != null);
            }
        }

        private class ExpressionElementSet<TCollection, TElement>
            where TCollection : ExpressionElementSet<TCollection, TElement>, new()
            where TElement : ExpressionElement<TElement>
        {
            internal IList<TElement> ExpressionElements { get; set; }

            // Empty Constructor, initialize list
            internal ExpressionElementSet()
            {
                this.ExpressionElements = new List<TElement>();
            }

            // The Or function represents a sort of logical union where the two sets are combined and then "ORable" elemnets are "ORed" together
            internal TCollection Or(TCollection other)
            {
                // First create a deep copy of this
                TCollection result = this.Clone();

                // Add function will first try to OR-in (reduce) the new elements otherwise just add them to the list
                foreach (TElement element in other.ExpressionElements)
                {
                    result.Add(element);
                }

                return result;
            }

            // The And function is a sort of cross-join where all elements are "AND"ed together and all valid combinations are added to the result
            internal TCollection And(TCollection other)
            {
                // Start with a new empty collection
                TCollection result = new TCollection();

                // AND each element and collect the non-null results
                foreach (TElement left in this.ExpressionElements)
                {
                    foreach (TElement right in other.ExpressionElements)
                    {
                        TElement and = left.And(right);

                        if (and != null)
                        {
                            result.Add(and);
                        }
                    }
                }

                return result;
            }

            // Add function will first try to "OR" the new element with an existing element in the set.
            // If this is not possible, it will simply add it to the list
            internal void Add(TElement element)
            {
                // Find an existing element to OR with
                TElement candidate = this.ExpressionElements.FirstOrDefault((e) => element.CanOr(e));

                // If can or, replace the existing one with the OR of the two
                if (candidate != null)
                {
                    this.ExpressionElements.Remove(candidate);
                    this.ExpressionElements.Add(element.Or(candidate));
                }
                else
                {
                    // Can't OR, add the new one to the list
                    this.ExpressionElements.Add(element);
                }
            }

            internal TCollection Clone()
            {
                TCollection result = new TCollection();

                foreach (TElement element in this.ExpressionElements)
                {
                    result.ExpressionElements.Add(element.Clone());
                }

                return result;
            }
        }

        private class MetricFilterExpression : ExpressionElementSet<MetricFilterExpression, SubExpression>
        {
            public MetricFilterExpression()
            {
                this.ExpressionElements = new List<SubExpression>();
            }

            // used for creating the most basic filters the expected usage will only have one non-null parameter
            // The most basic form also cannot have a complex dimension constraint
            // so the constructor only accepts a singe string (or null) for metric name, dimension name, or dimension value as well
            internal MetricFilterExpression(string timeGrain, string startTime, string endTime, string metricName, string dimensionName, string dimensionValue)
            {
                this.ExpressionElements = new List<SubExpression>()
                {
                    new SubExpression()
                    {
                        TimeGrain = timeGrain,
                        StartTime = startTime,
                        EndTime = endTime,
                        MetricDimensions = (metricName == null && dimensionName == null && dimensionValue == null) ? null : new MetricDimensionExpressionSet(metricName, dimensionName, dimensionValue)
                    }
                };
            }

            internal MetricFilter ToMetricFilter(bool validate = true)
            {
                int numSubexpressions = this.ExpressionElements.Count;

                // empty subexression list means the filter is impossible to satisfy
                if (numSubexpressions < 1)
                {
                    throw new InvalidOperationException("Filter is impossible to satisfy");
                }

                // multiple subexpressions means multiple ways to satisfy the expression (not allowed)
                if (numSubexpressions > 1)
                {
                    throw new InvalidOperationException(string.Format(
                        "Filter is underconstrained (modified DNF must not have any ORs); modified DNF of expression: {0}",
                        this.ToString()));
                }

                // filter must have exactly one subexpression to be valid
                SubExpression expression = this.ExpressionElements[0];

                // Timegrain is required
                if (validate && expression.TimeGrain == null)
                {
                    throw new InvalidOperationException("TimeGrain constraint is required");
                }

                // Starttime is required
                if (validate && expression.StartTime == null)
                {
                    throw new InvalidOperationException("StartTime constraint is required");
                }

                // Endtime is required
                if (validate && expression.EndTime == null)
                {
                    throw new InvalidOperationException("EndTime constraint is required");
                }

                // Names is optional (null means no constraint)
                if (validate && expression.MetricDimensions != null)
                {
                    // Empty means name constraint cannot be satisfied
                    if (!expression.MetricDimensions.ExpressionElements.Any())
                    {
                        throw new InvalidOperationException("Constraint on Name is impossible to satisfy");
                    }

                    foreach (MetricDimensionExpression metricDimension in expression.MetricDimensions.ExpressionElements)
                    {
                        // Metric Name is required
                        if (metricDimension.Name == null)
                        {
                            throw new InvalidOperationException("Metric Name constraint (name.value) is required for specified dimensions");
                        }

                        // Dimensions are optional (null means no constraint)
                        if (metricDimension.Dimensions != null)
                        {
                            // Empty means dimension constraint cannot be satisfied
                            if (!metricDimension.Dimensions.ExpressionElements.Any())
                            {
                                throw new InvalidOperationException("Constraint on Dimensions is impossible to satisfy");
                            }

                            foreach (DimensionExpression dimension in metricDimension.Dimensions.ExpressionElements)
                            {
                                // Dimension Name is required (only when the dimension exists)
                                if (dimension.Name == null)
                                {
                                    throw new InvalidOperationException("Dimension Name constraint (dimensionName.value) is required for specified dimensions");
                                }

                                // Dimension Values are optional (null means no constraint)
                                // Empty means dimension value constraint cannot be satisfied
                                if (!(dimension.Values == null || dimension.Values.Any()))
                                {
                                    throw new InvalidOperationException("Constraint on dimension values is impossible to satisfy");
                                }
                            }
                        }
                    }
                }

                return new MetricFilter()
                {
                    TimeGrain = expression.TimeGrain == null ? default(TimeSpan) : XmlConvert.ToTimeSpan(expression.TimeGrain),
                    StartTime = expression.StartTime == null ? default(DateTime) : DateTime.Parse(expression.StartTime, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal),
                    EndTime = expression.EndTime == null ? default(DateTime) : DateTime.Parse(expression.EndTime, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal),
                    DimensionFilters = expression.MetricDimensions == null ? null : expression.MetricDimensions.ExpressionElements.Select(md => new MetricDimension()
                    {
                        Name = md.Name,
                        Dimensions = md.Dimensions == null ? null : md.Dimensions.ExpressionElements.Select(d => new MetricFilterDimension()
                        {
                            Name = d.Name,
                            Values = d.Values
                        })
                    })
                };
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();

                foreach (SubExpression s in this.ExpressionElements)
                {
                    if (sb.Length > 0)
                    {
                        sb.Append(" OR ");
                    }

                    sb.AppendFormat("({0})", s);
                }

                return sb.ToString();
            }
        }

        // SubFilter represents a single conjunctive (no ORs) filter segment
        private class SubExpression : ExpressionElement<SubExpression>
        {
            [ExpressionElementProperty]
            internal string TimeGrain { get; set; }

            [ExpressionElementProperty]
            internal string StartTime { get; set; }

            [ExpressionElementProperty]
            internal string EndTime { get; set; }

            [ExpressionElementCollectionProperty(typeof(MetricDimensionExpressionSet), "Union", "Intersect")]
            internal MetricDimensionExpressionSet MetricDimensions { get; set; }

            internal SubExpression()
            {
                this.TimeGrain = null;
                this.StartTime = null;
                this.EndTime = null;
                this.MetricDimensions = null;
            }

            internal override SubExpression Clone()
            {
                return new SubExpression()
                {
                    TimeGrain = this.TimeGrain,
                    StartTime = this.StartTime,
                    EndTime = this.EndTime,
                    MetricDimensions = this.MetricDimensions == null ? null : this.MetricDimensions.Clone()
                };
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();

                if (this.TimeGrain != null)
                {
                    sb.AppendFormat("TimeGrain = {0}", this.TimeGrain);
                }

                if (this.StartTime != null)
                {
                    if (sb.Length > 0)
                    {
                        sb.Append(" AND ");
                    }

                    sb.AppendFormat("StartTime = {0}", this.StartTime);
                }

                if (this.EndTime != null)
                {
                    if (sb.Length > 0)
                    {
                        sb.Append(" AND ");
                    }

                    sb.AppendFormat("EndTime = {0}", this.EndTime);
                }

                if (this.MetricDimensions != null)
                {
                    if (sb.Length > 0)
                    {
                        sb.Append(" AND ");
                    }

                    StringBuilder metricDimensionBuilder = new StringBuilder();
                    foreach (MetricDimensionExpression md in this.MetricDimensions.ExpressionElements)
                    {
                        if (metricDimensionBuilder.Length > 0)
                        {
                            metricDimensionBuilder.Append(", ");
                        }

                        metricDimensionBuilder.AppendFormat("{0}{1}{2}", '{', md, '}');
                    }

                    sb.AppendFormat("MetricDimension IN [{0}]", metricDimensionBuilder.ToString());
                }

                return sb.ToString();
            }
        }

        private class MetricDimensionExpressionSet : ExpressionElementSet<MetricDimensionExpressionSet, MetricDimensionExpression>
        {
            public MetricDimensionExpressionSet()
                : base()
            {
            }

            // used for creating the most basic filters the expected usage will only have one non-null parameter
            internal MetricDimensionExpressionSet(string metricName, string dimensionName, string dimensionValue)
                : base()
            {
                this.ExpressionElements.Add(new MetricDimensionExpression()
                {
                    Name = metricName,
                    Dimensions = (dimensionName == null && dimensionValue == null) ? null : new DimensionExpressionSet(dimensionName, dimensionValue)
                });
            }

            internal static MetricDimensionExpressionSet Union(MetricDimensionExpressionSet right, MetricDimensionExpressionSet left)
            {
                return right.Or(left);
            }

            internal static MetricDimensionExpressionSet Intersect(MetricDimensionExpressionSet right, MetricDimensionExpressionSet left)
            {
                return right.And(left);
            }
        }

        // MetricDimension represents a dimension with a metric name and optional list of Dimensions
        private class MetricDimensionExpression : ExpressionElement<MetricDimensionExpression>
        {
            [ExpressionElementProperty]
            internal string Name { get; set; }

            [ExpressionElementCollectionProperty(typeof(DimensionExpressionSet), "Union", "Intersect")]
            internal DimensionExpressionSet Dimensions { get; set; }

            internal override MetricDimensionExpression Clone()
            {
                return new MetricDimensionExpression()
                {
                    Name = this.Name,
                    Dimensions = this.Dimensions == null ? null : this.Dimensions.Clone()
                };
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();

                if (this.Name != null)
                {
                    sb.AppendFormat("Metric Name = \"{0}\"", this.Name);
                }

                if (this.Dimensions != null)
                {
                    if (sb.Length > 0)
                    {
                        sb.Append(" AND ");
                    }

                    StringBuilder dimensionBuilder = new StringBuilder();
                    foreach (DimensionExpression dimension in this.Dimensions.ExpressionElements)
                    {
                        if (dimensionBuilder.Length > 0)
                        {
                            dimensionBuilder.Append(", ");
                        }

                        dimensionBuilder.AppendFormat("{0}{1}{2}", '{', dimension, '}');
                    }

                    sb.AppendFormat("Dimension IN [{0}]", dimensionBuilder.ToString());
                }

                return sb.ToString();
            }
        }

        private class DimensionExpressionSet : ExpressionElementSet<DimensionExpressionSet, DimensionExpression>
        {
            public DimensionExpressionSet()
                : base()
            {
            }

            // used for creating the most basic filters the expected usage will only have one non-null parameter
            internal DimensionExpressionSet(string dimensionName, string dimensionValue)
                : base()
            {
                this.ExpressionElements.Add(new DimensionExpression()
                {
                    Name = dimensionName,
                    Values = dimensionValue == null ? null : new HashSet<string>() { dimensionValue }
                });
            }

            internal static DimensionExpressionSet Union(DimensionExpressionSet right, DimensionExpressionSet left)
            {
                return right.Or(left);
            }

            internal static DimensionExpressionSet Intersect(DimensionExpressionSet right, DimensionExpressionSet left)
            {
                return right.And(left);
            }
        }

        // A Dimension has a dimension name and an optional list of dimension values
        private class DimensionExpression : ExpressionElement<DimensionExpression>
        {
            [ExpressionElementProperty]
            internal string Name { get; set; }

            [ExpressionElementCollectionProperty(typeof(DimensionExpression), "Union", "Intersect")]
            internal HashSet<string> Values { get; set; }

            internal override DimensionExpression Clone()
            {
                return new DimensionExpression()
                {
                    Name = this.Name,
                    Values = this.Values == null ? null : new HashSet<string>(this.Values)
                };
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();

                if (this.Name != null)
                {
                    sb.AppendFormat("Dimension Name = \"{0}\"", this.Name);
                }

                if (this.Values != null)
                {
                    if (sb.Length > 0)
                    {
                        sb.Append(" AND ");
                    }

                    StringBuilder valueBuilder = new StringBuilder();
                    foreach (string value in this.Values)
                    {
                        if (valueBuilder.Length > 0)
                        {
                            valueBuilder.Append(", ");
                        }

                        valueBuilder.AppendFormat("\"{0}\"", value);
                    }

                    sb.AppendFormat("Value IN [{0}]", valueBuilder.ToString());
                }

                return sb.ToString();
            }

            internal static HashSet<string> Union(HashSet<string> right, HashSet<string> left)
            {
                return new HashSet<string>(right.Union(left));
            }

            internal static HashSet<string> Intersect(HashSet<string> right, HashSet<string> left)
            {
                return new HashSet<string>(right.Intersect(left));
            }
        }

        private class MetricFilterExpressionTokenizer
        {
            private List<MetricFilterExpressionToken> Tokens { get; set; }

            internal MetricFilterExpressionToken Current
            {
                get { return this.IsEmpty ? null : this.Tokens[0]; }
            }

            internal bool IsEmpty
            {
                get { return this.Tokens.Count == 0; }
            }

            internal MetricFilterExpressionTokenizer(string filterString)
            {
                this.Tokens = this.TokenizeFilterString(filterString);
            }

            internal void Advance()
            {
                this.Tokens.RemoveAt(0);
            }

            [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
            private List<MetricFilterExpressionToken> TokenizeFilterString(string filterString)
            {
                List<MetricFilterExpressionToken> tokenList = new List<MetricFilterExpressionToken>();
                int pos = 0;

                // preliminary tokenizing loop
                while (pos < filterString.Length)
                {
                    char c = filterString[pos];

                    // Whitespace Token
                    if (char.IsWhiteSpace(c))
                    {
                        StringBuilder sb = new StringBuilder();

                        for (sb.Append(c); ++pos < filterString.Length && char.IsWhiteSpace(c = filterString[pos]); sb.Append(c))
                        {
                        }

                        // The whitespace tokens will be removed later, but are required to separate other tokens for now
                        tokenList.Add(new MetricFilterExpressionToken(sb.ToString(), MetricFilterExpressionToken.TokenType.Whitespace));
                    }
                    else if (char.IsLetter(c) || c == '_')
                    {
                        // Identifier Token (keywords are handled later)
                        StringBuilder sb = new StringBuilder();

                        for (sb.Append(c); ++pos < filterString.Length && (char.IsLetterOrDigit(c = filterString[pos]) || c == '_' || c == '.'); sb.Append(c))
                        {
                        }

                        tokenList.Add(new MetricFilterExpressionToken(sb.ToString(), MetricFilterExpressionToken.TokenType.Identifier));
                    }
                    else if (char.IsDigit(c) || c == '-')
                    {
                        // only supported token starting with a number is DateTimeOffset
                        StringBuilder sb = new StringBuilder();

                        for (sb.Append(c);
                            ++pos < filterString.Length &&
                            (char.IsDigit(c = filterString[pos]) || "TZ:.-+".Contains(c));
                            sb.Append(c))
                        {
                        }

                        tokenList.Add(new MetricFilterExpressionToken(sb.ToString(), MetricFilterExpressionToken.TokenType.DateTimeOffsetValue));
                    }
                    else
                    {
                        switch (c)
                        {
                            case '\'':
                                StringBuilder sb = new StringBuilder();

                                // slight variation here to avoid capturing opening quote
                                for (pos++; pos < filterString.Length && (c = filterString[pos]) != '\''; pos++)
                                {
                                    sb.Append(c);
                                }

                                // verify and step over closing quote
                                if (pos++ >= filterString.Length)
                                {
                                    throw new FormatException("Unclosed StringValue token");
                                }

                                tokenList.Add(new MetricFilterExpressionToken(sb.ToString(), MetricFilterExpressionToken.TokenType.StringValue));

                                break;
                            case ')':
                            case '(':
                                tokenList.Add(new MetricFilterExpressionToken(
                                    filterString.Substring(pos++, 1),
                                    c == '(' ? MetricFilterExpressionToken.TokenType.OpenParen : MetricFilterExpressionToken.TokenType.CloseParen));
                                break;
                            default:
                                throw new FormatException(string.Format(CultureInfo.InvariantCulture, "Unexpected character encountered '{0}'", c));
                        }
                    }
                }

                // Second pass identifies keywords (operators) and duration values
                for (int i = 0; i < tokenList.Count; i++)
                {
                    MetricFilterExpressionToken t = tokenList[i];

                    if (t.Type == MetricFilterExpressionToken.TokenType.Whitespace)
                    {
                        tokenList.RemoveAt(i--);
                        continue;
                    }

                    if (t.Type != MetricFilterExpressionToken.TokenType.Identifier)
                    {
                        continue;
                    }

                    // The OData spec appears to be case sensitive here.
                    switch (t.Value)
                    {
                        case "and":
                            t.Type = MetricFilterExpressionToken.TokenType.AndOperator;
                            continue;
                        case "or":
                            t.Type = MetricFilterExpressionToken.TokenType.OrOperator;
                            continue;
                        case "eq":
                            t.Type = MetricFilterExpressionToken.TokenType.EqOperator;
                            continue;
                        case "duration":
                            if (i + 1 < tokenList.Count && tokenList[i + 1].Type == MetricFilterExpressionToken.TokenType.StringValue)
                            {
                                t.Type = MetricFilterExpressionToken.TokenType.DurationValue;
                                t.Value = tokenList[i + 1].Value;
                                tokenList.RemoveAt(i + 1);
                            }

                            continue;
                    }
                }

                return tokenList;
            }
        }

        /// <summary>
        /// Generates a MetricFilter object from the given filter string
        /// </summary>
        /// <param name="query">the ($filter) query string</param>
        /// <param name="validate">True to validate fields. Fase to skip validation.</param>
        /// <returns>A MetricFilter object representing the query</returns>
        public static MetricFilter Parse(string query, bool validate = true)
        {
            // Tokenize, parse, interpret, then translate to MetricFilter
            return InterpretFilterExpressionTree(ParseFilterExpressionTree(new MetricFilterExpressionTokenizer(query.Trim()))).ToMetricFilter(validate);
        }

        /**
         * Parser implements a recursive-descent parser for the following grammar:
         * 
         * E -> T OR E | T
         * T -> F AND T | F
         * F -> ID EQ VALUE | ( E )
         * 
         * E = Expression (ANDs and ORs)
         * T = Term (ANDs only)
         * F = Clause
         * ID = Identifier (token)
         * EQ = EQ operator (token)
         * VALUE = value (token)
         * OR = OR operator (token)
         * AND = AND operator (token)
         * ( and ) are also terminals (tokens)
         * */

        private static MetricFilterExpressionTree ParseFilterExpressionTree(MetricFilterExpressionTokenizer tokenizer)
        {
            MetricFilterExpressionTree tree = ParseFilterExpression(tokenizer);
            if (!tokenizer.IsEmpty)
            {
                throw GenerateFilterParseException(tokenizer.Current, MetricFilterExpressionToken.TokenType.OrOperator);
            }

            return tree;
        }

        // Parse Filter Expression (disjunction) corresponds to E -> T OR E | T
        private static MetricFilterExpressionTree ParseFilterExpression(MetricFilterExpressionTokenizer tokenizer)
        {
            MetricFilterExpressionTree node = ParseFilterTerm(tokenizer);

            // E -> T
            if (tokenizer.IsEmpty)
            {
                return node;
            }

            if (tokenizer.Current.Type == MetricFilterExpressionToken.TokenType.OrOperator)
            {
                // Consume OR
                tokenizer.Advance();

                // E -> T OR E
                return new MetricFilterExpressionTree()
                {
                    IsConjunction = false,
                    LeftExpression = node,
                    RightExpression = ParseFilterExpression(tokenizer)
                };
            }

            return node;
        }

        // Parse Filter Term (conjunction) corresponds to T -> F AND T | F
        private static MetricFilterExpressionTree ParseFilterTerm(MetricFilterExpressionTokenizer tokenizer)
        {
            // Match Clause
            MetricFilterExpressionTree node = ParseFilterClause(tokenizer);

            // T -> F
            if (tokenizer.IsEmpty)
            {
                return node;
            }

            if (tokenizer.Current.Type == MetricFilterExpressionToken.TokenType.AndOperator)
            {
                // Consume AND
                tokenizer.Advance();

                // T -> F AND T
                return new MetricFilterExpressionTree()
                {
                    IsConjunction = true,
                    LeftExpression = node,
                    RightExpression = ParseFilterTerm(tokenizer)
                };
            }

            return node;
        }

        // Parse filter clause (or parenthesized expression) corresponds to F -> ID EQ VALUE | (E)
        private static MetricFilterExpressionTree ParseFilterClause(MetricFilterExpressionTokenizer tokenizer)
        {
            if (tokenizer == null || tokenizer.IsEmpty)
            {
                throw GenerateFilterParseException(null, MetricFilterExpressionToken.TokenType.Identifier);
            }

            MetricFilterExpressionToken token = tokenizer.Current;

            switch (token.Type)
            {
                case MetricFilterExpressionToken.TokenType.Identifier: // F -> ID EQ VALUE
                    // validate and store the parameter name
                    FilterParameter parameter = ParseParameter(token.Value);

                    // Consume name
                    tokenizer.Advance();

                    // Verify and comsume EQ
                    if (tokenizer.IsEmpty || tokenizer.Current.Type != MetricFilterExpressionToken.TokenType.EqOperator)
                    {
                        throw GenerateFilterParseException(tokenizer.Current, MetricFilterExpressionToken.TokenType.EqOperator);
                    }

                    tokenizer.Advance();
                    MetricFilterExpressionToken.TokenType expectedType = GetExpectedTokenTypeForParameter(parameter);

                    // Verify, store, and consume value
                    if (tokenizer.IsEmpty || tokenizer.Current.Type != expectedType)
                    {
                        throw GenerateFilterParseException(tokenizer.Current, expectedType);
                    }

                    string value = tokenizer.Current.Value;
                    tokenizer.Advance();

                    return new MetricFilterExpressionTree()
                    {
                        Value = new KeyValuePair<FilterParameter, string>(ParseParameter(token.Value), value)
                    };
                case MetricFilterExpressionToken.TokenType.OpenParen: // F -> (E)
                    // Consume (
                    tokenizer.Advance();

                    // Match Expression
                    MetricFilterExpressionTree node = ParseFilterExpression(tokenizer);

                    // Verify and consume )
                    if (tokenizer.IsEmpty || tokenizer.Current.Type != MetricFilterExpressionToken.TokenType.CloseParen)
                    {
                        throw GenerateFilterParseException(tokenizer.Current, MetricFilterExpressionToken.TokenType.CloseParen);
                    }

                    tokenizer.Advance();

                    return node;
                default:
                    throw GenerateFilterParseException(token, MetricFilterExpressionToken.TokenType.Identifier);
            }
        }

        // Build MetricFilter from expression tree by depth-first evaluation
        private static MetricFilterExpression InterpretFilterExpressionTree(MetricFilterExpressionTree tree)
        {
            if (tree == null)
            {
                return null;
            }

            // Leaf Node: Create simple Filter
            if (tree.LeftExpression == null && tree.RightExpression == null)
            {
                MetricFilterExpression expression = new MetricFilterExpression(
                    tree.Value.Key == FilterParameter.TimeGrain ? tree.Value.Value : null,
                    tree.Value.Key == FilterParameter.StartTime ? tree.Value.Value : null,
                    tree.Value.Key == FilterParameter.EndTime ? tree.Value.Value : null,
                    tree.Value.Key == FilterParameter.MetricName ? tree.Value.Value : null,
                    tree.Value.Key == FilterParameter.DimensionName ? tree.Value.Value : null,
                    tree.Value.Key == FilterParameter.DimensionValue ? tree.Value.Value : null);

                return expression;
            }

            // Just in case (should never happen)
            if (tree.LeftExpression == null || tree.RightExpression == null)
            {
                throw new FormatException("Unexpected Parse Error.");
            }

            // Tree Node: Combine children
            return tree.IsConjunction
                ? InterpretFilterExpressionTree(tree.LeftExpression).And(InterpretFilterExpressionTree(tree.RightExpression)) as MetricFilterExpression
                : InterpretFilterExpressionTree(tree.LeftExpression).Or(InterpretFilterExpressionTree(tree.RightExpression)) as MetricFilterExpression;
        }

        private static FilterParameter ParseParameter(string value)
        {
            switch (value)
            {
                case "timeGrain": return FilterParameter.TimeGrain;
                case "startTime": return FilterParameter.StartTime;
                case "endTime": return FilterParameter.EndTime;
                case "name.value": return FilterParameter.MetricName;
                case "dimensionName.value": return FilterParameter.DimensionName;
                case "dimensionValue.value": return FilterParameter.DimensionValue;
                default: throw new FormatException("Invalid Identifier: " + value);
            }
        }

        private static MetricFilterExpressionToken.TokenType GetExpectedTokenTypeForParameter(FilterParameter parameter)
        {
            switch (parameter)
            {
                // TimeGrain should have Duration value
                case FilterParameter.TimeGrain:
                    return MetricFilterExpressionToken.TokenType.DurationValue;

                // StartTime and EndTime should have DateTimeOffset Value
                case FilterParameter.StartTime:
                case FilterParameter.EndTime:
                    return MetricFilterExpressionToken.TokenType.DateTimeOffsetValue;

                // Others (MetricName, DimensionName, DimensionValue) should have String value
                default:
                    return MetricFilterExpressionToken.TokenType.StringValue;
            }
        }

        private class MetricFilterExpressionToken
        {
            internal string Value { get; set; }

            internal TokenType Type { get; set; }

            internal MetricFilterExpressionToken(string value, TokenType type)
            {
                this.Value = value;
                this.Type = type;
            }

            public override string ToString()
            {
                return "[TokenType: " + this.Type + ", Value: " + this.Value + "]";
            }

            internal enum TokenType
            {
                Whitespace,
                Identifier,
                DurationValue,
                DateTimeOffsetValue,
                StringValue,
                AndOperator,
                OrOperator,
                EqOperator,
                OpenParen,
                CloseParen
            }
        }

        // FilterExpressionNodes represent AND/OR operations
        private class MetricFilterExpressionTree
        {
            internal bool IsConjunction { get; set; }

            internal MetricFilterExpressionTree LeftExpression { get; set; }

            internal MetricFilterExpressionTree RightExpression { get; set; }

            internal KeyValuePair<FilterParameter, string> Value { get; set; }
        }

        private enum FilterParameter
        {
            TimeGrain,
            StartTime,
            EndTime,
            MetricName,
            DimensionName,
            DimensionValue,
        }

        private static FormatException GenerateFilterParseException(MetricFilterExpressionToken encountered, MetricFilterExpressionToken.TokenType expected)
        {
            return new FormatException(
                string.Format(CultureInfo.InvariantCulture, "Failed to parse expression. Expected {0} token (encountered {1}).", expected, encountered));
        }
    }
}