using Infraestructure.Core.Repository.Interface;
using Infraestructure.Entity.Models.Library;
using Infraestructure.Entity.Models.Master;
using Infraestructure.Entity.Models.Security;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Core.UnitOfWork.Interface
{
    public interface IUnitOfWork
    {
        IRepository<UserEntity> UserRepository { get; }

        IRepository<RolEntity> RolRepository { get; }

        IRepository<RolUserEntity> RolUserRepository { get; }

        IRepository<TypeStateEntity> TypeStateRepository { get; }

        IRepository<PermissionEntity> PermissionRepository { get; }

        IRepository<TypePermissionEntity> TypePermissionRepository { get; }

        IRepository<RolPermissionEntity> RolesPermissionRepository { get; }

        IRepository<BooksEntity> BooksRepository { get; }
        IRepository<EditorialEntity> EditorialRepository { get; }
        IRepository<AuthorsEntity> AuthorsRepository { get; }
        IRepository<AuthorbooksEntity> AuthorbooksRepository { get; }












        new void Dispose();

        Task<int> Save();
    }
}
