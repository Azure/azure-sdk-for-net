//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Xml;

namespace Microsoft.Azure.Insights
{
    /// <summary>
    /// The expression parser creates an Expression that represents an expression in disjunctive-normal-form
    /// Each Expression contains a set of Subexpressions (the conjunctions) with the total expression being the disjunction of them
    /// </summary>
    public static class MetricFilterExpressionParser
    {
        private class MetricFilterExpression
        {
            private List<SubExpression> SubExpressions { get; set; }

            private MetricFilterExpression()
            {
                this.SubExpressions = new List<SubExpression>();
            }

            // used for creating the most basic filters the expected usage will only have one non-null parameter
            // The most basic form also cannot have a complex names constraint so the constructor only accepts a singe string (or null) here as well
            internal MetricFilterExpression(string timeGrain, string startTime, string endTime, string name)
            {
                this.SubExpressions = new List<SubExpression>()
                {
                    new SubExpression()
                    {
                        TimeGrain = timeGrain,
                        StartTime = startTime,
                        EndTime = endTime,
                        Names = name == null ? null : new HashSet<string>() { name }
                    }
                };
            }

            /// <summary>
            /// Filter AND is a sort of cross-join keeping all the valid subfilter ANDs between one subfilter from each filter
            /// </summary>
            /// <param name="other">The MetricFilter to AND with</param>
            /// <returns>A new MetricFilter that is the AND result</returns>
            internal MetricFilterExpression And(MetricFilterExpression other)
            {
                MetricFilterExpression result = new MetricFilterExpression();

                foreach (SubExpression left in this.SubExpressions)
                {
                    foreach (SubExpression right in other.SubExpressions)
                    {
                        SubExpression and = left.And(right);

                        if (and != null)
                        {
                            result.Add(and);
                        }
                    }
                }

                return result;
            }

            /// <summary>
            /// Filter OR adds the two lists of subfilters together and then tries to reduce them by performing subfilter ORs
            /// </summary>
            /// <param name="other">The MetricFilter to OR with</param>
            /// <returns>A new MetricFilter that is the OR result</returns>
            internal MetricFilterExpression Or(MetricFilterExpression other)
            {
                MetricFilterExpression result = this.Clone();

                // First try to OR-in (reduce) the new filters otherwise just add them to the list
                foreach (SubExpression subExpression in other.SubExpressions)
                {
                    result.Add(subExpression);
                }

                return result;
            }

            private void Add(SubExpression subExpression)
            {
                // Find an existing subfilter to OR with
                SubExpression candidate = this.SubExpressions.FirstOrDefault((s) => subExpression.CanOr(s));

                // If can or, replace the existing one with the OR of the two
                if (candidate != null)
                {
                    this.SubExpressions.Remove(candidate);
                    this.SubExpressions.Add(subExpression.Or(candidate));
                }
                else
                {
                    // Can't OR, add the new one to the list
                    this.SubExpressions.Add(subExpression);
                }
            }

            // SubFilter represents a single conjunctive (no ORs) filter segment
            private class SubExpression
            {
                internal string TimeGrain { get; set; }

                internal string StartTime { get; set; }

                internal string EndTime { get; set; }

                internal HashSet<string> Names { get; set; }

                internal SubExpression()
                {
                    this.TimeGrain = null;
                    this.StartTime = null;
                    this.EndTime = null;
                    this.Names = null;
                }

                // AND is mainly used to combine subfilters with non-overlapping parameters. Overlapping parameters must match
                internal SubExpression And(SubExpression other)
                {
                    SubExpression result = this.Clone();

                    // If other has a TimeGrain constraint
                    if (other.TimeGrain != null)
                    {
                        // AND this has a TimeGrain constraint
                        if (result.TimeGrain != null)
                        {
                            // Then they must be the same
                            if (result.TimeGrain != other.TimeGrain)
                            {
                                return null;
                            }
                        }
                        else
                        {
                            // Other has one, but this doesn't simply add the constraint
                            result.TimeGrain = other.TimeGrain;
                        }
                    }

                    // If other has a StartTime constraint
                    if (other.StartTime != null)
                    {
                        // AND this has a StartTime constraint
                        if (result.StartTime != null)
                        {
                            // Then they must be the same
                            if (result.StartTime != other.StartTime)
                            {
                                return null;
                            }
                        }
                        else
                        {
                            // Other has one, but this doesn't simply add the constraint
                            result.StartTime = other.StartTime;
                        }
                    }

                    // If other has a EndTime constraint
                    if (other.EndTime != null)
                    {
                        // AND this has a EndTime constraint
                        if (result.EndTime != null)
                        {
                            // Then they must be the same
                            if (result.EndTime != other.EndTime)
                            {
                                return null;
                            }
                        }
                        else
                        {
                            // Other has one, but this doesn't simply add the constraint
                            result.EndTime = other.EndTime;
                        }
                    }

                    // If other has a Names constraint
                    if (other.Names != null)
                    {
                        // Take other's constraint in the absence of one on this, otherwise take the intersection
                        if (result.Names == null)
                        {
                            result.Names = new HashSet<string>(other.Names);
                        }
                        else
                        {
                            result.Names.IntersectWith(other.Names);
                        }
                    }

                    return result;
                }

                // Or on subfilters really only exists for the names parameter, which can have multiple values
                internal SubExpression Or(SubExpression other)
                {
                    if (!this.CanOr(other))
                    {
                        return null;
                    }

                    SubExpression result = this.Clone();

                    if (result.Names != null)
                    {
                        result.Names.UnionWith(other.Names);
                    }

                    return result;
                }

