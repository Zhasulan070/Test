using System.Threading.Tasks;
using Test.Models.Dto;

namespace Test.Services
{
    public interface IAddCountService
    {
        Task<ImageInfoDto> ImageInfo(long userId, long imageId);
    }
}