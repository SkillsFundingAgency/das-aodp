﻿using AutoMapper;
using MediatR;
using SFA.DAS.AODP.Domain.FormBuilder.Requests.Forms;
using SFA.DAS.AODP.Domain.FormBuilder.Responses.Forms;
using SFA.DAS.AODP.Domain.Interfaces;
using SFA.DAS.AODP.Domain.Models;

namespace SFA.DAS.AODP.Application.Commands.FormBuilder.Forms;

public class PublishFormVersionCommandHandler : IRequestHandler<PublishFormVersionCommand, PublishFormVersionCommandResponse>
{
    private readonly IApiClient _apiClient;

    public PublishFormVersionCommandHandler(IApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public async Task<PublishFormVersionCommandResponse> Handle(PublishFormVersionCommand request, CancellationToken cancellationToken)
    {
        var response = new PublishFormVersionCommandResponse();
        response.Success = false;

        try
        {
            var apiRequest = new PublishFormVersionApiRequest(request.FormVersionId);
            var result = await _apiClient.PutWithResponseCode<PublishFormVersionApiResponse>(apiRequest);
            response = new PublishFormVersionCommandResponse();
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
