using System;
using System.Collections.Generic;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Test.Context;
using Test.Models;
using Test.Models.Dto;

namespace Test.Services.Impl
{
    public class DefaultAddCountService : IAddCountService 
    {
        private readonly CountInfoContext _context;

        public DefaultAddCountService(CountInfoContext context)
        {
            _context = context;
        }
        
        // private string GetIPAddress()
        // {
        //     System.Web.HttpContext context = System.Web.HttpContext.Current; 
        //     string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        //
        //     if (!string.IsNullOrEmpty(ipAddress))
        //     {
        //         string[] addresses = ipAddress.Split(',');
        //         if (addresses.Length != 0)
        //         {
        //             return addresses[0];
        //         }
        //     }
        //
        //     return context.Request.ServerVariables["REMOTE_ADDR"];
        // }
        private async Task AddCount(long userId, long imageId)
        {
            // var ipaddress = GetIPAddress();
            var countInfo = _context.UserInfos.FirstOrDefaultAsync(x => x.UserId == userId && x.ImageId == imageId).Result;
            if (countInfo == null)
            {
                var userinfo = new UserInfo
                {
                    UserId = userId,
                    Count = 1,
                    Date = DateTime.Now,
                    ImageId = imageId
                };
                await _context.UserInfos.AddAsync(userinfo);
            }
            else
            {
                countInfo.Count += 1;
                countInfo.Date = DateTime.Now;
                
            }
            await _context.SaveChangesAsync();
            await UpdateImageInfo(imageId);
        }

        private async Task UpdateImageInfo(long imageId)
        {
            var imageInfo = await _context.ImageInfos.FirstOrDefaultAsync(x => x.ImageId == imageId);
            if (imageInfo != null)
            {
                imageInfo.Statistic += 1;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<UserInfoDto> UserInfo(long userId, long imageId)
        {
            await AddCount(userId, imageId);
            var context = _context.UserInfos.FirstOrDefaultAsync(x=>x.UserId == userId && x.ImageId == imageId).Result;
            return new UserInfoDto
            {
                Data = context != null ? context : null
            };
        }
    }
}