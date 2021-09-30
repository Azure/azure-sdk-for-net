// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using NUnit.Framework.Constraints;

// All classes defined herein to make extension easily portable.
#pragma warning disable SA1402

namespace Azure.Core.TestFramework
{
    public static class ConstraintExtensions
    {
        /// <summary>
        /// Determines if the dictionary or key-value collection contain the given <paramref name="key"/> and <paramref name="value"/>.
        /// </summary>
        /// <typeparam name="TKey">The type of key to compare.</typeparam>
        /// <typeparam name="TValue">The type of value to compare.</typeparam>
        /// <param name="source">The <see cref="ConstraintExpression"/> to extend.</param>
        /// <param name="key">The key to compare.</param>
        /// <param name="value">The value to compare.</param>
        /// <returns>a <see cref="ContainsKeyValueConstraint{TKey, TValue}"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> is null.</exception>
        public static ContainsKeyValueConstraint<TKey, TValue> ContainsKeyValue<TKey, TValue>(this ConstraintExpression source, TKey key, TValue value)
            where TKey : notnull
        {
            var constraint = new ContainsKeyValueConstraint<TKey, TValue>(key, value);
            source.Append(constraint);

            return constraint;
        }

        /// <summary>
        /// Determines if an item matches the given <paramref name="predicate"/>.
        /// </summary>
        /// <typeparam name="T">The type of item to check.</typeparam>
        /// <param name="source">The <see cref="ConstraintExpression"/> to extend.</param>
        /// <param name="predicate">The predicate to invoke with the item.</param>
        /// <returns>A <see cref="MatchConstraint{T}"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="predicate"/> is null.</exception>
        public static MatchConstraint<T> Match<T>(this ConstraintExpression source, Func<T, bool> predicate)
        {
            var constraint = new MatchConstraint<T>(predicate ?? throw new ArgumentNullException(nameof(predicate)));
            source.Append(constraint);

            return constraint;
        }
    }

    public class ContainsKeyValueConstraint<TKey, TValue> : Constraint
    {
        private readonly TKey _key;
        private readonly TValue _value;

        private IEqualityComparer<TKey> _keyComparer;
        private IEqualityComparer<TValue> _valueComparer;

        public ContainsKeyValueConstraint(TKey key, TValue value)
        {
            _key = key ?? throw new ArgumentNullException(nameof(key));
            _value = value;
        }

        public override string Description => $"dictionary containing entry [{_key}, {_value}]";

        protected IEqualityComparer<TKey> KeyComparer
        {
            get => _keyComparer ?? EqualityComparer<TKey>.Default;
            set => _keyComparer = value;
        }

        protected IEqualityComparer<TValue> ValueComparer
        {
            get => _valueComparer ?? EqualityComparer<TValue>.Default;
            set => _valueComparer = value;
        }

        public override ConstraintResult ApplyTo<TActual>(TActual actual)
        {
            bool success = actual is KeyValuePair<TKey, TValue> pair
                 && KeyComparer.Equals(_key, pair.Key)
                 && ValueComparer.Equals(_value, pair.Value);

            return new ConstraintResult(this, actual, success);
        }

        /// <summary>
        /// Configures the key comparer; otherwise, <see cref="EqualityComparer{T}.Default"/> is used.
        /// </summary>
        /// <param name="comparer">The <see cref="IEqualityComparer{T}"/> to use for key comparisons.</param>
        /// <returns>This <see cref="ContainsKeyValueConstraint{TKey, TValue}"/>.</returns>
        public ContainsKeyValueConstraint<TKey, TValue> UsingKeyComparer(IEqualityComparer<TKey> comparer)
        {
            _keyComparer = comparer;
            return this;
        }

        /// <summary>
        /// Configures the value comparer; otherwise, <see cref="EqualityComparer{T}.Default"/> is used.
        /// </summary>
        /// <param name="comparer">The <see cref="IEqualityComparer{T}"/> to use for value comparisons.</param>
        /// <returns>This <see cref="ContainsKeyValueConstraint{TKey, TValue}"/>.</returns>
        public ContainsKeyValueConstraint<TKey, TValue> UsingValueComparer(IEqualityComparer<TValue> comparer)
        {
            _valueComparer = comparer;
            return this;
        }
    }

    public class MatchConstraint<T> : Constraint
    {
        private readonly Func<T, bool> _predicate;

        public MatchConstraint(Func<T, bool> predicate)
        {
            _predicate = predicate ?? throw new ArgumentNullException(nameof(predicate));
        }

        public override string Description
        {
            get => _predicate.Method.Name.StartsWith("<")
                ? "value matching lambda expression"
                : "value matching " + _predicate.Method.Name;
        }

        public override ConstraintResult ApplyTo<TActual>(TActual actual)
        {
            if (actual is T argument)
            {
                return new ConstraintResult(this, argument, _predicate(argument));
            }

            return new ConstraintResult(this, actual, false);
        }
    }
}
