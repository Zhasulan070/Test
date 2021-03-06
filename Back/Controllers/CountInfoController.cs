using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Test.Models;
using Test.Models.Dto;
using Test.Services;
using Test.Services.Impl;

namespace Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CountInfoController : ControllerBase
    {
        private readonly ICountInfoService _service;
        private readonly IAddCountService _serviceAdd;
        private readonly IGetUsersInfo _serviceGet;

        public CountInfoController(ICountInfoService service, IAddCountService serviceAdd, IGetUsersInfo serviceGet)
        {
            _service = service;
            _serviceAdd = serviceAdd;
            _serviceGet = serviceGet;
        }

        [HttpGet("ImagesInfo")]
        public async Task<IActionResult> LoadCountInfo()
        {
            try
            {
                var a = await _service.LoadCountInfo();
                return Ok(a);
            }
            catch (Exception e)
            {
                
                if (!(e.InnerException is SocketException) && (e is DataException || e is ExternalException || e is HttpRequestException))
                {
                    Log.Warning(e,"Source Exception thrown on URL {DisplayUrl}", HttpContext.Request.GetDisplayUrl());
                    return BadRequest();
                }
                else
                {   
                    Log.Error(e, "Uncaught Service Exception thrown on URL {DisplayUrl}", HttpContext.Request.GetDisplayUrl());
                    return StatusCode((int) HttpStatusCode.InternalServerError);
                }
            }
        }
        
        [HttpGet("UsersInfo")]
        public async Task<IActionResult> AddCount()
        {
            try
            {
                var a = await _serviceGet.UsersInfo();
                return Ok(a);
            }
            catch (Exception e)
            {
                if (!(e.InnerException is SocketException) && (e is DataException || e is ExternalException || e is HttpRequestException))
                {
                    Log.Warning(e,"Source Exception thrown on URL {DisplayUrl}", HttpContext.Request.GetDisplayUrl());
                    return BadRequest();
                }
                else
                {   
                    Log.Error(e, "Uncaught Service Exception thrown on URL {DisplayUrl}", HttpContext.Request.GetDisplayUrl());
                    return StatusCode((int) HttpStatusCode.InternalServerError);
                }
            }
        }
        
        [HttpPost("ImageInfo")]
        public async Task<IActionResult> AddCount([FromBody] Body body)
        {
            try
            {
                var a = await _serviceAdd.ImageInfo(body.UserId, body.ImageId);
                return Ok(a);
            }
            catch (Exception e)
            {
                if (!(e.InnerException is SocketException) && (e is DataException || e is ExternalException || e is HttpRequestException))
                {
                    Log.Warning(e,"Source Exception thrown on URL {DisplayUrl}", HttpContext.Request.GetDisplayUrl());
                    return BadRequest();
                }
                else
                {   
                    Log.Error(e, "Uncaught Service Exception thrown on URL {DisplayUrl}", HttpContext.Request.GetDisplayUrl());
                    return StatusCode((int) HttpStatusCode.InternalServerError);
                }
            }
        }
    }
}