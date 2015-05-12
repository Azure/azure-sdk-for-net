//
// Copyright © Microsoft Corporation, All Rights Reserved
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS
// OF ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION
// ANY IMPLIED WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A
// PARTICULAR PURPOSE, MERCHANTABILITY OR NON-INFRINGEMENT.
//
// See the Apache License, Version 2.0 for the specific language
// governing permissions and limitations under the License.

using System;

namespace Microsoft.Azure.KeyVault
{
    public static class UnixEpoch
    {
        public static readonly DateTime EpochDate = new DateTime( 1970, 1, 1, 0, 0, 0, DateTimeKind.Utc );

        /// <summary>
        /// Convert the number of seconds since midnight (UTC) on 1st January 1970 to date
        /// </summary>
        /// <param name="seconds">The number of seconds since midnight (UTC) on 1st January 1970</param>
        /// <returns>The date in UTC form</returns>
        public static DateTime FromUnixTime( long seconds )
        {
            return EpochDate.AddSeconds( seconds );
        }

        /// <summary>
        /// Gets the current time as the number of seconds since midnight (UTC) on 1st January 1970
        /// </summary>
        /// <returns>The number of seconds since midnight (UTC) on 1st January 1970</returns>
        public static long Now()
        {
            return DateTime.UtcNow.ToUnixTime();
        }

        /// <summary>
        /// Returns the number of seconds after Unix Epoch (January 1 1970 00:00:00 GMT, until the given time).
        /// </summary>
        /// <param name="dateTime">The date, in UTC form.</param>
        /// <returns>Number of seconds from January 1 1970.</returns>
        public static long ToUnixTime( this DateTime dateTime )
        {
            return ( long )dateTime.Subtract( EpochDate ).TotalSeconds;
        }
    }
}
