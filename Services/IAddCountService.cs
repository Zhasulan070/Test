using System.Threading.Tasks;
using Test.Models.Dto;

namespace Test.Services
{
    public interface IAddCountService
    {
        Task<UserInfoDto> UserInfo(long userId, long imageId);
    }
}