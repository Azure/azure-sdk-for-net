// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.Language.QuestionAnswering.Authoring
{
    public partial class QnaRecord
    {
        /// <summary> Initializes a new instance of <see cref="QnaRecord"/>. </summary>
        /// <param name="id"> Unique ID for the QnA. </param>
        public QnaRecord(int id) : this()
        {
            Id = id;
        }
    }
}
