using System;
using System.Collections.Generic;

namespace CDNApi.Models
{
    public partial class TblFreelancerUserList
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Mail { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string? Skillsets { get; set; }
        public string? Hobby { get; set; }
    }
}
