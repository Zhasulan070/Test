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
using Test.Models.Dto;
using Test.Services;

namespace Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CountInfoController : ControllerBase
    {
        private readonly ICountInfoService _service;
        private readonly IAddCountService _serviceAdd;

        public CountInfoController(ICountInfoService service, IAddCountService serviceAdd)
        {
            _service = service;
            _serviceAdd = serviceAdd;
        }

        [HttpGet]
        public async Task<IActionResult> LoadCountInfo()
        {
            try
            {
                var a = await _service.LoadCountInfo();
                return Ok(a);
            }
            catch (Exception e)
            {
                var a = new ResponseDto
                {
                    Found = false,
                    Updated = false,
                    Success = false
                };
                if (!(e.InnerException is SocketException) && (e is DataException || e is ExternalException || e is HttpRequestException))
                {
                    Log.Warning(e,"Source Exception thrown on URL {DisplayUrl}", HttpContext.Request.GetDisplayUrl());
                    return BadRequest(a);
                }
                else
                {   
                    Log.Error(e, "Uncaught Service Exception thrown on URL {DisplayUrl}", HttpContext.Request.GetDisplayUrl());
                    return StatusCode((int) HttpStatusCode.InternalServerError, a);
                }
            }
        }
        
        [HttpGet("{userid}/{imageid}")]
        public async Task<IActionResult> AddCount(string userId, string imageId)
        {
            try
            {
                var a = await _serviceAdd.UsersInfo(long.Parse(userId), long.Parse(imageId));
                return Ok(a);
            }
            catch (Exception e)
            {
                var a = new ResponseDto
                {
                    Found = false,
                    Updated = false,
                    Success = false
                };
                if (!(e.InnerException is SocketException) && (e is DataException || e is ExternalException || e is HttpRequestException))
                {
                    Log.Warning(e,"Source Exception thrown on URL {DisplayUrl}", HttpContext.Request.GetDisplayUrl());
                    return BadRequest(a);
                }
                else
                {   
                    Log.Error(e, "Uncaught Service Exception thrown on URL {DisplayUrl}", HttpContext.Request.GetDisplayUrl());
                    return StatusCode((int) HttpStatusCode.InternalServerError, a);
                }
            }
        }
    }
}