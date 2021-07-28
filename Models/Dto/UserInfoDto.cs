using System.Collections.Generic;

namespace Test.Models.Dto
{
    public class UserInfoDto
    {
        public bool Updated { get; set; } = false;
        public bool Success { get; set; } = true;
        public bool Found { get; set; } = true;
        public List<UserInfo> Message { get; set; }
    }
}