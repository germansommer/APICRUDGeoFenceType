using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ApiCrudGFType.Models;

namespace ApiCrudGFType.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GeofenceTypeController : ControllerBase
    {
        [HttpGet]

        public List<GeofenceType> Get()
        {
            return GeofenceType.GetAll();
        }

        [HttpPost]
        public void Post(int id, string name, string colour, int enterpriseid, string active)
        {
            GeofenceType.PostGFT(id, name, colour, enterpriseid, active);
        }

        [HttpPatch]
        public void Patch(int id, string name, string colour, int enterpriseid, string active)
        {
            GeofenceType.UpdateGFT(id, name, colour, enterpriseid, active);
        }

        [HttpDelete]
        public void Delete (int id)
        {
            GeofenceType.DeleteGFT(id);
        }
    }
}