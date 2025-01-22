﻿namespace SFA.DAS.AODP.Application.Commands.FormBuilder.Sections;

public class UpdateSectionCommandResponse : BaseResponse {
    public Section Data { get; set; }

    public class Section
    {
        public Guid Id { get; set; }
        public Guid FormVersionId { get; set; }
        public Guid Key { get; set; }
        public int Order { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? NextSectionId { get; set; }
    }
}