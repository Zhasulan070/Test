using Microsoft.EntityFrameworkCore;
using Test.Models;

namespace Test.Context
{
    public class CountInfoContext : DbContext
    {
        public CountInfoContext(DbContextOptions<CountInfoContext> options)
            : base(options)
        {
            
        }
        public DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<ImageInfo> ImageInfos { get; set; }
    }
}