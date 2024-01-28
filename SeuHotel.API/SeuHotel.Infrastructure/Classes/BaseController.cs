using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shared.Core.Classes.Interfaces;

namespace Shared.Core.Classes;

public abstract class BaseController<O, I> : ControllerBase
    where I : IService<O>
{
    protected ILogger _logger;
    protected IMapper _mapper;
    protected I _service;
    protected BaseController(ILogger logger, IMapper mapper, I service)
    {
        _logger = logger;
        _mapper = mapper;
        _service = service;
    }

    [HttpGet("{id}")]
    public virtual async Task<ActionResult<O>> ById(long id)
    {
        var result = await _service.GetOne(id);

        if (result is null) return NotFound();

        return Ok(result);
    }

    [HttpGet]
    public virtual async Task<ActionResult<List<O>>> All()
    {
        var result = await _service.GetAll();

        if (result is null) return NotFound();

        return Ok(result);
    }

    [HttpPost]
    public virtual async Task<ActionResult<O>> Post([FromBody] O dto)
    {
        var result = await _service.Create(dto);

        if (result is null) return NotFound();

        return Ok(result);
    }

    [HttpPut("{id}")]
    public virtual async Task<ActionResult<O>> Put([FromRoute] long? id, [FromBody] O dto)
    {
        var result = await _service.Update(id, dto);

        if (result is null) return NotFound();

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public virtual async Task<ActionResult<O>> Delete([FromRoute] long id)
    {
        await _service.Delete(id);

        return NoContent();
    }
}