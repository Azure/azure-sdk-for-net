// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// 
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.
namespace Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading;

    /// <summary>
   ///    An interlocked Boolean.
   /// </summary>
   [Serializable]
#if Non_Public_SDK
   public struct InterlockedBoolean : IComparable<bool>, IComparable<InterlockedBoolean>, IComparable, IEquatable<bool>, IEquatable<InterlockedBoolean>
#else
   internal struct InterlockedBoolean : IComparable<bool>, IComparable<InterlockedBoolean>, IComparable, IEquatable<bool>, IEquatable<InterlockedBoolean>
#endif
   {
      private int value;

      /// <summary>
      ///    Initializes a new instance of the <see cref="InterlockedBoolean" /> struct.
      /// </summary>
      /// <param name="value"> The initial value of the instance. </param>
      public InterlockedBoolean(bool value)
      {
         this.value = value ? 1 : 0;
      }

      /// <inheritdoc />
      public int CompareTo(bool other)
      {
         return this.GetValue().CompareTo(other);
      }

      /// <inheritdoc />
      public int CompareTo(InterlockedBoolean other)
      {
         return this.GetValue().CompareTo(other.GetValue());
      }

      /// <inheritdoc />
      public bool Equals(bool other)
      {
         return other.Equals(this.GetValue());
      }

      /// <summary>
      ///    Indicates whether the current object is equal to another object of the same type.
      /// </summary>
      /// <returns> <c>true</c> if the current object is equal to the <paramref name="other" /> parameter; otherwise, <c>false</c> . </returns>
      /// <param name="other"> An object to compare with this object. </param>
      [SuppressMessage("Microsoft.StyleCop.CSharp.ReadabilityRules", "SA1101:PrefixLocalCallsWithThis",
         Justification = "SA is incorrectly ignoring the static method on Object.")]
      public bool Equals(InterlockedBoolean other)
      {
         return this.Equals(other.GetValue());
      }

      /// <summary>
      ///    Determines whether the specified <see cref="System.Object" /> is equal to this instance.
      /// </summary>
      /// <param name="obj"> The <see cref="System.Object" /> to compare with this instance. </param>
      /// <returns> <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c> . </returns>
      public override bool Equals(object obj)
      {
         if (ReferenceEquals(obj, null))
         {
            return false;
         }

         if (obj is InterlockedBoolean)
         {
            return this.Equals((InterlockedBoolean)obj);
         }

         if (obj is bool)
         {
            return this.Equals((bool)obj);
         }

         return false;
      }

      /// <summary>
      ///    Exchanges the value.
      /// </summary>
      /// <param name="newValue"> The value to which the instance is set. </param>
      /// <returns> The original value. </returns>
      public bool ExchangeValue(bool newValue)
      {
         int workingValue = newValue ? 1 : 0;
         int was = Interlocked.Exchange(ref this.value, workingValue);
         return was == 1;
      }

      /// <summary>
      ///    Returns a hash code for this instance.
      /// </summary>
      /// <returns> A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. </returns>
      public override int GetHashCode()
      {
         return Thread.VolatileRead(ref this.value);
      }

      /// <summary>
      ///    Gets the value.
      /// </summary>
      /// <returns> The current value. </returns>
      [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "Method indicates relative cost MWP")]
      public bool GetValue()
      {
         return 0 != Thread.VolatileRead(ref this.value);
      }

      /// <summary>
      ///    Sets the value.
      /// </summary>
      /// <param name="newValue"> The value to which the instance is set. </param>
      [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode",
          Justification = "Okay for now, evaluate later.")]
      public void SetValue(bool newValue)
      {
         this.ExchangeValue(newValue);
      }

      /// <summary>
      ///    Returns a <see cref="System.String" /> that represents this instance.
      /// </summary>
      /// <returns> A <see cref="System.String" /> that represents this instance. </returns>
      public override string ToString()
      {
         return this.GetValue().ToString();
      }

      /// <summary>
      ///    Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
      /// </summary>
      /// <param name="obj"> An object to compare with this instance. </param>
      /// <returns> A value that indicates the relative order of the objects being compared. The return value has these meanings: Value Meaning Less than zero This instance is less than <paramref
      ///     name="obj" /> . Zero This instance is equal to <paramref name="obj" /> . Greater than zero This instance is greater than <paramref
      ///     name="obj" /> . </returns>
      /// <exception cref="ArgumentException">The parameter "obj" is not the same type as this instance.</exception>
      int IComparable.CompareTo(object obj)
      {
         if (ReferenceEquals(obj, null))
         {
            // this object is greater than null.
            return 1;
         }

         if (obj is bool)
         {
            return this.CompareTo((bool)obj);
         }

         if (obj is InterlockedBoolean)
         {
            return this.CompareTo((InterlockedBoolean)obj);
         }

         // It is "standard" to throw ArgumentException when the object is not of a comparable type.
         throw new ArgumentException("Object must be of type Boolean or InterlockedBoolean", "obj");
      }

      /// <summary>
      ///    Equality operator overload.
      /// </summary>
      /// <param name="left"> The left value. </param>
      /// <param name="right"> The right value. </param>
      /// <returns> <c>true</c> when the instances are equal, otherwise <c>false</c> . </returns>
      public static bool operator ==(bool left, InterlockedBoolean right)
      {
         return left.Equals(right.GetValue());
      }

      /// <summary>
      ///    Equality operator overload.
      /// </summary>
      /// <param name="left"> The left value. </param>
      /// <param name="right"> The right value. </param>
      /// <returns> <c>true</c> when the instances are equal, otherwise <c>false</c> . </returns>
      public static bool operator ==(InterlockedBoolean left, bool right)
      {
         return left.Equals(right);
      }

      /// <summary>
      ///    Equality operator overload.
      /// </summary>
      /// <param name="left"> The left value. </param>
      /// <param name="right"> The right value. </param>
      /// <returns> <c>true</c> when the instances are equal, otherwise <c>false</c> . </returns>
      public static bool operator ==(InterlockedBoolean left, InterlockedBoolean right)
      {
         return left.Equals(right);
      }

      /// <summary>
      ///    Greater-than operator overload.
      /// </summary>
      /// <param name="left"> The left value. </param>
      /// <param name="right"> The right value. </param>
      /// <returns> <c>true</c> when the <paramref name="left" /> is greater-than <paramref name="right" /> , otherwise <c>false</c> . </returns>
      public static bool operator >(bool left, InterlockedBoolean right)
      {
         return left.CompareTo(right.GetValue()) > 0;
      }

      /// <summary>
      ///    Greater-than operator overload.
      /// </summary>
      /// <param name="left"> The left value. </param>
      /// <param name="right"> The right value. </param>
      /// <returns> <c>true</c> when the <paramref name="left" /> is greater-than <paramref name="right" /> , otherwise <c>false</c> . </returns>
      public static bool operator >(InterlockedBoolean left, bool right)
      {
         return left.GetValue().CompareTo(right) > 0;
      }

      /// <summary>
      ///    Greater-than operator overload.
      /// </summary>
      /// <param name="left"> The left value. </param>
      /// <param name="right"> The right value. </param>
      /// <returns> <c>true</c> when the <paramref name="left" /> is greater-than <paramref name="right" /> , otherwise <c>false</c> . </returns>
      public static bool operator >(InterlockedBoolean left, InterlockedBoolean right)
      {
         return left.CompareTo(right) > 0;
      }

      /// <summary>
      ///    Greater-than-or-equal-to operator overload.
      /// </summary>
      /// <param name="left"> The left value. </param>
      /// <param name="right"> The right value. </param>
      /// <returns> <c>true</c> when the <paramref name="left" /> is Greater-than-or-equal-to <paramref name="right" /> , otherwise <c>false</c> . </returns>
      public static bool operator >=(bool left, InterlockedBoolean right)
      {
         return left.CompareTo(right.GetValue()) >= 0;
      }

      /// <summary>
      ///    Greater-than-or-equal-to operator overload.
      /// </summary>
      /// <param name="left"> The left value. </param>
      /// <param name="right"> The right value. </param>
      /// <returns> <c>true</c> when the <paramref name="left" /> is Greater-than-or-equal-to <paramref name="right" /> , otherwise <c>false</c> . </returns>
      public static bool operator >=(InterlockedBoolean left, bool right)
      {
         return left.GetValue().CompareTo(right) >= 0;
      }

      /// <summary>
      ///    Greater-than-or-equal-to operator overload.
      /// </summary>
      /// <param name="left"> The left value. </param>
      /// <param name="right"> The right value. </param>
      /// <returns> <c>true</c> when the <paramref name="left" /> is Greater-than-or-equal-to <paramref name="right" /> , otherwise <c>false</c> . </returns>
      public static bool operator >=(InterlockedBoolean left, InterlockedBoolean right)
      {
         return left.CompareTo(right) >= 0;
      }

      /// <summary>
      ///    Performs an implicit conversion from <see cref="InterlockedBoolean" /> to <see cref="System.Boolean" />.
      /// </summary>
      /// <param name="value"> The value. </param>
      /// <returns> The result of the conversion. </returns>
      public static implicit operator bool(InterlockedBoolean value)
      {
         return value.GetValue();
      }

      /// <summary>
      ///    Inequality operator overload.
      /// </summary>
      /// <param name="left"> The left value. </param>
      /// <param name="right"> The right value. </param>
      /// <returns> <c>true</c> when the instances are not equal, otherwise <c>false</c> . </returns>
      public static bool operator !=(bool left, InterlockedBoolean right)
      {
         return !left.Equals(right.GetValue());
      }

      /// <summary>
      ///    Inequality operator overload.
      /// </summary>
      /// <param name="left"> The left value. </param>
      /// <param name="right"> The right value. </param>
      /// <returns> <c>true</c> when the instances are not equal, otherwise <c>false</c> . </returns>
      public static bool operator !=(InterlockedBoolean left, bool right)
      {
         return !left.Equals(right);
      }

      /// <summary>
      ///    Inequality operator overload.
      /// </summary>
      /// <param name="left"> The left value. </param>
      /// <param name="right"> The right value. </param>
      /// <returns> <c>true</c> when the instances are not equal, otherwise <c>false</c> . </returns>
      public static bool operator !=(InterlockedBoolean left, InterlockedBoolean right)
      {
         return !left.Equals(right);
      }

      /// <summary>
      ///    Less-than operator overload.
      /// </summary>
      /// <param name="left"> The left value. </param>
      /// <param name="right"> The right value. </param>
      /// <returns> <c>true</c> when the <paramref name="left" /> is less-than <paramref name="right" /> , otherwise <c>false</c> . </returns>
      public static bool operator <(bool left, InterlockedBoolean right)
      {
         return left.CompareTo(right.GetValue()) < 0;
      }

      /// <summary>
      ///    Less-than operator overload.
      /// </summary>
      /// <param name="left"> The left value. </param>
      /// <param name="right"> The right value. </param>
      /// <returns> <c>true</c> when the <paramref name="left" /> is less-than <paramref name="right" /> , otherwise <c>false</c> . </returns>
      public static bool operator <(InterlockedBoolean left, bool right)
      {
         return left.GetValue().CompareTo(right) < 0;
      }

      /// <summary>
      ///    Less-than operator overload.
      /// </summary>
      /// <param name="left"> The left value. </param>
      /// <param name="right"> The right value. </param>
      /// <returns> <c>true</c> when the <paramref name="left" /> is less-than <paramref name="right" /> , otherwise <c>false</c> . </returns>
      public static bool operator <(InterlockedBoolean left, InterlockedBoolean right)
      {
         return left.CompareTo(right) < 0;
      }

      /// <summary>
      ///    Less-than-or-equal-to operator overload.
      /// </summary>
      /// <param name="left"> The left value. </param>
      /// <param name="right"> The right value. </param>
      /// <returns> <c>true</c> when the <paramref name="left" /> is Less-than-or-equal-to <paramref name="right" /> , otherwise <c>false</c> . </returns>
      public static bool operator <=(bool left, InterlockedBoolean right)
      {
         return left.CompareTo(right.GetValue()) <= 0;
      }

      /// <summary>
      ///    Less-than-or-equal-to operator overload.
      /// </summary>
      /// <param name="left"> The left value. </param>
      /// <param name="right"> The right value. </param>
      /// <returns> <c>true</c> when the <paramref name="left" /> is Less-than-or-equal-to <paramref name="right" /> , otherwise <c>false</c> . </returns>
      public static bool operator <=(InterlockedBoolean left, bool right)
      {
         return left.GetValue().CompareTo(right) <= 0;
      }

      /// <summary>
      ///    Less-than-or-equal-to operator overload.
      /// </summary>
      /// <param name="left"> The left value. </param>
      /// <param name="right"> The right value. </param>
      /// <returns> <c>true</c> when the <paramref name="left" /> is Less-than-or-equal-to <paramref name="right" /> , otherwise <c>false</c> . </returns>
      public static bool operator <=(InterlockedBoolean left, InterlockedBoolean right)
      {
         return left.CompareTo(right) <= 0;
      }
   }
}
