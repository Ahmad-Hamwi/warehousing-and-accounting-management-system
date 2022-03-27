using Microsoft.AspNetCore.Mvc;
using wms.Dto.Requests;
using wms.Dto.Responses.Authentication;
using wms.Dto.ViewModels;

namespace wms.Controllers;

public class AuthenticationController : ApiControllerBase
{
    [HttpPost("authenticate")]
    public ActionResult<AuthenticateResponseBody> Authenticate(AuthenticateRequestBody body)
    {
        var authenticatedUser = _Authenticate(body);

        return Ok(new AuthenticateResponseBody(authenticatedUser));
    }

    private AuthenticatedUserViewModel _Authenticate(AuthenticateRequestBody body)
    {
        return new AuthenticatedUserViewModel()
        {
            Token = "eyfiowjeiouqwhfgnwipejcnxowuehfiuqiwubqndijwniwqu",
            UserViewModel = new UserViewModel()
            {
                Username = body.UserName
            }
        };
    }

    [HttpGet("test")]
    public IActionResult Test()
    {
        throw new Exception("This is a test to the 500 Internal Server Error exception");
    }
}