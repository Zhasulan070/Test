using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Models
{
    [Table("image_info")]
    public class ImageInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")] public long Id { get; set; }
        [Column("url")] public string Url { get; set; }
        [Column("statistic")] public long Statistic { get; set; }
        [Column("image_id")] public long ImageId { get; set; }
    }
}