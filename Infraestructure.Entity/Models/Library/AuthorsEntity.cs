using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Infraestructure.Entity.Models.Library
{
    [Table("Authors", Schema = "Library")]
    public class AuthorsEntity
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public string  Name { get; set; }

        [MaxLength(100)]
        public string LastName { get; set; }

    }
}
