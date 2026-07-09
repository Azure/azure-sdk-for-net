// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Communication.ShortCodes.Models
{
    public static partial class CommunicationShortCodesModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Models.USProgramBrief"/> for mocking. </summary>
        /// <param name="id"> Program Brief Id. </param>
        /// <param name="status"> Status of the program brief. </param>
        /// <param name="number"> The short code of the program brief. </param>
        /// <param name="reviewNotes"> Review notes of the program brief. </param>
        /// <param name="costs"> Costs of the program brief. </param>
        /// <param name="submissionDate"> Date in which the program brief was submitted. </param>
        /// <param name="statusUpdatedDate"> Date in which the status of the program brief was last updated. </param>
        /// <param name="programDetails"> Details of the program. </param>
        /// <param name="companyInformation"> Information about the company. </param>
        /// <param name="messageDetails"> Details of the message. </param>
        /// <param name="trafficDetails"> Details of the traffic. </param>
        /// <returns> A new <see cref="Models.USProgramBrief"/> instance for mocking. </returns>
        public static USProgramBrief USProgramBrief(Guid id = default, ProgramBriefStatus? status = null, string number = null, IEnumerable<ReviewNote> reviewNotes = null, IEnumerable<ShortCodeCost> costs = null, DateTimeOffset? submissionDate = null, DateTimeOffset? statusUpdatedDate = null, ProgramDetails programDetails = null, CompanyInformation companyInformation = null, MessageDetails messageDetails = null, TrafficDetails trafficDetails = null)
        {
            reviewNotes ??= new List<ReviewNote>();
            costs ??= new List<ShortCodeCost>();

            return new USProgramBrief(id, status, number, reviewNotes?.ToList(), costs?.ToList(), submissionDate, statusUpdatedDate, programDetails, companyInformation, messageDetails, trafficDetails);
        }
    }
}
