using Application.Activities;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ActivitiesController : BaseController
{
    public ActivitiesController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet]
    public async Task<ActionResult<List<Activity>>> GetActivities(CancellationToken cancellationToken)
    {
        return await Mediator.Send(new List.Query(), cancellationToken);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Activity>> GetActivities(Guid id)
    {
        return await Mediator.Send(new Details.Query { Id = id });
    }

    [HttpPost]
    public async Task<IActionResult> CreateActivity(Activity activity)
    {
        return Ok(await Mediator.Send(new Create.Command {Activity = activity}));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> EditActivity(Guid id, Activity activity)
    {
        activity.Id = id;
        return Ok(await Mediator.Send(new Edit.Command { Activity = activity }));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteActivity(Guid id)
    {
        return Ok(await Mediator.Send(new Delete.Command { Id = id }));
    }
}