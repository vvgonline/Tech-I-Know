using System.ComponentModel.DataAnnotations;

namespace CoreWebApp.Models
{
    public class ProjListModel
    {
        ///<summary>
        /// Gets or sets Project unique number.
        ///</summary>
        public int ProjId { get; set; }
        ///<summary>
        /// Gets or sets Project Name.
        ///</summary>
        [Required]
        public required string ProjName { get; set; }
        ///<summary>
        /// Gets or sets Project location. It can be as simple as city/country name or can be full address
        ///</summary>
        [Required]
        public required string Location { get; set; }
        ///<summary>
        /// I have not used this
        ///</summary>
        public bool IsEdit { get; set; }
    }
}
