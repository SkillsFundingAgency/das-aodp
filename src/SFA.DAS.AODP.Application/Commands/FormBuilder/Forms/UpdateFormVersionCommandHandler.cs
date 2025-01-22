﻿using AutoMapper;
using MediatR;
using SFA.DAS.AODP.Domain.FormBuilder.Requests.Forms;
using SFA.DAS.AODP.Domain.FormBuilder.Responses.Forms;
using SFA.DAS.AODP.Domain.Interfaces;
using SFA.DAS.AODP.Domain.Models;

namespace SFA.DAS.AODP.Application.Commands.FormBuilder.Forms;

public class UpdateFormVersionCommandHandler : IRequestHandler<UpdateFormVersionCommand, UpdateFormVersionCommandResponse>
{
    private readonly IApiClient _apiClient;
    private readonly IMapper _mapper;

    public UpdateFormVersionCommandHandler(IApiClient apiClient, IMapper mapper)
    {
        _apiClient = apiClient;
        _mapper = mapper;
    }

    public async Task<UpdateFormVersionCommandResponse> Handle(UpdateFormVersionCommand request, CancellationToken cancellationToken)
    {
        var response = new UpdateFormVersionCommandResponse();
        response.Success = false;

        try
        {
            var apiRequestData = _mapper.Map<UpdateFormVersionApiRequest.FormVersion>(request.Data);
            var apiRequest = new UpdateFormVersionApiRequest(request.FormVersionId, apiRequestData);
            var result = await _apiClient.PutWithResponseCode<UpdateFormVersionApiResponse>(apiRequest);
            response.Data = _mapper.Map<UpdateFormVersionCommandResponse.FormVersion>(result.Body.Data);
            response.Success = true;
        }
        catch (Exception ex)
        {
            response.Success = false;
            response.ErrorMessage = ex.Message;
        }

        return response;
    }
}
