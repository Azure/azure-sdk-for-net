// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace Azure.Data.Tables.Queryable
{
    internal enum CountOption
    {
        None,
        ValueOnly,
        InlineAll
    }

    internal abstract class ResourceExpression : Expression
    {
        [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Reviewed.")]
        protected InputReferenceExpression inputRef;

        private List<string> expandPaths;

        private CountOption countOption;

        private Dictionary<ConstantExpression, ConstantExpression> customQueryOptions;

        public override ExpressionType NodeType { get; }

        public override Type Type { get; }

        internal ResourceExpression(Expression source, ExpressionType nodeType, Type type, List<string> expandPaths, CountOption countOption, Dictionary<ConstantExpression, ConstantExpression> customQueryOptions, ProjectionQueryOptionExpression projection)
            : base()
        {
            this.expandPaths = expandPaths ?? new List<string>();
            this.countOption = countOption;
            this.customQueryOptions = customQueryOptions ?? new Dictionary<ConstantExpression, ConstantExpression>(ReferenceEqualityComparer<ConstantExpression>.Instance);
            Projection = projection;
            Source = source;
            NodeType = nodeType;
            Type = type;
        }

        internal abstract ResourceExpression CreateCloneWithNewType(Type type);

        internal abstract bool HasQueryOptions { get; }

        internal abstract Type ResourceType { get; }

        internal abstract bool IsSingleton { get; }

        internal virtual List<string> ExpandPaths
        {
            get { return expandPaths; }
            set { expandPaths = value; }
        }

        internal virtual CountOption CountOption
        {
            get { return countOption; }
            set { countOption = value; }
        }

        internal virtual Dictionary<ConstantExpression, ConstantExpression> CustomQueryOptions
        {
            get { return customQueryOptions; }
            set { customQueryOptions = value; }
        }

        internal ProjectionQueryOptionExpression Projection { get; set; }

        internal Expression Source { get; private set; }

        internal InputReferenceExpression CreateReference()
        {
            if (inputRef == null)
            {
                inputRef = new InputReferenceExpression(this);
            }

            return inputRef;
        }
    }
}
