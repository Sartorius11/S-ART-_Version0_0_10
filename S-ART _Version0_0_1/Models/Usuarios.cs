using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace S_ART__Version0_0_1.Models
{
    [Table("USERS")]
    public class Usuario
    {
        [Key]
        [Column("IDUSUARIO")]
        public int IdUsuario { get; set; }


        [Column("NOMBRE")]
        public string? Nombre { get; set; } 


        [Column("EMAIL")]
        public string? Email { get; set; }


        [Column("SALT")]
        public string? Salt { get; set; }

        //LOS TIPOS VARBINARY, CLOB, BLOB, SON CONVERTIDOS AUTOMATICAMENTE A BYTE[] POR EF
        [Column("PASS")]
        public byte[] Password { get; set; }


        [Column("PAIS")]
        public string? Pais { get; set; }

        [Column("ARTISTA_FAV")]
        public string? Artista_fav { get; set; }


    }
}
