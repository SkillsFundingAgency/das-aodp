﻿using AutoMapper;
using MediatR;
using SFA.DAS.AODP.Domain.FormBuilder.Requests.Sections;
using SFA.DAS.AODP.Domain.FormBuilder.Responses.Sections;
using SFA.DAS.AODP.Domain.Interfaces;
using SFA.DAS.AODP.Domain.Models;

namespace SFA.DAS.AODP.Application.Commands.FormBuilder.Sections;

public class UpdateSectionCommandHandler : IRequestHandler<UpdateSectionCommand, UpdateSectionCommandResponse>
{
    private readonly IAodpApiClient<AodpApiConfiguration> _apiClient;
    private readonly IMapper _mapper;

    public UpdateSectionCommandHandler(IAodpApiClient<AodpApiConfiguration> apiClient, IMapper mapper)
    {
        _apiClient = apiClient;
        _mapper = mapper;
    }

    public async Task<UpdateSectionCommandResponse> Handle(UpdateSectionCommand request, CancellationToken cancellationToken)
    {
        var response = new UpdateSectionCommandResponse()
        {
            Success = false
        };

        try
        {
            var apiRequestData = _mapper.Map<UpdateSectionApiRequest.Section>(request.Data);
            var apiRequest = new UpdateSectionApiRequest(request.FormVersionId, apiRequestData);
            var result = await _apiClient.PutWithResponseCode<UpdateSectionApiResponse>(apiRequest);
            response.Data = _mapper.Map<UpdateSectionCommandResponse.Section>(result.Body.Data);
            response.Success = true;
        }
        catch (Exception ex)
        {
            response.ErrorMessage = ex.Message;
        }

        return response;
    }
}
