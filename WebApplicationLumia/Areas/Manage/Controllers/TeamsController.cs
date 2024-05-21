using Microsoft.AspNetCore.Mvc;
using WebApplicationLumia.DAL;
using WebApplicationLumia.Models;
using WebApplicationLumia.ViewModel;

namespace WebApplicationLumia.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class TeamsController : Controller
    {
       
        AppDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public TeamsController(AppDbContext context,IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public IActionResult Index()
        {
            var teams=_context.Teams.ToList();
            return View(teams);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateTeamsVm teamsVm)
        {
            if(!teamsVm.ImgFile.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("ImgFile", "Sekil elave edile bilmedi");

            }

            string path =_environment.WebRootPath+ @"\Upload\";
            string filename = Guid.NewGuid() + teamsVm.ImgFile.FileName;


            using (FileStream stream = new FileStream(path + filename, FileMode.Create))
            {
               teamsVm.ImgFile.CopyTo(stream);
            }

            if (!ModelState.IsValid)
            {
                return View();
            }
            Teams team = new Teams()
            {
                Name = teamsVm.Name,
                Description = teamsVm.Description,
                Position = teamsVm.Position,
                ImgUrl = filename,

            };
            _context.Teams.Add(team);
            _context.SaveChanges();
            



            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var team = _context.Teams.FirstOrDefault(x => x.Id == id);

            if (team != null)
            {
                string path = _environment.WebRootPath + @"\Upload\" + team.ImgUrl;
                FileInfo fileInfo = new FileInfo(path);
                if (fileInfo.Exists)
                {
                    fileInfo.Delete();
                }
                _context.Teams.Remove(team);
                _context.SaveChanges();
                return Ok();
            }
            return BadRequest();

        }
        public IActionResult Update(int id)
        {
            Teams team = _context.Teams.FirstOrDefault(x => x.Id == id);
            UpdateTeamsVm teamsVm = new UpdateTeamsVm()
            {
                Id=team.Id,
                Name = team.Name,
                Description = team.Description,
                Position = team.Position,
                ImgUrl = team.ImgUrl,
            };
            if(team == null)
            {
                return RedirectToAction("Index");
            }
            return View(teamsVm);

        }
        [HttpPost]
        public IActionResult Update(UpdateTeamsVm teamsVm)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }

            var oldteam=_context.Teams.FirstOrDefault(x=>x.Id==teamsVm.Id);
            if (oldteam != null) { return RedirectToAction("Index"); }
            {

                oldteam.Name=teamsVm.Name;
                oldteam.Description=teamsVm.Description;
                oldteam.Position=teamsVm.Position;
                oldteam.ImgUrl=teamsVm.ImgUrl;
                
                _context.SaveChanges();
                return RedirectToAction("Index");

            }

        }


    }
}
