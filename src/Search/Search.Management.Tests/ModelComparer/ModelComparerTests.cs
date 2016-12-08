// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Tests
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Models;
    using Utilities;
    using Xunit;

    public sealed class ModelComparerTests
    {
        private enum Direction
        {
            Right,
            Left
        }

        [Fact]
        public void CanComparePrimitives()
        {
            Assert.Equal(5, 5, new ModelComparer<int>());
            Assert.Equal(3.14, 3.14, new ModelComparer<double>());
            Assert.Equal('c', 'c', new ModelComparer<char>());

            Assert.NotEqual(5, 1, new ModelComparer<int>());
            Assert.NotEqual(3.14, -2.7, new ModelComparer<double>());
            Assert.NotEqual('c', 'z', new ModelComparer<char>());
        }

        [Fact]
        public void CanCompareEnums()
        {
            Assert.Equal(Direction.Left, Direction.Left, new ModelComparer<Direction>());
            Assert.NotEqual(Direction.Left, Direction.Right, new ModelComparer<Direction>());
        }

        [Fact]
        public void CanCompareNulls()
        {
            Model nullModel = null;

            Assert.Equal(nullModel, nullModel, new ModelComparer<Model>());
            Assert.NotEqual(new Model(), nullModel, new ModelComparer<Model>());
            Assert.NotEqual(nullModel, new Model(), new ModelComparer<Model>());

            IEnumerable<int> nullCollection = null;

            Assert.True(new ModelComparer<IEnumerable<int>>().Equals(nullCollection, nullCollection));
            Assert.False(new ModelComparer<IEnumerable<int>>().Equals(new[] { 1 }, nullCollection));
            Assert.False(new ModelComparer<IEnumerable<int>>().Equals(nullCollection, new[] { 4, 5 }));
        }

        [Fact]
        public void CanCompareExtensibleEnums()
        {
            Assert.Equal(FancyDirection.Left, FancyDirection.Left, new ModelComparer<FancyDirection>());
            Assert.NotEqual(FancyDirection.Left, FancyDirection.Right, new ModelComparer<FancyDirection>());
        }

        [Fact]
        public void CanCompareNullables()
        {
            int? maybeSeven = 7;
            int? maybeFive = 5;
            double? maybePi = 3.14;
            double? maybeE = 2.718;
            bool? maybeTrue = true;
            bool? maybeFalse = false;

            Assert.Equal(maybeSeven, maybeSeven, new ModelComparer<int?>());
            Assert.Equal(maybePi, maybePi, new ModelComparer<double?>());
            Assert.Equal(maybeTrue, maybeTrue, new ModelComparer<bool?>());

            Assert.NotEqual(maybeSeven, maybeFive, new ModelComparer<int?>());
            Assert.NotEqual(maybePi, maybeE, new ModelComparer<double?>());
            Assert.NotEqual(maybeTrue, maybeFalse, new ModelComparer<bool?>());

            Assert.NotEqual(null, maybeSeven, new ModelComparer<int?>());
            Assert.NotEqual(null, maybePi, new ModelComparer<double?>());
            Assert.NotEqual(null, maybeTrue, new ModelComparer<bool?>());

            Assert.NotEqual(maybeSeven, null, new ModelComparer<int?>());
            Assert.NotEqual(maybePi, null, new ModelComparer<double?>());
            Assert.NotEqual(maybeTrue, null, new ModelComparer<bool?>());
        }

        [Fact]
        public void NullEqualsDefault()
        {
            int? maybeZero = 0;
            int? maybeFive = 5;
            int? nullNumber = null;

            bool? maybeFalse = false;
            bool? maybeTrue = true;
            bool? nullBool = null;

            Assert.Equal(maybeZero, nullNumber, new ModelComparer<int?>());
            Assert.Equal(nullNumber, maybeZero, new ModelComparer<int?>());
            Assert.Equal(maybeFalse, nullBool, new ModelComparer<bool?>());
            Assert.Equal(nullBool, maybeFalse, new ModelComparer<bool?>());

            Assert.NotEqual(maybeFive, nullNumber, new ModelComparer<int?>());
            Assert.NotEqual(nullNumber, maybeFive, new ModelComparer<int?>());
            Assert.NotEqual(maybeTrue, nullBool, new ModelComparer<bool?>());
            Assert.NotEqual(nullBool, maybeTrue, new ModelComparer<bool?>());
        }

        [Fact]
        public void CanCompareCollections()
        {
            var ints = new[] { 1, 2, 3 };
            var otherInts = new[] { 4, 5, 6 };
            var strings = new[] { "hello", "bonjour", "guten tag", "你好", "aloha" };
            var otherStrings = new[] { "good bye", "au revoir", "auf wiedersehen", "再見", "aloha" };

            var intComparer = new ModelComparer<int[]>();
            var stringComparer = new ModelComparer<string[]>();

            // We have to use Assert.True/False instead of .Equal/.NotEqual or we won't actually exercise the ModelComparer's collection handling.
            // Also, we use deep copies for some comparisons to make sure the ModelComparer isn't falling back on reference equality.
            Assert.True(intComparer.Equals(ints, ints));
            Assert.True(stringComparer.Equals(strings, strings));

            Assert.True(intComparer.Equals(ints, (int[])ints.Clone()));
            Assert.True(stringComparer.Equals((string[])strings.Clone(), strings));

            Assert.False(intComparer.Equals(ints, otherInts));
            Assert.False(stringComparer.Equals(otherStrings, strings));

            Assert.False(intComparer.Equals(ints, new[] { 7 }));
            Assert.False(stringComparer.Equals(new[] { "who?" }, strings));
        }

        [Fact]
        public void CanCompareDictionaries()
        {
            var x = new Dictionary<string, double>() { { "pi", 3.14 }, { "e", 2.718 } };
            var notX = new Dictionary<string, double>() { { "m", 13.3 }, { "v", 77 } };

            var y = new Dictionary<string, object>() { { "a", "test" }, { "b", "test2" } };
            var notY = new Dictionary<string, object>() { { "w", "other" }, { "u", "side" } };

            var doubleComparer = new ModelComparer<Dictionary<string, double>>();
            var stringComparer = new ModelComparer<Dictionary<string, object>>();

            // We have to use Assert.True/False instead of .Equal/.NotEqual or we won't actually exercise the ModelComparer's collection handling.
            // Also, we use deep copies for some comparisons to make sure the ModelComparer isn't falling back on reference equality.
            Assert.True(doubleComparer.Equals(x, x));
            Assert.True(stringComparer.Equals(y, y));

            Assert.True(doubleComparer.Equals(x, new Dictionary<string, double>(x)));
            Assert.True(stringComparer.Equals(new Dictionary<string, object>(y), y));

            Assert.False(doubleComparer.Equals(x, notX));
            Assert.False(stringComparer.Equals(notY, y));

            Assert.False(doubleComparer.Equals(x, new Dictionary<string, double>() { { "r", 12.0 } }));
            Assert.False(stringComparer.Equals(new Dictionary<string, object>() { { "c", "other" } }, y));
        }

        [Fact]
        public void IEquatableTakesPrecedenceOverIEnumerable()
        {
            var ints = new BiasedList(1, 2, 3);
            var odds = new BiasedList(1, 3, 5);
            var evens = new BiasedList(2, 4, 6);

            var comparer = new ModelComparer<BiasedList>();

            Assert.True(comparer.Equals(ints, ints));
            Assert.True(comparer.Equals(ints, new BiasedList(ints)));

            // ints and odds should compare as equal because BiasedList only looks at the first element.
            Assert.True(comparer.Equals(odds, ints));
            Assert.True(comparer.Equals(new BiasedList(odds), ints));

            Assert.False(comparer.Equals(ints, evens));
            Assert.False(comparer.Equals(ints, new BiasedList(evens)));
        }

        [Fact]
        public void CanComparePolymorphicObjects()
        {
            var cat = new Cat("Gizmo");
            var otherCat = new Cat("Ness");
            var dog = new Dog("Mara");
            var otherDog = new Dog("Daisy");

            var comparer = new ModelComparer<Animal>();

            Assert.Equal(dog, dog, comparer);
            Assert.Equal(dog, new Dog(dog), comparer);
            Assert.Equal(cat, cat, comparer);
            Assert.Equal(cat, new Cat(cat), comparer);

            Assert.NotEqual(dog, otherDog, comparer);
            Assert.NotEqual(cat, otherCat, comparer);
            Assert.NotEqual(dog, cat, comparer);
        }

        [Fact]
        public void CanCompareDtos()
        {
            var model = new Model() { Name = "Magical Trevor", Age = 11 };
            var sameModel = new Model(model);
            var differentModel = new Model() { Name = "Mr. Stabby", Age = 35 };

            var comparer = new ModelComparer<Model>();

            Assert.Equal(model, model, comparer);
            Assert.Equal(model, sameModel, comparer);
            Assert.NotEqual(model, differentModel, comparer);
        }

        [Fact]
        public void ComparisonIgnoresETags()
        {
            var model = new Model() { Name = "Magical Trevor", Age = 11, ETag = "1" };
            var sameModel = new Model(model) { ETag = "2" };

            Assert.Equal(model, sameModel, new ModelComparer<Model>());
        }

        [Fact]
        public void ComparingMarkerClassesAlwaysReturnsTrue()
        {
            var marker = new Empty();
            var otherMarker = new Empty();

            Assert.Equal(marker, marker, new ModelComparer<Empty>());
            Assert.Equal(marker, otherMarker, new ModelComparer<Empty>());
        }

        [Fact]
        public void CanCompareDifferentEnumerableTypes()
        {
            var intArray = new[] { 1, 2, 3 };
            var intList = new List<int>() { 1, 2, 3 };

            var intComparer = new ModelComparer<IEnumerable<int>>();

            // We have to use Assert.True/False instead of .Equal/.NotEqual or we won't actually exercise the ModelComparer's collection handling.
            Assert.True(intComparer.Equals(intArray, intList));
        }

        [Fact]
        public void IntegerComparisonsUseWidestType()
        {
            byte b = 10;
            short s = 10;
            int i = 10;
            long l = 10;

            var comparer = new ModelComparer<object>();

            Assert.Equal(b, s, comparer);
            Assert.Equal(b, i, comparer);
            Assert.Equal(b, l, comparer);
            Assert.Equal(s, b, comparer);
            Assert.Equal(s, i, comparer);
            Assert.Equal(s, l, comparer);
            Assert.Equal(i, b, comparer);
            Assert.Equal(i, s, comparer);
            Assert.Equal(i, l, comparer);
            Assert.Equal(l, b, comparer);
            Assert.Equal(l, s, comparer);
            Assert.Equal(l, i, comparer);
        }

        [Fact]
        public void NullEqualsEmptyCollection()
        {
            IEnumerable<int> nullCollection = null;
            var emptyArray = new int[0];
            var emptyList = new List<int>();

            var comparer = new ModelComparer<IEnumerable<int>>();

            Assert.True(comparer.Equals(nullCollection, emptyArray));
            Assert.True(comparer.Equals(emptyArray, nullCollection));
            Assert.True(comparer.Equals(nullCollection, emptyList));
            Assert.True(comparer.Equals(emptyList, nullCollection));
        }

        [Fact]
        public void CanCompareComplexModels()
        {
            var homeAddress = new USAddress()
            {
                Street = "308 Negra Arroyo Lane",
                City = "Albuquerque",
                State = "New Mexico",
                ZipCode = 87104
            };

            var alternateAddress = new USAddress()
            {
                Street = "Los Pollos Hermanos, 123 Central Ave Southeast",
                City = "Albuquerque",
                State = "New Mexico",
                ZipCode = 87108
            };

            var theOneWhoKnocks = new Customer()
            {
                FirstName = "Walter",
                LastName = "White",
                Aliases = new[] { "Heisenberg", "The One Who Knocks" },
                Age = 51,
                Address = homeAddress,
                Directions = new List<Direction?>() { null, Direction.Left, null, Direction.Right },
                Occupations = new Dictionary<string, Address>()
                {
                    { "Husband and father", homeAddress },
                    { "Career criminal", alternateAddress }
                }
            };

            var walterWhite = theOneWhoKnocks.Clone();

            var gustavoFring = new Customer()
            {
                FirstName = "Gustavo",
                LastName = "Fring",
                Age = 49,
                Address = alternateAddress
            };

            var comparer = new ModelComparer<Customer>();

            Assert.Equal(theOneWhoKnocks, theOneWhoKnocks, comparer);
            Assert.Equal(walterWhite, theOneWhoKnocks, comparer);
            Assert.NotEqual(gustavoFring, theOneWhoKnocks, comparer);
        }

        private class Empty { }

        private class Model : IResourceWithETag
        {
            public Model() { }

            public Model(Model other)
            {
                Name = other.Name;
                Age = other.Age;
                ETag = other.ETag;
            }

            public string Name { get; set; }

            public int Age { get; set; }

            public string ETag { get; set; }
        }

        private class FancyDirection : ExtensibleEnum<FancyDirection>
        {
            public static readonly FancyDirection Left = new FancyDirection("left");

            public static readonly FancyDirection Right = new FancyDirection("right");

            private FancyDirection(string name) : base(name)
            {
                // Base class does all initialization.
            }

            public static FancyDirection Create(string name) => Lookup(name) ?? new FancyDirection(name);
        }

        // Biased lists only care about the first element when it comes to equality comparison.
        private class BiasedList : IEnumerable<int>, IEquatable<BiasedList>
        {
            private int[] _values;

            public BiasedList(params int[] values)
            {
                if (values == null)
                {
                    throw new ArgumentNullException(nameof(values));
                }

                if (values.Length == 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(values), "List must be non-empty");
                }

                _values = values;
            }

            public BiasedList(BiasedList other)
            {
                if (other == null)
                {
                    throw new ArgumentNullException(nameof(other));
                }

                _values = (int[])other._values.Clone();
            }

            public bool Equals(BiasedList other) => other != null && this.First() == other.First();

            public IEnumerator<int> GetEnumerator() => ((IEnumerable<int>)_values).GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
        }

        private abstract class Animal
        {
            protected Animal(string name)
            {
                Name = name;
            }

            public abstract string Noise { get; }

            public string Name { get; }
        }

        private sealed class Dog : Animal, IEquatable<Dog>
        {
            private Random _random;

            public Dog(string name) : base(name)
            {
                _random = new Random();
            }

            public Dog(Dog dog) : this(dog.Name) { }

            // Add some randomness to ensure that IEquatable always takes precedence.
            public override string Noise => _random.Next() % 2 == 0 ? "woof!" : "bark!";

            public bool Equals(Dog other) => other != null && this.Name == other.Name;
        }

        private sealed class Cat : Animal, IEquatable<Cat>
        {
            public Cat(string name) : base(name) { }

            public Cat(Cat cat) : this(cat.Name) { }

            public override string Noise => "meow!";

            public bool Equals(Cat other) => other != null && this.Name == other.Name;
        }

        private class Customer
        {
            public Customer() { }

            public Customer(Customer other)
            {
                Aliases = other.Aliases.ToArray();
                Age = other.Age;
                Address = other.Address.Clone();
                FirstName = other.FirstName;
                LastName = other.LastName;
                Directions = other.Directions.ToList();
                Occupations = other.Occupations.ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Clone());
            }

            public string Name => FirstName + " " + LastName;

            public IList<string> Aliases { get; set; }

            public int? Age { get; set; }

            public Address Address { get; set; }

            public string FirstName { get; set; }

            public string LastName { get; set; }

            public List<Direction?> Directions { get; set; }

            public Dictionary<string, Address> Occupations { get; set; }

            public Customer Clone() => new Customer(this);
        }

        private abstract class Address
        {
            public string Street { get; set; }

            public string City { get; set; }

            public abstract Address Clone();
        }

        private sealed class USAddress : Address
        {
            public USAddress() { }

            public USAddress(USAddress other)
            {
                Street = other.Street;
                City = other.City;
                State = other.State;
                ZipCode = other.ZipCode;
            }

            public string State { get; set; }

            public int ZipCode { get; set; }

            public override Address Clone() => new USAddress(this);
        }
    }
}
