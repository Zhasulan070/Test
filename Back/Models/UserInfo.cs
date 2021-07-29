using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Models
{
    [Table("user_info")]
    public class UserInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")] public long Id { get; set; }
        [Column("user_id")] public long UserId { get; set; }
        [Column("count")] public int Count { get; set; }
        [Column("date")] public DateTime Date { get; set; }
        [Column("image_id")] public long ImageId { get; set; }
    }
}