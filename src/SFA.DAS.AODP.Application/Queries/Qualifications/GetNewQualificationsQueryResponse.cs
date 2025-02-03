﻿
namespace SFA.DAS.AODP.Application.Queries.Qualifications
{
    public class GetNewQualificationsQueryResponse
    {
        public bool Success { get; set; }
        public List<NewQualification> NewQualifications { get; set; } = new();

    }

    public class NewQualification
    {
        public int Id { get; set; }
        public string? Title { get; set; }
    }
}
