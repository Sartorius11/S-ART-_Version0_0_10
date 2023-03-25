using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using S_ART__Version0_0_1.Data;
using S_ART__Version0_0_1.Models;
using static System.Net.Mime.MediaTypeNames;
using System.Collections.Generic;

namespace S_ART__Version0_0_1.Repositories
{
    #region Procedure

        /*    create procedure sp_subirImagen
            (@idUsuario int , @titulo Nvarchar(50), @imagen nvarchar(100))
        as
        declare @idImagen int
        select @idImagen= ISNULL(Max (id_imagen),0)+1 FROM GALERIA
        insert into GALERIA values(@idImagen, @idUsuario, @titulo, @imagen)
        go*/
    #endregion
    public class RepositoryFormularios
    {
        private UsuariosContext context;
        public RepositoryFormularios(UsuariosContext context)
        {
            this.context = context;
        }

        public async Task FomularioUsuario(string nombre, string correo, string artistaFav, string pais)
        {
            Usuario usuario = new Usuario();
            usuario.Nombre = nombre;
            usuario.Email = correo;
            usuario.Artista_fav = artistaFav;
            usuario.Pais = pais;
        }



     
        public async Task subirFichero(string imagen, string nombre, int idUsuario)
        {
            string sql = "sp_subirImagen @idUsuario,@titulo,@imagen";

            SqlParameter pamfichero = new SqlParameter("@imagen", imagen);
            SqlParameter pamIdUsuario = new SqlParameter("@idUsuario", idUsuario);
            SqlParameter pamnombre = new SqlParameter("@titulo", nombre);
            await this.context.Database.ExecuteSqlRawAsync(sql,pamfichero,pamIdUsuario,pamnombre);
        }
           


    }
}
