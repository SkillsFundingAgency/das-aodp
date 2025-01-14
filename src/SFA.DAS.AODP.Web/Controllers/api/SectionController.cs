﻿using Microsoft.AspNetCore.Mvc;
using SFA.DAS.AODP.Application.Repository;
using SFA.DAS.AODP.Models.Forms.FormBuilder;

namespace SFA.DAS.AODP.Web.Controllers.api;

[Route("api/[controller]")]
[ApiController]
public class SectionController : ControllerBase
{
    private readonly IGenericRepository<Section> _sectionRepository;

    public SectionController(IGenericRepository<Section> sectionRepository) {
        _sectionRepository = sectionRepository;
    }

    [HttpGet]
    [Route("GetSections", Name = "GetSections")]
    [ProducesResponseType(typeof(List<Section>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public IActionResult GetSections(Guid formId)
    {
        try
        {
            var sections = _sectionRepository.GetAll().Where(s => s.FormId == formId).ToList();
            return Ok(sections);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
