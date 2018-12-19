using System;
using System.Collections.Generic;
using System.Linq;
using EntityFrameworkCore.Sharp.Sample.Models;

namespace EntityFrameworkCore.Sharp.Sample.Repos
{
    public class HostRepo
    {
        private readonly MyDbContext context;

        public HostRepo(MyDbContext context)
        {
            this.context = context;
        }
         

        public void Add(Host host)
        {
            context.Hosts.Add(host);
            context.SaveChanges();
        }

        public List<Host> All()
        {
            return context.Hosts.ToList();
        }
    }
}
