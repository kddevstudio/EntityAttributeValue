using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ODataApiController : ODataController
    {
        private EAVContext db;

        public ODataApiController(EAVContext context) {
            db = context;
        }

        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(db.Attributes);
        }

        [EnableQuery]
        public IActionResult Get(int key)
        {
            return Ok(db.Attributes.FirstOrDefault(c => c.AttributeId == key));
        }
    }
}