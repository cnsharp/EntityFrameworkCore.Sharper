using System;
using System.Collections.Generic;
using EntityFrameworkCore.Sharp.Sample.Models;
using EntityFrameworkCore.Sharp.Sample.Repos;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkCore.Sharp.Sample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HostController : ControllerBase
    {
        private readonly HostRepo repo;

        public HostController(HostRepo repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Host>> Index()
        {
            var count = repo.All().Count;
            count++;
            var host = new Host { Id = Guid.NewGuid(), Name = "host" + count, Url = count + ".demo.com" };
            repo.Add(host);
            return repo.All();
        }

        [HttpPost]
        public ActionResult<Host> New()
        {
            var count = repo.All().Count;
            count++;
            var host = new Host { Id = Guid.NewGuid(), Name = "host" + count, Url = count + ".demo.com" };
            repo.Add(host);
            return host;
        }
    }
}
