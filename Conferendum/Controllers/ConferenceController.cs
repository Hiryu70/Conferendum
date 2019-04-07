using Conferendum.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Conferendum.Controllers
{
    [Produces("application/json")]
    public class ConferenceController : Controller
    {
        [Route("api/conference/info")]
        public IActionResult Get()
        {
            var sections = new List<SectionEntry>
            {
                GetSection1(),
                GetSection2()
            };

            return Ok(sections);
        }

        [Route("api/conference/{section}/info")]
        public IActionResult Get(string section)
        {
            if (section == "GIS")
            {
                var sectinInfo = GetSection1().Info;
                return Ok(sectinInfo);
            }
            
            if (section == "CS")
            {
                var sectinInfo = GetSection2().Info;
                return Ok(sectinInfo);
            }

            return NotFound($"I never hear about {section} before."); 
        }

        private SectionEntry GetSection1()
        {
            var section1 = new SectionEntry
            {
                Section = "GIS",
                Info = new Info
                {
                    City = "Tomsk",
                    Name = "Geoinformation Systems",
                    Location = "Lenina 2, 404"
                }
            };

            return section1;
        }

        private SectionEntry GetSection2()
        {
            var section2 = new SectionEntry
            {
                Section = "CS",
                Info = new Info
                {
                    City = "Tomsk",
                    Name = "Computer Science",
                    Location = "Lenina 30, 206"
                }
            };

            return section2;
        }
    }
}