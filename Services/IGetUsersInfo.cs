using System.Threading.Tasks;
using Test.Models.Dto;

namespace Test.Services.Impl
{
    public interface IGetUsersInfo
    {
        Task<UsersInfoDto> UsersInfo();
    }
}