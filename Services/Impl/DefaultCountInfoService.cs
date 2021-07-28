using System;
using System.Collections.Generic;
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
            var imageInfos = new List<ImageInfo>();
            var context = _context.ImageInfos;
            await foreach (var info in context)
            {
               imageInfos.Add(info);
            }

            return new ImageInfoDto
            {
                Success = true,
                Updated = true,
                Found = true,
                Message = imageInfos
            };
        }
    }
}