// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Azure.Data.Tables.Queryable
{
    [DebuggerDisplay("ResourceSetExpression {Source}.{MemberExpression}")]
    internal class ResourceSetExpression : ResourceExpression
    {
        private readonly Type resourceType;
        private List<QueryOptionExpression> sequenceQueryOptions;

        internal ResourceSetExpression(Type type, Expression source, Expression memberExpression, Type resourceType, List<string> expandPaths, CountOption countOption, Dictionary<ConstantExpression, ConstantExpression> customQueryOptions, ProjectionQueryOptionExpression projection)
            : base(source, source != null ? (ExpressionType)ResourceExpressionType.ResourceNavigationProperty : (ExpressionType)ResourceExpressionType.RootResourceSet, type, expandPaths, countOption, customQueryOptions, projection)
        {
            Debug.Assert(type != null, "type != null");
            Debug.Assert(memberExpression != null, "memberExpression != null");
            Debug.Assert(resourceType != null, "resourceType != null");
            Debug.Assert(
                (source == null && memberExpression is ConstantExpression) ||
                (source != null && memberExpression is MemberExpression),
                "source is null with constant entity set name, or not null with member expression");

            MemberExpression = memberExpression;
            this.resourceType = resourceType;
            sequenceQueryOptions = new List<QueryOptionExpression>();
        }

        internal Expression MemberExpression { get; }

        internal override Type ResourceType
        {
            get { return resourceType; }
        }

        internal bool HasTransparentScope
        {
            get { return TransparentScope != null; }
        }

        internal TransparentAccessors TransparentScope { get; set; }

        internal bool HasKeyPredicate
        {
            get { return KeyPredicate != null; }
        }

        internal Dictionary<PropertyInfo, ConstantExpression> KeyPredicate { get; set; }

        internal override bool IsSingleton
        {
            get { return HasKeyPredicate; }
        }

        internal override bool HasQueryOptions
        {
            get
            {
                return sequenceQueryOptions.Count > 0 ||
                    ExpandPaths.Count > 0 ||
                    CountOption == CountOption.InlineAll ||
                    CustomQueryOptions.Count > 0 ||
                    Projection != null;
            }
        }

        internal FilterQueryOptionExpression Filter
        {
            get
            {
                return sequenceQueryOptions.OfType<FilterQueryOptionExpression>().SingleOrDefault();
            }
        }

        internal RequestOptionsQueryOptionExpression RequestOptions
        {
            get { return sequenceQueryOptions.OfType<RequestOptionsQueryOptionExpression>().SingleOrDefault(); }
        }

        internal TakeQueryOptionExpression Take
        {
            get { return sequenceQueryOptions.OfType<TakeQueryOptionExpression>().SingleOrDefault(); }
        }

        internal IEnumerable<QueryOptionExpression> SequenceQueryOptions
        {
            get { return sequenceQueryOptions.ToList(); }
        }

        internal bool HasSequenceQueryOptions
        {
            get { return sequenceQueryOptions.Count > 0; }
        }

        internal override ResourceExpression CreateCloneWithNewType(Type type)
        {
            ResourceSetExpression rse = new ResourceSetExpression(
                type,
                Source,
                MemberExpression,
                TypeSystem.GetElementType(type),
                ExpandPaths.ToList(),
                CountOption,
                CustomQueryOptions.ToDictionary(kvp => kvp.Key, kvp => kvp.Value),
                Projection)
            {
                KeyPredicate = KeyPredicate,
                sequenceQueryOptions = sequenceQueryOptions,
                TransparentScope = TransparentScope
            };
            return rse;
        }

        internal void AddSequenceQueryOption(QueryOptionExpression qoe)
        {
            Debug.Assert(qoe != null, "qoe != null");
            QueryOptionExpression old = sequenceQueryOptions.Where(o => o.GetType() == qoe.GetType()).FirstOrDefault();
            if (old != null)
            {
                qoe = qoe.ComposeMultipleSpecification(old);
                sequenceQueryOptions.Remove(old);
            }

            sequenceQueryOptions.Add(qoe);
        }

        internal void OverrideInputReference(ResourceSetExpression newInput)
        {
            Debug.Assert(newInput != null, "Original resource set cannot be null");
            Debug.Assert(this.inputRef == null, "OverrideInputReference cannot be called if the target has already been referenced");

            InputReferenceExpression inputRef = newInput.inputRef;
            if (inputRef != null)
            {
                this.inputRef = inputRef;
                inputRef.OverrideTarget(this);
            }
        }

        [DebuggerDisplay("{ToString()}")]
        internal class TransparentAccessors
        {
            internal readonly string Accessor;

            internal readonly Dictionary<string, Expression> SourceAccessors;

            internal TransparentAccessors(string acc, Dictionary<string, Expression> sourceAccessors)
            {
                Debug.Assert(!string.IsNullOrEmpty(acc), "Set accessor cannot be null or empty");
                Debug.Assert(sourceAccessors != null, "sourceAccessors != null");

                Accessor = acc;
                SourceAccessors = sourceAccessors;
            }

            public override string ToString()
            {
                string result = "SourceAccessors=[" + string.Join(",", SourceAccessors.Keys.ToArray());
                result += "] ->* Accessor=" + Accessor;
                return result;
            }
        }
    }
}
