using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace S_ART__Version0_0_1.Models
{
        [Table("GALERIA")]
        public class Galeria
        {
            [Key]
            [Column("ID_IMAGEN")]
            public int id_Imagen { get; set; }


            [Column("ID_USUARIO")]
            public int id_usuario { get; set; }


            [Column("TITULO_OBRA")]
            public string Titulo_obra { get; set; }


            [Column("RUTA")]
            public string Ruta { get; set; }

            

        }
    
}
