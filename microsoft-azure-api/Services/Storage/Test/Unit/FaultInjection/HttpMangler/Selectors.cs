// -----------------------------------------------------------------------------------------
// <copyright file="Selectors.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// -----------------------------------------------------------------------------------------

//-----------------------------------------------------------------------
// <copyright file="Selectors.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// <summary>
//     Selectors are predicates over Fiddler.Session objects.
// </summary>
//-----------------------------------------------------------------------
namespace Microsoft.WindowsAzure.Test.Network
{
    using System;
    using Fiddler;

    /// <summary>
    /// Selectors are predicates over Fiddler.Session objects. This static class contains a good number of useful ones.
    /// </summary>
    public static class Selectors
    {
        /// <summary>
        /// Always returns a predicate which returns true in every case.
        /// </summary>
        /// <returns>The relevant selector.</returns>
        public static Func<Session, bool> Always()
        {
            return Always;
        }

        /// <summary>
        /// Never returns a predicate which returns false in every case.
        /// </summary>
        /// <returns>The relevant selector.</returns>
        public static Func<Session, bool> Never()
        {
            return Never;
        }

        /// <summary>
        /// And returns a selector which is the logical AND value of the two provided selectors.
        /// </summary>
        /// <param name="lhsPredicate">The left-hand side predicate.</param>
        /// <param name="rhsPredicate">The right-hand side predicate.</param>
        /// <returns>The relevant selector.</returns>
        public static Func<Session, bool> And(this Func<Session, bool> lhsPredicate, Func<Session, bool> rhsPredicate)
        {
            return session => lhsPredicate(session) && rhsPredicate(session);
        }

        /// <summary>
        /// Or returns a selector which is the logical OR value of the two provided selectors.
        /// </summary>
        /// <param name="lhsPredicate">The left-hand side predicate.</param>
        /// <param name="rhsPredicate">The right-hand side predicate.</param>
        /// <returns>The relevant selector.</returns>
        public static Func<Session, bool> Or(this Func<Session, bool> lhsPredicate, Func<Session, bool> rhsPredicate)
        {
            return session => lhsPredicate(session) || rhsPredicate(session);
        }

        /// <summary>
        /// Alternating returns a predicate which returns true, then false, then true, and so forth.
        /// </summary>
        /// <param name="initialState">The initial state of the alternating selector.</param>
        /// <returns>The relevant selector.</returns>
        public static Func<Session, bool> Alternating(bool initialState = true)
        {
            return new AlternatingSelector(initialState).Tick;
        }

        /// <summary>
        /// Alternating returns a predicate which returns true, then false, then true, and so forth.
        /// </summary>
        /// <param name="predicate">The initial predicate.</param>
        /// <param name="initialState">The initial state of the alternating selector.</param>
        /// <returns>The relevant selector.</returns>
        public static Func<Session, bool> Alternating(this Func<Session, bool> predicate, bool initialState = true)
        {
            return predicate.And(Selectors.Alternating(initialState));
        }

        /// <summary>
        /// EveryNSessions returns a predicate which returns true once every n times.
        /// </summary>
        /// <param name="n">The period of the selector.</param>
        /// <returns>The relevant selector.</returns>
        public static Func<Session, bool> EveryNSessions(int n)
        {
            return new EveryNSessionsSelector(n).Tick;
        }

        /// <summary>
        /// EveryNSessions returns a predicate which returns true once every n times.
        /// </summary>
        /// <param name="predicate">The initial predicate.</param>
        /// <param name="n">The period of the selector.</param>
        /// <returns>The relevant selector.</returns>
        public static Func<Session, bool> EveryNSessions(this Func<Session, bool> predicate, int n)
        {
            return predicate.And(Selectors.EveryNSessions(n));
        }

        /// <summary>
        /// SkipNSessions returns a predicate which always returns true after n invocations.
        /// </summary>
        /// <param name="n">How many sessions to skip.</param>
        /// <returns>The relevant selector.</returns>
        public static Func<Session, bool> SkipNSessions(int n)
        {
            return new SkipNSessionsSelector(n).Tick;
        }

        /// <summary>
        /// SkipNSessions returns a predicate which always returns true after n invocations.
        /// </summary>
        /// <param name="predicate">The initial predicate.</param>
        /// <param name="n">How many sessions to skip.</param>
        /// <returns>The relevant selector.</returns>
        public static Func<Session, bool> SkipNSessions(this Func<Session, bool> predicate, int n)
        {
            return predicate.And(Selectors.SkipNSessions(n));
        }

        /// <summary>
        /// IfGet returns a selector on the GET verb.
        /// </summary>
        /// <returns>The relevant selector.</returns>
        public static Func<Session, bool> IfGet()
        {
            return session => session.HTTPMethodIs("GET");
        }

