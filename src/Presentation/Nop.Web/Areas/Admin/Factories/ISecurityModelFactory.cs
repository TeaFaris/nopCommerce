using Nop.Web.Areas.Admin.Models.Security;

namespace Nop.Web.Areas.Admin.Factories;

/// <summary>
/// Represents the security model factory
/// </summary>
public partial interface ISecurityModelFactory
{
    /// <summary>
    /// Prepare permission configuration model
    /// </summary>
    /// <param name="model">Permission configuration model</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the permission configuration model
    /// </returns>
    Task<PermissionConfigurationModel> PreparePermissionConfigurationModelAsync(PermissionConfigurationModel model);
}