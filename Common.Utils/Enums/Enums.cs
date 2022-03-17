using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Utils.Enums
{
    public class Enums
    {
        public enum TypeState
        {
            //Usuario
            Vendido = 1,
            Alquilado = 2,
            Encargado = 3,
            Reparando = 4,

        }
        public enum TypePermission
        {
            Usuario = 1,
            Roles = 2,
            Permisos = 3,
            Libros = 4,
            Editoriales = 5,
            Autores = 6,
            Estados = 7
        }
        public enum Permission
        {
            //Usuarios
            CrearUsuarios = 1,
            ActualizarUsuarios = 2,
            EliminarUsuarios = 3,
            ConsultarUsuarios = 4,

            //Roles
            ActualizarRoles = 5,
            ConsultarRoles = 6,

            //Permisos
            ActualizarPermisos = 7,
            ConsultarPermisos = 8,
            DenegarPermisos = 9,

            //Estados
            ConsultarEstados = 10,
            ActualizarEstados = 11,

            //Libros
            CrearLibros = 12,
            ActualizarLibros = 13,
            EliminarLibros = 14,
            ConsultarLibros = 15,

            //Editorial
            CrearEditoriales = 16,
            ActualizarEditoriales = 17,
            EliminarEditoriales = 18,
            ConsultarEditoriales = 19,

            //Autores
            CrearAutores = 20,
            ActualizarAutores = 21,
            EliminarAutores = 22,
            ConsultarAutores = 23
        }

        public enum RolUser
        {
            Administrador = 1,
            Estandar = 2
        }
    }
}
