namespace Similarity1.Entitiy
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HOMEWORK
    {
        public int ID { get; set; }

        [Required]
        [StringLength(250)]
        public string TITLE { get; set; }

        [Required]
        public string CONTEXT { get; set; }

        public decimal SIMILARTYRATE { get; set; }

        public bool ISSCAN { get; set; }

        public int USERID { get; set; }
    }
}
