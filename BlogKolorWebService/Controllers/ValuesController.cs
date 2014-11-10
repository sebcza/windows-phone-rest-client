﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BlogKolorWebService.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public string Post([FromBody]string value)
        {
            return "Czesc " + value;
        }

        // PUT api/values/5
        public string Put(int id, [FromBody]string value)
        {
            return "Zmieniem dane dla rekordu:" + id + " Nowa tresc to:" + value;
        }

        // DELETE api/values/5
        public string Delete(int id)
        {
            return "Usunąlem rekord o id:" + id;
        }
    }
}