        /// <summary>
        /// IfGet returns a selector that adds a test for the GET verb.
        /// </summary>
        /// <param name="predicate">The initial predicate.</param>
        /// <returns>The relevant selector.</returns>
        public static Func<Session, bool> IfGet(this Func<Session, bool> predicate)
        {
            return predicate.And(Selectors.IfGet());
        }

        /// <summary>
        /// IfHead returns a selector on the HEAD verb.
        /// </summary>
        /// <returns>The relevant selector.</returns>
        public static Func<Session, bool> IfHead()
        {
            return session => session.HTTPMethodIs("HEAD");
        }

        /// <summary>
        /// IfHead returns a selector that adds a test for the HEAD verb.
        /// </summary>
        /// <param name="predicate">The initial predicate.</param>
        /// <returns>The relevant selector.</returns>
        public static Func<Session, bool> IfHead(this Func<Session, bool> predicate)
        {
            return predicate.And(Selectors.IfHead());
        }

        /// <summary>
        /// IfPost returns a selector on the POST verb.
        /// </summary>
        /// <returns>The relevant selector.</returns>
        public static Func<Session, bool> IfPost()
        {
            return session => session.HTTPMethodIs("POST");
        }

        /// <summary>
        /// IfPost returns a selector that adds a test for the POST verb.
        /// </summary>
        /// <param name="predicate">The initial predicate.</param>
        /// <returns>The relevant selector.</returns>
        public static Func<Session, bool> IfPost(this Func<Session, bool> predicate)
        {
            return predicate.And(Selectors.IfPost());
        }

        /// <summary>
        /// IfPut returns a selector on the PUT verb.
        /// </summary>
        /// <returns>The relevant selector.</returns>
        public static Func<Session, bool> IfPut()
        {
            return session => session.HTTPMethodIs("PUT");
        }

        /// <summary>
        /// IfPut returns a selector that adds a test for the PUT verb.
        /// </summary>
        /// <param name="predicate">The initial predicate.</param>
        /// <returns>The relevant selector.</returns>
        public static Func<Session, bool> IfPut(this Func<Session, bool> predicate)
        {
            return predicate.And(Selectors.IfPut());
        }

        /// <summary>
        /// IfDelete returns a selector on the DELETE verb.
        /// </summary>
        /// <returns>The relevant selector.</returns>
        public static Func<Session, bool> IfDelete()
        {
            return session => session.HTTPMethodIs("DELETE");
        }

        /// <summary>
        /// IfDelete returns a selector that adds a test for the GET verb.
        /// </summary>
        /// <param name="predicate">The initial predicate.</param>
        /// <returns>The relevant selector.</returns>
        public static Func<Session, bool> IfDelete(this Func<Session, bool> predicate)
        {
            return predicate.And(Selectors.IfDelete());
        }

        /// <summary>
        /// IfUrlEquals returns a predicate which returns true if the URL in the session matches the given URL.
        /// </summary>
        /// <param name="urlToMatch">The URL to match.</param>
        /// <returns>The relevant selector.</returns>
        public static Func<Session, bool> IfUrlEquals(string urlToMatch)
        {
            return session => session.url == urlToMatch;
        }

        /// <summary>
        /// IfUrlEquals returns a predicate which returns true if the URL in the session matches the given URL.
        /// </summary>
        /// <param name="predicate">The initial predicate.</param>
        /// <param name="urlToMatch">The URL to match.</param>
        /// <returns>The relevant selector.</returns>
        public static Func<Session, bool> IfUrlEquals(this Func<Session, bool> predicate, string urlToMatch)
        {
            return predicate.And(Selectors.IfUrlEquals(urlToMatch));
        }

        /// <summary>
        /// IfUrlContains returns a predicate which returns true if the URL contains the given substring of a URL.
        /// </summary>
        /// <param name="urlSubstring">The substring for which to search.</param>
        /// <returns>The relevant selector.</returns>
        public static Func<Session, bool> IfUrlContains(string urlSubstring)
        {
            return session => session.url.Contains(urlSubstring);
        }

        /// <summary>
        /// IfUrlContains returns a predicate which returns true if the URL contains the given substring of a URL.
        /// </summary>
        /// <param name="predicate">The initial predicate.</param>
        /// <param name="urlSubstring">The substring for which to search.</param>
        /// <returns>The relevant selector.</returns>
        public static Func<Session, bool> IfUrlContains(this Func<Session, bool> predicate, string urlSubstring)
        {
            return predicate.And(Selectors.IfUrlContains(urlSubstring));
        }

        /// <summary>
        /// IfHostNameContains returns a predicate which returns true if the hostname contains the given substring.
        /// </summary>
        /// <param name="hostNameSubstring">The substring for which to search.</param>
        /// <returns>The relevant selector.</returns>
        public static Func<Session, bool> IfHostNameContains(string hostNameSubstring)
        {
            return session => session.hostname.Contains(hostNameSubstring);
        }

