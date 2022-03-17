using Common.Utils.Enums;
using Infraestructure.Entity.Models.Master;
using Infraestructure.Entity.Models.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Core.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        #region Builder
        public SeedDb(DataContext context)
        {
            _context = context;
        }
        #endregion

        public async Task ExecSeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckTypeStateAsync();

            await CheckTypePermissionAsync();
            await CheckPermissionAsync();
            await CheckRolAsync();
            await CheckRolPermissonAsync();

        }
        private async Task CheckTypeStateAsync()
        {
            if (!_context.TypeStateEntity.Any())
            {
                _context.TypeStateEntity.AddRange(new List<TypeStateEntity>
                {
                    new TypeStateEntity
                    {
                        IdTypeState=(int)Enums.TypeState.Vendido,
                        TypeState="Vendido"
                    },
                    new TypeStateEntity
                    {
                        IdTypeState=(int)Enums.TypeState.Alquilado,
                        TypeState ="Alquilado"
                    },
                    new TypeStateEntity
                    {
                        IdTypeState=(int)Enums.TypeState.Encargado,
                        TypeState ="Encargado"
                    },new TypeStateEntity
                    {
                        IdTypeState=(int)Enums.TypeState.Reparando,
                        TypeState ="Reparando"
                    }
                });
                await _context.SaveChangesAsync();
            }
        }
        private async Task CheckTypePermissionAsync()
        {
            if (!_context.TypePermissionEntity.Any())
            {
                _context.TypePermissionEntity.AddRange(new List<TypePermissionEntity>
                {
                      new TypePermissionEntity
                      {
                        IdTypePermission=(int)Enums.TypePermission.Usuarios,
                        TypePermission="Usuarios"

                      },
                       new TypePermissionEntity
                       {
                        IdTypePermission=(int)Enums.TypePermission.Roles,
                        TypePermission="Roles"

                       },
                      new TypePermissionEntity
                      {
                        IdTypePermission=(int)Enums.TypePermission.Permisos,
                        TypePermission="Permisos"

                      },
                      new TypePermissionEntity
                      {
                        IdTypePermission=(int)Enums.TypePermission.Biblioteca,
                        TypePermission="Biblioteca"

                      },
                      new TypePermissionEntity
                      {
                        IdTypePermission=(int)Enums.TypePermission.Autor,
                        TypePermission="AutorS"

                      },
                });
                await _context.SaveChangesAsync();
            }
        }
        private async Task CheckPermissionAsync()
        {
            if (!_context.PermissionEntity.Any())
            {
                _context.PermissionEntity.AddRange(new List<PermissionEntity>
                {
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.CrearUsuarios,
                        IdTypePermission=(int)Enums.TypePermission.Usuarios,
                        Permission="Crear Usuarios",
                        Description="Crear usuarios en el sistema"
                    },
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.ActualizarUsuarios,
                        IdTypePermission=(int)Enums.TypePermission.Usuarios,
                        Permission="Actualizar Usuarios",
                        Description="Actualizar datos de un usuario en el sistema"
                    },
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.EliminarUsuarios,
                        IdTypePermission=(int)Enums.TypePermission.Usuarios,
                        Permission="Eliminar Usuarios",
                        Description="Eliminar un usuairo del sistema"
                    },
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.ConsultarUsuarios,
                        IdTypePermission=(int)Enums.TypePermission.Usuarios,
                        Permission="Consultar Usuarios",
                        Description="Consulta todos los usuarios"
                    },
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.ActualizarRoles,
                        IdTypePermission=(int)Enums.TypePermission.Roles,
                        Permission="Actualizar Roles",
                        Description="Actualizar datos de un Roles en el sistema"
                    },
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.ConsultarRoles,
                        IdTypePermission=(int)Enums.TypePermission.Roles,
                        Permission="Consultar Roles",
                        Description="Consultar Roles del sistema"
                    },
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.ActualizarPermisos,
                        IdTypePermission=(int)Enums.TypePermission.Permisos,
                        Permission="Actualizar Permisos",
                        Description="Actualizar datos de un Permiso en el sistema"
                    },
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.ConsultarPermisos,
                        IdTypePermission=(int)Enums.TypePermission.Permisos,
                        Permission="Consultar Permisos",
                        Description="Consultar Permisos del sistema"
                    },
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.DenegarPermisos,
                        IdTypePermission=(int)Enums.TypePermission.Permisos,
                        Permission="Denegar Permisos Rol",
                        Description="Denegar permisos a un rol del sistema"
                    },
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.InsertarNuevoLibro,
                        IdTypePermission=(int)Enums.TypePermission.Biblioteca,
                        Permission="Insertar Libro",
                        Description="Insertar nuevo libro en el sistema"
                    },
                     new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.ActualizarDatosLibro,
                        IdTypePermission=(int)Enums.TypePermission.Biblioteca,
                        Permission="Actualizar Libro",
                        Description="Actualizar Datos de un Libro en el Sistema"
                    },
                     new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.EliminarLibro,
                        IdTypePermission=(int)Enums.TypePermission.Biblioteca,
                        Permission="Eliminar Libro",
                        Description="Eliminar libro del sistema"
                    },
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.ConsultarLibros,
                        IdTypePermission=(int)Enums.TypePermission.Biblioteca,
                        Permission="Consultar libros",
                        Description="Consultar todos los libros del sistema"
                    },
                     new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.BuscarLibro,
                        IdTypePermission=(int)Enums.TypePermission.Biblioteca,
                        Permission="Buscar Libro",
                        Description="Buscar un libro del sistema"
                    }, 
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.ActualizarEditorial,
                        IdTypePermission=(int)Enums.TypePermission.Biblioteca,
                        Permission="Actualizar Editorial",
                        Description="Actualizar editorial en el sistema"
                    },
                     new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.InsertarEditorial,
                        IdTypePermission=(int)Enums.TypePermission.Biblioteca,
                        Permission="Insertar Editorial",
                        Description="Insertar Editorial en el  sistema"
                    },
                      new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.EliminarEditorial,
                        IdTypePermission=(int)Enums.TypePermission.Biblioteca,
                        Permission="Eliminar Editorial",
                        Description="Eliminiar Editorial del Sistema"
                    }, 
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.ConsultarEditoriales,
                        IdTypePermission=(int)Enums.TypePermission.Biblioteca,
                        Permission="Consultar Editoriales",
                        Description="Consultar Editoriales del Sistema"
                    },
                     new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.ConsultarEdtadoLibro,
                        IdTypePermission=(int)Enums.TypePermission.Biblioteca,
                        Permission="Consultar Estado de libros",
                        Description="Consultar Estado de los libros del sistema"
                    },
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.InsertarAutor,
                        IdTypePermission=(int)Enums.TypePermission.Autor,
                        Permission="Insertar Autor",
                        Description="Insertar Autor de un libro del sistema"
                    },
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.ConsultarAutores,
                        IdTypePermission=(int)Enums.TypePermission.Autor,
                        Permission="Consultar Autor",
                        Description="Consultar Autor de un libro del sistema"
                    },
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.ActualizarDatosAutor,
                        IdTypePermission=(int)Enums.TypePermission.Autor,
                        Permission="Actualizar Autor",
                        Description="Actualizar datos de un Autor de un libro del sistema"
                    },
                    new PermissionEntity
                    {
                        IdPermission=(int)Enums.Permission.EliminarAutor,
                        IdTypePermission=(int)Enums.TypePermission.Autor,
                        Permission="Eliminar Autor",
                        Description="Eliminar Autor de un libro del sistema"
                    },

                });

                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckRolAsync()
        {
            if (!_context.RolEntity.Any())
            {
                _context.RolEntity.AddRange(new List<RolEntity>
                {
                    new RolEntity
                    {
                        IdRol=(int)Enums.RolUser.Administrador,
                        Rol="Administrador"
                    },
                     new RolEntity
                    {
                        IdRol=(int)Enums.RolUser.Estandar,
                        Rol="Estandar"
                    }
                });

                await _context.SaveChangesAsync();
            }
        }
        private async Task CheckRolPermissonAsync()
        {
            if (!_context.RolPermissionEntity.Where(x => x.IdRol == (int)Enums.RolUser.Administrador).Any())
            {
                var rolesPermisosAdmin = _context.PermissionEntity.Select(x => new RolPermissionEntity
                {
                    IdRol = (int)Enums.RolUser.Administrador,
                    IdPermission = x.IdPermission
                }).ToList();

                _context.RolPermissionEntity.AddRange(rolesPermisosAdmin);


                await _context.SaveChangesAsync();
            }
        }
    }
}
