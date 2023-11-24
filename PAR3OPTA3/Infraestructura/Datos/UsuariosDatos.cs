using System;
using System.Data;
using Infraestructura.Conexiones;
using Infraestructura.Modelos;

namespace Infraestructura.Datos
{
    public class UsuarioDatos
    {
        //CRUD USUARIOS  

        public static void insertarusuario(UsuarioModel usuario)
        {
          
            var comando = new Npgsql.NpgsqlCommand("INSERT INTO usuario(idusuario, IDPersona, nombre_usuario, contraseña, Nivel, estado)" +
                                                "VALUES(@idusuario, @IdPersona, @nombre_usuario, @contraseña, @nivel, @estado)");
            comando.Parameters.AddWithValue("IDPersona", usuario.IDPersona);
            comando.Parameters.AddWithValue("nombre_usuario", usuario.nombre_usuario);
            comando.Parameters.AddWithValue("estado", usuario.estado);
            comando.Parameters.AddWithValue("idusuario", usuario.idusuario);
            comando.Parameters.AddWithValue("contraseña", usuario.estado);
            comando.Parameters.AddWithValue("nivel", usuario.idusuario);
            comando.ExecuteNonQuery();
        }

        public UsuarioModel obtenerusuarioPorId(int id)
        {
            
            var comando = new Npgsql.NpgsqlCommand($"Select * from usuario where idusuario = {id}");
            using var reader = comando.ExecuteReader();
            if (reader.Read())
            {
                return new UsuarioModel
                {
                    idusuario = reader.GetInt32("idusuario"),
                    contraseña = reader.GetString("contraseña"),
                    nombre_usuario = reader.GetString("nombre_usuario"),
                    nivel = reader.GetString("nivel"),
                    IDPersona = reader.GetString("idPersona"),
                    estado = reader.GetString("estado")
                };
            }
            return null;
        }

        public void Modificarusuario(UsuarioModel usuario)
        {
            
            var comando = new Npgsql.NpgsqlCommand($"UPDATE usuario SET contraseña = '{usuario.contraseña}', " +
                                                          $"nombre_usuario = '{usuario.nombre_usuario}', " +
                                                          $"estado = '{usuario.estado}' " +
                                                          $"nivel = '{usuario.nivel}' " +
                                                          $"IdPersona = '{usuario.IDPersona}' " +
                                                $" WHERE idusuario = {usuario.idusuario}");

            comando.ExecuteNonQuery();
        }
    }
}