                // Since each subfilter represents a conjunction, ORs are only allowed on subfilters with the same parameters set
                internal bool CanOr(SubExpression other)
                {
                    // All the parameters must be equal in order or OR, except Names, which must either be both null or neither null
                    return this.TimeGrain == other.TimeGrain &&
                           this.StartTime == other.StartTime &&
                           this.EndTime == other.EndTime &&
                           (this.Names == null) == (other.Names == null);
                }

                // A subfilter is valid it has a constraint for timegrain, starttime, endtime, and optionally nameo
                internal bool IsValid()
                {
                    // Names == null means that the name is unconstrained (valid)
                    // Names == empty list means that the names is constrained, but the constraint cannot be satisfied (invalid)
                    return this.TimeGrain != null && this.StartTime != null && this.EndTime != null &&
                           (this.Names == null || this.Names.Count > 0);
                }

                internal SubExpression Clone()
                {
                    return new SubExpression()
                    {
                        TimeGrain = this.TimeGrain,
                        StartTime = this.StartTime,
                        EndTime = this.EndTime,
                        Names = this.Names == null ? null : new HashSet<string>(this.Names)
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

                    if (this.Names != null)
                    {
                        if (sb.Length > 0)
                        {
                            sb.Append(" AND ");
                        }

                        StringBuilder nameBuilder = new StringBuilder();
                        foreach (string name in this.Names)
                        {
                            if (nameBuilder.Length > 0)
                            {
                                nameBuilder.Append(", ");
                            }

                            nameBuilder.Append(name);
                        }

                        sb.AppendFormat("Name IN [{0}]", nameBuilder.ToString());
                    }

                    return sb.ToString();
                }
            }

            /// <summary>
            /// A Filter is valid if it has a single constraint (exactly 1 subfilter) on all properties (Names constraint optional)
            /// </summary>
            /// <returns>Whether or not the filter is valid</returns>
            internal bool IsValid()
            {
                return this.SubExpressions.Count == 1 && this.SubExpressions[0].IsValid();
            }

            internal MetricFilter ToMetricFilter()
            {
                int numSubexpressions = this.SubExpressions.Count;

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
                SubExpression expression = this.SubExpressions[0];

                // Timegrain is required
                if (expression.TimeGrain == null)
                {
                    throw new InvalidOperationException("TimeGrain constraint is required");
                }

                // Starttime is required
                if (expression.StartTime == null)
                {
                    throw new InvalidOperationException("StartTime constraint is required");
                }

                // Endtime is required
                if (expression.EndTime == null)
                {
                    throw new InvalidOperationException("EndTime constraint is required");
                }

                // Names is optional (null means no constraint)
                // Empty means name constraint cannot be satisfied
                if (!(expression.Names == null || expression.Names.Any()))
                {
                    throw new InvalidOperationException("Constraint on Name is impossible to satisfy");
                }

                return new MetricFilter()
                {
                    TimeGrain = XmlConvert.ToTimeSpan(expression.TimeGrain),
                    StartTime = DateTime.Parse(expression.StartTime, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal),
                    EndTime = DateTime.Parse(expression.EndTime, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal),
                    Names = expression.Names
                };
            }

            /// <summary>
            /// Creates a deep copy of the MetricFilterExpression
            /// </summary>
            /// <returns>A deep copf or the Expression</returns>
            private MetricFilterExpression Clone()
            {
                MetricFilterExpression clone = new MetricFilterExpression();

                foreach (SubExpression s in this.SubExpressions)
                {
                    clone.SubExpressions.Add(s.Clone());
                }

                return clone;
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();

                foreach (SubExpression s in this.SubExpressions)
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
        /// <returns>A MetricFilter object representing the query</returns>
        public static MetricFilter Parse(string query)
        {
            // Tokenize, parse, interpret, then translate to MetricFilter
            return InterpretFilterExpressionTree(ParseFilterExpressionTree(new MetricFilterExpressionTokenizer(query.Trim()))).ToMetricFilter();
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
                    MetricFilterExpressionToken.TokenType expectedType =
                        parameter == FilterParameter.TimeGrain ? MetricFilterExpressionToken.TokenType.DurationValue :
                        parameter == FilterParameter.Name ? MetricFilterExpressionToken.TokenType.StringValue :
                        MetricFilterExpressionToken.TokenType.DateTimeOffsetValue;

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
                    tree.Value.Key == FilterParameter.Name ? tree.Value.Value : null);

                return expression;
            }

            // Just in case (should never happen)
            if (tree.LeftExpression == null || tree.RightExpression == null)
            {
                throw new FormatException("Unexpected Parse Error.");
            }

            // Tree Node: Combine children
            return tree.IsConjunction
                ? InterpretFilterExpressionTree(tree.LeftExpression)
                    .And(InterpretFilterExpressionTree(tree.RightExpression))
                : InterpretFilterExpressionTree(tree.LeftExpression)
                    .Or(InterpretFilterExpressionTree(tree.RightExpression));
        }

        private static FilterParameter ParseParameter(string value)
        {
            switch (value)
            {
                case "name.value": return FilterParameter.Name;
                case "timeGrain": return FilterParameter.TimeGrain;
                case "startTime": return FilterParameter.StartTime;
                case "endTime": return FilterParameter.EndTime;
                default: throw new FormatException("Invalid Identifier: " + value);
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
            Name
        }

        private static FormatException GenerateFilterParseException(MetricFilterExpressionToken encountered, MetricFilterExpressionToken.TokenType expected)
        {
            return new FormatException(
                string.Format(CultureInfo.InvariantCulture, "Failed to parse expression. Expected {0} token (encountered {1}).", expected, encountered));
        }
    }
}