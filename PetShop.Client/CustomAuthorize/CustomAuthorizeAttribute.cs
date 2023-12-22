using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PetShop.Models.Entities.Users;
using System.Security.Claims;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
public class CustomAuthorizeAttribute : Attribute
{
    public string[] Roles { get; }

    public CustomAuthorizeAttribute(params string[] roles)
    {
        Roles = roles;
    }
}
 







