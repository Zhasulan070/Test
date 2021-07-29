using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Context;
using Test.Models;
using Test.Models.Dto;

namespace Test.Services.Impl
{
    public class DefaultCountInfoService : ICountInfoService
    {
        private readonly CountInfoContext _context;

        public DefaultCountInfoService(CountInfoContext context)
        {
            _context = context;
        }

        public async Task<ImageInfoDto> LoadCountInfo()
        {
            var context = _context.ImageInfos;
            var imageInfos = context.ToList();

            return new ImageInfoDto
            {
                Data = imageInfos
            };
        }
    }
}