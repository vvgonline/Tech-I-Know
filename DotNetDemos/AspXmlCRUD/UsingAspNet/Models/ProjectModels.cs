using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UsingAspNet.Models
{
    public class ProjectModels
    {
        ///<summary>
        /// Gets or sets Project unique number.
        ///</summary>
        public int ProjId { get; set; }
        ///<summary>
        /// Gets or sets Project Name.
        ///</summary>
        [Required]
        public string ProjName { get; set; }
        ///<summary>
        /// Gets or sets Project location. It can be as simple as city/country name or can be full address
        ///</summary>
        [Required]
        public string Location { get; set; }
        ///<summary>
        /// I have not used this
        ///</summary>
        public bool IsEdit { get; set; }
    }
}