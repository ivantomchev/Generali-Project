namespace Project.Data.UnitOfWork
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Project.Data;
    using Project.Data.Common.Repository;
    using Project.Data.Models;


    public interface IProjectData
    {
        IApplicationDbContext Context { get; }

        IRepository<NavigationItem> NavigationItems { get; }

        int SaveChanges();
    }
}
