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

    public class PollController : ControllerBase
    {
        public static List<Poll> DataPoll = new List<Poll>
        {
            new Poll { pollId = "1", homeTeamName = "admin1" , awayTeamName =  "1234", dateBall = DateTime.Now ,timeBall = "0165466516" , timeBallpoll = "Admin" ,scoreBall = "15/8 ขอนแก่น",voteHomeTeam = "sdf", voteAwayTeam = "dfg", pollStatus = "",luckyName = "dfgdfg" ,luckyTel = "dfgdfg",},
            new Poll { pollId = "1", homeTeamName = "admin1" , awayTeamName =  "1234", dateBall = DateTime.Now ,timeBall = "0165466516" , timeBallpoll = "Admin" ,scoreBall = "15/8 ขอนแก่น",voteHomeTeam = "sdf", voteAwayTeam = "dfg", pollStatus = "",luckyName = "dfgdfg" ,luckyTel = "dfgdfg",},
            new Poll { pollId = "1", homeTeamName = "admin1" , awayTeamName =  "1234", dateBall = DateTime.Now ,timeBall = "0165466516" , timeBallpoll = "Admin" ,scoreBall = "15/8 ขอนแก่น",voteHomeTeam = "sdf", voteAwayTeam = "dfg", pollStatus = "",luckyName = "dfgdfg" ,luckyTel = "dfgdfg",}
  };

        [HttpGet]
        public ActionResult<IEnumerable<Poll>> GetPollAll()
        {
            return DataPoll.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Poll> GetPollById(string id)
        {
            return DataPoll.FirstOrDefault(it => it.pollId == id.ToString());
        }

        [HttpPost]
        public Poll AddPoll([FromBody] Poll Pollx)
        {
            var id = Guid.NewGuid().ToString();
            var item = new Poll
            {
                 pollId = id,
                homeTeamName = Pollx.homeTeamName,
                awayTeamName = Pollx.awayTeamName,
                dateBall = Pollx.dateBall,
                timeBall = Pollx.timeBall,
                timeBallpoll = Pollx.timeBallpoll,
                scoreBall = Pollx.scoreBall,
                voteHomeTeam = Pollx.voteHomeTeam,
                voteAwayTeam = Pollx.voteAwayTeam,
                pollStatus = Pollx.pollStatus,
                luckyName = Pollx.luckyName,
                luckyTel = Pollx.luckyTel
                


            };

            DataPoll.Add(item);
            return item;
        }

        [HttpPut("{id}")]
        public Poll EditPoll(string id, [FromBody] Poll Pollx)
        {
            var _id = DataPoll.FirstOrDefault(it => it.pollId == id.ToString());
            var item = new Poll
            {
                 pollId = id,
                homeTeamName = Pollx.homeTeamName,
                awayTeamName = Pollx.awayTeamName,
                dateBall = Pollx.dateBall,
                timeBall = Pollx.timeBall,
                timeBallpoll = Pollx.timeBallpoll,
                scoreBall = Pollx.scoreBall,
                voteHomeTeam = Pollx.voteHomeTeam,
                voteAwayTeam = Pollx.voteAwayTeam,
                pollStatus = Pollx.pollStatus,
                luckyName = Pollx.luckyName,
                luckyTel = Pollx.luckyTel
            };
            DataPoll.Remove(_id);
            DataPoll.Add(item);
            return item;

        }

        [HttpDelete("{id}")]
        public void DeletePoll(string id)
        {
            var delete = DataPoll.FirstOrDefault(it => it.pollId == id.ToString());
            DataPoll.Remove(delete);
        }


    }

}