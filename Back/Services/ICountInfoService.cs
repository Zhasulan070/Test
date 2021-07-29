using System.Threading.Tasks;
using Test.Models.Dto;

namespace Test.Services
{
    public interface ICountInfoService
    {
        Task<ImagesInfoDto> LoadCountInfo();
    }
}