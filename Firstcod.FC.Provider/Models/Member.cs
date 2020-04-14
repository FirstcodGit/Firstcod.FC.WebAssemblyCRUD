using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Firstcod.FC.Provider.Models
{
    public class Member
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public byte[] Password { get; set; }
        public string Roles { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime CreateDate { get; set; }
        public int StateId { get; set; }
    }
}