        /// <summary>
        /// IfHostNameContains returns a predicate which returns true if the hostname contains the given substring.
        /// </summary>
        /// <param name="predicate">The initial predicate.</param>
        /// <param name="hostNameSubstring">The substring for which to search.</param>
        /// <returns>The relevant selector.</returns>
        public static Func<Session, bool> IfHostNameContains(this Func<Session, bool> predicate, string hostNameSubstring)
        {
            return predicate.And(Selectors.IfHostNameContains(hostNameSubstring));
        }

        /// <summary>
        /// Always will always return true.
        /// </summary>
        /// <param name="session">The relevant session; unused.</param>
        /// <returns>True in every case.</returns>
        private static bool Always(Session session)
        {
            return true;
        }

        /// <summary>
        /// Never will always return false.
        /// </summary>
        /// <param name="session">The relevant session; unused.</param>
        /// <returns>False in every case.</returns>
        private static bool Never(Session session)
        {
            return false;
        }

        /// <summary>
        /// Helper class for the Alternating selector.
        /// </summary>
        private class AlternatingSelector
        {
            /// <summary>
            /// Holds the state that will be returned with the next call to Tick
            /// </summary>
            private bool state;

            /// <summary>
            /// Initializes a new instance of the AlternatingSelector class.
            /// </summary>
            /// <param name="initialState">The initial value of a call to Tick.</param>
            public AlternatingSelector(bool initialState)
            {
                this.state = initialState;
            }

            /// <summary>
            /// Tick returns the current value of the state parameter, switching it in the process.
            /// </summary>
            /// <param name="session">The session in question; unused.</param>
            /// <returns>The previous value of the state parameter.</returns>
            public bool Tick(Session session)
            {
                bool returnState = this.state;
                this.state = !this.state;
                return returnState;
            }
        }

        /// <summary>
        /// Helper class for the Alternating selector.
        /// </summary>
        private class PercentageSelector
        {
            /// <summary>
            /// Holds the state that will be returned with the next call to Tick
            /// </summary>
            private double percentage;
            double tState = 0;
            /// <summary>
            /// Initializes a new instance of the AlternatingSelector class.
            /// </summary>
            /// <param name="percentage">The initial value of a call to Tick.</param>
            public PercentageSelector(double percentage)
            {
                this.percentage = percentage;
            }

            /// <summary>
            /// Tick returns the current value of the state parameter, switching it in the process.
            /// </summary>
            /// <param name="session">The session in question; unused.</param>
            /// <returns>The previous value of the state parameter.</returns>
            public bool Tick(Session session)
            {
                tState += percentage;
                if (tState > 1.0)
                {
                    tState -= 1;
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        /// Helper class for the EveryNSessions selectors
        /// </summary>
        private class EveryNSessionsSelector
        {
            /// <summary>
            /// Holds the value which count must be divisible by in order for Tick to return true.
            /// </summary>
            private readonly int n;

            /// <summary>
            /// Holds the count of the number of times tick has been called.
            /// </summary>
            private int count;

            /// <summary>
            /// Initializes a new instance of the EveryNSessionsSelector class.
            /// </summary>
            /// <param name="n">Tick will return true every n times.</param>
            public EveryNSessionsSelector(int n)
            {
                this.count = 0;
                this.n = n;
            }

            /// <summary>
            /// Tick returns true if the current count is divisible by count.
            /// </summary>
            /// <param name="session">The session in question; unused.</param>
            /// <returns>True if the current number of times Tick has been called is divisible by n; false otherwise.</returns>
            public bool Tick(Session session)
            {
                return 0 == (++this.count % this.n);
            }
        }

        /// <summary>
        /// Helper class for the SkipNSessions selectors
        /// </summary>
        private class SkipNSessionsSelector
        {
            /// <summary>
            /// Holds the value which count must be greater than in order for Tick to return true.
            /// </summary>
            private readonly int n;

            /// <summary>
            /// Holds the count of the number of times Tick has been called.
            /// </summary>
            private int count;

            /// <summary>
            /// Initializes a new instance of the SkipNSessionsSelector class.
            /// </summary>
            /// <param name="n">Tick will return true after it has been called n times.</param>
            public SkipNSessionsSelector(int n)
            {
                this.count = 0;
                this.n = n;
            }

            /// <summary>
            /// Tick returns true if the current call count is greater than n.
            /// </summary>
            /// <param name="session">The session in question; unused.</param>
            /// <returns>True if the current number of times Tick has been called is greater than n; false otherwise.</returns>
            public bool Tick(Session session)
            {
                return ++this.count > this.n;
            }
        }
    }
}