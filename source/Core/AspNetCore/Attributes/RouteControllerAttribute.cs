using Microsoft.AspNetCore.Mvc;
using System;

namespace Solution.Core.AspNetCore
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class RouteControllerAttribute : RouteAttribute
    {
        public RouteControllerAttribute() : base("[controller]")
        {
        }
    }
}
