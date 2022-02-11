using FullSD_Project.Shared.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FullSD_Project.Server.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        Task Save(HttpContext httpContext);
        IGenericRepository<State> States { get; }
        IGenericRepository<Tool> Tools { get; }
        IGenericRepository<Brand> Brands { get; }
        IGenericRepository<Booking> Bookings { get; }
        IGenericRepository<Member> Members { get; }
    }
}