using Infraestructure.Entity.Models.Master;
using Infraestructure.Entity.Models.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Infraestructure.Entity.Models.Library
{
    [Table("Bocks", Schema = "Library")]
    public class BooksEntity
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(100)]
        public string Gender { get; set; }
        public string Synopsis { get; set; }

        public int Pages { get; set; }

        [ForeignKey("EditorialEntity")]
        public int IdEditorial { get; set; }

        public EditorialEntity EditorialEntity { get; set; }

        public AuthorbooksEntity AuthorbooksEntity { get; set; }

        [ForeignKey("TypeStateEntity")]
        public int IdTypeState { get; set; }

        public TypeStateEntity TypeStateEntity { get; set; }

    }
}
