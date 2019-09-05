namespace Sales.API.Controllers
{
    using Helpers;
    using Sales.Common.Models;
    using System;
    using System.IO;
    using System.Web.Http;

    [RoutePrefix("api/Users")]
    public class UsersController : ApiController
    {
        public IHttpActionResult PostUser(UserRequest userRequest)
        {
            if (userRequest.ImageArray != null && userRequest.ImageArray.Length>0)
            {
                var stream = new MemoryStream(userRequest.ImageArray);
                var guid = Guid.NewGuid().ToString();
                var file = $"{guid}.jgp";
                var folder = "~/Content/Users";
                var fullPath = $"{folder}/{file}";
                var response = FilesHelper.UploadPhoto(stream, folder, file);

                if (response)
                {
                    userRequest.ImagePath = fullPath;
                }
            }
            var answer = UsersHelper.CreateUserASP(userRequest);
            if (answer.IsSuccess)
            {
                return Ok(answer);
            }

            return BadRequest(answer.Message);
            
        }

    }
}
