﻿using SFA.DAS.AODP.Domain.FormBuilder.Responses.Sections;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SFA.DAS.AODP.Application.Queries.FormBuilder.Sections;

public class GetSectionByIdQueryResponse : BaseResponse
{
    public Section Data { get; set; }


    public class Section
    {
        public Guid Id { get; set; }
        public Guid FormVersionId { get; set; }
        public Guid Key { get; set; }
        public int Order { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Page> Pages { get; set; }

        public static implicit operator Section(GetSectionByIdApiResponse.Section entity)
        {
            return new()
            {
                Id = entity.Id,
                FormVersionId = entity.FormVersionId,
                Title = entity.Title,
                Key = entity.Key,
                Description = entity.Description,
                Order = entity.Order

            };
        }
    }


    public class Page
    {
        public Guid Id { get; set; }
        public Guid Key { get; set; }
        public int Order { get; set; }
        public string Title { get; set; }

        public static implicit operator Page(GetSectionByIdApiResponse.Page entity)
        {
            return new()
            {
                Id = entity.Id,
                Key = entity.Key,
                Order = entity.Order,
                Title = entity.Title
            };
        }
    }
}