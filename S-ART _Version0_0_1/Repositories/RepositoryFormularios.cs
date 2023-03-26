using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using S_ART__Version0_0_1.Data;
using S_ART__Version0_0_1.Models;
using static System.Net.Mime.MediaTypeNames;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Runtime.ConstrainedExecution;
using System.Diagnostics.Metrics;

namespace S_ART__Version0_0_1.Repositories
{
    #region Procedure SP_SUBIR_IMAGEN

    /*    create procedure sp_subirImagen
        (@idUsuario int , @titulo Nvarchar(50), @imagen nvarchar(100))
    as
    declare @idImagen int
    select @idImagen= ISNULL(Max (id_imagen),0)+1 FROM GALERIA
    insert into GALERIA values(@idImagen, @idUsuario, @titulo, @imagen)
    go*/
    #endregion


    #region Procedure SP_GUARDAR_INFO

        /*    alter procedure SP_GUARDAR_INFO
        (@IDUSUARIO INT, @NOMBRE NVARCHAR(50),@EMAIL NVARCHAR(50),@PAIS VARCHAR(50), @ARTISTA_FAV VARCHAR(50))
        AS

        UPDATE users SET nombre=@NOMBRE, email=@EMAIL, PAIS=@PAIS, artista_fav=@ARTISTA_FAV
        WHERE idUsuario =@IDUSUARIO
        GO
        */
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
            await this.context.SaveChangesAsync();
        }



     
        public async Task subirFichero(string imagen, string nombre, int idUsuario)
        {
            string sql = "sp_subirImagen @idUsuario,@titulo,@imagen";

            SqlParameter pamfichero = new SqlParameter("@imagen", imagen);
            SqlParameter pamIdUsuario = new SqlParameter("@idUsuario", idUsuario);
            SqlParameter pamnombre = new SqlParameter("@titulo", nombre);
            await this.context.Database.ExecuteSqlRawAsync(sql,pamfichero,pamIdUsuario,pamnombre);
        }

       
        public async Task<List<Galeria>> GetImagenes()
        {
            return await this.context.galerias.ToListAsync();
        }
		public async Task<Galeria> GetDetallesImagenes(int id_Imagen)
		{

			return await this.context.galerias.Where(x => x.id_Imagen==id_Imagen).FirstOrDefaultAsync();
		}

	}
}
