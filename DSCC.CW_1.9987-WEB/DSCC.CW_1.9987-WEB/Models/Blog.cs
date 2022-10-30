using System;
using System.ComponentModel;

namespace DSCC.CW_1._9987_WEB.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public DateTime? WrittenDate { get; set; }
        [DisplayName("Written Date")]
        public string FormattedWrittenDate { get; set; }

        public string Post { get; set; }
    }
}