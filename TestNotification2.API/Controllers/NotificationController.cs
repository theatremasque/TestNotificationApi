using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestNotification2.API.Notifications;
using TestNotification2.API.Sender;

namespace TestNotification2.API.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class NotificationController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IEmailSender _email;
    private readonly IMessageCreator _creator;

    public NotificationController(IMediator mediator, IEmailSender email, IMessageCreator creator)
    {
        _mediator = mediator;
        _email = email;
        _creator = creator;
    }
    
    [HttpPost]
    public async Task<ActionResult> AddNotify(OnPublicationDisapprovedNotification notification)
    {
        await _mediator.Publish(notification);
        
        return Ok("Entity was successfully added to db!");
    }

    [HttpGet]
    public async Task<ActionResult> SendMessage(string email, CancellationToken cancellationToken)
    {
        var titles = new[]
        {
            "Методичні засади та проблеми оцінювання інтелектуальної складової інноваційного розвитку промислового підприємства",
            "SYSTEM AFFORDING SAFETY AT ROAD SITUATIONS",
            "Теоретичні основи визначення сутності загальновиробничих витрат в системі бухгалтерського обліку промислових підприємств"
        };
        
        try

        {
            var message = _creator.Create(email, "НУОП | Національний Університет \"Одеська Політехніка\"", titles);
            
            await _email.SendAsync(message, cancellationToken);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        return Ok();
    }
}