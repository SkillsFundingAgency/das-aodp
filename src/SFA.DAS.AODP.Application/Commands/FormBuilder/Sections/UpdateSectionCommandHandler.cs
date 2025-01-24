﻿using AutoMapper;
using MediatR;
using SFA.DAS.AODP.Domain.FormBuilder.Requests.Sections;
using SFA.DAS.AODP.Domain.FormBuilder.Responses.Sections;
using SFA.DAS.AODP.Domain.Interfaces;
using SFA.DAS.AODP.Domain.Models;

namespace SFA.DAS.AODP.Application.Commands.FormBuilder.Sections;

public class UpdateSectionCommandHandler : IRequestHandler<UpdateSectionCommand, UpdateSectionCommandResponse>
{
    private readonly IApiClient _apiClient;


    public UpdateSectionCommandHandler(IApiClient apiClient)
    {
        _apiClient = apiClient;

    }

    public async Task<UpdateSectionCommandResponse> Handle(UpdateSectionCommand request, CancellationToken cancellationToken)
    {
        var response = new UpdateSectionCommandResponse()
        {
            Success = false
        };

        try
        {
            var apiRequest = new UpdateSectionApiRequest()
            {
                Data = new UpdateSectionApiRequest.Section()
                {
                    Title = request.Title,
                    Description = request.Description
                }
            };

            await _apiClient.Put(apiRequest);
            response.Success = true;
        }
        catch (Exception ex)
        {
            response.ErrorMessage = ex.Message;
        }

        return response;
    }
}
