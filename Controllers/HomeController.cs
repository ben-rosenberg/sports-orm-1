using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsORM.Models;


namespace SportsORM.Controllers
{
    public class HomeController : Controller
    {

        private static Context _context;

        public HomeController(Context DBContext)
        {
            _context = DBContext;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.BaseballLeagues = _context.Leagues
                .Where(l => l.Sport.Contains("Baseball"))
                .ToList();
            return View();
        }

        [HttpGet("level_1")]
        public IActionResult Level1()
        {
            ViewBag.WomensLeagues = _context.Leagues
                .Where(league => league.Name.Contains("Womens"))
                .ToList();

            ViewBag.AllHockeyLeagues = _context.Leagues
                .Where(league => league.Sport.Contains("Hockey"))
                .ToList();
            
            ViewBag.NonFootballLeagues = _context.Leagues
                .Where(league => !league.Sport.Contains("Football"))
                .ToList();

            ViewBag.Conferences = _context.Leagues
                .Where(league => league.Name.Contains("Conference"))
                .ToList();

            ViewBag.AtlanticLeagues = _context.Leagues
                .Where(league => league.Name.Contains("Atlantic"))
                .ToList();

            ViewBag.DallasTeams = _context.Teams
                .Where(team => team.Location == "Dallas")
                .ToList();
            
            ViewBag.RaptorsTeams = _context.Teams
                .Where(team => team.TeamName == "Raptors")
                .ToList();
            
            ViewBag.CityTeams = _context.Teams
                .Where(team => team.Location.Contains("City"))
                .ToList();
            
           ViewBag.TeamsStartingWithT = _context.Teams
                .Where(team => team.TeamName.StartsWith("T"))
                .ToList();

            ViewBag.AllTeamsSortedByLocation = _context.Teams
                .OrderBy(team => team.Location)
                .ToList();

            ViewBag.AllTeamsDescendingAlphabetically = _context.Teams
                .OrderByDescending(team => team.TeamName)
                .ToList();
            
            ViewBag.LastNameCooper = _context.Players
                .Where(player => player.LastName == "Cooper")
                .ToList();

            ViewBag.FirstNameJoshua = _context.Players
                .Where(player => player.FirstName == "Joshua")
                .ToList();

            ViewBag.LastNameCooperNotFirstNameJoshua = _context.Players
                .Where(player => player.LastName == "Cooper" && player.FirstName != "Joshua")
                .ToList();
            
            ViewBag.FirstNameAlexanderOrWyatt = _context.Players
                .Where(player => player.FirstName == "Alexander" || player.FirstName != "Wyatt")
                .ToList();

            return View();
        }

        /* WHY DOES THIS NOT WORK */
        [HttpGet("level_2")]
        public IActionResult Level2()
        {
            /* ViewBag.AtlanticSoccerConferenceTeams = _context.Leagues
                .Join(_context.Teams, 
                league => league.LeagueId,
                team => team.LeagueId,
                (league, team) => new { league, team })
                .Where(leagueAndTeam => leagueAndTeam.league.Name == "Atlantic Soccer Conference")
                .ToList();
            */
            return View(); 
        }

        [HttpGet("level_3")]
        public IActionResult Level3()
        {
            return View();
        }

    }
}