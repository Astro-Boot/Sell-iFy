using System.Net;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sellify.Application.Contracts.Infrasctructure;
using Sellify.Application.Features.Auths.Users.Commands.LoginUser;
using Sellify.Application.Features.Auths.Users.Commands.RegisterUser;
using Sellify.Application.Features.Auths.Users.Commands.ResetPassword;
using Sellify.Application.Features.Auths.Users.Commands.ResetPasswordByToken;
using Sellify.Application.Features.Auths.Users.Commands.SendPassword;
using Sellify.Application.Features.Auths.Users.Commands.UpdateUser;
using Sellify.Application.Features.Auths.Users.Vms;
using Sellify.Application.Models.ImageManagement;

namespace Sellify.Api.Controllers;


[ApiController]
[Route("api/v1/[controller]")]
public class UserController : ControllerBase
{
    private IMediator _mediator;
    private IManageImageService _manageImageService;

    public UserController(IMediator mediator, IManageImageService manageImageService)
    {
        _mediator = mediator;
        _manageImageService = manageImageService;
    }

    [AllowAnonymous]
    [HttpPost("login", Name = "Login")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult<AuthResponse>> Login([FromBody] LoginUserCommand request)
    {
        return await _mediator.Send(request);
    }


    [AllowAnonymous]
    [HttpPost("register", Name = "Register")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult<AuthResponse>> Register([FromForm] RegisterUserCommand request)
    {
        if(request.Foto is not null)
        {
            var resultImage = await _manageImageService.UploadImage(new ImageData
            {
                ImageStream = request.Foto!.OpenReadStream(),
                Nombre = request.Foto.Name
            });
            request.FotoId = resultImage.PublicId;
            request.FotoUrl = resultImage.Url;
        }
        return await _mediator.Send(request);
    }


    [AllowAnonymous]
    [HttpPost("forgotpassword", Name = "ForgotPassword")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult<string>> ForgotPassword([FromBody] SendPasswordCommand request)
    {
        return await _mediator.Send(request);
    }

    [AllowAnonymous]
    [HttpPost("resetpassword", Name = "ResetPassword")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult<string>> ResetPassword([FromBody] ResetPasswordByTokenCommand request)
    {
        return await _mediator.Send(request);
    }


    [HttpPost("updatepassword", Name = "UpdatePassword")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult<Unit>> UpdatePassword([FromBody] ResetPasswordCommand request)
    {
        return await _mediator.Send(request);
    }


    [HttpPut("update", Name = "Update")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult<AuthResponse>> Update([FromForm] UpdateUserCommand request)
    {
        if(request.Foto is not null)
        {
            var resultImage = await _manageImageService.UploadImage( new ImageData
            {
                ImageStream = request.Foto!.OpenReadStream(),
                Nombre = request.Foto!.Name
            });

            request.FotoId =  resultImage.PublicId;
            request.FotoUrl = resultImage.Url;
        }


        return await _mediator.Send(request);
    }
}