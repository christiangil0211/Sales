﻿namespace Sales.API.Controllers
{
    using Helpers;
    using Newtonsoft.Json.Linq;
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

        [HttpPost]
        [Authorize]
        [Route("GetUser")]
        public IHttpActionResult GetUser(JObject form)
        {
            try
            {
                var email = string.Empty;
                dynamic jsonObject = form;

                try
                {
                    email = jsonObject.Email.value;
                }
                catch 
                {

                    return BadRequest("Incorrect call.");
                }

                var user = UsersHelper.GetUserASP(email);
                return Ok(user);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}
