using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCMySql.Models
{
    [Table("contact")]
    public class ContactModel
    {
        [Key]
        public int MsgId { get; set; }
        public string MsgUserName { get; set; }
        public string MsgUserEmail { get; set; }
        public string Msg { get; set; }
    }

    public class MySqlCon : DbContext
    {
        //MySql Database connection String
        public MySqlCon() : base(nameOrConnectionString: "LocalMySqlServer") { }
        public virtual DbSet<ContactModel> Contacts { get; set; }
    }    
}