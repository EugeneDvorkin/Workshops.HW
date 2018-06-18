using System.Collections.Generic;
using Rocket.BL.Common.Models.UserRoles;

namespace Rocket.BL.Common.Services
{
    public interface IPermissionService
    {
        /// <summary>
        /// Добавить существующую функц возможность для выбранной роли
        /// </summary>
        /// <param name="idRole"> ID role </param>
        /// <param name="idPermission"> ID permission </param>
        void AddPermissionToRole(string idRole, int idPermission);

        /// <summary>
        /// Удалить функц возможность из текущего списка у роли
        /// </summary>
        /// <param name="idRole"> ID role </param>
        /// <param name="idPermission"> ID permission </param>
        void RemovePermissionFromRole(string idRole, int idPermission);

        /// <summary>
        /// Gets the permission by yser.
        /// </summary>
        /// <param name="idRole">The identifier role.</param>
        IEnumerable<Permission> GetPermissionByYser(string idRole);

        /// <summary>
        /// Gets all permissions.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Permission> GetAllPermissions();
    }
}