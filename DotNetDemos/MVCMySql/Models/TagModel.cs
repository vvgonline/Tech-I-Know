using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCMySql.Models
{
    [Table("tbl_tag")]
    public class TagModel
    {
        [Key]
        public int TagId { get; set; }
        public string TagName { get; set; }
        public int TagFrequency { get; set; }
    }

    public class RemoteMySqlCon : DbContext
    {
        //MySql Database connection String
        //public RemoteMySqlCon() : base (nameOrConnectionString: "RemoteMySqlServer") { }
        public virtual DbSet<TagModel> Tags { get; set; }
    }
}