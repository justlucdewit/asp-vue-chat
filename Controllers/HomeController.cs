using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using vue_test3.Models;
using helpers;

namespace vue_test3.Controllers
{
    public class HomeController : Controller
    {
        public static RandomManager manager = new RandomManager();
        public static Dictionary<string, List<Message>> messages = new Dictionary<string, List<Message>>();

        public static bool FirstTime = true;
        /*private readonly ILogger<HomeController> _logger;*/

        public HomeController(/*ILogger<HomeController> logger*/)
        {
            /*_logger = logger;*/
            if (FirstTime){
                FirstTime = false;
                LoadHistToDrive();
                manager.AddJob(20, DumpHistToDrive, "saving history to disk");
            }
        }

        // ---- TASKS ----
        public void DumpHistToDrive()
        {
            string output = "";
            foreach (KeyValuePair<string, List<Message>> entry in messages){
                string server = entry.Key;
                foreach(Message m in entry.Value){
                    output += $"{m.message}♦{m.author}♦{m.server}♦{m.color}♦{m.date}\n";
                }
            }
                
            System.IO.File.WriteAllText("./messages.data", output);
        }

        public void LoadHistToDrive(){
            if (System.IO.File.Exists("./messages.data")) {
                string history = System.IO.File.ReadAllText("./messages.data");
                history = history.Replace('\n', '♦');
                string[] parts = history.Split("♦");

                for (int i = 0; i < parts.Length - 1; i += 5){
                    var m = new Message();
                    m.message = parts[i];
                    m.author = parts[i+1];
                    m.server = parts[i+2];
                    m.color = Convert.ToUInt16(parts[i+3]);
                    m.date = Convert.ToDateTime(parts[i+4]);
                }
            }
        }

        // ---- API EndPoints ----
        public IActionResult Index()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        [Route("api/sendMessage/{message}/{author}/{color}/{server}")]
        public void SendMessage(string message, string author, string color, string server) {
            manager.Manage();
            Console.WriteLine($"[#{server}] {author}: {message}");
            if (!messages.ContainsKey(server))
                messages[server] = new List<Message>();
            messages[server].Add(new Message(){
                author=author,
                message=message,
                color=Convert.ToUInt16(color),
                server=server,
                date=DateTime.Now,
            });
        }

        [HttpGet]
        [Route("api/getServer/{server}")]
        public List<Message> GetServer(string server) {
            if (server != null && messages.ContainsKey(server))
                return messages[server];
            else
                return new List<Message>();
        }
    }
}
