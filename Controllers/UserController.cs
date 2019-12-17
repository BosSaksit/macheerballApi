using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using macheerballApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace macheerballApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class UserController : ControllerBase
    {
        public static List<User> DataUser = new List<User>
        {
            new User { nameUser = "1", telUser = "admin1" },
            new User { nameUser = "1", telUser = "admin1" },
            new User { nameUser = "1", telUser = "admin1" }
        };

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUserAll()
        {
            return DataUser.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUserById(string id)
        {
            return DataUser.FirstOrDefault(it => it.nameUser == id.ToString());
        }

        [HttpPost]
        public User AddUser([FromBody] User Userx)
        {
            var id = Guid.NewGuid().ToString();
            var item = new User
            {
                nameUser = id,
                 telUser = Userx.telUser
                
            };

            DataUser.Add(item);
            return item;
        }

        [HttpPut("{id}")]
        public User EditUser(string id, [FromBody] User Userx)
        {
            var _id = DataUser.FirstOrDefault(it => it.nameUser == id.ToString());
            var item = new User
            {
                nameUser = id,
                 telUser = Userx.telUser
               
            };
            DataUser.Remove(_id);
            DataUser.Add(item);
            return item;

        }

        [HttpDelete("{id}")]
        public void DeleteUser(string id)
        {
            var delete = DataUser.FirstOrDefault(it => it.nameUser == id.ToString());
            DataUser.Remove(delete);
        }


    }

}