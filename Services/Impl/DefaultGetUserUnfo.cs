using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Context;
using Test.Models;
using Test.Models.Dto;

namespace Test.Services.Impl
{
    public class DefaultGetUserUnfo : IGetUsersInfo
    {
        private readonly CountInfoContext _context;

        public DefaultGetUserUnfo(CountInfoContext context)
        {
            _context = context;
        }

        public async Task<UsersInfoDto> UsersInfo()
        {
            var context = _context.UserInfos;
            var list = context.ToList();

            return new UsersInfoDto
            {
                Data = list
            };
        }
    }
}