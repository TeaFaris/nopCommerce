using Nop.Services.Customers;
using Nop.Services.Localization;
using Nop.Services.Security;
using Nop.Web.Areas.Admin.Models.Security;

namespace Nop.Web.Areas.Admin.Factories;

/// <summary>
/// Represents the security model factory implementation
/// </summary>
public partial class SecurityModelFactory : ISecurityModelFactory
{
    #region Fields

    protected readonly ICustomerService _customerService;
    protected readonly ILocalizationService _localizationService;
    protected readonly IPermissionService _permissionService;
    protected readonly IPermissionManager _permissionManager;

    #endregion

    #region Ctor

    public SecurityModelFactory(ICustomerService customerService,
        ILocalizationService localizationService,
        IPermissionService permissionService,
        IPermissionManager permissionManager)
    {
        _customerService = customerService;
        _localizationService = localizationService;
        _permissionService = permissionService;
        _permissionManager = permissionManager;
    }

    #endregion

    #region Methods

    /// <summary>
    /// Prepare permission configuration model
    /// </summary>
    /// <param name="model">Permission configuration model</param>
    /// <returns>
    /// A task that represents the asynchronous operation
    /// The task result contains the permission configuration model
    /// </returns>
    public virtual async Task<PermissionConfigurationModel> PreparePermissionConfigurationModelAsync(PermissionConfigurationModel model)
    {
        ArgumentNullException.ThrowIfNull(model);

        var customerRoles = await _customerService.GetAllCustomerRolesAsync(true);
        model.AreCustomerRolesAvailable = customerRoles.Any();
        var permissionRecords = await _permissionManager.GetAllPermissionRecordsAsync();
        model.IsPermissionsAvailable = permissionRecords.Any();

        return model;
    }

    #endregion
}